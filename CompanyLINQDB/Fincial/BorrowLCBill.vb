Partial Public Class BorrowLCBill
    Implements IBorrowDBObject

    Dim DBDataContext As New FincialDataContext

#Region "取得下一個可用編號ID 方法:GetNextCanUseID"
    ''' <summary>
    ''' 取得下一個可用編號ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetNextCanUseID() As Integer
        Return PublicModule1.GetNextNumber((From A In DBDataContext.BorrowLCBill Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.FK_BorrowID Select A.ID).ToList)
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
    Public Shared Function GetCheckDataError(ByVal SourceData As BorrowLCBill, Optional ByVal CheckMode As CheckDataErrorMode = CheckDataErrorMode.InsertMode) As String
        Dim ReturnValue As String = Nothing
        Dim DBDataContext0 As New FincialDataContext
        Dim BorrowLCBillPayMoneyDataCount As Integer = 0
        BorrowLCBillPayMoneyDataCount = (From A In DBDataContext0.BorrowLCBillPayMoney Where A.FK_BankNumber = SourceData.FK_BankNumber And A.FK_ContractKind = SourceData.FK_ContractKind And A.FK_StartDate = SourceData.FK_StartDate And A.FK_BorrowID = SourceData.ID And A.FK_BorrowLCBillID = SourceData.ID Select A).Count
        If BorrowLCBillPayMoneyDataCount > 0 Then
            ReturnValue = "已有LC付款資料,無法刪除!"
        End If


        Dim DBDataContext1 As New FincialDataContext
        Dim EditModeOrginData As BorrowLCBill = Nothing
        EditModeOrginData = (From a In DBDataContext1.BorrowLCBill Where a.FK_BankNumber = SourceData.FK_BankNumber And a.FK_ContractKind = SourceData.FK_ContractKind And a.FK_StartDate = SourceData.FK_StartDate And a.FK_BorrowID = SourceData.FK_BorrowID Select a).FirstOrDefault

        Dim AboutBorrow As Borrow = SourceData.About_Borrow

        ' AboutBorrow.BorrowMoney
        Select Case True
            Case IsNothing(AboutBorrow)
                ReturnValue = "無法參考到LC開狀!"
                'Case CheckMode = CheckDataErrorMode.EditMode And IsNothing(EditModeOrginData)
                '    ReturnValue = "編輯資料核對模式下找不到原始資料(可能已被其它使用者刪除)作核對,請重新查詢後再編修!!"
                'Case CheckMode = CheckDataErrorMode.EditMode AndAlso AboutBorrowContract.CanUseMoney + EditModeOrginData.BorrowMoney < SourceData.BorrowMoney
                '    ReturnValue = "合約可使用金額不可大於 $" & AboutBorrowContract.CanUseMoney + EditModeOrginData.BorrowMoney
                'Case CheckMode = CheckDataErrorMode.InsertMode AndAlso AboutBorrowContract.CanUseMoney <= 0
                '    ReturnValue = "合約可使用金額目前已為0!"
                'Case SourceData.BorrowMoney <= 0
                '    ReturnValue = "借款金額不可小於0!"
                'Case AboutBorrowContract.IsLCCreate AndAlso String.IsNullOrEmpty(SourceData.LCNumber)
                '    ReturnValue = "LCNumber不可為空白!"
                'Case AboutBorrowContract.IsLCCreate AndAlso String.IsNullOrEmpty(SourceData.LCCaseNumber)
                '    ReturnValue = "LC案號不可為空白!"
                'Case SourceData.ExchangeRate <= 0
                '    ReturnValue = "匯率不可小於等於零!"
                'Case String.IsNullOrEmpty(SourceData.BorrowStartDate) OrElse String.IsNullOrEmpty(SourceData.BorrowEndDate)
                '    ReturnValue = "借款啟始及終止日期不可為空白!"
                'Case SourceData.BorrowEndDate < SourceData.BorrowStartDate
                '    ReturnValue = "借款終止日必須大於借款啟始日!"
                'Case SourceData.PayPrincipalMoneyDayNumber < 1 OrElse SourceData.PayPrincipalMoneyDayNumber > 31
                '    ReturnValue = "還本日不正確(範圍:1~31)!"
                'Case SourceData.PayRateMoneyDayNumber < 1 OrElse SourceData.PayRateMoneyDayNumber > 31
                '    ReturnValue = "付息日不正確(範圍:1~31)!"
                'Case SourceData.RePaymentTimes < 1 AndAlso SourceData.PayRateKind <> 4
                '    ReturnValue = "還款期數最少必須1期!"
                'Case SourceData.RePaymentTimes <> 1 AndAlso SourceData.PayRateKind = 5
                '    ReturnValue = "到期時付息還款期數必須為1期!"
                'Case SourceData.LatePayMonths < 0
                '    ReturnValue = "寬緩月數必須大於等於零!"
                'Case SourceData.BorrowStartDate.AddMonths(AboutBorrowContract.RepaymentMonths) > SourceData.BorrowEndDate
                '    ReturnValue = "借款終止日必須小於或等於 借款起始日+合約還款期限(月數) !"
                'Case SourceData.BorrowStartDate.AddMonths(SourceData.LatePayMonths).AddMonths(SourceData.RePaymentTimes) > SourceData.BorrowEndDate
                '    ReturnValue = "借款起始日+寬緩月數+還款期數 必須小於或等於借款終止日!"
                'Case (SourceData.PayRateKind = 1 Or SourceData.PayRateKind = 2 Or SourceData.PayRateKind = 3) And (RepaymentMoneyMonthCount Mod SourceData.RePaymentTimes <> 0)
                '    ReturnValue = "還款月數:" & RepaymentMoneyMonthCount & " 無法被還款期數:" & SourceData.RePaymentTimes & "整除"
                'Case SourceData.PayRateKind = 4 And SourceData.PayRateMoney <= 0
                '    ReturnValue = "借款時付息,付息金額必須大於0"
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
            Return Me.UseMoney
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
            Return Me.About_Borrow.PayRateKind
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
            Return BillRate
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
            Return Me.BillStartDate
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
            Return Me.BillEndDate
        End Get
    End Property
#End Region
#Region "已押匯金額 屬性:AlreadyUseLCMoney"
    ''' <summary>
    ''' 已押匯金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AlreadyUseLCBorrowMoney() As Double
        Get
            If IsNothing(Me.About_Borrow) Then
                Return Nothing
            End If
            Return Me.About_Borrow.AlreadyUseLCBorrowMoney
        End Get
    End Property
#End Region
#Region "可押匯金額 屬性:CanUseLCMoney"
    ''' <summary>
    ''' 可押匯金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CanUseLCBorrowMoney() As Double
        Get
            If IsNothing(Me.About_Borrow) Then
                Return Nothing
            End If

            Return Me.About_Borrow.BorrowMoney - AlreadyUseLCBorrowMoney
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
                Return Me.BillEndDate
            End If
            Dim LastPayUseMoneyRecord As BorrowLCBillPayMoney = (From a In Me.About_BorrowLCBillPayMoney Select a Order By a.PayMoneyDate Descending).FirstOrDefault
            If IsNothing(LastPayUseMoneyRecord) Then
                Return Me.BillEndDate
            End If
            Return LastPayUseMoneyRecord.PayMoneyDate
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
            'If Me.About_BorrowContract.IsLCCreate Then
            '    Dim AboutBorrowLCBillPayMoneyItems As List(Of BorrowLCBillPayMoney) = (From A In DBDataContext.BorrowLCBillPayMoney Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.ID Select A).ToList
            '    Return (From B In AboutBorrowLCBillPayMoneyItems Select B.PayUseMoney).Sum
            'End If
            'Dim PayMoneyItems As List(Of BorrowPayMoney) = (From A In DBDataContext.BorrowPayMoney Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.ID Select A).ToList
            'Return (From A In PayMoneyItems Select A.PayUseMoney).Sum
            Return (From A In Me.About_BorrowLCBillPayMoney Select A.PayUseMoney).Sum
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
            Return Me.UseMoney - Me.AlreadyPayUseMoney
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
                If Me.BillStartDate > Me.BillEndDate OrElse Me.About_Borrow.PayRateKind = 4 Then
                    Return _PlanPayRateMoneyInformations
                End If
                Dim FinalBorrowENDDate As DateTime = IIf(Me.LastPayUseMoneyDate < Me.BillEndDate, Me.LastPayUseMoneyDate, Me.BillEndDate)
                If Me.About_Borrow.PayRateKind = 5 Then '到期一次付息
                    _PlanPayRateMoneyInformations.Add(New PayRateMoneyDaySessionClass(Me.BillStartDate, FinalBorrowENDDate, PayRateMoneyDaySessionClass.RateTypeEnum.StartDateToBeforeEndDate, Me))
                    Return _PlanPayRateMoneyInformations
                End If

                Dim ToMonthCount As Integer = 0
                Do While Format(Me.BillStartDate.AddMonths(ToMonthCount), "yyyyMM") <= Format(FinalBorrowENDDate, "yyyyMM")
                    ToMonthCount += 1
                Loop

                Dim RecordDatePoints As New List(Of DateTime)
                For MonthCount As Integer = 0 To ToMonthCount
                    Dim SetYear As Integer = Me.BillStartDate.AddMonths(MonthCount).Year
                    Dim SetMonth As Integer = Me.BillStartDate.AddMonths(MonthCount).Month
                    Dim ThisMonthMaxDayNumber = DateTime.DaysInMonth(SetYear, SetMonth)
                    Select Case True
                        Case MonthCount = 0
                            RecordDatePoints.Add(Me.BillStartDate)
                            Dim SetDayNumber As Integer = IIf(Me.About_Borrow.PayRateMoneyDayNumber > ThisMonthMaxDayNumber, ThisMonthMaxDayNumber, Me.About_Borrow.PayRateMoneyDayNumber)
                            If Me.BillStartDate.Day < SetDayNumber Then
                                RecordDatePoints.Add(New DateTime(SetYear, SetMonth, SetDayNumber))
                            End If
                        Case MonthCount = ToMonthCount
                            If Me.About_Borrow.PayRateMoneyDayNumber < FinalBorrowENDDate.Day Then
                                RecordDatePoints.Add(New DateTime(FinalBorrowENDDate.Year, FinalBorrowENDDate.Month, Me.About_Borrow.PayRateMoneyDayNumber))
                            End If
                            RecordDatePoints.Add(FinalBorrowENDDate)
                        Case Else
                            Dim SetDayNumber As Integer = IIf(Me.About_Borrow.PayRateMoneyDayNumber > ThisMonthMaxDayNumber, ThisMonthMaxDayNumber, Me.About_Borrow.PayRateMoneyDayNumber)
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
                    Select Case Me.About_Borrow.PayRateKind
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
            Dim LastPayMoneyRecord As BorrowLCBillPayMoney = (From A In DBDataContext.BorrowLCBillPayMoney Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.FK_BorrowID And A.FK_BorrowLCBillID = Me.ID And A.PayRateMoney > 0 Select A Order By A.PayRateMoneyCritdialDate Descending).FirstOrDefault
            Dim AlreadyPayRateMoneyDaySessions As List(Of PayRateMoneyDaySessionClass) = Nothing
            If Not IsNothing(LastPayMoneyRecord) Then
                Dim CritdialDate As DateTime = LastPayMoneyRecord.PayRateMoneyCritdialDate
                AlreadyPayRateMoneyDaySessions = (From A In PlanPayRateMoneyInformations Where CritdialDate >= A.StartDate Or CritdialDate >= A.EndDate Select A).ToList
            End If
            Dim ReturnValue As List(Of PayRateMoneyDaySessionClass) = New List(Of PayRateMoneyDaySessionClass)
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
                If Me.About_Borrow.RePaymentTimes <= 1 Then
                    _PlanPayUseMoneyInformations.Add(New PayUseMoneyDaySessionClass(Me.BillEndDate, Me.UseMoney, Me))
                    Return _PlanPayUseMoneyInformations '一次還本
                End If

                Dim TotalBorrowMonthCount As Integer = 0    '總借款月數
                Do While Format(Me.BillStartDate.AddMonths(TotalBorrowMonthCount), "yyyyMM") < Format(Me.BillEndDate, "yyyyMM")
                    TotalBorrowMonthCount += 1
                Loop
                Dim SetPayUseMoney As Double = Me.UseMoney / Me.About_Borrow.RePaymentTimes
                Dim OneTimePayUseMoneyUseMonths As Integer = (TotalBorrowMonthCount - Me.About_Borrow.LatePayMonths) \ Me.About_Borrow.RePaymentTimes
                For PayMonthNumber As Integer = Me.About_Borrow.LatePayMonths + OneTimePayUseMoneyUseMonths To TotalBorrowMonthCount Step OneTimePayUseMoneyUseMonths
                    Dim SetYear As Integer = Me.BillStartDate.AddMonths(PayMonthNumber).Year
                    Dim SetMonth As Integer = Me.BillStartDate.AddMonths(PayMonthNumber).Month
                    Dim ThisMonthMaxDayNumber = DateTime.DaysInMonth(SetYear, SetMonth)
                    Dim SetDayNumber As Integer = IIf(Me.About_Borrow.PayPrincipalMoneyDayNumber > ThisMonthMaxDayNumber, ThisMonthMaxDayNumber, Me.About_Borrow.PayPrincipalMoneyDayNumber)
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
                Dim BorrowPayMoneyRecords As List(Of BorrowLCBillPayMoney) = (From A In DBDataContext.BorrowLCBillPayMoney Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.FK_BorrowID And A.FK_BorrowLCBillID = Me.ID And A.PayRateMoney > 0 Select A Order By A.PayMoneyDate Descending).ToList
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
                Dim NowBorrowMoney As Double = Me.UseMoney
                If IsNothing(Me.About_BorrowLCBillPayMoney) OrElse Me.About_BorrowLCBillPayMoney.Count = 0 Then
                    _SessionDateSurplusBorrowMoneys.Add(New SessionDateSurplusBorrowMoneyClass(Me.BillStartDate, Me.BillEndDate, NowBorrowMoney))
                    Return _SessionDateSurplusBorrowMoneys
                End If
                Dim PreItemDate As Nullable(Of DateTime) = Nothing
                '找尋所有時間段落剩餘借款金額
                Dim TempDatas As New List(Of SessionDateSurplusBorrowMoneyClass)
                Dim SumPayUseMoney As Double = 0
                For Each EachItem As Date In (From B In (From A In Me.About_BorrowLCBillPayMoney Select A.PayMoneyDate Distinct).ToList Select B Order By B).ToList
                    Dim EachItemValue As Date = EachItem
                    SumPayUseMoney = (From a In Me.About_BorrowLCBillPayMoney Where a.PayMoneyDate = EachItemValue Select a.PayUseMoney).Sum
                    If IsNothing(PreItemDate) Then
                        TempDatas.Add(New SessionDateSurplusBorrowMoneyClass(Me.BillStartDate, EachItemValue.AddDays(-1), NowBorrowMoney))
                    Else
                        TempDatas.Add(New SessionDateSurplusBorrowMoneyClass(PreItemDate, EachItemValue.AddDays(-1), NowBorrowMoney))
                    End If
                    NowBorrowMoney -= SumPayUseMoney
                    PreItemDate = EachItemValue
                Next
                If PreItemDate <> Me.BillEndDate Then
                    TempDatas.Add(New SessionDateSurplusBorrowMoneyClass(PreItemDate, Me.BillEndDate, NowBorrowMoney))
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
#Region "相關還款記錄  屬性:About_BorrowLCBillPayMoney"
    Private _About_BorrowLCBillPayMoney As List(Of BorrowLCBillPayMoney)
    ''' <summary>
    ''' 相關還款記錄
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property About_BorrowLCBillPayMoney() As List(Of BorrowLCBillPayMoney)
        Get
            If IsNothing(_About_BorrowLCBillPayMoney) Then
                _About_BorrowLCBillPayMoney = (From A In DBDataContext.BorrowLCBillPayMoney Where A.FK_BankNumber = Me.FK_BankNumber And A.FK_ContractKind = Me.FK_ContractKind And A.FK_StartDate = Me.FK_StartDate And A.FK_BorrowID = Me.FK_BorrowID And A.FK_BorrowLCBillID = Me.ID Select A Order By A.PayMoneyDate).ToList
            End If
            Return _About_BorrowLCBillPayMoney
        End Get
    End Property
#End Region
#Region "相關還款記錄  屬性:IAbout_BorrowLCBillPayMoney"
    ''' <summary>
    ''' 相關還款記錄
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IAbout_BorrowLCBillPayMoney() As List(Of IBorrowPayMoneyDBObject) Implements IBorrowDBObject.About_BorrowPayMoney
        Get
            Dim ReturnValue As New List(Of IBorrowPayMoneyDBObject)
            ReturnValue.AddRange(Me.About_BorrowLCBillPayMoney)
            Return ReturnValue
        End Get
    End Property
#End Region

End Class
