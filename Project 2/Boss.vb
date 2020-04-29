Public Class frmBoss
    Public pbHP As Single
    Public pbHPCap As Single
    Public pbDMG As Single

    Private Sub frmBoss_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmUpgrades.TabControl.TabPages(1).Enabled = False
        frmUpgrades.btnBuy.Visible = False
        frmUpgrades.btnRefund.Visible = False
        frmUpgrades.btnSacrifice.Visible = True

        frmMain.DPSTimer.Stop()

        pbDMG = 0

        CoinDownTimer.Start()
    End Sub
    Private Sub CoinDown_Tick(sender As Object, e As EventArgs) Handles CoinDownTimer.Tick
        If frmMain.Data.mdCoins > frmMain.Data.mdLVL ^ 2 Then
            frmMain.Data.mdCoins -= frmMain.Data.mdLVL ^ 2
            frmUpgrades.UpdateCoins(0)
        Else
            frmMain.EndGame()
        End If
        frmUpgrades.SetDesktopLocation(Me.Location.X + Me.Size.Width, Me.Location.Y)
    End Sub

    Private Sub imgCookie_MouseDown(sender As Object, e As EventArgs) Handles imgCookie.MouseDown
        pbHP -= pbDMG
        UpdateHP()
    End Sub

    Public Sub UpdateHP()
        progHP.Value = Math.Max((pbHP / pbHPCap) * 100, 0)
        If pbHP <= 0 Then
            MessageBox.Show("Boss defeated!" & vbNewLine & "You get a $" & pbHPCap & " bonus.")
            frmUpgrades.UpdateCoins(pbHPCap)
            frmUpgrades.listStats.Items.Item(3).SubItems.Item(1).Text = frmUpgrades.GetIntOnly(frmUpgrades.listStats.Items.Item(3).SubItems.Item(1).Text) + 1
            frmMain.Show()
            frmMain.DPSTimer.Start()
            frmUpgrades.TabControl.TabPages(1).Enabled = True
            frmUpgrades.btnBuy.Visible = True
            frmUpgrades.btnRefund.Visible = True
            frmUpgrades.btnSacrifice.Visible = False
            Me.Dispose()
        End If
    End Sub

    Private Sub frmBoss_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        MessageBox.Show("Not a good time!")
    End Sub
End Class