Public Class SearchPrint

#Region "重整編輯批次下拉選單 函式:RefreshEditPullDownBatchMenu"
    ''' <summary>
    ''' 重整編輯批次下拉選單
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshEditPullDownBatchMenu()
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("0.全部")
        Dim Qry As String = "Select * from @#PPS100LB.PPSCICPF WHERE CIC00='STK' AND CIC03=" & New CompanyORMDB.AS400DateConverter(DateTimePicker1.Value).TwIntegerTypeData & " order by cic05 "
        Dim AllEditData = CompanyORMDB.PPS100LB.PPSCICPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSCICPF)(Qry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim PreRecordUserID As String = Nothing
        Dim BatchCount As Integer = 1
        For Each EachItem As CompanyORMDB.PPS100LB.PPSCICPF In AllEditData
            If IsNothing(PreRecordUserID) OrElse PreRecordUserID <> EachItem.CIC94.Trim Then
                ComboBox1.Items.Add(BatchCount & "." & EachItem.CIC94.Trim)
                BatchCount += 1
            End If
            PreRecordUserID = EachItem.CIC94.Trim
        Next
        ComboBox1.SelectedIndex = ComboBox1.Items.Count - 1
    End Sub
#End Region

#Region "產生報表 函式:CreateReport"
    ''' <summary>
    ''' 產生報表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateReport()
        If String.IsNullOrEmpty(ComboBox1.SelectedItem.ToString) Then
            Me.PPSCICPFBindingSource.DataSource = New List(Of CompanyORMDB.PPS100LB.PPSCICPF)
            Exit Sub
        End If
        Dim DataBatchNumber As Integer = ComboBox1.SelectedItem.ToString.Split(".")(0)
        Dim Qry As String = "Select * from @#PPS100LB.PPSCICPF WHERE CIC00='STK' AND CIC03=" & New CompanyORMDB.AS400DateConverter(DateTimePicker1.Value).TwIntegerTypeData & " order by cic05 "
        Dim AllEditData = CompanyORMDB.PPS100LB.PPSCICPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSCICPF)(Qry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim ReportData As New List(Of CompanyORMDB.PPS100LB.PPSCICPF)
        PPSCICPFBindingSource.DataSource = ReportData

        Dim PreRecordUserID As String = Nothing
        Dim BatchCount As Integer = 0
        For Each EachItem As CompanyORMDB.PPS100LB.PPSCICPF In AllEditData
            If IsNothing(PreRecordUserID) OrElse PreRecordUserID <> EachItem.CIC94.Trim Then
                BatchCount += 1
            End If
            If DataBatchNumber > 0 Then
                If BatchCount = DataBatchNumber Then
                    ReportData.Add(EachItem)
                End If
            Else
                ReportData.Add(EachItem)
            End If
            PreRecordUserID = EachItem.CIC94.Trim
        Next
        PPSCICPFBindingSource.DataSource = ReportData
        Dim ReportInfo As String = Nothing
        ReportInfo &= "資料日期:" & Format(DateTimePicker1.Value, "yyyy/MM/dd") & " 批次:" & IIf(DataBatchNumber = 0, "全部", DataBatchNumber)
        Dim Parameters(0) As Microsoft.Reporting.WinForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WinForms.ReportParameter("ReportInfo", ReportInfo)
        ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.RefreshReport()
    End Sub
#End Region


    Private Sub SearchPrint_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshEditPullDownBatchMenu()  '重整編輯批次下拉選單
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        RefreshEditPullDownBatchMenu()  '重整編輯批次下拉選單
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        CreateReport()
    End Sub

End Class
