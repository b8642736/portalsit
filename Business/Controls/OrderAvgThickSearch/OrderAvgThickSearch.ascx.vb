Public Class OrderAvgThickSearch
    Inherits System.Web.UI.UserControl

#Region "資料查詢 方法:Search"
    ''' <summary>
    ''' 資料查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function Search(ByVal QryString As String) As SLS300LB.OrderAvgThickSearchDataTable
        If String.IsNullOrEmpty(QryString) Then
            Return New SLS300LB.OrderAvgThickSearchDataTable
        End If
        Dim SearchResult As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In CompanyORMDB.SLS300LB.SL2QTNPF.CDBSetDataTableToObjects(Of CompanyORMDB.SLS300LB.SL2QTNPF)(New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString).SelectQuery) Where A.About_SL2CH2PF_CH202 <> "Y" And A.QTN05 <> "" Select A Order By A.QTN01, A.QTN02, A.QTN03).ToList
        Dim ReturnValue As New SLS300LB.OrderAvgThickSearchDataTable
        Dim AddItem As SLS300LB.OrderAvgThickSearchRow = Nothing
        For Each EachItem In (From a In SearchResult Select a.QTN01 & "&" & a.IsHomeSell & "&" & a.QTN03 & "&" & a.IsCRNotHR).Distinct
            Dim EachItemTemp() As String = EachItem.Split("&")
            Dim SubDatas As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In SearchResult Where A.QTN01 = EachItemTemp(0) And A.IsHomeSell = CType(EachItemTemp(1), Boolean) And A.QTN03 = EachItemTemp(2) And A.IsCRNotHR = CType(EachItemTemp(3), Boolean) Select A).ToList
            AddRowItem(EachItem, ReturnValue, SubDatas)
        Next
        For Each EachItem In (From a In SearchResult Select "客戶合計&" & a.IsHomeSell & "&" & a.QTN03 & "&" & a.IsCRNotHR).Distinct
            Dim EachItemTemp() As String = EachItem.Split("&")
            Dim SubDatas As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In SearchResult Where A.IsHomeSell = CType(EachItemTemp(1), Boolean) And A.QTN03 = EachItemTemp(2) And A.IsCRNotHR = CType(EachItemTemp(3), Boolean) Select A).ToList
            AddRowItem(EachItem, ReturnValue, SubDatas)
        Next
        For Each EachItem In (From a In SearchResult Select "客戶合計&" & "內外銷合計&" & a.QTN03 & "&" & a.IsCRNotHR).Distinct
            Dim EachItemTemp() As String = EachItem.Split("&")
            Dim SubDatas As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In SearchResult Where A.QTN03 = EachItemTemp(2) And A.IsCRNotHR = CType(EachItemTemp(3), Boolean) Select A).ToList
            AddRowItem(EachItem, ReturnValue, SubDatas)
        Next
        For Each EachItem In (From a In SearchResult Select "客戶合計&" & "內外銷合計&" & "鋼種合計&" & a.IsCRNotHR).Distinct
            Dim EachItemTemp() As String = EachItem.Split("&")
            Dim SubDatas As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In SearchResult Where A.IsCRNotHR = CType(EachItemTemp(3), Boolean) Select A).ToList
            AddRowItem(EachItem, ReturnValue, SubDatas)
        Next
        For Each EachItem In (From a In SearchResult Select "客戶合計&" & "內外銷合計&" & "鋼種合計&" & "CR或HR合計").Distinct
            Dim EachItemTemp() As String = EachItem.Split("&")
            Dim SubDatas As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In SearchResult Select A).ToList
            AddRowItem(EachItem, ReturnValue, SubDatas)
        Next

        Return ReturnValue
    End Function

    Private Shared Sub AddRowItem(ByVal EachItemString As String, ByRef ReturnValue As SLS300LB.OrderAvgThickSearchDataTable, ByVal SubDatas As List(Of CompanyORMDB.SLS300LB.SL2QTNPF))
        If SubDatas.Count = 0 Then
            Exit Sub
        End If
        Dim AddItem As SLS300LB.OrderAvgThickSearchRow = Nothing
        Static PreValue(5) As Object
        Dim EachItemTemp() As String = EachItemString.Split("&")

        AddItem = ReturnValue.NewRow
        With AddItem
            If IsNothing(PreValue(0)) OrElse PreValue(0) <> EachItemTemp(0) Then
                .客戶名稱 = IIf(EachItemTemp(0) = "客戶合計", EachItemTemp(0), SubDatas(0).CustomerName & "(" & EachItemTemp(0) & ")")
                '.報價單編號 = EachItemTemp(1)
                If EachItemTemp(1) = "內外銷合計" Then
                    .內外銷 = EachItemTemp(2)
                Else
                    .內外銷 = IIf(CType(EachItemTemp(1), Boolean), "內銷", "外銷")
                End If
                .鋼種 = EachItemTemp(2)
                If EachItemTemp(3) = "CR或HR合計" Then
                    .CR或HR = EachItemTemp(3)
                Else
                    .CR或HR = IIf(CType(EachItemTemp(3), Boolean), "CR", "HR")
                End If
                PreValue(0) = EachItemTemp(0)
            End If
            'If IsNothing(PreValue(1)) OrElse PreValue(1) <> EachItemTemp(1) Then
            '    .報價單編號 = EachItemTemp(1)
            '    If EachItemTemp(2) = "內外銷合計" Then
            '        .內外銷 = EachItemTemp(2)
            '    Else
            '        .內外銷 = IIf(CType(EachItemTemp(2), Boolean), "內銷", "外銷")
            '    End If
            '    .鋼種 = EachItemTemp(3)
            '    If EachItemTemp(4) = "CR或HR合計" Then
            '        .CR或HR = EachItemTemp(4)
            '    Else
            '        .CR或HR = IIf(CType(EachItemTemp(4), Boolean), "CR", "HR")
            '    End If
            '    PreValue(1) = EachItemTemp(1)
            'End If
            If IsNothing(PreValue(1)) OrElse PreValue(1) <> EachItemTemp(1) Then
                If EachItemTemp(1) = "內外銷合計" Then
                    .內外銷 = EachItemTemp(1)
                Else
                    .內外銷 = IIf(CType(EachItemTemp(1), Boolean), "內銷", "外銷")
                End If
                .鋼種 = EachItemTemp(2)
                If EachItemTemp(3) = "CR或HR合計" Then
                    .CR或HR = EachItemTemp(3)
                Else
                    .CR或HR = IIf(CType(EachItemTemp(3), Boolean), "CR", "HR")
                End If
                PreValue(1) = EachItemTemp(1)
            End If
            If IsNothing(PreValue(2)) OrElse PreValue(2) <> EachItemTemp(2) Then
                .鋼種 = EachItemTemp(2)
                If EachItemTemp(3) = "CR或HR合計" Then
                    .CR或HR = EachItemTemp(3)
                Else
                    .CR或HR = IIf(CType(EachItemTemp(3), Boolean), "CR", "HR")
                End If
                PreValue(2) = EachItemTemp(2)
            End If
            If IsNothing(PreValue(3)) OrElse PreValue(3) <> EachItemTemp(3) Then
                If EachItemTemp(3) = "CR或HR合計" Then
                    .CR或HR = EachItemTemp(3)
                Else
                    .CR或HR = IIf(CType(EachItemTemp(3), Boolean), "CR", "HR")
                End If
                PreValue(3) = EachItemTemp(3)
            End If
            ._2D = GetThithAverage(SubDatas, "2D")
            ._2B = GetThithAverage(SubDatas, "2B")
            .BA = GetThithAverage(SubDatas, "BA")
            .SH = GetThithAverage(SubDatas, "SH")
            .NO1 = GetThithAverage(SubDatas, "NO1")
        End With
        ReturnValue.Rows.Add(AddItem)
    End Sub

    Private Shared Function GetThithAverage(ByVal SourceDatas As List(Of CompanyORMDB.SLS300LB.SL2QTNPF), ByVal FindFace As String) As Single
        Dim FindDatas As List(Of CompanyORMDB.SLS300LB.SL2QTNPF) = (From A In SourceDatas Where A.QTN04.Trim = FindFace Select A).ToList
        If FindDatas.Count = 0 Then
            Return 0
        End If
        Return (From A In FindDatas Select CType(A.QTN05, Single)).Average
    End Function
#End Region
#Region "產生查詢至控製項 函式:MakeQryToControl"
    Private Sub MakeQryToControl()
        Dim StartTwDate As String = Format(CType(tbStartYear.Text, Integer) * 100 + CType(tbStartMonth.Text, Integer), "00000")
        Dim EndTwDate As String = Format(CType(tbStartYear.Text, Integer) * 100 + CType(tbStartMonth.Text, Integer) + 1, "00000")
        Dim SQLString As String = "Select A.* from @#SLS300LB.SL2QTNPF AS A WHERE  QTN02 >= '" & StartTwDate & "' AND QTN02<'" & EndTwDate & "' " 'QTN29='E' "  '外銷

        If Not String.IsNullOrEmpty(TextBox1.Text) AndAlso TextBox1.Text.Trim.Length > 0 Then
            Dim FindValue As String = TextBox1.Text.Trim
            SQLString &= " AND QTN01='" & FindValue & "' "
        End If

        hfQryString.Value = SQLString
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            tbStartYear.Text = Now.Year - 1911
            tbStartMonth.Text = Now.Month
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MakeQryToControl()
        GridView1.DataBind()
    End Sub

    Protected Sub btnSearchToExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchToExcel.Click
        MakeQryToControl()
        Dim ExcelConvert As New PublicClassLibrary.DataConvertExcel(Search(Me.hfQryString.Value), "客戶訂單平均厚度統計表" & Format(Now, "mmss") & ".xls")
        ExcelConvert.DownloadEXCELFile(Me.Response)

    End Sub
End Class