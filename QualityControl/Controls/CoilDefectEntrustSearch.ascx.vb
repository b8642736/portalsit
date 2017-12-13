Public Partial Class CoilDefectEntrustSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String, ByVal OrderFieldList As String) As QualityControlDataSet.CoilDefectEntrustSearchDataTableDataTable
        Dim ReturnValue As New QualityControlDataSet.CoilDefectEntrustSearchDataTableDataTable
        Dim ShowTitleInfoKey As DataRow = Nothing
        Dim NumberCount As Integer = 0
        Dim CoilBugAssey As List(Of CompanyORMDB.PPS100LB.PPSDEFPF) = CompanyORMDB.PPS100LB.PPSDEFPF.ALL_PPSDEPF(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC))

        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        Dim SearchTemp As List(Of DataRow) = (From A In (From A In Adapter.SelectQuery.Rows Select CType(A, DataRow)).ToList Select A Order By A.Item(OrderFieldList.Split(",")(0)), A.Item(OrderFieldList.Split(",")(1)), A.Item(OrderFieldList.Split(",")(2)), A.Item(OrderFieldList.Split(",")(3)), A.Item(OrderFieldList.Split(",")(4)), A.Item(OrderFieldList.Split(",")(5)), A.Item(OrderFieldList.Split(",")(6))).ToList
        For Each EachItem As DataRow In SearchTemp
            Dim EachItemTemp As DataRow = EachItem
            Dim ADDItem As QualityControlDataSet.CoilDefectEntrustSearchDataTableRow = ReturnValue.NewRow
            With ADDItem
                Dim IsTitleInfoKeyChanged As Boolean = Not IsNothing(ShowTitleInfoKey) AndAlso (ShowTitleInfoKey("熱軋號碼") <> EachItem.Item("BWD01") OrElse ShowTitleInfoKey("加工業(外購)批次") <> EachItem.Item("BWD11") OrElse ShowTitleInfoKey("鋼胚號碼") <> EachItem.Item("BWD07") OrElse ShowTitleInfoKey("鋼捲號碼") <> EachItem.Item("BWD09") OrElse ShowTitleInfoKey("鋼種") <> EachItem.Item("BWD02") OrElse ShowTitleInfoKey("入廠產日") <> EachItem.Item("BWD08"))
                If IsNothing(ShowTitleInfoKey) OrElse IsTitleInfoKeyChanged Then
                    NumberCount += 1
                    .序號 = NumberCount
                    .熱軋號碼 = EachItem.Item("BWD01")
                    ._加工業_外購_批次 = EachItem.Item("BWD11")
                    .鋼胚號碼 = EachItem.Item("BWD07")
                    .鋼捲號碼 = EachItem.Item("BWD09")
                    .鋼種 = EachItem.Item("BWD02")
                    .材質 = EachItem.Item("BWD19")
                    .入廠產日 = EachItem.Item("BWD08")
                    .公稱厚度 = EachItem.Item("BWD03")
                    .產線日期 = EachItem.Item("QDE04")
                    ShowTitleInfoKey = ADDItem
                End If
                .追蹤線別 = EachItem.Item("QDE01")
                .公稱厚度 = EachItem.Item("BWD03")
                Dim GetCoilBugAssey As CompanyORMDB.PPS100LB.PPSDEFPF = (From A In CoilBugAssey Where A.DEF01 = CType(EachItemTemp.Item("QDE05"), String) Select A).FirstOrDefault
                If IsNothing(GetCoilBugAssey) Then
                    .缺陷代號 = EachItemTemp.Item("QDE05")
                Else
                    .缺陷代號 = GetCoilBugAssey.DEF02
                End If
                .程度 = EachItemTemp.Item("QDE17")
                Select Case EachItem.Item("QDE09")
                    Case "0"
                        .分佈 = "全"
                    Case "1"
                        .分佈 = "內"
                    Case "2"
                        .分佈 = "中"
                    Case "3"
                        .分佈 = "外"
                    Case "4"
                        .分佈 = "雙"
                    Case Else
                        .分佈 = EachItem.Item("QDE09")
                End Select
                .直起 = EachItem.Item("QDE07")
                .直終 = EachItem.Item("QDE08")
                .橫起 = EachItem.Item("QDE10")
                .橫終 = EachItem.Item("QDE11")
                Select Case CType(EachItem.Item("QDE12"), String)
                    Case "1"
                        .正反 = "正面"
                    Case "2"
                        .正反 = "反面"
                    Case "3"
                        .正反 = "雙面"
                    Case Else
                        .正反 = CType(EachItem.Item("QDE12"), String)
                End Select
                .密度 = CType(EachItem.Item("QDE14"), String)
                '.材質 = EachItem.Item("QCA06")
            End With
            ReturnValue.Rows.Add(ADDItem)

        Next

        ' 統計
        Dim FindLotsNumbersQryIn As String = (From A In SQLString.Replace("AND", "~").Replace("Order", "~").Replace("UNION", "~").Split("~") Where A.Trim.Contains("B.BWD11 IN") Select A).FirstOrDefault
        If Not IsNothing(FindLotsNumbersQryIn) Then
            FindLotsNumbersQryIn = FindLotsNumbersQryIn.Replace("B.BWD11 IN", Nothing)
            Dim TotalBatchCoilCountQry As String = "Select Count(*) from " & (New CompanyORMDB.PPS100LB.PPSBWDPF).CDBFullAS400DBPath & " Where BWD15='  ' AND  BWD11 IN " & FindLotsNumbersQryIn
            Dim TotalBatchCoilCount As Integer = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, TotalBatchCoilCountQry).SelectQuery.Rows(0).Item(0)
            Dim ToProcessQry As String = "Select COUNT(*) from " & (New CompanyORMDB.PPS100LB.PPSBWDPF).CDBFullAS400DBPath & " Where  BWD15='  ' AND BWD11 IN " & FindLotsNumbersQryIn & " AND " & _
                                        " BWD09 IN ( Select SHA01 from  " & (New CompanyORMDB.PPS100LB.PPSSHAPF).CDBFullAS400DBPath & "  WHERE SHA04=1 AND  SHA21<>0)"
            Dim ToProcessCount As Integer = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, ToProcessQry).SelectQuery.Rows(0).Item(0)
            Dim ADDItem As QualityControlDataSet.CoilDefectEntrustSearchDataTableRow = ReturnValue.NewRow
            With ADDItem
                ._加工業_外購_批次 = "鋼捲總數:" & TotalBatchCoilCount
                .鋼胚號碼 = "投入數:" & ToProcessCount
                .熱軋號碼 = "有缺陷數:" & NumberCount
            End With
            ReturnValue.Rows.Add(ADDItem)
        End If
        Return ReturnValue

    End Function


#End Region

#Region "使用者是否已按下查詢 屬性:IsUserAlreadyPutSearch"

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
#Region "控制項Where條件產生器 方法:ControlWhereMaker"
    ''' <summary>
    ''' 控制項Where條件產生器
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ControlWhereMaker()
        ''1020617 by renhsin,移除日期條件  B.BWD08<=C.QDE04,張群正Say此條件不需存在
        Dim ReturnValue As String = "Select B.*,C.* " & _
            " From  @#PPS100LB.PPSBWDPF B,@#PPS100LB.PPSQDEPF C " & _
            " WHERE B.BWD09 = C.QDE02" & _
            " AND B.BWD15='  ' "

        ''加入備份檔找尋利用Union將相同爐代找出鋼肧化學成份資料
        'Dim AddBackupFileDataQry As String = ReturnValue.Replace("A.", "AA.").Replace("B.", "BB.").Replace("C.", "CC.").Replace("@#PPS100LBB.PPSQCAPF A", "@#PPS100LB.PPSQCSPF AA").Replace("@#PPS100LBB.PPSBWDPF B", "@#PPS100LB.PPSBWDPF BB").Replace("@#PPS100LBB.PPSQDEPF C", "@#PPS100LB.PPSQDEPF CC")
        'AddBackupFileDataQry &= " AND AA.QCA35=BB.BWD13 "

        Dim WhereValue As String = Nothing
        If Not String.IsNullOrEmpty(tbSteelKind.Text) Then
            tbSteelKind.Text = tbSteelKind.Text.Replace("'", Nothing)
            WhereValue &= IIf(tbSteelKind.Text.Trim.Length > 0, "  AND B.BWD02 IN ('" & tbSteelKind.Text.Replace(",", "','") & "')", Nothing)
        End If
        If Not String.IsNullOrEmpty(tbBugCode.Text) Then
            tbBugCode.Text = tbBugCode.Text.Replace("'", Nothing)
            WhereValue &= IIf(tbBugCode.Text.Trim.Length > 0, " AND C.QDE05  IN (" & tbBugCode.Text & ")", Nothing)
        End If
        If CheckBox1.Checked Then   '入廠日
            Dim StartDate As Date = tbStartDate.Text
            Dim EndDate As Date = tbEndDate.Text
            WhereValue &= " AND B.BWD08>=" & (Format(StartDate, "yyyy") - 1911) * 10000 + Format(StartDate, "MMdd") & " AND B.BWD08<=" & (Format(EndDate, "yyyy") - 1911) * 10000 + Format(EndDate, "MMdd")
        End If
        If CheckBox2.Checked Then   '產線日
            Dim StartDate As Date = tbProLineStartDate.Text
            Dim EndDate As Date = tbProLineEndDate.Text
            WhereValue &= " AND C.QDE04>=" & (Format(StartDate, "yyyy") - 1911) * 10000 + Format(StartDate, "MMdd") & " AND C.QDE04<=" & (Format(EndDate, "yyyy") - 1911) * 10000 + Format(EndDate, "MMdd")
        End If
        If Not String.IsNullOrEmpty(tbProuctLine.Text) Then '品檢線別
            tbProuctLine.Text = tbProuctLine.Text.Replace("'", Nothing)
            WhereValue &= IIf(tbProuctLine.Text.Trim.Length > 0, " AND C.QDE01 IN ('" & tbProuctLine.Text.Replace(",", "','") & "')", Nothing)
        End If
        If Not String.IsNullOrEmpty(tbTotalEvent.Text) Then '綜合程度
            tbTotalEvent.Text = tbTotalEvent.Text.Replace("'", Nothing)
            WhereValue &= IIf(tbTotalEvent.Text.Trim.Length > 0, " AND C.QDE17 IN ('" & tbTotalEvent.Text.Replace(",", "','") & "')", Nothing)
        End If
        If Not String.IsNullOrEmpty(tbLotsNumbers.Text) Then    '批次
            tbLotsNumbers.Text = tbLotsNumbers.Text.Replace("'", Nothing)
            If tbLotsNumbers.Text.Contains("~") Then
                WhereValue &= IIf(tbLotsNumbers.Text.Trim.Length > 0, " AND B.BWD11 >= '" & tbLotsNumbers.Text.Split("~")(0).Trim & "' AND B.BWD11 <= '" & tbLotsNumbers.Text.Split("~")(1).Trim & "'", Nothing)
            Else
                WhereValue &= IIf(tbLotsNumbers.Text.Trim.Length > 0, " AND B.BWD11 IN ('" & tbLotsNumbers.Text.Replace(",", "','") & "')", Nothing)
            End If
        End If

        If Not String.IsNullOrEmpty(tbBugWidth.Text) Then   '缺陷寬度
            tbBugWidth.Text = tbBugWidth.Text.Replace("'", Nothing)
            WhereValue &= IIf(tbBugWidth.Text.Trim.Length > 0, " AND (C.QDE11-C.QDE10+1) " & RadioButtonList1.SelectedValue & CType(tbBugWidth.Text, Integer), Nothing)
        End If
        'If Not String.IsNullOrEmpty(WhereValue) AndAlso WhereValue.Trim.Length > 0 Then
        '    WhereValue = WhereValue.ToUpper.Trim
        '    If WhereValue.Substring(0, 3) = "AND" Then
        '        WhereValue = WhereValue.Substring(3, WhereValue.Length - 3)
        '    End If
        'End If
        If Not String.IsNullOrEmpty(Me.tbFrontBackCode.Text) Then   '缺陷面代碼
            tbFrontBackCode.Text = tbFrontBackCode.Text.Replace("'", Nothing)
            WhereValue &= IIf(tbFrontBackCode.Text.Trim.Length > 0, " AND C.QDE12 IN ('" & tbFrontBackCode.Text.Replace(",", "','") & "')", Nothing)
        End If

        If Not String.IsNullOrEmpty(tbSteelBugCodes.Text) AndAlso tbSteelBugCodes.Text.Trim.Length > 0 Then  '煉鋼異常代碼
            WhereValue &= IIf(WhereValue.Length > 0, " AND ", Nothing)
            Dim SteelBugCodes As String = tbSteelBugCodes.Text.Replace("'", Nothing).Replace(",", "','")
            Dim SGAFilterStr As String = Nothing
            For Each EachItem As String In SteelBugCodes.Replace("'", Nothing).Split(",")
                SGAFilterStr &= IIf(IsNothing(SGAFilterStr), Nothing, " OR ")
                SGAFilterStr &= " POSSTR(SGE11 ,'" & EachItem & "')<>0 "
            Next
            WhereValue &= "("
            WhereValue &= "B.BWD07 IN (Select DISTINCT SGA01 || '-' || SGA02 || SUBSTR(CHAR(SGA03+100),2,2) || SGA04 From @#SMS100LB.SMSSGAPF Where SGA26 IN ('" & SteelBugCodes & "') )"
            WhereValue &= " OR B.BWD07 IN (Select DISTINCT SGA01 || '-' || SGA02 || SUBSTR(CHAR(SGA03+100),2,2) || SGA04 From @#SMS100LB.SMSSGEPF Where " & SGAFilterStr & ")"
            WhereValue &= ")"

        End If

        'For Each EachItem As ListItem In lbElements.Items
        '    Dim Datas() As String = EachItem.Value.Split(":")
        '    WhereValue &= IIf(String.IsNullOrEmpty(WhereValue), Nothing, " AND ")
        '    WhereValue &= " QCA" & Datas(0) & " >= " & Datas(1) & " AND QCA" & Datas(0) & " <= " & Datas(2)
        'Next

        If Not String.IsNullOrEmpty(Me.tbDefective.Text) Then   '密度
            tbFrontBackCode.Text = tbFrontBackCode.Text.Replace("'", Nothing)
            WhereValue &= IIf(String.IsNullOrEmpty(WhereValue), Nothing, " AND ")
            WhereValue &= IIf(tbDefective.Text.Trim.Length > 0, " C.QDE14 IN ('" & tbDefective.Text.Replace(",", "','") & "')", Nothing)
        End If


        'If Not String.IsNullOrEmpty(WhereValue) AndAlso WhereValue.Trim.Length > 0 Then
        '    ReturnValue &= " AND " & WhereValue
        '    ReturnValue &= " UNION ALL (" & AddBackupFileDataQry & " AND " & WhereValue.Replace("A.", "AA.").Replace("B.", "BB.").Replace("C.", "CC.").Replace("SMS100LBB", "SMS100LB") & ")"
        'End If

        hfSortFieldsList.Value = Nothing
        For Each EachItem As ListItem In lbSort.Items
            hfSortFieldsList.Value &= IIf(String.IsNullOrEmpty(hfSortFieldsList.Value), Nothing, ",")
            hfSortFieldsList.Value &= EachItem.Value.Trim
        Next

        Me.hfSQLString.Value = ReturnValue & WhereValue
    End Sub
#End Region
#Region "重整顯示排序按鈕啟用 函式:RefreshSortButtonEnable"
    ''' <summary>
    ''' 重整顯示排序按鈕啟用
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshSortButtonEnable()
        Me.btnSortUp.Enabled = False
        Me.btnSortDown.Enabled = False
        If lbSort.Items.Count = 0 OrElse lbSort.SelectedIndex < 0 Then
            Exit Sub
        End If
        Try
            Select Case True
                Case lbSort.SelectedItem Is lbSort.Items(0)
                    Me.btnSortDown.Enabled = True
                Case lbSort.SelectedItem Is lbSort.Items(lbSort.Items.Count - 1)
                    Me.btnSortUp.Enabled = True
                Case Else
                    Me.btnSortUp.Enabled = True
                    Me.btnSortDown.Enabled = True
            End Select
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack OrElse String.IsNullOrEmpty(Me.tbStartDate.Text) OrElse String.IsNullOrEmpty(Me.tbEndDate.Text) Then
            Me.tbStartDate.Text = New Date(Now.Year, 1, 1)
            Me.tbEndDate.Text = Now.Date
            Me.tbProLineStartDate.Text = Me.tbStartDate.Text
            Me.tbProLineEndDate.Text = Me.tbEndDate.Text
        End If

    End Sub

    Protected Sub odsSearchResult1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult1.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Me.IsUserAlreadyPutSearch = True
        ControlWhereMaker()
        Me.MultiView1.SetActiveView(Me.View1)
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        Me.tbSteelKind.Text = Nothing
        Me.tbBugCode.Text = Nothing
        Me.tbProuctLine.Text = Nothing
        Me.tbStartDate.Text = New Date(Now.Year, 1, 1)
        Me.tbEndDate.Text = Now.Date
        Me.tbTotalEvent.Text = Nothing
        Me.tbLotsNumbers.Text = Nothing
        Me.tbBugWidth.Text = Nothing
        Me.tbFrontBackCode.Text = Nothing
        Me.tbSteelBugCodes.Text = Nothing
        Me.tbDefective.Text = Nothing
    End Sub

    Protected Sub btnSearchDownExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchDownExcel.Click
        Me.IsUserAlreadyPutSearch = True
        ControlWhereMaker()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing
        ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search(Me.hfSQLString.Value, Me.hfSortFieldsList.Value), "加工(外購)鋼捲缺陷查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub

    Protected Sub btnBackSearch2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBackSearch2.Click
        Me.MultiView1.SetActiveView(Me.SearchView)
    End Sub

    Private Sub lbSort_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSort.SelectedIndexChanged
        RefreshSortButtonEnable()
    End Sub

    Protected Sub btnSortUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSortUp.Click, btnSortDown.Click
        If IsNothing(lbSort.SelectedItem) Then
            Exit Sub
        End If
        Dim MoveToIndex As Integer = lbSort.SelectedIndex
        Dim InsertItem As ListItem = lbSort.SelectedItem
        lbSort.Items.Remove(lbSort.SelectedItem)
        If sender Is btnSortUp Then
            MoveToIndex -= 1
        Else
            MoveToIndex += 1
        End If
        MoveToIndex = IIf(MoveToIndex < 0, 0, MoveToIndex)
        lbSort.Items.Insert(MoveToIndex, InsertItem)
        RefreshSortButtonEnable()
    End Sub

End Class