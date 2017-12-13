Public Class ARState
    Sub New(ByVal SetStateName As String, ByVal SetValue As Integer)
        StateName = SetStateName
        Value = SetValue
    End Sub
    Property Value As Integer
    Property StateName As String
End Class
