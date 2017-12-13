Imports System.Web.UI.WebControls

Public Module UtilityTools


    Public Sub DropDownListSelectIndex(ByVal fromDropDownList As DropDownList, ByVal fromSelectText As String)
        Dim II As Integer
        fromDropDownList.SelectedIndex = -1
        For II = 0 To fromDropDownList.Items.Count - 1
            If fromDropDownList.Items(II).Value = fromSelectText Then
                fromDropDownList.SelectedIndex = II
                Exit For
            End If
        Next II
    End Sub

    Public Sub RadioButtonListSelect(ByVal fromRadioButtonList As RadioButtonList, ByVal fromSelectText As String)
        For II As Integer = 0 To fromRadioButtonList.Items.Count - 1
            fromRadioButtonList.Items(II).Selected = (fromRadioButtonList.Items(II).Text = fromSelectText)
        Next
    End Sub
End Module
