Public Class SQLServerStoveElementSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As QualityControlDataSet.SQLServerStoveElementSearchDataTableDataTable

        Dim ReturnValue As New QualityControlDataSet.SQLServerStoveElementSearchDataTableDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If
        Dim ShowTitleInfoKey As DataRow = Nothing

        Dim QryString As String = SQLString
        Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
        Dim AdapterResult As List(Of DataRow) = (From A In Adapter.SelectQuery(SQLString).Rows Select CType(A, DataRow)).ToList

        Dim NumberCount As Integer = 0
        Dim ADDItem As QualityControlDataSet.SQLServerStoveElementSearchDataTableRow = Nothing
        For Each EachItem As DataRow In AdapterResult
            Dim EachItemTemp As DataRow = EachItem
            ADDItem = ReturnValue.NewRow
            With ADDItem
                NumberCount += 1
                .序號 = NumberCount
                .爐號 = EachItem.Item("爐號")
                .鋼種 = EachItem.Item("鋼種")
                .材質 = EachItem.Item("材質")
                .日期 = EachItem.Item("日期")
                .DF = EachItem.Item("DF")
                .MD30 = EachItem.Item("MD30")
                .C = EachItem.Item("C")
                .SI = EachItem.Item("SI")
                .MN = EachItem.Item("MN")
                .P = EachItem.Item("P")
                .S = EachItem.Item("S")
                .CR = EachItem.Item("CR")
                .NI = EachItem.Item("NI")
                .CU = EachItem.Item("CU")
                .MO = EachItem.Item("MO")
                .CO = EachItem.Item("CO")
                .AL = EachItem.Item("AL")
                .SN = EachItem.Item("SN")
                .PB = EachItem.Item("PB")
                .TI = EachItem.Item("TI")
                .NB = EachItem.Item("NB")
                .V = EachItem.Item("V")
                .W = EachItem.Item("W")
                .O2 = EachItem.Item("O2")
                .N2 = EachItem.Item("N2")
                .H2 = EachItem.Item("H2")
                .B = EachItem.Item("B")
                .Ca = EachItem.Item("CA")
                .Mg = EachItem.Item("MG")
                .Fe = EachItem.Item("FE")
                .判定代碼 = EachItem.Item("判定")
                .驗收料 = EachItem.Item("驗收料")

                ._As = ModTools.NoNull(EachItem.Item("As"))
                .Bi = ModTools.NoNull(EachItem.Item("Bi"))
                .Sb = ModTools.NoNull(EachItem.Item("Sb"))
                .Zn = ModTools.NoNull(EachItem.Item("Zn"))
                .Zr = ModTools.NoNull(EachItem.Item("Zr"))
                .GP = ModTools.NoNull(EachItem.Item("GP"))
                .Ta = ModTools.NoNull(EachItem.Item("Ta"))
                .CAndN = Double.Parse(ModTools.NoNull(EachItem.Item("C"), 0)) + Double.Parse(ModTools.NoNull(EachItem.Item("N1"), 0))
                .NbAndTa = Double.Parse(ModTools.NoNull(EachItem.Item("Nb"), 0)) + Double.Parse(ModTools.NoNull(EachItem.Item("Ta"), 0))


                ShowTitleInfoKey = ADDItem
            End With
            ReturnValue.Rows.Add(ADDItem)
        Next
        AddJudgeRateData("Y1", AdapterResult, ReturnValue, "A")
        AddJudgeRateData("Y2", AdapterResult, ReturnValue, "A")
        AddJudgeRateData("N", AdapterResult, ReturnValue, "A")
        AddJudgeRateData("Y1", AdapterResult, ReturnValue, "B")
        AddJudgeRateData("Y2", AdapterResult, ReturnValue, "B")
        AddJudgeRateData("N", AdapterResult, ReturnValue, "B")
        AddJudgeRateData("Y1", AdapterResult, ReturnValue)
        AddJudgeRateData("Y2", AdapterResult, ReturnValue)
        AddJudgeRateData("N", AdapterResult, ReturnValue)

        Return ReturnValue
    End Function


    Private Sub AddJudgeRateData(ByVal JudgeCode As String, ByVal SourceData As List(Of DataRow), ByRef AddToDataTable As QualityControlDataSet.SQLServerStoveElementSearchDataTableDataTable, Optional ByVal SetABStoveKind As Char = " ")
        Dim ADDItem As QualityControlDataSet.SQLServerStoveElementSearchDataTableRow = AddToDataTable.NewRow
        If SetABStoveKind = " " Then
            ADDItem.爐號 = "全部爐"
            ADDItem.鋼種 = Format((From A In SourceData Where CType(A.Item("判定"), String).Trim = JudgeCode Select A).Count / SourceData.Count, "0.00%")
        Else
            ADDItem.爐號 = IIf(SetABStoveKind = "A", "A爐", "B爐")
            ADDItem.鋼種 = Format((From A In SourceData Where CType(A.Item("判定"), String).Trim = JudgeCode And CType(A.Item("爐號"), String).Trim Like SetABStoveKind & "*" Select A).Count / SourceData.Count, "0.00%")
        End If
        ADDItem.爐號 &= "判定" & JudgeCode & "比率:"
        AddToDataTable.Rows.Add(ADDItem)

    End Sub
#End Region

#Region "設定查詢條件至控制項 屬性:SetQryStringToControl"
    ''' <summary>
    ''' 設定查詢條件至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryStringToControl()
        'Dim IsFilterBatchNumber As Boolean = (Not String.IsNullOrEmpty(tbLotsNumbers.Text)) AndAlso tbLotsNumbers.Text.Trim.Length > 0
        Dim ReturnValue As String = "Select * From 分析資料 WHERE 站別 LIKE 'C%' "
        Dim WhereValue As String = Nothing

        If Not String.IsNullOrEmpty(tbSteelKind.Text) Then  '鋼種材質篩選
            tbSteelKind.Text = tbSteelKind.Text.Replace("'", Nothing)
            WhereValue &= IIf(tbSteelKind.Text.Trim.Length > 0, "  AND RTRIM(LTRIM(鋼種)) + RTRIM(LTRIM(材質)) IN ('" & tbSteelKind.Text.Replace(",", "','") & "')", Nothing)
        End If

        If Not String.IsNullOrEmpty(tbStove.Text) AndAlso tbStove.Text.Trim.Length > 0 Then
            Dim AddWhereString1 As String = Nothing
            Dim AddWhereString2 As String = Nothing
            For Each EachStoveRange As String In tbStove.Text.Trim.Split(",")
                If EachStoveRange.Contains("~") Then
                    AddWhereString1 &= IIf(String.IsNullOrEmpty(AddWhereString1), Nothing, " OR ")
                    AddWhereString1 &= " 爐號 >='" & EachStoveRange.Split("~")(0).Trim & "' AND 爐號 <='" & EachStoveRange.Split("~")(1).Trim & "' "
                Else
                    AddWhereString2 &= IIf(String.IsNullOrEmpty(AddWhereString2), Nothing, ",") & "'" & EachStoveRange.Trim & "'"
                End If
            Next
            Dim AddWhereString As String = Nothing
            AddWhereString &= AddWhereString1
            If Not String.IsNullOrEmpty(AddWhereString2) Then
                AddWhereString &= IIf(String.IsNullOrEmpty(AddWhereString), Nothing, " OR ") & " 爐號 IN (" & AddWhereString2 & ")"
            End If
            WhereValue &= " AND (" & AddWhereString & ")"
        End If


        For Each EachItem As ListItem In lbElements.Items   '成份篩選
            Dim Datas() As String = EachItem.Value.Split(":")
            WhereValue &= " AND " & Datas(0) & " >= " & Datas(1) & " AND " & Datas(0) & " <= " & Datas(2)
        Next

        If CheckBox1.Checked Then
            Dim StartDateValue As String = Format(CType(Me.tbStartDate.Text, Date), "yyyyMMdd HH:mm:ss")
            Dim EndDateValue As String = Format(CType(Me.tbEndDate.Text, Date), "yyyyMMdd HH:mm:ss")
            WhereValue &= " AND (RIGHT(STR(日期+19110000),8) +' ' + 時間) >= '" & StartDateValue & "' AND (RIGHT(STR(日期+19110000),8) +' ' + 時間) <= '" & EndDateValue & "'"
        End If
        If txDF1.Text.Trim <> "-999" OrElse txDF2.Text.Trim <> "999" Then
            WhereValue &= " AND DF>=" & txDF1.Text.Trim & " AND DF<=" & txDF2.Text.Trim
        End If
        If txMD301.Text.Trim <> "-999" OrElse txMD302.Text.Trim <> "999" Then
            WhereValue &= " AND MD30>=" & txMD301.Text.Trim & " AND MD30<=" & txMD302.Text.Trim
        End If
        If Not String.IsNullOrEmpty(TBJudge.Text) AndAlso TBJudge.Text.Trim.Length > 0 Then
            WhereValue &= " AND 判定 in ('" & TBJudge.Text.ToUpper.Trim.Replace(",", "','") & "')"

        End If

        If rbCheckMaterial.SelectedValue <> "ALL" Then
            WhereValue &= " AND 驗收料 = '" & rbCheckMaterial.SelectedValue & "' "
        End If


        Me.hfSQLString.Value = ReturnValue & WhereValue & " Order by 爐號,鋼種,材質,站別,序號"
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(New Date(Now.Year, Now.Month, 1), "yyyy/MM/dd")
            tbEndDate.Text = Format(New Date(Now.Year, Now.Month, 1).AddMonths(1), "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub tbSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Click
        SetQryStringToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnAddElement_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddElement.Click
        Try
            Dim AddItem As New ListItem
            AddItem.Text = DropDownList1.SelectedItem.Text & ":" & CType(tbElementStartValue.Text.Trim, Single).ToString & "~" & CType(tbElementEndValue.Text.Trim, Single).ToString
            AddItem.Value = DropDownList1.SelectedItem.Value & ":" & CType(tbElementStartValue.Text.Trim, Single).ToString & ":" & CType(tbElementEndValue.Text.Trim, Single).ToString
            lbElements.Items.Add(AddItem)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnDeleteElement_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteElement.Click
        If Not IsNothing(lbElements.SelectedItem) Then
            lbElements.Items.Remove(lbElements.SelectedItem)
        End If
    End Sub

    Protected Sub tbClearSearchCondiction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbClearSearchCondiction.Click
        tbStove.Text = Nothing
        Call btnDeleteElement_Click(Nothing, Nothing)
    End Sub

    Protected Sub btnSearchDownExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchDownExcel.Click
        SetQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfSQLString.Value), "SQLServer爐號成份查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub
End Class