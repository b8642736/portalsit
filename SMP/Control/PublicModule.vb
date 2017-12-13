Module PublicModule

    Dim DBDataContext As New CompanyLINQDB.SMPDataContext

#Region "依GridViewRow變更顏色 函式:ChangeGridViewCellColorForData"
    Private Mut As New Threading.Mutex

    ''' <summary>
    ''' 依GridViewRow變更顏色
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ChangeGridViewCellColorForData(ByVal SourceGridView As GridView, ByVal GetGridViewRow As GridViewRow)
        If IsNothing(GetGridViewRow) Or IsNothing(GetGridViewRow.DataItem) Then
            Exit Sub
        End If
        If GetGridViewRow.Cells.Count > 3 AndAlso GetGridViewRow.Cells(2).Text.ToUpper.Trim.Substring(0, 1) = "E" AndAlso GetGridViewRow.Cells(3).Text.Trim = "3" Then
            GetGridViewRow.ForeColor = Drawing.Color.Blue
        Else
            GetGridViewRow.ForeColor = Drawing.Color.Black
        End If

        Mut.WaitOne()
        Dim GetDataRow As DataRowView = GetGridViewRow.DataItem
        Dim FiltNumber As Integer = 0
        If GetDataRow.Item("站別").ToString.ToUpper.Substring(0, 1) = "C" OrElse GetDataRow.Item("站別").ToString.ToUpper.Substring(0, 1) = "L" Or GetDataRow.Item("站別").ToString.ToUpper.Substring(0, 1) = "S" Then
            FiltNumber = 1
        Else
            FiltNumber = CType(GetDataRow.Item("序號"), Integer)
        End If
        Dim JudgeDatas As List(Of CompanyLINQDB.製程判定) = (From A In DBDataContext.製程判定 Where A.鋼種 = GetDataRow.Item("鋼種").ToString And A.材質 = GetDataRow.Item("材質").ToString And A.站別 = GetDataRow.Item("站別").ToString And A.序號 = FiltNumber Select A).ToList
        Dim HDatarow As CompanyLINQDB.製程判定 = (From A In JudgeDatas Where A.上下限 = "H" Select A).FirstOrDefault
        Dim LDatarow As CompanyLINQDB.製程判定 = (From A In JudgeDatas Where A.上下限 = "L" Select A).FirstOrDefault
        Mut.ReleaseMutex()
        If IsNothing(HDatarow) OrElse IsNothing(LDatarow) Then
            Exit Sub
        End If
        If HDatarow.IsHaveNullValue OrElse LDatarow.IsHaveNullValue Then

            GetGridViewRow.ForeColor = Drawing.Color.Red
            Exit Sub
        End If

        Dim ColumnIndex As Integer = 0
        For Each EachField As DataControlField In SourceGridView.Columns
            Dim FieldName As String = SourceGridView.Columns.Item(ColumnIndex).HeaderText.ToUpper

            '1050122 by jiarong   convert "--" and DBNoll to "0"
            Dim item As String
            If "(DF,MD30,C,SI,MN,P,CR,NI,CU,MO,SN,PB,N2,CO,AL,TI,NB,O2,B,CA,MG,V,S,FE,AS,BI,SB,ZN,ZR,GP,TA,CANDN,NBANDTA)".Contains(FieldName) Then
                If GetDataRow.Item(FieldName).Equals("") Or GetDataRow.Item(FieldName).Equals("--") Or IsDBNull(GetDataRow.Item(FieldName)) Then
                    item = "0"
                Else
                    item = GetDataRow.Item(FieldName)
                End If
            End If


            Select Case True
                Case FieldName = "DF"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.DF, LDatarow.DF)
                Case FieldName = "MD30"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.MD30, LDatarow.MD30)
                Case FieldName = "C"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.C, LDatarow.C)
                Case FieldName = "SI"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Si, LDatarow.Si)
                Case FieldName = "MN"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Mn, LDatarow.Mn)
                Case FieldName = "P"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.P, LDatarow.P)
                Case FieldName = "CR"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Cr, LDatarow.Cr)
                Case FieldName = "NI"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Ni, LDatarow.Ni)
                Case FieldName = "CU"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Cu, LDatarow.Cu)
                Case FieldName = "MO"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Mo, LDatarow.Mo)
                Case FieldName = "SN"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Sn, LDatarow.Sn)
                Case FieldName = "PB"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Pb, LDatarow.Pb)
                Case FieldName = "N2"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.N2, LDatarow.N2)
                    If item = "0.000" Or item.Equals("0") Then
                        GetGridViewRow.Cells(ColumnIndex).ForeColor = Drawing.Color.Red
                    End If
                Case FieldName = "CO"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Co, LDatarow.Co)
                Case FieldName = "AL"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.AL, LDatarow.AL)
                Case FieldName = "TI"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Ti, LDatarow.Ti)
                Case FieldName = "NB"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Nb, LDatarow.Nb)
                Case FieldName = "O2"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.O2, LDatarow.O2)
                    If item = "0.000" Or item.Equals("0") Then
                        GetGridViewRow.Cells(ColumnIndex).ForeColor = Drawing.Color.Red
                    End If
                Case FieldName = "B"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.B, LDatarow.B)
                Case FieldName = "CA"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Ca, LDatarow.Ca)
                Case FieldName = "MG"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Mg, LDatarow.Mg)
                Case FieldName = "V"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.V, LDatarow.V)




                Case FieldName = "S"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.S, LDatarow.S)
                Case FieldName = "FE"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Fe, LDatarow.Fe)
                Case FieldName = "AS"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.As, LDatarow.As)
                Case FieldName = "BI"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Bi, LDatarow.Bi)
                Case FieldName = "SB"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Sb, LDatarow.Sb)
                Case FieldName = "ZN"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Zn, LDatarow.Zn)
                Case FieldName = "ZR"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Zr, LDatarow.Zr)
                Case FieldName = "GP"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.GP, LDatarow.GP)
                Case FieldName = "TA"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.Ta, LDatarow.Ta)
                Case FieldName = "CANDN"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.CAndN, LDatarow.CAndN)
                Case FieldName = "NBANDTA"
                    ChangeCellColor(GetGridViewRow.Cells(ColumnIndex), item, HDatarow.NbAndTa, LDatarow.NbAndTa)

            End Select
            ColumnIndex += 1
        Next
    End Sub

    Private Sub ChangeCellColor(ByVal SourceTableCell As TableCell, ByVal SourceFieldValue As Single, ByVal HiValue As Single, ByVal LowValue As Single)
        Dim HiCellColor = Drawing.Color.Red
        Dim LoCellColor = Drawing.Color.Red
        If SourceFieldValue > HiValue Then
            SourceTableCell.ForeColor = HiCellColor
        End If
        If SourceFieldValue < LowValue Then
            SourceTableCell.ForeColor = HiCellColor
        End If
    End Sub

#Region "當E站別與C站別材資變更時則加註解於鋼捲編號 函式:AddMarkToStoveNumberFormMaterialChanged(可刪除已廢除不用)"
    '''' <summary>
    '''' 當E站別與C站別材資變更時則加註解於鋼捲編號
    '''' </summary>
    '''' <param name="GetGridViewRow"></param>
    '''' <remarks></remarks>
    'Private Sub AddMarkToStoveNumberFormMaterialChanged(ByVal GetGridViewRow As GridViewRow)
    '    If GetGridViewRow.Cells.Count < 28 OrElse GetGridViewRow.Cells(2).Text.ToUpper.Trim.Substring(0, 1) <> "C" Then
    '        Exit Sub
    '    End If
    '    Dim StoveNumber As String = GetGridViewRow.Cells(0).Text
    '    Dim SerialNumber As String = CType(GetGridViewRow.Cells(3).Text, Integer)
    '    Dim DataDate1 As DateTime = New DateTime(CType(GetGridViewRow.Cells(18).Text.Substring(0, 2), Integer) + 1911, CType(GetGridViewRow.Cells(18).Text.Substring(2, 2), Integer), CType(GetGridViewRow.Cells(18).Text.Substring(4, 2), Integer))
    '    Dim DataDate2 As DateTime = DataDate1.AddDays(-1)
    '    Dim DataDate3 As DateTime = DataDate2.AddDays(-1)
    '    Dim DataDate11 As Integer = (DataDate1.Year - 1911).ToString & Format(DataDate1, "MMdd")
    '    Dim DataDate21 As Integer = (DataDate2.Year - 1911).ToString & Format(DataDate2, "MMdd")
    '    Dim DataDate31 As Integer = (DataDate3.Year - 1911).ToString & Format(DataDate3, "MMdd")
    '    Dim SQLString As String = "Select * From 分析資料 Where 爐號='" & StoveNumber & "' and 站別 Like'L%' and 序號=" & SerialNumber & " and (日期=" & DataDate11 & " OR 日期=" & DataDate21 & " OR 日期=" & DataDate31 & ")"
    '    Dim ConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("SMP.My.MySettings.DefaultDBConnect").ConnectionString
    '    Dim SqlCommand As New SqlClient.SqlCommand(SQLString, New SqlClient.SqlConnection(ConnectionString))
    '    SqlCommand.Connection.Open()
    '    Dim SqlReader As SqlClient.SqlDataReader = SqlCommand.ExecuteReader
    '    Do While SqlReader.Read
    '        If GetGridViewRow.Cells(28).Text.Trim.Replace("&nbsp;", "") <> SqlReader.Item("材質").ToString.Trim Then
    '            'GetGridViewRow.Cells(1).ForeColor = Drawing.Color.Green
    '            GetGridViewRow.Cells(0).Text &= vbNewLine & "L站材質:" & SqlReader.Item("材質").ToString.Trim
    '            SqlCommand.Connection.Close()
    '            Exit Sub
    '        End If
    '    Loop
    '    SqlCommand.Connection.Close()
    'End Sub
#End Region


#End Region

End Module
