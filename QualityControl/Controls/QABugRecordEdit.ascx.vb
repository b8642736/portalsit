Public Class QABugRecordEdit
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Search(ByVal QryString As String) As List(Of CompanyORMDB.SQLServer.PPS100LB.QABugRecord)
        Dim ReturnValue As New List(Of CompanyORMDB.SQLServer.PPS100LB.QABugRecord)
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If
        ReturnValue = CompanyORMDB.SQLServer.PPS100LB.QABugRecord.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.QABugRecord)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)

        Return ReturnValue
    End Function

    Public Function SearchToDataTable(ByVal QryString As String) As QualityControlDataSet.QABugRecordEditDataTable
        Dim ReturnValue As New QualityControlDataSet.QABugRecordEditDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If
        For Each EachItem As CompanyORMDB.SQLServer.PPS100LB.QABugRecord In CompanyORMDB.SQLServer.PPS100LB.QABugRecord.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.QABugRecord)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
            Dim AddRow As QualityControlDataSet.QABugRecordEditRow = ReturnValue.NewRow
            With AddRow
                .鋼捲號碼 = EachItem.CoilNumber
                .資料日期 = EachItem.DataDate
                .產線 = EachItem.StationName
                .版次 = EachItem.Version
                .資料建立時間 = EachItem.DataCreateTime
                .缺陷編號 = EachItem.QABug_Number
                .程度 = EachItem.Degree
                .起始長度 = EachItem.StartPosition
                .終止長度 = EachItem.EndPosition
                .分佈型態 = EachItem.DPositionTypeName
                .分佈起始位置 = EachItem.DPositionStart
                .分佈終止位置 = EachItem.DPositionEnd
                .正反 = EachItem.PosOrNegName
                .密度 = EachItem.Density
                .周期 = EachItem.Cycle
                .員工編號 = EachItem.EditEmployeeID
            End With
            ReturnValue.Rows.Add(AddRow)
        Next

        Return ReturnValue
    End Function
#End Region
#Region "新增 方法:CDBInsert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Function CDBInsert(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.QABugRecord) As Integer
        SourceObject.CoilNumber = SourceObject.CoilNumber.ToUpper
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        Return SourceObject.CDBInsert()
    End Function
#End Region
#Region "刪除 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function CDBDelete(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.QABugRecord) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        SourceObject.RecordState = 3
        Return SourceObject.CDBSave
    End Function
#End Region
#Region "修改 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As CompanyORMDB.SQLServer.PPS100LB.QABugRecord) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
        Return SourceObject.CDBSave
    End Function
#End Region

#Region "設定查詢條件至控制項 屬性:SetQryStringToControl"
    ''' <summary>
    ''' 設定查詢條件至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryStringToControl()
        Me.hfQryString.Value = Nothing
        Dim ReturnValue As New StringBuilder
        ReturnValue.Append("Select A.* From QABugRecord A Where RecordState<>3 ")

        If Not String.IsNullOrEmpty(tbCoilNumbers.Text) Then
            tbCoilNumbers.Text = tbCoilNumbers.Text.ToUpper
            ReturnValue.Append(" AND CoilNumber in ('" & tbCoilNumbers.Text.Replace(",", "','") & "')")
        End If

        If CheckBox1.Checked Then
            ReturnValue.Append(" AND DataDate >='" & tbStartDate.Text & "' and DataDate<='" & tbEndDate.Text & "'")
        End If

        Dim SelectLines As New StringBuilder
        SelectLines.Append(IIf(cblLines.Items(0).Selected, cblLines.Items(0).Value, Nothing))
        SelectLines.Append(IIf(cblLines.Items(1).Selected, IIf(Not String.IsNullOrEmpty(SelectLines.ToString), ",", Nothing) & cblLines.Items(1).Value, Nothing))
        SelectLines.Append(IIf(cblLines.Items(2).Selected, IIf(Not String.IsNullOrEmpty(SelectLines.ToString), ",", Nothing) & cblLines.Items(2).Value, Nothing))
        If Not String.IsNullOrEmpty(SelectLines.ToString) AndAlso SelectLines.ToString.Split(",").Count < 3 Then
            ReturnValue.Append(" AND StationName in ('" & SelectLines.ToString.Replace(",", "','") & "')")
        End If

        If Not String.IsNullOrEmpty(tbDateVersion.Text) Then
            ReturnValue.Append(" AND Version in ('" & tbDateVersion.Text.ToString.Replace(",", "','") & "')")
        End If

        If Not String.IsNullOrEmpty(tbBugCodes.Text) Then
            ReturnValue.Append(" AND QABug_Number in ('" & tbBugCodes.Text.ToString.Replace(",", "','") & "')")
        End If
        Me.hfQryString.Value = ReturnValue.ToString

       
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim StartDate As DateTime = New Date(Now.Year, Now.Month, 1)
            Dim EndDate As DateTime = Now.Date
            Me.tbStartDate.Text = StartDate
            Me.tbEndDate.Text = EndDate
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SetQryStringToControl()
        ListView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        SetQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(SearchToDataTable(Me.hfQryString.Value), "品管缺陷資料查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

    Private Sub ListView1_ItemUpdating(sender As Object, e As ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Dim tbRunClientIP As TextBox = ListView1.InsertItem.FindControl("RunClientIPTextBox")
        tbRunClientIP.Text = Me.Page.Request.UserHostAddress
    End Sub

    Private Sub ListView1_PreRender(sender As Object, e As EventArgs) Handles ListView1.PreRender
        Dim tbDataDate As TextBox = ListView1.InsertItem.FindControl("DataDateTextBox")
        Dim tbVersion As TextBox = ListView1.InsertItem.FindControl("VersionTextBox")
        Dim tbDataCreateTime As TextBox = ListView1.InsertItem.FindControl("DataCreateTimeTextBox")
        Dim tbRunClientIP As TextBox = ListView1.InsertItem.FindControl("RunClientIPTextBox")
        If String.IsNullOrEmpty(tbDataDate.Text) Then
            tbDataDate.Text = Format(Now, "yyyy/MM/dd")
        End If
        If String.IsNullOrEmpty(tbVersion.Text) Then
            tbVersion.Text = "1"
        End If
        If String.IsNullOrEmpty(tbDataCreateTime.Text) Then
            tbDataCreateTime.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
        End If
        If String.IsNullOrEmpty(tbRunClientIP.Text) Then
            tbRunClientIP.Text = Me.Page.Request.UserHostAddress
        End If
    End Sub

End Class