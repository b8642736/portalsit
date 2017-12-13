Public Class AS400StoveElementEdit
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As List(Of CompanyORMDB.PPS100LB.PPSQCAPF)
        If String.IsNullOrEmpty(SQLString) Then
            Return New List(Of CompanyORMDB.PPS100LB.PPSQCAPF)
        End If
        Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return CompanyORMDB.PPS100LB.PPSQCAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSQCAPF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function

#End Region
#Region "修改 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As CompanyORMDB.PPS100LB.PPSQCAPF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBSave
    End Function
#End Region
    '#Region "刪除 方法:CDBDelete"
    '    <DataObjectMethod(DataObjectMethodType.Delete)> _
    '    Public Shared Function CDBDelete(ByVal SourceObject As CompanyORMDB.PPS100LB.PPSQCAPF) As Integer
    '        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    '        Return SourceObject.CDBDelete()
    '    End Function
    '#End Region

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQLString As String = Nothing
        Dim DeclareStartDate As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbStartDate.Text, Date)).TwIntegerTypeData
        Dim DeclareEndDate As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbEndDate.Text, Date)).TwIntegerTypeData
        SQLString = " Select * From @#PPS100LB.PPSQCAPF  Where QCA02 >=" & DeclareStartDate & " AND QCA02 <=" & DeclareEndDate

        If Not String.IsNullOrEmpty(tbStoveNumber.Text) And tbStoveNumber.Text.Trim.Length > 0 Then
            SQLString &= " AND QCA01 ='" & tbStoveNumber.Text.Trim & "'"
        End If

        Me.hfQryString.Value = SQLString & " ORDER BY QCA01"
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.tbStartDate.Text = Format(Now.AddMonths(-6), "yyyy/MM/01")
            Me.tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub tbSearch_Click(sender As Object, e As EventArgs) Handles tbSearch.Click
        MakQryStringToControl()
        GridView1.DataBind()
    End Sub
End Class