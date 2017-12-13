Public Class BAL
    Implements IStationRunningControl


#Region "編輯中資料 屬性:EdittingData"
    ''' <summary>
    ''' 編輯中資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property EdittingData As CompanyORMDB.SQLServer.PPS100LB.RunProcessData Implements IStationRunningControl.EdittingData
        Get
            Return Me.bsDataSource.Current
        End Get
    End Property
#End Region
#Region "編輯中CoilScanedTreeNode 屬性:EditingCoilScanedTreeNode"
    Private _EditingCoilScanedTreeNode As CoilScanedTreeNode
    ''' <summary>
    ''' 編輯中CoilScanedTreeNode
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EditingCoilScanedTreeNode() As CoilScanedTreeNode Implements IStationRunningControl.EditingCoilScanedTreeNode
        Get
            Return _EditingCoilScanedTreeNode
        End Get
        Private Set(ByVal value As CoilScanedTreeNode)
            _EditingCoilScanedTreeNode = value
        End Set
    End Property

#End Region
#Region "上層控制項CoilScanAndMachineProcess 屬性:ParentControl_CoilScanAndMachineProcess"
    Private _ParentControl_CoilScanAndMachineProcess As CoilScanAndMachineProcess
    ''' <summary>
    ''' 上層控制項CoilScanAndMachineProcess
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentControl_CoilScanAndMachineProcess As CoilScanAndMachineProcess Implements IStationRunningControl.ParentControl_CoilScanAndMachineProcess
        Get
            Return _ParentControl_CoilScanAndMachineProcess
        End Get
        Private Set(value As CoilScanAndMachineProcess)
            _ParentControl_CoilScanAndMachineProcess = value
        End Set
    End Property
#End Region
#Region "列管訂控制項 屬性:ControlOrderControl"
    Private _ControlOrderControl As ControlOlder
    ''' <summary>
    ''' 列管訂控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ControlOrderControl() As ControlOlder
        Get
            If IsNothing(_ControlOrderControl) Then
                If Not IsNothing(Me.EditingCoilScanedTreeNode) Then
                    _ControlOrderControl = New ControlOlder(Me.EditingCoilScanedTreeNode)
                End If
            End If
            Return _ControlOrderControl
        End Get
        Private Set(ByVal value As ControlOlder)
            _ControlOrderControl = value
        End Set
    End Property
#End Region


    Public Sub New(ByVal SetDefaultData As CompanyORMDB.SQLServer.PPS100LB.RunProcessData, ByVal SetCoilScanAndMachineProcess As CoilScanAndMachineProcess, ByVal SetEditingCoilScanedTreeNode As CoilScanedTreeNode)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        '在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.ParentControl_CoilScanAndMachineProcess = SetCoilScanAndMachineProcess
        Me.EditingCoilScanedTreeNode = SetEditingCoilScanedTreeNode
        Me.bsDataSource.Clear()
        Me.bsDataSource.Add(SetDefaultData)
        Dim LastRefPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = SetDefaultData.AboutLastRefPPSSHAPF

        '加入列管訂單顥示
        If PSpecialOrderControl.Controls.Count = 0 Then
            PSpecialOrderControl.Controls.Add(Me.ControlOrderControl)
            Me.ControlOrderControl.Dock = DockStyle.Fill
        End If

    End Sub


    Public Function DataEndEditAndSave() As Integer Implements IStationRunningControl.DataEndEditAndSave
        Me.bsDataSource.EndEdit()
        Return Me.EdittingData.CDBSave()
    End Function


    Private Sub cbCheckAllDataCorrect_CheckedChanged(sender As Object, e As EventArgs) Handles cbCheckAllDataCorrect.CheckedChanged
        Me.bsDataSource.EndEdit()
        Dim SetCheckedTime As Nullable(Of DateTime) = CompanyORMDB.DeviceInformation.GetSQLServerTime(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m)
        If IsNothing(SetCheckedTime) Then
            SetCheckedTime = Me.EdittingData.SysCoilStartTime
        End If
        If Me.EdittingData.IsUserRunningDataChecked AndAlso Me.EdittingData.UserRunningDataCheckedTime < Me.EdittingData.SysCoilStartTime Then
            Me.EdittingData.UserRunningDataCheckedTime = SetCheckedTime
        Else
            Me.EdittingData.UserRunningDataCheckedTime = New DateTime(2000, 1, 1)
            tCheckData.Enabled = True
        End If
    End Sub

    Private Sub tCheckData_Tick(sender As Object, e As EventArgs) Handles tCheckData.Tick
        Static OrginBackColor As System.Drawing.Color = cbCheckAllDataCorrect.BackColor
        Static OrginForeColor As System.Drawing.Color = cbCheckAllDataCorrect.ForeColor
        Static IsDisplayMode1 As Boolean = False
        If IsDisplayMode1 Then
            cbCheckAllDataCorrect.ForeColor = Color.Red
            cbCheckAllDataCorrect.BackColor = Color.LightPink
        Else
            cbCheckAllDataCorrect.ForeColor = OrginForeColor
            cbCheckAllDataCorrect.BackColor = OrginBackColor
        End If
        IsDisplayMode1 = Not IsDisplayMode1
        If cbCheckAllDataCorrect.Checked Then
            cbCheckAllDataCorrect.ForeColor = OrginForeColor
            cbCheckAllDataCorrect.BackColor = OrginBackColor
            tCheckData.Enabled = False
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
