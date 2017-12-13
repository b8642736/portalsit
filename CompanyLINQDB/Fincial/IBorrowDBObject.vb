Public Interface IBorrowDBObject
    ReadOnly Property LastPayUseMoneyDate() As DateTime
    ReadOnly Property BorrowMoney() As Double
    ReadOnly Property PayRateKind() As Integer
    ReadOnly Property BorrowRate() As Single
    ReadOnly Property BorrowStartDate() As Date
    ReadOnly Property BorrowEndDate() As Date
    ReadOnly Property About_BorrowPayMoney() As List(Of IBorrowPayMoneyDBObject)
    Property SessionDateSurplusBorrowMoneys() As List(Of SessionDateSurplusBorrowMoneyClass)
    Function GetOneTimeSurplusBorrowMoney(ByVal SetTime As Date) As Double

End Interface
