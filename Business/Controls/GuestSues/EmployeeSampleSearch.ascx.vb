Public Partial Class EmployeeSampleSearch
    Inherits System.Web.UI.UserControl
    Dim DBDatacontext As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
#Region "查詢 方法:Search"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal SQLString As String) As List(Of CompanyORMDB.PLT500LB.PTM010PF)
        Return ClassDBAS400.CDBSelect(Of CompanyORMDB.PLT500LB.PTM010PF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
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

    Public Event UserSelectedEmployee(ByVal SenderControl As EmployeeSampleSearch, ByVal SelectedEmployee As CompanyORMDB.PLT500LB.PTM010PF)
    Public Event UserCancelReturn(ByVal SenderControl As EmployeeSampleSearch)


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.DropDownList1.Items.Add(New ListItem("全部", "ALL"))
            For Each EachItem As DataRow In DBDatacontext.SelectQuery("Select DEPCOD,DEPNAM FROM @#GPL2.DEPCODPF").Rows
                Dim AddItem As New ListItem(EachItem.Item("DEPCOD") & EachItem.Item("DEPNAM"), EachItem.Item("DEPCOD"))
                Me.DropDownList1.Items.Add(AddItem)
            Next
            Me.DropDownList1.SelectedValue = "C21 "
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        'SELECT * FROM @#PLT000LB.PQDM01PF WHERE QD100A='30276'  FETCH FIRST 100 ROWS ONLY
        Dim WhereString As String = " PT0157=0 "
        If Not String.IsNullOrEmpty(TextBox1.Text.Trim) Then
            WhereString &= " AND PT0102 LIKE '%" & TextBox1.Text.Trim.Replace("'", Nothing) & "%'"
        End If
        If Not String.IsNullOrEmpty(TextBox2.Text.Trim) Then
            WhereString &= " AND PT0101 LIKE '%" & TextBox2.Text.Trim.Replace("'", Nothing) & "%'"
        End If
        If Me.DropDownList1.SelectedValue <> "ALL" Then
            Dim NowTimeYear As Integer = Val(New CompanyORMDB.AS400DateConverter(Now).TwSevenCharsTypeData.Substring(0, 3))
            Dim NowTimeMonth As Integer = Val(New CompanyORMDB.AS400DateConverter(Now).TwSevenCharsTypeData.Substring(3, 2))
            WhereString &= " AND PT0102 IN (SELECT QD100A FROM @#PLT000LB.PQDM01PF WHERE QD100E='" & Me.DropDownList1.SelectedValue & "' AND QD100I =" & NowTimeYear & " AND QD100J=" & NowTimeMonth & " ) "
        End If
        Dim QueryString As String = "Select PT0101,PT0102 From @#" & (New CompanyORMDB.PLT500LB.PTM010PF).CDBLibraryName & ".PTM010PF " & IIf(IsNothing(WhereString), Nothing, "Where " & WhereString)
        Me.hfSearchSQLString.Value = QueryString
        Me.IsUserAlreadyPutSearch = True
        Me.GridView1.DataBind()
    End Sub

    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        e.Cancel = Not IsUserAlreadyPutSearch
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim SQLString As String = "Select PT0101,PT0102 From @#" & (New CompanyORMDB.PLT500LB.PTM010PF).CDBLibraryName & ".PTM010PF Where PT0102='" & GridView1.SelectedValue & "'"
        Dim SelectedEemployee As CompanyORMDB.PLT500LB.PTM010PF = ClassDBAS400.CDBSelect(Of CompanyORMDB.PLT500LB.PTM010PF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).FirstOrDefault
        If Not IsNothing(SelectedEemployee) Then
            RaiseEvent UserSelectedEmployee(Me, SelectedEemployee)
        End If
    End Sub

    Protected Sub btnCancelReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelReturn.Click
        RaiseEvent UserCancelReturn(Me)
    End Sub
End Class