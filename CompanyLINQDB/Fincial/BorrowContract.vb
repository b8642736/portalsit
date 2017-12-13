Partial Public Class BorrowContract

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
            Return GetBankName(Me.BankNumber)
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
            Return GetContractKindName(Me.ContractKind)
        End Get
    End Property
#End Region
#Region "幣別名稱 屬性:CreditMoneyName"
    ''' <summary>
    ''' 幣別名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CreditMoneyName() As String
        Get
            If String.IsNullOrEmpty(Me.CreditMoneyKind) Then
                Return Nothing
            End If
            'Dim GetValue As List(Of CompanyLINQDB.DEBY.DEBY07PF) = ClassDB.CDBSelect(Of CompanyLINQDB.DEBY.DEBY07PF)("Select * from @#DEBY.DEBY07PF WHERE TYPENO='" & Me.CreditMoneyKind & "'")
            Dim GetValue As List(Of CompanyORMDB.DEBY.DEBY07PF) = CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.DEBY.DEBY07PF)("Select * from @#DEBY.DEBY07PF WHERE TYPENO='" & Me.CreditMoneyKind & "'")
            If GetValue.Count = 0 Then
                Return Nothing
            End If
            Return GetValue.Item(0).TYPENM
        End Get
    End Property
#End Region
#Region "還款銀行名稱 屬性:RePaymentBankName"
    ''' <summary>
    ''' 還款銀行名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property RePaymentBankName() As String
        Get

            If String.IsNullOrEmpty(Me.RePaymentBankNumber) Then
                Return Nothing
            End If
            Dim GetValue As List(Of CompanyORMDB.CASH.CASH05PF) = CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.CASH.CASH05PF)("Select * from @#CASH.CASH05PF WHERE BANKN1='" & Me.RePaymentBankNumber & "'")
            If GetValue.Count = 0 Then
                Return Nothing
            End If
            Return GetValue.Item(0).BANKNM
        End Get
    End Property
#End Region
#Region "還款期限 屬性:RepaymentMonthsToYearMonthString"
    ''' <summary>
    ''' 還款期限
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property RepaymentMonthsToYearMonthString() As String
        Get
            If Me.RepaymentMonths < 0 Then
                Return Nothing
            End If
            Select Case True
                Case Me.RepaymentMonths < 0
                    Return Nothing
                Case Me.RepaymentMonths = 0
                    Return "0年0個月"
                Case Else
                    Dim YearCount As Integer = CType(Me.RepaymentMonths / 12, Integer)
                    Dim MonthCount As Integer = Me.RepaymentMonths - YearCount * 12
                    Return YearCount & "年" & MonthCount & "個月"
            End Select
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
            Return GetPayRateKindName(PayRateKind)
        End Get
    End Property
#End Region
#Region "是否為綜合額度合約 屬性:IsCompostBorrowContract"
    ''' <summary>
    ''' 是否為綜合額度合約
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsCompostBorrowContract() As Boolean
        Get
            'Return (From A In DBDataContext.BorrowContract Where A.IsHaveParentBorrowContract = True And A.FK_CompostBankNumber = Me.BankNumber And A.FK_CompostContractKind = Me.ContractKind And A.FK_CompostStartDate = Me.StartDate Select A).Count > 0
            Return Me.ContractKind = "99"
        End Get
    End Property
#End Region
#Region "是否為綜合額度合約中文 屬性:IsCompostBorrowContractChinese"
    ''' <summary>
    ''' 是否為綜合額度合約中文
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsCompostBorrowContractChinese() As String
        Get
            Return IIf(Me.IsCompostBorrowContract, "是", "否")
        End Get
    End Property

#End Region
#Region "所有合約種類代碼 屬性:AllContractKindCodes"
    Private Shared _AllContractKindCodes As List(Of String)
    ''' <summary>
    ''' 所有合約種類代碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property AllContractKindCodes() As List(Of String)
        Get
            If IsNothing(_AllContractKindCodes) Then
                _AllContractKindCodes = New List(Of String)
                _AllContractKindCodes.Add("S1")
                _AllContractKindCodes.Add("S2")
                _AllContractKindCodes.Add("S3")
                _AllContractKindCodes.Add("S4")
                _AllContractKindCodes.Add("S5")
                _AllContractKindCodes.Add("L1")
                _AllContractKindCodes.Add("L2")
                _AllContractKindCodes.Add("99")
            End If
            Return _AllContractKindCodes
        End Get
    End Property
#End Region

#Region "已借款金額 屬性:AlreadyBorrowMoney"
    ''' <summary>
    ''' 已借款金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AlreadyBorrowMoney() As Double
        Get
            If Me.IsCompostBorrowContract Then
                Dim ReturnValue As Double = 0
                For Each EachItem As BorrowContract In From A In DBDataContext.BorrowContract Where A.FK_CompostBankNumber = Me.BankNumber And A.FK_CompostContractKind = Me.ContractKind And A.FK_CompostStartDate = Me.StartDate Select A
                    ReturnValue += EachItem.AlreadyBorrowMoney
                Next
                Return ReturnValue
            End If

            Dim GetValues As List(Of Borrow) = (From A In DBDataContext.Borrow Where A.FK_BankNumber = Me.BankNumber And A.FK_ContractKind = Me.ContractKind And A.FK_StartDate = Me.StartDate Select A).ToList
            If GetValues.Count > 0 Then
                Return (From A In GetValues Select A.BorrowMoney).Sum
            End If

            Return 0
        End Get
    End Property
#End Region
#Region "已還款本金金額 屬性:AlreadyPayUseMoney"
    ''' <summary>
    ''' 已還款本金金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AlreadyPayUseMoney() As Double
        Get
            Dim ReturnValue As Double = 0
            If Me.IsCompostBorrowContract Then
                For Each EachItem As BorrowContract In From A In DBDataContext.BorrowContract Where A.FK_CompostBankNumber = Me.BankNumber And A.FK_CompostContractKind = Me.ContractKind And A.FK_CompostStartDate = Me.StartDate Select A
                    ReturnValue += EachItem.AlreadyPayUseMoney
                Next
                Return ReturnValue
            End If
            For Each EachItem As Borrow In From A In DBDataContext.Borrow Where A.FK_BankNumber = Me.BankNumber And A.FK_ContractKind = Me.ContractKind And A.FK_StartDate = Me.StartDate Select A
                ReturnValue += EachItem.AlreadyPayUseMoney
            Next
            Return ReturnValue
        End Get
    End Property
#End Region
#Region "可動用額度 屬性:CanUseMoney"
    ''' <summary>
    ''' 可動用額度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CanUseMoney() As Double
        Get
            Dim ReturnValue As Double = 0
            If Me.IsCompostBorrowContract Then
                For Each EachItem As BorrowContract In From A In DBDataContext.BorrowContract Where A.FK_CompostBankNumber = Me.BankNumber And A.FK_CompostContractKind = Me.ContractKind And A.FK_CompostStartDate = Me.StartDate Select A
                    ReturnValue += EachItem.CanUseMoney
                Next
                ReturnValue = IIf(ReturnValue > Me.CreditMoney, Me.CreditMoney, ReturnValue)    '可用金額不可大於主合約額度
            Else
                ReturnValue = Me.CreditMoney - Me.AlreadyBorrowMoney
                If Me.ContractKind = "L2" OrElse Me.ContractKind = "S3" Then    '長期循環或LC還款需加回額度
                    ReturnValue += Me.AlreadyPayUseMoney
                End If
            End If
            Return ReturnValue
        End Get
    End Property
#End Region
#Region "可動用台幣額度 屬性:CanUseNTMoney"
    ''' <summary>
    ''' 可動用台幣額度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CanUseNTMoney() As Double
        Get
            Return Me.CanUseMoney * NTExchangeRate
        End Get
    End Property
#End Region
#Region "可借時間 屬性:CanBorrorTimeSpan"
    ''' <summary>
    ''' 可借時間
    ''' </summary>
    ''' <remarks></remarks>
    Private _CanBorrorTimeSpan As TimeSpan = Nothing
    ReadOnly Property CanBorrorTimeSpan() As TimeSpan
        Get
            If IsNothing(_CanBorrorTimeSpan) Then

            End If
            Return _CanBorrorTimeSpan
        End Get
    End Property
#End Region
#Region "合約利率 屬性:ContractRate"
    ''' <summary>
    ''' 合約利率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ContractRate() As Single
        Get
            Dim ReturnValue As Single = 0
            Dim GetRateItem As BorrowContractRate = (From A In DBDataContext.BorrowContractRate Where A.BankNumber = Me.BankNumber And A.ContractKind = Me.ContractKind And A.StartDate = Me.StartDate And A.RateStartDate <= Now.Date And A.RateEndDate >= Now.Date Select A).FirstOrDefault
            If IsNothing(GetRateItem) Then
                Return 0
            End If
            Return GetRateItem.Rate
        End Get
    End Property
#End Region
#Region "台幣對換滙率 屬性:NTChangeRate"
    ''' <summary>
    ''' 台幣對換滙率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NTExchangeRate() As Single
        Get
            If Me.CreditMoneyKind = "07" Then
                Return 1
            End If
            Dim GetRate As List(Of CompanyORMDB.DEBYSYSLB.DEBKCRPF) = CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.DEBYSYSLB.DEBKCRPF)("Select * from @#DEBSYSLB.DEBKCRPF Where CURRNO='" & Me.CreditMoneyKind & "'")
            If GetRate.Count = 0 Then
                Return Nothing
            End If
            Return GetRate.Item(0).CHGRTE
        End Get
    End Property
#End Region
#Region "台幣合約金額 屬性:NTCreditMoney"
    ''' <summary>
    ''' 台幣合約金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NTCreditMoney() As Double
        Get
            If IsForeignMoneyKind Then
                Return Me.CreditMoney * Me.NTExchangeRate
            End If
            Return Me.CreditMoney
        End Get
    End Property
#End Region

#Region "是否為LC開狀 屬性:IsLCCreate"
    ''' <summary>
    ''' 是否為LC開狀
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsLCCreate() As Boolean
        Get
            Return Me.ContractKind.Trim = "S3"
        End Get
    End Property
#End Region
#Region "是否為外幣 屬性:IsForeignMoneyKind"
    ''' <summary>
    ''' 是否為外幣
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsForeignMoneyKind() As Boolean
        Get
            Return CreditMoneyKind.Trim <> "07"
        End Get
    End Property
#End Region

#Region "綜合合約排序篩選下取得可動用額度 屬性:SubBorrowContractCanUseMoneyByOrderAndFilder"

    Private _SubBorrowContractCanUseMoneyByOrderAndFilder As Double = 0
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubBorrowContractCanUseMoneyByOrderAndFilder() As Double
        Get
            If IsNothing(IsHaveParentBorrowContract) OrElse IsHaveParentBorrowContract = False Then
                Return Me.CanUseMoney
            End If
            Return _SubBorrowContractCanUseMoneyByOrderAndFilder
        End Get
        Private Set(ByVal value As Double)
            _SubBorrowContractCanUseMoneyByOrderAndFilder = value
        End Set
    End Property

#End Region

#Region "排序篩選取得額度分配子合約 函式:GetSubContractCanUseMoneyByOrderContractKind"
    ''' <summary>
    ''' 排序篩選取得額度分配子合約
    ''' </summary>
    ''' <param name="FilderAndOrdersContractType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSubContractCanUseMoneyByOrderAndFilder(ByVal FilderAndOrdersContractType As List(Of String)) As List(Of BorrowContract)
        If IsCompostBorrowContract = False Then
            Return Nothing
        End If
        Static SubBorrowContracts As List(Of BorrowContract) = Nothing
        If IsNothing(SubBorrowContracts) Then
            SubBorrowContracts = (From A In DBDataContext.BorrowContract Where A.FK_CompostBankNumber = Me.BankNumber And A.FK_CompostContractKind = Me.ContractKind And A.FK_CompostStartDate = Me.StartDate And FilderAndOrdersContractType.Contains(A.ContractKind) Select A).ToList
            Dim AlreadyToUseItems As New List(Of BorrowContract)
            Dim CanUseMoneyRemain As Double = Me.CreditMoney
            For Each EachItem As String In FilderAndOrdersContractType
                Dim TempData As String = EachItem
                If TempData = "BR" Then '開始以利率分配剩餘可用綜合總額度
                    For Each EachItem1 As BorrowContract In From A In SubBorrowContracts Where Not AlreadyToUseItems.Contains(A) Select A Order By A.ContractRate
                        EachItem1.SubBorrowContractCanUseMoneyByOrderAndFilder = IIf(CanUseMoneyRemain > EachItem1.CanUseMoney, EachItem1.CanUseMoney, CanUseMoneyRemain)
                        CanUseMoneyRemain -= EachItem1.SubBorrowContractCanUseMoneyByOrderAndFilder
                        If CanUseMoneyRemain <= 0 Then
                            Exit For
                        End If
                    Next
                    Exit For
                End If
                Dim GetItem As BorrowContract = (From A In SubBorrowContracts Where A.ContractKind = TempData Select A).FirstOrDefault
                If Not IsNothing(GetItem) Then
                    GetItem.SubBorrowContractCanUseMoneyByOrderAndFilder = IIf(CanUseMoneyRemain > GetItem.CanUseMoney, GetItem.CanUseMoney, CanUseMoneyRemain)
                    CanUseMoneyRemain -= GetItem.SubBorrowContractCanUseMoneyByOrderAndFilder
                    AlreadyToUseItems.Add(GetItem) '記錄已分配過的項目
                    If CanUseMoneyRemain <= 0 Then
                        Exit For
                    End If
                End If
            Next
        End If
        Return SubBorrowContracts
    End Function
#End Region

#Region "取得付息方式名稱 方法:GetPayRateKindName"
    ''' <summary>
    ''' 取得付息方式名稱
    ''' </summary>
    ''' <param name="SetPayRateKind"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPayRateKindName(ByVal SetPayRateKind As Integer) As String
        Dim ReturnValue As String = Nothing
        Select Case SetPayRateKind
            Case 1
                ReturnValue = "月"
            Case 2
                ReturnValue = "日(算頭不算尾)"
            Case 3
                ReturnValue = "日(頭尾都算)"
            Case 4
                ReturnValue = "借款時付息"
            Case 5
                ReturnValue = "到期一次付息"
        End Select
        Return ReturnValue
    End Function
#End Region
#Region "取得合約種類名稱 方法:GetContractKindName"
    ''' <summary>
    ''' 取得合約種類名稱
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetContractKindName(ByVal FindContrackKindCode As String) As String
        Dim ReturnValue As String = Nothing
        Select Case FindContrackKindCode
            Case "S1"
                ReturnValue = "短期借款"
            Case "S2"
                ReturnValue = "透支"
            Case "S3"
                ReturnValue = "LC"
            Case "S4"
                ReturnValue = "商業本票"
            Case "S5"
                ReturnValue = "工程保證"
            Case "L1"
                ReturnValue = "長期借款"
            Case "L2"
                ReturnValue = "長期循環"
            Case "99"
                ReturnValue = "綜合額度"
        End Select
        Return ReturnValue
    End Function
#End Region
#Region "取得借款銀行名稱 方法:GetBankName"
    ''' <summary>
    ''' 取得借款銀行名稱
    ''' </summary>
    ''' <param name="GetBankNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetBankName(ByVal GetBankNumber As String) As String
        If String.IsNullOrEmpty(GetBankNumber) Then
            Return Nothing
        End If
        Dim GetValue As List(Of CompanyORMDB.CASH.CASH05PF) = CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.CASH.CASH05PF)("Select * from @#CASH.CASH05PF WHERE BANKN1='" & GetBankNumber & "'")
        If GetValue.Count = 0 Then
            Return Nothing
        End If
        Return GetValue.Item(0).BANKNM
    End Function
#End Region


End Class


