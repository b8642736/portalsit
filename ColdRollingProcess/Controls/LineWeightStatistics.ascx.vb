Public Class LineWeightStatistics
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.tbDateStart.Text = Format(Now, "yyyy/MM/01")
            Me.tbDateEnd.Text = Format(Now, "yyyy/MM/dd")
        End If
    End Sub



#Region "產生查詢字串至控制項 函式:MakQryStringToControl"
    ''' <summary>
    ''' 產生查詢字串至控制項
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakQryStringToControl()
        Dim SQLString As New StringBuilder

        Dim SearchDateStart As String = New AS400DateConverter(tbDateStart.Text).TwSixCharsTypeData
        Dim SearchDateEnd As String = New AS400DateConverter(tbDateEnd.Text).TwSixCharsTypeData
        Dim LineName1Char As String = ""
        Dim LineName2Char As String = ""

        Dim isSelectAllItem As Boolean
        For Each eachItem As ListItem In CheckBoxList1.Items
            If eachItem.Selected = True OrElse isSelectAllItem = True Then
                If eachItem.Text.Substring(0, 1) = "Z" Then
                    If LineName1Char.Length > 0 Then LineName1Char &= ","
                    LineName1Char &= eachItem.Text.Substring(0, 1)
                Else
                    If eachItem.Text = "全部" Then
                        isSelectAllItem = True
                    Else
                        If LineName2Char.Length > 0 Then LineName2Char &= ","
                        LineName2Char &= eachItem.Text.Substring(0, 2)
                    End If

                End If

            End If
        Next


        '規則跟AS400  
        'PPS100LB/QCLSRC/PPSRL1CP       18:GPL生產量統計分析       PASS量  CR+HR
        'PPS100LB/QRPGSRC/PPSG01RA

        SQLString.Append("SELECT * FROM @#PPS100LB.PPSSHAPF" & vbNewLine)
        SQLString.Append("  WHERE 1=1" & vbNewLine)

        SQLString.Append("    AND sha21 BETWEEN " & SearchDateStart & " AND " & SearchDateEnd & vbNewLine)
        SQLString.Append("    AND  SHA29<>'*' AND SHA28 IN ('A','*') " & vbNewLine)     '本站已完成
        SQLString.Append("    AND SHA27<>'STK ' " & vbNewLine)                                            '下一站不等是STK成品庫

        SQLString.Append("    AND  ( " & vbNewLine)
        SQLString.Append("                   LEFT(sha08,2) IN (" & "'" & String.Join("','", LineName2Char.Split(",")) & "'" & ") " & vbNewLine)
        SQLString.Append("                   OR  LEFT(sha08,1) IN (" & "'" & String.Join("','", LineName1Char.Split(",")) & "'" & ")  " & vbNewLine)
        SQLString.Append("    ) " & vbNewLine)


        Me.hfQryString.Value = SQLString.ToString
        Me.hfLineName1Char.Value = LineName1Char
        Me.hfLineName2Char.Value = LineName2Char
        Me.hfParam.Value = DropDownList1.SelectedValue & "|" & DropDownList2.SelectedValue
    End Sub
#End Region

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        MakQryStringToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchDownExcel_Click(sender As Object, e As EventArgs) Handles btnSearchDownExcel.Click
        Call MakQryStringToControl()
        Dim ExcelConvert As PublicClassLibrary.DataConvertExcel = New PublicClassLibrary.DataConvertExcel(Search(Me.hfQryString.Value, Me.hfLineName2Char.Value, Me.hfLineName1Char.Value, Me.hfParam.Value), "產線重量統計查詢" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)
    End Sub


    Private Function FI_ObjectParseInteger(ByVal fromObj As Object) As Integer
        If (IsNumeric(fromObj.ToString.Trim) = False) Then
            Return 0
        Else
            Return Integer.Parse(fromObj.ToString.Trim)
        End If
    End Function

#Region "Search"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="fromSQL"></param>
    ''' <param name="fromLineName2Char"></param>
    ''' <param name="fromLineName1Char"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Function Search(ByVal fromSQL As String, ByVal fromLineName2Char As String, ByVal fromLineName1Char As String, ByVal fromParam As String) As DataTable
        Dim ReturnDataTable_Detail As New DataTable
        Dim ReturnDataTable_Statistics As New DataTable

        If String.IsNullOrEmpty(fromSQL) Then
            Return ReturnDataTable_Detail
        End If

        If String.IsNullOrEmpty(fromLineName2Char) Then fromLineName2Char = ""
        If String.IsNullOrEmpty(fromLineName1Char) Then fromLineName1Char = ""

        Dim param() As String = fromParam.Split("|")

        For II As Integer = 0 To 4
            ReturnDataTable_Detail.Columns.Add(getColumnName(II))
        Next


        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter
        Dim QueryList As List(Of PPS100LB.PPSSHAPF) = PPS100LB.PPSSHAPF.CDBSelect(Of PPS100LB.PPSSHAPF)(fromSQL, Adapter)


        Dim FilterClass As PPS100LB.PPSSHAPF = Nothing
        Dim FilterList1 As List(Of PPS100LB.PPSSHAPF) = Nothing
        Dim FilterList2 As List(Of DisplayClass) = Nothing
        Dim FilterList3A As List(Of PPS100LB.PPSSHAPF) = Nothing
        Dim FilterList3B As List(Of PPS100LB.PPSSHAPF) = Nothing
        Dim FilterList3C As List(Of PPS100LB.PPSSHAPF) = Nothing
        Dim FilterList3C_Item As PPS100LB.PPSSHAPF = Nothing
        Dim FilterList3C_GroupList As List(Of DisplayClass3) = Nothing

        Dim FilterGroupList1 As List(Of String) = Nothing
        Dim FilterGroupList2 As List(Of String) = Nothing
        Dim FilterLineName As String = fromLineName2Char
        If (fromLineName1Char.Length > 0) Then
            If (FilterLineName.Length > 0) Then
                FilterLineName &= ","
            End If
            FilterLineName &= fromLineName1Char
        End If


        Dim GroupLineSHA08List As New List(Of String)

        For Each eachLineName As String In FilterLineName.Split(",")

            'FilterList1(用關鍵字取得產線的明細資料)：Ex:GP/AP/Z
            FilterList1 = (From A In QueryList Where A.SHA08.StartsWith(eachLineName) Select A).ToList

            'FilterGroupList1(取的關鍵字開頭的所有產線明細名稱)
            FilterGroupList1 = (From A In FilterList1 Group By A.SHA08 Into GroupCount = Count() Order By SHA08 Select SHA08).ToList


            For Each eachSha08 As String In FilterGroupList1
                GroupLineSHA08List.Add(eachSha08)

                'FilterList2(取得線別明細群組(產線明細名稱/寬度/厚度)清單)：EX:GP1C/GP1H...
                FilterList2 = (From A In FilterList1 Where A.SHA08 = eachSha08 _
                                                 Group By A.SHA08, A.SHA34, A.SHA33 Into GroupCount = Count() _
                                                 Order By SHA08, SHA34, SHA33
                                                 Select New DisplayClass(SHA08, SHA34, SHA33)).ToList


                For Each eachDisplayClass As DisplayClass In FilterList2
                    FilterList3A = (From A In FilterList1 Where A.SHA08 = eachDisplayClass.線別明細名稱 _
                                                               And A.SHA34 = eachDisplayClass.寬度 And A.SHA33 = eachDisplayClass.厚度 _
                                                               Select A).ToList

                    If param(1) = "PASS" Then
                        '1030616 by renhsin
                        '投入量:每一次都算,產出量:只算最後一次

                        FilterList3C = New List(Of PPS100LB.PPSSHAPF)
                        FilterList3C_GroupList = (From A In FilterList3A _
                                                                                  Group By A.SHA01, A.SHA02 Into GroupCount = Count() _
                                                                                    Order By SHA01, SHA02 _
                                                                                    Select New DisplayClass3(SHA01, SHA02)).ToList
                        For Each eachDisplayClass3 In FilterList3C_GroupList
                            FilterList3C_Item = (From A In FilterList3A _
                                                                        Where A.SHA01 = eachDisplayClass3.鋼捲編號1 _
                                                                                 And A.SHA02 = eachDisplayClass3.鋼捲編號2 _
                                                                        Order By A.SHA04 Descending _
                                                                        Select A).FirstOrDefault
                            FilterList3C.Add(FilterList3C_Item)
                        Next

                        eachDisplayClass.投入量 = (From A In FilterList3A Select (A.SHA17 + A.SHA18 + A.SHA19 + A.SHA20)).Sum
                        eachDisplayClass.產出量 = (From A In FilterList3C Select (A.SHA17)).Sum


                    Else
                        '同產線同鋼捲計算
                        If param(1) = "只算一次" Then
                            FilterList3B = New List(Of PPS100LB.PPSSHAPF)
                            For Each eachItem As PPS100LB.PPSSHAPF In FilterList3A
                                If (From A In FilterList3B Where A.SHA01 = eachItem.SHA01 And A.SHA02 = eachItem.SHA02 Select A).Count = 0 Then
                                    FilterList3B.Add(eachItem)
                                End If
                            Next

                        Else
                            '每次都算
                            FilterList3B = FilterList3A
                        End If

                        eachDisplayClass.投入量 = (From A In FilterList3B Select (A.SHA17 + A.SHA18 + A.SHA19 + A.SHA20)).Sum
                        eachDisplayClass.產出量 = (From A In FilterList3B Select (A.SHA17)).Sum
                    End If

                    P_Add_DataRow(ReturnDataTable_Detail, eachDisplayClass)
                Next

            Next

        Next

        If param(0) = "明細" Then Return ReturnDataTable_Detail




        '統計
        '1：除GPL外各條線依『線別明細名稱』統計
        '2：GPL統計方式依『線別明細名稱』最後一碼(C/H/R)統計
        '       H還須依照 
        '                           I)『寬度』區分 三尺(<1219) / 四尺：>=1219
        '                           II)『厚度』區分 <=3.0   >3.0
        '-----------------------------------------------------------------------------        

        ReturnDataTable_Statistics = ReturnDataTable_Detail.Clone

        Dim GroupDataRowList1 As List(Of DataRow) = Nothing

        '統計1：除GPL外各條線
        Dim haveLineOfGP As Boolean = False
        For Each eachSha08 As String In GroupLineSHA08List
            If eachSha08.Substring(0, 2) = "GP" Then
                haveLineOfGP = True
                Continue For
            End If

            GroupDataRowList1 = (From A In ReturnDataTable_Detail Where A.Item(ColumnName_Enum.線別) = eachSha08 Select A).ToList
            P_Add_Statistic_DataRow(ReturnDataTable_Statistics, GroupDataRowList1, eachSha08)
        Next

        '統計2：GPL特殊統計
        If haveLineOfGP = True Then
            Dim GroupGPLLine() As String = New String() {"C", "H", "R"}
            For Each eachGPLLine As String In GroupGPLLine
                GroupDataRowList1 = (From A In ReturnDataTable_Detail Where 1 = 1 _
                                                            And A.Item(ColumnName_Enum.線別).ToString.StartsWith("GP") _
                                                            And A.Item(ColumnName_Enum.線別).ToString.EndsWith(eachGPLLine) _
                                                            Select A).ToList

                If eachGPLLine = "H" Then
                    Const C_GPL_H_固定尺寸 = 1219
                    Const C_GPL_H_固定厚度 = 300
                    Dim GroupDataRowList2 As List(Of DataRow) = Nothing
                    Dim GroupDataRowList3 As List(Of DataRow) = Nothing

                    GroupDataRowList2 = (From A In GroupDataRowList1 Where FI_ObjectParseInteger(A.Item(ColumnName_Enum.寬度)) < C_GPL_H_固定尺寸 Select A).ToList

                    GroupDataRowList3 = (From A In GroupDataRowList2 Where FI_ObjectParseInteger(A.Item(ColumnName_Enum.厚度)) <= C_GPL_H_固定厚度 Select A).ToList
                    P_Add_Statistic_DataRow(ReturnDataTable_Statistics, GroupDataRowList3, "GP" & eachGPLLine, "三尺", "<=" & (C_GPL_H_固定厚度 / 100))
                    GroupDataRowList3 = (From A In GroupDataRowList2 Where FI_ObjectParseInteger(A.Item(ColumnName_Enum.厚度)) > C_GPL_H_固定厚度 Select A).ToList
                    P_Add_Statistic_DataRow(ReturnDataTable_Statistics, GroupDataRowList3, "GP" & eachGPLLine, "三尺", ">" & (C_GPL_H_固定厚度 / 100))

                    P_Add_Statistic_DataRow(ReturnDataTable_Statistics, GroupDataRowList2, "GP" & eachGPLLine, "四尺")


                    GroupDataRowList2 = (From A In GroupDataRowList1 Where FI_ObjectParseInteger(A.Item(ColumnName_Enum.寬度)) >= C_GPL_H_固定尺寸 Select A).ToList

                    GroupDataRowList3 = (From A In GroupDataRowList2 Where FI_ObjectParseInteger(A.Item(ColumnName_Enum.厚度)) <= C_GPL_H_固定厚度 Select A).ToList
                    P_Add_Statistic_DataRow(ReturnDataTable_Statistics, GroupDataRowList3, "GP" & eachGPLLine, "四尺", "<=" & (C_GPL_H_固定厚度 / 100))
                    GroupDataRowList3 = (From A In GroupDataRowList2 Where FI_ObjectParseInteger(A.Item(ColumnName_Enum.厚度)) > C_GPL_H_固定厚度 Select A).ToList
                    P_Add_Statistic_DataRow(ReturnDataTable_Statistics, GroupDataRowList3, "GP" & eachGPLLine, "四尺", ">" & (C_GPL_H_固定厚度 / 100))

                    P_Add_Statistic_DataRow(ReturnDataTable_Statistics, GroupDataRowList2, "GP" & eachGPLLine, "四尺")
                End If

                P_Add_Statistic_DataRow(ReturnDataTable_Statistics, GroupDataRowList1, "GP" & eachGPLLine)
            Next
        End If

        Return ReturnDataTable_Statistics
    End Function

    Private Sub P_Add_DataRow(ByRef fromDataTable As DataTable, ByVal fromDisplayClass As DisplayClass)
        Dim AddItem As DataRow = Nothing

        AddItem = fromDataTable.NewRow

        AddItem.Item(ColumnName_Enum.線別) = fromDisplayClass.線別明細名稱
        AddItem.Item(ColumnName_Enum.寬度) = fromDisplayClass.寬度
        AddItem.Item(ColumnName_Enum.厚度) = fromDisplayClass.厚度
        AddItem.Item(ColumnName_Enum.投入量) = FS_FormatNumber(fromDisplayClass.投入量)
        AddItem.Item(ColumnName_Enum.產出量) = FS_FormatNumber(fromDisplayClass.產出量)


        fromDataTable.Rows.Add(AddItem)
    End Sub

    Private Sub P_Add_Statistic_DataRow(ByRef fromDataTable As DataTable, ByRef fromQueryList As List(Of DataRow), _
                                                                                             ByVal form線別明細名稱 As String)
        P_Add_Statistic_DataRow(fromDataTable, fromQueryList, form線別明細名稱, "")
    End Sub

    Private Sub P_Add_Statistic_DataRow(ByRef fromDataTable As DataTable, ByRef fromQueryList As List(Of DataRow), _
                                                                                             ByVal form線別明細名稱 As String, ByVal from寬度 As String)
        P_Add_Statistic_DataRow(fromDataTable, fromQueryList, form線別明細名稱, from寬度, "")
    End Sub
    Private Sub P_Add_Statistic_DataRow(ByRef fromDataTable As DataTable, ByRef fromQueryList As List(Of DataRow), _
                                                                                         ByVal form線別明細名稱 As String, ByVal from寬度 As String, ByVal from厚度 As String)
        Dim GroupDisplayClass As DisplayClass = New DisplayClass

        GroupDisplayClass.線別明細名稱 = form線別明細名稱
        GroupDisplayClass.寬度 = from寬度
        GroupDisplayClass.厚度 = from厚度

        GroupDisplayClass.投入量 = (From B In fromQueryList Select Double.Parse(B.Item(ColumnName_Enum.投入量), System.Globalization.NumberStyles.Number)).Sum
        GroupDisplayClass.產出量 = (From B In fromQueryList Select Double.Parse(B.Item(ColumnName_Enum.產出量), System.Globalization.NumberStyles.Number)).Sum

        P_Add_DataRow(fromDataTable, GroupDisplayClass)
    End Sub


    Private Function FS_FormatNumber(ByVal fromText) As String
        Dim ReturnText As String = fromText

        If IsNumeric(fromText) Then ReturnText = String.Format("{0:N0}", Double.Parse(fromText))
        Return ReturnText
    End Function

#End Region

#Region "DataTable欄位名稱"
    Enum ColumnName_Enum
        線別 = 0
        寬度 = 1
        厚度 = 2
        投入量 = 3
        產出量 = 4
    End Enum

    Public Function getColumnName(ByVal fromColumnName_Enum As ColumnName_Enum) As String
        Select Case fromColumnName_Enum
            Case ColumnName_Enum.線別
                Return "線別"
            Case ColumnName_Enum.寬度
                Return "寬度"
            Case ColumnName_Enum.厚度
                Return "厚度"
            Case ColumnName_Enum.投入量
                Return "投入量"
            Case ColumnName_Enum.產出量
                Return "產出量"
        End Select

        Return "XX"
    End Function

#End Region

#Region "顯示用Class：DisplayClass"

    Public Class DisplayClass
        Private _線別明細名稱 As String = ""
        Private _寬度 As String = ""
        Private _厚度 As String = ""
        Private _投入量 As String = ""
        Private _產出量 As String = ""

        Sub New()

        End Sub

        Sub New(ByVal fromSHA08 As String, ByVal fromSHA34 As String, ByVal fromSHA33 As String)
            _線別明細名稱 = fromSHA08
            _寬度 = fromSHA34
            _厚度 = fromSHA33
        End Sub

        Sub New(ByVal fromSHA08 As String, ByVal fromSHA34 As String, ByVal fromSHA33 As String, ByVal fromSHA17_20 As String, ByVal fromSHA17 As String)
            _線別明細名稱 = fromSHA08
            _寬度 = fromSHA34
            _厚度 = fromSHA33
            _投入量 = fromSHA17_20
            _產出量 = fromSHA17
        End Sub

        Public Property 線別明細名稱 As String
            Get
                Return _線別明細名稱
            End Get
            Set(value As String)
                _線別明細名稱 = value
            End Set
        End Property

        Public Property 寬度 As String
            Get
                Return _寬度
            End Get
            Set(value As String)
                _寬度 = value
            End Set
        End Property

        Public ReadOnly Property 厚度Display As String
            Get
                Dim Return厚度 As String = ""
                If _厚度.Trim.Length > 0 Then
                    Return厚度 = _厚度.Substring(0, 2).Trim & "." & _厚度.Substring(2, 2)
                End If

                Return Return厚度
            End Get
        End Property

        Public Property 厚度 As String
            Get
                Return _厚度
            End Get
            Set(value As String)
                _厚度 = value
            End Set
        End Property

        Public Property 投入量 As String
            Get
                Return _投入量
            End Get
            Set(value As String)
                _投入量 = value
            End Set
        End Property

        Public Property 產出量 As String
            Get
                Return _產出量
            End Get
            Set(value As String)
                _產出量 = value
            End Set
        End Property
    End Class

    Public Class DisplayClass3
        Public 鋼捲編號1 As String
        Public 鋼捲編號2 As String

        Sub New(ByVal from鋼捲編號1 As String, ByVal from鋼捲編號2 As String)
            鋼捲編號1 = from鋼捲編號1
            鋼捲編號2 = from鋼捲編號2
        End Sub
    End Class
#End Region

#Region "GridView排版：文字靠右/數字靠左"
    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim newWidth As Integer

            For II As Integer = 0 To e.Row.Cells.Count - 1

                '數字靠右對齊
                Select Case II
                    Case ColumnName_Enum.線別
                        newWidth = 70
                    Case Else
                        e.Row.Cells(II).Attributes.Add("style", "text-align:right")
                        newWidth = 100
                End Select

                '調整寬度
                e.Row.Cells(II).Width = newWidth
            Next II

        End If
    End Sub

#End Region


End Class