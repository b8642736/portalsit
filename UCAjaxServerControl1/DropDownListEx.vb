Public Class DropDownListEx
    Inherits System.Web.UI.WebControls.DropDownList

    Public Sub SelectedIndexByValue(ByVal fromValue As String)
        Me.SelectedIndex = -1
        For II As Integer = 0 To Me.Items.Count - 1
            If Me.Items(II).Value = fromValue Then
                Me.SelectedIndex = II
                Exit For
            End If
        Next II
    End Sub

    Public Sub SelectedIndexByText(ByVal fromText As String)
        Me.SelectedIndex = -1
        For II As Integer = 0 To Me.Items.Count - 1
            If Me.Items(II).Text = fromText Then
                Me.SelectedIndex = II
                Exit For
            End If
        Next II
    End Sub

End Class
