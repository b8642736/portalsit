Public Partial Class SQLServerDBToVBClass
    Inherits System.Web.UI.UserControl

#Region "轉換物件 屬性:SQLServerDBToVBConverter"
    Private _SQLServerDBToVBConverter As SQLServerDBToVB
    ''' <summary>
    ''' 轉換物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SQLServerDBToVBConverter() As SQLServerDBToVB
        Get
            Dim QueryServer As CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum = CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.UnKnow
            Select Case True
                Case ddlServer.SelectedValue.ToUpper = "SERVER0SM"
                    QueryServer = CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server0SM
                Case ddlServer.SelectedValue.ToUpper = "SERVER04M"
                    QueryServer = CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m
                Case ddlServer.SelectedValue.ToUpper = "SERVERSPM"
                    QueryServer = CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.ServerSPM
                Case Else
                    QueryServer = CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.UnKnow
            End Select
            _SQLServerDBToVBConverter = New SQLServerDBToVB(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QueryServer, tbDBName.Text.Trim, tbTableName.Text.Trim)
            Return _SQLServerDBToVBConverter
        End Get
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnConvertToVBFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConvertToVBFile.Click
        Me.TextBox1.Text = SQLServerDBToVBConverter.ConvertFieldRowInfoToVBCode
    End Sub

    Protected Sub btnDownLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownLoad.Click
        AS400DBToVB.DownTextVBCode(Me.TextBox1.Text, tbTableName.Text & ".vb", Me.Page)
    End Sub
End Class