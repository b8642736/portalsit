Public Class AS400DBToVB

    Sub New(ByVal SetSourceFileString As String)
        Me.SourceFileString = SetSourceFileString
    End Sub

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
                For Each EachItem As String In Me.SourceFileLinesData
                    _FieldsRowInformation.Add(New RowInformation(EachItem))
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
    Public Function ConvertFieldRowInfoToVBCode(ByVal ClassName As String, Optional ByVal InheritsClassName As String = "ClassDBAS400") As String
        Dim ReturnValue As String = Nothing
        ReturnValue &= vbNewLine & vbTab & "Sub New()"
        ReturnValue &= vbNewLine & vbTab & vbTab & "MyBase.New(""TESTKUKU"", GetType(" & ClassName.Trim & ").Name)"
        ReturnValue &= vbNewLine & vbTab & "End Sub"
        ReturnValue &= vbNewLine

        For Each EachItem As RowInformation In FieldsRowInformation
            If EachItem.IsField = False Then
                Continue For
            End If


            Dim TempFieldName As String = EachItem.FieldName
            Dim IsPrimaryKeyFieldRow As Boolean = Not IsNothing((From A In FieldsRowInformation Where A.IsDefinePKData = True And A.FieldName = TempFieldName Select A).FirstOrDefault)
            Dim FieldTypeString As String = EachItem.FieldForAPDataType.ToString
            ReturnValue &= vbNewLine & "#Region """ & EachItem.FieldCOLHDG & " 屬性:" & EachItem.FieldName & """"
            ReturnValue &= vbNewLine & vbTab & "Private _" & EachItem.FieldName & " As " & FieldTypeString
            ReturnValue &= vbNewLine & vbTab & "''' <summary>"
            ReturnValue &= vbNewLine & vbTab & "''' " & EachItem.FieldCOLHDG
            ReturnValue &= vbNewLine & vbTab & "''' </summary>"
            ReturnValue &= vbNewLine & vbTab & "''' <returns></returns>"
            ReturnValue &= vbNewLine & vbTab & "''' <remarks></remarks>"
            If IsPrimaryKeyFieldRow Then
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
            ReturnValue = "Public Class " & ClassName.Trim & vbNewLine & ReturnValue & vbNewLine & "End Class"
        Else
            ReturnValue = "Public Class " & ClassName.Trim & vbNewLine & vbTab & "Inherits " & InheritsClassName & vbNewLine & ReturnValue & vbNewLine & "End Class"
        End If
        Return ReturnValue
    End Function
#End Region


End Class

Public Class RowInformation

    Sub New(ByVal SetSourceLineData As String)
        Me.SourceLineData = SetSourceLineData
    End Sub

#Region "原始文字資料行 屬性:SourceLineData"

    Private _SourceLineData As String
    ''' <summary>
    ''' 原始文字資料行
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceLineData() As String
        Get
            Return _SourceLineData
        End Get
        Set(ByVal value As String)
            _SourceLineData = value
        End Set
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
            If SourceLineData.Length < 35 Then
                Return False
            End If
            If SourceLineData.Substring(34, 1) = " " Then
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
            Return SourceLineData.Substring(18, 10).Trim.ToUpper
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
            Return CType(SourceLineData.Substring(29, 5), Integer)
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
            If IsField = False OrElse SourceLineData.Substring(34, 1).ToUpper <> "S" Then
                Return -1
            End If
            Return CType(SourceLineData.Substring(35, 2), Integer)
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
            Select Case SourceLineData.Substring(34, 1).ToUpper
                Case "A"
                    Return GetType(String)
                Case "O"
                    Return GetType(String)
                Case "J"
                    Return GetType(String)
                Case "E"
                    Return GetType(String)
                Case "B"
                    Return GetType(BitArray)
                Case "S"
                    If FieldLenth - DecimalLenth > 37 OrElse DecimalLenth > 44 Then
                        Return GetType(Double)
                    End If
                    Return GetType(Integer)
                Case "P"
                    If FieldLenth - DecimalLenth > 37 OrElse DecimalLenth > 44 Then
                        Return GetType(Double)
                    End If
                    Return GetType(Integer)
                Case "F"
                    Return GetType(Double)
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
            Dim TempData() As String = Me.SourceLineData.Split("'")
            If TempData.Length < 2 Then
                Return Nothing
            End If
            Return TempData(1)
        End Get
    End Property
#End Region

#Region "是否為主鍵欄位定義 屬性:IsDefinePKData"
    ''' <summary>
    ''' 是否為主鍵欄位定義
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsDefinePKData() As Boolean
        Get
            If IsField = False Then
                Return Nothing
            End If
            If SourceLineData.Substring(34, 1).ToUpper = "K" Then
                Return True
            End If
            Return False
        End Get
    End Property
#End Region

End Class