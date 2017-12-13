Public Class PendingPayment
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            P_INI()
        End If
    End Sub

    Private Sub P_INI()
        tbDateStart.Text = (DateAdd(DateInterval.Day, -30, Now).ToString("yyyy/MM/dd"))
        tbDateEnd.Text = (DateAdd(DateInterval.Day, 10, Now).ToString("yyyy/MM/dd"))
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
    End Sub


#Region "MakQryStringToControl：產生SQL"

    Private Sub MakQryStringToControl()

        CustomValidator1.Text = ""
        If IsDate(tbDateStart.Text) = False OrElse IsDate(tbDateEnd.Text) = False Then
            CustomValidator1.Text = "『編票日期』範圍區間輸入錯誤，請檢查！"
            CustomValidator1.IsValid = (CustomValidator1.Text = "")
            Exit Sub
        End If


        Dim SQL As New StringBuilder
        Dim as400DateConverter As New CompanyORMDB.AS400DateConverter

        Dim W_today_S As String, W_today_E As String, W_today_Now As String
        as400DateConverter.DateValue = Date.Parse(tbDateStart.Text)
        W_today_S = as400DateConverter.TwSevenCharsTypeData

        as400DateConverter.DateValue = Date.Parse(tbDateEnd.Text)
        W_today_E = as400DateConverter.TwSevenCharsTypeData

        as400DateConverter.DateValue = Now
        W_today_Now = as400DateConverter.TwSevenCharsTypeData

        SQL.Append("  SELECT SALENO,SHTNO1,SUM(AMOUNT) AMOUNT_S,SHTDAT,REMARK                                              " & vbNewLine)
        SQL.Append("  FROM @#ACLIB.ACD010PF.SA  T01                        " & vbNewLine)
        SQL.Append("  WHERE 1=1                                            " & vbNewLine)
        SQL.Append("    AND SHTDAT BETWEEN " & W_today_S & " AND " & W_today_E & "             " & vbNewLine)
        SQL.Append("    AND SUBSTR(SHTNO1,2,1)='C'                         " & vbNewLine)
        SQL.Append("    AND NOT EXISTS (                                   " & vbNewLine)
        SQL.Append(" 		SELECT SHTNOO                                  " & vbNewLine)
        SQL.Append(" 		FROM @#CASH.CASH01PF.CASH01PF T02              " & vbNewLine)
        SQL.Append(" 		Where T02.SHTNOO = T01.SHTNO1                  " & vbNewLine)
        SQL.Append(" 		AND NOT (T02.PAYDAT='     ' OR T02.PAYDAT >'" & W_today_Now & "')  " & vbNewLine)
        SQL.Append(" 	)		                                           " & vbNewLine)
        SQL.Append("    AND DBORCR='A'                                     " & vbNewLine)
        SQL.Append("    AND DBORCR='A' AND WORKNO IN ('BOT-1  ','      ')  " & vbNewLine)
        SQL.Append("    GROUP BY SALENO,SHTNO1,SHTDAT,REMARK " & vbNewLine)
        SQL.Append("    ORDER BY SALENO,SHTNO1,SHTDAT,REMARK  " & vbNewLine)

        Me.hfSQL.Value = SQL.ToString
        Me.hfParam.Value = W_today_S & "," & W_today_E
    End Sub
#End Region


#Region "查詢 方法:Search"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="fromSQL"></param>
    ''' <param name="fromParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal fromSQL As String, ByVal fromParam As String) As DataTable
        Dim retTable As New DataTable

        If String.IsNullOrEmpty(fromSQL) OrElse String.IsNullOrEmpty(fromParam) Then
            Return retTable
        End If

        '1：query
        '--------------------------------------------------------------------------------    
        Dim queryTable As New DataTable
        Dim as400Adapter As New CompanyORMDB.AS400SQLQueryAdapter
        queryTable = as400Adapter.SelectQuery(fromSQL)

        '2：數字轉文字
        '--------------------------------------------------------------------------------    
        retTable = queryTable.Clone
        retTable.Columns("AMOUNT_S").DataType = GetType(String)

        For Each eachRow As DataRow In queryTable.Rows
            retTable.ImportRow(eachRow)
        Next

        '3：3個數字加上1個逗號
        '--------------------------------------------------------------------------------
        Dim W_Text1 As String, W_Text2 As String
        For Each eachRow As DataRow In retTable.Rows
            W_Text1 = eachRow.Item("AMOUNT_S")

            If W_Text1.Substring(W_Text1.Length - 3) = ".00" Then
                W_Text1 = W_Text1.Substring(0, W_Text1.Length - 3)
                W_Text2 = String.Format("{0:N0}", Long.Parse(W_Text1))
            Else
                W_Text2 = String.Format("{0:0,0.##}", Double.Parse(W_Text1))
            End If

            eachRow.Item("AMOUNT_S") = W_Text2
        Next
        '--------------------------------------------------------------------------------
        retTable.Columns("SALENO").ColumnName = "受款人"
        retTable.Columns("SHTNO1").ColumnName = "傳票"
        retTable.Columns("AMOUNT_S").ColumnName = "金額"
        retTable.Columns("SHTDAT").ColumnName = "傳票日"
        retTable.Columns("REMARK").ColumnName = "傳票摘要"
        '--------------------------------------------------------------------------------

        Return retTable
    End Function

#End Region


    Enum gridName_Enum
        受款人_1 = 1
        傳票_2 = 2
        金額_3 = 3
        傳票日_4 = 4
        傳票摘要_5 = 5
    End Enum

    Private Function getGridName(ByVal fromParam As gridName_Enum) As String
        Select Case fromParam
            Case gridName_Enum.受款人_1
                Return "受款人"
            Case gridName_Enum.傳票_2
                Return "傳票"
            Case gridName_Enum.金額_3
                Return "金額"
            Case gridName_Enum.傳票日_4
                Return "傳票日"
            Case gridName_Enum.傳票摘要_5
                Return "傳票摘要"
        End Select
    End Function

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        MakQryStringToControl()

        Dim W_Param() As String = Me.hfParam.Value.Split(",")

        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfSQL.Value, Me.hfParam.Value), "債務信用狀_" & W_Param(0) & "~" & W_Param(1) & "_" & Format(Now, "yyyyMMddhhmmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)

    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If IsNothing(e.Row.DataItem) Then Exit Sub

        Dim displayDataTable As DataTable = CType(e.Row.DataItem, System.Data.DataRowView).DataView.Table
        If IsNothing(displayDataTable) Then Exit Sub

        Dim newWidth As Integer
        Dim columnName As String
        Dim cellNow As System.Web.UI.WebControls.TableCell = Nothing
        For II As Integer = 0 To displayDataTable.Columns.Count - 1
            columnName = displayDataTable.Columns(II).Caption
            cellNow = e.Row.Cells(II)

            '數字靠右對齊
            Select Case columnName
                Case getGridName(gridName_Enum.金額_3), getGridName(gridName_Enum.傳票日_4)
                    cellNow.Attributes.Add("style", "text-align:right")
            End Select


            '調整寬度
            Select Case columnName
                Case getGridName(gridName_Enum.金額_3), getGridName(gridName_Enum.傳票_2)
                    newWidth = 100
                Case getGridName(gridName_Enum.傳票摘要_5)
                    newWidth = 400
            End Select
            cellNow.Width = newWidth

            'cellNow.Text &= "<BR>" & Format(Now, "hh:mm:ss")
        Next II
    End Sub
End Class