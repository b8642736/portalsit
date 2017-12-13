Public Class TemperatureWeightEdit

#Region "目前是在執行的攪拌明細控制項 屬性:TemperatureWeightEdit_StirRecordEditControl"
    Private _TemperatureWeightEdit_StirRecordEditControl As New TemperatureWeightEdit_StirRecord
    ''' <summary>
    ''' 目前是在執行的攪拌明細控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TemperatureWeightEdit_StirRecordEditControl As TemperatureWeightEdit_StirRecord
        Get
            Return _TemperatureWeightEdit_StirRecordEditControl
        End Get
    End Property
#End Region
#Region "目前是在執行的攪拌明細控制項 屬性:TemperatureWeightEdit_MeasureRecordControl"
    Private _TemperatureWeightEdit_MeasureRecordControl As New TemperatureWeightEdit_MeasureRecord
    ''' <summary>
    ''' 目前是在執行的攪拌明細控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TemperatureWeightEdit_MeasureRecordControl As TemperatureWeightEdit_MeasureRecord
        Get
            Return _TemperatureWeightEdit_MeasureRecordControl
        End Get
    End Property
#End Region
#Region "目前編輯之溫度及重量記錄 屬性:CurrentEditSMSC1PF"
    ''' <summary>
    ''' 目前編輯之溫度及重量記錄單頭資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentEditSMSC1PF() As CompanyORMDB.SMS100LB.SMSC1PF
        Get
            If Me.bsSMSC1PF.Count = 0 Then
                Return Nothing
            End If
            Return Me.bsSMSC1PF.Current
        End Get
    End Property

#End Region

#Region "重整顯示畫面所有控制項 函式:RefreshDisplayControl"
    ''' <summary>
    ''' 重整顯示畫面所有控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshDisplayControl()
        tb_T1.Enabled = True
        TextBox5.Enabled = True
        If bsSMSC1PF.Position >= 0 AndAlso Not IsNothing(bsSMSC1PF.Current) Then
            Dim CurrentObject As CompanyORMDB.SMS100LB.SMSC1PF = bsSMSC1PF.Current
            If String.IsNullOrEmpty(CurrentObject.T1) Then
                Exit Sub
            End If
            Dim QryString As String = "Select count(*) from @#sms100lb.smsc1pf where T1='" & tb_T1.Text & "' AND T3=" & Val(TextBox5.Text.Trim)
            tb_T1.Enabled = Not CType(AS400Adpter.SelectQuery(QryString).Rows(0).Item(0), Integer) > 0
            TextBox5.Enabled = tb_T1.Enabled
        End If

    End Sub
#End Region
    '#Region "關閉前資料處理 函式:BeforeCloseProcess"
    '    ''' <summary>
    '    ''' 關閉前資料處理
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function BeforeCloseProcess() As Boolean
    '        Me.bsSMSC1PF.EndEdit()
    '        If Not IsNothing(Me.CurrentEditSMSC1PF) AndAlso Me.CurrentEditSMSC1PF.IsFistAddNewData AndAlso String.IsNullOrEmpty(Me.CurrentEditSMSC1PF.T1) Then
    '            Return True
    '        End If
    '        Call tsbSave_Click(Nothing, Nothing)
    '        If Me.ValidateChildren = False OrElse Not String.IsNullOrEmpty(Me.CurrentEditSMSC1PF.ErrorMessage) Then
    '            MsgBox("資料存儲發生錯誤(如不需要此筆資料請直接刪除)!:" & Me.CurrentEditSMSC1PF.ErrorMessage)
    '            Return False
    '        End If
    '        Return True
    '    End Function
    '#End Region

#Region "設定查詢結果資料 方法:SetSearchResultDatas"
    ''' <summary>
    ''' 設定查詢結果資料
    ''' </summary>
    ''' <param name="SetDatas"></param>
    ''' <remarks></remarks>
    Public Sub SetSearchResultDatas(ByVal SetDatas As List(Of CompanyORMDB.SMS100LB.SMSC1PF))
        Me.bsSMSC1PF.CancelEdit()
        Me.bsSMSC1PF.DataSource = SetDatas
        Me.bsSMSC1PF.ResetBindings(False)
        If SetDatas.Count > 0 Then
            Me.bsSMSC1PF.MoveFirst()
            Me.TemperatureWeightEdit_StirRecordEditControl.bsSMSC11PF.DataSource = Me.CurrentEditSMSC1PF.AboutSMSC11PFs
            Me.TemperatureWeightEdit_MeasureRecordControl.bsSMSC21PF.DataSource = Me.CurrentEditSMSC1PF.AboutSMSC21PFs
            Me.TemperatureWeightEdit_StirRecordEditControl.bsSMSC11PF.ResetBindings(True)
            Me.TemperatureWeightEdit_MeasureRecordControl.bsSMSC21PF.ResetBindings(True)
        End If
    End Sub
#End Region
#Region "詢問核對離開前之資料儲存 方法:IsCheckOutOK"
    ''' <summary>
    ''' 詢問核對離開前之資料儲存
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsCheckOutOK() As Boolean
        Me.bsSMSC1PF.EndEdit()
        Me.TemperatureWeightEdit_StirRecordEditControl.DataGridView1.EndEdit()
        Me.TemperatureWeightEdit_MeasureRecordControl.DataGridView1.EndEdit()

        If Me.bsSMSC1PF.Count = 0 OrElse IsNothing(Me.CurrentEditSMSC1PF) OrElse String.IsNullOrEmpty(Me.CurrentEditSMSC1PF.T1) Then
            Me.bsSMSC1PF.Clear()
            Return True
        End If

        Try
            If Me.CurrentEditSMSC1PF.ValidData = False Then
                MsgBox(Me.CurrentEditSMSC1PF.ErrorMessage, vbOKOnly)
                Return False
            End If

            If Me.CurrentEditSMSC1PF.CDBSave() = 0 AndAlso MsgBox("此筆資料儲存是否要放棄存檔而離開?", vbYesNo) = MsgBoxResult.No Then
                Return False
            End If
        Catch ex As Exception
            If MsgBox("此筆資料儲存是否要放棄存檔而離開?系統錯誤:" & ex.ToString, vbYesNo) = MsgBoxResult.Yes Then
                Me.bsSMSC1PF.Clear()
                Return True
            End If
        End Try

        Me.bsSMSC1PF.Clear()
        Return True
    End Function
#End Region

#Region "新增或編輯連鑄記錄表事件 屬性:NewOrEditSMSC2PFEvent"
    ''' <summary>
    ''' 新增或編輯連鑄記錄表事件
    ''' </summary>
    ''' <param name="EditData"></param>
    ''' <remarks></remarks>
    Public Event NewOrEditSMSC2PFEvent(ByVal EditData As CompanyORMDB.SMS100LB.SMSC2PF)
#End Region

    Dim AS400Adpter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

    Private Sub TemperatureWeightEdit_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Panel1.Controls.Add(TemperatureWeightEdit_StirRecordEditControl)
        TemperatureWeightEdit_StirRecordEditControl.Dock = DockStyle.Fill
        Panel2.Controls.Add(TemperatureWeightEdit_MeasureRecordControl)
        TemperatureWeightEdit_MeasureRecordControl.Dock = DockStyle.Fill
        Me.TemperatureWeightEdit_StirRecordEditControl.TitleControl = Me
        Me.TemperatureWeightEdit_MeasureRecordControl.TitleControl = Me
        If Me.bsSMSC1PF.Count = 0 Then
            Me.bsSMSC1PF.AddNew()
        End If
    End Sub


    Private Sub bsSMSC1PF_PositionChanged(sender As Object, e As System.EventArgs) Handles bsSMSC1PF.PositionChanged
        If Me.bsSMSC1PF.Count = 0 Then
            Me.bsSMSC1PF.AddNew()
            Me.bsSMSC1PF.ResetBindings(False)
        End If
        RefreshDisplayControl()
    End Sub

    Private Sub tsbAddNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbAddNew.Click
        Call tsbSave_Click(sender, Nothing)
        If Not String.IsNullOrEmpty(Me.CurrentEditSMSC1PF.ErrorMessage) Then
            MsgBox("資料存儲發生錯誤,無法新增一筆新記錄(請核對資料再手動做資料儲存):" & Me.CurrentEditSMSC1PF.ErrorMessage)
            Exit Sub
        End If
        Me.bsSMSC1PF.AddNew()
    End Sub

    Private Sub tsbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tsbDelete.Click
        If MsgBox("是否確確定刪除?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Me.bsSMSC1PF.EndEdit()
        If Not IsNothing(CurrentEditSMSC1PF) Then
            If Not CurrentEditSMSC1PF.IsFistAddNewData Then
                Me.CurrentEditSMSC1PF.SQLQueryAdapterByThisObject = AS400Adpter
                CurrentEditSMSC1PF.CDBDelete()
            End If
            Me.bsSMSC1PF.Remove(Me.bsSMSC1PF.Current)
            Me.bsSMSC1PF.ResetBindings(False)
            RefreshDisplayControl()
        End If
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        'Me.CurrentEditSMSC1PF.ErrorMessage = Nothing
        'Me.bsSMSC1PF.EndEdit()
        'If Me.ValidateChildren = False Then
        '    Exit Sub
        'End If

        Me.bsSMSC1PF.EndEdit()
        Me.TemperatureWeightEdit_StirRecordEditControl.DataGridView1.EndEdit()
        Me.TemperatureWeightEdit_MeasureRecordControl.DataGridView1.EndEdit()
        If Me.CurrentEditSMSC1PF.ValidData = False Then
            Exit Sub
        End If

        Me.CurrentEditSMSC1PF.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        If Me.CurrentEditSMSC1PF.CDBSave() = 0 AndAlso sender Is tsbSave Then
            MsgBox("資料存儲發生錯誤:" & Me.CurrentEditSMSC1PF.ErrorMessage)
        End If
        If Not String.IsNullOrEmpty(Me.CurrentEditSMSC1PF.ErrorMessage) Then
            Me.CurrentEditSMSC1PF.T1 = Nothing
            Me.bsSMSC1PF.ResetBindings(False)
        End If
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As System.Object, e As System.EventArgs) Handles BindingNavigatorMoveNextItem.Click, BindingNavigatorMoveLastItem.Click, BindingNavigatorMovePreviousItem.Click, BindingNavigatorMoveFirstItem.Click
        Call tsbSave_Click(sender, Nothing)
        If Not String.IsNullOrEmpty(Me.CurrentEditSMSC1PF.ErrorMessage) Then
            MsgBox(Me.CurrentEditSMSC1PF.ErrorMessage)
            Exit Sub
        End If
        Select Case True
            Case sender Is BindingNavigatorMoveNextItem
                Me.bsSMSC1PF.MoveNext()
            Case sender Is BindingNavigatorMoveLastItem
                Me.bsSMSC1PF.MoveLast()
            Case sender Is BindingNavigatorMovePreviousItem
                Me.bsSMSC1PF.MovePrevious()
            Case sender Is BindingNavigatorMoveFirstItem
                Me.bsSMSC1PF.MoveFirst()
        End Select
    End Sub

    Private Sub tsbAboutSMSC2PF_Click(sender As System.Object, e As System.EventArgs) Handles tsbAboutSMSC2PF.Click
        Call tsbSave_Click(sender, Nothing)
        If Not String.IsNullOrEmpty(Me.CurrentEditSMSC1PF.ErrorMessage) Then
            MsgBox(Me.CurrentEditSMSC1PF.ErrorMessage)
            Exit Sub
        End If

        If IsNothing(Me.CurrentEditSMSC1PF) OrElse Me.CurrentEditSMSC1PF.IsFistAddNewData = True Then
            Exit Sub
        End If
        Dim EditItem As CompanyORMDB.SMS100LB.SMSC2PF = Me.CurrentEditSMSC1PF.AboutSMSC2PF
        If IsNothing(EditItem) Then
            If MsgBox("尚未有連鑄資料是否新增相關續鑄造記錄表?", vbYesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            EditItem = New CompanyORMDB.SMS100LB.SMSC2PF
            With EditItem
                .T1 = Me.CurrentEditSMSC1PF.T1
                .T2 = Me.CurrentEditSMSC1PF.T3
            End With
        End If
        RaiseEvent NewOrEditSMSC2PFEvent(EditItem)
    End Sub

    Private Sub tb_T1_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_T1.TextChanged, tb_T2.TextChanged
        Dim SenderControl As TextBox = sender
        SenderControl.Text = SenderControl.Text.ToUpper.Trim
        SenderControl.SelectionStart = SenderControl.Text.Length
    End Sub
End Class
