Public Class SteelPlantSendInOutSearch
    Inherits System.Web.UI.UserControl

    Protected Sub btnSearchReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchReset.Click
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakeQryToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchToExcel.Click
        MakeQryToControl()
        Dim ExcelConvert As New DataConvertExcel(Search(Me.hfQry.Value), "送外代軋鋼胚送回統計" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As DisplayDataSet.SteelPlantSendInOutDisplayDataTableDataTable
        Dim ReturnValue As New DisplayDataSet.SteelPlantSendInOutDisplayDataTableDataTable
        Dim AddItem As DisplayDataSet.SteelPlantSendInOutDisplayDataTableRow = Nothing

        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If
        Dim SearchResult As List(Of CompanyORMDB.SMS100LB.SMSSGAPF) = (From A In CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.SMS100LB.SMSSGAPF)(SQLString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC) Select A Order By A.SGA05, A.SGA06, A.SGA09, A.SGA35StateLeng).ToList
        Dim QueryResult As List(Of CompanyORMDB.SMS100LB.SMSSGAPF) = Nothing

        Dim GroupItemA As List(Of DisplayData1A) = (From A In SearchResult _
                                                                             Group By A.SGA05, A.SGA06, A.SGA41 Into GroupCount = Count() _
                                                                             Order By SGA05, SGA06, SGA41
                                                                             Select New DisplayData1A(SGA05, SGA06, SGA41)).ToList
        Dim GroupItemB As List(Of DisplayData1B) = (From A In GroupItemA _
                                                                                                   Group By A.鋼種, A.材質 Into GroupCount = Count() _
                                                                                                   Order By 鋼種, 材質 _
                                                                                                   Select New DisplayData1B(鋼種, 材質)).ToList


        Dim GroupItem2 As List(Of DisplayData2) = Nothing
        For Each eachItem1B As DisplayData1B In GroupItemB

            AddItem = ReturnValue.NewRow

            AddItem.鋼種 = eachItem1B.鋼種
            AddItem.材質 = eachItem1B.材質

            AddItem.送至中鋼數量 = (From A In SearchResult Where A.SGA05 = eachItem1B.鋼種 And A.SGA06 = eachItem1B.材質 Select A.SGA24).Count.ToString.Trim
            AddItem.送至中鋼重量 = (From A In SearchResult Where A.SGA05 = eachItem1B.鋼種 And A.SGA06 = eachItem1B.材質 Select A.SGA24).Sum.ToString.Trim


            Dim displayData3 As New DisplayData3
            For Each eachItem1A As DisplayData1A In (From A In GroupItemA _
                                                                                                 Where A.鋼種 = eachItem1B.鋼種 And A.材質 = eachItem1B.材質 _
                                                                                                 Order By A.回廠日期 _
                                                                                                 Select A).ToList

                displayData3.回廠日期 = eachItem1A.回廠日期

                'SGA35  C:送至中鋼未回
                QueryResult = (From A In SearchResult Where A.SGA05 = eachItem1A.鋼種 And A.SGA06 = eachItem1A.材質 _
                                   And ((A.SGA35 = "C" And A.SGA41 = 0) Or (A.SGA35 = "*" And A.SGA41 > eachItem1A.回廠日期)) _
                                Select A).ToList
                displayData3.未壓數量 = (From A In QueryResult Select A).Count.ToString.Trim
                displayData3.未壓重量 = (From A In QueryResult Select A.SGA24).Sum.ToString.Trim


                'SGA35   *:中鋼送回     SGA40  B:中鋼壓壞(初壓)   C:中鋼壓壞 (後壓)
                Dim LossCode As String = "B,C"
                QueryResult = (From A In SearchResult Where A.SGA05 = eachItem1A.鋼種 And A.SGA06 = eachItem1A.材質 And A.SGA41 = eachItem1A.回廠日期 And A.SGA35 = "*" And LossCode.Split(",").Contains(A.SGA40.Trim) Select A).ToList
                displayData3.中鋼壓壞數量 = (From A In QueryResult Select A).Count.ToString.Trim
                displayData3.中鋼壓壞重量 = (From A In QueryResult Select A.SGA24).Sum.ToString.Trim


                'SGA35   *:中鋼送回     SGA40  空白:正常品
                Dim SQL2String As String = ""
                Dim SQL2Where As String = ""
                displayData3.中鋼會判數量 = 0
                displayData3.中鋼會判重量 = 0
                displayData3.捲型不良數量 = 0
                displayData3.捲型不良重量 = 0
                displayData3.正常品數量 = 0
                displayData3.正常品重量 = 0

                GroupItem2 = (From A In SearchResult _
                                                Where A.SGA05 = eachItem1A.鋼種 And A.SGA06 = eachItem1A.材質 And A.SGA41 = eachItem1A.回廠日期 _
                                                      And A.SGA35 = "*" And A.SGA40.Trim = "" _
                                                Select New DisplayData2(A.SGA01 & "-" & A.SGA02 & Right("00" & A.SGA03.ToString.Trim, 2) & A.SGA04, A.SGA33)).ToList

                If GroupItem2.Count > 0 Then
                    For Each eachItem2 As DisplayData2 In GroupItem2
                        SQL2Where &= " (bla07='" & eachItem2.SlabNO & "' AND bla11='" & eachItem2.LotsNo & "') OR"
                    Next

                    SQL2String = "SELECT * FROM  @#PPS100LB.PPSBLAPF WHERE " & Mid(SQL2Where, 1, SQL2Where.Length - 2)
                    Dim SearchResult2 As List(Of CompanyORMDB.PPS100LB.PPSBLAPF) = CompanyORMDB.ORMBaseClass.ClassDBAS400.CDBSelect(Of CompanyORMDB.PPS100LB.PPSBLAPF)(SQL2String, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

                    For Each eachItem3 As CompanyORMDB.PPS100LB.PPSBLAPF In SearchResult2
                        Select Case eachItem3.BLA16.Trim
                            Case "12", "20"     '中鋼會判
                                displayData3.中鋼會判數量 += 1
                                displayData3.中鋼會判重量 += eachItem3.BLA06

                            Case ""     '正常品/捲型不良
                                If eachItem3.BLA15.Trim = "A" Then
                                    displayData3.捲型不良數量 += 1
                                    displayData3.捲型不良重量 += eachItem3.BLA06

                                ElseIf eachItem3.BLA15.Trim = "" Then
                                    displayData3.正常品數量 += 1
                                    displayData3.正常品重量 += eachItem3.BLA06

                                End If
                        End Select
                    Next
                End If

                AddItem.回廠日期 &= displayData3.回廠日期.ToString.Trim & "<BR>"
                AddItem.未壓數量 &= String.Format("{0:N0}", displayData3.未壓數量) & "<BR>"
                AddItem.未壓重量 &= String.Format("{0:N0}", displayData3.未壓重量) & "<BR>"

                AddItem.正常品數量 &= String.Format("{0:N0}", displayData3.正常品數量) & "<BR>"
                AddItem.正常品重量 &= String.Format("{0:N0}", displayData3.正常品重量) & "<BR>"
                AddItem.中鋼會判數量 &= String.Format("{0:N0}", displayData3.中鋼會判數量) & "<BR>"
                AddItem.中鋼會判重量 &= String.Format("{0:N0}", displayData3.中鋼會判重量) & "<BR>"
                AddItem.捲型不良數量 &= String.Format("{0:N0}", displayData3.捲型不良數量) & "<BR>"
                AddItem.捲型不良重量 &= String.Format("{0:N0}", displayData3.捲型不良重量) & "<BR>"

                AddItem.中鋼壓壞數量 &= String.Format("{0:N0}", displayData3.中鋼壓壞數量) & "<BR>"
                AddItem.中鋼壓壞重量 &= String.Format("{0:N0}", displayData3.中鋼壓壞重量) & "<BR>"

            Next


            AddItem.送至中鋼數量 = String.Format("{0:N0}", Integer.Parse(AddItem.送至中鋼數量))
            AddItem.送至中鋼重量 = String.Format("{0:N0}", Integer.Parse(AddItem.送至中鋼重量))

            ReturnValue.Rows.Add(AddItem)
        Next


        AddItem = ReturnValue.NewRow
        AddItem.鋼種 = "小計"
        AddItem.送至中鋼數量 = (From A In ReturnValue Select Integer.Parse(A.送至中鋼數量.Replace(",", ""))).Sum
        AddItem.送至中鋼重量 = (From A In ReturnValue Select Integer.Parse(A.送至中鋼重量.Replace(",", ""))).Sum
        AddItem.送至中鋼數量 = String.Format("{0:N0}", Integer.Parse(AddItem.送至中鋼數量))
        AddItem.送至中鋼重量 = String.Format("{0:N0}", Integer.Parse(AddItem.送至中鋼重量))
        ReturnValue.Rows.Add(AddItem)

        Return ReturnValue
    End Function

#End Region

#Region "產生查詢指令至控制項 函式:MakeQryToControl"
    ''' <summary>
    ''' 產生查詢指令至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryToControl()
        'Note                         SGA35  C:送至中鋼   *:中鋼送回
        '                                   SGA40  C:中鋼壓壞   空白:正常

        Dim SearchBathNumber As String = TextBox1.Text.Trim.Replace("'", Nothing)
        Dim QueryString As String = "Select * from @#SMS100LB.SMSSGAPF Where SGA33='" & SearchBathNumber & "' AND ( SGA35='C' OR SGA35='*') "
        If Not String.IsNullOrEmpty(TextBox2.Text) Then
            QueryString &= " AND SGA05 IN ('" & TextBox2.Text.Trim.Replace(",", "','") & "')"
        End If
        QueryString &= " Order By SGA05,SGA06"
        Me.hfQry.Value = QueryString
    End Sub
#End Region

    Class DisplayData1A
        Public 鋼種 As String
        Public 材質 As String
        Public 回廠日期 As String

        Sub New(ByVal from鋼種 As String, ByVal from材質 As String, ByVal from回廠日期 As Integer)
            鋼種 = from鋼種
            材質 = from材質
            回廠日期 = from回廠日期
        End Sub
    End Class

    Class DisplayData1B
        Public 鋼種 As String
        Public 材質 As String

        Sub New(ByVal from鋼種 As String, ByVal from材質 As String)
            鋼種 = from鋼種
            材質 = from材質
        End Sub
    End Class

    Class DisplayData2
        Public SlabNO As String
        Public LotsNo As String

        Sub New(ByVal fromSlabNo As String, ByVal fromLotsNo As String)
            SlabNO = fromSlabNo
            LotsNo = fromLotsNo
        End Sub
    End Class

    Class DisplayData3
        Public 回廠日期 As Integer
     
        Public 未壓數量 As Integer
        Public 未壓重量 As Integer

        Public 正常品數量 As Integer
        Public 正常品重量 As Integer

        Public 中鋼會判數量 As Integer
        Public 中鋼會判重量 As Integer

        Public 捲型不良數量 As Integer
        Public 捲型不良重量 As Integer

        Public 中鋼壓壞數量 As Integer
        Public 中鋼壓壞重量 As Integer
    End Class


    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            '數字靠右對齊
            For II As Integer = 0 To GridView1.Columns.Count - 1
                e.Row.Cells(II).Attributes.Add("style", "text-align:right")
            Next II
        End If
    End Sub

End Class