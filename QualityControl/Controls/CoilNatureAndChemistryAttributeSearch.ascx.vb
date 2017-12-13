Public Class CoilNatureAndChemistryAttributeSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As QualityControlDataSet.CoilNatureAndChemistryAttributeSearchDataTable
        Dim ReturnValue As New QualityControlDataSet.CoilNatureAndChemistryAttributeSearchDataTable
        Dim AddRow As QualityControlDataSet.CoilNatureAndChemistryAttributeSearchRow = Nothing

        If String.IsNullOrEmpty(SQLString) OrElse SQLString.Trim.Length = 0 Then
            Return ReturnValue
        End If

        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

        Dim SQLStringAB As New StringBuilder
        SQLStringAB.Append("SELECT A.CIA55 S1 , A.CIA63 S2 ")
        SQLStringAB.Append("              ,A.CIA02 key1, left(B.bla07,5) key2 ")
        SQLStringAB.Append("              ,A.CIA05 || A.CIA36 V1,left(B.bla07,5) V2, B.bla07 V3, TRIM(A.CIA02) || TRIM(A.CIA03) V4 , A.CIA06 V5 , A.CIA07 V6 ")
        SQLStringAB.Append(SQLString)
        SQLStringAB.Append(" ORDER BY A.CIA05 ,left(B.bla07,5) , B.bla07 , TRIM(A.CIA02) || TRIM(A.CIA03)")

        Dim AdapterResultAB As List(Of DataRow) = (From A In Adapter.SelectQuery(SQLStringAB.ToString).Rows Select CType(A, DataRow)).ToList

        Dim SQLStringC As New StringBuilder
        SQLStringC.Append("SELECT C.qca01 Key2C,C.qca07 w1, C.qca08 w2, C.qca09 w3, C.qca10 w4, C.qca11 w5, C.qca12 w6, C.qca13 w7, C.qca14 w8, C.qca25 w9 ")
        SQLStringC.Append("FROM @#pps100lb.ppsqcapf C ")
        SQLStringC.Append("WHERE  C.qca01 IN( ")

        '   SQLStringC.Append("                 SELECT left(B.bla07,5) " & SQLString)
        'SQLStringC.Append("                  '" & SQLStringC_qca01 & "' " & SQLString)
        '------------------------------------------------------------------------------------------
        '1030514 by renhsin 
        '                AS400會出現不明原因錯誤，分開執行卻正常
        Dim SQLStringC_QueryTable As DataTable = Adapter.SelectQuery("                 SELECT left(B.bla07,5) " & SQLString)
        Dim SQLStringC_qca01 As String = ""

        For Each eachItem As DataRow In SQLStringC_QueryTable.Rows
            If SQLStringC_qca01 <> "" Then SQLStringC_qca01 &= ","
            SQLStringC_qca01 &= "'" & eachItem.Item(0).ToString & "'"
        Next
        If SQLStringC_qca01 = "" Then SQLStringC_qca01 &= " '' "
        SQLStringC.Append("                 " & SQLStringC_qca01 & " ")
        '------------------------------------------------------------------------------------------

        SQLStringC.Append(") ")
        Dim AdapterResultC As List(Of DataRow) = (From A In Adapter.SelectQuery(SQLStringC.ToString).Rows Select CType(A, DataRow)).ToList

        Dim SQLStringD As New StringBuilder
        SQLStringD.Append("SELECT D.qcg02 key1D, D.qcg11 x1, D.qcg12 x2, D.qcg13 x3, D.qcg14 x4, D.qcg28 x5 ")
        SQLStringD.Append("              , D.qcg01 x6, D.qcg04 x7, D.qcg05 x8 , D.qcg20 x9 ")
        SQLStringD.Append("FROM @#pps100lb.ppsqcgpf D ")
        SQLStringD.Append("WHERE  D.qcg05='T' AND D.qcg02 IN( ")
        SQLStringD.Append("                 SELECT A.CIA02 " & SQLString)
        SQLStringD.Append(") ")
        Dim AdapterResultD As List(Of DataRow) = (From A In Adapter.SelectQuery(SQLStringD.ToString).Rows Select CType(A, DataRow)).ToList

        For Each EachItemAB As DataRow In AdapterResultAB
            AddRow = ReturnValue.NewRow

            Dim EachItemC As List(Of DataRow) = (From C In AdapterResultC Where C.Item("KEY2C") = IIf(IsDBNull(EachItemAB.Item("KEY2")), "", EachItemAB.Item("KEY2")) Select CType(C, DataRow)).ToList
            Dim EachItemD As List(Of DataRow) = (From D In AdapterResultD Where D.Item("KEY1D") = IIf(IsDBNull(EachItemAB.Item("KEY1")), "", EachItemAB.Item("KEY1")) Select CType(D, DataRow)).ToList
            With AddRow

                .鋼種Type = EachItemAB.Item("V1")
                .爐號 = IIf(IsDBNull(EachItemAB.Item("V2")), "", EachItemAB.Item("V2"))
                .鋼胚號碼 = IIf(IsDBNull(EachItemAB.Item("V3")), "", EachItemAB.Item("V3"))
                .鋼捲號碼 = EachItemAB.Item("V4")
                .表面 = EachItemAB.Item("V5")
                .厚度 = EachItemAB.Item("V6")

                If Not (EachItemC Is Nothing) AndAlso EachItemC.Count > 0 Then
                    .C = DataFormatValue(EachItemC.Item(0).Item("W1"))
                    .Si = DataFormatValue(EachItemC.Item(0).Item("W2"))
                    .Mn = DataFormatValue(EachItemC.Item(0).Item("W3"))
                    .P = DataFormatValue(EachItemC.Item(0).Item("W4"))
                    .S = DataFormatValue(EachItemC.Item(0).Item("W5"))
                    .Cr = DataFormatValue(EachItemC.Item(0).Item("W6"))
                    .Ni = DataFormatValue(EachItemC.Item(0).Item("W7"))
                    .Cu = DataFormatValue(EachItemC.Item(0).Item("W8"))
                    .N = DataFormatValue(EachItemC.Item(0).Item("W9"))
                End If

                If Not (EachItemD Is Nothing) AndAlso EachItemD.Count > 0 Then
                    .YS = EachItemD.Item(0).Item("X1")
                    .TS = EachItemD.Item(0).Item("X2")
                    .Elongation = EachItemD.Item(0).Item("X3")
                    .HRB = EachItemD.Item(0).Item("X4")
                    .HV = EachItemD.Item(0).Item("X9")
                    .RP10 = EachItemD.Item(0).Item("X5")

                    .物理性能日期 = EachItemD.Item(0).Item("X6")
                    .物理性能線別 = EachItemD.Item(0).Item("X7")
                    .物理性能方向 = EachItemD.Item(0).Item("X8")
                End If
            End With
            ReturnValue.Rows.Add(AddRow)
        Next

        '報表最後面固定標題
        AddDaTtableTitle(ReturnValue, AddRow)

        Return ReturnValue
    End Function

    Private Function DataFormatValue(ByVal fromData As Object) As Object
        If IsNumeric(fromData) = True Then
            Return Format(fromData, "0.000")
        Else
            Return fromData
        End If
    End Function

    Private Sub AddDaTtableTitle(ByRef fromDataTable As DataTable, ByRef fromDataRow As QualityControlDataSet.CoilNatureAndChemistryAttributeSearchRow)
        '第一行:空白
        fromDataRow = fromDataTable.NewRow
        fromDataTable.Rows.Add(fromDataRow)

        '第二行:銷售規範(EN)
        fromDataRow = fromDataTable.NewRow
        AddDatatTitleLine(fromDataRow, "銷售規範(EN)", "≦0.07", "≦1.0", "≦2.00", "≦0.045", "≦0.015", "17.50~19.50", _
                                              "8.0~10.5", "----", "≦0.10", "≧230", "540~720", "≧45", "≦90", "≧260")
        fromDataTable.Rows.Add(fromDataRow)

        '第三行:空白
        fromDataRow = fromDataTable.NewRow
        fromDataTable.Rows.Add(fromDataRow)

        '第四行:銷售規範(others)
        fromDataRow = fromDataTable.NewRow
        AddDatatTitleLine(fromDataRow, "銷售規範(others)", "≦0.07", "≦0.75", "≦2.00", "≦0.040管", "≦0.015", "18.0~19.5", _
                                              "8.0~10.5", "----", "≦0.10", "≧205", "≧520", "≧40", "≦90", "")
        fromDataTable.Rows.Add(fromDataRow)

        '第五行:
        fromDataRow = fromDataTable.NewRow
        AddDatatTitleLine(fromDataRow, "≦0.045板")
        fromDataTable.Rows.Add(fromDataRow)
    End Sub

    Private Sub AddDatatTitleLine(ByRef fromDataRow As QualityControlDataSet.CoilNatureAndChemistryAttributeSearchRow, _
                                                          ByVal from鋼種 As String, _
                                                           ByVal fromC As String, ByVal fromSi As String, ByVal fromMn As String, _
                                                           ByVal fromP As String, ByVal fromS As String, ByVal fromCr As String, _
                                                           ByVal fromNi As String, ByVal fromCu As String, ByVal fromN As String, _
                                                           ByVal fromYS As String, ByVal fromTS As String, ByVal fromElongation As String, _
                                                           ByVal fromHRB As String, ByVal fromRP10 As String)
        fromDataRow.鋼種Type = from鋼種
        fromDataRow.C = fromC
        fromDataRow.Si = fromSi
        fromDataRow.Mn = fromMn
        fromDataRow.P = fromP
        fromDataRow.S = fromS
        fromDataRow.Cr = fromCr
        fromDataRow.Ni = fromNi
        fromDataRow.Cu = fromCu
        fromDataRow.N = fromN
        fromDataRow.YS = fromYS
        fromDataRow.TS = fromTS
        fromDataRow.Elongation = fromElongation
        fromDataRow.HRB = fromHRB
        fromDataRow.RP10 = fromRP10
    End Sub

    Private Sub AddDatatTitleLine(ByRef fromDataRow As QualityControlDataSet.CoilNatureAndChemistryAttributeSearchRow, ByVal fromP As String)
        fromDataRow.P = fromP
    End Sub

#End Region

#Region "控制項SQL條件產生器 方法:SQLMakerToControl"
    ''' <summary>
    ''' 控制項SQL條件產生器
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SQLMakerToControl()
        Dim ReurntWhereValue As New StringBuilder

        '提庫日期-繳庫日期小於等於1年(年要多加10000,ex:1020419-1010130=10289)
        ReurntWhereValue.Append(" FROM  @#pps100lb.ppsciapf A  ")
        ReurntWhereValue.Append("           LEFT JOIN @#pps100lB.ppsblapf B ON B.bla09=A.CIA02  AND (A.CIA63-B.BLA08) <=20000 ")
        ReurntWhereValue.Append("WHERE 1=1 ")

        ReurntWhereValue.Append(" AND left(A.cia02,1)<>'B' ")
        If Not String.IsNullOrEmpty(tbSteelKind1.Text) AndAlso tbSteelKind1.Text.Length > 0 Then
            tbSteelKind1.Text = tbSteelKind1.Text.Replace("'", Nothing)
            ReurntWhereValue.Append(" AND TRIM(A.CIA05)  IN ('" & tbSteelKind1.Text.Replace(",", "','") & "')")
        End If
        If Not String.IsNullOrEmpty(tbSteelKind2.Text) AndAlso tbSteelKind2.Text.Length > 0 Then
            tbSteelKind2.Text = tbSteelKind2.Text.Replace("'", Nothing)
            ReurntWhereValue.Append(" AND TRIM(A.CIA36) IN ('" & tbSteelKind2.Text.Replace(",", "','") & "')")
        End If

        If Not String.IsNullOrEmpty(tbNumbers.Text) Then
            tbNumbers.Text = tbNumbers.Text.Replace("'", Nothing)
            If tbNumbers.Text.Contains("~") Then
                ReurntWhereValue.Append(IIf(tbNumbers.Text.Trim.Length > 0, " AND left(B.bla07,5) >= '" & tbNumbers.Text.Split("~")(0).Trim & "' AND left(B.bla07,5) <= '" & tbNumbers.Text.Split("~")(1).Trim & "'", Nothing))
            Else
                ReurntWhereValue.Append(IIf(tbNumbers.Text.Trim.Length > 0, " AND left(B.bla07,5) IN ('" & tbNumbers.Text.Replace(",", "','") & "')", Nothing))
            End If
        End If

        If Not String.IsNullOrEmpty(tbCoilNumbers.Text) AndAlso tbCoilNumbers.Text.Length > 0 Then
            tbCoilNumbers.Text = tbCoilNumbers.Text.Replace("'", Nothing)
            ReurntWhereValue.Append(" AND TRIM(A.CIA02) || TRIM(A.CIA03)  IN ('" & tbCoilNumbers.Text.Replace(",", "','") & "')")
        End If

        If Not String.IsNullOrEmpty(tbCoiType.Text) AndAlso tbCoiType.Text.Length > 0 Then
            tbCoiType.Text = tbCoiType.Text.Replace("'", Nothing)
            ReurntWhereValue.Append(" AND A.CIA06 IN ('" & tbCoiType.Text.Replace(",", "','") & "')")
        End If

        If Not String.IsNullOrEmpty(tbStartThick.Text) OrElse Not String.IsNullOrEmpty(tbEndThick.Text) Then
            Dim StartThick As Single = IIf(String.IsNullOrEmpty(tbStartThick.Text), 0, Val(tbStartThick.Text))
            Dim EndThick As Single = IIf(String.IsNullOrEmpty(tbEndThick.Text), 99.99, Val(tbEndThick.Text))
            ReurntWhereValue.Append(" AND ( A.CIA07>=" & StartThick & " AND A.CIA07<=" & EndThick & ")")
        End If

        If CheckBox1.Checked = True Then
            ReurntWhereValue.Append(" AND ( 1=1")
            If Not String.IsNullOrEmpty(tbStartDate.Text) Then
                Dim startDate As String = New AS400DateConverter(tbStartDate.Text).TwSixCharsTypeData
                ReurntWhereValue.Append(" AND  (A.CIA55 >=" & startDate & " AND  A.CIA63 >=" & startDate & " )")
            End If
            If Not String.IsNullOrEmpty(tbEndDate.Text) Then
                Dim endDate As String = New AS400DateConverter(tbEndDate.Text).TwSixCharsTypeData
                ReurntWhereValue.Append(" AND  (A.CIA55 <=" & endDate & " AND A.CIA63 <=" & endDate & " )")
            End If
            ReurntWhereValue.Append("  )")
        End If

        Me.hfControlSQLMaker.Value = ReurntWhereValue.ToString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            btnClearSearchField_Click(Nothing, Nothing)
        End If
    End Sub


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        SQLMakerToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchDownExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchDownExcel.Click
        SQLMakerToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing

        Dim queryDataTable As DataTable = Search(Me.hfControlSQLMaker.Value)
        '標題列加上符號
        ModirecDataTableTilte(queryDataTable)

        ExcelConvert = New PublicClassLibrary.DataConvertExcel(queryDataTable, "鋼捲物理化學性能查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If
    End Sub

    Private Sub ModirecDataTableTilte(ByRef fromDataTable As DataTable)
        ModirecDataTableTilte(fromDataTable.Columns("厚度"), "厚度(mm)")
        ModirecDataTableTilte(fromDataTable.Columns("C"), "C%")
        ModirecDataTableTilte(fromDataTable.Columns("Si"), "Si%")
        ModirecDataTableTilte(fromDataTable.Columns("Mn"), "Mn%")
        ModirecDataTableTilte(fromDataTable.Columns("P"), "P%")
        ModirecDataTableTilte(fromDataTable.Columns("S"), "S%")
        ModirecDataTableTilte(fromDataTable.Columns("Cr"), "Cr%")
        ModirecDataTableTilte(fromDataTable.Columns("Ni"), "Ni%")
        ModirecDataTableTilte(fromDataTable.Columns("Cu"), "Cu%")
        ModirecDataTableTilte(fromDataTable.Columns("N"), "N%")
        ModirecDataTableTilte(fromDataTable.Columns("YS"), "YS(N/mm²)%")
        ModirecDataTableTilte(fromDataTable.Columns("TS"), "TS(N/mn2)%")
        ModirecDataTableTilte(fromDataTable.Columns("Elongation"), "Elongation%")
        ModirecDataTableTilte(fromDataTable.Columns("RP10"), "RP1.0%")
    End Sub

    Private Sub ModirecDataTableTilte(ByRef fromColumn As DataColumn, ByVal fromNewName As String)
        If Not fromColumn Is Nothing Then fromColumn.ColumnName = fromNewName
    End Sub

    Protected Sub btnClearSearchField_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearchField.Click
        tbStartThick.Text = "0.0"
        tbEndThick.Text = "99.9"

        tbSteelKind1.Text = ""
        tbSteelKind2.Text = ""
        tbNumbers.Text = ""
        tbCoilNumbers.Text = ""
        tbCoiType.Text = ""
        CheckBox1.Checked = True
        tbStartDate.Text = Format(DateAdd(DateInterval.Month, -1, Now), "yyyy/MM/01")
        tbEndDate.Text = Format(DateAdd(DateInterval.Day, -1, CDate(Format(Now, "yyyy/MM/01"))), "yyyy/MM/dd")
    End Sub
End Class