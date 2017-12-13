Namespace AST500LB
    ''' <summary>
    ''' 本月折舊主檔
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class AST101PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("AST500LB", GetType(AST101PF).Name)
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
                If Not String.IsNullOrEmpty(_TransferNewNumber) Then
                    _TransferNewNumber = _TransferNewNumber.Trim
                End If
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
                If Not String.IsNullOrEmpty(_TransferNewDEPTSA) Then
                    _TransferNewDEPTSA = _TransferNewDEPTSA.Trim
                End If
            End Set
        End Property

#End Region
#Region "相關AST106PF_使用單位 屬性:AboutAST106PF_UseDept"
        Private _AboutAST106PF_UseDept As String
        ''' <summary>
        ''' 相關AST106PF_使用單位
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutAST106PF_UseDept() As String
            Get
                If IsNothing(_AboutAST106PF_UseDept) Then
                    Dim GetAboutAST106PF As AST106PF = AboutAST106PF
                    If Not IsNothing(GetAboutAST106PF) Then
                        _AboutAST106PF_UseDept = GetAboutAST106PF.DEPTSA
                    End If
                End If
                Return _AboutAST106PF_UseDept
            End Get
        End Property
#End Region

#Region "資產移轉錯誤訊息 屬性:AssetTransferErrorMsg"
        ''' <summary>
        ''' 資產移轉錯誤訊息
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
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
            Dim GetAboutAST106PF As AST106PF = Me.AboutAST106PF
            'If String.IsNullOrEmpty(TransferNewNumber) OrElse TransferCount <= 0 OrElse _
            '    String.IsNullOrEmpty(TransferNewDEPTSA) OrElse Me.DEPT <> "SA" OrElse _
            '    Me.AboutAST106PF_UseDept.Trim = Me.TransferNewDEPTSA.Trim OrElse _
            '    String.IsNullOrEmpty(AboutAST106PF_UseDept) OrElse IsNothing(GetAboutAST106PF) Then
            '    AssetTransferErrorMsg = "資料不正確或移轉單位必須不同!(不可單獨變更資產編號)"
            '    Return 0
            'End If
            If String.IsNullOrEmpty(TransferNewNumber) OrElse String.IsNullOrEmpty(TransferNewDEPTSA) OrElse _
                TransferCount <= 0 OrElse Me.DEPT <> "SA" OrElse _
                String.IsNullOrEmpty(AboutAST106PF_UseDept) OrElse IsNothing(GetAboutAST106PF) Then
                AssetTransferErrorMsg = "移轉資料不正確!"
                Return 0
            End If


            Dim QryOldAssetString As String = "Select * from @#AST500LB.AST101PF.ASTFSA WHERE NUMBER='" & Me.NUMBER & "' AND DEPT='" & DEPT & "' "
            Dim OldAssetResult As List(Of AST101PF) = AST101PF.CDBSelect(Of AST101PF)(QryOldAssetString, Me.CDBCurrentUseSQLQueryAdapter)
            If OldAssetResult.Count <> 1 Then
                AssetTransferErrorMsg = "資料庫中找出" & OldAssetResult.Count & " 筆原資產編號,無法執行資產移轉作業!"
                Return 0
            End If
            Dim QryOldAssetDetpString As String = "Select * from @#AST500LB.AST106PF.ASTFSA WHERE NUMBER='" & Me.NUMBER & "' AND SEQ=1 "
            Dim OldAssetDetpResult As List(Of AST106PF) = AST106PF.CDBSelect(Of AST106PF)(QryOldAssetDetpString, Me.CDBCurrentUseSQLQueryAdapter)
            If OldAssetDetpResult.Count <> 1 Then
                AssetTransferErrorMsg = "資料庫中找出" & OldAssetDetpResult.Count & " 筆原資產使用單位,無法執行資產移轉作業!"
                Return 0
            End If
            If Me.NUMBER.Trim = Me.TransferNewNumber AndAlso Me.TransferCount >= Me.QUANT AndAlso Me.AboutAST106PF_UseDept.Trim <> Me.TransferNewDEPTSA.Trim Then
                '全部資產作單位移轉更換保管單位
                With GetAboutAST106PF
                    GetAboutAST106PF.DEPTSA = Me.TransferNewDEPTSA.ToUpper
                    GetAboutAST106PF.SQLQueryAdapterByThisObject = Me.CDBCurrentUseSQLQueryAdapter
                    Return .CDBSave
                End With
            End If

            Dim QryNewAssetString As String = "Select * from @#AST500LB.AST101PF.ASTFSA WHERE NUMBER='" & Me.TransferNewNumber & "' AND DEPT='" & DEPT & "' "
            Dim NewAssetResult As List(Of AST101PF) = AST101PF.CDBSelect(Of AST101PF)(QryNewAssetString, Me.CDBCurrentUseSQLQueryAdapter)
            If NewAssetResult.Count <> 0 Then
                AssetTransferErrorMsg = "資料庫中找出" & NewAssetResult.Count & " 筆新資產編號存在於資料庫中,無法執行資產移轉作業!"
                Return 0
            End If
            Dim QryNewAssetDetpString As String = "Select * from @#AST500LB.AST106PF.ASTFSA WHERE NUMBER='" & Me.TransferNewNumber & "' AND SEQ=1 "
            Dim NewAssetDetpResult As List(Of AST106PF) = AST106PF.CDBSelect(Of AST106PF)(QryNewAssetDetpString, Me.CDBCurrentUseSQLQueryAdapter)
            If NewAssetDetpResult.Count <> 0 Then
                AssetTransferErrorMsg = "資料庫中找出" & NewAssetDetpResult.Count & " 筆新資產使用單位存在於資料庫中,無法執行資產移轉作業!"
                Return 0
            End If
            Dim ReturnValue As Integer = 0
            Select Case True
                Case Me.NUMBER.Trim <> Me.TransferNewNumber AndAlso Me.TransferCount >= Me.QUANT AndAlso Me.AboutAST106PF_UseDept.Trim = Me.TransferNewDEPTSA.Trim
                    '全部資產作資產編號移轉沒有更換保管單位
                    Dim NewAssetDBObject As AST101PF = Me.CDBClone
                    With NewAssetDBObject
                        .NUMBER = TransferNewNumber.ToUpper
                        .SQLQueryAdapterByThisObject = Me.CDBCurrentUseSQLQueryAdapter
                        ReturnValue = .CDBSave
                    End With
                    If ReturnValue > 0 Then
                        Dim NewDeptDBObject As AST106PF = Me.AboutAST106PF.CDBClone
                        With NewDeptDBObject
                            .NUMBER = TransferNewNumber.ToUpper
                            If .CDBSave = 0 Then
                                NewAssetDBObject.CDBDelete()
                                AssetTransferErrorMsg = "資料移轉失敗"
                                Return 0
                            End If
                        End With
                        If OldAssetResult(0).CDBDelete() > 0 Then
                            OldAssetDetpResult(0).CDBDelete()
                        Else
                            NewAssetDBObject.CDBDelete()
                            NewDeptDBObject.CDBDelete()
                            AssetTransferErrorMsg = "資料移轉失敗,因為無法刪除原資產資料(但已回復原狀態)!"
                            Return 0
                        End If
                    End If
                Case Me.NUMBER.Trim <> Me.TransferNewNumber AndAlso Me.TransferCount < Me.QUANT AndAlso Me.AboutAST106PF_UseDept <> Me.TransferNewDEPTSA AndAlso Me.TransferCount > 0
                    '資產數量分割並做單位移轉
                    Dim ModValue As Double = 0
                    Dim UnitPrice As Double = 0
                    Dim NewAssetDBObject As AST101PF = Me.CDBClone
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
                        Dim NewDeptDBObject As AST106PF = Me.AboutAST106PF.CDBClone
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
                                Return 0
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
#Region "相關AS106PF  屬性:AboutAST106PF"
        ''' <summary>
        ''' 相關AS106PF
        ''' </summary>
        ''' <remarks></remarks>
        Private _AboutAST106PF As AST106PF
        Private Shared _AboutAST106PFAll As List(Of AST106PF)
        Private Shared Last_AboutAST106PFAccessTime As DateTime = Now.AddSeconds(-10)
        ''' <summary>
        ''' 相關AS106PF
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutAST106PF() As AST106PF
            Get
                If IsNothing(_AboutAST106PFAll) OrElse Now.Subtract(Last_AboutAST106PFAccessTime).TotalSeconds > 3 Then
                    _AboutAST106PFAll = CDBSelect(Of AST106PF)("Select * from " & Me.CDBFullAS400DBPath.ToUpper.Replace("AST101PF", "AST106PF"), Me.CDBCurrentUseSQLQueryAdapter)
                End If
                If IsNothing(_AboutAST106PF) OrElse Now.Subtract(Last_AboutAST106PFAccessTime).TotalSeconds > 3 Then
                    For Each EachItem As AST106PF In _AboutAST106PFAll
                        If EachItem.NUMBER = Me.NUMBER Then
                            _AboutAST106PF = EachItem
                            Exit For
                        End If
                    Next
                End If
                Last_AboutAST106PFAccessTime = Now
                Return _AboutAST106PF
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


#Region "相關AST401PF 屬性:AboutAST401PF"
        Private _AboutAST401PF As List(Of AST401PF)
        ''' <summary>
        ''' 相關AST401PF
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public ReadOnly Property AboutAST401PF(Optional ByVal SearchCash As List(Of AST401PF) = Nothing) As List(Of AST401PF)
            Get
                If IsNothing(_AboutAST401PF) Then
                    Dim FindObjects As List(Of AST401PF) = Nothing
                    If IsNothing(SearchCash) Then
                        FindObjects = ClassDBAS400.CDBSelect(Of AST401PF)("Select * From " & (New AST401PF).CDBFullAS400DBPath & " Where FNUMBER='" & Me.NUMBER & "' Order by TRNDATE, TRNTIME", Me.CDBCurrentUseSQLQueryAdapter)
                    Else
                        FindObjects = SearchCash
                    End If
                    _AboutAST401PF = New List(Of AST401PF)
                    For Each EachItem As AST401PF In FindObjects
                        If EachItem.FNUMBER = Me.NUMBER Then
                            _AboutAST401PF.Add(EachItem)
                        End If
                    Next
                End If
                Return _AboutAST401PF
            End Get
        End Property

#End Region

#Region "所有資產(有資料快取功能) 屬性:AllAST101PF"
        Shared _AllAST101PF As New Dictionary(Of String, List(Of AST101PF))
        ''' <summary>
        ''' 所有資產(有資料快取功能)
        ''' </summary>
        ''' <param name="FindFactoryType"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Shared ReadOnly Property AllAST101PF(ByVal FindFactoryType As FactoryEnum) As List(Of AST101PF)
            Get
                If _AllAST101PF.ContainsKey(FindFactoryType) = False Then
                    Dim GetValues As List(Of AST101PF) = AST101PF.CDBSelect(Of AST101PF)("SELECT * FROM " & (New AST101PF).CDBFullAS400DBPath.Trim & ".ASTF" & [Enum].GetName(GetType(FactoryEnum), FindFactoryType), AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    _AllAST101PF.Add(FindFactoryType, GetValues)
                End If
                Return _AllAST101PF.Item(FindFactoryType)
            End Get
        End Property


        Public Enum FactoryEnum
            SA = 1
            AA = 2
            AB = 3
            QA = 4
            NA = 5
            RA = 6
            RC = 7
            RD = 8
        End Enum

#End Region

#Region "取得資產類別 方法:GetCategoryName"
        ''' <summary>
        ''' 取得資產類別
        ''' </summary>
        ''' <param name="AssetNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetCategoryName(ByVal AssetNumber As String) As String
            Select Case True
                Case AssetNumber.Substring(0, 1) = "1" AndAlso AssetNumber.Substring(0, 7) >= "1110101"
                    Return "土地改良物"
                Case AssetNumber.Substring(0, 1) = "1"
                    Return "土地"
                Case AssetNumber.Substring(0, 1) = "2"
                    Return "房屋及設備"
                Case AssetNumber.Substring(0, 1) = "3"
                    Return "機械及設備"
                Case AssetNumber.Substring(0, 1) = "4"
                    Return "交通設備"
                Case AssetNumber.Substring(0, 1) = "5"
                    Return "雜項設備"
            End Select
            Return Nothing
        End Function
#End Region

    End Class
End Namespace