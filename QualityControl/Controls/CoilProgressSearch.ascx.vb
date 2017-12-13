Public Class CoilProgressSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"

    Private Property A As Object

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As QualityControlDataSet.CoilProgressDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return New QualityControlDataSet.CoilProgressDataTable
        End If
        Dim ReturnValue As New QualityControlDataSet.CoilProgressDataTable
        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, SQLString)
        Dim Result As List(Of DataRow) = (From A In Adapter.SelectQuery.Rows Select CType(A, DataRow)).ToList
        Dim AlreadyBreakCoilNumbers As List(Of String) = (From A In Result Where CType(A.Item("SHA29"), String).Trim = "*" Select CType(A.Item("SHA01"), String).Trim).ToList

        For Each EachCoilFullNumber As String In (From A In Result Select CType(A.Item("SHA01"), String).Trim & CType(A.Item("SHA02"), String).Trim).Distinct.ToList
            Dim EachCoilFullNumberTemp As String = EachCoilFullNumber
            Dim LastSchedual As DataRow = (From A In Result Where Not AlreadyBreakCoilNumbers.Contains(CType(A.Item("SHA01"), String).Trim & CType(A.Item("SHA02"), String).Trim) AndAlso CType(A.Item("SHA01"), String).Trim & CType(A.Item("SHA02"), String).Trim = EachCoilFullNumberTemp Select A Order By A.Item("SHA04") Descending).FirstOrDefault
            Dim AddDataRow As QualityControlDataSet.CoilProgressRow
            If Not IsNothing(LastSchedual) Then
                AddDataRow = ReturnValue.NewRow
                With AddDataRow
                    .鋼捲號碼 = LastSchedual.Item("SHA01")
                    .分捲號碼 = LastSchedual.Item("SHA02")
                    .製程名稱 = LastSchedual.Item("SHA08")
                    .完成日期 = LastSchedual.Item("SHA21")
                    .公稱厚度 = LastSchedual.Item("BLA03")
                    .熱軋批號 = LastSchedual.Item("BLA11")
                    .熱軋號碼 = LastSchedual.Item("BLA01")
                    .表面 = LastSchedual.Item("SHA06")
                End With
                ReturnValue.Rows.Add(AddDataRow)
            End If
        Next

        Return ReturnValue
    End Function
#End Region

#Region "產生條件產字串 方法:SetSelectArgToControl"
    ''' <summary>
    ''' 產生條件產字串
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSelectArgToControl()
        Dim ReturnValue As String = "Select A.*,B.*" & _
        " From  @#PPS100LB.PPSSHAPF A INNER JOIN @#PPS100LB.PPSBLAPF B ON A.SHA01=B.BLA09 " & _
        " WHERE 1=1 "

        If Not String.IsNullOrEmpty(tbEndDate.Text) Then
            Dim SetDate As DateTime = CType(tbEndDate.Text, Date)
            ReturnValue &= " AND SHA21 <= " & (Val(Format(SetDate, "yyyy")) - 1911) * 10000 + Format(SetDate, "MMdd")
        End If

        If Not String.IsNullOrEmpty(tbLotsNumbers.Text) Then
            tbLotsNumbers.Text = tbLotsNumbers.Text.Replace("'", Nothing)
            If tbLotsNumbers.Text.Contains("~") Then
                ReturnValue &= IIf(tbLotsNumbers.Text.Trim.Length > 0, " AND B.BLA11 >= '" & tbLotsNumbers.Text.Split("~")(0).Trim & "' AND B.BLA11 <= '" & tbLotsNumbers.Text.Split("~")(1).Trim & "'", Nothing)
            Else
                ReturnValue &= IIf(tbLotsNumbers.Text.Trim.Length > 0, " AND B.BLA11 IN ('" & tbLotsNumbers.Text.Replace(",", "','") & "')", Nothing)
            End If
        End If

        hfSQLString.Value = ReturnValue & " Order by B.BLA01"
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.tbEndDate.Text = Format(Now.Date, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        SetSelectArgToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchDownExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchDownExcel.Click
        SetSelectArgToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfSQLString.Value), "鋼捲生產進度查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub
End Class