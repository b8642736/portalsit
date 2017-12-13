Public Class WeightProcess2
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            P_Init()
        End If
    End Sub

    Private Sub P_Init()
        tbDateStart.Text = Format(New Date(Now.Year, Now.Month, 1), "yyyy/MM/dd")
        tbDateEnd.Text = Format(Now, "yyyy/MM/dd")

        ddLine.Items.Clear()
        ddLine.Items.Add("STK ")

        tbSerNo.Text = ""
        tbCoilNo.Text = ""
    End Sub

#Region "Enum"
    Enum Enum_Column
        日期 = 0
        時間 = 1
        磅序 = 2
        鋼捲號碼 = 3
        磅重 = 4
        使用者 = 5
        鋼捲儲區 = 6
    End Enum

    Private Function getColumnName(ByVal fromEnum_Column As Enum_Column) As String
        Dim retColumnName As String = ""

        Select Case fromEnum_Column
            Case Enum_Column.日期
                retColumnName = "日期"
            Case Enum_Column.時間
                retColumnName = "時間"
            Case Enum_Column.磅序
                retColumnName = "磅序"
            Case Enum_Column.鋼捲號碼
                retColumnName = "鋼捲號碼"
            Case Enum_Column.磅重
                retColumnName = "磅重"
            Case Enum_Column.使用者
                retColumnName = "使用者"
            Case Enum_Column.鋼捲儲區
                retColumnName = "鋼捲儲區"
        End Select

        Return retColumnName
    End Function
#End Region

#Region "Search:查詢"

    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Function Search(ByVal SQLString As String) As DataTable
        Dim AddItem As DataRow
        Dim retDataTable As New DataTable

        If String.IsNullOrEmpty(SQLString) Then
            Return retDataTable
            Exit Function
        End If

        retDataTable.Columns.Add(getColumnName(Enum_Column.日期))
        retDataTable.Columns.Add(getColumnName(Enum_Column.時間))
        retDataTable.Columns.Add(getColumnName(Enum_Column.磅序))
        retDataTable.Columns.Add(getColumnName(Enum_Column.鋼捲號碼))
        retDataTable.Columns.Add(getColumnName(Enum_Column.磅重))
        retDataTable.Columns.Add(getColumnName(Enum_Column.使用者))
        retDataTable.Columns.Add(getColumnName(Enum_Column.鋼捲儲區))

        Dim as400DateConverter As New CompanyORMDB.AS400DateConverter
        Dim showDate As String, showTime As String
        Dim queryList As List(Of CompanyORMDB.PPS100LB.PPSCICPF) = CompanyORMDB.PPS100LB.PPSCICPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSCICPF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each eachItem As CompanyORMDB.PPS100LB.PPSCICPF In queryList
            AddItem = retDataTable.NewRow
            showDate = Format(as400DateConverter.StringToDate(eachItem.CIC03), "yyyy/MM/dd")
            showTime = IIf(eachItem.CIC04.Length < 5 _
                                        , eachItem.CIC04 _
                                        , (eachItem.CIC04.Substring(0, 2) & ":" & eachItem.CIC04.Substring(2, 2) & ":" & eachItem.CIC04.Substring(4, 2)))

            AddItem.Item(Enum_Column.日期) = showDate
            AddItem.Item(Enum_Column.時間) = showTime
            AddItem.Item(Enum_Column.磅序) = eachItem.CIC05
            AddItem.Item(Enum_Column.鋼捲號碼) = eachItem.CIC01.Trim & eachItem.CIC02.Trim
            AddItem.Item(Enum_Column.磅重) = String.Format("{0:N0}", Integer.Parse(eachItem.CIC06))
            AddItem.Item(Enum_Column.使用者) = eachItem.CIC94
            AddItem.Item(Enum_Column.鋼捲儲區) = eachItem.CIC95

            retDataTable.Rows.Add(AddItem)
        Next

        Return retDataTable

    End Function
#End Region

#Region "MakeQryStringToControl"
    Private Sub MakeQryStringToControl()
        Dim retSQL As New StringBuilder
        Dim queryDateStart As String = New CompanyORMDB.AS400DateConverter(tbDateStart.Text).TwSixCharsTypeData
        Dim queryDateEnd As String = New CompanyORMDB.AS400DateConverter(tbDateEnd.Text).TwSixCharsTypeData

        retSQL.Append(" SELECT * " & vbNewLine)
        retSQL.Append(" FROM @#pps100lb.PPSCICPF " & vbNewLine)
        retSQL.Append(" WHERE 1=1 " & vbNewLine)
        retSQL.Append("     AND cic00='" & ddLine.Text & " ' " & vbNewLine)
        retSQL.Append("     AND cic03 between " & queryDateStart & " and " & queryDateEnd & " " & vbNewLine)
        If tbSerNo.Text <> "" Then
            retSQL.Append("     " & MakeQryStringWhereNum(tbSerNo.Text, "cic05") & vbNewLine)
        End If
        If tbCoilNo.Text <> "" Then
            retSQL.Append("     " & MakeQryStringWhere(tbCoilNo.Text, "cic01 || cic02") & vbNewLine)
        End If

        retSQL.Append(" ORDER BY cic03,cic05 " & vbNewLine)

        Me.hfSQLString.Value = retSQL.ToString
    End Sub

    Public Function MakeQryStringWhereNum(ByVal fromInputText As String, ByVal fromDBColumn As String) As String
        Dim retSQL As String = MakeQryStringWhere(fromInputText, fromDBColumn)
        retSQL = retSQL.Replace("'", "")
        Return retSQL
    End Function

    Public Function MakeQryStringWhere(ByVal fromInputText As String, ByVal fromDBColumn As String) As String
        Dim RetSQL As String = ""

        Dim AddWhereString As String = ""
        Dim AddWhereString1 As String = Nothing
        Dim AddWhereString2 As String = Nothing

        If Not String.IsNullOrEmpty(fromInputText) AndAlso fromInputText.Trim.Length > 0 Then
            For Each EachStoveRange As String In fromInputText.Trim.Split(",")
                If EachStoveRange.Contains("~") Then
                    AddWhereString1 &= IIf(String.IsNullOrEmpty(AddWhereString1), Nothing, " OR ")
                    AddWhereString1 &= " " & fromDBColumn & ">='" & EachStoveRange.Split("~")(0).Trim & "' AND " & fromDBColumn & "<='" & EachStoveRange.Split("~")(1).Trim & "' "
                Else
                    AddWhereString2 &= IIf(String.IsNullOrEmpty(AddWhereString2), Nothing, ",") & "'" & EachStoveRange.Trim & "'"
                End If
            Next

            AddWhereString &= AddWhereString1
            If Not String.IsNullOrEmpty(AddWhereString2) Then
                AddWhereString &= IIf(String.IsNullOrEmpty(AddWhereString), Nothing, " OR ") & " " & fromDBColumn & " IN (" & AddWhereString2 & ")"
            End If

        End If
        RetSQL = IIf(AddWhereString = "", Nothing, " AND (" & AddWhereString & ")")
        Return RetSQL
    End Function
#End Region

#Region "GridView排版：文字靠右/數字靠左"
    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            For II As Integer = 0 To e.Row.Cells.Count - 1
                '調整寬度
                e.Row.Cells(II).Width = 100
            Next II

        End If
    End Sub

#End Region

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakeQryStringToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchDownExcel_Click(sender As Object, e As EventArgs) Handles btnSearchDownExcel.Click
        MakeQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing

        Dim QueryDataTable As DataTable = Search(Me.hfSQLString.Value)

        ExcelConvert = New PublicClassLibrary.DataConvertExcel(QueryDataTable, "鋼捲過磅紀錄查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If
    End Sub

    Protected Sub tbClearSearchCondiction_Click(sender As Object, e As EventArgs) Handles tbClearSearchCondiction.Click
        P_Init()
    End Sub
End Class