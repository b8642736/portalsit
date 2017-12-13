''' <summary>
''' SQLServer查詢配接器
''' </summary>
''' <remarks></remarks>
Public Class SQLServerSQLQueryAdapter
    Implements IAS400QueryAdapter


#Region "建構式函"

    Sub New(ByVal SetGetDataMoe As ConnectionMoeEnum, ByVal SetSQLServerName As ConnectServerNameEnum, ByVal SetConnectDBName As String)
        Me.SQLServerName = SetSQLServerName
        Me.ConnectDBName = SetConnectDBName
        Me.GetDataMoe = SetGetDataMoe
    End Sub

    Sub New(ByVal SetGetDataMoe As ConnectionMoeEnum, ByVal SetSQLServerName As ConnectServerNameEnum, ByVal SetConnectDBName As String, ByVal SetSourceQueryString As String)
        Me.SourceQueryString = SetSourceQueryString
        Me.SQLServerName = SetSQLServerName
        Me.ConnectDBName = SetConnectDBName
        Me.GetDataMoe = SetGetDataMoe
    End Sub
    ''' <summary>
    ''' 建構式函
    ''' </summary>
    ''' <param name="SetSourceQueryString">SQL增刪修查詢</param>
    ''' <param name="SetOutputDataTableName">輸出資料表名稱</param>
    ''' <remarks></remarks>
    Sub New(ByVal SetGetDataMoe As ConnectionMoeEnum, ByVal SetSQLServerName As ConnectServerNameEnum, ByVal SetConnectDBName As String, ByVal SetSourceQueryString As String, ByVal SetOutputDataTableName As String)
        Me.SourceQueryString = SetSourceQueryString
        Me.SQLServerName = SetSQLServerName
        Me.ConnectDBName = SetConnectDBName
        Me.GetDataMoe = SetGetDataMoe
        Me.OutputDataTableName = SetOutputDataTableName
    End Sub

#End Region


#Region "取得資料模式 屬性:GetDataMoe"

    Private _GetDataMoe As ConnectionMoeEnum = ConnectionMoeEnum.WebService
    ''' <summary>
    ''' 取得資料模式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GetDataMoe() As ConnectionMoeEnum
        Get
            Return _GetDataMoe
        End Get
        Set(ByVal value As ConnectionMoeEnum)
            If value = ConnectionMoeEnum.ADO AndAlso Me.SQLServerName = ConnectServerNameEnum.UnKnow Then
                Throw New Exception("設定ADO連線必須先設定連線之SQL伺服器!")
            End If
            _GetDataMoe = value
        End Set
    End Property

#End Region
#Region "SQL伺服器名稱 屬性:SQLServerName"

    Private _SQLServerName As ConnectServerNameEnum
    ''' <summary>
    ''' SQL伺服器名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SQLServerName() As ConnectServerNameEnum
        Get
            Return _SQLServerName
        End Get
        Set(ByVal value As ConnectServerNameEnum)
            _SQLServerName = value
            SqlConnection = Nothing
        End Set
    End Property
#End Region
#Region "SQL伺服器名稱字串 屬性:SQLServerNameString"
    ''' <summary>
    ''' SQL伺服器名稱字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SQLServerNameString() As String
        Get
            Select Case SQLServerName
                Case ConnectServerNameEnum.Server04m
                    Return "SERVER0SM"
                Case ConnectServerNameEnum.Server0SM
                    Return "SERVER04M"
                Case ConnectServerNameEnum.ServerSPM
                    Return "SERVERSPM"
            End Select
            Return Nothing
        End Get
    End Property
#End Region
#Region "連線資料庫名稱 屬性:ConnectDBName"

    Private _ConnectDBName As String
    ''' <summary>
    ''' 連線資料庫名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ConnectDBName() As String
        Get
            Return _ConnectDBName
        End Get
        Set(ByVal value As String)
            _ConnectDBName = value
            SqlConnection = Nothing
        End Set
    End Property

#End Region
#Region "SqlConnection連線物件 屬性:SqlConnection"

    Private _SqlConnection As SqlClient.SqlConnection
    ''' <summary>
    ''' SqlConnection連線物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SqlConnection() As SqlClient.SqlConnection
        Get
            If IsNothing(_SqlConnection) Then
                If IsNothing(SqlConnectionString) Then
                    Return Nothing
                End If
                _SqlConnection = New SqlClient.SqlConnection(SqlConnectionString)
            End If
            Return _SqlConnection
        End Get
        Private Set(ByVal value As SqlClient.SqlConnection)
            _SqlConnection = value
        End Set
    End Property

#End Region
#Region "SqlConnection連線字串 屬性:SqlConnectionString"
    ''' <summary>
    ''' SqlConnection連線字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SqlConnectionString() As String
        Get
            If Not String.IsNullOrEmpty(GlobalReplaceSqlConnectionString) Then
                Dim ConnStrings() As String = GlobalReplaceSqlConnectionString.Split(";")
                If ConnStrings.Length > 2 Then
                    ConnStrings(1) = "Initial Catalog=" & Me.ConnectDBName
                End If
                Dim SetConnString As String = ""
                For ArrCount As Integer = 0 To ConnStrings.Length - 1
                    SetConnString &= ConnStrings(ArrCount) & ";"
                Next
                Return SetConnString ' GlobalReplaceSqlConnectionString.Replace("QCdb01", Me.ConnectDBName)
            End If
            Dim ConnectionString As String = Nothing
            Select Case SQLServerName
                Case ConnectServerNameEnum.Server0SM
                    ConnectionString = My.Settings.Server04m
                    '將預設資料庫變更為指定資料庫
                    ConnectionString = ConnectionString.Replace("QCdb01", Me.ConnectDBName)
                Case ConnectServerNameEnum.Server04m
                    ConnectionString = My.Settings.Server04m
                    '將預設資料庫變更為指定資料庫
                    ConnectionString = ConnectionString.Replace("QCdb01", Me.ConnectDBName)
                Case ConnectServerNameEnum.ServerSPM
                    ConnectionString = My.Settings.ServerSPM
                    '將預設資料庫變更為指定資料庫
                    ConnectionString = ConnectionString.Replace("SPM", Me.ConnectDBName)
                Case ConnectServerNameEnum.UnKnow
                    Return Nothing
            End Select

            Return ConnectionString
        End Get
    End Property
#End Region
#Region "全域取代連線字串 屬性:GlobalReplaceSqlConnectionString"
    ''' <summary>
    ''' 全域取代連線字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>如有設定可取代SqlConnectionString輸出結果,做為測試DB伺服器用途</remarks>
    Shared Property GlobalReplaceSqlConnectionString As String = ""
#End Region
#Region "WEBServiceSQL查詢轉接器 屬性:WebServiceSQLQueryAdapter"

    Private _WebServiceSQLQueryAdapter As WSDBSQLQueryAdapter
    ''' <summary>
    ''' WEBServiceSQL查詢轉接器
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WebServiceSQLQueryAdapter() As WSDBSQLQueryAdapter
        Get
            If IsNothing(_WebServiceSQLQueryAdapter) Then
                _WebServiceSQLQueryAdapter = New WSDBSQLQueryAdapter(True)
            End If
            Return _WebServiceSQLQueryAdapter
        End Get
        Set(ByVal value As WSDBSQLQueryAdapter)
            _WebServiceSQLQueryAdapter = value
        End Set
    End Property

#End Region


#Region "輸出資料表名稱 屬性:OutputDataTableName"

    Private _OutputDataTableName As String = Nothing
    ''' <summary>
    ''' 輸出資料表名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OutputDataTableName() As String
        Get
            Return _OutputDataTableName
        End Get
        Set(ByVal value As String)
            _OutputDataTableName = value
        End Set
    End Property

#End Region
#Region "查詢字串 屬性:SourceQueryString"

    Private _SourceQueryString As String = Nothing
    ''' <summary>
    ''' 查詢字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceQueryString() As String
        Get
            Return _SourceQueryString
        End Get
        Set(ByVal value As String)
            _SourceQueryString = value
        End Set
    End Property


#End Region
#Region "查詢類型 屬性:QueryType"
    ''' <summary>
    ''' 查詢類型
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property QueryType() As QueryTypeEnum
        Get
            If String.IsNullOrEmpty(SourceQueryString) OrElse SourceQueryString.Length < 5 Then
                Return QueryTypeEnum.UnKnowType
            End If
            Dim SQLString As String = Me.SourceQueryString.Trim.ToUpper
            Dim IsSelectMode As Boolean = SQLString.Substring(0, 6) = "SELECT"
            Dim IsInsertMode As Boolean = SQLString.Substring(0, 6) = "INSERT"
            Dim IsUpdateMode As Boolean = SQLString.Substring(0, 6) = "UPDATE"
            Dim IsDeleteMode As Boolean = SQLString.Substring(0, 6) = "DELETE"
            Select Case True
                Case IsSelectMode And Not IsInsertMode And Not IsUpdateMode And Not IsDeleteMode
                    Return QueryTypeEnum.SelectType
                Case Not IsSelectMode And IsInsertMode And Not IsUpdateMode And Not IsDeleteMode
                    Return QueryTypeEnum.InsertType
                Case Not IsSelectMode And Not IsInsertMode And IsUpdateMode And Not IsDeleteMode
                    Return QueryTypeEnum.UpdateType
                Case Not IsSelectMode And Not IsInsertMode And Not IsUpdateMode And IsDeleteMode
                    Return QueryTypeEnum.DeleteType
            End Select
            Return QueryTypeEnum.UnKnowType
        End Get
    End Property
#End Region
#Region "查詢類型列舉 屬性:QueryTypeEnum"
    ''' <summary>
    ''' 查詢類型列舉
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum QueryTypeEnum
        UnKnowType = 0
        SelectType = 1
        InsertType = 2
        UpdateType = 3
        DeleteType = 4
    End Enum
#End Region


#Region "Select查詢 方法:SelectQuery"
    ''' <summary>
    ''' Select查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function SelectQuery() As DataTable
        Return SelectQuery(Me.SourceQueryString)
    End Function


    Public Overridable Function SelectQuery(ByVal SetSourceQueryString As String) As System.Data.DataTable Implements IAS400QueryAdapter.SelectQueryGo
        If Not IsNothing(SetSourceQueryString) Then
            Me.SourceQueryString = SetSourceQueryString
        End If
        Dim ReturnValue As DataTable
        If Me.GetDataMoe = ConnectionMoeEnum.ADO Then
            Try
                Dim myCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand(Me.SourceQueryString, SqlConnection)
                Dim NewAdapter = New SqlClient.SqlDataAdapter(myCommand)
                ReturnValue = New DataTable(OutputDataTableName)

                '1020301 by renhsin
                NewAdapter.FillSchema(ReturnValue, SchemaType.Mapped)

                NewAdapter.Fill(ReturnValue)

            Catch ex As Exception
                If Me.SqlConnection.State <> ConnectionState.Closed Then
                    Me.SqlConnection.Close()
                End If
                Throw ex
            Finally
                If Me.SqlConnection.State <> ConnectionState.Closed Then
                    Me.SqlConnection.Close()
                End If
            End Try
        Else
            ReturnValue = WebServiceSQLQueryAdapter.SQLServerSelectQuery(SetSourceQueryString, Me.SqlConnectionString)
            ReturnValue.TableName = OutputDataTableName
        End If

        Return ReturnValue

    End Function
#End Region
#Region "SQLExecute查詢 方法:ExecuteNonQuery"
    ''' <summary>
    ''' SQLExecute查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function ExecuteNonQuery() As Integer
        Return ExecuteNonQuery(Me.SourceQueryString)
    End Function

    Public Overridable Function ExecuteNonQuery(ByVal SetSourceQueryString As String) As Integer Implements IAS400QueryAdapter.ExecuteNonQueryGo
        If Not IsNothing(SetSourceQueryString) Then
            Me.SourceQueryString = SetSourceQueryString
        End If
        Dim ReturnValue As Integer = 0
        If Me.GetDataMoe = ConnectionMoeEnum.ADO Then
            Try
                Dim myCommand As SqlClient.SqlCommand = New SqlClient.SqlCommand(Me.SourceQueryString, Me.SqlConnection)
                Me.SqlConnection.Open()
                ReturnValue = myCommand.ExecuteNonQuery()
            Catch ex As Exception
                If Me.SqlConnection.State <> ConnectionState.Closed Then
                    Me.SqlConnection.Close()
                End If
                Throw ex
            Finally
                If Me.SqlConnection.State <> ConnectionState.Closed Then
                    Me.SqlConnection.Close()
                End If
            End Try
        Else
            ReturnValue = WebServiceSQLQueryAdapter.SQLServerExecuteNonQuery(SetSourceQueryString, Me.SqlConnectionString)
        End If
        Return ReturnValue

    End Function

#End Region


#Region "連線模式列舉 屬性:ConnectionMoeEnum"
    ''' <summary>
    ''' 連線模式列舉
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ConnectionMoeEnum
        ADO = 1
        WebService = 2
    End Enum
#End Region

#Region "連線資料伺服器稱列舉 列舉:ConnectServerNameEnum"
    ''' <summary>
    ''' 連線資料伺服器稱列舉
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ConnectServerNameEnum
        Server0SM = 1
        Server04m = 2
        ServerSPM = 3
        UnKnow = 99
    End Enum
#End Region




End Class
