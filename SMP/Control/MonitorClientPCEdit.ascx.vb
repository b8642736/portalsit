Public Partial Class MonitorClientPCEdit
    Inherits System.Web.UI.UserControl

    Dim DataContext As New ClassDBDataContext
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub LDSUnMonitorClientPC_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSUnMonitorClientPC.Selecting
        Dim Query As IQueryable = From A In DataContext.WebClientPCAccount Where Not (From B In DataContext.SMPClientPCMonitor Select B.ClientPCIP).Contains(A.ClientIP) Select A
        e.Result = Query
    End Sub

    Protected Sub LDSMonitorClientPC_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSMonitorClientPC.Selecting
        Dim Query As IQueryable = From A In DataContext.WebClientPCAccount Where (From B In DataContext.SMPClientPCMonitor Select B.ClientPCIP).Contains(A.ClientIP) Select A
        e.Result = Query
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim AddObject As New CompanyLINQDB.SMPClientPCMonitor
        With AddObject
            .ClientPCIP = GridView1.SelectedValue
            .PingTimeOutSeconds = 2
        End With
        DataContext.SMPClientPCMonitor.InsertOnSubmit(AddObject)
        DataContext.SubmitChanges()
        Me.GridView1.DataBind()
        Me.GridView2.DataBind()
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView2.SelectedIndexChanged
        Dim DeleteObject As CompanyLINQDB.SMPClientPCMonitor = (From A In DataContext.SMPClientPCMonitor Where A.ClientPCIP = Me.GridView2.SelectedValue.ToString Select A).FirstOrDefault
        If IsNothing(DeleteObject) Then
            Exit Sub
        End If
        DataContext.SMPClientPCMonitor.DeleteOnSubmit(DeleteObject)
        DataContext.SubmitChanges()
        Me.GridView1.DataBind()
        Me.GridView2.DataBind()

    End Sub
End Class