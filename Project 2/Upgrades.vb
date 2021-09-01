Imports System.Text.RegularExpressions

Public Class frmUpgrades
    Public Class Stat
        Public Name As String
        Public Value As UInt32
        Public Format As String
        Public Overrides Function ToString() As String
            If Format = "$" Then
                Return FormatMoney(Value)
            End If
            Return String.Format(Format, Value)
        End Function
    End Class

    Public Enum StatsIndex As Byte
        upgradepurchases
        cookieclicks
        cashgen
        cashspent
        cookiekills
        bosskills
        dmg
        dps
        timeplayed
    End Enum

    Public Stats = New List(Of Stat) From {
        New Stat With {.Name = "Upgrades Purchased", .Format = "{0}"},
        New Stat With {.Name = "Cookies Clicked", .Format = "{0}"},
        New Stat With {.Name = "Cash Earned", .Format = "$"},
        New Stat With {.Name = "Cash Spent", .Format = "$"},
        New Stat With {.Name = "Defeated Cookies", .Format = "{0}"},
        New Stat With {.Name = "Defeated Boss Cookies", .Format = "{0}"},
        New Stat With {.Name = "Cursor Damage (DMG)", .Format = "{0}/click"},
        New Stat With {.Name = "Passive Damage (DPS)", .Format = "{0}/s"},
        New Stat With {.Name = "Time Played", .Format = "{0} seconds"}
    }

    Public Enum UpgradeTypes As Byte
        Active
        Passive
    End Enum

    Public Class Upgrade
        Public Id As String
        Public Name As String
        Public Description As String
        Public Type As UpgradeTypes
        Public Power As Byte
        Public Quantity As UInt16
        Public BasePrice As UInt16
        Public Function Price() As UInt32
            Return Math.Round(BasePrice * (1.25 ^ Quantity))
        End Function
        Public Overrides Function ToString() As String
            Return "+" & Power & " " & If(Type = UpgradeTypes.Active, "DPS", "DMG")
        End Function
    End Class

    Public Upgrades = New List(Of Upgrade) From {
        New Upgrade With {.Id = "bigcursor",
                          .Name = "Bigger Cursor",
                          .Description = "Increases the size of the cursor, making each click more effective.",
                          .Type = UpgradeTypes.Active,
                          .Power = 1,
                          .BasePrice = 20},
        New Upgrade With {.Id = "sharpteeth",
                          .Name = "Sharper Teeth",
                          .Description = "Bite through cookies like they're nothing.",
                          .Type = UpgradeTypes.Active,
                          .Power = 10,
                          .BasePrice = 180},
        New Upgrade With {.Id = "lipo",
                          .Name = "Liposuction",
                          .Description = "Eat even more cookies without the guilt.",
                          .Type = UpgradeTypes.Active,
                          .Power = 25,
                          .BasePrice = 300},
        New Upgrade With {.Id = "unhinged",
                          .Name = "Unhinged Jaw",
                          .Description = "Fit even more cookies in your mouth at a time, drastically improving efficiency.",
                          .Type = UpgradeTypes.Active,
                          .Power = 100,
                          .BasePrice = 2500},
        New Upgrade With {.Id = "autoclick",
                          .Name = "Auto Clickers",
                          .Description = "Sit back and watch these mice click for you precicely once every second.",
                          .Type = UpgradeTypes.Passive,
                          .Power = 1,
                          .BasePrice = 100},
        New Upgrade With {.Id = "bakery",
                          .Name = "Cookie Bakers",
                          .Description = "Bakers join the fight against the monsters they've created. (Spawn kill bonus included)",
                          .Type = UpgradeTypes.Passive,
                          .Power = 5,
                          .BasePrice = 500},
        New Upgrade With {.Id = "factory",
                          .Name = "Cookie Factory",
                          .Description = "Factory workers have more hours and less pay than bakers, making them a more efficient option with a greater cost.",
                          .Type = UpgradeTypes.Passive,
                          .Power = 50,
                          .BasePrice = 3500},
        New Upgrade With {.Id = "nuke",
                          .Name = "Cookie Nuke",
                          .Description = "Nuclear weapons and their fallout will consistently make it harder for cookies to survive.",
                          .Type = UpgradeTypes.Passive,
                          .Power = 100,
                          .BasePrice = 8000}
    }

    Private Sub frmUpgrades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listUpgrades.Items.Clear()
        Dim i = 0
        For Each upgrade As Upgrade In Upgrades
            upgrade.Quantity = frmMain.State.Upgrades(i)
            listUpgrades.Items.Add(New ListViewItem With {.ImageIndex = i,
                                                          .Group = listUpgrades.Groups(upgrade.Type)})
            listUpgrades.Items(i).SubItems.Add(New ListViewItem.ListViewSubItem With {.Text = upgrade.Name})
            listUpgrades.Items(i).SubItems.Add(New ListViewItem.ListViewSubItem With {.Text = upgrade.Quantity})
            listUpgrades.Items(i).SubItems.Add(New ListViewItem.ListViewSubItem With {.Text = FormatMoney(upgrade.Price())})
            listUpgrades.Items(i).SubItems.Add(New ListViewItem.ListViewSubItem With {.Text = upgrade.ToString()})
            i += 1
        Next

        listStats.Items.Clear()
        i = 0
        For Each stat As Stat In Stats
            stat.Value = frmMain.State.Stats(i)
            listStats.Items.Add(New ListViewItem With {.Text = stat.Name})
            listStats.Items(i).SubItems.Add(New ListViewItem.ListViewSubItem With {.Text = stat.ToString()})
            i += 1
        Next
    End Sub

    Private Sub listUpgrades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listUpgrades.SelectedIndexChanged
        UpdateDisplay()
    End Sub

    Private Sub btnBuy_Click(sender As Object, e As EventArgs) Handles btnBuy.Click
        Dim upgrade = Upgrades(listUpgrades.SelectedItems(0).Index)

        frmMain.State.PlayerCoins -= upgrade.Price()
        frmMain.State.Stats(StatsIndex.cashspent) += upgrade.Price()
        frmMain.State.Upgrades(listUpgrades.SelectedItems(0).Index) += 1

        If upgrade.Type = UpgradeTypes.Active Then
            frmMain.State.PlayerDMG += upgrade.Power
        Else
            frmMain.State.PlayerDPS += upgrade.Power
        End If
        frmMain.State.Stats(StatsIndex.upgradepurchases) += 1
        UpdateDisplay()
    End Sub

    Private Sub btnRefund_Click(sender As Object, e As EventArgs) Handles btnRefund.Click
        Dim upgrade = Upgrades(listUpgrades.SelectedItems(0).Index)

        upgrade.Quantity -= 1
        frmMain.State.Upgrades(listUpgrades.SelectedItems(0).Index) -= 1
        frmMain.State.PlayerCoins += upgrade.Price() / 2
        If Upgrade.Type = UpgradeTypes.Active Then
            frmMain.State.PlayerDMG -= upgrade.Power
        Else
            frmMain.State.PlayerDPS -= upgrade.Power
        End If
        UpdateDisplay()
    End Sub

    Private Sub btnSacrifice_Click(sender As Object, e As EventArgs) Handles btnSacrifice.Click
        Dim upgrade = Upgrades(listUpgrades.SelectedItems(0).Index)

        upgrade.Quantity -= 1
        frmMain.State.Upgrades(listUpgrades.SelectedItems(0).Index) -= 1
        If upgrade.Type = UpgradeTypes.Active Then
            frmMain.State.PlayerDMG -= upgrade.Power
        Else
            frmMain.State.PlayerDPS -= upgrade.Power
        End If

        frmBoss.PlayerBossDMG += Math.Round(upgrade.Price() * 1.09, 0)
        frmBoss.lblBossDMG.Text = frmBoss.PlayerBossDMG & " Boss DMG"

        UpdateDisplay()
        btnBegin.Enabled = True
    End Sub

    Private Sub btnBegin_Click(sender As Object, e As EventArgs) Handles btnBegin.Click
        frmBoss.CoinDrainTimer.Start()
        frmBoss.imgCookie.Enabled = True
        btnBegin.Visible = False
    End Sub

    Public Sub UpdateDisplay()
        ' Coins, DMG and DPS labels
        lblDMG.Text = frmMain.State.PlayerDMG & " DMG"
        frmMain.State.Stats(StatsIndex.dmg) = frmMain.State.PlayerDMG
        lblDPS.Text = frmMain.State.PlayerDPS & " DPS"
        frmMain.State.Stats(StatsIndex.dps) = frmMain.State.PlayerDPS
        lblCoins.Text = FormatMoney(frmMain.State.PlayerCoins)

        ' Upgrade quantities and prices
        For Each item As ListViewItem In listUpgrades.Items
            Dim upgrade = Upgrades(item.Index)
            If Not frmMain.State.Upgrades(item.Index) = upgrade.Quantity Then
                upgrade.Quantity = frmMain.State.Upgrades(item.Index)
                item.SubItems(2).Text = upgrade.Quantity
                item.SubItems(3).Text = FormatMoney(upgrade.Price())
            End If
        Next

        ' Stats and autosave information
        For Each item As ListViewItem In listStats.Items
            Dim stat = Stats(item.Index)
            If Not frmMain.State.Stats(item.Index) = stat.Value Then
                stat.Value = frmMain.State.Stats(item.Index)
                item.SubItems(1).Text = stat.ToString()
            End If
        Next
        If frmMain.State.AutoSave Then
            Dim timestamp = My.Computer.FileSystem.GetFileInfo(frmMain.FileAutoSave).LastWriteTime()
            lblAutoSave.Text = "Last Saved " & Math.Round(Now.Subtract(timestamp).TotalSeconds) & " seconds ago."
        Else
            lblAutoSave.Text = "Disabled (enable in File menu)"
        End If

        ' Upgrade buttons and description label
        If listUpgrades.SelectedItems.Count = 0 Then
            lblDescription.Text = "Select an upgrade for more information."
            btnBuy.Text = "Buy"
            btnBuy.Enabled = False
            btnRefund.Text = "Refund"
            btnRefund.Enabled = False
            btnSacrifice.Enabled = False
        Else
            Dim item = listUpgrades.SelectedItems(0)
            Dim upgrade = Upgrades(item.Index)
            lblDescription.Text = upgrade.Description
            btnBuy.Text = "Buy " & FormatMoney(upgrade.Price())
            btnBuy.Enabled = upgrade.Price() <= frmMain.State.PlayerCoins
            btnRefund.Text = "Refund " & FormatMoney(Math.Round(upgrade.Price() / 1.25 / 2))
            btnRefund.Enabled = upgrade.Quantity > 0
            btnSacrifice.Enabled = upgrade.Quantity > 0
        End If
    End Sub

    Private Sub btnAddCoins_Click(sender As Object, e As EventArgs) Handles btnAddCoins.Click
        frmMain.State.PlayerCoins += numAddCoins.Value
        frmMain.State.Stats(StatsIndex.cashgen) += numAddCoins.Value
        UpdateDisplay()
    End Sub

    Private Sub btnTakeCoins_Click(sender As Object, e As EventArgs) Handles btnTakeCoins.Click
        frmMain.State.PlayerCoins -= numAddCoins.Value
        frmMain.State.Stats(StatsIndex.cashspent) += numAddCoins.Value
        UpdateDisplay()
    End Sub

    Private Sub btnAddDPS_Click(sender As Object, e As EventArgs) Handles btnAddDPS.Click
        frmMain.State.PlayerDPS += numAddDPS.Value
        UpdateDisplay()
    End Sub

    Private Sub btnTakeDPS_Click(sender As Object, e As EventArgs) Handles btnTakeDPS.Click
        frmMain.State.PlayerDPS -= numAddDPS.Value
        UpdateDisplay()
    End Sub

    Private Sub btnAddDMG_Click(sender As Object, e As EventArgs) Handles btnAddDMG.Click
        frmMain.State.PlayerDMG += numAddDMG.Value
        UpdateDisplay()
    End Sub

    Private Sub btnTakeDMG_Click(sender As Object, e As EventArgs) Handles btnTakeDMG.Click
        frmMain.State.PlayerDMG -= numAddDMG.Value
        UpdateDisplay()
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

    Public Shared Function GetIntOnly(ByVal value As String) As UInt32
        Dim lcReturnVal As String = "0"
        Dim lcCollection As MatchCollection = Regex.Matches(value, "\d+")
        For Each m As Match In lcCollection
            lcReturnVal += m.ToString()
        Next
        Return Convert.ToInt32(lcReturnVal)
    End Function

    Public Shared Function FormatMoney(money As UInt64) As String
        Dim fmoney As String
        If money >= 1_000_000_000_000_000_000 Then
            fmoney = (money / 1_000_000_000_000_000_000).ToString("N1") & "Qui"
        ElseIf money >= 1_000_000_000_000_000 Then
            fmoney = (money / 1_000_000_000_000_000).ToString("N1") & "Qua"
        ElseIf money >= 1_000_000_000_000 Then
            fmoney = (money / 1_000_000_000_000).ToString("N1") & "Tri"
        ElseIf money >= 1_000_000_000 Then
            fmoney = (money / 1_000_000_000).ToString("N1") & "Bi"
        ElseIf money >= 1_000_000 Then
            fmoney = (money / 1_000_000).ToString("N1") & "Mi"
        Else
            fmoney = money.ToString("N0")
        End If
        Return "$" & fmoney
    End Function

    Private Sub frmUpgrades_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        frmMain.btnHSUpgrades.Text = ">>"
        Hide()
    End Sub

    Private Sub linkAutoSave_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkAutoSave.LinkClicked
        System.Diagnostics.Process.Start(frmMain.FileAutoSave.Substring(0, frmMain.FileAutoSave.Length() - 10))
    End Sub
End Class