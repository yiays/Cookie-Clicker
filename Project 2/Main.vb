﻿Public Class frmMain
    <Serializable()>
    Public Structure GameState
        Dim CookieHP As UInt32
        Dim CookieMaxHP As UInt32
        Dim PlayerXP As UInt32
        Dim PlayerLVL As UInt32
        Dim PlayerDMG As UInt32
        Dim PlayerDPS As UInt32
        Dim PlayerCoins As Int64

        Dim mdUpgradeStats(,) As String

        Dim mdStats(,) As String

        Dim mdBossPrompted As Boolean
    End Structure

    Public State As GameState

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmUpgrades.Show()
        frmUpgrades.SetDesktopLocation(Me.Location.X + Me.Size.Width, Me.Location.Y)

        State.CookieHP = 5
        State.CookieMaxHP = 5
        State.PlayerXP = 0
        State.PlayerLVL = 1
        State.PlayerDMG = 1
        State.PlayerDPS = 0
        State.PlayerCoins = 0

        State.mdUpgradeStats = frmUpgrades.GetUpgrades()
        State.mdStats = frmUpgrades.GetStats()

        State.mdBossPrompted = False

        UpdateAll()

        HelpToolStripMenuItem1_Click(Nothing, Nothing)

        DPSTimer.Start()
    End Sub

    Private Sub DPSTimer_Tick(sender As Object, e As EventArgs) Handles DPSTimer.Tick
        If State.PlayerDPS > 0 Then
            If State.CookieHP > State.PlayerDPS Then
                State.CookieHP -= State.PlayerDPS
            Else
                State.CookieHP = 0
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
        If State.CookieHP > State.PlayerDMG Then
            State.CookieHP -= State.PlayerDMG
        Else
            State.CookieHP = 0
        End If
        UpdateHP()
    End Sub

    Private Sub UpdateAll()
        ''listUpgrades.Items = Data.Upgrades

        UpdateHP()
        frmUpgrades.UpdateDisplay()
        frmUpgrades.UpdateDPS()
        frmUpgrades.UpdateDMG()
        UpdateXP()

        lblLVL.Text = "Level " & State.PlayerLVL
    End Sub
    Public Sub UpdateHP()
        If State.CookieHP = 0 Then
            State.PlayerXP += State.CookieMaxHP
            State.CookieHP = State.PlayerLVL ^ 2 * 5
            State.CookieMaxHP = State.CookieHP
            frmUpgrades.AddCoins(State.PlayerLVL * 10)
            frmUpgrades.UpdateDisplay()
            frmUpgrades.listStats.Items.Item(3).SubItems.Item(1).Text = frmUpgrades.GetIntOnly(frmUpgrades.listStats.Items.Item(3).SubItems.Item(1).Text) + 1
            UpdateXP()
        End If

        Dim mdHPx = State.CookieHP / State.CookieMaxHP

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

        progHP.Value = (State.CookieHP / State.CookieMaxHP) * 500
    End Sub
    Private Sub UpdateXP()
        If State.PlayerXP >= State.PlayerLVL ^ 2 * 50 Then
            State.PlayerLVL += 1
            State.PlayerXP = 0
            lblLVL.Text = "Level " & State.PlayerLVL
            If State.PlayerLVL Mod 5 = 0 Then
                frmBoss.Show()
                frmBoss.SetDesktopLocation(Me.Location.X, Me.Location.Y)
                frmBoss.BossHP = State.PlayerLVL ^ 2 * 50
                frmBoss.BossMaxHP = State.PlayerLVL ^ 2 * 50
                Me.Hide()
            End If
        End If

        progXP.Value = (State.PlayerXP / (State.PlayerLVL ^ 2 * 50)) * 100
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
        State.mdUpgradeStats = frmUpgrades.GetUpgrades()
        State.mdStats = frmUpgrades.GetStats()
        Dim lcMyBinaryFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim lcMyContainer As New System.IO.MemoryStream()
        lcMyBinaryFormatter.Serialize(lcMyContainer, State)
        My.Computer.FileSystem.WriteAllBytes(SaveFileDialog1.FileName, lcMyContainer.GetBuffer(), False)
    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim lcMyBinaryFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim lcMyContainer As New System.IO.MemoryStream()
        Dim lcBytes As Byte() = My.Computer.FileSystem.ReadAllBytes(OpenFileDialog1.FileName)
        State = DirectCast(lcMyBinaryFormatter.Deserialize(New System.IO.MemoryStream(lcBytes)), GameState)
        frmUpgrades.SetUpgrades(State.mdUpgradeStats)
        frmUpgrades.SetStats(State.mdStats)
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
        MessageBox.Show("Click on the cookie to reduce its health. Destroying cookies increases your XP which brings you closer to leveling up, every 5 levels you will need to fight a boss cookie, which drains your Coins until you die of poverty. Be sure to save up some disposable upgrades to sacrifice for the boss fights. Good luck.")
    End Sub
End Class
