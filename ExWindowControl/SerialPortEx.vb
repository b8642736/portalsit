Public Class SerialPortEx
    Inherits System.IO.Ports.SerialPort

    Delegate Sub SerialPortDataReceivedAndSetDataInvoker(ByVal SourceControl As System.IO.Ports.SerialPort, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs)

    Public Event DataReceivFinishedEx(ByVal Sender As System.IO.Ports.SerialPort, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs, ByVal ReceiveData As String)
    Public Event DataReceivEx(ByVal Sender As System.IO.Ports.SerialPort, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs)

    Sub New()

    End Sub
    Sub New(ByVal ContainerControl As Control)
        Me.ContainerUserControl = ContainerControl
    End Sub

#Region "開啟Port並設定來源使用者控制項 方法:OpenAndSetContainerControl"
    ''' <summary>
    ''' 開啟Port並設定來源使用者控制項
    ''' </summary>
    ''' <param name="ContainerControl"></param>
    ''' <remarks></remarks>
    Public Sub OpenAndSetContainerControl(ByVal ContainerControl As Control)
        Me.ContainerUserControl = ContainerControl
        Me.Open()
    End Sub
#End Region

#Region "等待資料接數間隔時間 屬性:ReceiveDataIntervalMilliSeconds"

    Private _ReceiveDataIntervalMilliSeconds As Int32 = 100
    ''' <summary>
    ''' 等待資料接數間隔時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReceiveDataIntervalMilliSeconds() As Int32
        Get
            Return _ReceiveDataIntervalMilliSeconds
        End Get
        Set(ByVal value As Int32)
            _ReceiveDataIntervalMilliSeconds = value
        End Set
    End Property

#End Region

#Region "容器控制項 屬性:ContainerUserControl"

    Private _ContainerUserControl As Control
    ''' <summary>
    ''' 容器控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ContainerUserControl() As Control
        Get
            Return _ContainerUserControl
        End Get
        Set(ByVal value As Control)
            _ContainerUserControl = value
        End Set
    End Property

#End Region


    Sub DataReceivedEx1(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Me.DataReceived
        If Not IsNothing(ContainerUserControl) Then
            Dim ParamArgs(1) As Object
            ParamArgs(0) = sender
            ParamArgs(1) = e
            ContainerUserControl.Invoke(New SerialPortDataReceivedAndSetDataInvoker(AddressOf DataReceivedEx2_SetRs232Data), ParamArgs)
        End If
    End Sub

    Public Sub DataReceivedEx_SetRs232Data(ByVal SourceControl As System.IO.Ports.SerialPort, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs)
        RaiseEvent DataReceivEx(SourceControl, e)
    End Sub




    Private Sub DataReceivedEx2(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Me.DataReceived

        If Not IsNothing(ContainerUserControl) Then
            Dim ParamArgs(1) As Object
            ParamArgs(0) = sender
            ParamArgs(1) = e
            ContainerUserControl.Invoke(New SerialPortDataReceivedAndSetDataInvoker(AddressOf DataReceivedEx2_SetRs232Data), ParamArgs)
        End If

    End Sub

    Public Sub DataReceivedEx2_SetRs232Data(ByVal SourceControl As System.IO.Ports.SerialPort, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs)
        Dim GetValue As String
        Dim SetValue As String = Nothing
        Do
            GetValue = SourceControl.ReadExisting
            SetValue &= GetValue
            Threading.Thread.Sleep(ReceiveDataIntervalMilliSeconds)
        Loop While GetValue.Length > 0
        RaiseEvent DataReceivFinishedEx(SourceControl, e, SetValue)
    End Sub

End Class
