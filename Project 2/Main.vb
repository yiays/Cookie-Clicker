Public Class frmMain
    <Serializable()>
    Public Structure GameState
        Dim Version As Byte
        Dim CookieHP As UInt32
        Dim CookieMaxHP As UInt32
        Dim PlayerXP As UInt32
        Dim PlayerLVL As UInt16
        Dim PlayerDMG As UInt32
        Dim PlayerDPS As UInt32
        Dim PlayerCoins As UInt32

        Dim Upgrades As List(Of UInt16)
        Dim Stats As List(Of UInt32)

        Dim BossPrompted As Boolean
        Dim AutoSave As Boolean
    End Structure

    Public ReadOnly StateVer As Byte = 4
    Public State As GameState
    Private locappdata As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
    Public FileAutoSave As String = locappdata & "\Cookie.Clicker\cookie.sav"

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Reset()

        If locappdata.Length() Then
            My.Computer.FileSystem.CreateDirectory(locappdata & "\Cookie.Clicker")
            If My.Computer.FileSystem.FileExists(FileAutoSave) Then
                LoadGame(FileAutoSave)
                UpdateAll()
            End If
        End If

        frmUpgrades.Show()
        frmUpgrades.SetDesktopLocation(Me.Location.X + Me.Size.Width, Me.Location.Y)

        If State.PlayerLVL = 1 Then
            HelpToolStripMenuItem1_Click(Nothing, Nothing)
        End If

        DPSTimer.Start()
    End Sub

    Public Sub Reset()
        State = New GameState() With {
            .Version = StateVer,
            .CookieHP = 5,
            .CookieMaxHP = 5,
            .PlayerXP = 0,
            .PlayerLVL = 1,
            .PlayerDMG = 1,
            .PlayerDPS = 0,
            .PlayerCoins = 0,
            .Upgrades = New List(Of UInt16),
            .Stats = New List(Of UInt32),
            .BossPrompted = False,
            .AutoSave = True
        }

        For Each upgrade In frmUpgrades.Upgrades
            State.Upgrades.Add(0)
        Next

        For Each stat In frmUpgrades.Stats
            State.Stats.Add(0)
        Next

        UpdateAll()
    End Sub

    Private Sub SaveGame(Path As String)
        Dim lcMyBinaryFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim lcMyContainer As New System.IO.MemoryStream()
        lcMyBinaryFormatter.Serialize(lcMyContainer, State)
        My.Computer.FileSystem.WriteAllBytes(Path, lcMyContainer.GetBuffer(), False)
    End Sub

    Private Sub LoadGame(Path As String)
        Dim lcMyBinaryFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim lcMyContainer As New System.IO.MemoryStream()
        Dim lcBytes As Byte() = My.Computer.FileSystem.ReadAllBytes(Path)
        Dim NewState As GameState = lcMyBinaryFormatter.Deserialize(New System.IO.MemoryStream(lcBytes))

        If Not NewState.Version = StateVer Then
            Dim result As DialogResult = MessageBox.Show(
                "The save data just loaded appears to be from an older version of the game, this may have unintended consequences. Continue?",
                "Warning",
                MessageBoxButtons.YesNo
            )
            If result = DialogResult.Yes Then
                NewState.Version = StateVer
                State = NewState
            End If
        Else
            State = NewState
        End If
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

        State.Stats(frmUpgrades.StatsIndex.timeplayed) += 1
        frmUpgrades.UpdateDisplay()

        If frmUpgrades.Visible Then
            frmUpgrades.SetDesktopLocation(Me.Location.X + Me.Size.Width, Me.Location.Y)
        End If
    End Sub

    Private Sub imgCookie_MouseDown(sender As Object, e As EventArgs) Handles imgCookie.MouseDown
        State.Stats(frmUpgrades.StatsIndex.cookieclicks) += 1

        If State.CookieHP > State.PlayerDMG Then
            State.CookieHP -= State.PlayerDMG
        Else
            State.CookieHP = 0
        End If
        UpdateHP()
    End Sub

    Private Sub UpdateAll()
        UpdateHP()
        UpdateXP()
        UpdateLVL()
        menuAutoSaveToggle.Checked = State.AutoSave
        frmUpgrades.UpdateDisplay()
    End Sub

    Public Sub UpdateHP()
        If State.CookieHP = 0 Then
            State.PlayerXP += State.CookieMaxHP
            State.CookieHP = State.PlayerLVL ^ 2 * 5
            State.CookieMaxHP = State.CookieHP
            State.PlayerCoins += State.PlayerLVL * 10
            State.Stats(frmUpgrades.StatsIndex.cashgen) += State.PlayerLVL * 10
            frmUpgrades.UpdateDisplay()
            State.Stats(frmUpgrades.StatsIndex.cookiekills) += 1
            UpdateXP()
        End If

        Dim mdHPx = State.CookieHP / State.CookieMaxHP

        If mdHPx > 0.91 Then
            imgCookie.Image = My.Resources.cookie_0
        ElseIf mdHPx > 0.82 Then
            imgCookie.Image = My.Resources.cookie_1
        ElseIf mdHPx > 0.73 Then
            imgCookie.Image = My.Resources.cookie_2
        ElseIf mdHPx > 0.64 Then
            imgCookie.Image = My.Resources.cookie_3
        ElseIf mdHPx > 0.55 Then
            imgCookie.Image = My.Resources.cookie_4
        ElseIf mdHPx > 0.46 Then
            imgCookie.Image = My.Resources.cookie_5
        ElseIf mdHPx > 0.37 Then
            imgCookie.Image = My.Resources.cookie_6
        ElseIf mdHPx > 0.28 Then
            imgCookie.Image = My.Resources.cookie_7
        ElseIf mdHPx > 0.19 Then
            imgCookie.Image = My.Resources.cookie_8
        ElseIf mdHPx > 0.1 Then
            imgCookie.Image = My.Resources.cookie_9
        Else
            imgCookie.Image = My.Resources.cookie_10
        End If

        progHP.Value = (State.CookieHP / State.CookieMaxHP) * 500
    End Sub

    Private Sub UpdateXP()
        If State.PlayerXP >= State.PlayerLVL ^ 2 * 50 Then
            State.PlayerLVL += 1
            State.PlayerXP = 0
            UpdateLVL()
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

    Private Sub UpdateLVL()
        lblLVL.Text = "Level " & State.PlayerLVL
        If locappdata.Length() And State.AutoSave And State.PlayerLVL > 1 And (State.PlayerLVL Mod 5) > 0 Then
            SaveGame(FileAutoSave)
        End If
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        EndGame()
    End Sub

    Public Sub EndGame()
        frmBoss.Dispose()
        frmUpgrades.UpdateDisplay()

        Dim timestamp = My.Computer.FileSystem.GetFileInfo(FileAutoSave).LastWriteTime()
        If State.PlayerCoins > 0 And Now.Subtract(timestamp).TotalSeconds > 10 Then
            Dim result As DialogResult = MessageBox.Show(
                "Do you want to save your game before quitting?",
                "Warning",
                MessageBoxButtons.YesNo
            )
            If result = DialogResult.Yes Then
                If State.AutoSave Then
                    SaveGame(FileAutoSave)
                Else
                    SaveToolStripMenuItem_Click(Nothing, Nothing)
                End If
            End If
        End If

        frmEndGame.Show()
        frmEndGame.SetDesktopLocation(Me.Location.X, Me.Location.Y)
        frmEndGame.Init()
        frmUpgrades.Dispose()
        Hide()
        DPSTimer.Stop()
    End Sub

    Private Sub SaveFileSelected(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        SaveGame(SaveFileDialog1.FileName)
    End Sub

    Private Sub LoadFileSelected(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        LoadGame(OpenFileDialog1.FileName)
        State.AutoSave = False
        UpdateAll()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub LoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        Reset()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        EndGame()
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
        MessageBox.Show(
            "Click on the cookie to reduce its health." & vbCrLf &
            "Destroying cookies increases your XP which brings you closer to leveling up, every 5 levels you will need to fight a boss cookie, which drains your Coins until you die of poverty." & vbCrLf &
            "Be sure to save up some disposable upgrades to sacrifice for the boss fights." & vbCrLf & vbCrLf &
            "Good luck."
        )
    End Sub

    Private Sub GitHubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GitHubToolStripMenuItem.Click
        System.Diagnostics.Process.Start("https://github.com/yiays/Cookie-Clicker/")
    End Sub

    Private Sub menuAutoSaveToggle_Click(sender As Object, e As EventArgs) Handles menuAutoSaveToggle.Click
        State.AutoSave = menuAutoSaveToggle.Checked
        frmUpgrades.UpdateDisplay()
    End Sub
End Class
