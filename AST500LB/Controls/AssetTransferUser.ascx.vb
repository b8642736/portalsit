Public Partial Class AssetTransferUser
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal SQLQryString As String) As List(Of AST401PF)
        If String.IsNullOrEmpty(SQLQryString) Then
            Return New List(Of AST401PF)
        End If
        Return ClassDBAS400.CDBSelect(Of AST401PF)(SQLQryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function
#End Region
#Region "新增 方法:CDBInsert"
    <DataObjectMethod(DataObjectMethodType.Insert)> _
    Public Shared Function CDBInsert(ByVal SourceObject As AST401PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        SourceObject.TRNTIME = Format(Now, "hhmmss")
        Return SourceObject.CDBInsert()
    End Function
#End Region
#Region "更新 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As AST401PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBUpdate
    End Function
#End Region
#Region "刪除 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function CDBDelete(ByVal SourceObject As AST401PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBDelete()
    End Function
#End Region

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim WhereString As String = " Where "
        WhereString &= " TRNDATE>=" & btStartDate.Text
        WhereString &= " AND TRNDATE<=" & btEndDate.Text
        If Not String.IsNullOrEmpty(tbAssetNumber.Text) Then
            WhereString &= " AND (TNUMBER like '" & tbAssetNumber.Text & "%'"
            WhereString &= " OR FNUMBER like '" & tbAssetNumber.Text & "%')"
        End If
        If Not String.IsNullOrEmpty(tbMemo.Text) Then
            WhereString &= " AND MEMO1 like '%" & tbMemo.Text & "%'"
        End If
        Dim SQLString As String = "Select * from " & (New AST401PF).CDBFullAS400DBPath & WhereString & " Order by TRNDATE DESC"

        Me.hfQryString.Value = SQLString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            btStartDate.Text = New CompanyORMDB.AS400DateConverter(New Date(Now.Year - 1, 1, 1)).TwIntegerTypeData
            btEndDate.Text = New CompanyORMDB.AS400DateConverter(New Date(Now.Year, 12, 31)).TwIntegerTypeData
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        Me.ListView1.DataBind()
    End Sub

    Protected Sub btnSearchCondictionClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchCondictionClear.Click
        btStartDate.Text = New CompanyORMDB.AS400DateConverter(New Date(Now.Year - 1, 1, 1)).TwIntegerTypeData
        btEndDate.Text = New CompanyORMDB.AS400DateConverter(New Date(Now.Year, 12, 31)).TwIntegerTypeData
        Me.tbAssetNumber.Text = Nothing
    End Sub

    Private Sub ListView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.PreRender
        Dim InsertControl As TextBox = ListView1.InsertItem.FindControl("TRNDATETextBox")
        If String.IsNullOrEmpty(InsertControl.Text) Then
            InsertControl.Text = New CompanyORMDB.AS400DateConverter(Now).TwIntegerTypeData
        End If
    End Sub


    'Sub InsertDataValidator1_ServerValidation(ByVal source As Object, ByVal args As ServerValidateEventArgs)
    '    Dim ValidateObject As New AST401PF
    '    Dim ValidaterConrol As CustomValidator = Me.ListView1.InsertItem.FindControl("InsertDataValidator1")
    '    With ValidateObject
    '        .SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    '        .TRNDATE = CType(Me.ListView1.InsertItem.FindControl("TRNDATETextBox"), TextBox).Text
    '        .FNUMBER = CType(Me.ListView1.InsertItem.FindControl("FNUMBERTextBox"), TextBox).Text
    '        .TNUMBER = CType(Me.ListView1.InsertItem.FindControl("TNUMBERTextBox"), TextBox).Text
    '        .TDEPTSA = CType(Me.ListView1.InsertItem.FindControl("TDEPTSATextBox"), TextBox).Text
    '        Dim TrnCount As Integer = 0
    '        Try
    '            TrnCount = CType(Me.ListView1.InsertItem.FindControl("TRNCOUNTTextBox"), TextBox).Text
    '        Catch ex As Exception
    '            TrnCount = 0
    '        End Try
    '        .TRNCOUNT = TrnCount
    '    End With
    '    Dim GetErrMsg As String = ValidateObject.GetSaveCheckErrorMessage
    '    ValidaterConrol.Text = GetErrMsg
    '    args.IsValid = IsNothing(GetErrMsg)
    'End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        MakQryStringToControl()
        Dim ReturnValue As New AST500LBDataSet.AssetTransferUserDataTable
        For Each EachItem In Search(Me.hfQryString.Value)
            Dim AddItem As AST500LBDataSet.AssetTransferUserRow = ReturnValue.NewRow
            With AddItem
                .移轉日期 = EachItem.TRNDATE
                .原資產編號 = EachItem.FNUMBER
                .新資產編號 = EachItem.TNUMBER
                .原單位 = EachItem.FDEPTSA
                .新單位 = EachItem.TDEPTSA
                .移轉數量 = EachItem.TRNCOUNT
                .備註1 = EachItem.MEMO1
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(ReturnValue, "固定資產報廢備註查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)

    End Sub
End Class