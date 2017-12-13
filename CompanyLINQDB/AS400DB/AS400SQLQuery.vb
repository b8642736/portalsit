Public Class AS400SQLQuery

#Region "建構式函"

    Sub New()

    End Sub

    Sub New(ByVal SetSourceQueryString As String)
        Me.SourceQueryString = SetSourceQueryString
    End Sub
    ''' <summary>
    ''' 建構式函
    ''' </summary>
    ''' <param name="SetSourceQueryString">SQL增刪修查詢</param>
    ''' <param name="SetOutputDataTableName">輸出資料表名稱</param>
    ''' <remarks></remarks>
    Sub New(ByVal SetSourceQueryString As String, ByVal SetOutputDataTableName As String)
        Me.SourceQueryString = SetSourceQueryString
        Me.OutputDataTableName = SetOutputDataTableName
    End Sub

    ''' <summary>
    ''' 建構式函
    ''' </summary>
    ''' <param name="SetSourceQueryString">SQL增刪修查詢</param>
    ''' <param name="SetOutputDataTableName">輸出資料表名稱</param>
    ''' <param name="SetSQLFromDBMemberIndicatory">SQL From 之後資料來源指示詞,告知為資料來源以供轉換,內定'@#'</param>
    ''' <remarks></remarks>
    Sub New(ByVal SetSourceQueryString As String, ByVal SetOutputDataTableName As String, ByVal SetSQLFromDBMemberIndicatory As String)
        Me.SourceQueryString = SetSourceQueryString
        Me.OutputDataTableName = SetOutputDataTableName
        Me.SQLFromDBMemberIndicatory = SetSQLFromDBMemberIndicatory
    End Sub
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
            ConvertAS400QueryAndToQueryFromParameters(value)
        End Set
    End Property


#End Region

#Region "SQL資料庫來源指示詞 屬性:SQLFromDBMemberIndicatory"

    Private _SQLFromDBMemberIndicatory As String = "@#"
    ''' <summary>
    ''' SQL資料庫來源指示詞（SQL From 之後資料來源指示詞,告知為資料來源以供轉換,內定'@#')
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SQLFromDBMemberIndicatory() As String
        Get
            Return _SQLFromDBMemberIndicatory
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                Exit Property
            End If
            _SQLFromDBMemberIndicatory = value
            ConvertAS400QueryAndToQueryFromParameters(Me.SourceQueryString)
        End Set
    End Property

#End Region

#Region "執行查詢字串 屬性:RunQueryString"

    Private _RunQueryString As String = Nothing
    ''' <summary>
    ''' 執行查詢字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RunQueryString() As String
        Get
            Dim Reurnvalue As String = Me.SourceQueryString.Replace(SQLFromDBMemberIndicatory, "")
            For Each EachItem In Me.QueryFromParameters
                If EachItem.IsUseMemberAccessMode = False Then
                    Continue For
                End If
                Dim ReplaceSourceString As String = EachItem.LibraryName & "." & EachItem.FileName & "." & EachItem.MemberName
                Dim ReplaceTargetString As String = EachItem.LibraryName & "." & EachItem.AS400DDMTempFileName
                Reurnvalue = Reurnvalue.Replace(ReplaceSourceString, ReplaceTargetString)
            Next
            Return Reurnvalue
        End Get
    End Property

#End Region

#Region "轉換AS400查詢字串 函式:ConvertAS400Query"
    ''' <summary>
    ''' 轉換AS400查詢字串
    ''' </summary>
    ''' <param name="SourceString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertAS400QueryAndToQueryFromParameters(ByVal SourceString As String) As String
        QueryFromParameters.Clear()
        If String.IsNullOrEmpty(SourceString) Then
            Return Nothing
        End If
        For Each EachItem As String In (From A In SourceString.Split(" ") Where A.Contains(SQLFromDBMemberIndicatory) Select A).ToList
            Dim EachItemString As String = EachItem
            If Not (From A In QueryFromParameters Where A.OrginParameterString = EachItemString Select A).Any Then
                QueryFromParameters.Add(New SQLFromParameterClass(EachItem, Me.SQLFromDBMemberIndicatory))
            End If
        Next
        Return IIf(QueryFromParameters.Count = 0, SourceString, SourceString.Replace(SQLFromDBMemberIndicatory, ""))
    End Function
#End Region

#Region "查詢資料來源參數 屬性:QueryFromParameters"

    Private _QueryFromParameters As List(Of SQLFromParameterClass) = New List(Of SQLFromParameterClass)
    ''' <summary>
    ''' 查詢資料來源參數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property QueryFromParameters() As List(Of SQLFromParameterClass)
        Get
            Return _QueryFromParameters
        End Get
        Set(ByVal value As List(Of SQLFromParameterClass))
            _QueryFromParameters = value
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
    Public Overridable Function SelectQuery(Optional ByVal SetSourceQueryString As String = Nothing) As DataTable
        If Not IsNothing(SetSourceQueryString) Then
            Me.SourceQueryString = SetSourceQueryString
        End If
        Dim ReturnValue As DataTable = New DataTable(OutputDataTableName)
        Dim CN As Odbc.OdbcConnection = New Odbc.OdbcConnection(My.Settings.As400)
        Try
            SQLFromParameterClass.OpenAs400DDMTempFile(Me.QueryFromParameters)
            Dim myCommand As Odbc.OdbcCommand = New Odbc.OdbcCommand(Me.RunQueryString, CN)
            Dim NewAdapter = New Odbc.OdbcDataAdapter(myCommand)
            ReturnValue = New DataTable(OutputDataTableName)
            NewAdapter.Fill(ReturnValue)
        Catch ex As Exception
            SQLFromParameterClass.CloseAs400DDMTempFile(Me.QueryFromParameters)
            Throw ex
        Finally
            SQLFromParameterClass.CloseAs400DDMTempFile(Me.QueryFromParameters)
        End Try
        Return ReturnValue
    End Function
#End Region
#Region "SQLExecute查詢 方法:ExecuteNonQuery"
    ''' <summary>
    ''' SQLExecute查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function ExecuteNonQuery(Optional ByVal SetSourceQueryString As String = Nothing) As Integer
        If Not IsNothing(SetSourceQueryString) Then
            Me.SourceQueryString = SetSourceQueryString
        End If
        Dim CN As Odbc.OdbcConnection = New Odbc.OdbcConnection(My.Settings.As400)
        Dim ReturnValue As Integer = 0
        Try
            SQLFromParameterClass.OpenAs400DDMTempFile(Me.QueryFromParameters)
            Dim myCommand As Odbc.OdbcCommand = New Odbc.OdbcCommand(Me.RunQueryString, CN)
            CN.Open()
            ReturnValue = myCommand.ExecuteNonQuery()
        Catch ex As Exception
            SQLFromParameterClass.CloseAs400DDMTempFile(Me.QueryFromParameters)
            If CN.State <> ConnectionState.Closed Then
                CN.Close()
            End If
            Throw ex
        Finally
            SQLFromParameterClass.CloseAs400DDMTempFile(Me.QueryFromParameters)
            If CN.State <> ConnectionState.Closed Then
                CN.Close()
            End If
        End Try
        Return ReturnValue
    End Function
#End Region

    Protected Overrides Sub Finalize()
        If Me.QueryFromParameters.Count > 0 Then
            SQLFromParameterClass.CloseAs400DDMTempFile(Me.QueryFromParameters)
        End If
        MyBase.Finalize()
    End Sub

#Region "SQLFrom參數類別 類別:SQLFromParameterClass"
    ''' <summary>
    ''' SQLFrom參數類別
    ''' </summary>
    ''' <remarks></remarks>
    Class SQLFromParameterClass

        Sub New(ByVal SetOrginParameterString As String)
            Me.OrginParameterString = SetOrginParameterString
        End Sub
        Sub New(ByVal SetOrginParameterString As String, ByVal SetSQLFromDBMemberIndicator As String)
            Me.OrginParameterString = SetOrginParameterString
            Me.SQLFromDBMemberIndicatory = SetSQLFromDBMemberIndicator
        End Sub


#Region "SQL資料庫來源指示詞 屬性:SQLFromDBMemberIndicatory"

        Private _SQLFromDBMemberIndicatory As String = "@#"
        ''' <summary>
        ''' SQL資料庫來源指示詞
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SQLFromDBMemberIndicatory() As String
            Get
                Return _SQLFromDBMemberIndicatory
            End Get
            Set(ByVal value As String)
                If String.IsNullOrEmpty(value) Then
                    Exit Property
                End If
                _SQLFromDBMemberIndicatory = value
                DecomposeOrginParameterStringName(OrginParameterString)
            End Set
        End Property

#End Region
#Region "開始暫存Member連結檔 Shared函式:OpenAs400DDMTempFile"
        Public Shared Sub OpenAs400DDMTempFile(ByVal OpenSQLFromParameterClasses As List(Of SQLFromParameterClass))
            Dim CN As New Odbc.OdbcConnection(My.Settings.As400)
            Dim myCommand As Odbc.OdbcCommand
            CN.Open()
            Try
                For Each EachItem As SQLFromParameterClass In (From A In OpenSQLFromParameterClasses Where A.IsUseMemberAccessMode = True Select A).ToList
                    myCommand = New Odbc.OdbcCommand("CREATE ALIAS " & EachItem.LibraryName & "." & EachItem.AS400DDMTempFileName & " FOR " & EachItem.LibraryName & "." & EachItem.FileName & " (" & EachItem.MemberName & ")", CN)
                    myCommand.ExecuteNonQuery()
                    EachItem.IsCreatedDDMFile = True
                Next
            Catch ex As Exception
                CloseAs400DDMTempFile(OpenSQLFromParameterClasses)
                Throw ex
            Finally
                CN.Close()
            End Try
        End Sub
#End Region
#Region "關閉暫存Member連結檔 Shared函式:CloseAs400DDMTempFile"
        ''' <summary>
        ''' 關閉暫存Member連結檔
        ''' </summary>
        ''' <param name="CloseSQLFromParameterClasses"></param>
        ''' <remarks></remarks>
        Public Shared Sub CloseAs400DDMTempFile(ByVal CloseSQLFromParameterClasses As List(Of SQLFromParameterClass))
            Dim CN As New Odbc.OdbcConnection(My.Settings.As400)
            Dim myCommand As Odbc.OdbcCommand
            CN.Open()
            Try
                For Each EachItem As SQLFromParameterClass In (From A In CloseSQLFromParameterClasses Where A.IsUseMemberAccessMode = True And A.IsCreatedDDMFile = True Select A).ToList
                    myCommand = New Odbc.OdbcCommand("drop alias " & EachItem.LibraryName & "." & EachItem.AS400DDMTempFileName, CN)
                    myCommand.ExecuteNonQuery()
                    EachItem.IsCreatedDDMFile = False
                Next
            Catch ex As Exception
                Throw ex
            Finally
                CN.Close()
            End Try
        End Sub
#End Region


#Region "原始參數字串 屬性:OrginParameterString"

        Private _OrginParameterString As String
        ''' <summary>
        ''' 原始參數字串
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property OrginParameterString() As String
            Get
                Return _OrginParameterString
            End Get
            Set(ByVal value As String)
                _OrginParameterString = value
                DecomposeOrginParameterStringName(_OrginParameterString)
            End Set
        End Property
#End Region
#Region "分解原始參數字串 函式:DecomposeOrginParameterStringName"
        ''' <summary>
        ''' 分解原始參數字串
        ''' </summary>
        ''' <param name="OrginName"></param>
        ''' <remarks></remarks>
        Private Sub DecomposeOrginParameterStringName(ByVal OrginName As String)
            Dim StringTokens() As String = OrginName.Replace(SQLFromDBMemberIndicatory, "").Split(".")
            Me.AS400DDMTempFileName = Nothing
            Me.IsUseMemberAccessMode = False
            Me.LibraryName = Nothing
            Me.FileName = Nothing
            Me.MemberName = Nothing
            Select Case True
                Case StringTokens.Length > 3 OrElse StringTokens.Length < 2
                    Throw New Exception("From之後原始參數字串輸入有誤!")
                    Exit Sub
                Case StringTokens.Length = 2
                    Me.LibraryName = StringTokens(0)
                    Me.FileName = StringTokens(1)
                    Me.IsUseMemberAccessMode = False
                Case StringTokens.Length = 3
                    Me.LibraryName = StringTokens(0)
                    Me.FileName = StringTokens(1)
                    Me.MemberName = StringTokens(2)
                    Me.IsUseMemberAccessMode = True
            End Select
        End Sub
#End Region

#Region "是否使用Member存取模式 屬性:IsUseMemberAccessMode"

        Private _IsUseMemberAccessMode As Boolean = False
        ''' <summary>
        ''' 是否使用Member存取模式
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsUseMemberAccessMode() As Boolean
            Get
                Return _IsUseMemberAccessMode
            End Get
            Private Set(ByVal value As Boolean)
                _IsUseMemberAccessMode = value
            End Set
        End Property

#End Region
#Region "函式庫名稱 屬性:LibraryName"

        Private _LibraryName As String = Nothing
        Public Property LibraryName() As String
            Get
                Return _LibraryName
            End Get
            Private Set(ByVal value As String)
                _LibraryName = value
            End Set
        End Property

#End Region
#Region "檔案名稱 屬性:FileName"

        Private _FileName As String = Nothing
        ''' <summary>
        ''' 檔案名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FileName() As String
            Get
                Return _FileName
            End Get
            Private Set(ByVal value As String)
                _FileName = value
            End Set
        End Property

#End Region
#Region "成員名稱 屬性:MemberName"

        Private _MemberName As String = Nothing
        ''' <summary>
        ''' 成員名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MemberName() As String
            Get
                Return _MemberName
            End Get
            Private Set(ByVal value As String)
                _MemberName = value
            End Set
        End Property

#End Region

#Region "AS400暫存Member連結檔 屬性:AS400DDMTempFileName"
        Private _AS400DDMTempFileName As String = Nothing
        ''' <summary>
        ''' AS400暫存Member連結檔
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property AS400DDMTempFileName() As String
            Get
                If IsNothing(_AS400DDMTempFileName) Then
                    _AS400DDMTempFileName = "ODB" & Format(Now, "mmssfff").ToString
                End If
                Return _AS400DDMTempFileName
            End Get
            Private Set(ByVal value As String)
                _AS400DDMTempFileName = value
            End Set
        End Property
#End Region
#Region "是否已開啟IsCreatedDDMFile 屬性:IsCreatedDDMFile"

        Private _IsCreatedDDMFile As Boolean = False
        ''' <summary>
        ''' 是否已開啟IsCreatedDDMFil
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Property IsCreatedDDMFile() As Boolean
            Get
                Return _IsCreatedDDMFile
            End Get
            Set(ByVal value As Boolean)
                _IsCreatedDDMFile = value
            End Set
        End Property


#End Region

    End Class
#End Region

End Class
