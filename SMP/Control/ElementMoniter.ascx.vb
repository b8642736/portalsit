Public Partial Class ElementMoniter
    Inherits System.Web.UI.UserControl

    Dim DBDataContext As New CompanyLINQDB.SMPDataContext

#Region "經使用者確認之資料 屬性:UserOverLookDataKey"
    ''' <summary>
    ''' 經使用者確認之資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UserOverLookDataKey() As String
        Get
            Return Me.ViewState("_UserOverLookDataKey")
        End Get
        Set(ByVal value As String)
            Me.ViewState("_UserOverLookDataKey") = value
        End Set
    End Property

#End Region
#Region "轉換GridViewRow日期時間值成一字串 法方:ConvertGridViewRowDataTimeToString"
    ''' <summary>
    ''' 轉換GridViewRow所有值成一字串
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertGridViewRowDataTimeToString(ByVal SourceGridViewRow As GridViewRow) As String
        Dim DateIndex As Integer = -1
        Dim TimeIndex As Integer = -1
        Dim ColumnIndex As Integer = 0
        For Each EachItem As DataControlField In Me.GridView1.Columns
            If EachItem.HeaderText = "日期" Then
                DateIndex = ColumnIndex
            End If
            If EachItem.HeaderText = "時間" Then
                TimeIndex = ColumnIndex
            End If
            ColumnIndex += 1
        Next
        Dim ReturnValue As String = SourceGridViewRow.Cells(DateIndex).Text & SourceGridViewRow.Cells(TimeIndex).Text
        'For Each EachItem As TableCell In SourceGridViewRow.Cells
        '    ReturnValue &= EachItem.Text.Trim
        'Next
        Return ReturnValue
    End Function

#End Region
#Region "更新第一筆資料之取樣品質  函式:UpdateFirstDataSampleStatus"
    ''' <summary>
    ''' 更新第一筆資料之取樣品質
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateFirstDataSampleStatus()
        If GridView1.Rows.Count <= 0 Then
            Exit Sub
        End If
        Dim DBDataContext As New CompanyLINQDB.SMPDataContext
        Dim StoveNumber As String = GridViewValue(GridView1.Rows(0), "爐號")     '爐號
        Dim DateValue As Integer = GridViewValue(GridView1.Rows(0), "日期")     '日期
        Dim TimeValue As String = GridViewValue(GridView1.Rows(0), "時間")      '時間
        Dim FindDatas As List(Of CompanyLINQDB.取樣品質) = (From A In DBDataContext.取樣品質 Where A.爐號 = StoveNumber And A.日期 = DateValue And A.時間 = TimeValue And A.IsDeleted = False Select A).ToList
        If FindDatas.Count = 0 Then
            lbFirstSampleState.Text = "未知(無資料)!"
            Exit Sub
        End If
        lbFirstSampleState.Text = ""
        For Each EachItem As CompanyLINQDB.取樣品質 In FindDatas
            lbFirstSampleState.Text &= IIf(lbFirstSampleState.Text = "", "", ",") & EachItem.取樣品質說明
        Next
        Me.UpdatePanel3.Update()
    End Sub
#End Region
#Region "取得幅射背景值異常字串 方法:GetRadiationRareString"
    ''' <summary>
    ''' 取得幅射背景值異常字串
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetRadiationRareString() As String
        Try
            Static ReturnValue As String
            ReturnValue = ""
            For Each EachItem As GridViewRow In Me.GridView1.Rows
                Dim Value As Single = Val(GridViewValue(EachItem, "輻射"))
                If Value <= 0 Then
                    Continue For
                End If
                If Value >= 0.15 Then
                    ReturnValue &= "爐號:" & GridViewValue(EachItem, "爐號") & " 幅射(" & Value & ") 異常!"
                End If
            Next
            Return ReturnValue.ToString
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function
#End Region
#Region "取得GridView1欄位值 方法:GridViewValue"
    ''' <summary>
    ''' 取得GridView1欄位值
    ''' </summary>
    ''' <param name="ColumnHeaderName"></param>
    ''' <param name="SoureGridViewRow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GridViewValue(ByVal SoureGridViewRow As GridViewRow, ByVal ColumnHeaderName As String) As String
        'If IsNothing(SoureGridViewRow) Then
        '    Return String.Empty
        'End If
        'Dim FieldColumnIndex As Integer = -1
        'For Each EachControlField As DataControlField In Me.GridView1.Columns
        '    If EachControlField.HeaderText.Trim = ColumnHeaderName.Trim Then
        '        FieldColumnIndex = Me.GridView1.Columns.IndexOf(EachControlField)
        '    End If
        'Next
        'If FieldColumnIndex < 0 Then
        '    Return String.Empty
        'End If
        'Return SoureGridViewRow.Cells(FieldColumnIndex).Text
        Dim FindCell As TableCell = GridViewCell(SoureGridViewRow, ColumnHeaderName)
        If IsNothing(FindCell) Then
            Return String.Empty
        End If
        Return FindCell.Text
    End Function
#End Region
#Region "取得GridView1欄位控制項 方法:GridViewValue"
    ''' <summary>
    ''' 取得GridView1欄位控制項
    ''' </summary>
    ''' <param name="ColumnHeaderName"></param>
    ''' <param name="SoureGridViewRow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GridViewCell(ByVal SoureGridViewRow As GridViewRow, ByVal ColumnHeaderName As String) As TableCell
        If IsNothing(SoureGridViewRow) Then
            Return Nothing
        End If
        Dim FieldColumnIndex As Integer = -1
        For Each EachControlField As DataControlField In Me.GridView1.Columns
            If EachControlField.HeaderText.Trim = ColumnHeaderName.Trim Then
                FieldColumnIndex = Me.GridView1.Columns.IndexOf(EachControlField)
            End If
        Next
        If FieldColumnIndex < 0 Then
            Return Nothing
        End If

        Return SoureGridViewRow.Cells(FieldColumnIndex)
    End Function
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.GridView1.DataBind()
            UpdateFirstDataSampleStatus()
        End If
    End Sub

    Private Sub GridView1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Load
        Label1.Text = Now.ToString
    End Sub

    Private Sub GridView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PreRender
        For Each EachRow As GridViewRow In Me.GridView1.Rows
            If EachRow.RowIndex = 0 Then
                EachRow.Height = 70
            End If

            'If Not String.IsNullOrEmpty(EachRow.Cells(28).Text.Trim) Then
            '    Select Case True
            '        Case EachRow.Cells(28).Text.Length = 2 AndAlso Left(EachRow.Cells(28).Text, 1).ToUpper = "T"
            '            EachRow.Cells(1).Text = Left(EachRow.Cells(28).Text, 2) & EachRow.Cells(1).Text
            '        Case EachRow.Cells(28).Text.Length = 3 And IsNumeric(Right(EachRow.Cells(28).Text, 1)) AndAlso Left(EachRow.Cells(28).Text, 1).ToUpper = "T"
            '            EachRow.Cells(1).Text = Left(EachRow.Cells(28).Text, 2) & EachRow.Cells(1).Text & "-" & Right(EachRow.Cells(28).Text, 1)
            '        Case EachRow.Cells(28).Text.Length = 3 And Not IsNumeric(Right(EachRow.Cells(28).Text, 1)) AndAlso Left(EachRow.Cells(28).Text, 1).ToUpper = "T"
            '            EachRow.Cells(1).Text = Left(EachRow.Cells(28).Text, 2) & EachRow.Cells(1).Text & Right(EachRow.Cells(28).Text, 1)
            '        Case EachRow.Cells(28).Text.Length > 0 And IsNumeric(Right(EachRow.Cells(28).Text, 1))
            '            EachRow.Cells(1).Text = EachRow.Cells(1).Text & "-" & EachRow.Cells(28).Text
            '    End Select
            'End If
            'If EachRow.Cells(2).Text.Trim <> "L1" AndAlso EachRow.Cells(2).Text.Trim <> "C1" Then
            '    EachRow.Cells(4).Text = ""
            '    EachRow.Cells(5).Text = ""
            'End If
            'If EachRow.Cells(17).Text.Trim = "0.000" Then
            '    EachRow.Cells(17).Text = "--"
            'End If
            'If EachRow.Cells(24).Text.Trim = "0.000" Then
            '    EachRow.Cells(24).Text = "--"
            'End If

            Dim GetMaterialCell As TableCell = GridViewCell(EachRow, "材質")
            Dim SteelKindCell As TableCell = GridViewCell(EachRow, "鋼種")
            Dim StationKind As String = GridViewValue(EachRow, "站別")
            Dim ElementN2Cell As TableCell = GridViewCell(EachRow, "N2")
            Dim ElementO2Cell As TableCell = GridViewCell(EachRow, "O2")

            If Not String.IsNullOrEmpty(GetMaterialCell.Text.Trim) Then
                Select Case True
                    Case GetMaterialCell.Text.Length = 2 AndAlso Left(GetMaterialCell.Text, 1).ToUpper = "T"
                        SteelKindCell.Text = Left(GetMaterialCell.Text, 2) & SteelKindCell.Text
                    Case GetMaterialCell.Text.Length = 3 And IsNumeric(Right(GetMaterialCell.Text, 1)) AndAlso Left(GetMaterialCell.Text, 1).ToUpper = "T"
                        SteelKindCell.Text = Left(GetMaterialCell.Text, 2) & SteelKindCell.Text & "-" & Right(GetMaterialCell.Text, 1)
                    Case GetMaterialCell.Text.Length = 3 And Not IsNumeric(Right(GetMaterialCell.Text, 1)) AndAlso Left(GetMaterialCell.Text, 1).ToUpper = "T"
                        SteelKindCell.Text = Left(GetMaterialCell.Text, 2) & SteelKindCell.Text & Right(GetMaterialCell.Text, 1)

                        '1020116 by renhsin
                        'Case GetMaterialCell.Text.Length > 0 And IsNumeric(Right(GetMaterialCell.Text, 1))
                        '    SteelKindCell.Text = SteelKindCell.Text & "-" & GetMaterialCell.Text
                    Case GetMaterialCell.Text.Length > 0
                        If GetMaterialCell.Text <> "" AndAlso GetMaterialCell.Text <> "&nbsp;" Then
                            SteelKindCell.Text = SteelKindCell.Text & "-" & GetMaterialCell.Text
                        Else
                            SteelKindCell.Text = SteelKindCell.Text
                        End If
                End Select
            End If


            If Not String.IsNullOrEmpty(StationKind) AndAlso Not {"L", "C", "S"}.Contains(Left(Trim(StationKind), 1)) Then
                GridViewCell(EachRow, "DF").Text = ""
                GridViewCell(EachRow, "MD30").Text = ""
            End If

            If ElementN2Cell.Text.Trim = "0.000" Then
                ElementN2Cell.Text = "--"
            End If
            If ElementO2Cell.Text.Trim = "0.000" Then
                ElementO2Cell.Text = "--"
            End If

            '1020115 by renhsin,INGOT=Y 且站別為C1 > 站別:更改為G1
            If GridViewCell(EachRow, "INGOT").Text = "Y" AndAlso GridViewCell(EachRow, "站別").Text = "C1" Then
                GridViewCell(EachRow, "站別").Text = "G1"
            End If
        Next

    End Sub


    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Private Sub labPCConnectMsg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles labPCConnectMsg.Load
        Dim DisConnPCs As List(Of MonitorClientPCStatusDisplayItem) = (From A In MonitorClientPCStatusDisplayItem.Search Where A.IsNetworkNormal = False Select A).ToList
        Static Message As String
        Message = ""
        Message &= GetRadiationRareString()
        If DisConnPCs.Count > 0 Then
            Me.labPCConnectMsg.BackColor = Drawing.Color.Pink
            Message &= "有" & DisConnPCs.Count & "台電腦離線中:"
            For Each EachItem As MonitorClientPCStatusDisplayItem In DisConnPCs
                Select Case True
                    Case Not String.IsNullOrEmpty(EachItem.Memo1) AndAlso EachItem.Memo1.Trim.Length > 0
                        Message &= "(" & EachItem.Memo1.Trim & ")"
                    Case Not String.IsNullOrEmpty(EachItem.ClentPCName) AndAlso EachItem.ClentPCName.Trim.Length > 0
                        Message &= "(" & EachItem.ClentPCName.Trim & ")"
                    Case Else
                        Message &= "(" & EachItem.ClientPCIP.Trim & ")"
                End Select
            Next
        Else
            Me.labPCConnectMsg.BackColor = System.Drawing.Color.Transparent
            Message &= "所有電腦上線中!"
        End If
        Message &= "更新時間:" & Now.ToString

        Me.labPCConnectMsg.Text = Message.ToString
    End Sub

    'Protected Sub LDSAnalysisData_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LDSAnalysisData.Selecting
    '    Dim Result As IQueryable(Of CompanyLINQDB.分析資料) = (From A In DBDataContext.分析資料 Select A)
    '    Dim IsAllSelect As Boolean = True
    '    For Each EachItem As ListItem In CheckBoxList1.Items
    '        IsAllSelect = (IsAllSelect = EachItem.Selected)
    '    Next
    '    If IsAllSelect = False Then
    '        For Each EachItem As ListItem In CheckBoxList1.Items
    '            Dim CurrentListItem As ListItem = EachItem
    '            Result = IIf(CurrentListItem.Selected = False, Result, From A In Result Where A.站別 = CurrentListItem.Value Select A)
    '        Next
    '    End If
    '    e.Result = (From A In Result Select A.爐號, A.鋼種, A.材質, A.站別, A.序號, A.判定, A.日期, A.時間, A.操作員, A.DF, A.MD30, A.C, A.Si, A.Mn, A.P, A.S, A.Cr, A.Ni, A.Cu, A.Mo, A.Co, A.AL, A.Sn, A.Pb, A.Ti, A.Nb, A.V, A.W, O2 = A.O1, N2 = A.N1, A.H2, A.B, A.Ca, A.Mg, A.Fe, A.分光儀編號).Take(8)
    'End Sub

    Protected Sub CheckBoxList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBoxList1.SelectedIndexChanged
        Dim IsAllSelect As Boolean = True
        For Each EachItem As ListItem In CheckBoxList1.Items
            IsAllSelect = (IsAllSelect And EachItem.Selected)
        Next
        Me.HFSETALL.Value = IIf(IsAllSelect, "TRUE", "FALSE")
        Me.HFST1.Value = IIf(CheckBoxList1.Items(0).Selected, CheckBoxList1.Items(0).Value, "@#")
        Me.HFST2.Value = IIf(CheckBoxList1.Items(1).Selected, CheckBoxList1.Items(1).Value, "@#")
        Me.HFST3.Value = IIf(CheckBoxList1.Items(2).Selected, CheckBoxList1.Items(2).Value, "@#")
        Me.HFST4.Value = IIf(CheckBoxList1.Items(3).Selected, CheckBoxList1.Items(3).Value, "@#")
        Me.HFST5.Value = IIf(CheckBoxList1.Items(4).Selected, CheckBoxList1.Items(4).Value, "@#")
        Me.HFST6.Value = IIf(CheckBoxList1.Items(5).Selected, CheckBoxList1.Items(5).Value, "@#")

        '1020115 by renhsin,add INGOT
        Me.HFST7.Value = IIf(CheckBoxList1.Items(6).Selected, "TRUE", "FALSE")

        Me.GridView1.DataBind()
        Call btnChangeFirstBackupColor_Click(sender, Nothing)
        Me.GridView1.DataBind()
        UpdateFirstDataSampleStatus()

    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        If Me.GridView1.Rows.Count = 0 Then
            Exit Sub
        End If
        Me.SDSAnalysisData.ConnectionString = My.Settings.Item("DefaultDBConnect").ToString
        Me.GridView1.DataBind()
        If Me.GridView1.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim GetKey As String = Nothing
        For Each EachCell As TableCell In Me.GridView1.Rows(0).Cells
            GetKey &= EachCell.Text
        Next

        If Me.ViewState.Item("FirstDataKey") = GetKey OrElse IsNothing(Me.ViewState.Item("FirstDataKey")) Then
            Me.WaveSound1.Attributes("src") = Nothing
            Me.WaveSound1.Attributes("autostart") = False
        Else
            Me.WaveSound1.Attributes("src") = "Control/WindowsBalloon.wav"
            Me.WaveSound1.Attributes("autostart") = True
            UpdateFirstDataSampleStatus()
        End If
        If Me.lbFirstSampleState.Text = "未知(無資料)!" Then
            UpdateFirstDataSampleStatus()
        End If

        Me.ViewState.Item("FirstDataKey") = GetKey
    End Sub


    Protected Sub btnChangeFirstBackupColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnChangeFirstBackupColor.Click
        If GridView1.Rows.Count > 0 Then
            Me.UserOverLookDataKey = ConvertGridViewRowDataTimeToString(GridView1.Rows(0))
        Else
            Me.UserOverLookDataKey = Nothing
        End If
        GridView1.DataBind()
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowIndex = 0 Then
            If IsNothing(UserOverLookDataKey) OrElse UserOverLookDataKey <> ConvertGridViewRowDataTimeToString(e.Row) Then
                e.Row.BackColor = Drawing.Color.Yellow
            Else
                e.Row.BackColor = Drawing.Color.White
            End If
        End If
        ChangeGridViewCellColorForData(Me.GridView1, e.Row)
    End Sub

    Protected Sub SDSAnalysisData_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SDSAnalysisData.Selecting
        Me.Label2.Text = "SelectingTime:" & Now.ToString
    End Sub


End Class