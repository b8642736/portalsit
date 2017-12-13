Public Class QCTLL
    Implements IQCControl
    Dim IsInProgrammerTestMode As Boolean = False    '系統測試測間設為True以免發送出Email

    Public WithEvents AboutCoilScanAndMachineProcessEvent As CoilScanAndMachineProcess


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
            AboutCoilScanAndMachineProcessEvent = _AboutCoilScanAndMachineProcess
            If IsNothing(_AboutCoilScanAndMachineProcess) OrElse IsNothing(_AboutCoilScanAndMachineProcess.CurrentEditCoilRunningItem) OrElse IsNothing(EditCoilTreeNode) Then
                EditCoilTreeNode = Nothing
                Me.QCTitleData = Nothing
                Me.QCTitleDataDetail = Nothing
                ReloadDataToControl()
                RefreshShowEnableControl()
                Exit Property
            End If
            SearchQCDataForTreeNode(EditCoilTreeNode)
            If IsNothing(Me.QCTitleData) OrElse IsNothing(Me.QCTitleDataDetail) OrElse Me.QCTitleDataDetail.Count < 3 Then
                InitialTheStationData()
            End If
            RefreshShowEnableControl()
        End Set
    End Property

#End Region
#Region "編修鋼捲節點項目 屬性:EditCoilTreeNode"
    Private _EditCoilTreeNode As CoilScanedTreeNode
    ''' <summary>
    ''' 編修鋼捲節點項目
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property EditCoilTreeNode() As CoilScanedTreeNode
        Get
            If IsNothing(_EditCoilTreeNode) Then
                If Not IsNothing(_AboutCoilScanAndMachineProcess) AndAlso Not IsNothing(_AboutCoilScanAndMachineProcess.CurrentEditCoilRunningItem) Then
                    _EditCoilTreeNode = _AboutCoilScanAndMachineProcess.CurrentEditCoilRunningItem.CurrentRunningCoilScanedTreeNode
                Else
                    _EditCoilTreeNode = Nothing
                End If
            End If
            Return _EditCoilTreeNode
        End Get
        Set(value As CoilScanedTreeNode)
            _EditCoilTreeNode = value
        End Set
    End Property
#End Region
#Region "品檢資料明細 屬性:QCTitleData"
    Private _QCTitleData As RunProcessQCTitle
    ''' <summary>
    ''' 品檢資料明細
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property QCTitleData As RunProcessQCTitle
        Get
            Return _QCTitleData
        End Get
        Private Set(value As RunProcessQCTitle)
            _QCTitleData = value
        End Set
    End Property
#End Region
#Region "品檢資料表頭 屬性:QCTitleDataDetail"
    Private _QCTitleDataDetail As List(Of RunProcessQCDetail)
    ''' <summary>
    ''' 品檢資料表頭
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property QCTitleDataDetail As List(Of RunProcessQCDetail)
        Get
            If IsNothing(_QCTitleDataDetail) Then
                _QCTitleDataDetail = New List(Of RunProcessQCDetail)
            End If
            Return _QCTitleDataDetail
        End Get
        Private Set(value As List(Of RunProcessQCDetail))
            _QCTitleDataDetail = value
        End Set
    End Property
#End Region
#Region "未有本站資料前初始新增本站資料 函式:InitialTheStationData"
    ''' <summary>
    ''' 未有本站資料前初始新增本站資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitialTheStationData()

        If IsNothing(QCTitleData) Then
            If IsNothing(EditCoilTreeNode) Then
                QCTitleData = Nothing
                QCTitleDataDetail = Nothing
                Exit Sub
            End If
            If IsNothing(EditCoilTreeNode.MyPPSSHAPFFlowAdapter) Then
                QCTitleData = Nothing
                QCTitleDataDetail = Nothing
                Exit Sub
            End If
            Dim RefRunProcessData As RunProcessData = EditCoilTreeNode.Tag
            If IsNothing(RefRunProcessData) Then
                If EditCoilTreeNode.MyPPSSHAPFFlowAdapter.AboutRunProcessDatas.Count = 0 Then
                    Exit Sub
                Else
                    RefRunProcessData = (From A As RunProcessData In EditCoilTreeNode.MyPPSSHAPFFlowAdapter.AboutRunProcessDatas Select A Order By A.SysCoilStartTime Descending).FirstOrDefault
                End If
            End If



            If IsNothing(RefRunProcessData) Then
                QCTitleData = Nothing
                QCTitleDataDetail = Nothing
                Exit Sub
            End If
            'Dim RunProcessData As RunProcessData = RunProcessDatas(0)
            'Dim RunProcessData As RunProcessData = RefRunProcessData
            QCTitleData = New CompanyORMDB.SQLServer.PPS100LB.RunProcessQCTitle
            With QCTitleData
                .FK_RunProcessDataID = RefRunProcessData.ID
                .FK_LastRefSHA01 = RefRunProcessData.FK_LastRefSHA01
                .FK_LastRefSHA02 = RefRunProcessData.FK_LastRefSHA02
                .FK_LastRefSHA04 = RefRunProcessData.FK_LastRefSHA04
                .SysCoilStartTime = RefRunProcessData.SysCoilStartTime
                .RunStationName = RefRunProcessData.FK_RunStationName
                .RunStationPCIP = CompanyORMDB.DeviceInformation.GetLocalIPs(0).Trim
                .UserCheckTime = "2000/1/1"
            End With

            If QCTitleData.CDBSave = 0 Then
                QCTitleData = Nothing
                QCTitleDataDetail = Nothing
                Exit Sub
            Else
                QCTitleDataDetail = QCTitleData.AboutRunProcessQCDetail
            End If
        End If


        Dim QryString As String = "Select * from QABugRecordTitle Where CoilNumber='" & Trim(QCTitleData.FK_LastRefSHA01 & QCTitleData.FK_LastRefSHA02) & "' AND ConvertToAS400Time>='2010/1/1' Order by ConvertToAS400Time Desc , CoilStartTime Desc"
        '測試用
        'Dim QryString As String = "Select * from QABugRecordTitle Where CoilNumber='" & Trim(QCTitleData.FK_LastRefSHA01 & QCTitleData.FK_LastRefSHA02) & "' Order by ConvertToAS400Time Desc , CoilStartTime Desc"
        Dim QCData As CompanyORMDB.SQLServer.PPS100LB.QABugRecordTitle = (From A In QABugRecordTitle.CDBSelect(Of QABugRecordTitle)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString) Select A).FirstOrDefault

        If QCTitleDataDetail.Count < 3 Then
            For EachRowGroup As Integer = 1 To 3
                Dim EachRowGroupTemp As Integer = EachRowGroup
                If (From A In QCTitleDataDetail Where A.RowGroup = EachRowGroupTemp Select A).Count > 0 Then
                    Continue For
                End If
                If Not IsNothing(QCData) AndAlso QCData.CoilMaxLength > 150 AndAlso QCData.CoilMaxLength < 9999 Then
                    Dim CoilMaxLength As Double = QCData.CoilMaxLength
                    For Each EachDefaultBug As QABUG In Me.TheStationCanUseBugDefines(False)
                        Dim AddItem As New RunProcessQCDetail
                        With AddItem
                            .FK_RunProcessDataID = _QCTitleData.FK_RunProcessDataID
                            .IsUpLineBug = False
                            .IsBugHappen = False
                            .QABugNumber = EachDefaultBug.Number.Trim
                            .RowGroup = EachRowGroup
                            .SaveTime = Now
                            Select Case EachRowGroup
                                Case 1
                                    .StartPosition = 30
                                    .EndPosition = 100
                                Case 2
                                    .StartPosition = CoilMaxLength / 2 - 35
                                    .EndPosition = CoilMaxLength / 2 + 35
                                Case 3
                                    .StartPosition = CoilMaxLength - 100
                                    .EndPosition = CoilMaxLength - 30
                            End Select

                            QCTitleDataDetail.Add(AddItem)

                        End With
                    Next
                Else
                    For Each EachDefaultBug As QABUG In Me.TheStationCanUseBugDefines(False)
                        Dim AddItem As New RunProcessQCDetail
                        With AddItem
                            .FK_RunProcessDataID = _QCTitleData.FK_RunProcessDataID
                            .IsUpLineBug = False
                            .IsBugHappen = False
                            .QABugNumber = EachDefaultBug.Number.Trim
                            .RowGroup = EachRowGroup
                            .SaveTime = Now
                            Select Case EachRowGroup
                                Case 1
                                    .StartPosition = 1
                                    .EndPosition = 99
                                Case 2
                                    .StartPosition = 100
                                    .EndPosition = 199
                                Case 3
                                    .StartPosition = 200
                                    .EndPosition = 299
                            End Select
                            QCTitleDataDetail.Add(AddItem)
                        End With
                    Next

                End If
            Next
        End If
        ReloadDataToControl()
    End Sub
#End Region
#Region "本線可使用缺陷定義 屬性:TheStationCanUseBugDefines(各線修改程式時此段程式碼會不同)"
    Private _TheStationCanUseBugDefines As List(Of QABUG)
    Private _TempDatas As List(Of QABUG)
    ''' <summary>
    ''' 本線可使用缺陷定義
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TheStationCanUseBugDefines(Optional IsUpLineBug As Boolean = False) As List(Of QABUG)
        Get
            If IsNothing(_TempDatas) Then
                Dim QryString As String = "Select * from QABUG "
                _TempDatas = QABUG.CDBSelect(Of QABUG)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
            End If

            If Not IsNothing(_TempDatas) AndAlso _TempDatas.Count > 0 Then
                If IsUpLineBug Then
                    _TheStationCanUseBugDefines = (From A In _TempDatas Where A.TLLUseSortUpLineNumber > 0 Order By A.TLLUseSortUpLineNumber Select A).ToList
                Else
                    _TheStationCanUseBugDefines = (From A In _TempDatas Where A.TLLUseSortNumber > 0 Order By A.TLLUseSortNumber Select A).ToList
                End If
            Else
                _TheStationCanUseBugDefines = New List(Of QABUG)
            End If
            Return _TheStationCanUseBugDefines
        End Get
    End Property
#End Region
#Region "重新載入資料至制項 函式:ReloadDataToControl"
    ''' <summary>
    ''' 重新載入資料至制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReloadDataToControl()
        If IsNothing(Me.QCTitleData) Then
            Me.bsDefaultGroupBugs.DataSource = Nothing
            tvSelfInsertBugs.Nodes.Clear()
            Exit Sub
        End If

        '顯示畫面上半部資料至控制項
        btnCheckOK.Text = "確認無誤"
        cbIsNoFlap.Checked = Me.QCTitleData.IsNoSmooth
        cbNoticeQCDept.Checked = Me.QCTitleData.IsNoticeQC
        btnCheckOK.Text &= IIf(Me.QCTitleData.IsUserCheckOK, "(已確認)", "")
        Dim RowGroupDatas As List(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessQCDetail) = Nothing
        Dim SetData As New ColdRollingClient.ColdRollingClientDataSet.QCCheckDatasDataTable
        For EachRowGroup As Integer = 1 To 3
            Dim EachRowGroupNum As Integer = EachRowGroup
            RowGroupDatas = (From A In QCTitleDataDetail Where A.RowGroup = EachRowGroupNum Select A).ToList
            If RowGroupDatas.Count = 0 Then
                Continue For
            End If
            Dim SetRowItem As ColdRollingClientDataSet.QCCheckDatasRow = SetData.NewRow
            With SetRowItem
                .RowGroup = EachRowGroup
                If RowGroupDatas.Count > 0 Then
                    .StartPosition = RowGroupDatas(0).StartPosition
                    .EndPosition = RowGroupDatas(0).EndPosition
                End If
                For Each EachColumn As DataGridViewColumn In DataGridView1.Columns
                    Dim FindRunProcessQCDetail As RunProcessQCDetail = (From A In RowGroupDatas Where A.QABugNumber.ToUpper.Trim = EachColumn.ToolTipText.ToUpper.Trim Select A).FirstOrDefault
                    If Not IsNothing(FindRunProcessQCDetail) Then
                        SetRowItem.Item(EachColumn.Name) = FindRunProcessQCDetail.IsBugHappen
                    End If
                Next
            End With
            SetData.Rows.Add(SetRowItem)
        Next
        Me.bsDefaultGroupBugs.DataSource = SetData


        '顯示畫面下半部資料至控制項
        'cbBugList.Items.Clear()
        For Each EachItem As QABUG In TheStationCanUseBugDefines(False)
            cbBugList.Items.Add("本線." & EachItem.Number.ToString.Trim & "." & EachItem.CName.ToString.Trim)
        Next
        For Each EachItem As QABUG In TheStationCanUseBugDefines(True)
            cbBugList.Items.Add("上線." & EachItem.Number.ToString.Trim & "." & EachItem.CName.ToString.Trim)
        Next

        RowGroupDatas = (From A In QCTitleDataDetail Where A.RowGroup = 99 Select A).ToList
        tvSelfInsertBugs.Nodes.Clear()
        'Dim FindBugDefine As QABUG = Nothing
        Dim AddItemText As New StringBuilder
        For Each EachBugDetail As RunProcessQCDetail In RowGroupDatas
            AddItemText.Clear()
            If EachBugDetail.IsUpLineBug Then
                AddItemText.Append("上線.")
            Else
                AddItemText.Append("本線.")
            End If
            Dim FindBugDefine As QABUG = (From A In TheStationCanUseBugDefines(EachBugDetail.IsUpLineBug) Where A.Number.Trim = EachBugDetail.QABugNumber.Trim Select A).FirstOrDefault
            If IsNothing(FindBugDefine) Then
                AddItemText.Append(EachBugDetail.QABugNumber.Trim & ".未知." & EachBugDetail.StartPosition & "~" & EachBugDetail.EndPosition)
            Else
                AddItemText.Append(EachBugDetail.QABugNumber.Trim & "." & FindBugDefine.CName.Trim & "." & EachBugDetail.StartPosition & "~" & EachBugDetail.EndPosition)
            End If
            Dim AddNode As New TreeNode
            AddNode.Text = AddItemText.ToString
            AddNode.Tag = EachBugDetail
            tvSelfInsertBugs.Nodes.Add(AddNode)
        Next

    End Sub
#End Region
#Region "查詢品檢記錄 函式:SearchQCDataForTreeNode"
    ''' <summary>
    ''' 查詢品檢記錄
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SearchQCDataForTreeNode(ByVal setEditCoilTreeNode As CoilScanedTreeNode)
        If IsNothing(setEditCoilTreeNode) OrElse Not IsNothing(setEditCoilTreeNode.MyPPSSHAPFFlowAdapter) _
            AndAlso Not IsNothing(setEditCoilTreeNode.MyPPSSHAPFFlowAdapter.AboutRunProcessDatas) Then

            Dim RefRunProcessData As RunProcessData = setEditCoilTreeNode.Tag
            If IsNothing(RefRunProcessData) Then
                If setEditCoilTreeNode.MyPPSSHAPFFlowAdapter.AboutRunProcessDatas.Count = 0 Then
                    ReloadDataToControl()
                    Exit Sub
                Else
                    RefRunProcessData = (From A In AboutCoilScanAndMachineProcess.CurrentEditCoilRunningItem.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.AboutRunProcessDatas Select A Order By A.SysCoilStartTime Descending).FirstOrDefault
                End If
            End If

            Dim QryString As New StringBuilder
            QryString.Append("Select * from RunProcessQCTitle Where ")
            QryString.Append(" FK_RunProcessDataID='" & RefRunProcessData.ID & "' ")
            Dim SearchResult = CompanyORMDB.SQLServer.PPS100LB.RunProcessQCTitle.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessQCTitle)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString.ToString)
            If SearchResult.Count > 0 Then
                QCTitleData = SearchResult(0)
                If Not IsNothing(QCTitleData) Then
                    QCTitleDataDetail = QCTitleData.AboutRunProcessQCDetail
                End If
            Else
                QCTitleData = Nothing
                QCTitleDataDetail = Nothing
            End If
        Else
            QCTitleData = Nothing
            QCTitleDataDetail = Nothing
        End If
        ReloadDataToControl()
    End Sub

#End Region
#Region "重整顯示控制項 函式:RefreshShowEnableControl"
    ''' <summary>
    ''' 重整顯示控制項
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshShowEnableControl()

        If IsNothing(Me.QCTitleData) Then
            cbIsNoFlap.Enabled = False
            cbNoticeQCDept.Enabled = False
        Else
            cbIsNoFlap.Enabled = True
            cbNoticeQCDept.Enabled = True
        End If

        If Not IsNothing(Me.QCTitleData) AndAlso Val(tbStartPositon.Text) > 0 AndAlso Val(tbEndPosition.Text) > 0 AndAlso _
            Val(tbEndPosition.Text) > Val(tbStartPositon.Text) AndAlso _
            cbBugList.Items.Count > 0 AndAlso Not IsNothing(cbBugList.SelectedItem) Then
            btnAdd.Enabled = True
        Else
            btnAdd.Enabled = False
        End If

        If Not IsNothing(Me.QCTitleData) AndAlso tvSelfInsertBugs.Nodes.Count > 0 Then
            tvSelfInsertBugs.Enabled = True
            If Not IsNothing(tvSelfInsertBugs.SelectedNode) Then
                btnDelete.Enabled = True
            Else
                btnDelete.Enabled = False
            End If
        Else
            tvSelfInsertBugs.Enabled = False
        End If

        If tvSelfInsertBugs.Nodes.Count > 0 AndAlso Not IsNothing(tvSelfInsertBugs.SelectedNode) Then
            btnDelete.Enabled = True
        Else
            btnDelete.Enabled = False
        End If

        If Not IsNothing(Me.EditCoilTreeNode) Then
            lbTitle.Text = "鋼捲:" & Me.EditCoilTreeNode.CoilFullNumber & "  自主品檢品質異常記錄表"
        Else
            lbTitle.Text = "自主品檢品質異常記錄表"
        End If

        btnCheckOK.Text = "確認無誤"
        btnCheckOK.BackColor = Me.BackColor
        If Not IsNothing(Me.QCTitleData) Then
            btnCheckOK.Text &= IIf(Me.QCTitleData.IsUserCheckOK, "(已確認)", "")
            btnCheckOK.BackColor = Color.LightGreen
        End If

        tvSelfInsertBugs.ExpandAll()
        tvSearchResult.ExpandAll()
    End Sub
#End Region
#Region "儲存控制項資料至資料庫 函式:SaveControlValueToDB"
    ''' <summary>
    ''' 儲存控制項資料至資料庫
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveControlValueToDB(ByVal IsUserSelfCheckOK As Boolean)

        If Not IsNothing(Me.QCTitleData) Then
            With Me.QCTitleData
                .IsNoSmooth = cbIsNoFlap.Checked
                .IsNoticeQC = cbNoticeQCDept.Checked
                If IsUserSelfCheckOK Then
                    .IsUserCheckOK = True
                    .UserCheckTime = Now
                End If
                .RunStationName = EditCoilTreeNode.AboutOperationPCRunningState.DefaultUseStationName
                .RunStationPCIP = EditCoilTreeNode.AboutOperationPCRunningState.RunningPCIP
                If .CDBSave > 0 Then
                    RefreshShowEnableControl()
                End If
            End With

            CheckPositionBeforeChangeAndSave()      '偵測位置是否有變更,有則存檔前預先變更並存檔

            Dim IsNewAddBug As Boolean = False
            Dim CellValueChanged As Boolean = False
            Dim SetStartPosition As Long = 0
            Dim SetEndPosition As Long = 0
            Dim SetRowGroup As Long = 0
            For Each EachGridViewRow As DataGridViewRow In DataGridView1.Rows
                SetStartPosition = 0 : SetEndPosition = 0
                SetStartPosition = Val(EachGridViewRow.Cells("StartPosition").Value)
                SetEndPosition = Val(EachGridViewRow.Cells("EndPosition").Value)
                SetRowGroup = Val(EachGridViewRow.Cells("RowGroup").Value)
                For Each EachColumn As DataGridViewColumn In DataGridView1.Columns
                    If Val(EachColumn.ToolTipText.Trim) = 0 Then
                        Continue For
                    End If
                    Dim FindRunProcessQCDetail As RunProcessQCDetail = (From A In Me.QCTitleDataDetail Where A.QABugNumber.ToUpper.Trim = EachColumn.ToolTipText.ToUpper.Trim And A.RowGroup = SetRowGroup Select A).FirstOrDefault
                    IsNewAddBug = False
                    CellValueChanged = False
                    If IsNothing(FindRunProcessQCDetail) Then
                        FindRunProcessQCDetail = New RunProcessQCDetail
                        IsNewAddBug = True
                        CellValueChanged = True
                    End If
                    With FindRunProcessQCDetail
                        .FK_RunProcessDataID = Me.QCTitleData.FK_RunProcessDataID
                        .QABugNumber = Val(EachColumn.ToolTipText.Trim)
                        Dim SetBugHappenValue As Boolean = False
                        If IsDBNull(EachGridViewRow.Cells(EachColumn.Name).Value) Then
                            SetBugHappenValue = False
                        Else
                            SetBugHappenValue = EachGridViewRow.Cells(EachColumn.Name).Value.ToString.Trim
                        End If
                        If SetBugHappenValue <> .IsBugHappen Then
                            CellValueChanged = True
                        End If
                        .IsBugHappen = SetBugHappenValue
                        .StartPosition = SetStartPosition
                        .EndPosition = SetEndPosition
                        .IsUpLineBug = False
                        .RowGroup = SetRowGroup
                        If IsNewAddBug OrElse CellValueChanged Then
                            .SaveTime = Now
                        End If
                        If .CDBSave > 0 AndAlso Not QCTitleDataDetail.Contains(FindRunProcessQCDetail) Then
                            QCTitleDataDetail.Add(FindRunProcessQCDetail)
                        End If
                    End With
                Next

            Next

        End If
    End Sub

    Private Sub CheckPositionBeforeChangeAndSave()
        '偵測位置是否有變更,有則變更並存檔
        Dim RowIndex As Integer = 0
        For Each EachGridViewRow As DataGridViewRow In DataGridView1.Rows
            RowIndex += 1
            Dim FindRunProcessQCDetail As List(Of RunProcessQCDetail) = (From A In Me.QCTitleDataDetail Where A.RowGroup = RowIndex Select A).ToList
            Dim SetStartPosition As Long = Val(EachGridViewRow.Cells("StartPosition").Value)
            Dim SetEndPosition As Long = Val(EachGridViewRow.Cells("EndPosition").Value)
            For Each EachBug As RunProcessQCDetail In FindRunProcessQCDetail
                If EachBug.StartPosition <> SetStartPosition OrElse EachBug.EndPosition <> SetEndPosition Then
                    EachBug.CDBDelete()
                    EachBug.StartPosition = SetStartPosition
                    EachBug.EndPosition = SetEndPosition
                    EachBug.CDBSave()
                End If
            Next
        Next
    End Sub
#End Region
#Region "查詢歷史鋼捲 函式:SearchHistoryCoil"
    ''' <summary>
    ''' 查詢歷史鋼捲
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SearchHistoryCoil()
        Dim QryString As New StringBuilder
        Dim FilterDate As DateTime = Now.AddDays(-Val(tbDate.Text))

        QryString.Append("Select top 1000 A.* ,B.IsUserCheckOK from RunProcessData AS A LEFT JOIN RunProcessQCTitle AS B ON A.ID=B.FK_RunProcessDataID  where A.SysCoilStartTime>='" & Format(FilterDate, "yyyy/MM/dd HH:mm:ss") & "'")
        QryString.Append(" and A.RunStationPCIP='" & Me.AboutCoilScanAndMachineProcess.CurrentOperationPCRunningState.RunningPCIP.Trim & "'")
        QryString.Append(" and A.FK_RunStationName='" & Me.AboutCoilScanAndMachineProcess.CurrentUesStationName & "' ")
        If Not String.IsNullOrEmpty(tbCoilNumber.Text) AndAlso tbCoilNumber.Text.Trim.Length > 0 Then
            QryString.Append(" and RTRIM(B.FK_LastRefSHA01 + B.FK_LastRefSHA02=)'" & tbCoilNumber.Text.Trim & "'")
        End If

        If cbChecked.Checked Then
            QryString.Append(" and not  B.IsUserCheckOK is null")
        End If
        Dim SearchResult As List(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessData) = CompanyORMDB.SQLServer.PPS100LB.RunProcessData.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessData)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString.ToString)

        tvSearchResult.Nodes.Clear()
        For Each EachItem As RunProcessData In SearchResult
            Dim AddNode As CoilScanedTreeNode = New CoilScanedTreeNode(EachItem.FK_LastRefSHA01 & EachItem.FK_LastRefSHA02.Trim)
            AddNode.Tag = EachItem
            tvSearchResult.Nodes.Add(AddNode)
        Next

    End Sub


#End Region
#Region "發信給相關管理人員 函式:MailToManagers"
    ''' <summary>
    ''' 發信給相關管理人員
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MailToManagers()
        If IsNothing(Me.QCTitleData) OrElse IsNothing(Me.QCTitleDataDetail) OrElse Me.QCTitleData.IsUserCheckOK = False Then
            Exit Sub
        End If
        Dim IsHaveBugInCoil As Boolean = False
        Dim BugString As New StringBuilder
        If Me.QCTitleData.IsNoSmooth Then
            BugString.Append(vbNewLine & "發生鋼捲不平整狀況!")
            IsHaveBugInCoil = True
        End If
        For Each EachItem As RunProcessQCDetail In (From A In Me.QCTitleDataDetail Select A Order By A.RowGroup Descending, A.QABugNumber Ascending).ToArray
            If EachItem.IsBugHappen = True Then
                BugString.Append(vbNewLine & IIf(EachItem.RowGroup < 99, "本線", "上線") & " 缺陷代碼:" & EachItem.QABugNumber & EachItem.QABugNumberChinese & "  發生於位置:" & EachItem.StartPosition & " ~ " & EachItem.EndPosition)
                IsHaveBugInCoil = True
            End If
        Next

        Dim Smtp As New SmtpClient("mail.tangeng.com.tw", 25)
        Smtp.Credentials = New System.Net.NetworkCredential("mis", "1j4@vu.4")
        Dim SendMessage As New MailMessage
        SendMessage.From = New MailAddress("mis@mail.tangeng.com.tw", "系統發送")
        If IsInProgrammerTestMode OrElse Me.AboutCoilScanAndMachineProcess.IsOnLineMachine = False Then
            SendMessage.To.Add(New MailAddress("kuku@mail.tangeng.com.tw", "古政剛"))
        Else
            If IsHaveBugInCoil Then
                SendMessage.To.Add(New MailAddress("chou@mail.tangeng.com.tw", "周治亮"))
                Select Case Me.QCTitleData.RunStationName.PadRight(3).Substring(0, 3)
                    Case "SBL"
                        SendMessage.To.Add(New MailAddress("w441@mail.tangeng.com.tw", "SBL操作室"))
                    Case "SPL"
                        SendMessage.To.Add(New MailAddress("w442@mail.tangeng.com.tw", "SPL操作室"))
                    Case "TLL"
                        SendMessage.To.Add(New MailAddress("w443@mail.tangeng.com.tw", "TLL操作室"))
                End Select
            End If
            If Me.QCTitleData.IsNoticeQC OrElse IsHaveBugInCoil = False Then
                SendMessage.To.Add(New MailAddress("liumin@mail.tangeng.com.tw", "劉志敏"))
                SendMessage.To.Add(New MailAddress("chenyr@mail.tangeng.com.tw", "陳裕仁"))
                SendMessage.To.Add(New MailAddress("iphung@mail.tangeng.com.tw", "洪易鵬"))
                SendMessage.To.Add(New MailAddress("planckli@mail.tangeng.com.tw", "利嘉翔"))
                SendMessage.To.Add(New MailAddress("jjs@mail.tangeng.com.tw", "蕭錦江"))
                SendMessage.To.Add(New MailAddress("wcy53@mail.tangeng.com.tw", "魏誌勇"))
            End If
        End If

        SendMessage.Subject = IIf(IsHaveBugInCoil, "軋鋼成品線自主品管缺陷發生通知!    <<異常>> !", "軋鋼成品線自主品管完成通知!")
        SendMessage.IsBodyHtml = False
        Dim SendString As New StringBuilder
        SendString.Append("產線:" & Me.QCTitleData.RunStationName & "  時間:" & Format("yyyy/MM/dd HH:mm:ss", Me.QCTitleData.SysCoilStartTime))
        SendString.Append(vbNewLine & "鋼捲編號:" & Trim(Me.QCTitleData.FK_LastRefSHA01 & Me.QCTitleData.FK_LastRefSHA02))
        If IsHaveBugInCoil Then
            SendString.Append(BugString.ToString)
        Else
            SendString.Append(vbNewLine & "成品線生產完成無發現任何缺陷!")
        End If
        SendMessage.Body = SendString.ToString
        Smtp.Send(SendMessage)
    End Sub
#End Region


    Private Sub btnCheckOK_Click(sender As Object, e As EventArgs) Handles btnCheckOK.Click
        SaveControlValueToDB(True)
        RefreshShowEnableControl()
        MailToManagers()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not IsNothing(Me.QCTitleData) AndAlso Val(tbStartPositon.Text) > 0 AndAlso Val(tbEndPosition.Text) > 0 AndAlso _
            Val(tbEndPosition.Text) > Val(tbStartPositon.Text) AndAlso _
            cbBugList.Items.Count > 0 AndAlso Not IsNothing(cbBugList.SelectedItem) Then
            Dim AddItem As New RunProcessQCDetail
            With AddItem
                .FK_RunProcessDataID = Me.QCTitleData.FK_RunProcessDataID
                .QABugNumber = Val(CType(cbBugList.SelectedItem, String).Split(".")(1))
                .StartPosition = Val(tbStartPositon.Text)
                .EndPosition = Val(tbEndPosition.Text)
                .IsUpLineBug = IIf(CType(cbBugList.SelectedItem, String).Split(".")(0) = "本線", False, True)
                .IsBugHappen = True
                .RowGroup = 99
                .SaveTime = Now
                If .CDBSave > 0 Then
                    Dim AddItemText As New StringBuilder
                    AddItemText.Append(IIf(.IsUpLineBug, "上線.", "本線."))
                    Dim FindBugDefine As QABUG = Nothing
                    FindBugDefine = (From A In TheStationCanUseBugDefines(.IsUpLineBug) Where A.Number.Trim = .QABugNumber.Trim Select A).FirstOrDefault
                    If IsNothing(FindBugDefine) Then
                        AddItemText.Append(.QABugNumber.Trim & "." & .StartPosition & "~" & .EndPosition)
                    End If
                    AddItemText.Append(.QABugNumber.Trim & "." & FindBugDefine.CName.Trim & "." & .StartPosition & "~" & .EndPosition)
                    Dim AddNode As New TreeNode
                    AddNode.Text = AddItemText.ToString
                    AddNode.Tag = AddItem
                    tvSelfInsertBugs.Nodes.Add(AddNode)
                    QCTitleDataDetail.Add(AddItem)
                End If
            End With
        End If
        tbStartPositon.Text = Nothing
        tbEndPosition.Text = Nothing
        cbBugList.SelectedItem = Nothing
        RefreshShowEnableControl()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If tvSelfInsertBugs.Nodes.Count = 0 OrElse IsNothing(tvSelfInsertBugs.SelectedNode)  Then
            Exit Sub
        End If
        Dim DeleteItem As RunProcessQCDetail = tvSelfInsertBugs.SelectedNode.Tag
        If Not IsNothing(DeleteItem) AndAlso DeleteItem.CDBDelete > 0 Then
            tvSelfInsertBugs.Nodes.Remove(tvSelfInsertBugs.SelectedNode)
            QCTitleDataDetail.Remove(DeleteItem)
        End If

        RefreshShowEnableControl()
    End Sub

    Private Sub tbStartPositon_TextChanged(sender As Object, e As EventArgs) Handles tbStartPositon.TextChanged, tbEndPosition.TextChanged, cbBugList.SelectedValueChanged, tvSelfInsertBugs.AfterSelect
        RefreshShowEnableControl()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchHistoryCoil()
    End Sub

    Public Sub New(ByVal SetCoilScanAndMachineProcess As CoilScanAndMachineProcess)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.AboutCoilScanAndMachineProcess = SetCoilScanAndMachineProcess
    End Sub

    Private Sub tvSearchResult_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvSearchResult.AfterSelect
        EditCoilTreeNode = tvSearchResult.SelectedNode
        SearchQCDataForTreeNode(EditCoilTreeNode)
        If IsNothing(Me.QCTitleData) OrElse IsNothing(Me.QCTitleDataDetail) OrElse Me.QCTitleDataDetail.Count < 3 Then
            InitialTheStationData()
        End If
        ReloadDataToControl()
        RefreshShowEnableControl()

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
    End Sub


    Private Sub DataGridView1_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        If e.ColumnIndex < 2 Then
            Exit Sub
        End If
        DataGridView1.EndEdit()
        SaveControlValueToDB(False)
    End Sub

    Private Sub AboutCoilScanAndMachineProcessEvent_CurrentEditCoilRunningItemChanged(OldValue As CoilRunningItem, CurrentValue As CoilRunningItem) Handles AboutCoilScanAndMachineProcessEvent.CurrentEditCoilRunningItemChanged
        Me.QCTitleData = Nothing
        Me.QCTitleDataDetail = Nothing
        Me.EditCoilTreeNode = Nothing
        tvSearchResult.Nodes.Clear()
        AboutCoilScanAndMachineProcess = AboutCoilScanAndMachineProcess
    End Sub

    Private Sub AboutCoilScanAndMachineProcessEvent_CurrentCoilRunningItemEditEvent(Sender As CoilRunningItem) Handles AboutCoilScanAndMachineProcessEvent.CurrentCoilRunningItemEditEvent
        Call AboutCoilScanAndMachineProcessEvent_CurrentEditCoilRunningItemChanged(Nothing, Sender)
    End Sub
End Class
