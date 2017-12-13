Partial Public Class BorrowLCBillPayMoney
    Implements IBorrowPayMoneyDBObject

    Dim DBDataContext As New FincialDataContext


#Region "取得下一個可用編號ID 方法:GetNextCanUseID"
    ''' <summary>
    ''' 取得下一個可用編號ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetNextCanUseID() As Integer
        Return PublicModule1.GetNextNumber((From A In DBDataContext.BorrowLCBillPayMoney Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.FK_BorrowID And FK_BorrowLCBillID = Me.FK_BorrowLCBillID Select A.ID).ToList)
    End Function
#End Region

#Region "銀行名稱 屬性:BankName"
    ''' <summary>
    ''' 銀行名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BankName() As String
        Get
            If IsNothing(About_BorrowContract) Then
                Return Nothing
            End If
            Return About_BorrowContract.BankName

        End Get
    End Property
#End Region
#Region "LC編號 屬性:LCNumber"
    ''' <summary>
    ''' LC編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property LCNumber() As String
        Get
            If IsNothing(Me.About_Borrow) Then
                Return Nothing
            End If
            Return Me.About_Borrow.LCNumber
        End Get
    End Property
#End Region
#Region "幣別名稱 屬性:CreditMoneyName"
    ''' <summary>
    ''' 幣別說明
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CreditMoneyName() As String
        Get
            If IsNothing(About_BorrowContract) Then
                Return Nothing
            End If
            Return About_BorrowContract.CreditMoneyName
        End Get
    End Property
#End Region
#Region "還款日期 屬性:IPayMoneyDate"
    ''' <summary>
    ''' 還款日期
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IPayMoneyDate() As Date Implements IBorrowPayMoneyDBObject.PayMoneyDate
        Get
            Return Me.PayMoneyDate
        End Get
    End Property
#End Region
#Region "還款本金金額 屬性:IPayUseMoney"
    ''' <summary>
    ''' 還款本金金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IPayUseMoney() As Double Implements IBorrowPayMoneyDBObject.PayUseMoney
        Get
            Return Me.PayUseMoney
        End Get
    End Property
#End Region




#Region "相關借款合約 屬性:About_BorrowContract"
    Private _About_BorrowContract As CompanyLINQDB.BorrowContract = Nothing
    ''' <summary>
    ''' 相關借款合約
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property About_BorrowContract() As CompanyLINQDB.BorrowContract
        Get
            Dim DBDataContext As New CompanyLINQDB.FincialDataContext
            If IsNothing(_About_BorrowContract) Then
                _About_BorrowContract = (From A In DBDataContext.BorrowContract Where A.BankNumber = Me.FK_BankNumber And A.ContractKind = Me.FK_ContractKind And A.StartDate = Me.FK_StartDate Select A).FirstOrDefault
            End If
            Return _About_BorrowContract
        End Get
    End Property
#End Region
#Region "相關LC開狀 屬性:About_Borrow"
    Private _About_Borrow As Borrow
    ''' <summary>
    ''' 相關LC開狀
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property About_Borrow() As Borrow
        Get
            If IsNothing(_About_Borrow) Then
                _About_Borrow = (From A In DBDataContext.Borrow Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.ID = Me.FK_BorrowID Select A).FirstOrDefault

            End If
            Return _About_Borrow
        End Get
    End Property
#End Region
End Class
