Public Class SLABProcessEdit_ModelWaterTemperature

#Region "單頭控制項 屬性/事件:TitleControl/TitleControlEvent"
    WithEvents TitleControlEvent As SLABProcessEdit
    Private _TitleControl As SLABProcessEdit
    ''' <summary>
    ''' 單頭控制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TitleControl() As SLABProcessEdit
        Get
            Return _TitleControl
        End Get
        Set(ByVal value As SLABProcessEdit)
            Me.Enabled = IsNothing(_TitleControl)
            TitleControlEvent = value
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
    Public ReadOnly Property CurrentEditSMSC2PF() As CompanyORMDB.SMS100LB.SMSC2PF
        Get
            If IsNothing(TitleControl) OrElse IsNothing(TitleControl.bsSMSC2PF) Then
                Return Nothing
            End If
            Return TitleControl.CurrentEditSMSC2PF
        End Get
    End Property

#End Region

    Private Sub TitleControlEvent_DataPositionChanged(sender As Object, e As System.EventArgs) Handles TitleControlEvent.DataPositionChanged
        If IsNothing(CurrentEditSMSC2PF) Then
            Me.bsSMSC22PF.DataSource = Nothing
            Me.Enabled = False
        Else
            Me.bsSMSC22PF.DataSource = CurrentEditSMSC2PF.AboutSMSC22PFs
            Me.Enabled = True
        End If
        Me.bsSMSC22PF.ResetBindings(False)
    End Sub


    Private Sub BindingNavigatorDeleteItem_Click(sender As System.Object, e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
        If MsgBox("是否確確定刪除?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        If DataGridView1.IsCurrentCellInEditMode = True Then
            DataGridView1.CancelEdit()
        Else
            Dim CurrentRowObject As CompanyORMDB.SMS100LB.SMSC22PF = Me.DataGridView1.CurrentRow.DataBoundItem
            If Not IsNothing(CurrentRowObject) Then
                CurrentRowObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                CurrentRowObject.CDBDelete()
                Me.TitleControl.CurrentEditSMSC2PF.AboutSMSC22PFs.Remove(CurrentRowObject)
                Me.bsSMSC22PF.ResetBindings(False)
            End If
        End If
    End Sub

    Private Sub bsSMSC22PF_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles bsSMSC22PF.AddingNew
        If IsNothing(Me.TitleControl.CurrentEditSMSC2PF) Then
            e.NewObject = Nothing
            Exit Sub
        End If

        Dim NewObject As CompanyORMDB.SMS100LB.SMSC22PF = New CompanyORMDB.SMS100LB.SMSC22PF
        NewObject.T1 = Me.TitleControl.CurrentEditSMSC2PF.T1
        NewObject.T2 = Me.TitleControl.CurrentEditSMSC2PF.T2
        e.NewObject = NewObject

    End Sub
End Class
