Public Class DBSQLQuery

    Sub New()
        AllWebServices.Add(New Server0bm.WSDBSQLQuery)
        AllWebServices.Add(New Server04m.WSDBSQLQuery)
        AllWebServices.Add(New Portalsit2.WSDBSQLQuery)
    End Sub
    Sub New(ByVal SetBeforeQueryCheckAndAutoChangeWebServiceSite As Boolean)
        Me.New()
        Me.IsBeforeQueryCheckAndAutoChangeWebServiceSite = SetBeforeQueryCheckAndAutoChangeWebServiceSite
    End Sub

#Region "執行查詢前是否自動偵測網站狀況並自動切換正常網站 屬性:BeforeQueryCheckAndAutoChangeWebServiceSite"

    Private _IsBeforeQueryCheckAndAutoChangeWebServiceSite As Boolean = False
    ''' <summary>
    ''' 執行查詢前是否自動偵測網站狀況並自動切換正常網站
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsBeforeQueryCheckAndAutoChangeWebServiceSite() As Boolean
        Get
            Return _IsBeforeQueryCheckAndAutoChangeWebServiceSite
        End Get
        Set(ByVal value As Boolean)
            _IsBeforeQueryCheckAndAutoChangeWebServiceSite = value
        End Set
    End Property

#End Region
#Region "所有可有WEB服務 屬性:AllWebServices"
    ''' <summary>
    ''' 所有可有WEB服務
    ''' </summary>
    ''' <remarks></remarks>
    Private _AllWebServices As New List(Of IWSDBSQLQuery)
    Property AllWebServices() As List(Of IWSDBSQLQuery)
        Get
            Return _AllWebServices
        End Get
        Private Set(ByVal value As List(Of IWSDBSQLQuery))
            _AllWebServices = value
        End Set
    End Property
#End Region
#Region "現行可使用WEB服務 屬性:CurrentCanUseQueryService"
    Private _CurrentCanUseQueryService As IWSDBSQLQuery
    ''' <summary>
    ''' 現行可使用WEB服務
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentCanUseQueryService() As IWSDBSQLQuery
        Get
            If IsNothing(_CurrentCanUseQueryService) OrElse (IsBeforeQueryCheckAndAutoChangeWebServiceSite AndAlso IsWebServiceCanUse(_CurrentCanUseQueryService) = False) Then
                ChangeNextCanUseQueryService()
            End If
            Return _CurrentCanUseQueryService
        End Get
        Set(ByVal value As IWSDBSQLQuery)
            _CurrentCanUseQueryService = value
        End Set
    End Property
#End Region
#Region "現行可使用WEB服務SoapHttpClientProtocol　屬性:CurrentCanUseQueryServiceSoapHttpClientProtocol"
    ''' <summary>
    ''' 現行可使用WEB服務SoapHttpClientProtocol
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CurrentCanUseQueryServiceSoapHttpClientProtocol() As System.Web.Services.Protocols.SoapHttpClientProtocol
        Get
            If IsNothing(CurrentCanUseQueryService) Then
                Return Nothing
            End If
            Return CType(CurrentCanUseQueryService, System.Web.Services.Protocols.SoapHttpClientProtocol)
        End Get
    End Property
#End Region
#Region "變更下一個可用WEB服務 方法:ChangeNextCanUseQueryService"
    ''' <summary>
    ''' 變更下一個可用WEB服務
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ChangeNextCanUseQueryService() As Boolean
        For Each EachItem As IWSDBSQLQuery In Me.AllWebServices
            If IsWebServiceCanUse(EachItem) Then
                Me.CurrentCanUseQueryService = EachItem
                Return True
            End If
        Next
        Me.CurrentCanUseQueryService = Nothing
        Return False
    End Function
#End Region

#Region "偵測WebService是否可使用 方法:IsWebServiceCanUse"
    ''' <summary>
    ''' 偵測WebService是否可使用
    ''' </summary>
    ''' <param name="SetWebService"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsWebServiceCanUse(ByVal SetWebService As IWSDBSQLQuery) As Boolean
        Dim OLDWSTimeOout As Integer = 0
        Dim WS As New Server04m.WSDBSQLQuery
        OLDWSTimeOout = WS.Timeout
        WS.Timeout = 1000
        Try
            WS.GetServerTime()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
#End Region
#Region "WebService資料取得通行碼 方法:WSDataQueryGetPassCode"
    ''' <summary>
    ''' WebService資料取得通行碼
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function WSDataQueryGetPassCode() As Integer
        Return (Format(CurrentCanUseQueryService.GetServerTimeGo, "yyyy/MM/dd hh:mm") & "TANGENG").GetHashCode
    End Function
#End Region

#Region "AS400SELECT查詢 方法:AS400SelectQuery"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SetSourceQueryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AS400SelectQuery(ByVal SetSourceQueryString As String) As DataTable
        Return CurrentCanUseQueryService.AS400SelectQueryGo(SetSourceQueryString, Me.WSDataQueryGetPassCode)
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
    Public Function AS400ExecuteNonQuery(ByVal SetSourceQueryString As String, ByVal AcceptCodeReplay As String) As Integer
        Return CurrentCanUseQueryService.AS400ExecuteNonQueryGo(SetSourceQueryString, Me.WSDataQueryGetPassCode)
    End Function
#End Region
#Region "SQLServerSELECT查詢 方法:SQLServerSelectQuery"
    ''' <summary>
    ''' SQLServerSELECT查詢
    ''' </summary>
    ''' <param name="SetSourceQueryString"></param>
    ''' <param name="SetSQLServerIPOrName"></param>
    ''' <param name="SetConnectDBName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SQLServerSelectQuery(ByVal SetSourceQueryString As String, ByVal SetSQLServerIPOrName As String, ByVal SetConnectDBName As String) As DataTable
        Return CurrentCanUseQueryService.SQLServerSelectQueryGo(SetSourceQueryString, SetSQLServerIPOrName, SetConnectDBName, Me.WSDataQueryGetPassCode)
    End Function
#End Region
#Region "SQLServerSELECT增刪修查詢 方法:SQLServerExecuteNonQuery"
    ''' <summary>
    ''' SQLServerSELECT增刪修查詢
    ''' </summary>
    ''' <param name="SetSourceQueryString"></param>
    ''' <param name="SetSQLServerIPOrName"></param>
    ''' <param name="SetConnectDBName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SQLServerExecuteNonQuery(ByVal SetSourceQueryString As String, ByVal SetSQLServerIPOrName As String, ByVal SetConnectDBName As String) As Integer
        Return CurrentCanUseQueryService.SQLServerExecuteNonQueryGo(SetSourceQueryString, SetSQLServerIPOrName, SetConnectDBName, Me.WSDataQueryGetPassCode)
    End Function
#End Region

End Class
