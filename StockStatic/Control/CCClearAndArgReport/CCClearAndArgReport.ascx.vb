Public Class CCClearAndArgReport
    Inherits System.Web.UI.UserControl


#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As DisplayDataSet.CCClearAndArgReportDataTable
        Dim ReturnValue As New DisplayDataSet.CCClearAndArgReportDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If

        Dim DBAdapter = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchReslut As List(Of CompanyORMDB.SMS100LB.SMSREGPF) = CompanyORMDB.SMS100LB.SMSREGPF.CDBSelect(Of CompanyORMDB.SMS100LB.SMSREGPF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SubSearchResult As New List(Of CompanyORMDB.SMS100LB.SMSREGPF)

        For Each EachClass As String In {"A", "B", "C", "D", "CHANGE"}
            Dim EachClassTemp As String = EachClass
            Dim Additem As DisplayDataSet.CCClearAndArgReportRow = ReturnValue.NewRow
            Dim DivCount As Integer
            With Additem
                If EachClass <> "CHANGE" Then
                    SubSearchResult = (From A In SearchReslut Where A.T21.Trim.Length = 1 And A.T21 = EachClassTemp Select A).ToList
                    .班別 = EachClass & "班"
                Else
                    SubSearchResult = (From A In SearchReslut Where A.T21.Trim.Length > 1 Select A).ToList
                    .班別 = "交接班"
                End If

                .取樣數 = (From A In SubSearchResult Where A.T11 > 0 Select A).Count
                .攪拌時間取樣數 = (From A In SubSearchResult Where A.T10 > 0 And A.T10 < 15 Select A).Count
                DivCount = (From A In SubSearchResult Where A.T10 > 0 Select A).Count
                If DivCount > 0 Then
                    .攪拌時間百分比 = Val(.攪拌時間取樣數) / DivCount
                End If
                .靜置時間取樣數 = (From A In SubSearchResult Where A.T11 > 0 And A.T11 < 12 Select A).Count
                DivCount = Val(.取樣數)
                If DivCount > 0 Then
                    .靜置時間百分比 = Val(.靜置時間取樣數) / DivCount
                End If
                .攪拌強度取樣數 = (From A In SubSearchResult Where {1, 2}.Contains(A.T15) Select A).Count
                DivCount = (From A In SubSearchResult Where A.T15 <> 0 Select A).Count
                If DivCount > 0 Then
                    .攪拌強度百分比 = Val(.攪拌強度取樣數) / DivCount
                End If
            End With
            ReturnValue.Rows.Add(Additem)
        Next
        Return ReturnValue
    End Function
#End Region

#Region "產生查詢指令至控制項 函式:MakeQryToControl"
    ''' <summary>
    ''' 產生查詢指令至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryToControl()
        Dim QueryString As String = "SELECT A.* FROM @#SMS100LB.SMSREGPF A Left JOIN @#PPS100LB.PPSQCAPF B ON A.T2=B.QCA01 WHERE 1=1 "

        If CheckBox1.Checked Then
            Dim StartDateValue As Integer = New CompanyORMDB.AS400DateConverter(tbStartDate.Text).TwIntegerTypeData
            Dim EndDateValue As Integer = New CompanyORMDB.AS400DateConverter(tbEndDate.Text).TwIntegerTypeData
            QueryString &= " AND A.T1 >= " & StartDateValue & " AND A.T1 <= " & EndDateValue
        End If
        If Not String.IsNullOrEmpty(tbStoveNumber.Text) AndAlso tbStoveNumber.Text.Trim.Length > 0 Then
            Dim AddQryString As String = Nothing
            For Each EachItem As String In tbStoveNumber.Text.Split(",")
                AddQryString &= IIf(String.IsNullOrEmpty(AddQryString), Nothing, " OR ")
                If EachItem.Contains("~") Then
                    AddQryString &= " (A.T2 >='" & EachItem.ToUpper.Split("~")(0) & "' AND A.T2<='" & EachItem.ToUpper.Split("~")(1) & "')"
                Else
                    AddQryString &= " A.T2 = '" & EachItem.ToUpper & "'"
                End If
            Next
            QueryString &= " AND (" & AddQryString & " ) "
        End If

        If Not String.IsNullOrEmpty(tbSteelKind.Text) Then
            QueryString &= " AND B.QCA05 IN ('" & tbSteelKind.Text.Trim.Replace(",", "','") & "')"
        End If
        QueryString &= " Order by A.T1,A.T25,A.T2"

        Me.hfQry.Value = QueryString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now, "yyyy/MM/01")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakeQryToControl()
        Dim TitleString As String = "鋼種:" & IIf(tbSteelKind.Text.Trim.Length = 0, "全部", tbSteelKind.Text.Trim.Replace(",", " "))
        TitleString &= " 爐號:" & IIf(tbStoveNumber.Text.Trim.Length = 0, "全部", tbStoveNumber.Text.Trim)
        Dim TimeString As String = IIf(CheckBox1.Checked = False, "全部", tbStartDate.Text.Trim & " ~ " & tbEndDate.Text.Trim)
        Dim Parameters(1) As Microsoft.Reporting.WebForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("Title", TitleString)
        Parameters(1) = New Microsoft.Reporting.WebForms.ReportParameter("TimeRange", "資料時間範圍:" & TimeString)

        ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.LocalReport.Refresh()

    End Sub
End Class