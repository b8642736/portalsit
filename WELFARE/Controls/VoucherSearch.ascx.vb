
Public Class VoucherSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As WELFARE.VoucherSearchDataTable
        '傳票編號	傳票日期	入帳日期	會計科目	款項目	明細項	借貸別	 金額 	科目別	摘要

        Dim ReturnValue As New WELFARE.VoucherSearchDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
            ReturnValue.NewVoucherSearchRow()
        End If
        Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "WELFARE")
        Dim SearchResult As DataTable = Adapter.SelectQuery(QryString)
        For Each EachItem As DataRow In SearchResult.Rows
            Dim AddRow As WELFARE.VoucherSearchRow = ReturnValue.NewRow
            With AddRow
                .傳票編號 = EachItem.Item("傳票編號")
                .傳票日期 = EachItem.Item("傳票日期")
                .入帳日期 = EachItem.Item("入帳日期")
                .會計科目 = EachItem.Item("會計科目")
                If Not IsDBNull(EachItem.Item("款項目")) Then
                    .款項目 = EachItem.Item("款項目")
                End If
                If Not IsDBNull(EachItem.Item("明細項")) Then
                    .明細項 = EachItem.Item("明細項")
                End If
                .借貸別 = EachItem.Item("借貸別")
                .金額 = EachItem.Item("金額")
                .科目別 = EachItem.Item("科目別")
                If Not IsDBNull(EachItem.Item("摘要")) Then
                    .摘要 = EachItem.Item("摘要")
                End If
            End With
            ReturnValue.Rows.Add(AddRow)
        Next
        Return ReturnValue
    End Function
#End Region


#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim StartDate As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbStartDate.Text, Date)).TwIntegerTypeData
        Dim EndDate As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbEndDate.Text, Date)).TwIntegerTypeData
        Dim SQLString As StringBuilder = New StringBuilder("Select A.傳票編號,A.傳票別,A.傳票日期,A.入帳日期,A.入帳編號,B.* from 傳票 A JOIN 傳票明細 B ON A.傳票編號=B.傳票編號 Where 入帳日期>=" & StartDate & " and 入帳日期<=" & EndDate)
        If Not String.IsNullOrEmpty(tbAccCodes.Text) AndAlso tbAccCodes.Text.Trim.Length > 0 Then
            SQLString.Append(" and B.會計科目 IN ('" & tbAccCodes.Text.Replace(",", "','") & "') ")
        End If
        If Not String.IsNullOrEmpty(tbAccItems.Text) AndAlso tbAccItems.Text.Trim.Length > 0 Then
            SQLString.Append(" and B.款項目 IN ('" & tbAccItems.Text.Replace(",", "','") & "') ")
        End If
        If Not String.IsNullOrEmpty(tbAccDetailCodes.Text) AndAlso tbAccDetailCodes.Text.Trim.Length > 0 Then
            SQLString.Append(" and B.明細項 IN ('" & tbAccDetailCodes.Text.Replace(",", "','") & "') ")
        End If
        If Not String.IsNullOrEmpty(tbAccMemos.Text) AndAlso tbAccMemos.Text.Trim.Length > 0 Then
            Dim EachDatas As List(Of String) = tbAccMemos.Text.Trim.Split(",").ToList
            SQLString.Append(" AND (")
            Dim IsFirstLoop As Boolean = True
            For Each EachItem As String In EachDatas
                If Not IsFirstLoop Then
                    SQLString.Append(" and ")
                End If
                SQLString.Append(" B.摘要 like '%" & EachItem & "%'")
                IsFirstLoop = False
            Next
            SQLString.Append(")")
        End If
        Me.hfQryString.Value = SQLString.ToString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now, "yyyy/MM/01")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        MakQryStringToControl()
        Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(Search(Me.hfQryString.Value), "傳票查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

End Class