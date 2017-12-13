Namespace TESTKUKU
    ''' <summary>
    ''' 本月折舊主檔
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class AST901PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("TESTKUKU", GetType(AST901PF).Name)
        End Sub

#Region "CODE 屬性:CODE"
        Private _CODE As System.String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CODE() As System.String
            Get
                Return _CODE
            End Get
            Set(ByVal value As System.String)
                _CODE = value
            End Set
        End Property
#End Region
#Region "資產編號 屬性:NUMBER"
        Private _NUMBER As System.String
        ''' <summary>
        ''' 資產編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <CompanyORMDB.ORMBaseClass.SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property NUMBER() As System.String
            Get
                Return _NUMBER
            End Get
            Set(ByVal value As System.String)
                _NUMBER = value
            End Set
        End Property
#End Region
#Region "資產名稱 屬性:NAME"
        Private _NAME As System.String
        ''' <summary>
        ''' 資產名稱
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property NAME() As System.String
            Get
                Return _NAME
            End Get
            Set(ByVal value As System.String)
                _NAME = value
            End Set
        End Property
#End Region
#Region "單位 屬性:UNIT"
        Private _UNIT As System.String
        ''' <summary>
        ''' 單位
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UNIT() As System.String
            Get
                Return _UNIT
            End Get
            Set(ByVal value As System.String)
                _UNIT = value
            End Set
        End Property
#End Region
#Region "數量 屬性:QUANT"
        Private _QUANT As System.Int32
        ''' <summary>
        ''' 數量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QUANT() As System.Int32
            Get
                Return _QUANT
            End Get
            Set(ByVal value As System.Int32)
                _QUANT = value
            End Set
        End Property
#End Region
#Region "購入原始總價(=單價*數量) 屬性:AMOUNT"
        Private _AMOUNT As Double
        ''' <summary>
        ''' 購入原始總價(=單價*數量)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AMOUNT() As Double
            Get
                Return _AMOUNT
            End Get
            Set(ByVal value As Double)
                _AMOUNT = value
            End Set
        End Property
#End Region
#Region "購入日期 屬性:DATE"
        Private _DATE As System.Int32
        ''' <summary>
        ''' 購入日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property [DATE]() As System.Int32
            Get
                Return _DATE
            End Get
            Set(ByVal value As System.Int32)
                _DATE = value
            End Set
        End Property
#End Region
#Region "使用年限 屬性:USLAFF"
        Private _USLAFF As System.Int32
        ''' <summary>
        ''' 使用年限
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property USLAFF() As System.Int32
            Get
                Return _USLAFF
            End Get
            Set(ByVal value As System.Int32)
                _USLAFF = value
            End Set
        End Property
#End Region
#Region "部門單位 屬性:DEPT"
        Private _DEPT As System.String
        ''' <summary>
        ''' 部門單位
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <CompanyORMDB.ORMBaseClass.SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property DEPT() As System.String
            Get
                Return _DEPT
            End Get
            Set(ByVal value As System.String)
                _DEPT = value
            End Set
        End Property
#End Region
#Region "累計折舊 屬性:DEPR"
        Private _DEPR As System.Single
        ''' <summary>
        ''' 累計折舊
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEPR() As System.Single
            Get
                Return _DEPR
            End Get
            Set(ByVal value As System.Single)
                _DEPR = value
            End Set
        End Property
#End Region
#Region "REESTIMATE(無使用) 屬性:AMT"
        Private _AMT As System.Single
        ''' <summary>
        ''' REESTIMATE(無使用)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AMT() As System.Single
            Get
                Return _AMT
            End Get
            Set(ByVal value As System.Single)
                _AMT = value
            End Set
        End Property
#End Region
#Region "BMT(無使用) 屬性:BMT"
        Private _BMT As System.Single
        ''' <summary>
        ''' (無使用)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BMT() As System.Single
            Get
                Return _BMT
            End Get
            Set(ByVal value As System.Single)
                _BMT = value
            End Set
        End Property
#End Region
#Region "CMT(無使用) 屬性:CMT"
        Private _CMT As System.Single
        ''' <summary>
        ''' (無使用)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CMT() As System.Single
            Get
                Return _CMT
            End Get
            Set(ByVal value As System.Single)
                _CMT = value
            End Set
        End Property
#End Region
#Region "CDT(無使用) 屬性:CDT"
        Private _CDT As System.String
        ''' <summary>
        ''' (無使用)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CDT() As System.String
            Get
                Return _CDT
            End Get
            Set(ByVal value As System.String)
                _CDT = value
            End Set
        End Property
#End Region
#Region "ACD1(未知待查) 屬性:ACD1"
        Private _ACD1 As System.String
        ''' <summary>
        ''' (未知待查)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACD1() As System.String
            Get
                Return _ACD1
            End Get
            Set(ByVal value As System.String)
                _ACD1 = value
            End Set
        End Property
#End Region
#Region "ACD2 屬性:ACD2"
        Private _ACD2 As System.String
        ''' <summary>
        ''' ' ':正常 'A':閒置 'B':出租
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACD2() As System.String
            Get
                Return _ACD2
            End Get
            Set(ByVal value As System.String)
                _ACD2 = value
            End Set
        End Property
#End Region
#Region "ACD3 屬性:ACD3"
        Private _ACD3 As System.String
        ''' <summary>
        ''' '-':累計減損不提折舊
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACD3() As System.String
            Get
                Return _ACD3
            End Get
            Set(ByVal value As System.String)
                _ACD3 = value
            End Set
        End Property
#End Region
#Region "殘值金額 屬性:V7611"
        Private _V7611 As System.Single
        ''' <summary>
        ''' 殘值金額
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property V7611() As System.Single
            Get
                Return _V7611
            End Get
            Set(ByVal value As System.Single)
                _V7611 = value
            End Set
        End Property
#End Region
#Region "殘值重估使用年限 屬性:N7611"
        Private _N7611 As System.Int32
        ''' <summary>
        ''' 殘值重估使用年限
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property N7611() As System.Int32
            Get
                Return _N7611
            End Get
            Set(ByVal value As System.Int32)
                _N7611 = value
            End Set
        End Property
#End Region
#Region "環會科目 屬性:ACNO"
        Private _ACNO As String
        ''' <summary>
        ''' 環會科目
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACNO() As String
            Get
                Return _ACNO
            End Get
            Set(ByVal value As String)
                _ACNO = value
            End Set
        End Property

#End Region
#Region "移轉新資產編號 屬性:TransferNewNumber"
        Private _TransferNewNumber As String
        ''' <summary>
        ''' 移轉新資產編號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property TransferNewNumber() As String
            Get
                Return _TransferNewNumber
            End Get
            Set(ByVal value As String)
                _TransferNewNumber = value
            End Set
        End Property
#End Region
#Region "移轉資產數量 屬性:TransferCount"
        Private _TransferCount As Integer
        ''' <summary>
        ''' 移轉資產數量
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property TransferCount() As Integer
            Get
                Return _TransferCount
            End Get
            Set(ByVal value As Integer)
                _TransferCount = value
            End Set
        End Property

#End Region
#Region "移轉新使用單位 屬性:TransferNewDEPTSA"
        Private _TransferNewDEPTSA As String
        ''' <summary>
        ''' 移轉新使用單位
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property TransferNewDEPTSA() As String
            Get
                Return _TransferNewDEPTSA
            End Get
            Set(ByVal value As String)
                _TransferNewDEPTSA = value
            End Set
        End Property

#End Region
#Region "相關AST106PF_使用單位 屬性:AboutAST906PF_UseDept"
        Private _AboutAST906PF_UseDept As String
        ''' <summary>
        ''' 相關AST906PF_使用單位
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutAST906PF_UseDept() As String
            Get
                If IsNothing(_AboutAST906PF_UseDept) Then
                    Dim GetAboutAST906PF As AST906PF = AboutAST906PF
                    If Not IsNothing(GetAboutAST906PF) Then
                        _AboutAST906PF_UseDept = GetAboutAST906PF.DEPTSA
                    End If
                End If
                Return _AboutAST906PF_UseDept
            End Get
        End Property
#End Region

#Region "資產移轉錯誤訊息 屬性:AssetTransferErrorMsg"
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property AssetTransferErrorMsg As String
#End Region
#Region "資產移轉 方法:AssetTransfer"
        ''' <summary>
        ''' 資產移轉
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function AssetTransfer() As Integer
            AssetTransferErrorMsg = ""
            Dim GetAboutAST106PF As AST906PF = Me.AboutAST906PF
            If String.IsNullOrEmpty(TransferNewNumber) OrElse TransferCount <= 0 OrElse _
                String.IsNullOrEmpty(TransferNewDEPTSA) OrElse Me.DEPT <> "SA" OrElse _
                Me.AboutAST906PF_UseDept.Trim = Me.TransferNewDEPTSA.Trim OrElse _
                String.IsNullOrEmpty(AboutAST906PF_UseDept) OrElse IsNothing(GetAboutAST106PF) Then
                AssetTransferErrorMsg = "資料不完整!"
                Return 0
            End If
            Dim QryOldAssetString As String = "Select * from @#TESTKUKU.AST901PF.ASTFSA WHERE NUMBER='" & Me.NUMBER & "' AND DEPT='" & DEPT & "' "
            Dim OldAssetResult As List(Of AST901PF) = AST901PF.CDBSelect(Of AST901PF)(QryOldAssetString, Me.CDBCurrentUseSQLQueryAdapter)
            If OldAssetResult.Count <> 1 Then
                AssetTransferErrorMsg = "資料庫中找出" & OldAssetResult.Count & " 筆原資產編號,無法執行資產移轉作業!"
                Return 0
            End If
            Dim QryOldAssetDetpString As String = "Select * from @#TESTKUKU.AST906PF.ASTFSA WHERE NUMBER='" & Me.NUMBER & "' AND SEQ=1 "
            Dim OldAssetDetpResult As List(Of AST906PF) = AST906PF.CDBSelect(Of AST906PF)(QryOldAssetDetpString, Me.CDBCurrentUseSQLQueryAdapter)
            If OldAssetDetpResult.Count <> 1 Then
                AssetTransferErrorMsg = "資料庫中找出" & OldAssetDetpResult.Count & " 筆原資產使用單位,無法執行資產移轉作業!"
                Return 0
            End If
            If Me.NUMBER.Trim = Me.TransferNewNumber AndAlso Me.TransferCount >= Me.QUANT AndAlso Me.AboutAST906PF_UseDept <> Me.TransferNewDEPTSA Then
                '全部資產作單位移轉更換保管單位
                With GetAboutAST106PF
                    GetAboutAST106PF.DEPTSA = Me.TransferNewDEPTSA.ToUpper
                    GetAboutAST106PF.SQLQueryAdapterByThisObject = Me.CDBCurrentUseSQLQueryAdapter
                    Return .CDBSave
                End With
            End If
            Dim QryNewAssetString As String = "Select * from @#TESTKUKU.AST901PF.ASTFSA WHERE NUMBER='" & Me.TransferNewNumber & "' AND DEPT='" & DEPT & "' "
            Dim NewAssetResult As List(Of AST901PF) = AST901PF.CDBSelect(Of AST901PF)(QryNewAssetString, Me.CDBCurrentUseSQLQueryAdapter)
            If NewAssetResult.Count <> 0 Then
                AssetTransferErrorMsg = "資料庫中找出" & NewAssetResult.Count & " 筆新資產編號存在於資料庫中,無法執行資產移轉作業!"
                Return 0
            End If
            Dim QryNewAssetDetpString As String = "Select * from @#TESTKUKU.AST906PF.ASTFSA WHERE NUMBER='" & Me.TransferNewNumber & "' AND SEQ=1 "
            Dim NewAssetDetpResult As List(Of AST906PF) = AST906PF.CDBSelect(Of AST906PF)(QryNewAssetDetpString, Me.CDBCurrentUseSQLQueryAdapter)
            If NewAssetDetpResult.Count <> 0 Then
                AssetTransferErrorMsg = "資料庫中找出" & NewAssetDetpResult.Count & " 筆新資產使用單位存在於資料庫中,無法執行資產移轉作業!"
                Return 0
            End If
            Dim ReturnValue As Integer = 0
            Select Case True
                Case Me.NUMBER.Trim <> Me.TransferNewNumber AndAlso Me.TransferCount < Me.QUANT AndAlso Me.AboutAST906PF_UseDept <> Me.TransferNewDEPTSA AndAlso Me.TransferCount > 0
                    '部份資產作單位移轉
                    Dim ModValue As Double = 0
                    Dim UnitPrice As Double = 0
                    Dim NewAssetDBObject As AST901PF = Me.CDBClone
                    With NewAssetDBObject
                        .NUMBER = TransferNewNumber.ToUpper
                        .QUANT = TransferCount
                        If Me.AMOUNT > 0 Then
                            ModValue = Me.AMOUNT Mod Me.QUANT
                            UnitPrice = (Me.AMOUNT - ModValue) / QUANT
                            .AMOUNT = UnitPrice * TransferCount
                        End If
                        If Me.DEPR > 0 Then
                            ModValue = Me.DEPR Mod Me.QUANT
                            UnitPrice = (Me.DEPR - ModValue) / QUANT
                            .DEPR = UnitPrice * TransferCount
                        End If
                        If Me.V7611 > 0 Then
                            ModValue = Me.V7611 Mod Me.QUANT
                            UnitPrice = (Me.V7611 - ModValue) / QUANT
                            .V7611 = UnitPrice * TransferCount
                        End If
                        .SQLQueryAdapterByThisObject = Me.CDBCurrentUseSQLQueryAdapter
                        ReturnValue = .CDBSave
                    End With
                    If ReturnValue > 0 Then
                        Dim NewDeptDBObject As AST906PF = Me.AboutAST906PF.CDBClone
                        With NewDeptDBObject
                            .NUMBER = TransferNewNumber.ToUpper
                            .DEPTSA = TransferNewDEPTSA.ToUpper
                            .SQLQueryAdapterByThisObject = Me.CDBCurrentUseSQLQueryAdapter
                            If .CDBSave = 0 Then
                                NewAssetDBObject.CDBDelete()
                                AssetTransferErrorMsg = "資料分割失敗1-2"
                                Return 0
                            End If
                        End With
                        With OldAssetResult(0)
                            .AMOUNT -= NewAssetDBObject.AMOUNT
                            .DEPR -= NewAssetDBObject.DEPR
                            .V7611 -= NewAssetDBObject.V7611
                            .QUANT -= NewAssetDBObject.QUANT
                            If .CDBSave() = 0 Then
                                NewAssetDBObject.CDBDelete()
                                NewDeptDBObject.CDBDelete()
                            End If
                        End With
                    Else
                        AssetTransferErrorMsg = "資料分割失敗1-1"
                        Return 0
                    End If
                Case Else
                    AssetTransferErrorMsg = "資料有錯誤或不完整無法分割資料!"
                    Return 0
            End Select
            Return ReturnValue

        End Function
#End Region

#Region "報廢日期 屬性:JunkDate"
        Private _JunkDate As Date = Nothing
        Private IsAlreadyGetData As Boolean = False
        ''' <summary>
        ''' 報廢日期
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property JunkDate() As Date
            Get
                If IsAlreadyGetData = False Then
                    IsAlreadyGetData = True
                    Dim StartDate As Date = New AS400DateConverter(Me.DATE * 100 + 1).DateValue : StartDate = New Date(StartDate.Year, StartDate.Month, 1)
                    Dim EndDate As Date = StartDate.AddYears(Me.USLAFF).AddMonths(-1)
                    _JunkDate = EndDate
                    If Me.N7611 > 0 Then
                        Dim ExStartDate As Date = (New Date(EndDate.Year, EndDate.Month, Date.DaysInMonth(EndDate.Year, EndDate.Month))).AddDays(1)
                        Dim ExEndDate As Date = ExStartDate.AddYears(Me.N7611).AddMonths(-1)
                        _JunkDate = ExEndDate
                    End If
                End If
                Return _JunkDate
            End Get
        End Property
#End Region
#Region "相關AS906PF  屬性:AboutAST906PF"
        ''' <summary>
        ''' 相關AS106PF
        ''' </summary>
        ''' <remarks></remarks>
        Private _AboutAST906PF As AST906PF
        Private Shared _AboutAST906PFAll As List(Of AST906PF)
        Private Last_AboutAST906PFAccessTime As DateTime = Now.AddSeconds(-10)
        ''' <summary>
        ''' 相關AS106PF
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutAST906PF() As AST906PF
            Get
                If IsNothing(_AboutAST906PFAll) OrElse Now.Subtract(Last_AboutAST906PFAccessTime).TotalSeconds > 3 Then
                    _AboutAST906PFAll = CDBSelect(Of AST906PF)("Select * from " & Me.CDBFullAS400DBPath.ToUpper.Replace("AST901PF", "AST906PF"), Me.CDBCurrentUseSQLQueryAdapter)
                End If
                If IsNothing(_AboutAST906PF) OrElse Now.Subtract(Last_AboutAST906PFAccessTime).TotalSeconds > 3 Then
                    For Each EachItem As AST906PF In _AboutAST906PFAll
                        If EachItem.NUMBER = Me.NUMBER Then
                            _AboutAST906PF = EachItem
                            Exit For
                        End If
                    Next
                End If
                Last_AboutAST906PFAccessTime = Now
                Return _AboutAST906PF
            End Get
        End Property
#End Region
#Region "狀態碼(ACD2)中文說明 屬性:NowStateChineseExplain"
        ''' <summary>
        ''' 狀態碼(ACD2)中文說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ORMBaseClass.SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property NowStateChineseExplain() As String
            Get
                Select Case True
                    Case Me.ACD2 = " "
                        Return "正常"
                    Case Me.ACD2 = "A"
                        Return "閒置"
                    Case Me.ACD2 = "B"
                        Return "出租"
                End Select
                Return Nothing
            End Get
        End Property


#End Region
#Region "取得年月計劃折舊 方法:GetPlanYearMonthDepreciationMoney"
        ''' <summary>
        ''' 取得年月計劃折舊
        ''' </summary>
        ''' <param name="FindYearMonth"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPlanYearMonthDepreciationMoney(ByVal FindYearMonth As Date) As Double
            If Me.ACD3 = "-" OrElse Me.USLAFF = 0 Then
                Return 0
            End If
            Dim StartDate As Date = New AS400DateConverter(Me.DATE * 100 + 1).DateValue : StartDate = New Date(StartDate.Year, StartDate.Month, 1)
            Dim EndDate As Date = StartDate.AddYears(Me.USLAFF).AddMonths(-1) : EndDate = New Date(EndDate.Year, EndDate.Month, Date.DaysInMonth(EndDate.Year, EndDate.Month))
            Dim ExStartDate As Date = EndDate.AddDays(1)
            Dim ExEndDate As Date = ExStartDate.AddYears(Me.N7611).AddMonths(-1) : ExEndDate = New Date(ExEndDate.Year, ExEndDate.Month, Date.DaysInMonth(ExEndDate.Year, ExEndDate.Month))

            Select Case True
                Case FindYearMonth >= StartDate And FindYearMonth <= EndDate
                    Return (AMOUNT / (Me.USLAFF + 1)) / 12
                Case Me.N7611 > 0 AndAlso FindYearMonth >= ExStartDate And FindYearMonth <= ExEndDate
                    Return ((AMOUNT / (Me.USLAFF + 1)) / (Me.N7611 + 1)) / 12
                Case Else
                    Return 0
            End Select
        End Function
#End Region
#Region "取得期間計劃累計折舊 方法:GetPlanYearMonthSessionAggregateDepreciationMoney"
        ''' <summary>
        ''' 取得期間計劃累計折舊
        ''' </summary>
        ''' <param name="ToYearMonth"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPlanYearMonthSessionAggregateDepreciationMoney(ByVal ToYearMonth As Date) As Double
            Dim StartYearMonth As Date = New AS400DateConverter(Me.DATE * 100 + 1).DateValue
            Dim StartDate As Date = New Date(StartYearMonth.Year, StartYearMonth.Month, 1)
            Dim EndDate As Date = New Date(ToYearMonth.Year, ToYearMonth.Month, Date.DaysInMonth(ToYearMonth.Year, ToYearMonth.Month))

            Dim ReturnValue As Double = 0
            Dim DateCount As Date = StartYearMonth
            Do While DateCount <= EndDate
                If DateCount >= StartDate And DateCount <= EndDate Then
                    ReturnValue += GetPlanYearMonthDepreciationMoney(DateCount)
                End If
                DateCount = DateCount.AddMonths(1)
            Loop
            Return ReturnValue
        End Function
#End Region
#Region "取得期間計畫累計折舊殘值 方法:GetPlanYearMonthScrapValue"
        ''' <summary>
        ''' 取得期間計畫累計折舊殘值
        ''' </summary>
        ''' <param name="ToYearMonth"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPlanYearMonthSessionScrapValue(ByVal ToYearMonth As Date) As Double
            Return AMOUNT - GetPlanYearMonthSessionAggregateDepreciationMoney(ToYearMonth)
        End Function
#End Region



    End Class
End Namespace