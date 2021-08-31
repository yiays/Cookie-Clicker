Public Class frmEndGame
    Public Sub Init()
        listEndGameStats.Items.Clear()
        Dim i = 0
        For Each stat As frmUpgrades.Stat In frmUpgrades.Stats
            stat.Value = frmMain.State.Stats(i)
            listEndGameStats.Items.Add(New ListViewItem With {.Text = stat.Name})
            listEndGameStats.Items(i).SubItems.Add(New ListViewItem.ListViewSubItem With {.Text = stat.ToString()})
            i += 1
        Next
    End Sub

    Private Sub frmEndGame_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Environment.Exit(0)
    End Sub
End Class