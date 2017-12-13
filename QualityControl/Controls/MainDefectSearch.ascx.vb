Public Partial Class MainDefectSearch
    Inherits System.Web.UI.UserControl


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryWhereAfterString As String) As QualityControlDataSet.MainDefectSearchDataTableDataTable
        Dim ReturnValue As New QualityControlDataSet.MainDefectSearchDataTableDataTable
        Dim QryString As String = "Select A.*,B.* from "
        QryString &= (New CompanyORMDB.PPS100LB.PPSQCPPF).CDBFullAS400DBPath & " A , " & (New CompanyORMDB.PPS100LB.PPSCIAPF).CDBFullAS400DBPath & " B "

        QryString &= " Where A.QCP02=B.CIA02 AND A.QCP02=B.CIA02 AND " & QryWhereAfterString
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
        Dim SearchResult As List(Of DataRow) = (From A In Adapter.SelectQuery(QryString) Select A).ToList
        Dim ShowTitleInfoKey As QualityControl.QualityControlDataSet.MainDefectSearchDataTableRow = Nothing
        Dim NumberCount As Integer = 0
        For Each EachItem As DataRow In (From A In SearchResult Order By A.Item("QCP02"), A.Item("QCP03") Select A).ToList
            Dim ObjectTemp As New CompanyORMDB.PPS100LB.PPSQCPPF
            ObjectTemp.CDBSetDataRowValueToObject(EachItem)
            For Each EachDefect As CompanyORMDB.PPS100LB.PPSQCPPF.DefectClass In ObjectTemp.MainDefects
                Dim IsTitleInfoKeyChanged As Boolean = Not IsNothing(ShowTitleInfoKey) AndAlso ShowTitleInfoKey.鋼捲號碼.Trim <> (ObjectTemp.QCP02 & ObjectTemp.QCP03).Trim
                Dim EachDefectCodeTemp As CompanyORMDB.PPS100LB.PPSQCPPF.DefectClass = EachDefect
                Dim AddDataRow As QualityControlDataSet.MainDefectSearchDataTableRow = ReturnValue.NewRow
                With AddDataRow
                    If IsNothing(ShowTitleInfoKey) OrElse IsTitleInfoKeyChanged Then
                        NumberCount += 1
                        .序號 = NumberCount
                        .鋼捲號碼 = ObjectTemp.QCP02 & ObjectTemp.QCP03
                        ShowTitleInfoKey = AddDataRow
                    End If
                    .等級 = EachDefectCodeTemp.Level
                    .主要缺陷 = EachDefectCodeTemp.DefectCodeExplainString
                    .長度 = EachDefectCodeTemp.DefectLength
                    .程度 = EachDefectCodeTemp.DefectLevel
                End With
                ReturnValue.Rows.Add(AddDataRow)
            Next
        Next
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
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property ControlWhereMaker() As String
        Get
            If Me.TabContainer1.ActiveTab Is Me.TabPanel2 Then
                ConvertFileToControl()
            End If
            Dim ReturnValue As String = Nothing
            Dim StartDate As Date = tbStartDate.Text
            Dim EndDate As Date = tbEndDate.Text
            ReturnValue &= " B.CIA63>=" & (Format(StartDate, "yyyy") - 1911) * 10000 + Format(StartDate, "MMdd") & " AND B.CIA63<=" & (Format(EndDate, "yyyy") - 1911) * 10000 + Format(EndDate, "MMdd")
            If Not String.IsNullOrEmpty(tbCompanyCode.Text) Then
                tbCompanyCode.Text = tbCompanyCode.Text.Replace("'", Nothing).ToUpper
                ReturnValue &= IIf(tbCompanyCode.Text.Trim.Length > 0, "  AND LEFT(B.CIA04,3) IN ('" & tbCompanyCode.Text.Replace(",", "','") & "')", Nothing)
            End If
            If Not String.IsNullOrEmpty(tbCoilNumbers.Text) Then
                tbCoilNumbers.Text = tbCoilNumbers.Text.Replace("'", Nothing).ToUpper
                Dim InString As String = Nothing
                For Each EachItem As String In tbCoilNumbers.Text.Split(",")
                    InString &= IIf(IsNothing(InString), Nothing, ",") & EachItem.PadLeft(5).Substring(0, 5)
                    If EachItem.Length > 5 Then
                        InString &= EachItem.PadRight(10).Substring(5, 5)
                    Else
                        InString &= "     "
                    End If
                Next
                ReturnValue &= IIf(Not IsNothing(InString), " AND B.CIA02 || B.CIA03  IN ('" & InString.Replace(",", "','") & "')", Nothing)
            End If
            Return ReturnValue
        End Get
    End Property
#End Region
#Region "轉換檔案至查詢控制項 函式:ConvertFileToControl"
    ''' <summary>
    ''' 轉換檔案至查詢控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ConvertFileToControl()
        If Not Me.FileUpload1.HasFile Then
            Exit Sub
        End If
        Dim GetFileString As String = System.Text.Encoding.UTF8.GetString(Me.FileUpload1.FileBytes).ToUpper
        Dim Datas As New List(Of String)
        For Each EachItem As String In GetFileString.Split(vbCrLf)
            Datas.Add(EachItem.Replace(vbLf, Nothing))
        Next
        Dim Title1 As String = "BILLSOFLADINGDATE:"
        Dim Title2 As String = "FACTORYCODES:"
        Dim Title3 As String = "COILNUMBERS:"
        Select Case True
            Case Datas.Count < 3 OrElse Datas(0).Trim.Substring(0, Title1.Length) <> Title1 OrElse Datas(1).Trim.Substring(0, Title2.Length) <> Title2 OrElse Datas(2).Trim.Substring(0, Title3.Length) <> Title3
                Throw New Exception("檔案格式不符合!")
            Case Datas(0).Replace(Title1, Nothing).Split("~").Length <> 2 OrElse Date.TryParse(Datas(0).Replace(Title1, Nothing).Split("~")(0), Nothing) = False OrElse Date.TryParse(Datas(0).Replace(Title1, Nothing).Split("~")(1), Nothing) = False
                Throw New Exception("檔案提貨單日期格式不符合!")
        End Select
        Me.tbStartDate.Text = CType(Datas(0).Replace(Title1, Nothing).Split("~")(0), Date)
        Me.tbEndDate.Text = CType(Datas(0).Replace(Title1, Nothing).Split("~")(1), Date)
        Me.tbCompanyCode.Text = Datas(1).Replace(Title2, Nothing)

        For EachLineIndex As Integer = 2 To Datas.Count - 1
            If EachLineIndex = 2 Then
                Me.tbCoilNumbers.Text = Datas(EachLineIndex).Replace(Title3, Nothing)
            Else
                If Me.tbCoilNumbers.Text.Substring(Me.tbCoilNumbers.Text.Length - 1, 1) <> "," AndAlso Datas(EachLineIndex).Substring(0, 1) <> "," Then
                    Me.tbCoilNumbers.Text &= ","
                End If
                Me.tbCoilNumbers.Text &= Datas(EachLineIndex)
            End If
        Next


    End Sub
#End Region

#Region "設定查詢條件至控制項 屬性:SetSelectArgToControl"
    Private Sub SetSelectArgToControl()
        Me.hfQryWhere.Value = ControlWhereMaker
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now.AddYears(-1), "yyyy/MM/dd")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        SetSelectArgToControl()
        Me.TabContainer1.ActiveTab = Me.TabPanel1
        Me.GridView1.DataBind()
    End Sub

    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        tbStartDate.Text = Format(Now.AddYears(-1), "yyyy/MM/dd")
        tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        tbCompanyCode.Text = Nothing
        tbCoilNumbers.Text = Nothing
    End Sub

    Protected Sub btnSearchToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchToExcel.Click
        Me.IsUserAlreadyPutSearch = True
        SetSelectArgToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfQryWhere.Value), "鋼捲主要缺陷查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub
End Class