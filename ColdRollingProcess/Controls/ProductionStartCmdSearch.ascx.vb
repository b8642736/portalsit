Public Class ProductionStartCmdSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="AS400SQLString"></param>
    ''' <param name="SQLSQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal AS400SQLString As String, ByVal SQLSQLString As String, ByVal IsDispatchNoneZero As Boolean) As ColdRollingProcessDataSet.ProductionStartCmdSearchDataTable
        Dim ReturnValue As New ColdRollingProcessDataSet.ProductionStartCmdSearchDataTable
        If String.IsNullOrEmpty(AS400SQLString) OrElse String.IsNullOrEmpty(SQLSQLString) Then
            Return ReturnValue
        End If
        Dim QryAdapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, AS400SQLString)
        Dim AS400SearchResult As List(Of SLS300LB.SL2CIWPF) = SLS300LB.SL2CIWPF.CDBSelect(Of SLS300LB.SL2CIWPF)(AS400SQLString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SQLSearchResult As List(Of CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay) = CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.PlanProductionDisplay)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLSQLString)

        Dim AddItem As ColdRollingProcessDataSet.ProductionStartCmdSearchRow
        Dim SameSpecAS400Data As CompanyORMDB.SLS300LB.SL2CIWPF
        Dim AST00FindedDatas As New List(Of CompanyORMDB.SLS300LB.SL2CIWPF)
        For Each EachItem In SQLSearchResult
            With EachItem
                SameSpecAS400Data = (From A In AS400SearchResult Where A.CIW0A.Trim = .CIW0A.Trim And A.CIW02 = .CIW02 And A.CIW03.Trim = .CIW03.Trim And A.CIW04.Trim = .CIW04.Trim And A.CIW05.Trim = .CIW05.Trim And A.CIW06 = .CIW06 And A.CIW15 = .CIW15 Select A).FirstOrDefault
                AST00FindedDatas.Add(SameSpecAS400Data)
            End With
            AddItem = ReturnValue.NewRow
            With AddItem
                .優先順序 = EachItem.CIW15
                .線別 = EachItem.CIW0A
                .鋼種Type = EachItem.CIW03.Trim & EachItem.CIW04.Trim
                .黑皮寬度 = EachItem.CIW02
                .黑皮厚度 = EachItem.CIW05
                If IsNothing(SameSpecAS400Data) Then
                    .生技派工量 = 0
                Else
                    .生技派工量 = SameSpecAS400Data.CIW12
                End If
                .現場派工量 = EachItem.CIW12
                .處理程序 = GetProcessString(EachItem.CIW06)
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        For Each EachItem In (From A In AS400SearchResult Where Not AST00FindedDatas.Contains(A) Select A).ToList
            AddItem = ReturnValue.NewRow
            With AddItem
                .優先順序 = EachItem.CIW15
                .線別 = EachItem.CIW0A
                .鋼種Type = EachItem.CIW03.Trim & EachItem.CIW04.Trim
                .黑皮寬度 = EachItem.CIW02
                .黑皮厚度 = EachItem.CIW05
                .生技派工量 = EachItem.CIW12
                .現場派工量 = 0
                .處理程序 = GetProcessString(EachItem.CIW06)
            End With
            ReturnValue.Rows.Add(AddItem)
        Next

        Dim RemoveItems As New List(Of ColdRollingProcessDataSet.ProductionStartCmdSearchRow)
        If IsDispatchNoneZero Then
            For Each EachItem In ReturnValue
                If Val(EachItem.生技派工量) = 0 AndAlso Val(EachItem.現場派工量) = 0 Then
                    RemoveItems.Add(EachItem)
                End If
            Next

            For Each EachItem In RemoveItems
                ReturnValue.Rows.Remove(EachItem)
            Next
        End If
        Return ReturnValue
    End Function
    Private Function GetProcessString(ByVal ProcessCode As Integer) As String
        Select Case ProcessCode
            Case 1
                Return "組合料"
            Case 2
                Return "黑皮直軋"
            Case 3
                Return "直投ZML"
            Case 4
                Return "直投NO1"
        End Select
        Return ProcessCode
    End Function

#End Region


#Region "控制項Where條件產生器 方法:ControlWhereMaker"
    ''' <summary>
    ''' Where
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ControlWhereMaker()
        Dim ReturnValueForAS400 As New StringBuilder
        Dim ReturnValueForSQL As New StringBuilder
        ReturnValueForAS400.Append("Select * from @#SLS300LB.SL2CIWPF Where 1=1 ")
        ReturnValueForSQL.Append("Select * from PlanProductionDisplay Where 1=1 ")

        If RadioButtonList1.SelectedValue <> "ALL" Then
            ReturnValueForAS400.Append(" AND LEFT(RTRIM(LTRIM(CIW0A)),2)='" & RadioButtonList1.SelectedValue.Substring(0, 2) & "'")
            ReturnValueForSQL.Append(" AND LEFT(CIW0A,2)='" & RadioButtonList1.SelectedValue.Substring(0, 2) & "'")
        End If

        If Not String.IsNullOrEmpty(tbSteelKindType.Text) AndAlso tbSteelKindType.Text.Trim.Length > 0 Then
            ReturnValueForAS400.Append(" AND ((RTRIM(LTRIM(CIW03)) || RTRIM(LTRIM(CIW04))) IN ('" & tbSteelKindType.Text.Trim.Replace(",", "','") & "') )")
            ReturnValueForSQL.Append(" AND ((RTRIM(LTRIM(CIW03)) + RTRIM(LTRIM(CIW04))) IN ('" & tbSteelKindType.Text.Trim.Replace(",", "','") & "') )")
        End If

        If Not String.IsNullOrEmpty(tbWidth.Text) AndAlso tbWidth.Text.Trim.Length > 0 Then
            ReturnValueForAS400.Append(" AND CIW02 IN (" & tbWidth.Text.Trim & ")")
            ReturnValueForSQL.Append(" AND CIW02 IN (" & tbWidth.Text.Trim & ")")
        End If

        If Not String.IsNullOrEmpty(tbThick.Text) AndAlso tbThick.Text.Trim.Length > 0 Then
            ReturnValueForAS400.Append(" AND FLOAT(CIW05) IN (" & tbThick.Text.Trim & ")")
            ReturnValueForSQL.Append(" AND CAST(CIW05 as float) IN (" & tbThick.Text.Trim & ")")
        End If

        Dim SelectValues As String = Nothing
        For Each EachItem As ListItem In CheckBoxList1.Items
            If EachItem.Selected Then
                SelectValues &= IIf(String.IsNullOrEmpty(SelectValues), "", ",") & EachItem.Value
            End If
        Next
        If Not (String.IsNullOrEmpty(SelectValues) OrElse SelectValues.Split(",").Count = CheckBoxList1.Items.Count) Then
            ReturnValueForAS400.Append(" AND CIW06 IN (" & SelectValues & ")")
            ReturnValueForSQL.Append(" AND CIW06 IN (" & SelectValues & ")")
        End If

        Me.hfIsDispatchNoneZero.Value = IIf(CheckBox1.Checked, True, False)

        ReturnValueForAS400.Append(" AND CIW91='' ")

        Me.hfAS400Qry.Value = ReturnValueForAS400.ToString & " Order by CIW15"
        Me.hfSQLQry.Value = ReturnValueForSQL.ToString & " Order by CIW15"
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GridView1.Sort("優先順序", SortDirection.Ascending)
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ControlWhereMaker()
        GridView1.DataBind()
    End Sub

End Class