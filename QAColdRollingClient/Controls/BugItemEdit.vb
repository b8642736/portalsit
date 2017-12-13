Public Class BugItemEdit

    Public Event CallBackEvent(ByVal Sender As Object, ByVal FinishEditData As QABugRecord)
    Public Event CallBackCancelEvent(ByVal Sender As Object, ByVal FinishEditData As QABugRecord)

#Region "父控主制項 屬性:ParentMainControl"
    Private _ParentMainControl As MainControl
    ''' <summary>
    ''' 父控主制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ParentMainControl As MainControl
        Get
            Return _ParentMainControl
        End Get
        Set(value As MainControl)
            _ParentMainControl = value
        End Set
    End Property
#End Region
#Region "編輯缺限資料 屬性:EditQABugRecord"
    Private _EditQABugRecord As QABugRecord
    ''' <summary>
    ''' 編輯缺限資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property EditQABugRecord As QABugRecord
        Get
            Return _EditQABugRecord
        End Get
        Set(value As QABugRecord)
            _EditQABugRecord = value
            gbEditArea.Controls.Clear()
            RefishDisplayData(True)
        End Set
    End Property
#End Region
#Region "缺陷輸入控制項 屬性/事件:BugItemEdit_BugInputControl/BugItemEdit_BugInputControlEvent"
    WithEvents BugItemEdit_BugInputControlEvent As BugEdit_BugInput
    Private _BugItemEdit_BugInputControl As BugEdit_BugInput
    ''' <summary>
    ''' 缺陷輸入控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BugItemEdit_BugInputControl As BugEdit_BugInput
        Get
            If IsNothing(_BugItemEdit_BugInputControl) Then
                _BugItemEdit_BugInputControl = New BugEdit_BugInput(ParentMainControl.EditStationName, Me)
                BugItemEdit_BugInputControlEvent = _BugItemEdit_BugInputControl
                _BugItemEdit_BugInputControl.Dock = DockStyle.Fill
            End If
            Return _BugItemEdit_BugInputControl
        End Get
    End Property
#End Region
#Region "程度輸入控制項 屬性/事件:BugItemEdit_DegreeInputControl/BugItemEdit_DegreeInputControlEvent"
    WithEvents BugItemEdit_DegreeInputControlEvent As NumberKeyboard
    Private _BugItemEdit_DegreeInputControl As NumberKeyboard
    ''' <summary>
    ''' 程度輸入控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BugItemEdit_DegreeInputControl As NumberKeyboard
        Get
            If IsNothing(_BugItemEdit_DegreeInputControl) Then
                _BugItemEdit_DegreeInputControl = New NumberKeyboard
                _BugItemEdit_DegreeInputControl.InputMode = NumberKeyboard.InputModeEnum.Density
                BugItemEdit_DegreeInputControlEvent = _BugItemEdit_DegreeInputControl
                _BugItemEdit_DegreeInputControl.Dock = DockStyle.Fill
            End If
            Return _BugItemEdit_DegreeInputControl
        End Get
    End Property
#End Region
#Region "長度輸入控制項 屬性/事件:BugItemEdit_LengthInputControl/BugItemEdit_LengthInputControlEvent"
    WithEvents BugItemEdit_LengthInputControlEvent As BugItemEdit_LengthInput
    Private _BugItemEdit_LengthInputControl As BugItemEdit_LengthInput
    ''' <summary>
    ''' 長度輸入控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BugItemEdit_LengthInputControl As BugItemEdit_LengthInput
        Get
            If IsNothing(_BugItemEdit_LengthInputControl) Then
                _BugItemEdit_LengthInputControl = New BugItemEdit_LengthInput(Me.ParentMainControl)
                _BugItemEdit_LengthInputControl.InputMode = BugItemEdit_LengthInput.InputModeEnum.Length
                BugItemEdit_LengthInputControlEvent = _BugItemEdit_LengthInputControl
                _BugItemEdit_LengthInputControl.Dock = DockStyle.Fill
            End If
            Return _BugItemEdit_LengthInputControl
        End Get
    End Property
#End Region
#Region "分佈位置輸入控制項 屬性/事件:BugItemEdit_DistributeInputControl/BugItemEdit_DistributeInputControlEvent"
    WithEvents BugItemEdit_DistributeInputControlEvent As BugItemEdit_LengthInput
    Private _BugItemEdit_DistributeInputControl As BugItemEdit_LengthInput
    ''' <summary>
    ''' 分佈位置輸入控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BugItemEdit_DistributeInputControl As BugItemEdit_LengthInput
        Get
            If IsNothing(_BugItemEdit_DistributeInputControl) Then
                _BugItemEdit_DistributeInputControl = New BugItemEdit_LengthInput(Me.ParentMainControl)
                _BugItemEdit_DistributeInputControl.InputMode = BugItemEdit_LengthInput.InputModeEnum.DistributePosition
                BugItemEdit_DistributeInputControlEvent = _BugItemEdit_DistributeInputControl
                _BugItemEdit_DistributeInputControl.Dock = DockStyle.Fill
            End If
            Return _BugItemEdit_DistributeInputControl
        End Get
    End Property
#End Region
#Region "正反輸入控制項 屬性/事件:BugItemEdit_PosOrNegInputControl/BugItemEdit_PosOrNegInputControlEvent"
    WithEvents BugItemEdit_PosOrNegInputControlEvent As NumberKeyboard
    Private _BugItemEdit_PosOrNegInputControl As NumberKeyboard
    ''' <summary>
    ''' 正反輸入控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BugItemEdit_PosOrNegInputControl As NumberKeyboard
        Get
            If IsNothing(_BugItemEdit_PosOrNegInputControl) Then
                _BugItemEdit_PosOrNegInputControl = New NumberKeyboard
                BugItemEdit_PosOrNegInputControlEvent = _BugItemEdit_PosOrNegInputControl
                _BugItemEdit_PosOrNegInputControl.InputMode = NumberKeyboard.InputModeEnum.PosOrNegInput
                '_BugItemEdit_PosOrNegInputControl.SetButtonVisibleOnly({"1", "2", "3", "確認"})
                '_BugItemEdit_PosOrNegInputControl.ChangeButtonDisplayName("1", "1正")
                '_BugItemEdit_PosOrNegInputControl.ChangeButtonDisplayName("2", "2反")
                '_BugItemEdit_PosOrNegInputControl.ChangeButtonDisplayName("3", "3雙")
                _BugItemEdit_PosOrNegInputControl.Dock = DockStyle.Fill
            End If
            Return _BugItemEdit_PosOrNegInputControl
        End Get
    End Property
#End Region
#Region "密度輸入控制項 屬性/事件:BugItemEdit_DensityInputControl/BugItemEdit_DensityInputControlEvent"
    WithEvents BugItemEdit_DensityInputControlEvent As NumberKeyboard
    Private _BugItemEdit_DensityInputControl As NumberKeyboard
    ''' <summary>
    ''' 密度輸入控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BugItemEdit_DensityInputControl As NumberKeyboard
        Get
            If IsNothing(_BugItemEdit_DensityInputControl) Then
                _BugItemEdit_DensityInputControl = New NumberKeyboard
                BugItemEdit_DensityInputControlEvent = _BugItemEdit_DensityInputControl
                _BugItemEdit_DensityInputControl.Dock = DockStyle.Fill
            End If
            Return _BugItemEdit_DensityInputControl
        End Get
    End Property
#End Region
#Region "週期輸入控制項 屬性/事件:BugItemEdit_CycleInputControl/BugItemEdit_CycleInputControlEvent"
    WithEvents BugItemEdit_CycleInputControlEvent As BugItemEdit_LengthInput
    Private _BugItemEdit_CycleInputControl As BugItemEdit_LengthInput
    ''' <summary>
    ''' 週期輸入控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BugItemEdit_CycleInputControl As BugItemEdit_LengthInput
        Get
            If IsNothing(_BugItemEdit_CycleInputControl) Then
                _BugItemEdit_CycleInputControl = New BugItemEdit_LengthInput(ParentMainControl)
                _BugItemEdit_CycleInputControl.InputMode = BugItemEdit_LengthInput.InputModeEnum.Cycle
                BugItemEdit_CycleInputControlEvent = _BugItemEdit_CycleInputControl
                _BugItemEdit_CycleInputControl.Dock = DockStyle.Fill
            End If
            Return _BugItemEdit_CycleInputControl
        End Get
    End Property
#End Region

#Region "傳送按鈕命令 函式:SendButtonCommand"
    ''' <summary>
    ''' 傳送按鈕命令
    ''' </summary>
    ''' <param name="ButtonType"></param>
    ''' <remarks></remarks>
    Public Sub SendButtonCommand(ByVal ButtonType As ButtonTypeEnum)
        Select Case ButtonType
            Case ButtonTypeEnum.BugNumberButton
                Call tbBug_Number_Click(tbBug_Number, Nothing)
            Case ButtonTypeEnum.DegreeButton
                Call tbBug_Number_Click(tbDegree, Nothing)
            Case ButtonTypeEnum.LengthButton
                Call tbBug_Number_Click(tbLength, Nothing)
            Case ButtonTypeEnum.DPositionButton
                Call tbBug_Number_Click(tbDistribute, Nothing)
            Case ButtonTypeEnum.PosOrNegButton
                Call tbBug_Number_Click(tbPosOrNeg, Nothing)
            Case ButtonTypeEnum.DensityButton
                Call tbBug_Number_Click(tbDensity, Nothing)
            Case ButtonTypeEnum.CycleButton
                Call tbBug_Number_Click(tbCycle, Nothing)
        End Select
    End Sub
    Public Enum ButtonTypeEnum
        BugNumberButton = 1
        DegreeButton = 2
        LengthButton = 3
        DPositionButton = 4
        PosOrNegButton = 5
        DensityButton = 6
        CycleButton = 7
    End Enum
#End Region

#Region "控制項資料處理模式 屬性/列舉:ControlDataProcessMode/ControlDataProcessModeEnum"
    ''' <summary>
    ''' 控制項資料處理模式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ControlDataProcessMode As ControlDataProcessModeEnum = ControlDataProcessModeEnum.EditMode
    Enum ControlDataProcessModeEnum
        InsertMode = 1
        EditMode = 2
    End Enum
#End Region
#Region "選擇缺陷設定其它資料預設值 SetDefaultValueFromQABugRecord"
    ''' <summary>
    ''' 選擇缺陷設定其它資料預設值
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDefaultValueFromQABugRecord(ByVal SetQABug As QABUG)
        If IsNothing(EditQABugRecord) OrElse IsNothing(SetQABug) OrElse ControlDataProcessMode = ControlDataProcessModeEnum.EditMode OrElse _
            String.IsNullOrEmpty(EditQABugRecord.QABug_Number) OrElse EditQABugRecord.QABug_Number.Trim.Length = 0 OrElse _
            EditQABugRecord.QABug_Number.Trim <> SetQABug.Number.Trim Then
            Exit Sub
        End If
        With SetQABug
            If .Degree > 0 Then
                EditQABugRecord.Degree = .Degree
            End If
            If .StartPosition > 0 Then
                EditQABugRecord.StartPosition = .StartPosition
            End If
            If .EndPosition > 0 Then
                EditQABugRecord.EndPosition = .EndPosition
            End If
            If .DPositionType > 0 Then
                EditQABugRecord.DPositionType = .DPositionType
            End If
            If .DPositionStart > 0 Then
                EditQABugRecord.DPositionStart = .DPositionStart
            End If
            If .DPositionEnd > 0 Then
                EditQABugRecord.DPositionEnd = .DPositionEnd
            End If
            If .PosOrNeg > 0 Then
                EditQABugRecord.PosOrNeg = .PosOrNeg
            End If
            If .Density > 0 Then
                EditQABugRecord.Density = .Density
            End If
            If .Cycle > 0 Then
                EditQABugRecord.Cycle = .Cycle
            End If
        End With
    End Sub
#End Region

#Region "顯示位置及收捲 函式:ShowPositionAndCoilReceiveType"
    ''' <summary>
    ''' 顯示位置及收捲
    ''' </summary>
    ''' <param name="ShowValue"></param>
    ''' <remarks></remarks>
    Public Sub ShowPositionAndCoilReceiveType(ByVal ShowValue As Long, ByVal ReceiveType As Integer)
        Dim ShowMessage As String = Nothing
        If ShowValue < 0 Then
            lbLength.Text = "長度"
            Exit Sub
        End If
        ShowMessage = "長度(位置:" & ShowValue & ")"
        Select Case ReceiveType
            Case 0
                ShowMessage &= "下收"
            Case Else
                ShowMessage &= "上收"
                'Case Else
                'ShowMessage &= " 收捲信號異常"


        End Select
        lbLength.Text = ShowMessage
    End Sub
#End Region
#Region "顯示鋼捲資訊 函式:ShowCoilInformation"
    ''' <summary>
    ''' 顯示鋼捲資訊
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowCoilInformation(ByVal CoilNumber As String)
        Static ShowCoilNumber As String = Nothing
        Static SetString As New System.Text.StringBuilder
        Select Case True
            Case CoilNumber = ShowCoilNumber
                Exit Select   '限制同樣鋼捲號碼只需進來查詢一次
            Case String.IsNullOrEmpty(CoilNumber) OrElse CoilNumber.Trim.Length < 5
                ShowCoilNumber = " "
                SetString.Clear()
                SetString.Append(" 找不到鋼捲資訊!")
            Case ShowCoilNumber = CoilNumber AndAlso ShowCoilNumber = " "
                SetString.Clear()
                SetString.Append(" 找不到鋼捲資訊!")
            Case String.IsNullOrEmpty(ShowCoilNumber) OrElse CoilNumber <> ShowCoilNumber
                SetString.Clear()
                ShowCoilNumber = CoilNumber
                Dim QryCoilNumber As String = ShowCoilNumber.Trim
                If QryCoilNumber.Length > 5 Then
                    QryCoilNumber = QryCoilNumber.Substring(0, QryCoilNumber.Length - 1)
                End If

                Dim QryString As String = "Select * from RunProcessData Where (FK_LastRefSHA01 + FK_LastRefSHA02) like '" & QryCoilNumber & "%' and sysCoilEndTime < '" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "' and  FK_RunStationName <> '" & Me._ParentMainControl.EditStationName & "' and (ThisRecordState=2 or ThisRecordState=3) order by sysCoilEndTime desc"
                Dim SearchResult As List(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessData) = RunProcessData.CDBSelect(Of RunProcessData)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                Dim FindRunProcessData As CompanyORMDB.SQLServer.PPS100LB.RunProcessData = Nothing
                Dim AboutPPSBLAPF As CompanyORMDB.PPS100LB.PPSBLAPF = Nothing
                If SearchResult.Count > 0 Then
                    FindRunProcessData = SearchResult(0)
                    AboutPPSBLAPF = FindRunProcessData.AboutPPSBLAPF
                End If

                If Not IsNothing(AboutPPSBLAPF) Then
                    SetString.Append(" 鋼胚號碼(" & AboutPPSBLAPF.BLA07 & ") 熱軋批號(" & AboutPPSBLAPF.BLA11 & ") 鋼種(" & Trim(AboutPPSBLAPF.BLA02) & ") 前站重量(" & FindRunProcessData.Weight & ")")
                Else
                    QryString = "Select A.BLA07,A.BLA11,B.SHA01,B.SHA02,B.SHA04,B.SHA12,B.SHA13,B.SHA17 From @#PPS100LB.PPSBLAPF A LEFT JOIN @#PPS100LB.PPSSHAPF B ON A.BLA09=B.SHA01 WHERE SHA01 || SHA02 LIKE '" & ShowCoilNumber & "%' and sha11 <= '" & (New CompanyORMDB.AS400DateConverter(Now)).TwIntegerTypeData & "' Order by SHA04 desc ,SHA02 asc"
                    Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
                    Dim SearchResult1 As DataTable = Adapter.SelectQuery(QryString)
                    If SearchResult1.Rows.Count > 0 Then
                        SetString.Append(" 鋼胚號碼(" & SearchResult1.Rows(0).Item("BLA07") & ") 熱軋批號(" & SearchResult1.Rows(0).Item("BLA11") & ") 鋼種TYPE(" & Trim(SearchResult1.Rows(0).Item("SHA12") & SearchResult1.Rows(0).Item("SHA13")) & ") 上一線重量(" & SearchResult1.Rows(0).Item("SHA17") & ")")
                    End If
                End If
        End Select

        If Not SetString.ToString.Contains("找不到鋼捲資訊") Then
            Dim SetString0 As String = Nothing
            Dim SetString1 As String = Nothing
            SetString0 = "模式:" & IIf(Me.ControlDataProcessMode = ControlDataProcessModeEnum.InsertMode, "新增", "編修")
            If Not String.IsNullOrEmpty(Me.ParentMainControl.CanEditStationLine) AndAlso Me.ParentMainControl.CanEditStationLine = "APL1" Then
                Dim PlanCutCoilLength As Long = Me.ParentMainControl.CurrentEditQABugRecordTitle.PlanCutCoilLength
                If PlanCutCoilLength > 0 Then
                    SetString1 = "分捲長:" & PlanCutCoilLength
                End If
            End If
            lbShowCoilMessage.Text = SetString0 & SetString.ToString & SetString1
            Exit Sub
        End If

        lbShowCoilMessage.Text = SetString.ToString
    End Sub
#End Region

#Region "重整顯示控制項資料 函式:RefishDisplayData"
    ''' <summary>
    ''' 重整顯示控制項資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefishDisplayData(Optional IsInitialStatus As Boolean = False)
        If IsNothing(EditQABugRecord) Then
            tbBug_Number.Text = "--"
            tbDegree.Text = "--"
            tbLength.Text = "--"
            tbDistribute.Text = "--"
            tbPosOrNeg.Text = "--"
            tbDensity.Text = "--"
            tbCycle.Text = "--"
        Else
            With EditQABugRecord
                tbBug_Number.Text = .QABug_Number
                tbDegree.Text = .Degree
                tbLength.Text = .StartPosition & "~" & .EndPosition
                If {"全", "無"}.Contains(.DPositionTypeName) Then
                    tbDistribute.Text = .DPositionTypeName
                Else
                    tbDistribute.Text = .DPositionTypeName & ":" & .DPositionStart & "~" & .DPositionEnd
                End If
                tbPosOrNeg.Text = .PosOrNeg
                tbDensity.Text = .Density
                tbCycle.Text = .Cycle
            End With
        End If
        If IsInitialStatus Then
            btnDelete.Text = "刪除"
            btnOKCopy1.Text = "多複製1份"
            btnOKCopy2.Text = "多複製2份"
            btnOKCopy3.Text = "多複製3份"
        End If
        EditButtonSelectChangeColor(Nothing)
    End Sub

#End Region



    Private Sub EditButtonSelectChangeColor(ByVal SourceButton As Button)
        tbBug_Number.BackColor = Me.BackColor
        tbDegree.BackColor = Me.BackColor
        tbLength.BackColor = Me.BackColor
        tbDistribute.BackColor = Me.BackColor
        tbPosOrNeg.BackColor = Me.BackColor
        tbDensity.BackColor = Me.BackColor
        tbCycle.BackColor = Me.BackColor
        If IsNothing(SourceButton) Then
            Exit Sub
        End If
        SourceButton.BackColor = Color.LightPink
    End Sub



    Sub New(ByVal SetEditQABugRecord As QABugRecord, ByVal SetParentMainControl As MainControl, ByVal SetControlDataProcessMode As ControlDataProcessModeEnum)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        ShowPositionAndCoilReceiveType(-1, -1)
        Me.ControlDataProcessMode = SetControlDataProcessMode
        EditQABugRecord = SetEditQABugRecord
        ParentMainControl = SetParentMainControl
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click, btnOKCopy1.Click, btnOKCopy2.Click, btnOKCopy3.Click
        If btnDelete.Text = "確定刪除" Then
            Exit Sub
        End If

        If sender Is btnOKCopy1 OrElse sender Is btnOKCopy2 OrElse sender Is btnOKCopy3 Then
            If CType(sender, Button).Text.Substring(0, 2) <> "確定" Then
                CType(sender, Button).Text = "確定" & CType(sender, Button).Text
                Exit Sub
            End If
            btnOKCopy1.Text = "多複製1份"
            btnOKCopy2.Text = "多複製2份"
            btnOKCopy3.Text = "多複製3份"
        End If

        If String.IsNullOrEmpty(EditQABugRecord.QABug_Number) OrElse EditQABugRecord.QABug_Number.Trim.Length = 0 Then
            SendButtonCommand(ButtonTypeEnum.BugNumberButton)
            Exit Sub
        End If

        If Not IsNothing(EditQABugRecord) AndAlso EditQABugRecord.CDBSave > 0 Then
            '取得所有資料最後一筆的儲存時間
            Dim LastSaveTime As DateTime = EditQABugRecord.DataCreateTime
            For Each EachItem As BugItemMinDisplay In ParentMainControl.QABugRecordShowControls
                If EachItem.QABugRecordData.DataCreateTime > LastSaveTime Then
                    LastSaveTime = EachItem.QABugRecordData.DataCreateTime
                End If
            Next

            For CopyTimes As Integer = 1 To Val(CType(sender, Button).Tag)
                Dim CopyObj As QABugRecord = EditQABugRecord.CDBClone
                CopyObj.DataCreateTime = LastSaveTime.AddSeconds(CopyTimes)
                CopyObj.CDBSave()
            Next
            RaiseEvent CallBackEvent(Me, EditQABugRecord)
        End If

    End Sub

    'Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
    '    If btnDelete.Text = "確定刪除" OrElse _
    '       btnOKCopy1.Text.Substring(0, 2) = "確定" OrElse _
    '        btnOKCopy2.Text.Substring(0, 2) = "確定" OrElse _
    '        btnOKCopy3.Text.Substring(0, 2) = "確定" Then
    '        btnDelete.Text = "刪除"
    '        btnOKCopy1.Text = "多複製1份"
    '        btnOKCopy2.Text = "多複製2份"
    '        btnOKCopy3.Text = "多複製3份"
    '        Exit Sub
    '    End If
    '    RaiseEvent CallBackCancelEvent(Me, EditQABugRecord)
    'End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If btnDelete.Text = "刪除" Then
            btnDelete.Text = "確定刪除" : Exit Sub
        End If
        If btnDelete.Text = "確定刪除" AndAlso Not IsNothing(EditQABugRecord) Then
            EditQABugRecord.RunClientIP = CompanyORMDB.DeviceInformation.GetLocalIPs(0)
            EditQABugRecord.RecordState = 3
            If EditQABugRecord.CDBSave > 0 Then
                btnDelete.Text = "刪除"
                RaiseEvent CallBackEvent(Me, Nothing)
            End If

        End If
    End Sub

    Private Sub tbBug_Number_Click(sender As Object, e As EventArgs) Handles tbBug_Number.Click, tbDegree.Click, tbLength.Click, tbDistribute.Click, tbPosOrNeg.Click, tbDensity.Click, tbCycle.Click
        gbEditArea.Controls.Clear()
        Select Case True
            Case sender Is tbBug_Number
                BugItemEdit_BugInputControl.TheStationName = ParentMainControl.EditStationName
                BugItemEdit_BugInputControl.ResetDefault()
                BugItemEdit_BugInputControl.InitControlValue(Me.EditQABugRecord)
                gbEditArea.Controls.Add(BugItemEdit_BugInputControl)
                '一般控制項定位
                gbEditArea.SetColumnSpan(BugItemEdit_BugInputControl, 2)
                gbEditArea.SetRowSpan(BugItemEdit_BugInputControl, 2)
            Case sender Is tbDegree
                gbEditArea.Controls.Add(BugItemEdit_DegreeInputControl)
                '鍵盤控制項定位
                gbEditArea.SetRow(BugItemEdit_DegreeInputControl, 1)
                gbEditArea.SetColumn(BugItemEdit_DegreeInputControl, 1)
                BugItemEdit_DegreeInputControl.Margin = New Padding(0)
                BugItemEdit_DegreeInputControl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            Case sender Is tbLength
                gbEditArea.Controls.Add(BugItemEdit_LengthInputControl)
                BugItemEdit_LengthInputControl.InitControlValue(Me.EditQABugRecord)
                '一般控制項定位
                gbEditArea.SetColumnSpan(BugItemEdit_LengthInputControl, 2)
                gbEditArea.SetRowSpan(BugItemEdit_LengthInputControl, 2)
            Case sender Is tbDistribute
                BugItemEdit_DistributeInputControl.InputMode = BugItemEdit_LengthInput.InputModeEnum.DistributePosition
                gbEditArea.Controls.Add(BugItemEdit_DistributeInputControl)
                BugItemEdit_DistributeInputControl.InitControlValue(Me.EditQABugRecord)
                '一般控制項定位
                gbEditArea.SetColumnSpan(BugItemEdit_DistributeInputControl, 2)
                gbEditArea.SetRowSpan(BugItemEdit_DistributeInputControl, 2)
            Case sender Is tbPosOrNeg
                gbEditArea.Controls.Add(BugItemEdit_PosOrNegInputControl)
                '鍵盤控制項定位
                gbEditArea.SetRow(BugItemEdit_PosOrNegInputControl, 1)
                gbEditArea.SetColumn(BugItemEdit_PosOrNegInputControl, 1)
                BugItemEdit_PosOrNegInputControl.Margin = New Padding(0)
                BugItemEdit_PosOrNegInputControl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            Case sender Is tbDensity
                gbEditArea.Controls.Add(BugItemEdit_DensityInputControl)
                '鍵盤控制項定位
                gbEditArea.SetRow(BugItemEdit_DensityInputControl, 1)
                gbEditArea.SetColumn(BugItemEdit_DensityInputControl, 1)
                BugItemEdit_DensityInputControl.Margin = New Padding(0)
                BugItemEdit_DensityInputControl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
            Case sender Is tbCycle
                gbEditArea.Controls.Add(BugItemEdit_CycleInputControl)
                BugItemEdit_CycleInputControl.InitControlValue(Me.EditQABugRecord)
                '一般控制項定位
                gbEditArea.SetColumnSpan(BugItemEdit_CycleInputControl, 2)
                gbEditArea.SetRowSpan(BugItemEdit_CycleInputControl, 2)
        End Select
        EditButtonSelectChangeColor(sender)
    End Sub

    Private Sub BugItemEdit_BugInputControlEvent_BugCallBackEvent(Sender As Object, UserSelectBugData As QABUG) Handles BugItemEdit_BugInputControlEvent.BugCallBackEvent
        '輸入控制項資料確認返回處理
        If Not IsNothing(UserSelectBugData) AndAlso tbBug_Number.BackColor = Color.LightPink Then
            Me.EditQABugRecord.QABug_Number = UserSelectBugData.Number.Trim
            SetDefaultValueFromQABugRecord(UserSelectBugData)
        End If
        RefishDisplayData()
        gbEditArea.Controls.Clear()
        SendButtonCommand(ButtonTypeEnum.DegreeButton)  '跳下一個輸入畫面
    End Sub

    Private Sub BugItemEdit_DegreeInputControlEvent_ButtonClickEvent(sender As Object, Value As String) Handles BugItemEdit_DegreeInputControlEvent.ButtonClickEvent, BugItemEdit_DensityInputControlEvent.ButtonClickEvent, BugItemEdit_PosOrNegInputControlEvent.ButtonClickEvent
        '輸入控制項資料確認返回處理
        If Not IsNothing(Me.EditQABugRecord) Then
            Select Case True
                Case Value = "OK"
                Case sender Is BugItemEdit_DegreeInputControlEvent
                    Me.EditQABugRecord.Degree = Val(Value)          '程度
                Case sender Is BugItemEdit_DensityInputControlEvent
                    Me.EditQABugRecord.Density = Val(Value)         '密度
                Case sender Is BugItemEdit_PosOrNegInputControlEvent
                    Me.EditQABugRecord.PosOrNeg = Val(Value)        '正反
            End Select
        End If
        RefishDisplayData()
        gbEditArea.Controls.Clear()
        Select Case True
            Case sender Is BugItemEdit_DegreeInputControl
                SendButtonCommand(ButtonTypeEnum.LengthButton)  '跳下一個輸入畫面
            Case sender Is BugItemEdit_PosOrNegInputControlEvent
                SendButtonCommand(ButtonTypeEnum.DensityButton)  '跳下一個輸入畫面
            Case sender Is BugItemEdit_DensityInputControlEvent
                SendButtonCommand(ButtonTypeEnum.CycleButton)  '跳下一個輸入畫面
        End Select

    End Sub

    Private Sub BugItemEdit_LengthInputControlEvent_LengthInputCallBackEvent(Sender As BugItemEdit_LengthInput) Handles BugItemEdit_LengthInputControlEvent.LengthInputCallBackEvent, BugItemEdit_DistributeInputControlEvent.LengthInputCallBackEvent, BugItemEdit_CycleInputControlEvent.LengthInputCallBackEvent
        '輸入控制項資料確認返回處理
        If Not IsNothing(Me.EditQABugRecord) Then
            Select Case True
                Case Sender Is BugItemEdit_LengthInputControl
                    Me.EditQABugRecord.StartPosition = Val(Sender.StartValue)   '長度
                    Me.EditQABugRecord.EndPosition = Val(Sender.EndValue)
                Case Sender Is BugItemEdit_DistributeInputControl
                    Me.EditQABugRecord.DPositionType = Sender.PositionSelectValue  '分佈位置
                    Me.EditQABugRecord.DPositionStart = Val(Sender.StartValue)
                    Me.EditQABugRecord.DPositionEnd = Val(Sender.EndValue)
                Case Sender Is BugItemEdit_CycleInputControl
                    Me.EditQABugRecord.Cycle = Val(Sender.StartValue)        '週期
            End Select
        End If
        RefishDisplayData()
        Select Case True
            Case Sender.NumberKeyboardControlValue = "OK" AndAlso Sender Is BugItemEdit_LengthInputControl
                SendButtonCommand(ButtonTypeEnum.DPositionButton)  '跳下一個輸入畫面
            Case Sender.NumberKeyboardControlValue = "OK" AndAlso Sender Is BugItemEdit_DistributeInputControl
                SendButtonCommand(ButtonTypeEnum.PosOrNegButton)  '跳下一個輸入畫面
            Case Sender.NumberKeyboardControlValue = "OK" AndAlso Sender Is BugItemEdit_CycleInputControl
                Call btnOK_Click(btnOK, Nothing)
        End Select
    End Sub

End Class
