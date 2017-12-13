Public Partial Class WebClientPCAuthorityEdit
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New ClassDBDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub ClientPCSearch1_ClientPCSearchedEvent(ByVal SenderControl As ClientPCSearch) Handles ClientPCSearch1.ClientPCSearchedEvent
        If IsNothing(SenderControl.SelectedClientPCIP) OrElse String.IsNullOrEmpty(SenderControl.SelectedClientPCIP) Then
            Panel1.Visible = False
            UpdatePanel2.Update()
        End If
    End Sub

    Private Sub ClientPCSearch1_ClientPCSelectedEvent(ByVal SelectClientPCIP As String) Handles ClientPCSearch1.ClientPCSelectedEvent
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
        Dim Q1 As IQueryable(Of CompanyLINQDB.WebSystemFunction) = (From A In DBDataContext.WebSystemFunction, B In DBDataContext.WebClientPCAuthority Where A.SystemCode = CType(GridView2.SelectedValue, String) And A.FunctionCode = B.FK_SystemFunctionCode And B.FKWebClientPCAccount_ClientIP = ClientPCSearch1.SelectedClientPCIP Select A).Distinct
        e.Result = (From A In DBDataContext.WebSystemFunction Where A.SystemCode = CType(GridView2.SelectedValue, String) Select A).Except(Q1)
    End Sub

    Private Sub LDSWebSystemFunctionYesAuthority_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSWebSystemFunctionYesAuthority.Selecting
        If IsNothing(GridView2.SelectedValue) Then
            GridView4.Visible = False
            e.Cancel = True
            Exit Sub
        End If
        GridView4.Visible = True
        Dim Q1 As IQueryable(Of CompanyLINQDB.WebSystemFunction) = (From A In DBDataContext.WebSystemFunction, B In DBDataContext.WebClientPCAuthority Where A.SystemCode = CType(GridView2.SelectedValue, String) And A.FunctionCode = B.FK_SystemFunctionCode And B.FKWebClientPCAccount_ClientIP = ClientPCSearch1.SelectedClientPCIP Select A).Distinct
        e.Result = (From A In DBDataContext.WebSystemFunction Where A.SystemCode = CType(GridView2.SelectedValue, String) Select A).Intersect(Q1)
    End Sub

    Private Sub GridView3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView3.SelectedIndexChanged
        If IsNothing(GridView2.SelectedValue) OrElse IsNothing(GridView3.SelectedValue) OrElse IsNothing(ClientPCSearch1.SelectedClientPCIP) Then
            Exit Sub
        End If
        Dim AddNewData As New CompanyLINQDB.WebClientPCAuthority
        With AddNewData
            .FK_SystemCode = GridView2.SelectedValue
            .FK_SystemFunctionCode = GridView3.SelectedValue
            .FKWebClientPCAccount_ClientIP = ClientPCSearch1.SelectedClientPCIP
            .Description = "起始授權時間:" & Format(Now, "yyyy/MM/dd hh:mm:ss").ToString & ",授權者:" & ValidAuthorityModule.CurrentWindowsLoginName & "(" & ValidAuthorityModule.CurrentWindowsLoginEmployeeNumber & ")"
        End With
        DBDataContext.WebClientPCAuthority.InsertOnSubmit(AddNewData)
        DBDataContext.SubmitChanges()
        GridView3.DataBind()
        GridView4.DataBind()
    End Sub

    Private Sub GridView4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView4.SelectedIndexChanged
        If IsNothing(GridView2.SelectedValue) OrElse IsNothing(GridView4.SelectedValue) OrElse IsNothing(ClientPCSearch1.SelectedClientPCIP) Then
            Exit Sub
        End If
        Dim DeleteData As CompanyLINQDB.WebClientPCAuthority = (From A In DBDataContext.WebClientPCAuthority Where A.FK_SystemCode = CType(GridView2.SelectedValue, String) And A.FK_SystemFunctionCode = CType(GridView4.SelectedValue, String) And A.FKWebClientPCAccount_ClientIP = ClientPCSearch1.SelectedClientPCIP Select A).FirstOrDefault
        If Not IsNothing(DeleteData) Then
            DBDataContext.WebClientPCAuthority.DeleteOnSubmit(DeleteData)
            DBDataContext.SubmitChanges()
            GridView3.DataBind()
            GridView4.DataBind()
        End If
    End Sub

    Protected Sub btnClearAllSysAuthority_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearAllSysAuthority.Click
        DBDataContext.WebClientPCAuthority.DeleteAllOnSubmit(From A In DBDataContext.WebClientPCAuthority Where A.FKWebClientPCAccount_ClientIP = Me.ClientPCSearch1.SelectedClientPCIP Select A)
        DBDataContext.SubmitChanges()
        GridView3.DataBind()
        GridView4.DataBind()
    End Sub

    Protected Sub btnClearAllSysFunAuthority_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearAllSysFunAuthority.Click
        DBDataContext.WebClientPCAuthority.DeleteAllOnSubmit(From A In DBDataContext.WebClientPCAuthority Where A.FKWebClientPCAccount_ClientIP = Me.ClientPCSearch1.SelectedClientPCIP And A.FK_SystemCode = CType(Me.GridView2.SelectedValue, String) Select A)
        DBDataContext.SubmitChanges()
        GridView3.DataBind()
        GridView4.DataBind()
    End Sub

End Class