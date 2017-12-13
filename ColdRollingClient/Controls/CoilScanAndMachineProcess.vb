
Imports System.Threading
Public Class CoilScanAndMachineProcess
    '鋼捲方向最左邊為Tail最右邊為Head

    Public Event CurrentCoilRunningItemEditEvent(ByVal Sender As CoilRunningItem)   '目前編輯中鋼捲編輯事件觸發

#Region "是否為線上正式機器 屬性:IsOnLineMachine"
    ''' <summary>
    ''' 是否為線上正式機器
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsOnLineMachine As Boolean
        Get
            Dim TheDeviceIIP As String = CompanyORMDB.DeviceInformation.GetLocalIPs(0)
            If String.IsNullOrEmpty(TheDeviceIIP) Then
                Return False
            End If
            Dim DeviceIPArray() As String = TheDeviceIIP.Split(".")
            If DeviceIPArray(0).Trim = "10" AndAlso DeviceIPArray(1).Trim = "12" Then
                Return True
            End If
            Return False
        End Get
    End Property
#End Region


#Region "運行中鋼捲連結控制項尾端 屬性:TailProcessCoilLinkControl"
    ''' <summary>
    ''' 運行中鋼捲連結控制項尾端
    ''' </summary>
    ''' <remarks></remarks>
    Private _TailProcessCoilLinkControl As CoilRunningItem
    ''' <summary>
    ''' 運行中鋼捲連結控制項尾端
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TailProcessCoilLinkControl() As CoilRunningItem
        Get
            Return _TailProcessCoilLinkControl
        End Get
        Set(ByVal value As CoilRunningItem)
            _TailProcessCoilLinkControl = value
            TailProcessCoilLinkControlEvent = _TailProcessCoilLinkControl
            Select Case True
                Case IsNothing(_TailProcessCoilLinkControl)
                    Me.CurrentEditCoilRunningItem = Nothing
                Case IsNothing(_TailProcessCoilLinkControl.PreRunningCoilRunningItem) AndAlso IsNothing(_TailProcessCoilLinkControl.NextRunningCoilRunningItem) AndAlso Not Me.CurrentEditCoilRunningItem Is _TailProcessCoilLinkControl
                    Me.CurrentEditCoilRunningItem = _TailProcessCoilLinkControl
            End Select
        End Set
    End Property
#End Region
#Region "重整顯示運行中鋼捲控制項 方法:RefreshDisplayProcessCoilLinkControls"
    ''' <summary>
    ''' 重整顯示運行中鋼捲控制項
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshDisplayProcessCoilLinkControls()
        Dim PCRunningState As OperationPCRunningState = Me.CurrentOperationPCRunningState
        Static ProcessCoilLinkControls As New Dictionary(Of Integer, Panel)
        If PCRunningState.MaxCoilNumberInRunningProcessSet <> ProcessCoilLinkControls.Count Then
            tlpCoilRunControls.Controls.Clear()
            ProcessCoilLinkControls.Clear()
            Dim IsHeadControl As Boolean = False
            Dim ContainerCount As Integer = tlpCoilRunControls.ColumnCount
            For AddPanelCount As Integer = 1 To PCRunningState.MaxCoilNumberInRunningProcessSet
                Dim AddPanel As New Panel
                With AddPanel
                    .Margin = New Padding(0)
                    .Padding = .Margin
                    .Dock = DockStyle.Fill
                    .BackColor = Color.Gray
                End With
                tlpCoilRunControls.Controls.Add(AddPanel)
                ProcessCoilLinkControls.Add(AddPanelCount, AddPanel)
                IsHeadControl = (AddPanelCount = PCRunningState.MaxCoilNumberInRunningProcessSet)
                If IsHeadControl Then
                    tlpCoilRunControls.SetColumnSpan(AddPanel, ContainerCount - AddPanelCount + 1)
                Else
                    tlpCoilRunControls.SetColumnSpan(AddPanel, 1)
                End If
                If AddPanelCount > ContainerCount Then
                    Exit For
                End If
            Next
        End If

        Dim WillSetCoilLinkControls As List(Of CoilRunningItem) = CoilRunningItem.GetTailToHeadCoilRunningItems(TailProcessCoilLinkControl)
        WillSetCoilLinkControls.Reverse()   '反轉元素為由右至左
        Dim SetColumnPosition As Integer = ProcessCoilLinkControls.Count
        For Each ShowEachItem As CoilRunningItem In WillSetCoilLinkControls
            Dim GetPanel As Panel = ProcessCoilLinkControls(SetColumnPosition)
            If GetPanel.Controls.Count = 0 OrElse Not (GetPanel.Controls(0) Is ShowEachItem) Then
                GetPanel.Controls.Clear()
                ShowEachItem.Dock = DockStyle.Fill
                GetPanel.Controls.Add(ShowEachItem)
            End If
            SetColumnPosition -= 1
            If SetColumnPosition < 1 Then
                Exit For
            End If
        Next
        If SetColumnPosition > 0 Then
            For EachPanelCount As Integer = 1 To SetColumnPosition
                Dim GetPanel As Panel = ProcessCoilLinkControls(SetColumnPosition)
                GetPanel.Controls.Clear()
            Next
        End If
    End Sub

    '舊版本寫法(缺點為有時會產生BUG訊息)
    'Public Sub RefreshDisplayProcessCoilLinkControls()
    '    tlpCoilRunControls.Controls.Clear()

    '    Dim ContainerCount As Integer = tlpCoilRunControls.ColumnCount ' Me.nudMaxCoilRunningNumber.Value
    '    Dim WillSetCoilLinkControls As List(Of CoilRunningItem) = CoilRunningItem.GetTailToHeadCoilRunningItems(TailProcessCoilLinkControl)
    '    Dim IsHeadControl As Boolean = False
    '    Dim SetColumnPosition As Integer = 1
    '    For Each EachItem As CoilRunningItem In WillSetCoilLinkControls
    '        tlpCoilRunControls.Controls.Add(EachItem)
    '        EachItem.Dock = DockStyle.Fill
    '        tlpCoilRunControls.SetColumn(EachItem, SetColumnPosition)
    '        IsHeadControl = EachItem Is WillSetCoilLinkControls(WillSetCoilLinkControls.Count - 1)
    '        If IsHeadControl Then
    '            tlpCoilRunControls.SetColumnSpan(EachItem, ContainerCount - SetColumnPosition + 1)
    '        Else
    '            tlpCoilRunControls.SetColumnSpan(EachItem, 1)
    '        End If
    '        SetColumnPosition += 1
    '        If SetColumnPosition > ContainerCount Then
    '            Exit Sub
    '        End If
    '    Next

    'End Sub
#End Region

#Region "由資料庫中載入本控制項狀態 方法:LoadDBOperationPCRunningStateToControlValue"
    ''' <summary>
    ''' 由資料庫中載入本控制項狀態
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function LoadDBOperationPCRunningStateToControlValue() As Boolean
        Dim GetData As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState = CurrentOperationPCRunningState
        If IsNothing(GetData) Then
            Return False
        End If



        RefreshDisplayStationAndDefaultSet()    '重整顯示站台屬性預設設定
        For Each EachItem As StationRadioButton In Me.flpDefaultStationSet.Controls
            If EachItem.UseStation.StationName.Trim = GetData.DefaultUseStationName.Trim Then
                EachItem.Checked = True
                Exit For
            End If
        Next




        Dim GetTheMachinePCRunningState = TheMachinePCRunningState
        rbMode1.Checked = GetTheMachinePCRunningState.ClientRunningMode
        tbRemoteToServerIP.Text = GetTheMachinePCRunningState.ClientRemoteToServerIP.Trim
        lbDisplayRole.Text = IIf(GetTheMachinePCRunningState.ClientRunningMode = 1, "伺服端(注意:非本機):" & GetTheMachinePCRunningState.ClientRemoteToServerIP, "本機:" & GetTheMachinePCRunningState.RunningPCIP)
        nudMaxCoilRunningNumber.Value = GetData.MaxCoilNumberInRunningProcessSet
        NumericUpDown1.Value = GetData.Line1COMPortNumber
        cbLine2Switch.Checked = IIf(GetData.Line2IsEnable, True, False)
        Me.rbLine2CoilInpupt.Visible = cbLine2Switch.Checked
        TreeView1.Nodes(1).Text = IIf(GetData.Line2IsEnable, "下線", "")

        rbLine1CoilInpupt.Checked = IIf(Not rbLine2CoilInpupt.Enabled, True, rbLine1CoilInpupt.Checked)
        cbAutoCoilStart.Checked = GetData.IsAutoCoilStartWhenCoilEnd
        cbIsStopL2MessageTalk.Checked = GetData.IsStopL2MsgTalk
        cbIsStopPDIMessageTalk.Checked = GetData.IsStopPDIMsgTalk
        cbIsStopPDOMessageTalk.Checked = GetData.IsStopPDOMsgTalk
        Me.TreeView1.Nodes(0).Nodes.Clear()
        Me.TreeView1.Nodes(1).Nodes.Clear()
        If Not IsNothing(GetData.Line1WaitProcessCoils) AndAlso GetData.Line1WaitProcessCoils.Trim.Length > 0 Then
            For Each EacchItem As String In GetData.Line1WaitProcessCoils.Split(";")
                Me.TreeView1.Nodes(0).Nodes.Add(New CoilScanedTreeNode(EacchItem, 1))
                Application.DoEvents()
            Next
        End If
        If Not IsNothing(GetData.Line2WaitProcessCoils) AndAlso GetData.Line2WaitProcessCoils.Trim.Length > 0 Then
            For Each EacchItem As String In GetData.Line2WaitProcessCoils.Split(";")
                Me.TreeView1.Nodes(1).Nodes.Add(New CoilScanedTreeNode(EacchItem, 2))
                Application.DoEvents()
            Next
        End If



        Me.TailProcessCoilLinkControl = Nothing
        If GetData.RunningProcessCoils.Trim.Length > 0 Then
            For Each EachItem As String In GetData.RunningProcessCoils.Split(";")
                Dim AddCoilScanedTreeNode As CoilScanedTreeNode = New CoilScanedTreeNode(EachItem.Trim)
                If IsNothing(Me.TailProcessCoilLinkControl) Then
                    Me.TailProcessCoilLinkControl = New CoilRunningItem(AddCoilScanedTreeNode)
                    AddCoilScanedTreeNode.IsWillShowCoilRunningOrder = Me.CurrentOperationPCRunningState.Line2IsEnable
                Else
                    Me.TailProcessCoilLinkControl.AddCoilRunningItemToItemTopHead(New CoilRunningItem(AddCoilScanedTreeNode))
                    AddCoilScanedTreeNode.IsWillShowCoilRunningOrder = Me.CurrentOperationPCRunningState.Line2IsEnable
                End If
                Application.DoEvents()
            Next
        End If


        'Me.FinishProcessWaitEditCoilsNodes.Clear()
        'For Each EachItem As String In GetData.AboutTop50FinishProcessWaitEditCoilNumbers
        '    Me.FinishProcessWaitEditCoilsNodes.Add(New CoilScanedTreeNode(EachItem.Trim, Not String.IsNullOrEmpty(CurrentUesStationName) AndAlso (CurrentUesStationName.Substring(0, 2) = "AP" OrElse CurrentUesStationName.Substring(0, 2) = "CP" OrElse CurrentUesStationName.Substring(0, 3) = "ZML")))
        '    Application.DoEvents()
        'Next



        For Each EachItem As RadioButton In GroupBox2.Controls
            EachItem.Enabled = False
        Next
        For Each EachItem As RadioButton In GroupBox3.Controls
            EachItem.Enabled = False
        Next
        If Not String.IsNullOrEmpty(Me.CurrentUesStationName) And _
            Me.CurrentUesStationName.Length > 2 AndAlso _
            (Me.CurrentUesStationName.Substring(0, 2) = "CP" OrElse _
            Me.CurrentUesStationName.Substring(0, 2) = "AP" OrElse _
            Me.CurrentUesStationName.Substring(0, 2) = "ZM") Then
            Select Case True
                Case Me.CurrentUesStationName.Substring(0, 2) = "CP"
                    RadioButton11.Enabled = True
                    RadioButton12.Enabled = True
                    RadioButton21.Enabled = True
                    RadioButton22.Enabled = True
                Case Me.CurrentUesStationName.Substring(0, 2) = "AP"
                    RadioButton11.Enabled = True
                    RadioButton12.Enabled = True
                    RadioButton13.Enabled = True
                    RadioButton14.Enabled = True
                    RadioButton21.Enabled = True
                    RadioButton22.Enabled = True
                    RadioButton23.Enabled = True
                    RadioButton24.Enabled = True
                Case Me.CurrentUesStationName.Substring(0, 2) = "ZM"
                    RadioButton13.Checked = True
                    RadioButton23.Checked = True
            End Select
            TableLayoutPanel8.Enabled = True
        Else
            TableLayoutPanel8.Enabled = False
        End If


        'APL或BAL或SPL或TLL啟動定時狀態更新(因為有其它Client端會變更狀態)
        Me.TFlashControlState.Enabled = ("APL" = GetData.DefaultUseStationName.Substring(0, 3).ToUpper) OrElse ("BAL" = GetData.DefaultUseStationName.Substring(0, 3).ToUpper) OrElse ("SPL" = GetData.DefaultUseStationName.Substring(0, 3).ToUpper) OrElse ("TLL" = GetData.DefaultUseStationName.Substring(0, 3).ToUpper)
        rbMode1.Checked = (TheMachinePCRunningState.RunningPCIP = CurrentOperationPCRunningState.RunningPCIP) : rbMode2.Checked = Not rbMode1.Checked
        tbRemoteToServerIP.Text = ""
        If rbMode2.Checked Then
            tbRemoteToServerIP.Text = TheMachinePCRunningState.ClientRemoteToServerIP
        End If

        Return True
    End Function
#End Region
#Region "本機狀態資訊 屬性:TheMachinePCRunningState"
    ''' <summary>
    ''' 本機狀態資訊
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TheMachinePCRunningState As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState
        Get
            Return PPSSHAPFFlowAdapter.TheMachinePCRunningState
        End Get
    End Property
#End Region
#Region "目前正在執行的OperationPCRunningState 屬性:CurrentOperationPCRunningState"
    ''' <summary>
    ''' 目前正在執行的OperationPCRunningState
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CurrentOperationPCRunningState As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState
        Get
            Return PPSSHAPFFlowAdapter.CurrentOperationPCRunningState
        End Get
    End Property
#End Region
#Region "儲存本控制項執行狀態至資料庫中 方法:SaveControlValueToOperationPCRunningState"
    ''' <summary>
    ''' 儲存本控制項執行狀態至資料庫中
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SaveControlValueToOperationPCRunningState(Optional ByVal SaveCoilRunningItemEditDatas As Boolean = True) As Boolean
        '特殊設定:SPL入口資料如有任何異動不做回寫動作
        If Me.CurrentUesStationName = "SPL" AndAlso Me.CurrentOperationPCRunningState.IsTheOperationPCRunningStateForThisMachine = False Then
            Return False
        End If

        Dim SourceDataObject As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState = Me.TheMachinePCRunningState
        If IsNothing(SourceDataObject) Then
            SourceDataObject = New CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState
            SourceDataObject.RunningPCIP = CompanyORMDB.DeviceInformation.GetLocalIPs(0).Trim
        Else
            Dim GetCurrentOperationPCRunningState As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState = Me.CurrentOperationPCRunningState
            If SourceDataObject.ClientRunningMode = 1 Then
                If IsNothing(GetCurrentOperationPCRunningState) Then
                    tsslMessage.Text = "本機為用戶端設定,找不到伺服端資料無法儲存OperationPCRunningState!"
                    Return False
                Else
                    SourceDataObject = GetCurrentOperationPCRunningState
                End If
            End If
        End If

        With SourceDataObject
            If .IsTheOperationPCRunningStateForThisMachine Then
                .RunningPCIP = CompanyORMDB.DeviceInformation.GetLocalIPs(0).Trim
                .RunPCName = My.Computer.Name
            End If
            .MaxCoilNumberInRunningProcessSet = nudMaxCoilRunningNumber.Value
            .Line1COMPortNumber = NumericUpDown1.Value
            .Line2IsEnable = cbLine2Switch.Checked
            .IsAutoCoilStartWhenCoilEnd = cbAutoCoilStart.Checked
            .IsStopL2MsgTalk = cbIsStopL2MessageTalk.Checked
            .IsStopPDIMsgTalk = cbIsStopPDIMessageTalk.Checked
            .IsStopPDOMsgTalk = cbIsStopPDOMessageTalk.Checked
            'Dim SetWaitProcessCoilsString As String = Nothing
            Static SetWaitProcessCoilsString As New StringBuilder
            SetWaitProcessCoilsString.Clear()
            For Each EachItem As TreeNode In TreeView1.Nodes(0).Nodes
                If TypeOf EachItem Is CoilScanedTreeNode Then
                    Dim SetNode As CoilScanedTreeNode = EachItem
                    'SetWaitProcessCoilsString &= IIf(String.IsNullOrEmpty(SetWaitProcessCoilsString), Nothing, ";") & SetNode.CoilFullNumber
                    SetWaitProcessCoilsString.Append(IIf(String.IsNullOrEmpty(SetWaitProcessCoilsString.ToString), SetNode.CoilFullNumber, ";" & SetNode.CoilFullNumber))
                End If
            Next
            '.Line1WaitProcessCoils = SetWaitProcessCoilsString
            .Line1WaitProcessCoils = SetWaitProcessCoilsString.ToString

            SetWaitProcessCoilsString.Clear()
            For Each EachItem As TreeNode In TreeView1.Nodes(1).Nodes
                If TypeOf EachItem Is CoilScanedTreeNode Then
                    Dim SetNode As CoilScanedTreeNode = EachItem
                    'SetWaitProcessCoilsString &= IIf(String.IsNullOrEmpty(SetWaitProcessCoilsString), Nothing, ";") & SetNode.CoilFullNumber
                    SetWaitProcessCoilsString.Append(IIf(String.IsNullOrEmpty(SetWaitProcessCoilsString.ToString), SetNode.CoilFullNumber, ";" & SetNode.CoilFullNumber))
                End If
            Next
            '.Line2WaitProcessCoils = SetWaitProcessCoilsString
            .Line2WaitProcessCoils = SetWaitProcessCoilsString.ToString

            Dim SetRunningProcessCoilsString As String = ""
            For Each EachItem As CoilRunningItem In CoilRunningItem.GetTailToHeadCoilRunningItems(Me.TailProcessCoilLinkControl)
                SetRunningProcessCoilsString &= IIf(String.IsNullOrEmpty(SetRunningProcessCoilsString), Nothing, ";")
                SetRunningProcessCoilsString &= EachItem.CurrentRunningCoilScanedTreeNode.CoilFullNumber
            Next
            .RunningProcessCoils = SetRunningProcessCoilsString

            'Dim SetWaitEditCoilsString As String = ""
            'For Each EachItem As CoilScanedTreeNode In Me.FinishProcessWaitEditCoilsNodes
            '    SetWaitEditCoilsString &= IIf(String.IsNullOrEmpty(SetWaitEditCoilsString), Nothing, ";")
            '    SetWaitEditCoilsString &= EachItem.CoilFullNumber
            'Next
            .FinishProcessWaitEditCoils = ""    '此欄位已廢棄不用

            For Each EachItem As StationRadioButton In Me.flpDefaultStationSet.Controls
                If EachItem.Checked Then
                    .DefaultUseStationName = EachItem.UseStation.StationName.Trim : Exit For
                End If
            Next
        End With

        Dim ReturnValue As Boolean = SourceDataObject.CDBSave() > 0

        If ReturnValue AndAlso SaveCoilRunningItemEditDatas Then
            ReturnValue = SaveCoilRunningItemEditDataToDB()
        End If

        If ReturnValue Then
            LastSaveStationDataLastChangeTime = StationDataLastChangeTime.SetNewLastSaveTime(SourceDataObject.RunningPCIP, StationDataLastChangeTime.StationDataLastChangeTimeType.OperationPCRunningStateSaveTime)
        End If


        If Not SourceDataObject.IsStopL2MsgTalk Then
            '將產線目前鋼捲狀態轉成文字檔傳送至Level2
            Dim TestModePath As String = IIf(Not IsOnLineMachine, "_Test", Nothing)
            If ReturnValue AndAlso Not String.IsNullOrEmpty(Me.CurrentUesStationName) AndAlso Me.CurrentUesStationName.Trim.Length >= 3 AndAlso _
                {"SBL", "TLL", "SPL", "CPL1", "CPL2", "GPL1", "GPL2", "APL1", "APL2", "BAL", "ZML1", "ZML2", "ZML3"} _
                .Contains(Me.CurrentUesStationName.PadRight(4).Substring(0, 4).Trim) Then
                Dim WriteString As String = (New SendStateToL2(CurrentOperationPCRunningState.RunningPCIP)).ConvertStateToText
                Dim LineName As String = Me.CurrentUesStationName.PadRight(4).Substring(0, 4).Trim
                My.Computer.FileSystem.WriteAllText("\\10.12.6.30\" & LineName & TestModePath & "\received\" & LineName & ".txt", WriteString, False)
            End If
        End If

        Return ReturnValue
    End Function
#End Region
#Region "最後儲存之StationDataLastChangeTime(狀態資料) 屬性/事件:LastSaveStationDataLastChangeTime/SaveStationDataLastChangeTimeEvent"
    'Public Event SaveStationDataLastChangeTimeEvent(ByVal LastStationDataLastChangeTime As StationDataLastChangeTime, ByVal NewStationDataLastChangeTime As StationDataLastChangeTime, ByVal FinishProcessWaitEditCoilsNodes As List(Of CoilScanedTreeNode))
    Public Event SaveStationDataLastChangeTimeEvent(ByVal LastStationDataLastChangeTime As StationDataLastChangeTime, ByVal NewStationDataLastChangeTime As StationDataLastChangeTime, ByVal SenderControl As CoilScanAndMachineProcess)
    Private _LastSaveStationDataLastChangeTime As CompanyORMDB.SQLServer.PPS100LB.StationDataLastChangeTime
    ''' <summary>
    ''' 最後儲存之StationDataLastChangeTime(狀態資料)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LastSaveStationDataLastChangeTime() As CompanyORMDB.SQLServer.PPS100LB.StationDataLastChangeTime
        Get
            Return _LastSaveStationDataLastChangeTime
        End Get
        Set(ByVal value As CompanyORMDB.SQLServer.PPS100LB.StationDataLastChangeTime)
            _LastSaveStationDataLastChangeTime = value
            TFlashControlStateLastChangeTime = value
        End Set
    End Property

#End Region


#Region "重整控制項啟用按鈕 函式:RefreshEnableButton"
    ''' <summary>
    ''' 重整控制項啟用按鈕
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshEnableButton(Optional WillReSortRunCoilsOrder As Boolean = True)
        Dim IsHaveCoilScanedTreeNodeSelected As Boolean = (Not IsNothing(TreeView1.SelectedNode)) AndAlso (TypeOf TreeView1.SelectedNode Is CoilScanedTreeNode)
        PBCoilStart.Enabled = Not IsNothing(TreeView1.SelectedNode) AndAlso (TypeOf TreeView1.SelectedNode Is CoilScanedTreeNode OrElse Not TypeOf TreeView1.SelectedNode Is CoilScanedTreeNode And TreeView1.SelectedNode.Nodes.Count > 0)
        PBCoilStart.Enabled = PBCoilStart.Enabled And CoilRunningItem.GetTailToHeadCoilRunningItems(TailProcessCoilLinkControl).Count < nudMaxCoilRunningNumber.Value
        PBCoilStart.Image = IIf(PBCoilStart.Enabled, My.Resources.OutputImage, My.Resources.OutputImage0)
        btnCoilMoveOtherLine.Enabled = IsHaveCoilScanedTreeNodeSelected
        btnCoilMoveUp.Enabled = IsHaveCoilScanedTreeNodeSelected AndAlso Not IsNothing(TreeView1.SelectedNode.PrevNode)
        btnCoilMoveDown.Enabled = IsHaveCoilScanedTreeNodeSelected AndAlso Not IsNothing(TreeView1.SelectedNode.NextNode)
        btnClearCoils.Enabled = (Not IsNothing(TreeView1.SelectedNode) And TypeOf TreeView1.SelectedNode Is CoilScanedTreeNode) : btnClearCoils.Text = "移除鋼捲"
        If Not IsNothing(TreeView1.SelectedNode) Then
            btnClearCoils.Text &= ":" & TreeView1.SelectedNode.Text
        End If
        btnManualAddCoil.Enabled = (btInputCoilNumber.Text.Trim.Length >= 5)
        btnManualInsertCoil.Enabled = btnManualAddCoil.Enabled AndAlso Not IsNothing(TreeView1.SelectedNode) AndAlso TypeOf TreeView1.SelectedNode Is CoilScanedTreeNode
        GroupBox3.Enabled = IsHaveCoilScanedTreeNodeSelected AndAlso Not String.IsNullOrEmpty(Me.CurrentUesStationName) AndAlso Me.CurrentUesStationName.Length > 2 AndAlso (Me.CurrentUesStationName.Substring(0, 2) = "CP" OrElse Me.CurrentUesStationName.Substring(0, 2) = "AP")
        If GroupBox3.Enabled Then
            Dim SelectNode As CoilScanedTreeNode = TreeView1.SelectedNode
            Dim NodeCoilNumber As String = SelectNode.MyPPSSHAPFFlowAdapter.CoilFullNumber
            Dim GetOperationPCRunningStateDetail As OperationPCRunningStateDetail = OperationPCRunningStateDetail.FindOperationPCRunningStateDetail(Me.CurrentOperationPCRunningState.RunningPCIP, NodeCoilNumber)
            If Not IsNothing(GetOperationPCRunningStateDetail) Then
                Dim CIW06Value As Integer = GetOperationPCRunningStateDetail.Set_PlanProductionDisplay_CIW06Value
                For Each EachItem As RadioButton In GroupBox3.Controls
                    If TypeOf EachItem Is RadioButton Then
                        EachItem.Checked = (Integer.Parse(EachItem.Text.Substring(0, 1)) = CIW06Value)
                    End If
                Next
            End If
        End If

        'SPL強制入口分捲按鈕不作用
        If Me.CurrentUesStationName.PadRight(3).ToUpper = "SPL" Then
            If Me.CurrentOperationPCRunningState.IsTheOperationPCRunningStateForThisMachine = False Then
                tsbAddBreadkCoil.Enabled = False
            Else
                tsbAddBreadkCoil.Enabled = True
            End If
        End If


        '重新整理顯示L2PDO訊號顯示
        If Not Me.CurrentOperationPCRunningState.IsStopPDOMsgTalk Then
            L2PDOMessageWatchControl.RelodL2FileAndSendPDOMessage()
        End If

        If WillReSortRunCoilsOrder Then
            ReSortRunCoilsOrder()   '重整顯示鋼捲執行順序
        End If
    End Sub
#End Region
#Region "重新啟動RS232 函式:ReStartRS232"
    ''' <summary>
    ''' 重新啟動RS232
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReStartRS232()
        If Me.speLine1RS232.IsOpen Then
            Me.speLine1RS232.DiscardInBuffer()
            Me.speLine1RS232.Close()
        End If
        Me.speLine1RS232.PortName = "COM" & NumericUpDown1.Value
        If NumericUpDown1.Value > 0 Then
            Me.speLine1RS232.OpenAndSetContainerControl(Me)
            Me.speLine1RS232.DiscardOutBuffer()
        End If
    End Sub
#End Region
#Region "重整顯示站台屬性預設設定 函式:RefreshDisplayStationAndDefaultSet"
    ''' <summary>
    ''' 重整顯示站台屬性預設設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshDisplayStationAndDefaultSet()
        Dim LoacalPCIPs As New List(Of String)
        LoacalPCIPs.Add(Me.CurrentOperationPCRunningState.RunningPCIP)
        flpDefaultStationSet.Controls.Clear()
        For Each EachItem In CompanyORMDB.SQLServer.PPS100LB.Station.GetIPsStations(LoacalPCIPs)
            Dim AddItem As New StationRadioButton(EachItem, Me)
            flpDefaultStationSet.Controls.Add(AddItem)
            If flpDefaultStationSet.Controls.Count = 1 Then
                AddItem.Checked = True
            End If
        Next

    End Sub
#End Region

#Region "掃描或手動加入鋼捲 函式:ScanOrManualAddCoil"
    ''' <summary>
    ''' 掃描或手動加入鋼捲
    ''' </summary>
    ''' <param name="TEOrCSCNumber">唐榮鋼捲編號或中鋼熱軋編號</param>
    ''' <remarks></remarks>
    Private Sub ScanOrManualAddCoil(ByVal TEOrCSCNumber As String, ByVal AddToLineNumber As Integer, Optional InsertAfterNode As CoilScanedTreeNode = Nothing)
        'Dim TEFullNumber As String = CSCNumToTangNum(TEOrCSCNumber)

        Select Case True
            Case IsNothing(TEOrCSCNumber)
                'MsgBox("發生錯誤:鋼捲掃描資料為空白Nothing!")
                Exit Sub
            Case TEOrCSCNumber.Replace(vbNewLine, Nothing).Trim.Length < 5
                MsgBox("發生錯誤:鋼捲輸入資料長度不足5位!")
                Exit Sub
            Case TEOrCSCNumber.Replace(vbNewLine, Nothing).Trim.Length > 15
                MsgBox("發生錯誤:鋼捲輸入資料長度過長大於15位!")
                Exit Sub
            Case TEOrCSCNumber.Replace(vbNewLine, Nothing).Trim.Length > 10
                Dim OutsourcingCoilNumber As String = CoilScanedTreeNode.FindOutsourcingCoilNumber(TEOrCSCNumber.Replace(vbNewLine, Nothing).Trim)
                If IsNothing(OutsourcingCoilNumber) Then
                    MsgBox("發生錯誤:鋼捲輸入資料長度過長大於10位並無法找出外購鋼捲!")
                    Exit Sub
                End If
                TEOrCSCNumber = OutsourcingCoilNumber
            Case IsCoilNumberIsExist(TEOrCSCNumber)
                Exit Sub
            Case Else
                TEOrCSCNumber = TEOrCSCNumber.Replace(vbNewLine, Nothing).Trim.ToUpper
        End Select

        'Dim AddNode As New CoilScanedTreeNode(TEFullNumber, AddToLineNumber, IIf(TEOrCSCNumber <> TEFullNumber, TEOrCSCNumber, Nothing))
        Dim AddNode As New CoilScanedTreeNode(TEOrCSCNumber, AddToLineNumber)
        Select Case True
            Case AddToLineNumber = 1 ' rbLine1CoilInpupt.Checked
                If Not IsNothing(InsertAfterNode) AndAlso TypeOf InsertAfterNode Is CoilScanedTreeNode Then
                    Me.TreeView1.Nodes(0).Nodes.Insert(Me.TreeView1.Nodes(0).Nodes.IndexOf(InsertAfterNode), AddNode)
                Else
                    Me.TreeView1.Nodes(0).Nodes.Add(AddNode)
                End If
            Case AddToLineNumber = 2 'rbLine2CoilInpupt.Checked
                If Not IsNothing(InsertAfterNode) AndAlso TypeOf InsertAfterNode Is CoilScanedTreeNode Then
                    Me.TreeView1.Nodes(1).Nodes.Insert(Me.TreeView1.Nodes(1).Nodes.IndexOf(InsertAfterNode), AddNode)
                Else
                    Me.TreeView1.Nodes(1).Nodes.Add(AddNode)
                End If
        End Select
        Me.SaveControlValueToOperationPCRunningState()

        '將鋼捲號碼本站之生技扣帳狀態寫入暫存資料庫
        Dim myPCRunningState As CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState = CurrentOperationPCRunningState
        If Not IsNothing(myPCRunningState) Then
            Dim SetProductionValue As Integer = -1
            For Each EachItem As RadioButton In GroupBox2.Controls
                If EachItem.Checked Then
                    SetProductionValue = Val(EachItem.Text.Substring(0, 1))
                    CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningStateDetail.AddOrUpdateOperationPCRunningStateDetailToDB(myPCRunningState, AddNode.MyPPSSHAPFFlowAdapter.CoilFullNumber, SetProductionValue)
                    Exit Sub
                End If
            Next
        End If

        If AddNode.VerifyCoil() = False Then
            MsgBox(AddNode.Message)
        End If

    End Sub

    Private Function IsCoilNumberIsExist(ByVal TEOrCSCNumber As String) As Boolean
        For Each EachNode In TreeView1.Nodes(0).Nodes
            If TypeOf EachNode Is CoilScanedTreeNode Then
                Dim GetNode As CoilScanedTreeNode = EachNode
                If GetNode.CoilFullNumber.Trim = TEOrCSCNumber.Trim.ToUpper Then
                    Return True
                End If
            End If
        Next
        For Each EachNode In TreeView1.Nodes(1).Nodes
            If TypeOf EachNode Is CoilScanedTreeNode Then
                Dim GetNode As CoilScanedTreeNode = EachNode
                If GetNode.CoilFullNumber.Trim = TEOrCSCNumber.Trim.ToUpper Then
                    Return True
                End If

            End If
        Next
        For Each EachItem As RunProcessData In Me.CurrentEditRunProcessDatas
            If Trim(EachItem.FK_OutSHA01 & EachItem.FK_LastRefSHA02).Trim.ToUpper = TEOrCSCNumber.Trim.ToUpper Then
                Return True
            End If
        Next
        Return False
    End Function

    '#Region "轉換中鋼熱軋號碼至唐榮鋼捲號碼 方法:CSCNumToTangNum"
    '    ''' <summary>
    '    ''' 轉換中鋼熱軋號碼至唐榮鋼捲號碼
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Private Function CSCNumToTangNum(ByVal SourceNumber As String) As String
    '        '如果為中鋼鋼捲號碼(大於7位)
    '        If SourceNumber.Trim.Length < 7 Then
    '            Return SourceNumber
    '        End If
    '        For Each EachControl As StationRadioButton In flpDefaultStationSet.Controls
    '            Dim StationName As String = EachControl.UseStation.StationName.Trim.ToUpper
    '            '並且為APL與CPL則進行鋼捲號碼轉換
    '            If (StationName.Substring(0, 2) = "AP" OrElse StationName.Substring(0, 2) = "CP") Then
    '                Dim QryString As String = "Select BLA09 FROM @#PPS100LB.PPSBLAPF WHERE BLA01='" & SourceNumber & "' FETCH FIRST 1 ROWS ONLY"
    '                Dim DBAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
    '                Dim SearchResult As DataTable = DBAdapter.SelectQuery
    '                If SearchResult.Rows.Count > 0 Then
    '                    Return CType(SearchResult.Rows(0).Item(0), String)
    '                End If
    '            End If
    '        Next
    '        Return SourceNumber
    '    End Function
    '#End Region
#End Region
#Region "目前使用站台名稱 屬性:CurrentUesStationName"
    ''' <summary>
    ''' 目前使用站台名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CurrentUesStationName As String
        Get
            For Each EachControl As StationRadioButton In flpDefaultStationSet.Controls
                If EachControl.Checked Then
                    Return EachControl.UseStation.StationName.Trim.ToUpper
                End If
            Next
            Return String.Empty
        End Get
    End Property
#End Region


#Region "鋼捲處理完成事件 事件:CoilEnd"
    ''' <summary>
    ''' 鋼捲處理完成事件
    ''' </summary>
    ''' <remarks></remarks>
    Public Event CoilEnd(ByVal FinishItem As CoilScanedTreeNode, ByVal SenderControl As CoilScanAndMachineProcess)
#End Region


#Region "現在正在使用的站台RadioButton 屬性:CurrentUseingStationRadioButton"
    ''' <summary>
    ''' 現在正在使用的站台
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CurrentUseingStationRadioButton As StationRadioButton
        Get
            For Each EachItem As StationRadioButton In Me.flpDefaultStationSet.Controls
                If EachItem.Checked Then
                    Return EachItem
                End If
            Next
            Return Nothing
        End Get
    End Property
#End Region


#Region "由資庫中載入作業中鋼捲編輯資料 函式:LoadCoilRunningItemEditDataFromDB"
    ''' <summary>
    ''' 由資庫中載入作業中鋼捲編輯資料
    ''' </summary>
    ''' <param name="SourceControl"></param>
    ''' <remarks></remarks>
    Private Function LoadCoilRunningItemEditDataFromDB(ByVal SourceControl As CoilRunningItem) As Boolean
        CurrentEditRunProcessDatas.Clear()
        For Each EachItem As TabPage In tabDetailEdit.TabPages
            Dim ContentControl As Control = EachItem.Controls(0)
            ContentControl.Dispose()
            tabDetailEdit.TabPages.Remove(EachItem)
        Next
        'tabDetailEdit.TabPages.Clear()

        If IsNothing(SourceControl) Then
            Return False
        End If

        Dim GetPPSSHAPFFlowAdapter As PPSSHAPFFlowAdapter = Nothing
        Try
            GetPPSSHAPFFlowAdapter = SourceControl.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter
        Catch ex As Exception
        Finally
            If IsNothing(GetPPSSHAPFFlowAdapter) Then
                GetPPSSHAPFFlowAdapter = SourceControl.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter
            End If
        End Try

        If IsNothing(GetPPSSHAPFFlowAdapter) Then
            tsslMessage.Text = "此鋼捲編號沒有可供參考的排程檔PPSSHAPF,固已無法編輯!"
            Return False
        End If

        Dim GetRunProcessDatas As List(Of RunProcessData) = (From A In GetPPSSHAPFFlowAdapter.AboutRunProcessDatas Where A.ThisRecordState = 1 And A.RunStationPCIP = Me.CurrentOperationPCRunningState.RunningPCIP And A.FK_RunStationName.Trim = Me.CurrentOperationPCRunningState.DefaultUseStationName.Trim Select A).ToList
        'If IsNothing(GetRunProcessDatas) OrElse GetRunProcessDatas.Count = 0 Then
        '    tsslMessage.Text = "此鋼捲編號沒有可供參考的排程檔PPSSHAPF,固已無法編輯!"
        '    Return False
        'End If


        Dim AddEditStationControl As Control = Nothing
        Dim CoilBreakNumber As Integer = 1
        Dim IsSuccessAddControl As Boolean = False
        For Each EachBreakItemData In GetRunProcessDatas
            Try
                If Not IsNothing(Me.CurrentUseingStationRadioButton) Then
                    SetL2MsgToRunProcessData(EachBreakItemData) '設定L2資料傳送過來的資
                    AddEditStationControl = Me.CurrentUseingStationRadioButton.CreateStationRunningControl(EachBreakItemData, SourceControl.CurrentRunningCoilScanedTreeNode)
                End If

                If Not IsNothing(AddEditStationControl) Then
                    Dim AddTabPage As New TabPage()
                    AddTabPage.ImageIndex = 1
                    AddTabPage.Text = EachBreakItemData.FK_OutSHA01 & EachBreakItemData.FK_OutSHA02.Trim
                    AddTabPage.Controls.Add(AddEditStationControl)
                    CurrentEditRunProcessDatas.Add(EachBreakItemData)
                    tabDetailEdit.TabPages.Add(AddTabPage)
                    IsSuccessAddControl = True
                    AddEditStationControl.Dock = DockStyle.Fill
                    CoilBreakNumber += 1
                End If
            Catch ex As Exception
                tsslMessage.Text = ex.ToString
            End Try
            Application.DoEvents()
        Next
        tsbDelBreadkCoil.Enabled = Me.tabDetailEdit.TabPages.Count > 1
        Return IsSuccessAddControl
    End Function

#End Region
#Region "儲存作業中鋼捲編輯資料 方法:SaveCoilRunningItemEditDataToDB"
    ''' <summary>
    ''' 儲存作業中鋼捲編輯資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveCoilRunningItemEditDataToDB() As Boolean
        Dim ReturnValue As Boolean = True
        For Each EachTabPage As TabPage In tabDetailEdit.TabPages
            If EachTabPage.Controls.Count = 0 Then
                Continue For
            End If
            Dim StationRunningControl As IStationRunningControl = EachTabPage.Controls(0)
            ReturnValue = ReturnValue And StationRunningControl.DataEndEditAndSave()
        Next
        Return ReturnValue
    End Function
#End Region
#Region "加入作業中鋼捲編輯資料 函式:AddCoilRunningItemEditData"
    ''' <summary>
    ''' 加入作業中鋼捲編輯資料
    ''' </summary>
    ''' <param name="SourceControl"></param>
    ''' <remarks></remarks>
    Private Function AddCoilRunningItemEditData(ByVal SourceControl As CoilRunningItem) As Boolean

        Dim CoilFullNumberForLastPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = SourceControl.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF
        If IsNothing(CoilFullNumberForLastPPSSHAPF) Then
            tsslMessage.Text = "此鋼捲編號沒有可供參考的排程檔PPSSHAPF,固已無法編輯!"
            Return False
        End If

        Dim AddEditStationControl As Control = Nothing
        If Not IsNothing(Me.CurrentUseingStationRadioButton) Then
            'Dim RefPPSSHAPFs As List(Of CompanyORMDB.IPPS100LB.IPPSSHAPF) = SourceControl.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF
            Dim AddRunProcessData As RunProcessData = New CompanyORMDB.SQLServer.PPS100LB.RunProcessData(CoilFullNumberForLastPPSSHAPF)
            Dim GetRunProcessDatas As List(Of RunProcessData) = (From A In SourceControl.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.AboutRunProcessDatas Where A.ThisRecordState = 1 And A.RunStationPCIP = Me.CurrentOperationPCRunningState.RunningPCIP And A.FK_RunStationName.Trim = Me.CurrentOperationPCRunningState.DefaultUseStationName.Trim Select A Order By A.DataCreateTime Ascending).ToList
            Dim BeforeBreakLastRunProcessData As RunProcessData = Nothing
            If GetRunProcessDatas.Count >= 5 Then
                Return False     '限制最多分5捲,以防止系統異常分捲訊號發生
            End If
            If GetRunProcessDatas.Count > 0 Then
                BeforeBreakLastRunProcessData = GetRunProcessDatas(GetRunProcessDatas.Count - 1)
                AddRunProcessData.FirstsysCoilStartTime = GetRunProcessDatas(GetRunProcessDatas.Count - 1).FirstsysCoilStartTime
            End If
            With AddRunProcessData
                .AboutStation = Me.CurrentUseingStationRadioButton.UseStation
                '.SetCICWeightDefaultValues()    '設定過磅資料(襯紙/套筒/奇力龍)預設值
                .RunStationPCIP = Me.CurrentOperationPCRunningState.RunningPCIP
                .FK_OutSHA01 = .FK_LastRefSHA01
                .SysCoilStartTime = SourceControl.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.WebServerNowTime
                .SysCoilEndTime = .SysCoilStartTime
                .Guage = CoilFullNumberForLastPPSSHAPF.SHA14
                .Width = CoilFullNumberForLastPPSSHAPF.SHA15
                If Not IsNothing(BeforeBreakLastRunProcessData) Then
                    .Width = BeforeBreakLastRunProcessData.Width
                End If
                .Length = CoilFullNumberForLastPPSSHAPF.SHA16
                .Weight = CoilFullNumberForLastPPSSHAPF.SHA17
                .DataCreateTime = SourceControl.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.WebServerNowTime
                .ThisRecordState = 1 '改變鋼捲編輯資料為CoilStart狀態

                '設定過磅資料(襯紙/套筒/奇力龍)預設值  / ZML給定 第一中間/第二中間/背棍/外徑 預設值
                .SetInitialWorkData(Me.CurrentOperationPCRunningState)
            End With


            AddRunProcessData.CDBSave()

            '修改前一筆CoilRunningItem 之CoilEnd 的時間
            If Not IsNothing(BeforeBreakLastRunProcessData) Then
                BeforeBreakLastRunProcessData.SysCoilEndTime = AddRunProcessData.SysCoilStartTime
                BeforeBreakLastRunProcessData.CoilEndTime = BeforeBreakLastRunProcessData.SysCoilEndTime
                BeforeBreakLastRunProcessData.CDBSave()
            End If


            RefreshBreakNumberAndCoilEndSave(False) '重整鋼捲號碼及儲存CoilEnd時間
            AddEditStationControl = Me.CurrentUseingStationRadioButton.CreateStationRunningControl(AddRunProcessData, SourceControl.CurrentRunningCoilScanedTreeNode)
        End If
        Return True
    End Function
#End Region
#Region "刪除作業中鋼捲編輯資料 函式:DeleteCoilRunningItemEditData"
    ''' <summary>
    ''' 結束或移除作業中鋼捲編輯資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Function DeleteOrMoveCoilRunningItemEditData(ByVal DeleteCoilRunningItemType As DeleteCoilRunningItemType, ByVal DeleteCoilRunningItem As CoilRunningItem) As Boolean
        Me.tsslMessage.Text = Nothing

        Dim ContentControl As IStationRunningControl
        Select Case DeleteCoilRunningItemType
            Case CoilScanAndMachineProcess.DeleteCoilRunningItemType.BeforeCoilStart
                For Each Eachitem In (From A In DeleteCoilRunningItem.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.AboutRunProcessDatas Where A.ThisRecordState = 1 And A.RunStationPCIP = Me.CurrentOperationPCRunningState.RunningPCIP And A.FK_RunStationName.Trim = Me.CurrentOperationPCRunningState.DefaultUseStationName.Trim Select A).ToList
                    If Eachitem.CDBDelete() = 0 Then
                        Return False
                    End If
                Next
                Return True
            Case CoilScanAndMachineProcess.DeleteCoilRunningItemType.CoilStarting
                If IsNothing(tabDetailEdit.SelectedTab) OrElse tabDetailEdit.SelectedTab.Controls.Count = 0 OrElse Not TypeOf tabDetailEdit.SelectedTab.Controls(0) Is IStationRunningControl Then
                    tsslMessage.Text = "必須有鋼捲資料可供刪除!"
                    Return False
                End If
                If tabDetailEdit.TabPages.Count < 2 Then
                    tsslMessage.Text = "每捲鋼捲至少必須有一顆鋼捲資料!"
                    Return False
                End If
                '只刪除目前正在編輯中的分捲資料
                ContentControl = tabDetailEdit.SelectedTab.Controls(0)
                If ContentControl.EdittingData.CDBDelete() = 0 Then
                    Return False
                End If
            Case CoilScanAndMachineProcess.DeleteCoilRunningItemType.AfterCoilEnd
                For Each Eachitem In (From A In DeleteCoilRunningItem.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.AboutRunProcessDatas Where A.ThisRecordState = 1 And A.RunStationPCIP = Me.CurrentOperationPCRunningState.RunningPCIP And A.FK_RunStationName.Trim = Me.CurrentOperationPCRunningState.DefaultUseStationName.Trim Select A).ToList
                    Eachitem.ThisRecordState = 2 '改變鋼捲編輯資料為CoilEnd狀態
                    'If Eachitem.CDBUpdate() = 0 Then
                    '    Return False
                    'End If
                    Eachitem.CDBUpdate()
                Next
                Return True
        End Select

        RefreshBreakNumberAndCoilEndSave(False) '重整鋼捲號碼及儲存CoilEnd時間
        Return True
    End Function

    Public Enum DeleteCoilRunningItemType
        BeforeCoilStart = 1
        CoilStarting = 2
        AfterCoilEnd = 3
    End Enum

#End Region
#Region "重整鋼捲號碼及儲存CoilEnd時間 函式:RefreshBreakNumberAndCoilEndSave"
    ''' <summary>
    ''' 重整鋼捲號碼及儲存最後一捲CoilEnd時間
    ''' </summary>
    ''' <remarks></remarks>
    Sub RefreshBreakNumberAndCoilEndSave(ByVal IsAllCoilToCoilEnd As Boolean)
        Dim RefPPSSHAPFFlowAdapter As CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter = Me.CurrentEditCoilRunningItem.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter
        If IsNothing(RefPPSSHAPFFlowAdapter) Then
            Exit Sub
        End If
        Dim GetValue As List(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessData) = (From A In RefPPSSHAPFFlowAdapter.AboutRunProcessDatas Where A.ThisRecordState = 1 And A.RunStationPCIP = Me.CurrentOperationPCRunningState.RunningPCIP And A.FK_RunStationName.Trim = Me.CurrentOperationPCRunningState.DefaultUseStationName.Trim Select A).ToList
        Select Case True
            Case GetValue.Count > 1
                Dim BreakCount As Integer = 1
                For Each EachItem As RunProcessData In GetValue
                    EachItem.FK_OutSHA01 = RefPPSSHAPFFlowAdapter.SHA01
                    EachItem.FK_OutSHA02 = RefPPSSHAPFFlowAdapter.SHA02.Trim & Chr(Asc("A") + BreakCount - 1)
                    If IsAllCoilToCoilEnd AndAlso BreakCount = GetValue.Count OrElse EachItem.SysCoilStartTime = EachItem.SysCoilEndTime Then
                        '儲存最後一捲CoilEnd時間
                        EachItem.SysCoilEndTime = RefPPSSHAPFFlowAdapter.WebServerNowTime
                        EachItem.CoilEndTime = EachItem.SysCoilEndTime
                    End If
                    BreakCount += 1
                    EachItem.CDBSave()
                Next
            Case GetValue.Count = 1
                GetValue(0).FK_OutSHA01 = RefPPSSHAPFFlowAdapter.SHA01
                GetValue(0).FK_OutSHA02 = RefPPSSHAPFFlowAdapter.SHA02
                GetValue(0).SysCoilEndTime = RefPPSSHAPFFlowAdapter.WebServerNowTime    '儲存最後一捲CoilEnd時間
                GetValue(0).CoilEndTime = GetValue(0).SysCoilEndTime
                GetValue(0).CDBSave()
            Case Else
        End Select
    End Sub
#End Region
#Region "現在編輯的CoilRunningItem 屬性/變更事件:CurrentEditCoilRunningItem/CurrentEditCoilRunningItemChanged"
    Public Event CurrentEditCoilRunningItemChanged(ByVal OldValue As CoilRunningItem, ByVal CurrentValue As CoilRunningItem)
    Private _CurrentEditCoilRunningItem As CoilRunningItem
    ''' <summary>
    ''' 現在編輯的CoilRunningItem
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentEditCoilRunningItem() As CoilRunningItem
        Get
            Return _CurrentEditCoilRunningItem
        End Get
        Set(ByVal value As CoilRunningItem)
            Static OldCurrentEditCoilRunningItem As CoilRunningItem = Nothing
            OldCurrentEditCoilRunningItem = _CurrentEditCoilRunningItem
            SaveCoilRunningItemEditDataToDB()
            _CurrentEditCoilRunningItem = value
            Me.tsslMessage.Text = Nothing
            If Not IsNothing(_CurrentEditCoilRunningItem) Then
                If LoadCoilRunningItemEditDataFromDB(_CurrentEditCoilRunningItem) = False Then
                    If Me.CurrentOperationPCRunningState.IsTheOperationPCRunningStateForThisMachine AndAlso Me.AddCoilRunningItemEditData(_CurrentEditCoilRunningItem) Then
                        LoadCoilRunningItemEditDataFromDB(_CurrentEditCoilRunningItem)
                    End If
                End If
            Else
                LoadCoilRunningItemEditDataFromDB(Nothing)
            End If
            tsButtons.Enabled = Me.tabDetailEdit.TabPages.Count > 0
            tsbDelBreadkCoil.Enabled = Me.tabDetailEdit.TabPages.Count > 1
            If Not OldCurrentEditCoilRunningItem Is _CurrentEditCoilRunningItem Then
                RaiseEvent CurrentEditCoilRunningItemChanged(OldCurrentEditCoilRunningItem, _CurrentEditCoilRunningItem)
            End If
            OldCurrentEditCoilRunningItem = _CurrentEditCoilRunningItem
        End Set
    End Property
#End Region
#Region "現在正在編輯的所有製程中資料 屬性:CurrentEditRunProcessDatas"
    Private _CurrentEditRunProcessDatas As New List(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessData)
    ''' <summary>
    ''' 現在正在編輯的所有製程中資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentEditRunProcessDatas() As List(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessData)
        Get
            Return _CurrentEditRunProcessDatas
        End Get
        Private Set(ByVal value As List(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessData))
            _CurrentEditRunProcessDatas = value
        End Set
    End Property

#End Region
#Region "L2訊號監控元件 屬性/事件:L2MessageWatchControl"
    WithEvents L2MessageWatchControlEvent As ReceiveL2Message
    Private _L2MessageWatchControl As ReceiveL2Message
    ''' <summary>
    ''' L2訊號監控元件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property L2MessageWatchControl() As ReceiveL2Message
        Get
            If IsNothing(_L2MessageWatchControl) AndAlso Not String.IsNullOrEmpty(Me.CurrentUesStationName) AndAlso Me.CurrentUesStationName.Trim.Length >= 3 Then
                Dim TestModePath As String = IIf(Not IsOnLineMachine, "_Test", Nothing)

                If {"SBL", "TLL", "SPL", "CPL1", "CPL2", "GPL1", "GPL2", "APL1", "APL2", "BAL", "ZML1", "ZML2", "ZML3"} _
                    .Contains(Me.CurrentUesStationName.PadRight(4).Substring(0, 4).Trim) Then
                    Dim LineName As String = Me.CurrentUesStationName.PadRight(4).Substring(0, 4).Trim

                    _L2MessageWatchControl = New ReceiveL2Message("//10.12.6.30/" & LineName & TestModePath & "/sent/" & LineName & "_CoilData.txt")
                End If

                L2MessageWatchControlEvent = _L2MessageWatchControl
            End If
            Return _L2MessageWatchControl
        End Get
    End Property

#End Region
#Region "L2PDO訊號監控元件 屬性/事件:L2PDOMessageWatchControl"
    WithEvents L2PDOMessageWatchControlEvent As ReceiveL2PDOMessage
    Private _L2PDOMessageWatchControl As ReceiveL2PDOMessage
    ''' <summary>
    ''' L2PDO訊號監控元件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property L2PDOMessageWatchControl() As ReceiveL2PDOMessage
        Get
            If IsNothing(_L2PDOMessageWatchControl) AndAlso Not String.IsNullOrEmpty(Me.CurrentUesStationName) AndAlso Me.CurrentUesStationName.Trim.Length >= 3 Then
                Dim TestModePath As String = IIf(Not IsOnLineMachine, "_Test", Nothing)

                Dim LineName As String = Me.CurrentUesStationName.PadRight(4).Substring(0, 4).Trim
                _L2PDOMessageWatchControl = New ReceiveL2PDOMessage("//10.12.6.30/" & LineName & TestModePath & "/sent/" & LineName & "_PDO.txt")

                L2PDOMessageWatchControlEvent = _L2PDOMessageWatchControl
            End If
            Return _L2PDOMessageWatchControl
        End Get
    End Property

#End Region

#Region "快速執行鋼捲結束並印表 方法:QuickCoilEndAndPrint"
    ''' <summary>
    ''' 快速執行鋼捲結束並印表
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub QuickCoilEndAndPrint()
        Select Case True
            Case Not IsNothing(TailProcessCoilLinkControl)
                Call TailProcessCoilLinkControl.MoveBackOrFront(True)
            Case Else
                '判斷是目前選的節點是否未在準備線節點上,如果沒有則自動調整選取所屬之準備線節點
                If Not IsNothing(Me.TreeView1.SelectedNode) AndAlso TypeOf Me.TreeView1.SelectedNode.Parent Is TreeNode Then
                    Me.TreeView1.SelectedNode = Me.TreeView1.SelectedNode.Parent
                End If
                If IsNothing(Me.TreeView1.SelectedNode) Then
                    Me.TreeView1.SelectedNode = Me.TreeView1.Nodes(0)
                End If
                Call PBCoilStart_Click(PBCoilStart, Nothing)
                If Not IsNothing(TailProcessCoilLinkControl) Then
                    Call TailProcessCoilLinkControl.MoveBackOrFront(True)
                End If
        End Select
    End Sub
#End Region

#Region "新增鋼捲移動狀態記錄 函式:AddNewCoilMoveStateRecord"
    ''' <summary>
    ''' 新增鋼捲移動狀態記錄
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddNewCoilMoveStateRecord(ByVal SourceCoilRunningItem As CoilRunningItem)
        Dim CurrentUseStationName As String = ""
        CurrentUseStationName = Me.CurrentUseingStationRadioButton.Text.Trim

        Dim AboutPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = SourceCoilRunningItem.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF
        If IsNothing(AboutPPSSHAPF) Then
            Exit Sub
        End If
        Dim NewInsertObject As New CompanyORMDB.SQLServer.PPS100LB.CoilMoveState(AboutPPSSHAPF.SHA01 & AboutPPSSHAPF.SHA02.Trim, CurrentUseStationName, AboutPPSSHAPF.SHA27, "此站處理完畢!", SourceCoilRunningItem.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter)
        NewInsertObject.CDBSave()
    End Sub
#End Region

#Region "接收處理L2訊號 方法/委派:ProcessL2Message/ProcessL2MessageAndUpdateUI"
    Private Shared mut As New Mutex()
    Private Delegate Sub ProcessL2MessageAndUpdateUI(L2Message As L2Message)
    ''' <summary>
    ''' 接收處理L2訊號
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcessL2Message(ByVal L2Message As L2Message)
        If CurrentOperationPCRunningState.IsTheOperationPCRunningStateForThisMachine = False Then
            Exit Sub    '非伺服端站台不接收 Level2 訊號命令
        End If

        mut.WaitOne()
        Try
            LoadDBOperationPCRunningStateToControlValue()   '重新取得最新系統狀態
            ReSortRunCoilsOrder()

            Dim CoilStartLineNode As TreeNode = Nothing
            '比對訊號命令是否符合目前系統狀態,不符合則立刻離開
            Select Case True
                Case L2Message.TraggerKind = L2Message.TraggerKindEnum.CoilStart
                    'If (Me.CurrentOperationPCRunningState.Line2IsEnable AndAlso L2Message.InputLineKind = L2Message.InputLineKindEnum.NODiffer) OrElse _
                    '   (Me.CurrentOperationPCRunningState.Line2IsEnable = False AndAlso L2Message.InputLineKind <> L2Message.InputLineKindEnum.NODiffer) Then
                    '    Exit Sub
                    'End If

                    'If L2Message.InputLineKind = ColdRollingClient.L2Message.InputLineKindEnum.NODiffer OrElse _
                    '    L2Message.InputLineKind = ColdRollingClient.L2Message.InputLineKindEnum.UP Then
                    '    CoilStartLineNode = TreeView1.Nodes(0)
                    'Else
                    '    CoilStartLineNode = TreeView1.Nodes(1)
                    'End If
                    Select Case True
                        Case String.IsNullOrEmpty(L2Message.CoilFullNumber)
                            Exit Sub
                        Case L2Message.InputLineKind = ColdRollingClient.L2Message.InputLineKindEnum.UP
                            CoilStartLineNode = TreeView1.Nodes(0)
                        Case L2Message.InputLineKind = ColdRollingClient.L2Message.InputLineKindEnum.DOWN
                            CoilStartLineNode = TreeView1.Nodes(1)
                        Case Else
                            If TreeView1.Nodes(0).Nodes.Count > 0 AndAlso CType(TreeView1.Nodes(0).Nodes(0), CoilScanedTreeNode).CoilFullNumber.Trim = L2Message.CoilFullNumber.Trim Then
                                CoilStartLineNode = TreeView1.Nodes(0) : Exit Select
                            End If
                            If TreeView1.Nodes(1).Nodes.Count > 0 AndAlso CType(TreeView1.Nodes(1).Nodes(0), CoilScanedTreeNode).CoilFullNumber.Trim = L2Message.CoilFullNumber.Trim Then
                                CoilStartLineNode = TreeView1.Nodes(1) : Exit Select
                            End If
                    End Select
                    If IsNothing(CoilStartLineNode) OrElse CoilStartLineNode.Nodes.Count = 0 OrElse CType(CoilStartLineNode.Nodes(0), CoilScanedTreeNode).CoilFullNumber.Trim <> L2Message.CoilFullNumber.Trim Then
                        Exit Sub
                    End If

                    If Not IsNothing(Me.CurrentEditCoilRunningItem) AndAlso _
                       Me.CurrentEditCoilRunningItem.TailLeftToHeadRightAllCoilRunningItems.Count > Me.CurrentOperationPCRunningState.MaxCoilNumberInRunningProcessSet Then
                        Exit Sub
                    End If
                    TreeView1.SelectedNode = CoilStartLineNode
                    RefreshEnableButton()
                    Call PBCoilStart_Click(Nothing, Nothing)
                Case L2Message.TraggerKind = L2Message.TraggerKindEnum.CoilEnd
                    If IsNothing(Me.CurrentEditCoilRunningItem) Then
                        Exit Sub
                    End If

                    Dim HeadCoilRunningItem As CoilRunningItem = Me.CurrentEditCoilRunningItem.HeadeCoilRunningItem

                    '犧牲鋼捲特殊處理(不存檔)
                    If L2Message.CoilFullNumber.Substring(0, 2) = "BA" OrElse L2Message.CoilFullNumber.Substring(0, 2) = "AP" OrElse L2Message.CoilFullNumber.Substring(0, 2) = "TE" Then
                        Me.LoadCoilRunningItemEditDataFromDB(HeadCoilRunningItem)
                        Call HeadCoilRunningItem.MoveBackOrFront(True) : Exit Sub
                    End If

                    Dim GetNextCoilEndProcessData As RunProcessData = (From A In HeadCoilRunningItem.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.AboutRunProcessDatas Select A Order By (A.FK_OutSHA01 & A.FK_OutSHA02) Descending).FirstOrDefault
                    If Not String.IsNullOrEmpty(L2Message.CoilFullNumber) AndAlso (GetNextCoilEndProcessData.FK_OutSHA01 & GetNextCoilEndProcessData.FK_OutSHA02).Trim <> L2Message.CoilFullNumber.Trim Then
                        Exit Sub
                    End If
                    GetNextCoilEndProcessData.L2MessageString = L2Message.Message   'L2訊號儲存
                    SetL2MsgToRunProcessData(GetNextCoilEndProcessData)             '轉換L2訊號至RunprocessData
                    GetNextCoilEndProcessData.CDBSave()
                    Me.LoadCoilRunningItemEditDataFromDB(HeadCoilRunningItem)
                    Call HeadCoilRunningItem.MoveBackOrFront(True)
                Case L2Message.TraggerKind = L2Message.TraggerKindEnum.BreakCoil OrElse L2Message.TraggerKind = L2Message.TraggerKindEnum.CutCoil   '斷捲/分捲
                    If Me.CurrentUesStationName.PadRight(3).ToUpper = "SPL" OrElse IsNothing(Me.CurrentEditCoilRunningItem) Then
                        'SPL 不接收分捲訊號,一律由手動分捲
                        Exit Sub
                    End If
                    Dim GetCoilRunningItem As CoilRunningItem = Me.CurrentEditCoilRunningItem.HeadeCoilRunningItem
                    If Not String.IsNullOrEmpty(L2Message.CoilFullNumber) Then
                        GetCoilRunningItem = Nothing
                        For Each EachItem In Me.CurrentEditCoilRunningItem.TailLeftToHeadRightAllCoilRunningItems
                            If EachItem.CurrentRunningCoilScanedTreeNode.CoilFullNumber.Trim = L2Message.CoilFullNumber Then
                                GetCoilRunningItem = EachItem : Exit For
                            End If
                        Next
                    End If
                    If IsNothing(GetCoilRunningItem) Then
                        Exit Sub
                    End If

                    Dim HeadCoilRunningItem As CoilRunningItem = Me.CurrentEditCoilRunningItem.HeadeCoilRunningItem
                    Dim GetNextCoilEndProcessData As RunProcessData = (From A In HeadCoilRunningItem.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.AboutRunProcessDatas Select A Order By (A.FK_OutSHA01 & A.FK_OutSHA02) Descending).FirstOrDefault
                    GetNextCoilEndProcessData.L2MessageString = L2Message.Message   'L2訊號儲存
                    SetL2MsgToRunProcessData(GetNextCoilEndProcessData)             '轉換L2訊號至RunprocessData
                    GetNextCoilEndProcessData.CDBSave()
                    Me.LoadCoilRunningItemEditDataFromDB(HeadCoilRunningItem)
                    Call tsbAddBreadkCoil_Click(Nothing, Nothing)
                Case L2Message.TraggerKind = L2Message.TraggerKindEnum.BreakDown    '故障
                Case Else
                    Exit Sub
            End Select
        Catch ex As Exception
            tsslMessage.Text = "L2訊號接收後處理錯誤:" & ex.ToString


            Dim Smtp As New SmtpClient("mail.tangeng.com.tw", 25)
            Smtp.Credentials = New System.Net.NetworkCredential("mis", "1j4@vu.4")
            Dim SendMessage As New MailMessage
            SendMessage.From = New MailAddress("mis@mail.tangeng.com.tw", "系統發送")
            SendMessage.To.Add(New MailAddress("kuku@mail.tangeng.com.tw", "古政剛"))
            SendMessage.Subject = "軋鋼訊號接收資料異常通知!"
            SendMessage.IsBodyHtml = False
            SendMessage.Body = Me.CurrentUesStationName & "接收資料" & L2Message.Message & vbNewLine & "錯誤訊息:" & ex.ToString
            SendMessage.Body &= vbNewLine & "ProcessL2Message 執行動作訊息:" & L2Message.Message
            Smtp.Send(SendMessage)


            'Dim MailObject As New PublicClassLibrary.MISMail
            'Dim SendBody As String
            'With MailObject
            '    .ToMailAddress.Add(New MailAddress("kuku@mail.tangeng.com.tw", "古政剛"))
            '    SendBody = Me.CurrentUesStationName & "接收資料" & L2Message.Message & vbNewLine & "錯誤訊息:" & ex.ToString
            '    SendBody &= vbNewLine & "ProcessL2Message 執行動作訊息:" & L2Message.Message
            '    .SendMail("軋鋼訊號接收資料異常通知!", SendBody)
            'End With

        Finally
            mut.ReleaseMutex()
        End Try
        '2013/05/02 03:10:06,1,A1233,R,100,200,300,400,500
        '欄位定義:
        '2013/05/02 03:10:06=發生日期及時間
        '1=觸發種類 (1= Coil start, 2=Coil end, 3=斷捲,4=分捲,5=故障)
        'A1233=鋼捲號碼
        'R=生產(R=生產(無上下線), U=上線生產,D=下線生產)
        '100=長度
        '200=厚度
        '300=寬度
        '400=斷捲長度
        '500=軋研次數
    End Sub

#End Region
#Region "接收處理L2PDO訊號 方法/委派:ProcessL2PDOMessage/ProcessL2PDOMessageAndUpdateUI"
    Private Delegate Sub ProcessL2PDOMessageAndUpdateUI(L2PDOMessage As L2PDOMessage)
    ''' <summary>
    ''' 接收處理L2PDO訊號
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcessL2PDOMessage(ByVal L2PDOMessage As L2PDOMessage)
        mut.WaitOne()
        Try
            For Each EachNode As CoilScanedTreeNode In Me.TreeView1.Nodes(0).Nodes
                EachNode.BackColor = Color.White
            Next
            For Each EachNode As CoilScanedTreeNode In Me.TreeView1.Nodes(1).Nodes
                EachNode.BackColor = Color.White
            Next

            If CurrentOperationPCRunningState.IsTheOperationPCRunningStateForThisMachine = False Then
                Exit Sub    '非伺服端站台不接收 Level2 訊號命令
            End If

            If L2PDOMessage.InputLineKind = ColdRollingClient.L2PDOMessage.InputLineKindEnum.UP AndAlso L2PDOMessage.SingalType = ColdRollingClient.L2PDOMessage.SingalTypeEnum.StartWeld Then
                For Each EachNode As CoilScanedTreeNode In Me.TreeView1.Nodes(0).Nodes
                    If EachNode.CoilFullNumber.Trim = L2PDOMessage.CoilFullNumber Then
                        EachNode.BackColor = Color.LightPink
                        Exit For
                    End If
                Next
            End If
            If L2PDOMessage.InputLineKind = ColdRollingClient.L2PDOMessage.InputLineKindEnum.DOWN AndAlso L2PDOMessage.SingalType = ColdRollingClient.L2PDOMessage.SingalTypeEnum.StartWeld Then
                For Each EachNode As CoilScanedTreeNode In Me.TreeView1.Nodes(1).Nodes
                    If EachNode.CoilFullNumber.Trim = L2PDOMessage.CoilFullNumber Then
                        EachNode.BackColor = Color.LightPink
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            tsslMessage.Text = "L2訊號接收後處理錯誤:" & ex.ToString

            Dim Smtp As New SmtpClient("mail.tangeng.com.tw", 25)
            Smtp.Credentials = New System.Net.NetworkCredential("mis", "1j4@vu.4")
            Dim SendMessage As New MailMessage
            SendMessage.From = New MailAddress("mis@mail.tangeng.com.tw", "系統發送")
            SendMessage.To.Add(New MailAddress("kuku@mail.tangeng.com.tw", "古政剛"))
            SendMessage.Subject = "軋鋼訊號接收資料異常通知!"
            SendMessage.IsBodyHtml = False
            SendMessage.Body = Me.CurrentUesStationName & "接收資料" & L2PDOMessage.Message & vbNewLine & "錯誤訊息:" & ex.ToString
            SendMessage.Body &= vbNewLine & "ProcessL2PDOMessage執行動作訊息:" & L2PDOMessage.Message
            Smtp.Send(SendMessage)

        Finally
            mut.ReleaseMutex()
        End Try
        'APL(PDO):
        '產線,鋼捲號碼,資料建立時間,上下線(2上線/3下線),1焊接開始/2結束
        'APL2,M1111,2014/03/20 16:02:44,2,1
    End Sub

#End Region
#Region "設定L2資料傳送過來的資料 函式:SetL2MsgToRunProcessData"
    ''' <summary>
    ''' '設定L2資料傳送過來的資料
    ''' </summary>
    ''' <param name="SetItem"></param>
    ''' <remarks></remarks>
    Private Sub SetL2MsgToRunProcessData(ByVal SetItem As RunProcessData)
        If IsNothing(SetItem) OrElse String.IsNullOrEmpty(SetItem.L2MessageString) OrElse SetItem.L2MessageString.Trim.Length = 0 Then
            Exit Sub
        End If
        Dim ConvertErrString As String = Nothing
        Try
            Dim L2MsgObject = New L2Message(SetItem.L2MessageString)
            ConvertErrString = L2MsgObject.ErrorMessage
            With SetItem
                .Length = L2MsgObject.Length
                .Guage = L2MsgObject.Thick
                .Width = L2MsgObject.Width
            End With
        Catch ex As Exception
            ConvertErrString = ex.ToString
        End Try
        If Not String.IsNullOrEmpty(ConvertErrString) Then
            Me.tsslMessage.Text &= ConvertErrString
        End If
    End Sub
#End Region
#Region "將產線目前鋼捲品管PDI命令轉成文字檔傳送至Level2 方法:SendPDIToL2"
    ''' <summary>
    ''' 將產線目前鋼捲品管PDI命令轉成文字檔傳送至Level2
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SendPDIToL2(ByVal setCoilFullNumber As String) As Boolean
        If Me.CurrentOperationPCRunningState.IsStopL2MsgTalk Then
            Return False
        End If
        '將產線目前鋼捲品管PDI命令轉成文字檔傳送至Level2
        Dim TestModePath As String = IIf(Not IsOnLineMachine, "_Test", Nothing)

        '傳送成品線作業規定至成品線 SBL/TLL/SPL
        If Not String.IsNullOrEmpty(Me.CurrentUesStationName) AndAlso Me.CurrentUesStationName.Trim.Length >= 3 AndAlso _
            {"SBL", "TLL", "SPL"}.Contains(Me.CurrentUesStationName.PadRight(3).Substring(0, 3).Trim) Then
            Dim WriteString As String = (New SendPDIToL2(CurrentOperationPCRunningState.RunningPCIP, setCoilFullNumber)).ConvertPDIToText(ColdRollingClient.SendPDIToL2.ConvertPIDType.QASeparateCmd)
            Dim LineName As String = Me.CurrentUesStationName.PadRight(4).Substring(0, 4).Trim
            My.Computer.FileSystem.WriteAllText("\\10.12.6.30\" & LineName & TestModePath & "\received\" & LineName & "_PDI.txt", WriteString, False)
            Return True
        End If
        Return False
    End Function

    Public Function SendPDIToL2(ByVal setCoilFullNumber As String, ByVal SetUserDefinePDIString As String) As Boolean
        If Me.CurrentOperationPCRunningState.IsStopL2MsgTalk Then
            Return False
        End If
        '將產線目前鋼捲APL之PDI命令轉成文字檔傳送至Level2
        Dim TestModePath As String = IIf(Not IsOnLineMachine, "_Test", Nothing)

        '傳送APL分捲命令
        If Not String.IsNullOrEmpty(Me.CurrentUesStationName) AndAlso Me.CurrentUesStationName.Trim.Length >= 3 AndAlso _
            {"APL"}.Contains(Me.CurrentUesStationName.PadRight(3).Substring(0, 3).Trim) Then
            Dim WriteString As String = (New SendPDIToL2(CurrentOperationPCRunningState.RunningPCIP, setCoilFullNumber, SetUserDefinePDIString)).ConvertPDIToText(ColdRollingClient.SendPDIToL2.ConvertPIDType.APLSeparateCmd)
            Dim LineName As String = Me.CurrentUesStationName.PadRight(4).Substring(0, 4).Trim
            My.Computer.FileSystem.WriteAllText("\\10.12.6.30\" & LineName & TestModePath & "\received\" & LineName & "_PDI.txt", WriteString, False)
            Return True
        End If

        Return False
    End Function
#End Region

#Region "現在執行ZMLOperationPCRunningState控制項 屬性:CurrentEditZMLOperationPCRunningStateControl"
    Private _CurrentEditZMLOperationPCRunningStateControl As IStationOperationPCRunningState
    ''' <summary>
    ''' 現在執行ZMLOperationPCRunningState控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentEditZMLOperationPCRunningStateControl() As ZMLOperationPCRunningState
        Get
            If IsNothing(_CurrentEditZMLOperationPCRunningStateControl) Then
                _CurrentEditZMLOperationPCRunningStateControl = New ZMLOperationPCRunningState(Me.CurrentOperationPCRunningState, Me)
            End If
            Return _CurrentEditZMLOperationPCRunningStateControl
        End Get
        Private Set(ByVal value As ZMLOperationPCRunningState)
            _CurrentEditZMLOperationPCRunningStateControl = value
        End Set
    End Property
#End Region

#Region "重新排序鋼捲執行順序 函式:ReSortRunCoilsOrder"
    ''' <summary>
    ''' 重新排序鋼捲執行順序
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReSortRunCoilsOrder()
        Dim OrderNumber As Integer = 1
        Dim NextOrderTreeNodeLinePoint As Integer  '計算準備線上之鋼捲排序指標(0.上線 1.下線)
        If Not IsNothing(Me.CurrentEditCoilRunningItem) Then
            Dim GetDatas As List(Of CoilRunningItem) = Me.CurrentEditCoilRunningItem.TailLeftToHeadRightAllCoilRunningItems
            GetDatas.Reverse()
            For Each EachItem As CoilRunningItem In GetDatas
                If Not IsNothing(EachItem.CurrentRunningCoilScanedTreeNode) Then
                    EachItem.CurrentRunningCoilScanedTreeNode.CoilRunningOrderNumber = OrderNumber
                    EachItem.CurrentRunningCoilScanedTreeNode.IsWillShowCoilRunningOrder = Me.CurrentOperationPCRunningState.Line2IsEnable

                    OrderNumber += 1
                    NextOrderTreeNodeLinePoint = IIf(EachItem.CurrentRunningCoilScanedTreeNode.CoilScanWaitProcessNumber = 1, 1, 0)
                End If
            Next
        End If

        If Not Me.CurrentOperationPCRunningState.Line2IsEnable Then
            For Each EachNode As CoilScanedTreeNode In TreeView1.Nodes(0).Nodes
                EachNode.IsWillShowCoilRunningOrder = False
                EachNode.CoilRunningOrderNumber = OrderNumber
                OrderNumber += 1
            Next
        Else
            Dim DataStack As New Stack(Of CoilScanedTreeNode)
            Dim UPLineNodePoint As Integer = 0      '上線節點指標
            Dim DownLineNodePoint As Integer = 0    '下線節點指標
            If Not IsNothing(TreeView1.SelectedNode) Then
                Dim UserSelectLineNode As TreeNode = TreeView1.SelectedNode
                If TypeOf TreeView1.SelectedNode Is CoilScanedTreeNode Then
                    UserSelectLineNode = TreeView1.SelectedNode.Parent
                End If
                If UserSelectLineNode Is TreeView1.Nodes(0) Then
                    NextOrderTreeNodeLinePoint = 0
                Else
                    NextOrderTreeNodeLinePoint = 1
                End If
            End If
            For Index As Integer = 0 To IIf(TreeView1.Nodes(0).Nodes.Count > TreeView1.Nodes(1).Nodes.Count, TreeView1.Nodes(0).Nodes.Count, TreeView1.Nodes(1).Nodes.Count) * 2
                If NextOrderTreeNodeLinePoint = 0 Then
                    If TreeView1.Nodes(0).Nodes.Count > UPLineNodePoint Then
                        CType(TreeView1.Nodes(0).Nodes(UPLineNodePoint), CoilScanedTreeNode).CoilRunningOrderNumber = OrderNumber
                        CType(TreeView1.Nodes(0).Nodes(UPLineNodePoint), CoilScanedTreeNode).IsWillShowCoilRunningOrder = True
                        OrderNumber += 1
                        UPLineNodePoint += 1
                    End If

                    NextOrderTreeNodeLinePoint = 1
                Else
                    If TreeView1.Nodes(1).Nodes.Count > DownLineNodePoint Then
                        CType(TreeView1.Nodes(1).Nodes(DownLineNodePoint), CoilScanedTreeNode).CoilRunningOrderNumber = OrderNumber
                        CType(TreeView1.Nodes(1).Nodes(DownLineNodePoint), CoilScanedTreeNode).IsWillShowCoilRunningOrder = True
                        OrderNumber += 1
                        DownLineNodePoint += 1
                    End If

                    NextOrderTreeNodeLinePoint = 0
                End If
            Next
        End If
    End Sub
#End Region

    WithEvents TailProcessCoilLinkControlEvent As CoilRunningItem

    Private Sub CoilScanAndMachineProcess_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Me.CurrentOperationPCRunningState.IsTheOperationPCRunningStateForThisMachine Then
            '只有主伺服端離開時才做資料保存回寫動作
            Me.SaveControlValueToOperationPCRunningState()
        End If
    End Sub


    Private Sub CoilScanAndMachineProcess_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ParentForm.Text = "軋鋼現場作業系統"
        If CompanyORMDB.DeviceInformation.GetLocalIPs.Count > 0 Then
            Me.ParentForm.Text &= "  本機電腦IP:" & CompanyORMDB.DeviceInformation.GetLocalIPs(0)
        End If
        If PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.RunningPCIP.Trim = CompanyORMDB.DeviceInformation.GetLocalIPs(0).Trim Then
            Me.ParentForm.Text &= " 本機角色:伺服端"
        Else
            Me.ParentForm.Text &= " 本機角色:用戶端(連線Server IP:" & PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.RunningPCIP.Trim & ")"
        End If

        If IsNothing(Me.TheMachinePCRunningState) Then
            If Me.SaveControlValueToOperationPCRunningState() = False Then
                TableLayoutPanel1.Enabled = False
                MsgBox("請洽系統管理員:" & Me.tsslMessage.Text)
                Exit Sub
            End If
        End If

        Dim FindStationDataLastChangeTime = StationDataLastChangeTime.FindStationDataLastChangeTimeForIP(Me.CurrentOperationPCRunningState.RunningPCIP)
        If IsNothing(FindStationDataLastChangeTime) Then
            FindStationDataLastChangeTime = New StationDataLastChangeTime(Me.CurrentOperationPCRunningState.RunningPCIP)
            FindStationDataLastChangeTime.CDBSave()
        End If
        LastSaveStationDataLastChangeTime = FindStationDataLastChangeTime

        If LoadDBOperationPCRunningStateToControlValue() = False Then
            TableLayoutPanel1.Enabled = False
            MsgBox("請洽系統管理員:" & Me.tsslMessage.Text)
            Exit Sub
        End If


        Me.RefreshDisplayProcessCoilLinkControls()
        Me.RefreshEnableButton()

        ''載入預設所有樣本
        'Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        'Dim InsertNode As TreeNode = TreeView1.Nodes(0)
        'For Each EachNumer As DataRow In Adapter.SelectQuery("Select DISTINCT SHA01 from PPSSHAPF WHERE DATASOURCETYPE=1").Rows
        '    If Me.TreeView1.Nodes.ContainsKey(EachNumer.Item("SHA01")) = False Then
        '        InsertNode.Nodes.Add(New CoilScanedTreeNode(EachNumer.Item("SHA01"), IIf(InsertNode Is TreeView1.Nodes(0), 1, 2)))
        '    End If
        '    If Me.CheckBox2.Checked Then
        '        InsertNode = IIf(InsertNode Is TreeView1.Nodes(0), TreeView1.Nodes(1), TreeView1.Nodes(0))
        '    End If
        'Next


        TreeView1.ExpandAll()
        If Not Me.CurrentOperationPCRunningState.IsStopL2MsgTalk AndAlso Me.CurrentOperationPCRunningState.IsTheOperationPCRunningStateForThisMachine Then
            If Not IsNothing(L2MessageWatchControl) AndAlso L2MessageWatchControl.StartWatch() = False Then  'Server端開始監控Level2之訊號及接收
                MsgBox("無法連線接L2訊號伺服器請洽資訊處系統管理員!")
            End If
        End If
        If Not Me.CurrentOperationPCRunningState.IsStopPDOMsgTalk AndAlso Me.CurrentOperationPCRunningState.IsTheOperationPCRunningStateForThisMachine Then
            If Not IsNothing(L2PDOMessageWatchControl) AndAlso L2PDOMessageWatchControl.StartWatch() = False Then  'Server端開始監控Level2PDO之訊號及接收
                MsgBox("無法連線接L2PDO訊號伺服器請洽資訊處系統管理員!")
            Else
                L2PDOMessageWatchControl.RelodL2FileAndSendPDOMessage()
            End If
        End If
        Try
            ReStartRS232()
        Catch ex As Exception
            MsgBox("掃描槍無法使用:" & ex.ToString)
        End Try


        '特殊設定:SPL入口資料如有任何異動不做編修動作
        If Me.CurrentUesStationName = "SPL" AndAlso Me.CurrentOperationPCRunningState.IsTheOperationPCRunningStateForThisMachine = False Then
            Me.tpMainOperator.Enabled = False
        End If

    End Sub

    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBCoilStart.MouseEnter
        Dim SenderControl As PictureBox = sender
        SenderControl.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBCoilStart.MouseLeave
        Dim SenderControl As PictureBox = sender
        SenderControl.BorderStyle = Windows.Forms.BorderStyle.None
    End Sub

    Private Sub PBCoilStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBCoilStart.Click
        Dim SelectLineNode As TreeNode = Nothing
        If cbLine2Switch.Checked Then
            Dim UpLineTopNode As CoilScanedTreeNode = Nothing
            Dim DownLineTopNode As CoilScanedTreeNode = Nothing
            If TreeView1.Nodes(0).Nodes.Count > 0 Then
                UpLineTopNode = TreeView1.Nodes(0).Nodes(0)
            End If
            If TreeView1.Nodes(1).Nodes.Count > 0 Then
                DownLineTopNode = TreeView1.Nodes(1).Nodes(0)
            End If
            Select Case True
                Case Not IsNothing(UpLineTopNode) AndAlso Not IsNothing(DownLineTopNode)
                    If DownLineTopNode.CoilRunningOrderNumber < UpLineTopNode.CoilRunningOrderNumber Then
                        SelectLineNode = TreeView1.Nodes(1)
                    Else
                        SelectLineNode = TreeView1.Nodes(0)
                    End If
                Case Not IsNothing(UpLineTopNode)
                    SelectLineNode = TreeView1.Nodes(0)
                Case Not IsNothing(DownLineTopNode)
                    SelectLineNode = TreeView1.Nodes(1)
                Case Else
                    Exit Sub
            End Select
        Else
            If IsNothing(Me.TreeView1.SelectedNode) _
           OrElse (Me.TreeView1.SelectedNode Is TreeView1.Nodes(0) AndAlso TreeView1.Nodes(0).Nodes.Count = 0) _
           OrElse (Me.TreeView1.SelectedNode Is TreeView1.Nodes(1) AndAlso TreeView1.Nodes(1).Nodes.Count = 0) Then
                Exit Sub
            Else
                Select Case True
                    Case TypeOf Me.TreeView1.SelectedNode Is CoilScanedTreeNode AndAlso Not TypeOf Me.TreeView1.SelectedNode.Parent Is CoilScanedTreeNode
                        SelectLineNode = Me.TreeView1.SelectedNode.Parent
                    Case TypeOf Me.TreeView1.SelectedNode Is CoilScanedTreeNode
                        Exit Sub
                    Case Else
                        SelectLineNode = Me.TreeView1.SelectedNode
                End Select
            End If
        End If

        Dim InsertControl As New CoilRunningItem(SelectLineNode.Nodes(0))
        If IsNothing(Me.TailProcessCoilLinkControl) Then
            Me.TailProcessCoilLinkControl = InsertControl
            If Not Me.CurrentEditCoilRunningItem Is InsertControl Then
                Me.CurrentEditCoilRunningItem = InsertControl
            End If
        Else
            Me.TailProcessCoilLinkControl.InsertCoilRunningItemToItemTail(InsertControl)
            Me.TailProcessCoilLinkControl = InsertControl
        End If


        If Not IsNothing(InsertControl.CurrentRunningCoilScanedTreeNode.Parent) Then
            InsertControl.CurrentRunningCoilScanedTreeNode.Parent.Nodes.Remove(InsertControl.CurrentRunningCoilScanedTreeNode)
        End If
        Me.SaveControlValueToOperationPCRunningState()
        Me.RefreshDisplayProcessCoilLinkControls()
        RefreshEnableButton()
        Call AddNewCoilMoveStateRecord(InsertControl) '新增鋼捲移動狀態記錄


        '如果選擇二兩鋼捲入口線則要自動切換
        If cbLine2Switch.Checked Then
            Dim NextSelectNode As TreeNode = IIf(TreeView1.SelectedNode Is TreeView1.Nodes(0), TreeView1.Nodes(1), TreeView1.Nodes(0))
            If NextSelectNode.Nodes.Count = 0 AndAlso TreeView1.SelectedNode.Nodes.Count > 0 Then
                NextSelectNode = TreeView1.SelectedNode
            End If
            TreeView1.SelectedNode = NextSelectNode
        End If
        TreeView1.Focus()
        ReSortRunCoilsOrder()   '重整顯示鋼捲執行順序



        '將產線目前鋼捲品管PDI命令轉成文字檔傳送至Level2
        If Not IsNothing(Me.TailProcessCoilLinkControl) Then
            SendPDIToL2(Me.TailProcessCoilLinkControl.CurrentRunningCoilScanedTreeNode.CoilFullNumber)
        End If

        'APL之PDI訊送出(暫時使用)
        If tabDetailEdit.TabPages.Count > 0 AndAlso tabDetailEdit.TabPages.Item(0).Controls.Count > 0 AndAlso TypeOf tabDetailEdit.TabPages.Item(0).Controls(0) Is APL Then
            Dim FirstAPLFirstControl As APL = tabDetailEdit.TabPages.Item(0).Controls(0)
            FirstAPLFirstControl.SendPDIMsg(False)
        End If

    End Sub

    Private Sub TreeView1_AfterCollapse(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCollapse
        TreeView1.ExpandAll()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        RefreshEnableButton(False)
    End Sub

    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles TreeView1.DoubleClick
        If Not IsNothing(TreeView1.SelectedNode) AndAlso Not TypeOf (TreeView1.SelectedNode) Is CoilScanedTreeNode Then
            ReSortRunCoilsOrder()   '重整顯示鋼捲執行順序
            TreeView1.ExpandAll()
        End If
    End Sub


    Private Sub btnChgSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.SaveControlValueToOperationPCRunningState()
    End Sub

    Private Sub btnClearCoils_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearCoils.Click
        If IsNothing(Me.TreeView1.SelectedNode) OrElse Not TypeOf Me.TreeView1.SelectedNode Is CoilScanedTreeNode OrElse MsgBox("是否確定移除鋼捲?", vbYesNo, "注意") = MsgBoxResult.No Then
            Exit Sub
        End If
        '移除暫存資料庫中本站鋼捲號碼之生技扣帳狀態
        If Not IsNothing(CType(Me.TreeView1.SelectedNode, CoilScanedTreeNode).MyPPSSHAPFFlowAdapter) Then
            CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningStateDetail.DeleteOperationPCRunningStateDetailFromDB(Me.CurrentOperationPCRunningState, CType(Me.TreeView1.SelectedNode, CoilScanedTreeNode).MyPPSSHAPFFlowAdapter.CoilFullNumber)
        End If
        Me.TreeView1.SelectedNode.Parent.Nodes.Remove(Me.TreeView1.SelectedNode)
        Me.SaveControlValueToOperationPCRunningState()
        Me.RefreshEnableButton()
    End Sub

    Private Sub TailProcessCoilLinkControlEvent_BackToWaitArea(ByVal Sender As CoilRunningItem, ByVal NewTailCoilRunningItem As CoilRunningItem) Handles TailProcessCoilLinkControlEvent.BackToWaitArea
        Me.SaveCoilRunningItemEditDataToDB()
        Me.TailProcessCoilLinkControl = NewTailCoilRunningItem
        Select Case Sender.CurrentRunningCoilScanedTreeNode.CoilScanWaitProcessNumber
            Case 1
                Me.TreeView1.Nodes(0).Nodes.Insert(0, Sender.CurrentRunningCoilScanedTreeNode)
            Case 2
                Me.TreeView1.Nodes(1).Nodes.Insert(0, Sender.CurrentRunningCoilScanedTreeNode)
        End Select

        '加回生技未派工數量
        Dim FindMoveState As CompanyORMDB.SQLServer.PPS100LB.CoilMoveState = CompanyORMDB.SQLServer.PPS100LB.CoilMoveState.FindCoilMoveState(PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.RunningPCIP.Trim, Sender.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.CoilFullNumber)
        If Not IsNothing(FindMoveState) Then
            FindMoveState.CDBDelete()
        End If

        '刪除編輯中所有RunProcessData資料
        Call DeleteOrMoveCoilRunningItemEditData(DeleteCoilRunningItemType.BeforeCoilStart, Sender)

        Me.RefreshDisplayProcessCoilLinkControls()
        Me.SaveControlValueToOperationPCRunningState(False)
        Me.RefreshEnableButton()
        TreeView1.Focus()
        TreeView1.ExpandAll()
    End Sub


    Private Sub TailProcessCoilLinkControlEvent_EditAndShowDetailData(ByVal Sender As CoilRunningItem) Handles TailProcessCoilLinkControlEvent.EditAndShowDetailData
        Me.SaveCoilRunningItemEditDataToDB()
        Me.CurrentEditCoilRunningItem = Sender
        RaiseEvent CurrentCoilRunningItemEditEvent(Sender)
        If Not String.IsNullOrEmpty(Me.tsslMessage.Text) Then
            MsgBox(Me.tsslMessage.Text)
        End If
    End Sub

    Private Sub TailProcessCoilLinkControlEvent_FinishProcess(ByVal Sender As CoilRunningItem, ByVal NewTailCoilRunningItem As CoilRunningItem) Handles TailProcessCoilLinkControlEvent.FinishProcess
        'APL之PDI訊送出(暫時使用)
        If tabDetailEdit.TabPages.Count > 0 AndAlso tabDetailEdit.TabPages.Item(0).Controls.Count > 0 AndAlso TypeOf tabDetailEdit.TabPages.Item(0).Controls(0) Is APL Then
            Dim FirstAPLFirstControl As APL = tabDetailEdit.TabPages.Item(0).Controls(0)
            FirstAPLFirstControl.SendPDIMsg(False)
        End If

        Me.SaveCoilRunningItemEditDataToDB()
        Me.RefreshBreakNumberAndCoilEndSave(True)  '重整鋼捲號碼及儲存CoilEnd時間
        Me.LoadCoilRunningItemEditDataFromDB(CurrentEditCoilRunningItem)
        If Not Sender Is CurrentEditCoilRunningItem Then
            CurrentEditCoilRunningItem = Sender
        End If
        If Me.CurrentEditRunProcessDatas.Count >= 1 AndAlso Me.CurrentOperationPCRunningState.IsTheOperationPCRunningStateForThisMachine Then
            Dim IsAPLFinishToStockCoil As Boolean = False  '= (Me.CurrentUesStationName.PadRight(3).Substring(0, 3) = "APL" AndAlso Me.CurrentEditRunProcessDatas.Count > 1)     '判斷是否為AP2繳庫,如果有分捲一定是要繳庫,如是則印4份標籤
            '如果為APL成品繳庫,如是則印6份標籤
            If Me.CurrentUesStationName.PadRight(3).Substring(0, 3) = "APL" AndAlso Not IsNothing(Me.CurrentEditRunProcessDatas(Me.CurrentEditRunProcessDatas.Count - 1).IsFinishProduct) AndAlso Me.CurrentEditRunProcessDatas(Me.CurrentEditRunProcessDatas.Count - 1).IsFinishProduct = True Then
                IsAPLFinishToStockCoil = True
            End If
            If IsAPLFinishToStockCoil = False Then
                Dim GetLastRefPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = Sender.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.AboutAS400PPSSHAPFs.LastOrDefault '= Me.CurrentEditRunProcessDatas(Me.CurrentEditRunProcessDatas.Count - 1).AboutLastOutPPSSHAPF
                IsAPLFinishToStockCoil = (Me.CurrentUesStationName.PadRight(3).Substring(0, 3) = "APL" AndAlso Not IsNothing(GetLastRefPPSSHAPF) AndAlso GetLastRefPPSSHAPF.SHA36 = "A")
            End If

            Select Case True
                Case IsAPLFinishToStockCoil AndAlso Me.CurrentUesStationName.PadRight(3).Substring(0, 4) = "APL1"
                    UnUIPrint.UnUIQuickPrint(Me.CurrentEditRunProcessDatas(Me.CurrentEditRunProcessDatas.Count - 1), Me.CurrentUseingStationRadioButton.Text, 6)   'APL1成品列印條碼6張
                Case IsAPLFinishToStockCoil
                    UnUIPrint.UnUIQuickPrint(Me.CurrentEditRunProcessDatas(Me.CurrentEditRunProcessDatas.Count - 1), Me.CurrentUseingStationRadioButton.Text, 4)   'APL2成品列印條碼4張
                Case Else
                    UnUIPrint.UnUIQuickPrint(Me.CurrentEditRunProcessDatas(Me.CurrentEditRunProcessDatas.Count - 1), Me.CurrentUseingStationRadioButton.Text, 2)   '其它產線列印條碼2張
            End Select
        End If



        Me.TailProcessCoilLinkControl = NewTailCoilRunningItem
        '搬移鋼捲至等待編輯區並將編輯中所有RunProcessData資料狀態改為CoilEnd
        Call DeleteOrMoveCoilRunningItemEditData(DeleteCoilRunningItemType.AfterCoilEnd, Sender)

        Me.RefreshDisplayProcessCoilLinkControls()
        Me.SaveControlValueToOperationPCRunningState(False)
        Me.RefreshEnableButton()
        TreeView1.Focus()
        If cbAutoCoilStart.Checked Then '判斷檔COILEND發生時是否要自動產生CoilStart訊號
            '判斷是目前選的節點是否未在準備線節點上,如果沒有則自動調整選取所屬之準備線節點
            If Not IsNothing(Me.TreeView1.SelectedNode) AndAlso TypeOf Me.TreeView1.SelectedNode.Parent Is TreeNode Then
                Me.TreeView1.SelectedNode = Me.TreeView1.SelectedNode.Parent
            End If
            Call PBCoilStart_Click(PBCoilStart, Nothing)
        End If
        RaiseEvent CoilEnd(Sender.CurrentRunningCoilScanedTreeNode, Me)

    End Sub

    Private Sub TailProcessCoilLinkControlEvent_CoilOrderChanged(Sender As CoilRunningItem, NewTailLeftToHeadRightAllCoilRunningItems As List(Of CoilRunningItem)) Handles TailProcessCoilLinkControlEvent.CoilOrderChanged
        Me.SaveControlValueToOperationPCRunningState(False)
        ReSortRunCoilsOrder()   '重整顯示鋼捲執行順序
    End Sub


    Private Sub btInputCoilNumber_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles btInputCoilNumber.KeyDown
        If e.KeyData = Keys.Enter AndAlso btnManualAddCoil.Enabled Then
            Call btnManualAddCoil_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btInputCoilNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInputCoilNumber.TextChanged
        RefreshEnableButton()
    End Sub

    Private Sub btnCoilMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCoilMoveUp.Click, btnCoilMoveDown.Click
        Dim MoveNode As TreeNode = Me.TreeView1.SelectedNode
        Dim MoveNodeParentNode As TreeNode = Me.TreeView1.SelectedNode.Parent
        Dim MoveToIndex As Integer = MoveNodeParentNode.Nodes.IndexOf(IIf(sender Is btnCoilMoveUp, MoveNode.PrevNode, MoveNode.NextNode))
        MoveNode.Parent.Nodes.Remove(MoveNode)
        MoveNodeParentNode.Nodes.Insert(MoveToIndex, MoveNode)
        Me.TreeView1.SelectedNode = MoveNode
        Me.SaveControlValueToOperationPCRunningState()
        RefreshEnableButton()
    End Sub

    Private Sub btnManualAddCoil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManualAddCoil.Click, btnManualInsertCoil.Click
        Try
            If sender Is btnManualInsertCoil AndAlso Not IsNothing(TreeView1.SelectedNode) AndAlso TypeOf TreeView1.SelectedNode Is CoilScanedTreeNode Then
                Call ScanOrManualAddCoil(btInputCoilNumber.Text.Trim, IIf(rbLine1CoilInpupt.Checked, 1, 2), TreeView1.SelectedNode)
            Else
                Call ScanOrManualAddCoil(btInputCoilNumber.Text.Trim, IIf(rbLine1CoilInpupt.Checked, 1, 2))
            End If
            Me.SaveControlValueToOperationPCRunningState()
            btInputCoilNumber.Text = Nothing
            RefreshEnableButton()
            TreeView1.ExpandAll()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnCoilMoveOtherLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCoilMoveOtherLine.Click
        If IsNothing(Me.TreeView1.SelectedNode) OrElse Not (TypeOf TreeView1.SelectedNode Is CoilScanedTreeNode) Then
            Exit Sub
        End If
        Dim SelectNode As CoilScanedTreeNode = TreeView1.SelectedNode
        Select Case True
            Case SelectNode.Parent Is Me.TreeView1.Nodes(0)
                SelectNode.Parent.Nodes.Remove(SelectNode)
                Me.TreeView1.Nodes(1).Nodes.Add(SelectNode)
                SelectNode.CoilScanWaitProcessNumber = 2
            Case (SelectNode.Parent Is Me.TreeView1.Nodes(1))
                SelectNode.Parent.Nodes.Remove(SelectNode)
                Me.TreeView1.Nodes(0).Nodes.Add(SelectNode)
                SelectNode.CoilScanWaitProcessNumber = 1
        End Select
        Me.SaveControlValueToOperationPCRunningState()
        RefreshEnableButton()
        Me.TreeView1.SelectedNode = SelectNode
    End Sub

    Private Sub btClearCoils_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClearCoils.Click
        If rbLine1CoilInpupt.Checked AndAlso TreeView1.Nodes(0).Nodes.Count > 0 AndAlso MsgBox("是否確定清除上線鋼捲(合計" & TreeView1.Nodes(0).Nodes.Count & "筆資料)?", MsgBoxStyle.YesNo, "注意!") = MsgBoxResult.Yes Then
            '移除暫存資料庫中本站鋼捲號碼之生技扣帳狀態
            For Each EachItem In Me.TreeView1.Nodes(0).Nodes
                CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningStateDetail.DeleteOperationPCRunningStateDetailFromDB(Me.CurrentOperationPCRunningState, EachItem.MyPPSSHAPFFlowAdapter.CoilFullNumber)
            Next
            Me.TreeView1.Nodes(0).Nodes.Clear()
        End If
        If rbLine2CoilInpupt.Checked AndAlso TreeView1.Nodes(1).Nodes.Count > 0 AndAlso MsgBox("是否確定清除下線鋼捲(合計" & TreeView1.Nodes(1).Nodes.Count & "筆資料)?", MsgBoxStyle.YesNo, "注意!") = MsgBoxResult.Yes Then
            '移除暫存資料庫中本站鋼捲號碼之生技扣帳狀態
            For Each EachItem In Me.TreeView1.Nodes(1).Nodes
                CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningStateDetail.DeleteOperationPCRunningStateDetailFromDB(Me.CurrentOperationPCRunningState, EachItem.MyPPSSHAPFFlowAdapter.CoilFullNumber)
            Next
            Me.TreeView1.Nodes(1).Nodes.Clear()
        End If

        Me.SaveControlValueToOperationPCRunningState()
        RefreshEnableButton()
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        Static PreSelectTabPage As TabPage = Nothing
        Me.SaveControlValueToOperationPCRunningState()
        If Not TabControl1.SelectedTab Is tpSetSysConfig Then
            TableLayoutPanel2.Enabled = False
            TableLayoutPanel4.Enabled = TableLayoutPanel2.Enabled
            Me.LoadDBOperationPCRunningStateToControlValue()
            If TabControl1.SelectedTab Is tpMainOperator Then
                Try
                    ReStartRS232()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                If Me.CurrentOperationPCRunningState.IsStopL2MsgTalk Then
                    L2MessageWatchControl.StopWatch()
                Else
                    L2MessageWatchControl.StartWatch()
                End If
                If Me.CurrentOperationPCRunningState.IsStopPDOMsgTalk Then
                    L2PDOMessageWatchControl.StopWatch()
                Else
                    L2PDOMessageWatchControl.StartWatch()
                End If
            End If
        End If

        If TabControl1.SelectedTab Is tpZMLWorkConfig Then
            If tpZMLWorkConfig.Controls.Count = 0 Then
                tpZMLWorkConfig.Controls.Add(Me.CurrentEditZMLOperationPCRunningStateControl)
                Me.CurrentEditZMLOperationPCRunningStateControl.Dock = DockStyle.Fill
            End If
            Me.CurrentEditZMLOperationPCRunningStateControl.Enabled = (Me.CurrentOperationPCRunningState.DefaultUseStationName.PadRight(3).Substring(0, 3) = "ZML")
        End If

        If Not IsNothing(PreSelectTabPage) AndAlso Not IsNothing(Me.CurrentEditZMLOperationPCRunningStateControl) AndAlso PreSelectTabPage Is tpZMLWorkConfig Then
            Me.CurrentEditZMLOperationPCRunningStateControl.DataEndEditAndSave()
        End If
        PreSelectTabPage = e.TabPage
    End Sub

    Private Sub speLine1RS232_DataReceivFinishedEx(ByVal Sender As System.IO.Ports.SerialPort, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs, ByVal ReceiveData As String) Handles speLine1RS232.DataReceivFinishedEx
        Static LastReceiveDataTime As DateTime
        If Now.Subtract(LastReceiveDataTime).TotalSeconds <= 2 Then
            Exit Sub
        End If
        LastReceiveDataTime = Now
        tsslMessage.Text = ReceiveData
        If tsslMessage.Text.Length = 10 AndAlso tsslMessage.Text.Substring(0, 5) = tsslMessage.Text.Substring(5, 5) Then
            tsslMessage.Text = tsslMessage.Text.Substring(0, 5)   '掃描資料異常處理 EX:A1234A1234 
        End If
        If Not String.IsNullOrEmpty(ReceiveData) AndAlso ReceiveData.Substring(0, 1) = "$" Then
            If rbLine2CoilInpupt.Visible Then
                rbLine1CoilInpupt.Checked = (ReceiveData.ToUpper.Trim = "$UP")
                rbLine2CoilInpupt.Checked = Not rbLine1CoilInpupt.Checked
            Else
                rbLine1CoilInpupt.Checked = True
            End If
            Application.DoEvents()
            Exit Sub
        End If
        Call ScanOrManualAddCoil(ReceiveData.Trim, IIf(rbLine1CoilInpupt.Checked, 1, 2))
        Me.SaveControlValueToOperationPCRunningState()
        RefreshEnableButton()
        TreeView1.ExpandAll()
        Application.DoEvents()
    End Sub

    Private Sub tsbAddBreadkCoil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAddBreadkCoil.Click
        'APL之PDI訊送出(暫時使用)
        If tabDetailEdit.TabPages.Count > 0 AndAlso tabDetailEdit.TabPages.Item(0).Controls.Count > 0 AndAlso TypeOf tabDetailEdit.TabPages.Item(0).Controls(0) Is APL Then
            Dim FirstAPLFirstControl As APL = tabDetailEdit.TabPages.Item(0).Controls(0)
            FirstAPLFirstControl.SendPDIMsg(False)
        End If


        Me.SaveCoilRunningItemEditDataToDB()
        Dim AddCoilResult As Boolean = Me.AddCoilRunningItemEditData(CurrentEditCoilRunningItem)
        Me.LoadCoilRunningItemEditDataFromDB(CurrentEditCoilRunningItem)
        Me.SaveControlValueToOperationPCRunningState()
        Me.tabDetailEdit.SelectedIndex = Me.tabDetailEdit.TabPages.Count - 1
        If AddCoilResult AndAlso Me.CurrentOperationPCRunningState.IsTheOperationPCRunningStateForThisMachine Then
            '如果為APL成品繳庫,如是則印4份標籤
            Dim IsAP2FinishToStockCoil As Boolean = False
            If Me.CurrentUesStationName.PadRight(3).Substring(0, 3) = "APL" AndAlso Not IsNothing(Me.CurrentEditRunProcessDatas(Me.CurrentEditRunProcessDatas.Count - 2).IsFinishProduct) AndAlso Me.CurrentEditRunProcessDatas(Me.CurrentEditRunProcessDatas.Count - 2).IsFinishProduct = True Then
                IsAP2FinishToStockCoil = True
            End If
            UnUIPrint.UnUIQuickPrint(Me.CurrentEditRunProcessDatas(Me.CurrentEditRunProcessDatas.Count - 2), Me.CurrentUseingStationRadioButton.Text, IIf(IsAP2FinishToStockCoil, 4, 2))   '列印條碼

        End If
        If Not String.IsNullOrEmpty(Me.tsslMessage.Text) Then
            MsgBox(Me.tsslMessage.Text)
        End If
    End Sub

    Private Sub tsbDelBreadkCoil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelBreadkCoil.Click
        If MsgBox("是否確定要刪除此筆分捲資料?", MsgBoxStyle.YesNo, "注意!") = MsgBoxResult.No Then
            Exit Sub
        End If
        If DeleteOrMoveCoilRunningItemEditData(DeleteCoilRunningItemType.CoilStarting, Me.CurrentEditCoilRunningItem) Then
            Me.LoadCoilRunningItemEditDataFromDB(CurrentEditCoilRunningItem)
            Me.SaveControlValueToOperationPCRunningState()
        End If
        Me.tabDetailEdit.SelectedIndex = Me.tabDetailEdit.TabPages.Count - 1
        If Not String.IsNullOrEmpty(Me.tsslMessage.Text) Then
            MsgBox(Me.tsslMessage.Text)
        End If
    End Sub


    Private Sub NoticeToReReadOperationPCRunningStateEventDelegateFun()
        LoadDBOperationPCRunningStateToControlValue()
        RefreshEnableButton()
        TreeView1.ExpandAll()
    End Sub

    Private Sub tsbShowOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbShowOrder.Click
        If Not IsNothing(Me.CurrentEditCoilRunningItem) Then
            Dim ShowOrderControl As New ShowOrderDialog
            ShowOrderControl.Show(Me.ParentForm, Me.CurrentEditCoilRunningItem.CurrentRunningCoilScanedTreeNode)
        End If
    End Sub

    Private Sub tsbShowHistoryProcess_Click(sender As System.Object, e As System.EventArgs) Handles tsbShowHistoryProcess.Click
        If Not IsNothing(Me.CurrentEditCoilRunningItem) Then
            Dim ShowHistoryProcessControl As New ShowHistoryProcessDialog
            ShowHistoryProcessControl.Show(Me.ParentForm, Me.CurrentEditCoilRunningItem.CurrentRunningCoilScanedTreeNode)
        End If
    End Sub

    Private Sub btnInputChangePWD_Click(sender As System.Object, e As System.EventArgs) Handles btnInputChangePWD.Click
        TableLayoutPanel2.Enabled = (tbInputPWD.Text.Trim = "1j4@vu.4")
        TableLayoutPanel4.Enabled = TableLayoutPanel2.Enabled
        tbInputPWD.Text = Nothing
    End Sub

    Private Sub tsbManualBarCodePrint_Click(sender As System.Object, e As System.EventArgs) Handles tsbManualBarCodePrint.Click
        ShowLabelPrintDialog.Show(TailProcessCoilLinkControl, Me, Me.ParentForm)
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton21.CheckedChanged, RadioButton22.CheckedChanged, RadioButton23.CheckedChanged, RadioButton24.CheckedChanged
        Dim IsHaveCoilScanedTreeNodeSelected As Boolean = (Not IsNothing(TreeView1.SelectedNode)) AndAlso (TypeOf TreeView1.SelectedNode Is CoilScanedTreeNode)
        If IsHaveCoilScanedTreeNodeSelected Then
            Dim SelectTreeNode As CoilScanedTreeNode = TreeView1.SelectedNode
            Dim SetValue As Single = CType(sender, RadioButton).Text.Substring(0, 1)
            Dim FindOperationPCRunningStateDetail As OperationPCRunningStateDetail = OperationPCRunningStateDetail.FindOperationPCRunningStateDetail(PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.RunningPCIP.Trim, SelectTreeNode.CoilFullNumber)
            If Not IsNothing(FindOperationPCRunningStateDetail) Then
                FindOperationPCRunningStateDetail.Set_PlanProductionDisplay_CIW06Value = SetValue
                FindOperationPCRunningStateDetail.CDBSave()
            End If
        End If
    End Sub

    Private TFlashControlStateLastChangeTime As CompanyORMDB.SQLServer.PPS100LB.StationDataLastChangeTime = CompanyORMDB.SQLServer.PPS100LB.StationDataLastChangeTime.FindStationDataLastChangeTimeForIP(Me.CurrentOperationPCRunningState.RunningPCIP)
    Private Sub TFlashControlState_Tick(sender As System.Object, e As System.EventArgs) Handles TFlashControlState.Tick
        mut.WaitOne()
        Try

            Dim LastSaveStationDataLastChangeTime As CompanyORMDB.SQLServer.PPS100LB.StationDataLastChangeTime = Me.LastSaveStationDataLastChangeTime
            TFlashControlStateLastChangeTime = CompanyORMDB.SQLServer.PPS100LB.StationDataLastChangeTime.FindStationDataLastChangeTimeForIP(Me.CurrentOperationPCRunningState.RunningPCIP)
            If IsNothing(LastSaveStationDataLastChangeTime) OrElse IsNothing(TFlashControlStateLastChangeTime) Then
                Exit Sub
            End If
            Dim PreEditCoilRunningItem As CoilRunningItem = Nothing
            Select Case True
                Case LastSaveStationDataLastChangeTime.OperationPCRunningStateSaveTime <> TFlashControlStateLastChangeTime.OperationPCRunningStateSaveTime
                    Me.LastSaveStationDataLastChangeTime = TFlashControlStateLastChangeTime
                    PreEditCoilRunningItem = Me.CurrentEditCoilRunningItem
                    tabDetailEdit.TabPages.Clear()
                    LoadDBOperationPCRunningStateToControlValue()
                    Me.RefreshDisplayProcessCoilLinkControls()
                    Me.RefreshEnableButton()
                    RaiseEvent SaveStationDataLastChangeTimeEvent(LastSaveStationDataLastChangeTime, TFlashControlStateLastChangeTime, Me)
                Case LastSaveStationDataLastChangeTime.OperationPCRunningStateDetailSaveTime <> TFlashControlStateLastChangeTime.OperationPCRunningStateDetailSaveTime
                    RefreshEnableButton()
            End Select

            If Not IsNothing(PreEditCoilRunningItem) Then   '恢復使用者之前正在編修的鋼捲
                Dim AllRunCoilRunningItems As List(Of CoilRunningItem) = CoilRunningItem.GetTailToHeadCoilRunningItems(TailProcessCoilLinkControl)
                For Each EachItem As CoilRunningItem In AllRunCoilRunningItems
                    If EachItem.CurrentRunningCoilScanedTreeNode.CoilFullNumber = PreEditCoilRunningItem.CurrentRunningCoilScanedTreeNode.CoilFullNumber Then
                        Me.CurrentEditCoilRunningItem = PreEditCoilRunningItem
                        Exit For
                    End If
                Next
            End If
            TFlashControlState.Interval = 3000
        Catch ex As Exception
            TFlashControlState.Interval = 10000 '當發生異常時改以十秒後再更新一次
        Finally
            mut.ReleaseMutex()
        End Try
    End Sub

    Private Sub tbInputPWD_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbInputPWD.KeyDown
        If e.KeyData = Keys.Enter Then
            Call btnInputChangePWD_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub rbMode1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles rbMode1.MouseUp, rbMode2.MouseUp
        Static TheProcessRunning As Boolean = False
        If Not TabControl1.SelectedTab Is tpSetSysConfig OrElse TheProcessRunning Then
            Exit Sub
        End If
        TheProcessRunning = True
        Dim GetTheMachinePCRunningState As OperationPCRunningState = Me.TheMachinePCRunningState
        tsslMessage.Text = ""
        If rbMode2.Checked Then
            GetTheMachinePCRunningState.ClientRunningMode = 1
            GetTheMachinePCRunningState.ClientRemoteToServerIP = tbRemoteToServerIP.Text.Trim
            If IsNothing(GetTheMachinePCRunningState.AboutServerOperationPCRunningState) Then
                GetTheMachinePCRunningState.ClientRunningMode = 0
                GetTheMachinePCRunningState.ClientRemoteToServerIP = ""
                rbMode1.Checked = True
                tsslMessage.Text = "切換用戶端失敗,系統找不到此伺服端狀態資料,系統將本機切換伺服端!"
            End If
        Else
            GetTheMachinePCRunningState.ClientRunningMode = 0
            GetTheMachinePCRunningState.ClientRemoteToServerIP = ""
        End If
        GetTheMachinePCRunningState.CDBSave()
        LoadDBOperationPCRunningStateToControlValue()
        Me.LastSaveStationDataLastChangeTime = StationDataLastChangeTime.FindStationDataLastChangeTimeForIP(Me.CurrentOperationPCRunningState.RunningPCIP)
        'Me.RefreshDisplayProcessCoilLinkControls()
        'Me.RefreshEnableButton()
        TheProcessRunning = False
    End Sub

    Private Sub L2MessageWatchControlEvent_FileChangedEvent(sender As Object, e As IO.FileSystemEventArgs, L2Message As L2Message) Handles L2MessageWatchControlEvent.FileChangedEvent
        Dim cb As New ProcessL2MessageAndUpdateUI(AddressOf ProcessL2Message)
        Me.BeginInvoke(cb, L2Message)
    End Sub

    Private Sub L2PDOMessageWatchControlEvent_FileChangedEvent(sender As Object, e As IO.FileSystemEventArgs, L2PDOMessages As L2PDOMessage) Handles L2PDOMessageWatchControlEvent.FileChangedEvent
        Dim cb As New ProcessL2PDOMessageAndUpdateUI(AddressOf ProcessL2PDOMessage)
        Me.BeginInvoke(cb, L2PDOMessages)
    End Sub

    Private Sub tabDetailEdit_Deselecting(sender As Object, e As TabControlCancelEventArgs) Handles tabDetailEdit.Deselecting
        If Not IsNothing(e.TabPage) AndAlso e.TabPage.Controls.Count > 0 Then
            Dim SelControl As IStationRunningControl = e.TabPage.Controls(0)
            SelControl.DataEndEditAndSave()
        End If
    End Sub

End Class
