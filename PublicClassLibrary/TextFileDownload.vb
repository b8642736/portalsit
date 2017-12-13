Public Class TextFileDownload

#Region "下載VB文字程式碼檔  函式:DownTextVBCode"
    ''' <summary>
    ''' 下載VB文字程式碼檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Download(ByVal SourceString As String, ByVal SetFullFileName As String, ByVal SourcePage As System.Web.UI.Page)
        SourcePage.Response.Clear()
        SourcePage.Response.Buffer = True
        SourcePage.Response.Charset = ""
        SourcePage.Response.AddHeader("Accept-Language", "zh-tw")
        SourcePage.Response.AddHeader("Content-Disposition", "Attachment;FileName=" + System.Web.HttpUtility.UrlEncode(SetFullFileName, System.Text.Encoding.UTF8))
        SourcePage.Response.ContentType = "application/octet-stream"

        SourcePage.Response.Write(SourceString)
        SourcePage.Response.Flush()
        SourcePage.Response.End()

    End Sub
#End Region

End Class
