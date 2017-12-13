Public Class OrderProduceAssignSearch
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call InitFrom()
        End If
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call InitFrom()
    End Sub

    Private Sub InitFrom()
        Dim W_Now As Date = Now
        tbStartMonth.Text = Format(New Date(W_Now.Year, 1, 1), "yyyy/MM")
        tbEndMonth.Text = Format(W_Now, "yyyy/MM")
    End Sub

#Region "MakeQuerySQL"
    Private Sub MakeQuerySQL()
        Dim queryStartMonth As String = New AS400DateConverter(tbStartMonth.Text).TwSevenCharsTypeData
        Dim queryEndMonth As String = New AS400DateConverter(tbEndMonth.Text).TwSevenCharsTypeData
        queryStartMonth = Mid(queryStartMonth, 1, 5)
        queryEndMonth = Mid(queryEndMonth, 1, 5)

        Dim SQL1Master As New StringBuilder
        Dim SQL2Detail As New StringBuilder

        SQL1Master.Append("select * " & vbNewLine)
        SQL1Master.Append("from ( " & vbNewLine)
        SQL1Master.Append("SELECT qtn01,qtn02,qtn03,qtn04,qtn05,qtn25,(qtn12-qtn21-qtn22) S00007,qtn93,qtn29,case qtn25 when 'G' THEN 'G' ELSE 'X' END qtn25b " & vbNewLine)
        SQL1Master.Append(" " & vbNewLine)
        SQL1Master.Append("FROM SLS300LB.SL2QTNL2,SLS300LB.SL2CH2PF  " & vbNewLine)
        SQL1Master.Append(" " & vbNewLine)
        SQL1Master.Append("WHERE SUBSTR(qtn02,1,5) BETWEEN '" & queryStartMonth & "' and '" & queryEndMonth & "'  " & vbNewLine)
        SQL1Master.Append("  AND qtn04=ch201 AND ch202<>'Y' AND ch204=' ' " & vbNewLine)
        SQL1Master.Append(") v " & vbNewLine)
        SQL1Master.Append("ORDER BY qtn03,qtn04,qtn29,qtn25b,qtn01,qtn02 " & vbNewLine)


        SQL2Detail.Append("SELECT  cic10,cic11,cic13,cic14,cic17,sha08, SUM(sha17) S0001 " & vbNewLine)
        SQL2Detail.Append(" " & vbNewLine)
        SQL2Detail.Append("FROM SLS300LB.SL2CICLC,PPS100LB.PPSSHAPF  " & vbNewLine)
        SQL2Detail.Append("WHERE 1=1 " & vbNewLine)
        SQL2Detail.Append("  AND cic01=sha01 AND cic02=sha02 AND cic03=sha04  " & vbNewLine)
        SQL2Detail.Append("  AND RIGHT(cic10,8)<>'' " & vbNewLine)

        '1020906 by renhsin,排除非數字的報價單號
        SQL2Detail.Append("  AND LENGTH(TRIM(Translate(SUBSTR(cic10,4,5), '          ','0123456789')))=0 " & vbNewLine)
        SQL2Detail.Append("  AND SUBSTR(cic10,4,5)>=" & queryStartMonth & " AND SUBSTR(cic10,4,5)<=" & queryEndMonth & " " & vbNewLine)
        SQL2Detail.Append(" " & vbNewLine)
        SQL2Detail.Append("GROUP BY  cic10,cic11,cic13,cic14,cic17,sha08 " & vbNewLine)

        hfSQL1Master.Value = SQL1Master.ToString
        hfSQL2Detail.Value = SQL2Detail.ToString
        hfParam.Value = "( " & Left(queryStartMonth, 3) & "/" & Right(queryStartMonth, 2) & " ~ " _
                                          & Left(queryEndMonth, 3) & "/" & Right(queryEndMonth, 2) & " )"
    End Sub
#End Region

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakeQuerySQL()
    End Sub


    Protected Sub btnSearchDownExcel_Click(sender As Object, e As EventArgs) Handles btnSearchDownExcel.Click
        MakeQuerySQL()

        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing
        Dim QueryDataTable As DataTable = Search(Me.hfParam.Value, hfSQL1Master.Value, hfSQL2Detail.Value)

        Dim changeColumnName As String
        For Each eachItem As DataColumn In QueryDataTable.Columns
            changeColumnName = ""

            Select Case eachItem.ColumnName
                Case "類別"
                    changeColumnName = "　"
                Case "落後量"
                    changeColumnName = "落後量(噸)"
                Case "製程線"
                    changeColumnName = "製程線(噸)"
                Case "成品線"
                    changeColumnName = "成品線(噸)"
                Case "未派量"
                    changeColumnName = "未派量(噸)"
            End Select
            If changeColumnName <> "" Then eachItem.ColumnName = changeColumnName
            'eachItem.ColumnName = eachItem.ColumnName.Replace("類別", "　")
        Next

        ExcelConvert = New PublicClassLibrary.DataConvertExcel(QueryDataTable, "訂單生產派工狀況查詢" & Format(Now, "mmss") & ".xls")
        If Not IsNothing(ExcelConvert) Then
            ExcelConvert.DownloadEXCELFile(Me.Response)
        End If

    End Sub


#Region "查詢訂單生產派工狀況：Search"

    Enum DisplyCol
        鋼種 = 0
        表面 = 1
        落後量 = 2
        製程線 = 3
        成品線 = 4
        未派量 = 5
        備註 = 6

        MinCol = 1
        MaxCol = 6
    End Enum

    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function Search(ByVal fromParam As String, ByVal fromSQL1Master As String, ByVal fromSQL2Detail As String) As EISDataSet.OrderProduceAssignDataTable
        Dim retDatatable As EISDataSet.OrderProduceAssignDataTable = New EISDataSet.OrderProduceAssignDataTable
        Dim AddItem As EISDataSet.OrderProduceAssignRow = Nothing

        If String.IsNullOrEmpty(fromSQL1Master) OrElse String.IsNullOrEmpty(fromSQL2Detail) OrElse String.IsNullOrEmpty(fromParam) Then
            Return retDatatable
        End If

        Dim Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim queryNow As DataTable = Nothing
        Dim query1Master As DataTable = Adapter.SelectQuery(fromSQL1Master)
        Dim query2Detail As DataTable = Adapter.SelectQuery(fromSQL2Detail)

        Dim II As Integer, JJ As Integer
        Dim Ro As Integer, PP As Double, inPP As Double, QTN As Double, Gtype As String
        Dim PDa As Double, PDb As Double
        Dim EX As String
        Dim WriteOk As Boolean

        Dim MaxRow As Integer = 28


        For II = 1 To MaxRow
            retDatatable.Rows.Add(retDatatable.NewRow)
        Next
        Ro = -1
        For Each eachItem1 As DataRow In query1Master.Rows


            If (eachItem1.Item("QTN29") <> " ") Then EX = "X" Else EX = "　"

            ' 有主在製品量
            inPP = getProcessing(query2Detail, eachItem1.Item("QTN01"), eachItem1.Item("QTN02"), eachItem1.Item("QTN03"), eachItem1.Item("QTN04"), eachItem1.Item("QTN05"), eachItem1.Item("QTN25"), PDa, PDb)

            ' 未派量
            PP = eachItem1.Item("S00007") - inPP
            If (PP < 3 Or eachItem1.Item("QTN93") = "A") Then PP = 0

            ' 落後量
            If (eachItem1.Item("S00007") >= 3) Then QTN = eachItem1.Item("S00007") Else QTN = 0

            If (QTN > 0 Or inPP > 0) Then
                With retDatatable
                    WriteOk = True

                    If (eachItem1.Item("QTN03") = "304 " And eachItem1.Item("QTN04") = "2B " And eachItem1.Item("QTN25") = "G") Then Gtype = "G" Else Gtype = "　"


                    If (Ro = -1) OrElse (.Rows(Ro).Item(DisplyCol.鋼種) <> eachItem1.Item("QTN03") Or .Rows(Ro).Item(DisplyCol.表面) <> eachItem1.Item("QTN04") Or Left(.Rows(Ro).Item(DisplyCol.備註), 1) <> EX) Then
                        Ro = Ro + 1
                        .Rows(Ro).Item(DisplyCol.鋼種) = eachItem1.Item("QTN03")
                        .Rows(Ro).Item(DisplyCol.表面) = eachItem1.Item("QTN04")
                        .Rows(Ro).Item(DisplyCol.備註) = EX & Gtype

                    ElseIf (.Rows(Ro).Item(DisplyCol.鋼種) = "304 " And .Rows(Ro).Item(DisplyCol.表面) = "2B ") Then
                        If (.Rows(Ro - 1).Item(DisplyCol.鋼種) = "304 " And .Rows(Ro - 1).Item(DisplyCol.表面) = "2B " And Left(.Rows(Ro - 1).Item(DisplyCol.備註), 1) = EX) Then
                            If (Gtype = Mid(.Rows(Ro).Item(DisplyCol.備註), 2, 1)) Then
                                AddValue(retDatatable, Ro - 1, DisplyCol.落後量, QTN)
                                AddValue(retDatatable, Ro - 1, DisplyCol.製程線, PDa)
                                AddValue(retDatatable, Ro - 1, DisplyCol.成品線, PDb)
                                AddValue(retDatatable, Ro - 1, DisplyCol.未派量, PP)
                                WriteOk = False
                            Else
                            End If
                        Else
                            If (Gtype = Mid(.Rows(Ro).Item(DisplyCol.備註), 2, 1)) Then
                            Else
                                Ro = Ro + 1
                                .Rows(Ro).Item(DisplyCol.鋼種) = eachItem1.Item("QTN03")
                                .Rows(Ro).Item(DisplyCol.表面) = eachItem1.Item("QTN04")
                                .Rows(Ro).Item(DisplyCol.備註) = EX & Gtype
                            End If
                        End If
                    End If

                    If (WriteOk) Then
                        AddValue(retDatatable, Ro - 1, DisplyCol.落後量, QTN)
                        AddValue(retDatatable, Ro - 1, DisplyCol.製程線, PDa)
                        AddValue(retDatatable, Ro - 1, DisplyCol.成品線, PDb)
                        AddValue(retDatatable, Ro - 1, DisplyCol.未派量, PP)
                    End If

                End With
            End If

        Next

        Dim ArrayDataCount(6) As Integer
        Dim ArrayDataNow(6) As Integer

        '四捨五入/數字分隔/統計
        For II = 0 To Ro
            'Init
            For JJ = LBound(ArrayDataNow) To UBound(ArrayDataNow)
                ArrayDataNow(JJ) = 0
            Next

            For JJ = DisplyCol.MinCol To DisplyCol.MaxCol
                If IsNumeric(retDatatable.Rows(II).Item(JJ)) = True Then
                    ArrayDataNow(JJ) = Math.Round(Double.Parse(retDatatable.Rows(II).Item(JJ)), 0, MidpointRounding.AwayFromZero)

                    If ArrayDataNow(JJ) <= 0 Then
                        retDatatable.Rows(II).Item(JJ) = ""
                    Else
                        retDatatable.Rows(II).Item(JJ) = String.Format("{0:N0}", ArrayDataNow(JJ))
                        ArrayDataCount(JJ) += ArrayDataNow(JJ)
                    End If
                End If
            Next
        Next

        Ro = MaxRow - 3
        With retDatatable
            .Rows(Ro).Item(DisplyCol.鋼種) = "統計"
            .Rows(Ro).Item(DisplyCol.落後量) = String.Format("{0:N0}", ArrayDataCount(DisplyCol.落後量))
            .Rows(Ro).Item(DisplyCol.製程線) = String.Format("{0:N0}", ArrayDataCount(DisplyCol.製程線))
            .Rows(Ro).Item(DisplyCol.成品線) = String.Format("{0:N0}", ArrayDataCount(DisplyCol.成品線))
            .Rows(Ro).Item(DisplyCol.未派量) = String.Format("{0:N0}", ArrayDataCount(DisplyCol.未派量))
        End With

        Ro = MaxRow - 2        
        retDatatable.Rows(Ro).Item(DisplyCol.備註) = "PS.本表資料項目&quot;落後量&quot;和&quot;未派量&quot;皆包含業務&lt;暫不派工&gt;訂單。"       'PS.本表資料項目"落後量"和"未派量"皆包含業務<暫不派工>訂單。

        Ro = MaxRow - 1
        retDatatable.Rows(Ro).Item(DisplyCol.備註) = fromParam.Split("|")(0) & "<BR>" & "編製時間：" & Format(Now, "yyyy/MM/dd HH:mm")

        Return retDatatable
    End Function


    Private Shared Sub AddValue(ByRef fromDataTable As DataTable, ByVal fromRow As Integer, ByVal fromCol As Integer, ByVal fromAddValue As Object)
        If fromRow = -1 Then
            fromRow = 0
        Else
            fromRow += 1
        End If

        Dim ParamAddValue As Double
        If IsNumeric(fromAddValue) = True Then ParamAddValue = fromAddValue

        Dim NowText As String = fromDataTable.Rows(fromRow).Item(fromCol)
        Dim NowValue As Double
        If IsNumeric(NowText) = False OrElse NowText.Trim = "" Then
            NowValue = 0
        Else
            NowValue = Double.Parse(NowText)
        End If

        fromDataTable.Rows(fromRow).Item(fromCol) = (NowValue + ParamAddValue).ToString
    End Sub

    ' 讀取在製品量
    Private Shared Function getProcessing(ByRef fromQuery2Detail As DataTable, _
                                                                                 QTN01 As String, QTN02 As String, QTN03 As String, QTN04 As String, QTN05 As String, QTN25 As String, _
                                                                                 ByRef PDa As Double, ByRef PDb As Double) As Double

        Dim QTNNO, THICK, SHA08

        PDa = 0 : PDb = 0
        QTNNO = QTN01 & QTN02
        THICK = Mid(QTN05, 1, 2) & Mid(QTN05, 4, 2)

        Dim queryDataTable As List(Of DataRow) = (From A In fromQuery2Detail _
                                                                                                  Where A.Item("cic10") = QTNNO And A.Item("cic11") = QTN03 _
                                                                                                        And A.Item("cic13") = QTN04 And A.Item("cic14") = THICK _
                                                                                                        And A.Item("cic17") = QTN25 Select A).ToList

        For Each eachItem As DataRow In queryDataTable
            SHA08 = Mid(eachItem.Item("sha08"), 1, 3)
            If (SHA08 = "SBL" Or SHA08 = "SPL" Or SHA08 = "TLL") Then
                PDb = PDb + Integer.Parse(eachItem.Item("S0001"))      ' 成品線
            Else
                PDa = PDa + Integer.Parse(eachItem.Item("S0001"))       ' 製程線
            End If
        Next

        PDa = PDa / 1000
        PDb = PDb / 1000
        Dim retValue As Double = PDa + PDb
        Return retValue
    End Function

#End Region

#Region "GridView1排版：數字靠右"
    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        '數字靠右對齊
        For II As Integer = 0 To GridView1.Columns.Count - 1
            Select Case GridView1.Columns(II).HeaderText
                Case "落後量", "製程線", "成品線", "未派量"
                    e.Row.Cells(II).Attributes.Add("style", "text-align:right")
            End Select
        Next II
    End Sub
#End Region


End Class