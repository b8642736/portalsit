Public Class YieldRateSearch
    Inherits System.Web.UI.UserControl

#Region "查詢 方法:Search"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="SQLString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal SQLString As String) As QualityControlDataSet.YieldRateSearchDataTableDataTable
        Dim ReturnValue As New QualityControlDataSet.YieldRateSearchDataTableDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If
        Dim SearchResult As List(Of PPS100LB.PPSCIAPF) = (From A In PPS100LB.PPSCIAPF.CDBSelect(Of PPS100LB.PPSCIAPF)(SQLString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC) Order By A.IsHR, A.CIA06 Descending, A.CIA05, A.CIA34, A.CIA33, A.CIA59 Select A).ToList
        Dim QryString As String = "Select * From @#PPS100LB.PPSSHAPF Where SHA01 IN (" & SQLString.Replace("*", "CIA02") & ") Order By SHA01,SHA02"
        Dim AboutAllPPSSHAPFs As New List(Of IPPS100LB.IPPSSHAPF)
        For Each EachItem In CompanyORMDB.PPS100LB.PPSSHAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSSHAPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            AboutAllPPSSHAPFs.Add(EachItem)
        Next
        Dim AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AboutAllHotRollingInOutWeights As DataTable 'LEFT(A.BLA11,1) = 'T' 才為本廠生產
        QryString = "Select A.BLA09, A.BLA06 , B.SGA24 from @#PPS100LB.PPSBLAPF AS A  Left Join @#SMS100LB.SMSSGAPF AS B ON A.BLA07= (B.sga01 || '-'  || B.sga02 || Right('0' || B.sga03,2) || B.sga04)  WHERE  LEFT(A.BLA11,1) = 'T' AND A.BLA09 IN  (" & SQLString.Replace("*", "CIA02") & ") Order By A.BLA09"
        AboutAllHotRollingInOutWeights = AS400Adapter.SelectQuery(QryString)
        Dim LossItems As New List(Of IPPS100LB.IPPSSHAPF)

        For Each EachGroupString1 As String In (From A In SearchResult Select A.CIA06 Distinct).ToList
            For Each EachGroupString2 As String In (From A In SearchResult Where A.CIA06 = EachGroupString1 Select A.CIA05 Distinct).ToList
                For Each EachGroupString3 As String In (From A In SearchResult Where A.CIA06 = EachGroupString1 And A.CIA05 = EachGroupString2 Select A.CIA34 & "@" & A.CIA33 Distinct).ToList
                    For Each EachGroupString4 As String In (From A In SearchResult Where A.CIA06 = EachGroupString1 And A.CIA05 = EachGroupString2 And A.CIA34 = EachGroupString3.Split("@")(0) And A.CIA33 = EachGroupString3.Split("@")(1) Select A.CIA59 Distinct).ToList
                        AddGroupData(EachGroupString1 & "@" & EachGroupString2 & "@" & EachGroupString3 & "@" & EachGroupString4, SearchResult, ReturnValue, AboutAllPPSSHAPFs, LossItems, AboutAllHotRollingInOutWeights)
                    Next
                    AddGroupData(EachGroupString1 & "@" & EachGroupString2 & "@" & EachGroupString3, SearchResult, ReturnValue, AboutAllPPSSHAPFs, LossItems, AboutAllHotRollingInOutWeights)
                Next
                AddGroupData(EachGroupString1 & "@" & EachGroupString2, SearchResult, ReturnValue, AboutAllPPSSHAPFs, LossItems, AboutAllHotRollingInOutWeights)
            Next
            AddGroupData(EachGroupString1, SearchResult, ReturnValue, AboutAllPPSSHAPFs, LossItems, AboutAllHotRollingInOutWeights)
        Next

        For Each EachItem As PPS100LB.PPSCIAPF In LossItems
            Dim ADDDataRow As QualityControlDataSet.YieldRateSearchDataTableRow = ReturnValue.NewRow
            With ADDDataRow
                .表面 = EachItem.CIA06
                .鋼種 = EachItem.CIA05
                .料別 = EachItem.CIA34 & EachItem.CIA33
                .厚度 = Format(Val(EachItem.CIA59) / 100, "0.00")
                .投入量 = "資料發生錯誤無法得知!"
            End With
        Next
        Return ReturnValue
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search0(ByVal SQLString As String) As QualityControlDataSet.YieldRateSearchDataTableDataTable
        Dim ReturnValue As New QualityControlDataSet.YieldRateSearchDataTableDataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If
        Dim SearchResult As List(Of PPS100LB.PPSCIAPF) = (From A In PPS100LB.PPSCIAPF.CDBSelect(Of PPS100LB.PPSCIAPF)(SQLString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC) Order By A.IsHR, A.CIA06 Descending, A.CIA05, A.CIA34, A.CIA33, A.CIA59 Select A).ToList
        Dim QryString As String = "Select * From @#PPS100LB.PPSSHAPF Where SHA01 IN (" & SQLString.Replace("*", "CIA02") & ") Order By SHA01,SHA02"
        Dim AboutAllPPSSHAPFs As New List(Of IPPS100LB.IPPSSHAPF)
        For Each EachItem In CompanyORMDB.PPS100LB.PPSSHAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSSHAPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            AboutAllPPSSHAPFs.Add(EachItem)
        Next
        Dim AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AboutAllHotRollingInOutWeights As DataTable
        QryString = "Select A.BLA09, A.BLA06 , B.SGA24 from @#PPS100LB.PPSBLAPF AS A  Left Join @#SMS100LB.SMSSGAPF AS B ON A.BLA07= (B.sga01 || '-'  || B.sga02 || Right('0' || B.sga03,2) || B.sga04)  WHERE LEFT(A.BLA11,1) = 'T' AND  A.BLA09 IN  (" & SQLString.Replace("*", "CIA02") & ") Order By A.BLA09"
        AboutAllHotRollingInOutWeights = AS400Adapter.SelectQuery(QryString)
        Dim LossItems As New List(Of IPPS100LB.IPPSSHAPF)


        For Each EachItem As PPS100LB.PPSCIAPF In SearchResult
            Dim EachItemTemp As PPS100LB.PPSCIAPF = EachItem
            Dim ADDDataRow As QualityControlDataSet.YieldRateSearchDataTableRow = ReturnValue.NewRow
            Dim NewFlowAdapter As New CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter(EachItem.CIA02.Trim & EachItem.CIA03.Trim, SQLServer.PPS100LB.PPSSHAPFFlowAdapter.FinalALLPPSSHAPFsModeEnum.AS400Only)
            Dim AboutHotRollingInOutWeightData As DataRow = (From A In AboutAllHotRollingInOutWeights Where CType(A.Item("BLA09"), String) = EachItem.CIA02 Select A).FirstOrDefault
            With ADDDataRow
                .鋼捲號碼 = EachItem.CIA02.Trim & EachItem.CIA03.Trim
                .表面 = EachItem.CIA06
                .鋼種 = EachItem.CIA05
                .料別 = EachItem.CIA34 & EachItem.CIA33
                .厚度 = Format(Val(EachItem.CIA59) / 100, "0.00")
                .投入量 = CType((New CoilYieldRateCompute(EachItemTemp, (From A In AboutAllPPSSHAPFs Where A.SHA01 = EachItemTemp.CIA02 Select A).ToList)).InputWeight, Long)
                If .投入量 = "-1" Then
                    LossItems.Add(EachItem)
                    Continue For
                End If
                .產出量 = EachItem.CIA13 '淨重
                .產出率 = Format(Val(.產出量) / Val(.投入量), "0.00%")
                .一級品率 = Format(Val(EachItem.CIA23) / Val(.產出量), "0.00%")
                If Not IsNothing(AboutHotRollingInOutWeightData) Then
                    If IsDBNull(AboutHotRollingInOutWeightData.Item("SGA24")) Then
                        '未找到SGA資料暫時由SMSSGAPY.P981015取得
                        QryString = "Select A.BLA09, A.BLA06 , B.SGA24 from @#PPS100LB.PPSBLAPF AS A  Left Join @#SMS100LB.SMSSGAPY.P1010524 AS B ON A.BLA07= (B.sga01 || '-'  || B.sga02 || Right('0' || B.sga03,2) || B.sga04)  WHERE LEFT(A.BLA11,1) = 'T' AND  A.BLA09 IN  (" & SQLString.Replace("*", "CIA02") & ") Order By A.BLA09"
                        Dim AboutAllHotRollingInOutWeights1 As DataTable = AS400Adapter.SelectQuery(QryString)
                        Dim AboutHotRollingInOutWeightData1 As DataRow = (From A In AboutAllHotRollingInOutWeights1 Where CType(A.Item("BLA09"), String) = EachItem.CIA02 Select A).FirstOrDefault
                        .熱軋投入量 = Format(Val(AboutHotRollingInOutWeightData1.Item("SGA24")), "0")
                        .熱軋產出量 = Format(Val(AboutHotRollingInOutWeightData1.Item("BLA06")), "0")
                        .熱軋產出率 = Format(Val(.熱軋產出量) / Val(.熱軋投入量), "0.00%")
                    Else
                        .熱軋投入量 = Format(Val(AboutHotRollingInOutWeightData.Item("SGA24")), "0")
                        .熱軋產出量 = Format(Val(AboutHotRollingInOutWeightData.Item("BLA06")), "0")
                        .熱軋產出率 = Format(Val(.熱軋產出量) / Val(.熱軋投入量), "0.00%")
                    End If
                End If
            End With
            ReturnValue.Rows.Add(ADDDataRow)
        Next

        For Each EachItem As PPS100LB.PPSCIAPF In LossItems
            Dim ADDDataRow As QualityControlDataSet.YieldRateSearchDataTableRow = ReturnValue.NewRow
            With ADDDataRow
                .表面 = EachItem.CIA06
                .鋼種 = EachItem.CIA05
                .料別 = EachItem.CIA34 & EachItem.CIA33
                .厚度 = Format(Val(EachItem.CIA59) / 100, "0.00")
                .投入量 = "資料發生錯誤無法得知!"
            End With
        Next
        Return ReturnValue

    End Function

    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search2(ByVal SQLString As String) As QualityControlDataSet.YieldRateSearchDataTable_1DataTable
        Dim ReturnValue As New QualityControlDataSet.YieldRateSearchDataTable_1DataTable
        If String.IsNullOrEmpty(SQLString) Then
            Return ReturnValue
        End If
        Dim SearchResult As List(Of PPS100LB.PPSCIAPF) = (From A In PPS100LB.PPSCIAPF.CDBSelect(Of PPS100LB.PPSCIAPF)(SQLString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC) Order By A.IsHR, A.CIA06 Descending, A.CIA05, A.CIA34, A.CIA33, A.CIA59 Select A).ToList
        Dim QryString As String = "Select * From @#PPS100LB.PPSSHAPF Where SHA01 IN (" & SQLString.Replace("*", "CIA02") & ") Order By SHA01,SHA02"
        Dim AboutAllPPSSHAPFs As New List(Of IPPS100LB.IPPSSHAPF)
        For Each EachItem In CompanyORMDB.PPS100LB.PPSSHAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSSHAPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            AboutAllPPSSHAPFs.Add(EachItem)
        Next
        Dim AS400Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim AboutAllHotRollingInOutWeights As DataTable 'LEFT(A.BLA11,1) = 'T' 才為本廠生產
        QryString = "Select A.BLA09, A.BLA06 , B.SGA24 from @#PPS100LB.PPSBLAPF AS A  Left Join @#SMS100LB.SMSSGAPF AS B ON A.BLA07= (B.sga01 || '-'  || B.sga02 || Right('0' || B.sga03,2) || B.sga04)  WHERE  LEFT(A.BLA11,1) = 'T' AND A.BLA09 IN  (" & SQLString.Replace("*", "CIA02") & ") Order By A.BLA09"
        AboutAllHotRollingInOutWeights = AS400Adapter.SelectQuery(QryString)
        Dim LossItems As New List(Of IPPS100LB.IPPSSHAPF)

        For Each Eachitem As PPS100LB.PPSCIAPF In SearchResult
            If Trim(Eachitem.CIA59) >= "080" Then
                Eachitem.CIA59 = "0.8(含以上)"
            Else
                Eachitem.CIA59 = "0.7(含以下)"
            End If
        Next

        For Each EachGroupString1 As String In (From A In SearchResult Select A.CIA06 Distinct).ToList
            For Each EachGroupString2 As String In (From A In SearchResult Where A.CIA06 = EachGroupString1 Select A.CIA34 & "@" & A.CIA33 Distinct).ToList
                For Each EachGroupString3 As String In (From A In SearchResult Where A.CIA06 = EachGroupString1 And A.CIA34 = EachGroupString2.Split("@")(0) And A.CIA33 = EachGroupString2.Split("@")(1) Select A.CIA59 Distinct).ToList
                    For Each EachGroupString4 As String In (From A In SearchResult Where A.CIA06 = EachGroupString1 And A.CIA34 = EachGroupString2.Split("@")(0) And A.CIA33 = EachGroupString2.Split("@")(1) And A.CIA59 = EachGroupString3 Select A.CIA60 Distinct).ToList
                        AddGroupData2(EachGroupString1 & "@" & EachGroupString2 & "@" & EachGroupString3 & "@" & EachGroupString4, SearchResult, ReturnValue, AboutAllPPSSHAPFs, LossItems, AboutAllHotRollingInOutWeights)
                    Next
                    'AddGroupData2(EachGroupString1 & "@" & EachGroupString2 & "@" & EachGroupString3, SearchResult, ReturnValue, AboutAllPPSSHAPFs, LossItems, AboutAllHotRollingInOutWeights)
                Next
                'AddGroupData2(EachGroupString1 & "@" & EachGroupString2, SearchResult, ReturnValue, AboutAllPPSSHAPFs, LossItems, AboutAllHotRollingInOutWeights)
            Next
            'AddGroupData2(EachGroupString1, SearchResult, ReturnValue, AboutAllPPSSHAPFs, LossItems, AboutAllHotRollingInOutWeights)
        Next


        For Each EachItem As PPS100LB.PPSCIAPF In LossItems
            Dim ADDDataRow As QualityControlDataSet.YieldRateSearchDataTable_1Row = ReturnValue.NewRow
            With ADDDataRow
                .表面 = EachItem.CIA06
                .料別 = EachItem.CIA34 & EachItem.CIA33
                '.厚度 = Format(Val(EachItem.CIA59) / 100, "0.00")
                .厚度 = EachItem.CIA59
                .寬度 = EachItem.CIA60
                .投入量 = "資料發生錯誤無法得知!"
            End With
        Next
        Return ReturnValue
    End Function

#Region "群組資料加組 函式:AddGroupData"
    Private Sub AddGroupData(ByVal GroupDataKeys As String, ByVal AllDatas As List(Of PPS100LB.PPSCIAPF), ByRef ReturnValue As QualityControlDataSet.YieldRateSearchDataTableDataTable, ByVal SetAboutAllPPSSHAPFs As List(Of IPPS100LB.IPPSSHAPF), ByRef ErrorDatas As List(Of IPPS100LB.IPPSSHAPF), ByVal AllHotRollingInOutWeightDatas As DataTable)
        Dim KeyValues() As String = GroupDataKeys.Split("@")
        Dim GroupDatas As New List(Of PPS100LB.PPSCIAPF)
        Select Case True
            Case KeyValues.Count = 1
                GroupDatas = (From A In AllDatas Where A.CIA06 = KeyValues(0) Select A).ToList
            Case KeyValues.Count = 2
                GroupDatas = (From A In AllDatas Where A.CIA06 = KeyValues(0) And A.CIA05 = KeyValues(1) Select A).ToList
            Case KeyValues.Count = 3
                GroupDatas = (From A In AllDatas Where A.CIA06 = KeyValues(0) And A.CIA05 = KeyValues(1) And A.CIA34 = KeyValues(2) Select A).ToList
            Case KeyValues.Count = 4
                GroupDatas = (From A In AllDatas Where A.CIA06 = KeyValues(0) And A.CIA05 = KeyValues(1) And A.CIA34 = KeyValues(2) And A.CIA33 = KeyValues(3) Select A).ToList
            Case KeyValues.Count = 5
                GroupDatas = (From A In AllDatas Where A.CIA06 = KeyValues(0) And A.CIA05 = KeyValues(1) And A.CIA34 = KeyValues(2) And A.CIA33 = KeyValues(3) And A.CIA59 = KeyValues(4) Select A).ToList
        End Select

        Dim InputWeight As Double = 0
        Dim InputWeightTemp As Double = 0
        Dim OutputWeight As Double = 0
        Dim L1OutputWeight As Double = 0
        For Each EachItem As PPS100LB.PPSCIAPF In GroupDatas
            Dim EachItemTemp As PPS100LB.PPSCIAPF = EachItem
            Dim NewFlowAdapter As New CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter(EachItem.CIA02.Trim & EachItem.CIA03.Trim, SQLServer.PPS100LB.PPSSHAPFFlowAdapter.FinalALLPPSSHAPFsModeEnum.AS400Only)
            InputWeightTemp = CType((New CoilYieldRateCompute(EachItemTemp, (From A In SetAboutAllPPSSHAPFs Where A.SHA01 = EachItemTemp.CIA02 Select A).ToList)).InputWeight, Long) ' GetInputWeight(EachItem, SetAboutAllPPSSHAPFs)
            If InputWeightTemp = "-1" Then
                ErrorDatas.Add(EachItem)
                Continue For
            Else
                InputWeight += InputWeightTemp
            End If
            OutputWeight += EachItem.CIA13 '淨重
            L1OutputWeight += EachItem.CIA23
        Next
        Dim ADDDataRow As QualityControlDataSet.YieldRateSearchDataTableRow = ReturnValue.NewRow
        Dim AboutHotRollingInOutWeightDatas As List(Of DataRow) = (From A In AllHotRollingInOutWeightDatas Where (From B In GroupDatas Select B.CIA02).ToList.Contains(CType(A.Item("BLA09"), String)) Select A).ToList
        With ADDDataRow
            If KeyValues.Count > 0 Then
                .表面 = KeyValues(0)
            End If
            If KeyValues.Count > 1 Then
                .鋼種 = KeyValues(1)
            End If
            If KeyValues.Count > 2 Then
                .料別 = KeyValues(2) & KeyValues(3)
            End If
            If KeyValues.Count > 4 Then
                .厚度 = Format(Val(KeyValues(4)) / 100, "0.00")
            End If
            .投入量 = InputWeight
            .產出量 = OutputWeight
            .產出率 = Format(Val(.產出量) / Val(.投入量), "0.00%")
            .一級品率 = Format(L1OutputWeight / Val(.產出量), "0.00%")
            .熱軋投入量 = Format((From A In AboutHotRollingInOutWeightDatas Where Not IsDBNull(A.Item("SGA24")) Select Val(A.Item("SGA24"))).Sum, "0")
            .熱軋產出量 = Format((From A In AboutHotRollingInOutWeightDatas Where Not IsDBNull(A.Item("BLA06")) Select Val(A.Item("BLA06"))).Sum, "0")
            .熱軋產出率 = Format(Val(.熱軋產出量) / Val(.熱軋投入量), "0.00%")
        End With
        ReturnValue.Rows.Add(ADDDataRow)

    End Sub
#End Region
#Region "群組資料加組 函式:AddGroupData2"
    Private Sub AddGroupData2(ByVal GroupDataKeys As String, ByVal AllDatas As List(Of PPS100LB.PPSCIAPF), ByRef ReturnValue As QualityControlDataSet.YieldRateSearchDataTable_1DataTable, ByVal SetAboutAllPPSSHAPFs As List(Of IPPS100LB.IPPSSHAPF), ByRef ErrorDatas As List(Of IPPS100LB.IPPSSHAPF), ByVal AllHotRollingInOutWeightDatas As DataTable)
        Dim KeyValues() As String = GroupDataKeys.Split("@")
        Dim GroupDatas As New List(Of PPS100LB.PPSCIAPF)
        Select Case True
            Case KeyValues.Count = 1
                GroupDatas = (From A In AllDatas Where A.CIA06 = KeyValues(0) Select A).ToList
            Case KeyValues.Count = 2
                'GroupDatas = (From A In AllDatas Where A.CIA06 = KeyValues(0) And A.CIA05 = KeyValues(1) Select A).ToList
                GroupDatas = (From A In AllDatas Where A.CIA06 = KeyValues(0) And A.CIA34 = KeyValues(1) Select A).ToList
            Case KeyValues.Count = 3
                GroupDatas = (From A In AllDatas Where A.CIA06 = KeyValues(0) And A.CIA34 = KeyValues(1) And A.CIA33 = KeyValues(2) Select A).ToList
            Case KeyValues.Count = 4
                GroupDatas = (From A In AllDatas Where A.CIA06 = KeyValues(0) And A.CIA34 = KeyValues(1) And A.CIA33 = KeyValues(2) And A.CIA59 = KeyValues(3) Select A).ToList
            Case KeyValues.Count = 5
                GroupDatas = (From A In AllDatas Where A.CIA06 = KeyValues(0) And A.CIA34 = KeyValues(1) And A.CIA33 = KeyValues(2) And A.CIA59 = KeyValues(3) And A.CIA60 = KeyValues(4) Select A).ToList
        End Select

        Dim InputWeight As Double = 0
        Dim InputWeightTemp As Double = 0
        Dim OutputWeight As Double = 0
        Dim L1OutputWeight As Double = 0
        For Each EachItem As PPS100LB.PPSCIAPF In GroupDatas
            Dim EachItemTemp As PPS100LB.PPSCIAPF = EachItem
            Dim NewFlowAdapter As New CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter(EachItem.CIA02.Trim & EachItem.CIA03.Trim, SQLServer.PPS100LB.PPSSHAPFFlowAdapter.FinalALLPPSSHAPFsModeEnum.AS400Only)
            InputWeightTemp = CType((New CoilYieldRateCompute(EachItemTemp, (From A In SetAboutAllPPSSHAPFs Where A.SHA01 = EachItemTemp.CIA02 Select A).ToList)).InputWeight, Long) ' GetInputWeight(EachItem, SetAboutAllPPSSHAPFs)
            If InputWeightTemp = "-1" Then
                ErrorDatas.Add(EachItem)
                Continue For
            Else
                InputWeight += InputWeightTemp
            End If
            OutputWeight += EachItem.CIA13 '淨重
            L1OutputWeight += EachItem.CIA23
        Next
        Dim ADDDataRow As QualityControlDataSet.YieldRateSearchDataTable_1Row = ReturnValue.NewRow
        Dim AboutHotRollingInOutWeightDatas As List(Of DataRow) = (From A In AllHotRollingInOutWeightDatas Where (From B In GroupDatas Select B.CIA02).ToList.Contains(CType(A.Item("BLA09"), String)) Select A).ToList
        With ADDDataRow
            If KeyValues.Count > 0 Then
                .表面 = KeyValues(0)
            End If
            If KeyValues.Count > 2 Then
                .料別 = KeyValues(1) & KeyValues(2)
            End If
            If KeyValues.Count > 3 Then
                '.厚度 = Format(Val(KeyValues(3)) / 100, "0.00")
                .厚度 = KeyValues(3)
            End If
            If KeyValues.Count > 4 Then
                .寬度 = KeyValues(4)
            End If

            .投入量 = InputWeight
            .產出量 = OutputWeight
            .產出率 = Format(Val(.產出量) / Val(.投入量), "0.00%")
            .一級品率 = Format(L1OutputWeight / Val(.產出量), "0.00%")
            .熱軋投入量 = Format((From A In AboutHotRollingInOutWeightDatas Where Not IsDBNull(A.Item("SGA24")) Select Val(A.Item("SGA24"))).Sum, "0")
            .熱軋產出量 = Format((From A In AboutHotRollingInOutWeightDatas Where Not IsDBNull(A.Item("BLA06")) Select Val(A.Item("BLA06"))).Sum, "0")
            .熱軋產出率 = Format(Val(.熱軋產出量) / Val(.熱軋投入量), "0.00%")
        End With
        ReturnValue.Rows.Add(ADDDataRow)

    End Sub
#End Region

#End Region

#Region "設定查詢條件至控制項 屬性:SetQryStringToControl"
    ''' <summary>
    ''' 設定查詢條件至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetQryStringToControl()
        Dim ReturnValue As String = "Select * From @#PPS100LB.PPSCIAPF WHERE 1=1 "
        'Dim ReturnValue As String = "Select * From @#PPS100LB.PPSCIAPF WHERE 1=1 and cia02='H6474' "

        Dim StartDate As DateTime = CType(Me.tbStartDate.Text, DateTime)
        Dim EndDate As DateTime = CType(Me.tbEndDate.Text, DateTime)
        Dim StartDateValue As Integer = (Val(Format(StartDate, "yyyy")) - 1911) * 10000 + Val(Format(StartDate, "MMdd"))
        Dim EndDateValue As Integer = (Val(Format(EndDate, "yyyy")) - 1911) * 10000 + Val(Format(EndDate, "MMdd"))
        If ddsSearchDateMode.Text = "會計日期" Then
            ReturnValue &= " AND CIA58>=" & StartDateValue & " AND CIA58<=" & EndDateValue
        Else
            ReturnValue &= " AND CIA55>=" & StartDateValue & " AND CIA55<=" & EndDateValue
        End If
        ReturnValue &= " AND ( CIA06 = 'BA' OR CIA06 = '2B' OR CIA06 = 'NO1' OR CIA06 = 'SH' OR CIA06 = '2D' )"
        Me.hfSQLString.Value = ReturnValue
    End Sub
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim StartDate As DateTime = New Date(Now.Year, Now.Month, 1)
            Dim EndDate As DateTime = New Date(Now.Year, Now.Month, 1)
            tbStartDate.Text = Format(Now, "yyyy/MM/01")
            tbEndDate.Text = Format(Now, "yyyy/MM/dd")
            'tbStartDate.Text = "2010/10/01"
            'tbEndDate.Text = "2010/10/31"
        End If
    End Sub

    Protected Sub tbSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearch.Click
        SetQryStringToControl()
        Me.MultiView1.ActiveViewIndex = RadioButtonList1.SelectedValue
        Select Case True
            Case RadioButtonList1.SelectedValue = "0"
                GridView1.DataBind()
            Case RadioButtonList1.SelectedValue = "1"
                GridView2.DataBind()
            Case RadioButtonList1.SelectedValue = "2"
                GridView3.DataBind()
        End Select

    End Sub


    Protected Sub tbSearchToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbSearchToExcel.Click
        SetQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = Nothing
        Select Case True
            Case RadioButtonList1.SelectedValue = "0"
                Dim SearchResult As DataTable = Search(Me.hfSQLString.Value)
                SearchResult.Columns.Remove("鋼捲號碼")
                ExcelConvert = New PublicClassLibrary.DataConvertExcel(SearchResult, "鋼捲產出率查詢" & Format(Now, "mmss") & ".xls")
            Case RadioButtonList1.SelectedValue = "1"
                ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search0(Me.hfSQLString.Value), "鋼捲產出率查詢" & Format(Now, "mmss") & ".xls")
            Case RadioButtonList1.SelectedValue = "2"
                ExcelConvert = New PublicClassLibrary.DataConvertExcel(Search2(Me.hfSQLString.Value), "鋼捲產出率查詢" & Format(Now, "mmss") & ".xls")
        End Select

        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub

End Class