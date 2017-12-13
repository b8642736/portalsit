Public Class APL
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
#Region "重整下拉選單Bind資料來源 函式:RefreshBindPullDownMenuData"
    ''' <summary>
    ''' 重整下拉選單Bind資料來源
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshBindPullDownMenuData()
        ColdRollingClientDataSet.PackageSelectTable0.Rows.Clear()
        ColdRollingClientDataSet.PackageSelectTable1.Rows.Clear()
        ColdRollingClientDataSet.PackageSelectTable2.Rows.Clear()
        Dim AddItem0 As ColdRollingClientDataSet.PackageSelectTable0Row
        AddItem0 = ColdRollingClientDataSet.PackageSelectTable0.NewRow
        With AddItem0
            .Item("襯紙夾整捲") = "無"
            .Item("值") = "N"
        End With
        ColdRollingClientDataSet.PackageSelectTable0.Rows.Add(AddItem0)

        AddItem0 = ColdRollingClientDataSet.PackageSelectTable0.NewRow
        With AddItem0
            .Item("襯紙夾整捲") = "有"
            .Item("值") = "Y"
        End With
        ColdRollingClientDataSet.PackageSelectTable0.Rows.Add(AddItem0)



        Dim AddItem1 As ColdRollingClientDataSet.PackageSelectTable1Row
        AddItem1 = ColdRollingClientDataSet.PackageSelectTable1.NewRow
        With AddItem1
            .Item("厚薄") = "無"
            .Item("值") = "N"
        End With
        ColdRollingClientDataSet.PackageSelectTable1.Rows.Add(AddItem1)

        AddItem1 = ColdRollingClientDataSet.PackageSelectTable1.NewRow
        With AddItem1
            .Item("厚薄") = "薄"
            .Item("值") = "1"
        End With
        ColdRollingClientDataSet.PackageSelectTable1.Rows.Add(AddItem1)

        AddItem1 = ColdRollingClientDataSet.PackageSelectTable1.NewRow
        With AddItem1
            .Item("厚薄") = "厚"
            .Item("值") = "2"
        End With
        ColdRollingClientDataSet.PackageSelectTable1.Rows.Add(AddItem1)


        Dim AddItem2 As ColdRollingClientDataSet.PackageSelectTable2Row
        AddItem2 = ColdRollingClientDataSet.PackageSelectTable2.NewRow
        With AddItem2
            .Item("是否使用紙套筒") = "無"
            .Item("值") = "N"
        End With
        ColdRollingClientDataSet.PackageSelectTable2.Rows.Add(AddItem2)

        AddItem2 = ColdRollingClientDataSet.PackageSelectTable2.NewRow
        With AddItem2
            .Item("是否使用紙套筒") = "薄板"
            .Item("值") = "Y"
        End With
        ColdRollingClientDataSet.PackageSelectTable2.Rows.Add(AddItem2)


        Dim AddItem3 As ColdRollingClientDataSet.PackageSelectTable3Row
        AddItem3 = ColdRollingClientDataSet.PackageSelectTable3.NewRow
        With AddItem3
            .Item("是否奇力龍包整捲") = "是"
            .Item("值") = "Y"
        End With
        ColdRollingClientDataSet.PackageSelectTable3.Rows.Add(AddItem3)

        AddItem3 = ColdRollingClientDataSet.PackageSelectTable3.NewRow
        With AddItem3
            .Item("是否奇力龍包整捲") = "否"
            .Item("值") = "N"
        End With
        ColdRollingClientDataSet.PackageSelectTable3.Rows.Add(AddItem3)

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

#Region "傳送PDI訊號(APL暫時使用) 函式:SendPDIMsg"
    Shared cbWillSplitCoil_CheckedChangedLastChangeTime As DateTime = New DateTime(2000, 1, 1)
    ''' <summary>
    ''' 傳送PDI訊號(APL暫時使用)
    ''' </summary>
    ''' <param name="WillSplitCoil"></param>
    ''' <remarks></remarks>
    Public Sub SendPDIMsg(ByVal WillSplitCoil As Boolean)
        If Now.Subtract(cbWillSplitCoil_CheckedChangedLastChangeTime).TotalSeconds < 2 Then
            Exit Sub
        End If

        Dim PDIString As String = Nothing
        Dim SendCoilNumber As String = Nothing
        If Not IsNothing(Me.ParentControl_CoilScanAndMachineProcess) Then
            SendCoilNumber = Me.EdittingData.FK_LastRefSHA01 & Me.EdittingData.FK_LastRefSHA02.Trim
            PDIString &= Me.ParentControl_CoilScanAndMachineProcess.CurrentUesStationName
            PDIString &= "," & SendCoilNumber
            PDIString &= "," & Format(Now, "yyyy/MM/dd HH:mm:ss")
            PDIString &= "," & IIf(WillSplitCoil, "1", "0")
        End If
        If Not String.IsNullOrEmpty(PDIString) Then
            Me.ParentControl_CoilScanAndMachineProcess.SendPDIToL2(SendCoilNumber, PDIString)
        End If


        cbWillSplitCoil_CheckedChangedLastChangeTime = Now
        '連動所有分捲之控制項之cbWillSplitCoil欄位
        Dim ParentTabPage As TabPage = Me.Parent
        Dim ParentTabControl As TabControl = ParentTabPage.Parent
        For Each EachItem As TabPage In ParentTabControl.TabPages
            Dim SubControl As APL = Nothing
            If EachItem.Controls.Count > 0 AndAlso (TypeOf EachItem.Controls(0) Is APL) Then
                SubControl = EachItem.Controls(0)
                SubControl.cbWillSplitCoil.Checked = cbWillSplitCoil.Checked
            End If
        Next

    End Sub
#End Region


    Sub New(ByVal SetDefaultData As CompanyORMDB.SQLServer.PPS100LB.RunProcessData, ByVal SetCoilScanAndMachineProcess As CoilScanAndMachineProcess, ByVal SetEditingCoilScanedTreeNode As CoilScanedTreeNode)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        '在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.ParentControl_CoilScanAndMachineProcess = SetCoilScanAndMachineProcess
        Me.EditingCoilScanedTreeNode = SetEditingCoilScanedTreeNode
        RefreshBindPullDownMenuData()   '重整下拉選單Bind資料來源
        Me.bsDataSource.Clear()
        Me.bsDataSource.Add(SetDefaultData)
        Dim LastRefPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = SetDefaultData.AboutLastRefPPSSHAPF

        '加入列管訂單顥示
        If PSpecialOrderControl.Controls.Count = 0 Then
            PSpecialOrderControl.Controls.Add(Me.ControlOrderControl)
            Me.ControlOrderControl.Dock = DockStyle.Fill
        End If

        Dim CurrentOperationPCRunningState As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState = ParentControl_CoilScanAndMachineProcess.CurrentOperationPCRunningState
        If Not IsNothing(CurrentOperationPCRunningState) AndAlso CurrentOperationPCRunningState.LabelPrintPageCount = 4 Then
            SetDefaultData.IsFinishProduct = True
        End If
    End Sub

    Public Function DataEndEditAndSave() As Integer Implements IStationRunningControl.DataEndEditAndSave
        Me.bsDataSource.EndEdit()
        Return Me.EdittingData.CDBSave()
    End Function

    Private Sub cbPaperPLSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPaperPLSelect.SelectedIndexChanged
        tbPaperFixLength.Enabled = (CType(sender, ComboBox).SelectedValue = "N")
        If tbPaperFixLength.Enabled = False Then
            tbPaperFixLength.Text = "9999.9"
        End If

    End Sub

    Private Sub cbWillSplitCoil_CheckedChanged(sender As Object, e As EventArgs) Handles cbWillSplitCoil.CheckedChanged
        SendPDIMsg(cbWillSplitCoil.Checked)
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
        Me.bsDataSource.Clear()
        EditingCoilScanedTreeNode = Nothing
        ControlOrderControl = Nothing
        ParentControl_CoilScanAndMachineProcess = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub cbPaperPrint4Copies_MouseUp(sender As Object, e As MouseEventArgs) Handles cbPaperPrint4Copies.MouseUp
        Dim CurrentOperationPCRunningState As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState = ParentControl_CoilScanAndMachineProcess.CurrentOperationPCRunningState
        If Not IsNothing(ParentControl_CoilScanAndMachineProcess) Then
            If cbPaperPrint4Copies.Checked Then
                CurrentOperationPCRunningState.LabelPrintPageCount = 4
            Else
                CurrentOperationPCRunningState.LabelPrintPageCount = 2
            End If
            'Dim SourceDataObject As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState = ParentControl_CoilScanAndMachineProcess.TheMachinePCRunningState
            If CurrentOperationPCRunningState.CDBSave > 0 Then
                ParentControl_CoilScanAndMachineProcess.LastSaveStationDataLastChangeTime = StationDataLastChangeTime.SetNewLastSaveTime(CurrentOperationPCRunningState.RunningPCIP, StationDataLastChangeTime.StationDataLastChangeTimeType.OperationPCRunningStateSaveTime)
            End If
        End If
    End Sub

End Class
