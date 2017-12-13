Public Class SLABProcessEdit

#Region "1目前正在執行的攪拌資料(溫度/重量)控制項 屬性:SLABProcessEdit_TemperatureWeightViewControl"
    Private _SLABProcessEdit_TemperatureWeightViewControl As New SLABProcessEdit_TemperatureWeightView
    ''' <summary>
    ''' 1目前正在執行的攪拌資料(溫度/重量)控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SLABProcessEdit_TemperatureWeightViewControl As SLABProcessEdit_TemperatureWeightView
        Get
            Return _SLABProcessEdit_TemperatureWeightViewControl
        End Get
    End Property
#End Region
#Region "2目前正在執行的分鋼槽液溫控制項 屬性:SLABProcessEdit_SteelTrouthTemperatureControl"
    Private _SLABProcessEdit_SteelTrouthTemperatureControl As New SLABProcessEdit_SteelTrouthTemperature
    ''' <summary>
    ''' 2目前正在執行的澆鑄過程控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SLABProcessEdit_SteelTrouthTemperatureControl As SLABProcessEdit_SteelTrouthTemperature
        Get
            Return _SLABProcessEdit_SteelTrouthTemperatureControl
        End Get
    End Property

#End Region
#Region "3目前正在執行的澆鑄過程控制項 屬性:SLABProcessEdit_SLABProcessEditCastProcessControl"
    Private _SLABProcessEdit_SLABProcessEditCastProcessControl As New SLABProcessEditCastProcess
    ''' <summary>
    ''' 3目前正在執行的澆鑄過程控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SLABProcessEdit_SLABProcessEditCastProcessControl As SLABProcessEditCastProcess
        Get
            Return _SLABProcessEdit_SLABProcessEditCastProcessControl
        End Get
    End Property
#End Region
#Region "4目前正在執行的鑄模條件控制項 屬性:SLABProcessEdit_SLABProcessEditModuleCondictionControl"
    Private _SLABProcessEdit_SLABProcessEditModuleCondictionControl As New SLABProcessEditModuleCondiction
    ''' <summary>
    ''' 目前正在執行的鑄模條件控制項SLABProcessEditModuleCondiction
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SLABProcessEdit_SLABProcessEditModuleCondictionControl As SLABProcessEditModuleCondiction
        Get
            Return _SLABProcessEdit_SLABProcessEditModuleCondictionControl
        End Get
    End Property
#End Region
#Region "5目前正在執行的分鋼槽時間及澆鑄管時間控制項 屬性:SLABProcessEdit_SLABProcessEditTroughAndPipeControl"
    Private _SLABProcessEdit_SLABProcessEditTroughAndPipeControl As New SLABProcessEditTroughAndPipe
    ''' <summary>
    ''' 5目前正在執行的分鋼槽時間及澆鑄管時間控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SLABProcessEdit_SLABProcessEditTroughAndPipeControl As SLABProcessEditTroughAndPipe
        Get
            Return _SLABProcessEdit_SLABProcessEditTroughAndPipeControl
        End Get
    End Property
#End Region
#Region "6目前正在執行的模冷却水溫度控制項 屬性:SLABProcessEdit_ModelWaterTemperatureControl"
    Private _SLABProcessEdit_ModelWaterTemperatureControl As New SLABProcessEdit_ModelWaterTemperature
    ''' <summary>
    ''' 6目前正在執行的模冷却水溫度控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SLABProcessEdit_ModelWaterTemperatureControl As SLABProcessEdit_ModelWaterTemperature
        Get
            Return _SLABProcessEdit_ModelWaterTemperatureControl
        End Get
    End Property
#End Region
#Region "7目前正在執行的二次冷却水控制項 屬性:SLABProcessEdit_SLABProcessEditSecondColdWaterControl"
    Private _SLABProcessEdit_SLABProcessEditSecondColdWaterControl As New SLABProcessEditSecondColdWater
    ''' <summary>
    ''' 7目前正在執行的二次冷却水控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SLABProcessEdit_SLABProcessEditSecondColdWaterControl As SLABProcessEditSecondColdWater
        Get
            Return _SLABProcessEdit_SLABProcessEditSecondColdWaterControl
        End Get
    End Property
#End Region
#Region "8目前正在顯示之化學成份控制項 屬性:SLABProcessEdit_SLABProcessEdit_ElementsInfoControl"
    Private _SLABProcessEdit_SLABProcessEdit_ElementsInfoControl As New SLABProcessEdit_ElementsInfo
    ''' <summary>
    ''' 8目前正在顯示之化學成份控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SLABProcessEdit_SLABProcessEdit_ElementsInfoControl As SLABProcessEdit_ElementsInfo
        Get
            Return _SLABProcessEdit_SLABProcessEdit_ElementsInfoControl
        End Get
    End Property
#End Region
    '#Region "9目前正在執行的重量及其它控制項 屬性:SLABProcessEdit_SLABProcessEditWeightAndOtherControl"
    '    Private _SLABProcessEdit_SLABProcessEditWeightAndOtherControl As New SLABProcessEditWeightAndOther
    '    ''' <summary>
    '    ''' 9目前正在執行的重量及其它控制項
    '    ''' </summary>
    '    ''' <value></value>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    ReadOnly Property SLABProcessEdit_SLABProcessEditWeightAndOtherControl As SLABProcessEditWeightAndOther
    '        Get
    '            Return _SLABProcessEdit_SLABProcessEditWeightAndOtherControl
    '        End Get
    '    End Property
    '#End Region

#Region "目前編輯之鋼胚連鑄記錄表記錄 屬性:CurrentEditSMSC2PF"
    ''' <summary>
    ''' 目前編輯之鋼胚連鑄記錄表記錄
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentEditSMSC2PF() As CompanyORMDB.SMS100LB.SMSC2PF
        Get
            If Me.bsSMSC2PF.Count = 0 Then
                Return Nothing
            End If
            Return Me.bsSMSC2PF.Current
        End Get
    End Property

#End Region

#Region "重整顯示畫面所有控制項 函式:RefreshDisplayControl"
    ''' <summary>
    ''' 重整顯示畫面所有控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshDisplayControl()
        tbSMSC1PF_F1.Enabled = True
        tbSMSC1PF_F2.Enabled = True
        If bsSMSC2PF.Position >= 0 AndAlso Not IsNothing(bsSMSC2PF.Current) Then
            Dim CurrentObject As CompanyORMDB.SMS100LB.SMSC2PF = bsSMSC2PF.Current
            If String.IsNullOrEmpty(CurrentObject.T1) Then
                Exit Sub
            End If
            Dim QryString As String = "Select count(*) from @#sms100lb.smsc2pf where T1='" & tbSMSC1PF_F1.Text & "' AND T3=" & Val(tbSMSC1PF_F2.Text.Trim)
            tbSMSC1PF_F1.Enabled = Not CType(AS400Adpter.SelectQuery(QryString).Rows(0).Item(0), Integer) > 0
            tbSMSC1PF_F2.Enabled = tbSMSC1PF_F1.Enabled
        End If

    End Sub
#End Region

#Region "資料來源位置變更 事件:DataPositionChanged(sender As Object, e As System.EventArgs)"
    ''' <summary>
    ''' 資料來源位置變更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event DataPositionChanged(sender As Object, e As System.EventArgs)
#End Region

#Region "設定查詢結果資料 方法:SetSearchResultDatas"
    ''' <summary>
    ''' 設定查詢結果資料
    ''' </summary>
    ''' <param name="SetDatas"></param>
    ''' <remarks></remarks>
    Public Sub SetSearchResultDatas(ByVal SetDatas As List(Of CompanyORMDB.SMS100LB.SMSC2PF))
        Me.bsSMSC2PF.CancelEdit()
        Me.bsSMSC2PF.DataSource = SetDatas
        Me.bsSMSC2PF.ResetBindings(False)
        If SetDatas.Count > 0 Then
            Me.bsSMSC2PF.MoveFirst()
            Me.SLABProcessEdit_SteelTrouthTemperatureControl.bsSMSC21PF.DataSource = Me.CurrentEditSMSC2PF.AboutSMSC21PFs
            Me.SLABProcessEdit_ModelWaterTemperatureControl.bsSMSC22PF.DataSource = Me.CurrentEditSMSC2PF.AboutSMSC22PFs
            Me.SLABProcessEdit_SteelTrouthTemperatureControl.bsSMSC21PF.ResetBindings(True)
            Me.SLABProcessEdit_ModelWaterTemperatureControl.bsSMSC22PF.ResetBindings(True)
            RaiseEvent DataPositionChanged(Nothing, Nothing)
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
        Me.bsSMSC2PF.EndEdit()
        Me.SLABProcessEdit_SteelTrouthTemperatureControl.DataGridView1.EndEdit()
        Me.SLABProcessEdit_ModelWaterTemperatureControl.DataGridView1.EndEdit()

        If Me.bsSMSC2PF.Count = 0 OrElse IsNothing(Me.CurrentEditSMSC2PF) OrElse String.IsNullOrEmpty(Me.CurrentEditSMSC2PF.T1) Then
            Me.bsSMSC2PF.Clear()
            Return True
        End If

        Try
            If Me.CurrentEditSMSC2PF.ValidData = False Then
                MsgBox(Me.CurrentEditSMSC2PF.ErrorMessage, vbOKOnly)
                Return False
            End If

            If Me.CurrentEditSMSC2PF.CDBSave() = 0 AndAlso MsgBox("此筆資料儲存是否要放棄存檔而離開?", vbYesNo) = MsgBoxResult.No Then
                Return False
            End If
        Catch ex As Exception
            If MsgBox("此筆資料儲存是否要放棄存檔而離開?系統錯誤:" & ex.ToString, vbYesNo) = MsgBoxResult.Yes Then
                Me.bsSMSC2PF.Clear()
                Return True
            End If
        End Try

        Me.bsSMSC2PF.Clear()
        Return True
    End Function
#End Region

#Region "新增或編輯溫度重量記錄表事件 屬性:NewOrEditSMSC1PFEvent"
    ''' <summary>
    ''' 新增或編輯連鑄記錄表事件
    ''' </summary>
    ''' <param name="EditData"></param>
    ''' <remarks></remarks>
    Public Event NewOrEditSMSC1PFEvent(ByVal EditData As CompanyORMDB.SMS100LB.SMSC1PF)
#End Region

#Region "顯示員工對話框 函式:ShowEmployeeSelectDialog"
    Private _ShowEmployeeSelectDialog As EmployeeSelectDialog
    WithEvents ShowEmployeeSelectDialogEvent As EmployeeSelectDialog
    ''' <summary>
    ''' 顯示員工對話框
    ''' </summary>
    ''' <param name="ReturnValueControl"></param>
    ''' <remarks></remarks>
    Private Sub ShowEmployeeSelectDialog(ByVal ReturnValueControl As TextBox)
        If IsNothing(_ShowEmployeeSelectDialog) Then
            _ShowEmployeeSelectDialog = New EmployeeSelectDialog
            ShowEmployeeSelectDialogEvent = _ShowEmployeeSelectDialog
        End If
        ShowEmployeeValueSetControl = ReturnValueControl
        Me.ParentForm.Enabled = False
        _ShowEmployeeSelectDialog.Show()
    End Sub
#End Region
#Region "顯示員工對話框回傳設定控制項 屬性:ShowEmployeeValueSetControl"
    ''' <summary>
    ''' 顯示員工對話框回傳設定控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property ShowEmployeeValueSetControl As TextBox
#End Region


    Dim AS400Adpter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

    Private Sub bsSMSC2PF_PositionChanged(sender As Object, e As System.EventArgs) Handles bsSMSC2PF.PositionChanged
        If Me.bsSMSC2PF.Count = 0 Then
            Me.bsSMSC2PF.AddNew()
            Me.bsSMSC2PF.ResetBindings(False)
            Exit Sub
        End If
        RefreshDisplayControl()
        RaiseEvent DataPositionChanged(sender, e)
    End Sub


    Private Sub SLABProcessEdit_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Panel1.Controls.Add(Me.SLABProcessEdit_TemperatureWeightViewControl) : Me.SLABProcessEdit_TemperatureWeightViewControl.Dock = DockStyle.Fill
        Me.SLABProcessEdit_TemperatureWeightViewControl.TitleControl = Me
        Panel2.Controls.Add(Me.SLABProcessEdit_SteelTrouthTemperatureControl) : Me.SLABProcessEdit_SteelTrouthTemperatureControl.Dock = DockStyle.Fill
        Me.SLABProcessEdit_SteelTrouthTemperatureControl.TitleControl = Me
        Panel3.Controls.Add(Me.SLABProcessEdit_SLABProcessEditCastProcessControl) : Me.SLABProcessEdit_SLABProcessEditCastProcessControl.Dock = DockStyle.Fill
        Me.SLABProcessEdit_SLABProcessEditCastProcessControl.TitleControl = Me
        Panel4.Controls.Add(Me.SLABProcessEdit_SLABProcessEditModuleCondictionControl) : Me.SLABProcessEdit_SLABProcessEditModuleCondictionControl.Dock = DockStyle.Fill
        Me.SLABProcessEdit_SLABProcessEditModuleCondictionControl.TitleControl = Me
        Panel5.Controls.Add(Me.SLABProcessEdit_SLABProcessEditTroughAndPipeControl) : Me.SLABProcessEdit_SLABProcessEditTroughAndPipeControl.Dock = DockStyle.Fill
        Me.SLABProcessEdit_SLABProcessEditTroughAndPipeControl.TitleControl = Me
        Panel6.Controls.Add(Me.SLABProcessEdit_ModelWaterTemperatureControl) : Me.SLABProcessEdit_ModelWaterTemperatureControl.Dock = DockStyle.Fill
        Me.SLABProcessEdit_ModelWaterTemperatureControl.TitleControl = Me
        Panel7.Controls.Add(Me.SLABProcessEdit_SLABProcessEditSecondColdWaterControl) : Me.SLABProcessEdit_SLABProcessEditSecondColdWaterControl.Dock = DockStyle.Fill
        Me.SLABProcessEdit_SLABProcessEditSecondColdWaterControl.TitleControl = Me
        Panel8.Controls.Add(Me.SLABProcessEdit_SLABProcessEdit_ElementsInfoControl) : Me.SLABProcessEdit_SLABProcessEdit_ElementsInfoControl.Dock = DockStyle.Fill
        Me.SLABProcessEdit_SLABProcessEdit_ElementsInfoControl.TitleControl = Me
        'TabPage9.Controls.Add(Me.SLABProcessEdit_SLABProcessEditWeightAndOtherControl) : Me.SLABProcessEdit_SLABProcessEditWeightAndOtherControl.Dock = DockStyle.Fill
        'Me.SLABProcessEdit_SLABProcessEditWeightAndOtherControl.TitleControl = Me
        Me.bsSMSC2PF.AddNew()
    End Sub

    Private Sub tbStoveNumber_TextChanged(sender As Object, e As System.EventArgs) Handles tbSMSC1PF_F1.TextChanged
        tbSMSC1PF_F1.Text = tbSMSC1PF_F1.Text.Trim.ToUpper
        tbSMSC1PF_F1.SelectionStart = tbSMSC1PF_F1.Text.Length
    End Sub

    Private Sub tbStoveNumber_LostFocus(sender As Object, e As System.EventArgs) Handles tbSMSC1PF_F1.LostFocus, tbSMSC1PF_F2.LostFocus
        If tbSMSC1PF_F1.Text.Trim.Length >= 5 Then
            If Val(tbSMSC1PF_F2.Text) = 0 Then
                Dim FindLastSMSC1PF As CompanyORMDB.SMS100LB.SMSC1PF = CompanyORMDB.SMS100LB.SMSC2PF.GetOneYearLastSMSC1PFForStoveNumber(tbSMSC1PF_F1.Text.Trim)
                If IsNothing(FindLastSMSC1PF) Then
                    Exit Sub
                End If
                Me.tbSMSC1PF_F2.Text = FindLastSMSC1PF.T3
            End If
            Me.bsSMSC2PF.EndEdit()
            Me.bsSMSC2PF.ResetBindings(False)
            RaiseEvent DataPositionChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub tsbSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbSave.Click
        Me.bsSMSC2PF.EndEdit()
        Me.SLABProcessEdit_SteelTrouthTemperatureControl.DataGridView1.EndEdit()
        Me.SLABProcessEdit_ModelWaterTemperatureControl.DataGridView1.EndEdit()


        Me.SLABProcessEdit_SLABProcessEditCastProcessControl.bsSMSC2PF.EndEdit()
        Me.SLABProcessEdit_SLABProcessEditModuleCondictionControl.bsSMSC2PF.EndEdit()
        Me.SLABProcessEdit_SLABProcessEditTroughAndPipeControl.bsSMSC2PF.EndEdit()
        Me.SLABProcessEdit_SLABProcessEditSecondColdWaterControl.bsSMSC2PF.EndEdit()
        'Me.SLABProcessEdit_SLABProcessEditWeightAndOtherControl.bsSMSC2PF.EndEdit()


        If Me.CurrentEditSMSC2PF.ValidData = False Then
            Exit Sub
        End If

        Me.CurrentEditSMSC2PF.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        If Me.CurrentEditSMSC2PF.CDBSave() = 0 AndAlso sender Is tsbSave Then
            MsgBox("資料存儲發生錯誤:" & Me.CurrentEditSMSC2PF.ErrorMessage)
        End If
        If Not String.IsNullOrEmpty(Me.CurrentEditSMSC2PF.ErrorMessage) Then
            Me.CurrentEditSMSC2PF.T1 = Nothing
            Me.bsSMSC2PF.ResetBindings(False)
        End If

    End Sub

    Private Sub tsbDelete_Click(sender As System.Object, e As System.EventArgs) Handles tsbDelete.Click
        If MsgBox("是否確確定刪除?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Me.bsSMSC2PF.EndEdit()
        If Not IsNothing(CurrentEditSMSC2PF) Then
            If Not CurrentEditSMSC2PF.IsFistAddNewData Then
                Me.CurrentEditSMSC2PF.SQLQueryAdapterByThisObject = AS400Adpter
                CurrentEditSMSC2PF.CDBDelete()
            End If
            Me.bsSMSC2PF.Remove(Me.bsSMSC2PF.Current)
            Me.bsSMSC2PF.ResetBindings(False)
            RefreshDisplayControl()
        End If

    End Sub

    Private Sub tsbAddNew_Click(sender As System.Object, e As System.EventArgs) Handles tsbAddNew.Click
        Call tsbSave_Click(sender, Nothing)
        If Not String.IsNullOrEmpty(Me.CurrentEditSMSC2PF.ErrorMessage) Then
            MsgBox("資料存儲發生錯誤,無法新增一筆新記錄(請核對資料再手動做資料儲存):" & Me.CurrentEditSMSC2PF.ErrorMessage)
            Exit Sub
        End If
        Me.bsSMSC2PF.AddNew()
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As System.Object, e As System.EventArgs) Handles BindingNavigatorMoveNextItem.Click, BindingNavigatorMoveLastItem.Click, BindingNavigatorMovePreviousItem.Click, BindingNavigatorMoveFirstItem.Click
        Call tsbSave_Click(sender, Nothing)
        If Not String.IsNullOrEmpty(Me.CurrentEditSMSC2PF.ErrorMessage) Then
            MsgBox(Me.CurrentEditSMSC2PF.ErrorMessage)
            Exit Sub
        End If
        Select Case True
            Case sender Is BindingNavigatorMoveNextItem
                Me.bsSMSC2PF.MoveNext()
            Case sender Is BindingNavigatorMoveLastItem
                Me.bsSMSC2PF.MoveLast()
            Case sender Is BindingNavigatorMovePreviousItem
                Me.bsSMSC2PF.MovePrevious()
            Case sender Is BindingNavigatorMoveFirstItem
                Me.bsSMSC2PF.MoveFirst()
        End Select
    End Sub

    Private Sub tsbAboutSMSC2PF_Click(sender As System.Object, e As System.EventArgs) Handles tsbAboutSMSC2PF.Click
        Call tsbSave_Click(sender, Nothing)
        If Not String.IsNullOrEmpty(Me.CurrentEditSMSC2PF.ErrorMessage) Then
            MsgBox(Me.CurrentEditSMSC2PF.ErrorMessage)
            Exit Sub
        End If

        If IsNothing(Me.CurrentEditSMSC2PF) OrElse Me.CurrentEditSMSC2PF.IsFistAddNewData = True Then
            Exit Sub
        End If
        Dim EditItem As CompanyORMDB.SMS100LB.SMSC1PF = Me.CurrentEditSMSC2PF.AboutSMSC1PF
        If IsNothing(EditItem) Then
            If MsgBox("尚未有溫度重量資料是否新增相關鋼水及重量記錄表?", vbYesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            EditItem = New CompanyORMDB.SMS100LB.SMSC1PF
            With EditItem
                .T1 = Me.CurrentEditSMSC2PF.T1
                .T3 = Me.CurrentEditSMSC2PF.T2
            End With
        End If
        RaiseEvent NewOrEditSMSC1PFEvent(EditItem)

    End Sub

    Private Sub ShowEmployeeSelectDialogEvent_ReturnEvent(ReturnValue As CompanyORMDB.PLT000LB.PQDM01PF) Handles ShowEmployeeSelectDialogEvent.ReturnEvent
        If Not IsNothing(ShowEmployeeValueSetControl) AndAlso Not IsNothing(ReturnValue) Then
            ShowEmployeeValueSetControl.Text = ReturnValue.QD100A
        End If
        Me.ParentForm.Enabled = True

    End Sub

    Private Sub btnSearchEmployee_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchEmployee.Click, btnSearchEmployee1.Click, btnSearchEmployee2.Click
        Select Case True
            Case sender Is btnSearchEmployee
                ShowEmployeeSelectDialog(TextBox15)
            Case sender Is btnSearchEmployee1
                ShowEmployeeSelectDialog(TextBox13)
            Case sender Is btnSearchEmployee2
                ShowEmployeeSelectDialog(TextBox14)
        End Select
    End Sub
End Class
