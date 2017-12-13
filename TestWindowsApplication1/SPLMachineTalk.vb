Public Class SPLMachineTalk


    Sub New()
        TalkDataObject = Me.TalkDataObject
    End Sub

#Region "通訊資料結構 屬性:TalkDataStructure"
    ''' <summary>
    ''' 通訊資料結構
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure TalkDataStructure
        Dim xhead() As Char
        Dim space_2 As Char
        Dim width() As Char
        Dim space_3 As Char
        Dim guage() As Char
        Dim space_4 As Char
        Dim surface As Char
        Dim space_5 As Char
        Dim alloy() As Char
        Dim space_6 As Char
        Dim data_1() As Char
        Dim space_7 As Char
        Dim data_2() As Char
        Dim space_8 As Char
        Dim data_3() As Char
        Dim xend As Char

    End Structure
#End Region

#Region "取得傳送儀器資料 方法:GetSendValue"
    Public Function GetSendValue() As String
        Dim ReturnValue As String = Nothing
        With Me.TalkDataObject

            ReturnValue &= String.Concat(.xhead) & .space_2
            ReturnValue &= String.Concat(.width) & .space_3
            ReturnValue &= String.Concat(.guage) & .space_4 & .surface & .space_5
            ReturnValue &= String.Concat(.alloy) & .space_6
            ReturnValue &= String.Concat(.data_1) & .space_7
            ReturnValue &= String.Concat(.data_2) & .space_8
            ReturnValue &= String.Concat(.data_3) & .xend
        End With
        Return ReturnValue
    End Function

#End Region
#Region "通訊資料物件 屬性:TalkDataObject"

    Private _TalkDataObject As TalkDataStructure
    Private _isFirstEntry As Boolean = True
    Public Property TalkDataObject() As TalkDataStructure
        Get
            If _isFirstEntry Then
                _TalkDataObject = New TalkDataStructure
                With _TalkDataObject
                    Dim Setxhead() As Char = " <000000WR -1".ToCharArray
                    Setxhead(0) = Convert.ToChar(10)
                    .xhead = Setxhead
                    .space_2 = Convert.ToChar(32)
                    .width = "    "
                    .space_3 = Convert.ToChar(32)
                    .guage = "    "
                    .space_4 = Convert.ToChar(32)
                    .surface = Convert.ToChar(57)
                    .space_5 = Convert.ToChar(32)
                    .alloy = {Convert.ToChar(49), " "}
                    .space_6 = Convert.ToChar(32)
                    .data_1 = ""
                    .space_7 = Convert.ToChar(32)
                    .data_2 = ""
                    .space_8 = Convert.ToChar(32)
                    .data_3 = ""
                    .xend = Convert.ToChar(13)
                End With
                _isFirstEntry = False
            End If
            Return _TalkDataObject
        End Get
        Private Set(value As TalkDataStructure)
            _TalkDataObject = value
        End Set
    End Property

#End Region

#Region "表面 屬性:surface"
    Private _surface As String
    ''' <summary>
    ''' 表面
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property surface() As String
        Get
            Return _surface
        End Get
        Set(ByVal value As String)
            _surface = value
            With _TalkDataObject
                Select Case _surface.ToUpper.Trim
                    Case "NO1"
                        .surface = Convert.ToChar(49)
                    Case "2D"
                        .surface = Convert.ToChar(50)
                    Case "2B"
                        .surface = Convert.ToChar(51)
                    Case "BA"
                        .surface = Convert.ToChar(52)
                    Case Else
                        .surface = Convert.ToChar(57)
                End Select
            End With
        End Set
    End Property

#End Region
#Region "鋼種 屬性:SteelKind"
    Private _SteelKind As String
    ''' <summary>
    ''' 鋼種
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SteelKind() As String
        Get
            Return _SteelKind
        End Get
        Set(ByVal value As String)
            _SteelKind = value
            With _TalkDataObject
                Select Case _SteelKind.ToUpper.Trim
                    Case "301"
                        .alloy = {"", Convert.ToChar(49)}
                    Case "302"
                        .alloy = {"", Convert.ToChar(50)}
                    Case "304"
                        .alloy = {"", Convert.ToChar(51)}
                    Case "304L"
                        .alloy = {"", Convert.ToChar(52)}
                    Case "316"
                        .alloy = {"", Convert.ToChar(53)}
                    Case "316L"
                        .alloy = {"", Convert.ToChar(54)}
                    Case "403"
                        .alloy = {"", Convert.ToChar(55)}
                    Case "403L"
                        .alloy = {"", Convert.ToChar(56)}
                    Case Else
                        .alloy = {"", Convert.ToChar(57)}
                End Select
            End With
        End Set
    End Property

#End Region
#Region "厚度 屬性:Guage"
    Private _Guage As Single
    ''' <summary>
    ''' 厚度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Guage() As Single
        Get
            Return _Guage
        End Get
        Set(ByVal value As Single)
            _Guage = value
            Me._TalkDataObject.guage = (Val(Format(_Guage, "0.000")) * 1000).ToString.PadLeft(5).Substring(0, 5).ToCharArray
        End Set
    End Property

#End Region
#Region "寬度 屬性:Width"

    Private _Width As Integer
    Public Property Width() As Integer
        Get
            Return _Width
        End Get
        Set(ByVal value As Integer)
            _Width = value
            Me._TalkDataObject.width = _Width.ToString.PadLeft(4).Substring(0, 4).ToCharArray
        End Set
    End Property

#End Region
#Region "鋼捲號碼 屬性:Data_1CoilNumber"
    Private _Data_1CoilNumber As String
    ''' <summary>
    ''' 鋼捲號碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Data_1CoilNumber() As String
        Get
            Return _Data_1CoilNumber
        End Get
        Set(ByVal value As String)
            _Data_1CoilNumber = value.Replace("-", Nothing).PadRight(10, " ")
            _TalkDataObject.data_1 = (_Data_1CoilNumber.Substring(0, 5) & "-" & _Data_1CoilNumber.Substring(5, 5) & vbCr).ToCharArray
        End Set
    End Property

#End Region
#Region "資料2 屬性:Data_2"
    Private _Data_2 As String
    ''' <summary>
    ''' 資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Data_2() As String
        Get
            Return _Data_2
        End Get
        Set(ByVal value As String)
            _Data_2 = value.PadRight(11, " ")
            _TalkDataObject.data_2 = (_Data_2.Substring(0, 11) & vbCr).ToCharArray
        End Set
    End Property

#End Region
#Region "資料3 屬性:Data_3"
    Private _Data_3 As String
    ''' <summary>
    ''' 資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Data_3() As String
        Get
            Return _Data_3
        End Get
        Set(ByVal value As String)
            _Data_3 = value.PadRight(11, " ")
            _TalkDataObject.data_2 = (_Data_3.Substring(0, 11) & vbCr).ToCharArray
        End Set
    End Property

#End Region

#Region "方法傳送資料至儀器 方法:SendDataToDevice"
    ''' <summary>
    ''' 方法傳送資料至儀器
    ''' </summary>
    ''' <param name="SourceRs232"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SendDataToDevice(ByVal SourceRs232 As IO.Ports.SerialPort) As Boolean
        If SourceRs232.IsOpen = False Then
            SourceRs232.Open()
        End If
        Try
            SourceRs232.Write(Me.TalkDataObject.ToString)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
#End Region

End Class
