Public Class AS400DateConverter

    Sub New()

    End Sub

    Sub New(ByVal SetSourceValue As DateTime)
        Me.DateValue = SetSourceValue
    End Sub
    Sub New(ByVal SetSourceValue As String)
        Dim GetDateValue As DateTime = StringToDate(SetSourceValue)
        If IsNothing(GetDateValue) Then
            Throw (New Exception("輸入字串非日期格式"))
        End If
        Me.DateValue = GetDateValue
    End Sub
    Sub New(ByVal SetSourceValue As Integer)
        Dim GetDateValue As DateTime = IntegerToDate(SetSourceValue)
        If IsNothing(GetDateValue) Then
            Throw (New Exception("輸入數值非日期格式"))
        End If
        Me.DateValue = GetDateValue

    End Sub



#Region "日期格式資料 屬性:DateValue"

    Private _DateValue As DateTime
    ''' <summary>
    ''' 日期格式資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DateValue() As DateTime
        Get
            Return _DateValue
        End Get
        Set(ByVal value As DateTime)
            _DateValue = value
        End Set
    End Property

#End Region
#Region "民國年六位字元格式日期資料 屬性:TwSixCharsTypeData"
    ''' <summary>
    ''' 民國年六位字元格式日期資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TwSixCharsTypeData() As String
        Get
            Return Me.DateToTwString(Me.DateValue, TwStringType.SixChars)
        End Get
        Set(ByVal value As String)
            If IsStringIsValidDateType(value) = False Then
                Throw (New Exception("輸入字串非日期格式"))
            End If
            Me.DateValue = Me.StringToDate(value)
        End Set
    End Property

#End Region
#Region "民國年七位字元格式日期資料 屬性:TwSevenCharsTypeData"

    ''' <summary>
    ''' 民國年七位字元格式日期資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TwSevenCharsTypeData() As String
        Get
            Return Me.DateToTwString(Me.DateValue, TwStringType.SevenChars)
        End Get
        Set(ByVal value As String)
            If IsStringIsValidDateType(value) = False Then
                Throw (New Exception("輸入字串非日期格式"))
            End If

            Me.DateValue = Me.StringToDate(value)
        End Set
    End Property

#End Region
#Region "民國年數字格式日期資料 屬性:TwIntegerTypeData"

    ''' <summary>
    ''' 民國年數字格式日期資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TwIntegerTypeData() As Integer
        Get
            Return Me.DateToTwInteger(Me.DateValue)
        End Get
        Set(ByVal value As Integer)
            If IsIntegerIsValidDateType(value) = False Then
                Throw (New Exception("輸入數字非日期格式"))
            End If
            Me.DateValue = Me.IntegerToDate(value)
        End Set
    End Property

#End Region


#Region "日期型態轉換為民國年字串 方法:DateToTwString"
    ''' <summary>
    ''' 日期型態轉換為民國年字串
    ''' </summary>
    ''' <param name="SourceValue"></param>
    ''' <param name="ConverStringType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DateToTwString(ByVal SourceValue As DateTime, ByVal ConverStringType As TwStringType) As String
        If IsNothing(SourceValue) Then
            Return Nothing
        End If
        Select Case ConverStringType
            Case TwStringType.SixChars
                Return Format(SourceValue.Year - 1911, "00").ToString & Format(SourceValue.Month, "00").ToString & Format(SourceValue.Day, "00").ToString
            Case TwStringType.SevenChars
                Return Format(SourceValue.Year - 1911, "000").ToString & Format(SourceValue.Month, "00").ToString & Format(SourceValue.Day, "00").ToString
        End Select
        Return Nothing
    End Function
#End Region
#Region "日期型態轉換為民國年數字格式 方法:DateToTwInteger"
    ''' <summary>
    ''' 日期型態轉換為民國年數字格式
    ''' </summary>
    ''' <param name="SourceValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DateToTwInteger(ByVal SourceValue As DateTime) As Integer
        If IsNothing(SourceValue) Then
            Return -1
        End If
        Return CType(Format(SourceValue.Year - 1911, "000").ToString & Format(SourceValue.Month, "00").ToString & Format(SourceValue.Day, "00").ToString, Integer)
    End Function
#End Region
#Region "轉換字串為日期格式 方法:StringToDate"
    ''' <summary>
    ''' 轉換字串為日期格式(可轉換民國年)
    ''' </summary>
    ''' <param name="SourceValue"></param>
    ''' <returns>如無法轉換則傳回Nothing</returns>
    ''' <remarks></remarks>
    Public Function StringToDate(ByVal SourceValue As String) As DateTime
        Dim GetSourceValue As String = Nothing
        If DateTime.TryParse(SourceValue, Nothing) = True Then
            Return CType(GetSourceValue, DateTime)
        End If
        GetSourceValue = SourceValue.Trim.Replace("/", Nothing)
        Dim GetYear As Integer
        Dim GetMonth As Integer
        Dim GetDay As Integer

        Select Case True
            Case GetSourceValue.Length = 6
                GetYear = CType(GetSourceValue.Substring(0, 2), Integer) + 1911
                GetMonth = CType(GetSourceValue.Substring(3, 2), Integer)
                GetDay = CType(GetSourceValue.Substring(4, 2), Integer)
                Dim IsValidYear As Boolean = (DateTime.MinValue.Year <= GetYear) And (DateTime.MaxValue.Year >= GetYear)
                Dim IsValidMonth As Boolean = (GetMonth >= 1 And GetMonth <= 12)
                Dim IsValidDay As Boolean = (GetDay >= 1 And GetDay <= DateTime.DaysInMonth(GetYear, GetMonth))
                If IsValidYear And IsValidMonth And IsValidDay Then
                    Return New DateTime(GetYear, GetMonth, GetDay)
                End If
            Case GetSourceValue.Length = 7
                GetYear = CType(GetSourceValue.Substring(0, 3), Integer) + 1911
                GetMonth = CType(GetSourceValue.Substring(3, 2), Integer)
                GetDay = CType(GetSourceValue.Substring(5, 2), Integer)
                Dim IsValidYear As Boolean = (DateTime.MinValue.Year <= GetYear) And (DateTime.MaxValue.Year >= GetYear)
                Dim IsValidMonth As Boolean = (GetMonth >= 1 And GetMonth <= 12)
                Dim IsValidDay As Boolean = (GetDay >= 1 And GetDay <= DateTime.DaysInMonth(GetYear, GetMonth))
                If IsValidYear And IsValidMonth And IsValidDay Then
                    Return New DateTime(GetYear, GetMonth, GetDay)
                End If
            Case GetSourceValue.Length = 8
                GetYear = CType(GetSourceValue.Substring(0, 4), Integer)
                GetMonth = CType(GetSourceValue.Substring(4, 2), Integer)
                GetDay = CType(GetSourceValue.Substring(6, 2), Integer)
                Dim IsValidYear As Boolean = (DateTime.MinValue.Year <= GetYear) And (DateTime.MaxValue.Year >= GetYear)
                Dim IsValidMonth As Boolean = (GetMonth >= 1 And GetMonth <= 12)
                Dim IsValidDay As Boolean = (GetDay >= 1 And GetDay <= DateTime.DaysInMonth(GetYear, GetMonth))
                If IsValidYear And IsValidMonth And IsValidDay Then
                    Return New DateTime(GetYear, GetMonth, GetDay)
                End If
        End Select
        Return Nothing
    End Function
#End Region
#Region "數字型態轉換為日期格式 方法:IntegerToDate"
    ''' <summary>
    ''' 數字型態轉換為日期格式
    ''' </summary>
    ''' <param name="SourceValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IntegerToDate(ByVal SourceValue As Integer) As DateTime
        Return StringToDate(CType(SourceValue, String))
    End Function
#End Region


#Region "數字是否符合日期格式 方法:IsIntegerIsValidDateType"
    ''' <summary>
    ''' 數字是否符合日期格式
    ''' </summary>
    ''' <param name="SourceValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsIntegerIsValidDateType(ByVal SourceValue As Integer) As Boolean
        Return Not IsNothing(StringToDate(CType(SourceValue, String)))
    End Function
#End Region
#Region "字串是否符合日期格式 方法:IsStringIsValidDateType"
    ''' <summary>
    ''' 字串是否符合日期格式
    ''' </summary>
    ''' <param name="SourceValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsStringIsValidDateType(ByVal SourceValue As String) As Boolean
        Return Not IsNothing(StringToDate(SourceValue))
    End Function
#End Region


    Public Enum TwStringType
        SixChars = 0
        SevenChars = 1
    End Enum
End Class
