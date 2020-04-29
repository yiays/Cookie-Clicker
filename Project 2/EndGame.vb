Public Class frmEndGame
    Public Sub Init()
        Dim Stats = frmUpgrades.GetStats()
        Dim i As Byte
        i = 0
        For Each item In listEndGameStats.Items
            item.SubItems.Item(0).Text = Stats(i, 0)
            item.SubItems.Item(1).Text = Stats(i, 1)
            i += 1
        Next
    End Sub

    Private Sub frmEndGame_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Environment.Exit(0)
    End Sub
End Class