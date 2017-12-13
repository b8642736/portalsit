Public Class StationClient
    Implements IStation

#Region "本站所有處理排程 屬性:TheStationAllProcessScheduals"
    Private _TheStationAllProcessScheduals As List(Of ProcessSchedual)
    ''' <summary>
    ''' 本站所有處理排程
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TheStationAllProcessScheduals As System.Collections.Generic.List(Of CompanyORMDB.SQLServer.PPS100LB.ProcessSchedual) Implements IStation.StationIsProcessScheduals
        Get
            Static LastGetDataTime As DateTime = Now
            If IsNothing(_TheStationAllProcessScheduals) OrElse Now.Subtract(LastGetDataTime).Seconds > 3 Then
                Dim FindIPs As New List(Of String)
                FindIPs.Add(PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.RunningPCIP.Trim)
                _TheStationAllProcessScheduals = ProcessSchedual.GetProcessSchedualFromStationForIP(FindIPs)
                LastGetDataTime = Now
            End If
            Return _TheStationAllProcessScheduals
        End Get
        Private Set(ByVal value As System.Collections.Generic.List(Of CompanyORMDB.SQLServer.PPS100LB.ProcessSchedual))
            _TheStationAllProcessScheduals = value
        End Set
    End Property
#End Region
#Region "取得現在使用中處理排程 屬性:GetCurrentUseProcessSchedual"
    ''' <summary>
    ''' 取得現在使用中處理排程
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCurrentUseProcessSchedual() As ProcessSchedual
        If flpProcessSchedualSelect.Controls.Count = 0 Then
            Return Nothing
        End If
        Dim SelectedStationName As String = Nothing
        For Each Eachitem As ProcessSchedualRadioButton In flpProcessSchedualSelect.Controls
            If Eachitem.Checked Then
                Return Eachitem.UseProcessSchedual
            End If
        Next
        Return Nothing
    End Function

#End Region
#Region "重整顯示處理排程選擇 函式:RefreshDisplayProcessSchedual"
    ''' <summary>
    ''' 重整顯示處理排程選擇
    ''' </summary>
    ''' <param name="SteelFace">指定顯示處理表面(EX:2B/2D/BA...)</param>
    ''' <remarks></remarks>
    Private Sub RefreshDisplayProcessSchedual(ByVal SteelFace As String)
        flpProcessSchedualSelect.Controls.Clear()
        If String.IsNullOrEmpty(SteelFace) Then
            Exit Sub
        End If
        Dim AllKnowFinalFishStrings As New List(Of String)
        For Each EachItem As ProcessSchedual In ProcessSchedual.AllProcessScheduals
            If Not AllKnowFinalFishStrings.Contains(EachItem.FinalFish.Trim) AndAlso EachItem.FinalFish.Trim <> "*" Then
                AllKnowFinalFishStrings.Add(EachItem.FinalFish.Trim)
            End If
        Next

        '處理角色選定:
        If AllKnowFinalFishStrings.Contains(SteelFace.Trim) Then
            lbProcessSchedual.Text = SteelFace.Trim & "表面 處理角色選定:"
            For Each EachItem As ProcessSchedual In TheStationAllProcessScheduals
                If EachItem.FinalFish.Trim <> "*" AndAlso EachItem.FinalFish.Trim = SteelFace.Trim Then
                    flpProcessSchedualSelect.Controls.Add(New ProcessSchedualRadioButton(EachItem))
                    If flpProcessSchedualSelect.Controls.Count = 1 Then
                        CType(flpProcessSchedualSelect.Controls(0), RadioButton).Checked = True
                    End If
                End If
            Next
            If flpProcessSchedualSelect.Controls.Count = 0 Then
                MsgBox("找不到最終表面為" & SteelFace.Trim & " 之處理流程 請洽系統管理員!")
            End If
        Else
            lbProcessSchedual.Text = "(未知:*)表面 處理角色選定:"
            For Each EachItem As ProcessSchedual In TheStationAllProcessScheduals
                If EachItem.FinalFish.Trim = "*" Then
                    flpProcessSchedualSelect.Controls.Add(New ProcessSchedualRadioButton(EachItem))
                    If flpProcessSchedualSelect.Controls.Count = 1 Then
                        CType(flpProcessSchedualSelect.Controls(0), RadioButton).Checked = True
                    End If
                End If
            Next
            If flpProcessSchedualSelect.Controls.Count = 0 Then
                MsgBox("找不到 已知/(未知:*) 最終表面為" & SteelFace.Trim & " 之處理流程 請洽系統管理員!")
            End If
        End If
    End Sub
#End Region
#Region "現在作業中鋼捲詳細資料 屬性:CurrentRunningCoilDetailDatas"
    ''' <summary>
    ''' 現在作業中鋼捲
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentRunningCoilDetailDatas() As List(Of CompanyORMDB.IPPS100LB.IPPSSHAPF)
        Get
            Dim ReturnValue As New List(Of CompanyORMDB.IPPS100LB.IPPSSHAPF)
            Dim SelectNode As CoilScanedTreeNode = Me.TreeView1.SelectedNode
            If IsNothing(SelectNode) OrElse IsNothing(SelectNode.MyPPSSHAPFFlowAdapter) Then
                Return ReturnValue
            End If
            Return SelectNode.MyPPSSHAPFFlowAdapter.FinalALLPPSSHAPFs
        End Get
    End Property
#End Region
#Region "現在選擇處理的鋼捲樹狀節點 屬性:CurrentSelectTreeNode"
    Private _CurrentSelectTreeNode As CoilScanedTreeNode
    ''' <summary>
    ''' 現在選擇處理的鋼捲樹狀節點
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CurrentSelectTreeNode As CoilScanedTreeNode
        Get
            If Not _CurrentSelectTreeNode Is Me.TreeView1.SelectedNode Then
                CurrentSelectTreeNode = Me.TreeView1.SelectedNode
            End If
            Return _CurrentSelectTreeNode ' Me.TreeView1.SelectedNode
        End Get
        Set(ByVal value As CoilScanedTreeNode)
            _CurrentSelectTreeNode = value
            ChangTreeNodeProcess()
        End Set
    End Property

    Private Sub ChangTreeNodeProcess()
        Try
            btnEndAndSave.Enabled = False
            Me.bsCurrentRunProcessData.DataSource = (From A In CurrentSelectTreeNode.MyPPSSHAPFFlowAdapter.AboutRunProcessDatas Where A.ThisRecordState = 2 And A.RunStationPCIP = CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.RunningPCIP And A.FK_RunStationName.Trim = CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.DefaultUseStationName.Trim Select A).ToList
            Me.bsCurrentCoilDatas.DataSource = CurrentSelectTreeNode.MyPPSSHAPFFlowAdapter.FinalALLPPSSHAPFs

            '分捲數量設定 NumericUpDown1.Value = CurrentSelectTreeNode.
            Me.bsdNewAddCoilDatas.DataSource = Nothing
            Dim TreeView1SelectNode As CoilScanedTreeNode = TreeView1.SelectedNode
            btnCreateTheStationDatas.Enabled = Not IsNothing(TreeView1SelectNode)
            If Not IsNothing(TreeView1SelectNode) AndAlso Not IsNothing(TreeView1SelectNode.MyPPSSHAPFFlowAdapter) Then
                RefreshDisplayProcessSchedual(TreeView1SelectNode.MyPPSSHAPFFlowAdapter.CoilFullNumberPlanningFinish)
            Else
                RefreshDisplayProcessSchedual(Nothing)
            End If
            tsslMessage.Text = Nothing
            Dim CanDeleteDataCount As Integer = GetTheStationLastSaveDatas.Count
            btnDeleteLastSaveDatas.Text = "刪除最後本站儲存資料(" & CanDeleteDataCount & " 筆)"
            btnDeleteLastSaveDatas.Enabled = CanDeleteDataCount > 0
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
#End Region
#Region "現在編輯新增的PPSSHAPF 屬性:CurrentEditNewPPSSHAPF"

    Private _CurrentEditNewPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF
    ''' <summary>
    ''' 現在編輯新增的PPSSHAPF
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentEditNewPPSSHAPF() As CompanyORMDB.IPPS100LB.IPPSSHAPF
        Get
            Return _CurrentEditNewPPSSHAPF
        End Get
        Set(ByVal value As CompanyORMDB.IPPS100LB.IPPSSHAPF)
            _CurrentEditNewPPSSHAPF = value
        End Set
    End Property

#End Region
#Region "新資料TabPage 屬性:NewDataEditTabpage"
    Private _NewDataEditTabpage As TabPage = Nothing
    WithEvents NewDataEditControlEvent As NewDataEdit
    ReadOnly Property NewDataEditTabpage As TabPage
        Get
            If IsNothing(_NewDataEditTabpage) Then
                _NewDataEditTabpage = New TabPage
                _NewDataEditTabpage.Text = "新增鋼捲掃描作業資料編輯"
                _NewDataEditTabpage.Name = "tpNewDataEdit"
                'Me.TabControl1.TabPages.Add(_NewDataEditTabpage)
                Dim EditControl As New NewDataEdit
                NewDataEditControlEvent = EditControl
                EditControl.PreControl = Me
                _NewDataEditTabpage.Controls.Add(EditControl)
                EditControl.Dock = DockStyle.Top
            End If
            Return _NewDataEditTabpage
        End Get
    End Property


    Private Sub NewDataEditControlEvent_Finish(ByVal Sender As NewDataEdit) Handles NewDataEditControlEvent.Finish
        Me.TabControl1.TabPages.Remove(NewDataEditTabpage)
        Me.TabControl1.SelectTab(Me.TabPage2)
    End Sub
#End Region
#Region "取得本站最後一次存檔資料 方法:GetTheStationLastSaveDatas"
    ''' <summary>
    ''' 取得本站最後一次存檔資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTheStationLastSaveDatas() As List(Of CompanyORMDB.SQLServer.PPS100LB.PPSSHAPF)
        '驗證本站是否可刪除最後一次存檔資料(含分捲)
        Dim ReturnValue As New List(Of CompanyORMDB.SQLServer.PPS100LB.PPSSHAPF)
        Dim CoilFullNumberForLastPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = Me.CurrentSelectTreeNode.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF
        If TypeOf CoilFullNumberForLastPPSSHAPF Is CompanyORMDB.SQLServer.PPS100LB.PPSSHAPF AndAlso CType(CoilFullNumberForLastPPSSHAPF, CompanyORMDB.SQLServer.PPS100LB.PPSSHAPF).SavePCIP.Trim = PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.RunningPCIP.Trim Then
            ReturnValue.Add(CoilFullNumberForLastPPSSHAPF)
        End If
        Return ReturnValue
    End Function
#End Region
#Region "重整已完成處理等待編輯鋼捲節點 函式:RefreshFinishProcessWaitEditCoilsNodes"
    ''' <summary>
    ''' 重整已完成處理等待編輯鋼捲節點
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshFinishProcessWaitEditCoilsNodes()
        Dim GetData As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState = PPSSHAPFFlowAdapter.CurrentOperationPCRunningState
        If IsNothing(GetData) Then
            Exit Sub
        End If
        Dim CurrentUesStationName As String = GetData.DefaultUseStationName
        TreeView1.Nodes.Clear()
        For Each EachItem As String In GetData.AboutTop50FinishProcessWaitEditCoilNumbers
            TreeView1.Nodes.Add(New CoilScanedTreeNode(EachItem.Trim))
            Application.DoEvents()
        Next
    End Sub
#End Region


#Region "現在執行RunningCoilScanAndMachineProcess控制項 屬性/事件:CurrentRunningCoilScanAndMachineProcessControl"
    ''' <summary>
    ''' 現在執行RunningCoilScanAndMachineProcess控制項
    ''' </summary>
    ''' <remarks></remarks>
    Public WithEvents CoilScanAndMachineProcessEvent As CoilScanAndMachineProcess
    Private _CurrentRunningCoilScanAndMachineProcessControl As CoilScanAndMachineProcess = Nothing
    ReadOnly Property CurrentRunningCoilScanAndMachineProcessControl As CoilScanAndMachineProcess
        Get
            If IsNothing(_CurrentRunningCoilScanAndMachineProcessControl) Then
                _CurrentRunningCoilScanAndMachineProcessControl = New CoilScanAndMachineProcess
                CoilScanAndMachineProcessEvent = _CurrentRunningCoilScanAndMachineProcessControl
            End If
            Return _CurrentRunningCoilScanAndMachineProcessControl
        End Get
    End Property

#End Region

#Region "現在執行CurrentCoilMoveStationEditControl控制項 屬性:CurrentCoilMoveStationEditControl"
    Private _CurrentCoilMoveStationEditControl As CoilMoveStationEdit
    ''' <summary>
    ''' 現在執行CurrentCoilMoveStationEditControl控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentCoilMoveStationEditControl() As CoilMoveStationEdit
        Get
            If IsNothing(_CurrentCoilMoveStationEditControl) Then
                _CurrentCoilMoveStationEditControl = New CoilMoveStationEdit(Me.CurrentRunningCoilScanAndMachineProcessControl)
            End If
            Return _CurrentCoilMoveStationEditControl
        End Get
        Set(ByVal value As CoilMoveStationEdit)
            _CurrentCoilMoveStationEditControl = value
        End Set
    End Property
#End Region


#Region "現在執行CoilBeforeRunningProcess控制項 屬性:CoilBeforeRunningProcessControl"
    Private _CoilBeforeRunningProcessControl As CoilBeforeRunningProcess
    ''' <summary>
    ''' 現在執行CoilBeforeRunningProcess控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CoilBeforeRunningProcessControl() As CoilBeforeRunningProcess
        Get
            If IsNothing(_CoilBeforeRunningProcessControl) Then
                _CoilBeforeRunningProcessControl = New CoilBeforeRunningProcess(Me.CurrentRunningCoilScanAndMachineProcessControl)
            End If
            Return _CoilBeforeRunningProcessControl
        End Get
        Set(ByVal value As CoilBeforeRunningProcess)
            _CoilBeforeRunningProcessControl = value
        End Set
    End Property
#End Region

#Region "現在執行CoilAfterRunningProcess控制項 屬性:CoilAfterRunningProcessControl"
    Private _CoilAfterRunningProcess As CoilAfterRunningProcess
    ''' <summary>
    ''' 現在執行CoilAfterRunningProcess控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CoilAfterRunningProcessControl() As CoilAfterRunningProcess
        Get
            If IsNothing(_CoilAfterRunningProcess) Then
                _CoilAfterRunningProcess = New CoilAfterRunningProcess(Me.CurrentRunningCoilScanAndMachineProcessControl)
            End If
            Return _CoilAfterRunningProcess
        End Get
        Set(ByVal value As CoilAfterRunningProcess)
            _CoilAfterRunningProcess = value
        End Set
    End Property
#End Region

#Region "現在執行自主品管控制項 屬性:CurrentQCControl"
    Private _CurrentQCControl As IQCControl = Nothing
    ''' <summary>
    ''' 現在執行自主品管控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CurrentQCControl() As IQCControl
        Get
            If IsNothing(_CurrentQCControl) AndAlso Not IsNothing(Me.CurrentRunningCoilScanAndMachineProcessControl) AndAlso Not IsNothing(Me.CurrentRunningCoilScanAndMachineProcessControl.CurrentUesStationName) Then
                Dim StationName As String = Me.CurrentRunningCoilScanAndMachineProcessControl.CurrentUesStationName.PadRight(3).ToUpper

                Select Case True
                    Case StationName = "TLL" AndAlso Me.CurrentRunningCoilScanAndMachineProcessControl.TheMachinePCRunningState.IsTheOperationPCRunningStateForThisMachine
                        _CurrentQCControl = New QCTLL(Me.CurrentRunningCoilScanAndMachineProcessControl)
                    Case StationName = "SPL" AndAlso Me.CurrentRunningCoilScanAndMachineProcessControl.TheMachinePCRunningState.IsTheOperationPCRunningStateForThisMachine
                        _CurrentQCControl = New QCSPL(Me.CurrentRunningCoilScanAndMachineProcessControl)
                    Case StationName = "SBL" AndAlso Me.CurrentRunningCoilScanAndMachineProcessControl.TheMachinePCRunningState.IsTheOperationPCRunningStateForThisMachine
                        _CurrentQCControl = New QCSBL(Me.CurrentRunningCoilScanAndMachineProcessControl)
                    Case Else
                        _CurrentQCControl = New QCOthers(Me.CurrentRunningCoilScanAndMachineProcessControl)
                End Select
            End If
            Return _CurrentQCControl
        End Get
        Private Set(value As IQCControl)
            _CurrentQCControl = value
        End Set
    End Property
#End Region


#Region "快速鍵呼叫特殊功能 函式:QuickKeyCallSpecialFunction"
    ''' <summary>
    ''' 快速鍵呼叫特殊功能(如直接將鋼捲結束並印表)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub QuickKeyCallSpecialFunction(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.Q AndAlso Not IsNothing(Me.CurrentRunningCoilScanAndMachineProcessControl) Then
            Me.CurrentRunningCoilScanAndMachineProcessControl.QuickCoilEndAndPrint()
        End If
    End Sub
#End Region




    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.tpCoilScanAndMachineProcess.Controls.Add(Me.CurrentRunningCoilScanAndMachineProcessControl)
        Me.CurrentRunningCoilScanAndMachineProcessControl.Dock = DockStyle.Fill

        Me.tpCoilMoveStationEdit.Controls.Add(Me.CurrentCoilMoveStationEditControl)
        CurrentCoilMoveStationEditControl.Dock = DockStyle.Fill

        Me.tpCoilBeforeRunningProcess.Controls.Add(Me.CoilBeforeRunningProcessControl)
        Me.CoilBeforeRunningProcessControl.Dock = DockStyle.Fill

        Me.tpCoilAfterRunningProcessControl.Controls.Add(Me.CoilAfterRunningProcessControl)
        Me.CoilAfterRunningProcessControl.Dock = DockStyle.Fill

        Me.tpSelfQC.Controls.Add(Me.CurrentQCControl)
        If Not IsNothing(Me.CurrentQCControl) Then
            CType(Me.CurrentQCControl, Control).Dock = DockStyle.Fill
        End If

    End Sub

    Private Sub btnAddCoil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCoil.Click
        Dim AddNode As New CoilScanedTreeNode(TextBox1.Text)
        TextBox1.Text = Nothing
        Me.TreeView1.Nodes.Add(AddNode)
        Me.CurrentRunningCoilScanAndMachineProcessControl.SaveControlValueToOperationPCRunningState()
        Me.RefreshFinishProcessWaitEditCoilsNodes()
        tsslMessage.Text = Nothing
        If AddNode.VerifyCoil() = False Then
            tsslMessage.Text = AddNode.Message
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        CurrentSelectTreeNode = TreeView1.SelectedNode
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If Not IsNothing(TreeView1.SelectedNode) AndAlso MsgBox("是否確定移除此鋼捲(" & TreeView1.SelectedNode.Text & ")?", MsgBoxStyle.YesNo, "注意!") = MsgBoxResult.Yes Then
            Dim SelectNode As CoilScanedTreeNode = TreeView1.SelectedNode
            Me.TreeView1.Nodes.Remove(SelectNode)
            TreeView1.Nodes.Remove(TreeView1.SelectedNode)
        End If
    End Sub

    Private Sub btnCreateTheStationDatas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateTheStationDatas.Click, btnCreateTheStationDatas1.Click
        Dim SelectNode As CoilScanedTreeNode = Me.TreeView1.SelectedNode
        If IsNothing(SelectNode) Then
            Exit Sub
        End If
        tsslMessage.Text = "新增資料產生中請稍後....!" : Application.DoEvents()
        '依最終表面取得目前本站設定處理的ProcessSchedual角色
        Dim UseProcessSchedual As ProcessSchedual = GetCurrentUseProcessSchedual()
        If sender Is btnCreateTheStationDatas Then
            If SelectNode.MyPPSSHAPFFlowAdapter.NewPPSSHAPFs(UseProcessSchedual, NumericUpDown1.Value - 1) = False Then
                tsslMessage.Text = SelectNode.MyPPSSHAPFFlowAdapter.Message
                Exit Sub
            End If
        Else
            Dim GetSelectRunProcessData As New List(Of RunProcessData)
            For Each EachItem As DataGridViewRow In Me.DataGridView3.Rows
                GetSelectRunProcessData.Add(EachItem.DataBoundItem)
            Next
            If SelectNode.MyPPSSHAPFFlowAdapter.NewPPSSHAPFs(UseProcessSchedual, GetSelectRunProcessData) = False Then
                tsslMessage.Text = SelectNode.MyPPSSHAPFFlowAdapter.Message
                Exit Sub
            End If
        End If

        Me.bsdNewAddCoilDatas.DataSource = SelectNode.MyPPSSHAPFFlowAdapter.AlreadyNewPPSSHAPFs
        tsslMessage.Text = "已成功產生 " & SelectNode.MyPPSSHAPFFlowAdapter.AlreadyNewPPSSHAPFs.Count & " 筆資料並等待確認後新增!"
        btnEndAndSave.Enabled = SelectNode.MyPPSSHAPFFlowAdapter.AlreadyNewPPSSHAPFs.Count > 0
    End Sub

    Private Sub btnEndAndSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEndAndSave.Click
        Dim SelectNode As CoilScanedTreeNode = Me.TreeView1.SelectedNode
        If IsNothing(SelectNode) Then
            Exit Sub
        End If
        If Not SelectNode.MyPPSSHAPFFlowAdapter.CheckAlreadyNewPPSSHAPFs() Then
            tsslMessage.Text = SelectNode.MyPPSSHAPFFlowAdapter.Message
            Exit Sub
        End If
        Dim SaveCount As Integer = 0
        For Each EachItem As CompanyORMDB.SQLServer.PPS100LB.PPSSHAPF In SelectNode.MyPPSSHAPFFlowAdapter.AlreadyNewPPSSHAPFs
            SaveCount += EachItem.CDBSave
        Next
        If SaveCount > 0 Then
            Call TreeView1_AfterSelect(Nothing, Nothing)
        End If
        tsslMessage.Text = "已成功儲存 " & SaveCount & " 筆資料!"
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If Not IsNothing(DataGridView2.CurrentCell.Value) AndAlso TypeOf DataGridView2.CurrentCell.Value Is String AndAlso DataGridView2.CurrentCell.Value = "編輯" Then
            Me.CurrentEditNewPPSSHAPF = DataGridView2.CurrentRow.DataBoundItem
            If TabControl1.TabPages.Contains(NewDataEditTabpage) = False Then
                TabControl1.TabPages.Add(NewDataEditTabpage)
                TabControl1.SelectedTab = NewDataEditTabpage
            End If
            CType(NewDataEditTabpage.Controls(0), NewDataEdit).RefreshEditData(Me.CurrentEditNewPPSSHAPF)
        End If
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If TabControl1.TabPages.Contains(NewDataEditTabpage) AndAlso Not e.TabPage Is NewDataEditTabpage Then
            e.Cancel = True
            MsgBox("新作業資料編輯中,請使用""完成按鈕""表示完成該項操作作業!", MsgBoxStyle.OkOnly)
        End If

        If e.TabPage Is tpCoilMoveStationEdit Then
            Me.CurrentCoilMoveStationEditControl.RefreshPMDisplayInformation()
        End If
        Me.CurrentCoilMoveStationEditControl.MoniterMode = (e.TabPage Is tpCoilMoveStationEdit)

        If e.TabPage Is TabPage2 Then
            RefreshFinishProcessWaitEditCoilsNodes()
        End If

        If e.TabPage Is tpCoilBeforeRunningProcess AndAlso Not IsNothing(Me.CoilBeforeRunningProcessControl) Then
            Me.CoilBeforeRunningProcessControl.ReloadTreeViewNodes()
        End If

        If Not IsNothing(Me.CurrentQCControl) AndAlso e.TabPage Is tpSelfQC AndAlso Not IsNothing(Me.CurrentRunningCoilScanAndMachineProcessControl) AndAlso Not IsNothing(Me.CurrentRunningCoilScanAndMachineProcessControl.CurrentEditCoilRunningItem) Then
            'Static PreSetTreeNode As CoilScanedTreeNode = Nothing
            'If Not IsNothing(_CurrentQCControl) AndAlso _
            '    (IsNothing(_CurrentQCControl.EditCoilTreeNode) OrElse Not _CurrentQCControl.EditCoilTreeNode Is PreSetTreeNode) Then
            '    _CurrentQCControl.EditCoilTreeNode = Me.CurrentRunningCoilScanAndMachineProcessControl.CurrentEditCoilRunningItem.CurrentRunningCoilScanedTreeNode
            '    PreSetTreeNode = _CurrentQCControl.EditCoilTreeNode
            'End If
            CurrentQCControl.AboutCoilScanAndMachineProcess = CurrentQCControl.AboutCoilScanAndMachineProcess
        End If

        Static PreSelectTagPage As TabPage = Nothing
        If Not IsNothing(PreSelectTagPage) AndAlso (PreSelectTagPage Is tpCoilAfterRunningProcessControl) AndAlso (Not e.TabPage Is tpCoilAfterRunningProcessControl) Then
            CoilAfterRunningProcessControl.RefreshBreakNumberAndCoilEndSave()
        End If
        PreSelectTagPage = e.TabPage

    End Sub

    Private Sub btnDeleteLastSaveDatas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteLastSaveDatas.Click
        Dim DeleteDatas As List(Of CompanyORMDB.SQLServer.PPS100LB.PPSSHAPF) = GetTheStationLastSaveDatas()
        Dim DeleteStoveNumbers As String = Nothing
        For Each EachItem In DeleteDatas
            DeleteStoveNumbers &= IIf(IsNothing(DeleteStoveNumbers), Nothing, vbNewLine) & "鋼捲號碼:" & EachItem.SHA01.Trim & " 分捲號碼:" & EachItem.SHA02.Trim & " 順序=" & EachItem.SHA04
        Next

        If MsgBox("是否確定刪除以下資料?" & vbNewLine & DeleteStoveNumbers, MsgBoxStyle.YesNo, "注意 是否確定刪除!") = MsgBoxResult.Yes Then
            Dim DeletedCount As Integer = 0
            For Each EachItem In DeleteDatas
                DeletedCount += EachItem.CDBDelete
            Next
            tsslMessage.Text = IIf(DeletedCount > 0, "成功刪除" & DeletedCount & "筆資料!", "刪除資料失敗!")
            Call TreeView1_AfterSelect(Nothing, Nothing)
        End If
    End Sub

    Private Sub CoilScanAndMachineProcessEvent_CoilEnd(ByVal FinishItem As CoilScanedTreeNode, ByVal SenderControl As CoilScanAndMachineProcess) Handles CoilScanAndMachineProcessEvent.CoilEnd
        Me.RefreshFinishProcessWaitEditCoilsNodes()
    End Sub

    Private Sub CoilScanAndMachineProcessEvent_SaveStationDataLastChangeTimeEvent(LastStationDataLastChangeTime As CompanyORMDB.SQLServer.PPS100LB.StationDataLastChangeTime, NewStationDataLastChangeTime As CompanyORMDB.SQLServer.PPS100LB.StationDataLastChangeTime, ByVal SenderControl As CoilScanAndMachineProcess) Handles CoilScanAndMachineProcessEvent.SaveStationDataLastChangeTimeEvent
        If IsNothing(LastStationDataLastChangeTime) OrElse IsNothing(NewStationDataLastChangeTime) Then
            Exit Sub
        End If

        Select Case True
            Case LastStationDataLastChangeTime.OperationPCRunningStateSaveTime <> NewStationDataLastChangeTime.OperationPCRunningStateSaveTime
                If TabControl1.SelectedTab Is TabPage2 Then
                    Me.RefreshFinishProcessWaitEditCoilsNodes()
                End If

                If TabControl1.SelectedTab Is tpCoilMoveStationEdit Then
                    Me.CurrentCoilMoveStationEditControl.RefreshPMDisplayInformation()
                End If

            Case LastStationDataLastChangeTime.OperationPCRunningStateDetailSaveTime <> NewStationDataLastChangeTime.OperationPCRunningStateDetailSaveTime
        End Select

    End Sub

    Private Sub btnPrintLabel_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintLabel.Click
        If Not IsNothing(Me.bsCurrentCoilDatas.Current) Then
            Dim CurrentRecord As CompanyORMDB.IPPS100LB.IPPSSHAPF = Me.bsCurrentCoilDatas.Current
            LabelPrint.UnUIQuickPrint(CType(Me.bsCurrentRunProcessData.Current, RunProcessData), CurrentRecord.SHA08)
        End If
    End Sub

    'Protected Overrides Sub Finalize()
    '    'If TabControl1.SelectedTab Is tpCoilAfterRunningProcessControl Then
    '    '    CoilAfterRunningProcessControl.DataEndEditAndSave() '離開前儲存編輯中的資料
    '    'End If
    '    MyBase.Finalize()
    'End Sub

End Class
