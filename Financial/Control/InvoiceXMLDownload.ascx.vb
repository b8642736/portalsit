Public Partial Class InvoiceXMLDownload
    Inherits System.Web.UI.UserControl

    Private Sub DownLoadInvoiceFile(ByVal DownLoadFileName As String, Optional ByVal DownAS400DBMemberName As String = Nothing)
        Dim SearchResult As List(Of CompanyORMDB.sls300lb.INVOICEA) = CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.sls300lb.INVOICEA)("Select * from @#SLS300LB.INVOICEA" & IIf(IsNothing(DownAS400DBMemberName), Nothing, "." & DownAS400DBMemberName))
        Dim DownloadText As String = Nothing
        For Each EachItem As CompanyORMDB.sls300lb.INVOICEA In SearchResult
            DownloadText &= IIf(IsNothing(DownloadText), EachItem.TEXTConvertToUTF8Text, vbNewLine & EachItem.TEXTConvertToUTF8Text)
        Next
        TextFileDownload.Download(DownloadText, DownLoadFileName, Me.Page)
    End Sub
    Private Sub DownLoadNegotiationFile(ByVal DownLoadFileName As String, Optional ByVal DownAS400DBMemberName As String = Nothing)
        Dim SearchResult As List(Of CompanyORMDB.sls300lb.INVOICEE) = CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.sls300lb.INVOICEE)("Select * from @#SLS300LB.INVOICEE" & IIf(IsNothing(DownAS400DBMemberName), Nothing, "." & DownAS400DBMemberName))
        Dim DownloadText As String = Nothing
        For Each EachItem As CompanyORMDB.sls300lb.INVOICEE In SearchResult
            DownloadText &= IIf(IsNothing(DownloadText), EachItem.TEXTConvertToUTF8Text, vbNewLine & EachItem.TEXTConvertToUTF8Text)
        Next
        TextFileDownload.Download(DownloadText, DownLoadFileName, Me.Page)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownLoad.Click
        DownLoadInvoiceFile("電子發票.xml")
    End Sub

    Protected Sub btnDownLoad0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownLoad0.Click
        DownLoadInvoiceFile("電子發票.xml", "TEMP01")
    End Sub

    Protected Sub btnDownLoad1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownLoad1.Click
        DownLoadInvoiceFile("電子發票.xml", "TEMP02")
    End Sub

    Protected Sub btnDownLoad2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownLoad2.Click
        DownLoadInvoiceFile("電子發票.xml", "TEMP03")
    End Sub

    Protected Sub btnDownLoad3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownLoad3.Click
        DownLoadInvoiceFile("電子發票.xml", "TEMP04")
    End Sub

    Protected Sub btnDownLoadA0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownLoadA0.Click
        DownLoadNegotiationFile("交運清單.xml")
    End Sub

End Class