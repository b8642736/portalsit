Public Class L2Message

    Sub New(ByVal SetMessage As String)
        Message = SetMessage
        ConvertMessageToField()
    End Sub

#Region "訊息 屬性:Message"
    Private _Message As String
    ''' <summary>
    ''' 訊息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Message() As String
        Get
            Return _Message
        End Get
        Set(ByVal value As String)
            _Message = value

        End Set
    End Property

#End Region
#Region "錯誤訊息 屬性:ErrorMessage"

    Private _ErrorMessage As String
    ''' <summary>
    ''' 錯誤訊息
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ErrorMessage() As String
        Get
            Return _ErrorMessage
        End Get
        Set(ByVal value As String)
            _ErrorMessage = value
        End Set
    End Property

#End Region


#Region "轉換訊息至欄位位值 函式:ConvertMessageToField"
    ''' <summary>
    ''' 轉換訊息至欄位位值
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ConvertMessageToField()
        If String.IsNullOrEmpty(Me.Message) Then
            Me.ErrorMessage = "取得訊號值內容異常(不可為空值)"
            Throw New Exception(Me.ErrorMessage)
            Exit Sub
        End If
        Me.ErrorMessage = Nothing
        Try
            Dim SplitData() As String = Me.Message.Split(",")
            If SplitData.Length <> 9 Then
                Me.ErrorMessage = "取得訊號值內容異常(格式有誤):" & Me.Message
                Throw New Exception(Me.ErrorMessage)
            End If
            Dim DataLeng As Integer = 0
            For Each EachItem As String In SplitData
                Select Case True
                    Case String.IsNullOrEmpty(EachItem)
                        Me.ErrorMessage = "取得訊號值內容異常(格式有誤):" & Me.Message
                        Throw New Exception(Me.ErrorMessage)
                    Case DataLeng = 0 AndAlso DateTime.TryParse(EachItem, Nothing)
                        Me.HappenTime = CType(EachItem, DateTime)
                    Case DataLeng = 1 AndAlso Integer.TryParse(EachItem, Nothing) AndAlso Val(EachItem) >= 1 AndAlso Val(EachItem) <= 5
                        Select Case Val(EachItem)
                            Case 1
                                Me.TraggerKind = TraggerKindEnum.CoilStart
                            Case 2
                                Me.TraggerKind = TraggerKindEnum.CoilEnd
                            Case 3
                                Me.TraggerKind = TraggerKindEnum.BreakCoil
                            Case 4
                                Me.TraggerKind = TraggerKindEnum.CutCoil
                            Case 5
                                Me.TraggerKind = TraggerKindEnum.BreakDown
                        End Select
                    Case DataLeng = 2
                        If String.IsNullOrEmpty(EachItem) Then
                            Me.CoilFullNumber = ""
                        Else
                            Me.CoilFullNumber = EachItem.Trim.ToUpper
                        End If
                    Case DataLeng = 3 AndAlso Not String.IsNullOrEmpty(EachItem) AndAlso {"1", "2", "3"}.Contains(EachItem.Trim.ToUpper)
                        Select Case EachItem.Trim.ToUpper
                            Case "1"
                                Me.InputLineKind = InputLineKindEnum.NODiffer
                            Case "2"
                                Me.InputLineKind = InputLineKindEnum.UP
                            Case "3"
                                Me.InputLineKind = InputLineKindEnum.DOWN
                        End Select
                    Case DataLeng = 4 AndAlso Double.TryParse(EachItem, Nothing)
                        Me.Length = CType(EachItem, Double)
                    Case DataLeng = 5 AndAlso Single.TryParse(EachItem, Nothing)
                        Me.Thick = CType(EachItem, Single)
                    Case DataLeng = 6 AndAlso Double.TryParse(EachItem, Nothing)
                        Me.Width = CType(EachItem, Double)
                    Case DataLeng = 7 AndAlso Double.TryParse(EachItem, Nothing)
                        Me.BreakCoilLength = CType(EachItem, Double)
                    Case DataLeng = 8 AndAlso Integer.TryParse(EachItem, Nothing)
                        Me.MillOfTimes = CType(EachItem, Integer)
                    Case Else
                        Select Case DataLeng
                            Case 0
                                Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "時間格式有誤):" & Me.Message
                            Case 1
                                Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "觸發種類格式有誤):" & Me.Message
                                'Case 2
                                '    Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "鋼捲號碼格式有誤):" & Me.Message
                            Case 3
                                Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "入口產線格式有誤):" & Me.Message
                            Case 4
                                Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "長度格式有誤):" & Me.Message
                            Case 5
                                Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "厚度格式有誤):" & Me.Message
                            Case 6
                                Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "寬度格式有誤):" & Me.Message
                            Case 7
                                Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "斷捲長度格式有誤):" & Me.Message
                            Case 8
                                Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "軋研次數格式有誤):" & Me.Message
                        End Select
                        Throw New Exception(Me.ErrorMessage)
                End Select
                DataLeng += 1
            Next
        Catch ex As Exception
            Me.ErrorMessage = "取得訊號值內容異常:" & ex.ToString
            Throw New Exception(Me.ErrorMessage)
        End Try
    End Sub
#End Region

#Region "發生時間 屬性:HappenTime"
    Private _HappenTime As DateTime
    Public Property HappenTime() As DateTime
        Get
            Return _HappenTime
        End Get
        Set(ByVal value As DateTime)
            _HappenTime = value
        End Set
    End Property

#End Region
#Region "觸發種類 屬性:TraggerKind"
    Private _TraggerKind As TraggerKindEnum
    ''' <summary>
    ''' 觸發種類
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TraggerKind() As TraggerKindEnum
        Get
            Return _TraggerKind
        End Get
        Set(ByVal value As TraggerKindEnum)
            _TraggerKind = value
        End Set
    End Property

#End Region
#Region "鋼捲號碼 屬性:CoilFullNumber"
    Private _CoilFullNumber As String
    Public Property CoilFullNumber() As String
        Get
            Return _CoilFullNumber
        End Get
        Set(ByVal value As String)
            _CoilFullNumber = value
        End Set
    End Property

#End Region
#Region "入口產線 屬性:InputLineKind"
    Private _InputLineKind As InputLineKindEnum
    ''' <summary>
    ''' 入口產線
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InputLineKind() As InputLineKindEnum
        Get
            Return _InputLineKind
        End Get
        Set(ByVal value As InputLineKindEnum)
            _InputLineKind = value
        End Set
    End Property


#End Region
#Region "長度 屬性:Length"
    Private _Length As Double
    ''' <summary>
    ''' 長度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Length() As Double
        Get
            Return _Length
        End Get
        Set(ByVal value As Double)
            _Length = value
        End Set
    End Property

#End Region
#Region "厚度 屬性:Thick"
    Private _Thick As Single
    ''' <summary>
    ''' 厚度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Thick() As Single
        Get
            Return _Thick
        End Get
        Set(ByVal value As Single)
            _Thick = value
        End Set
    End Property

#End Region
#Region "寬度 屬性:Width"
    Private _Width As Double
    ''' <summary>
    ''' 寬度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Width() As Double
        Get
            Return _Width
        End Get
        Set(ByVal value As Double)
            _Width = value
        End Set
    End Property

#End Region
#Region "斷捲長度 屬性:BreakCoilLength"
    Private _BreakCoilLength As Double
    ''' <summary>
    ''' 斷捲長度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BreakCoilLength() As Double
        Get
            Return _BreakCoilLength
        End Get
        Set(ByVal value As Double)
            _BreakCoilLength = value
        End Set
    End Property

#End Region
#Region "軋研次數 屬性:MillOfTimes"
    Private _MillOfTimes As Integer
    ''' <summary>
    ''' 軋研次數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MillOfTimes() As Integer
        Get
            Return _MillOfTimes
        End Get
        Set(ByVal value As Integer)
            _MillOfTimes = value
        End Set
    End Property

#End Region

#Region "入口產線列舉 列舉:InputLineKindEnum"
    ''' <summary>
    ''' 入口產線列舉
    ''' </summary>
    ''' <remarks></remarks>
    Enum InputLineKindEnum
        NODiffer = 0
        UP = 1
        DOWN = 2
    End Enum
#End Region
#Region "觸發種類列舉 列舉:TraggerKindEnum"
    ''' <summary>
    ''' 觸發種類列舉
    ''' </summary>
    ''' <remarks></remarks>
    Enum TraggerKindEnum
        CoilStart = 1
        CoilEnd = 2
        BreakCoil = 3
        CutCoil = 4
        BreakDown = 5
    End Enum
#End Region


    '2013/05/02 03:10:06,1,A1233,R,100,200,300,400,500
    '欄位定義:
    '2013/05/02 03:10:06=發生日期及時間
    '1=觸發種類 (1= Coil start, 2=Coil end, 3=斷捲,4=分捲,5=故障)
    'A1233=鋼捲號碼
    'R=生產(R=生產(無上下限), U=上限生產,D=下限生產)
    '100=長度
    '200=厚度
    '300=寬度
    '400=斷捲長度
    '500=軋研次數
End Class
