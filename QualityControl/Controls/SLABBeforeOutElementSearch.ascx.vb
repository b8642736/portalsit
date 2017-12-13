Public Partial Class SLABBeforeOutElementSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="WhereAfterString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal WhereAfterString As String, ByVal DFAndMD30Range As String) As QualityControlDataSet.SLABBeforeOutElementSearchDataTableDataTable
        Dim SMSSGAPFQryString As String = "Select A.* From " & (New SMS100LB.SMSSGAPF).CDBFullAS400DBPath & " A LEFT JOIN " & (New PPS100LB.PPSQCAPF).CDBFullAS400DBPath & " B ON A.SGA01=B.QCA01 " & IIf(IsNothing(WhereAfterString), Nothing, " Where " & WhereAfterString)
        Dim PPSQCAPFQryString As String = "Select B.* From " & (New SMS100LB.SMSSGAPF).CDBFullAS400DBPath & " A LEFT JOIN " & (New PPS100LB.PPSQCAPF).CDBFullAS400DBPath & " B ON A.SGA01=B.QCA01 " & IIf(IsNothing(WhereAfterString), Nothing, " Where " & WhereAfterString)
        Dim PPSQCAPFQryCacheData As List(Of PPS100LB.PPSQCAPF) = PPS100LB.PPSQCAPF.CDBSelect(Of PPS100LB.PPSQCAPF)(PPSQCAPFQryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim PPSQCAPFSearchResult As List(Of SMS100LB.SMSSGAPF) = SMS100LB.SMSSGAPF.CDBSelect(Of SMS100LB.SMSSGAPF)(SMSSGAPFQryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchResult As New List(Of SMS100LB.SMSSGAPF) : SearchResult.AddRange(PPSQCAPFSearchResult)
        If Not IsNothing(DFAndMD30Range) AndAlso DFAndMD30Range.Trim.Length > 0 Then
            For Each EachItem As String In DFAndMD30Range.Split(",")
                Dim EachItemValue As Single = CType(EachItem.Replace("<=", Nothing).Replace(">=", Nothing).Replace("|", Nothing).Replace("&", Nothing).Replace("MD", Nothing).Replace("DF", Nothing), Single)

                Try
                    Select Case True
                        Case EachItem.Length >= 4 AndAlso EachItem.Substring(3, 2) = ">="
                            Select Case True
                                Case EachItem.Substring(0, 1) = "&" AndAlso EachItem.Substring(1, 2) = "MD"
                                    SearchResult = (From A In SearchResult Where A.AboutPPSQCAPF(PPSQCAPFQryCacheData).MD30 >= EachItemValue Select A).ToList
                                Case EachItem.Substring(0, 1) = "&" AndAlso EachItem.Substring(1, 2) = "DF"
                                    SearchResult = (From A In SearchResult Where A.AboutPPSQCAPF(PPSQCAPFQryCacheData).DF >= EachItemValue Select A).ToList
                                Case EachItem.Substring(0, 1) = "|" AndAlso EachItem.Substring(1, 2) = "MD"
                                    SearchResult.AddRange((From A In PPSQCAPFSearchResult Where Not SearchResult.Contains(A) And A.AboutPPSQCAPF(PPSQCAPFQryCacheData).MD30 >= EachItemValue Select A).ToList)
                                Case EachItem.Substring(0, 1) = "|" AndAlso EachItem.Substring(1, 2) = "DF"
                                    SearchResult.AddRange((From A In PPSQCAPFSearchResult Where Not SearchResult.Contains(A) And A.AboutPPSQCAPF(PPSQCAPFQryCacheData).DF >= EachItemValue Select A).ToList)
                            End Select
                        Case EachItem.Length >= 4 AndAlso EachItem.Substring(3, 2) = "<="
                            Select Case True
                                Case EachItem.Substring(0, 1) = "&" AndAlso EachItem.Substring(1, 2) = "MD"
                                    SearchResult = (From A In SearchResult Where A.AboutPPSQCAPF(PPSQCAPFQryCacheData).MD30 <= EachItemValue Select A).ToList
                                Case EachItem.Substring(0, 1) = "&" AndAlso EachItem.Substring(1, 2) = "DF"
                                    SearchResult = (From A In SearchResult Where A.AboutPPSQCAPF(PPSQCAPFQryCacheData).DF <= EachItemValue Select A).ToList
                                Case EachItem.Substring(0, 1) = "|" AndAlso EachItem.Substring(1, 2) = "MD"
                                    SearchResult.AddRange((From A In PPSQCAPFSearchResult Where Not SearchResult.Contains(A) And A.AboutPPSQCAPF(PPSQCAPFQryCacheData).MD30 <= EachItemValue Select A).ToList)
                                Case EachItem.Substring(0, 1) = "|" AndAlso EachItem.Substring(1, 2) = "DF"
                                    SearchResult.AddRange((From A In PPSQCAPFSearchResult Where Not SearchResult.Contains(A) And A.AboutPPSQCAPF(PPSQCAPFQryCacheData).DF <= EachItemValue Select A).ToList)
                            End Select
                    End Select
                Catch ex As Exception

                End Try
            Next
        End If
        Dim ReturnValue As New QualityControlDataSet.SLABBeforeOutElementSearchDataTableDataTable
        Dim DataRowCount As Integer = 0
        For Each EachSMSSGAPF As SMS100LB.SMSSGAPF In (From A In SearchResult Select A Order By A.SGA33, A.SLABNumber, A.SGA05, A.SGA06).ToList
            Dim EachSMSSGAPFTemp As SMS100LB.SMSSGAPF = EachSMSSGAPF
            Dim AddItem As QualityControlDataSet.SLABBeforeOutElementSearchDataTableRow = ReturnValue.NewRow
            DataRowCount += 1
            With AddItem
                .序號 = DataRowCount
                .鋼種 = EachSMSSGAPFTemp.SGA05
                .材質 = EachSMSSGAPFTemp.SGA06
                .批次 = EachSMSSGAPFTemp.SGA33
                .鋼胚號碼 = EachSMSSGAPFTemp.SLABNumber
                Try
                    .DF = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).DF
                    .MD30 = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).MD30
                Catch ex As Exception

                End Try
                .C = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA07
                .SI = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA08
                .MN = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA09
                .P = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA10
                .S = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA11
                .CR = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA12
                .NI = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA13
                .CU = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA14
                .MO = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA15
                .CO = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA16
                .AL = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA17
                .SN = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA18
                .PB = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA19
                .TI = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA20
                .NB = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA21
                .V = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA22
                .W = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA23
                .O2 = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA24
                .N2 = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA25
                .H2 = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA26
                .B = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA27
                .Ca = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA28 / 100
                .Mg = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA29 / 100
                .Fe = EachSMSSGAPFTemp.AboutPPSQCAPF(PPSQCAPFQryCacheData).QCA30
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        Return ReturnValue
    End Function
#End Region

#Region "使用者是否已按下查詢 屬性:IsUserAlreadyPutSearch"

    Property IsUserAlreadyPutSearch() As Boolean
        Get
            If IsNothing(Me.ViewState("_IsUserAlreadyPutSearch")) Then
                Return False
            End If
            Return Me.ViewState("_IsUserAlreadyPutSearch")
        End Get
        Set(ByVal value As Boolean)
            Me.ViewState("_IsUserAlreadyPutSearch") = value
            Me.lbMessage.Visible = False
        End Set
    End Property
#End Region
#Region "Where條件產生器至傳輸控制項 方法:ControlWhereMaker"
    ''' <summary>
    ''' Where條件產生器至傳輸控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub WhereMakerToControl()
        hfControlWhereMaker.Value = Nothing
        hfDFAndMD30Range.Value = Nothing
        Dim ReturnValue As String = Nothing
        Dim SlabStatuses As String = Nothing
        For Each EachItem As ListItem In CheckBoxList1.Items
            If EachItem.Selected Then
                SlabStatuses &= IIf(IsNothing(SlabStatuses), Nothing, ",") & EachItem.Value
            End If
        Next
        If Not IsNothing(SlabStatuses) AndAlso SlabStatuses.Split(",").Count <> CheckBoxList1.Items.Count Then
            ReturnValue &= IIf(IsNothing(ReturnValue), Nothing, "  AND ") & " SGA35 IN ('" & SlabStatuses.Replace(",", "','") & "')"
        End If

        If Not String.IsNullOrEmpty(btBatchNumber.Text) AndAlso btBatchNumber.Text.Trim.Length > 0 Then
            btBatchNumber.Text = btBatchNumber.Text.Replace("'", Nothing)
            'ReturnValue &= IIf(btBatchNumber.Text.Trim.Length > 0, "  AND SGA33 IN ('" & btBatchNumber.Text.Replace(",", "','") & "')", Nothing)
            ReturnValue &= IIf(IsNothing(ReturnValue), Nothing, "  AND ") & " SGA33 IN ('" & btBatchNumber.Text.Replace(",", "','") & "')"
        End If

        If Not String.IsNullOrEmpty(tbSteelKind.Text) AndAlso tbSteelKind.Text.Trim.Length > 0 Then
            tbSteelKind.Text = tbSteelKind.Text.Replace("'", Nothing)
            ReturnValue &= IIf(IsNothing(ReturnValue), Nothing, "  AND ") & " SGA05 IN ('" & tbSteelKind.Text.Replace(",", "','") & "')"
        End If


        For Each EachItem As ListItem In ListBox1.Items
            Dim EachItemValue As String = EachItem.Value
            If EachItem.Text.Contains("MD30") Or EachItem.Text.Contains("DF") Then
                Me.hfDFAndMD30Range.Value &= IIf(String.IsNullOrEmpty(Me.hfDFAndMD30Range.Value), Nothing, ",") & EachItemValue
                Continue For
            End If
            Dim AndOrString As String = IIf(EachItemValue.Substring(0, 1) = "&", " AND ", " OR ")
            EachItemValue = EachItemValue.Replace("&", Nothing).Replace("|", Nothing)
            ReturnValue &= IIf(IsNothing(ReturnValue), Nothing, AndOrString) & EachItemValue
        Next
        Me.hfControlWhereMaker.Value = ReturnValue
    End Sub
#End Region

#Region "顯示訊息  方法:ShowMessage"
    ''' <summary>
    ''' 顯示訊息
    ''' </summary>
    ''' <param name="MessageText"></param>
    ''' <remarks></remarks>
    Private Sub ShowMessage(ByVal MessageText As String)
        Me.lbMessage.Text = MessageText
        Me.lbMessage.Visible = True
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub TextBox3_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Protected Sub btnRemove0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemove0.Click
        Me.IsUserAlreadyPutSearch = False
        Me.ListBox1.Items.Clear()
        RadioButtonList1.Enabled = ListBox1.Items.Count > 0
    End Sub

    Protected Sub btnRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemove.Click
        Me.btnRemove.Enabled = False
        Me.IsUserAlreadyPutSearch = False
        If Not IsNothing(ListBox1.SelectedItem) Then
            ListBox1.Items.Remove(ListBox1.SelectedItem)
        End If
        If ListBox1.Items.Count > 0 AndAlso ListBox1.Items(0).Value.Substring(0, 1) = "|" Then
            ListBox1.Items(0).Text = ListBox1.Items(0).Text.Replace("或", "並且")
            ListBox1.Items(0).Value = ListBox1.Items(0).Value.Replace("|", "&")
        End If
        RadioButtonList1.Enabled = ListBox1.Items.Count > 0
    End Sub

    Private Sub ListBox1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.PreRender
        If ListBox1.Items.Count = 0 Then
            RadioButtonList1.SelectedIndex = 0
            RadioButtonList1.Enabled = False
            UpdatePanel2.Update()
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        btnRemove.Enabled = Not IsNothing(ListBox1.SelectedItem)
    End Sub

    Protected Sub btnClearSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClearSearch.Click
        Me.IsUserAlreadyPutSearch = False
        Me.btBatchNumber.Text = Nothing
        Call btnRemove0_Click(btnRemove0, Nothing)
        Me.hfControlWhereMaker.Value = Nothing
        Me.hfDFAndMD30Range.Value = Nothing
    End Sub

    Protected Sub odsSearchResult_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsSearchResult.Selecting
        If Not IsUserAlreadyPutSearch Then
            e.Cancel = Not IsUserAlreadyPutSearch
            Exit Sub
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        If String.IsNullOrEmpty(btBatchNumber.Text) OrElse btBatchNumber.Text.Trim.Length = 0 Then
            ShowMessage("請勿必輸入查詢批號!")
            Exit Sub
        End If
        Me.IsUserAlreadyPutSearch = True
        WhereMakerToControl()
        Me.GridView1.DataBind()
        ShowMessage("合計查詢資料共 " & GridView1.Rows.Count & " 筆!")
    End Sub

    Protected Sub btnADD_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnADD.Click
        Me.IsUserAlreadyPutSearch = False
        Dim AddItemTextString As String = IIf(RadioButtonList1.Enabled, RadioButtonList1.SelectedItem.Text, "並且")
        Dim AddItemValueString As String = IIf(RadioButtonList1.Enabled, RadioButtonList1.SelectedItem.Value, "&")
        AddItemTextString &= DropDownList2.SelectedItem.Text & DropDownList1.SelectedItem.Text & TextBox2.Text.Replace("'", Nothing).Trim
        If DropDownList2.SelectedItem.Text.ToUpper = "CA" OrElse DropDownList2.SelectedItem.Text.ToUpper = "MG" Then
            AddItemValueString &= DropDownList2.SelectedItem.Value & "/100 " & DropDownList1.SelectedItem.Value & TextBox2.Text.Replace("'", Nothing).Trim
        Else
            AddItemValueString &= DropDownList2.SelectedItem.Value & DropDownList1.SelectedItem.Value & TextBox2.Text.Replace("'", Nothing).Trim
        End If
        ListBox1.Items.Add(New ListItem(AddItemTextString, AddItemValueString))
        RadioButtonList1.Enabled = ListBox1.Items.Count > 0
    End Sub

    Protected Sub btnSearchToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchToExcel.Click
        If String.IsNullOrEmpty(btBatchNumber.Text) OrElse btBatchNumber.Text.Trim.Length = 0 Then
            ShowMessage("請勿必輸入查詢批號!")
            Exit Sub
        End If
        Me.IsUserAlreadyPutSearch = True
        WhereMakerToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfControlWhereMaker.Value, Me.hfDFAndMD30Range.Value), "待熱軋鋼肧查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub

End Class