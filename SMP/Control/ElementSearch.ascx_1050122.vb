Public Partial Class ElementSearch
    Inherits System.Web.UI.UserControl

#Region "取得GridView1欄位值 方法:GridViewValue"
    ''' <summary>
    ''' 取得GridView1欄位值
    ''' </summary>
    ''' <param name="ColumnHeaderName"></param>
    ''' <param name="SoureGridViewRow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GridViewValue(ByVal SoureGridViewRow As GridViewRow, ByVal ColumnHeaderName As String) As String
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
        If Not Me.IsPostBack Then
            tbStartDate.Text = Format(Now, "yyyy/MM/dd").ToString
            tbEndDate.Text = Format(Now, "yyyy/MM/dd").ToString
        End If
    End Sub

    Dim ShowRowNumber As Integer = 0

    Private Sub GridView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PreRender
        For Each EachRow As GridViewRow In Me.GridView1.Rows
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

    Private Sub DDLStationName_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLStationName.DataBound
        Me.DDLStationName.Items.Insert(0, New ListItem("全部", "ALL"))
        Me.DDLStationName.SelectedIndex = 0
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim StartDateTime = CType(Me.tbStartDate.Text, DateTime)
        Dim EndDateTime = CType(Me.tbEndDate.Text, DateTime)
        SDSAnalysisData.SelectParameters.Item("SetStartDate").DefaultValue = Val((Val(Format(StartDateTime, "yyyy")) - 1911).ToString & Format(StartDateTime, "MMdd").ToString)
        SDSAnalysisData.SelectParameters.Item("SetEndDate").DefaultValue = Val((Val(Format(EndDateTime, "yyyy")) - 1911).ToString & Format(EndDateTime, "MMdd").ToString)
        SDSAnalysisData.SelectParameters.Item("SetStoveNumber").DefaultValue = IIf(String.IsNullOrEmpty(tbFurnaceNumber.Text), "ALL", tbFurnaceNumber.Text.Trim)
        SDSAnalysisData.SelectParameters.Item("SetKind").DefaultValue = IIf(String.IsNullOrEmpty(tbKind.Text), "ALL", tbKind.Text.Trim)
        Me.GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(sender As Object, e As EventArgs) Handles btnSearchToExcel.Click
        'Step1：讀取資料放置畫面上
        btnSearch_Click(btnSearch, e)

        'Step2：Copy
        Dim queryDataTable As DataTable = CType(SDSAnalysisData.Select(DataSourceSelectArguments.Empty), System.Data.DataView).Table

        'Step3：轉Excel
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(queryDataTable, "化學成分資料" & "_" & Format(Now, "yyyyMMddhhmmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)

    End Sub

    Protected Sub btnClearSearchCondiction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSearchCondiction.Click
        tbStartDate.Text = Format(Now, "yyyy/MM/dd").ToString
        tbEndDate.Text = Format(Now, "yyyy/MM/dd").ToString
        tbFurnaceNumber.Text = ""
        DDLStationName.SelectedIndex = 0
        Me.GridView1.DataBind()
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        ChangeGridViewCellColorForData(Me.GridView1, e.Row)
    End Sub

End Class