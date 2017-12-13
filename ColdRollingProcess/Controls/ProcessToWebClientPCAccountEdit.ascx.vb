﻿Public Class ProcessToWebClientPCAccountEdit
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
    Public Function Search1(ByVal QryString As String, ByVal CurrentProcessSchedualID As String) As List(Of CompanyORMDB.SQLServer.QCDB01.WebClientPCAccount)
        Dim InPCIPs As String = Nothing
        Dim SQLQry As String = "Select ClientIP From ProcessToWebClientPCAccount Where ProcessSchedualID='" & CurrentProcessSchedualID & "' "
        For Each EachItem As ProcessToWebClientPCAccount In ProcessToWebClientPCAccount.CDBSelect(Of ProcessToWebClientPCAccount)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLQry)
            InPCIPs &= IIf(String.IsNullOrEmpty(InPCIPs), Nothing, "','") & EachItem.ClientIP.Trim
        Next
        QryString &= " AND NOT ClientIP IN ('" & InPCIPs & "') " & " Order by ClientIP"
        If String.IsNullOrEmpty(QryString) OrElse QryString.Trim.Length = 0 Then
            Return New List(Of CompanyORMDB.SQLServer.QCDB01.WebClientPCAccount)
        End If
        Return CompanyORMDB.SQLServer.QCDB01.WebClientPCAccount.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.WebClientPCAccount)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
    End Function
#End Region
#Region "查詢(已加入名稱轉換) 方法:Search2"
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search2(ByVal QryString As String, ByVal CurrentProcessSchedualID As String) As List(Of CompanyORMDB.SQLServer.QCDB01.WebClientPCAccount)
        Dim InPCIPs As String = Nothing
        Dim SQLQry As String = "Select ClientIP From ProcessToWebClientPCAccount Where ProcessSchedualID='" & CurrentProcessSchedualID & "' "
        For Each EachItem As ProcessToWebClientPCAccount In ProcessToWebClientPCAccount.CDBSelect(Of ProcessToWebClientPCAccount)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLQry)
            InPCIPs &= IIf(String.IsNullOrEmpty(InPCIPs), Nothing, "','") & EachItem.ClientIP.Trim
        Next
        QryString &= " AND  ClientIP IN ('" & InPCIPs & "') " & " Order by ClientIP"

        If String.IsNullOrEmpty(QryString) OrElse QryString.Trim.Length = 0 Then
            Return New List(Of CompanyORMDB.SQLServer.QCDB01.WebClientPCAccount)
        End If

        Return CompanyORMDB.SQLServer.QCDB01.WebClientPCAccount.CDBSelect(Of CompanyORMDB.SQLServer.QCDB01.WebClientPCAccount)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
    End Function
#End Region

#Region "產生查詢字串至控制項1或2  函式:MakeQryStringToControl1Or2"
    Private Sub MakeQryStringToControl1Or2(ByVal ToControlNumber As Integer)

        Dim WhereString As String = " 1=1 "
        If Not (String.IsNullOrEmpty(TextBox1.Text) OrElse TextBox1.Text.Trim.Length = 0) Then
            WhereString &= " AND PCName like '%" & TextBox1.Text.Trim & "%'"
        End If
        If Not (String.IsNullOrEmpty(TextBox2.Text) OrElse TextBox2.Text.Trim.Length = 0) Then
            WhereString &= " AND ClientIP in ('" & TextBox2.Text.Trim.Replace(",", "','") & "')"
        End If
        If Not (String.IsNullOrEmpty(TextBox3.Text) OrElse TextBox3.Text.Trim.Length = 0) Then
            WhereString &= " AND Memo1 like '%" & TextBox3.Text.Trim & "%' "
        End If



        If ToControlNumber = 1 Then
            Me.hfQryString1.Value = "Select * From WebClientPCAccount Where " & WhereString
        Else
            Me.hfQryString2.Value = "Select * From WebClientPCAccount Where " & WhereString
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

    'Protected Sub btnSearch0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch0.Click
    '    MakeQryStringToControl1Or2(2)
    '    GridView2.DataBind()
    'End Sub

    Private Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim SelectValue As String = GridView1.SelectedValue
        If String.IsNullOrEmpty(SelectValue) OrElse SelectValue.Trim.Length = 0 Then
            Exit Sub
        End If
        Dim AddItem As New ProcessToWebClientPCAccount
        With AddItem
            .ProcessSchedualID = Me.ProcessSchedualID
            .ClientIP = SelectValue.Trim
        End With
        AddItem.CDBInsert()
        'MakeQryStringToControl1Or2(1)
        'MakeQryStringToControl1Or2(2)
        GridView1.DataBind()
        GridView2.DataBind()
    End Sub

    Private Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged
        Dim SelectValue As String = GridView2.SelectedValue
        If String.IsNullOrEmpty(SelectValue) OrElse SelectValue.Trim.Length = 0 Then
            Exit Sub
        End If
        Dim FindObject As ProcessToWebClientPCAccount = (From A In ProcessToWebClientPCAccount.CDBSelect(Of ProcessToWebClientPCAccount)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, "Select * from ProcessToWebClientPCAccount Where ProcessSchedualID='" & Me.ProcessSchedualID.Trim & "' and ClientIP='" & SelectValue.Trim & "'") Select A).FirstOrDefault
        If Not IsNothing(FindObject) Then
            FindObject.CDBDelete()
        End If
        'MakeQryStringToControl1Or2(1)
        'MakeQryStringToControl1Or2(2)
        GridView1.DataBind()
        GridView2.DataBind()
    End Sub

    Protected Sub btnClearSearchCondiction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearchCondiction.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
    End Sub
End Class