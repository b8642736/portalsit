Public Class CSSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As QualityControlDataSet.CSSearchDataTable
        Dim ReturnValue As New QualityControlDataSet.CSSearchDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If
        Dim QryAdapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
        For Each EachItem As DataRow In QryAdapter.SelectQuery.Rows
            Dim AddRow As QualityControlDataSet.CSSearchRow = ReturnValue.NewRow
            With AddRow
                If Not IsDBNull(EachItem.Item("CIA55")) Then
                    .繳庫時間 = Val(EachItem.Item("CIA55")) + 19110000
                    .繳庫時間 = Left(.繳庫時間, 4) & "/" & Mid(.繳庫時間, 5, 2) & "/" & Right(.繳庫時間, 2)
                End If
                .客訴案號 = EachItem.Item("SUA01")
                .代碼 = EachItem.Item("SUA05")
                .客戶 = CustomerName(EachItem.Item("SUA05"))
                .鋼捲編號 = CType(EachItem.Item("SUA02"), String) & CType(EachItem.Item("SUA03"), String).Trim
                If Not IsDBNull(EachItem.Item("CIA05")) Then
                    .鋼種 = EachItem.Item("CIA05")
                End If
                If Not IsDBNull(EachItem.Item("CIA06")) Then
                    .材質 = EachItem.Item("CIA06")
                End If
                .責任單位 = EachItem.Item("SUA30")
                If Not IsDBNull(EachItem.Item("CIA07")) Then
                    .厚度 = EachItem.Item("CIA07")
                End If
                .缺陷編號 = EachItem.Item("SUA28")
                .缺陷 = BugName(EachItem.Item("SUA28"))
                Dim DiscuntStr As String = CType(EachItem.Item("SUA11"), String).Trim
                DiscuntStr &= IIf(String.IsNullOrEmpty(DiscuntStr) OrElse CType(EachItem.Item("SUA12"), String).Trim = "", "", ",") & CType(EachItem.Item("SUA12"), String).Trim
                DiscuntStr &= IIf(String.IsNullOrEmpty(DiscuntStr) OrElse CType(EachItem.Item("SUA13"), String).Trim = "", "", ",") & CType(EachItem.Item("SUA13"), String).Trim
                DiscuntStr &= IIf(String.IsNullOrEmpty(DiscuntStr) OrElse CType(EachItem.Item("SUA14"), String).Trim = "", "", ",") & CType(EachItem.Item("SUA14"), String).Trim
                .折讓方式 = DiscuntStr
                .要求重量 = EachItem.Item("SUA45") + EachItem.Item("SUA46") + EachItem.Item("SUA47") + EachItem.Item("SUA48")
                .要求金額 = EachItem.Item("SUA49") + EachItem.Item("SUA50") + EachItem.Item("SUA51") + EachItem.Item("SUA52")
                .核定重量 = EachItem.Item("SUA15") + EachItem.Item("SUA16") + EachItem.Item("SUA17") + EachItem.Item("SUA18")
                .核定金額 = EachItem.Item("SUA19") + EachItem.Item("SUA20") + EachItem.Item("SUA21") + EachItem.Item("SUA22")
                .業務收文 = Val(EachItem.Item("SUA06")) + 19110000
                .業務收文 = Left(.業務收文, 4) & "/" & Mid(.業務收文, 5, 2) & "/" & Right(.業務收文, 2)
                .品管查驗 = Val(EachItem.Item("SUA36")) + 19110000
                .品管查驗 = Left(.品管查驗, 4) & "/" & Mid(.品管查驗, 5, 2) & "/" & Right(.品管查驗, 2)
                .品管簽結 = Val(EachItem.Item("SUA37")) + 19110000
                .品管簽結 = Left(.品管簽結, 4) & "/" & Mid(.品管簽結, 5, 2) & "/" & Right(.品管簽結, 2)
                .結案日 = Val(EachItem.Item("SUA07")) + 19110000
                .結案日 = Left(.結案日, 4) & "/" & Mid(.結案日, 5, 2) & "/" & Right(.結案日, 2)
            End With
            ReturnValue.Rows.Add(AddRow)
        Next
        Return ReturnValue
    End Function

    Private Function BugName(ByVal BugCode As String) As String
        Static AllBugCodeTables As List(Of PPS100LB.PPSDEFPF) = PPS100LB.PPSQDEPF.CDBSelect(Of PPS100LB.PPSDEFPF)("Select * from @#PPS100LB.PPSDEFPF", AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Static AllBugKindCodeTables As List(Of PPS100LB.PPSSUCPF) = PPS100LB.PPSQDEPF.CDBSelect(Of PPS100LB.PPSSUCPF)("Select * from @#PPS100LB.PPSSUCPF Where SUC01='D'", AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim BugCodeInteger As Integer
        If Integer.TryParse(BugCode, BugCodeInteger) Then
            Dim FindRecord As PPS100LB.PPSDEFPF = (From A In AllBugCodeTables Where A.DEF01 = BugCodeInteger Select A).FirstOrDefault
            If Not IsNothing(FindRecord) Then
                Return FindRecord.DEF02.Trim
            End If
        Else
            Dim FindRecord As PPS100LB.PPSSUCPF = (From A In AllBugKindCodeTables Where A.SUC02.Trim = BugCode.Trim Select A).FirstOrDefault
            If Not IsNothing(FindRecord) Then
                Return FindRecord.SUC03.Trim
            End If
        End If
        Return ""
    End Function

    Private Function CustomerName(ByVal CustomerCode As String) As String
        Static AllCustomerTables As List(Of SLS300LB.SL2CUAPF) = PPS100LB.PPSQDEPF.CDBSelect(Of SLS300LB.SL2CUAPF)("Select * from @#SLS300LB.SL2CUAPF", AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim FindRecord As SLS300LB.SL2CUAPF = (From A In AllCustomerTables Where A.CUA01 = CustomerCode Select A).FirstOrDefault
        If Not IsNothing(FindRecord) Then
            Return FindRecord.CUA11.Trim
        End If
        Return ""
    End Function
#End Region

#Region "SQL查詢產生至控制項 方法:MakerSQLStringToControl"
    ''' <summary>
    ''' 查詢產生至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakerSQLStringToControl()
        Dim QryString As New StringBuilder
        QryString.Append("Select A.*,B.CIA05,B.CIA06,B.CIA07,B.CIA55 from @#PPS100LB.PPSSUAPF A LEFT JOIN @#PPS100LB.PPSCIAPF B ON A.SUA05=LEFT(B.CIA04,3) and A.SUA02=B.CIA02 AND A.SUA03=B.CIA03 WHERE SUA28<>'' ")
        If cbSUA06.Checked Then
            QryString.Append(" and A.SUA06 >='" & tbSUA06StartDate.Text.Trim & "' AND A.SUA06<='" & tbSUA06EndDate.Text & "'")
        End If
        If cbSUA37.Checked Then
            QryString.Append(" and A.SUA37 >='" & tbSUA37StartDate.Text.Trim & "' AND A.SUA37<='" & tbSUA37EndDate.Text & "'")
        End If
        If cbSUA07.Checked Then
            QryString.Append(" and A.SUA07 >='" & tbSUA07StartDate.Text.Trim & "' AND A.SUA07<='" & tbSUA07EndDate.Text & "'")
        End If
        hfQuery.Value = QryString.ToString
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim TheMonthFirstDate As New System.DateTime(Now.Year, Now.Month, 1)
            Dim SetStartDate As String = New CompanyORMDB.AS400DateConverter(TheMonthFirstDate).TwSevenCharsTypeData
            Dim SetEndDate As String = New CompanyORMDB.AS400DateConverter(TheMonthFirstDate.AddMonths(1).AddDays(-1)).TwSevenCharsTypeData
            tbSUA06StartDate.Text = SetStartDate
            tbSUA06EndDate.Text = SetEndDate
            tbSUA37StartDate.Text = SetStartDate
            tbSUA37EndDate.Text = SetEndDate
            tbSUA07StartDate.Text = SetStartDate
            tbSUA07EndDate.Text = SetEndDate
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakerSQLStringToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        MakerSQLStringToControl()
        Dim ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search(Me.hfQuery.Value), "訴賠資料" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

End Class