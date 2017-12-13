Public Class DebtLetterofCreditSearch
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            P_Init()
        End If
    End Sub

    Public Sub P_Init()
        tbToday_Start.Text = (DateAdd(DateInterval.Month, -1, Now).ToString("yyyy/MM/")) & "01"
        tbToday_End.Text = (Now.ToString("yyyy/MM/dd"))
    End Sub
#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQL As New StringBuilder
        Dim as400DateConverter As New CompanyORMDB.AS400DateConverter

        CustomValidator1.Text = ""
        If IsDate(tbToday_Start.Text) = False OrElse IsDate(tbToday_End.Text) = False Then
            CustomValidator1.Text = "『到期日期』範圍區間輸入錯誤，請檢查！"
            CustomValidator1.IsValid = (CustomValidator1.Text = "")
            Exit Sub
        End If

        Dim W_today_S As String, W_today_E As String
        as400DateConverter.DateValue = Date.Parse(tbToday_Start.Text)
        W_today_S = as400DateConverter.TwSevenCharsTypeData

        as400DateConverter.DateValue = Date.Parse(tbToday_End.Text)
        W_today_E = as400DateConverter.TwSevenCharsTypeData


        SQL.Append(" SELECT * " & vbNewLine)
        SQL.Append(" FROM @#debsyslb.lcuspf " & vbNewLine)
        SQL.Append(" WHERE 1=1" & vbNewLine)
        SQL.Append("  AND today >='" & W_today_S & "' " & vbNewLine)
        SQL.Append("  AND today <='" & W_today_E & "' " & vbNewLine)
        SQL.Append(" ORDER BY today, lcusno " & vbNewLine)

        Me.hfSQL.Value = SQL.ToString
        Me.hfParam.Value = W_today_S & "," & W_today_E

    End Sub
#End Region


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="fromSQL"></param>
    ''' <param name="fromParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal fromSQL As String, ByVal fromParam As String) As AccountDataSet.DebtLetterofCreditSearchDataTable
        Dim retTable As New AccountDataSet.DebtLetterofCreditSearchDataTable
        Dim addItem As AccountDataSet.DebtLetterofCreditSearchRow

        If String.IsNullOrEmpty(fromSQL) OrElse String.IsNullOrEmpty(fromParam) Then
            Return retTable
        End If

        Dim queryList As List(Of DEBSYSLB.LCUSPF) = DEBSYSLB.LCUSPF.CDBSelect(Of DEBSYSLB.LCUSPF) _
                                                                                            (fromSQL, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

        For Each eachItem As DEBSYSLB.LCUSPF In queryList
            addItem = retTable.NewRow

            addItem.到期日 = eachItem.TODAY
            addItem.信用狀編號 = eachItem.LCUSNO
            addItem.單位別 = eachItem.DEPART
            addItem.幣別 = eachItem.CURRAN
            addItem.金額 = eachItem.AMOUNT
            addItem.發行日 = eachItem.LODAY
            addItem.銀行別 = eachItem.BANK
            addItem.期限 = eachItem.PERIOD
            addItem.利率 = eachItem.IR
            addItem.利息 = eachItem.INTER
            addItem.兌換率 = eachItem.CR
            addItem.新台幣金額 = eachItem.NTAMT

            retTable.Rows.Add(addItem)
        Next


        Return retTable
    End Function
#End Region

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        MakQryStringToControl()

        Dim W_Param() As String = Me.hfParam.Value.Split(",")

        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfSQL.Value, Me.hfParam.Value), "債務信用狀_" & W_Param(0) & "~" & W_Param(1) & "_" & Format(Now, "yyyyMMdd_hhmmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.MakQryStringToControl()
    End Sub



    Public Function showSpace(ByVal fromNum As Integer) As String
        Dim retString As String
        Dim W_String As String

        W_String = Space(fromNum)
        retString = W_String.Replace(Space(1), "&nbsp")

        Return retString
    End Function
End Class