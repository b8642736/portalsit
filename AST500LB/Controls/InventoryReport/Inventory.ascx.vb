Public Partial Class Inventory
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search() As List(Of AST500LBDataSet.InventoryDataTableRow)

    End Function
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String) As AST500LBDataSet.InventoryDataTableDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return New AST500LBDataSet.InventoryDataTableDataTable
        End If
        Dim AllDEPCODPFs As List(Of CompanyORMDB.GPL2.DEPCODPF) = Nothing
        AllDEPCODPFs = CompanyORMDB.GPL2.DEPCODPF.CDBSelect(Of CompanyORMDB.GPL2.DEPCODPF)("Select * from @#GPL2.DEPCODPF", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim DBService As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim ReturnValue As New AST500LBDataSet.InventoryDataTableDataTable
        For Each EachItem As DataRow In DBService.SelectQuery(QryString).Rows
            Dim AddItem As AST500LBDataSet.InventoryDataTableRow = ReturnValue.NewRow
            With AddItem
                .分類編號 = EachItem.Item("NUMBER")
                .單位 = EachItem.Item("DEPTSA")
                .數量 = EachItem.Item("QUANT")
                .財產名稱 = EachItem.Item("NAME")
                .入帳年月 = EachItem.Item("DATE")
                .使用年限 = EachItem.Item("USLAFF")
                If CType(EachItem.Item("N7611"), String).Trim <> "0" Then
                    .使用年限 &= "+" & EachItem.Item("N7611")
                End If
                .入帳金額 = Format(EachItem.Item("AMOUNT"), "#,##0")
                Dim FindDep As CompanyORMDB.GPL2.DEPCODPF = (From A In AllDEPCODPFs Where A.DEPCOD.Trim.PadRight(2) = CType(EachItem.Item("DEPTSA"), String).Trim.PadRight(2).Substring(0, 2) Select A).FirstOrDefault
                If Not IsNothing(FindDep) Then
                    .歸屬單位 = FindDep.DEPNAM.Trim
                End If
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Return ReturnValue
    End Function
#End Region

    '#Region "取得廠別單位名稱 函式:GetSA_AST106PF_DEPTSAName"
    '    ''' <summary>
    '    ''' 取得廠別單位名稱
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function GetSA_AST106PF_DEPTSAName() As List(Of String)
    '        Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter
    '        Return (From A In AS400Adapter.SelectQuery("Select DISTINCT DEPTSA From @#AST500LB.AST106PF Where SEQ=1 AND NUMBER IN ( Select NUMBER From @#AST500LB.AST101PF.ASTFSA Where DEPT='SA') ").Rows Select CType(A.ITEM(0), String)).ToList
    '    End Function
    '#End Region
#Region "重整顯示部門篩選名稱 函式:RefreshShowDepartemntNames"
    ''' <summary>
    ''' 重整顯示部門篩選名稱
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshShowDepartemntNames()
        CheckBoxList1.Items.Clear()
        For Each EachItem As String In GetAST106PF_DEPTSA("ASTF" & RadioButtonList1.SelectedValue)
            Me.CheckBoxList1.Items.Add(EachItem)
        Next
    End Sub
    Private Function GetAST106PF_DEPTSA(ByVal MemberName As String) As List(Of String)
        Dim SQLQry As String = Nothing
        Select Case True
            Case MemberName.ToUpper = "DEPTSA"
                SQLQry = "Select DISTINCT DEPTSA FROM @#AST500LB.AST106PF." & MemberName & " Where NUMBER IN (Select Number From @#AST500LB.AST101PF." & MemberName & " Where DEPT='SA') AND SEQ=1 Order by DEPTSA"
            Case Else
                SQLQry = "Select DISTINCT DEPTSA FROM @#AST500LB.AST106PF." & MemberName & " Where NUMBER IN (Select Number From @#AST500LB.AST101PF." & MemberName & " ) AND SEQ=1 Order by DEPTSA"
        End Select
        Return (From A In (New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)).SelectQuery(SQLQry) Select CType(A.Item("DEPTSA"), String)).ToList

    End Function
#End Region
#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()

        Dim SQLString As String = Nothing
        If CheckBoxList1.Visible Then
            SQLString = "Select A.* , B.DEPTSA From " & (New CompanyORMDB.AST500LB.AST101PF).CDBFullAS400DBPath.Trim & ".ASTF" & RadioButtonList1.SelectedValue & " A LEFT JOIN " & (New CompanyORMDB.AST500LB.AST106PF).CDBFullAS400DBPath.Trim & ".ASTF" & RadioButtonList1.SelectedValue & " B ON A.NUMBER=B.NUMBER Where B.SEQ=1 "
        Else
            SQLString = "Select A.* , A.DEPT DEPTSA From " & (New CompanyORMDB.AST500LB.AST101PF).CDBFullAS400DBPath.Trim & ".ASTF" & RadioButtonList1.SelectedValue & " A  Where 1=1 "
        End If

        Dim FilterDepartment As String = Nothing
        If CheckBoxList1.Visible Then
            For Each EachItem As ListItem In CheckBoxList1.Items
                If EachItem.Selected Then
                    FilterDepartment &= IIf(IsNothing(FilterDepartment), Nothing, "','") & EachItem.Value
                End If
            Next
            If IsNothing(FilterDepartment) OrElse FilterDepartment.Trim.Length = 0 Then
                SQLString &= " AND 1=0 "
            Else
                SQLString &= " AND DEPTSA IN ('" & FilterDepartment & "') "
            End If
        End If
        Me.hfQryString.Value = SQLString & " Order by A.NUMBER "
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RefreshShowDepartemntNames()
        End If
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        CheckBoxList1.Visible = (RadioButtonList1.SelectedValue = "SA" OrElse RadioButtonList1.SelectedValue = "AA" OrElse RadioButtonList1.SelectedValue = "AB" OrElse RadioButtonList1.SelectedValue = "QA" OrElse RadioButtonList1.SelectedValue = "NA")
        btnSelectAll.Visible = CheckBoxList1.Visible
        btnClearAll.Visible = CheckBoxList1.Visible
        If CheckBoxList1.Visible Then
            RefreshShowDepartemntNames()
        End If
        Me.UpdatePanel2.Update()
    End Sub

    Protected Sub btnSelectAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectAll.Click
        For Each EachItem As ListItem In CheckBoxList1.Items
            EachItem.Selected = True
        Next
    End Sub

    Protected Sub btnClearAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearAll.Click
        For Each EachItem As ListItem In CheckBoxList1.Items
            EachItem.Selected = False
        Next
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        ReportViewer1.LocalReport.Refresh()
    End Sub
End Class