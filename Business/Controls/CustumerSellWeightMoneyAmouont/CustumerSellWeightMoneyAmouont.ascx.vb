Public Partial Class CustumerSellWeightMoneyAmouont
    Inherits System.Web.UI.UserControl

#Region "資料查詢 方法:Search"

    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal SQLString) As SLS300LB.CustumerSellWeightMoneyAmouontDataTableDataTable
        Dim ReturnValue As New SLS300LB.CustumerSellWeightMoneyAmouontDataTableDataTable
        Dim SearchResult As List(Of CompanyORMDB.SLS300LB.SL2BOLPF) = (From A In CompanyORMDB.SLS300LB.SL2BOLPF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2BOLPF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC) Where A.CROrHR Like "CR*" Or A.CROrHR Like "HR*" Select A).ToList

        Dim HomeSellTotalWeight As Double = (From A In SearchResult Where A.IsHomeSell Select A.BOL14).Sum
        Dim OutSellTotalWeight As Double = (From A In SearchResult Where Not A.IsHomeSell Select A.BOL14).Sum
        Dim HomeOrOutSellDatas As New List(Of SLS300LB.CustumerSellWeightMoneyAmouontDataTableRow)
        Dim CustomerDatas As New List(Of SLS300LB.CustumerSellWeightMoneyAmouontDataTableRow)
        Dim TotalDatas As New List(Of SLS300LB.CustumerSellWeightMoneyAmouontDataTableRow)
        Dim AddItem As SLS300LB.CustumerSellWeightMoneyAmouontDataTableRow
        For Each EachItem In From A In SearchResult Select A.IsHomeSell, A.CustomerName, A.BOL05, A.CROrHR, A.BOL06 Order By IsHomeSell Descending, CustomerName, BOL05, CROrHR, BOL06 Distinct
            If CustomerDatas.Count > 0 AndAlso CustomerDatas(CustomerDatas.Count - 1).客戶別 <> EachItem.CustomerName Then
                AddItem = ReturnValue.NewRow
                AddCustomersCount(ReturnValue, CustomerDatas, IIf(CustomerDatas(0).內外銷.Trim = "內銷", HomeSellTotalWeight, OutSellTotalWeight))
                CustomerDatas.Clear()
            End If
            If HomeOrOutSellDatas.Count > 0 AndAlso HomeOrOutSellDatas(HomeOrOutSellDatas.Count - 1).內外銷 <> IIf(EachItem.IsHomeSell, "內銷", "外銷") Then
                AddHomeOrOutSellCount(ReturnValue, HomeOrOutSellDatas)
                HomeOrOutSellDatas.Clear()
            End If
            AddItem = ReturnValue.NewRow
            With AddItem
                .內外銷 = IIf(EachItem.IsHomeSell, "內銷", "外銷")
                .客戶別 = EachItem.CustomerName
                .鋼種 = EachItem.BOL05
                .CRHR = EachItem.CROrHR
                .表面 = EachItem.BOL06
                .噸數 = Format((From A In SearchResult Where A.IsHomeSell = EachItem.IsHomeSell And A.CustomerName = EachItem.CustomerName And A.BOL05 = EachItem.BOL05 And A.CROrHR = EachItem.CROrHR And A.BOL06 = EachItem.BOL06 Select A.BOL14).Sum, "###,###,###,###,###.000")
                .金額 = Format((From A In SearchResult Where A.IsHomeSell = EachItem.IsHomeSell And A.CustomerName = EachItem.CustomerName And A.BOL05 = EachItem.BOL05 And A.CROrHR = EachItem.CROrHR And A.BOL06 = EachItem.BOL06 Select A.BOL27).Sum, "###,###,###,###,###.00")
            End With
            ReturnValue.Rows.Add(AddItem)
            CustomerDatas.Add(AddItem)
            HomeOrOutSellDatas.Add(AddItem)
            TotalDatas.Add(AddItem)
        Next
        AddCustomersCount(ReturnValue, CustomerDatas, IIf(CustomerDatas(0).內外銷.Trim = "內銷", HomeSellTotalWeight, OutSellTotalWeight))
        AddHomeOrOutSellCount(ReturnValue, HomeOrOutSellDatas)

        AddItem = ReturnValue.NewRow
        With AddItem
            .內外銷 = "全部總計:"
            .噸數 = Format((From A In TotalDatas Select CType(A.噸數, Double)).Sum, "###,###,###,###,###.000")
            .金額 = Format((From A In TotalDatas Select CType(A.金額, Double)).Sum, "###,###,###,###,###.00")
        End With
        ReturnValue.Rows.Add(AddItem)

        Return ReturnValue
    End Function
    Private Shared Sub AddCustomersCount(ByVal SourceDataTable As SLS300LB.CustumerSellWeightMoneyAmouontDataTableDataTable, ByVal Datas As List(Of SLS300LB.CustumerSellWeightMoneyAmouontDataTableRow), ByVal HomeOrOutSellTotalWeight As Double)
        Dim AddItem As SLS300LB.CustumerSellWeightMoneyAmouontDataTableRow = SourceDataTable.NewRow
        Dim WeightSum As Double
        With AddItem
            .客戶別 = Datas(Datas.Count - 1).客戶別 & " 小計:"
            WeightSum = (From A In Datas Select CType(A.噸數, Double)).Sum
            .噸數 = Format(WeightSum, "###,###,###,###,###.000")
            .金額 = Format((From A In Datas Select CType(A.金額, Double)).Sum, "###,###,###,###,###.00")
            .內外銷噸數百分比 = Format((WeightSum / HomeOrOutSellTotalWeight), "0.00%")
        End With
        SourceDataTable.Rows.Add(AddItem)
    End Sub
    Private Shared Sub AddHomeOrOutSellCount(ByVal SourceDataTable As SLS300LB.CustumerSellWeightMoneyAmouontDataTableDataTable, ByVal Datas As List(Of SLS300LB.CustumerSellWeightMoneyAmouontDataTableRow))
        Dim AddItem As SLS300LB.CustumerSellWeightMoneyAmouontDataTableRow = SourceDataTable.NewRow
        With AddItem
            .內外銷 = Datas(Datas.Count - 1).內外銷 & " 加總:"
            .噸數 = Format((From A In Datas Select CType(A.噸數, Double)).Sum, "###,###,###,###,###.000")
            .金額 = Format((From A In Datas Select CType(A.金額, Double)).Sum, "###,###,###,###,###.00")
        End With
        SourceDataTable.Rows.Add(AddItem)
    End Sub
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

#Region "設定查詢字串 函式:SetQryString"
    ''' <summary>
    ''' 設定查詢字串
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryString()
        Dim StartDate As Date = CType(tbStartDate.Text, Date)
        Dim EndDate As Date = CType(tbEndDate.Text, Date)
        Dim StartDateStr As String = Format(Format(StartDate, "yyyy") - 1911, "000") & Format(StartDate, "MMdd")
        Dim EndDateStr As String = Format(Format(EndDate, "yyyy") - 1911, "000") & Format(EndDate, "MMdd")
        Dim QryString As String = Nothing
        'If RadioButtonList1.SelectedValue = 1 Then
        '    QryString = "Select * From @#SLS300LB.SL2BOLPF Where "  '提貨單檔
        '    QryString &= " ((BOL92=' ' OR BOL92 ='F') AND BOL04>='" & StartDateStr & "' AND BOL04<='" & EndDateStr & "')"
        '    QryString &= " OR ( (NOT (BOL92=' ' OR BOL92 ='F')) AND BOL01>='" & StartDateStr & "' AND BOL01<='" & EndDateStr & "')"
        'Else    '發票檔
        '    QryString = "Select UFI01 AS BOL01,UFI01 AS BOL04,UFI03 AS BOL03,UFI04 AS BOL05,UFI05 AS BOL06,UFI12 AS BOL14,UFI15 AS BOL27,UFI92 AS BOL92 From @#SLS300LB.SL2UFIPF Where "
        '    QryString &= "  UFI01>='" & StartDateStr & "' AND UFI01<='" & EndDateStr & "'"
        'End If

        QryString = "Select BOL01,BOL04,BOL03,BOL05,BOL06,BOL14,BOL27,BOL92 From @#SLS300LB.SL2BOLPF Where "  '提貨單檔(取外銷)
        QryString &= " NOT (BOL92=' ' OR BOL92 ='F') AND BOL01>='" & StartDateStr & "' AND BOL01<='" & EndDateStr & "'"
        '發票檔取內銷
        QryString &= " UNION ALL Select UFI01 AS BOL01,UFI01 AS BOL04,UFI03 AS BOL03,UFI04 AS BOL05,UFI05 AS BOL06,UFI12/1000 AS BOL14,UFI15 AS BOL27,UFI92 AS BOL92 From @#SLS300LB.SL2UFIPF Where "
        QryString &= " (UFI92=' ' OR UFI92 ='F') "
        QryString &= " AND  UFI01>='" & StartDateStr & "' AND UFI01<='" & EndDateStr & "'"

        Me.hfQryString.Value = QryString
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = New Date(Now.Year, 1, 1)
            tbEndDate.Text = New Date(Now.Year, 12, 31)
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        SetQryString()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchToExcel.Click
        IsUserAlreadyPutSearch = True
        SetQryString()
        Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(Search(Me.hfQryString.Value), "客戶出貨噸數金額統計表" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub
End Class