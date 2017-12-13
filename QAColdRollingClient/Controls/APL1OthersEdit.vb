Public Class APL1OthersEdit
    Implements IxxxTitleEdit


    Public Event CallBackEvent(Sender As IxxxTitleEdit, ReturnValue As String) Implements IxxxTitleEdit.CallBackEvent
    Public Event MessageEvent(Message As String) Implements IxxxTitleEdit.MessageEvent

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
#Region "數字輸入控制項 屬性/事件:NumberKeyboardControl/NumberKeyboardEvent"
    WithEvents NumberKeyboardEvent As NumberKeyboard
    Private _NumberKeyboardControl As NumberKeyboard
    ''' <summary>
    ''' 數字輸入控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NumberKeyboardControl As NumberKeyboard
        Get
            If IsNothing(_NumberKeyboardControl) Then
                _NumberKeyboardControl = New NumberKeyboard
                NumberKeyboardEvent = _NumberKeyboardControl
                _NumberKeyboardControl.Dock = DockStyle.Fill
            End If
            Return _NumberKeyboardControl
        End Get
    End Property
#End Region

#Region "鋼捲位置修正參數 屬性:CoilPositionErrLength"
    ''' <summary>
    ''' 鋼捲位置修正參數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CoilPositionErrLength As Long Implements IxxxTitleEdit.CoilPositionErrLength
        Get
            Return -Val(tbCoilPositionErrLength.Text)
        End Get
    End Property

#End Region
#Region "L2訊號是否已更新相關資料 屬性:IsUpdateFromL2Value"
    ''' <summary>
    ''' L2訊號是否已更新相關資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsUpdateFromL2Value As Boolean Implements IxxxTitleEdit.IsUpdateFromL2Value
        Get
            Return Me.cbIsUpdateFromL2Value.Checked
        End Get
    End Property
#End Region


#Region "初始化控制項值 屬性:InitControlValue"
    ''' <summary>
    ''' 初始化控制項值
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitControlValue() Implements IxxxTitleEdit.InitControlValue

        If IsNothing(Me.ParentMainControl.CurrentEditQABugRecordTitle) Then
            Exit Sub
        End If

        If KeybordPanel.Controls.Count = 0 Then
            KeybordPanel.Controls.Add(NumberKeyboardControl)
        End If

        For Each EachControl As Control In TableLayoutPanel2.Controls
            If TypeOf EachControl Is TextBox Then
                AddHandler CType(EachControl, TextBox).MouseClick, AddressOf tbInputTextBox_Click
            End If
        Next
        AddHandler tbAPL1No1TestThickMM.MouseClick, AddressOf tbInputTextBox_Click
        AddHandler tbCoilPositionErrLength.MouseClick, AddressOf tbInputTextBox_Click
        AddHandler tbAPL2BATestHeadMM.MouseClick, AddressOf tbInputTextBox_Click
        AddHandler tbAPL2BATestTailMM.MouseClick, AddressOf tbInputTextBox_Click



        With Me.ParentMainControl.CurrentEditQABugRecordTitle
            tbAPL2BATestHeadMM.Text = .APL2BATestHeadMM
            tbAPL2BATestTailMM.Text = .APL2BATestTailMM
            Select Case True
                Case .APL1IsExportPackage = 1
                    rbAPL1IsExportPackage2.Checked = True
                Case .APL1IsExportPackage = 2
                    rbAPL1IsExportPackage3.Checked = True
                Case Else
                    rbAPL1IsExportPackage1.Checked = True
            End Select

            Select Case True
                Case .APL1IsNo1GetTest = 1
                    rbAPL1IsNo1GetTest2.Checked = True
                Case .APL1IsNo1GetTest = 2
                    rbAPL1IsNo1GetTest3.Checked = True
                Case Else
                    rbAPL1IsNo1GetTest1.Checked = True
            End Select
            tbAPL1No1TestThickMM.Enabled = rbAPL1IsNo1GetTest2.Checked
            Select Case True
                Case .APL1IsUseDestory = 1
                    rbAPL1IsUseDestory2.Checked = True
                Case .APL1IsUseDestory = 2
                    rbAPL1IsUseDestory3.Checked = True
                Case Else
                    rbAPL1IsUseDestory1.Checked = True
            End Select
            Select Case True
                Case .APL1No1Form = 1
                    rbAPL1No1Form2.Checked = True
                Case .APL1No1Form = 2
                    rbAPL1No1Form3.Checked = True
                Case .APL1No1Form = 3
                    rbAPL1No1Form4.Checked = True
                Case Else
                    rbAPL1No1Form1.Checked = True
            End Select
            tbAPL1No1TestThickMM.Text = .APL1No1TestThickMM

            tbCoilMaxLength.Text = .CoilMaxLength
            tbCoilPositionErrLength.Text = -(.CoilPositionErrLength)
            tbJointLength.Text = .JointLength
            lbCoilStartTime.Text = Format(.CoilStartTime, "yyyy/MM/dd HH:mm:ss")
            lbCoilEndTime.Text = Format(.CoilEndTime, "yyyy/MM/dd HH:mm:ss")
            cbIsUpdateFromL2Value.Checked = .IsUpdateFromL2Value
            tbPlanCutCoilWeight.Text = .PlanCutCoilWeight
        End With


    End Sub
#End Region
#Region "設定控制項值至資料物件 函式:SetControlValueToQABugRecordOtherData"
    ''' <summary>
    ''' 設定控制項值至資料物件
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetControlValueToQABugRecordOtherData() Implements IxxxTitleEdit.SetControlValueToQABugRecordOtherData
        If IsNothing(Me.ParentMainControl.CurrentEditQABugRecordTitle) OrElse _
            Me.ParentMainControl.CurrentEditStationLine <> Me.ParentMainControl.CanEditStationLine Then
            Exit Sub
        End If

        With Me.ParentMainControl.CurrentEditQABugRecordTitle
            .CoilNumber = Me.ParentMainControl.EditCoilNumber
            .DataDate = Me.ParentMainControl.EditDataDate
            .StationName = Me.ParentMainControl.EditStationName
            .Version = Me.ParentMainControl.EditDataDateVersion
            .OutCoilNumber = Me.ParentMainControl.EditOutCoilNumber
            .APL2BATestHeadMM = tbAPL2BATestHeadMM.Text
            .APL2BATestTailMM = tbAPL2BATestTailMM.Text
            Select Case True
                Case rbAPL1IsExportPackage2.Checked
                    .APL1IsExportPackage = 1
                Case rbAPL1IsExportPackage3.Checked
                    .APL1IsExportPackage = 2
                Case Else
                    .APL1IsExportPackage = 0
            End Select
            Select Case True
                Case rbAPL1IsNo1GetTest2.Checked
                    .APL1IsNo1GetTest = 1
                Case rbAPL1IsNo1GetTest3.Checked
                    .APL1IsNo1GetTest = 2
                Case Else
                    .APL1IsNo1GetTest = 0
            End Select
            tbAPL1No1TestThickMM.Text = tbAPL1No1TestThickMM.Text
            Select Case True
                Case rbAPL1IsUseDestory2.Checked
                    .APL1IsUseDestory = 1
                Case rbAPL1IsUseDestory3.Checked
                    .APL1IsUseDestory = 2
                Case Else
                    .APL1IsUseDestory = 0
            End Select
            Select Case True
                Case rbAPL1No1Form2.Checked
                    .APL1No1Form = 1
                Case rbAPL1No1Form3.Checked
                    .APL1No1Form = 2
                Case rbAPL1No1Form4.Checked
                    .APL1No1Form = 3
                Case Else
                    .APL1No1Form = 0
            End Select
            .APL1No1TestThickMM = Val(tbAPL1No1TestThickMM.Text)
            .CoilMaxLength = tbCoilMaxLength.Text
            .CoilPositionErrLength = -Val(tbCoilPositionErrLength.Text)
            .JointLength = Val(tbJointLength.Text)
            .CoilStartTime = CType(lbCoilStartTime.Text, DateTime)
            .CoilEndTime = CType(lbCoilEndTime.Text, DateTime)
            .IsUpdateFromL2Value = cbIsUpdateFromL2Value.Checked
            .LastEditEmployeeID = Me.ParentMainControl.LoginID
            .PlanCutCoilWeight = tbPlanCutCoilWeight.Text

        End With
    End Sub
#End Region

#Region "儲存控製項資料至資料庫 函式:SaveControlDataToDB"
    ''' <summary>
    ''' 儲存控製項資料至資料庫
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SaveControlDataToDB() As Integer Implements IxxxTitleEdit.SaveControlDataToDB
        If IsNothing(Me.ParentMainControl.CurrentEditQABugRecordTitle) OrElse Me.Visible = False OrElse _
            Me.ParentMainControl.CurrentEditStationLine <> Me.ParentMainControl.CanEditStationLine Then
            Return 0
        End If
        SetControlValueToQABugRecordOtherData()
        Dim ReturnValue As Integer = Me.ParentMainControl.CurrentEditQABugRecordTitle.CDBSave
        If ReturnValue > 0 Then
            RaiseEvent MessageEvent("成功儲存APL1其它資訊!")
        Else
            RaiseEvent MessageEvent("儲存APL1其它資訊失敗!")
        End If
        Return ReturnValue
    End Function
#End Region


    Public Sub New(ByVal SetParentMainControl As MainControl)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        ParentMainControl = SetParentMainControl
        InitControlValue()

        ''該物件創建時，將radioBtn刷新
        ''refreshRadioBtn_upAndDown()

    End Sub

    Private Sub tbInputTextBox_Click(sender As Object, e As EventArgs)
        Dim SelectControl As TextBox = sender
        For Each EachControl As Control In TableLayoutPanel2.Controls
            If TypeOf EachControl Is TextBox Then
                EachControl.BackColor = Color.White
            End If
        Next
        For Each EachControl As Control In FlowLayoutPanel8.Controls
            If TypeOf EachControl Is TextBox Then
                EachControl.BackColor = Color.White
            End If
        Next
        tbAPL1No1TestThickMM.BackColor = Color.White

        SelectControl.BackColor = Color.PaleGreen
        SelectControl.SelectAll()
    End Sub

    Private Sub NumberKeyboardEvent_ButtonClickEvent(sender As Object, Value As String) Handles NumberKeyboardEvent.ButtonClickEvent
        Dim InputTextBox As TextBox = Nothing
        For Each EachControl As Control In FlowLayoutPanel8.Controls
            If TypeOf EachControl Is TextBox AndAlso EachControl.BackColor = Color.PaleGreen Then
                InputTextBox = EachControl : Exit For
            End If
        Next
        For Each EachControl As Control In TableLayoutPanel2.Controls
            If TypeOf EachControl Is TextBox AndAlso EachControl.BackColor = Color.PaleGreen Then
                InputTextBox = EachControl : Exit For
            End If
        Next
        If IsNothing(InputTextBox) AndAlso tbAPL1No1TestThickMM.BackColor = Color.PaleGreen Then
            InputTextBox = tbAPL1No1TestThickMM
        End If


        If IsNothing(InputTextBox) Then
            Exit Sub
        End If
        Select Case True
            Case Value = "DELETE" AndAlso InputTextBox.Text.Length > 0
                InputTextBox.Text = InputTextBox.Text.Substring(0, InputTextBox.Text.Length - 1)
            Case Value = "DELETE"
            Case Value = "CLEAR"
                InputTextBox.Text = ""
            Case Value = "DOT" AndAlso (InputTextBox Is tbAPL1No1TestThickMM OrElse InputTextBox Is tbAPL2BATestHeadMM OrElse InputTextBox Is tbAPL2BATestTailMM)
                InputTextBox.SelectedText = ""
                If InputTextBox.Text.Length < 5 Then
                    InputTextBox.Text &= "."
                End If
            Case Value = "OK"
            Case Else
                InputTextBox.SelectedText = ""
                If InputTextBox.Text.Length < 5 Then
                    InputTextBox.Text &= Value
                End If
        End Select

    End Sub

    'Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
    '    If Me.SaveControlDataToDB() > 0 Then
    '        Dim SetMaxLength As Long = Me.QABugRecordOtherDataEdit.CoilMaxLength
    '        Dim SaveDataCount As Integer = 0
    '        For Each EachItem As BugItemMinDisplay In Me.ParentMainControl.QABugRecordShowControls
    '            If EachItem.QABugRecordData.EditEmployeeID.Trim = Me.ParentMainControl.LoginID.Trim Then
    '                EachItem.QABugRecordData.CoilMaxLength = SetMaxLength
    '                SaveDataCount += EachItem.QABugRecordData.CDBSave()
    '            End If
    '        Next
    '        RaiseEvent MessageEvent("成功儲存APL1其它資訊!")
    '        RaiseEvent CallBackEvent(Me, "OK")
    '    Else
    '        RaiseEvent MessageEvent("儲存APL1其它資訊失敗!")
    '    End If
    'End Sub

    Private Sub rbAPL1IsNo1GetTest1_CheckedChanged(sender As Object, e As EventArgs) Handles rbAPL1IsNo1GetTest1.CheckedChanged, rbAPL1IsNo1GetTest2.CheckedChanged, rbAPL1IsNo1GetTest3.CheckedChanged
        tbAPL1No1TestThickMM.Enabled = rbAPL1IsNo1GetTest2.Checked
        If tbAPL1No1TestThickMM.Enabled Then
            tbAPL1No1TestThickMM.BackColor = Color.PaleGreen
            tbAPL1No1TestThickMM.SelectAll()
            tbCoilMaxLength.BackColor = Color.White
        End If
    End Sub

    Private Sub btnAssignEndTime_Click(sender As Object, e As EventArgs) Handles btnAssignEndTime.Click
        If Me.ParentMainControl.CanEditCoilFullNumberIsOnLineCoilFullNumberState AndAlso Not IsNothing(Me.ParentMainControl.CurrentEditQABugRecordTitle) Then
            If MsgBox("是否定指定現在時間為鋼捲結束時間", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.ParentMainControl.CurrentEditQABugRecordTitle.CoilEndTime = System.DateTime.Now()
                Me.ParentMainControl.CurrentEditQABugRecordTitle.CDBSave()
                Me.InitControlValue()
            End If
        End If
    End Sub


    ''' <summary>
    ''' 106/08/17 ADD 
    ''' </summary>
    ''' <remarks></remarks>
    '#Region "重整RadioBtn 上下收"
    '    Public Sub refreshRadioBtn_upAndDown() Implements IxxxTitleEdit.refreshRadioBtn_upAndDown

    '        ''APL1 預設下收
    '        radBtn_UP.Checked = False
    '        radBtn_Down.Checked = True
    '    End Sub
    '#End Region


    '#Region "回傳RadioBtn 上下收狀態"
    '    Public Sub getUpDown_Status(ByRef status As String) Implements IxxxTitleEdit.getUpDown_Status
    '        If radBtn_UP.Checked = True And radBtn_Down.Checked = False Then
    '            status = "上收"
    '        ElseIf radBtn_UP.Checked = False And radBtn_Down.Checked = True Then
    '            status = "下收"
    '        Else
    '            status = "none"
    '        End If
    '    End Sub
    '#End Region

    '#Region "設定RadioBtn 上下收狀態"
    '    Public Sub SetUpDown_Status(ByVal status As String) Implements IxxxTitleEdit.SetUpDown_Status

    '        If status = "上收" Then
    '            radBtn_UP.Checked = True
    '            radBtn_Down.Checked = False
    '        ElseIf status = "下收" Then
    '            radBtn_UP.Checked = False
    '            radBtn_Down.Checked = True
    '        Else
    '            radBtn_UP.Checked = False
    '            radBtn_Down.Checked = False
    '        End If
    '    End Sub
    '#End Region


End Class
