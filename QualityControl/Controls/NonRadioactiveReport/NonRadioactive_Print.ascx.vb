Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Security.Cryptography

Public Class NonRadioactive_Print
    Inherits System.Web.UI.UserControl

    Dim WP_System_Type As String = "品保_無輻射證明"
    Dim dot_NOTE_Type As String = "_分隔符號"
    Dim FPinfo_NOTE_Type As String = "第一頁_內容"
    Dim FPtitle_NOTE_Type As String = "第一頁_標題"
    Dim FPpeople_NOTE_Type As String = "第一頁_偵檢人員"
    Dim SPinfo_NOTE_Type As String = "第二頁_內容"
    Dim WP_ClsSystemNote As New PublicClassLibrary.ClsSystemNote
    Dim WP_LangCode As String
    Dim WP_SplitStr As String
    Dim perpage_colis As Int32 = 30 '每頁鋼捲數量
    Dim MD5head As String = "Tangeng-H3"
    Public Event Event_reFresh父物件(ByVal from主畫面_ActiveTabIndex As NonRadioactive_Main.主畫面_Enum, _
                          ByVal fromLabno As String, ByVal subno As Int32)


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            P_Init()
        End If
    End Sub
    Public Sub P_reFresh子物件(ByVal labno As String, ByVal subno As Int32)
        P_Init()
        If labno = "LOCK" Then
            tbLabNo.Enabled = False
            btnPrint.Enabled = False
        Else
            tbLabNo.Enabled = True
            btnPrint.Enabled = True
            tbLabNo.Text = labno
            tb_subno.Text = subno
            btnPrint_Click(btnPrint, Nothing)
        End If

    End Sub
    Private Sub P_Init()
        tbLabNo.Text = ""
        ReportViewer1.LocalReport.DataSources.Clear()
        ViewState.Clear()
        ViewState("lan") = "EN"
    End Sub
    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Try
            CustomValidator1.ErrorMessage = ""
            If tbLabNo.Text.Trim = "" Then
                CustomValidator1.ErrorMessage = "請輸入單據號碼"
                Exit Try
            End If
            '------------------------------------------------------------------------------------------------------------------------
            Dim SQLAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter( _
                                   CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, _
                                   CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, _
                                    "QCDB01")

            Dim W_SQL As String
            W_SQL = "SELECT * FROM LabRecordA1_M WHERE LAB_REPORTNO = '" & tbLabNo.Text.Trim & "' AND LAB_REPORTNO2 = '" & tb_subno.Text.Trim & "'"
            Dim queryTableM As DataTable = SQLAdapter.SelectQuery(W_SQL)
            W_SQL = "SELECT * FROM LabRecordA1_D WHERE LAB_REPORTNO = '" & tbLabNo.Text.Trim & "' AND LAB_REPORTNO2 = '" & tb_subno.Text.Trim & "'"
            Dim queryTableD As DataTable = SQLAdapter.SelectQuery(W_SQL)

            Debug.Print(Now)
            ReportViewer1.LocalReport.EnableExternalImages = True
            '------------------------------------------------------------------------------------------------------------------------
            With ReportViewer1.LocalReport
                .DataSources.Clear()

                Dim labno As String = tbLabNo.Text.Trim

                '-- Main---------------------------------------------------------------------------------------------------------------------------------------------
                .DataSources.Add(P_AddTable("DataSet_Master", P_AddTable_Master(queryTableM, FS_allcoils(queryTableD))))
                .DataSources.Add(P_AddTable("DataSet_DetailTitle", P_AddTable_DetailTitle(ViewState("lan").ToString)))
                .DataSources.Add(P_AddTable("DataSet_Detail", P_AddTable_Detail(queryTableD)))
                .SetParameters(P_AddParam("Param_FontIsChinese", Convert.ToBoolean(ViewState("lan").ToString = "TW")))
                .SetParameters(P_AddParam("Param_FontName_Chinese", "標楷體"))
                .SetParameters(P_AddParam("Param_FontName_Other", "Verdana"))
                Dim dot As String = WP_ClsSystemNote.getLev4Content(WP_System_Type, dot_NOTE_Type, ViewState("lan").ToString).ToString().Trim
                .SetParameters(P_AddParam("Param_QcmanList", queryTableM.Rows(0).Item("檢驗人員字號").ToString.Split(dot)(1).Trim))
                '.SetParameters(P_AddParam("Param_qrcodeimg", getQRcodeImgbyte(FS_allcoils(queryTableD))))
                '.SetParameters(P_AddParam("Param_FontName_Other", "Times New Roman"))
                .Refresh()
            End With

        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message
        End Try
        CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")
    End Sub

    Private Function P_AddTable_Master(ByVal queryTable As DataTable, ByVal allcoils As String) As QualityControlDataSet.NonRadioactive_PAGE1DataTable
        Dim paramTable As New QualityControlDataSet.NonRadioactive_PAGE1DataTable

        CustomValidator1.ErrorMessage = ""

        Try
            Dim lan As String = "EN"
            Dim paramRow As QualityControlDataSet.NonRadioactive_PAGE1Row
            Dim sourceRow As DataRow = queryTable.Rows(0)
            paramRow = paramTable.NewRow
            Dim atomNumber As String = sourceRow.Item("原能會字號")
            Dim dateStart As Date = Date.Parse(sourceRow.Item("品檢日期_起"))
            Dim dateEnd As Date = Date.Parse(sourceRow.Item("品檢日期_迄"))
            Dim datadate As Date = Date.Parse(sourceRow.Item("資料日期"))
            Dim dateStartYear As String = dateStart.Year.ToString
            Dim dateEndYear As String = dateEnd.Year.ToString
            Dim datadateYear As String = datadate.Year.ToString
            If sourceRow.Item("標題1").ToString.Contains("無") Then
                lan = "TW"
                dateStartYear = (dateStart.Year - 1911).ToString
                dateEndYear = (dateEnd.Year - 1911).ToString
                datadateYear = (datadate.Year - 1911).ToString
            End If
            ViewState("lan") = lan
            If Not lan = "TW" Then
                Dim dotindex = atomNumber.IndexOf(WP_ClsSystemNote.getLev4Content(WP_System_Type, dot_NOTE_Type, lan).Trim)
                atomNumber = atomNumber.Insert(dotindex + 2, vbNewLine & Space(4))

            End If
            With paramRow
                .標題列_01 = sourceRow.Item("標題1")
                .標題列_02 = sourceRow.Item("標題2")
                .內容_01 = sourceRow.Item("說明1")
                .內容_02 = sourceRow.Item("說明2")
                .內容_03 = sourceRow.Item("客戶名稱")
                .內容_04 = sourceRow.Item("公司名稱")
                .內容_05 = atomNumber
                .內容_06 = sourceRow.Item("檢驗人員字號")
                .內容_07 = sourceRow.Item("品檢主管")


                .內容_08 = WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "08A_" & lan) & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, dot_NOTE_Type, lan) & _
                           dateStartYear & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "08B_" & lan) & _
                           dateStart.Month.ToString("00") & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "08C_" & lan) & _
                           dateStart.Day.ToString("00") & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "08D_" & lan) & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "08E_" & lan) & _
                           dateEndYear & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "08B_" & lan) & _
                           dateEnd.Month.ToString("00") & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "08C_" & lan) & _
                           dateEnd.Day.ToString("00") & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "08D_" & lan)
                .內容_09 = sourceRow.Item("公司負責人")
                .內容_10 = sourceRow.Item("公司地址")
                .內容_11 = WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "11A_" & lan) & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, dot_NOTE_Type, lan) & _
                           datadateYear & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "11B_" & lan) & _
                           datadate.Month.ToString("00") & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "11C_" & lan) & _
                           datadate.Day.ToString("00") & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, FPinfo_NOTE_Type, "11D_" & lan)


                Dim labno As String = tbLabNo.Text & IIf(CInt(tb_subno.Text.Trim) = 0, "", "-" & CInt(tb_subno.Text.Trim).ToString("000"))
                Dim pagecount As Int32 = Math.Ceiling(allcoils.Split(",").Length / perpage_colis)
                Dim finalqrcode1 As String = String.Format("{0}{1}{2}{3}", _
                                                         labno & vbNewLine, _
                                                         pagingArray(allcoils.Split(","), 1, False), _
                                                         "1" & getMd5fixed(getMd5Hash(MD5head & allcoils)) & vbNewLine, _
                                                         "1/" & pagecount.ToString)


                .QRcodeImage1 = getQRcodeImgbyte(finalqrcode1)
                If pagecount > 1 Then
                    Dim finalqrcode2 As String = String.Format("{0}{1}{2}{3}", _
                                                        labno & vbNewLine, _
                                                        pagingArray(allcoils.Split(","), 2, True), _
                                                       "1" & getMd5fixed(getMd5Hash(MD5head & allcoils)) & vbNewLine, _
                                                        IIf(pagecount = 2, "2/2", "More..."))
                    .QRcodeImage2 = getQRcodeImgbyte(finalqrcode2)
                End If




            End With
            paramTable.Rows.Add(paramRow)
        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message
        Finally
            CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")
        End Try
        Return paramTable
    End Function
    Private Function P_AddTable_DetailTitle(ByVal lan As String) As QualityControlDataSet.NonRadioactive_PAGE2DataTable
        Dim paramTable As New QualityControlDataSet.NonRadioactive_PAGE2DataTable
        CustomValidator1.ErrorMessage = ""
        Try
            Dim paramRow As QualityControlDataSet.NonRadioactive_PAGE2Row
            paramRow = paramTable.NewRow

            With paramRow
                .標題列_01 = WP_ClsSystemNote.getLev4Content(WP_System_Type, SPinfo_NOTE_Type, "00_" & lan)

                .項目_01 = WP_ClsSystemNote.getLev4Content(WP_System_Type, SPinfo_NOTE_Type, "01_" & lan)
                .項目_02 = WP_ClsSystemNote.getLev4Content(WP_System_Type, SPinfo_NOTE_Type, "02A_" & lan)
                .項目_03 = WP_ClsSystemNote.getLev4Content(WP_System_Type, SPinfo_NOTE_Type, "03A_" & lan)
                .項目_04 = WP_ClsSystemNote.getLev4Content(WP_System_Type, SPinfo_NOTE_Type, "04A_" & lan) & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, SPinfo_NOTE_Type, "04B_" & lan)

                .項目_05 = WP_ClsSystemNote.getLev4Content(WP_System_Type, SPinfo_NOTE_Type, "05A_" & lan) & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, SPinfo_NOTE_Type, "05B_" & lan)
                .項目_06 = WP_ClsSystemNote.getLev4Content(WP_System_Type, SPinfo_NOTE_Type, "06A_" & lan) & _
                           WP_ClsSystemNote.getLev4Content(WP_System_Type, SPinfo_NOTE_Type, "06B_" & lan)
            End With
            paramTable.Rows.Add(paramRow)
        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message
        Finally
            CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")
        End Try
        Return paramTable
    End Function
    Private Function P_AddTable_Detail(ByVal queryTable As DataTable) As QualityControlDataSet.NonRadioactive_DetailDataTable
        Dim paramTable As New QualityControlDataSet.NonRadioactive_DetailDataTable
        CustomValidator1.ErrorMessage = ""
        Try
            Dim paramRow As QualityControlDataSet.NonRadioactive_DetailRow
            For Each dr As DataRow In queryTable.Rows
                paramRow = paramTable.NewRow
                With paramRow
                    .鋼捲號碼 = dr.Item("鋼捲號碼")
                    .鋼種 = dr.Item("鋼種")
                    .表面 = dr.Item("表面")
                    .厚度 = dr.Item("厚度")
                    .寬度 = dr.Item("寬度")
                    .重量 = dr.Item("重量")
                End With
                paramTable.Rows.Add(paramRow)
            Next
        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message
        Finally
            CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")
        End Try
        Return paramTable
    End Function
    Private Function FS_allcoils(ByVal queryTable As DataTable) As String
        Dim paramTable As New QualityControlDataSet.NonRadioactive_DetailDataTable
        Dim result As String = ""
        Try
            For Each dr As DataRow In queryTable.Rows
                result &= "," & dr.Item("鋼捲號碼")
            Next
        Catch ex As Exception
            CustomValidator1.ErrorMessage = ex.Message
        Finally
            CustomValidator1.IsValid = (CustomValidator1.ErrorMessage = "")
        End Try
        result = result.Remove(0, 1)
        Return result
    End Function
    Private Function pagingArray(ByVal arr As String(), ByVal pagenumber As Int32, ByVal getmore As Boolean) As String
        Dim length As Int32 = arr.Length
        Dim lintex As Int32 = perpage_colis * (pagenumber - 1)
        Dim rindex As Int32 = IIf(length - 1 > perpage_colis * pagenumber - 1, perpage_colis * pagenumber - 1, length - 1)
        Dim result As String = ""
        If getmore Then
            rindex = length - 1
        End If

        For i = lintex To rindex
            result &= arr(i) & vbNewLine
        Next
        'result = result.Remove(0, 1)
        Return result
    End Function
    Private Function getQRcodeImgbyte(ByVal content As String) As Byte()
        Dim W_Content As String = content
        Dim W_Qrcode As Bitmap
        Dim result As Byte()
        'Type1
        'W_Qrcode = New QRCode(W_Content).GetImage

        'Typ2
        Dim W_QRCodeObj As QRCode = New QRCode
        W_QRCodeObj.ColorOfDark = Brushes.Blue
        W_QRCodeObj.Content = W_Content

        W_Qrcode = W_QRCodeObj.GetImage
        Using ms As New System.IO.MemoryStream
            W_Qrcode.Save(ms, ImageFormat.Png)
            result = ms.ToArray()
            Return result
        End Using

    End Function
   
    Private Function P_AddParam(ByVal fromTag As String, ByVal fromObj As Object) As Microsoft.Reporting.WebForms.ReportParameter
        Dim reportParam As New Microsoft.Reporting.WebForms.ReportParameter(fromTag, fromObj.ToString)
        Return reportParam
    End Function
    Private Function getMd5Hash(ByVal input As String) As String    'MD5計算Function,取自MSDN
        ' 建立一個MD5物件
        Dim md5Hasher As MD5 = MD5.Create()

        ' 將input轉換成MD5，並且以Bytes傳回，由於ComputeHash只接受Bytes型別參數，所以要先轉型別為Bytes
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))

        ' 建立一個StringBuilder物件
        Dim sBuilder As New StringBuilder()

        ' 將Bytes轉型別為String，並且以16進位存放
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        '傳回
        Return sBuilder.ToString()

    End Function

    Private Function getMd5fixed(ByVal input As String) As String
        Dim str As String = input
        str = str.Replace("1", "@")
        str = str.Replace("2", "1")
        str = str.Replace("@", "2")
        Return str

    End Function

    Private Function P_AddTable(ByVal fromTag As String, ByVal fromObj As Object) As Microsoft.Reporting.WebForms.ReportDataSource
        Dim rds As New Microsoft.Reporting.WebForms.ReportDataSource()
        rds.Name = fromTag
        rds.Value = fromObj

        Return rds
    End Function
End Class