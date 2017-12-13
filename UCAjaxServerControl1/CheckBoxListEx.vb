Public Class CheckBoxListEx
    Inherits CheckBoxList

    Public Sub SelectedAll()
        For II As Integer = 0 To Me.Items.Count - 1
            Me.Items(II).Selected = True
        Next
    End Sub

    Public Function TextSelectToSQL() As String
        Dim retStr As String = ""

        For II As Integer = 0 To Me.Items.Count - 1
            If Me.Items(II).Selected = True Then
                If retStr <> "" Then retStr = retStr & ","
                retStr = retStr & "'" & Me.Items(II).Text & "'"
            End If
        Next

        Return retStr
    End Function



End Class
