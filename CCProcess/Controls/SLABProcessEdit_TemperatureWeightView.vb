﻿Public Class SLABProcessEdit_TemperatureWeightView

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
        If IsNothing(Me.TitleControl.CurrentEditSMSC2PF) OrElse _
            String.IsNullOrEmpty(Me.TitleControl.CurrentEditSMSC2PF.T1) OrElse _
            Me.TitleControl.CurrentEditSMSC2PF.T1.Trim.Length < 5 OrElse _
            Me.TitleControl.CurrentEditSMSC2PF.T2 <= 0 Then
            Me.bsTemperatureTimeDataView.DataSource = Nothing
            Me.bsTemperatureTimeDataView.ResetBindings(False)
            Me.Enabled = False
        End If
        Dim AboutSMSC1PF As CompanyORMDB.SMS100LB.SMSC1PF = Me.TitleControl.CurrentEditSMSC2PF.AboutSMSC1PF
        If IsNothing(AboutSMSC1PF) Then
            Me.bsTemperatureTimeDataView.DataSource = Nothing
            Me.bsTemperatureTimeDataView.ResetBindings(False)
            Me.Enabled = False
        End If
        Me.bsTemperatureTimeDataView.DataSource = TemperatureTimeDataView.GetTemperatureTimeDataViews(AboutSMSC1PF)
        Me.Enabled = True
        Me.bsTemperatureTimeDataView.ResetBindings(False)
    End Sub
End Class
