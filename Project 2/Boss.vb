﻿Public Class frmBoss
    Public BossHP As UInt32
    Public BossMaxHP As UInt32
    Public PlayerBossDMG As UInt32

    Private Sub frmBoss_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmUpgrades.TabControl.TabPages(1).Enabled = False
        frmUpgrades.btnBuy.Visible = False
        frmUpgrades.btnRefund.Visible = False
        frmUpgrades.btnSacrifice.Visible = True
        frmUpgrades.btnBegin.Visible = True
        frmUpgrades.btnBegin.Enabled = False

        frmMain.DPSTimer.Stop()

        PlayerBossDMG = 0

        If Not frmMain.State.BossPrompted Then
            MessageBox.Show("A boss cookie appears! Sacrifice upgrades to build up strength and press 'Begin Fight' to challenge it!")
            frmMain.State.BossPrompted = True
        End If
    End Sub

    Private Sub CoinDown_Tick(sender As Object, e As EventArgs) Handles CoinDrainTimer.Tick
        If frmMain.State.PlayerCoins > frmMain.State.PlayerLVL ^ 2 Then
            frmMain.State.PlayerCoins -= frmMain.State.PlayerLVL ^ 2
            frmUpgrades.UpdateDisplay()
        Else
            frmMain.State.PlayerCoins = 0
            frmMain.EndGame()
        End If
        frmUpgrades.SetDesktopLocation(Me.Location.X + Me.Size.Width, Me.Location.Y)
    End Sub

    Private Sub imgCookie_MouseDown(sender As Object, e As EventArgs) Handles imgCookie.MouseDown
        If BossHP > PlayerBossDMG Then
            BossHP -= PlayerBossDMG
        Else
            BossHP = 0
        End If

        UpdateHP()
    End Sub

    Public Sub UpdateHP()
        progHP.Value = Math.Max((BossHP / BossMaxHP) * 100, 0)
        If BossHP = 0 Then
            Me.CoinDrainTimer.Stop()
            MessageBox.Show("Boss defeated!" & vbNewLine & "You get a " & frmUpgrades.FormatMoney(BossMaxHP) & " bonus.")
            frmMain.State.PlayerCoins += BossMaxHP
            frmMain.State.Stats(frmUpgrades.StatsIndex.cashgen) += BossMaxHP
            frmMain.Show()
            frmMain.State.Stats(frmUpgrades.StatsIndex.bosskills) += 1
            frmMain.DPSTimer.Start()
            frmUpgrades.TabControl.TabPages(1).Enabled = True
            frmUpgrades.btnBuy.Visible = True
            frmUpgrades.btnRefund.Visible = True
            frmUpgrades.btnSacrifice.Visible = False
            frmUpgrades.btnBegin.Visible = False
            frmUpgrades.UpdateDisplay()
            Me.Dispose()
        End If
    End Sub

    Private Sub frmBoss_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        MessageBox.Show("Not a good time!")
    End Sub
End Class