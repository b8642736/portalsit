Public Class ThickItemEdit

    Public Event CallBackEvent(ByVal Sender As Object, ByVal FinishEditData As QAThickness)


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
#Region "編輯厚寬長資料 屬性:EditQAThickness"
    Private _EditQAThickness As QAThickness
    ''' <summary>
    ''' 編輯厚寬長資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property EditQAThickness As QAThickness
        Get
            Return _EditQAThickness
        End Get
        Set(value As QAThickness)
            _EditQAThickness = value
            RefishDisplayData(True)
            EditButtonSelectChangeColor(tbThick60)
            'tbThick.SelectAll()
            'tbThick60.BackColor = Color.Red
        End Set
    End Property
#End Region
#Region "編輯控制項 屬性:EditControl"
    ''' <summary>
    ''' 編輯控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property EditControl As TextBox
        Get
            Select Case True
                Case tbThick60.BackColor = Color.LightPink
                    Return tbThick60
                Case tbThick.BackColor = Color.LightPink
                    Return tbThick
                Case tbWidth.BackColor = Color.LightPink
                    Return tbWidth
                Case tbLength.BackColor = Color.LightPink
                    Return tbLength
            End Select
            Return Nothing
        End Get
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

#Region "傳送按鈕命令列舉 函式:SendButtonCommand"
    ''' <summary>
    ''' 傳送按鈕命令
    ''' </summary>
    ''' <param name="ButtonType"></param>
    ''' <remarks></remarks>
    Public Sub SendButtonCommand(ByVal ButtonType As ThickItemMinDisplay.ButtonTypeEnum)
        Select Case ButtonType
            Case ThickItemMinDisplay.ButtonTypeEnum.ThickButton
                Call tbThick_Click(tbThick, Nothing)
            Case ThickItemMinDisplay.ButtonTypeEnum.ThickButton60
                Call tbThick_Click(tbThick60, Nothing)
            Case ThickItemMinDisplay.ButtonTypeEnum.WidtheButton
                Call tbThick_Click(tbWidth, Nothing)
            Case ThickItemMinDisplay.ButtonTypeEnum.LengthButton
                Call tbThick_Click(tbLength, Nothing)
        End Select
    End Sub
#End Region

#Region "控制項資料處理模式 屬性/列舉:ControlDataProcessMode/ControlDataProcessModeEnum"
    Private _ControlDataProcessMode As ControlDataProcessModeEnum = ControlDataProcessModeEnum.InsertMode
    ''' <summary>
    ''' 控制項資料處理模式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ControlDataProcessMode As ControlDataProcessModeEnum
        Get
            Return _ControlDataProcessMode
        End Get
        Set(value As ControlDataProcessModeEnum)
            _ControlDataProcessMode = value
            ShowCoilInformation()
        End Set
    End Property
    Enum ControlDataProcessModeEnum
        InsertMode = 1
        EditMode = 2
    End Enum
#End Region
#Region "顯示鋼捲資訊 函式:ShowCoilInformation"
    ''' <summary>
    ''' 顯示鋼捲資訊
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowCoilInformation()
        Dim SetString As New System.Text.StringBuilder
        SetString.Append("模式:" & IIf(Me.ControlDataProcessMode = ControlDataProcessModeEnum.InsertMode, "新增", "編修"))
        lbShowCoilMessage.Text = SetString.ToString
    End Sub
#End Region

#Region "重整顯示控制項資料 函式:RefishDisplayData"
    ''' <summary>
    ''' 重整顯示控制項資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefishDisplayData(Optional IsInitialStatus As Boolean = False)

        Dim SetValue As Boolean = Not (Me.ParentMainControl.EditStationName = "BAL" OrElse Me.ParentMainControl.EditStationName = "APL2")
        tbThick.Visible = SetValue
        btnMinus.Visible = SetValue
        btnPlus.Visible = SetValue
        lbThick25.Text = IIf(SetValue, "距邊25mm厚", "----")

        If IsNothing(EditQAThickness) Then
            tbThick.Text = "--"
            tbThick60.Text = "--"
            tbWidth.Text = "--"
            tbLength.Text = "--"
        Else
            With EditQAThickness
                tbThick.Text = .Thick
                tbThick60.Text = .Thick60
                tbWidth.Text = .Width
                tbLength.Text = .Length
            End With
        End If
        If IsInitialStatus Then
            btnDelete.Text = "刪除"
            btnOKCopy1.Text = "多複製1份"
            btnOKCopy2.Text = "多複製2份"
            btnOKCopy3.Text = "多複製3份"
        End If
        EditButtonSelectChangeColor(Me.EditControl)
    End Sub

    Private Sub EditButtonSelectChangeColor(ByVal SourceButton As TextBox)
        tbThick.BackColor = Color.LightGray
        tbThick60.BackColor = Color.LightGray
        tbLength.BackColor = Color.LightGray
        tbWidth.BackColor = Color.LightGray
        If IsNothing(SourceButton) Then
            Exit Sub
        End If
        SourceButton.BackColor = Color.LightPink
    End Sub
#End Region

    Public Sub New(ByVal SetEditQAThickness As QAThickness, ByVal SetParentMainControl As MainControl)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        ParentMainControl = SetParentMainControl
        Me.EditQAThickness = SetEditQAThickness
        InputPanel.Controls.Add(Me.NumberKeyboardControl)
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

        If IsNothing(Me.EditQAThickness) Then
            Exit Sub
        End If
        Me.EditQAThickness.Thick60 = Val(tbThick60.Text)
        Me.EditQAThickness.Thick = Val(tbThick.Text)
        Me.EditQAThickness.Width = Val(tbWidth.Text)
        Me.EditQAThickness.Length = Val(tbLength.Text)

        If Not IsNothing(EditQAThickness) AndAlso EditQAThickness.CDBSave > 0 Then
            '取得所有資料最後一筆的儲存時間
            Dim LastSaveTime As DateTime = EditQAThickness.DataCreateTime
            For Each EachItem As ThickItemMinDisplay In ParentMainControl.QAThicknessRecordShowControls
                If EachItem.QAThicknessRecordData.DataCreateTime > LastSaveTime Then
                    LastSaveTime = EachItem.QAThicknessRecordData.DataCreateTime
                End If
            Next

            For CopyTimes As Integer = 1 To Val(CType(sender, Button).Tag)
                Dim CopyObj As QAThickness = EditQAThickness.CDBClone
                CopyObj.DataCreateTime = LastSaveTime.AddSeconds(CopyTimes)
                CopyObj.CDBSave()
            Next
            RaiseEvent CallBackEvent(Me, EditQAThickness)
        End If

    End Sub


    'Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
    '    If btnDelete.Text = "確定刪除" OrElse _
    '        btnOKCopy1.Text.Substring(0, 2) = "確定" OrElse _
    '        btnOKCopy2.Text.Substring(0, 2) = "確定" OrElse _
    '        btnOKCopy3.Text.Substring(0, 2) = "確定" Then
    '        btnDelete.Text = "刪除"
    '        btnOKCopy1.Text = "多複製1份"
    '        btnOKCopy2.Text = "多複製2份"
    '        btnOKCopy3.Text = "多複製3份"
    '        Exit Sub
    '    End If
    '    RaiseEvent CallBackEvent(Me, Nothing)
    'End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If btnDelete.Text = "刪除" Then
            btnDelete.Text = "確定刪除" : Exit Sub
        End If
        If btnDelete.Text = "確定刪除" AndAlso Not IsNothing(EditQAThickness) Then
            EditQAThickness.RunClientIP = CompanyORMDB.DeviceInformation.GetLocalIPs(0)
            EditQAThickness.RecordState = 3
            If EditQAThickness.CDBSave > 0 Then
                btnDelete.Text = "刪除"
                RaiseEvent CallBackEvent(Me, Nothing)
            End If

        End If
    End Sub

    Private Sub NumberKeyboardEvent_ButtonClickEvent(sender As Object, Value As String) Handles NumberKeyboardEvent.ButtonClickEvent
        If IsNothing(EditControl) Then
            Exit Sub
        End If
        Select Case True
            Case Value = "DELETE" AndAlso EditControl.Text.Length > 0
                EditControl.Text = EditControl.Text.Substring(0, EditControl.Text.Length - 1)
            Case Value = "DELETE"
            Case Value = "DOT"
                If EditControl Is tbThick AndAlso Not tbThick.Text.Contains(".") Then
                    EditControl.Text &= "."
                End If
                If EditControl Is tbThick60 AndAlso Not tbThick60.Text.Contains(".") Then
                    EditControl.Text &= "."
                End If
            Case Value = "OK"
                Select Case True
                    Case EditControl Is tbThick60
                        If btnMinus.Visible Then
                            Call tbThick_Click(tbThick, Nothing)
                        Else
                            Call tbThick_Click(tbWidth, Nothing)    'BAL/APL2不需輸入距邊26直接跳過
                        End If
                    Case EditControl Is tbThick
                        Call tbThick_Click(tbWidth, Nothing)
                    Case EditControl Is tbWidth
                        Call tbThick_Click(tbLength, Nothing)
                    Case EditControl Is tbLength
                        Call btnOK_Click(btnOK, Nothing)
                End Select
            Case Value = "CLEAR"
                EditControl.Text = ""
            Case Else
                EditControl.SelectedText = ""
                Select Case True
                    Case EditControl Is tbThick OrElse EditControl Is tbThick60
                        If EditControl.Text.Length < 5 Then
                            EditControl.Text &= Value
                        End If
                    Case EditControl Is tbWidth
                        If EditControl.Text.Length < 4 Then
                            EditControl.Text &= Value
                        End If
                    Case Else
                        If EditControl.Text.Length < 5 Then
                            EditControl.Text &= Value
                        End If
                End Select
        End Select
    End Sub

    Private Sub tbThick_Click(sender As Object, e As EventArgs) Handles tbThick.Click, tbThick60.Click, tbLength.Click, tbWidth.Click
        CType(sender, TextBox).SelectAll()
        'Me.EditControl = sender
        Me.EditButtonSelectChangeColor(sender)
    End Sub

    'Private Sub tbThick_LostFocus(sender As Object, e As EventArgs) Handles tbThick.LostFocus, tbLength.LostFocus, tbWidth.LostFocus
    '    If IsNothing(Me.EditQAThickness) Then
    '        Exit Sub
    '    End If
    '    Select Case True
    '        Case sender Is tbThick
    '            Me.EditQAThickness.Thick = Val(CType(sender, TextBox).Text)
    '        Case sender Is tbLength
    '            Me.EditQAThickness.Length = Val(CType(sender, TextBox).Text)
    '        Case sender Is tbWidth
    '            Me.EditQAThickness.Width = Val(CType(sender, TextBox).Text)
    '    End Select
    'End Sub

    Private Sub pbGetL2Msg_Click(sender As Object, e As EventArgs) Handles pbGetL2Msg.Click
        Select Case True
            Case Me.ParentMainControl.CanEditStationLine = "APL1"
                tbLength.Text = Me.ParentMainControl.APL1CoilPosition
            Case Me.ParentMainControl.CanEditStationLine = "APL2"
                tbLength.Text = Me.ParentMainControl.APL2CoilPosition
            Case Me.ParentMainControl.CanEditStationLine = "BAL"
                tbLength.Text = Me.ParentMainControl.BALCoilPosition
        End Select

    End Sub

    Private Sub btnMinus_Click(sender As Object, e As EventArgs) Handles btnMinus.Click, btnPlus.Click
        Dim OrginVlaue As Single = Val(tbThick.Text)
        If sender Is btnPlus Then
            OrginVlaue += 0.01
        Else
            OrginVlaue -= 0.01
        End If
        OrginVlaue = IIf(OrginVlaue < 0, 0, OrginVlaue)
        tbThick.Text = OrginVlaue
    End Sub

    Private Sub btnMinus2_Click(sender As Object, e As EventArgs) Handles btnMinus2.Click, btnPlus2.Click
        Dim OrginVlaue As Single = Val(tbThick60.Text)
        If sender Is btnPlus2 Then
            OrginVlaue += 0.01
        Else
            OrginVlaue -= 0.01
        End If
        OrginVlaue = IIf(OrginVlaue < 0, 0, OrginVlaue)
        tbThick60.Text = OrginVlaue
    End Sub

    Private Sub btnMinus1_Click(sender As Object, e As EventArgs) Handles btnMinus1.Click, btnPlus1.Click
        Dim OrginVlaue As Single = Val(tbWidth.Text)
        If sender Is btnPlus1 Then
            OrginVlaue += 1
        Else
            OrginVlaue -= 1
        End If
        OrginVlaue = IIf(OrginVlaue < 0, 0, OrginVlaue)
        tbWidth.Text = OrginVlaue
    End Sub

End Class
