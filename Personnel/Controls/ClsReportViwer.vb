Imports Microsoft.Reporting.WebForms

Public Class ClsReportViwer


    Public Enum ReportExport_Enum
        畫面 = 1
        PDF = 2
        Excel = 3
        Image = 4
    End Enum

    Public Function ReportExport_Name(ByVal fromReportExport_Enum As ReportExport_Enum) As String

        Select Case fromReportExport_Enum
            Case ReportExport_Enum.畫面
                Return "畫面"
            Case ReportExport_Enum.PDF
                Return "PDF"
            Case ReportExport_Enum.Excel
                Return "Excel"
            Case ReportExport_Enum.Image
                Return "Image"
            Case Else
                Return "UnKnow：" & fromReportExport_Enum
        End Select

    End Function


    Public Sub execReport(ByVal fromReportExport As ClsReportViwer.ReportExport_Enum, _
                                               ByRef fromReportViewer As ReportViewer, _
                                               ByRef fromResponse As System.Web.HttpResponse, _
                                               Optional ByVal fromFileName As String = "")
        Select Case fromReportExport
            Case ClsReportViwer.ReportExport_Enum.畫面
                fromReportViewer.LocalReport.Refresh()

            Case Else
                Dim warnings() As Warning = Nothing
                Dim streamids() As String = Nothing
                Dim mimeType As String = Nothing
                Dim encoding As String = Nothing
                Dim extension As String = Nothing

                Dim exportTypeMode As String = ""
                Dim exportTypeFileSubName As String = ""

                Select Case fromReportExport
                    Case ClsReportViwer.ReportExport_Enum.PDF
                        exportTypeMode = "Pdf"
                        exportTypeFileSubName = "pdf"
                    Case ClsReportViwer.ReportExport_Enum.Excel
                        exportTypeMode = "Excel"
                        exportTypeFileSubName = "xls"
                    Case ClsReportViwer.ReportExport_Enum.Image
                        exportTypeMode = "Image"
                        exportTypeFileSubName = "tif"
                End Select

                Dim bytes() As Byte = fromReportViewer.LocalReport.Render(
                    exportTypeMode,
                     "", mimeType, encoding, extension, streamids, warnings)

                fromResponse.Clear()
                fromResponse.AddHeader("Content-Disposition", "attachment; filename=" & System.Web.HttpUtility.UrlEncode(fromFileName) & "." & exportTypeFileSubName)
                fromResponse.AddHeader("Content-Length", bytes.Length.ToString())
                fromResponse.ContentType = "application/octet-stream"
                fromResponse.OutputStream.Write(bytes, 0, bytes.Length)
        End Select
    End Sub



End Class
