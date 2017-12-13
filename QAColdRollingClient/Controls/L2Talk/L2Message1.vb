Public Class L2Message1

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
        Me.ErrorMessage = ""
        Try
            Dim SplitData() As String = Me.Message.Split(",")
            If SplitData.Length < 8 Then
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
                        Me.LineName = EachItem.Trim
                    Case DataLeng = 1
                        Select Case EachItem
                            Case "RUNNING"
                                Status = StatusEnum.RUNNING
                            Case "PRE-UP"
                                Status = StatusEnum.PRE_UP
                            Case "PRE-DOWN"
                                Status = StatusEnum.PRE_DOAN
                            Case Else
                                Status = StatusEnum.UnKnow
                        End Select
                    Case DataLeng = 2 AndAlso Integer.TryParse(EachItem, Nothing)
                        StatusOrder = CType(EachItem, Integer)
                    Case DataLeng = 3
                        CoilFullNumber = EachItem.Trim
                    Case DataLeng = 4
                        OutCoilFullNumber = EachItem.Trim
                    Case DataLeng = 5 AndAlso Double.TryParse(EachItem, Nothing)
                        Me.Length = CType(EachItem, Double)
                    Case DataLeng = 6 AndAlso Single.TryParse(EachItem, Nothing)
                        Me.Thick = CType(EachItem, Single)
                    Case DataLeng = 7 AndAlso Double.TryParse(EachItem, Nothing)
                        Me.Width = CType(EachItem, Double)
                        'Case DataLeng > 7
                        'Case Else
                        '    Select Case DataLeng
                        '        Case 0
                        '            Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "產線資料格式有誤):" & Me.Message
                        '        Case 1
                        '            Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "狀態格式有誤):" & Me.Message
                        '        Case 2
                        '            Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "狀態順序格式有誤):" & Me.Message
                        '        Case 3
                        '            Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "原捲鋼捲編號格式有誤):" & Me.Message
                        '        Case 4
                        '            Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "輸出鋼捲編號格式有誤):" & Me.Message
                        '        Case 5
                        '            Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "長度格式有誤):" & Me.Message
                        '        Case 6
                        '            Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "厚度格式有誤):" & Me.Message
                        '        Case 7
                        '            Me.ErrorMessage = "取得訊號值內容異常(" & DataLeng & "寬度格式有誤):" & Me.Message
                        '    End Select
                        '    Throw New Exception(Me.ErrorMessage)
                End Select
                DataLeng += 1
            Next
        Catch ex As Exception
            'original
            'Me.ErrorMessage = "取得訊號值內容異常:" & ex.ToString()
            ' Throw New Exception(Me.ErrorMessage)
        End Try
    End Sub
#End Region

#Region "產線名稱 屬性:LineName"
    Private _LineName As String
    ''' <summary>
    ''' 產線名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LineName() As String
        Get
            Return _LineName
        End Get
        Set(ByVal value As String)
            _LineName = value
        End Set
    End Property
#End Region
#Region "狀態 屬性/列舉:Status/StatusEnum"
    Private _Status As StatusEnum = StatusEnum.UnKnow
    ''' <summary>
    ''' 狀態
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Status() As StatusEnum
        Get
            Return _Status
        End Get
        Set(ByVal value As StatusEnum)
            _Status = value
        End Set
    End Property
    Public Enum StatusEnum
        UnKnow = 0
        RUNNING = 1
        PRE_UP = 2
        PRE_DOAN = 3
    End Enum
#End Region
#Region "原鋼捲號碼 屬性:CoilFullNumber"
    Private _CoilFullNumber As String
    ''' <summary>
    ''' 原鋼捲號碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CoilFullNumber() As String
        Get
            Return _CoilFullNumber
        End Get
        Set(ByVal value As String)
            _CoilFullNumber = value
        End Set
    End Property

#End Region
#Region "輸出鋼捲號碼 屬性:OutCoilFullNumber"
    Private _OutCoilFullNumber As String
    ''' <summary>
    ''' 輸出鋼捲號碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OutCoilFullNumber() As String
        Get
            Return _OutCoilFullNumber
        End Get
        Set(ByVal value As String)
                _OutCoilFullNumber = value
        End Set
    End Property

#End Region
#Region "狀態的順序 屬性:StatusOrder"
    Private _StatusOrder As Integer
    ''' <summary>
    ''' 狀態的順序
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StatusOrder() As Integer
        Get
            Return _StatusOrder
        End Get
        Set(ByVal value As Integer)
            _StatusOrder = value
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



    'ZML1,RUNNING,1,P7417,P7417A,0,1.4,960
    'ZML1,PRE-UP,1,P6672,P6672,0,0.49,960

    '欄位定義:
    'APL1=產線
    'RUNNING=狀態(RUNNING,PRE-UP,PRE-DOWN)
    '1= 狀態的順序(由靠近出至入口,由上到下)
    'P7417=原捲鋼捲編號
    'P7417A=輸出鋼捲編號
    '0=長度
    '1.4=厚度(TLL, CPL, GPL 產線實際值*1000)
    '960=寬度

End Class
