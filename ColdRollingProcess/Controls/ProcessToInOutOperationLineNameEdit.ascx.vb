Public Class ProcessToInOutOperationLineNameEdit
    Inherits System.Web.UI.UserControl

#Region "作業排程ID 屬性:ProcessSchedualID"
    Public Property ProcessSchedualID() As String
        Get
            Return Me.Session("_ProcessSchedualID")
        End Get
        Set(ByVal value As String)
            Me.Session("_ProcessSchedualID") = value
        End Set
    End Property

#End Region

#Region "查詢(未加入名稱轉換) 方法:Search1"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search1(ByVal QryString As String) As List(Of InOutOperationLineName)
        If String.IsNullOrEmpty(QryString) OrElse QryString.Trim.Length = 0 Then
            Return New List(Of InOutOperationLineName)
        End If
        'If String.IsNullOrEmpty(QryString) Then
        '    QryString = "Select * From InOutOperationLineName Where NOT ID IN (Select InOutOperationLineNameID From ProcessToInOutOperationLineName Where ProcessSchedualID='" & Me.ProcessSchedualID & "') Order by InNextOperationLineName"
        'End If
        If String.IsNullOrEmpty(QryString) Then
            Return New List(Of InOutOperationLineName)
        End If
        Return InOutOperationLineName.CDBSelect(Of InOutOperationLineName)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
    End Function
#End Region
#Region "查詢(已加入名稱轉換) 方法:Search2"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search2(ByVal QryString As String) As List(Of InOutOperationLineName)
        If String.IsNullOrEmpty(QryString) OrElse QryString.Trim.Length = 0 Then
            Return New List(Of InOutOperationLineName)
        End If
        'If String.IsNullOrEmpty(QryString) Then
        '    QryString = "Select * From InOutOperationLineName Where ID IN (Select InOutOperationLineNameID From ProcessToInOutOperationLineName Where ProcessSchedualID='" & Me.ProcessSchedualID & "') Order by InNextOperationLineName"
        'End If
        If String.IsNullOrEmpty(QryString) Then
            Return New List(Of InOutOperationLineName)
        End If
        Return InOutOperationLineName.CDBSelect(Of InOutOperationLineName)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
    End Function
#End Region

#Region "產生查詢字串至控制項1或2  函式:MakeQryStringToControl1Or2"
    Private Sub MakeQryStringToControl1Or2(ByVal ToControlNumber As Integer)
        Dim ReturnValue As String = "Select * From InOutOperationLineName Where 1=1 "
        If Not (String.IsNullOrEmpty(TextBox1.Text) OrElse TextBox1.Text.Trim.Length = 0) Then
            ReturnValue &= " AND InNextOperationLineName LIKE '%" & TextBox1.Text.Trim & "%' "
        End If
        If Not (String.IsNullOrEmpty(TextBox2.Text) OrElse TextBox2.Text.Trim.Length = 0) Then
            ReturnValue &= " AND InCurrentFish LIKE '%" & TextBox2.Text.Trim & "%'"
        End If
        If Not (String.IsNullOrEmpty(TextBox3.Text) OrElse TextBox3.Text.Trim.Length = 0) Then
            ReturnValue &= " AND OutOperationLineName LIKE '%" & TextBox3.Text.Trim & "%'"
        End If
        If Not (String.IsNullOrEmpty(TextBox4.Text) OrElse TextBox4.Text.Trim.Length = 0) Then
            ReturnValue &= " AND OutNextOperationLineName LIKE '%" & TextBox4.Text.Trim & "%'"
        End If

        If ToControlNumber = 1 Then
            Me.hfQryString1.Value = ReturnValue & " And NOT ID IN (Select InOutOperationLineNameID From ProcessToInOutOperationLineName Where ProcessSchedualID='" & Me.ProcessSchedualID & "') Order by InNextOperationLineName"
        Else
            Me.hfQryString2.Value = ReturnValue & " And ID IN (Select InOutOperationLineNameID From ProcessToInOutOperationLineName Where ProcessSchedualID='" & Me.ProcessSchedualID & "') Order by InNextOperationLineName"
        End If
    End Sub
#End Region

#Region "重整顯示 函式:Refresh"
    ''' <summary>
    ''' 重整顯示
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DefaultSearchRefresh()
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
        MakeQryStringToControl1Or2(1)
        MakeQryStringToControl1Or2(2)
        GridView1.DataBind()
        GridView2.DataBind()
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakeQryStringToControl1Or2(1)
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearch0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch0.Click
        MakeQryStringToControl1Or2(2)
        GridView2.DataBind()
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim SelectValue As String = GridView1.SelectedValue
        If String.IsNullOrEmpty(SelectValue) OrElse SelectValue.Trim.Length = 0 Then
            Exit Sub
        End If
        Dim AddItem As New ProcessToInOutOperationLineName
        With AddItem
            .ProcessSchedualID = Me.ProcessSchedualID
            .InOutOperationLineNameID = SelectValue.Trim
        End With
        AddItem.CDBInsert()
        GridView1.DataBind()
        GridView2.DataBind()
    End Sub

    Private Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged
        Dim SelectValue As String = GridView2.SelectedValue
        If String.IsNullOrEmpty(SelectValue) OrElse SelectValue.Trim.Length = 0 Then
            Exit Sub
        End If
        Dim FindObject As ProcessToInOutOperationLineName = (From A In ProcessToInOutOperationLineName.CDBSelect(Of ProcessToInOutOperationLineName)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, "Select * from ProcessToInOutOperationLineName Where ProcessSchedualID='" & Me.ProcessSchedualID.Trim & "' and InOutOperationLineNameID='" & SelectValue.Trim & "'") Select A).FirstOrDefault
        If Not IsNothing(FindObject) Then
            FindObject.CDBDelete()
        End If
        GridView1.DataBind()
        GridView2.DataBind()
    End Sub

    Protected Sub btnClearSearchCondiction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearchCondiction.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
    End Sub

End Class