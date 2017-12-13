Partial Public Class MessageBoard
    Dim DBContext As New EAFDataContext

    Private Sub OnCreated()
        Me.ID = "{" & Guid.NewGuid.ToString & "}"
        Me.StartDateTime = Now
        Me.EndDateTime = Me.StartDateTime.AddMonths(1)
    End Sub

End Class

