Public Class QCOthers
    Implements IQCControl


#Region "相關CoilScanAndMachineProcess 屬性:AboutCoilScanAndMachineProcess"

    Private _AboutCoilScanAndMachineProcess As CoilScanAndMachineProcess
    ''' <summary>
    ''' 相關CoilScanAndMachineProcess
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutCoilScanAndMachineProcess() As CoilScanAndMachineProcess Implements IQCControl.AboutCoilScanAndMachineProcess
        Get
            Return _AboutCoilScanAndMachineProcess
        End Get
        Private Set(ByVal value As CoilScanAndMachineProcess)
            _AboutCoilScanAndMachineProcess = value
        End Set
    End Property

#End Region


    Public Sub New(ByVal SetCoilScanAndMachineProcess As CoilScanAndMachineProcess)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.AboutCoilScanAndMachineProcess = SetCoilScanAndMachineProcess
    End Sub


End Class
