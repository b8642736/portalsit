Public Class ProductLabelPrint

    Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Declare Auto Function SetForegroundWindow Lib "USER32.DLL" (ByVal hWnd As IntPtr) As Boolean


#Region "是否已按下查詢按鈕 屬性:IsPushSearchButton"

    Private _IsPushSearchButton As Boolean
    ''' <summary>
    ''' 是否已按下查詢按鈕
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsPushSearchButton() As Boolean
        Get
            Return _IsPushSearchButton
        End Get
        Set(ByVal value As Boolean)
            _IsPushSearchButton = value
        End Set
    End Property

#End Region

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim Parameters(13) As Microsoft.Reporting.WinForms.ReportParameter  'Microsoft.Reporting.WebForms.ReportParameter
        Parameters(0) = New Microsoft.Reporting.WinForms.ReportParameter("PRODUCT", "冷軋不锈鋼帶捲")
        Parameters(1) = New Microsoft.Reporting.WinForms.ReportParameter("WG", "4320")
        Parameters(2) = New Microsoft.Reporting.WinForms.ReportParameter("TWNUMBER", 5699)
        Parameters(3) = New Microsoft.Reporting.WinForms.ReportParameter("SIZE", "0.7 * 1219" & vbNewLine & "Scrap edge width 0mm")
        Parameters(4) = New Microsoft.Reporting.WinForms.ReportParameter("NW", "4213")
        Parameters(5) = New Microsoft.Reporting.WinForms.ReportParameter("COILNO", "C7002-A")
        Parameters(6) = New Microsoft.Reporting.WinForms.ReportParameter("GRADEFINISH", "TE201" & vbNewLine & "2B")
        Parameters(7) = New Microsoft.Reporting.WinForms.ReportParameter("SLABNO", "B3501-3010")
        Parameters(8) = New Microsoft.Reporting.WinForms.ReportParameter("CLIENT", "源鋼" & vbNewLine & "P489709003")
        Parameters(9) = New Microsoft.Reporting.WinForms.ReportParameter("LOCATION", "X")
        Parameters(10) = New Microsoft.Reporting.WinForms.ReportParameter("DATE", "2008/10/21")
        Parameters(11) = New Microsoft.Reporting.WinForms.ReportParameter("INSPECTOR", "33100")
        Parameters(12) = New Microsoft.Reporting.WinForms.ReportParameter("SERIALNO", "38")
        Parameters(13) = New Microsoft.Reporting.WinForms.ReportParameter("CLASS", "1")
        ReportViewer1.LocalReport.SetParameters(Parameters)
        IsPushSearchButton = True
        ReportViewer1.RefreshReport()
    End Sub


    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        If IsPushSearchButton Then
            IsPushSearchButton = False
            Dim NewThread As New Threading.Thread(AddressOf SendKeyForPrintWindow)
            NewThread.Start()
            ReportViewer1.PrintDialog()
        End If
    End Sub

    Private Sub SendKeyForPrintWindow(Optional ByVal DelayMilliSeconds As Double = 1000)
        Threading.Thread.Sleep(DelayMilliSeconds)
        Dim hWnd As Integer
        hWnd = FindWindow(vbNullString, "列印")
        If hWnd Then
            SetForegroundWindow(hWnd)
            SendKeys.SendWait("{Enter}")
        Else
            MsgBox("未找到列印視窗!")
        End If
    End Sub

End Class