Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices.Marshal

Partial Public Class AgencyStockStatic
    Inherits System.Web.UI.UserControl

#Region "查詢 函式:Search1"
    '<DataObjectMethod(DataObjectMethodType.Select)> _
    'Public Function Search1(ByVal QryString As String, ByVal CCMQry As String, ByVal SGMQry As String) As StockStatic.DisplayDataSet.DisplayDataTable1DataTable

    'End Function

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search1(ByVal QryString As String, ByVal CCMQry As String, ByVal SGMQry As String) As StockStatic.DisplayDataSet.DisplayDataTable1DataTable
        Dim ReturnValue As New StockStatic.DisplayDataSet.DisplayDataTable1DataTable
        If String.IsNullOrEmpty(QryString) Then
            Return ReturnValue
        End If

        Dim DBAdapter = New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim SearchResult As DataTable = DBAdapter.SelectQuery(QryString)
        Dim TotalGroupDatas As New List(Of ItemData)
        Dim FinalTotalGroupDatas As New List(Of ItemData)
        Dim TotalGroupCahageKey As String = Nothing
        Dim AddItem As StockStatic.DisplayDataSet.DisplayDataTable1Row
        For Each EachItem As ItemData In (From B In ItemData.GroupDataItems((From A In SearchResult Select A).ToList) Select B Order By B.SteelKind, B.MaterialKind, B.Width, B.LengthLevelNumber).ToList
            If Not IsNothing(TotalGroupCahageKey) AndAlso TotalGroupCahageKey <> (EachItem.SteelKind & EachItem.MaterialKind & EachItem.Width) Then
                AddDisplayTotalItem(TotalGroupDatas, ReturnValue, "小計:")
                TotalGroupDatas.Clear()
            Else
                TotalGroupDatas.Add(EachItem)
            End If
            TotalGroupCahageKey = EachItem.SteelKind & EachItem.MaterialKind & EachItem.Width
            FinalTotalGroupDatas.Add(EachItem)
            AddItem = ReturnValue.NewRow
            With AddItem
                .計劃代軋量 = ""
                .尺寸 = EachItem.ShowTitle
                .數量小計 = EachItem.CountSum
                .未研磨數量 = EachItem.NoProcessCount
                .已研磨未繳庫數量 = EachItem.ProcessNoToStockCount
                .繳庫數量 = EachItem.ToStockCount
                .重量小計 = EachItem.WeightSum
                .未研磨重量 = EachItem.NoProcessWeight
                .已研磨未繳庫重量 = EachItem.ProcessNoToStockWeight
                .繳庫重量 = EachItem.ToStockWeight
            End With
            ReturnValue.Rows.Add(AddItem)
        Next
        AddDisplayTotalItem(FinalTotalGroupDatas, ReturnValue, "合計:")

        '加入顯示累計量
        Dim CCMQryResult As DataTable = DBAdapter.SelectQuery(CCMQry)
        AddItem = ReturnValue.NewRow
        AddItem.尺寸 = "CCM月累計量:"
        AddItem.計劃代軋量 = (From A In CCMQryResult Select CType(A.Item("SGA14"), Double)).Sum
        ReturnValue.Rows.Add(AddItem)
        AddItem = ReturnValue.NewRow
        AddItem.尺寸 = "CCM研磨後月累計量:"
        'AddItem.計劃代軋量 = (From A In CCMQryResult Select CType(A.Item("SGA24"), Double)).Sum
        AddItem.計劃代軋量 = (From A In CCMQryResult Where CType(A.Item("SGA24"), Double) = 0 Select CType(A.Item("SGA14"), Double)).Sum + (From A In CCMQryResult Where CType(A.Item("SGA24"), Double) > 0 Select CType(A.Item("SGA24"), Double)).Sum
        ReturnValue.Rows.Add(AddItem)
        AddItem = ReturnValue.NewRow
        AddItem.尺寸 = "CCM研磨前月累計量:"
        AddItem.計劃代軋量 = (From A In CCMQryResult Where CType(A.Item("SGA15"), Double) = 0 Select CType(A.Item("SGA14"), Double)).Sum + (From A In CCMQryResult Where CType(A.Item("SGA15"), Double) > 0 Select CType(A.Item("SGA15"), Double)).Sum
        ReturnValue.Rows.Add(AddItem)
        Dim SGMQryResult As DataTable = DBAdapter.SelectQuery(SGMQry)
        AddItem = ReturnValue.NewRow
        AddItem.尺寸 = "SGM月累計量:"
        AddItem.計劃代軋量 = (From A In SGMQryResult Select CType(A.Item("SGA24"), Double)).Sum
        ReturnValue.Rows.Add(AddItem)
        'For Each EachItem As StockStatic.DisplayDataSet.DisplayDataTable1Row In ReturnValue.Rows
        '    With EachItem
        '        If .計劃代軋量 <> "" Then
        '            .計劃代軋量 = Format(Val(.計劃代軋量), "#,#")
        '        End If
        '        .數量小計 = Format(Val(.數量小計), "#,#")
        '        .重量小計 = Format(Val(.重量小計), "#,#")
        '        .未研磨數量 = Format(Val(.未研磨數量), "#,#")
        '        .未研磨重量 = Format(Val(.未研磨重量), "#,#")
        '        .已研磨未繳庫數量 = Format(Val(.已研磨未繳庫數量), "#,#")
        '        .已研磨未繳庫重量 = Format(Val(.已研磨未繳庫重量), "#,#")
        '        .繳庫數量 = Format(Val(.繳庫數量), "#,#")
        '        .繳庫重量 = Format(Val(.繳庫重量), "#,#")
        '    End With
        'Next
        Return ReturnValue
    End Function

    Private Sub AddDisplayTotalItem(ByVal GroupDatas As List(Of ItemData), ByVal AddTargetDataSource As StockStatic.DisplayDataSet.DisplayDataTable1DataTable, ByVal ShowTitle As String)
        Dim AddItem As StockStatic.DisplayDataSet.DisplayDataTable1Row = AddTargetDataSource.NewRow
        With AddItem
            .尺寸 = ShowTitle
            .數量小計 = (From A In GroupDatas Select A.CountSum).Sum
            .未研磨數量 = (From A In GroupDatas Select A.NoProcessCount).Sum
            .已研磨未繳庫數量 = (From A In GroupDatas Select A.ProcessNoToStockCount).Sum
            .繳庫數量 = (From A In GroupDatas Select A.ToStockCount).Sum
            .重量小計 = (From A In GroupDatas Select A.WeightSum).Sum
            .未研磨重量 = (From A In GroupDatas Select A.NoProcessWeight).Sum
            .已研磨未繳庫重量 = (From A In GroupDatas Select A.ProcessNoToStockWeight).Sum
            .繳庫重量 = (From A In GroupDatas Select A.ToStockWeight).Sum
        End With
        AddTargetDataSource.Rows.Add(AddItem)
    End Sub


#Region "單筆顯示項目資料群組 結構:ItemData"
    ''' <summary>
    ''' 單筆顯示項目資料群組
    ''' </summary>
    ''' <remarks></remarks>
    Private Class ItemData
        Public SteelKind As String
        Public MaterialKind As String
        Public Width As Double
        Public Length As Double
        Public LengthRangeStart As Double
        Public LengthRangeEnd As Double
        Public GroupDatas As New List(Of DataRow)

        Private Sub New(ByVal SourceDatarow As DataRow)
            Me.SteelKind = CType(SourceDatarow.Item("SGA05"), String).Trim
            Me.MaterialKind = CType(SourceDatarow.Item("SGA06"), String).Trim
            Me.Width = CType(SourceDatarow.Item("SGA09"), Double)
            If SourceDatarow("SGA35") = "A" OrElse SourceDatarow("SGA35") = " " OrElse Val(SourceDatarow("SGA18")) = 0 Then
                Me.Length = Val(SourceDatarow("SGA08")) '研磨中長度
            Else
                Me.Length = Val(SourceDatarow("SGA18")) '研磨後長度 EachItem("SGA35") = "B"
            End If
            GroupDatas.Add(SourceDatarow)
        End Sub

#Region "重量小計 屬性:WeightSum"
        ReadOnly Property WeightSum As Double
            Get
                Return NoProcessWeight + ProcessNoToStockWeight + ToStockWeight
            End Get
        End Property
#End Region
#Region "未研磨重量 屬性:NoProcessWeight"
        ReadOnly Property NoProcessWeight As Double
            Get
                Dim ReturnValue As Double = 0
                For Each EachItem As DataRow In (From A In GroupDatas Where CType(A.Item("SGA35"), String) = " " Select A).ToList
                    If Val(EachItem.Item("SGA15")) = 0 Then
                        ReturnValue += Val(EachItem.Item("SGA14"))
                    Else
                        ReturnValue += Val(EachItem.Item("SGA15"))
                    End If
                Next
                Return ReturnValue
            End Get
        End Property
#End Region
#Region "已研磨未繳庫重量 屬性:ProcessNoToStockWeight"
        ReadOnly Property ProcessNoToStockWeight As Double
            Get
                Dim ReturnValue As Double = 0
                For Each EachItem As DataRow In (From A In GroupDatas Where CType(A.Item("SGA35"), String) = "A" Select A).ToList
                    If Val(EachItem.Item("SGA24")) = 0 Then
                        ReturnValue += Val(EachItem.Item("SGA15"))
                    Else
                        ReturnValue += Val(EachItem.Item("SGA24"))
                    End If
                Next
                Return ReturnValue
            End Get
        End Property
#End Region
#Region "已繳庫重量 屬性:ToStockWeight"
        ReadOnly Property ToStockWeight As Double
            Get
                Return (From A In GroupDatas Where CType(A.Item("SGA35"), String) = "B" Select CType(A.Item("SGA24"), Double)).Sum
            End Get
        End Property
#End Region


#Region "數量小計 屬性:CountSum"
        ReadOnly Property CountSum As Integer
            Get
                Return NoProcessCount + ProcessNoToStockCount + ToStockCount
            End Get
        End Property
#End Region
#Region "未研磨數量 屬性:NoProcessCount"
        ReadOnly Property NoProcessCount As Double
            Get
                Return (From A In GroupDatas Where CType(A.Item("SGA35"), String) = " " Select A).Count
            End Get
        End Property
#End Region
#Region "已研磨未繳庫數量 屬性:ProcessNoToStockCount"
        ReadOnly Property ProcessNoToStockCount As Double
            Get
                Return (From A In GroupDatas Where CType(A.Item("SGA35"), String) = "A" Select A).Count
            End Get
        End Property
#End Region
#Region "已繳庫數量 屬性:ToStockCount"
        ReadOnly Property ToStockCount As Double
            Get
                Return (From A In GroupDatas Where CType(A.Item("SGA35"), String) = "B" Select A).Count
            End Get
        End Property
#End Region


        Shared Function GroupDataItems(ByVal SourceDatas As List(Of DataRow)) As List(Of ItemData)
            Dim ReturnValue As New Dictionary(Of String, ItemData)

            Dim SteelKindGroupDatas As List(Of DataRow) = Nothing
            Dim MaterialKindGroupDatas As List(Of DataRow) = Nothing
            Dim WidthGroupDatas As List(Of DataRow) = Nothing
            Dim LengthGroupDatas As List(Of DataRow) = Nothing

            For Each EachSteelKind As String In (From A In SourceDatas Select CType(A.Item("SGA05"), String).Trim Distinct).ToList
                Dim EachSteelKindTemp As String = EachSteelKind
                SteelKindGroupDatas = (From A In SourceDatas Where CType(A.Item("SGA05"), String).Trim = EachSteelKindTemp Select A).ToList
                For Each EachMaterialKind As String In (From A In SteelKindGroupDatas Select CType(A.Item("SGA06"), String).Trim Distinct).ToList
                    Dim EachMaterialKindTemp As String = EachMaterialKind
                    MaterialKindGroupDatas = (From A In SteelKindGroupDatas Where CType(A.Item("SGA06"), String).Trim = EachMaterialKindTemp Select A).ToList
                    For Each EachWidth As Double In (From A In MaterialKindGroupDatas Select CType(A.Item("SGA09"), Double) Distinct).ToList
                        Dim EachWidthTemp As Double = EachWidth
                        WidthGroupDatas = (From A In MaterialKindGroupDatas Where CType(A.Item("SGA09"), Double) = EachWidthTemp Select A).ToList
                        For Each EachItem As DataRow In WidthGroupDatas
                            Dim AddItem As New ItemData(EachItem)
                            Dim AddItemKey As String = AddItem.SteelKind & AddItem.MaterialKind & AddItem.Width & AddItem.LengthLevelNumber
                            If ReturnValue.ContainsKey(AddItemKey) Then
                                ReturnValue.Item(AddItemKey).GroupDatas.Add(EachItem)
                            Else
                                ReturnValue.Add(AddItemKey, AddItem)
                            End If
                        Next
                    Next
                Next
            Next

            Return ReturnValue.Values.ToList
        End Function

        ReadOnly Property ShowTitle As String
            Get
                Dim ReturnValue As String = Me.SteelKind.Trim

                If Not String.IsNullOrEmpty(MaterialKind) AndAlso MaterialKind.Trim <> "" Then
                    '鋼種+材質
                    ReturnValue = Left(MaterialKind, 2) & ReturnValue
                    If MaterialKind.Length >= 3 Then
                        ReturnValue &= "-" & Right(MaterialKind, 1)
                    End If
                End If
                ReturnValue &= "寬:" & Width.ToString.Trim & " " & LengthLevelString
                Return ReturnValue
            End Get
        End Property

        Public ReadOnly Property LengthLevelNumber As Integer
            Get
                If SteelKind.Substring(0, 1) = "3" Then
                    '300系專用
                    'If Width = 1020 OrElse Width = 945 Then
                    If Width <= 1040 Then
                        Select Case True
                            Case Length >= 7000 AndAlso Length <= 8400
                                Return 1
                            Case Length > 8400 AndAlso Length <= 9000
                                Return 2
                            Case Length > 9000 AndAlso Length <= 9200
                                Return 3
                            Case Length > 9200 AndAlso Length <= 9600
                                Return 4
                            Case Length > 9600
                                Return 5
                        End Select
                    Else
                        Select Case True
                            Case Length >= 7000 AndAlso Length <= 7400
                                Return 1
                            Case Length > 7400 AndAlso Length <= 8000
                                Return 2
                            Case Length > 8000 AndAlso Length <= 8600
                                Return 3
                            Case Length > 8600 AndAlso Length <= 9200
                                Return 4
                            Case Length > 9200 AndAlso Length <= 9600
                                Return 5
                            Case Length > 9600
                                Return 6
                        End Select
                    End If
                Else
                    Select Case True
                        Case Length >= 7000 AndAlso Length <= 7400
                            Return 1
                        Case Length > 7400 AndAlso Length <= 7800
                            Return 2
                        Case Length > 7800 AndAlso Length <= 8600
                            Return 3
                        Case Length > 8600 AndAlso Length <= 9200
                            Return 4
                        Case Length > 9200 AndAlso Length <= 9600
                            Return 5
                        Case Length > 9600
                            Return 6
                    End Select
                End If
                Return -1
            End Get
        End Property

        Public ReadOnly Property LengthLevelString As String
            Get
                Dim ReturnValue As String = Nothing
                If SteelKind.Substring(0, 1) = "3" Then
                    '300系專用
                    'If Width = 1020 OrElse Width = 945 Then
                    If Width <= 1040 Then
                        Select Case LengthLevelNumber
                            Case 1
                                ReturnValue &= "(7.00M~8.40M)"
                            Case 2
                                ReturnValue &= "(8.41M~9.00M)"
                            Case 3
                                ReturnValue &= "(9.01M~9.20M)"
                            Case 4
                                ReturnValue &= "(9.21M~9.60M)"
                            Case 5
                                ReturnValue &= "(9.60M以上)"
                        End Select
                    Else
                        Select Case LengthLevelNumber
                            Case 1
                                ReturnValue &= "中一(7.00M~7.40M)"
                            Case 2
                                ReturnValue &= "中一(7.41M~8.00M)"
                            Case 3
                                ReturnValue &= "中二(8.01M~8.60M)"
                            Case 4
                                ReturnValue &= "中三(8.60M~9.20M)"
                            Case 5
                                ReturnValue &= "中四(9.21M~9.60M)"
                            Case 6
                                ReturnValue &= "(9.60M以上)"
                        End Select
                    End If

                Else
                    Select Case LengthLevelNumber
                        Case 1
                            ReturnValue &= "中一(7.00M~7.40M)"
                        Case 2
                            ReturnValue &= "中一(7.41M~7.80M)"
                        Case 3
                            ReturnValue &= "中二(7.81M~8.60M)"
                        Case 4
                            ReturnValue &= "中三(8.60M~9.20M)"
                        Case 5
                            ReturnValue &= "中四(9.21M~9.60M)"
                        Case 6
                            ReturnValue &= "(9.60M以上)"
                    End Select
                End If
                Return ReturnValue
            End Get
        End Property
    End Class
#End Region

#End Region

#Region "查詢 函式:Search0"
    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="QryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search0(ByVal QryString As String) As StockStatic.DisplayDataSet.DisplayDataTableDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return New StockStatic.DisplayDataSet.DisplayDataTableDataTable
        End If
        Dim ShowDataSet As New StockStatic.DisplayDataSet.DisplayDataTableDataTable
        Dim TempDataSet As New DataSet
        Dim DBAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        TempDataSet.Tables.Add(DBAdapter.SelectQuery(QryString)) : TempDataSet.Tables(0).TableName = "Temp"


        Dim NowUserSteelKind As String = Nothing
        Dim LastUserTableRow As DataRow = Nothing
        For Each EachItem As DataRow In (From A In AddJudgeSortColumn(TempDataSet.Tables("Temp")) Select A Order By A.Item("SGA05"), A.Item("SGA06"), A.Item("SGA09"), A.Item("SortColumn1"))
            NowUserSteelKind = GetField1String(EachItem)
            If IsNothing(NowUserSteelKind) Then
                Continue For
            End If

            If IsNothing(LastUserTableRow) OrElse LastUserTableRow.Item("鋼種尺寸") <> NowUserSteelKind Then
                LastUserTableRow = ShowDataSet.NewDisplayDataTableRow
                LastUserTableRow.Item("鋼種尺寸") = NowUserSteelKind
                LastUserTableRow.Item("鋼種") = EachItem.Item("SGA05")
                LastUserTableRow.Item("材質") = EachItem.Item("SGA06")
                LastUserTableRow.Item("寬度") = EachItem.Item("SGA09")
                DisplayGroupEndSum(LastUserTableRow.Item("鋼種"), LastUserTableRow.Item("材質"), LastUserTableRow.Item("寬度"), False, ShowDataSet)
                ShowDataSet.Rows.Add(LastUserTableRow)
            End If

            With LastUserTableRow
                Select Case CType(EachItem.Item("SGA35"), String)
                    Case " "
                        .Item("未研磨數量") += 1
                        .Item("未研磨重量") += IIf(Val(EachItem.Item("SGA15")) = 0, Val(EachItem.Item("SGA14")), Val(EachItem.Item("SGA15")))
                    Case "A"
                        .Item("已研磨未繳庫數量") += 1
                        .Item("已研磨未繳庫重量") += IIf(Val(EachItem.Item("SGA24")) = 0, Val(EachItem.Item("SGA15")), Val(EachItem.Item("SGA24")))
                    Case "B"
                        .Item("繳庫數量") += 1
                        .Item("繳庫重量") += Val(EachItem.Item("SGA24"))
                End Select
                .Item("重量小計") = .Item("未研磨重量") + .Item("已研磨未繳庫重量") + .Item("繳庫重量")
                .Item("數量小計") += 1

                Select Case True
                    Case CType(EachItem.Item("SGA36"), String).Trim = "T" And CType(EachItem.Item("SGA35"), String) = "B"
                        .Item("中鋼代工數量") += 1
                        .Item("中鋼代工重量") += Val(EachItem.Item("SGA24"))
                    Case CType(EachItem.Item("SGA36"), String).Trim = "Y" And CType(EachItem.Item("SGA35"), String) = "B"
                        .Item("燁聯代工數量") += 1
                        .Item("燁聯代工重量") += Val(EachItem.Item("SGA24"))
                    Case CType(EachItem.Item("SGA35"), String) = "B"
                        .Item("其它代工數量") += 1
                        .Item("其它代工重量") += Val(EachItem.Item("SGA24"))
                End Select
            End With
        Next
        If Not IsNothing(LastUserTableRow) Then
            DisplayGroupEndSum(LastUserTableRow.Item("鋼種"), LastUserTableRow.Item("材質"), LastUserTableRow.Item("寬度"), True, ShowDataSet)
        End If
        DisplayEndSum(ShowDataSet)
        Return ShowDataSet
    End Function


    Private Function GetField1String(ByVal SetDataRow As DataRow) As String
        Dim ReturnValue As String = Nothing
        Dim GetSGA05 As String = CType(SetDataRow("SGA05"), String).Trim
        If String.IsNullOrEmpty(GetSGA05) OrElse GetSGA05.Trim = "" Then
            Return ReturnValue
        End If
        ReturnValue = GetSGA05  '鋼種

        Dim GetSGA06 As String = CType(SetDataRow("SGA06"), String).Trim
        If Not String.IsNullOrEmpty(GetSGA06) AndAlso GetSGA06.Trim <> "" Then
            '鋼種+材質
            ReturnValue = Left(GetSGA06, 2) & GetSGA05
            If GetSGA06.Length >= 3 Then
                ReturnValue &= "-" & Right(GetSGA06, 1)
            End If
        End If

        Dim SetWith As Long = Val(SetDataRow("SGA09"))
        ReturnValue = IIf(IsNothing(SetWith), ReturnValue, ReturnValue & " 寬:" & SetWith & "m") '鋼種+材質+寬度

        '鋼種+材質+寬度+長度
        Dim SetSize As Long
        If SetDataRow("SGA35") = "A" OrElse SetDataRow("SGA35") = " " OrElse Val(SetDataRow("SGA18")) = 0 Then
            SetSize = Val(SetDataRow("SGA08")) '研磨中長度
        Else
            SetSize = Val(SetDataRow("SGA18")) '研磨後長度 EachItem("SGA35") = "B"
        End If
        If CType(SetDataRow("SGA05"), String).Trim.Substring(0, 1) = "3" Then
            '300系專用
            'If CType(SetDataRow("SGA09"), Integer) = 1020 OrElse CType(SetDataRow("SGA09"), Integer) = 945 Then
            If CType(SetDataRow("SGA09"), Integer) <= 1040 Then
                Select Case True
                    Case SetSize >= 7000 AndAlso SetSize <= 8400
                        ReturnValue &= "(7.00M~8.40M)"
                    Case SetSize > 8400 AndAlso SetSize <= 9000
                        ReturnValue &= "(8.41M~9.00M)"
                    Case SetSize > 9000 AndAlso SetSize <= 9200
                        ReturnValue &= "(9.01M~9.20M)"
                    Case SetSize > 9200 AndAlso SetSize <= 9600
                        ReturnValue &= "(9.21M~9.60M)"
                    Case SetSize > 9600
                        ReturnValue &= "(9.60M以上)"
                End Select
            Else
                Select Case True
                    Case SetSize >= 7000 AndAlso SetSize <= 7400
                        ReturnValue &= "中一(7.00M~7.40M)"
                    Case SetSize > 7400 AndAlso SetSize <= 8000
                        ReturnValue &= "中一(7.41M~8.00M)"
                    Case SetSize > 8000 AndAlso SetSize <= 8600
                        ReturnValue &= "中二(8.01M~8.60M)"
                    Case SetSize > 8600 AndAlso SetSize <= 9200
                        ReturnValue &= "中三(8.60M~9.20M)"
                    Case SetSize > 9200 AndAlso SetSize <= 9600
                        ReturnValue &= "中四(9.21M~9.60M)"
                    Case SetSize > 9600
                        ReturnValue &= "(9.60M以上)"
                End Select
            End If
        Else
            Select Case True
                Case SetSize >= 7000 AndAlso SetSize <= 7400
                    ReturnValue &= "中一(7.00M~7.40M)"
                Case SetSize > 7400 AndAlso SetSize <= 7800
                    ReturnValue &= "中一(7.41M~7.80M)"
                Case SetSize > 7800 AndAlso SetSize <= 8600
                    ReturnValue &= "中二(7.81M~8.60M)"
                Case SetSize > 8600 AndAlso SetSize <= 9200
                    ReturnValue &= "中三(8.60M~9.20M)"
                Case SetSize > 9200 AndAlso SetSize <= 9600
                    ReturnValue &= "中四(9.21M~9.60M)"
                Case SetSize > 9600
                    ReturnValue &= "(9.60M以上)"
            End Select
        End If
        Return ReturnValue
    End Function

    Private Function AddJudgeSortColumn(ByVal SourceDataTable As DataTable) As DataTable
        Dim ReturnValue As DataTable = SourceDataTable
        Dim NewView As DataView = New DataView(SourceDataTable)
        ReturnValue.Columns.Add(New DataColumn("SortColumn1", GetType(Long)))
        For Each EachRow As DataRow In SourceDataTable.Rows
            If EachRow("SGA35") = "A" OrElse EachRow("SGA35") = " " OrElse Val(EachRow("SGA18")) = 0 Then
                EachRow("SortColumn1") = Val(EachRow("SGA08")) '研磨中長度
            Else
                EachRow("SortColumn1") = Val(EachRow("SGA18")) '研磨後長度 EachItem("SGA35") = "B"
            End If
        Next

        'For Each EachItem As DataRow In From A In SourceDataTable Select A Order By A.Item("SGA05"), A.Item("SGA06"), A.Item("SGA09"), A.Item("SortColumn1")
        '    ReturnValue.Rows.Add(EachItem)
        'Next

        Return ReturnValue
    End Function

    Private Sub DisplayGroupEndSum(ByVal SteelKind As String, ByVal SteelMaterialAttribute As String, ByVal SteelWith As Long, ByVal IsFinalRecord As Boolean, ByVal SourceDataSet As StockStatic.DisplayDataSet.DisplayDataTableDataTable)
        Static OldSteelKind As String = Nothing
        Static OldSteelMaterialAttribute As String = Nothing
        Static OldSteelWith As Long = 0
        Static IsDifferentPreValue As Boolean = False
        If IsNothing(OldSteelKind) And IsNothing(OldSteelMaterialAttribute) And OldSteelWith = 0 Then
            OldSteelKind = SteelKind
            OldSteelMaterialAttribute = SteelMaterialAttribute
            OldSteelWith = SteelWith
        Else
            IsDifferentPreValue = (OldSteelKind <> SteelKind OrElse OldSteelMaterialAttribute <> SteelMaterialAttribute OrElse OldSteelWith <> SteelWith)
        End If
        If IsFinalRecord OrElse IsDifferentPreValue Then
            Dim EndSumRow As DataRow = SourceDataSet.NewRow
            EndSumRow.Item("鋼種尺寸") = "小計:"
            For Each EachItem As DataRow In SourceDataSet.Rows
                If EachItem.Item("鋼種尺寸") = "合計:" OrElse EachItem.Item("鋼種尺寸") = "小計:" Then
                    Continue For
                End If

                If EachItem.Item("鋼種") = OldSteelKind AndAlso EachItem.Item("材質") = OldSteelMaterialAttribute AndAlso EachItem.Item("寬度") = OldSteelWith Then
                    With EndSumRow
                        .Item("數量小計") += EachItem.Item("數量小計")
                        .Item("重量小計") += EachItem.Item("重量小計")
                        .Item("未研磨數量") += EachItem.Item("未研磨數量")
                        .Item("未研磨重量") += EachItem.Item("未研磨重量")
                        .Item("已研磨未繳庫數量") += EachItem.Item("已研磨未繳庫數量")
                        .Item("已研磨未繳庫重量") += EachItem.Item("已研磨未繳庫重量")
                        .Item("繳庫數量") += EachItem.Item("繳庫數量")
                        .Item("繳庫重量") += EachItem.Item("繳庫重量")
                        .Item("中鋼代工數量") += EachItem.Item("中鋼代工數量")
                        .Item("中鋼代工重量") += EachItem.Item("中鋼代工重量")
                        .Item("燁聯代工數量") += EachItem.Item("燁聯代工數量")
                        .Item("燁聯代工重量") += EachItem.Item("燁聯代工重量")
                        .Item("其它代工數量") += EachItem.Item("其它代工數量")
                        .Item("其它代工重量") += EachItem.Item("其它代工重量")
                    End With
                End If
            Next
            SourceDataSet.Rows.Add(EndSumRow)
            OldSteelKind = SteelKind
            OldSteelMaterialAttribute = SteelMaterialAttribute
            OldSteelWith = SteelWith
        End If
    End Sub

    Private Sub DisplayEndSum(ByVal SourceDataSet As StockStatic.DisplayDataSet.DisplayDataTableDataTable)
        Dim EndSumRow As DataRow = SourceDataSet.NewRow
        EndSumRow.Item("鋼種尺寸") = "合計:"
        For Each EachItem As DataRow In SourceDataSet.Rows
            If EachItem.Item("鋼種尺寸") = "合計:" OrElse EachItem.Item("鋼種尺寸") = "小計:" Then
                Continue For
            End If

            With EndSumRow
                .Item("數量小計") += EachItem.Item("數量小計")
                .Item("重量小計") += EachItem.Item("重量小計")
                .Item("未研磨數量") += EachItem.Item("未研磨數量")
                .Item("未研磨重量") += EachItem.Item("未研磨重量")
                .Item("已研磨未繳庫數量") += EachItem.Item("已研磨未繳庫數量")
                .Item("已研磨未繳庫重量") += EachItem.Item("已研磨未繳庫重量")
                .Item("繳庫數量") += EachItem.Item("繳庫數量")
                .Item("繳庫重量") += EachItem.Item("繳庫重量")
                .Item("中鋼代工數量") += EachItem.Item("中鋼代工數量")
                .Item("中鋼代工重量") += EachItem.Item("中鋼代工重量")
                .Item("燁聯代工數量") += EachItem.Item("燁聯代工數量")
                .Item("燁聯代工重量") += EachItem.Item("燁聯代工重量")
                .Item("其它代工數量") += EachItem.Item("其它代工數量")
                .Item("其它代工重量") += EachItem.Item("其它代工重量")
            End With
        Next
        SourceDataSet.Rows.Add(EndSumRow)
    End Sub

#End Region

#Region "產生查詢指令至控制項 函式:MakeQryToControl"
    ''' <summary>
    ''' 產生查詢指令至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeQryToControl()
        Dim QueryString As String = Nothing
        Dim CCMQueryString As String = Nothing
        Dim SGMQueryString As String = Nothing
        Select Case RadioButtonList1.SelectedValue
            Case 0
                QueryString = "SELECT SGA01,SGA05,SGA06,SGA08,SGA09,SGA14,SGA15,SGA18,SGA19,SGA24,SGA35,SGA36 FROM SMS100LB.SMSSGAPF WHERE SGA33='    ' and SGA35 IN (' ','A','B')"
            Case 1
                QueryString = "SELECT SGA05,SGA35,SGA18,SGA08,SGA24,SGA14,SGA15,SGA06,SGA09,SGA19,SGA01 FROM SMS100LB.SMSSGAPF WHERE SGA07>980300 AND SGA33='    ' AND SGA35 IN (' ','A','B')"
                CCMQueryString = "SELECT  SGA14, SGA24, SGA15 FROM SMS100LB.SMSSGAPF  WHERE SGA35 <> 'R' "
                SGMQueryString = "SELECT SUM(SGA24) SGA24 FROM SMS100LB.SMSSGAPF  WHERE SGA35 <> 'R' "
        End Select
        QueryString &= IIf(DropDownList1.SelectedValue = "全部", Nothing, " AND SGA05='" & DropDownList1.SelectedValue & "'")
        If CheckBox1.Checked Then
            Dim StartDate As Date = CType(Me.tbStartDate.Text, Date)
            Dim EndDate As Date = CType(Me.tbEndDate.Text, Date)
            Dim StartDateValue As Integer = New CompanyORMDB.AS400DateConverter(StartDate).TwIntegerTypeData
            Dim EndDateValue As Integer = New CompanyORMDB.AS400DateConverter(EndDate).TwIntegerTypeData
            QueryString &= " AND SGA07 >= " & StartDateValue & " AND SGA07<= " & EndDateValue
            CCMQueryString &= " AND SGA07 >= " & StartDateValue & " AND SGA07<= " & EndDateValue
            SGMQueryString &= " AND SGA16 >= " & StartDateValue & " AND SGA16<= " & EndDateValue
        End If
        QueryString &= " Order By SGA05,SGA06,SGA09,SGA08,SGA18"

        Me.hfQry.Value = QueryString
        Me.hfCCMQry.Value = CCMQueryString
        Me.hfSGMQry.Value = SGMQueryString
    End Sub
#End Region


    Private Sub DropDownList1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.DataBound
        Me.DropDownList1.Items.Insert(0, "全部")
    End Sub

    Protected Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Select Case RadioButtonList1.SelectedValue
            Case 0
                MakeQryToControl()
                Me.MultiView1.SetActiveView(View1)
                GridView1.DataBind()
            Case 1
                MakeQryToControl()
                Me.MultiView1.SetActiveView(View2)
                GridView2.DataBind()
        End Select

    End Sub


    Private Sub GridView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PreRender, GridView2.PreRender
        For Each EachRow As GridViewRow In CType(sender, GridView).Rows
            Select Case True
                Case EachRow.Cells(0).Text = "小計:"
                    EachRow.BackColor = Drawing.Color.Yellow
                Case EachRow.Cells(0).Text = "合計:"
                    EachRow.BackColor = Drawing.Color.LightPink
            End Select
        Next
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartDate.Text = Format(New Date(Now.Year, Now.Month, 1), "yyyy/MM/dd")
            tbEndDate.Text = Format(New Date(Now.Year, Now.Month, Date.DaysInMonth(Now.Year, Now.Month)), "yyyy/MM/dd")
            DropDownList1.Items.Add("全部")
            Dim DBAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            For Each EachItem As DataRow In DBAdapter.SelectQuery("Select Distinct SGA05 FROM SMS100LB.SMSSGAPF").Rows
                DropDownList1.Items.Add(EachItem.Item("SGA05"))
            Next
        End If
    End Sub

    Protected Sub tbConvertToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tbConvertToExcel.Click
        MakeQryToControl()
        Select Case RadioButtonList1.SelectedValue
            Case 0
                Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(Search0(hfQry.Value), "鋼捲庫存查詢格式1" & Format(Now, "mmss") & ".xls")
                ExcelConvert.DownloadEXCELFile(Me.Response)
            Case 1
                Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(Search1(hfQry.Value, hfCCMQry.Value, hfSGMQry.Value), "鋼捲庫存查詢格式2" & Format(Now, "mmss") & ".xls")
                ExcelConvert.DownloadEXCELFile(Me.Response)
        End Select

    End Sub

End Class
