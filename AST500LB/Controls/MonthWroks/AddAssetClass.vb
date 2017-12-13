Public Class AddAssetClass
    Inherits CompanyORMDB.AST501LB.AST001PF

#Region "入帳單字號 屬性:PNO"
    Private _PNO As String
    ''' <summary>
    ''' 入帳單字號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PNO() As String
        Get
            Return _PNO
        End Get
        Set(ByVal value As String)
            _PNO = value
        End Set
    End Property

#End Region
#Region "設備規格1  屬性:SPEC1"
    Private _SPEC1 As String
    ''' <summary>
    ''' 設備規格1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SPEC1() As String
        Get
            Return _SPEC1
        End Get
        Set(ByVal value As String)
            _SPEC1 = value
        End Set
    End Property

#End Region
#Region "設備規格2  屬性:SPEC2"
    Private _SPEC2 As String
    ''' <summary>
    ''' 設備規格2
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SPEC2() As String
        Get
            Return _SPEC2
        End Get
        Set(ByVal value As String)
            _SPEC2 = value
        End Set
    End Property

#End Region
#Region "採購案號 屬性:PURNO"
    Private _PURNO As String
    ''' <summary>
    ''' 採購案號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PURNO() As String
        Get
            Return _PURNO
        End Get
        Set(ByVal value As String)
            _PURNO = value
        End Set
    End Property

#End Region
#Region "供應廠商統一編號 屬性:MTSV001"
    Private _MTSV001 As String
    ''' <summary>
    ''' 供應廠商統一編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MTSV001() As String
        Get
            Return _MTSV001
        End Get
        Set(ByVal value As String)
            If value <> _MTSV001 Then
                About_MTSV01PF = Nothing
            End If
            _MTSV001 = value
        End Set
    End Property
#End Region

#Region "相關供應廠商資料 屬性:About_MTSV01PF"
    Private _About_MTSV01PF As CompanyORMDB.MTS600LB.MTSV01PF
    Private _About_MTSV01PFSearched As Boolean = False
    ''' <summary>
    ''' 相關供應廠商資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property About_MTSV01PF() As CompanyORMDB.MTS600LB.MTSV01PF
        Get
            If _About_MTSV01PFSearched = False AndAlso IsNothing(_About_MTSV01PF) Then
                Dim Qry As String = "Select * from @#MTS600LB.MTSV01PF Where MTS01='" & Me.MTSV001.Trim & "'"
                Dim SearchResult As List(Of CompanyORMDB.MTS600LB.MTSV01PF) = CompanyORMDB.MTS600LB.MTSV01PF.CDBSelect(Of CompanyORMDB.MTS600LB.MTSV01PF)(Qry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                _About_MTSV01PF = (From A In SearchResult Select A).FirstOrDefault
                _About_MTSV01PFSearched = True
            End If
            Return _About_MTSV01PF
        End Get
        Private Set(ByVal value As CompanyORMDB.MTS600LB.MTSV01PF)
            _About_MTSV01PF = value
            _About_MTSV01PFSearched = False
        End Set
    End Property
#End Region

End Class
