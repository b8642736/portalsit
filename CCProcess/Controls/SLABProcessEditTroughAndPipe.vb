Public Class SLABProcessEditTroughAndPipe


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

    Private Sub TitleControlEvent_DataPositionChanged(sender As Object, e As System.EventArgs) Handles TitleControlEvent.DataPositionChanged
        If IsNothing(Me.TitleControl.CurrentEditSMSC2PF) Then
            Me.bsSMSC2PF.DataSource = Nothing
            Me.Enabled = False
        Else
            Me.bsSMSC2PF.DataSource = Me.TitleControl.CurrentEditSMSC2PF
            Me.Enabled = True
        End If
        Me.bsSMSC2PF.ResetBindings(False)
    End Sub


End Class
