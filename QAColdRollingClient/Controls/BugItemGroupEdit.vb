Public Class BugItemGroupEdit

    'Public Event DataDateSelect(ByVal Sender As BugItemGroupEdit, ByVal SelectDate As Nullable(Of Date), ByVal Version As String)
    Public Event DataDateSelect(ByVal Sender As BugItemGroupEdit, ByVal SenderClickButton As Button)

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

#Region "日期輸入模式 屬性:DateInputMode"
    Private _DateInputMode As DateInputModeEnum = DateInputModeEnum.InputFinished
    ''' <summary>
    ''' 日期輸入模式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property DateInputMode As DateInputModeEnum
        Get
            Return _DateInputMode
        End Get
        Set(value As DateInputModeEnum)
            _DateInputMode = value
        End Set
    End Property
#End Region
#Region "日期輸入模式列舉 屬性:DateInputModeEnum"
    ''' <summary>
    ''' 日期輸入模式列舉
    ''' </summary>
    ''' <remarks></remarks>
    Enum DateInputModeEnum
        InputFinished = 0
        YearInputing = 1
        MomthInputing = 2
        DayInputing = 3
    End Enum
#End Region
#Region "核對日期輸入 函式:CheckInputDate"
    ''' <summary>
    ''' 核對日期輸入
    ''' </summary>
    ''' <param name="CheckInputMode"></param>
    ''' <remarks></remarks>
    Private Function CheckInputDate(ByVal CheckInputMode As DateInputModeEnum, ByRef CorrectDate As Date) As Boolean
        Dim TryDateValue As String = Val(rbYear.Text) + 1911 & "/" & rbMonth.Text & "/" & rbDay.Text
        Static MinDate As Date = New Date(2000, 1, 1)
        If Date.TryParse(TryDateValue, Nothing) Then
            CorrectDate = TryDateValue
            Return True
        End If
        Select Case True
            Case CheckInputMode = DateInputModeEnum.YearInputing
                TryDateValue = Format(Now, "yyyy") & "/" & rbMonth.Text & "/" & rbDay.Text
                If Date.TryParse(TryDateValue, Nothing) Then
                    CorrectDate = IIf(TryDateValue < MinDate, MinDate, TryDateValue)
                    Return False
                End If
            Case CheckInputMode = DateInputModeEnum.MomthInputing
                TryDateValue = rbYear.Text & "/" & Format(Now, "MM") & "/" & rbDay.Text
                If Date.TryParse(TryDateValue, Nothing) Then
                    CorrectDate = IIf(TryDateValue < MinDate, MinDate, TryDateValue)
                    Return False
                End If
            Case CheckInputMode = DateInputModeEnum.DayInputing
                TryDateValue = rbYear.Text & "/" & rbMonth.Text & "/" & Format(Now, "dd")
                If Date.TryParse(TryDateValue, Nothing) Then
                    CorrectDate = IIf(TryDateValue < MinDate, MinDate, TryDateValue)
                    Return False
                End If
            Case Else
                CorrectDate = Now.Date
                Return False
        End Select
        CorrectDate = Format(Now, "yyyy/MM/dd")
        Return False
    End Function
#End Region


#Region "重整控制項顯示 函式:RefreshControlDispaly"
    ''' <summary>
    ''' 重整控制項顯示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshControlDispaly()
        Select Case True
            Case DateInputMode = DateInputModeEnum.InputFinished
                rbYear.Enabled = True
                rbMonth.Enabled = True
                rbDay.Enabled = True
            Case DateInputMode = DateInputModeEnum.YearInputing
                rbYear.Enabled = True
                rbMonth.Enabled = False
                rbDay.Enabled = False
            Case DateInputMode = DateInputModeEnum.MomthInputing
                rbYear.Enabled = False
                rbMonth.Enabled = True
                rbDay.Enabled = False
            Case DateInputMode = DateInputModeEnum.DayInputing
                rbYear.Enabled = False
                rbMonth.Enabled = False
                rbDay.Enabled = True
        End Select
    End Sub
#End Region
#Region "重整站台資料期選單 函式:RefreshDataDateMenu"
    ''' <summary>
    ''' 重整站台資料期選單
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshDataDateMenu()
        For Each EachButton As Button In (From A In FlowLayoutPanel1.Controls Where TypeOf A Is Button Select A).ToList
            RemoveHandler EachButton.Click, AddressOf DateSelectButton_Click
            FlowLayoutPanel1.Controls.Remove(EachButton)
        Next

        If IsNothing(Me.ParentMainControl) OrElse String.IsNullOrEmpty(Me.ParentMainControl.EditCoilNumber) Then
            Exit Sub
        End If
        Dim Qry As String = "Select Distinct DataDate,Version,CoilNumber,OutCoilNumber From QABugRecordTitle where (CoilNumber='" & Me.ParentMainControl.EditCoilNumber & "' OR OutCoilNumber='" & Me.ParentMainControl.EditCoilNumber & "') and StationName='" & ParentMainControl.CanEditStationLine.Trim & "' Order by DataDate Desc, Version ASC "
        Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        Dim DisplayItems As New List(Of String)
        For Each EachItem As DataRow In Adapter.SelectQuery(Qry).Rows
            DisplayItems.Add(EachItem.Item("DataDate").ToString & "," & EachItem.Item("Version").ToString.Trim & "," & EachItem.Item("CoilNumber").ToString.Trim & "," & EachItem.Item("OutCoilNumber").ToString.Trim)
        Next
        If DisplayItems.Count = 0 Then
            DisplayItems.Add(Now.Date & ",1," & Me.ParentMainControl.EditCoilNumber.Trim & "," & Me.ParentMainControl.EditOutCoilNumber.Trim)
        End If
        For Each EachItem As String In DisplayItems
            AddDataDateButton(EachItem.Split(",")(0), EachItem.Split(",")(1), EachItem.Split(",")(2).Trim, EachItem.Split(",")(3).Trim)
        Next
    End Sub
#End Region
#Region "新增日期按鈕 函式:AddDataDateButton"
    ''' <summary>
    ''' 新增日期按鈕
    ''' </summary>
    ''' <param name="AddDate"></param>
    ''' <remarks></remarks>
    Private Sub AddDataDateButton(ByVal AddDate As Date, ByVal Version As String, ByVal EditCoilNumber As String, ByVal OutEditCoilNumber As String)
        Dim SetVersion As String = Version
        Dim AddDateString = Format(AddDate, "yyyy/MM/dd")
        Dim ALLFlowButtons As List(Of Button) = (From A In FlowLayoutPanel1.Controls Where TypeOf A Is Button Select CType(A, Button)).ToList
        If String.IsNullOrEmpty(SetVersion) Then
            '新增當日新版處理
            'Dim GetLastSameDateButton As Button = (From A In ALLFlowButtons Where A.Tag.ToString.Split(",")(0).Trim = AddDateString Select A Order By A.Tag.ToString.Split(",")(1) Descending).FirstOrDefault
            Dim GetLastSameDateButton As Button = (From A In ALLFlowButtons Where A.Tag.ToString.Split(",")(0).Trim = AddDateString And A.Tag.ToString.Split(",")(2).Trim = EditCoilNumber And A.Tag.ToString.Split(",")(3).Trim = OutEditCoilNumber Select A Order By A.Tag.ToString.Split(",")(1) Descending).FirstOrDefault
            If Not IsNothing(GetLastSameDateButton) Then
                SetVersion = Val(GetLastSameDateButton.Tag.ToString.Split(",")(1)) + 1
            End If
        End If
        If String.IsNullOrEmpty(SetVersion) Then
            SetVersion = "1"
        End If
        For Each EachButton As Button In ALLFlowButtons
            If EachButton.Tag = Format(AddDate, "yyyy/MM/dd") & "," & SetVersion & "," & EditCoilNumber & "," & OutEditCoilNumber Then
                Exit Sub
            End If
        Next
        Dim AddButton As New Button
        'Dim ButtonText As String = AddDateString & " 版:" & SetVersion
        Dim ButtonText As String = AddDateString & "版:" & SetVersion & "入:" & EditCoilNumber & "出:" & OutEditCoilNumber
        Static ButtonFont As Font = New Font("Arial", 22, FontStyle.Bold)
        With AddButton
            .Text = ButtonText
            .Font = ButtonFont
            .TextAlign = ContentAlignment.BottomCenter
            .Width = FlowLayoutPanel1.Width - 6
            .Tag = Format(AddDate, "yyyy/MM/dd") & "," & SetVersion & "," & EditCoilNumber & "," & OutEditCoilNumber
            .Height = 60
            .Cursor = Cursors.Hand
            AddHandler AddButton.Click, AddressOf DateSelectButton_Click
        End With
        FlowLayoutPanel1.Controls.Add(AddButton)
    End Sub
#End Region


    Sub New(ByVal SetParentMainControl As MainControl)
        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.ParentMainControl = SetParentMainControl
    End Sub

    Private Sub BugItemGroupEdit_Load(sender As Object, e As EventArgs) Handles Me.Load
        rbYear.Text = Val(Format(Now, "yyyy")) - 1911
        rbMonth.Text = Format(Now, "MM")
        rbDay.Text = Format(Now, "dd")
        Panel1.Controls.Add(NumberKeyboardControl)
    End Sub

    Private Sub rbYear_CheckedChanged(sender As Object, e As EventArgs) Handles rbYear.CheckedChanged

    End Sub

    Private Sub rbYear_MouseUp(sender As Object, e As MouseEventArgs) Handles rbYear.MouseUp, rbMonth.MouseUp, rbDay.MouseUp
        CType(sender, RadioButton).Text = Nothing
        Select Case True
            Case sender Is rbYear
                DateInputMode = DateInputModeEnum.YearInputing
            Case sender Is rbMonth
                DateInputMode = DateInputModeEnum.MomthInputing
            Case sender Is rbDay
                DateInputMode = DateInputModeEnum.DayInputing
        End Select
        RefreshControlDispaly()
    End Sub

    Private Sub NumberKeyboardEvent_ButtonClickEvent(sender As Object, Value As String) Handles NumberKeyboardEvent.ButtonClickEvent
        Dim InputControl As RadioButton = Nothing
        Select Case True
            Case rbYear.Checked
                InputControl = rbYear
            Case rbMonth.Checked
                InputControl = rbMonth
            Case rbDay.Checked
                InputControl = rbDay
        End Select
        If IsNothing(InputControl) Then
            Exit Sub
        End If

        Dim CheckedDate As Date = Nothing
        Select Case True
            Case DateInputMode = DateInputModeEnum.InputFinished
                Exit Sub
            Case Value = "DELETE" AndAlso InputControl.Text.Length > 0
                InputControl.Text = InputControl.Text.Substring(0, InputControl.Text.Length - 1)
            Case Value = "DELETE"
            Case Value = "CLEAR"
                InputControl.Text = ""
            Case Value = "OK"
            Case DateInputMode = DateInputModeEnum.YearInputing
                rbYear.Text &= Value
                If rbYear.Text.Length = 3 Then
                    CheckInputDate(DateInputMode, CheckedDate)
                    DateInputMode = DateInputModeEnum.InputFinished
                    rbYear.Text = Val(CheckedDate.Year) - 1911
                    rbMonth.Text = Format(CheckedDate, "MM")
                    rbDay.Text = Format(CheckedDate, "dd")
                End If
            Case DateInputMode = DateInputModeEnum.MomthInputing
                rbMonth.Text &= Value
                If (rbMonth.Text.Length = 1 AndAlso Val(rbMonth.Text) > 1) OrElse rbMonth.Text.Length > 1 Then
                    CheckInputDate(DateInputMode, CheckedDate)
                    DateInputMode = DateInputModeEnum.InputFinished
                    rbYear.Text = Val(CheckedDate.Year) - 1911
                    rbMonth.Text = Format(CheckedDate, "MM")
                    rbDay.Text = Format(CheckedDate, "dd")
                End If
            Case DateInputMode = DateInputModeEnum.DayInputing
                rbDay.Text &= Value
                If (rbDay.Text.Length = 1 AndAlso Val(rbDay.Text) > 3) OrElse rbDay.Text.Length > 1 Then
                    CheckInputDate(DateInputMode, CheckedDate)
                    DateInputMode = DateInputModeEnum.InputFinished
                    rbYear.Text = Val(CheckedDate.Year) - 1911
                    rbMonth.Text = Format(CheckedDate, "MM")
                    rbDay.Text = Format(CheckedDate, "dd")
                End If
        End Select
        RefreshControlDispaly()
    End Sub

    Private Sub DateSelectButton_Click(sender As Object, e As EventArgs)
        'RaiseEvent DataDateSelect(Me, CType(CType(sender, Button).Tag.ToString.Split(",")(0), Date), CType(sender, Button).Tag.ToString.Split(",")(1))
        RaiseEvent DataDateSelect(Me, sender)
    End Sub

    Private Sub btnCoilNumber_Click(sender As Object, e As EventArgs) Handles btnCoilNumber.Click
        'AddDataDateButton(CType(Val(rbYear.Text) + 1911 & "/" & rbMonth.Text & "/" & rbDay.Text, Date), Nothing)
        AddDataDateButton(CType(Val(rbYear.Text) + 1911 & "/" & rbMonth.Text & "/" & rbDay.Text, Date), Nothing, Me.ParentMainControl.EditOutCoilNumber, Me.ParentMainControl.EditOutCoilNumber)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'RaiseEvent DataDateSelect(Me, Nothing, Nothing)
        RaiseEvent DataDateSelect(Me, Nothing)
    End Sub
End Class
