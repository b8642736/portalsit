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
    ''' 列印
    ''' </summary>
    ''' <remarks></remarks>
    Private intIndex As Integer = 0   '頁數索引
    Private MyStreamList As List(Of System.IO.Stream) = New List(Of System.IO.Stream)    '各頁的串流
    ''' <summary>
    ''' 列印
    ''' </summary>
    ''' <param name="PrintData"></param>
    ''' <remarks></remarks>
    Public Sub Print(ByVal PrintData() As ReportDataSource, ByVal SetPrintArgs As PrintArg)
        LocalReportObject.ReportEmbeddedResource = ReportEmbeddedResource  '內崁資料名稱
        For Each EachItem As ReportDataSource In PrintData
            LocalReportObject.DataSources.Add(EachItem) '設定報表資料來源
        Next


        With SetPrintArgs
            Dim Parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)
            If SetPrintArgs.HeadLineName.Trim.ToUpper.PadRight(3).Substring(0, 3) = "APL" Then
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TitleArg1", .TitleArg1))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadCoilNumber", .HeadCoilNumber))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadSteelKind", .HeadSteelKind))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadSteelFace", .HeadSteelFace))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadThick", .HeadThick))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadLength", .HeadLength))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadLineName", .HeadLineName))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadMaterialType", .HeadMaterialType))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadCoilBirthday", .HeadCoilBirthday))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadBilletNumber", .HeadBilletNumber))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailHotCoilBatch", .TailHotCoilBatch))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailPackage", .TailPackage))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailBrokeMachine", .TailBrokeMachine))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailTestThick", .TailTestThick))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailNO1Shape", .TailNO1Shape))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailInputEmployeeNO", .TailInputEmployeeNO))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadCoilReceiveType", .HeadCoilReceiveType))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("APLMemo", .APLMemo))
                If Not IsNothing(.HandOverLength) Then
                    Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HandOverLength", .HandOverLength))
                Else
                    Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HandOverLength", ""))
                End If
                If SetPrintArgs.HeadLineName.Trim.ToUpper.PadRight(4).Substring(0, 4) = "APL1" Then
                    Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("C40", .C40))
                End If
            Else
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TitleArg1", .TitleArg1))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadCoilNumber", .HeadCoilNumber))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadSteelKind", .HeadSteelKind))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadSteelFace", .HeadSteelFace))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadThick", .HeadThick))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadLength", .HeadLength))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadLineName", .HeadLineName))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadMaterialType", .HeadMaterialType))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadCoilBirthday", .HeadCoilBirthday))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailHotCoilBatch", .TailHotCoilBatch))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailPackage", .TailPackage))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailInputEmployeeNO", .TailInputEmployeeNO))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailBALLightArg1", .TailBALLightArg1))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailBALLightArg2", .TailBALLightArg2))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailBALLightArg3", .TailBALLightArg3))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailTestThick", .TailTestThick))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HeadCoilReceiveType", .HeadCoilReceiveType))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailBALLightArg4", .TailBALLightArg4))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailBALLightArg5", .TailBALLightArg5))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("TailBALLightArg6", .TailBALLightArg6))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("SectionSheetArg1", .SectionSheetArg1))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("SectionSheetArg2", .SectionSheetArg2))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("SectionSheetArg3", .SectionSheetArg3))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("SectionSheetArg4", .SectionSheetArg4))
                Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("BALMemo", .BALMemo))
                If Not IsNothing(.HandOverLength) Then
                    Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HandOverLength", .HandOverLength))
                Else
                    Parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("HandOverLength", ""))
                End If
            End If
            LocalReportObject.SetParameters(Parameters.ToArray)
        End With

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

#Region "設定列印資料 函式:SetPrintDatasAndPrint"
    ''' <summary>
    ''' 設定列印資料
    ''' </summary>
    ''' <param name="Set2DataTable"></param>
    ''' <param name="SetPrintArgs"></param>
    ''' <remarks></remarks>
    Public Sub SetPrintDatasAndPrint(ByVal Set2DataTable() As DataTable, ByVal SetPrintArgs As PrintArg)
        Dim PrintControl As RDLCDirectPrint = Nothing
        Select Case True
            Case SetPrintArgs.HeadLineName.Trim.ToUpper.PadRight(4).Substring(0, 4) = "APL1"
                PrintControl = New RDLCDirectPrint("QAColdRollingClient.APL.rdlc")
            Case SetPrintArgs.HeadLineName.Trim.ToUpper.PadRight(4).Substring(0, 4) = "APL2"
                PrintControl = New RDLCDirectPrint("QAColdRollingClient.APL2.rdlc")
            Case SetPrintArgs.HeadLineName.Trim.ToUpper.PadRight(3).Substring(0, 3) = "BAL"
                PrintControl = New RDLCDirectPrint("QAColdRollingClient.BAL.rdlc")
        End Select

        With PrintControl
            '.DeviceInfo_MarginLeft = 0.1
            '.DeviceInfo_MarginRight = 0.5
            '.DeviceInfo_MarginTop = 0.75
            '.DeviceInfo_MarginBottom = 0
            '.OutPaperSize = New PaperSize("Customer", 11.45 * 0.039 * 1000, 21.6 * 0.039 * 1000)
            .DeviceInfo_MarginLeft = 1
            .DeviceInfo_MarginRight = 1
            .DeviceInfo_MarginTop = 1
            .DeviceInfo_MarginBottom = 1
            .OutPaperSize = New PaperSize("A4", 21 * 0.039 * 1000, 29.7 * 0.039 * 1000)
            .OutPrintDocument.DefaultPageSettings.Landscape = False
        End With
        'Dim myDataSet As New DBDataSet
        'myDataSet.Tables.Add(SetData1)
        'myDataSet.Tables.Add(SetData2)

        Dim DataSorce1 As New ReportDataSource("DataSet1", CType(Set2DataTable(0), DataTable))
        Dim DataSorce2 As New ReportDataSource("DataSet2", CType(Set2DataTable(1), DataTable))

        Try
            PrintControl.Print({DataSorce1, DataSorce2}, SetPrintArgs)


        Catch ex As Exception

            MessageBox.Show("錯誤!!報表無法印出，請聯繫相關人員處理")

            Dim MailObject As New PublicClassLibrary.MISMail

            MailObject.ToMailAddress.Add(New MailAddress("30355@mail.tangeng.com.tw", "龔泓璋"))
            MailObject.SendMail("報表印出處理錯誤通知!!", "錯誤訊息:" & ex.ToString)

            Exit Sub
        End Try
    End Sub

#End Region



#Region "印表參數 類別:PrintArg"
    ''' <summary>
    ''' 印表參數
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PrintArg
        Property TitleArg1 As String
        Property HeadCoilNumber As String
        Property HeadSteelKind As String
        Property HeadSteelFace As String
        Property HeadThick As String
        Property HeadLength As String
        Property HeadLineName As String
        Property HeadMaterialType As String
        Property HeadCoilBirthday As String
        Property HeadBilletNumber As String
        Property TailHotCoilBatch As String
        Property TailPackage As String
        Property TailBrokeMachine As String
        Property TailTestThick As String
        Property TailNO1Shape As String
        Property TailInputEmployeeNO As String
        Property HeadCoilReceiveType As String
        Property HandOverLength As String

        ''1060522 鋼種Type
        Property CoilType As String

        'APL1專用參數
        Property C40 As String

        'APL2專用參數
        Property APLMemo As String          'APL2生產備註右側文字

        'BAL專用參數
        Property TailBALLightArg1 As String
        Property TailBALLightArg2 As String
        Property TailBALLightArg3 As String
        Property TailBALLightArg4 As String
        Property TailBALLightArg5 As String
        Property TailBALLightArg6 As String
        Property SectionSheetArg1 As String '片型
        Property SectionSheetArg2 As String
        Property SectionSheetArg3 As String
        Property SectionSheetArg4 As String
        Property BALMemo As String          'BAL生產備註右側文字
    End Class
#End Region

End Class
