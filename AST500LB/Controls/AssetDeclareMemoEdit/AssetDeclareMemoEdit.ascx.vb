Public Class AssetDeclareMemoEdit
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As List(Of ASTB05PF)
        If String.IsNullOrEmpty(QryString) OrElse QryString.Trim.Length = 0 Then
            Return New List(Of ASTB05PF)
        End If
        Return CompanyORMDB.AST500LB.AST501PF.CDBSelect(Of CompanyORMDB.AST500LB.ASTB05PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function

#End Region
#Region "刪除 方法:CDBDelete"
    <DataObjectMethod(DataObjectMethodType.Delete)> _
    Public Shared Function CDBDelete(ByVal SourceObject As ASTB05PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBDelete()
    End Function
#End Region
#Region "修改 方法:CDBUpdate"
    <DataObjectMethod(DataObjectMethodType.Update)> _
    Public Shared Function CDBUpdate(ByVal SourceObject As ASTB05PF) As Integer
        SourceObject.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Return SourceObject.CDBSave
    End Function
#End Region

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQLString As String = Nothing
        Dim DeclareStartDate As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbStartDate.Text, Date)).TwIntegerTypeData \ 100
        Dim DeclareEndDate As Integer = New CompanyORMDB.AS400DateConverter(CType(Me.tbEndDate.Text, Date)).TwIntegerTypeData \ 100
        SQLString = " Select A.*, B.* From @#AST500LB.ASTB03PF.ASTFSA A LEFT JOIN  @#AST500LB.ASTB05PF B ON A.NUMBER = B.NUMBER AND A.DATEC = B.DATEC "
        SQLString &= " Where A.DATEC>=" & DeclareStartDate & " AND A.DATEC<=" & DeclareEndDate

        If Not String.IsNullOrEmpty(tbNumber.Text) And tbNumber.Text.Trim.Length > 0 Then
            SQLString &= " AND A.NUMBER ='" & tbNumber.Text.Trim & "'"
        End If
        If Not String.IsNullOrEmpty(tbAssetName.Text) And tbAssetName.Text.Trim.Length > 0 Then
            SQLString &= " AND A.CNAME LIKE '%" & tbAssetName.Text.Trim & "%'"
        End If
        If Not String.IsNullOrEmpty(tbStationKeyWords.Text) AndAlso tbStationKeyWords.Text.Trim.Length > 0 Then
            SQLString &= " AND ("
            Dim IsFirtIn As Boolean = True
            For Each EachItem As String In tbStationKeyWords.Text.Split("@")
                SQLString &= IIf(IsFirtIn, Nothing, " OR ")
                SQLString &= " B.STATION LIKE '%" & EachItem.Trim & "%'"
                IsFirtIn = False
            Next
            SQLString &= ")"
        End If
        If Not String.IsNullOrEmpty(tbMemoKeyWords.Text) AndAlso tbMemoKeyWords.Text.Trim.Length > 0 Then
            SQLString &= " AND ("
            Dim IsFirtIn As Boolean = True
            For Each EachItem As String In tbMemoKeyWords.Text.Split("@")
                SQLString &= IIf(IsFirtIn, Nothing, " OR ")
                SQLString &= " B.MEMO1 LIKE '%" & EachItem.Trim & "%'"
            Next
            SQLString &= ")"
        End If

        Me.hfQryString.Value = SQLString & " ORDER BY A.DATEC"
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = "1900/01/01"
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        MakQryStringToControl()
        Dim ReturnValue As New AST500LBDataSet.AssetDeclareMemoDataTable
        For Each EachItem In Search(Me.hfQryString.Value)
            Dim AddItem As AST500LBDataSet.AssetDeclareMemoRow = ReturnValue.NewRow
            With AddItem
                .資產編號 = EachItem.NUMBER
                .數量 = EachItem.Quantity
                .使用單位 = EachItem.UseDept
                .資產名稱 = EachItem.About_ASTB03PF_Name
                .報廢年月 = EachItem.DeclareDate
                .處理結果 = EachItem.STATION
                .簽准廢品處理方式 = EachItem.MEMO1
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(ReturnValue, "固定資產報廢備註查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)

    End Sub
End Class