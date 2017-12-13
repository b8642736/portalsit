Imports CompanyORMDB.PPS100LB

Public Class PackSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As ColdRollingProcessDataSet.PackSearchDataTable
        Dim ReturnValue As New ColdRollingProcessDataSet.PackSearchDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If

        Dim SearchResult As List(Of PPSCICPF) = PPSCICPF.CDBSelect(Of PPSCICPF)(SQLString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EachItem As PPSCICPF In SearchResult
            Dim AddItem As ColdRollingProcessDataSet.PackSearchRow = ReturnValue.NewRow
            With AddItem
                .襯紙夾整捲 = EachItem.CIC11Descript
                .襯紙厚薄 = EachItem.CIC15Descript
                .鋼捲編號 = Trim(EachItem.CIC01 & EachItem.CIC02)
                .線別 = EachItem.CIC00
                .日期 = EachItem.CIC03
                .時間 = EachItem.CIC04
                .襯紙寬 = EachItem.CIC13
                .襯紙定長 = EachItem.CIC12
                .襯紙基重 = EachItem.CIC14
                .是否套筒 = EachItem.CIC21Descript
                .套筒外徑 = EachItem.CIC22
                .套筒內徑 = EachItem.CIC23
                .套筒重 = EachItem.CIC24
                .奇力龍整捲 = EachItem.CIC31Descript
                .奇力龍寬 = EachItem.CIC33
                .奇力龍長 = EachItem.CIC32
                .奇力龍基重 = EachItem.CIC34
            End With
            ReturnValue.Rows.Add(AddItem)
        Next

        Return ReturnValue
    End Function

#End Region

#Region "控制項Where條件產生器 方法:ControlWhereMaker"
    ''' <summary>
    ''' Where
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ControlWhereMaker()

        Dim ReturnValue As New StringBuilder
        ReturnValue.Append("Select * from @#PPS100LB.PPSCICPF WHERE  CIC00 <> 'STK' ")

        If CheckBox1.Checked Then
            Dim StartDate As Integer = New CompanyORMDB.AS400DateConverter(tbStartDate.Text).TwIntegerTypeData
            Dim EndDate As Integer = New CompanyORMDB.AS400DateConverter(tbEndDate.Text).TwIntegerTypeData
            ReturnValue.Append(" AND CIC03 >=" & StartDate & " AND CIC03 <=" & EndDate)
        End If

        If Not String.IsNullOrEmpty(tbLines.Text) AndAlso tbLines.Text.Trim.Length > 0 Then
            ReturnValue.Append(" AND CIC00 IN ('" & tbLines.Text.Trim.Replace(",", "','") & "') ")
        End If


        If Not String.IsNullOrEmpty(tbCoilNumbers.Text) AndAlso tbCoilNumbers.Text.Trim.Length > 0 Then
            ReturnValue.Append(" AND CIC01 IN ('" & tbCoilNumbers.Text.Trim.Replace(",", "','") & "') ")
        End If

        ReturnValue.Append(" ORDER BY CIC01,CIC02 ")
        Me.hfSQLString.Value = ReturnValue.ToString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.tbStartDate.Text = Format(Now.AddYears(-1), "yyyy/MM/dd")
        Me.tbEndDate.Text = Format(Now, "yyyy/MM/dd")
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call ControlWhereMaker()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchDownExcel_Click(sender As Object, e As EventArgs) Handles btnSearchDownExcel.Click
        Call ControlWhereMaker()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfSQLString.Value), "AS400鋼捲包裝查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

End Class