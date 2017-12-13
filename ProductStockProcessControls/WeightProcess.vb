<System.Security.Permissions.ZoneIdentityPermission(Security.Permissions.SecurityAction.LinkDemand)> _
Public Class WeightProcess


#Region "WebServer現在時間 屬性:WebServerNowTime"

    Private _WebServerNowTime As Nullable(Of DateTime)
    ''' <summary>
    ''' WebServer現在時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WebServerNowTime() As Nullable(Of DateTime)
        Get
            Static GetTimeTimes As Integer
            If IsNothing(_WebServerNowTime) OrElse GetTimeTimes > 600 Then
                GetTimeTimes = 0
                Try
                    _WebServerNowTime = (New CompanyORMDB.WSDBSQLQueryAdapter(True)).CurrentCanUseQueryService.GetServerTimeGo
                Catch ex As Exception
                    _WebServerNowTime = Now
                End Try
            End If
            GetTimeTimes += 1
            Return _WebServerNowTime
        End Get
        Private Set(ByVal value As Nullable(Of DateTime))
            _WebServerNowTime = value
        End Set
    End Property

#End Region
#Region "現在使用P.P.排程檔 屬性:CurrentUsePPSSHAPF"

    Private _CurrentUsePPSSHAPF As DataRow
    ''' <summary>
    ''' 現在使用P.P.排程檔
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentUsePPSSHAPF() As DataRow
        Get
            Return _CurrentUsePPSSHAPF
        End Get
        Set(ByVal value As DataRow)
            _CurrentUsePPSSHAPF = value
        End Set
    End Property

#End Region


    Private Sub SPWeight_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SPWeight.DataReceived
        Me.Invoke(New MethodInvoker(AddressOf Me.SetSPWeightData), Nothing)
    End Sub


    'Private Sub SPBarCordScanner_DataReceivFinishedEx(ByVal Sender As System.IO.Ports.SerialPort, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs, ByVal ReceiveData As String)
    '    Dim GetData As String = ReceiveData.Trim
    '    btSteelTapeNumber.Text = GetData.Substring(0, 5)
    '    If GetData.Length < 7 Then
    '        btSteelTapeNumberSubNumber.Text = Nothing
    '    Else
    '        btSteelTapeNumberSubNumber.Text = GetData.Substring(7, GetData.Length - 7)
    '    End If
    '    Call btnSearch_Click(btnSearch, Nothing)
    'End Sub



    Public Sub SetSPWeightData()
        Threading.Thread.Sleep(10)
        Dim GetOrginData As String = SPWeight.ReadExisting
        If String.IsNullOrEmpty(GetOrginData) OrElse Not GetOrginData.ToUpper.EndsWith("KG") Then
            Exit Sub
        End If
        Try
            GetOrginData = GetOrginData.ToUpper.Replace("ST,GS,+", Nothing).Replace("KG", Nothing).Trim
            tbDeviceWeight.Text = CType(GetOrginData, Integer)
            Dim ShowBarValue As Integer = CType(tbDeviceWeight.Text, Integer)
            ProgressBar1.Maximum = IIf(ShowBarValue > 10000, ShowBarValue + 10, 10000)
            ProgressBar1.Value = IIf(ShowBarValue < 0, 0, ShowBarValue)
            btnSaveWeight.Enabled = btSteelTapeNumber.Text.Length > 0 And ProgressBar1.Value > 5
            btnSaveWeight.BackColor = IIf(btnSaveWeight.Enabled, Color.LightGreen, Color.Gray)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WeightProcess_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If SPWeight.IsOpen Then
            SPWeight.Close()
            SPWeight.Dispose()
        End If
    End Sub



    Private Sub StartForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbDeviceWeight.Enabled = False
        Try
            SPWeight.OpenAndSetContainerControl(Me)
        Catch ex As Exception
            stlMessage.Text = "注意:過磅程式偵測重量發生異常,改以手動輸入重量!"
            tbDeviceWeight.Enabled = True
            btnSaveWeight.Enabled = True
            MsgBox(stlMessage.Text & ex.ToString)
        End Try
        btSteelTapeNumber.Focus()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim AS400QueryServiceAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.WebService)
        Try
            btSteelTapeNumber.Text = btSteelTapeNumber.Text.Trim.ToUpper.Replace("'", "").Replace("""", "")
            btSteelTapeNumberSubNumber.Text = btSteelTapeNumberSubNumber.Text.Trim.ToUpper.Replace("'", "").Replace("""", "")
            Dim AS400DBFullPath As String = (New CompanyORMDB.PPS100LB.PPSSHAPF).CDBFullAS400DBPath.Trim
            Dim FindPPSSHAPFs As DataTable = AS400QueryServiceAdapter.SelectQuery("Select * from " & AS400DBFullPath & " Where SHA01='" & btSteelTapeNumber.Text & "' AND SHA02='" & btSteelTapeNumberSubNumber.Text & "' AND SHA29<>'*'  order by SHA04 desc ")
            If IsNothing(FindPPSSHAPFs) Then
                Exit Sub
            End If
            If FindPPSSHAPFs.Rows.Count = 0 Then
                FindPPSSHAPFs = AS400QueryServiceAdapter.SelectQuery("Select * from " & AS400DBFullPath & " Where SHA01='" & btSteelTapeNumber.Text & "'  AND SHA29<>'*'  order by SHA04 desc ")
            End If
            If FindPPSSHAPFs.Rows.Count > 0 Then
                Me.CurrentUsePPSSHAPF = FindPPSSHAPFs.Rows(0)
            Else
                Me.CurrentUsePPSSHAPF = Nothing
            End If

            If Not IsNothing(CurrentUsePPSSHAPF) Then
                Me.lbSHA12.Text = Me.CurrentUsePPSSHAPF.Item("SHA12")
                Me.lbSHA13.Text = Me.CurrentUsePPSSHAPF.Item("SHA06") 'Me.CurrentUsePPSSHAPF.Item("SHA13")
                Me.lbSHA6.Text = Me.CurrentUsePPSSHAPF.Item("SHA14")
                Me.lbSHA14.Text = Me.CurrentUsePPSSHAPF.Item("SHA15")
                stlMessage.Text = "已找到一筆排程資料!"
                btnSaveWeight.Focus()
            Else
                Me.lbSHA12.Text = "(未知)"
                Me.lbSHA13.Text = "(未知)"
                Me.lbSHA6.Text = "(未知)"
                Me.lbSHA14.Text = "(未知)"
                stlMessage.Text = "未找到任何排程資料!"
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btSteelTapeNumber_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btSteelTapeNumber.GotFocus, btSteelTapeNumberSubNumber.GotFocus
        CType(sender, TextBox).BackColor = Color.Yellow
    End Sub

    Private Sub btSteelTapeNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btSteelTapeNumber.LostFocus, btSteelTapeNumberSubNumber.LostFocus
        CType(sender, TextBox).BackColor = Color.White
    End Sub


    Private Sub btSteelTapeNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btSteelTapeNumberSubNumber.KeyDown, btSteelTapeNumber.KeyDown
        If e.KeyData = Keys.Enter Then
            Call btnSearch_Click(btnSearch, Nothing)
            btnSaveWeight.Focus()
        End If
    End Sub

    Private Sub btnSaveWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveWeight.Click
        If btnSaveWeight.Enabled = False Then
            Exit Sub
        End If
        If CType(tbDeviceWeight.Text, Integer) < 5 AndAlso MsgBox("重量小於5是否確定儲存?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        If String.IsNullOrEmpty(btSteelTapeNumber.Text) OrElse btSteelTapeNumber.Text.Trim = "" Then
            MsgBox("鋼捲編號不可為空白!")
            Exit Sub
        End If
        Call btnSearch_Click(btnSearch, Nothing)
        'btnSaveWeight.Enabled = False OrElse tbDeviceWeight.Enabled
        Dim SetCoilNumber As String = btSteelTapeNumber.Text.Trim.ToUpper.Replace("'", "").Replace("""", "")
        Dim SetCoilSubNumber As String = btSteelTapeNumberSubNumber.Text.Trim.ToUpper.Replace("'", "").Replace("""", "")
        Dim SetSaveTime As DateTime = Me.WebServerNowTime.Value
        Dim SetWeight As Integer = CType(tbDeviceWeight.Text, Integer)
        Dim SetSaveState As Integer = IIf(IsNothing(Me.CurrentUsePPSSHAPF), 1, 0)

        'Dim SQLServerQueryServiceAdapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.WebService, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server0SM, "STK")
        'Dim DeleteString As String = "Delete ToWeight Where CoilNumber='" & SetCoilNumber & "' AND CoilSubNumber='" & SetCoilSubNumber & "' AND SaveTime='" & Format(SetSaveTime, "yyyy/MM/dd hh:mm:ss") & "'"
        'SQLServerQueryServiceAdapter.ExecuteNonQuery(DeleteString)
        'Dim InsertInstring As String = "Insert into ToWeight (CoilNumber,CoilSubNumber,SaveTime,Weight,SaveState) Values('" & SetCoilNumber & "','" & SetCoilSubNumber & "','" & Format(SetSaveTime, "yyyy/MM/dd hh:mm:ss") & "'," & SetWeight & "," & SetSaveState & ")"
        'SQLServerQueryServiceAdapter.ExecuteNonQuery(InsertInstring)
        Dim SQLQry As String = "Select * from " & (New CompanyORMDB.PPS100LB.PPSCICPF).CDBFullAS400DBPath & " Where PPS03=" & Format(Me.WebServerNowTime.Value, "yyyy") - 1911
        Dim FindTodayOldDatas As List(Of CompanyORMDB.PPS100LB.PPSCICPF) = CompanyORMDB.PPS100LB.PPSCICPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSCICPF)(SQLQry)
        Dim SaveObject As CompanyORMDB.PPS100LB.PPSCICPF = Nothing
        If FindTodayOldDatas.Count > 0 Then
            SaveObject = FindTodayOldDatas(0)
        Else
            SaveObject = New CompanyORMDB.PPS100LB.PPSCICPF
            With SaveObject
                .PPS01 = btSteelTapeNumber.Text
                .PPS02 = btSteelTapeNumberSubNumber.Text
                .PPS03 = Format(WebServerNowTime.Value.Date, "yyyy") - 1911 & Format(WebServerNowTime.Value.Date, "MMdd")
            End With
        End If
        With SaveObject
            .PPS04 = Format(WebServerNowTime.Value, "hhmmss")
            .PPS05 = CType(tbDeviceWeight.Text, Double)
            .PPS06 = IIf(RadioButton1.Checked, 510, 610)
            .PPS07 = MaskedTextBox1.Text
        End With
        Dim SaveCount As Integer = SaveObject.CDBSave

        stlMessage.Text = SaveCount & " 筆資料儲存成功!重量=" & SaveObject.PPS05.ToString
        If Not String.IsNullOrEmpty(SetCoilSubNumber) OrElse SetCoilSubNumber.Trim.Length > 0 Then
            stlMessage.Text &= " (鋼捲編號:" & SetCoilNumber & " 分捲編號:" & SetCoilSubNumber & ")"
        Else
            stlMessage.Text &= " (鋼捲編號:" & SetCoilNumber & ")"
        End If
        If SaveCount > 0 Then
            MaskedTextBox1.Text = CType(MaskedTextBox1.Text, Integer) + 1
        End If
        btSteelTapeNumber.Text = Nothing
        btSteelTapeNumberSubNumber.Text = Nothing
        Me.lbSHA12.Text = "(未知)"
        Me.lbSHA13.Text = "(未知)"
        Me.lbSHA6.Text = "(未知)"
        Me.lbSHA14.Text = "(未知)"

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.WebServerNowTime = Me.WebServerNowTime.Value.AddSeconds(1)
        lbNowTime.Text = Format(Me.WebServerNowTime.Value, "yyyy/MM/dd hh:mm:ss")
    End Sub

    Private Sub btSteelTapeNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSteelTapeNumber.TextChanged
        If Not IsNothing(btSteelTapeNumber.Text) AndAlso btSteelTapeNumber.Text.Length >= 5 Then
            btSteelTapeNumberSubNumber.Focus()
        End If
    End Sub

    Private Sub btSteelTapeNumberSubNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btSteelTapeNumberSubNumber.TextChanged
        If Not IsNothing(btSteelTapeNumberSubNumber.Text) AndAlso btSteelTapeNumberSubNumber.Text.Length >= 5 Then
            btSteelTapeNumberSubNumber.Text = btSteelTapeNumberSubNumber.Text.Substring(0, 5)
        End If

    End Sub
End Class
