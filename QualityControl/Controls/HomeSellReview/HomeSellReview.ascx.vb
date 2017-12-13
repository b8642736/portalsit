Public Class HomeSellReview
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    Public Function Search(ByVal QryString As String, ByVal DateArgs As String) As QualityControlDataSet.HomeSellReviewDataTable
        Dim ReturnValue As New QualityControlDataSet.HomeSellReviewDataTable
        If String.IsNullOrEmpty(QryString) OrElse String.IsNullOrEmpty(DateArgs) Then
            Return ReturnValue
        End If
        Dim DateConverter As New CompanyORMDB.AS400DateConverter
        Dim SearchResult As List(Of DataRow) = (From A In New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString).SelectQuery).ToList

        '依CR/HR重新排序
        Dim SortDataTemp As New List(Of DataRow)
        For Each EachItem As String In (From A In SearchResult Select CType(A.Item("CIA05"), String).Trim Distinct).ToList
            Dim EachItemTemp As String = EachItem
            SortDataTemp.AddRange((From A In SearchResult Where CType(A.Item("CIA05"), String).Trim = EachItemTemp And CType(A.Item("CIA06"), String).Trim = "NO1" Select A Order By CType(A.Item("CIA05"), String)).ToList)
            SortDataTemp.AddRange((From A In SearchResult Where CType(A.Item("CIA05"), String).Trim = EachItemTemp And CType(A.Item("CIA06"), String).Trim <> "NO1" Select A Order By CType(A.Item("CIA05"), String), CType(A.Item("CIA06"), String)).ToList)
        Next
        SearchResult = SortDataTemp

        Dim TimeSectionCount As Integer = 0
        For Each EachItem As String In (From A In SearchResult Select CType(A.Item("CIA05"), String).Trim & "," & CType(A.Item("CIA06"), String).Trim Distinct).ToList
            Dim EachItemTemp As String = EachItem
            Dim GroupDatas1 As List(Of DataRow) = (From A In SearchResult Where CType(A.Item("CIA05"), String).Trim = EachItemTemp.Split(",")(0) And CType(A.Item("CIA06"), String).Trim = EachItemTemp.Split(",")(1) Select A).ToList
            TimeSectionCount = 0
            Dim AddRow As QualityControlDataSet.HomeSellReviewRow = ReturnValue.NewRow
            With AddRow
                For Each EachItemTime In DateArgs.Split(",")
                    TimeSectionCount += 1
                    DateConverter.DateValue = CType(EachItemTime.Split("~")(0), Date)
                    Dim Time1 As Integer = DateConverter.TwIntegerTypeData
                    DateConverter.DateValue = CType(EachItemTime.Split("~")(1), Date)
                    Dim Time2 As Integer = DateConverter.TwIntegerTypeData
                    Dim GroupDatas2 As List(Of DataRow) = (From A In GroupDatas1 Where CType(A.Item("CIA58"), Integer) >= Time1 And CType(A.Item("CIA58"), Integer) <= Time2 Select A).ToList
                    Dim Level1Weight As Double = 0
                    .項目名稱 = EachItemTemp.Split(",")(0) & "/" & EachItemTemp.Split(",")(1)
                    Dim ProductWeight As Double = (From A In GroupDatas2 Select CType(A.Item("CIA13"), Double)).Sum
                    If ProductWeight = 0 Then
                        Continue For
                    End If
                    Select Case TimeSectionCount
                        Case 1
                            .產量1 = String.Format("{0:#,0.###}", ProductWeight / 1000)
                            .一級品率1 = String.Format("{0:0.##}%", (From A In GroupDatas2 Select CType(A.Item("CIA23"), Double)).Sum / ProductWeight * 100)
                            .次級主要缺陷1 = GetMainBugString(GroupDatas2)
                        Case 2
                            .產量2 = String.Format("{0:#,0.###}", ProductWeight / 1000)
                            .一級品率2 = String.Format("{0:0.##}%", (From A In GroupDatas2 Select CType(A.Item("CIA23"), Double)).Sum / ProductWeight * 100)
                            .次級主要缺陷2 = GetMainBugString(GroupDatas2)
                        Case 3
                            .產量3 = String.Format("{0:#,0.###}", ProductWeight / 1000)
                            .一級品率3 = String.Format("{0:0.##}%", (From A In GroupDatas2 Select CType(A.Item("CIA23"), Double)).Sum / ProductWeight * 100)
                            .次級主要缺陷3 = GetMainBugString(GroupDatas2)
                        Case 4
                            .產量4 = String.Format("{0:#,0.###}", ProductWeight / 1000)
                            .一級品率4 = String.Format("{0:0.##}%", (From A In GroupDatas2 Select CType(A.Item("CIA23"), Double)).Sum / ProductWeight * 100)
                            .次級主要缺陷4 = GetMainBugString(GroupDatas2)
                    End Select
                Next
            End With
            ReturnValue.Rows.Add(AddRow)
        Next

        '最後統計一級品率
        TimeSectionCount = 0
        Dim AddLastRow As QualityControlDataSet.HomeSellReviewRow = ReturnValue.NewRow
        With AddLastRow
            For Each EachItemTime In DateArgs.Split(",")
                TimeSectionCount += 1
                DateConverter.DateValue = CType(EachItemTime.Split("~")(0), Date)
                Dim Time1 As Integer = DateConverter.TwIntegerTypeData
                DateConverter.DateValue = CType(EachItemTime.Split("~")(1), Date)
                Dim Time2 As Integer = DateConverter.TwIntegerTypeData
                Dim GroupDatas3 As List(Of DataRow) = (From A In SearchResult Where CType(A.Item("CIA58"), Integer) >= Time1 And CType(A.Item("CIA58"), Integer) <= Time2 Select A).ToList
                Dim Level1Weight As Double = 0
                .項目名稱 = "合計"
                Dim ProductWeight As Double = (From A In GroupDatas3 Select CType(A.Item("CIA13"), Double)).Sum
                If ProductWeight = 0 Then
                    Continue For
                End If
                Select Case TimeSectionCount
                    Case 1
                        .產量1 = String.Format("{0:#,0.###}", ProductWeight / 1000)
                        .一級品率1 = String.Format("{0:0.##}%", (From A In GroupDatas3 Select CType(A.Item("CIA23"), Double)).Sum / ProductWeight * 100)
                    Case 2
                        .產量2 = String.Format("{0:#,0.###}", ProductWeight / 1000)
                        .一級品率2 = String.Format("{0:0.##}%", (From A In GroupDatas3 Select CType(A.Item("CIA23"), Double)).Sum / ProductWeight * 100)
                    Case 3
                        .產量3 = String.Format("{0:#,0.###}", ProductWeight / 1000)
                        .一級品率3 = String.Format("{0:0.##}%", (From A In GroupDatas3 Select CType(A.Item("CIA23"), Double)).Sum / ProductWeight * 100)
                    Case 4
                        .產量4 = String.Format("{0:#,0.###}", ProductWeight / 1000)
                        .一級品率4 = String.Format("{0:0.##}%", (From A In GroupDatas3 Select CType(A.Item("CIA23"), Double)).Sum / ProductWeight * 100)
                End Select
            Next
        End With
        ReturnValue.Rows.Add(AddLastRow)





        Return ReturnValue
    End Function

    Private Function GetMainBugString(ByVal SourceDatas As List(Of DataRow)) As String
        Static AllPPSDEFPFKeyAndNames As Dictionary(Of Integer, String)
        If IsNothing(AllPPSDEFPFKeyAndNames) Then
            AllPPSDEFPFKeyAndNames = New Dictionary(Of Integer, String)
            Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            For Each EachItem In CompanyORMDB.PPS100LB.PPSDEFPF.ALL_PPSDEPF(AS400Adapter)
                AllPPSDEFPFKeyAndNames.Add(EachItem.DEF01, EachItem.DEF02)
            Next
        End If
        Dim Bugs As New Dictionary(Of String, Double)
        For Each EachItem As DataRow In SourceDatas     '次級品(2級)之 缺限代碼,重量
            Dim TotalLevel2BugWeight As Double = CType(EachItem.Item("CIA24"), Double)
            Dim TotalLevel2BugLength As Double = 0
            For BugNumber As Integer = 25 To 34 Step 3
                If Not IsDBNull(EachItem.Item("QCP" & BugNumber)) Then
                    TotalLevel2BugLength += CType(EachItem.Item("QCP" & BugNumber), Double)
                End If
            Next
            For BugNumber As Integer = 24 To 33 Step 3
                If IsDBNull(EachItem.Item("QCP" & BugNumber)) Then
                    Continue For
                End If
                Dim BugCode As Integer = CType(EachItem.Item("QCP" & BugNumber), Integer)
                Dim BugLength As Integer = CType(EachItem.Item("QCP" & BugNumber + 1), Double)
                If BugCode = 0 OrElse BugLength = 0 Then
                    Continue For
                End If
                Dim BugWeigt As Double = TotalLevel2BugWeight * (BugLength / TotalLevel2BugLength)
                If Bugs.ContainsKey(BugCode) = False Then
                    Bugs.Add(BugCode, BugWeigt)
                Else
                    Bugs.Item(BugCode) += BugWeigt
                End If
            Next
        Next
        For Each EachItem As DataRow In SourceDatas     '次級品(3級)之 缺限代碼,重量
            Dim TotalLevel3BugWeight As Double = CType(EachItem.Item("CIA25"), Double)
            Dim TotalLevel3BugLength As Double = 0
            For BugNumber As Integer = 37 To 46 Step 3
                If Not IsDBNull(EachItem.Item("QCP" & BugNumber)) Then
                    TotalLevel3BugLength += CType(EachItem.Item("QCP" & BugNumber), Double)
                End If
            Next
            For BugNumber As Integer = 36 To 45 Step 3
                If IsDBNull(EachItem.Item("QCP" & BugNumber)) Then
                    Continue For
                End If
                Dim BugCode As Integer = CType(EachItem.Item("QCP" & BugNumber), Integer)
                Dim BugLength As Integer = CType(EachItem.Item("QCP" & BugNumber + 1), Double)
                If BugCode = 0 OrElse BugLength = 0 Then
                    Continue For
                End If
                Dim BugWeigt As Double = TotalLevel3BugWeight * (BugLength / TotalLevel3BugLength)
                If Bugs.ContainsKey(BugCode) = False Then
                    Bugs.Add(BugCode, BugWeigt)
                Else
                    Bugs.Item(BugCode) += BugWeigt
                End If
            Next
        Next

        For Each EachItem As DataRow In SourceDatas
            '頭尾
            If Not IsDBNull(EachItem.Item("QCP45")) AndAlso CType(EachItem.Item("QCP45"), Integer) > 0 Then
                Dim BugCode As Integer = CType(EachItem.Item("QCP45"), Integer)
                Dim BugWeigt As Double = CType(EachItem.Item("CIA26"), Double)
                If Bugs.ContainsKey(BugCode) = False Then
                    Bugs.Add(BugCode, BugWeigt)
                Else
                    Bugs.Item(BugCode) += BugWeigt
                End If
            End If

            '廢料
            If Not IsDBNull(EachItem.Item("QCP56")) AndAlso CType(EachItem.Item("QCP56"), Integer) > 0 Then
                Dim BugCode As Integer = CType(EachItem.Item("QCP56"), Integer)
                Dim BugWeigt As Double = CType(EachItem.Item("CIA28"), Double)
                If Bugs.ContainsKey(BugCode) = False Then
                    Bugs.Add(BugCode, BugWeigt)
                Else
                    Bugs.Item(BugCode) += BugWeigt
                End If
            End If

        Next


        Dim ReturnValue As String = Nothing
        ''排除顯示'83.重量不足'與'88.其它'之缺陷顯示
        'Dim SortedBugs = From A In Bugs Where A.Key.Trim <> "83" And A.Key.Trim <> "88" Select A Order By A.Value Descending

        '正常無排除
        Dim SortedBugs = From A In Bugs Select A Order By A.Value Descending
        Dim BugCount As Integer = 0
        Dim SourceDatasTotalWeight As Double = (From A In SourceDatas Select CType(A.Item("CIA13"), Double)).Sum
        For Each EachItem In SortedBugs.ToList
            If AllPPSDEFPFKeyAndNames.ContainsKey(EachItem.Key) Then
                ReturnValue &= IIf(String.IsNullOrEmpty(ReturnValue), Nothing, ",") & AllPPSDEFPFKeyAndNames.Item(EachItem.Key).Trim
                ReturnValue &= String.Format(":{0:0.##}%", EachItem.Value / SourceDatasTotalWeight * 100)
                BugCount += 1
                If BugCount >= 10 Then
                    Exit For
                End If
            End If
        Next
        Return ReturnValue
    End Function

    'Private Function GetMainBugString(ByVal SourceDatas As List(Of DataRow)) As String
    '    Static AllPPSDEFPFKeyAndNames As Dictionary(Of Integer, String)
    '    If IsNothing(AllPPSDEFPFKeyAndNames) Then
    '        AllPPSDEFPFKeyAndNames = New Dictionary(Of Integer, String)
    '        Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
    '        For Each EachItem In CompanyORMDB.PPS100LB.PPSDEFPF.ALL_PPSDEPF(AS400Adapter)
    '            AllPPSDEFPFKeyAndNames.Add(EachItem.DEF01, EachItem.DEF02)
    '        Next
    '    End If
    '    Dim Bugs As New Dictionary(Of String, Double)   '次級品(2級+3級)之 缺限代碼,重量
    '    For Each EachItem As DataRow In SourceDatas
    '        Dim TotalWeight As Double = CType(EachItem.Item("CIA13"), Double)
    '        Dim TotalLength As Double = CType(EachItem.Item("CIA09"), Double)
    '        For BugNumber As Integer = 24 To 45 Step 3
    '            If IsDBNull(EachItem.Item("QCP" & BugNumber)) Then
    '                Continue For
    '            End If
    '            Dim BugCode As Integer = CType(EachItem.Item("QCP" & BugNumber), Integer)
    '            Dim BugLength As Integer = CType(EachItem.Item("QCP" & BugNumber + 1), Double)
    '            If BugCode = 0 OrElse BugLength = 0 Then
    '                Continue For
    '            End If
    '            Dim BugWeigt As Double = TotalWeight * (BugLength / TotalLength)
    '            If Bugs.ContainsKey(BugCode) = False Then
    '                Bugs.Add(BugCode, BugWeigt)
    '            Else
    '                Bugs.Item(BugCode) += BugWeigt
    '            End If
    '        Next
    '    Next
    '    Dim ReturnValue As String = Nothing
    '    '排除顯示'83.重量不足'與'88.其它'之缺陷顯示
    '    Dim SortedBugs = From A In Bugs Where A.Key.Trim <> "83" And A.Key.Trim <> "88" Select A Order By A.Value Descending
    '    Dim BugCount As Integer = 0
    '    Dim SourceDatasTotalWeight As Double = (From A In SourceDatas Select CType(A.Item("CIA13"), Double)).Sum
    '    For Each EachItem In SortedBugs.ToList
    '        If AllPPSDEFPFKeyAndNames.ContainsKey(EachItem.Key) Then
    '            ReturnValue &= IIf(String.IsNullOrEmpty(ReturnValue), Nothing, ",") & AllPPSDEFPFKeyAndNames.Item(EachItem.Key).Trim
    '            ReturnValue &= String.Format(":{0:0.##}%", EachItem.Value / SourceDatasTotalWeight * 100)
    '            BugCount += 1
    '            If BugCount >= 10 Then
    '                Exit For
    '            End If
    '        End If
    '    Next
    '    Return ReturnValue
    'End Function


#End Region
#Region "設定查詢條件至控制項 屬性:SetQryStringToControl"
    ''' <summary>
    ''' 設定查詢條件至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryStringToControl()
        Dim ReturnValue As String = "Select A.* , B.* From @#PPS100LB.PPSCIAPF A LEFT JOIN @#PPS100LB.PPSQCPPF B ON A.CIA02=B.QCP02 AND A.CIA03=B.QCP03 AND A.CIA58=B.QCP59 WHERE  A.CIA06 IN (SELECT CH201 FROM @#SLS300LB.SL2CH2PF WHERE CH202=' ' ) AND A.CIA45 IN ('C','D','Z','*','R') "
        Dim MaxStartTime As DateTime = Now.Date
        Dim MaxEndTime As DateTime = MaxStartTime
        Dim TimeSectionArgs As String = Nothing
        Dim GetStartTimes As New List(Of DateTime)
        Dim GetEndTimes As New List(Of DateTime)

        Me.hfQryString.Value = Nothing
        Me.hfDateArgs.Value = Nothing

        If CheckBox1.Checked = False AndAlso CheckBox2.Checked = False AndAlso CheckBox3.Checked = False AndAlso CheckBox4.Checked = False Then
            Exit Sub
        End If
        If CheckBox1.Checked Then
            GetStartTimes.Add(CType(tbStartDate1.Text, DateTime))
            GetEndTimes.Add(CType(tbEndDate1.Text, DateTime))
        End If
        If CheckBox2.Checked Then
            GetStartTimes.Add(CType(tbStartDate2.Text, DateTime))
            GetEndTimes.Add(CType(tbEndDate2.Text, DateTime))
        End If
        If CheckBox3.Checked Then
            GetStartTimes.Add(CType(tbStartDate3.Text, DateTime))
            GetEndTimes.Add(CType(tbEndDate3.Text, DateTime))
        End If
        If CheckBox4.Checked Then
            GetStartTimes.Add(CType(tbStartDate4.Text, DateTime))
            GetEndTimes.Add(CType(tbEndDate4.Text, DateTime))
        End If
        Select Case RadioButtonList1.SelectedValue
            Case "內銷"
                '2012/2/9劉志銘指示201與202部份不份內外銷
                ReturnValue &= " AND (CIA34 = ' ' OR LEFT(CIA05,3)='201' OR LEFT(CIA05,3)='202') "
            Case "外銷"
                '2012/2/9劉志銘指示201與202部份不份內外銷
                ReturnValue &= " AND (CIA34 <> ' ' OR LEFT(CIA05,3)='201' OR LEFT(CIA05,3)='202') "
            Case Else
        End Select

        ReturnValue &= " AND A.CIA58>=" & New CompanyORMDB.AS400DateConverter(GetStartTimes.Min).TwIntegerTypeData & " AND A.CIA58<=" & New CompanyORMDB.AS400DateConverter(GetEndTimes.Max).TwIntegerTypeData
        For Each EachItem In GetStartTimes
            TimeSectionArgs &= IIf(String.IsNullOrEmpty(TimeSectionArgs), Nothing, ",") & EachItem & "~" & GetEndTimes(GetStartTimes.IndexOf(EachItem))
        Next

        Me.hfQryString.Value = ReturnValue & " Order By A.CIA05,A.CIA06 "
        Me.hfDateArgs.Value = TimeSectionArgs
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim StartDate As DateTime = New Date(Now.Year, Now.Month, 1)
            Dim EndDate As DateTime = StartDate.AddDays(5)
            Me.tbStartDate1.Text = StartDate
            Me.tbStartDate2.Text = StartDate
            Me.tbStartDate3.Text = StartDate
            Me.tbStartDate4.Text = StartDate
            Me.tbEndDate1.Text = EndDate
            Me.tbEndDate2.Text = EndDate
            Me.tbEndDate3.Text = EndDate
            Me.tbEndDate4.Text = EndDate
        End If

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SetQryStringToControl()
        Dim Parameters(5) As Microsoft.Reporting.WebForms.ReportParameter
        Dim TimeSectionCount As Integer = 0
        Parameters(0) = New Microsoft.Reporting.WebForms.ReportParameter("TitleArg", CType(IIf(RadioButtonList1.SelectedValue = "ALL", "內外銷", RadioButtonList1.SelectedValue), String))
        Parameters(1) = New Microsoft.Reporting.WebForms.ReportParameter("DateRange1", "")
        Parameters(2) = New Microsoft.Reporting.WebForms.ReportParameter("DateRange2", "")
        Parameters(3) = New Microsoft.Reporting.WebForms.ReportParameter("DateRange3", "")
        Parameters(4) = New Microsoft.Reporting.WebForms.ReportParameter("DateRange4", "")
        For Each EachItemTime In Me.hfDateArgs.Value.Split(",")
            TimeSectionCount += 1
            Parameters(TimeSectionCount) = New Microsoft.Reporting.WebForms.ReportParameter("DateRange" & TimeSectionCount, EachItemTime)
        Next
        Parameters(5) = New Microsoft.Reporting.WebForms.ReportParameter("BigBugRate", Val(tbTargetRate.Text))
        ReportViewer1.LocalReport.SetParameters(Parameters)
        ReportViewer1.LocalReport.Refresh()
    End Sub
End Class