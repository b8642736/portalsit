Public MustInherit Class DeviceDataConverterBase

    Sub New(ByVal SetDevice As DeviceTypeEnum, ByVal SetDeviceData As String)
        Me.Device = SetDevice
        Me.DeviceData = SetDeviceData
    End Sub

    Public Event DeviceDataChanged(ByVal OrginData As String, ByVal NewData As String)

#Region "裝置 屬性:Device"

    Private _Device As DeviceTypeEnum
    ''' <summary>
    ''' DataDevice
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Device() As DeviceTypeEnum
        Get
            Return _Device
        End Get
        Private Set(ByVal value As DeviceTypeEnum)
            _Device = value
        End Set
    End Property

#End Region
#Region "裝置資料 屬性:DeviceData"

    Private _DeviceData As String
    ''' <summary>
    ''' 裝置資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DeviceData() As String
        Get
            Return _DeviceData
        End Get
        Private Set(ByVal value As String)
            Dim OrginData As String = _DeviceData
            _DeviceData = value
            RaiseEvent DeviceDataChanged(OrginData, _DeviceData)
        End Set
    End Property

#End Region
#Region "裝置資料行 屬性:DeviceDataLines"

    Private _DeviceDataLines As List(Of String)
    ''' <summary>
    ''' 裝置資料行
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DeviceDataLines() As List(Of String)
        Get
            If IsNothing(_DeviceDataLines) Then
                _DeviceDataLines = New List(Of String)
                For Each EachItem As String In Me.DeviceData.Split(vbNewLine)
                    Dim TrimDataString As String = EachItem.Trim
                    If TrimDataString.Length > 0 Then
                        _DeviceDataLines.Add(TrimDataString)
                    End If
                Next
            End If
            Return _DeviceDataLines
        End Get
        Private Set(ByVal value As List(Of String))
            _DeviceDataLines = value
        End Set
    End Property

#End Region

End Class
