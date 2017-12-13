Partial Public Class BorrowContractRate

    Dim DBDataContext As New FincialDataContext

#Region "銀行名稱 屬性:BankName"
    ''' <summary>
    ''' 銀行名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BankName() As String
        Get
            If String.IsNullOrEmpty(Me.BankNumber) Then
                Return Nothing
            End If
            Dim GetValue As List(Of CompanyORMDB.CASH.CASH05PF) = CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.CASH.CASH05PF)("Select * from @#CASH.CASH05PF WHERE BANKN1='" & Me.BankNumber & "'")

            If GetValue.Count = 0 Then
                Return Nothing
            End If
            Return GetValue.Item(0).BANKNM
        End Get
    End Property
#End Region
#Region "合約種類別稱  屬性:ContractKindName"
    ''' <summary>
    ''' 合約種類別稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ContractKindName() As String
        Get
            Dim ReturnValue As String = "未知!"
            Select Case True
                Case Me.ContractKind = "S1"
                    ReturnValue = "短期借款"
                Case Me.ContractKind = "S2"
                    ReturnValue = "透支"
                Case Me.ContractKind = "S3"
                    ReturnValue = "LC"
                Case Me.ContractKind = "S4"
                    ReturnValue = "商業本票"
                Case Me.ContractKind = "S5"
                    ReturnValue = "工程保證"
                Case Me.ContractKind = "L1"
                    ReturnValue = "長期借款"
                Case Me.ContractKind = "L2"
                    ReturnValue = "長期循環"
                Case Me.ContractKind = "99"
                    ReturnValue = "綜合額度"
            End Select
            Return ReturnValue
        End Get
    End Property
#End Region
#Region "付息方式名稱 屬性:PayRateKindName"
    ''' <summary>
    ''' 付息方式名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PayRateKindName() As String
        Get
            If IsNothing(Me.About_BorrowContract) Then
                Return Nothing
            End If
            Dim ReturnValue As String = Nothing
            Select Case About_BorrowContract.PayRateKind
                Case 1
                    ReturnValue = "月"
                Case 2
                    ReturnValue = "日(算頭不算尾)"
                Case 3
                    ReturnValue = "日(頭尾都算)"
            End Select
            Return ReturnValue
        End Get
    End Property
#End Region

#Region "相關合約 屬性:About_BorrowContract"
    Private _About_BorrowContract As BorrowContract
    ''' <summary>
    ''' 相關合約
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property About_BorrowContract() As BorrowContract
        Get
            If IsNothing(_About_BorrowContract) Then
                _About_BorrowContract = (From A In DBDataContext.BorrowContract Where A.BankNumber = Me.BankNumber And A.ContractKind = Me.ContractKind And A.StartDate = Me.StartDate Select A).FirstOrDefault
            End If
            Return _About_BorrowContract
        End Get
    End Property
#End Region

End Class
