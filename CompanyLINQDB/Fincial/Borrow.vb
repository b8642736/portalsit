Partial Public Class Borrow
    Implements IBorrowDBObject
    Dim DBDataContext As New FincialDataContext



#Region "取得下一個可用編號ID 方法:GetNextCanUseID"
    ''' <summary>
    ''' 取得下一個可用編號ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetNextCanUseID() As Integer
        Return PublicModule1.GetNextNumber((From A In DBDataContext.Borrow Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate Select A.ID).ToList)
    End Function
#End Region
#Region "確認資料正確性並取得錯誤訊息  方法:GetCheckDataError"
    ''' <summary>
    ''' 確認資料正確性並取得錯誤訊息
    ''' </summary>
    ''' <param name="SourceData"></param>
    ''' <param name="CheckMode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCheckDataError(ByVal SourceData As Borrow, Optional ByVal CheckMode As CheckDataErrorMode = CheckDataErrorMode.InsertMode) As String
        Dim DBDataContext0 As New FincialDataContext
        Dim ReturnValue As String = Nothing
        Dim EditModeOrginData As Borrow = Nothing
        If CheckMode = CheckDataErrorMode.Delete Then   '刪除前確認是否已有其它資料產生
            Dim IsLcCreate As Boolean = SourceData.About_BorrowContract.IsLCCreate
            Select Case True
                Case IsLcCreate = True AndAlso (From A In DBDataContext0.BorrowLCBill Where A.FK_BankNumber = SourceData.FK_BankNumber And A.FK_ContractKind = SourceData.FK_ContractKind And A.FK_StartDate = SourceData.FK_StartDate And A.FK_BorrowID = SourceData.ID Select A).Count > 0
                    ReturnValue = "已有LC到單資料,無法刪除!"
                Case IsLcCreate = False AndAlso (From A In DBDataContext0.BorrowPayMoney Where A.FK_BankNumber = SourceData.FK_BankNumber And A.FK_ContractKind = SourceData.FK_ContractKind And A.FK_StartDate = SourceData.FK_StartDate And A.FK_BorrowID = SourceData.ID Select A).Count > 0
                    ReturnValue = "已有付款資料,無法刪除!"
            End Select
            If Not String.IsNullOrEmpty(ReturnValue) Then
                Return ReturnValue
            End If
        End If

        If CheckMode = CheckDataErrorMode.EditMode Then
            Dim DBDataContext1 As New FincialDataContext
            EditModeOrginData = (From a In DBDataContext1.Borrow Where a.FK_BankNumber = SourceData.FK_BankNumber And a.FK_ContractKind = SourceData.FK_ContractKind And a.FK_StartDate = SourceData.FK_StartDate And a.ID = SourceData.ID Select a).FirstOrDefault
        End If
        Dim AboutBorrowContract As BorrowContract = SourceData.About_BorrowContract
        Dim TotalBorrowMonthCount As Integer = 0    '總借款月數
        Do While Format(SourceData.BorrowStartDate.AddMonths(TotalBorrowMonthCount), "yyyyMM") < Format(SourceData.BorrowEndDate, "yyyyMM")
            TotalBorrowMonthCount += 1
        Loop
        Dim RepaymentMoneyMonthCount As Integer = TotalBorrowMonthCount - SourceData.LatePayMonths  '可還款月數

        Select Case True
            Case IsNothing(AboutBorrowContract)
                ReturnValue = "無法參考到交易合約!"
            Case CheckMode = CheckDataErrorMode.EditMode And IsNothing(EditModeOrginData)
                ReturnValue = "編輯資料核對模式下找不到原始資料(可能已被其它使用者刪除)作核對,請重新查詢後再編修!!"
            Case CheckMode = CheckDataErrorMode.EditMode AndAlso AboutBorrowContract.CanUseMoney + EditModeOrginData.BorrowMoney < SourceData.BorrowMoney
                ReturnValue = "合約可使用金額不可大於 $" & AboutBorrowContract.CanUseMoney + EditModeOrginData.BorrowMoney
            Case CheckMode = CheckDataErrorMode.InsertMode AndAlso AboutBorrowContract.CanUseMoney <= 0
                ReturnValue = "合約可使用金額目前已為0!"
            Case SourceData.BorrowMoney <= 0
                ReturnValue = "借款金額不可小於0!"
            Case AboutBorrowContract.IsLCCreate AndAlso String.IsNullOrEmpty(SourceData.LCNumber)
                ReturnValue = "LCNumber不可為空白!"
            Case AboutBorrowContract.IsLCCreate AndAlso String.IsNullOrEmpty(SourceData.LCCaseNumber)
                ReturnValue = "LC案號不可為空白!"
            Case SourceData.ExchangeRate <= 0
                ReturnValue = "匯率不可小於等於零!"
            Case String.IsNullOrEmpty(SourceData.BorrowStartDate) OrElse String.IsNullOrEmpty(SourceData.BorrowEndDate)
                ReturnValue = "借款啟始及終止日期不可為空白!"
            Case SourceData.BorrowEndDate < SourceData.BorrowStartDate
                ReturnValue = "借款終止日必須大於借款啟始日!"
            Case SourceData.PayPrincipalMoneyDayNumber < 1 OrElse SourceData.PayPrincipalMoneyDayNumber > 31
                ReturnValue = "還本日不正確(範圍:1~31)!"
            Case SourceData.PayRateMoneyDayNumber < 1 OrElse SourceData.PayRateMoneyDayNumber > 31
                ReturnValue = "付息日不正確(範圍:1~31)!"
            Case SourceData.RePaymentTimes < 1 AndAlso SourceData.PayRateKind <> 4
                ReturnValue = "還款期數最少必須1期!"
            Case SourceData.RePaymentTimes <> 1 AndAlso SourceData.PayRateKind = 5
                ReturnValue = "到期時付息還款期數必須為1期!"
            Case SourceData.LatePayMonths < 0
                ReturnValue = "寬緩月數必須大於等於零!"
            Case SourceData.BorrowStartDate.AddMonths(AboutBorrowContract.RepaymentMonths) > SourceData.BorrowEndDate
                ReturnValue = "借款終止日必須小於或等於 借款起始日+合約還款期限(月數) !"
            Case SourceData.BorrowStartDate.AddMonths(SourceData.LatePayMonths).AddMonths(SourceData.RePaymentTimes) > SourceData.BorrowEndDate
                ReturnValue = "借款起始日+寬緩月數+還款期數 必須小於或等於借款終止日!"
            Case (SourceData.PayRateKind = 1 Or SourceData.PayRateKind = 2 Or SourceData.PayRateKind = 3) And (RepaymentMoneyMonthCount Mod SourceData.RePaymentTimes <> 0)
                ReturnValue = "還款月數:" & RepaymentMoneyMonthCount & " 無法被還款期數:" & SourceData.RePaymentTimes & "整除"
            Case SourceData.PayRateKind = 4 And SourceData.PayRateMoney <= 0
                ReturnValue = "借款時付息,付息金額必須大於0"
        End Select
        Return ReturnValue
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
#Region "借款金額 屬性:IBorrowMoney"
    ''' <summary>
    ''' 借款金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IBorrowMoney() As Double Implements IBorrowDBObject.BorrowMoney
        Get
            Return Me.BorrowMoney
        End Get
    End Property
#End Region
#Region "計息方式  屬性:IRateType"
    ''' <summary>
    ''' 計息方式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IPayRateKind() As Integer Implements IBorrowDBObject.PayRateKind
        Get
            Return Me.PayRateKind
        End Get
    End Property
#End Region
#Region "借款利率 屬性:IBorrowRate"
    ''' <summary>
    ''' 借款利率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IBorrowRate() As Single Implements IBorrowDBObject.BorrowRate
        Get
            Return Me.BorrowRate
        End Get
    End Property
#End Region
#Region "借款起始時間 屬性:IBorrowStartDate"
    ''' <summary>
    ''' 借款起始時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IBorrowStartDate() As Date Implements IBorrowDBObject.BorrowStartDate
        Get
            Return Me.BorrowStartDate
        End Get
    End Property
#End Region
#Region "借款終止時間 屬性:IBorrowEndDate"
    ''' <summary>
    ''' 借款終止時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IBorrowEndDate() As Date Implements IBorrowDBObject.BorrowEndDate
        Get
            Return Me.BorrowEndDate
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
            If IsNothing(About_BorrowContract) Then
                Return Nothing
            End If
            Return About_BorrowContract.ContractKindName
        End Get
    End Property
#End Region
#Region "已使用LC到單金額 屬性:AlreadyUseLCMoney"
    ''' <summary>
    ''' 已使用LC到單金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AlreadyUseLCBorrowMoney() As Double
        Get
            If IsNothing(Me.About_BorrowContract) OrElse Me.About_BorrowContract.IsLCCreate = False Then
                Return 0
            End If
            Return (From A In Me.About_BorrowLCBill Select A.UseMoney).Sum
        End Get
    End Property

#End Region
#Region "可用LC到單額度 屬性:CanUseLCMoney"
    ''' <summary>
    ''' 可用LC到單額度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CanUseLCMoney() As Double
        Get
            If IsNothing(Me.About_BorrowContract) OrElse Me.About_BorrowContract.IsLCCreate = False Then
                Return Nothing
            End If
            Return Me.BorrowMoney - AlreadyUseLCBorrowMoney
        End Get
    End Property
#End Region
#Region "欠款本金金額 屬性:DebtUseMoney"
    ''' <summary>
    ''' 欠款本金金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DebtUseMoney() As Double
        Get
            Return Me.BorrowMoney - Me.AlreadyPayUseMoney
        End Get
    End Property
#End Region
#Region "欠款利息金額 屬性:DebtRateMoney"
    ''' <summary>
    ''' 欠款利息金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DebtRateMoney() As Double
        Get

        End Get
    End Property
#End Region
#Region "欠款金額 屬性:DebtMoney"
    ''' <summary>
    ''' 欠款金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DebtMoney() As Double
        Get
            Return DebtUseMoney + DebtRateMoney
        End Get
    End Property
#End Region
#Region "假設計息日 屬性:HypothesisDebtRateMoneyDay"

    Private _HypothesisDebtRateMoneyDay As DateTime
    ''' <summary>
    ''' 假設計息日
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HypothesisDebtRateMoneyDay() As DateTime
        Get
            If IsNothing(_HypothesisDebtRateMoneyDay) Then
                _HypothesisDebtRateMoneyDay = Now.Date
            End If
            Return _HypothesisDebtRateMoneyDay
        End Get
        Set(ByVal value As DateTime)
            _HypothesisDebtRateMoneyDay = value
        End Set
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
            If IsNothing(About_BorrowContract) Then
                Return Nothing
            End If
            Return BorrowContract.GetPayRateKindName(Me.PayRateKind)
        End Get
    End Property
#End Region
#Region "是否為外幣借款 屬性:IsForeignMoneyKind"
    ''' <summary>
    ''' 是否為外幣借款
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsForeignMoneyKind() As Boolean
        Get
            If IsNothing(About_BorrowContract) Then
                Return Nothing
            End If
            Return About_BorrowContract.IsForeignMoneyKind
        End Get
    End Property
#End Region
#Region "最後還本日期  屬性:LastPayUseMoneyDate"
    ''' <summary>
    ''' 最後還本日期
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property LastPayUseMoneyDate() As DateTime Implements IBorrowDBObject.LastPayUseMoneyDate
        Get
            If WaitPayUseMoney >= 0 Then
                Return Me.BorrowEndDate
            End If
            Dim LastPayUseMoneyRecord As BorrowPayMoney = (From a In Me.About_BorrowPayMoney Select a Order By a.PayMoneyDate Descending).FirstOrDefault
            If IsNothing(LastPayUseMoneyRecord) Then
                Return Me.BorrowEndDate
            End If
            Return LastPayUseMoneyRecord.PayMoneyDate
        End Get
    End Property

#End Region
#Region "所有可用(不含綜合額度)合約種類代碼 屬性:AllCanUseContractKindCodes"
    Private Shared _AllCanUseContractKindCodes As List(Of String)
    ''' <summary>
    ''' 所有可用(不含綜合額度)合約種類代碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared ReadOnly Property AllCanUseContractKindCodes() As List(Of String)
        Get
            If IsNothing(_AllCanUseContractKindCodes) Then
                _AllCanUseContractKindCodes = (From A In BorrowContract.AllContractKindCodes Where A <> "99" Select A).ToList
            End If
            Return _AllCanUseContractKindCodes
        End Get
    End Property
#End Region



#Region "計畫付息資訊集合 屬性:PlanPayRateMoneyInformations"
    Private _PlanPayRateMoneyInformations As List(Of PayRateMoneyDaySessionClass)
    ''' <summary>
    ''' 計畫付息資訊集合
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PlanPayRateMoneyInformations() As List(Of PayRateMoneyDaySessionClass)
        Get
            If IsNothing(_PlanPayRateMoneyInformations) Then
                _PlanPayRateMoneyInformations = New List(Of PayRateMoneyDaySessionClass)
                If Me.BorrowStartDate > Me.BorrowEndDate OrElse Me.About_BorrowContract.PayRateKind = 4 Then
                    Return _PlanPayRateMoneyInformations
                End If

                Dim FinalBorrowENDDate As DateTime = IIf(Me.LastPayUseMoneyDate < Me.BorrowEndDate, Me.LastPayUseMoneyDate, Me.BorrowEndDate)
                If Me.PayRateKind = 5 Then '到期一次付息
                    _PlanPayRateMoneyInformations.Add(New PayRateMoneyDaySessionClass(Me.BorrowStartDate, FinalBorrowENDDate, PayRateMoneyDaySessionClass.RateTypeEnum.StartDateToBeforeEndDate, Me))
                    Return _PlanPayRateMoneyInformations
                End If

                Dim ToMonthCount As Integer = 0
                Do While Format(Me.BorrowStartDate.AddMonths(ToMonthCount), "yyyyMM") <= Format(FinalBorrowENDDate, "yyyyMM")
                    ToMonthCount += 1
                Loop

                Dim RecordDatePoints As New List(Of DateTime)
                For MonthCount As Integer = 0 To ToMonthCount
                    Dim SetYear As Integer = Me.BorrowStartDate.AddMonths(MonthCount).Year
                    Dim SetMonth As Integer = Me.BorrowStartDate.AddMonths(MonthCount).Month
                    Dim ThisMonthMaxDayNumber = DateTime.DaysInMonth(SetYear, SetMonth)
                    Select Case True
                        Case MonthCount = 0
                            RecordDatePoints.Add(Me.BorrowStartDate)
                            Dim SetDayNumber As Integer = IIf(Me.PayRateMoneyDayNumber > ThisMonthMaxDayNumber, ThisMonthMaxDayNumber, Me.PayRateMoneyDayNumber)
                            If Me.BorrowStartDate.Day < SetDayNumber Then
                                RecordDatePoints.Add(New DateTime(SetYear, SetMonth, SetDayNumber))
                            End If
                        Case MonthCount = ToMonthCount
                            If Me.PayRateMoneyDayNumber < FinalBorrowENDDate.Day Then
                                RecordDatePoints.Add(New DateTime(FinalBorrowENDDate.Year, FinalBorrowENDDate.Month, Me.PayRateMoneyDayNumber))
                            End If
                            RecordDatePoints.Add(FinalBorrowENDDate)
                        Case Else
                            Dim SetDayNumber As Integer = IIf(Me.PayRateMoneyDayNumber > ThisMonthMaxDayNumber, ThisMonthMaxDayNumber, Me.PayRateMoneyDayNumber)
                            RecordDatePoints.Add(New DateTime(SetYear, SetMonth, SetDayNumber))
                    End Select
                Next

                Dim PreRecordDatePoint As Nullable(Of DateTime) = Nothing
                For Each EachItem As DateTime In RecordDatePoints
                    If IsNothing(PreRecordDatePoint) Then
                        PreRecordDatePoint = EachItem
                        Continue For
                    End If
                    Dim IsLastPoint As Boolean = (EachItem = RecordDatePoints.Last)
                    Dim SetRateType As PayRateMoneyDaySessionClass.RateTypeEnum = Nothing
                    Select Case Me.PayRateKind
                        Case 1  '月
                            SetRateType = PayRateMoneyDaySessionClass.RateTypeEnum.ByMonth
                        Case 2  '日(算頭不算尾)
                            SetRateType = PayRateMoneyDaySessionClass.RateTypeEnum.StartDateToBeforeEndDate
                        Case 3 And IsLastPoint = False  '日(頭尾都算)
                            SetRateType = PayRateMoneyDaySessionClass.RateTypeEnum.StartDateToBeforeEndDate
                        Case 3 And IsLastPoint = True   '日(頭尾都算)
                            SetRateType = PayRateMoneyDaySessionClass.RateTypeEnum.StartDateToEndDate
                    End Select
                    _PlanPayRateMoneyInformations.Add(New PayRateMoneyDaySessionClass(PreRecordDatePoint.Value.AddDays(1), EachItem, SetRateType, Me))
                    PreRecordDatePoint = EachItem
                Next
            End If

            Return _PlanPayRateMoneyInformations
        End Get
    End Property
#End Region
#Region "下次計劃付息資訊 屬性:NextTimePlanPayRateMoneyInformations"
    ''' <summary>
    ''' 下次計劃付息資訊
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NextTimePlanPayRateMoneyInformations() As List(Of PayRateMoneyDaySessionClass)
        Get
            If Me.FK_ContractKind = "S3" Then
                '此筆為LC開狀;回傳所有到單下次計劃付息資訊
                Dim AllValues As New List(Of PayRateMoneyDaySessionClass)
                For Each EachItem As BorrowLCBill In Me.About_BorrowLCBill
                    AllValues.AddRange(EachItem.NextTimePlanPayRateMoneyInformations)
                Next
                Dim FirstPayRateMoneyMoneyInformation As PayRateMoneyDaySessionClass = (From A In AllValues Select A Order By A.EndDate).FirstOrDefault
                Dim ReturnValue1 As List(Of PayRateMoneyDaySessionClass) = Nothing
                If Not IsNothing(FirstPayRateMoneyMoneyInformation) Then
                    Dim FirstPayRateMoneyDate As DateTime = FirstPayRateMoneyMoneyInformation.EndDate
                    ReturnValue1 = (From A In AllValues Where A.EndDate = FirstPayRateMoneyDate Select A).ToList
                End If
                Return ReturnValue1
            End If

            Dim LastPayMoneyRecord As BorrowPayMoney = (From A In DBDataContext.BorrowPayMoney Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.ID And A.PayRateMoney > 0 Select A Order By A.PayRateMoneyCritdialDate Descending).FirstOrDefault
            Dim AlreadyPayRateMoneyDaySessions As List(Of PayRateMoneyDaySessionClass) = Nothing
            If Not IsNothing(LastPayMoneyRecord) Then
                Dim CritdialDate As DateTime = LastPayMoneyRecord.PayRateMoneyCritdialDate
                AlreadyPayRateMoneyDaySessions = (From A In PlanPayRateMoneyInformations Where CritdialDate >= A.StartDate Or CritdialDate >= A.EndDate Select A).ToList
            End If
            Dim ReturnValue As New List(Of PayRateMoneyDaySessionClass)
            If Not IsNothing(AlreadyPayRateMoneyDaySessions) AndAlso AlreadyPayRateMoneyDaySessions.Count > 0 Then
                ReturnValue = (From A In PlanPayRateMoneyInformations Where Not AlreadyPayRateMoneyDaySessions.Contains(A) And (Now.Date >= A.EndDate Or (Now.Date <= A.EndDate And Now.Date >= A.StartDate)) Select A).ToList
            Else
                ReturnValue = (From A In PlanPayRateMoneyInformations Where (Now.Date >= A.EndDate Or (Now.Date <= A.EndDate And Now.Date >= A.StartDate)) Select A).ToList
            End If
            If IsNothing(ReturnValue) OrElse ReturnValue.Count = 0 Then
                '找不到現在時間點(含之前)還未付息的資訊,將加入下一次計劃付息資訊
                Dim AddItem As PayRateMoneyDaySessionClass = (From A In PlanPayRateMoneyInformations Where Now.Date < A.StartDate And Now.Date < A.EndDate Select A Order By A.StartDate).FirstOrDefault
                If Not IsNothing(AddItem) Then
                    ReturnValue.Add(AddItem)
                End If
            End If
            If IsNothing(ReturnValue) Then
                ReturnValue = New List(Of PayRateMoneyDaySessionClass)
            End If
            Return ReturnValue
        End Get
    End Property

#End Region
#Region "下次計劃付息金額 屬性:NextTimePlanPayRateMoney"
    ''' <summary>
    ''' 下次計劃付息金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NextTimePlanPayRateMoney() As Double
        Get
            Return (From a In NextTimePlanPayRateMoneyInformations Select a.RateMoney).Sum
        End Get
    End Property

#End Region
#Region "下次付息時間 屬性:NextTimePlanPayRateMoneyDate"
    ''' <summary>
    ''' 下次付息時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NextTimePlanPayRateMoneyDate() As DateTime
        Get
            Dim LastPlanPayRateMoneyInformation As PayRateMoneyDaySessionClass = (From A In NextTimePlanPayRateMoneyInformations Select A Order By A.EndDate Descending).FirstOrDefault
            If IsNothing(LastPlanPayRateMoneyInformation) Then
                Return Nothing
            End If
            Return LastPlanPayRateMoneyInformation.EndDate
        End Get
    End Property
#End Region

#Region "計劃償還本金資訊集合 屬性:PlanPayUseMoneyInformations"
    Private _PlanPayUseMoneyInformations As List(Of PayUseMoneyDaySessionClass)
    ''' <summary>
    ''' 計劃償還本金資訊集合
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PlanPayUseMoneyInformations() As List(Of PayUseMoneyDaySessionClass)
        Get
            If IsNothing(_PlanPayUseMoneyInformations) Then
                _PlanPayUseMoneyInformations = New List(Of PayUseMoneyDaySessionClass)
                If Me.RePaymentTimes <= 1 Then
                    _PlanPayUseMoneyInformations.Add(New PayUseMoneyDaySessionClass(Me.BorrowEndDate, Me.BorrowMoney, Me))
                    Return _PlanPayUseMoneyInformations '一次還本
                End If

                Dim TotalBorrowMonthCount As Integer = 0    '總借款月數
                Do While Format(Me.BorrowStartDate.AddMonths(TotalBorrowMonthCount), "yyyyMM") < Format(Me.BorrowEndDate, "yyyyMM")
                    TotalBorrowMonthCount += 1
                Loop
                Dim SetPayUseMoney As Double = Me.BorrowMoney / Me.RePaymentTimes
                Dim OneTimePayUseMoneyUseMonths As Integer = (TotalBorrowMonthCount - Me.LatePayMonths) \ Me.RePaymentTimes
                For PayMonthNumber As Integer = Me.LatePayMonths + OneTimePayUseMoneyUseMonths To TotalBorrowMonthCount Step OneTimePayUseMoneyUseMonths
                    Dim SetYear As Integer = Me.BorrowStartDate.AddMonths(PayMonthNumber).Year
                    Dim SetMonth As Integer = Me.BorrowStartDate.AddMonths(PayMonthNumber).Month
                    Dim ThisMonthMaxDayNumber = DateTime.DaysInMonth(SetYear, SetMonth)
                    Dim SetDayNumber As Integer = IIf(Me.PayPrincipalMoneyDayNumber > ThisMonthMaxDayNumber, ThisMonthMaxDayNumber, Me.PayPrincipalMoneyDayNumber)
                    Dim SetDateTime As New DateTime(SetYear, SetMonth, SetDayNumber)
                    _PlanPayUseMoneyInformations.Add(New PayUseMoneyDaySessionClass(SetDateTime, SetPayUseMoney, Me))
                Next
            End If
            Return _PlanPayUseMoneyInformations
        End Get
    End Property
#End Region
#Region "下次計劃償還本金資訊 屬性:NextTimePlanPayUseMoneyInformations"
    Private _NextTimePlanPayUseMoneyInformations As List(Of PayUseMoneyDaySessionClass)
    ''' <summary>
    ''' 下次計劃償還本金資訊
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NextTimePlanPayUseMoneyInformations() As List(Of PayUseMoneyDaySessionClass)
        Get
            If IsNothing(_NextTimePlanPayUseMoneyInformations) Then

                If Me.FK_ContractKind = "S3" Then
                    '此筆為LC開狀;回傳所有到單下次計劃償還本金資訊
                    Dim AllValues As New List(Of PayUseMoneyDaySessionClass)
                    For Each EachItem As BorrowLCBill In Me.About_BorrowLCBill
                        AllValues.AddRange(EachItem.NextTimePlanPayUseMoneyInformations)
                    Next
                    Dim FirstPayUseMoneyMoneyInformation As PayUseMoneyDaySessionClass = (From A In AllValues Select A Order By A.PayUseMoneyDate).FirstOrDefault
                    Dim ReturnValue1 As List(Of PayUseMoneyDaySessionClass) = Nothing
                    If Not IsNothing(FirstPayUseMoneyMoneyInformation) Then
                        Dim FirstPayRateMoneyDate As DateTime = FirstPayUseMoneyMoneyInformation.PayUseMoneyDate
                        ReturnValue1 = (From A In AllValues Where A.PayUseMoneyDate = FirstPayRateMoneyDate Select A).ToList
                    End If
                    Return ReturnValue1
                End If

                Dim BorrowPayMoneyRecords As List(Of BorrowPayMoney) = (From A In DBDataContext.BorrowPayMoney Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.ID And A.PayUseMoney > 0 Select A Order By A.PayMoneyDate Descending).ToList
                Dim TotalAlreadyPayMoney As Double = 0
                If BorrowPayMoneyRecords.Count > 0 Then
                    TotalAlreadyPayMoney = (From A In BorrowPayMoneyRecords Select A.PayUseMoney).Sum
                End If

                Dim WaillPayUseMoneyDaySessionClass As New List(Of PayUseMoneyDaySessionClass)
                For Each EachItem As PayUseMoneyDaySessionClass In PlanPayUseMoneyInformations
                    Select Case True
                        Case TotalAlreadyPayMoney = 0
                        Case TotalAlreadyPayMoney >= EachItem.PayUseMoney
                            TotalAlreadyPayMoney -= EachItem.PayUseMoney
                            EachItem.PayUseMoney = 0
                        Case TotalAlreadyPayMoney < EachItem.PayUseMoney
                            EachItem.PayUseMoney -= TotalAlreadyPayMoney
                            TotalAlreadyPayMoney = 0
                    End Select
                    If EachItem.PayUseMoney > 0 Then
                        WaillPayUseMoneyDaySessionClass.Add(EachItem)
                    End If
                Next

                Dim ReturnValue As List(Of PayUseMoneyDaySessionClass) = (From A In WaillPayUseMoneyDaySessionClass Where Now.Date >= A.PayUseMoneyDate Select A).ToList
                If ReturnValue.Count = 0 OrElse Now.Date <> (From A In ReturnValue Select A Order By A.PayUseMoneyDate Descending).First.PayUseMoneyDate Then
                    Dim NextItem As PayUseMoneyDaySessionClass = (From A In WaillPayUseMoneyDaySessionClass Where Now.Date < A.PayUseMoneyDate Select A).ToList.FirstOrDefault
                    If Not IsNothing(NextItem) Then
                        ReturnValue.Add(NextItem)
                    End If
                End If
                _NextTimePlanPayUseMoneyInformations = ReturnValue
            End If
            Return _NextTimePlanPayUseMoneyInformations
        End Get
    End Property
#End Region
#Region "下次計劃償還本金金額 屬性:NextTimePlanPayUseMoney"
    ''' <summary>
    ''' 下次計劃償還本金金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NextTimePlanPayUseMoney() As Double
        Get
            Return (From a In NextTimePlanPayUseMoneyInformations Select a.PayUseMoney).Sum
        End Get
    End Property

#End Region
#Region "下次償還本金時間 屬性:NextTimePlanPayUseMoneyDate"
    ''' <summary>
    ''' 下次償還本金時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NextTimePlanPayUseMoneyDate() As DateTime
        Get
            Dim LastPlanPayUseMoneyInformation As PayUseMoneyDaySessionClass = (From A In NextTimePlanPayUseMoneyInformations Select A Order By A.PayUseMoneyDate Descending).FirstOrDefault
            If IsNothing(LastPlanPayUseMoneyInformation) Then
                Return Nothing
            End If
            Return LastPlanPayUseMoneyInformation.PayUseMoneyDate
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
            If Me.About_BorrowContract.IsLCCreate Then
                Dim AboutBorrowLCBillPayMoneyItems As List(Of BorrowLCBillPayMoney) = (From A In DBDataContext.BorrowLCBillPayMoney Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.ID Select A).ToList
                Return (From B In AboutBorrowLCBillPayMoneyItems Select B.PayUseMoney).Sum
            End If
            Dim PayMoneyItems As List(Of BorrowPayMoney) = (From A In DBDataContext.BorrowPayMoney Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.ID Select A).ToList
            Return (From A In PayMoneyItems Select A.PayUseMoney).Sum
        End Get
    End Property
#End Region
#Region "等待償還本金金額 屬性:WaitPayUseMoney"
    ''' <summary>
    ''' 等待償還本金金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WaitPayUseMoney() As Double
        Get
            Return Me.BorrowMoney - Me.AlreadyPayUseMoney
        End Get
    End Property
#End Region

    '#Region "LC開狀不使用金額 屬性:LCCreateNoUseMoney"
    '    ''' <summary>
    '    ''' LC開狀不使用金額
    '    ''' </summary>
    '    ''' <value></value>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    ReadOnly Property LCCreateNoUseMoney() As Double
    '        Get
    '            If Not Me.About_BorrowContract.IsLCCreate Then
    '                Return 0
    '            End If
    '            Dim AboutBorrowLCBillPayMoneyItems As List(Of BorrowLCBillPayMoney) = (From A In DBDataContext.BorrowLCBillPayMoney Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.ID And A.IsNoPayMoneyAndUse = True Select A).ToList
    '            Return (From B In AboutBorrowLCBillPayMoneyItems Select B.PayUseMoney).Sum
    '        End Get
    '    End Property
    '#End Region



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
#Region "借款台幣 屬性:BorrowNTMoney"
    ''' <summary>
    ''' 借款台幣
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BorrowNTMoney() As Double
        Get
            If IsNothing(About_BorrowContract) AndAlso Not IsNothing(About_BorrowContract.NTExchangeRate) Then
                Return 0
            End If
            Return Me.BorrowMoney * ExchangeRate
        End Get
    End Property
#End Region
#Region "借款合約可動用額度 屬性:BorrowContract_CanUseMoney"
    ''' <summary>
    ''' 借款合約可動用額度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BorrowContract_CanUseMoney() As Double
        Get

            If IsNothing(About_BorrowContract) Then
                Return 0
            End If
            Return About_BorrowContract.CanUseMoney
        End Get
    End Property
#End Region
#Region "時間段落剩餘借款金額資料集 屬性:SessionDateSurplusBorrowMoneys"
    Private _SessionDateSurplusBorrowMoneys As List(Of SessionDateSurplusBorrowMoneyClass)
    ''' <summary>
    ''' 時間段落剩餘借款金額資料集
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SessionDateSurplusBorrowMoneys() As List(Of SessionDateSurplusBorrowMoneyClass) Implements IBorrowDBObject.SessionDateSurplusBorrowMoneys
        Get
            If IsNothing(_SessionDateSurplusBorrowMoneys) Then
                _SessionDateSurplusBorrowMoneys = New List(Of SessionDateSurplusBorrowMoneyClass)
                Dim NowBorrowMoney As Double = Me.BorrowMoney
                If IsNothing(Me.About_BorrowPayMoney) OrElse Me.About_BorrowPayMoney.Count = 0 Then
                    _SessionDateSurplusBorrowMoneys.Add(New SessionDateSurplusBorrowMoneyClass(Me.BorrowStartDate, Me.BorrowEndDate, NowBorrowMoney))
                    Return _SessionDateSurplusBorrowMoneys
                End If
                Dim PreItemDate As Nullable(Of DateTime) = Nothing
                '找尋所有時間段落剩餘借款金額
                Dim TempDatas As New List(Of SessionDateSurplusBorrowMoneyClass)
                Dim SumPayUseMoney As Double = 0
                For Each EachItem As Date In (From B In (From A In Me.About_BorrowPayMoney Select A.PayMoneyDate Distinct).ToList Select B Order By B).ToList
                    Dim EachItemValue As Date = EachItem
                    SumPayUseMoney = (From a In Me.About_BorrowPayMoney Where a.PayMoneyDate = EachItemValue Select a.PayUseMoney).Sum
                    If IsNothing(PreItemDate) Then
                        TempDatas.Add(New SessionDateSurplusBorrowMoneyClass(Me.BorrowStartDate, EachItemValue.AddDays(-1), NowBorrowMoney))
                    Else
                        TempDatas.Add(New SessionDateSurplusBorrowMoneyClass(PreItemDate, EachItemValue.AddDays(-1), NowBorrowMoney))
                    End If
                    NowBorrowMoney -= SumPayUseMoney
                    PreItemDate = EachItemValue
                Next
                If PreItemDate <> Me.BorrowEndDate Then
                    TempDatas.Add(New SessionDateSurplusBorrowMoneyClass(PreItemDate, Me.BorrowEndDate, NowBorrowMoney))
                End If
            End If
            Return _SessionDateSurplusBorrowMoneys
        End Get
        Private Set(ByVal value As List(Of SessionDateSurplusBorrowMoneyClass))
            _SessionDateSurplusBorrowMoneys = value
        End Set
    End Property
#End Region
#Region "取得某時間點剩餘借款金額 方法:GetOneTimeSurplusBorrowMoney"
    ''' <summary>
    ''' 取得某時間點剩餘借款金額
    ''' </summary>
    ''' <param name="SetTime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetOneTimeSurplusBorrowMoney(ByVal SetTime As Date) As Double Implements IBorrowDBObject.GetOneTimeSurplusBorrowMoney
        Dim FindSessionBorrowMoney As SessionDateSurplusBorrowMoneyClass = (From A In SessionDateSurplusBorrowMoneys Where SetTime >= A.StartDate And SetTime <= A.EndDate Select A).First
        If IsNothing(FindSessionBorrowMoney) Then
            Throw New Exception("系統發生錯誤,找不到取得某時間點剩餘借款金額!")
        End If
        Return FindSessionBorrowMoney.SurplusBorrowMoney
    End Function
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
#Region "相關LC到單 屬性:About_BorrowLCBill"
    Private _About_BorrowLCBill As List(Of BorrowLCBill) = Nothing
    ''' <summary>
    ''' 相關LC到單
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property About_BorrowLCBill() As List(Of BorrowLCBill)
        Get
            If Me.About_BorrowContract.IsLCCreate = False Then
                Return Nothing
            End If
            If IsNothing(_About_BorrowLCBill) Then
                _About_BorrowLCBill = (From A In DBDataContext.BorrowLCBill Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.ID Select A).ToList
            End If
            Return _About_BorrowLCBill
        End Get

    End Property
#End Region
#Region "相關LC還款 屬性:About_BorrowLCBillPayMoney"
    Private _About_BorrowLCBillPayMoney As List(Of BorrowLCBillPayMoney)
    ''' <summary>
    ''' 相關LC還款
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property About_BorrowLCBillPayMoney() As List(Of BorrowLCBillPayMoney)
        Get
            If IsNothing(_About_BorrowLCBillPayMoney) Then
                _About_BorrowLCBillPayMoney = (From A In DBDataContext.BorrowLCBillPayMoney Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.ID Select A).ToList
            End If
            Return _About_BorrowLCBillPayMoney
        End Get
    End Property
#End Region
#Region "相關還款記錄 屬性:About_BorrowPayMoney"
    Private _About_BorrowPayMoney As List(Of BorrowPayMoney)
    ''' <summary>
    ''' 相關還款記錄
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property About_BorrowPayMoney() As List(Of BorrowPayMoney)
        Get
            If IsNothing(_About_BorrowPayMoney) Then
                _About_BorrowPayMoney = (From a In DBDataContext.BorrowPayMoney Where a.FK_BankNumber = Me.FK_BankNumber And a.FK_ContractKind = Me.FK_ContractKind And a.FK_StartDate = Me.FK_StartDate And a.FK_BorrowID = Me.ID Select a Order By a.PayMoneyDate).ToList
            End If
            Return _About_BorrowPayMoney
        End Get
    End Property
#End Region
#Region "相關還款記錄 方法:IAbout_BorrowPayMoney"
    ''' <summary>
    ''' 相關還款記錄
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IAbout_BorrowPayMoney() As System.Collections.Generic.List(Of IBorrowPayMoneyDBObject) Implements IBorrowDBObject.About_BorrowPayMoney
        Get
            Dim ReturnValue As New List(Of IBorrowPayMoneyDBObject)
            ReturnValue.AddRange(Me.About_BorrowPayMoney)
            Return ReturnValue
        End Get
    End Property

#End Region


    '以下為列表時使用
#Region "建立報表時取得欄位結構 方法:GetReportFieldTemp"
    ''' <summary>
    ''' 建立報表時取得欄位結構
    ''' </summary>
    ''' <param name="FilderAndOrdersContractType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetReportFieldTemp(ByVal FilderAndOrdersContractType As List(Of String)) As List(Of Borrow)
        Return New List(Of Borrow)
    End Function
#End Region


#Region "合約台幣額度金額 屬性:BorrowContractCreditMoneyForNT"
    ''' <summary>
    ''' 合約台幣額度金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BorrowContractCreditMoneyForNT() As Double
        Get
            Return Me.About_BorrowContract.NTCreditMoney
        End Get
    End Property
#End Region
#Region "下次還款台幣本金金額 屬性:NextTimeNTPayUseMoney"
    ''' <summary>
    ''' 下次還款台幣本金金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NextTimeNTPayUseMoney() As Double
        Get
            If IsForeignMoneyKind Then
                Return Me.NextTimePlanPayUseMoney * Me.ExchangeRate
            End If
            Return Me.NextTimePlanPayUseMoney
        End Get
    End Property
#End Region
#Region "償還辦法 屬性:ContractDescription1"
    ''' <summary>
    ''' 償還辦法
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ContractDescription1() As String
        Get
            Dim ReturnValue As String = Nothing

            ReturnValue &= Format(Me.About_BorrowContract.RepaymentMonths / 12, "#.#") & " 年期 " & Me.About_BorrowContract.ContractKindName
            ReturnValue &= vbNewLine & Format(Me.BorrowStartDate, "yyyy/MM/dd") & " 首次動撥"
            If Me.RePaymentTimes > 1 Then
                ReturnValue &= vbNewLine & "寬緩" & Format(Me.LatePayMonths / 12, "#.#") & " 年,分" & Me.RePaymentTimes & "期還清!"
            Else
                ReturnValue &= vbNewLine & "到期一次還清!"
            End If
            Return ReturnValue
        End Get
    End Property
#End Region
#Region "契約期間 屬性:BorrowSessionDate"
    ''' <summary>
    ''' 契約期間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BorrowSessionDate() As String
        Get
            Return Format(BorrowStartDate, "yyyy/MM/dd") & "~" & Format(BorrowEndDate, "yyyy/MM/dd")
        End Get
    End Property
#End Region

End Class

#Region "付息期間類別 屬性:PayRateMoneyDaySessionClass"
''' <summary>
''' 付息期間類別
''' </summary>
''' <remarks></remarks>
Public Class PayRateMoneyDaySessionClass

    Public Sub New(ByVal SetStartDate As DateTime, ByVal SetEndDate As DateTime, ByVal SetPayRateKind As RateTypeEnum, ByVal SetSourceBorrowDBObject As IBorrowDBObject)
        Me.StartDate = SetStartDate
        Me.EndDate = SetEndDate
        Me.BorrowMoney = SetSourceBorrowDBObject.BorrowMoney
        Me.Rate = SetSourceBorrowDBObject.BorrowRate ' SetRate
        Me.UseRateType = SetPayRateKind
        Me.SourceBorrowDBObject = SetSourceBorrowDBObject
        'Select Case SetSourceBorrowDBObject.PayRateKind
        '    Case 1  '月
        '        Me.UseRateType = RateTypeEnum.ByMonth
        '    Case 2  '日(算頭不算尾)
        '        Me.UseRateType = RateTypeEnum.StartDateToBeforeEndDate
        '    Case 3  '日(頭尾都算)
        '        Me.UseRateType = RateTypeEnum.StartDateToEndDate
        '    Case Else
        '        Throw New Exception("無法決定計息方法")
        'End Select
    End Sub

#Region "借款資料物件 屬性:SourceBorrowDBObject"

    Private _SourceBorrowDBObject As IBorrowDBObject
    ''' <summary>
    ''' 借款資料物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceBorrowDBObject() As IBorrowDBObject
        Get
            Return _SourceBorrowDBObject
        End Get
        Private Set(ByVal value As IBorrowDBObject)
            _SourceBorrowDBObject = value
        End Set
    End Property

#End Region
#Region "起始時間 屬性:StartDate"

    Private _StartDate As DateTime
    ''' <summary>
    ''' 起始時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StartDate() As DateTime
        Get
            Return _StartDate
        End Get
        Set(ByVal value As DateTime)
            _StartDate = value
        End Set
    End Property

#End Region
#Region "終止時間 屬性:EndDate"

    Private _EndDate As DateTime
    ''' <summary>
    ''' 終止時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EndDate() As DateTime
        Get
            Return _EndDate
        End Get
        Set(ByVal value As DateTime)
            _EndDate = value
        End Set
    End Property

#End Region
#Region "找尋指定時間內所有時間段落剩餘借款金額 屬性:FindSessionDateBorrowMoneys"
    ''' <summary>
    ''' 找尋指定時間內所有時間段落剩餘借款金額
    ''' </summary>
    ''' <param name="SessionStartDate"></param>
    ''' <param name="SessionEndDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FindSessionDateBorrowMoneys(ByVal SessionStartDate As Date, ByVal SessionEndDate As Date) As List(Of SessionDateSurplusBorrowMoneyClass)
        Dim ReturnValue As New List(Of SessionDateSurplusBorrowMoneyClass)
        '找尋所有時間段落剩餘借款金額
        Dim AllSessionDateSurplusBorrowMoneys As List(Of SessionDateSurplusBorrowMoneyClass) = Me.SourceBorrowDBObject.SessionDateSurplusBorrowMoneys

        '找尋付息起始時間時所用的時間段落借款金額
        Dim StartItem As SessionDateSurplusBorrowMoneyClass = (From A In AllSessionDateSurplusBorrowMoneys Where SessionStartDate >= A.StartDate Select A Order By A.StartDate Descending).FirstOrDefault
        '找尋付息終止時間時所用的時間段落借款金額
        Dim EndItem As SessionDateSurplusBorrowMoneyClass = (From A In AllSessionDateSurplusBorrowMoneys Where SessionEndDate >= A.StartDate Select A Order By A.StartDate Descending).FirstOrDefault
        If StartItem Is EndItem Then
            ReturnValue.Add(New SessionDateSurplusBorrowMoneyClass(SessionStartDate, SessionEndDate, StartItem.SurplusBorrowMoney))
        Else
            Dim IsInnerStartTOEnd As Boolean = False
            For Each EachItem As SessionDateSurplusBorrowMoneyClass In (From A In AllSessionDateSurplusBorrowMoneys Select A Order By A.StartDate).ToList
                Dim SetStarDate As DateTime = EachItem.StartDate
                Dim SetEndDate As DateTime = EachItem.EndDate
                Select Case True
                    Case EachItem Is StartItem Or EachItem Is EndItem
                        SetStarDate = IIf(SetStarDate < SessionStartDate, SessionStartDate, SetStarDate)
                        SetEndDate = IIf(SetEndDate > SessionEndDate, SessionEndDate, SetEndDate)
                        ReturnValue.Add(New SessionDateSurplusBorrowMoneyClass(SetStarDate, SetEndDate, EachItem.SurplusBorrowMoney))
                        IsInnerStartTOEnd = (EachItem Is StartItem) Or (Not EachItem Is EndItem)
                    Case IsInnerStartTOEnd
                        SetStarDate = IIf(SetStarDate < SessionStartDate, SessionStartDate, SetStarDate)
                        SetEndDate = IIf(SetEndDate > SessionEndDate, SessionEndDate, SetEndDate)
                        ReturnValue.Add(New SessionDateSurplusBorrowMoneyClass(SetStarDate, SetEndDate, EachItem.SurplusBorrowMoney))
                    Case Else

                End Select
            Next
        End If
        Return ReturnValue
    End Function
#End Region
#Region "借款金額 屬性:BorrowMoney"
    Private _BorrowMoney As Double
    ''' <summary>
    ''' 借款金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BorrowMoney() As Double
        Get
            Return _BorrowMoney
        End Get
        Private Set(ByVal value As Double)
            _BorrowMoney = value
        End Set
    End Property

#End Region
#Region "利率 屬性:Rate"

    Private _Rate As Single
    ''' <summary>
    ''' 利率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Rate() As Single
        Get
            Return _Rate
        End Get
        Set(ByVal value As Single)
            _Rate = value
        End Set
    End Property

#End Region
#Region "計息方式 屬性:UseRateType"

    Private _UseRateType As RateTypeEnum
    ''' <summary>
    ''' 計息方式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UseRateType() As RateTypeEnum
        Get
            Return _UseRateType
        End Get
        Set(ByVal value As RateTypeEnum)
            _UseRateType = value
        End Set
    End Property

#End Region
#Region "計息天數 屬性:PayRateMoneyDayCout"
    ''' <summary>
    ''' 計息天數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PayRateMoneyDayCout() As Integer
        Get
            Dim ReturnValue As Integer = Me.EndDate.Subtract(Me.StartDate).Days
            If Me.UseRateType = RateTypeEnum.StartDateToEndDate Then
                ReturnValue += 1
            End If
            Return ReturnValue
        End Get
    End Property
#End Region
#Region "利息金 屬性:RateMoney"
    ''' <summary>
    ''' 利息金
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property RateMoney() As Double
        Get
            Dim ReturnValue As Double
            Select Case True
                Case Me.UseRateType = RateTypeEnum.StartDateToBeforeEndDate Or Me.UseRateType = RateTypeEnum.StartDateToEndDate
                    '原公式:ReturnValue = Me.BorrowMoney * Me.Rate * Me.PayRateMoneyDayCout / 365
                    '新公式依原本情況計算利率
                    For Each EachItem As SessionDateSurplusBorrowMoneyClass In FindSessionDateBorrowMoneys(Me.StartDate, Me.StartDate.AddDays(Me.PayRateMoneyDayCout).Date)
                        ReturnValue += EachItem.SurplusBorrowMoney * Me.Rate * EachItem.SessionDayCount / 365
                    Next
                Case Me.UseRateType = RateTypeEnum.ByMonth
                    Dim ToMonthCount As Integer = 0
                    Do While Format(StartDate.AddMonths(ToMonthCount), "yyyyMM") <= Format(EndDate, "yyyyMM")
                        ToMonthCount += 1
                    Loop

                    For MonthCount As Integer = 0 To ToMonthCount
                        Dim ThisMonthTotalDayCount As Integer = DateTime.DaysInMonth(Me.StartDate.AddMonths(MonthCount).Year, Me.StartDate.AddMonths(MonthCount).Month)
                        Dim ThisMonthRateDayCount As Integer = 0
                        Select Case True
                            Case MonthCount = ToMonthCount And ToMonthCount = 0
                                '起始日與終止日無跨月計算天數
                                ThisMonthRateDayCount = Me.EndDate.Subtract(Me.StartDate).Days
                            Case MonthCount = 0 And ToMonthCount > 0
                                '終止日有跨月,計算起始日至月底天數
                                Dim ThisMonthEndDate As DateTime = (New DateTime(Me.StartDate.Year, Me.StartDate.Month, 1)).AddMonths(MonthCount + 1).AddDays(-1)
                                ThisMonthRateDayCount = ThisMonthEndDate.Subtract(Me.StartDate).Days
                            Case MonthCount = ToMonthCount And ToMonthCount > 0
                                '終止日有跨月,計算1號至終止日天數
                                ThisMonthRateDayCount = Me.EndDate.Subtract(New DateTime(Me.EndDate.Year, Me.EndDate.Month, 1)).Days
                            Case ToMonthCount > 0
                                '終止日有跨月,起始或終止日均未落在該月,計算該月份天數
                                ThisMonthRateDayCount = ThisMonthTotalDayCount
                        End Select
                        '原公式:ReturnValue += Me.BorrowMoney * Me.Rate * (ThisMonthRateDayCount / ThisMonthTotalDayCount) / 12
                        '新公式依原本情況計算利率
                        For Each EachItem As SessionDateSurplusBorrowMoneyClass In FindSessionDateBorrowMoneys(Me.StartDate.AddMonths(MonthCount).Date, Me.StartDate.AddMonths(MonthCount).AddDays(ThisMonthRateDayCount).Date)
                            ReturnValue += EachItem.SurplusBorrowMoney * Me.Rate * (EachItem.SessionDayCount / ThisMonthTotalDayCount) / 12
                        Next
                    Next
            End Select
            Return ReturnValue
        End Get
    End Property
#End Region
#Region "是否過期 屬性:IsOverDue"
    ''' <summary>
    ''' 是否過期
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsOverDue() As Boolean
        Get
            Return Now.Date > Me.EndDate.Date
        End Get
    End Property
#End Region
#Region "計息方法列舉 列舉:RateTypeEnum"
    ''' <summary>
    ''' 計息方法列舉
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum RateTypeEnum
        StartDateToBeforeEndDate = 0    '算頭不算尾
        StartDateToEndDate = 1          '頭尾都算
        ByMonth = 3                     '以月計息
    End Enum
#End Region

End Class

#End Region
#Region "償還本金期間類別 屬性:PayUseMoneyDaySessionClass"
''' <summary>
''' 償還本金期間類別
''' </summary>
''' <remarks></remarks>
Public Class PayUseMoneyDaySessionClass


    Public Sub New(ByVal SetPayUseMoneyDate As DateTime, ByVal SetPayUseMoney As Double, ByVal SetSourceBorrowDBObject As IBorrowDBObject)
        Me.PayUseMoneyDate = SetPayUseMoneyDate
        Me.PayUseMoney = SetPayUseMoney
        Me.SourceBorrowDBObject = SetSourceBorrowDBObject
    End Sub

#Region "借款資料物件 屬性:SourceBorrowDBObject"

    Private _SourceBorrowDBObject As IBorrowDBObject
    ''' <summary>
    ''' 借款資料物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceBorrowDBObject() As IBorrowDBObject
        Get
            Return _SourceBorrowDBObject
        End Get
        Private Set(ByVal value As IBorrowDBObject)
            _SourceBorrowDBObject = value
        End Set
    End Property

#End Region
#Region "還本時間 屬性:PayUseMoneyDate"

    Private _PayUseMoneyDate As DateTime
    ''' <summary>
    ''' 還本時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PayUseMoneyDate() As DateTime
        Get
            Return _PayUseMoneyDate
        End Get
        Set(ByVal value As DateTime)
            _PayUseMoneyDate = value
        End Set
    End Property

#End Region
#Region "還款金額 屬性:PayUseMoney"

    Private _PayUseMoney As Double
    ''' <summary>
    ''' 還款金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PayUseMoney() As Double
        Get
            Return _PayUseMoney
        End Get
        Set(ByVal value As Double)
            _PayUseMoney = value
        End Set
    End Property

#End Region
#Region "是否過期 屬性:IsOverDue"
    ''' <summary>
    ''' 是否過期
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsOverDue() As Boolean
        Get
            Return Now.Date > Me.PayUseMoneyDate
        End Get
    End Property
#End Region
#Region "剩餘借款金額 屬性:SurplusBorrowMoney"
    ''' <summary>
    ''' 剩餘借款金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SurplusBorrowMoney() As Double
        Get
            Return SourceBorrowDBObject.GetOneTimeSurplusBorrowMoney(PayUseMoneyDate)
        End Get
    End Property
#End Region



End Class
#End Region
#Region "SessionDateSurplusBorrowMoneyClass"
''' <summary>
''' 一時間內之剩餘借款金額類別
''' </summary>
''' <remarks></remarks>
Public Class SessionDateSurplusBorrowMoneyClass

    Sub New(ByVal SetStartDate As Date, ByVal SetEndDate As Date, ByVal SetSurplusBorrowMoney As Double)
        Me.StartDate = SetStartDate
        Me.EndDate = SetEndDate
        Me.SurplusBorrowMoney = SetSurplusBorrowMoney
    End Sub

#Region "起始時間 屬性:StartDate"

    Private _StartDate As Date
    ''' <summary>
    ''' 起始時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StartDate() As Date
        Get
            Return _StartDate
        End Get
        Set(ByVal value As Date)
            _StartDate = value
        End Set
    End Property

#End Region
#Region "終止時間 屬性:EndDate"

    Private _EndDate As Date
    ''' <summary>
    ''' 終止時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EndDate() As Date
        Get
            Return _EndDate
        End Get
        Set(ByVal value As Date)
            _EndDate = value
        End Set
    End Property

#End Region
#Region "剩餘借款金額 屬性:SurplusBorrowMoney"

    Private _SurplusBorrowMoney As Double
    ''' <summary>
    ''' 剩餘借款金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SurplusBorrowMoney() As Double
        Get
            Return _SurplusBorrowMoney
        End Get
        Set(ByVal value As Double)
            _SurplusBorrowMoney = value
        End Set
    End Property

#End Region
#Region "起訖時間天數(頭尾都算) 屬性:SessionDayCount"
    ''' <summary>
    ''' 起訖時間天數(頭尾都算)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SessionDayCount() As Integer
        Get
            Return Me.EndDate.Subtract(Me.StartDate).Days + 1
        End Get
    End Property
#End Region


End Class
#End Region