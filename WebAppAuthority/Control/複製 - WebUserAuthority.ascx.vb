Public Partial Class WebUserAuthority
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New ClassDBDataContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Sub EmployeeSearch1_EmployeeSearchedEvent(ByVal DataSource As System.Web.UI.WebControls.SqlDataSource) Handles EmployeeSearch1.EmployeeSearchedEvent
        Panel1.Visible = False
    End Sub

    Private Sub EmployeeSearch1_EmployeeSelectedEvent(ByVal SelectEmployeeNumber As String) Handles EmployeeSearch1.EmployeeSelectedEvent
        Panel1.Visible = True
        GridView3.DataBind()
        GridView4.DataBind()
        Me.UpdatePanel2.Update()
    End Sub

    Private Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged
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
        Dim Q1 As IQueryable(Of CompanyLINQDB.WebSystemFunction) = (From A In DBDataContext.WebSystemFunction, B In DBDataContext.WebUserAuthority Where A.SystemCode = CType(GridView2.SelectedValue, String) And A.FunctionCode = B.FK_SystemFunctionCode And B.WorkNumber = EmployeeSearch1.SelectedEmployeeNumber Select A).Distinct
        e.Result = (From A In DBDataContext.WebSystemFunction Where A.SystemCode = CType(GridView2.SelectedValue, String) Select A).Except(Q1)
    End Sub

    Private Sub LDSWebSystemFunctionYesAuthority_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSWebSystemFunctionYesAuthority.Selecting
        If IsNothing(GridView2.SelectedValue) Then
            GridView4.Visible = False
            e.Cancel = True
            Exit Sub
        End If
        GridView4.Visible = True
        Dim Q1 As IQueryable(Of CompanyLINQDB.WebSystemFunction) = (From A In DBDataContext.WebSystemFunction, B In DBDataContext.WebUserAuthority Where A.SystemCode = CType(GridView2.SelectedValue, String) And A.FunctionCode = B.FK_SystemFunctionCode And B.WorkNumber = EmployeeSearch1.SelectedEmployeeNumber Select A).Distinct
        e.Result = (From A In DBDataContext.WebSystemFunction Where A.SystemCode = CType(GridView2.SelectedValue, String) Select A).Intersect(Q1)
    End Sub

    Private Sub GridView3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView3.SelectedIndexChanged
        If IsNothing(GridView2.SelectedValue) OrElse IsNothing(GridView3.SelectedValue) OrElse IsNothing(EmployeeSearch1.SelectedEmployeeNumber) Then
            Exit Sub
        End If
        Dim AddNewData As New CompanyLINQDB.WebUserAuthority
        With AddNewData
            .FK_SystemCode = GridView2.SelectedValue
            .FK_SystemFunctionCode = GridView3.SelectedValue
            .WorkNumber = EmployeeSearch1.SelectedEmployeeNumber
            .Description = "授權時間:" & Format(Now, "yyyy/MM/dd hh:mm:ss").ToString
        End With
        DBDataContext.WebUserAuthority.InsertOnSubmit(AddNewData)
        DBDataContext.SubmitChanges()
        GridView3.DataBind()
        GridView4.DataBind()
    End Sub

    Private Sub GridView4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView4.SelectedIndexChanged
        If IsNothing(GridView2.SelectedValue) OrElse IsNothing(GridView4.SelectedValue) OrElse IsNothing(EmployeeSearch1.SelectedEmployeeNumber) Then
            Exit Sub
        End If
        Dim DeleteData As CompanyLINQDB.WebUserAuthority = (From A In DBDataContext.WebUserAuthority Where A.FK_SystemCode = CType(GridView2.SelectedValue, String) And A.FK_SystemFunctionCode = CType(GridView4.SelectedValue, String) And A.WorkNumber = EmployeeSearch1.SelectedEmployeeNumber Select A).FirstOrDefault
        If Not IsNothing(DeleteData) Then
            DBDataContext.WebUserAuthority.DeleteOnSubmit(DeleteData)
            DBDataContext.SubmitChanges()
            GridView3.DataBind()
            GridView4.DataBind()
        End If
    End Sub
End Class