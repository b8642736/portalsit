Public Class BALOthersEdit
    Implements IxxxTitleEdit

    Public Event CallBackEvent(ByVal Sender As IxxxTitleEdit, ByVal ReturnValue As String) Implements IxxxTitleEdit.CallBackEvent
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

        For Each EachControl As Control In TableLayoutPanel3.Controls
            If TypeOf EachControl Is TextBox Then
                AddHandler CType(EachControl, TextBox).MouseClick, AddressOf tbInputTextBox_Click
            End If
        Next
        For Each EachControl As Control In TableLayoutPanel4.Controls
            If TypeOf EachControl Is TextBox Then
                AddHandler CType(EachControl, TextBox).MouseClick, AddressOf tbInputTextBox_Click
            End If
        Next
        AddHandler tbCoilPositionErrLength.MouseClick, AddressOf tbInputTextBox_Click


        With Me.ParentMainControl.CurrentEditQABugRecordTitle
            tbBALPBrightLengthMM1.Text = .BALPBrightLengthMM1
            tbBALPBrightLengthMM2.Text = .BALPBrightLengthMM2
            tbBALPBrightLengthMM3.Text = .BALPBrightLengthMM3
            tbBALPBrightLengthMM4.Text = .BALPBrightLengthMM4
            tbBALPBrightLengthMM5.Text = .BALPBrightLengthMM5
            tbBALPBrightLengthMM6.Text = .BALPBrightLengthMM6
            tbBALNBrightLengthMM1.Text = .BALNBrightLengthMM1
            tbBALNBrightLengthMM2.Text = .BALNBrightLengthMM2
            tbBALNBrightLengthMM3.Text = .BALNBrightLengthMM3
            tbBALNBrightLengthMM4.Text = .BALNBrightLengthMM4
            tbBALNBrightLengthMM5.Text = .BALNBrightLengthMM5
            tbBALNBrightLengthMM6.Text = .BALNBrightLengthMM6

            tbBALPBrightCenterMM1.Text = .BALPBrightCenterMM1
            tbBALPBrightCenterMM2.Text = .BALPBrightCenterMM2
            tbBALPBrightCenterMM3.Text = .BALPBrightCenterMM3
            tbBALPBrightCenterMM4.Text = .BALPBrightCenterMM4
            tbBALPBrightCenterMM5.Text = .BALPBrightCenterMM5
            tbBALPBrightCenterMM6.Text = .BALPBrightCenterMM6
            tbBALNBrightCenterMM1.Text = .BALNBrightCenterMM1
            tbBALNBrightCenterMM2.Text = .BALNBrightCenterMM2
            tbBALNBrightCenterMM3.Text = .BALNBrightCenterMM3
            tbBALNBrightCenterMM4.Text = .BALNBrightCenterMM4
            tbBALNBrightCenterMM5.Text = .BALNBrightCenterMM5
            tbBALNBrightCenterMM6.Text = .BALNBrightCenterMM6

            tbBALPBrightSideMM1.Text = .BALPBrightSideMM1
            tbBALPBrightSideMM2.Text = .BALPBrightSideMM2
            tbBALPBrightSideMM3.Text = .BALPBrightSideMM3
            tbBALPBrightSideMM4.Text = .BALPBrightSideMM4
            tbBALPBrightSideMM5.Text = .BALPBrightSideMM5
            tbBALPBrightSideMM6.Text = .BALPBrightSideMM6
            tbBALNBrightSideMM1.Text = .BALNBrightSideMM1
            tbBALNBrightSideMM2.Text = .BALNBrightSideMM2
            tbBALNBrightSideMM3.Text = .BALNBrightSideMM3
            tbBALNBrightSideMM4.Text = .BALNBrightSideMM4
            tbBALNBrightSideMM5.Text = .BALNBrightSideMM5
            tbBALNBrightSideMM6.Text = .BALNBrightSideMM6

            tbBALSection1PositionMM.Text = .BALSection1PositionMM
            tbBALSection2PositionMM.Text = .BALSection2PositionMM
            tbBALSection3PositionMM.Text = .BALSection3PositionMM
            tbBALSection4PositionMM.Text = .BALSection4PositionMM
            tbBALSection1OperateMM.Text = .BALSection1OperateMM
            tbBALSection2OperateMM.Text = .BALSection2OperateMM
            tbBALSection3OperateMM.Text = .BALSection3OperateMM
            tbBALSection4OperateMM.Text = .BALSection4OperateMM
            tbBALSection1MiddleMM.Text = .BALSection1MiddleMM
            tbBALSection2MiddleMM.Text = .BALSection2MiddleMM
            tbBALSection3MiddleMM.Text = .BALSection3MiddleMM
            tbBALSection4MiddleMM.Text = .BALSection4MiddleMM
            tbBALSection1PowerMM.Text = .BALSection1PowerMM
            tbBALSection2PowerMM.Text = .BALSection2PowerMM
            tbBALSection3PowerMM.Text = .BALSection3PowerMM
            tbBALSection4PowerMM.Text = .BALSection4PowerMM

            tbAPL2BATestHeadMM.Text = .APL2BATestHeadMM
            tbAPL2BATestTailMM.Text = .APL2BATestTailMM

            tbCoilMaxLength.Text = .CoilMaxLength
            tbCoilPositionErrLength.Text = -(.CoilPositionErrLength)
            tbJointLength.Text = .JointLength
            lbCoilStartTime.Text = Format(.CoilStartTime, "yyyy/MM/dd HH:mm:ss")
            lbCoilEndTime.Text = Format(.CoilEndTime, "yyyy/MM/dd HH:mm:ss")
            cbIsUpdateFromL2Value.Checked = .IsUpdateFromL2Value


        End With

        tbInputTextBox_Click(tbBALPBrightLengthMM1, Nothing)
        tbBALPBrightLengthMM1.SelectAll()

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
            .BALPBrightLengthMM1 = Val(tbBALPBrightLengthMM1.Text)
            .BALPBrightLengthMM2 = Val(tbBALPBrightLengthMM2.Text)
            .BALPBrightLengthMM3 = Val(tbBALPBrightLengthMM3.Text)
            .BALPBrightLengthMM4 = Val(tbBALPBrightLengthMM4.Text)
            .BALPBrightLengthMM5 = Val(tbBALPBrightLengthMM5.Text)
            .BALPBrightLengthMM6 = Val(tbBALPBrightLengthMM6.Text)
            .BALNBrightLengthMM1 = Val(tbBALNBrightLengthMM1.Text)
            .BALNBrightLengthMM2 = Val(tbBALNBrightLengthMM2.Text)
            .BALNBrightLengthMM3 = Val(tbBALNBrightLengthMM3.Text)
            .BALNBrightLengthMM4 = Val(tbBALNBrightLengthMM4.Text)
            .BALNBrightLengthMM5 = Val(tbBALNBrightLengthMM5.Text)
            .BALNBrightLengthMM6 = Val(tbBALNBrightLengthMM6.Text)

            .BALPBrightCenterMM1 = Val(tbBALPBrightCenterMM1.Text)
            .BALPBrightCenterMM2 = Val(tbBALPBrightCenterMM2.Text)
            .BALPBrightCenterMM3 = Val(tbBALPBrightCenterMM3.Text)
            .BALPBrightCenterMM4 = Val(tbBALPBrightCenterMM4.Text)
            .BALPBrightCenterMM5 = Val(tbBALPBrightCenterMM5.Text)
            .BALPBrightCenterMM6 = Val(tbBALPBrightCenterMM6.Text)
            .BALNBrightCenterMM1 = Val(tbBALNBrightCenterMM1.Text)
            .BALNBrightCenterMM2 = Val(tbBALNBrightCenterMM2.Text)
            .BALNBrightCenterMM3 = Val(tbBALNBrightCenterMM3.Text)
            .BALNBrightCenterMM4 = Val(tbBALNBrightCenterMM4.Text)
            .BALNBrightCenterMM5 = Val(tbBALNBrightCenterMM5.Text)
            .BALNBrightCenterMM6 = Val(tbBALNBrightCenterMM6.Text)

            .BALPBrightSideMM1 = Val(tbBALPBrightSideMM1.Text)
            .BALPBrightSideMM2 = Val(tbBALPBrightSideMM2.Text)
            .BALPBrightSideMM3 = Val(tbBALPBrightSideMM3.Text)
            .BALPBrightSideMM4 = Val(tbBALPBrightSideMM4.Text)
            .BALPBrightSideMM5 = Val(tbBALPBrightSideMM5.Text)
            .BALPBrightSideMM6 = Val(tbBALPBrightSideMM6.Text)
            .BALNBrightSideMM1 = Val(tbBALNBrightSideMM1.Text)
            .BALNBrightSideMM2 = Val(tbBALNBrightSideMM2.Text)
            .BALNBrightSideMM3 = Val(tbBALNBrightSideMM3.Text)
            .BALNBrightSideMM4 = Val(tbBALNBrightSideMM4.Text)
            .BALNBrightSideMM5 = Val(tbBALNBrightSideMM5.Text)
            .BALNBrightSideMM6 = Val(tbBALNBrightSideMM6.Text)



            .BALSection1PositionMM = Val(tbBALSection1PositionMM.Text)
            .BALSection2PositionMM = Val(tbBALSection2PositionMM.Text)
            .BALSection3PositionMM = Val(tbBALSection3PositionMM.Text)
            .BALSection4PositionMM = Val(tbBALSection4PositionMM.Text)
            .BALSection1OperateMM = Val(tbBALSection1OperateMM.Text)
            .BALSection2OperateMM = Val(tbBALSection2OperateMM.Text)
            .BALSection3OperateMM = Val(tbBALSection3OperateMM.Text)
            .BALSection4OperateMM = Val(tbBALSection4OperateMM.Text)
            .BALSection1MiddleMM = Val(tbBALSection1MiddleMM.Text)
            .BALSection2MiddleMM = Val(tbBALSection2MiddleMM.Text)
            .BALSection3MiddleMM = Val(tbBALSection3MiddleMM.Text)
            .BALSection4MiddleMM = Val(tbBALSection4MiddleMM.Text)
            .BALSection1PowerMM = Val(tbBALSection1PowerMM.Text)
            .BALSection2PowerMM = Val(tbBALSection2PowerMM.Text)
            .BALSection3PowerMM = Val(tbBALSection3PowerMM.Text)
            .BALSection4PowerMM = Val(tbBALSection4PowerMM.Text)

            .APL2BATestHeadMM = Val(tbAPL2BATestHeadMM.Text)
            .APL2BATestTailMM = Val(tbAPL2BATestTailMM.Text)

            .CoilMaxLength = Val(tbCoilMaxLength.Text)
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
            RaiseEvent MessageEvent("成功儲存BAL其它資訊!")
        Else
            RaiseEvent MessageEvent("儲存BAL其它資訊失敗!")
        End If
        Return ReturnValue
    End Function
#End Region

#Region "文字輸入完成位移 函式:TextBoxInputCompleteMove"
    ''' <summary>
    ''' 文字輸入完成位移
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub TextBoxInputCompleteMove(sender As Object, e As KeyEventArgs)
        Dim SenderButtonName As String = sender.Name
        Dim NextGoButtonName As String = Nothing
        Dim InputTextBox As TextBox = Nothing

        If SenderButtonName.Contains("Bright") Then
            Select Case True
                Case SenderButtonName.Contains("Length")
                    NextGoButtonName = SenderButtonName.Replace("Length", "Center")
                Case SenderButtonName.Contains("Center")
                    NextGoButtonName = SenderButtonName.Replace("Center", "Side")
                Case SenderButtonName.Contains("Side")
                    NextGoButtonName = SenderButtonName.Replace("Side", "Length")
                    Dim SenderColumnNumber As Integer = CType(SenderButtonName.Replace(SenderButtonName.Substring(0, SenderButtonName.Length - 1), Nothing), Integer)
                    Dim NextColumnNumber As Integer = 0
                    If SenderColumnNumber >= 6 Then
                        NextColumnNumber = 1
                    Else
                        NextColumnNumber = SenderColumnNumber + 1
                    End If
                    NextGoButtonName = NextGoButtonName.Replace(CType(SenderColumnNumber, String), CType(NextColumnNumber, String))
            End Select
            For Each EachControl As Control In TableLayoutPanel2.Controls
                If TypeOf EachControl Is TextBox AndAlso EachControl.Name = NextGoButtonName Then
                    InputTextBox = EachControl
                End If
            Next
        End If

        If IsNothing(InputTextBox) AndAlso SenderButtonName.Contains("Section") Then
            Select Case True
                Case SenderButtonName.Contains("Position")
                    NextGoButtonName = SenderButtonName.Replace("Position", "Operate")
                Case SenderButtonName.Contains("Operate")
                    NextGoButtonName = SenderButtonName.Replace("Operate", "Middle")
                Case SenderButtonName.Contains("Middle")
                    NextGoButtonName = SenderButtonName.Replace("Middle", "Power")
                Case SenderButtonName.Contains("Power")
                    NextGoButtonName = SenderButtonName.Replace("Power", "Position")
                    Dim SenderColumnNumber As Integer = CType(SenderButtonName.Replace("tbBALSection", Nothing).Substring(0, 1), Integer)
                    Dim NextColumnNumber As Integer = 0
                    If SenderColumnNumber >= 4 Then
                        NextColumnNumber = 1
                    Else
                        NextColumnNumber = SenderColumnNumber + 1
                    End If
                    NextGoButtonName = NextGoButtonName.Replace(CType(SenderColumnNumber, String), CType(NextColumnNumber, String))
            End Select
            If IsNothing(InputTextBox) Then
                For Each EachControl As Control In TableLayoutPanel3.Controls
                    If TypeOf EachControl Is TextBox AndAlso EachControl.Name = NextGoButtonName Then
                        InputTextBox = EachControl
                    End If
                Next
            End If
        End If

        If Not IsNothing(InputTextBox) Then
            Call tbInputTextBox_Click(InputTextBox, Nothing)
            InputTextBox.Focus()
        End If
    End Sub

#End Region

#Region "設定亮度米數 函式:SetBrightLengthMM"
    ''' <summary>
    ''' 設定亮度米數
    ''' </summary>
    ''' <param name="BALPBrightLengthMM"></param>
    ''' <param name="BALNBrightLengthMM"></param>
    ''' <remarks></remarks>
    Public Sub SetBrightLengthMM(ByVal BALPBrightLengthMM As List(Of Integer), ByVal BALNBrightLengthMM As List(Of Integer))
        If Not IsNothing(BALPBrightLengthMM) AndAlso BALPBrightLengthMM.Count > 0 Then
            For EachCount As Integer = 1 To IIf(BALPBrightLengthMM.Count > 6, 6, BALPBrightLengthMM.Count) - 1
                Dim SetControl As TextBox = TableLayoutPanel2.Controls.Item("tbBALPBrightLengthMM" & EachCount)
                If IsNothing(SetControl) Then
                    Continue For
                End If
                SetControl.Text = BALPBrightLengthMM(EachCount)
            Next
        End If


        ''106/08/10 Add
        ''現場人員要求在反面亮度的長度上，不須由缺陷138來設定，而是由鋼捲厚度頁籤的長度來決定
        ''106/08/15 ADD
        ''班長要求復原，保持原有功能
        If Not IsNothing(BALNBrightLengthMM) AndAlso BALNBrightLengthMM.Count > 0 Then
            For EachCount As Integer = 1 To IIf(BALNBrightLengthMM.Count > 6, 6, BALNBrightLengthMM.Count) - 1
                Dim SetControl As TextBox = TableLayoutPanel2.Controls.Item("tbBALNBrightLengthMM" & EachCount)
                If IsNothing(SetControl) Then
                    Continue For
                End If
                SetControl.Text = BALNBrightLengthMM(EachCount)
            Next
        End If
    End Sub
    Public Sub SetBrightLengthMM(ByVal BALPBrightLengthMM As Integer, ByVal BALNBrightLengthMM As Integer, ByVal SetControlLocation As Integer)
        If SetControlLocation < 1 OrElse SetControlLocation > 6 Then
            Exit Sub
        End If
        Dim SetControlP As TextBox = TableLayoutPanel2.Controls.Item("tbBALPBrightLengthMM" & SetControlLocation)
        Dim SetControlN As TextBox = TableLayoutPanel2.Controls.Item("tbBALNBrightLengthMM" & SetControlLocation)
        If IsNothing(SetControlP) OrElse IsNothing(SetControlN) Then
            Exit Sub
        End If
        SetControlP.Text = BALPBrightLengthMM
        SetControlN.Text = BALNBrightLengthMM
    End Sub


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
        For Each EachControl As Control In TableLayoutPanel3.Controls
            If TypeOf EachControl Is TextBox Then
                EachControl.BackColor = Color.White
            End If
        Next
        SelectControl.BackColor = Color.PaleGreen
        SelectControl.SelectAll()
        SelectControl.Focus()
    End Sub


    Private Sub NumberKeyboardEvent_ButtonClickEvent(sender As Object, Value As String) Handles NumberKeyboardEvent.ButtonClickEvent
        Dim InputTextBox As TextBox = Nothing
        For Each EachControl As Control In TableLayoutPanel2.Controls
            If TypeOf EachControl Is TextBox AndAlso EachControl.BackColor = Color.PaleGreen Then
                InputTextBox = EachControl : Exit For
            End If
        Next
        If IsNothing(InputTextBox) Then
            For Each EachControl As Control In TableLayoutPanel3.Controls
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
            Case Value = "DOT" AndAlso Not (InputTextBox Is tbAPL2BATestHeadMM OrElse InputTextBox Is tbAPL2BATestTailMM)
            Case Value = "DOT" AndAlso (InputTextBox Is tbAPL2BATestHeadMM OrElse InputTextBox Is tbAPL2BATestTailMM)
                InputTextBox.SelectedText = ""
                If InputTextBox.Text.Length < 5 Then
                    InputTextBox.Text &= "."
                End If
            Case Value = "OK"
                TextBoxInputCompleteMove(InputTextBox, Nothing)
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
    '        RaiseEvent MessageEvent("成功儲存BAL其它資訊!")
    '        RaiseEvent CallBackEvent(Me, "OK")
    '    Else
    '        RaiseEvent MessageEvent("儲存BAL其它資訊失敗!")
    '    End If
    'End Sub


    Private Sub BALOthersEdit_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim EachTextbox As TextBox = Nothing
        For Each EachControl As Control In TableLayoutPanel2.Controls
            If TypeOf EachControl Is TextBox Then
                EachTextbox = EachControl
                AddHandler EachTextbox.KeyDown, AddressOf TextBoxInputCompleteMove
            End If
        Next
        For Each EachControl As Control In TableLayoutPanel3.Controls
            If TypeOf EachControl Is TextBox Then
                EachTextbox = EachControl
                AddHandler EachTextbox.KeyDown, AddressOf TextBoxInputCompleteMove
            End If
        Next

    End Sub

    Private Sub btnAssignEndTime_Click(sender As Object, e As EventArgs) Handles btnAssignEndTime.Click
        If Me.ParentMainControl.CanEditCoilFullNumberIsOnLineCoilFullNumberState AndAlso Not IsNothing(Me.ParentMainControl.CurrentEditQABugRecordTitle) Then
            If MsgBox("是否定指定現在時間為鋼捲結束時間", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Me.ParentMainControl.CurrentEditQABugRecordTitle.CoilEndTime = Now
                Me.ParentMainControl.CurrentEditQABugRecordTitle.CDBSave()
                Me.InitControlValue()
            End If
        End If
    End Sub


    Private Sub lbPosition1Set_Click(sender As Object, e As EventArgs) Handles lbPosition1Set.Click, lbPosition2Set.Click, lbPosition3Set.Click, lbPosition4Set.Click
        If Me.ParentMainControl.CanEditStationLine <> "BAL" Then
            Exit Sub
        End If
        Dim SenderControl As Label = sender
        Select Case True
            Case SenderControl Is lbPosition1Set
                tbBALSection1PositionMM.Text = Me.ParentMainControl.BALCoilPosition
                Call tbInputTextBox_Click(tbBALSection1OperateMM, Nothing)
            Case SenderControl Is lbPosition2Set
                tbBALSection2PositionMM.Text = Me.ParentMainControl.BALCoilPosition
                Call tbInputTextBox_Click(tbBALSection2OperateMM, Nothing)
            Case SenderControl Is lbPosition3Set
                tbBALSection3PositionMM.Text = Me.ParentMainControl.BALCoilPosition
                Call tbInputTextBox_Click(tbBALSection3OperateMM, Nothing)
            Case SenderControl Is lbPosition4Set
                tbBALSection4PositionMM.Text = Me.ParentMainControl.BALCoilPosition
                Call tbInputTextBox_Click(tbBALSection4OperateMM, Nothing)
            Case Else
                Exit Sub
        End Select

    End Sub


    '    ''106/08/09 Add
    '    ''接收鋼捲厚度頁籤之長度
    '    Private Sub btnSyncLength_Click(sender As Object, e As EventArgs) Handles btnSyncLength.Click


    '        Dim receiveLength As String = MainControl.returnQAThick_Item()
    '        Dim lengthArray As String()

    '        If receiveLength Is Nothing Or receiveLength = "" Then
    '            Exit Sub
    '        End If
    '        lengthArray = receiveLength.Split(",")

    '        tbBALNBrightLengthMM1.Text = lengthArray(0)
    '        tbBALNBrightLengthMM2.Text = lengthArray(1)
    '        tbBALNBrightLengthMM3.Text = lengthArray(2)
    '        tbBALNBrightLengthMM4.Text = lengthArray(3)
    '        tbBALNBrightLengthMM5.Text = lengthArray(4)
    '        tbBALNBrightLengthMM6.Text = lengthArray(5)

    '    End Sub

    '    ''' <summary>
    '    ''' 106/08/17 ADD 
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '#Region "重整RadioBtn 上下收"
    '    Public Sub refreshRadioBtn_upAndDown() Implements IxxxTitleEdit.refreshRadioBtn_upAndDown

    '        ''BAL 預設下收
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
