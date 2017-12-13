Public Class ZMLOperationPCRunningState
    Implements IStationOperationPCRunningState

#Region "上層控制項CoilScanAndMachineProcess 屬性:ParentControl_CoilScanAndMachineProcess"
    Private _ParentControl_CoilScanAndMachineProcess As CoilScanAndMachineProcess
    ''' <summary>
    ''' 上層控制項CoilScanAndMachineProcess
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentControl_CoilScanAndMachineProcess As CoilScanAndMachineProcess Implements IStationOperationPCRunningState.ParentControl_CoilScanAndMachineProcess
        Get
            Return _ParentControl_CoilScanAndMachineProcess
        End Get
        Private Set(value As CoilScanAndMachineProcess)
            _ParentControl_CoilScanAndMachineProcess = value
        End Set
    End Property
#End Region
#Region "編輯中資料 屬性:EdittingData"
    ''' <summary>
    ''' 編輯中資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property EdittingData As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState Implements IStationOperationPCRunningState.EdittingData
        Get
            Return Me.bsDataSource.Current
        End Get
    End Property
#End Region


    Sub New(ByVal SetDefaultData As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState, ByVal SetCoilScanAndMachineProcess As CoilScanAndMachineProcess)
        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        '在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.ParentControl_CoilScanAndMachineProcess = SetCoilScanAndMachineProcess
        Me.bsDataSource.Add(SetDefaultData)
    End Sub

    Public Function DataEndEditAndSave() As Integer Implements IStationOperationPCRunningState.DataEndEditAndSave
        Me.bsDataSource.EndEdit()
        Return Me.EdittingData.CDBSave()
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
