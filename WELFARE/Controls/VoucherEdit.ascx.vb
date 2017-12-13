Public Class VoucherEdit
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As List(Of CompanyORMDB.SQLServer.WELFARE.傳票)
        Dim ReturnValue As New List(Of CompanyORMDB.SQLServer.WELFARE.傳票)
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If
        Return CompanyORMDB.SQLServer.WELFARE.傳票.CDBSelect(Of CompanyORMDB.SQLServer.WELFARE.傳票)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
    End Function
#End Region
#Region "新增 方法:CDBInsert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Function CDBInsert(ByVal SourceObject As CompanyORMDB.SQLServer.WELFARE.傳票) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "WELFARE")
        Return SourceObject.CDBInsert()
    End Function
#End Region
#Region "刪除 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function CDBDelete(ByVal SourceObject As CompanyORMDB.SQLServer.WELFARE.傳票) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "WELFARE")
        Return SourceObject.CDBDelete()
    End Function
#End Region
#Region "修改 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As CompanyORMDB.SQLServer.WELFARE.傳票) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "WELFARE")
        Return SourceObject.CDBUpdate()
    End Function
#End Region


#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQLString As StringBuilder = New StringBuilder("Select A.* from 傳票 A  Where 1=1 ")

        If Not String.IsNullOrEmpty(tbVoucherNumber.Text) Then
            SQLString.Append(" and A.傳票編號 ='" & tbVoucherNumber.Text.Trim & "'")
        End If

        If CheckBox1.Checked Then
            Dim StartDate As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbStartDate.Text, Date)).TwIntegerTypeData
            Dim EndDate As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbEndDate.Text, Date)).TwIntegerTypeData
            SQLString.Append(" and 傳票日期>=" & StartDate & " and 傳票日期<=" & EndDate)
        End If

        If Not String.IsNullOrEmpty(tbAccMemos.Text) AndAlso tbAccMemos.Text.Trim.Length > 0 Then
            Dim EachDatas As List(Of String) = tbAccMemos.Text.Trim.Split(",").ToList
            SQLString.Append(" AND (")
            Dim IsFirstLoop As Boolean = True
            For Each EachItem As String In EachDatas
                If Not IsFirstLoop Then
                    SQLString.Append(" and ")
                End If
                SQLString.Append(" A.摘要 like '%" & EachItem & "%'")
                IsFirstLoop = False
            Next
            SQLString.Append(")")
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