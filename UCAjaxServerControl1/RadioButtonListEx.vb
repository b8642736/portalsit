Public Class RadioButtonListEx
    Inherits System.Web.UI.WebControls.RadioButtonList

    Public Sub SelectedByText(ByVal fromText As String)
        For II As Integer = 0 To Me.Items.Count - 1
            Me.Items(II).Selected = (Me.Items(II).Text = fromText)
        Next
    End Sub

    Public Sub SelectedByValue(ByVal fromText As String)
        For II As Integer = 0 To Me.Items.Count - 1
            Me.Items(II).Selected = (Me.Items(II).Value = fromText)
        Next
    End Sub

End Class
