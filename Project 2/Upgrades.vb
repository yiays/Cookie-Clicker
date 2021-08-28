Imports System.Text.RegularExpressions

Public Class frmUpgrades
    Private Sub listUpgrades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listUpgrades.SelectedIndexChanged
        If listUpgrades.SelectedItems.Count = 0 Then
            lblDescription.Text = "Select an upgrade for more information."
        Else
            Dim item = listUpgrades.SelectedItems(0)

            lblDescription.Text = item.ToolTipText
        End If
        UpdateDisplay()
    End Sub

    Private Sub btnBuy_Click(sender As Object, e As EventArgs) Handles btnBuy.Click
        Dim item = listUpgrades.SelectedItems(0)

        AddCoins(0 - GetIntOnly(item.SubItems.Item(3).Text))
        item.SubItems.Item(3).Text = "$" & Math.Round(GetIntOnly(item.SubItems.Item(3).Text) * 1.25)
        item.SubItems.Item(2).Text = GetIntOnly(item.SubItems.Item(2).Text) + 1
        UpdateDisplay()
        If item.Group.Equals(listUpgrades.Groups.Item(0)) Then
            frmMain.State.PlayerDMG += GetIntOnly(item.SubItems.Item(4).Text)
            UpdateDMG()
        Else
            frmMain.State.PlayerDPS += GetIntOnly(item.SubItems.Item(4).Text)
            UpdateDPS()
        End If
        listStats.Items.Item(0).SubItems.Item(1).Text = GetIntOnly(listStats.Items.Item(0).SubItems.Item(1).Text) + 1
    End Sub

    Private Sub btnRefund_Click(sender As Object, e As EventArgs) Handles btnRefund.Click
        Dim item = listUpgrades.SelectedItems(0)

        AddCoins(GetIntOnly(item.SubItems.Item(3).Text) / 1.25 / 2)
        item.SubItems.Item(3).Text = "$" & Math.Round(GetIntOnly(item.SubItems.Item(3).Text) / 1.25)
        item.SubItems.Item(2).Text = GetIntOnly(item.SubItems.Item(2).Text) - 1
        UpdateDisplay()
        If item.Group.Equals(listUpgrades.Groups.Item(0)) Then
            frmMain.State.PlayerDMG -= GetIntOnly(item.SubItems.Item(4).Text)
            UpdateDMG()
        Else
            frmMain.State.PlayerDPS -= GetIntOnly(item.SubItems.Item(4).Text)
            UpdateDPS()
        End If
    End Sub

    Private Sub btnSacrifice_Click(sender As Object, e As EventArgs) Handles btnSacrifice.Click
        Dim item = listUpgrades.SelectedItems(0)

        item.SubItems.Item(3).Text = "$" & Math.Round(GetIntOnly(item.SubItems.Item(3).Text) / 1.25)
        item.SubItems.Item(2).Text = GetIntOnly(item.SubItems.Item(2).Text) - 1
        If item.Group.Equals(listUpgrades.Groups.Item(0)) Then
            frmMain.State.PlayerDMG -= GetIntOnly(item.SubItems.Item(4).Text)
            UpdateDMG()
        Else
            frmMain.State.PlayerDPS -= GetIntOnly(item.SubItems.Item(4).Text)
            UpdateDPS()
        End If
        frmBoss.PlayerBossDMG += Math.Round(GetIntOnly(item.SubItems.Item(3).Text) * 1.09, 0)
        frmBoss.lblBossDMG.Text = frmBoss.PlayerBossDMG & " Boss DMG"

        btnSacrifice.Enabled = GetIntOnly(item.SubItems.Item(2).Text) > 0
        btnBegin.Enabled = True
    End Sub

    Private Sub btnBegin_Click(sender As Object, e As EventArgs) Handles btnBegin.Click
        frmBoss.CoinDrainTimer.Start()
        frmBoss.imgCookie.Enabled = True
        btnBegin.Visible = False
    End Sub

    Public Function AddCoins(amnt)
        frmMain.State.PlayerCoins += amnt
        lblCoins.Text = "$" & frmMain.State.PlayerCoins
        If amnt > 0 Then
            listStats.Items.Item(2).SubItems.Item(1).Text =
                "$" & GetIntOnly(listStats.Items.Item(2).SubItems.Item(1).Text) + amnt
        End If
    End Function

    Public Function UpdateDisplay()
        If listUpgrades.SelectedItems.Count = 0 Then
            btnBuy.Text = "Buy"
            btnBuy.Enabled = False
            btnRefund.Text = "Refund"
            btnRefund.Enabled = False
            btnSacrifice.Enabled = False
        Else
            Dim item = listUpgrades.SelectedItems(0)
            btnBuy.Text = "Buy " & item.SubItems.Item(3).Text
            btnBuy.Enabled = GetIntOnly(item.SubItems.Item(3).Text) <= frmMain.State.PlayerCoins
            btnRefund.Text = "Refund $" & GetIntOnly(item.SubItems.Item(3).Text) / 1.25 / 2
            btnRefund.Enabled = item.SubItems.Item(2).Text > 0
            btnSacrifice.Enabled = GetIntOnly(item.SubItems.Item(2).Text) > 0
        End If
    End Function

    Public Function GetUpgrades()
        Dim lcupgradei(listUpgrades.Items.Count, 1) As String
        Dim i As Byte
        i = 0
        For Each item In listUpgrades.Items
            lcupgradei(i, 0) = item.SubItems.Item(2).Text
            lcupgradei(i, 1) = item.SubItems.Item(3).Text
            i += 1
        Next
        Return lcupgradei
    End Function
    Public Function SetUpgrades(lcupgradei(,) As String)
        Dim i As Byte
        i = 0
        For Each item In listUpgrades.Items
            item.SubItems.Item(2).Text = lcupgradei(i, 0)
            item.SubItems.Item(3).Text = lcupgradei(i, 1)
            i += 1
        Next
        Return lcupgradei
    End Function
    Public Function GetStats()
        Dim lcstati(listStats.Items.Count, 1) As String
        Dim i As Byte
        i = 0
        For Each item In listStats.Items
            lcstati(i, 0) = item.SubItems.Item(0).Text
            lcstati(i, 1) = item.SubItems.Item(1).Text
            i += 1
        Next
        Return lcstati
    End Function
    Public Function SetStats(lcstati(,) As String)
        Dim i As Byte
        i = 0
        For Each item In listStats.Items
            item.SubItems.Item(0).Text = lcstati(i, 0)
            item.SubItems.Item(1).Text = lcstati(i, 1)
            i += 1
        Next
        Return lcstati
    End Function

    Public Sub UpdateDPS()
        lblDPS.Text = frmMain.State.PlayerDPS & " DPS"
        listStats.Items.Item(5).SubItems.Item(1).Text = frmMain.State.PlayerDPS
    End Sub

    Public Sub UpdateDMG()
        lblDMG.Text = frmMain.State.PlayerDMG & " DMG"
        listStats.Items.Item(4).SubItems.Item(1).Text = frmMain.State.PlayerDMG
    End Sub

    Private Sub btnAddCoins_Click(sender As Object, e As EventArgs) Handles btnAddCoins.Click
        AddCoins(numAddCoins.Value)
        UpdateDisplay()
    End Sub

    Private Sub btnTakeCoins_Click(sender As Object, e As EventArgs) Handles btnTakeCoins.Click
        AddCoins(0 - numAddCoins.Value)
        UpdateDisplay()
    End Sub

    Private Sub btnAddDPS_Click(sender As Object, e As EventArgs) Handles btnAddDPS.Click
        frmMain.State.PlayerDPS += numAddDPS.Value
        UpdateDPS()
    End Sub

    Private Sub btnTakeDPS_Click(sender As Object, e As EventArgs) Handles btnTakeDPS.Click
        frmMain.State.PlayerDPS -= numAddDPS.Value
        UpdateDPS()
    End Sub

    Private Sub btnAddDMG_Click(sender As Object, e As EventArgs) Handles btnAddDMG.Click
        frmMain.State.PlayerDMG += numAddDMG.Value
        UpdateDMG()
    End Sub

    Private Sub btnTakeDMG_Click(sender As Object, e As EventArgs) Handles btnTakeDMG.Click
        frmMain.State.PlayerDMG -= numAddDMG.Value
        UpdateDMG()
    End Sub

    Private Sub btnInstakill_Click(sender As Object, e As EventArgs) Handles btnInstakill.Click
        frmMain.State.CookieHP = 0
        frmMain.UpdateHP()
    End Sub

    Private Sub btnHealCookie_Click(sender As Object, e As EventArgs) Handles btnHealCookie.Click
        frmMain.State.CookieHP = frmMain.State.CookieMaxHP
        frmMain.UpdateHP()
    End Sub

    Private Sub btnLvlDown_Click(sender As Object, e As EventArgs) Handles btnLvlDown.Click
        frmMain.State.PlayerLVL = Math.Max(frmMain.State.PlayerLVL - 1, 1)
        frmMain.State.PlayerXP = 0
        frmMain.lblLVL.Text = "Level " & frmMain.State.PlayerLVL
    End Sub

    Private Sub btnLvlUp_Click(sender As Object, e As EventArgs) Handles btnLvlUp.Click
        frmMain.State.PlayerLVL += 1
        frmMain.State.PlayerXP = 0
        frmMain.lblLVL.Text = "Level " & frmMain.State.PlayerLVL
    End Sub

    Public Shared Function GetIntOnly(ByVal value As String) As Integer
        Dim lcReturnVal As String = "0"
        Dim lcCollection As MatchCollection = Regex.Matches(value, "\d+")
        For Each m As Match In lcCollection
            lcReturnVal += m.ToString()
        Next
        Return Convert.ToInt32(lcReturnVal)
    End Function

    Private Sub frmUpgrades_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        frmMain.btnHSUpgrades.Text = ">>"
        Me.Hide()
    End Sub
End Class