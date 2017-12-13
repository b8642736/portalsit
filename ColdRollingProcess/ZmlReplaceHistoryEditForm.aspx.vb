Public Class ZmlReplaceHistoryEditForm
    Inherits System.Web.UI.Page

 

    Private Sub ZmlReplaceHistoryEditForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        WebAppAuthority.ValidAuthorityModule.ValidAuthoritySystem("COLD01", "COLD0109", Me)

        If Not IsPostBack Then
            Session("defaultSYSTEM_TYPE") = HttpUtility.UrlEncode("ZML更換紀錄表")

        End If
    End Sub

    Private Sub TabContainer1_ActiveTabChanged(sender As Object, e As EventArgs) Handles TabContainer1.ActiveTabChanged
        If TabContainer1.ActiveTabIndex = 0 Then
            '異動完片語資料，輸入畫面資料要重新載入

            Dim checkBoxListObj As CheckBoxList
            Dim checkBoxListName As String = Nothing

            For II As Integer = 1 To 2
                Select Case II
                    Case 1
                        checkBoxListName = "checkBoxListInsKind"
                    Case 2
                        checkBoxListName = "checkBoxListShiftKind"
                End Select
                checkBoxListObj = Me.ZmlReplaceHistory1.FindControl(checkBoxListName)
                If Not checkBoxListObj Is Nothing Then
                    checkBoxListObj.DataBind()
                End If
            Next II
        End If

        Dim radioBtnLst As RadioButtonList = Me.ZmlReplaceHistory1.FindControl("radioInsKind")
        If Not radioBtnLst Is Nothing Then radioBtnLst.DataBind()

        Dim listView As ListView = Me.ZmlReplaceHistory1.FindControl("ListView1")
        If Not listView Is Nothing Then
            Dim ddlistObj As DropDownList
            Dim ddlistName As String = Nothing

            For II As Integer = 1 To 5
                Select Case II
                    Case 1
                        ddlistName = "ddlistShiftKindCRUD"
                    Case 2, 4
                        ddlistName = "ddlist規格"
                    Case 3, 5
                        ddlistName = "ddlist背輥代號"
                End Select
                If II <= 3 Then
                    If listView.InsertItem Is Nothing Then
                        ddlistObj = Nothing
                    Else
                        ddlistObj = listView.InsertItem.FindControl(ddlistName)
                    End If

                Else
                    If listView.EditItem Is Nothing Then
                        ddlistObj = Nothing
                    Else
                        ddlistObj = listView.EditItem.FindControl(ddlistName)
                    End If
                End If
                If Not ddlistObj Is Nothing Then
                    If II > 1 Then
                        ddlistObj.Items.Clear()
                        ddlistObj.Items.Add("其他")
                    End If
                    ddlistObj.DataBind()
                End If
            Next II


        End If
    End Sub
End Class