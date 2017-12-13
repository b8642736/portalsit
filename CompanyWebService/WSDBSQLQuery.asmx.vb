Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WSDBSQLQuery
    Inherits System.Web.Services.WebService


#Region "AS400查詢物件　屬性:AS400SQLQueryObject"
    Private _AS400SQLQueryObject As CompanyORMDB.AS400SQLQueryAdapter = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    ''' <summary>
    ''' AS400查詢物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AS400SQLQueryObject() As CompanyORMDB.AS400SQLQueryAdapter
        Get
            If IsNothing(_AS400SQLQueryObject) Then
                _AS400SQLQueryObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            End If
            Return _AS400SQLQueryObject
        End Get
    End Property
#End Region

#Region "接授碼是否通過 方法:IsAcceptCodeReplayPass"
    ''' <summary>
    ''' 接授碼是否通過
    ''' </summary>
    ''' <param name="AcceptCodeReplay"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsAcceptCodeReplayPass(ByVal AcceptCodeReplay As String) As Boolean
        Dim NowDate As DateTime = Now
        Dim Pass1 As String = (Format(NowDate, "yyyy/MM/dd hh:mm") & "TANGENG").GetHashCode
        Dim Pass2 As String = (Format(NowDate.AddMinutes(-1), "yyyy/MM/dd hh:mm") & "TANGENG").GetHashCode
        Dim Pass3 As String = (Format(NowDate.AddMinutes(1), "yyyy/MM/dd hh:mm") & "TANGENG").GetHashCode
        Return AcceptCodeReplay = Pass1.GetHashCode OrElse AcceptCodeReplay = Pass2.GetHashCode OrElse AcceptCodeReplay = Pass3.GetHashCode
    End Function
#End Region

#Region "取得伺服器時間 方法:GetServerTime"
    ''' <summary>
    ''' 取得伺服器時間
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function GetServerTime() As DateTime
        Return Now
    End Function
#End Region


#Region "AS400SELECT查詢 方法:AS400SelectQuery"
    ''' <summary>
    ''' AS400SELECT查詢
    ''' </summary>
    ''' <param name="SetSourceQueryString"></param>
    ''' <param name="AcceptCodeReplay"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
   Public Function AS400SelectQuery(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String) As DataTable
        If IsAcceptCodeReplayPass(AcceptCodeReplay) Then
            Return Nothing
        End If
        Dim ReturnValue As DataTable = Me.AS400SQLQueryObject.SelectQuery(SetSourceQueryString)
        ReturnValue.TableName = "Table1"
        Return ReturnValue
    End Function
#End Region
#Region "AS400增刪修查詢 方法:AS400ExecuteNonQuery"
    ''' <summary>
    ''' AS400增刪修查詢
    ''' </summary>
    ''' <param name="SetSourceQueryString"></param>
    ''' <param name="AcceptCodeReplay"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
  Public Function AS400ExecuteNonQuery(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String) As Integer
        If IsAcceptCodeReplayPass(AcceptCodeReplay) Then
            Return Nothing
        End If
        Return Me.AS400SQLQueryObject.ExecuteNonQuery(SetSourceQueryString)
    End Function
#End Region
#Region "SQLServerSELECT查詢 方法:SQLServerSelectQuery"
    ''' <summary>
    ''' SQLServerSELECT查詢
    ''' </summary>
    ''' <param name="SetSourceQueryString"></param>
    ''' <param name="SetSQLServerConnectionString"></param>
    ''' <param name="AcceptCodeReplay"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function SQLServerSelectQuery(ByVal SetSourceQueryString As String, ByVal SetSQLServerConnectionString As String, ByVal AcceptCodeReplay As String) As DataTable
        If IsAcceptCodeReplayPass(AcceptCodeReplay) Then
            Return Nothing
        End If
        Dim ReturnDataSet As New DataSet
        Dim DBConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(SetSQLServerConnectionString)
        Dim DBAdapter As New SqlClient.SqlDataAdapter(New SqlClient.SqlCommand(SetSourceQueryString, DBConnection))
        DBConnection.Open()
        DBAdapter.Fill(ReturnDataSet)
        Dim ReturnValue As DataTable = ReturnDataSet.Tables(0)
        DBConnection.Close()
        ReturnValue.TableName = "Table1"
        Return ReturnValue
    End Function
#End Region
#Region "SQLServerSELECT增刪修查詢 方法:SQLServerExecuteNonQuery"
    ''' <summary>
    ''' SQLServerSELECT增刪修查詢
    ''' </summary>
    ''' <param name="SetSourceQueryString"></param>
    ''' <param name="SetSQLServerConnectionString"></param>
    ''' <param name="AcceptCodeReplay"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod()> _
    Public Function SQLServerExecuteNonQuery(ByVal SetSourceQueryString As String, ByVal SetSQLServerConnectionString As String, ByVal AcceptCodeReplay As String) As Integer
        If IsAcceptCodeReplayPass(AcceptCodeReplay) Then
            Return Nothing
        End If
        Dim DBConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection(SetSQLServerConnectionString)
        DBConnection.Open()
        Dim ReturnValue As Integer = (New SqlClient.SqlCommand(SetSourceQueryString, DBConnection)).ExecuteNonQuery
        DBConnection.Close()
        Return ReturnValue
    End Function
#End Region

End Class

