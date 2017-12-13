Public Class ZML
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
#Region "原始鋼捲重量 屬性:OrganCoilWeight"
    Private _OrganCoilWeight As Double = 0
    ''' <summary>
    ''' 原始鋼捲重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OrganCoilWeight() As Double
        Get
            Return _OrganCoilWeight
        End Get
        Private Set(ByVal value As Double)
            _OrganCoilWeight = value
        End Set
    End Property

#End Region
#Region "原始鋼捲退料重量 屬性:OrganCoilReturnWeightWeight"
    Private _OrganCoilReturnWeightWeight As Double
    ''' <summary>
    ''' 原始鋼捲退料重量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OrganCoilReturnWeightWeight() As Double
        Get
            Return _OrganCoilReturnWeightWeight
        End Get
        Private Set(ByVal value As Double)
            _OrganCoilReturnWeightWeight = value
        End Set
    End Property

#End Region
#Region "顯示其它輥設定值至Memo欄位 函式:ShowOtherWorkValuesToMemo"
    ''' <summary>
    ''' "顯示其它輥設定值至Memo欄位
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowThisCoilOtherWorkValuesToMemo()
        Dim ShowString As New StringBuilder
        If Not IsNothing(Me.EdittingData) Then
            With Me.EdittingData
                ShowString.Append("背輥A:" & .ZML_BURod1)
                ShowString.Append("背輥B:" & .ZML_BURod2)
                ShowString.Append("背輥C:" & .ZML_BURod3)
                ShowString.Append("背輥D:" & .ZML_BURod4)
                ShowString.Append("背輥E:" & .ZML_BDRod4)
                ShowString.Append("背輥F:" & .ZML_BDRod3)
                ShowString.Append("背輥G:" & .ZML_BDRod2)
                ShowString.Append("背輥H:" & .ZML_BDRod1)
                ShowString.Append(vbNewLine)
                ShowString.Append("2ST上左:" & .ZML_MURod1)
                ShowString.Append("2ST上惰輥:" & .ZML_MURod2)
                ShowString.Append("2ST上右:" & .ZML_MURod3)
                ShowString.Append("2ST下左:" & .ZML_MDRod1)
                ShowString.Append("2ST下惰輥:" & .ZML_MDRod2)
                ShowString.Append("2ST下右:" & .ZML_MDRod3)
                ShowString.Append(vbNewLine)
                ShowString.Append("1ST上左:" & .ZML_SURod1)
                ShowString.Append("1ST上右:" & .ZML_SURod3)
                ShowString.Append("1ST下左:" & .ZML_SDRod1)
                ShowString.Append("1ST下右:" & .ZML_SDRod3)
                ShowString.Append(vbNewLine)
                ShowString.Append("AT1:" & .ZML_AT1)
                ShowString.Append(vbTab & "AT2:" & .ZML_AT2)
                ShowString.Append(vbTab & "AT3:" & .ZML_AT3)
                ShowString.Append(vbTab & "AT4:" & .ZML_AT4)
                ShowString.Append(vbTab & "AT5:" & .ZML_AT5)
                ShowString.Append(vbTab & "AT6:" & .ZML_AT6)
                ShowString.Append(vbNewLine)
                ShowString.Append("BT1:" & .ZML_BT1)
                ShowString.Append(vbTab & "BT2:" & .ZML_BT2)
                ShowString.Append(vbTab & "BT3:" & .ZML_BT3)
                ShowString.Append(vbTab & "BT4:" & .ZML_BT4)
                ShowString.Append(vbTab & "BT5:" & .ZML_BT5)
                ShowString.Append(vbTab & "BT6:" & .ZML_BT6)
                ShowString.Append(vbNewLine)
                ShowString.Append("CT1:" & .ZML_CT1)
                ShowString.Append(vbTab & "CT2:" & .ZML_CT2)
                ShowString.Append(vbTab & "CT3:" & .ZML_CT3)
                ShowString.Append(vbTab & "CT4:" & .ZML_CT4)
                ShowString.Append(vbTab & "CT5:" & .ZML_CT5)
                ShowString.Append(vbTab & "CT6:" & .ZML_CT6)
                ShowString.Append(vbNewLine)
                ShowString.Append("DT1:" & .ZML_DT1)
                ShowString.Append(vbTab & "DT2:" & .ZML_DT2)
                ShowString.Append(vbTab & "DT3:" & .ZML_DT3)
                ShowString.Append(vbTab & "DT4:" & .ZML_DT4)
                ShowString.Append(vbTab & "DT5:" & .ZML_DT5)
                ShowString.Append(vbTab & "DT6:" & .ZML_DT6)
                ShowString.Append(vbNewLine)
                ShowString.Append("ET1:" & .ZML_ET1)
                ShowString.Append(vbTab & "ET2:" & .ZML_ET2)
                ShowString.Append(vbTab & "ET3:" & .ZML_ET3)
                ShowString.Append(vbTab & "ET4:" & .ZML_ET4)
                ShowString.Append(vbTab & "ET5:" & .ZML_ET5)
                ShowString.Append(vbTab & "ET6:" & .ZML_ET6)
                ShowString.Append(vbNewLine)
                ShowString.Append("FT1:" & .ZML_FT1)
                ShowString.Append(vbTab & "FT2:" & .ZML_FT2)
                ShowString.Append(vbTab & "FT3:" & .ZML_FT3)
                ShowString.Append(vbTab & "FT4:" & .ZML_FT4)
                ShowString.Append(vbTab & "FT5:" & .ZML_FT5)
                ShowString.Append(vbTab & "FT6:" & .ZML_FT6)
                ShowString.Append(vbNewLine)
                ShowString.Append("GT1:" & .ZML_GT1)
                ShowString.Append(vbTab & "GT2:" & .ZML_GT2)
                ShowString.Append(vbTab & "GT3:" & .ZML_GT3)
                ShowString.Append(vbTab & "GT4:" & .ZML_GT4)
                ShowString.Append(vbTab & "GT5:" & .ZML_GT5)
                ShowString.Append(vbTab & "GT6:" & .ZML_GT6)
                ShowString.Append(vbNewLine)
                ShowString.Append("HT1:" & .ZML_HT1)
                ShowString.Append(vbTab & "HT2:" & .ZML_HT2)
                ShowString.Append(vbTab & "HT3:" & .ZML_HT3)
                ShowString.Append(vbTab & "HT4:" & .ZML_HT4)
                ShowString.Append(vbTab & "HT5:" & .ZML_HT5)
                ShowString.Append(vbTab & "HT6:" & .ZML_HT6)
            End With
            rtbMemo.Text = ShowString.ToString & vbNewLine & rtbMemo.Text
        End If
    End Sub
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


#Region "重整控制項啟用按鈕 函式:RefreshEnableButton"
    ''' <summary>
    ''' 重整控制項啟用按鈕
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshEnableButton()
        btnWeightSubBackWeight.Enabled = True
    End Sub
#End Region




    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    End Sub

    Sub New(ByVal SetDefaultData As CompanyORMDB.SQLServer.PPS100LB.RunProcessData, ByVal SetCoilScanAndMachineProcess As CoilScanAndMachineProcess, ByVal SetEditingCoilScanedTreeNode As CoilScanedTreeNode)
        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.ParentControl_CoilScanAndMachineProcess = SetCoilScanAndMachineProcess
        Me.EditingCoilScanedTreeNode = SetEditingCoilScanedTreeNode
        Me.bsDataSource.Clear()
        Me.bsDataSource.Add(SetDefaultData)
        OrganCoilWeight = SetDefaultData.Weight
        OrganCoilReturnWeightWeight = SetDefaultData.ReturnWeight
        Call RefreshEnableButton()

        '加入列管訂單顥示
        If PSpecialOrderControl.Controls.Count = 0 Then
            PSpecialOrderControl.Controls.Add(Me.ControlOrderControl)
            Me.ControlOrderControl.Dock = DockStyle.Fill
        End If
    End Sub

    Public Function DataEndEditAndSave() As Integer Implements IStationRunningControl.DataEndEditAndSave
        Me.bsDataSource.EndEdit()
        Dim SelectValue As Integer = 0
        With EdittingData
            Select Case True
                Case rbScare0.Checked
                    SelectValue = 0
                Case rbScare1.Checked
                    SelectValue = 1
                Case rbScare2.Checked
                    SelectValue = 2
                Case rbScare3.Checked
                    SelectValue = 3
            End Select
            .ZML_Scare = SelectValue
            Select Case True
                Case rbPeels0.Checked
                    SelectValue = 0
                Case rbPeels1.Checked
                    SelectValue = 1
                Case rbPeels2.Checked
                    SelectValue = 2
                Case rbPeels3.Checked
                    SelectValue = 3
            End Select
            .ZML_Peels = SelectValue

            Select Case True
                Case rbSideState0.Checked
                    SelectValue = 0
                Case rbSideState1.Checked
                    SelectValue = 1
                Case rbSideState2.Checked
                    SelectValue = 2
                Case rbSideState3.Checked
                    SelectValue = 3
            End Select
            .ZML_SideState = SelectValue
        End With

        Return Me.EdittingData.CDBSave()
    End Function


    Private Sub btnWeightSubBackWeight_Click(sender As Object, e As EventArgs) Handles btnWeightSubBackWeight.Click
        Me.bsDataSource.EndEdit()
        If Not IsNothing(EdittingData) AndAlso EdittingData.ReturnWeight > 0 Then
            EdittingData.Weight -= EdittingData.ReturnWeight
            Me.bsDataSource.ResetBindings(False)
            btnWeightSubBackWeight.Enabled = False
        End If
    End Sub

    Private Sub btnResetWeight_Click(sender As Object, e As EventArgs) Handles btnResetWeight.Click
        Me.bsDataSource.EndEdit()
        If Not IsNothing(EdittingData) AndAlso EdittingData.ReturnWeight > 0 Then
            EdittingData.Weight = OrganCoilWeight
            Me.bsDataSource.ResetBindings(False)
            btnWeightSubBackWeight.Enabled = True
        End If
    End Sub

    Private Sub btnResetOtherWorkData_Click(sender As Object, e As EventArgs) Handles btnResetOtherWorkData.Click
        If Not IsNothing(Me.ParentControl_CoilScanAndMachineProcess) AndAlso Not IsNothing(Me.ParentControl_CoilScanAndMachineProcess.CurrentOperationPCRunningState) Then
            Me.EdittingData.SetZMLInitialWorkData(Me.ParentControl_CoilScanAndMachineProcess.CurrentOperationPCRunningState)
        End If
    End Sub

    Private Sub btnClearMemoData_Click(sender As Object, e As EventArgs) Handles btnClearMemoData.Click
        rtbMemo.Text = Nothing
    End Sub

    Private Sub btnShowOtherWorkData_Click(sender As Object, e As EventArgs) Handles btnShowOtherWorkData.Click
        ShowThisCoilOtherWorkValuesToMemo()
    End Sub

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
