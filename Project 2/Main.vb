Public Class frmMain
    <Serializable()>
    Public Structure DataStruct
        '0 through 65,535 (unsigned)
        Dim mdHP As Short
        Dim mdHPcap As UShort
        Dim mdXP As ULong
        Dim mdLVL As UShort
        Dim mdDMG As UShort
        Dim mdDPS As UShort
        '0 through 4,294,967,295 (unsigned)
        Dim mdCoins As UInteger

        Dim mdUpgradeStats(,) As String

        Dim mdStats(,) As String
    End Structure

    Public Data As DataStruct

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmUpgrades.Show()
        frmUpgrades.SetDesktopLocation(Me.Location.X + Me.Size.Width, Me.Location.Y)

        Data.mdHP = 5
        Data.mdHPcap = 5
        Data.mdXP = 0
        Data.mdLVL = 1
        Data.mdDMG = 1
        Data.mdDPS = 0
        Data.mdCoins = 0

        Data.mdUpgradeStats = frmUpgrades.GetUpgrades()
        Data.mdStats = frmUpgrades.GetStats()

        UpdateAll()

        DPSTimer.Start()
    End Sub

    Private Sub DPSTimer_Tick(sender As Object, e As EventArgs) Handles DPSTimer.Tick
        If Data.mdDPS > 0 Then
            If Data.mdHP - Data.mdDMG >= 0 Then
                Data.mdHP -= Data.mdDPS
            Else
                Data.mdHP = 0
            End If
            UpdateHP()
        End If

        frmUpgrades.listStats.Items.Item(6).SubItems.Item(1).Text =
            Convert.ToDateTime(frmUpgrades.listStats.Items.Item(6).SubItems.Item(1).Text).AddSeconds(1).ToString("HH:mm:ss")

        If Me.Visible Then
            frmUpgrades.SetDesktopLocation(Me.Location.X + Me.Size.Width, Me.Location.Y)
        End If
    End Sub

    Private Sub imgCookie_MouseDown(sender As Object, e As EventArgs) Handles imgCookie.MouseDown
        frmUpgrades.listStats.Items.Item(1).SubItems.Item(1).Text = frmUpgrades.GetIntOnly(frmUpgrades.listStats.Items.Item(1).SubItems.Item(1).Text) + 1
        If Data.mdHP - Data.mdDMG >= 0 Then
            Data.mdHP -= Data.mdDMG
        Else
            Data.mdHP = 0
        End If
        UpdateHP()
    End Sub

    Private Sub UpdateAll()
        ''listUpgrades.Items = Data.Upgrades

        UpdateHP()
        frmUpgrades.UpdateCoins(0)
        frmUpgrades.UpdateDPS()
        frmUpgrades.UpdateDMG()
        UpdateXP()

        lblLVL.Text = "Level " & Data.mdLVL
    End Sub
    Public Sub UpdateHP()
        If Data.mdHP <= 0 Then
            Data.mdXP += Data.mdHPcap
            Data.mdHP = Data.mdLVL ^ 2 * 5
            Data.mdHPcap = Data.mdHP
            frmUpgrades.UpdateCoins(Data.mdLVL * 10)
            frmUpgrades.listStats.Items.Item(3).SubItems.Item(1).Text = frmUpgrades.GetIntOnly(frmUpgrades.listStats.Items.Item(3).SubItems.Item(1).Text) + 1
            UpdateXP()
        End If

        Dim mdHPx = Data.mdHP / Data.mdHPcap

        If mdHPx > 0.91 Then
            imgCookie.Image = Project_2.My.Resources.cookie_0
        ElseIf mdHPx > 0.82 Then
            imgCookie.Image = Project_2.My.Resources.cookie_1
        ElseIf mdHPx > 0.73 Then
            imgCookie.Image = Project_2.My.Resources.cookie_2
        ElseIf mdHPx > 0.64 Then
            imgCookie.Image = Project_2.My.Resources.cookie_3
        ElseIf mdHPx > 0.55 Then
            imgCookie.Image = Project_2.My.Resources.cookie_4
        ElseIf mdHPx > 0.46 Then
            imgCookie.Image = Project_2.My.Resources.cookie_5
        ElseIf mdHPx > 0.37 Then
            imgCookie.Image = Project_2.My.Resources.cookie_6
        ElseIf mdHPx > 0.28 Then
            imgCookie.Image = Project_2.My.Resources.cookie_7
        ElseIf mdHPx > 0.19 Then
            imgCookie.Image = Project_2.My.Resources.cookie_8
        ElseIf mdHPx > 0.1 Then
            imgCookie.Image = Project_2.My.Resources.cookie_9
        Else
            imgCookie.Image = Project_2.My.Resources.cookie_10
        End If

        progHP.Value = (Data.mdHP / Data.mdHPcap) * 500
    End Sub
    Private Sub UpdateXP()
        If Data.mdXP >= Data.mdLVL ^ 2 * 50 Then
            Data.mdLVL += 1
            Data.mdXP = 0
            lblLVL.Text = "Level " & Data.mdLVL
            If Data.mdLVL Mod 5 = 0 Then
                frmBoss.Show()
                frmBoss.SetDesktopLocation(Me.Location.X, Me.Location.Y)
                frmBoss.pbHP = Data.mdLVL ^ 2 * 50
                frmBoss.pbHPCap = Data.mdLVL ^ 2 * 50
                Me.Hide()
                MessageBox.Show("A boss cookie approaches! You need to sacrifice upgrades to be able to do damage to the boss before you run out of coins!")
            End If
        End If

        progXP.Value = (Data.mdXP / (Data.mdLVL ^ 2 * 50)) * 100
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        EndGame()
    End Sub

    Public Sub EndGame()
        frmBoss.Dispose()
        frmEndGame.Show()
        frmEndGame.Init()
        frmUpgrades.Dispose()
        Hide()
        DPSTimer.Stop()
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Data.mdUpgradeStats = frmUpgrades.GetUpgrades()
        Data.mdStats = frmUpgrades.GetStats()
        Dim lcMyBinaryFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim lcMyContainer As New System.IO.MemoryStream()
        lcMyBinaryFormatter.Serialize(lcMyContainer, Data)
        My.Computer.FileSystem.WriteAllBytes(SaveFileDialog1.FileName, lcMyContainer.GetBuffer(), False)
    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim lcMyBinaryFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim lcMyContainer As New System.IO.MemoryStream()
        Dim lcBytes As Byte() = My.Computer.FileSystem.ReadAllBytes(OpenFileDialog1.FileName)
        Data = DirectCast(lcMyBinaryFormatter.Deserialize(New System.IO.MemoryStream(lcBytes)), DataStruct)
        frmUpgrades.SetUpgrades(Data.mdUpgradeStats)
        frmUpgrades.SetStats(Data.mdStats)
        UpdateAll()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
    End Sub
    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        Application.Restart()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub btnHSUpgrades_Click(sender As Object, e As EventArgs) Handles btnHSUpgrades.Click
        If btnHSUpgrades.Text = "<<" Then
            frmUpgrades.Hide()
            btnHSUpgrades.Text = ">>"
        Else
            frmUpgrades.Show()
            btnHSUpgrades.Text = "<<"
        End If
    End Sub

    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.Click
        MessageBox.Show("Click on the cookie to reduce it's health. Killing cookies increases your XP which brings you closer to leveling up, every 5 levels you will need to fight a boss cookie, which drains your Coins until you die of bankruptsy. You have to sacrifice your upgrades you've earned so far in order to make it possible to click on the boss cookie effectively. Good luck.")
    End Sub
End Class
