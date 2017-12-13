Public Class ProcessSchedualRadioButton
    Inherits RadioButton
    Sub New(ByVal SetUseProcessSchedual As ProcessSchedual)
        UseProcessSchedual = SetUseProcessSchedual
        Me.Text = UseProcessSchedual.EquipmentName
    End Sub

#Region "使用中UseProcessSchedual 屬性:UseProcessSchedual"

    Private _UseProcessSchedual As ProcessSchedual
    ''' <summary>
    ''' 使用中UseProcessSchedual
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UseProcessSchedual() As ProcessSchedual
        Get
            Return _UseProcessSchedual
        End Get
        Private Set(ByVal value As ProcessSchedual)
            _UseProcessSchedual = value
        End Set
    End Property

#End Region

End Class
