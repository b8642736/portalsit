Partial Public Class BorrowPayMoney
    Implements IBorrowPayMoneyDBObject


    Dim DBDataContext As New FincialDataContext


#Region "取得下一個可用編號ID 方法:GetNextCanUseID"
    ''' <summary>
    ''' 取得下一個可用編號ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetNextCanUseID() As Integer
        Return PublicModule1.GetNextNumber((From A In DBDataContext.BorrowPayMoney Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.FK_BorrowID Select A.ID).ToList)
    End Function
#End Region
#Region "借款銀行名稱 屬性:BorrowBankNumberName"
    ''' <summary>
    ''' 借款銀行名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BorrowBankNumberName() As String
        Get
            Return BorrowContract.GetBankName(Me.FK_BankNumber)
        End Get
    End Property
#End Region
#Region "付款銀行名稱 屬性:PayBankNumberName"
    ''' <summary>
    ''' 付款銀行名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PayBankNumberName() As String
        Get
            Return BorrowContract.GetBankName(Me.PayBankNumber)
        End Get
    End Property
#End Region
#Region "合約種類別稱 屬性:ContractKindName"
    ''' <summary>
    ''' 合約種類別稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ContractKindName() As String
        Get
            If IsNothing(About_Borrow) Then
                Return Nothing
            End If
            Return About_Borrow.ContractKindName
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
            If IsNothing(About_Borrow) Then
                Return Nothing
            End If
            Return About_Borrow.CreditMoneyName
        End Get
    End Property
#End Region
#Region "所有可用(不含綜合額度及LC)合約種類代碼 屬性:AllCanUseContractKindCodes"
    Private Shared _AllCanUseContractKindCodes As List(Of String)
    ''' <summary>
    ''' 所有可用(不含綜合額度及LC)合約種類代碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property AllCanUseContractKindCodes() As List(Of String)
        Get

            If IsNothing(_AllCanUseContractKindCodes) Then
                _AllCanUseContractKindCodes = (From A In BorrowContract.AllContractKindCodes Where A <> "99" And A <> "S3" Select A).ToList
            End If
            Return _AllCanUseContractKindCodes
        End Get
    End Property
#End Region
#Region "付款工具名稱 屬性:PayMoneyToolName"
    ''' <summary>
    ''' 付款工具名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PayMoneyToolName() As String
        Get
            Return GetPayMoneyToolName(Me.PayMoneyTool)
        End Get
    End Property
#End Region
#Region "所有付款工具代碼 屬性:AllPayMoneyToolCodes"
    Private Shared _AllPayMoneyToolCodes As List(Of Integer)
    ''' <summary>
    ''' 所有付款工具代碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property AllPayMoneyToolCodes() As List(Of Integer)
        Get
            If IsNothing(_AllPayMoneyToolCodes) Then
                _AllPayMoneyToolCodes = New List(Of Integer)
                For EachValue As Integer = 1 To 5
                    _AllPayMoneyToolCodes.Add(EachValue)
                Next
            End If
            Return _AllPayMoneyToolCodes
        End Get
    End Property
#End Region
#Region "取得付款工具名稱 方法:GetPayMoneyToolName"
    ''' <summary>
    ''' 取得付款工具名稱
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPayMoneyToolName(ByVal PayMoneyToolNumber As Integer) As String
        Dim ReturnValue As String = Nothing
        Select Case PayMoneyToolNumber
            Case 1
                ReturnValue = "支票"
            Case 2
                ReturnValue = "EDI"
            Case 3
                ReturnValue = "現轉傳票"
            Case 4
                ReturnValue = "支票匯款"
            Case 5
                ReturnValue = "支票劃付"
        End Select
        Return ReturnValue
    End Function
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

#Region "相關借款 屬性:About_Borrow"
    Private _About_Borrow As Borrow
    ''' <summary>
    ''' 相關LC相關借款
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
