Public Class CoilBeforeRunningProcess

#Region "相關CoilScanAndMachineProcess 屬性:AboutCoilScanAndMachineProcess"

    Private _AboutCoilScanAndMachineProcess As CoilScanAndMachineProcess
    ''' <summary>
    ''' 相關CoilScanAndMachineProcess
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutCoilScanAndMachineProcess() As CoilScanAndMachineProcess
        Get
            Return _AboutCoilScanAndMachineProcess
        End Get
        Private Set(ByVal value As CoilScanAndMachineProcess)
            _AboutCoilScanAndMachineProcess = value
        End Set
    End Property

#End Region

#Region "重新載節點入鋼捲資訊 函式:ReloadTreeViewNodes"
    ''' <summary>
    ''' 重新載節點入鋼捲資訊
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ReloadTreeViewNodes()
        Dim GetData As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState = AboutCoilScanAndMachineProcess.CurrentOperationPCRunningState
        If IsNothing(GetData) Then
            Return False
        End If
        Me.TreeView1.Nodes(0).Nodes.Clear()
        Me.TreeView1.Nodes(1).Nodes.Clear()
        If Not IsNothing(GetData.Line1WaitProcessCoils) AndAlso GetData.Line1WaitProcessCoils.Trim.Length > 0 Then
            For Each EacchItem As String In GetData.Line1WaitProcessCoils.Split(";")
                Me.TreeView1.Nodes(0).Nodes.Add(New CoilScanedTreeNode(EacchItem, 1))
            Next
        End If
        If Not IsNothing(GetData.Line2WaitProcessCoils) AndAlso GetData.Line2WaitProcessCoils.Trim.Length > 0 Then
            For Each EacchItem As String In GetData.Line2WaitProcessCoils.Split(";")
                Me.TreeView1.Nodes(1).Nodes.Add(New CoilScanedTreeNode(EacchItem, 2))
            Next
        End If
        Me.TreeView1.ExpandAll()
        Return True
    End Function
#End Region

#Region "載入截點鋼捲預覽控制項 函式:LoadTreeNodePreViewControls"
    ''' <summary>
    ''' 載入截點鋼捲預覽控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadTreeNodePreViewControls(ByVal SourceTreenode As CoilScanedTreeNode)
        TabPage1.Controls.Clear()
        If IsNothing(SourceTreenode) OrElse Not TypeOf TreeView1.SelectedNode Is CoilScanedTreeNode Then
            Exit Sub
        End If
        ShowCoilRunningItemDataControl(SourceTreenode)
        DisableAllSubControl(Me.TabPage1)
    End Sub
#End Region
#Region "加入作業中鋼捲編輯資料 函式:AddCoilRunningItemEditData"
    ''' <summary>
    ''' 加入作業中鋼捲編輯資料
    ''' </summary>
    ''' <param name="SourceTreenode"></param>
    ''' <remarks></remarks>
    Private Function ShowCoilRunningItemDataControl(ByVal SourceTreenode As CoilScanedTreeNode) As Boolean

        Dim CoilFullNumberForLastPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = SourceTreenode.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF
        If IsNothing(CoilFullNumberForLastPPSSHAPF) Then
            'tsslMessage.Text = "此鋼捲編號沒有可供參考的排程檔PPSSHAPF,固已無法預覽!"
            MsgBox("此鋼捲編號沒有可供參考的排程檔PPSSHAPF,固無法預覽!")
            Return False
        End If

        Dim ShowRunProcessData As RunProcessData = New CompanyORMDB.SQLServer.PPS100LB.RunProcessData(CoilFullNumberForLastPPSSHAPF)
        Dim ShowStationControl As IStationRunningControl
        If Not IsNothing(AboutCoilScanAndMachineProcess.CurrentUseingStationRadioButton) Then
            With ShowRunProcessData
                .AboutStation = AboutCoilScanAndMachineProcess.CurrentUseingStationRadioButton.UseStation
                .RunStationPCIP = AboutCoilScanAndMachineProcess.CurrentOperationPCRunningState.RunningPCIP
                .FK_OutSHA01 = .FK_LastRefSHA01
                .SysCoilStartTime = SourceTreenode.MyPPSSHAPFFlowAdapter.WebServerNowTime
                .SysCoilEndTime = .SysCoilStartTime
                .Guage = CoilFullNumberForLastPPSSHAPF.SHA14
                .Width = CoilFullNumberForLastPPSSHAPF.SHA15
                .Length = CoilFullNumberForLastPPSSHAPF.SHA16
                .Weight = CoilFullNumberForLastPPSSHAPF.SHA17
                '.DataCreateTime = SourceControl.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.WebServerNowTime
                .ThisRecordState = 1 '改變鋼捲編輯資料為CoilStart狀態

                '設定過磅資料(襯紙/套筒/奇力龍)預設值  / ZML給定 第一中間/第二中間/背棍/外徑 預設值
                .SetInitialWorkData(AboutCoilScanAndMachineProcess.CurrentOperationPCRunningState)
            End With
        End If
        ShowStationControl = AboutCoilScanAndMachineProcess.CurrentUseingStationRadioButton.CreateStationRunningControl(ShowRunProcessData, SourceTreenode)
        TabPage1.Controls.Add(ShowStationControl)
        CType(ShowStationControl, Control).Dock = DockStyle.Fill
        Return True
    End Function
#End Region
#Region "將控制項下之所有輸入控制項改為Disable 函式:DisableAllSubControl"
    ''' <summary>
    ''' 將控制項下之所有輸入控制項改為Disable
    ''' </summary>
    ''' <param name="SourceControl"></param>
    ''' <remarks></remarks>
    Private Sub DisableAllSubControl(ByVal SourceControl As Control)
        For Each EachItem As Control In SourceControl.Controls
            For Each EachSubControl As Control In EachItem.Controls
                DisableAllSubControl(EachSubControl)
            Next
            If Not TypeOf EachItem Is Label AndAlso _
                Not TypeOf EachItem Is TableLayoutPanel AndAlso _
                Not TypeOf EachItem Is IContainerControl Then
                EachItem.Enabled = False
            End If
            If TypeOf EachItem Is TableLayoutPanel Then
                EachItem.Enabled = False
            End If
        Next

    End Sub
#End Region


    Sub New(ByVal SetCoilScanAndMachineProcess As CoilScanAndMachineProcess)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.AboutCoilScanAndMachineProcess = SetCoilScanAndMachineProcess
    End Sub

    Private Sub TreeView1_AfterCollapse(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCollapse
        TreeView1.ExpandAll()
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If Not IsNothing(TreeView1.SelectedNode) AndAlso TypeOf TreeView1.SelectedNode Is CoilScanedTreeNode Then
            LoadTreeNodePreViewControls(TreeView1.SelectedNode)
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
