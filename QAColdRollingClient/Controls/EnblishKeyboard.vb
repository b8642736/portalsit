Public Class EnblishKeyboard

    Public Event ButtonClickEvent(sender As Object, ByVal Value As String)

#Region "初始化控制項按鈕 屬性:InitControlButton"
    Private Sub InitControlButton()
        For Each EachButton As Button In TableLayoutPanel1.Controls
            RemoveHandler EachButton.Click, AddressOf btn_Click
        Next
        TableLayoutPanel1.Controls.Clear()

        Dim SetChar As Char
        For RowCount As Integer = 0 To TableLayoutPanel1.RowCount
            For ColCount As Integer = 0 To TableLayoutPanel1.ColumnCount
                SetChar = Chr(Asc("A") + (RowCount) * 10 + ColCount)
                Dim AddButton As New Button
                With AddButton
                    .Text = SetChar
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Anchor = TableLayoutPanel1.Anchor
                    .Font = New Font("Arial", 26, FontStyle.Bold)
                    .Margin = New Padding(0)
                    .Cursor = Cursors.Hand
                    .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                    AddHandler .Click, AddressOf btn_Click
                End With
                TableLayoutPanel1.Controls.Add(AddButton)
                TableLayoutPanel1.SetCellPosition(AddButton, New TableLayoutPanelCellPosition(ColCount, RowCount))
                If SetChar = "Z" Then
                    Exit Sub
                End If
            Next
        Next
    End Sub
#End Region

    Private Sub EnblishKeyboard_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitControlButton()
    End Sub

    Private Sub btn_Click(sender As Object, e As EventArgs)
        Dim SenderControl As Button = sender
        RaiseEvent ButtonClickEvent(Me, SenderControl.Text)
    End Sub
End Class
