Public Partial Class AssetTransferSearch
    Inherits System.Web.UI.UserControl
    'Dim QryAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="AssetNumber"></param>
    ''' <param name="AssetName"></param>
    ''' <param name="PlanCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal USEState As String, ByVal AssetNumber As String, ByVal AssetName As String, ByVal PlanCode As String) As AST500LBDataSet.AssetTransferSearchDataTableDataTable
        If Not IsNothing(AssetNumber) Then
            AssetNumber = AssetNumber.Replace("'", Nothing).ToUpper
        End If
        If Not IsNothing(AssetName) Then
            AssetName = AssetName.Replace("'", Nothing)
        End If
        Dim ReturnValue As New AST500LBDataSet.AssetTransferSearchDataTableDataTable
        Dim FindObjectCash = ClassDBAS400.CDBSelect(Of AST401PF)("Select * From " & (New AST401PF).CDBFullAS400DBPath & " Order by TRNDATE, TRNTIME", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        If USEState = "INUSE" Or USEState = "ALL" Then
            For Each EachItem As CompanyORMDB.AST500LB.AST101PF In SearchAsset(Of CompanyORMDB.AST500LB.AST101PF)(AssetNumber, AssetName, PlanCode)
                Dim AboutAST401PFs As List(Of CompanyORMDB.AST500LB.AST401PF) = EachItem.AboutAST401PF(FindObjectCash)
                For EachAST401Index As Integer = 0 To IIf(AboutAST401PFs.Count = 0, 0, AboutAST401PFs.Count - 1)
                    Dim AddItem As AST500LBDataSet.AssetTransferSearchDataTableRow = ReturnValue.NewRow
                    With AddItem
                        .資產編號 = EachItem.NUMBER
                        .資產名稱 = EachItem.NAME
                        .入帳年月 = EachItem.DATE
                        .使用單位 = EachItem.AboutAST106PF_UseDept
                        .數量 = EachItem.QUANT
                        .報廢日期 = Nothing
                        If EachItem.QUANT > 0 Then
                            .單價 = EachItem.AMOUNT / EachItem.QUANT
                        End If
                        .總價 = EachItem.AMOUNT
                        .目前狀態 = "使用中(" & EachItem.NowStateChineseExplain & ")"
                        'If EachItem.N7611 > 0 Then
                        '    .殘值 = Format(EachItem.V7611, "0,0")
                        'Else
                        '    .殘值 = Format(EachItem.AMOUNT - EachItem.DEPR, "0,0")
                        'End If
                        .殘值 = Format(EachItem.AMOUNT - EachItem.DEPR, "0,0")
                        If AboutAST401PFs.Count > 0 Then
                            .移轉日期 = Format(AboutAST401PFs(EachAST401Index).TRNDATEDateFormat, "yyyy/MM/dd")
                            .移出單位 = AboutAST401PFs(EachAST401Index).FDEPTSA
                            .移入單位 = AboutAST401PFs(EachAST401Index).TDEPTSA
                        End If
                    End With
                    ReturnValue.Rows.Add(AddItem)
                Next
            Next
        End If
        If USEState = "NOUSE" Or USEState = "ALL" Then
            For Each EachItem As CompanyORMDB.AST500LB.ASTB03PF In SearchDiscardAsset(Of CompanyORMDB.AST500LB.ASTB03PF)(AssetNumber, AssetName, PlanCode)
                Dim AboutAST401PFs As List(Of CompanyORMDB.AST500LB.AST401PF) = EachItem.AboutAST401PF(FindObjectCash)
                For EachAST401Index As Integer = 0 To IIf(AboutAST401PFs.Count = 0, 0, AboutAST401PFs.Count - 1)
                    Dim AddItem As AST500LBDataSet.AssetTransferSearchDataTableRow = ReturnValue.NewRow
                    With AddItem
                        .資產編號 = EachItem.NUMBER
                        .資產名稱 = EachItem.CNAME
                        .入帳年月 = EachItem.DATE
                        .使用單位 = EachItem.AboutAST106PF_UseDept
                        .數量 = EachItem.QUANT
                        .報廢日期 = EachItem.DATEC
                        If EachItem.QUANT > 0 Then
                            .單價 = EachItem.TAMOUN / EachItem.QUANT
                        End If
                        .總價 = EachItem.TAMOUN
                        .目前狀態 = "已報廢"
                        .殘值 = EachItem.DEPREB
                        If AboutAST401PFs.Count > 0 Then
                            .移轉日期 = Format(AboutAST401PFs(EachAST401Index).TRNDATEDateFormat, "yyyy/MM/dd")
                            .移出單位 = AboutAST401PFs(EachAST401Index).FDEPTSA
                            .移入單位 = AboutAST401PFs(EachAST401Index).TDEPTSA
                        End If
                    End With
                    ReturnValue.Rows.Add(AddItem)
                Next
            Next
        End If

        Return ReturnValue
    End Function

    Private Function SearchAsset(Of ObjectType As {New, CompanyORMDB.ORMBaseClass.ClassDBAS400})(ByVal AssetNumber As String, ByVal AssetName As String, ByVal PlanCode As String) As List(Of ObjectType)
        Dim WhereString As String = Nothing
        Dim FromDBAndMemberPathString As String = (New ObjectType).CDBFullAS400DBPath.Trim
        If Not String.IsNullOrEmpty(AssetNumber) AndAlso AssetNumber.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & "NUMBER='" & AssetNumber & "'"
        End If
        If Not String.IsNullOrEmpty(AssetName) AndAlso AssetName.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & "NAME LIKE '%" & AssetName & "%'"
        End If
        If Not String.IsNullOrEmpty(PlanCode) AndAlso PlanCode.Trim.Length > 0 Then
            FromDBAndMemberPathString &= ".ASTF" & PlanCode
        End If

        Dim QryString As String = "Select * From " & FromDBAndMemberPathString & IIf(IsNothing(WhereString), Nothing, " Where " & WhereString)
        Return CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of ObjectType)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

    End Function

    Private Function SearchDiscardAsset(Of ObjectType As {New, CompanyORMDB.ORMBaseClass.ClassDBAS400})(ByVal AssetNumber As String, ByVal AssetName As String, ByVal PlanCode As String) As List(Of ObjectType)
        Dim WhereString As String = Nothing
        Dim FromDBAndMemberPathString As String = (New ObjectType).CDBFullAS400DBPath.Trim
        If Not String.IsNullOrEmpty(AssetNumber) AndAlso AssetNumber.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & "NUMBER='" & AssetNumber & "'"
        End If
        If Not String.IsNullOrEmpty(AssetName) AndAlso AssetName.Trim.Length > 0 Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND ") & "CNAME LIKE '%" & AssetName & "%'"
        End If
        If Not String.IsNullOrEmpty(PlanCode) AndAlso PlanCode.Trim.Length > 0 Then
            FromDBAndMemberPathString &= ".ASTF" & PlanCode
        End If

        Dim QryString As String = "Select * From " & FromDBAndMemberPathString & IIf(IsNothing(WhereString), Nothing, " Where " & WhereString)
        Return CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of ObjectType)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

    End Function


#End Region

#Region "使用者是否已按下查詢 屬性:IsUserAlreadyPutSearch"

    ''' <summary>
    ''' 使用者是否已按下查詢
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsUserAlreadyPutSearch() As Boolean
        Get
            If IsNothing(Me.ViewState("_IsUserAlreadyPutSearch")) Then
                Return False
            End If
            Return Me.ViewState("_IsUserAlreadyPutSearch")
        End Get
        Set(ByVal value As Boolean)
            Me.ViewState("_IsUserAlreadyPutSearch") = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        Me.GridView1.DataBind()
    End Sub

    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
    End Sub

    Protected Sub btnSearchToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchToExcel.Click
        Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(Search(RadioButtonList1.SelectedValue, Me.TextBox1.Text, Me.TextBox2.Text, RadioButtonList2.SelectedValue), "資產移轉查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

End Class