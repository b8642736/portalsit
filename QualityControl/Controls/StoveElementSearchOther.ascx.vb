Public Class StoveElementSearchOther
    Inherits System.Web.UI.UserControl

    Const 委驗Stove = "ET"
    Enum AnalysisMode_num
        外購鋼捲 = 2
        委驗 = 3
    End Enum

    Private Function shWebAnalysisMode() As AnalysisMode_num

        Select Case ddMode.SelectedValue
            Case "外購鋼捲"
                shWebAnalysisMode = AnalysisMode_num.外購鋼捲
            Case "委驗"
                shWebAnalysisMode = AnalysisMode_num.委驗
        End Select

    End Function

    Public Function GetShowTitle1(ByVal fromAnalysisMode As AnalysisMode_num) As String
        Dim RetText As String = ""
        Select Case fromAnalysisMode
            Case AnalysisMode_num.外購鋼捲
                RetText = "批號"
            Case AnalysisMode_num.委驗
                RetText = "TYPE"
        End Select
        Return RetText
    End Function

    Public Function GetShowTitle2(ByVal fromAnalysisMode As AnalysisMode_num) As String
        Dim RetText As String = ""

        Select Case fromAnalysisMode
            Case AnalysisMode_num.外購鋼捲
                RetText = "鋼捲"
            Case AnalysisMode_num.委驗
                RetText = "委託單號"
        End Select

        Return RetText
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(New Date(Now.Year, Now.Month, 1), "yyyy/MM/dd")
            tbEndDate.Text = Format(New Date(Now.Year, Now.Month, 1).AddMonths(1), "yyyy/MM/dd")

            ddMode_SelectedIndexChanged(ddMode, Nothing)
        End If
    End Sub

    Protected Sub ddMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddMode.SelectedIndexChanged
        Dim showLotsNo As Boolean
        Dim showBuildUpNo As Boolean
        Dim showLabNo As Boolean

        Select Case shWebAnalysisMode()
            Case AnalysisMode_num.外購鋼捲
                showLotsNo = True
                showBuildUpNo = True
                showLabNo = False

            Case AnalysisMode_num.委驗
                showLotsNo = False
                showBuildUpNo = False
                showLabNo = True
        End Select

        lbLotsNo.Visible = showLotsNo
        lbLotsNoMsg.Visible = showLotsNo
        tbLotsNo.Visible = showLotsNo
        lbBuildUpNo.Visible = showBuildUpNo
        lbBuildUpNoMsg.Visible = showBuildUpNo
        tbBuildUpNo.Visible = showBuildUpNo
        lbLabNo.Visible = showLabNo
        lbLabNoMsg.Visible = showLabNo
        tbLabNo.Visible = showLabNo

    End Sub

    Protected Sub tbSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Click
        MakeQryStringToControl()
        GridView1.DataBind()
    End Sub
    Protected Sub btnSearchDownExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchDownExcel.Click
        MakeQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing

        Dim QueryDataTable As DataTable = Search(Me.hfSQLString.Value)

        QueryDataTable.Columns(1).ColumnName = GetShowTitle1(shWebAnalysisMode)
        QueryDataTable.Columns(2).ColumnName = GetShowTitle2(shWebAnalysisMode)
        If shWebAnalysisMode() = AnalysisMode_num.委驗 Then
            QueryDataTable.Columns.Remove(QueryDataTable.Columns(1))
        End If

        ExcelConvert = New PublicClassLibrary.DataConvertExcel(QueryDataTable, "外購與委驗成份查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub

#Region "設定查詢條件至控制項 屬性:SetQryStringToControl"
    ''' <summary>
    ''' 設定查詢條件至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryStringToControl()
        Dim SQL As New StringBuilder
        Dim SearchMode As String = ""
        Dim SearchKey1 As String = ""
        Dim SearchKey2 As String = ""

        Select Case shWebAnalysisMode()
            Case AnalysisMode_num.外購鋼捲
                SearchMode = "<>"
                SearchKey1 = tbLotsNo.Text
                SearchKey2 = tbBuildUpNo.Text
            Case AnalysisMode_num.委驗
                SearchMode = "="
                SearchKey1 = 委驗Stove
                SearchKey2 = tbLabNo.Text
        End Select

        SQL.Append("SELECT A.* FROM @#PPS100LB.PPSQCIPF2 A WHERE 1=1 " & vbNewLine)
        SQL.Append(" AND QCA01A " & SearchMode & " '" & 委驗Stove & "' " & vbNewLine)
        SQL.Append(MakeQryStringWhere(SearchKey1, "QCA01A"))
        SQL.Append(MakeQryStringWhere(SearchKey2, "QCA01B"))

        If Not String.IsNullOrEmpty(tbSteelKind.Text) Then  '鋼種材質篩選
            tbSteelKind.Text = tbSteelKind.Text.Replace("'", Nothing)
            SQL.Append(IIf(tbSteelKind.Text.Trim.Length > 0, "  AND (RTRIM(A.QCA05) || A.QCA06) IN ('" & tbSteelKind.Text.Replace(",", "','") & "')", Nothing))
        End If

        If CheckBox1.Checked Then
            Dim StartDateTime As DateTime = CType(Me.tbStartDate.Text, Date).AddHours(Val(tbStartHour.Text)).AddMinutes(Val(tbStartMinute.Text))
            Dim EndDateTime As DateTime = CType(Me.tbEndDate.Text, Date).AddHours(Val(tbEndHour.Text)).AddMinutes(Val(tbEndMinute.Text))
            Dim StartDateValue As Integer = (Format(StartDateTime.AddDays(1), "yyyy") - 1911) * 10000 + Format(StartDateTime.AddDays(1), "MMdd")
            Dim EndDateValue As Integer = (Format(EndDateTime.AddDays(-1), "yyyy") - 1911) * 10000 + Format(EndDateTime.AddDays(-1), "MMdd")
            SQL.Append(" AND ( " & vbNewLine)
            SQL.Append(" QCA02>=" & StartDateValue & " AND QCA02<=" & EndDateValue & vbNewLine)

            StartDateValue = (Format(StartDateTime, "yyyy") - 1911) * 10000 + Format(StartDateTime, "MMdd")
            EndDateValue = (Format(EndDateTime, "yyyy") - 1911) * 10000 + Format(EndDateTime, "MMdd")
            SQL.Append(" OR (QCA02=" & StartDateValue & " AND (QCA03*100+QCA04)>=" & StartDateTime.Hour * 100 + StartDateTime.Minute & ")" & vbNewLine)
            SQL.Append(" OR (QCA02=" & EndDateValue & " AND (QCA03*100+QCA04)<=" & EndDateTime.Hour * 100 + EndDateTime.Minute & ")" & vbNewLine)
            SQL.Append(" ) ")
        End If

        SQL.Append(" ORDER BY A.QCA01A,A.QCA01B" & vbNewLine)
        Me.hfSQLString.Value = SQL.ToString
    End Sub

    Public Function MakeQryStringWhere(ByVal fromInputText As String, ByVal fromDBColumn As String) As String
        Dim RetSQL As String = ""

        Dim AddWhereString As String = ""
        Dim AddWhereString1 As String = Nothing
        Dim AddWhereString2 As String = Nothing

        If Not String.IsNullOrEmpty(fromInputText) AndAlso fromInputText.Trim.Length > 0 Then
            For Each EachStoveRange As String In fromInputText.Trim.Split(",")
                If EachStoveRange.Contains("~") Then
                    AddWhereString1 &= IIf(String.IsNullOrEmpty(AddWhereString1), Nothing, " OR ")
                    AddWhereString1 &= " " & fromDBColumn & ">='" & EachStoveRange.Split("~")(0).Trim & "' AND " & fromDBColumn & "<='" & EachStoveRange.Split("~")(1).Trim & "' "
                Else
                    AddWhereString2 &= IIf(String.IsNullOrEmpty(AddWhereString2), Nothing, ",") & "'" & EachStoveRange.Trim & "'"
                End If
            Next

            AddWhereString &= AddWhereString1
            If Not String.IsNullOrEmpty(AddWhereString2) Then
                AddWhereString &= IIf(String.IsNullOrEmpty(AddWhereString), Nothing, " OR ") & " " & fromDBColumn & " IN (" & AddWhereString2 & ")"
            End If

        End If
        RetSQL = IIf(AddWhereString = "", Nothing, " AND (" & AddWhereString & ")")
        Return RetSQL
    End Function
#End Region

#Region "查詢 方法:Search"

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As QualityControlDataSet.StoveElementSearchOtherDataTableDataTable
        Dim AddItem As QualityControlDataSet.StoveElementSearchOtherDataTableRow = Nothing
        Dim ReturnValue As New QualityControlDataSet.StoveElementSearchOtherDataTableDataTable

        If String.IsNullOrEmpty(SQLString) = True Then
            Return ReturnValue
        End If

        Dim NumberCount As Integer = 0
        Dim QueryList As List(Of PPS100LB.PPSQCIPF2) = ORMBaseClass.ClassDBAS400.CDBSelect(Of PPS100LB.PPSQCIPF2)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each eachItem As PPS100LB.PPSQCIPF2 In QueryList
            AddItem = ReturnValue.NewRow
            With AddItem
                NumberCount += 1
                .序號 = NumberCount
                .Title1 = eachItem.QCA01A
                .Title2 = eachItem.QCA01B
                .鋼種 = eachItem.QCA05
                .材質 = eachItem.QCA06
                .日期 = eachItem.QCA02
                .C = eachItem.QCA07
                .SI = eachItem.QCA08
                .MN = eachItem.QCA09
                .P = eachItem.QCA10
                .S = eachItem.QCA11
                .CR = eachItem.QCA12
                .NI = eachItem.QCA13
                .CU = eachItem.QCA14
                .MO = eachItem.QCA15
                .CO = eachItem.QCA16
                .AL = eachItem.QCA17
                .SN = eachItem.QCA18
                .PB = eachItem.QCA19
                .TI = eachItem.QCA20
                .NB = eachItem.QCA21
                .V = eachItem.QCA22
                .N2 = eachItem.QCA25
                .Fe = eachItem.QCA30
            End With

            ReturnValue.Rows.Add(AddItem)
        Next

        GetDataTableStatic(ReturnValue)
        Return ReturnValue
    End Function

    Private Sub GetDataTableStatic(ByRef fromDataTable As QualityControlDataSet.StoveElementSearchOtherDataTableDataTable)
        If fromDataTable.Rows.Count = 0 Then Exit Sub

        Dim AddItemMin As DataRow = fromDataTable.NewRow
        Dim AddItemMax As DataRow = fromDataTable.NewRow
        Dim AddItemAvg As DataRow = fromDataTable.NewRow

        For Each eachItem As DataColumn In fromDataTable.Columns
            Dim columnName As String = eachItem.ColumnName

            Select Case columnName
                Case "序號", "Title1", "Title2", "鋼種", "材質"
                Case "日期"
                    AddItemMin.Item(columnName) = "Min"
                    AddItemMax.Item(columnName) = "Max"
                    AddItemAvg.Item(columnName) = "Avg"
                Case Else
                    AddItemMin.Item(columnName) = (From A In fromDataTable Order By A.Item(columnName) Ascending Select A.Item(columnName)).FirstOrDefault
                    AddItemMax.Item(columnName) = (From A In fromDataTable Order By A.Item(columnName) Descending Select A.Item(columnName)).FirstOrDefault
                    AddItemAvg.Item(columnName) = (From A In fromDataTable Select A.Item(columnName)).Average(Function(a) Double.Parse(a)).ToString("#0.000")

            End Select
        Next

        fromDataTable.Rows.Add(AddItemMin)
        fromDataTable.Rows.Add(AddItemMax)
        fromDataTable.Rows.Add(AddItemAvg)
    End Sub
#End Region



    Private Sub GridView1_DataBound(sender As Object, e As EventArgs) Handles GridView1.DataBound
        Dim gridObj As GridView = CType(sender, GridView)

        With gridObj
            .Columns(1).HeaderText = GetShowTitle1(shWebAnalysisMode)
            .Columns(2).HeaderText = GetShowTitle2(shWebAnalysisMode)
            .Columns(1).Visible = (shWebAnalysisMode() = AnalysisMode_num.外購鋼捲)
        End With

    End Sub
End Class