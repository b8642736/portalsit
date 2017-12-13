Public Class L2PDOMessage

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
            If SplitData.Length <> 5 Then
                Me.ErrorMessage = "取得訊號值內容異常(格式有誤):" & Me.Message
                Throw New Exception(Me.ErrorMessage)
            End If
            Dim DataLeng As Integer = 0
            For Each EachItem As String In SplitData
                Select Case True
                    Case String.IsNullOrEmpty(EachItem)
                        Me.ErrorMessage = "取得訊號值內容異常(格式有誤):" & Me.Message
                        Throw New Exception(Me.ErrorMessage)
                    Case DataLeng = 0
                        Select Case EachItem.PadRight(3).ToUpper.Substring(0, 3)
                            Case "APL"
                                Me.StationKind = StationKindEnum.APL
                            Case Else
                                Me.StationKind = StationKindEnum.UnKnow
                        End Select
                    Case DataLeng = 1
                        If String.IsNullOrEmpty(EachItem) Then
                            Me.CoilFullNumber = ""
                        Else
                            Me.CoilFullNumber = EachItem.Trim.ToUpper
                        End If
                    Case DataLeng = 2 AndAlso DateTime.TryParse(EachItem, Nothing)
                        Me.HappenTime = CType(EachItem, DateTime)
                    Case DataLeng = 3 AndAlso Not String.IsNullOrEmpty(EachItem) AndAlso {"0", "1", "2", "3"}.Contains(EachItem.Trim.ToUpper)
                        Select Case EachItem.Trim.ToUpper
                            Case "2"
                                Me.InputLineKind = InputLineKindEnum.UP
                            Case "3"
                                Me.InputLineKind = InputLineKindEnum.DOWN
                            Case Else
                                Me.InputLineKind = InputLineKindEnum.UnKnow
                        End Select
                    Case DataLeng = 4 AndAlso Integer.TryParse(EachItem, Nothing) AndAlso Val(EachItem) >= 0 AndAlso Val(EachItem) <= 2
                        Select Case EachItem.Trim.ToUpper
                            Case "1"
                                Me.SingalType = SingalTypeEnum.StartWeld
                            Case "2"
                                Me.SingalType = SingalTypeEnum.EndWeld
                            Case Else
                                Me.SingalType = SingalTypeEnum.UnKnow
                        End Select
                    Case Else
                        Select Case DataLeng
                            Case 0
                                Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "產線格式有誤):" & Me.Message
                            Case 1
                                Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "鋼捲號碼格式有誤):" & Me.Message
                            Case 2
                                Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "資料建立時間格式有誤):" & Me.Message
                            Case 3
                                Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "上下線格式有誤):" & Me.Message
                            Case 4
                                Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "焊接開始/結束格式有誤):" & Me.Message
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
#Region "鋼捲號碼 屬性:CoilFullNumber"
    Private _CoilFullNumber As String
    ''' <summary>
    ''' 鋼捲號碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CoilFullNumber() As String
        Get
            Return _CoilFullNumber
        End Get
        Private Set(ByVal value As String)
            _CoilFullNumber = value
        End Set
    End Property

#End Region
#Region "產線別種類 屬性:StationKind"
    Private _StationKind As StationKindEnum = StationKindEnum.UnKnow
    ''' <summary>
    ''' 產線別種類
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StationKind() As StationKindEnum
        Get
            Return _StationKind
        End Get
        Private Set(ByVal value As StationKindEnum)
            _StationKind = value
        End Set
    End Property

#End Region
#Region "入口產線 屬性:InputLineKind"
    Private _InputLineKind As InputLineKindEnum = InputLineKindEnum.UnKnow
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
#Region "訊號種類 屬性:SingalType"
    Private _SingalType As SingalTypeEnum = SingalTypeEnum.UnKnow
    Public Property SingalType() As SingalTypeEnum
        Get
            Return _SingalType
        End Get
        Set(ByVal value As SingalTypeEnum)
            _SingalType = value
        End Set
    End Property

#End Region


#Region "產線別種類列舉 列舉:StationKindEnum"
    ''' <summary>
    ''' 產線別種類列舉
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum StationKindEnum
        APL = 1
        UnKnow = 99
    End Enum
#End Region
#Region "入口產線列舉 列舉:InputLineKindEnum"
    ''' <summary>
    ''' 入口產線列舉
    ''' </summary>
    ''' <remarks></remarks>
    Enum InputLineKindEnum
        UP = 1
        DOWN = 2
        UnKnow = 99
    End Enum
#End Region
#Region "訊號種類列舉 列舉:SingalTypeEnum"
    ''' <summary>
    ''' 訊號種類列舉
    ''' </summary>
    ''' <remarks></remarks>
    Enum SingalTypeEnum
        StartWeld = 1   '焊接開始
        EndWeld = 2     '結束
        UnKnow = 99
    End Enum
#End Region



    'APL(PDO):
    '產線,鋼捲號碼,資料建立時間,上下線(2上線/3下線),1焊接開始/2結束
    'APL2,M1111,2014/03/20 16:02:44,2,1

End Class
