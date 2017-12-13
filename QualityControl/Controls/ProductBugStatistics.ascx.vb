Public Class ProductBugStatistics
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(DateAdd(DateInterval.Month, -1, Now), "yyyy/MM/01")
            tbEndDate.Text = Format(DateAdd(DateInterval.Day, -1, CDate(Format(Now, "yyyy/MM/01"))), "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakerSQLStringToControl()
        Me.GridView1.DataBind()
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            '重量數字靠右對齊
            For II As Integer = 3 To 10
                e.Row.Cells(II).Attributes.Add("style", "text-align:right")
            Next II
        End If
    End Sub

    Protected Sub btnDownToExcel_Click(sender As Object, e As EventArgs) Handles btnDownToExcel.Click
        MakerSQLStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing

        Dim queryDataTable As DataTable = Search(Me.hfStartDate.Value, Me.hfEndDate.Value, Me.tbBugCodeNew.Text)

        ExcelConvert = New PublicClassLibrary.DataConvertExcel(queryDataTable, "缺陷類別統計" & Me.hfStartDate.Value & "~" & Me.hfEndDate.Value & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If
    End Sub
#Region "SQL查詢產生至控制項 方法:MakerSQLStringToControl"
    ''' <summary>
    ''' 查詢產生至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakerSQLStringToControl()
        Me.hfStartDate.Value = New CompanyORMDB.AS400DateConverter(Me.tbStartDate.Text).TwSixCharsTypeData
        Me.hfEndDate.Value = New CompanyORMDB.AS400DateConverter(Me.tbEndDate.Text).TwSixCharsTypeData
        Me.hfBugCodeNew.Value = tbBugCodeNew.Text
    End Sub
#End Region

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="fromStartDate"></param>
    ''' <param name="fromEndDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal fromStartDate As String, ByVal fromEndDate As String, ByVal fromBugCodeNew As String) As DataTable
        Dim ReturnDataTable As DataTable

        If String.IsNullOrEmpty(fromStartDate) OrElse String.IsNullOrEmpty(fromEndDate) Then
            Return New DataTable
        Else
            If Not (fromStartDate.Length = 6 Or fromStartDate.Length = 7) _
            OrElse Not (fromEndDate.Length = 6 Or fromEndDate.Length = 7) Then

                ReturnDataTable = New DataTable
                Dim ReturnDataRow As DataRow = ReturnDataTable.NewRow

                ReturnDataRow.Item(0) = "輸入的日期格式錯誤:" & fromStartDate & " - " & fromEndDate
                ReturnDataTable.Rows.Add(ReturnDataRow)
                Return ReturnDataTable
            End If
        End If

        ReturnDataTable = GetNewDataTable()
        Dim displayData As clsDisplay
        Dim StaticisticsData As clsDisplay = Nothing
        Dim StaticisticsTotalData As clsDisplay = Nothing
        Dim SortLastName As String = ""
        Dim SortNum As String = ""

        Dim MonthStart As String = fromStartDate.Substring(0, fromStartDate.Length - 2)
        Dim MonthEnd As String = fromEndDate.Substring(0, fromEndDate.Length - 2)

        Dim TitleListTotal As List(Of clsTitle) = GetTitleList(fromBugCodeNew)
        Dim TitleList As List(Of clsTitle) = (From A In TitleListTotal Where A.是否顯示 <> "N" Select A).ToList
        Dim WeightSecondHeadTailList As List(Of clsWeight次級品與頭尾廢料) = GetWeightSecondHeadTailList(MonthStart, MonthEnd)
        Dim WeightTotalSecondList As List(Of clsWeight全捲次級重量) = GetWeightTotalSecond(fromStartDate, fromEndDate)
        Dim AllWeightTotal As Integer = GetAllWeightTotal(MonthStart, MonthEnd)         '總繳庫輛

        Dim WeightSecondHeadTailQueryList As List(Of clsWeight次級品與頭尾廢料)
        Dim WeightTotalSecondQueryList As List(Of clsWeight全捲次級重量)

        For Each eachTitle As clsTitle In TitleList
            displayData = New clsDisplay
            displayData.新號 = eachTitle.新代碼
            displayData.舊號 = eachTitle.舊代碼
            displayData.缺陷名稱 = eachTitle.名稱

            Dim OldCodeList As List(Of String) = (From A In TitleListTotal Where A.新代碼 = eachTitle.新代碼 Select CType(A.舊代碼, String)).ToList
            Dim OldCode As String = String.Join(",", OldCodeList.ToArray)

            WeightSecondHeadTailQueryList = (From A In WeightSecondHeadTailList Where OldCode.Split(",").Contains(A.舊代碼) Select A).ToList
            If WeightSecondHeadTailQueryList.Count > 0 Then
                displayData.次級品重量 = (From A In WeightSecondHeadTailQueryList Select A.次級品重量).Sum
                displayData.頭尾廢料重量 = (From A In WeightSecondHeadTailQueryList Select A.頭尾廢料重量).Sum
            End If

            WeightTotalSecondQueryList = (From A In WeightTotalSecondList Where OldCode.Split(",").Contains(A.舊代碼) Select A).ToList
            If WeightTotalSecondQueryList.Count > 0 Then
                displayData.全捲次級重 = (From A In WeightTotalSecondQueryList Select A.全捲次級重量).Sum
            End If

            'AS400特例 : 如果『全捲次級重』大於『 次級品重量』那他的值就更改為『 次級品重量』
            If IsNumeric(displayData.全捲次級重) AndAlso IsNumeric(displayData.次級品重量) Then
                If Integer.Parse(displayData.全捲次級重) > Integer.Parse(displayData.次級品重量) Then
                    displayData.全捲次級重 = displayData.次級品重量
                End If
            End If

            If SortNum <> eachTitle.排序 Then
                If SortNum <> "" Then
                    StaticisticsData.缺陷名稱 = SortLastName & "小計"
                    PutDataRowData(ReturnDataTable, StaticisticsData, AllWeightTotal)

                    '總計
                    If StaticisticsTotalData Is Nothing Then
                        StaticisticsTotalData = New clsDisplay
                        StaticisticsTotalData.缺陷名稱 = "總計"
                    End If

                    SumData(StaticisticsTotalData, StaticisticsData)
                End If

                StaticisticsData = New clsDisplay
                SortNum = eachTitle.排序
            End If
            SumData(StaticisticsData, displayData)

            SortLastName = IIf(eachTitle.新代碼.Length >= 1, eachTitle.新代碼.Substring(0, 1), "")

            PutDataRowData(ReturnDataTable, displayData, AllWeightTotal)
        Next


        If Not StaticisticsTotalData Is Nothing Then
            '最後一個小計
            If Not StaticisticsData Is Nothing Then SumData(StaticisticsTotalData, StaticisticsData)
            '總計
            PutDataRowData(ReturnDataTable, StaticisticsTotalData, AllWeightTotal)
        End If

        Return ReturnDataTable
    End Function

    Private Sub SumData(ByRef fromStaticistics As clsDisplay, ByRef fromRecordItem As clsDisplay)
        fromRecordItem.次級品重量 = Integer.Parse(fromRecordItem.次級品重量, Globalization.NumberStyles.Number).ToString
        fromRecordItem.全捲次級重 = Integer.Parse(fromRecordItem.全捲次級重, Globalization.NumberStyles.Number).ToString
        fromRecordItem.綜合鋼捲次級重 = Integer.Parse(fromRecordItem.綜合鋼捲次級重, Globalization.NumberStyles.Number).ToString
        fromRecordItem.頭尾廢料重量 = Integer.Parse(fromRecordItem.頭尾廢料重量, Globalization.NumberStyles.Number).ToString

        fromStaticistics.次級品重量 = Integer.Parse(fromStaticistics.次級品重量) + Integer.Parse(fromRecordItem.次級品重量)
        fromStaticistics.全捲次級重 = Integer.Parse(fromStaticistics.全捲次級重) + Integer.Parse(fromRecordItem.全捲次級重)
        fromStaticistics.綜合鋼捲次級重 = Integer.Parse(fromStaticistics.綜合鋼捲次級重) + Integer.Parse(fromRecordItem.綜合鋼捲次級重)
        fromStaticistics.頭尾廢料重量 = Integer.Parse(fromStaticistics.頭尾廢料重量) + Integer.Parse(fromRecordItem.頭尾廢料重量)
    End Sub

    Private Function GetNewDataTable() As DataTable
        Dim ReturnDataTable As New DataTable

        ReturnDataTable.Columns.Add("新號")
        ReturnDataTable.Columns.Add("舊號")
        ReturnDataTable.Columns.Add("缺陷名稱")
        ReturnDataTable.Columns.Add("次級品重量")
        ReturnDataTable.Columns.Add("全捲次級重")
        ReturnDataTable.Columns.Add("綜合鋼捲次級重")
        ReturnDataTable.Columns.Add("頭尾廢料重量")

        ReturnDataTable.Columns.Add("次級品重量比例")
        ReturnDataTable.Columns.Add("全捲次級重比例")
        ReturnDataTable.Columns.Add("綜合鋼捲次級重比例")
        ReturnDataTable.Columns.Add("頭尾廢料重量比例")
        Return ReturnDataTable
    End Function
    Private Sub PutDataRowData(ByRef fromDataTable As DataTable, ByVal fromDisplay As clsDisplay, ByVal fromAllWeightTotal As Integer)
        Dim ReturnDataRow As DataRow = fromDataTable.NewRow

        fromDisplay.綜合鋼捲次級重 = Integer.Parse(fromDisplay.次級品重量) - Integer.Parse(fromDisplay.全捲次級重)

        '4個重量占總繳庫重量比例:小數兩位
        Dim 比例次級品重量 As String = String.Format("{0:0.##}", Integer.Parse(fromDisplay.次級品重量) / fromAllWeightTotal * 100) & "%"
        Dim 比例全捲次級重 As String = String.Format("{0:0.##}", Integer.Parse(fromDisplay.全捲次級重) / fromAllWeightTotal * 100) & "%"
        Dim 比例綜合鋼捲次級重 As String = String.Format("{0:0.##}", Integer.Parse(fromDisplay.綜合鋼捲次級重) / fromAllWeightTotal * 100) & "%"
        Dim 比例頭尾廢料重量 As String = String.Format("{0:0.##}", Integer.Parse(fromDisplay.頭尾廢料重量) / fromAllWeightTotal * 100) & "%"

        '3個數字加上1個逗號
        fromDisplay.次級品重量 = String.Format("{0:N0}", Integer.Parse(fromDisplay.次級品重量))
        fromDisplay.全捲次級重 = String.Format("{0:N0}", Integer.Parse(fromDisplay.全捲次級重))
        fromDisplay.綜合鋼捲次級重 = String.Format("{0:N0}", Integer.Parse(fromDisplay.綜合鋼捲次級重))
        fromDisplay.頭尾廢料重量 = String.Format("{0:N0}", Integer.Parse(fromDisplay.頭尾廢料重量))

        ReturnDataRow.Item("新號") = fromDisplay.新號
        ReturnDataRow.Item("舊號") = fromDisplay.舊號
        ReturnDataRow.Item("缺陷名稱") = fromDisplay.缺陷名稱

        ReturnDataRow.Item("次級品重量") = fromDisplay.次級品重量
        ReturnDataRow.Item("全捲次級重") = fromDisplay.全捲次級重
        ReturnDataRow.Item("綜合鋼捲次級重") = fromDisplay.綜合鋼捲次級重
        ReturnDataRow.Item("頭尾廢料重量") = fromDisplay.頭尾廢料重量

        ReturnDataRow.Item("次級品重量比例") = 比例次級品重量
        ReturnDataRow.Item("全捲次級重比例") = 比例全捲次級重
        ReturnDataRow.Item("綜合鋼捲次級重比例") = 比例綜合鋼捲次級重
        ReturnDataRow.Item("頭尾廢料重量比例") = 比例頭尾廢料重量

        fromDataTable.Rows.Add(ReturnDataRow)
    End Sub
#End Region

#Region "取得缺陷代號清單:GetTitleList"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Function GetTitleList(ByVal fromBugCodeNew As String) As List(Of clsTitle)
        Dim QuerySQL As New StringBuilder
        QuerySQL.Append("SELECT * ")
        QuerySQL.Append("FROM PPS100LB.ppsde1pf ")
        QuerySQL.Append("WHERE 1=1 ")
        If Not fromBugCodeNew Is Nothing AndAlso fromBugCodeNew <> "" Then
            QuerySQL.Append(" AND de101 IN ('" & fromBugCodeNew.Replace(",", "','") & "')")
        End If
        QuerySQL.Append("ORDER BY de102,de101,def01 ")

        Dim QueryDataTable As DataTable = New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).SelectQuery(QuerySQL.ToString)
        Dim ReturnList As New List(Of clsTitle)
        Dim ItemRow As clsTitle
        For Each eachItem As DataRow In QueryDataTable.Rows
            ItemRow = New clsTitle

            ItemRow.排序 = eachItem.Item("de102")
            ItemRow.新代碼 = eachItem.Item("de101")
            ItemRow.舊代碼 = eachItem.Item("def01")
            ItemRow.名稱 = CType(eachItem.Item("de103"), String).Replace(ChrW(63508), "銹")
            ItemRow.是否顯示 = eachItem.Item("de104")

            ReturnList.Add(ItemRow)
        Next

        Return ReturnList
    End Function
#End Region

#Region "取得二級/頭尾廢料的重量"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="fromStartMonth">開始年月份</param>
    ''' <param name="fromEndMonth">結束年月份</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetWeightSecondHeadTailList(ByVal fromStartMonth As String, ByVal fromEndMonth As String) As List(Of clsWeight次級品與頭尾廢料)
        Dim QuerySQL As New StringBuilder
        QuerySQL.Append("SELECT ci810,sum(ci811+ci812) WeightSecond,sum(ci813+ci815) WeightHeadTail ")
        QuerySQL.Append("FROM @#pps100lb.ppsci8pf ")
        QuerySQL.Append("WHERE 1 = 1 ")
        QuerySQL.Append("    AND ci700>='" & fromStartMonth & "' ")
        QuerySQL.Append("    AND ci700<='" & fromEndMonth & "' ")
        QuerySQL.Append("GROUP BY ci810 ")

        Dim QueryDataTable As DataTable = New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).SelectQuery(QuerySQL.ToString)
        Dim ReturnList As New List(Of clsWeight次級品與頭尾廢料)
        Dim ItemRow As clsWeight次級品與頭尾廢料
        For Each eachItem As DataRow In QueryDataTable.Rows
            ItemRow = New clsWeight次級品與頭尾廢料

            ItemRow.舊代碼 = eachItem.Item("ci810")
            ItemRow.次級品重量 = eachItem.Item("WeightSecond")
            ItemRow.頭尾廢料重量 = eachItem.Item("WeightHeadTail")
            ReturnList.Add(ItemRow)
        Next

        Return ReturnList
    End Function
#End Region

#Region "取得全捲次級重量"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="fromStartDate">開始年月日</param>
    ''' <param name="fromEndDate">結束年月日</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetWeightTotalSecond(ByVal fromStartDate As String, ByVal fromEndDate As String) As List(Of clsWeight全捲次級重量)
        Dim ReturnList As New List(Of clsWeight全捲次級重量)
        Dim ItemRow As clsWeight全捲次級重量

        Dim ColumnCode() As String = New String() {"qcp24", "qcp27", "qcp30", "qcp33", "qcp36", "qcp39", "qcp42", "qcp45"}
        Dim ColumnWeight() As String = New String() {"qcp25", "qcp28", "qcp31", "qcp34", "qcp37", "qcp40", "qcp43", "qcp36"}

        Dim adapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim QueryDataTable As DataTable
        Dim QuerySQL As New StringBuilder
        For II As Integer = LBound(ColumnCode) To UBound(ColumnCode)
            QuerySQL.Remove(0, QuerySQL.Length)
            QuerySQL.Append("SELECT BugCode, SUM(BugWeight) BugWeightSum ")
            QuerySQL.Append("FROM( ")
            QuerySQL.Append("                 SELECT  DEC(ROUND(cia58/100,0))  YM ")
            QuerySQL.Append("                               , T01." & ColumnCode(II) & "  BugCode ")
            QuerySQL.Append("                                , DEC(ROUND(( DOUBLE(T01." & ColumnWeight(II) & " / T02.cia09)  * T02.cia13 ),0)) BugWeight ")
            QuerySQL.Append("                 FROM( ")
            QuerySQL.Append("                                SELECT * ")
            QuerySQL.Append("                                FROM @#PPS100LB.PPSQCPPF ")
            QuerySQL.Append("                                WHERE 1=1 ")
            QuerySQL.Append("                                     AND QCP59 >=" & fromStartDate & " and QCP59<=" & fromEndDate & " ")
            QuerySQL.Append("                                      AND QCP10 in ('2','3') ")
            QuerySQL.Append("                 ) T01 ")
            QuerySQL.Append("                    LEFT JOIN @#PPS100LB.PPSCIAPF T02 ON T02.CIA02=T01.QCP02 AND T02.CIA03=T01.QCP03 AND T02.CIA58=T01.QCP59 ")
            QuerySQL.Append("                 WHERE T01." & ColumnCode(II) & "<>0 AND T01." & ColumnWeight(II) & "<>0 ")
            QuerySQL.Append("                 ) V ")
            QuerySQL.Append("GROUP BY BugCode ")
            QuerySQL.Append("ORDER BY BugCode ")

            QueryDataTable = adapter.SelectQuery(QuerySQL.ToString)
            Dim NewItemNeedAdd As Boolean
            For Each eachItem As DataRow In QueryDataTable.Rows
                ItemRow = (From A In ReturnList Where A.舊代碼 = eachItem.Item("BugCode") Select A).FirstOrDefault
                NewItemNeedAdd = (ItemRow Is Nothing)

                If ItemRow Is Nothing Then
                    ItemRow = New clsWeight全捲次級重量
                    ItemRow.舊代碼 = eachItem.Item("BugCode")
                End If

                ItemRow.全捲次級重量 += CType(eachItem.Item("BugWeightSum"), Integer)

                If NewItemNeedAdd = True Then ReturnList.Add(ItemRow)
            Next
        Next II


        Return ReturnList
    End Function
#End Region

#Region "取得總繳庫重量"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="fromStartMonth">開始年月份</param>
    ''' <param name="fromEndMonth">結束年月份</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAllWeightTotal(ByVal fromStartMonth As String, ByVal fromEndMonth As String) As Integer
        Dim QuerySQL As New StringBuilder
        QuerySQL.Append("SELECT SUM(CI711) AllWeightTotal ")
        QuerySQL.Append("FROM @#pps100lb.ppsci7pf ")
        QuerySQL.Append("WHERE 1 = 1 ")
        QuerySQL.Append("    AND CI700>=" & fromStartMonth & " ")
        QuerySQL.Append("    AND CI700<=" & fromEndMonth & " ")

        Dim ReturnValue As Integer
        Dim QueryDataTable As DataTable = New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).SelectQuery(QuerySQL.ToString)
        If QueryDataTable.Rows.Count = 0 Then
            ReturnValue = 0
        Else
            ReturnValue = CType(QueryDataTable.Rows(0).Item(0), Integer)
        End If

        Return ReturnValue
    End Function
#End Region

#Region "相關Class"
    Class clsTitle
        Private _排序 As String
        Public Property 排序 As String
            Get
                Return _排序
            End Get
            Set(value As String)
                _排序 = value
            End Set
        End Property

        Private _新代碼 As String
        Public Property 新代碼 As String
            Get
                Return _新代碼
            End Get
            Set(value As String)
                _新代碼 = value
            End Set
        End Property

        Private _舊代碼 As String
        Public Property 舊代碼 As String
            Get
                Return _舊代碼
            End Get
            Set(value As String)
                _舊代碼 = value
            End Set
        End Property
        Private _名稱 As String
        Public Property 名稱 As String
            Get
                Return _名稱
            End Get
            Set(value As String)
                _名稱 = value
            End Set
        End Property

        Private _是否顯示 As String
        Public Property 是否顯示 As String
            Get
                Return _是否顯示
            End Get
            Set(value As String)
                _是否顯示 = value
            End Set
        End Property
    End Class

    Class clsWeight次級品與頭尾廢料
        Private _舊代碼 As String
        Public Property 舊代碼 As String
            Get
                Return _舊代碼
            End Get
            Set(value As String)
                _舊代碼 = value
            End Set
        End Property

        Private _次級品重量 As Integer
        Public Property 次級品重量 As Integer
            Get
                Return _次級品重量
            End Get
            Set(value As Integer)
                _次級品重量 = value
            End Set
        End Property

        Private _頭尾廢料重量 As Integer
        Public Property 頭尾廢料重量 As Integer
            Get
                Return _頭尾廢料重量
            End Get
            Set(value As Integer)
                _頭尾廢料重量 = value
            End Set
        End Property
    End Class

    Class clsWeight全捲次級重量
        Private _舊代碼 As String
        Public Property 舊代碼 As String
            Get
                Return _舊代碼
            End Get
            Set(value As String)
                _舊代碼 = value
            End Set
        End Property

        Private _全捲次級重量 As Integer
        Public Property 全捲次級重量 As Integer
            Get
                Return _全捲次級重量
            End Get
            Set(value As Integer)
                _全捲次級重量 = value
            End Set
        End Property
    End Class

    Class clsDisplay
        Private _新號 As String
        Public Property 新號 As String
            Get
                Return _新號
            End Get
            Set(value As String)
                _新號 = value
            End Set
        End Property

        Private _舊號 As String
        Public Property 舊號 As String
            Get
                Return _舊號
            End Get
            Set(value As String)
                _舊號 = value
            End Set
        End Property

        Private _缺陷名稱 As String
        Public Property 缺陷名稱 As String
            Get
                Return _缺陷名稱
            End Get
            Set(value As String)
                _缺陷名稱 = value
            End Set
        End Property

        Private _次級品重量 As String = "0"
        Public Property 次級品重量 As String
            Get
                Return _次級品重量
            End Get
            Set(value As String)
                _次級品重量 = value
            End Set
        End Property

        Private _全捲次級重 As String = "0"
        Public Property 全捲次級重 As String
            Get
                Return _全捲次級重
            End Get
            Set(value As String)
                _全捲次級重 = value
            End Set
        End Property

        Private _綜合鋼捲次級重 As String = "0"
        Public Property 綜合鋼捲次級重 As String
            Get
                Return _綜合鋼捲次級重
            End Get
            Set(value As String)
                _綜合鋼捲次級重 = value
            End Set
        End Property

        Private _頭尾廢料重量 As String = "0"
        Public Property 頭尾廢料重量 As String
            Get
                Return _頭尾廢料重量
            End Get
            Set(value As String)
                _頭尾廢料重量 = value
            End Set
        End Property
    End Class
#End Region

    Protected Sub radioBugCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles radioBugCode.SelectedIndexChanged
        Select Case radioBugCode.SelectedValue
            Case "次級品"
                tbBugCodeNew.Text = "M01,M0203,H03,R01,R03,A07,C11,C36"
            Case "頭尾廢料"
                tbBugCodeNew.Text = "H03,C17"
            Case Else
                tbBugCodeNew.Text = ""
        End Select
    End Sub
End Class