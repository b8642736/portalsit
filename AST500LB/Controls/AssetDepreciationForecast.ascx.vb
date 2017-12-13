Public Partial Class AssetDepreciationForecast
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="StartYear"></param>
    ''' <param name="StartMonth"></param>
    ''' <param name="EndYear"></param>
    ''' <param name="EndMonth"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal StartYear As Integer, ByVal StartMonth As Integer, ByVal EndYear As Integer, ByVal EndMonth As Integer, ByVal AssetNumber As String, ByVal PlanCode As String, ByVal Units As String, ByVal AssetClass As String, ByVal AssetState As String, ByVal JunkStartDateAndEndDate As String) As AST500LBDataSet.AssetDepreciationForecaseDataTableDataTable
        Dim WhereString As String = Nothing
        Dim FromDBAndMemberPathString As String = (New CompanyORMDB.AST500LB.AST101PF).CDBFullAS400DBPath.Trim
        If Not String.IsNullOrEmpty(AssetNumber) AndAlso AssetNumber.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & " NUMBER LIKE '" & AssetNumber & "%'"
        End If
        If Not String.IsNullOrEmpty(AssetClass) AndAlso AssetClass.Trim.Length > 0 Then
            AssetClass = AssetClass.Replace("'", Nothing)
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & " LEFT(NUMBER,1) IN ('" & AssetClass.Replace(",", "','") & "') "
        End If
        If Not String.IsNullOrEmpty(AssetState) AndAlso AssetState.Trim.Length > 0 Then
            AssetState = AssetState.Replace("'", Nothing).Replace("0", " ").Replace("1", "A").Replace("2", "B")
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & " ACD2 IN ('" & AssetState.Replace(",", "','") & "') "
        End If


        If Not String.IsNullOrEmpty(PlanCode) AndAlso PlanCode.Trim.Length > 0 Then
            FromDBAndMemberPathString &= ".ASTF" & PlanCode
        End If

        Dim QryString As String = "Select * From " & FromDBAndMemberPathString & IIf(IsNothing(WhereString), Nothing, " Where " & WhereString)
        Dim ReturnValue As New AST500LBDataSet.AssetDepreciationForecaseDataTableDataTable
        Dim ToEndDateCount As Date = New Date(EndYear, EndMonth, Date.DaysInMonth(EndYear, EndMonth))
        Dim NowUseDep As String = Nothing '作單位小計 使用
        Dim NowNumberClass As String = Nothing  '作類別小計 使用
        Dim SearchDatas As List(Of AST101PF) = (From A In CompanyORMDB.AST500LB.AST101PF.CDBSelect(Of CompanyORMDB.AST500LB.AST101PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC) Select A Order By A.AboutAST106PF_UseDept, A.NUMBER).ToList
        If Not String.IsNullOrEmpty(Units) AndAlso Units.Trim.Length > 0 Then
            Dim QryResult As New List(Of AST101PF)
            For Each EachUnit As String In (From A In Units.Replace("'", Nothing).Split(",") Select A.ToUpper).ToList
                Dim EachUnitTemp As String = EachUnit
                QryResult.AddRange((From A In SearchDatas Where A.AboutAST106PF_UseDept Like EachUnitTemp & "*" Select A).ToList)
            Next
            SearchDatas = QryResult
        End If
        If Not String.IsNullOrEmpty(JunkStartDateAndEndDate) Then
            Dim StartDate As Date = JunkStartDateAndEndDate.Split(",")(0)
            Dim EndDate As Date = JunkStartDateAndEndDate.Split(",")(1)
            SearchDatas = (From A In SearchDatas Where A.JunkDate >= StartDate And A.JunkDate <= EndDate Select A).ToList
        End If

        For Each EachItem As CompanyORMDB.AST500LB.AST101PF In SearchDatas
            If String.IsNullOrEmpty(NowUseDep) Then
                NowUseDep = EachItem.AboutAST106PF_UseDept
            End If
            If String.IsNullOrEmpty(NowNumberClass) Then
                NowNumberClass = EachItem.NUMBER.Substring(0, 1)
            End If

            If EachItem.NUMBER.Substring(0, 1) <> NowNumberClass Then '類別小計
                Dim Addrow1 As AST500LBDataSet.AssetDepreciationForecaseDataTableRow = ReturnValue.NewRow
                With Addrow1
                    .資產名稱 = Format(ToEndDateCount, "MM") & "月單位:" & NowUseDep & "類別:" & NowNumberClass & " 小計:"
                    .帳面金額 = Format(CType((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep And A.NUMBER.Substring(0, 1) = NowNumberClass Select A.AMOUNT).Sum, Double), "0")
                    .累計折舊金額 = Format(CType(GetGroupDataGetPlanYearMonthSessionAggregateDepreciationMoney((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep And A.NUMBER.Substring(0, 1) = NowNumberClass Select A).ToList, ToEndDateCount), Double), "0")
                    .殘值 = Format(CType(GetGroupDataGetPlanYearMonthSessionScrapValue((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep And A.NUMBER.Substring(0, 1) = NowNumberClass Select A).ToList, ToEndDateCount), Double), "0")
                End With
                ReturnValue.Rows.Add(Addrow1)
                NowNumberClass = EachItem.NUMBER.Substring(0, 1)
            End If

            If EachItem.AboutAST106PF_UseDept <> NowUseDep Then '單位小計
                Dim Addrow1 As AST500LBDataSet.AssetDepreciationForecaseDataTableRow = ReturnValue.NewRow
                With Addrow1
                    .資產名稱 = Format(ToEndDateCount, "MM") & "月單位:" & NowUseDep & "小計:"
                    .帳面金額 = Format(CType((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep Select A.AMOUNT).Sum, Double), "0")
                    .累計折舊金額 = Format(CType(GetGroupDataGetPlanYearMonthSessionAggregateDepreciationMoney((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep Select A).ToList, ToEndDateCount), Double), "0")
                    .殘值 = Format(CType(GetGroupDataGetPlanYearMonthSessionScrapValue((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep Select A).ToList, ToEndDateCount), Double), "0")
                End With
                ReturnValue.Rows.Add(Addrow1)
                NowUseDep = EachItem.AboutAST106PF_UseDept
            End If



            Dim DateCount As Date = New Date(StartYear, StartMonth, 1)
            Dim IsNewAST101PFItem As Boolean = True
            Do While DateCount <= ToEndDateCount

                Dim Addrow As AST500LBDataSet.AssetDepreciationForecaseDataTableRow = ReturnValue.NewRow
                With Addrow
                    If IsNewAST101PFItem Then
                        .資產編號 = EachItem.NUMBER
                        If Not String.IsNullOrEmpty(EachItem.NUMBER) Then
                            .資產類別 = EachItem.NUMBER.Substring(0, 1)
                        End If
                        .使用單位 = EachItem.AboutAST106PF_UseDept
                        .資產名稱 = EachItem.NAME
                        .帳面金額 = Format(EachItem.AMOUNT, "0")
                        .使用年限 = EachItem.USLAFF & " 年"
                        If EachItem.N7611 > 0 Then
                            .使用年限 &= "(延長" & EachItem.N7611 & " 年)"
                        End If
                        .入帳年月 = EachItem.DATE
                    End If
                    .折舊年月 = DateCount.Year & "/" & DateCount.Month
                    .折舊金額 = Format(CType(EachItem.GetPlanYearMonthDepreciationMoney(DateCount), Double), "0")
                    .累計折舊金額 = Format(CType(EachItem.GetPlanYearMonthSessionAggregateDepreciationMoney(DateCount), Double), "0")
                    .殘值 = Format(CType(EachItem.GetPlanYearMonthSessionScrapValue(DateCount), Double), "0")
                    .報廢日期 = (Format(EachItem.JunkDate, "yyyy") - 1911) & "年" & Format(EachItem.JunkDate, "MM月")
                End With
                ReturnValue.Rows.Add(Addrow)
                DateCount = DateCount.AddMonths(1)
                IsNewAST101PFItem = False
            Loop
        Next

        '類別小計
        Dim Addrow3 As AST500LBDataSet.AssetDepreciationForecaseDataTableRow = ReturnValue.NewRow
        With Addrow3
            .資產名稱 = Format(ToEndDateCount, "MM") & "月單位:" & NowUseDep & "類別:" & NowNumberClass & " 小計:"
            .帳面金額 = Format(CType((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep And A.NUMBER.Substring(0, 1) = NowNumberClass Select A.AMOUNT).Sum, Double), "0")
            .累計折舊金額 = Format(CType(GetGroupDataGetPlanYearMonthSessionAggregateDepreciationMoney((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep And A.NUMBER.Substring(0, 1) = NowNumberClass Select A).ToList, ToEndDateCount), Double), "0")
            .殘值 = Format(CType(GetGroupDataGetPlanYearMonthSessionScrapValue((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep And A.NUMBER.Substring(0, 1) = NowNumberClass Select A).ToList, ToEndDateCount), Double), "0")
        End With
        ReturnValue.Rows.Add(Addrow3)
        '單位小計
        Dim Addrow4 As AST500LBDataSet.AssetDepreciationForecaseDataTableRow = ReturnValue.NewRow
        With Addrow4
            .資產名稱 = Format(ToEndDateCount, "MM") & "月單位:" & NowUseDep & "小計:"
            .帳面金額 = Format(CType((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep Select A.AMOUNT).Sum, Double), "0")
            .累計折舊金額 = Format(CType(GetGroupDataGetPlanYearMonthSessionAggregateDepreciationMoney((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep Select A).ToList, ToEndDateCount), Double), "0")
            .殘值 = Format(CType(GetGroupDataGetPlanYearMonthSessionScrapValue((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep Select A).ToList, ToEndDateCount), Double), "0")
        End With
        ReturnValue.Rows.Add(Addrow4)


        '總計
        Dim Addrow5 As AST500LBDataSet.AssetDepreciationForecaseDataTableRow = ReturnValue.NewRow
        With Addrow5
            .資產名稱 = Format(ToEndDateCount, "MM") & "月總計:(" & (From A In SearchDatas Select A).Count & "筆)"
            .帳面金額 = Format(CType((From A In SearchDatas Select A.AMOUNT).Sum, Double), "0")
            .累計折舊金額 = Format(CType(GetGroupDataGetPlanYearMonthSessionAggregateDepreciationMoney((From A In SearchDatas Select A).ToList, ToEndDateCount), Double), "0")
            .殘值 = Format(CType(GetGroupDataGetPlanYearMonthSessionScrapValue((From A In SearchDatas Select A).ToList, ToEndDateCount), Double), "0")
        End With
        ReturnValue.Rows.Add(Addrow5)

        Return ReturnValue
    End Function
    Private Function GetGroupDataGetPlanYearMonthSessionAggregateDepreciationMoney(ByVal GroupData As List(Of CompanyORMDB.AST500LB.AST101PF), ByVal ToYearMonth As Date) As Double
        If IsNothing(GroupData) OrElse GroupData.Count = 0 Then
            Return 0
        End If
        Dim ReturnValue As Double = 0
        For Each EachItem In GroupData
            ReturnValue += EachItem.GetPlanYearMonthSessionAggregateDepreciationMoney(ToYearMonth)
        Next
        Return ReturnValue
    End Function

    Private Function GetGroupDataGetPlanYearMonthSessionScrapValue(ByVal GroupData As List(Of CompanyORMDB.AST500LB.AST101PF), ByVal ToYearMonth As Date) As Double
        If IsNothing(GroupData) OrElse GroupData.Count = 0 Then
            Return 0
        End If
        Dim ReturnValue As Double = 0
        For Each EachItem In GroupData
            ReturnValue += EachItem.GetPlanYearMonthSessionScrapValue(ToYearMonth)
        Next
        Return ReturnValue
    End Function
#End Region
#Region "查詢1 方法:Search1"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search1(ByVal StartYear As Integer, ByVal StartMonth As Integer, ByVal EndYear As Integer, ByVal EndMonth As Integer, ByVal AssetNumber As String, ByVal PlanCode As String, ByVal Units As String, ByVal AssetClass As String, ByVal AssetState As String, ByVal JunkStartDateAndEndDate As String) As AST500LBDataSet.AssetDepreciationForecaseDataTableDataTable

        Dim WhereString As String = Nothing
        Dim FromDBAndMemberPathString As String = (New CompanyORMDB.AST500LB.AST101PF).CDBFullAS400DBPath.Trim
        If Not String.IsNullOrEmpty(AssetNumber) AndAlso AssetNumber.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & " NUMBER LIKE '" & AssetNumber & "%'"
        End If
        If Not String.IsNullOrEmpty(AssetClass) AndAlso AssetClass.Trim.Length > 0 Then
            AssetClass = AssetClass.Replace("'", Nothing)
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & " LEFT(NUMBER,1) IN ('" & AssetClass.Replace(",", "','") & "') "
        End If
        If Not String.IsNullOrEmpty(AssetState) AndAlso AssetState.Trim.Length > 0 Then
            AssetState = AssetState.Replace("'", Nothing).Replace("0", " ").Replace("1", "A").Replace("2", "B")
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & " ACD2 IN ('" & AssetState.Replace(",", "','") & "') "
        End If


        If Not String.IsNullOrEmpty(PlanCode) AndAlso PlanCode.Trim.Length > 0 Then
            FromDBAndMemberPathString &= ".ASTF" & PlanCode
        End If

        Dim QryString As String = "Select * From " & FromDBAndMemberPathString & IIf(IsNothing(WhereString), Nothing, " Where " & WhereString)

        Dim ReturnValue As New AST500LBDataSet.AssetDepreciationForecaseDataTableDataTable
        Dim ToEndDateCount As Date = New Date(EndYear, EndMonth, Date.DaysInMonth(EndYear, EndMonth))
        Dim NowUseDep As String = Nothing '作單位小計 使用
        Dim NowNumberClass As String = Nothing  '作類別小計 使用
        Dim SearchDatas As List(Of AST101PF) = (From A In CompanyORMDB.AST500LB.AST101PF.CDBSelect(Of CompanyORMDB.AST500LB.AST101PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC) Select A Order By A.AboutAST106PF_UseDept, A.NUMBER).ToList
        If Not String.IsNullOrEmpty(Units) AndAlso Units.Trim.Length > 0 Then
            Dim QryResult As New List(Of AST101PF)
            For Each EachUnit As String In (From A In Units.Replace("'", Nothing).Split(",") Select A.ToUpper).ToList
                Dim EachUnitTemp As String = EachUnit
                QryResult.AddRange((From A In SearchDatas Where A.AboutAST106PF_UseDept Like EachUnitTemp & "*" Select A).ToList)
            Next
            SearchDatas = QryResult
        End If
        If Not String.IsNullOrEmpty(JunkStartDateAndEndDate) Then
            Dim StartDate As Date = JunkStartDateAndEndDate.Split(",")(0)
            Dim EndDate As Date = JunkStartDateAndEndDate.Split(",")(1)
            SearchDatas = (From A In SearchDatas Where A.JunkDate >= StartDate And A.JunkDate <= EndDate Select A).ToList
        End If

        For Each EachItem As CompanyORMDB.AST500LB.AST101PF In SearchDatas
            If String.IsNullOrEmpty(NowUseDep) Then
                NowUseDep = EachItem.AboutAST106PF_UseDept
            End If
            If String.IsNullOrEmpty(NowNumberClass) Then
                NowNumberClass = EachItem.NUMBER.Substring(0, 1)
            End If

            If EachItem.NUMBER.Substring(0, 1) <> NowNumberClass Then '類別小計
                Dim Addrow1 As AST500LBDataSet.AssetDepreciationForecaseDataTableRow = ReturnValue.NewRow
                With Addrow1
                    .資產名稱 = Format(ToEndDateCount, "MM") & "月單位:" & NowUseDep & "類別:" & NowNumberClass & " 小計:"
                    .帳面金額 = Format(CType((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep And A.NUMBER.Substring(0, 1) = NowNumberClass Select A.AMOUNT).Sum, Double), "0")
                    .累計折舊金額 = Format(CType(GetGroupDataGetPlanYearMonthSessionAggregateDepreciationMoney((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep And A.NUMBER.Substring(0, 1) = NowNumberClass Select A).ToList, ToEndDateCount), Double), "0")
                    .殘值 = Format(CType(GetGroupDataGetPlanYearMonthSessionScrapValue((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep And A.NUMBER.Substring(0, 1) = NowNumberClass Select A).ToList, ToEndDateCount), Double), "0")
                End With
                ReturnValue.Rows.Add(Addrow1)
                NowNumberClass = EachItem.NUMBER.Substring(0, 1)
            End If

            If EachItem.AboutAST106PF_UseDept <> NowUseDep Then '單位小計
                Dim Addrow1 As AST500LBDataSet.AssetDepreciationForecaseDataTableRow = ReturnValue.NewRow
                With Addrow1
                    .資產名稱 = Format(ToEndDateCount, "MM") & "月單位:" & NowUseDep & "小計:"
                    .帳面金額 = Format(CType((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep Select A.AMOUNT).Sum, Double), "0")
                    .累計折舊金額 = Format(CType(GetGroupDataGetPlanYearMonthSessionAggregateDepreciationMoney((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep Select A).ToList, ToEndDateCount), Double), "0")
                    .殘值 = Format(CType(GetGroupDataGetPlanYearMonthSessionScrapValue((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep Select A).ToList, ToEndDateCount), Double), "0")
                End With
                ReturnValue.Rows.Add(Addrow1)
                NowUseDep = EachItem.AboutAST106PF_UseDept
            End If



            Dim DateCount As Date = New Date(StartYear, StartMonth, 1)
            Dim IsNewAST101PFItem As Boolean = True
            Dim Addrow As AST500LBDataSet.AssetDepreciationForecaseDataTableRow = ReturnValue.NewRow
            Do While DateCount <= ToEndDateCount
                With Addrow
                    If IsNewAST101PFItem Then
                        .資產編號 = EachItem.NUMBER
                        If Not String.IsNullOrEmpty(EachItem.NUMBER) Then
                            .資產類別 = EachItem.NUMBER.Substring(0, 1)
                        End If
                        .使用單位 = EachItem.AboutAST106PF_UseDept
                        .資產名稱 = EachItem.NAME
                        .帳面金額 = Format(EachItem.AMOUNT, "0")
                        .使用年限 = EachItem.USLAFF & " 年"
                        If EachItem.N7611 > 0 Then
                            .使用年限 &= "(延長" & EachItem.N7611 & " 年)"
                        End If
                        .入帳年月 = EachItem.DATE
                        .折舊年月 = DateCount.Year & "/" & DateCount.Month
                        .折舊金額 = 0
                    Else
                        .折舊年月 = .折舊年月.Split("~")(0) & "~" & DateCount.Year & "/" & DateCount.Month
                    End If
                    .折舊金額 += CType(EachItem.GetPlanYearMonthDepreciationMoney(DateCount), Double)
                    .累計折舊金額 = Format(CType(EachItem.GetPlanYearMonthSessionAggregateDepreciationMoney(DateCount), Double), "0")
                    .殘值 = Format(CType(EachItem.GetPlanYearMonthSessionScrapValue(DateCount), Double), "0")
                    .報廢日期 = (Format(EachItem.JunkDate, "yyyy") - 1911) & "年" & Format(EachItem.JunkDate, "MM月")
                End With
                DateCount = DateCount.AddMonths(1)
                IsNewAST101PFItem = False
            Loop
            Addrow.折舊金額 = Format(Addrow.折舊金額, "0")
            ReturnValue.Rows.Add(Addrow)
        Next

        '類別小計
        Dim Addrow3 As AST500LBDataSet.AssetDepreciationForecaseDataTableRow = ReturnValue.NewRow
        With Addrow3
            .資產名稱 = Format(ToEndDateCount, "MM") & "月單位:" & NowUseDep & "類別:" & NowNumberClass & " 小計:"
            .帳面金額 = Format(CType((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep And A.NUMBER.Substring(0, 1) = NowNumberClass Select A.AMOUNT).Sum, Double), "0")
            .累計折舊金額 = Format(CType(GetGroupDataGetPlanYearMonthSessionAggregateDepreciationMoney((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep And A.NUMBER.Substring(0, 1) = NowNumberClass Select A).ToList, ToEndDateCount), Double), "0")
            .殘值 = Format(CType(GetGroupDataGetPlanYearMonthSessionScrapValue((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep And A.NUMBER.Substring(0, 1) = NowNumberClass Select A).ToList, ToEndDateCount), Double), "0")
        End With
        ReturnValue.Rows.Add(Addrow3)
        '單位小計
        Dim Addrow4 As AST500LBDataSet.AssetDepreciationForecaseDataTableRow = ReturnValue.NewRow
        With Addrow4
            .資產名稱 = Format(ToEndDateCount, "MM") & "月單位:" & NowUseDep & "小計:"
            .帳面金額 = Format(CType((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep Select A.AMOUNT).Sum, Double), "0")
            .累計折舊金額 = Format(CType(GetGroupDataGetPlanYearMonthSessionAggregateDepreciationMoney((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep Select A).ToList, ToEndDateCount), Double), "0")
            .殘值 = Format(CType(GetGroupDataGetPlanYearMonthSessionScrapValue((From A In SearchDatas Where A.AboutAST106PF_UseDept = NowUseDep Select A).ToList, ToEndDateCount), Double), "0")
        End With
        ReturnValue.Rows.Add(Addrow4)


        '總計
        Dim Addrow5 As AST500LBDataSet.AssetDepreciationForecaseDataTableRow = ReturnValue.NewRow
        With Addrow5
            .資產名稱 = Format(ToEndDateCount, "MM") & "月總計:(" & (From A In SearchDatas Select A).Count & "筆)"
            .帳面金額 = Format(CType((From A In SearchDatas Select A.AMOUNT).Sum, Double), "0")
            .累計折舊金額 = Format(CType(GetGroupDataGetPlanYearMonthSessionAggregateDepreciationMoney((From A In SearchDatas Select A).ToList, ToEndDateCount), Double), "0")
            .殘值 = Format(CType(GetGroupDataGetPlanYearMonthSessionScrapValue((From A In SearchDatas Select A).ToList, ToEndDateCount), Double), "0")
        End With
        ReturnValue.Rows.Add(Addrow5)

        Return ReturnValue

    End Function

#End Region

#Region "使用者是否已按下查詢 屬性:IsUserAlreadyPutSearch"

    ''' <summary>
    ''' 使用者是否已按下查詢
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsUserAlreadyPutSearch() As Boolean
        Get
            If IsNothing(Me.ViewState("_IsUserAlreadyPutSearch")) Then
                Return False
            End If
            Return Me.ViewState("_IsUserAlreadyPutSearch")
        End Get
        Set(ByVal value As Boolean)
            Me.ViewState("_IsUserAlreadyPutSearch") = value
        End Set
    End Property
#End Region

#Region "設定資產狀態至被查詢參數控制項 函式:SetAssetStateToForSearchControl"
    ''' <summary>
    ''' 設定資產狀態至被查詢參數控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetAssetStateToForSearchControl()
        Me.hfAssetState.Value = ""
        If Not (CheckBoxList2.Items(0).Selected AndAlso CheckBoxList2.Items(1).Selected AndAlso CheckBoxList2.Items(2).Selected) Then
            For Each EachItem As ListItem In CheckBoxList2.Items
                If EachItem.Selected Then
                    Me.hfAssetState.Value &= IIf(String.IsNullOrEmpty(Me.hfAssetState.Value), EachItem.Value, "," & EachItem.Value)
                End If
            Next
        End If

        hfJunkStartAndEndDate.Value = ""
        If Me.cbIsJunkFilter.Checked Then
            hfJunkStartAndEndDate.Value = Me.tbJunkStartDate.Text & "," & Me.tbJunkEndDate.Text
        End If
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.TextBox1.Text = Now.Year
            Me.TextBox2.Text = Me.TextBox1.Text
            Me.tbJunkStartDate.Text = New Date(Now.Year, 1, 1)
            Me.tbJunkEndDate.Text = New Date(Now.Year, 12, 31)
            Me.DropDownList1.SelectedValue = Now.Month
            Me.DropDownList2.SelectedValue = Now.Month
        End If
    End Sub

    Private Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting, odsSearchResult0.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

    Private Sub btnSearchDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchDownload.Click
        SetAssetStateToForSearchControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing
        If RadioButtonList2.SelectedValue = 0 Then
            ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search(Me.TextBox1.Text, Me.DropDownList1.SelectedValue, Me.TextBox2.Text, Me.DropDownList2.SelectedValue, Me.TextBox3.Text, Me.RadioButtonList1.SelectedValue, Me.TextBox4.Text, Me.TextBox5.Text, Me.hfAssetState.Value, hfJunkStartAndEndDate.Value), "固定資產折舊預測" & Format(Now, "mmss") & ".xls")
        Else
            ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search1(Me.TextBox1.Text, Me.DropDownList1.SelectedValue, Me.TextBox2.Text, Me.DropDownList2.SelectedValue, Me.TextBox3.Text, Me.RadioButtonList1.SelectedValue, Me.TextBox4.Text, Me.TextBox5.Text, Me.hfAssetState.Value, hfJunkStartAndEndDate.Value), "固定資產折舊預測" & Format(Now, "mmss") & ".xls")
        End If
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        SetAssetStateToForSearchControl()
        Me.IsUserAlreadyPutSearch = True
        If RadioButtonList2.SelectedValue = 0 Then
            Me.MultiView1.SetActiveView(View1)
            Me.GridView1.DataBind()
        Else
            Me.MultiView1.SetActiveView(View2)
            Me.GridView2.DataBind()
        End If
    End Sub

End Class