Public Class CastPowder
    Sub New(ByVal SetValue As Integer, ByVal SetCastPowderName As String)
        CastPowderName = SetCastPowderName
        Value = SetValue
    End Sub

    Property Value As Integer
    Property CastPowderName As String
End Class
