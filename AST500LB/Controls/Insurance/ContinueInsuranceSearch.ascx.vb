Public Partial Class ContinueInsuranceSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal QryString As String, ByVal QryString1 As String, ByVal QAndAArgs As String) As AST500LBDataSet.InsuranceDataTableDataTable
        If String.IsNullOrEmpty(QryString) OrElse String.IsNullOrEmpty(QryString1) Then
            Return New AST500LBDataSet.InsuranceDataTableDataTable
        End If
        Dim ReturnValue As New AST500LBDataSet.InsuranceDataTableDataTable
        Dim QryResult As DataTable = (New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)).SelectQuery(QryString)
        Dim QryResult1 As List(Of CompanyORMDB.AST500LB.AST501PF) = CompanyORMDB.AST500LB.AST501PF.CDBSelect(Of CompanyORMDB.AST500LB.AST501PF)(QryString1, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        For Each EachItem As DataRow In QryResult.Rows
            Dim EachItemTemp As DataRow = EachItem
            Dim AddItem As AST500LBDataSet.InsuranceDataTableRow = ReturnValue.NewRow
            Dim IsHaveFireInsure As Boolean = (From A In QryResult1 Where A.SAVKIND = 1 And A.NUMBER.Trim = CType(EachItemTemp.Item("NUMBER"), String).Trim Select A).Count > 0
            Dim IsHaveExplosionInsure As Boolean = (From A In QryResult1 Where A.SAVKIND = 2 And A.NUMBER.Trim = CType(EachItemTemp.Item("NUMBER"), String).Trim Select A).Count > 0
            With AddItem
                .資產編號 = EachItem.Item("NUMBER")
                .資產名稱 = EachItem.Item("NAME")
                .置放地點 = EachItem.Item("DEPTSA")
                .單價 = Format(EachItem.Item("AMOUNT") / EachItem.Item("QUANT"), "0,0")
                .單位 = EachItem.Item("UNIT")
                .數量 = EachItem.Item("QUANT")
                .價值 = Format(EachItem.Item("AMOUNT"), "0,0")
                .入帳年月 = EachItem.Item("DATE")
                .耐用年限 = EachItem.Item("USLAFF") & IIf(EachItem.Item("N7611") <= 0, Nothing, "+" & EachItem.Item("N7611"))
                .已提折舊 = Format(EachItem.Item("DEPR"), "0,0")
                'If Val(EachItem.Item("N7611")) > 0 Then
                '    .殘餘價值 = Format(EachItem.Item("V7611"), "0,0")
                'Else
                '    .殘餘價值 = Format(EachItem.Item("AMOUNT") - EachItem.Item("DEPR"), "0,0")
                'End If
                .殘餘價值 = Format(EachItem.Item("AMOUNT") - EachItem.Item("DEPR"), "0,0")
                .保險狀態 = ""
                .加減保變更 = ""
                If QAndAArgs.Contains("1") Then
                    .保險狀態 &= "火險:" & IIf(IsHaveFireInsure, "有█", "無□")
                    .加減保變更 &= "□火險" & IIf(IsHaveFireInsure, "減保", "加保")
                End If
                If QAndAArgs.Contains("2") Then
                    .保險狀態 &= "　爆炸險:" & IIf(IsHaveExplosionInsure, "有█", "無□")
                    .加減保變更 &= "　□爆炸險" & IIf(IsHaveExplosionInsure, "減保", "加保")
                End If
                '.保險狀態 = "火險:" & IIf(IsHaveFireInsure, "有█", "無□") & "　爆炸險:" & IIf(IsHaveExplosionInsure, "有█", "無□")
                '.加減保變更 = "□火險" & IIf(IsHaveFireInsure, "減保", "加保") & "　□爆炸險" & IIf(IsHaveExplosionInsure, "減保", "加保")
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Return ReturnValue
    End Function
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
        Dim SQLString As String = "Select A.* , B.DEPTSA From  @#AST500LB.AST101PF.ASTF" & RadioButtonList1.SelectedValue & " A LEFT OUTER JOIN @#AST500LB.AST106PF.ASTF" & RadioButtonList1.SelectedValue & " B ON A.NUMBER=B.NUMBER  Where B.SEQ=1"
        Dim SQLString1 As String = "Select A.* From @#AST500LB.AST501PF A WHERE A.SDATE<=" & StartDate & " AND A.EDATE>=" & StartDate & " AND A.FACKIND='" & RadioButtonList1.SelectedValue.Trim & "'"
        Me.hfQAndAArgs.Value = Nothing
        For Each EachItem As ListItem In cblInsurceKind.Items
            If EachItem.Selected Then
                Me.hfQAndAArgs.Value &= IIf(String.IsNullOrEmpty(Me.hfQAndAArgs.Value), Nothing, ",") & EachItem.Value
            End If
        Next

        If {"RA", "RC", "RD"}.Contains(RadioButtonList1.SelectedValue) Then
            'RA,RC,RD之資產放至企劃處
            Me.hfQryString.Value = "Select A.* ,'C5' DEPTSA  From  @#AST500LB.AST101PF.ASTF" & RadioButtonList1.SelectedValue & " A"
        Else
            Me.hfQryString.Value = SQLString
        End If
        Me.hfQryString1.Value = SQLString1
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        ReportViewer1.LocalReport.Refresh()
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        MakQryStringToControl()
        Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(Search(Me.hfQryString.Value, Me.hfQryString1.Value, Me.hfQAndAArgs.Value), "資產保險查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub
End Class