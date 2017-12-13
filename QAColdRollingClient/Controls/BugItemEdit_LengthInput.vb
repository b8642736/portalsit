Public Class BugItemEdit_LengthInput

    Public Event LengthInputCallBackEvent(ByVal Sender As BugItemEdit_LengthInput)

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
#Region "數字輸入控項輸出值 屬性:NumberKeyboardControlValue"
    Private _NumberKeyboardControlValue As String
    ''' <summary>
    ''' 數字輸入控項輸出值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NumberKeyboardControlValue() As String
        Get
            Return _NumberKeyboardControlValue
        End Get
        Private Set(ByVal value As String)
            _NumberKeyboardControlValue = value
        End Set
    End Property

#End Region
#Region "輸入模式 屬性:InputMode"
    Private _InputMode As InputModeEnum = InputModeEnum.Length
    ''' <summary>
    ''' 輸入模式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property InputMode As InputModeEnum
        Get
            Return _InputMode
        End Get
        Set(value As InputModeEnum)
            _InputMode = value
            RefreshControlEnableOrVisible()
        End Set
    End Property
#End Region
#Region "輸入模式列舉 列舉:InputModeEnum"
    ''' <summary>
    ''' 輸入模式列舉
    ''' </summary>
    ''' <remarks></remarks>
    Enum InputModeEnum
        Length = 1
        DistributePosition = 2
        Cycle = 3
    End Enum
#End Region
#Region "重整顯示 函式:RefreshControlEnableOrVisible"
    ''' <summary>
    ''' 重整顯示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshControlEnableOrVisible()
        tbStartLength.Visible = False
        btnSlash.Visible = False
        tbEndLength.Visible = False
        flpPositionWidthArial.Visible = False
        flpPositionLengthArial.Visible = False
        pbGetL2Msg1.Visible = False
        pbGetL2Msg2.Visible = False
        Select Case InputMode
            Case InputModeEnum.Length
                lbInputCaption.Text = "長:"
                tbStartLength.Visible = True
                btnSlash.Visible = True
                tbEndLength.Visible = True
                flpPositionLengthArial.Visible = True
                pbGetL2Msg1.Visible = True
                pbGetL2Msg2.Visible = True
                Call tbStartLength_Click(tbStartLength, Nothing)
            Case InputModeEnum.DistributePosition
                lbInputCaption.Text = "寬:"
                tbStartLength.Visible = True
                btnSlash.Visible = True
                tbEndLength.Visible = True
                flpPositionWidthArial.Visible = True
                flpPositionLengthArial.Visible = True
                NumberKeyboardControl.InputMode = NumberKeyboard.InputModeEnum.DistributeLocationType
                If rbAll.Checked OrElse rbNone.Checked Then
                    tbStartLength.Visible = False
                    btnSlash.Visible = False
                    tbEndLength.Visible = False
                    flpPositionLengthArial.Visible = False
                End If
            Case InputModeEnum.Cycle
                lbInputCaption.Text = "周期:"
                tbStartLength.Visible = True
                Call tbStartLength_Click(tbStartLength, Nothing)
        End Select
        If Not (tbStartLength.BackColor = Color.Pink AndAlso tbEndLength.BackColor = Color.Pink) Then
            flpPositionWidthArial.BackColor = Color.Pink
        Else
            flpPositionWidthArial.BackColor = flpPositionWidthArial.Parent.BackColor
        End If
    End Sub
#End Region
#Region "初始化控制項值 屬性:InitControlValue"
    ''' <summary>
    ''' 初始化控制項值
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitControlValue(ByVal SetEditQABugRecord As QABugRecord)
        Me.EditQABugRecord = SetEditQABugRecord

        Select Case True
            Case InputMode = InputModeEnum.Length
                tbStartLength.Text = EditQABugRecord.StartPosition
                tbEndLength.Text = EditQABugRecord.EndPosition
                tbStartLength_Click(tbStartLength, Nothing)
            Case InputMode = InputModeEnum.DistributePosition
                tbStartLength.Text = EditQABugRecord.DPositionStart
                tbEndLength.Text = EditQABugRecord.DPositionEnd
                tbStartLength_Click(tbStartLength, Nothing)
                flpPositionWidthArial.BackColor = Color.Pink
            Case InputMode = InputModeEnum.Cycle
                tbStartLength.Text = EditQABugRecord.Cycle
        End Select

        Select Case SetEditQABugRecord.DPositionType
            Case 1
                rbIn.Checked = True
            Case 2
                rbOut.Checked = True
            Case 3
                rbAll.Checked = True
            Case 4
                rbTwo.Checked = True
            Case 5
                rbNone.Checked = True
        End Select

    End Sub
#End Region

#Region "啟始值 屬性:StartValue"
    ''' <summary>
    ''' 啟始值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property StartValue As Integer
        Get
            Return Val(Me.tbStartLength.Text)
        End Get
    End Property
#End Region
#Region "終止值 屬性:EndValue"
    ''' <summary>
    ''' 終止值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property EndValue As Integer
        Get
            Return Val(Me.tbEndLength.Text)
        End Get
    End Property
#End Region
#Region "分佈位置型態值 屬性:PositionSelectValue"
    ''' <summary>
    ''' 分佈位置型態值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PositionSelectValue As Integer
        Get
            Select Case True
                Case rbIn.Checked
                    Return 1
                Case rbOut.Checked
                    Return 2
                Case rbAll.Checked
                    Return 3
                Case rbTwo.Checked
                    Return 4
                Case rbNone.Checked
                    Return 5
            End Select
            Return -1
        End Get
    End Property
#End Region

    Sub New(ByVal SetParentMainControl As MainControl)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        ParentMainControl = SetParentMainControl

        KeyBoardPanel.Controls.Add(NumberKeyboardControl)
    End Sub


    Private Sub tbStartLength_Click(sender As Object, e As EventArgs) Handles tbStartLength.Click, tbEndLength.Click
        If Me.InputMode = InputModeEnum.DistributePosition Then
            NumberKeyboardControl.InputMode = NumberKeyboard.InputModeEnum.UnKnow
        End If
        flpPositionWidthArial.BackColor = flpPositionWidthArial.Parent.BackColor
        tbStartLength.BackColor = Color.White
        tbEndLength.BackColor = Color.White
        CType(sender, TextBox).BackColor = Color.Pink
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub rbIn_CheckedChanged(sender As Object, e As EventArgs) Handles rbIn.CheckedChanged, rbOut.CheckedChanged, rbTwo.CheckedChanged, rbAll.CheckedChanged, rbNone.CheckedChanged
        flpPositionWidthArial.BackColor = Color.Pink
        tbStartLength.BackColor = BugItemEdit_LengthInput.DefaultBackColor
        tbEndLength.BackColor = BugItemEdit_LengthInput.DefaultBackColor
        RefreshControlEnableOrVisible()
        Me.NumberKeyboardControlValue = ""
        RaiseEvent LengthInputCallBackEvent(Me)
    End Sub

    Private Sub NumberKeyboardEvent_ButtonClickEvent(sender As Object, Value As String) Handles NumberKeyboardEvent.ButtonClickEvent
        NumberKeyboardControlValue = Value
        Dim InputTextBox As TextBox = Nothing
        If tbStartLength.BackColor = Color.Pink Then
            InputTextBox = tbStartLength
        End If
        If tbEndLength.BackColor = Color.Pink Then
            InputTextBox = tbEndLength
        End If
        Select Case True
            Case InputMode = InputModeEnum.DistributePosition
                If flpPositionWidthArial.BackColor = Color.Pink Then
                    tbStartLength.BackColor = BugItemEdit_LengthInput.DefaultBackColor
                    tbEndLength.BackColor = BugItemEdit_LengthInput.DefaultBackColor
                    Select Case True
                        Case rbAll.Checked = True AndAlso Value = "OK"
                            RaiseEvent LengthInputCallBackEvent(Me)
                        Case rbIn.Checked = True AndAlso Value = "OK"
                            rbIn.Checked = True
                            NumberKeyboardControl.InputMode = NumberKeyboard.InputModeEnum.UnKnow
                            Call tbStartLength_Click(tbStartLength, Nothing)
                            flpPositionWidthArial.BackColor = BugItemEdit_LengthInput.DefaultBackColor
                            Exit Sub
                            'Case rbMiddle.Checked = True AndAlso Value = "OK"
                            '    rbMiddle.Checked = True
                            '    Call tbStartLength_Click(tbStartLength, Nothing)
                            '    flpPositionWidthArial.BackColor = BugItemEdit_LengthInput.DefaultBackColor
                            '    Exit Sub
                        Case rbOut.Checked = True AndAlso Value = "OK"
                            rbOut.Checked = True
                            NumberKeyboardControl.InputMode = NumberKeyboard.InputModeEnum.UnKnow
                            Call tbStartLength_Click(tbStartLength, Nothing)
                            flpPositionWidthArial.BackColor = BugItemEdit_LengthInput.DefaultBackColor
                            Exit Sub
                        Case rbTwo.Checked = True AndAlso Value = "OK"
                            rbTwo.Checked = True
                            NumberKeyboardControl.InputMode = NumberKeyboard.InputModeEnum.UnKnow
                            Call tbStartLength_Click(tbStartLength, Nothing)
                            flpPositionWidthArial.BackColor = BugItemEdit_LengthInput.DefaultBackColor
                            Exit Sub
                        Case rbNone.Checked = True AndAlso Value = "OK"
                            RaiseEvent LengthInputCallBackEvent(Me)
                        Case Value = "1"
                            rbIn.Checked = True
                        Case Value = "2"
                            rbOut.Checked = True
                        Case Value = "3"
                            rbAll.Checked = True
                        Case Value = "4"
                            rbTwo.Checked = True
                        Case Value = "5"
                            rbNone.Checked = True
                    End Select
                    RaiseEvent LengthInputCallBackEvent(Me)
                    Exit Sub
                Else
                    Select Case True
                        Case IsNothing(InputTextBox)
                            Exit Sub
                        Case InputTextBox Is tbStartLength AndAlso Value = "OK"
                            Call tbStartLength_Click(tbEndLength, Nothing)
                            Exit Sub
                        Case InputTextBox Is tbEndLength AndAlso Value = "OK"
                            RaiseEvent LengthInputCallBackEvent(Me)
                            Exit Sub
                    End Select
                End If
            Case InputMode = InputModeEnum.Length
                Select Case True
                    Case IsNothing(InputTextBox)
                        Exit Sub
                    Case InputTextBox Is tbStartLength AndAlso Value = "OK"
                        Call tbStartLength_Click(tbEndLength, Nothing)
                    Case InputTextBox Is tbEndLength AndAlso Value = "OK"
                        RaiseEvent LengthInputCallBackEvent(Me)
                End Select
            Case InputMode = InputModeEnum.Cycle
                Select Case True
                    Case IsNothing(InputTextBox)
                        Exit Sub
                    Case InputTextBox Is tbStartLength AndAlso Value = "OK"
                        RaiseEvent LengthInputCallBackEvent(Me)
                End Select
        End Select

        Select Case True
            Case Value = "DELETE" AndAlso InputTextBox.Text.Length > 0
                InputTextBox.Text = InputTextBox.Text.Substring(0, InputTextBox.Text.Length - 1)
            Case Value = "DELETE"
            Case Value = "CLEAR"
                InputTextBox.Text = ""
            Case Value = "DOT"
            Case Value = "OK"
            Case Else
                InputTextBox.SelectedText = ""
                If InputTextBox.Text.Length < 6 Then
                    InputTextBox.Text &= Value
                End If

                If Me.EditQABugRecord.Degree = 0 And InputMode = InputModeEnum.Length Then   '如果程度為0則長度位置為單點
                    If InputTextBox Is tbStartLength Then
                        tbEndLength.Text = tbStartLength.Text
                    Else
                        tbStartLength.Text = tbEndLength.Text
                    End If
                End If

                RaiseEvent LengthInputCallBackEvent(Me)
        End Select
    End Sub


    Private Sub pbGetL2Msg1_Click(sender As Object, e As EventArgs) Handles pbGetL2Msg1.Click, pbGetL2Msg2.Click
        Select Case True
            Case sender Is pbGetL2Msg1
                Select Case True
                    Case Me.ParentMainControl.CanEditStationLine = "APL1"
                        tbStartLength.Text = Me.ParentMainControl.APL1CoilPosition
                    Case Me.ParentMainControl.CanEditStationLine = "APL2"
                        tbStartLength.Text = Me.ParentMainControl.APL2CoilPosition
                    Case Me.ParentMainControl.CanEditStationLine = "BAL"
                        tbStartLength.Text = Me.ParentMainControl.BALCoilPosition
                End Select
            Case sender Is pbGetL2Msg2
                Select Case True
                    Case Me.ParentMainControl.CanEditStationLine = "APL1"
                        tbEndLength.Text = Me.ParentMainControl.APL1CoilPosition
                    Case Me.ParentMainControl.CanEditStationLine = "APL2"
                        tbEndLength.Text = Me.ParentMainControl.APL2CoilPosition
                    Case Me.ParentMainControl.CanEditStationLine = "BAL"
                        tbEndLength.Text = Me.ParentMainControl.BALCoilPosition
                End Select
        End Select

        If Me.EditQABugRecord.Degree = 0 And InputMode = InputModeEnum.Length Then   '如果程度為0則長度位置為單點
            If sender Is pbGetL2Msg1 Then
                tbEndLength.Text = tbStartLength.Text
            Else
                tbStartLength.Text = tbEndLength.Text
            End If
        End If

        'RaiseEvent LengthInputCallBackEvent(Me)
    End Sub

    Private Sub btnSlash_Click(sender As Object, e As EventArgs) Handles btnSlash.Click
        tbEndLength.Text = tbStartLength.Text
    End Sub

    Private Sub tbStartLength_TextChanged(sender As Object, e As EventArgs) Handles tbStartLength.TextChanged

    End Sub

    Private Sub tbEndLength_TextChanged(sender As Object, e As EventArgs) Handles tbEndLength.TextChanged

    End Sub
End Class
