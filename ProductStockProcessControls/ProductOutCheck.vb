Public Class ProductOutCheck

#Region "核定資料正確性並加入鋼捲出庫名單 函式:CheckDataAndAddToCheckOutList"
    ''' <summary>
    ''' 核定資料正確性並加入鋼捲出庫名單
    ''' </summary>
    ''' <param name="SourceCoilNumber"></param>
    ''' <param name="SourceCarNumber"></param>
    ''' <remarks></remarks>
    Private Sub CheckDataAndAddToCheckOutList(ByVal SourceCoilNumber As String, ByVal SourceCarNumber As String)
        ToolStripStatusLabel2.Text &= "資料查詢中請稍後.....!"
        If String.IsNullOrEmpty(SourceCarNumber) Then
            ToolStripStatusLabel2.Text = "車號不可為空白"
            Exit Sub
        End If
        SourceCoilNumber = SourceCoilNumber.Trim.Replace("-", Nothing)
        SourceCarNumber = SourceCarNumber.Trim
        'If System.Text.RegularExpressions.Regex.Match(SourceCarNumber, "\S+-\S+").Success = False Then
        '    ToolStripStatusLabel2.Text = "車號(" & SourceCarNumber & ")格式不正確!"
        '    Exit Sub
        'End If
        'Dim GetCoilsTemp As List(Of SL2BOLPF) = SL2BOLPF.CDBSelect(Of SL2BOLPF)("Select * From @#SLS300LB.SL2BOLPF Where BOL16||BOL17 = '" & SourceCoilNumber & "'")
        Dim TempObj As New SL2BOLPF
        Dim SQLString As String = "Select * From @#" & TempObj.CDBLibraryName & "." & TempObj.CDBFileName & " Where  BOL01>='970101' AND BOL16 ='" & SourceCoilNumber.Substring(0, 5) & "' "
        If SourceCoilNumber.Length > 5 Then
            SQLString &= " AND BOL17='" & SourceCoilNumber.Substring(5, SourceCoilNumber.Length - 5) & "'"
        End If
        Dim GetCoils As List(Of SL2BOLPF) = SL2BOLPF.CDBSelect(Of SL2BOLPF)(SQLString)

        'Dim GetCoilsTemp As List(Of SL2BOLPF) = SL2BOLPF.CDBSelect(Of SL2BOLPF)(SQLString)

        'Dim GetCoils As New List(Of SL2BOLPF)
        'For Each EachItem As SL2BOLPF In GetCoilsTemp   '篩選符合條件之資料
        '    If EachItem.IsCanOutFactoryNow Then
        '        GetCoils.Add(EachItem)
        '    End If
        'Next
        ToolStripStatusLabel2.Text = Nothing
        Select Case True
            Case GetCoils.Count = 0
                ToolStripStatusLabel2.Text &= "查無此筆鋼捲:" & SourceCoilNumber
                Exit Sub
            Case GetCoils.Count > 1
                ToolStripStatusLabel2.Text &= "注意:此筆鋼捲(" & SourceCoilNumber & ")有" & GetCoils.Count & "筆資料,無法判定輸入!"
                Exit Sub
            Case IsHaveSameDataInCheckOutList(GetCoils(0))
                ToolStripStatusLabel2.Text &= "此筆鋼捲:" & SourceCoilNumber & " 請勿重覆加入清單!"
                Exit Sub
        End Select
        Dim InsertItem As SL2BOLPF = GetCoils(0)
        If InsertItem.IsCanOutFactoryNow = False Then
            ToolStripStatusLabel2.Text = InsertItem.CanNotOutFactoryNowReason
            Exit Sub
        End If
        Dim NowTime As DateTime = WebServerNowTime
        InsertItem.CarNumber = SourceCarNumber
        InsertItem.BOL04 = Format(NowTime, "yyyy") - 1911 & Format(NowTime, "MMdd")
        If InsertItem.CDBSave > 0 Then
            Me.bsInput.Add(InsertItem)
        End If
        ToolStripStatusLabel2.Text &= " OK!"
    End Sub

    Private Function IsHaveSameDataInCheckOutList(ByVal SourceData As SL2BOLPF) As Boolean
        For Each EachItem As SL2BOLPF In Me.bsInput.List
            If EachItem.BOL02 = SourceData.BOL02 And EachItem.BOL16 = SourceData.BOL16 And EachItem.BOL17 = SourceData.BOL17 Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region
#Region "查詢出貨產品 函式:SearchProduct"
    ''' <summary>
    ''' 查詢出貨產品
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SearchProduct()
        ToolStripStatusLabel2.Text = "資料查詢中請稍後.....!"
        Dim TempObj As New SL2BOLPF
        Dim SQLString As String = "Select * From @#" & TempObj.CDBLibraryName & "." & TempObj.CDBFileName & " Where  BOL01>='970101'" ' AND BOL16 ='" & SourceCoilNumber.Substring(0, 5) & "' "
        If Not String.IsNullOrEmpty(TextBox3.Text) > 0 AndAlso TextBox3.Text.Trim.Length > 0 Then
            SQLString &= " AND BOL02 like '%" & TextBox3.Text & "'"
        End If
        If DateTimePicker1.Checked Then
            SQLString &= " AND BOL01='" & Format(DateTimePicker1.Value, "yyyy") - 1911 & Format(DateTimePicker1.Value, "MMdd") & "'"
        End If
        If Not String.IsNullOrEmpty(TextBox4.Text) > 0 AndAlso TextBox4.Text.Trim.Length > 0 Then
            SQLString &= " AND BOL20 LIKE '%" & TextBox4.Text.Trim & "%___'"
        End If
        If Not String.IsNullOrEmpty(TextBox5.Text) > 0 AndAlso TextBox5.Text.Trim.Length > 0 Then
            SQLString &= " AND BOL16||BOL17 like '" & TextBox5.Text & "%'"
        End If
        If DateTimePicker2.Checked Then
            Dim StartDate As String = Format(DateTimePicker2.Value, "yyyy") - 1911 & Format(DateTimePicker2.Value, "MMdd")
            Dim EndDate As String = Format(DateTimePicker3.Value, "yyyy") - 1911 & Format(DateTimePicker3.Value, "MMdd")
            SQLString &= " AND BOL04>='" & StartDate & "' AND BOL04<='" & EndDate & "' "
        End If


        'If SourceCoilNumber.Length > 5 Then
        '    SQLString &= " AND BOL17='" & SourceCoilNumber.Substring(5, SourceCoilNumber.Length - 5) & "'"
        'End If
        Dim SearchResult As List(Of SL2BOLPF) = SL2BOLPF.CDBSelect(Of SL2BOLPF)(SQLString)
        ToolStripStatusLabel2.Text = "合計查詢" & SearchResult.Count & "資料"
        Me.bsSearchResult.DataSource = SearchResult
    End Sub
#End Region
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


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        WebServerNowTime = WebServerNowTime.Value.AddSeconds(0.5)
        Label3.Text = Format(WebServerNowTime, "yyyy/MM/dd hh:mm:ss")
    End Sub

    Private Sub tsbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete.Click
        If MsgBox("是否確定要刪除登入鋼捲?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim DeleteObject As SL2BOLPF = Me.bsInput.Current
        If Not IsNothing(DeleteObject) Then
            DeleteObject.CarNumber = Nothing
            Dim DeleteCount As Integer = DeleteObject.CDBSave
            If DeleteCount > 0 Then
                Me.bsInput.RemoveCurrent()
            End If
            ToolStripStatusLabel2.Text = "已成功刪除" & DeleteCount & "筆資料"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged, TextBox2.TextChanged
        Dim SourceControl As TextBox = CType(sender, TextBox)
        SourceControl.Text = SourceControl.Text.Trim.ToUpper
        'Select Case True
        '    Case SourceControl Is TextBox2
        '        SourceControl.Text = SourceControl.Text.PadLeft(7).Substring(0, 7)
        '    Case SourceControl Is TextBox1
        '        SourceControl.Text = SourceControl.Text.Replace("-", Nothing)
        '        SourceControl.Text = SourceControl.Text.PadLeft(10).Substring(0, 10)
        'End Select
        SourceControl.SelectionStart = SourceControl.Text.Length
        btnAddCoil.Enabled = Not String.IsNullOrEmpty(TextBox1.Text.Trim) AndAlso TextBox2.Text.Trim.Length >= 5
    End Sub

    Private Sub ProductOutCheck_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.SerialPortEx1.IsOpen = False Then
            Try
                Me.SerialPortEx1.OpenAndSetContainerControl(Me)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub SerialPortEx1_DataReceivFinishedEx1(ByVal Sender As System.IO.Ports.SerialPort, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs, ByVal ReceiveData As String) Handles SerialPortEx1.DataReceivFinishedEx
        Me.TextBox2.Text = ReceiveData
        If TextBox1.Enabled Then
            CheckDataAndAddToCheckOutList(TextBox2.Text, TextBox1.Text)
        End If
    End Sub

    Private Sub btnAddCoil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCoil.Click
        CheckDataAndAddToCheckOutList(TextBox2.Text, TextBox1.Text)
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchProduct()
    End Sub

    Private Sub btnClearSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSearch.Click
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
        TextBox5.Text = Nothing
        DateTimePicker1.Checked = False
        DateTimePicker2.Checked = False
    End Sub

    Private Sub bsSearchResult_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsSearchResult.CurrentChanged
        Dim CurrentObject As SL2BOLPF = Me.bsSearchResult.Current
        If IsNothing(CurrentObject) OrElse CurrentObject.IsAlreadyOutOfFactory = False Then
            tsbDelete2.Enabled = False
        Else
            Try
                tsbDelete2.Enabled = True And WebServerNowTime.Value.Date <= (New CompanyORMDB.AS400DateConverter(CurrentObject.BOL04)).DateValue.Date.AddDays(7)
            Catch ex As Exception
                tsbDelete2.Enabled = False
            End Try
        End If
    End Sub

    Private Sub tsbDelete2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDelete2.Click
        If MsgBox("是否確定要刪除登入鋼捲?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim DeleteObject As SL2BOLPF = Me.bsSearchResult.Current
        If Not IsNothing(DeleteObject) Then
            DeleteObject.CarNumber = Nothing
            Dim DeleteCount As Integer = DeleteObject.CDBSave
            ToolStripStatusLabel2.Text = "已成功刪除" & DeleteCount & "筆資料"
            Me.DataGridView2.Refresh()
        End If

    End Sub

    Private Sub bsInput_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsInput.CurrentChanged
        tsbDelete.Enabled = Not IsNothing(Me.bsInput.Current)
    End Sub

End Class
