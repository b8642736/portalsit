Public Partial Class WeightProcess
    Inherits System.Web.UI.UserControl

    Private Sub CopyDellFileToRootPath(ByVal DllFile As String)
        Dim FromFullPath As String = Page.Server.MapPath("~") & "\bin\" & DllFile
        Dim ToFullPath As String = Page.Server.MapPath("~") & "\" & DllFile
        My.Computer.FileSystem.CopyFile(FromFullPath, ToFullPath, True)
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CopyDellFileToRootPath("ProductStockProcessControls.dll")
        CopyDellFileToRootPath("ExWindowControlLibrary.dll")
        CopyDellFileToRootPath("CompanyORMDB.dll")
        CopyDellFileToRootPath("CompanyORMDB.XmlSerializers.dll")
    End Sub

End Class