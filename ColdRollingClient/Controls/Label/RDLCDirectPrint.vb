Imports System.IO
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports Microsoft.Reporting.WinForms

Public Class RDLCDirectPrint

    Sub New(ByVal SetReportEmbeddedResource As String)
        ReportEmbeddedResource = SetReportEmbeddedResource
    End Sub


#Region "本機報表轉譯物件 屬性:LocalReportObject"
    Private _LocalReportObject As LocalReport = New LocalReport()
    ''' <summary>
    ''' 本機報表轉譯物件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LocalReportObject() As LocalReport
        Get
            Return _LocalReportObject
        End Get
        Set(ByVal value As LocalReport)
            _LocalReportObject = value
        End Set
    End Property

#End Region
#Region "裝置資訊字串 屬性:DeviceInfoString"
    ''' <summary>
    ''' 裝置資訊字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DeviceInfoString As String
        Get
            Dim ReturnValue As New StringBuilder
            ReturnValue.Append("<DeviceInfo>")
            ReturnValue.Append("<OutputFormat>" & DeviceInfo_OutputFormat & "</OutputFormat>")
            ReturnValue.Append("<PageHeigh>" & _DeviceInfo_PageHeight & "cm</PageHeigh>")
            ReturnValue.Append("<PageWidth>" & DeviceInfo_PageWidth & "cm</PageWidth>")
            ReturnValue.Append("<MarginTop>" & DeviceInfo_MarginTop & "cm</MarginTop>")
            ReturnValue.Append("<MarginLeft>" & DeviceInfo_MarginLeft & "cm</MarginLeft>")
            ReturnValue.Append("<MarginRight>" & DeviceInfo_MarginRight & "cm</MarginRight>")
            ReturnValue.Append("<MarginBottom>" & DeviceInfo_MarginBottom & "cm</MarginBottom>")
            ReturnValue.Append("</DeviceInfo>")
            Return ReturnValue.ToString
        End Get
    End Property
#End Region
#Region "裝置資訊_輸出格式 屬性:DeviceInfo_OutputFormat"
    Private _DeviceInfo_OutputFormat As String = "EMF"
    ''' <summary>
    ''' "裝置資訊_輸出格式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DeviceInfo_OutputFormat() As String
        Get
            Return _DeviceInfo_OutputFormat
        End Get
        Set(ByVal value As String)
            _DeviceInfo_OutputFormat = value
        End Set
    End Property

#End Region
#Region "裝置資訊_紙張寬度 屬性:DeviceInfo_PageWidth"
    Private _DeviceInfo_PageWidth As Single = 21
    ''' <summary>
    ''' 裝置資訊_紙張寬度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DeviceInfo_PageWidth() As Single
        Get
            Return _DeviceInfo_PageWidth
        End Get
        Set(ByVal value As Single)
            _DeviceInfo_PageWidth = value
        End Set
    End Property

#End Region
#Region "裝置資訊_紙張高度 屬性:DeviceInfo_PageHeight"
    Private _DeviceInfo_PageHeight As Single = 29.7
    ''' <summary>
    ''' 裝置資訊_紙張高度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DeviceInfo_PageHeight() As Single
        Get
            Return _DeviceInfo_PageHeight
        End Get
        Set(ByVal value As Single)
            _DeviceInfo_PageHeight = value
        End Set
    End Property

#End Region
#Region "裝置資訊_上邊空白 屬性:DeviceInfo_MarginTop"
    Private _DeviceInfo_MarginTop As Single = 1
    ''' <summary>
    ''' 裝置資訊_上邊空白
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DeviceInfo_MarginTop() As Single
        Get
            Return _DeviceInfo_MarginTop
        End Get
        Set(ByVal value As Single)
            _DeviceInfo_MarginTop = value
        End Set
    End Property

#End Region
#Region "裝置資訊_左邊空白 屬性:DeviceInfo_MarginLeft"
    Private _DeviceInfo_MarginLeft As Single = 1
    ''' <summary>
    ''' 裝置資訊_左邊空白s
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DeviceInfo_MarginLeft() As Single
        Get
            Return _DeviceInfo_MarginLeft
        End Get
        Set(ByVal value As Single)
            _DeviceInfo_MarginLeft = value
        End Set
    End Property

#End Region
#Region "裝置資訊_右邊空白 屬性:DeviceInfo_MarginRight"
    Private _DeviceInfo_MarginRight As Single = 1
    ''' <summary>
    ''' 裝置資訊_右邊空白
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DeviceInfo_MarginRight() As Single
        Get
            Return _DeviceInfo_MarginRight
        End Get
        Set(ByVal value As Single)
            _DeviceInfo_MarginRight = value
        End Set
    End Property

#End Region
#Region "裝置資訊_下邊空白 屬性:DeviceInfo_MarginBottom"
    Private _DeviceInfo_MarginBottom As Single = 1
    ''' <summary>
    ''' 裝置資訊_下邊空白
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DeviceInfo_MarginBottom() As Single
        Get
            Return _DeviceInfo_MarginBottom
        End Get
        Set(ByVal value As Single)
            _DeviceInfo_MarginBottom = value
        End Set
    End Property

#End Region
#Region "報表轉譯格式 屬性:ReportTransFormat"
    ''' <summary>
    ''' 報表轉譯格式(Excel、PDF、Word 和 Image 三種)
    ''' </summary>
    ''' <remarks></remarks>
    Private _ReportTransFormat As String = "Image"
    Public Property ReportTransFormat() As String
        Get
            Return _ReportTransFormat
        End Get
        Set(ByVal value As String)
            _ReportTransFormat = value
        End Set
    End Property

#End Region
#Region "內崁報表名稱 屬性:ReportEmbeddedResource"
    Private _ReportEmbeddedResource As String
    ''' <summary>
    ''' 報表檔案完整路徑
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>專案名稱.報表檔名 ex:RdlcPrintTest.Report1.rdlc</remarks>
    Public Property ReportEmbeddedResource() As String
        Get
            Return _ReportEmbeddedResource
        End Get
        Set(ByVal value As String)
            _ReportEmbeddedResource = value
        End Set
    End Property

#End Region
#Region "輸出印表機名稱 屬性:OutputPrinterName"
    Private _OutputPrinterName As String
    ''' <summary>
    ''' 輸出印表機名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>沒有給值則為預設印表機名稱 給值範例:"Microsoft XPS Document Writer"</remarks>
    Public Property OutputPrinterName() As String
        Get
            Return _OutputPrinterName
        End Get
        Set(ByVal value As String)
            _OutputPrinterName = value
        End Set
    End Property

#End Region
#Region "輸出紙張大小 屬性:OutPaperSize"
    Private _PaperSize As PaperSize = New PaperSize("MySize", 827, 1169)
    ''' <summary>
    ''' 輸出紙張大小
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>預設A4大小 計算公式:210mm*297mm ex:寬:210*0.039*1000 高:297*0.039*1000</remarks>
    Public Property OutPaperSize() As PaperSize
        Get
            Return _PaperSize
        End Get
        Set(ByVal value As PaperSize)
            _PaperSize = value
        End Set
    End Property
#End Region
#Region "繪製報表時的警告清單 屬性:OutWarnings"
    Private _Warnings() As Warning
    ''' <summary>
    ''' 繪製報表時的警告清單
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OutWarnings() As Warning()
        Get
            Return _Warnings
        End Get
        Private Set(ByVal value As Warning())
            _Warnings = value
        End Set
    End Property

#End Region
#Region "列印文件 屬性:OutPrintDocument"
    Private _OutPrintDocument As PrintDocument = New PrintDocument
    ''' <summary>
    ''' 列印文件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property OutPrintDocument As PrintDocument
        Get
            Return _OutPrintDocument
        End Get
    End Property
#End Region

#Region "列印 函式:Print"
    ''' <summary>
    ''' v
    ''' </summary>
    ''' <remarks></remarks>
    Private intIndex As Integer = 0   '頁數索引
    Private MyStreamList As List(Of System.IO.Stream) = New List(Of System.IO.Stream)    '各頁的串流
    ''' <summary>
    ''' 列印
    ''' </summary>
    ''' <param name="PrintData"></param>
    ''' <remarks></remarks>
    Public Sub Print(ByVal PrintData As ReportDataSource)
        LocalReportObject.ReportEmbeddedResource = ReportEmbeddedResource  '內崁資料名稱
        LocalReportObject.DataSources.Add(PrintData) '設定報表資料來源
        Try
            LocalReportObject.Render(Me.ReportTransFormat, Me.DeviceInfoString, AddressOf CreateStream, OutWarnings)

            If Not String.IsNullOrEmpty(OutputPrinterName) Then
                OutPrintDocument.PrinterSettings.PrinterName = OutputPrinterName    '指定印表機名稱
            End If
            If Not IsNothing(OutPaperSize) Then
                OutPrintDocument.DefaultPageSettings.PaperSize = OutPaperSize   '指定紙張大小
            End If
            AddHandler OutPrintDocument.PrintPage, AddressOf PrintPageProcess
            OutPrintDocument.Print()    '列印
            RemoveHandler OutPrintDocument.PrintPage, AddressOf PrintPageProcess

        Catch ex As Exception
            Throw ex
        Finally
            For Each EachItem As Stream In MyStreamList
                EachItem.Flush()
                EachItem.Close()
            Next
        End Try

    End Sub
    Private Sub PrintPageProcess(ByVal s As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
        '每列印一頁時的事件
        Dim MyRectangle As Rectangle = New Rectangle(ev.PageBounds.Left - CType(ev.PageSettings.HardMarginX, Integer), _
        ev.PageBounds.Top - CType(ev.PageSettings.HardMarginY, Integer), ev.PageBounds.Width, ev.PageBounds.Height)


        '將該頁串流位置設到起頭
        MyStreamList(intIndex).Position = 0

        '從串流繪製到印表機
        ev.Graphics.DrawImage(New Metafile(MyStreamList(intIndex)), MyRectangle)
        ev.Graphics.Dispose()

        '計算是否還有一下頁
        intIndex += 1
        ev.HasMorePages = (intIndex < MyStreamList.Count)

    End Sub

    Private Function CreateStream(name As String, fileNameExtension As String, encoding As Encoding, mimeType As String, willSeek As Boolean) As Stream
        Dim FileName As String = name + "." + fileNameExtension
        Dim stream As Stream = New FileStream(name + "." + fileNameExtension, FileMode.Create)
        MyStreamList.Add(stream)
        Return stream
    End Function
#End Region

End Class
