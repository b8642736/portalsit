Public Class APL2OthersEdit
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
    ''' CoilPositionErrLength
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

        For Each EachControl As Control In FlowLayoutPanel3.Controls
            If TypeOf EachControl Is TextBox Then
                AddHandler CType(EachControl, TextBox).MouseClick, AddressOf tbInputTextBox_Click
            End If
        Next
        AddHandler tbCoilPositionErrLength.MouseClick, AddressOf tbInputTextBox_Click

        With Me.ParentMainControl.CurrentEditQABugRecordTitle
            tbAPL2ThickMM.Text = .APL2ThickMM
            tbAPL2BATestHeadMM.Text = .APL2BATestHeadMM
            tbAPL2BATestTailMM.Text = .APL2BATestTailMM
            tbCoilMaxLength.Text = .CoilMaxLength
            Select Case True
                Case .APL2IsExportPackage = 1
                    rbAPL2IsExportPackage2.Checked = True
                Case .APL2IsExportPackage = 2
                    rbAPL2IsExportPackage3.Checked = True
                Case Else
                    rbAPL2IsExportPackage1.Checked = True
            End Select
            tbCoilMaxLength.Text = .CoilMaxLength
            tbCoilPositionErrLength.Text = -(.CoilPositionErrLength)
            tbJointLength.Text = .JointLength
            lbCoilStartTime.Text = Format(.CoilStartTime, "yyyy/MM/dd HH:mm:ss")
            lbCoilEndTime.Text = Format(.CoilEndTime, "yyyy/MM/dd HH:mm:ss")
            cbIsUpdateFromL2Value.Checked = .IsUpdateFromL2Value

        End With

        tbInputTextBox_Click(tbAPL2ThickMM, Nothing)
        tbAPL2ThickMM.SelectAll()

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
            .APL2ThickMM = tbAPL2ThickMM.Text
            .APL2BATestHeadMM = tbAPL2BATestHeadMM.Text
            .APL2BATestTailMM = tbAPL2BATestTailMM.Text
            .CoilMaxLength = tbCoilMaxLength.Text
            .OutCoilNumber = Me.ParentMainControl.EditOutCoilNumber
            Select Case True
                Case rbAPL2IsExportPackage2.Checked
                    .APL2IsExportPackage = 1
                Case rbAPL2IsExportPackage3.Checked
                    .APL2IsExportPackage = 2
                Case rbAPL2IsExportPackage1.Checked
                    .APL2IsExportPackage = 0
            End Select
            .CoilMaxLength = tbCoilMaxLength.Text
            .CoilPositionErrLength = -Val(tbCoilPositionErrLength.Text)
            .JointLength = Val(tbJointLength.Text)
            .CoilStartTime = CType(lbCoilStartTime.Text, DateTime)
            .CoilEndTime = CType(lbCoilEndTime.Text, DateTime)
            .IsUpdateFromL2Value = cbIsUpdateFromL2Value.Checked
            .LastEditEmployeeID = Me.ParentMainControl.LoginID
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
            RaiseEvent MessageEvent("成功儲存APL2其它資訊!")
        Else
            RaiseEvent MessageEvent("儲存APL2其它資訊失敗!")
        End If
        Return ReturnValue

        'With Me.QABugRecordOtherDataEdit
        '    .CoilNumber = Me.ParentMainControl.EditCoilNumber
        '    .DataDate = Me.ParentMainControl.EditDataDate
        '    .StationName = Me.ParentMainControl.EditStationName
        '    .Version = Me.ParentMainControl.EditDataDateVersion
        '    .APL2ThickMM = tbAPL2ThickMM.Text
        '    .APL2BATestHeadMM = tbAPL2BATestHeadMM.Text
        '    .APL2BATestTailMM = tbAPL2BATestTailMM.Text
        '    .CoilMaxLength = tbCoilMaxLength.Text
        '    Select Case True
        '        Case rbAPL2IsExportPackage2.Checked
        '            .APL2IsExportPackage = 1
        '        Case rbAPL2IsExportPackage3.Checked
        '            .APL2IsExportPackage = 2
        '        Case rbAPL2IsExportPackage1.Checked
        '            .APL2IsExportPackage = 0
        '    End Select
        '    .CoilMaxLength = tbCoilMaxLength.Text
        '    .CoilPositionErrLength = -Val(tbCoilPositionErrLength.Text)
        '    .CoilMaxAddJointLength = Val(tbCoilMaxAddJointLength.Text)
        '    .CoilStartTime = CType(lbCoilStartTime.Text, DateTime)
        '    .CoilEndTime = CType(lbCoilEndTime.Text, DateTime)
        '    .IsUpdateFromL2Value = cbIsUpdateFromL2Value.Checked

        '    Dim ReturnValue As Integer = .CDBSave
        '    If ReturnValue > 0 Then
        '        RaiseEvent MessageEvent("成功儲存APL2其它資訊!")
        '    Else
        '        RaiseEvent MessageEvent("儲存APL2其它資訊失敗!")
        '    End If
        '    Return ReturnValue
        'End With
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
        For Each EachControl As Control In FlowLayoutPanel3.Controls
            If TypeOf EachControl Is TextBox Then
                EachControl.BackColor = Color.White
            End If
        Next
        SelectControl.BackColor = Color.PaleGreen
        SelectControl.SelectAll()
    End Sub

    Private Sub NumberKeyboardEvent_ButtonClickEvent(sender As Object, Value As String) Handles NumberKeyboardEvent.ButtonClickEvent
        Dim InputTextBox As TextBox = Nothing
        For Each EachControl As Control In TableLayoutPanel2.Controls
            If TypeOf EachControl Is TextBox AndAlso EachControl.BackColor = Color.PaleGreen Then
                InputTextBox = EachControl : Exit For
            End If
        Next
        If IsNothing(InputTextBox) Then
            For Each EachControl As Control In FlowLayoutPanel3.Controls
                If TypeOf EachControl Is TextBox AndAlso EachControl.BackColor = Color.PaleGreen Then
                    InputTextBox = EachControl : Exit For
                End If
            Next
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
            Case Value = "DOT" AndAlso Not (InputTextBox Is tbAPL2BATestHeadMM OrElse InputTextBox Is tbAPL2BATestTailMM OrElse InputTextBox Is tbAPL2ThickMM)

            Case Value = "DOT" AndAlso (InputTextBox Is tbAPL2BATestHeadMM OrElse InputTextBox Is tbAPL2BATestTailMM OrElse InputTextBox Is tbAPL2ThickMM)
                InputTextBox.SelectedText = ""
                If InputTextBox.Text.Contains(".") Then  '防呆避免出現兩次逗點
                    Exit Sub
                End If
                If InputTextBox.Text.Length < 5 Then
                    InputTextBox.Text &= "."
                End If
            Case Value = "OK"
            Case Else
                InputTextBox.SelectedText = ""
                If InputTextBox.Text.Contains(".") AndAlso InputTextBox.Text.Split(".")(1).Length >= 2 Then '防呆限制只能打小數2位
                    Exit Sub
                End If
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
    '        RaiseEvent MessageEvent("成功儲存APL2其它資訊!")
    '        RaiseEvent CallBackEvent(Me, "OK")
    '    Else
    '        RaiseEvent MessageEvent("儲存APL2其它資訊失敗!")
    '    End If
    'End Sub


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

    '        ''APL2 預設不選
    '        radBtn_UP.Checked = False
    '        radBtn_Down.Checked = False
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
