Public Class StockStaticUnAssem
    Inherits System.Web.UI.UserControl

    Public SystemRunModeText As String
    Private Shared _SystemRunMode As SystemRunMode_Num
    Private Enum SystemRunMode_Num
        無主庫存_不含客戶保留 = 1
        無主庫存_客戶已保留 = 2
    End Enum


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case SystemRunModeText
            Case "無主庫存_不含客戶保留"
                _SystemRunMode = SystemRunMode_Num.無主庫存_不含客戶保留
                MultiView1.SetActiveView(View1)
            Case Else
                _SystemRunMode = SystemRunMode_Num.無主庫存_客戶已保留
                MultiView1.SetActiveView(View2)
        End Select


        If Not IsPostBack Then
            Call InitFrom()
        End If
    End Sub

    Private Sub InitFrom()
        tb繳庫日期Start.Text = "1980/01/01"
        tb繳庫日期End.Text = Format(Now, "yyyy/MM/dd") ' Format(DateAdd(DateInterval.Month, -2, Now), "yyyy/MM/dd")
        tb鋼種.Text = ""
        tb等級.Text = ""
        tb客戶代號.Text = ""
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call InitFrom()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call MakeQuerySQL()
    End Sub

    Protected Sub btnSearchDownExcel_Click(sender As Object, e As EventArgs) Handles btnSearchDownExcel.Click
        Call MakeQuerySQL()

        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing
        Dim QueryDataTable As DataTable = Search(hfSQL.Value, ddDisplayType.SelectedValue, hfParam.Value)

        Dim excelFileName As String
        Select Case _SystemRunMode
            Case SystemRunMode_Num.無主庫存_不含客戶保留
                excelFileName = "無主庫存查詢(不含客戶保留)"
            Case Else
                excelFileName = "客戶已保留無主庫存查詢"
        End Select

        ExcelConvert = New PublicClassLibrary.DataConvertExcel(QueryDataTable, excelFileName & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If
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
                Case getGridName(gridName_Enum.繳庫日期), getGridName(gridName_Enum.厚度), _
                            getGridName(gridName_Enum.寬度), getGridName(gridName_Enum.重量)
                    cellNow.Attributes.Add("style", "text-align:right")
            End Select


            '調整寬度
            Select Case columnName
                Case getGridName(gridName_Enum.鋼種), getGridName(gridName_Enum.表面), _
                           getGridName(gridName_Enum.厚度), getGridName(gridName_Enum.毛修邊), getGridName(gridName_Enum.等級)
                    newWidth = 50
                Case getGridName(gridName_Enum.客戶代號), getGridName(gridName_Enum.鋼捲號碼), getGridName(gridName_Enum.繳庫日期), _
                            getGridName(gridName_Enum.寬度), getGridName(gridName_Enum.重量)
                    newWidth = 80
            End Select
            cellNow.Width = newWidth

        Next II

    End Sub

#Region "MakeQuerySQL:查詢SQL"
    Private Sub MakeQuerySQL()
        Dim querySQL As New StringBuilder
        Dim queryParam As String = Format(Now, "yyyy/MM/dd hh:mm:ss")

        querySQL.Append("SELECT v1.* " & vbNewLine)
        querySQL.Append("FROM ( " & vbNewLine)
        querySQL.Append("		SELECT SUBSTR(cia04,1,3)custID, cia02 || cia03 ciaNum " & vbNewLine)
        querySQL.Append("			  ,cia05, cia58, cia06 " & vbNewLine)
        querySQL.Append("			  ,TRIM(SUBSTR(cia39,1,2)) || '.' || SUBSTR(cia39,3,2) cia39B, cia40 " & vbNewLine)
        querySQL.Append("			  ,cia61,  cia13, cia16 || TRIM(cia52) Lev " & vbNewLine)
        querySQL.Append(" " & vbNewLine)
        querySQL.Append("		From @#PPS100LB.PPSCIALJ A JOIN @#SLS300LB.SL2CH2PF B ON  a.cia06=b.ch201  " & vbNewLine)
        querySQL.Append("		WHERE 1=1 " & vbNewLine)
        querySQL.Append("		  AND  b.ch202<>'Y'  " & vbNewLine)
        querySQL.Append("		  AND TRIM(SUBSTR(cia04,4))='' " & vbNewLine)
        querySQL.Append(") v1 " & vbNewLine)
        querySQL.Append("WHERE 1=1 " & vbNewLine)
        querySQL.Append("     AND  " & IIf(_SystemRunMode = SystemRunMode_Num.無主庫存_不含客戶保留, "", "NOT") & " ( custid IN ('','XXX')) " & vbNewLine)

        Select Case _SystemRunMode
            Case SystemRunMode_Num.無主庫存_不含客戶保留
                If Not String.IsNullOrEmpty(tb鋼種.Text) AndAlso tb鋼種.Text.Trim.Length > 0 Then
                    querySQL.Append("      AND cia05 IN ('" & tb鋼種.Text.Replace(",", "','") & "') " & vbNewLine)
                    queryParam &= IIf(queryParam = "", "", "|") & tb鋼種.Text
                End If

                If Not String.IsNullOrEmpty(tb等級.Text) AndAlso tb等級.Text.Trim.Length > 0 Then
                    querySQL.Append("      AND lev IN ('" & tb等級.Text.Replace(",", "','") & "') " & vbNewLine)
                    queryParam &= IIf(queryParam = "", "", "|") & tb等級.Text
                End If

                Dim queryDateStart As String = New AS400DateConverter(tb繳庫日期Start.Text).TwIntegerTypeData
                Dim queryDateEnd As String = New AS400DateConverter(tb繳庫日期End.Text).TwIntegerTypeData
                querySQL.Append("      AND cia58 >=" & queryDateStart & " AND cia58<=" & queryDateEnd & " " & vbNewLine)

                querySQL.Append("ORDER BY cia05,  ciaNum " & vbNewLine) '鋼種/鋼捲編號

                queryParam &= IIf(queryParam = "", "", "|") & queryDateStart & "~" & queryDateEnd

            Case SystemRunMode_Num.無主庫存_客戶已保留
                tb客戶代號.Text = tb客戶代號.Text.Replace("'", Nothing)
                If Not String.IsNullOrEmpty(tb客戶代號.Text) AndAlso tb客戶代號.Text.Trim.Length > 0 Then
                    If tb客戶代號.Text.Contains("~") Then
                        querySQL.Append("     AND ( custID >= '" & tb客戶代號.Text.Split("~")(0).Trim & "' " & vbNewLine)
                        querySQL.Append("     AND custID <= '" & tb客戶代號.Text.Split("~")(1).Trim & "' ) " & vbNewLine)
                    Else
                        querySQL.Append("      AND custID IN ('" & tb客戶代號.Text.Replace(",", "','") & "') " & vbNewLine)
                    End If
                    queryParam = tb客戶代號.Text
                End If

                querySQL.Append("ORDER BY custid, cia05,  ciaNum " & vbNewLine) '客戶代號/鋼種/鋼捲編號
        End Select

        hfSQL.Value = querySQL.ToString
        hfParam.Value = queryParam
    End Sub
#End Region

#Region "Search:搜尋統計資料"
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function Search(ByVal fromSQL As String, ByVal fromDisplayType As String, ByVal fromParam As String) As DataTable
        Dim retDataTable As New DataTable
        If String.IsNullOrEmpty(fromSQL) OrElse String.IsNullOrEmpty(fromParam) Then Return retDataTable

        '明細
        Dim queryDataTableDetail As DataTable = New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).SelectQuery(fromSQL)

        '合計
        Dim StaticListSum As List(Of class合計) = SearchStaticTotal(queryDataTableDetail, fromDisplayType)


        Select Case fromDisplayType
            Case "明細"
                Display明細(retDataTable, queryDataTableDetail)

            Case "合計"
                Display合計(retDataTable, StaticListSum)

            Case "明細與合計"
                Display明細與合計(retDataTable, queryDataTableDetail, StaticListSum)
        End Select

        Return retDataTable
    End Function

    Private Shared Function SearchStaticTotal(ByVal fromDataTable As DataTable, ByVal fromDisplayType As String) As List(Of class合計)
        If fromDisplayType = "明細" Then Return Nothing

        Dim queryListTotal As List(Of class合計) = Nothing

        Select Case _SystemRunMode
            Case SystemRunMode_Num.無主庫存_不含客戶保留
                queryListTotal = (From A In fromDataTable.AsEnumerable _
                                                                Group A By groupKind = A.Item("cia05") Into GroupSum = Sum(Integer.Parse(A.Item("cia13"))) _
                                                                Order By groupKind _
                                                                Select New class合計("", groupKind, GroupSum)).ToList
            Case SystemRunMode_Num.無主庫存_客戶已保留
                queryListTotal = (From A In fromDataTable.AsEnumerable _
                                                                Group A By groupCustId = A.Item("custID"), groupKind = A.Item("cia05") Into GroupSum = Sum(Integer.Parse(A.Item("cia13"))) _
                                                                Order By groupCustId, groupKind
                                                                Select New class合計(groupCustId, groupKind, GroupSum)).ToList
        End Select

        Return queryListTotal
    End Function


#End Region

#Region "Display相關"
    Enum gridName_Enum
        客戶代號 = 1
        鋼種 = 2
        鋼捲號碼 = 3
        繳庫日期 = 4
        表面 = 5
        厚度 = 6
        寬度 = 7
        毛修邊 = 8
        重量 = 9
        等級 = 10
    End Enum

    Private Shared Function getGridName(ByVal fromGridName_Enum As gridName_Enum) As String
        Select Case fromGridName_Enum
            Case gridName_Enum.客戶代號
                Return "客戶代號"
            Case gridName_Enum.鋼種
                Return "鋼種"
            Case gridName_Enum.鋼捲號碼
                Return "鋼捲號碼"
            Case gridName_Enum.繳庫日期
                Return "繳庫日期"
            Case gridName_Enum.表面
                Return "表面"
            Case gridName_Enum.厚度
                Return "厚度"
            Case gridName_Enum.寬度
                Return "寬度"
            Case gridName_Enum.毛修邊
                Return "毛修邊"
            Case gridName_Enum.重量
                Return "重量"
            Case gridName_Enum.等級
                Return "等級"
            Case Else
                Throw New Exception("傳入的常數錯誤")
        End Select

    End Function

    Private Shared Sub Display合計(ByRef fromReturnDataTable As DataTable, ByVal fromStaticListSum As List(Of class合計))
        Dim AddItem As DataRow = Nothing

        For Each eachItem As class合計 In fromStaticListSum
            If fromReturnDataTable.Columns.Count = 0 Then
                If eachItem._客戶代號 <> "" Then fromReturnDataTable.Columns.Add(getGridName(gridName_Enum.客戶代號))
                fromReturnDataTable.Columns.Add(getGridName(gridName_Enum.鋼種))
                fromReturnDataTable.Columns.Add(getGridName(gridName_Enum.重量))
            End If

            AddItem = fromReturnDataTable.NewRow
            If eachItem._客戶代號 <> "" Then AddItem.Item(getGridName(gridName_Enum.客戶代號)) = eachItem._客戶代號
            AddItem.Item(getGridName(gridName_Enum.鋼種)) = eachItem._鋼種
            AddItem.Item(getGridName(gridName_Enum.重量)) = Math.Round((eachItem._重量 / 1000), 3, MidpointRounding.AwayFromZero)

            fromReturnDataTable.Rows.Add(AddItem)
        Next
    End Sub


    Private Shared Sub Display明細(ByRef fromReturnDataTable As DataTable, ByVal fromQueryDetail As DataTable)
        Display明細與合計(fromReturnDataTable, fromQueryDetail, Nothing)
    End Sub

    Private Shared Sub Display明細與合計(ByRef fromReturnDataTable As DataTable, ByVal fromQueryDetail As DataTable, ByVal fromStaticListSum As List(Of class合計))
        Dim _客戶代號Last As String = "X"
        Dim _客戶代號Now As String = ""
        Dim _鋼種Last As String = "X"
        Dim _鋼種Now As String = ""

        Dim AddItem As DataRow = Nothing

        For Each eachItem As DataRow In fromQueryDetail.Rows
            'Add Column
            '----------------------------------------------------------------------------------------------------------------------------------
            If fromReturnDataTable.Columns.Count = 0 Then
                Dim ColumnName() As String = {getGridName(gridName_Enum.客戶代號), _
                                                                                 getGridName(gridName_Enum.鋼種), _
                                                                                 getGridName(gridName_Enum.鋼捲號碼), _
                                                                                 getGridName(gridName_Enum.繳庫日期), _
                                                                                 getGridName(gridName_Enum.表面), _
                                                                                 getGridName(gridName_Enum.厚度), _
                                                                                 getGridName(gridName_Enum.寬度), _
                                                                                 getGridName(gridName_Enum.毛修邊), _
                                                                                 getGridName(gridName_Enum.重量), _
                                                                                 getGridName(gridName_Enum.等級)}

                For Each eachItemColumn As String In ColumnName
                    fromReturnDataTable.Columns.Add(eachItemColumn)
                Next

                If _SystemRunMode = SystemRunMode_Num.無主庫存_不含客戶保留 Then fromReturnDataTable.Columns.Remove(getGridName(gridName_Enum.客戶代號))
            End If

            'Add Data
            '----------------------------------------------------------------------------------------------------------------------------------
            AddItem = fromReturnDataTable.NewRow

            If _SystemRunMode = SystemRunMode_Num.無主庫存_客戶已保留 Then AddItem.Item(getGridName(gridName_Enum.客戶代號)) = eachItem.Item("custID")
            AddItem.Item(getGridName(gridName_Enum.鋼種)) = eachItem.Item("cia05")

            AddItem.Item(getGridName(gridName_Enum.鋼捲號碼)) = eachItem.Item("ciaNum")
            AddItem.Item(getGridName(gridName_Enum.繳庫日期)) = eachItem.Item("cia58")
            AddItem.Item(getGridName(gridName_Enum.表面)) = eachItem.Item("cia06")
            AddItem.Item(getGridName(gridName_Enum.厚度)) = eachItem.Item("cia39B")
            AddItem.Item(getGridName(gridName_Enum.寬度)) = eachItem.Item("cia40")
            AddItem.Item(getGridName(gridName_Enum.毛修邊)) = eachItem.Item("cia61")
            AddItem.Item(getGridName(gridName_Enum.重量)) = Math.Round((Integer.Parse(eachItem.Item("cia13")) / 1000), 3, MidpointRounding.AwayFromZero)
            AddItem.Item(getGridName(gridName_Enum.等級)) = eachItem.Item("Lev")

            If _SystemRunMode = SystemRunMode_Num.無主庫存_客戶已保留 Then
                _客戶代號Now = AddItem.Item(getGridName(gridName_Enum.客戶代號))
            Else
                _客戶代號Now = ""
            End If
            _鋼種Now = AddItem.Item(getGridName(gridName_Enum.鋼種))
            Display明細與合計_小計(fromReturnDataTable, fromStaticListSum, _客戶代號Last, _客戶代號Now, _鋼種Last, _鋼種Now)

            fromReturnDataTable.Rows.Add(AddItem)
        Next


        _客戶代號Now = "最後一筆資料"
        _鋼種Now = _客戶代號Now
        Display明細與合計_小計(fromReturnDataTable, fromStaticListSum, _客戶代號Last, _客戶代號Now, _鋼種Last, _鋼種Now)
    End Sub


    Private Shared Sub Display明細與合計_小計(ByRef fromReturnDataTable As DataTable, ByRef fromStaticListSum As List(Of class合計), _
                                                                                          ByRef from客戶代號Last As String, ByRef from客戶代號Now As String, _
                                                                                          ByRef from鋼種Last As String, ByRef from鋼種Now As String)
        If IsNothing(fromStaticListSum) Then Exit Sub
        If from客戶代號Last = "X" AndAlso from鋼種Last = "X" Then
            from客戶代號Last = from客戶代號Now
            from鋼種Last = from鋼種Now
            Exit Sub
        End If
        If from客戶代號Last = from客戶代號Now AndAlso from鋼種Last = from鋼種Now Then Exit Sub

        Dim linq客戶代號Last As String = from客戶代號Last
        Dim linq鋼種Last As String = from鋼種Last
        Dim queryItem As class合計 = (From A In fromStaticListSum Where A._客戶代號 = linq客戶代號Last And A._鋼種 = linq鋼種Last Select A).FirstOrDefault
        If IsNothing(queryItem) Then Exit Sub

        Dim AddItem As DataRow = Nothing
        AddItem = fromReturnDataTable.NewRow
        If _SystemRunMode = SystemRunMode_Num.無主庫存_客戶已保留 Then AddItem.Item("客戶代號") = from客戶代號Last
        AddItem.Item(getGridName(gridName_Enum.鋼種)) = from鋼種Last
        AddItem.Item(getGridName(gridName_Enum.鋼捲號碼)) = "小計"
        AddItem.Item(getGridName(gridName_Enum.重量)) = Math.Round((Integer.Parse(queryItem._重量) / 1000), 3, MidpointRounding.AwayFromZero)

        fromReturnDataTable.Rows.Add(AddItem)

        from客戶代號Last = from客戶代號Now
        from鋼種Last = from鋼種Now
    End Sub
#End Region

    Class class合計
        Public _客戶代號 As String
        Public _鋼種 As String
        Public _重量 As Integer

        Sub New(ByVal from客戶代號 As String, ByVal from鋼種 As String, ByVal from重量 As Integer)
            _客戶代號 = from客戶代號
            _鋼種 = from鋼種
            _重量 = from重量
        End Sub
    End Class

    

End Class