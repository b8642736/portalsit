Public Class AS400DBToVB

    Sub New(ByVal SetDBLibraryName As String, ByVal SetDBFileName As String, ByVal SetDBMemberName As String)
        DBLibraryName = SetDBLibraryName.Trim
        DBFileName = SetDBFileName.Trim
        Me.DBMemberName = SetDBMemberName.Trim
        SourceAS400SQLQueryAdapter = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, "Select * from @#" & SetDBLibraryName.Trim & "." & SetDBFileName.Trim & "." & SetDBMemberName.Trim)
    End Sub

#Region "SQLServer查詢配接器 屬性:SourceSQLServerSQLQueryAdapter"

    Private _SourceAS400SQLQueryAdapter As CompanyORMDB.AS400SQLQueryAdapter
    ''' <summary>
    ''' SQLServer查詢配接器
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceAS400SQLQueryAdapter() As CompanyORMDB.AS400SQLQueryAdapter
        Get
            Return _SourceAS400SQLQueryAdapter
        End Get
        Set(ByVal value As CompanyORMDB.AS400SQLQueryAdapter)
            _SourceAS400SQLQueryAdapter = value
        End Set
    End Property

#End Region




#Region "原始檔文字 屬性:SourceFileString"

    Private _SourceFileString As String
    ''' <summary>
    ''' 原始檔文字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceFileString() As String
        Get
            Return _SourceFileString
        End Get
        Set(ByVal value As String)
            _SourceFileString = value
        End Set
    End Property

#End Region
#Region "DBLibraryName 屬性:DBLibraryName"

    Private _DBLibraryName As String
    Public Property DBLibraryName() As String
        Get
            Return _DBLibraryName
        End Get
        Private Set(ByVal value As String)
            _DBLibraryName = value
        End Set
    End Property

#End Region
#Region "DBFileName 屬性:DBFileName"

    Private _DBFileName As String
    Public Property DBFileName() As String
        Get
            Return _DBFileName
        End Get
        Private Set(ByVal value As String)
            _DBFileName = value
        End Set
    End Property

#End Region
#Region "DBMemberName 屬性:DBMemberName"

    Private _DBMemberName As String
    Public Property DBMemberName() As String
        Get
            Return _DBMemberName
        End Get
        Set(ByVal value As String)
            _DBMemberName = value
        End Set
    End Property

#End Region
#Region "原始檔文字資料行 屬性:SourceFileLinesData"
    Private _SourceFileLinesData As List(Of String)
    ''' <summary>
    ''' 原始檔文字資料行
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SourceFileLinesData() As List(Of String)
        Get
            If IsNothing(_SourceFileLinesData) Then
                _SourceFileLinesData = New List(Of String)
                For Each EachItem As String In SourceFileString.Split(vbCr)
                    _SourceFileLinesData.Add(EachItem.Replace(vbLf, Nothing))
                Next
            End If
            Return _SourceFileLinesData
        End Get
        Private Set(ByVal value As List(Of String))
            _SourceFileLinesData = value
        End Set
    End Property
#End Region
#Region "欄位資料集合 屬性:FieldsRowInformation"

    Private _FieldsRowInformation As List(Of RowInformation)
    ''' <summary>
    ''' 欄位資料集合
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FieldsRowInformation() As List(Of RowInformation)
        Get
            If IsNothing(_FieldsRowInformation) Then
                _FieldsRowInformation = New List(Of RowInformation)
                Dim QueryTable As DataTable = Me.SourceAS400SQLQueryAdapter.SelectQuery
                For Each EachItem As DataRow In QueryTable.Rows
                    _FieldsRowInformation.Add(New RowInformation(EachItem, QueryTable))
                Next
            End If
            Return _FieldsRowInformation
        End Get
        Private Set(ByVal value As List(Of RowInformation))
            _FieldsRowInformation = value
        End Set
    End Property

#End Region

#Region "下載VB文字程式碼檔  函式:DownTextVBCode"
    ''' <summary>
    ''' 下載VB文字程式碼檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub DownTextVBCode(ByVal SourceVBCodeString As String, ByVal SetFullFileName As String, ByVal SourcePage As Page)
        SourcePage.Response.Clear()
        SourcePage.Response.Buffer = True
        SourcePage.Response.Charset = ""
        SourcePage.Response.AddHeader("Accept-Language", "zh-tw")
        SourcePage.Response.AddHeader("Content-Disposition", "Attachment;FileName=" + System.Web.HttpUtility.UrlEncode(SetFullFileName, System.Text.Encoding.UTF8))
        SourcePage.Response.ContentType = "application/octet-stream"

        SourcePage.Response.Write(SourceVBCodeString)
        SourcePage.Response.Flush()
        SourcePage.Response.End()

    End Sub
#End Region

#Region "轉換欄位資料集合至VB程式碼 方法:ConvertFieldRowInfoToVBCode"
    ''' <summary>
    ''' 轉換欄位資料集合至VB程式碼
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConvertFieldRowInfoToVBCode(Optional ByVal InheritsClassName As String = "ClassDBAS400") As String
        Dim ReturnValue As String = Nothing
        ReturnValue &= vbNewLine & vbTab & "Sub New()"
        ReturnValue &= vbNewLine & vbTab & vbTab & "MyBase.New(""" & Me.DBLibraryName.Trim & """, GetType(" & Me.DBMemberName.Trim & ").Name)"
        ReturnValue &= vbNewLine & vbTab & "End Sub"
        ReturnValue &= vbNewLine

        For Each EachItem As RowInformation In FieldsRowInformation
            If EachItem.IsField = False Then
                'Dim temp As Object = EachItem.IsField
                'If (temp Is Nothing) = False AndAlso EachItem.IsField = False Then
                Continue For
            End If


            Dim TempFieldName As String = EachItem.FieldName
            Dim FieldTypeString As String = EachItem.FieldForAPDataType.ToString
            ReturnValue &= vbNewLine & "#Region """ & EachItem.FieldCOLHDG & " 屬性:" & EachItem.FieldName & """"
            ReturnValue &= vbNewLine & vbTab & "Private _" & EachItem.FieldName & " As " & FieldTypeString
            ReturnValue &= vbNewLine & vbTab & "''' <summary>"
            ReturnValue &= vbNewLine & vbTab & "''' " & EachItem.FieldCOLHDG
            ReturnValue &= vbNewLine & vbTab & "''' </summary>"
            ReturnValue &= vbNewLine & vbTab & "''' <returns></returns>"
            ReturnValue &= vbNewLine & vbTab & "''' <remarks></remarks>"
            If EachItem.IsPKField Then
                ReturnValue &= vbNewLine & vbTab & "<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _"
            End If
            ReturnValue &= vbNewLine & vbTab & "Public Property " & EachItem.FieldName & " () As " & FieldTypeString
            ReturnValue &= vbNewLine & vbTab & vbTab & "Get"
            ReturnValue &= vbNewLine & vbTab & vbTab & vbTab & "Return _" & EachItem.FieldName
            ReturnValue &= vbNewLine & vbTab & vbTab & "End Get"
            ReturnValue &= vbNewLine & vbTab & vbTab & "Set(Byval value as " & FieldTypeString & ")"
            ReturnValue &= vbNewLine & vbTab & vbTab & vbTab & "_" & EachItem.FieldName & " = value"
            ReturnValue &= vbNewLine & vbTab & vbTab & "End Set"
            ReturnValue &= vbNewLine & vbTab & "End Property"
            ReturnValue &= vbNewLine & "#End Region"
        Next

        If IsNothing(InheritsClassName) OrElse String.IsNullOrEmpty(InheritsClassName) Then
            ReturnValue = "Public Class " & Me.DBMemberName.Trim & vbNewLine & ReturnValue & vbNewLine & "End Class"
        Else
            ReturnValue = "Public Class " & Me.DBMemberName.Trim & vbNewLine & vbTab & "Inherits " & InheritsClassName & vbNewLine & ReturnValue & vbNewLine & "End Class"
        End If
        ReturnValue = "Namespace " & Me.DBLibraryName & vbNewLine & ReturnValue & vbNewLine & "End Namespace"
        Return ReturnValue
    End Function
#End Region


End Class

Public Class RowInformation

    Sub New(ByVal SetSourceDataRow As DataRow, ByVal SetSourceDataTable As DataTable)
        Me.SourceDataRow = SetSourceDataRow
        Me.SourceDataTable = SetSourceDataTable
    End Sub

#Region "原始資料DataTable 屬性:SourceDataTable"

    Private _SourceDataTable As DataTable
    ''' <summary>
    ''' 原始資料DataTable
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceDataTable() As DataTable
        Get
            Return _SourceDataTable
        End Get
        Private Set(ByVal value As DataTable)
            _SourceDataTable = value
        End Set
    End Property


#End Region
#Region "原始資料行 屬性:SourceDataRow"

    Private _SourceDataRow As DataRow
    ''' <summary>
    ''' 原始資料行
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceDataRow() As DataRow
        Get
            Return _SourceDataRow
        End Get
        Set(ByVal value As DataRow)
            _SourceDataRow = value
        End Set
    End Property

#End Region
#Region "原始資料行SRCDTA欄位值 屬性:SourceDataRowField_SRCDTA"
    Private _SourceDataRowField_SRCDTA As String
    ''' <summary>
    ''' 原始資料行SRCDTA欄位值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SourceDataRowField_SRCDTA() As String
        Get
            If IsNothing(_SourceDataRowField_SRCDTA) Then
                For Each EachItem As String In SourceDataRow.Item("SRCDTA").Split(" ")
                    If EachItem.Length > 0 Then
                        _SourceDataRowField_SRCDTA &= " " & EachItem
                    End If
                Next
            End If

            '1020219 by renhsin
            If _SourceDataRowField_SRCDTA Is Nothing Then _SourceDataRowField_SRCDTA = ""

            Return _SourceDataRowField_SRCDTA.Trim
        End Get
    End Property
#End Region


#Region "是否為欄位定義字串 方法:IsField"
    ''' <summary>
    ''' 是否為欄位定義字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsField() As Boolean
        Get
            '1020219 by renhsin
            '  If SourceDataRowField_SRCDTA.Substring(0, 2).ToUpper <> "A " OrElse SourceDataRowField_SRCDTA.Substring(2, 2).ToUpper = "R " OrElse SourceDataRowField_SRCDTA.Substring(2, 2).ToUpper = "K " OrElse SourceDataRowField_SRCDTA.Split(" ").Length < 3 Then
            If SourceDataRowField_SRCDTA = "" OrElse SourceDataRowField_SRCDTA.Substring(0, 2).ToUpper <> "A " OrElse SourceDataRowField_SRCDTA.Substring(2, 2).ToUpper = "R " OrElse SourceDataRowField_SRCDTA.Substring(2, 2).ToUpper = "K " OrElse SourceDataRowField_SRCDTA.Split(" ").Length < 3 Then
                Return False
            End If
            Return True
        End Get
    End Property
#End Region
#Region "欄位名稱 屬性:FieldName"
    ''' <summary>
    ''' 欄位名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property FieldName() As String
        Get

            If IsField = False Then
                Return Nothing
            End If
            Return SourceDataRowField_SRCDTA.Split(" ")(1)
        End Get
    End Property
#End Region
#Region "欄位長度 屬性:FieldLenth"
    ''' <summary>
    ''' 欄位長度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property FieldLenth() As Integer
        Get
            If IsField = False Then
                Return -1
            End If
            Dim ReturnValue As String = Nothing
            For Each EachChar As Char In SourceDataRowField_SRCDTA.Split(" ")(2)
                If IsNumeric(EachChar) Then
                    ReturnValue &= EachChar
                Else
                    Exit For
                End If
            Next
            Return CType(ReturnValue, Integer)
        End Get
    End Property

#End Region
#Region "小數位數長度 屬性:DecimalLenth"
    ''' <summary>
    ''' 小數位數長度
    ''' </summary>
    ''' <remarks></remarks>
    ReadOnly Property DecimalLenth() As Integer
        Get
            Dim Values() As String = SourceDataRowField_SRCDTA.Split(" ")
            If IsField = False OrElse Values.Length < 4 OrElse Values(2).Substring(Values(2).Length - 1, 1).ToUpper <> "S" Then
                Return -1
            End If
            Return CType(Values(3), Integer)
        End Get
    End Property

#End Region
#Region "欄位應用程式中使用之型別 屬性:FieldForAPDataType"
    ''' <summary>
    ''' 欄位應用程式中使用之型別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property FieldForAPDataType() As Type
        Get
            If IsField = False Then
                Return Nothing
            End If
            Dim TypeChar As Char = SourceDataRowField_SRCDTA.Split(" ")(2).Substring(SourceDataRowField_SRCDTA.Split(" ")(2).Length - 1, 1).ToUpper
            Select Case True
                Case TypeChar = "A"
                    Return GetType(String)
                Case TypeChar = "O"
                    Return GetType(String)
                Case TypeChar = "J"
                    Return GetType(String)
                Case TypeChar = "E"
                    Return GetType(String)
                Case TypeChar = "B"
                    Return GetType(BitArray)
                Case TypeChar = "S"
                    Select Case True
                        Case FieldLenth - DecimalLenth > 37 OrElse DecimalLenth > 44
                            Return GetType(Double)
                        Case DecimalLenth > 0
                            Return GetType(Single)
                        Case Else
                            Return GetType(Integer)
                    End Select
                Case TypeChar = "P"
                    Select Case True
                        Case FieldLenth - DecimalLenth > 37 OrElse DecimalLenth > 44
                            Return GetType(Double)
                        Case DecimalLenth > 0
                            Return GetType(Single)
                        Case Else
                            Return GetType(Integer)
                    End Select
                Case TypeChar = "F"
                    Return GetType(Double)
                Case IsNumeric(TypeChar)
                    Return GetType(String)
            End Select
            Return GetType(Object)
        End Get
    End Property
#End Region
#Region "欄位表格抬頭名稱 屬性:FieldCOLHDG"
    ''' <summary>
    ''' 欄位表格抬頭名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property FieldCOLHDG() As String
        Get
            If IsField = False Then
                Return Nothing
            End If
            Dim TempData() As String = SourceDataRowField_SRCDTA.Split("'")
            If TempData.Length < 2 Then
                Return Nothing
            End If
            Return TempData(1).Trim
        End Get
    End Property
#End Region
#Region "是否為主鍵欄位定義 屬性:IsPKField"
    ''' <summary>
    ''' 是否為主鍵欄位定義
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsPKField() As Boolean
        Get
            For Each EachItem As DataRow In Me.SourceDataTable.Rows
                Dim ProcessData As String = Nothing
                For Each EachItem2 As String In EachItem.Item("SRCDTA").Split(" ")
                    If EachItem2.Length > 0 Then
                        ProcessData &= " " & EachItem2
                    End If

                    '1020219 by renhsin
                    If ProcessData Is Nothing Then ProcessData = ""
                    ProcessData = ProcessData.Trim
                Next

                'If  ProcessData.Split(" ")(1) = "K" AndAlso ProcessData.Split(" ")(2).ToUpper = Me.FieldName.ToUpper Then
                If ProcessData.Split(" ").Length >= 2 AndAlso ProcessData.Split(" ")(1) = "K" AndAlso ProcessData.Split(" ")(2).ToUpper = Me.FieldName.ToUpper Then
                    Return True
                End If
            Next
            Return False
        End Get
    End Property
#End Region

End Class