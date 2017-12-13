Partial Public Class EAFT2_Wait

#Region "等待時間(分) 屬性:WaitMinutes"
    ''' <summary>
    ''' 等待時間(分)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WaitMinutes() As Integer
        Get
            Return Me.EndTime.Subtract(Me.StartTime).TotalMinutes
        End Get
    End Property
#End Region


End Class
