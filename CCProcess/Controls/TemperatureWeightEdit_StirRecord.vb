Public Class TemperatureWeightEdit_StirRecord

#Region "單頭控制項 屬性:TitleControl"
    Private _TitleControl As TemperatureWeightEdit
    ''' <summary>
    ''' 單頭控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TitleControl() As TemperatureWeightEdit
        Get
            Return _TitleControl
        End Get
        Set(ByVal value As TemperatureWeightEdit)
            Me.Enabled = IsNothing(_TitleControl)
            If Not IsNothing(_TitleControl) Then
                RemoveHandler _TitleControl.bsSMSC1PF.PositionChanged, AddressOf TitleDataPositionChanged
            End If
            If Not IsNothing(value) Then
                AddHandler value.bsSMSC1PF.PositionChanged, AddressOf TitleDataPositionChanged
            End If
            _TitleControl = value
        End Set
    End Property
#End Region

#Region "目前編輯之溫度及重量記錄單頭資料 屬性:CurrentEditSMSC1PF"
    ''' <summary>
    ''' 目前編輯之溫度及重量記錄單頭資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentEditSMSC1PF() As CompanyORMDB.SMS100LB.SMSC1PF
        Get
            If IsNothing(TitleControl) OrElse IsNothing(TitleControl.bsSMSC1PF) Then
                Return Nothing
            End If
            Return TitleControl.CurrentEditSMSC1PF
        End Get
    End Property

#End Region

    Private Sub TitleDataPositionChanged(sender As Object, e As System.EventArgs)
        If IsNothing(CurrentEditSMSC1PF) Then
            Me.bsSMSC11PF.DataSource = Nothing
            Me.Enabled = False
        Else
            Me.bsSMSC11PF.DataSource = CurrentEditSMSC1PF.AboutSMSC11PFs
            Me.Enabled = True
        End If
        Me.bsSMSC11PF.ResetBindings(False)
    End Sub

    Private Sub TemperatureWeightEdit_StirRecord_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim ArStaeteValues As New List(Of ARState)
        ArStaeteValues.Add(New ARState("未知", 0))
        ArStaeteValues.Add(New ARState("開", 1))
        ArStaeteValues.Add(New ARState("關", 2))
        Me.bsARState.DataSource = ArStaeteValues
    End Sub

    Private Sub bsSMSC11PF_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles bsSMSC11PF.AddingNew
        If IsNothing(CurrentEditSMSC1PF) Then
            e.NewObject = Nothing
            Exit Sub
        End If

        Dim NewObject As CompanyORMDB.SMS100LB.SMSC11PF = New CompanyORMDB.SMS100LB.SMSC11PF
        NewObject.T1 = CurrentEditSMSC1PF.T1
        NewObject.T2 = CurrentEditSMSC1PF.T3
        e.NewObject = NewObject
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As System.Object, e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
        If MsgBox("是否確確定刪除?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        If DataGridView1.IsCurrentCellInEditMode = True Then
            DataGridView1.CancelEdit()
        Else
            Dim CurrentRowObject As CompanyORMDB.SMS100LB.SMSC11PF = Me.DataGridView1.CurrentRow.DataBoundItem
            If Not IsNothing(CurrentRowObject) Then
                CurrentRowObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                CurrentRowObject.CDBDelete()
                Me.TitleControl.CurrentEditSMSC1PF.AboutSMSC11PFs.Remove(CurrentRowObject)
                Me.bsSMSC11PF.ResetBindings(False)
            End If
        End If
    End Sub


End Class
