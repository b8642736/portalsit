Public Class RepairEdit
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As List(Of CompanyORMDB.SQLServer.MIS.RepairRecord)
        Dim ReturnValue As New List(Of CompanyORMDB.SQLServer.MIS.RepairRecord)
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If
        Return CompanyORMDB.SQLServer.MIS.RepairRecord.CDBSelect(Of CompanyORMDB.SQLServer.MIS.RepairRecord)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
    End Function
#End Region
#Region "新增 方法:CDBInsert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Function CDBInsert(ByVal SourceObject As CompanyORMDB.SQLServer.MIS.RepairRecord) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "MIS")
        Return SourceObject.CDBInsert()
    End Function
#End Region
#Region "刪除 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function CDBDelete(ByVal SourceObject As CompanyORMDB.SQLServer.MIS.RepairRecord) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "MIS")
        Return SourceObject.CDBDelete()
    End Function
#End Region
#Region "修改 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As CompanyORMDB.SQLServer.MIS.RepairRecord) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "MIS")
        Return SourceObject.CDBUpdate()
    End Function
#End Region

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQLString As StringBuilder = New StringBuilder("Select A.* from RepairRecord A  Where 1=1 ")

        If CheckBox1.Checked Then
            Dim StartDate As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbStartDate.Text, Date)).TwIntegerTypeData
            Dim EndDate As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbEndDate.Text, Date)).TwIntegerTypeData
            SQLString.Append(" and ApplyTime>=" & StartDate & " and ApplyTime<=" & EndDate)
        End If

        If Not String.IsNullOrEmpty(tbRepareItem.Text) Then
            SQLString.Append(" and A.RepareItem like '%" & tbRepareItem.Text.Trim & "%'")
        End If
        If Not String.IsNullOrEmpty(tbProcessResult.Text) Then
            SQLString.Append(" and A.ProcessResult like '%" & tbProcessResult.Text.Trim & "%'")
        End If
        If Not String.IsNullOrEmpty(tbApplyEmplyee.Text) Then
            SQLString.Append(" and A.ApplyEmplyee like '%" & tbApplyEmplyee.Text.Trim & "%'")
        End If

        Me.hfQryString.Value = SQLString.ToString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now, "yyyy/MM/01")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        Me.ListView1.DataBind()
    End Sub

End Class