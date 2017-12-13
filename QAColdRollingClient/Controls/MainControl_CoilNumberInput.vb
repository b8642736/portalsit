Public Class MainControl_CoilNumberInput

    Public Event ButtonClickEvent(sender As Object, ByVal Value As String)

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
#Region "重整顯示 函式:RefreshControlEnableOrVisible"
    ''' <summary>
    ''' 重整顯示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshControlEnableOrVisible()
        btnOKReturn.Enabled = (tbCoilNumber.Text.Length >= 5)
        btnMixCoilChange.Enabled = (tbNewCoilNumber.Text.Length >= 5)
    End Sub
#End Region
#Region "初始化控制項值 屬性:InitControlValue"
    ''' <summary>
    ''' 初始化控制項值
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitControlValue(ByVal SetCoilNumber As String)
        tbCoilNumber.Text = SetCoilNumber
        tbNewCoilNumber.Text = ""
        tbCoilNumber.SelectAll()
        tbCoilNumber.BackColor = Color.LightPink
        RefreshHisCoilNumberToButtons()
    End Sub
#End Region
#Region "重新整取得歷史鋼捲至Button控制項 函式:RefreshHisCoilNumberToButtons"
    ''' <summary>
    ''' 重新整取得歷史鋼捲至Button控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshHisCoilNumberToButtons()
        For Each EachButton As Button In fpHistoryCoilContainer.Controls
            EachButton.Text = ""
            EachButton.Enabled = False
        Next

        If IsNothing(ParentMainControl) OrElse String.IsNullOrEmpty(ParentMainControl.EditStationName) Then
            Exit Sub
        End If
        'Dim QryString As String = "Select Top 6 RTRIM(FK_OutSHA01 + FK_OutSHA02) from RunProcessData where RunStationPCip='" & Me.ParentMainControl.PrintLabelStationIP & "' Order By SysCoilEndTime Desc"
        'Dim ButtonIndexCount As Integer = 0
        'For Each EachItem As String In (From A In (New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")).SelectQuery(QryString).Rows Select A.item(0)).ToList
        '    If Not String.IsNullOrEmpty(EachItem) Then
        '        fpHistoryCoilContainer.Controls(ButtonIndexCount).Text = EachItem.Trim
        '        fpHistoryCoilContainer.Controls(ButtonIndexCount).Enabled = True
        '        ButtonIndexCount += 1
        '    End If
        'Next
        Dim QryString As String = "Select Top 6 A.FK_OutSHA01,A.FK_OutSHA02,B.ConvertToAS400Time from RunProcessData A LEFT JOIN QABugRecordTitle B ON RTRIM(A.FK_OutSHA01 + A.FK_OutSHA02) =RTRIM(B.OutCoilNumber) and a.sysCoilStartTime>=dateadd(""d"",-3,b.datadate) and a.sysCoilStartTime<=dateadd(""d"",3,b.datadate) where A.RunStationPCip='" & Me.ParentMainControl.PrintLabelStationIP & "' Order By A.SysCoilEndTime Desc"
        Dim ButtonIndexCount As Integer = 0
        Dim DBAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        For Each EachItem As DataRow In (From A In DBAdapter.SelectQuery(QryString) Select A).ToList
            If Not String.IsNullOrEmpty(EachItem.Item("FK_OutSHA01")) Then
                fpHistoryCoilContainer.Controls(ButtonIndexCount).Text = EachItem.Item("FK_OutSHA01")
                If Not String.IsNullOrEmpty(EachItem.Item("FK_OutSHA02")) Then
                    fpHistoryCoilContainer.Controls(ButtonIndexCount).Text &= EachItem.Item("FK_OutSHA02")
                End If
                fpHistoryCoilContainer.Controls(ButtonIndexCount).Text = Trim(fpHistoryCoilContainer.Controls(ButtonIndexCount).Text)
                fpHistoryCoilContainer.Controls(ButtonIndexCount).Enabled = True
                If Not IsDBNull(EachItem.Item("ConvertToAS400Time")) Then
                    Static CompareDate As New Date(2016, 1, 1)
                    If CType(EachItem.Item("ConvertToAS400Time"), Date) > CompareDate Then
                        fpHistoryCoilContainer.Controls(ButtonIndexCount).BackColor = Color.LightGreen
                    Else
                        fpHistoryCoilContainer.Controls(ButtonIndexCount).BackColor = Color.Transparent
                    End If
                End If
                ButtonIndexCount += 1
            End If
        Next

    End Sub
#End Region
    '#Region "混料鋼捲號碼變更 函式:ChangeCoilNumber"
    '    ''' <summary>
    '    ''' 混料鋼捲號碼變更
    '    ''' </summary>
    '    ''' <param name="OldCoilNumber"></param>
    '    ''' <param name="NewCoilNumber"></param>
    '    ''' <remarks></remarks>

    '    Private Function ChangeCoilNumber(ByVal OldCoilNumber As String, ByVal NewCoilNumber As String) As Integer
    '        '變更陷缺鋼捲號碼
    '        If String.IsNullOrEmpty(OldCoilNumber) OrElse String.IsNullOrEmpty(NewCoilNumber) OrElse _
    '           IsNothing(Me.ParentMainControl) OrElse _
    '           String.IsNullOrEmpty(Me.ParentMainControl.LoginID) OrElse IsNothing(Me.ParentMainControl.EditDataDate) OrElse _
    '           String.IsNullOrEmpty(Me.ParentMainControl.EditStationName) OrElse String.IsNullOrEmpty(Me.ParentMainControl.EditDataDateVersion) Then
    '            Return 0
    '        End If
    '        Dim QryTheUserLastEditRecord As String = "Select * from QABugRecord where CoilNumber='" & OldCoilNumber & "' and EditEmployeeID='" & Me.ParentMainControl.LoginID & "' and DataDate='" & Format(Me.ParentMainControl.EditDataDate, "yyyy/MM/dd") & "' and StationName='" & Me.ParentMainControl.EditStationName & "' and RecordState <> 3  and Version='" & Me.ParentMainControl.EditDataDateVersion & "' Order by DataCreateTime Desc "
    '        Dim SearchResult As List(Of QABugRecord) = QABugRecord.CDBSelect(Of QABugRecord)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryTheUserLastEditRecord)
    '        If SearchResult.Count = 0 Then
    '            Return 0
    '        End If
    '        Dim SetDataVersion As Integer = 1
    '        Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
    '        Dim ChangeTargetLastVersion As String = "Select top 1 Version from QABugRecord where CoilNumber='" & NewCoilNumber & "' and EditEmployeeID<>'" & Me.ParentMainControl.LoginID & "'  and DataDate='" & Format(Me.ParentMainControl.EditDataDate, "yyyy/MM/dd") & "' and StationName='" & Me.ParentMainControl.EditStationName & "'  and RecordState <> 3  Order by Version Desc "
    '        Dim SearchResult1 As DataTable = Adapter.SelectQuery(ChangeTargetLastVersion)
    '        If SearchResult1.Rows.Count > 0 Then
    '            SetDataVersion = Val(SearchResult1.Rows(0).Item(0)) + 1
    '        End If
    '        Dim ReturnValue As Integer = 0
    '        Dim WillDeleteItem As QABugRecord
    '        For Each EachItem As QABugRecord In SearchResult
    '            WillDeleteItem = EachItem.CDBClone
    '            With EachItem
    '                .CoilNumber = NewCoilNumber
    '                .Version = SetDataVersion
    '            End With
    '            If EachItem.CDBSave() > 0 Then
    '                WillDeleteItem.CDBDelete()
    '                ReturnValue += 1
    '            End If
    '        Next

    '        '變更鋼捲厚度之鋼捲號嗎
    '        QryTheUserLastEditRecord = "Select * from QAThickness where CoilNumber='" & OldCoilNumber & "' and EditEmployeeID='" & Me.ParentMainControl.LoginID & "' and DataDate='" & Format(Me.ParentMainControl.EditDataDate, "yyyy/MM/dd") & "' and StationName='" & Me.ParentMainControl.EditStationName & "' and RecordState <> 3  and Version='" & Me.ParentMainControl.EditDataDateVersion & "' Order by DataCreateTime Desc "
    '        Dim SearchResult3 As List(Of QAThickness) = QABugRecord.CDBSelect(Of QAThickness)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryTheUserLastEditRecord)
    '        If SearchResult3.Count = 0 Then
    '            Return 0
    '        End If
    '        SetDataVersion = 1
    '        Adapter = New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
    '        ChangeTargetLastVersion = "Select top 1 Version from QAThickness where CoilNumber='" & NewCoilNumber & "' and EditEmployeeID<>'" & Me.ParentMainControl.LoginID & "'  and DataDate='" & Format(Me.ParentMainControl.EditDataDate, "yyyy/MM/dd") & "' and StationName='" & Me.ParentMainControl.EditStationName & "'  and RecordState <> 3  Order by Version Desc "
    '        Dim SearchResult4 As DataTable = Adapter.SelectQuery(ChangeTargetLastVersion)
    '        If SearchResult4.Rows.Count > 0 Then
    '            SetDataVersion = Val(SearchResult4.Rows(0).Item(0)) + 1
    '        End If
    '        Dim WillDeleteItem1 As QAThickness
    '        For Each EachItem As QAThickness In SearchResult3
    '            WillDeleteItem1 = EachItem.CDBClone
    '            With EachItem
    '                .CoilNumber = NewCoilNumber
    '                .Version = SetDataVersion
    '            End With
    '            If EachItem.CDBSave() > 0 Then
    '                WillDeleteItem1.CDBDelete()
    '                ReturnValue += 1
    '            End If
    '        Next


    '        Return ReturnValue
    '    End Function
    '#End Region

    Sub New(ByVal SetParentMainControl As MainControl)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.ParentMainControl = SetParentMainControl
    End Sub

    Private Sub MainControl_CoilNumberInput_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim myEnglishKeyboard As New EnblishKeyboard
        With myEnglishKeyboard
            AddHandler myEnglishKeyboard.ButtonClickEvent, AddressOf Keyboard_Click
            .Dock = DockStyle.Fill
        End With
        Panel1.Controls.Add(myEnglishKeyboard)

        Dim myNumberkEYBOARD As New NumberKeyboard
        With myNumberkEYBOARD
            AddHandler myNumberkEYBOARD.ButtonClickEvent, AddressOf Keyboard_Click
            .Dock = DockStyle.Fill
        End With
        Panel2.Controls.Add(myNumberkEYBOARD)
    End Sub

    Private Sub btnOKReturn_Click(sender As Object, e As EventArgs) Handles btnOKReturn.Click
        RaiseEvent ButtonClickEvent(Me, tbCoilNumber.Text)
        tbCoilNumber.Text = ""
        btnOKReturn.Enabled = False
    End Sub

    Private Sub btnCancelReturn_Click(sender As Object, e As EventArgs) Handles btnCancelReturn.Click
        RaiseEvent ButtonClickEvent(Me, Nothing)
        tbCoilNumber.Text = ""
        btnOKReturn.Enabled = False
    End Sub

    Private Sub Keyboard_Click(sender As Object, Value As String)
        Dim EditTextBox As TextBox = Nothing
        Select Case True
            Case tbCoilNumber.BackColor = Color.LightPink
                EditTextBox = tbCoilNumber
            Case tbNewCoilNumber.BackColor = Color.LightPink
                EditTextBox = tbNewCoilNumber
            Case Else
                EditTextBox = Nothing
        End Select
        If IsNothing(EditTextBox) Then
            Exit Sub
        End If
        Select Case True
            Case TypeOf sender Is EnblishKeyboard
                If EditTextBox.SelectedText = EditTextBox.Text Then
                    EditTextBox.Text = Nothing
                End If
                EditTextBox.Text &= Value
            Case TypeOf sender Is NumberKeyboard AndAlso Value = "DELETE"
                If EditTextBox.Text.Length <= 1 Then
                    EditTextBox.Text = "" : Exit Select
                End If
                EditTextBox.Text = EditTextBox.Text.Substring(0, EditTextBox.Text.Length - 1)
            Case TypeOf sender Is NumberKeyboard AndAlso Value = "CLEAR"
                EditTextBox.Text = "" : Exit Select
            Case TypeOf sender Is NumberKeyboard AndAlso Value = "OK"
                btnOKReturn_Click(btnOKReturn, Nothing)
            Case TypeOf sender Is NumberKeyboard AndAlso Value = "DOT"
                Exit Select
            Case TypeOf sender Is NumberKeyboard
                If EditTextBox.SelectedText = EditTextBox.Text Then
                    EditTextBox.Text = Nothing
                End If
                EditTextBox.Text &= Value
        End Select
        RefreshControlEnableOrVisible()
    End Sub

    Private Sub tbCoilNumber_Click(sender As Object, e As EventArgs) Handles tbCoilNumber.Click, tbNewCoilNumber.Click
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub tbCoilNumber_GotFocus(sender As Object, e As EventArgs) Handles tbCoilNumber.GotFocus, tbNewCoilNumber.GotFocus
        tbCoilNumber.BackColor = IIf(sender Is tbCoilNumber, Color.LightPink, Color.White)
        tbNewCoilNumber.BackColor = IIf(sender Is tbNewCoilNumber, Color.LightPink, Color.White)
    End Sub

    Private Sub tbCoilNumber_TextChanged(sender As Object, e As EventArgs) Handles tbCoilNumber.TextChanged, tbNewCoilNumber.TextChanged
        RefreshControlEnableOrVisible()
    End Sub

    Private Sub btnMixCoilChange_Click(sender As Object, e As EventArgs) Handles btnMixCoilChange.Click

        Select Case True
            Case IsNothing(Me.ParentMainControl) OrElse String.IsNullOrEmpty(Me.ParentMainControl.CanEditStationLine)
                MsgBox("請先設定產線名稱", MsgBoxStyle.OkOnly)
                Exit Sub
            Case tbCoilNumber.Text.Trim = Me.ParentMainControl.EditOutCoilNumber
                MsgBox("請先結束目前編修中的鋼捲,再進行修改鋼捲編號動作!", MsgBoxStyle.OkOnly)
                Exit Sub
        End Select

        If MsgBox("是否確定要將" & Me.ParentMainControl.CurrentEditStationLine & " 您所編輯的鋼捲號碼 " & tbCoilNumber.Text & " 改為 " & tbNewCoilNumber.Text & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        If Me.ParentMainControl.ChangeCoilNumberForLastUserEditVersion(tbCoilNumber.Text.Trim, tbNewCoilNumber.Text.Trim, tbCoilNumber.Text.Trim, tbNewCoilNumber.Text.Trim) Then
            MsgBox("成功變更 " & tbCoilNumber.Text.Trim & " 鋼捲編號成 " & tbNewCoilNumber.Text.Trim & " !", vbOKOnly)
        Else
            MsgBox("變更失敗請先確認 " & tbCoilNumber.Text.Trim & " 鋼捲編號是否存在於目前可編修產線" & Me.ParentMainControl.CanEditStationLine & "!", vbOKOnly)
        End If
        Me.ParentMainControl.GoRunNextInputProcess()
    End Sub


    Private Sub pbGetOnlineCoilNumber_Click(sender As Object, e As EventArgs) Handles pbGetOnlineCoilNumber.Click
        If IsNothing(Me.ParentMainControl) OrElse String.IsNullOrEmpty(Me.ParentMainControl.CurrentEditStationLine) Then
            MsgBox("請先設定產線名稱", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        Dim QryString As String = "Select * from OperationPCRunningState where runningpcip='" & Me.ParentMainControl.PrintLabelStationIP & "'"
        If Not String.IsNullOrEmpty(QryString) Then
            Dim SearchResult As List(Of OperationPCRunningState) = OperationPCRunningState.CDBSelect(Of OperationPCRunningState)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
            If SearchResult.Count > 0 AndAlso Not String.IsNullOrEmpty(SearchResult(0).RunningProcessCoils) AndAlso SearchResult(0).RunningProcessCoils.Trim.Length > 0 Then
                Dim RunningCoils As List(Of String) = SearchResult(0).RunningProcessCoils.Split(";").ToList
                If RunningCoils.Count > 0 Then
                    tbCoilNumber.Text = RunningCoils(RunningCoils.Count - 1).Trim
                End If
            End If
        End If
    End Sub



    Private Sub btnHisCoil1_Click(sender As Object, e As EventArgs) Handles btnHisCoil1.Click, btnHisCoil2.Click, btnHisCoil3.Click, btnHisCoil4.Click, btnHisCoil5.Click, btnHisCoil1.Click, btnHisCoil6.Click
        tbCoilNumber.Text = CType(sender, Button).Text
        Call btnOKReturn_Click(Nothing, Nothing)
    End Sub

End Class
