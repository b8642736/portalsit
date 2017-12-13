Public Class StoveElementOutBuySearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String, ByVal DFAndMD30Range As String) As QualityControlDataSet.StoveElementOutBuySearchDataTable
        If String.IsNullOrEmpty(SQLString) OrElse SQLString.Trim.Length = 0 Then
            Return New QualityControlDataSet.StoveElementOutBuySearchDataTable
        End If

        Dim ReturnValue As New QualityControlDataSet.StoveElementOutBuySearchDataTable
        Dim ShowTitleInfoKey As DataRow = Nothing

        Dim QryString As String = SQLString
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
        Dim AdapterResult As List(Of DataRow) = (From A In Adapter.SelectQuery.Rows Select CType(A, DataRow)).ToList

        Dim DFAndMD30s As List(Of Single) = (From A In DFAndMD30Range.Split(",") Select CType(A, Single)).ToList
        If DFAndMD30s(0) <> -999 OrElse DFAndMD30s(1) <> 999 Then   'DF篩選
            AdapterResult = (From A In AdapterResult Where (CType(A.Item("QCI05"), String).Substring(0, 1) = "2" And CType(A.Item("DF_2"), Single) >= DFAndMD30s(0) And CType(A.Item("DF_2"), Single) <= DFAndMD30s(1)) Or CType(A.Item("QCI05"), String).Substring(0, 1) = "3" Select A).ToList
            AdapterResult = (From A In AdapterResult Where (CType(A.Item("QCI05"), String).Substring(0, 1) = "3" And CType(A.Item("DF_3"), Single) >= DFAndMD30s(0) And CType(A.Item("DF_3"), Single) <= DFAndMD30s(1)) Or CType(A.Item("QCI05"), String).Substring(0, 1) = "2" Select A).ToList
        End If
        If DFAndMD30s(2) <> -999 OrElse DFAndMD30s(3) <> 999 Then   'MD30篩選
            AdapterResult = (From A In AdapterResult Where CType(A.Item("MD30"), Single) >= DFAndMD30s(2) And CType(A.Item("MD30"), Single) <= DFAndMD30s(3) Select A).ToList
        End If

        Dim NumberCount As Integer = 0
        Dim ADDItem As QualityControlDataSet.StoveElementOutBuySearchRow = Nothing
        For Each EachItem As DataRow In AdapterResult
            Dim EachItemTemp As DataRow = EachItem
            ADDItem = ReturnValue.NewRow
            With ADDItem
                NumberCount += 1
                .序號 = NumberCount
                .批號 = EachItem.Item("QCI40")
                .爐號 = EachItem.Item("QCI01")
                .鋼種 = EachItem.Item("QCI05")
                .材質 = EachItem.Item("QCI06")
                .日期 = EachItem.Item("QCI02")
                .DF = IIf(CType(EachItem.Item("QCI05"), String).Substring(0, 1) = "2", EachItem.Item("DF_2"), EachItem.Item("DF_3"))
                .MD30 = EachItem.Item("MD30")
                .C = EachItem.Item("QCI07")
                .SI = EachItem.Item("QCI08")
                .MN = EachItem.Item("QCI09")
                .P = EachItem.Item("QCI10")
                .S = EachItem.Item("QCI11")
                .CR = EachItem.Item("QCI12")
                .NI = EachItem.Item("QCI13")
                .CU = EachItem.Item("QCI14")
                .MO = EachItem.Item("QCI15")
                .CO = EachItem.Item("QCI16")
                .AL = EachItem.Item("QCI17")
                .SN = EachItem.Item("QCI18")
                .PB = EachItem.Item("QCI19")
                .TI = EachItem.Item("QCI20")
                .NB = EachItem.Item("QCI21")
                .V = EachItem.Item("QCI22")
                .W = EachItem.Item("QCI23")
                .O2 = EachItem.Item("QCI24")
                .N2 = EachItem.Item("QCI25")
                .H2 = EachItem.Item("QCI26")
                .B = EachItem.Item("QCI27")
                '.Ca = EachItem.Item("QCI28") / 100
                '.Mg = EachItem.Item("QCI29") / 100
                '.Fe = EachItem.Item("QCI30")
                ShowTitleInfoKey = ADDItem
            End With
            ReturnValue.Rows.Add(ADDItem)
        Next

        Return ReturnValue
    End Function
#End Region


#Region "設定查詢條件至控制項 屬性:SetQryStringToControl"
    ''' <summary>
    ''' 設定查詢條件至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryStringToControl()
        Dim ReturnValue As String = Nothing
        Dim WhereValue As String = Nothing
        ReturnValue = "Select A.* " & _
                    ",3.66 * A.QCI12 + 5.64 * A.QCI08 + 0.84 * A.QCI15 - 75.78 * A.QCI07 - 71.62 * A.QCI25 - 2.87 * A.QCI13 - 0.16 * A.QCI09 - 0.08 * A.QCI14 - 36.63 AS DF_2" & _
                    ",3 * A.QCI12 + 4.5 * A.QCI08 + 3 * A.QCI15 - 2.8 * A.QCI13 - 84 * (A.QCI07 + A.QCI25) - 1.4 * (A.QCI09 + A.QCI14) - 19.8 AS DF_3" & _
                    ",413 - (A.QCI07 + A.QCI25) * 462 - 9.2 * A.QCI08 - 8.1 * A.QCI09 - 13.7 * A.QCI12 - 9.5 * A.QCI13 - 18.5 * A.QCI15 AS MD30 " & _
                    " From  @#PPS100LB.PPSQCIPF A "
        WhereValue &= " WHERE 1=1 "

        '篩選批號
        If Not String.IsNullOrEmpty(tbLotsNumbers.Text) AndAlso tbLotsNumbers.Text.Trim.Length > 0 Then
            WhereValue &= " AND QCI40 IN ('" & tbLotsNumbers.Text.Replace(",", "','") & "')"
        End If

        If Not String.IsNullOrEmpty(tbSteelKind.Text) Then  '鋼種材質篩選
            tbSteelKind.Text = tbSteelKind.Text.Replace("'", Nothing)
            WhereValue &= IIf(tbSteelKind.Text.Trim.Length > 0, "  AND (RTRIM(A.QCI05) || A.QCI06) IN ('" & tbSteelKind.Text.Replace(",", "','") & "')", Nothing)
        End If

        If Not String.IsNullOrEmpty(tbStove.Text) AndAlso tbStove.Text.Trim.Length > 0 Then
            Dim AddWhereString1 As String = Nothing
            Dim AddWhereString2 As String = Nothing
            For Each EachStoveRange As String In tbStove.Text.Trim.Split(",")   '成份篩選
                If EachStoveRange.Contains("~") Then
                    AddWhereString1 &= IIf(String.IsNullOrEmpty(AddWhereString1), Nothing, " OR ")
                    AddWhereString1 &= " QCI01>='" & EachStoveRange.Split("~")(0).Trim & "' AND QCI01<='" & EachStoveRange.Split("~")(1).Trim & "' "
                Else
                    AddWhereString2 &= IIf(String.IsNullOrEmpty(AddWhereString2), Nothing, ",") & "'" & EachStoveRange.Trim & "'"
                End If
            Next
            Dim AddWhereString As String = Nothing
            AddWhereString &= AddWhereString1
            If Not String.IsNullOrEmpty(AddWhereString2) Then
                AddWhereString &= IIf(String.IsNullOrEmpty(AddWhereString), Nothing, " OR ") & " QCI01 IN (" & AddWhereString2 & ")"
            End If
            WhereValue &= " AND (" & AddWhereString & ")"
        End If


        For Each EachItem As ListItem In lbElements.Items
            Dim Datas() As String = EachItem.Value.Split(":")
            WhereValue &= " AND QCI" & Datas(0) & " >= " & Datas(1) & " AND QCI" & Datas(0) & " <= " & Datas(2)
        Next
        If CheckBox1.Checked Then
            Dim StartDateTime As DateTime = CType(Me.tbStartDate.Text, Date).AddHours(Val(tbStartHour.Text)).AddMinutes(Val(tbStartMinute.Text))
            Dim EndDateTime As DateTime = CType(Me.tbEndDate.Text, Date).AddHours(Val(tbEndHour.Text)).AddMinutes(Val(tbEndMinute.Text))
            Dim StartDateValue As Integer = (Format(StartDateTime.AddDays(1), "yyyy") - 1911) * 10000 + Format(StartDateTime.AddDays(1), "MMdd")
            Dim EndDateValue As Integer = (Format(EndDateTime.AddDays(-1), "yyyy") - 1911) * 10000 + Format(EndDateTime.AddDays(-1), "MMdd")
            WhereValue &= " AND ( "
            WhereValue &= " QCI02>=" & StartDateValue & " AND QCI02<=" & EndDateValue
            StartDateValue = (Format(StartDateTime, "yyyy") - 1911) * 10000 + Format(StartDateTime, "MMdd")
            EndDateValue = (Format(EndDateTime, "yyyy") - 1911) * 10000 + Format(EndDateTime, "MMdd")
            WhereValue &= " OR (QCI02=" & StartDateValue & " AND (QCI03*100+QCI04)>=" & StartDateTime.Hour * 100 + StartDateTime.Minute & ")"
            WhereValue &= " OR (QCI02=" & EndDateValue & " AND (QCI03*100+QCI04)<=" & EndDateTime.Hour * 100 + EndDateTime.Minute & ")"
            WhereValue &= " ) "
        End If

        Me.hfSQLString.Value = ReturnValue & WhereValue & " Order by A.QCI40,A.QCI01"
        Me.hfDFAndMD30Range.Value = (Me.txDF1.Text & "," & Me.txDF2.Text & "," & Me.txMD301.Text & "," & Me.txMD302.Text).Replace("'", Nothing)
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(New Date(Now.Year, Now.Month, 1), "yyyy/MM/dd")
            tbEndDate.Text = Format(New Date(Now.Year, Now.Month, 1).AddMonths(1), "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnAddElement_Click(sender As Object, e As EventArgs) Handles btnAddElement.Click
        Try
            Dim AddItem As New ListItem
            AddItem.Text = DropDownList1.SelectedItem.Text & ":" & CType(tbElementStartValue.Text.Trim, Single).ToString & "~" & CType(tbElementEndValue.Text.Trim, Single).ToString
            If DropDownList1.SelectedItem.Text.ToUpper = "CA" OrElse DropDownList1.SelectedItem.Text.ToUpper = "MG" Then
                AddItem.Value = DropDownList1.SelectedItem.Value & "/100:" & CType(tbElementStartValue.Text.Trim, Single).ToString & ":" & CType(tbElementEndValue.Text.Trim, Single).ToString
            Else
                AddItem.Value = DropDownList1.SelectedItem.Value & ":" & CType(tbElementStartValue.Text.Trim, Single).ToString & ":" & CType(tbElementEndValue.Text.Trim, Single).ToString
            End If
            lbElements.Items.Add(AddItem)
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnDeleteElement_Click(sender As Object, e As EventArgs) Handles btnDeleteElement.Click
        If Not IsNothing(lbElements.SelectedItem) Then
            lbElements.Items.Remove(lbElements.SelectedItem)
        End If
    End Sub

    Protected Sub tbSearch_Click(sender As Object, e As EventArgs) Handles tbSearch.Click
        SetQryStringToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub tbClearSearchCondiction_Click(sender As Object, e As EventArgs) Handles tbClearSearchCondiction.Click
        tbStove.Text = Nothing
        tbSteelKind.Text = Nothing
        tbLotsNumbers.Text = Nothing
        Call btnDeleteElement_Click(Nothing, Nothing)
    End Sub


    Protected Sub btnSearchDownExcel_Click(sender As Object, e As EventArgs) Handles btnSearchDownExcel.Click
        SetQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfSQLString.Value, Me.hfDFAndMD30Range.Value), "爐號成份查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

End Class