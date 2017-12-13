Public Class SLABProcessEdit_ElementsInfo

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
            Me.bsElementInformation.DataSource = Nothing
            Me.bsElementInformation.ResetBindings(False)
            Me.Enabled = False
        End If
        Dim FindStoveNumber As String = Me.TitleControl.CurrentEditSMSC2PF.T1
        If Not IsNothing(FindStoveNumber) Then
            FindStoveNumber = FindStoveNumber.Trim
        End If
        Dim FindDate As Date
        Try
            FindDate = New CompanyORMDB.AS400DateConverter(Me.TitleControl.CurrentEditSMSC2PF.T2).DateValue
        Catch ex As Exception
            Me.bsElementInformation.DataSource = Nothing
            Me.bsElementInformation.ResetBindings(False)
            Me.Enabled = False
            Exit Sub
        End Try
        Me.bsElementInformation.DataSource = ElementInformation.GetElementInformations(FindStoveNumber, FindDate)
        Me.Enabled = True
        Me.bsElementInformation.ResetBindings(False)
    End Sub

End Class
