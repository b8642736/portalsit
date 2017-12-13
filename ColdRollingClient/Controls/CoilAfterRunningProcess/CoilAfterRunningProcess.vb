Public Class CoilAfterRunningProcess

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

#Region "查詢 函式:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Search()

        Dim QryString As New StringBuilder
        QryString.Append("Select distinct FK_LastRefSHA01,FK_LastRefSHA02,FK_LastRefSHA04 From RunProcessData Where ThisRecordState='2' and RunStationPCIP='" & Me.AboutCoilScanAndMachineProcess.CurrentOperationPCRunningState.RunningPCIP & "' AND FK_RunStationName='" & Me.AboutCoilScanAndMachineProcess.CurrentUesStationName & "'")
        If cbWillFilterDate.Checked Then
            QryString.Append(" AND SysCoilStartTime >='" & Format(dtpStartDate.Value, "yyyy/MM/dd") & "' and SysCoilEndTime < '" & Format(dtpEndDate.Value.AddDays(1), "yyyy/MM/dd") & "'")
        End If
        If Not rbIsCheckedDataAll.Checked Then
            QryString.Append(" AND IsUserRunningDataChecked = " & IIf(rbIsCheckedDataYes.Checked, 1, 0))
        End If
        If Not String.IsNullOrEmpty(tbCoilNumbers.Text) AndAlso tbCoilNumbers.Text.Trim.Length > 0 Then
            tbCoilNumbers.Text = tbCoilNumbers.Text.Replace("'", Nothing)
            QryString.Append(" AND RTRIM(FK_LastRefSHA01 + FK_LastRefSHA02) IN ('" & tbCoilNumbers.Text.Replace(",", "','") & "')")
        End If

        Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        tvSearchResult.Nodes.Clear()
        For Each EachItem As DataRow In (From A In Adapter.SelectQuery(QryString.ToString).Rows Select A).ToList.Union((From A In Adapter.SelectQuery(QryString.ToString.Replace("From RunProcessData", "From RunProcessDataHistory")).Rows Select A).ToList)
            tvSearchResult.Nodes.Add(New CoilScanedTreeNode(CType(EachItem.Item("FK_LastRefSHA01"), String) & CType(EachItem.Item("FK_LastRefSHA02"), String)))
        Next
    End Sub
#End Region
#Region "現在編輯的CoilRunningItem 屬性:CurrentEditCoilRunningItem"
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
            _CurrentEditCoilRunningItem = value
            tsslMessage.Text = Nothing
            LoadCoilRunningItemEditDataFromDB(_CurrentEditCoilRunningItem)
            tsbAddCoilBreak.Enabled = Me.tabDetailEdit.TabPages.Count > 0
            tsbPrintBarCode.Enabled = tsbAddCoilBreak.Enabled
            tsbDeletCoilBreak.Enabled = Me.tabDetailEdit.TabPages.Count > 1
        End Set
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
        Dim GetRunProcessDatas As List(Of RunProcessData) = (From A In GetPPSSHAPFFlowAdapter.AboutRunProcessDatas Where A.ThisRecordState = 2 And A.RunStationPCIP = AboutCoilScanAndMachineProcess.CurrentOperationPCRunningState.RunningPCIP And A.FK_RunStationName.Trim = AboutCoilScanAndMachineProcess.CurrentOperationPCRunningState.DefaultUseStationName.Trim Select A).ToList


        Dim AddEditStationControl As Control = Nothing
        Dim CoilBreakNumber As Integer = 1
        Dim IsSuccessAddControl As Boolean = False
        For Each EachBreakItemData In GetRunProcessDatas
            Try
                If Not IsNothing(AboutCoilScanAndMachineProcess) AndAlso Not IsNothing(AboutCoilScanAndMachineProcess.CurrentUseingStationRadioButton) Then
                    'SetL2MsgToRunProcessData(EachBreakItemData) '設定L2資料傳送過來的資
                    AddEditStationControl = AboutCoilScanAndMachineProcess.CurrentUseingStationRadioButton.CreateStationRunningControl(EachBreakItemData, SourceControl.CurrentRunningCoilScanedTreeNode)
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
        Next
        tsbDeletCoilBreak.Enabled = Me.tabDetailEdit.TabPages.Count > 1

        Return IsSuccessAddControl
    End Function

#End Region
#Region "加入作業完成鋼捲編輯資料 函式:AddCoilRunningItemEditData"
    ''' <summary>
    ''' 加入作業中鋼捲編輯資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Function AddCoilRunningItemEditData() As Boolean
        Dim SelectTreeNode As CoilScanedTreeNode = tvSearchResult.SelectedNode
        If CurrentEditRunProcessDatas.Count = 0 OrElse IsNothing(SelectTreeNode) Then
            Return False
        End If
        Dim CoilFullNumberForLastPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = CurrentEditRunProcessDatas(0).AboutLastRefPPSSHAPF   'SourceControl.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF
        If IsNothing(CoilFullNumberForLastPPSSHAPF) Then
            tsslMessage.Text = "此鋼捲編號沒有可供參考的排程檔PPSSHAPF,固已無法編輯!"
            Return False
        End If


        If Not IsNothing(Me.AboutCoilScanAndMachineProcess.CurrentUseingStationRadioButton) Then
            'Dim RefPPSSHAPFs As List(Of CompanyORMDB.IPPS100LB.IPPSSHAPF) = SourceControl.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF
            Dim AddRunProcessData As RunProcessData = New CompanyORMDB.SQLServer.PPS100LB.RunProcessData(CoilFullNumberForLastPPSSHAPF)
            'Dim GetRunProcessDatas As List(Of RunProcessData) = (From A In SourceControl.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter.AboutRunProcessDatas Where A.ThisRecordState = 1 And A.RunStationPCIP = Me.AboutCoilScanAndMachineProcess.CurrentOperationPCRunningState.RunningPCIP And A.FK_RunStationName.Trim = Me.AboutCoilScanAndMachineProcess.CurrentOperationPCRunningState.DefaultUseStationName.Trim Select A Order By A.DataCreateTime Ascending).ToList
            Dim GetRunProcessDatas As List(Of RunProcessData) = Me.CurrentEditRunProcessDatas
            Dim BeforeBreakLastRunProcessData As RunProcessData = Nothing
            If GetRunProcessDatas.Count >= 5 Then
                Return False     '限制最多分5捲,以防止系統異常分捲訊號發生
            End If
            If GetRunProcessDatas.Count > 0 Then
                BeforeBreakLastRunProcessData = GetRunProcessDatas(GetRunProcessDatas.Count - 1)
                AddRunProcessData.FirstsysCoilStartTime = GetRunProcessDatas(GetRunProcessDatas.Count - 1).FirstsysCoilStartTime
            End If
            With AddRunProcessData
                .AboutStation = CurrentEditRunProcessDatas(0).AboutStation  'Me.AboutCoilScanAndMachineProcess.CurrentUseingStationRadioButton.UseStation
                .RunStationPCIP = CurrentEditRunProcessDatas(0).RunStationPCIP  'Me.AboutCoilScanAndMachineProcess.CurrentOperationPCRunningState.RunningPCIP
                .FK_OutSHA01 = .FK_LastRefSHA01
                .SysCoilStartTime = SelectTreeNode.MyPPSSHAPFFlowAdapter.WebServerNowTime
                .CoilStartTime = .SysCoilStartTime
                .SysCoilEndTime = .SysCoilStartTime
                .CoilEndTime = .SysCoilEndTime
                .Guage = CoilFullNumberForLastPPSSHAPF.SHA14
                .Width = CoilFullNumberForLastPPSSHAPF.SHA15
                If Not IsNothing(BeforeBreakLastRunProcessData) Then
                    .Width = BeforeBreakLastRunProcessData.Width
                End If
                .Length = CoilFullNumberForLastPPSSHAPF.SHA16
                .Weight = CoilFullNumberForLastPPSSHAPF.SHA17
                .DataCreateTime = .CoilStartTime
                .ThisRecordState = 2 '改變鋼捲編輯資料為CoilStart狀態
                '設定過磅資料(襯紙/套筒/奇力龍)預設值  / ZML給定 第一中間/第二中間/背棍/外徑 預設值
                .SetInitialWorkData(Me.AboutCoilScanAndMachineProcess.CurrentOperationPCRunningState)

            End With
            Me.CurrentEditRunProcessDatas.Add(AddRunProcessData)
            RefreshBreakNumberAndCoilEndSave() '重整鋼捲號碼及儲存CoilEnd時間
            tabDetailEdit.TabPages.Clear()
            For Each EachItem As RunProcessData In Me.CurrentEditRunProcessDatas
                Dim AddEditStationControl As Control = Me.AboutCoilScanAndMachineProcess.CurrentUseingStationRadioButton.CreateStationRunningControl(EachItem, tvSearchResult.SelectedNode)
                Dim AddTabPage As New TabPage()
                AddTabPage.ImageIndex = 1
                AddTabPage.Text = (EachItem.FK_OutSHA01 & EachItem.FK_OutSHA02).Trim
                AddTabPage.Controls.Add(AddEditStationControl)
                tabDetailEdit.TabPages.Add(AddTabPage)
                AddEditStationControl.Dock = DockStyle.Fill
            Next
        End If
        Return True
    End Function
#End Region
#Region "刪除作業完成鋼捲編輯資料 函式:DeleteCoilRunningItemEditData"
    ''' <summary>
    ''' 結束或移除作業中鋼捲編輯資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Function DeleteOrMoveCoilRunningItemEditData(ByVal DeleteRunProcessData As RunProcessData) As Boolean
        Me.tsslMessage.Text = Nothing
        If IsNothing(tvSearchResult.SelectedNode) Then
            Return False
        End If
        If Me.CurrentEditRunProcessDatas.Count < 2 Then
            tsslMessage.Text = "每捲鋼捲至少必須有一顆鋼捲資料!"
            Return False
        End If
        Dim DeleteItem As RunProcessData = (From A In CurrentEditRunProcessDatas Where A Is DeleteRunProcessData Select A).FirstOrDefault
        If Not IsNothing(DeleteItem) AndAlso DeleteItem.CDBDelete() > 0 Then
            Me.CurrentEditRunProcessDatas.Remove(DeleteItem)
            RefreshBreakNumberAndCoilEndSave()
            tabDetailEdit.TabPages.Clear()
            For Each EachItem As RunProcessData In Me.CurrentEditRunProcessDatas
                Dim AddEditStationControl As Control = Me.AboutCoilScanAndMachineProcess.CurrentUseingStationRadioButton.CreateStationRunningControl(EachItem, tvSearchResult.SelectedNode)
                Dim AddTabPage As New TabPage()
                AddTabPage.ImageIndex = 1
                AddTabPage.Text = (EachItem.FK_OutSHA01 & EachItem.FK_OutSHA02).Trim
                AddTabPage.Controls.Add(AddEditStationControl)
                tabDetailEdit.TabPages.Add(AddTabPage)
                AddEditStationControl.Dock = DockStyle.Fill
            Next
        Else
            Return False
        End If
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
    Sub RefreshBreakNumberAndCoilEndSave()
        If IsNothing(Me.CurrentEditCoilRunningItem) Then
            Exit Sub
        End If
        Dim RefPPSSHAPFFlowAdapter As CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter = Me.CurrentEditCoilRunningItem.CurrentRunningCoilScanedTreeNode.MyPPSSHAPFFlowAdapter
        If IsNothing(RefPPSSHAPFFlowAdapter) Then
            Exit Sub
        End If
        'Dim GetValue As List(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessData) = (From A In RefPPSSHAPFFlowAdapter.AboutRunProcessDatas Where A.ThisRecordState = 2 And A.RunStationPCIP = Me.AboutCoilScanAndMachineProcess.CurrentOperationPCRunningState.RunningPCIP And A.FK_RunStationName.Trim = Me.AboutCoilScanAndMachineProcess.CurrentOperationPCRunningState.DefaultUseStationName.Trim Select A).ToList
        Dim GetValue As List(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessData) = Me.CurrentEditRunProcessDatas
        Select Case True
            Case GetValue.Count > 1
                Dim BreakCount As Integer = 1
                For Each EachItem As RunProcessData In GetValue
                    EachItem.FK_OutSHA01 = RefPPSSHAPFFlowAdapter.SHA01
                    EachItem.FK_OutSHA02 = RefPPSSHAPFFlowAdapter.SHA02.Trim & Chr(Asc("A") + BreakCount - 1)
                    BreakCount += 1
                    EachItem.CDBSave()
                Next
            Case GetValue.Count = 1
                GetValue(0).FK_OutSHA01 = RefPPSSHAPFFlowAdapter.SHA01
                GetValue(0).FK_OutSHA02 = RefPPSSHAPFFlowAdapter.SHA02
                GetValue(0).CDBSave()
            Case Else
        End Select
    End Sub
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

#Region "結束編輯並儲存 方法:DataEndEditAndSave"
    ''' <summary>
    ''' 結束編輯並儲存
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DataEndEditAndSave() As Integer
        Dim CurrentEditControl As IStationRunningControl
        Dim ReturnVlaue As Integer = 0
        For Each EachItem As TabPage In tabDetailEdit.TabPages
            CurrentEditControl = EachItem.Controls(0)
            ReturnVlaue += CurrentEditControl.DataEndEditAndSave()
        Next
        Return ReturnVlaue
    End Function

#End Region

#Region "重整控制項啟用按鈕 函式:RefreshEnableButton"
    ''' <summary>
    ''' 重整控制項啟用按鈕
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshEnableButton(Optional WillReSortRunCoilsOrder As Boolean = True)
        tsbAddCoilBreak.Enabled = Not IsNothing(tvSearchResult.SelectedNode)
        tsbDeletCoilBreak.Enabled = Not IsNothing(tvSearchResult.SelectedNode) AndAlso CurrentEditRunProcessDatas.Count > 1
        tsbPrintBarCode.Enabled = Not IsNothing(tvSearchResult.SelectedNode) AndAlso CurrentEditRunProcessDatas.Count > 0
        tsbSave.Enabled = Not IsNothing(Me.CurrentEditCoilRunningItem)
    End Sub
#End Region

    Public Sub New(ByVal SetCoilScanAndMachineProcess As CoilScanAndMachineProcess)
        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        dtpStartDate.Value = Now.AddMonths(-1)
        Me.AboutCoilScanAndMachineProcess = SetCoilScanAndMachineProcess
    End Sub

    Private Sub tsbSearchRun_Click(sender As Object, e As EventArgs) Handles tsbSearchRun.Click
        DataEndEditAndSave()
        Call Search()
        CurrentEditCoilRunningItem = Nothing
        RefreshEnableButton()
    End Sub

    Private Sub tsbClearSearchFilter_Click(sender As Object, e As EventArgs) Handles tsbClearSearchFilter.Click
        tbCoilNumbers.Text = Nothing
        rbIsCheckedDataAll.Checked = True
    End Sub

    Private Sub tvSearchResult_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvSearchResult.AfterSelect
        Me.CurrentEditCoilRunningItem = New CoilRunningItem(CType(tvSearchResult.SelectedNode, CoilScanedTreeNode))
        RefreshEnableButton()
    End Sub

    Private Sub tsbAddCoilBreak_Click(sender As Object, e As EventArgs) Handles tsbAddCoilBreak.Click
        AddCoilRunningItemEditData()
        tabDetailEdit.SelectedTab = tabDetailEdit.TabPages(tabDetailEdit.TabPages.Count - 1)
        RefreshEnableButton()
    End Sub

    Private Sub tsbDeletCoilBreak_Click(sender As Object, e As EventArgs) Handles tsbDeletCoilBreak.Click
        If MsgBox("是否確定刪除最後一顆鋼捲(" & Trim(Me.CurrentEditRunProcessDatas(Me.CurrentEditRunProcessDatas.Count - 1).FK_OutSHA01 & Me.CurrentEditRunProcessDatas(Me.CurrentEditRunProcessDatas.Count - 1).FK_OutSHA02) & ")資料?", vbYesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Call DeleteOrMoveCoilRunningItemEditData(Me.CurrentEditRunProcessDatas(Me.CurrentEditRunProcessDatas.Count - 1))
        RefreshEnableButton()
    End Sub

    Private Sub tsbPrintBarCode_Click(sender As Object, e As EventArgs) Handles tsbPrintBarCode.Click
        Dim CurrentEditData As RunProcessData
        If Not IsNothing(tabDetailEdit.SelectedTab) Then
            CurrentEditData = CType(tabDetailEdit.SelectedTab.Controls(0), IStationRunningControl).EdittingData
            If Not IsNothing(CurrentEditData) Then
                LabelPrint.UnUIQuickPrint(CurrentEditData, Me.AboutCoilScanAndMachineProcess.CurrentUesStationName)
            End If
        End If
    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        DataEndEditAndSave()
    End Sub

End Class
