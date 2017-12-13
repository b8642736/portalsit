Public Partial Class MenuEditForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CopyDellFileToRootPath("WCOtherOperator.dll")
        CopyDellFileToRootPath("CompanyORMDB.XmlSerializers.dll")
        CopyDellFileToRootPath("CompanyORMDB.dll")
    End Sub

    Private Sub CopyDellFileToRootPath(ByVal DllFile As String)
        Dim FromFullPath As String = Page.Server.MapPath("~") & "\bin\" & DllFile
        Dim ToFullPath As String = Page.Server.MapPath("~") & "\" & DllFile
        My.Computer.FileSystem.CopyFile(FromFullPath, ToFullPath, True)
    End Sub


End Class