Public Class InspectionSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String, ByVal FilterCoilNumber As String, ByVal FilterHeat As String, ByVal FilterFinish As String, ByVal FilterGrade As String) As QualityControlDataSet.InspectionSearchDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New QualityControlDataSet.InspectionSearchDataTable
        End If
        Dim ReturnValue As New QualityControlDataSet.InspectionSearchDataTable
        Dim NumberCount As Integer = 0
        Dim OrderNumberOutToCuntry As New Dictionary(Of String, String)
        Dim DBSearchResult As List(Of DataRow) = (From A In New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString).SelectQuery Select A).ToList
        Dim SearchResult As New List(Of PPS100LB.PPSQCDPY) '= CompanyORMDB.PPS100LB.PPSQCDPY.CDBSelect(Of PPS100LB.PPSQCDPY)(SQLString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EachItem As DataRow In DBSearchResult
            Dim AddItem As New PPS100LB.PPSQCDPY
            AddItem.CDBSetDataRowValueToObject(EachItem)
            SearchResult.Add(AddItem)
            If Not OrderNumberOutToCuntry.ContainsKey(AddItem.QCD03.Trim) Then
                OrderNumberOutToCuntry.Add(AddItem.QCD03.Trim, PublicClassLibrary.ModTools.NoNull(EachItem.Item("CII03")))
            End If
        Next
        BatchSetAboutPPSCIAPFToPPSQCDPY_DetailItemClass(SearchResult, FilterCoilNumber, FilterHeat, FilterFinish, FilterGrade)
        For Each EachItem As PPS100LB.PPSQCDPY In SearchResult
            Dim DetailFilterDatas As List(Of CompanyORMDB.PPS100LB.PPSQCDPY.DetailItemClass) = EachItem.InspectionDetailItems.ToList
            If Not String.IsNullOrEmpty(FilterCoilNumber) Then
                DetailFilterDatas = (From A In DetailFilterDatas Where FilterCoilNumber.Contains(A.CoilFullNumber.Trim) Select A).ToList
            End If
            If Not String.IsNullOrEmpty(FilterHeat) Then
                DetailFilterDatas = (From A In DetailFilterDatas Where FilterHeat.Contains(A.HeatNumber.Trim) Select A).ToList
            End If
            If Not String.IsNullOrEmpty(FilterFinish) Then
                DetailFilterDatas = (From A In DetailFilterDatas Where FilterFinish.Contains(A.FINISH.Trim) Select A).ToList
            End If
            If Not String.IsNullOrEmpty(FilterGrade) Then
                DetailFilterDatas = (From A In DetailFilterDatas Where FilterGrade.Contains(A.GRADE.Trim) Select A).ToList
            End If
            For Each EachInspectionItem As CompanyORMDB.PPS100LB.PPSQCDPY.DetailItemClass In DetailFilterDatas
                Dim AddItem As QualityControlDataSet.InspectionSearchRow = ReturnValue.NewRow
                With AddItem
                    .訂單編號 = EachInspectionItem.OrderNumber
                    .本單編號 = EachInspectionItem.ThisPageNumber
                    .產品編號 = EachInspectionItem.CoilFullNumber
                    .爐號 = EachInspectionItem.HeatNumber
                    .產品型態 = EachInspectionItem.ProductForm
                    .鋼種 = EachInspectionItem.GRADE
                    .表面 = EachInspectionItem.FINISH
                    .料別 = EachInspectionItem.MaterialType
                    .產品尺寸 = EachInspectionItem.SIZE
                    .淨重 = EachInspectionItem.Weight
                    .參照規範 = EachInspectionItem.Specification
                    .成份C = EachInspectionItem.ElementC
                    .成份Si = EachInspectionItem.ElementSi
                    .成份Mn = EachInspectionItem.ElementMn
                    .成份P = EachInspectionItem.ElementP
                    .成份S = EachInspectionItem.ElementS
                    .成份Cr = EachInspectionItem.ElementCr
                    .成份Ni = EachInspectionItem.ElementNi
                    .成份N = EachInspectionItem.ElementN
                    .成份Cu = EachInspectionItem.ElementCu
                    .抗拉強度 = EachInspectionItem.TS
                    .降伏強度 = EachInspectionItem.YS
                    .伸長率 = EachInspectionItem.Elong
                    .硬度 = EachInspectionItem.HRB
                    .Rp = EachInspectionItem.Rp
                    If .料別.PadRight(1).Substring(0, 1) = "X" AndAlso OrderNumberOutToCuntry.ContainsKey(.訂單編號) Then
                        .出口國別 = OrderNumberOutToCuntry.Item(.訂單編號)
                    End If
                End With
                ReturnValue.Rows.Add(AddItem)
            Next
        Next
        Return ReturnValue
    End Function

    '批次設設相關PPSCIAPF給PPSQCDPY_DetailItemClass類別以增加速度
    Private Sub BatchSetAboutPPSCIAPFToPPSQCDPY_DetailItemClass(ByVal SourceData As List(Of PPS100LB.PPSQCDPY), ByVal FilterCoilNumber As String, ByVal FilterHeat As String, ByVal FilterFinish As String, ByVal FilterGrade As String)
        Dim FindAllKeys As New StringBuilder     '一般鋼捲      PPSQCDPY.QCD05  <> 'SLAB'
        Dim FindAllKeys2 As New StringBuilder   '鋼胚             PPSQCDPY.QCD05  = 'SLAB'
        Dim ALLDetailFilterDatas As New List(Of PPS100LB.PPSQCDPY.DetailItemClass)
        For Each EachItem As PPS100LB.PPSQCDPY In SourceData
            Dim DetailFilterDatas As List(Of CompanyORMDB.PPS100LB.PPSQCDPY.DetailItemClass) = EachItem.InspectionDetailItems.ToList
            If Not String.IsNullOrEmpty(FilterCoilNumber) Then
                DetailFilterDatas = (From A In DetailFilterDatas Where FilterCoilNumber.Contains(A.CoilFullNumber.Trim) Select A).ToList
            End If
            If Not String.IsNullOrEmpty(FilterHeat) Then
                DetailFilterDatas = (From A In DetailFilterDatas Where FilterHeat.Contains(A.HeatNumber.Trim) Select A).ToList
            End If
            If Not String.IsNullOrEmpty(FilterFinish) Then
                DetailFilterDatas = (From A In DetailFilterDatas Where FilterFinish.Contains(A.FINISH.Trim) Select A).ToList
            End If
            If Not String.IsNullOrEmpty(FilterGrade) Then
                DetailFilterDatas = (From A In DetailFilterDatas Where FilterGrade.Contains(A.GRADE.Trim) Select A).ToList
            End If
            For Each EachInspectionItem As CompanyORMDB.PPS100LB.PPSQCDPY.DetailItemClass In DetailFilterDatas
                ALLDetailFilterDatas.Add(EachInspectionItem)
                If Not String.IsNullOrEmpty(FindAllKeys.ToString) Then
                    FindAllKeys.Append(",")
                    FindAllKeys2.Append(",")
                End If
                FindAllKeys.Append(EachInspectionItem.CoilFullNumber.Trim & EachInspectionItem.OrderNumber.Trim)
                FindAllKeys2.Append(EachInspectionItem.CoilFullNumber.Trim)
            Next            
        Next

        '一般鋼捲
        Dim Qry As String = "Select * from @#pps100lb.ppsciapf  where (rtrim(cia02 || cia03) || cia04) in ('" & FindAllKeys.ToString.Replace(",", "','") & "')"
        Dim SearchResult As List(Of PPS100LB.PPSCIAPF) = PPS100LB.PPSCIAPF.CDBSelect(Of PPS100LB.PPSCIAPF)(Qry, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

        For Each EachItem In ALLDetailFilterDatas
            Dim FindAboutPPSCIAPF = (From A In SearchResult Where A.CIA02 & A.CIA03.Trim & A.CIA04 = EachItem.CoilFullNumber.Trim & EachItem.OrderNumber Select A).FirstOrDefault
            If Not IsNothing(FindAboutPPSCIAPF) Then
                '一般鋼捲
                EachItem.AboutPPSCIAPF = FindAboutPPSCIAPF

            Else
                '鋼捲
                '--------------------------------------------------------------------------------
                Dim Qry2 As String = "Select * from @#SLS300LB.SL2Z01PF  where rtrim(BLT01 || BLT02) in ('" & FindAllKeys2.ToString.Replace(",", "','") & "')"
                Dim SearchResult2 As List(Of SLS300LB.SL2Z01PF) = SLS300LB.SL2Z01PF.CDBSelect(Of SLS300LB.SL2Z01PF)(Qry2, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                Dim FindAboutSL2Z01PF = (From A As SLS300LB.SL2Z01PF In SearchResult2 Where A.BLT01.Trim & A.BLT02.Trim = EachItem.CoilFullNumber.Trim Select A).FirstOrDefault
                If Not IsNothing(FindAboutSL2Z01PF) Then
                    EachItem.AboutSL2Z01PF = FindAboutSL2Z01PF
                End If
                '--------------------------------------------------------------------------------
            End If

        Next
    End Sub

#End Region

#Region "控制項SQL條件產生器 方法:SQLMakerToControl"
    ''' <summary>
    ''' 控制項SQL條件產生器
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SQLMakerToControl()
        Dim ReturnValue As New StringBuilder
        'ReturnValue.Append("Select A.*,COALESCE(C.CII03 ,B.BOL31) CII03 from @#PPS100LB.PPSQCDPY A LEFT JOIN @#SLS300LB.SL2BOLPF B ON A.QCD03=B.BOL03 LEFT JOIN @#SLS300LB.SL2CIIPF C ON B.BOL31= C.CII01 WHERE 1=1 ")
        ReturnValue.Append("Select A.*,COALESCE(C.CII03 ,B.BOL31) CII03  " & vbNewLine)
        ReturnValue.Append("FROM @#PPS100LB.PPSQCDPY A " & vbNewLine)
        ReturnValue.Append("         LEFT JOIN @#SLS300LB.SL2BOLPF B ON A.QCD03=B.BOL03 " & vbNewLine)
        ReturnValue.Append("         LEFT JOIN @#SLS300LB.SL2CIIPF C ON B.BOL31= C.CII01 " & vbNewLine)
        ReturnValue.Append("WHERE 1=1 " & vbNewLine)

        If CheckBox1.Checked Then
            '日期篩選
            Dim StartDate As Integer = New CompanyORMDB.AS400DateConverter(Me.tbStartDate.Text).TwIntegerTypeData
            Dim EndDate As Integer = New CompanyORMDB.AS400DateConverter(Me.tbEndDate.Text).TwIntegerTypeData

            'ReturnValue.Append(" AND LEFT(QCD01,7) >='" & StartDate & "' AND LEFT(QCD01,7)<='" & EndDate & "'")
            '1041015 by renhsin, 一般鋼捲、榮鋼
            ReturnValue.Append(" AND CASE " & vbNewLine)
            ReturnValue.Append("                WHEN SUBSTR(qcd01,1,1) IN ('0','1','2','3','4','5','6','7','8','9') THEN  SUBSTR(qcd01,1,7) " & vbNewLine)
            ReturnValue.Append("                ELSE SUBSTR(qcd01,2,5) || '01' " & vbNewLine)
            ReturnValue.Append("            END >='" & StartDate & "' " & vbNewLine)

            ReturnValue.Append(" AND CASE " & vbNewLine)
            ReturnValue.Append("                WHEN SUBSTR(qcd01,1,1) IN ('0','1','2','3','4','5','6','7','8','9') THEN  SUBSTR(qcd01,1,7) " & vbNewLine)
            ReturnValue.Append("                ELSE SUBSTR(qcd01,2,5) || '01' " & vbNewLine)
            ReturnValue.Append("            END <='" & EndDate & "' " & vbNewLine)
        End If

        If Not String.IsNullOrEmpty(tbCoilNumber.Text) Then
            ReturnValue.Append(" AND ("& vbNewLine)
            For ArrayCount As Integer = 1 To 7
                ReturnValue.Append(IIf(ArrayCount > 1, " OR ", Nothing))
                ReturnValue.Append(" RTRIM(QCD" & ArrayCount & "5 || QCD" & ArrayCount & "6) IN ('" & tbCoilNumber.Text.Replace(",", "','") & "')" & vbNewLine)
            Next
            ReturnValue.Append(")" & vbNewLine)
        End If

        If Not String.IsNullOrEmpty(tbFace.Text) Then
            ReturnValue.Append(" AND (" & vbNewLine)
            For ArrayCount As Integer = 0 To 6
                ReturnValue.Append(IIf(ArrayCount > 0, " OR ", Nothing))
                ReturnValue.Append(" QCD" & ArrayCount & "9X IN ('" & tbFace.Text.Replace(",", "','") & "')" & vbNewLine)
            Next
            ReturnValue.Append(")" & vbNewLine)
        End If
        If Not String.IsNullOrEmpty(tbSteelKind.Text) Then
            ReturnValue.Append(" AND (" & vbNewLine)
            For ArrayCount As Integer = 0 To 6
                ReturnValue.Append(IIf(ArrayCount > 0, " OR ", Nothing))
                ReturnValue.Append(" QCD" & ArrayCount & "8X IN ('" & tbSteelKind.Text.Replace(",", "','") & "')" & vbNewLine)
            Next
            ReturnValue.Append(")" & vbNewLine)
        End If
        If Not String.IsNullOrEmpty(tbStoveNumber.Text) Then
            ReturnValue.Append(" AND (" & vbNewLine)
            For ArrayCount As Integer = 1 To 7
                ReturnValue.Append(IIf(ArrayCount > 1, " OR ", Nothing))
                ReturnValue.Append(" QCD" & ArrayCount & "4 IN ('" & tbStoveNumber.Text.Replace(",", "','") & "')" & vbNewLine)
            Next
            ReturnValue.Append(")" & vbNewLine)
        End If
        If Not String.IsNullOrEmpty(tbSpec.Text) Then
            ReturnValue.Append(" AND QCD0D IN ('" & tbSpec.Text.Replace(",", "','") & "')" & vbNewLine)
        End If
        If Not String.IsNullOrEmpty(tbOrderNumber.Text) Then
            ReturnValue.Append(" AND QCD03 IN ('" & tbOrderNumber.Text.Replace(",", "','") & "')" & vbNewLine)
        End If

        If RadioButtonList1.SelectedValue <> "ALL" Then
            '內外銷篩選
            ReturnValue.Append(" AND QCD03 IN (Select CIA04 From @#PPS100LB.PPSCIAPF WHERE CIA34='" & IIf(RadioButtonList1.SelectedValue = "X", "X", " ") & "')" & vbNewLine)
        End If

        Me.hfQryString.Value = ReturnValue.ToString & vbNewLine & " UNION " & vbNewLine & ReturnValue.ToString.Replace("@#PPS100LB.PPSQCDPY", "@#PPS100LB.PPSQCDPY.HISTORY")
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now.AddMonths(-1), "yyyy/MM/01")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SQLMakerToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        SQLMakerToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfQryString.Value, tbCoilNumber.Text, tbStoveNumber.Text, tbFace.Text, tbSteelKind.Text), "檢驗證明書查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

End Class