Public Class ClipPaper
    Inherits System.Web.UI.UserControl


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            P_Init()
        End If
    End Sub

    Private Sub P_Init()
        tbDateStart.Text = Format(New Date(Now.Year, Now.Month, 1), "yyyy/MM/dd")
        tbDateEnd.Text = Format(Now, "yyyy/MM/dd")

        ddSurface.Items.Clear()
        ddSurface.Items.Add("2D")

    End Sub

#Region "Enum"
    Enum Enum_Column
        繳庫單位 = 0
        繳庫編號 = 1
        鋼捲號碼 = 2
        報價單號 = 3
        鋼種 = 4
        表面 = 5
        厚度 = 6
        寬度 = 7
        淨重 = 8
        毛重 = 9
        儲區 = 10
        繳庫日期 = 11
    End Enum

    Private Function getColumnName(ByVal fromEnum_Column As Enum_Column) As String
        Dim retColumnName As String = ""

        Select Case fromEnum_Column
            Case Enum_Column.繳庫單位
                retColumnName = "繳庫單位"
            Case Enum_Column.繳庫編號
                retColumnName = "繳庫編號"
            Case Enum_Column.鋼捲號碼
                retColumnName = "鋼捲號碼"
            Case Enum_Column.報價單號
                retColumnName = "報價單號"
            Case Enum_Column.鋼種
                retColumnName = "鋼種"
            Case Enum_Column.表面
                retColumnName = "表面"
            Case Enum_Column.厚度
                retColumnName = "厚度"
            Case Enum_Column.寬度
                retColumnName = "寬度"
            Case Enum_Column.淨重
                retColumnName = "淨重"
            Case Enum_Column.毛重
                retColumnName = "毛重"
            Case Enum_Column.儲區
                retColumnName = "儲區"
            Case Enum_Column.繳庫日期
                retColumnName = "繳庫日期"
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

        retDataTable.Columns.Add(getColumnName(Enum_Column.繳庫單位))
        retDataTable.Columns.Add(getColumnName(Enum_Column.繳庫編號))
        retDataTable.Columns.Add(getColumnName(Enum_Column.鋼捲號碼))
        retDataTable.Columns.Add(getColumnName(Enum_Column.報價單號))
        retDataTable.Columns.Add(getColumnName(Enum_Column.鋼種))
        retDataTable.Columns.Add(getColumnName(Enum_Column.表面))
        retDataTable.Columns.Add(getColumnName(Enum_Column.厚度))
        retDataTable.Columns.Add(getColumnName(Enum_Column.寬度))
        retDataTable.Columns.Add(getColumnName(Enum_Column.淨重))
        retDataTable.Columns.Add(getColumnName(Enum_Column.毛重))
        retDataTable.Columns.Add(getColumnName(Enum_Column.儲區))
        retDataTable.Columns.Add(getColumnName(Enum_Column.繳庫日期))

        Dim as400DateConverter As New CompanyORMDB.AS400DateConverter
        Dim showDate As String
        Dim queryList As List(Of CompanyORMDB.PPS100LB.PPSCIAPF) = CompanyORMDB.PPS100LB.PPSCIAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSCIAPF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each eachItem As CompanyORMDB.PPS100LB.PPSCIAPF In queryList
            AddItem = retDataTable.NewRow
            showDate = Format(as400DateConverter.StringToDate(eachItem.CIA58), "yyyy/MM/dd")

            AddItem.Item(Enum_Column.繳庫單位) = eachItem.CIA56
            AddItem.Item(Enum_Column.繳庫編號) = eachItem.CIA01
            AddItem.Item(Enum_Column.鋼捲號碼) = eachItem.CIA02.Trim & eachItem.CIA03.Trim
            AddItem.Item(Enum_Column.報價單號) = eachItem.CIA04
            AddItem.Item(Enum_Column.鋼種) = eachItem.CIA05
            AddItem.Item(Enum_Column.表面) = eachItem.CIA06
            AddItem.Item(Enum_Column.厚度) = eachItem.CIA07
            AddItem.Item(Enum_Column.寬度) = eachItem.CIA08
            AddItem.Item(Enum_Column.淨重) = eachItem.CIA13
            AddItem.Item(Enum_Column.毛重) = eachItem.CIA14
            AddItem.Item(Enum_Column.儲區) = eachItem.CIA15
            AddItem.Item(Enum_Column.繳庫日期) = showDate

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
        retSQL.Append(" FROM @#pps100lb.ppsciapf " & vbNewLine)
        retSQL.Append(" WHERE 1=1 " & vbNewLine)
        retSQL.Append("     AND cia58 between " & queryDateStart & " and " & queryDateEnd & " " & vbNewLine)
        retSQL.Append("     AND cia06='" & ddSurface.Text & " ' " & vbNewLine)
        retSQL.Append("     AND cia69='P' " & vbNewLine)        'P:夾襯紙


        retSQL.Append(" ORDER BY cia01 " & vbNewLine)

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

            Dim newWidth As Integer
            For II As Integer = 0 To e.Row.Cells.Count - 1
                Select Case II
                    Case Enum_Column.繳庫編號, Enum_Column.報價單號, Enum_Column.繳庫日期
                        newWidth = 150
                    Case Else
                        newWidth = 100
                End Select
                '調整寬度
                e.Row.Cells(II).Width = newWidth
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

        ExcelConvert = New PublicClassLibrary.DataConvertExcel(QueryDataTable, "成品庫夾襯紙鋼捲查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If
    End Sub

    Protected Sub tbClearSearchCondiction_Click(sender As Object, e As EventArgs) Handles tbClearSearchCondiction.Click
        P_Init()
    End Sub

End Class