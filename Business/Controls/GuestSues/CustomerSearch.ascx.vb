Public Class CustomerSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As List(Of CompanyORMDB.SLS300LB.SL2CUAPF)
        If String.IsNullOrEmpty(SQLString) Then
            Return New List(Of CompanyORMDB.SLS300LB.SL2CUAPF)
        End If
        Return CompanyORMDB.SLS300LB.SL2CUAPF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2CUAPF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    End Function
#End Region

    Public Event UserSelectedCustomer(ByVal SenderControl As CustomerSearch, ByVal SelectedSL2CUAPF As CompanyORMDB.SLS300LB.SL2CUAPF)
    Public Event UserCancelReturn(ByVal SenderControl As CustomerSearch)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Dim WhereString As String = Nothing
        If Not String.IsNullOrEmpty(tbCustomerName.Text.Trim) Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND") & " CUA02 LIKE '%" & tbCustomerName.Text.Trim.Replace("'", Nothing) & "%' OR UA11 LIKE '%" & tbCustomerName.Text.Trim.Replace("'", Nothing) & "%'"
        End If
        If Not String.IsNullOrEmpty(tbCustomerID.Text.Trim) Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND") & " CUA01 LIKE '%" & tbCustomerID.Text.Trim.Replace("'", Nothing) & "%'"
        End If
        If Not String.IsNullOrEmpty(tbCustomerAddress.Text.Trim) Then
            WhereString &= IIf(IsNothing(WhereString), Nothing, " AND") & " CUA05 LIKE '%" & tbCustomerAddress.Text.Trim.Replace("'", Nothing) & "%' OR CUA08 LIKE '%" & tbCustomerAddress.Text.Trim.Replace("'", Nothing) & "%'"
        End If
        Dim QueryString As String = "Select CUA01,CUA05,CUA11 From @#SLS300LB.SL2CUAPF " & IIf(IsNothing(WhereString), Nothing, " Where " & WhereString)
        Me.hfSearchSQLString.Value = QueryString
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnCancelReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelReturn.Click
        RaiseEvent UserCancelReturn(Me)
    End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim SQLString As String = "Select  CUA01,CUA05,CUA11 From @#SLS300LB.SL2CUAPF  Where CUA01='" & GridView1.SelectedValue & "'"
        Dim SelectedCustomer As CompanyORMDB.SLS300LB.SL2CUAPF = ClassDBAS400.CDBSelect(Of CompanyORMDB.SLS300LB.SL2CUAPF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC).FirstOrDefault
        If Not IsNothing(SelectedCustomer) Then
            RaiseEvent UserSelectedCustomer(Me, SelectedCustomer)
        End If
    End Sub

End Class