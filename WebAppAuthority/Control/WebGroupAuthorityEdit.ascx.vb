Public Partial Class WebGroupAuthorityEdit
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New ClassDBDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub ClientPCSearch1_ClientPCSearchedEvent(ByVal SenderControl As GroupSearch) Handles GroupSearch1.GroupSearchedEvent
        If IsNothing(SenderControl.SelectedGroupCode) OrElse String.IsNullOrEmpty(SenderControl.SelectedGroupCode) Then
            Panel1.Visible = False
            UpdatePanel2.Update()
        End If
    End Sub

    Private Sub GroupSearch1_GroupSearch1SelectedEvent(ByVal SelectClientPCIP As String) Handles GroupSearch1.GroupSelectedEvent
        Panel1.Visible = True
        GridView3.DataBind()
        GridView4.DataBind()
        Me.UpdatePanel2.Update()
    End Sub

    Private Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged
        btnClearAllSysFunAuthority.Enabled = Not IsNothing(GridView2.SelectedValue)
        lblSelectSystem.Text = GridView2.SelectedRow.Cells(1).Text
        GridView3.DataBind()
        GridView4.DataBind()
    End Sub

    Private Sub LDSWebSystemFunctionNotAuthority_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSWebSystemFunctionNotAuthority.Selecting
        If IsNothing(GridView2.SelectedValue) Then
            GridView3.Visible = False
            e.Cancel = True
            Exit Sub
        End If
        GridView3.Visible = True
        Dim Q1 As IQueryable(Of CompanyLINQDB.WebSystemFunction) = (From A In DBDataContext.WebSystemFunction, B In DBDataContext.WebGroupAuthority Where A.SystemCode = CType(GridView2.SelectedValue, String) And A.FunctionCode = B.FK_SystemFunctionCode And B.GroupCode = GroupSearch1.SelectedGroupCode Select A).Distinct
        e.Result = (From A In DBDataContext.WebSystemFunction Where A.SystemCode = CType(GridView2.SelectedValue, String) Select A).Except(Q1)
    End Sub

    Private Sub LDSWebSystemFunctionYesAuthority_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSWebSystemFunctionYesAuthority.Selecting
        If IsNothing(GridView2.SelectedValue) Then
            GridView4.Visible = False
            e.Cancel = True
            Exit Sub
        End If
        GridView4.Visible = True
        Dim Q1 As IQueryable(Of CompanyLINQDB.WebSystemFunction) = (From A In DBDataContext.WebSystemFunction, B In DBDataContext.WebGroupAuthority Where A.SystemCode = CType(GridView2.SelectedValue, String) And A.FunctionCode = B.FK_SystemFunctionCode And B.GroupCode = GroupSearch1.SelectedGroupCode Select A).Distinct
        e.Result = (From A In DBDataContext.WebSystemFunction Where A.SystemCode = CType(GridView2.SelectedValue, String) Select A).Intersect(Q1)
    End Sub

    Private Sub GridView3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView3.SelectedIndexChanged
        If IsNothing(GridView2.SelectedValue) OrElse IsNothing(GridView3.SelectedValue) OrElse IsNothing(GroupSearch1.SelectedGroupCode) Then
            Exit Sub
        End If
        Dim AddNewData As New CompanyLINQDB.WebGroupAuthority
        With AddNewData
            .FK_SystemCode = GridView2.SelectedValue
            .FK_SystemFunctionCode = GridView3.SelectedValue
            .GroupCode = GroupSearch1.SelectedGroupCode
            .Description = "起始授權時間:" & Format(Now, "yyyy/MM/dd hh:mm:ss").ToString & ",授權者:" & ValidAuthorityModule.CurrentWindowsLoginName & "(" & ValidAuthorityModule.CurrentWindowsLoginEmployeeNumber & ")"
        End With
        DBDataContext.WebGroupAuthority.InsertOnSubmit(AddNewData)
        DBDataContext.SubmitChanges()
        GridView3.DataBind()
        GridView4.DataBind()
    End Sub

    Private Sub GridView4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView4.SelectedIndexChanged
        If IsNothing(GridView2.SelectedValue) OrElse IsNothing(GridView4.SelectedValue) OrElse IsNothing(GroupSearch1.SelectedGroupCode) Then
            Exit Sub
        End If
        Dim DeleteData As CompanyLINQDB.WebGroupAuthority = (From A In DBDataContext.WebGroupAuthority Where A.FK_SystemCode = CType(GridView2.SelectedValue, String) And A.FK_SystemFunctionCode = CType(GridView4.SelectedValue, String) And A.GroupCode = GroupSearch1.SelectedGroupCode Select A).FirstOrDefault
        If Not IsNothing(DeleteData) Then
            DBDataContext.WebGroupAuthority.DeleteOnSubmit(DeleteData)
            DBDataContext.SubmitChanges()
            GridView3.DataBind()
            GridView4.DataBind()
        End If
    End Sub

    Protected Sub btnClearAllSysAuthority_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearAllSysAuthority.Click
        DBDataContext.WebGroupAuthority.DeleteAllOnSubmit(From A In DBDataContext.WebGroupAuthority Where A.GroupCode = Me.GroupSearch1.SelectedGroupCode Select A)
        DBDataContext.SubmitChanges()
        GridView3.DataBind()
        GridView4.DataBind()
    End Sub

    Protected Sub btnClearAllSysFunAuthority_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearAllSysFunAuthority.Click
        DBDataContext.WebGroupAuthority.DeleteAllOnSubmit(From A In DBDataContext.WebGroupAuthority Where A.GroupCode = Me.GroupSearch1.SelectedGroupCode And A.FK_SystemCode = CType(Me.GridView2.SelectedValue, String) Select A)
        DBDataContext.SubmitChanges()
        GridView3.DataBind()
        GridView4.DataBind()
    End Sub

End Class