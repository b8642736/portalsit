Public Class SQLServerDBToVB

    Sub New(ByVal SetGetDataMoe As CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum, ByVal SetSQLServerName As CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum, ByVal SetConvertDBName As String, ByVal SetConvertDBTableName As String)
        Me.SourceSQLServerSQLQueryAdapter = New CompanyORMDB.SQLServerSQLQueryAdapter(SetGetDataMoe, SetSQLServerName, SetConvertDBName)
        Me.ConvertDBTableName = SetConvertDBTableName
    End Sub

#Region "SQLServer查詢配接器 屬性:SourceSQLServerSQLQueryAdapter"

    Private _SourceSQLServerSQLQueryAdapter As CompanyORMDB.SQLServerSQLQueryAdapter
    ''' <summary>
    ''' SQLServer查詢配接器
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceSQLServerSQLQueryAdapter() As CompanyORMDB.SQLServerSQLQueryAdapter
        Get
            Return _SourceSQLServerSQLQueryAdapter
        End Get
        Set(ByVal value As CompanyORMDB.SQLServerSQLQueryAdapter)
            _SourceSQLServerSQLQueryAdapter = value
        End Set
    End Property

#End Region
#Region "轉換資料庫的資料表名稱 屬性:ConvertDBTableName"

    Private _ConvertDBTableName As String
    ''' <summary>
    ''' 轉換資料庫的資料表名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ConvertDBTableName() As String
        Get
            Return _ConvertDBTableName
        End Get
        Private Set(ByVal value As String)
            _ConvertDBTableName = value
        End Set
    End Property


#End Region
#Region "下載VB文字程式碼檔  函式:DownTextVBCode"
    ''' <summary>
    ''' 下載VB文字程式碼檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub DownTextVBCode(ByVal SourceVBCodeString As String, ByVal SetFullFileName As String, ByVal SourcePage As Page)
        Call AS400DBToVB.DownTextVBCode(SourceVBCodeString, SetFullFileName, SourcePage)
    End Sub
#End Region
#Region "轉換欄位資料集合至VB程式碼 方法:ConvertFieldRowInfoToVBCode"
    ''' <summary>
    ''' 轉換欄位資料集合至VB程式碼
    ''' </summary>
    ''' <param name="InheritsClassName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConvertFieldRowInfoToVBCode(Optional ByVal InheritsClassName As String = "ClassDBSQLServer") As String
        Dim ReturnValue As String = Nothing
        ReturnValue &= vbNewLine & vbTab & "Sub New()"
        Dim Type1String As String = SourceSQLServerSQLQueryAdapter.GetDataMoe.GetType.ToString.Replace("+ConnectionMoeEnum", ".ConnectionMoeEnum." & SourceSQLServerSQLQueryAdapter.GetDataMoe.ToString)
        Dim Type2String As String = SourceSQLServerSQLQueryAdapter.SQLServerName.GetType.ToString.Replace("+ConnectServerNameEnum", ".ConnectServerNameEnum." & SourceSQLServerSQLQueryAdapter.SQLServerName.ToString)
        ReturnValue &= vbNewLine & vbTab & vbTab & "MyBase.New(" & Type1String & "," & Type2String & ",""" & SourceSQLServerSQLQueryAdapter.ConnectDBName & """)"
        ReturnValue &= vbNewLine & vbTab & "End Sub"
        ReturnValue &= vbNewLine
        Dim GetTable As DataTable = Me.SourceSQLServerSQLQueryAdapter.SelectQuery("Select * From " & ConvertDBTableName & " Where 1=2")
        For Each EachItem As Data.DataColumn In GetTable.Columns

            Dim TempFieldName As String = EachItem.Caption
            Dim IsPrimaryKeyFieldRow As Boolean = GetTable.PrimaryKey.Contains(EachItem)
            Dim FieldTypeString As String = EachItem.DataType.ToString
            ReturnValue &= vbNewLine & "#Region """ & EachItem.Caption & " 屬性:" & EachItem.Caption & """"
            ReturnValue &= vbNewLine & vbTab & "Private _" & EachItem.Caption & " As " & FieldTypeString
            ReturnValue &= vbNewLine & vbTab & "''' <summary>"
            ReturnValue &= vbNewLine & vbTab & "''' " & EachItem.Caption
            ReturnValue &= vbNewLine & vbTab & "''' </summary>"
            ReturnValue &= vbNewLine & vbTab & "''' <returns></returns>"
            ReturnValue &= vbNewLine & vbTab & "''' <remarks></remarks>"
            If IsPrimaryKeyFieldRow Then
                ReturnValue &= vbNewLine & vbTab & "<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _"
            End If
            ReturnValue &= vbNewLine & vbTab & "Public Property " & EachItem.Caption & " () As " & FieldTypeString
            ReturnValue &= vbNewLine & vbTab & vbTab & "Get"
            ReturnValue &= vbNewLine & vbTab & vbTab & vbTab & "Return _" & EachItem.Caption
            ReturnValue &= vbNewLine & vbTab & vbTab & "End Get"
            ReturnValue &= vbNewLine & vbTab & vbTab & "Set(Byval value as " & FieldTypeString & ")"
            ReturnValue &= vbNewLine & vbTab & vbTab & vbTab & "_" & EachItem.Caption & " = value"
            ReturnValue &= vbNewLine & vbTab & vbTab & "End Set"
            ReturnValue &= vbNewLine & vbTab & "End Property"
            ReturnValue &= vbNewLine & "#End Region"
        Next

        Dim ClassStartString As String = "Namespace SQLServer" & vbNewLine & vbTab & "Namespace " & SourceSQLServerSQLQueryAdapter.ConnectDBName & vbNewLine & vbTab & "Public Class "
        Dim ClassEndString As String = vbTab & "End Class" & vbNewLine & vbTab & "End Namespace" & vbNewLine & "End Namespace"
        If IsNothing(InheritsClassName) OrElse String.IsNullOrEmpty(InheritsClassName) Then
            ReturnValue = ClassStartString & ConvertDBTableName.Trim & vbNewLine & ReturnValue & vbNewLine & ClassEndString
        Else
            ReturnValue = ClassStartString & ConvertDBTableName.Trim & vbNewLine & vbTab & "Inherits " & InheritsClassName & vbNewLine & ReturnValue & vbNewLine & ClassEndString
        End If

        Return ReturnValue
    End Function
#End Region

End Class
