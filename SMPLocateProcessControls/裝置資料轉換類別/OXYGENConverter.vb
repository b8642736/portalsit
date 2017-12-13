Public Class OXYGENConverter
    Inherits DeviceDataConverterBase

    Sub New(ByVal SetDeviceData As String)
        MyBase.New(DeviceTypeEnum.OXYGEN, SetDeviceData)
    End Sub

#Region "IDCode值 屬性:IDCode"

    Private _IDCode As String = Nothing
    ''' <summary>
    ''' IDCode值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IDCode() As String
        Get
            If IsNothing(_IDCode) Then
                _IDCode = FindIDCodeValue()
            End If
            Return _IDCode
        End Get
        Set(ByVal value As String)
            _IDCode = value
        End Set
    End Property

    Private Function FindIDCodeValue() As String
        For Each EachItem As String In Me.DeviceDataLines
            If EachItem.Contains("ID CODE") Then
                Dim GetValue As String = EachItem.Replace("ID CODE", Nothing).Trim
                Return GetValue
            End If
        Next
        Return Nothing
    End Function

#End Region
#Region "氧值 屬性:OXYGEN"

    Private _OXYGEN As Nullable(Of Single) = Nothing
    ''' <summary>
    ''' 氧值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OXYGEN() As Nullable(Of Single)
        Get
            If IsNothing(_OXYGEN) Then
                _OXYGEN = FindOXYGENValue()
            End If
            Return _OXYGEN
        End Get
        Set(ByVal value As Nullable(Of Single))
            _OXYGEN = value
        End Set
    End Property

    Private Function FindOXYGENValue() As Single
        For Each EachItem As String In Me.DeviceDataLines
            If EachItem.Contains("OXYGEN") Then
                Dim GetValues() As String = EachItem.Replace("OXYGEN", Nothing).Trim.Split("%")
                Return CType(GetValues(0).Trim, Single)
            End If
        Next
        Return Nothing
    End Function

#End Region
#Region "氮值 屬性:NITROGEN"

    Private _NITROGEN As Nullable(Of Single) = Nothing
    ''' <summary>
    ''' 氮值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NITROGEN() As Nullable(Of Single)
        Get
            If IsNothing(_NITROGEN) Then
                _NITROGEN = FindNITROGENValue()
            End If
            Return _NITROGEN
        End Get
        Set(ByVal value As Nullable(Of Single))
            _NITROGEN = value
        End Set
    End Property
    Private Function FindNITROGENValue() As Single
        For Each EachItem As String In Me.DeviceDataLines
            If EachItem.Contains("NITROGEN") Then
                Dim GetValues() As String = EachItem.Replace("NITROGEN", Nothing).Trim.Split("%")
                Return CType(GetValues(1).Trim, Single)
            End If
        Next
        Return Nothing
    End Function
#End Region
#Region "記錄時間 屬性:RecordTime"

    Private _RecordTime As DateTime = Nothing
    ''' <summary>
    ''' 記錄時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RecordTime() As DateTime
        Get
            If IsNothing(_RecordTime) Then
                _RecordTime = FindTimeValue()
            End If
            Return _RecordTime
        End Get
        Private Set(ByVal value As DateTime)
            _RecordTime = value
        End Set
    End Property

    Private Function FindTimeValue() As DateTime
        For RowIndex As Integer = DeviceDataLines.Count - 1 To 1 Step -1
            If DeviceDataLines(RowIndex).Trim.Length > 0 AndAlso DeviceDataLines(RowIndex).Contains("/") Then
                Dim GetValues() As String = DeviceDataLines(RowIndex).Trim.Trim.Split(" ")
                Dim Hour As Integer = CType(GetValues(0).Split(":")(0), Integer)
                Dim Minute As Integer = CType(GetValues(0).Split(":")(1), Integer)
                Return Now.Date.AddHours(Hour).AddMinutes(Minute)
            End If
        Next
        Return Nothing
    End Function

#End Region

#Region "資料物件 屬性:ORMObject"
    Private _ORMObject As OXYGENData
    ''' <summary>
    ''' 資料物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ORMObject() As OXYGENData
        Get
            If IsNothing(_ORMObject) Then
                _ORMObject = New OXYGENData
                With _ORMObject
                    .IDCODE = Me.IDCode
                    .NITROGEN = Me.NITROGEN
                    .OXYGEN = Me.OXYGEN
                End With
            End If
            Return _ORMObject
        End Get
        Protected Set(ByVal value As OXYGENData)
            _ORMObject = value
        End Set
    End Property
#End Region

End Class
