''' <summary>
''' 1050122 by jairong 重構
''' </summary>
''' <remarks></remarks>
Public Class ElementSearch
    Inherits System.Web.UI.UserControl


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            tbStartDate.Text = Format(Now, "yyyy/MM/dd").ToString
            tbEndDate.Text = Format(Now, "yyyy/MM/dd").ToString
        End If
    End Sub

    Dim ShowRowNumber As Integer = 0



    Private Sub DDLStationName_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLStationName.DataBound
        Me.DDLStationName.Items.Insert(0, New ListItem("全部", "ALL"))
        Me.DDLStationName.SelectedIndex = 0
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
    End Sub

    Protected Sub btnClearSearchCondiction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSearchCondiction.Click
        tbStartDate.Text = Format(Now, "yyyy/MM/dd").ToString
        tbEndDate.Text = Format(Now, "yyyy/MM/dd").ToString
        tbFurnaceNumber.Text = ""
        DDLStationName.SelectedIndex = 0
        Me.GridView1.DataBind()
    End Sub
   
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        ChangeGridViewCellColorForData(Me.GridView1, e.Row)
    End Sub
#Region "MakQryStringToControl：產生SQL"

    Private Sub MakQryStringToControl()

        Dim as400DateConverter As New CompanyORMDB.AS400DateConverter
        Dim W_startdate As String, W_enddate As String
        as400DateConverter.DateValue = Date.Parse(tbStartDate.Text)
        W_startdate = as400DateConverter.TwSevenCharsTypeData
        as400DateConverter.DateValue = Date.Parse(tbEndDate.Text)
        W_enddate = as400DateConverter.TwSevenCharsTypeData

        Dim SQL As New StringBuilder

        SQL.Append(" SELECT 爐號,     " & vbCrLf)
        SQL.Append("     CASE WHEN LEN(材質) = 2 AND UPPER(LEFT(LTRIM(材質),1))='T'     " & vbCrLf)
        SQL.Append("     THEN LEFT(LTRIM(材質),2) + 鋼種        " & vbCrLf)
        SQL.Append("     WHEN LEN(材質) = 3 AND ISNUMERIC(RIGHT(RTRIM(材質),1)) = 1 AND UPPER(LEFT(LTRIM(材質),1))='T'        " & vbCrLf)
        SQL.Append("     THEN LEFT(LTRIM(材質),2) + 鋼種 + '-' + RIGHT(RTRIM(材質),1)     " & vbCrLf)
        SQL.Append("     WHEN LEN(材質) = 3 AND ISNUMERIC(RIGHT(RTRIM(材質),1)) = 0 AND UPPER(LEFT(LTRIM(材質),1))='T'        " & vbCrLf)
        SQL.Append("     THEN LEFT(LTRIM(材質),2) + 鋼種 + RIGHT(RTRIM(材質),1)       " & vbCrLf)
        SQL.Append("     WHEN LEN(LTRIM(材質)) > 0        " & vbCrLf)
        SQL.Append("     THEN 鋼種 + '-' + 材質     " & vbCrLf)
        SQL.Append("     ELSE       " & vbCrLf)
        SQL.Append("     鋼種     " & vbCrLf)
        SQL.Append("     END        " & vbCrLf)
        SQL.Append("     AS 鋼種      " & vbCrLf)
        SQL.Append(" ,CASE WHEN (SELECT 'Y' FROM [FORCUSTOMERSTEELANDTYPE]      " & vbCrLf)
        SQL.Append("     WHERE [FORCUSTOMERSTEELANDTYPE].[STEELKIND] = [分析資料].[鋼種]      " & vbCrLf)
        SQL.Append("     AND [FORCUSTOMERSTEELANDTYPE].[TYPE] = [分析資料].[材質]         " & vbCrLf)
        SQL.Append("     AND [FORCUSTOMERSTEELANDTYPE].[SPECIALPROCESSTYPE]='1') = 'Y' AND 站別 = 'C1'        " & vbCrLf)
        SQL.Append(" THEN 'G1'      " & vbCrLf)
        SQL.Append(" ELSE 站別        " & vbCrLf)
        SQL.Append(" END AS 站別      " & vbCrLf)
        SQL.Append(" ,序號,判定,        " & vbCrLf)
        SQL.Append(" CASE WHEN 站別 != '' AND LEFT(LTRIM(站別),1)!= 'L' AND LEFT(LTRIM(站別),1)!= 'C' AND LEFT(LTRIM(站別),1)!= 'S'     " & vbCrLf)
        SQL.Append(" THEN ''        " & vbCrLf)
        SQL.Append(" ELSE       " & vbCrLf)
        SQL.Append(" FORMAT(DF,'0.00') END AS DF,       " & vbCrLf)
        SQL.Append(" CASE WHEN 站別 != '' AND LEFT(LTRIM(站別),1)!= 'L' AND LEFT(LTRIM(站別),1)!= 'C' AND LEFT(LTRIM(站別),1)!= 'S'     " & vbCrLf)
        SQL.Append(" THEN ''        " & vbCrLf)
        SQL.Append(" ELSE       " & vbCrLf)
        SQL.Append(" FORMAT(MD30,'0.00') END AS MD30,ROUND(C,3) AS C,ROUND(SI,3) AS SI,ROUND(MN,3) AS MN,ROUND(P,3) AS P,ROUND(S,3) AS S,ROUND(CR,3) AS CR,ROUND(NI,3) AS NI,ROUND(CU,3) AS CU,ROUND(MO,3) AS MO,ROUND(SN,3) AS SN,ROUND(PB,3) AS PB,       " & vbCrLf)
        SQL.Append(" CASE WHEN (STR(ROUND(N1,3),8,3) = 0.000)       " & vbCrLf)
        SQL.Append(" THEN ('--')        " & vbCrLf)
        SQL.Append(" ELSE FORMAT(N1,'0.000') END AS N2,日期,時間,ROUND(CO,3) AS CO ,ROUND(AL,3) AS AL ,ROUND(TI,3) AS TI ,ROUND(NB,3) AS NB ,       " & vbCrLf)
        SQL.Append(" CASE WHEN (STR(ROUND(O1,3),8,3) = 0.000)       " & vbCrLf)
        SQL.Append(" THEN ('--')        " & vbCrLf)
        SQL.Append(" ELSE FORMAT(O1,'0.000') END AS O2, FORMAT(B,'0.00000') AS B,ROUND(CA,5) AS CA,ROUND(MG,5) AS MG, 材質, FE        " & vbCrLf)
        SQL.Append(" ,(SELECT 'Y' FROM [FORCUSTOMERSTEELANDTYPE]        " & vbCrLf)
        SQL.Append("     WHERE [FORCUSTOMERSTEELANDTYPE].[STEELKIND] = [分析資料].[鋼種]      " & vbCrLf)
        SQL.Append("     AND [FORCUSTOMERSTEELANDTYPE].[TYPE] = [分析資料].[材質]         " & vbCrLf)
        SQL.Append("     AND [FORCUSTOMERSTEELANDTYPE].[SPECIALPROCESSTYPE]='1')        " & vbCrLf)
        SQL.Append("     INGOT,V,[AS],BI,SB,ZN,ZR,GP,TA ,([C]+[N1]) AS CANDN, ([NB]+[TA]) AS NBANDTA        " & vbCrLf)
        SQL.Append("     FROM 分析資料          " & vbCrLf)
        SQL.Append("     WHERE(日期 >= " & W_startdate & " AND 日期 <= " & W_enddate & " ) " & vbCrLf)
        SQL.Append("       AND  (爐號 = '" & tbFurnaceNumber.Text & "' OR '" & tbFurnaceNumber.Text & "'='') " & vbCrLf)
        SQL.Append("       AND  (鋼種 = '" & tbKind.Text & "' OR '" & tbKind.Text & "'='') " & vbCrLf)
        SQL.Append("       AND  (站別 Like '" & DDLStationName.SelectedValue & "'" & vbCrLf)
        SQL.Append("       OR '" & DDLStationName.SelectedValue & "' ='ALL' " & vbCrLf)
        SQL.Append("       OR ('" & DDLStationName.SelectedValue & "'='INGOT' " & vbCrLf)
        SQL.Append("       AND EXISTS (SELECT 1 FROM [FORCUSTOMERSTEELANDTYPE] WHERE [FORCUSTOMERSTEELANDTYPE].[STEELKIND]= [分析資料].[鋼種]  AND [FORCUSTOMERSTEELANDTYPE].[TYPE]= [分析資料].[材質] AND [FORCUSTOMERSTEELANDTYPE].[SPECIALPROCESSTYPE]='1'))) " & vbCrLf)
        SQL.Append("        " & vbCrLf)
        SQL.Append("        ORDER BY 日期 DESC,時間 DESC        " & vbCrLf)

        hfSQL.Value = SQL.ToString

        hfParam.Value = W_startdate & "," & W_enddate
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

        Dim sqlAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCdb01")
        retTable = sqlAdapter.SelectQuery(fromSQL)

        Return retTable
    End Function

#End Region


    
    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        MakQryStringToControl()
        Dim W_Param() As String = Me.hfParam.Value.Split(",")
        ''DataConvertExcel( DataTable , String )
        Dim table As DataTable = Search(Me.hfSQL.Value, Me.hfParam.Value)
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = _
            New PublicClassLibrary.DataConvertExcel(table, _
            "煉鋼製程化學成份歷史資料_" & W_Param(0) & "~" & W_Param(1) & "_" & Format(Now, "yyyyMMddhhmmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)


    End Sub
    ''' <summary>
    ''' Fix table for excel and GridView
    ''' </summary>
    ''' <param name="retTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
#Region " 修正DataTable "
    'Private Function fixtable(ByVal retTable As DataTable)
    '    Dim finalTable As New DataTable
    '    finalTable = retTable.Clone()
    '    finalTable.Columns.Item("鋼種").MaxLength = 10

    '    finalTable.Columns.Item("O2").DataType = Type.GetType("System.String")
    '    finalTable.Columns.Item("N2").DataType = Type.GetType("System.String")
    '    ''避免科學記號轉string
    '    For Each column In finalTable.Columns
    '        column.ReadOnly = False
    '    Next
    '    For Each row In retTable.Rows
    '        finalTable.ImportRow(row)
    '    Next

    '    For Each tableRow In finalTable.Rows
    '        If Not String.IsNullOrEmpty(tableRow.Item("材質").ToString.Trim) Then
    '            Select Case True
    '                Case tableRow.Item("材質").ToString.Trim.Length = 2 AndAlso Left(tableRow.Item("材質").ToString.Trim, 1).ToUpper = "T"
    '                    tableRow.Item("鋼種") = Left(tableRow.Item("材質").ToString.Trim, 2) & tableRow.Item("鋼種").ToString
    '                Case tableRow.Item("材質").ToString.Trim.Length = 3 And IsNumeric(Right(tableRow.Item("材質").ToString.Trim, 1)) AndAlso Left(tableRow.Item("材質").ToString.Trim, 1).ToUpper = "T"
    '                    tableRow.Item("鋼種") = Left(tableRow.Item("材質").ToString.Trim, 2) & tableRow.Item("鋼種").ToString & "-" & Right(tableRow.Item("材質").ToString.Trim, 1)
    '                Case tableRow.Item("材質").ToString.Trim.Length = 3 And Not IsNumeric(Right(tableRow.Item("材質").ToString.Trim, 1)) AndAlso Left(tableRow.Item("材質").ToString.Trim, 1).ToUpper = "T"
    '                    tableRow.Item("鋼種") = Left(tableRow.Item("材質").ToString.Trim, 2) & tableRow.Item("鋼種").ToString & Right(tableRow.Item("材質").ToString.Trim, 1)
    '                    '1020116 by renhsin
    '                    'Case GetMaterialCell.Text.Length > 0 And IsNumeric(Right(GetMaterialCell.Text, 1))
    '                    '    SteelKindCell.Text = SteelKindCell.Text & "-" & GetMaterialCell.Text
    '                Case tableRow.Item("材質").ToString.Trim.Length > 0
    '                    If tableRow.Item("材質").ToString.Trim <> "" Then
    '                        tableRow.Item("鋼種") = tableRow.Item("鋼種").ToString & "-" & tableRow.Item("材質").ToString.Trim
    '                    Else
    '                        tableRow.Item("鋼種") = tableRow.Item("鋼種").ToString
    '                    End If
    '            End Select
    '        End If

    '        If Not String.IsNullOrEmpty(tableRow.Item("站別").ToString) AndAlso Not {"L", "C", "S"}.Contains(Left(Trim(tableRow.Item("站別").ToString), 1)) Then
    '            tableRow.Item("DF") = DBNull.Value
    '            tableRow.Item("MD30") = DBNull.Value
    '        End If

    '        'If Not String.IsNullOrEmpty(StationKind) AndAlso Not {"L", "C", "S"}.Contains(Left(Trim(StationKind), 1)) Then
    '        '    GridViewCell(EachRow, "DF").Text = ""
    '        '    GridViewCell(EachRow, "MD30").Text = ""
    '        'End If

    '        If tableRow.Item("N2") = "0.000" Then
    '            tableRow.Item("N2") = "--"
    '        End If

    '        If tableRow.Item("O2") = "0.000" Then
    '            tableRow.Item("O2") = "--"
    '        End If

    '        If tableRow.Item("INGOT").ToString.Trim = "Y" AndAlso tableRow.Item("站別").ToString.Trim = "C1" Then
    '            tableRow.Item("站別") = "G1"
    '        End If
    '    Next

    '    '1020115 by renhsin,INGOT=Y 且站別為C1 > 站別:更改為G1

    '    Return finalTable
    '    'MsgBox(finalTable.Rows.Count())
    'End Function
#End Region

   
   
End Class