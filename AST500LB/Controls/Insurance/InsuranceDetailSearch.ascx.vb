Public Partial Class InsuranceDetailSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String, ByVal QryString1 As String, ByVal QAndAArgs As String) As AST500LBDataSet.InsuranceDetailDataTableDataTable
        Dim ReturnValue As New AST500LBDataSet.InsuranceDetailDataTableDataTable

        Dim QryResult As DataTable = (New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)).SelectQuery(QryString)
        Dim QryResult1 As List(Of CompanyORMDB.AST500LB.AST501PF) = CompanyORMDB.AST500LB.AST501PF.CDBSelect(Of CompanyORMDB.AST500LB.AST501PF)(QryString1, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim Number As Integer = 1
        For Each EachItem As DataRow In QryResult.Rows
            Dim EachItemTemp As DataRow = EachItem
            Dim AddItem As AST500LBDataSet.InsuranceDetailDataTableRow = ReturnValue.NewRow
            Dim IsHaveFireInsure As Boolean = (From A In QryResult1 Where A.SAVKIND = 1 And A.NUMBER.Trim = CType(EachItemTemp.Item("NUMBER"), String).Trim Select A).Count > 0
            Dim IsHaveExplosionInsure As Boolean = (From A In QryResult1 Where A.SAVKIND = 2 And A.NUMBER.Trim = CType(EachItemTemp.Item("NUMBER"), String).Trim Select A).Count > 0
            With AddItem
                .序號 = Number : Number += 1
                .資產編號 = EachItem.Item("NUMBER")
                .資產名稱 = EachItem.Item("NAME")
                If Not IsDBNull(EachItem.Item("DEPTSA")) Then
                    .置放地點 = EachItem.Item("DEPTSA")
                End If
                .單價 = Format(EachItem.Item("AMOUNT") / EachItem.Item("QUANT"), "0,0")
                .單位 = EachItem.Item("UNIT")
                .數量 = EachItem.Item("QUANT")
                .價值 = Format(EachItem.Item("AMOUNT"), "0,0")
                .入帳年月 = EachItem.Item("DATE")
                '.耐用年限 = EachItem.Item("USLAFF") & IIf(EachItem.Item("N7611") <= 0, Nothing, "+" & EachItem.Item("N7611"))
                .耐用年限 = EachItem.Item("USLAFF")
                .已提折舊 = Format(EachItem.Item("DEPR"), "0,0")
                .殘餘價值 = Format(EachItem.Item("AMOUNT") - EachItem.Item("DEPR"), "0,0")
                .保險 = ""
                If QAndAArgs.Contains("1") Then
                    .保險 &= "火險:" & IIf(IsHaveFireInsure, "有█", "無□")
                End If
                If QAndAArgs.Contains("2") Then
                    .保險 &= "　爆炸險:" & IIf(IsHaveExplosionInsure, "有█", "無□")
                End If

            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Return ReturnValue
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

#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim StartDate As Integer = (CType(tbStartDate.Text.Split("/")(0), Integer) - 1911) * 10000 + CType(tbStartDate.Text.Split("/")(1), Integer) * 100 + CType(tbStartDate.Text.Split("/")(2), Integer)
        'If CheckBoxList1.Visible Then
        '    SQLString = "Select A.* , B.DEPTSA From " & (New CompanyORMDB.AST500LB.AST101PF).CDBFullAS400DBPath.Trim & ".ASTF" & RadioButtonList1.SelectedValue & " A LEFT JOIN " & (New CompanyORMDB.AST500LB.AST106PF).CDBFullAS400DBPath.Trim & ".ASTF" & RadioButtonList1.SelectedValue & " B ON A.NUMBER=B.NUMBER Where B.SEQ=1 "
        'Else
        '    SQLString = "Select A.* , A.DEPT DEPTSA From " & (New CompanyORMDB.AST500LB.AST101PF).CDBFullAS400DBPath.Trim & ".ASTF" & RadioButtonList1.SelectedValue & " A  Where 1=1 "
        'End If
        'SQLString = "Select A.* , B.* , C.DEPTSA From @#AST500LB.AST501PF" & " A LEFT OUTER JOIN @#AST500LB.AST101PF.ASTF" & RadioButtonList1.SelectedValue & " B ON A.NUMBER=B.NUMBER LEFT OUTER JOIN @#AST500LB.AST106PF.ASTF" & RadioButtonList1.SelectedValue & " C ON A.NUMBER=C.NUMBER Where A.SDATE>=" & StartDate & " AND A.EDATE<=" & StartDate & " AND C.SEQ=1"
        'cblInsurceKind
        Dim InsurceKindFilterString As String = Nothing
        For Each EachItem As ListItem In cblInsurceKind.Items
            If EachItem.Selected Then
                InsurceKindFilterString &= IIf(IsNothing(InsurceKindFilterString), Nothing, ",") & EachItem.Value
            End If
        Next
        InsurceKindFilterString = IIf(IsNothing(InsurceKindFilterString), "(-1)", "(" & InsurceKindFilterString & ")")


        Dim SQLString As String = "Select A.* , B.DEPTSA From  @#AST500LB.AST101PF.ASTF" & RadioButtonList1.SelectedValue & " A LEFT OUTER JOIN @#AST500LB.AST106PF.ASTF" & RadioButtonList1.SelectedValue & " B ON A.NUMBER=B.NUMBER  Where " & IIf(RadioButtonList1.SelectedValue = "SA", " B.SEQ=1 ", " 1=1 ")
        SQLString &= " AND A.NUMBER IN (" & "Select C.NUMBER From @#AST500LB.AST501PF C WHERE C.SDATE<=" & StartDate & " AND C.EDATE>=" & StartDate & " AND C.FACKIND='" & RadioButtonList1.SelectedValue.Trim & "' AND SAVKIND IN " & InsurceKindFilterString & ") Order by DEPTSA,NUMBER"
        Dim SQLString1 As String = "Select A.* From @#AST500LB.AST501PF A WHERE A.SDATE<=" & StartDate & " AND A.EDATE>=" & StartDate & " AND A.FACKIND='" & RadioButtonList1.SelectedValue.Trim & "'"
        Me.hfQAndAArgs.Value = ""
        For Each EachItem As ListItem In cblInsurceKind.Items
            If EachItem.Selected Then
                Me.hfQAndAArgs.Value &= IIf(String.IsNullOrEmpty(Me.hfQAndAArgs.Value), Nothing, ",") & EachItem.Value
            End If
        Next

        Me.hfQryString.Value = SQLString
        Me.hfQryString1.Value = SQLString1
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        IsUserAlreadyPutSearch = True
        MakQryStringToControl()
        Me.GridView1.DataBind()
    End Sub

    Private Sub ObjectDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

    Protected Sub btnToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnToExcel.Click
        IsUserAlreadyPutSearch = True
        MakQryStringToControl()
        Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(Search(Me.hfQryString.Value, Me.hfQryString1.Value, Me.hfQAndAArgs.Value), "固定資產保險明細表" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)

    End Sub
End Class