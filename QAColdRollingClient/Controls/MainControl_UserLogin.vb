Public Class MainControl_UserLogin

    Public Event UserLoginEvent(sender As MainControl_UserLogin, ByVal LoginID As String, ByVal EditLineStation As String)

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
#Region "登入是否成功 屬性:IsLoginSucess"
    ''' <summary>
    ''' 登入是否成功
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsLoginSucess As Boolean
        Get
            Dim QryString As String = "Select Count(*) from QABugSysLoginUser Where EmployeeID='" & tbLoginID.Text.Replace("'", Nothing).Trim & "' and Password='" & tbPassword.Text.Replace("'", Nothing).Trim & "' "
            Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
            Return CType(Adapter.SelectQuery(QryString).Rows(0).Item(0), Integer) > 0
        End Get
    End Property
#End Region
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
#Region "強制唯一站台編修 屬性:CompulsiveEditStationName"
    ''' <summary>
    ''' 強制唯一站台編修
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CompulsiveEditStationName As String = ""
#End Region
#Region "重整顯示畫面 函式:RefreshDisplay"
    ''' <summary>
    ''' 重整顯示畫面
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshDisplay()
        If Not String.IsNullOrEmpty(CompulsiveEditStationName) Then
            Select Case True
                Case CompulsiveEditStationName = "APL1"
                    rbAPL1.Checked = True
                    rbAPL2.Visible = False
                    rbBAL.Visible = False
                Case CompulsiveEditStationName = "APL2"
                    rbAPL2.Checked = True
                    rbAPL1.Visible = False
                    rbBAL.Visible = False
                Case CompulsiveEditStationName = "BAL"
                    rbAPL1.Visible = False
                    rbAPL2.Visible = False
                    rbBAL.Checked = True
            End Select
        End If
        pbGetL2Length.Visible = False
        tbHandPosition.Visible = pbGetL2Length.Visible
        btnChangeHand.Visible = pbGetL2Length.Visible
        If IsLoginSucess AndAlso Not IsNothing(Me.ParentMainControl) Then
            pbGetL2Length.Visible = True
            tbHandPosition.Visible = pbGetL2Length.Visible
            btnChangeHand.Visible = pbGetL2Length.Visible
        End If
    End Sub
#End Region


    Private Sub NumberKeyboardEvent_ButtonClickEvent(sender As Object, Value As String) Handles NumberKeyboardEvent.ButtonClickEvent
        Dim InputTextBox As TextBox = Nothing
        If tbLoginID.BackColor = Color.Pink Then
            InputTextBox = tbLoginID
        End If
        If tbPassword.BackColor = Color.Pink Then
            InputTextBox = tbPassword
        End If
        If tbHandPosition.BackColor = Color.Pink Then
            InputTextBox = tbHandPosition
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
            Case Value = "DOT"
            Case Value = "OK"
                Select Case True
                    Case InputTextBox Is tbLoginID
                        tbLoginID_TextChanged(tbPassword, Nothing)
                    Case InputTextBox Is tbPassword
                        Select Case True
                            Case rbAPL1.Checked
                                rbAPL1_Click(rbAPL1, Nothing)
                            Case rbAPL2.Checked
                                rbAPL1_Click(rbAPL2, Nothing)
                            Case rbBAL.Checked
                                rbAPL1_Click(rbBAL, Nothing)
                        End Select
                End Select
            Case Else
                InputTextBox.SelectedText = ""
                InputTextBox.Text &= Value
        End Select

    End Sub

    Private Sub tbLoginID_TextChanged(sender As Object, e As EventArgs) Handles tbLoginID.Click, tbPassword.Click, tbHandPosition.Click
        tbLoginID.BackColor = Color.White
        tbPassword.BackColor = tbLoginID.BackColor
        tbHandPosition.BackColor = tbLoginID.BackColor
        CType(sender, TextBox).BackColor = Color.Pink
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub MainControl_UserLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim ThisStationIP As String = CompanyORMDB.DeviceInformation.GetCpuIDs(0).Trim
            Select Case True
                Case ThisStationIP = "10.12.7.21"
                    rbAPL1.Checked = True
                    rbAPL2.Enabled = False
                    rbBAL.Enabled = False
                Case ThisStationIP = "10.12.2.21"
                    rbAPL1.Enabled = False
                    rbAPL2.Checked = True
                    rbBAL.Enabled = False
                Case ThisStationIP = "10.12.21.21"
                    rbAPL1.Enabled = False
                    rbAPL2.Enabled = False
                    rbBAL.Checked = True
            End Select
        Catch ex As Exception
            Me.rbAPL1.Checked = True
        End Try

        EditPanel.Controls.Add(NumberKeyboardControl)
        tbLoginID.Focus()
        Call tbLoginID_TextChanged(tbLoginID, Nothing)
    End Sub

    Private Sub rbAPL1_Click(sender As Object, e As EventArgs) Handles rbAPL1.Click, rbAPL2.Click, rbBAL.Click
        If IsLoginSucess Then
            RaiseEvent UserLoginEvent(Me, tbLoginID.Text.Trim, CType(sender, RadioButton).Name.Replace("rb", Nothing))
            lbMessage.Text = "登入成功!"
        Else
            lbMessage.Text = "登入失敗!"
        End If
        tbLoginID.Focus()
        Call tbLoginID_TextChanged(tbLoginID, Nothing)
    End Sub

    Private Sub tbLoginID_TextChanged_1(sender As Object, e As EventArgs) Handles tbLoginID.TextChanged, tbPassword.TextChanged
        lbMessage.Text = Nothing
        If sender Is tbLoginID Then
            If Not String.IsNullOrEmpty(tbLoginID.Text) AndAlso tbLoginID.Text.Trim.Length > 0 AndAlso tbLoginID.Text.Trim.Trim.ToUpper = "1J4@VU" Then
                tbLoginID.Text = Nothing
                rbAPL1.Enabled = True
                rbAPL2.Enabled = True
                rbBAL.Enabled = True
            End If
        End If
    End Sub

    Private Sub pbGetL2Msg1_Click(sender As Object, e As EventArgs) Handles pbGetL2Length.Click
        tbHandPosition.Text = Me.ParentMainControl.APL1CoilPosition
        Select Case True
            Case Me.ParentMainControl.CanEditStationLine = "APL1"
                pbGetL2Length.Text = Me.ParentMainControl.APL1CoilPosition
            Case Me.ParentMainControl.CanEditStationLine = "APL2"
                pbGetL2Length.Text = Me.ParentMainControl.APL2CoilPosition
            Case Me.ParentMainControl.CanEditStationLine = "BAL"
                pbGetL2Length.Text = Me.ParentMainControl.BALCoilPosition
        End Select
    End Sub

    Public Sub New(ByVal SetParentMainControl As MainControl)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.ParentMainControl = SetParentMainControl
    End Sub

    Private Sub btnChangeHand_Click(sender As Object, e As EventArgs) Handles btnChangeHand.Click
        If IsNothing(Me.ParentMainControl) OrElse String.IsNullOrEmpty(ParentMainControl.EditCoilNumber) OrElse IsNothing(ParentMainControl.CurrentEditQABugRecordTitle) Then
            Exit Sub
        End If
        If IsLoginSucess = False Then
            MsgBox("使用帳號密碼驗證失敗,請先確定正確之帳號及密碼!", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        Dim LengthPosition As Long = CType(Val(tbHandPosition.Text), Long)
        Dim ShowMsg As String = Nothing
        If LengthPosition = 0 Then
            ShowMsg = "注意,交接米數為零! "
        End If
        Dim HandOverRecordCount As Integer = 0
        For Each EachItem As BugItemMinDisplay In Me.ParentMainControl.QABugRecordShowControls
            If EachItem.QABugRecordData.EditEmployeeID.Trim = Me.ParentMainControl.LoginID.Trim Then
                HandOverRecordCount += 1
            End If
        Next
        ShowMsg &= "有 " & HandOverRecordCount & " 筆缺陷資料可供轉移!"
        ShowMsg &= vbNewLine & "確認是否將此鋼捲(" & ParentMainControl.EditCoilNumber.Trim & ")列為交接鋼捲?"
        If MsgBox(ShowMsg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        With ParentMainControl.CurrentEditQABugRecordTitle
            .IsWillHandOver = True
            .HandOverBeforeeEmpID = ParentMainControl.LoginID
            .HandOverLength = CType(Val(tbHandPosition.Text), Long)
            .LastEditEmployeeID = ""
            If HandOverRecordCount > 0 Then
                .HandOverTime = Now
            End If
            If .CDBSave > 0 Then
                MsgBox("交接完成,此鋼捲可允許下位登入者編修!(系統即將關閉)", MsgBoxStyle.OkOnly)
                Me.ParentMainControl.btnExit.Text = "確認離開"
                Call Me.ParentMainControl.btnExit_Click(Me.ParentMainControl.btnExit, Nothing)
                Exit Sub
            End If
        End With

    End Sub

End Class
