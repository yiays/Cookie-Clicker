Imports System.Text.RegularExpressions

Public Class frmUpgrades
    Private Sub listUpgrades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listUpgrades.SelectedIndexChanged
        For Each item In listUpgrades.SelectedItems
            lblDescription.Text = item.ToolTipText
            btnSacrifice.Enabled = GetIntOnly(item.SubItems.Item(2).Text) > 0
        Next
        If listUpgrades.SelectedItems.Count = 0 Then
            lblDescription.Text = "Select an upgrade for more information."
        End If
        UpdateCoins(0)
    End Sub

    Private Sub btnBuy_Click(sender As Object, e As EventArgs) Handles btnBuy.Click
        For Each item In listUpgrades.SelectedItems
            UpdateCoins(0 - GetIntOnly(item.SubItems.Item(3).Text))
            item.SubItems.Item(3).Text = "$" & Math.Round(GetIntOnly(item.SubItems.Item(3).Text) * 1.25)
            item.SubItems.Item(2).Text = GetIntOnly(item.SubItems.Item(2).Text) + 1
            If item.Group.Equals(listUpgrades.Groups.Item(0)) Then
                frmMain.Data.mdDMG += GetIntOnly(item.SubItems.Item(4).Text)
                UpdateDMG()
            Else
                frmMain.Data.mdDPS += GetIntOnly(item.SubItems.Item(4).Text)
                UpdateDPS()
            End If
            listStats.Items.Item(0).SubItems.Item(1).Text = GetIntOnly(listStats.Items.Item(0).SubItems.Item(1).Text) + 1
        Next
    End Sub

    Private Sub btnRefund_Click(sender As Object, e As EventArgs) Handles btnRefund.Click
        For Each item In listUpgrades.SelectedItems
            UpdateCoins(GetIntOnly(item.SubItems.Item(3).Text) / 1.25 / 2)
            item.SubItems.Item(3).Text = "$" & Math.Round(GetIntOnly(item.SubItems.Item(3).Text) / 1.25)
            item.SubItems.Item(2).Text = GetIntOnly(item.SubItems.Item(2).Text) - 1
            If item.Group.Equals(listUpgrades.Groups.Item(0)) Then
                frmMain.Data.mdDMG -= GetIntOnly(item.SubItems.Item(4).Text)
                UpdateDMG()
            Else
                frmMain.Data.mdDPS -= GetIntOnly(item.SubItems.Item(4).Text)
                UpdateDPS()
            End If
        Next
    End Sub

    Private Sub btnSacrifice_Click(sender As Object, e As EventArgs) Handles btnSacrifice.Click
        For Each item In listUpgrades.SelectedItems
            item.SubItems.Item(3).Text = "$" & Math.Round(GetIntOnly(item.SubItems.Item(3).Text) / 1.25)
            item.SubItems.Item(2).Text = GetIntOnly(item.SubItems.Item(2).Text) - 1
            If item.Group.Equals(listUpgrades.Groups.Item(0)) Then
                frmMain.Data.mdDMG -= GetIntOnly(item.SubItems.Item(4).Text)
                UpdateDMG()
            Else
                frmMain.Data.mdDPS -= GetIntOnly(item.SubItems.Item(4).Text)
                UpdateDPS()
            End If
            frmBoss.pbDMG += Math.Round(GetIntOnly(item.SubItems.Item(3).Text) * 1.09, 2)
            frmBoss.lblBossDMG.Text = frmBoss.pbDMG & " Boss DMG"
        Next
    End Sub

    Public Function UpdateCoins(amnt)
        frmMain.Data.mdCoins += amnt
        lblCoins.Text = "$" & frmMain.Data.mdCoins
        If amnt > 0 Then
            listStats.Items.Item(2).SubItems.Item(1).Text =
                "$" & GetIntOnly(listStats.Items.Item(2).SubItems.Item(1).Text) + amnt
        End If
        For Each item In listUpgrades.SelectedItems
            btnBuy.Text = "Buy " & item.SubItems.Item(3).Text
            btnBuy.Enabled = GetIntOnly(item.SubItems.Item(3).Text) <= frmMain.Data.mdCoins
            btnRefund.Text = "Refund $" & GetIntOnly(item.SubItems.Item(3).Text) / 1.25 / 2
            btnRefund.Enabled = item.SubItems.Item(2).Text > 0
        Next
        If listUpgrades.SelectedItems.Count = 0 Then
            btnBuy.Text = "Buy"
            btnBuy.Enabled = False
            btnRefund.Text = "Refund"
            btnRefund.Enabled = False
        End If

        Return frmMain.Data.mdCoins
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
        lblDPS.Text = frmMain.Data.mdDPS & " DPS"
        listStats.Items.Item(5).SubItems.Item(1).Text = frmMain.Data.mdDPS
    End Sub

    Public Sub UpdateDMG()
        lblDMG.Text = frmMain.Data.mdDMG & " DMG"
        listStats.Items.Item(4).SubItems.Item(1).Text = frmMain.Data.mdDMG
    End Sub

    Private Sub btnAddCoins_Click(sender As Object, e As EventArgs) Handles btnAddCoins.Click
        UpdateCoins(numAddCoins.Value)
    End Sub

    Private Sub btnTakeCoins_Click(sender As Object, e As EventArgs) Handles btnTakeCoins.Click
        UpdateCoins(0 - numAddCoins.Value)
    End Sub

    Private Sub btnAddDPS_Click(sender As Object, e As EventArgs) Handles btnAddDPS.Click
        frmMain.Data.mdDPS += numAddDPS.Value
        UpdateDPS()
    End Sub

    Private Sub btnTakeDPS_Click(sender As Object, e As EventArgs) Handles btnTakeDPS.Click
        frmMain.Data.mdDPS -= numAddDPS.Value
        UpdateDPS()
    End Sub

    Private Sub btnAddDMG_Click(sender As Object, e As EventArgs) Handles btnAddDMG.Click
        frmMain.Data.mdDMG += numAddDMG.Value
        UpdateDMG()
    End Sub

    Private Sub btnTakeDMG_Click(sender As Object, e As EventArgs) Handles btnTakeDMG.Click
        frmMain.Data.mdDMG -= numAddDMG.Value
        UpdateDMG()
    End Sub

    Private Sub btnInstakill_Click(sender As Object, e As EventArgs) Handles btnInstakill.Click
        frmMain.Data.mdHP = 0
        frmMain.UpdateHP()
    End Sub

    Private Sub btnHealCookie_Click(sender As Object, e As EventArgs) Handles btnHealCookie.Click
        frmMain.Data.mdHP = frmMain.Data.mdHPcap
        frmMain.UpdateHP()
    End Sub

    Private Sub btnLvlDown_Click(sender As Object, e As EventArgs) Handles btnLvlDown.Click
        frmMain.Data.mdLVL = Math.Max(frmMain.Data.mdLVL - 1, 1)
        frmMain.Data.mdXP = 0
        frmMain.lblLVL.Text = "Level " & frmMain.Data.mdLVL
    End Sub

    Private Sub btnLvlUp_Click(sender As Object, e As EventArgs) Handles btnLvlUp.Click
        frmMain.Data.mdLVL += 1
        frmMain.Data.mdXP = 0
        frmMain.lblLVL.Text = "Level " & frmMain.Data.mdLVL
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