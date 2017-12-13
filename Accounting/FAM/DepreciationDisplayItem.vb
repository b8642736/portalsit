Public Class DepreciationDisplayItem


    Public Shared Function SearchToDataTabe(ByVal FactoryName As String, Optional ByVal SearchDepartmentString As String = Nothing, Optional ByVal SearchACD2String As String = Nothing) As DataTable
        Dim GetDatas As List(Of DepreciationDisplayItem) = Search(FactoryName, SearchDepartmentString, SearchACD2String)
        If IsNothing(GetDatas) Then
            Return Nothing
        End If
        Dim ReturnValue As New DataTable("Depreciation")
        ReturnValue.Columns.Add(New DataColumn("DisplayName", GetType(String)))
        ReturnValue.Columns.Add(New DataColumn("DEPTSA", GetType(String)))
        ReturnValue.Columns.Add(New DataColumn("Number", GetType(String)))
        ReturnValue.Columns.Add(New DataColumn("Name", GetType(String)))
        ReturnValue.Columns.Add(New DataColumn("Quant", GetType(Double)))
        ReturnValue.Columns.Add(New DataColumn("Amount", GetType(Double)))
        ReturnValue.Columns.Add(New DataColumn("StartDate", GetType(String)))
        ReturnValue.Columns.Add(New DataColumn("Uslaff", GetType(String)))
        ReturnValue.Columns.Add(New DataColumn("Depr", GetType(Double)))
        ReturnValue.Columns.Add(New DataColumn("Dept", GetType(String)))
        ReturnValue.Columns.Add(New DataColumn("AST201PF_Depr", GetType(Double)))
        ReturnValue.Columns.Add(New DataColumn("ThisMonthDepr", GetType(Double)))
        ReturnValue.Columns.Add(New DataColumn("NumberKind", GetType(String)))
        ReturnValue.Columns.Add(New DataColumn("ACD2_ChineseName", GetType(String)))
        For Each EachItem As DepreciationDisplayItem In GetDatas
            Dim AddRow As DataRow = ReturnValue.NewRow
            With AddRow
                .Item("DisplayName") = EachItem.DisplayName
                .Item("DEPTSA") = EachItem.DEPTSA
                .Item("Number") = EachItem.Number
                .Item("Name") = EachItem.Name
                .Item("Quant") = EachItem.Quant
                .Item("Amount") = EachItem.Amount
                .Item("StartDate") = EachItem.StartDate
                .Item("Uslaff") = EachItem.Uslaff
                .Item("Depr") = EachItem.Depr
                .Item("Dept") = EachItem.Dept
                .Item("AST201PF_Depr") = EachItem.AST201PF_Depr
                .Item("ThisMonthDepr") = EachItem.ThisMonthDepr
                .Item("NumberKind") = EachItem.NumberKind
                .Item("ACD2_ChineseName") = EachItem.ACD2_ChineseName
            End With
            ReturnValue.Rows.Add(AddRow)
        Next
        Return ReturnValue
    End Function


    Public Shared Function Search(ByVal FactoryName As String, Optional ByVal SearchDepartmentString As String = Nothing, Optional ByVal SearchACD2String As String = Nothing) As List(Of DepreciationDisplayItem)
        Static IsNowSearchAllFactory As Boolean = False
        If FactoryName = "全部" Then
            IsNowSearchAllFactory = True
            Dim SetDepartments As String = Nothing
            For Each EachItem As String In AST106PF.GetSA_AST106PF_DEPTSA
                SetDepartments &= IIf(IsNothing(SetDepartments), EachItem, "|" & EachItem)
            Next
            Dim ReturnValue1 As List(Of DepreciationDisplayItem) = Search("SA", SetDepartments, SearchACD2String)
            ReturnValue1.AddRange(Search("AA", SetDepartments, SearchACD2String))
            ReturnValue1.AddRange(Search("AB", SetDepartments, SearchACD2String))
            ReturnValue1.AddRange(Search("BA", Nothing, SearchACD2String))
            ReturnValue1.AddRange(Search("QA", SetDepartments, SearchACD2String))
            ReturnValue1.AddRange(Search("NA", SetDepartments, SearchACD2String))
            ReturnValue1.AddRange(Search("RA", Nothing, SearchACD2String))
            ReturnValue1.AddRange(Search("RC", Nothing, SearchACD2String))
            ReturnValue1.AddRange(Search("RD", Nothing, SearchACD2String))

            Dim DisplayItemNumber As Integer = 1
            For Each EachItem In (From A In ReturnValue1 Select A Order By A.DEPTSA, A.NumberKind).ToList
                EachItem.DisplayName = DisplayItemNumber
                DisplayItemNumber += 1
            Next

            ReturnValue1 = AddSubTotal((From A In ReturnValue1 Select A Order By A.DEPTSA, A.NumberKind).ToList)
            ReturnValue1 = AddEndTotal(ReturnValue1)
            IsNowSearchAllFactory = False
            Return ReturnValue1
        End If
        Dim SearchDeparts() As String = Nothing '篩選單位
        If Not IsNothing(SearchDepartmentString) Then
            SearchDeparts = SearchDepartmentString.Split("|")
        End If
        Dim SearchACD2s() As String = Nothing '篩選裝置狀態
        If Not IsNothing(SearchACD2String) Then
            SearchACD2s = SearchACD2String.Split("|")
        End If
        Dim AST101PFResult As List(Of DepreciationDisplayItem)
        If IsNothing(SearchACD2s) Then
            AST101PFResult = GetSelectAllAST101PFToDepreciationDisplayItem(FactoryName)
        Else
            AST101PFResult = (From A In GetSelectAllAST101PFToDepreciationDisplayItem(FactoryName) Where SearchACD2s.Contains(A.ACD2) Select A).ToList
        End If
        Dim AST201PFResult As List(Of DepreciationDisplayItem) = GetSelectAllAST101PFToDepreciationDisplayItem(FactoryName, True)
        Dim ReturnValue As New List(Of DepreciationDisplayItem)
        If FactoryName = "SA" Or FactoryName = "AA" Or FactoryName = "AB" Or FactoryName = "QA" Or FactoryName = "NA" Then
            If IsNothing(SearchDeparts) Then
                Return Nothing
            End If
            Dim AST106PFResult As List(Of AST106PF) = (From A In AST106PF.GetSelectResult("Select NUMBER,DEPTSA From @#AST500LB.AST106PF.ASTF" & FactoryName & " Where SEQ=1 Order by DEPTSA") Where SearchDeparts.Contains(A.DEPTSA) Select A).ToList

            '以AST106PF為主來作查詢
            'For Each EachItem As AST106PF In AST106PFResult
            '    Dim EachItemNumber As String = EachItem.NUMBER
            '    Dim FindDepreciationDisplayItem As DepreciationDisplayItem = (From A In AST101PFResult Where A.Number = EachItemNumber Select A).FirstOrDefault
            '    Dim SecondDepreciationDisplayItem As DepreciationDisplayItem = (From A In AST201PFResult Where A.Number = EachItemNumber Select A).FirstOrDefault
            '    If Not IsNothing(FindDepreciationDisplayItem) AndAlso Not IsNothing(SecondDepreciationDisplayItem) AndAlso (EachItem.NUMBER = FindDepreciationDisplayItem.Number And FindDepreciationDisplayItem.Number = SecondDepreciationDisplayItem.Number) Then
            '        With FindDepreciationDisplayItem
            '            .DEPTSA = EachItem.DEPTSA
            '            .AST201PF_Depr = SecondDepreciationDisplayItem.Depr
            '        End With
            '        ReturnValue.Add(FindDepreciationDisplayItem)
            '    End If
            'Next
            '以下程式碼與上一段產生結果相同,只是以下是以AST101PF為主來作查詢
            For Each EachItem As DepreciationDisplayItem In AST101PFResult
                Dim EachItemNumber As String = EachItem.Number
                Dim EachItemDept As String = EachItem.Dept
                Dim SecondDepreciationDisplayItem As DepreciationDisplayItem = (From A In AST201PFResult Where A.Number = EachItemNumber And A.Dept = EachItemDept Select A).FirstOrDefault
                Dim AST106PFItem As AST106PF = (From A In AST106PFResult Where A.NUMBER = EachItemNumber Select A).FirstOrDefault
                If Not IsNothing(SecondDepreciationDisplayItem) AndAlso Not IsNothing(AST106PFItem) Then
                    With EachItem
                        .DEPTSA = AST106PFItem.DEPTSA
                        .AST201PF_Depr = SecondDepreciationDisplayItem.Depr
                    End With
                    ReturnValue.Add(EachItem)
                End If
            Next
        Else
            For Each EachItem As DepreciationDisplayItem In AST101PFResult
                Dim EachItemNumber As String = EachItem.Number
                Dim EachItemDept As String = EachItem.Dept
                Dim SecondDepreciationDisplayItem As DepreciationDisplayItem = (From A In AST201PFResult Where A.Number = EachItemNumber And A.Dept = EachItemDept Select A).FirstOrDefault
                If Not IsNothing(SecondDepreciationDisplayItem) Then
                    With EachItem
                        .DEPTSA = SecondDepreciationDisplayItem.Dept
                        .AST201PF_Depr = SecondDepreciationDisplayItem.Depr
                    End With
                End If
            Next
            ReturnValue = AST101PFResult
        End If

        If Not IsNowSearchAllFactory Then

            Dim DisplayItemNumber As Integer = 1
            For Each EachItem In (From A In ReturnValue Select A Order By A.DEPTSA, A.NumberKind).ToList
                EachItem.DisplayName = DisplayItemNumber
                DisplayItemNumber += 1
            Next

            ReturnValue = AddSubTotal((From A In ReturnValue Select A Order By A.DEPTSA, A.NumberKind).ToList)
            ReturnValue = AddEndTotal(ReturnValue)
        End If

        Return ReturnValue
    End Function

#Region "加入小計 函式:AddSubTotal"
    ''' <summary>
    ''' 加入小計
    ''' </summary>
    ''' <param name="Source"></param>
    ''' <remarks></remarks>
    Private Shared Function AddSubTotal(ByVal Source As List(Of DepreciationDisplayItem)) As List(Of DepreciationDisplayItem)
        Dim ReturnValue As New List(Of DepreciationDisplayItem)
        For Each EachDeptsa As String In (From A In Source Select A.DEPTSA).Distinct
            Dim CurrentDeptsa As String = EachDeptsa
            Dim DeptGroup As List(Of DepreciationDisplayItem) = (From A In Source Where A.DEPTSA = CurrentDeptsa Select A).ToList
            ReturnValue.AddRange(DeptGroup)
            For Each EachNumberKind As String In (From A In DeptGroup Select A.NumberKind).Distinct
                Dim CurrentNumberKind As String = EachNumberKind
                Dim NumberKindGroup As List(Of DepreciationDisplayItem) = (From A In DeptGroup Where A.NumberKind = CurrentNumberKind Select A).ToList
                Dim AddNumberKindItem As New DepreciationDisplayItem
                With AddNumberKindItem
                    .Name = "單位:" & CurrentDeptsa & "類別:" & CurrentNumberKind & " 小計"
                    .Amount = (From A In NumberKindGroup Select A.Amount).Sum
                    .AST201PF_Depr = (From A In NumberKindGroup Select A.AST201PF_Depr).Sum
                    .Quant = (From A In NumberKindGroup Select A.Quant).Sum
                    .Depr = (From A In NumberKindGroup Select A.Depr).Sum
                End With
                ReturnValue.Add(AddNumberKindItem)
            Next

            Dim AddDeptItem As New DepreciationDisplayItem
            With AddDeptItem
                .Name = "單位:" & CurrentDeptsa & " 小計"
                .Amount = (From A In DeptGroup Select A.Amount).Sum
                .AST201PF_Depr = (From A In DeptGroup Select A.AST201PF_Depr).Sum
                .Quant = (From A In DeptGroup Select A.Quant).Sum
                .Depr = (From A In DeptGroup Select A.Depr).Sum
            End With
            ReturnValue.Add(AddDeptItem)
        Next

        Return ReturnValue
    End Function


#End Region
#Region "加入總計 函式:AddEndTotal"
    ''' <summary>
    ''' 加入總計
    ''' </summary>
    ''' <param name="Source"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function AddEndTotal(ByVal Source As List(Of DepreciationDisplayItem)) As List(Of DepreciationDisplayItem)
        Dim ReturnValue As List(Of DepreciationDisplayItem) = Source
        For Each EachNumberKind As String In From B In (From A In Source Where A.NumberKind <> "" And A.NumberKind <> Nothing Select A.NumberKind).Distinct Select B Order By B
            Dim CurrentNumberKind As String = EachNumberKind
            Dim EachNumberKindTemp As String = EachNumberKind
            Dim NumberKindGroup As List(Of DepreciationDisplayItem) = (From A In Source Where A.NumberKind = EachNumberKindTemp Select A).ToList
            Dim AddNumberKindItem As New DepreciationDisplayItem
            With AddNumberKindItem
                .Name = "單位:全部 類別:" & CurrentNumberKind & " 小計"
                .Amount = (From A In NumberKindGroup Select A.Amount).Sum
                .AST201PF_Depr = (From A In NumberKindGroup Select A.AST201PF_Depr).Sum
                .Quant = (From A In NumberKindGroup Select A.Quant).Sum
                .Depr = (From A In NumberKindGroup Select A.Depr).Sum
            End With
            ReturnValue.Add(AddNumberKindItem)
        Next

        Dim AddTotalSumItem As New DepreciationDisplayItem
        Dim OrginPureTotalDatas As List(Of DepreciationDisplayItem) = (From A In Source Where A.NumberKind <> "" Select A).ToList
        With AddTotalSumItem
            .Name = "單位:全部 類別:全部"
            .Amount = (From A In OrginPureTotalDatas Select A.Amount).Sum
            .AST201PF_Depr = (From A In OrginPureTotalDatas Select A.AST201PF_Depr).Sum
            .Quant = (From A In OrginPureTotalDatas Select A.Quant).Sum
            .Depr = (From A In OrginPureTotalDatas Select A.Depr).Sum
        End With
        ReturnValue.Add(AddTotalSumItem)

        Return ReturnValue
    End Function
#End Region

    Friend Shared Function GetSelectAllAST101PFToDepreciationDisplayItem(ByVal FactoryName As String, Optional ByVal IsLastPreMonth As Boolean = False) As List(Of DepreciationDisplayItem)
        'Dim DBService As New CompanyLINQDB.AS400SQLQuery
        Dim DBService As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim ReturnValue As New List(Of DepreciationDisplayItem)
        Dim QueryResult As DataTable = Nothing
        If IsLastPreMonth Then
            QueryResult = DBService.SelectQuery("Select NUMBER,NAME,QUANT,AMOUNT,DATE,USLAFF,DEPT,DEPR FROM @#AST500LB.AST201PF.ASTF" & FactoryName.ToUpper)
        Else
            QueryResult = DBService.SelectQuery("Select NUMBER,NAME,QUANT,AMOUNT,DATE,USLAFF,DEPT,DEPR ,ACD2 FROM @#AST500LB.AST101PF.ASTF" & FactoryName.ToUpper)
        End If
        If IsNothing(QueryResult) Then
            Return ReturnValue
        End If

        'Dim AST201PFResult As New List(Of DepreciationDisplayItem)
        'For Each EachItem As DataRow In QueryResult2.Rows
        '    Dim AddItem As New DepreciationDisplayItem
        '    With AddItem
        '        .Number = EachItem.Item("NUMBER")
        '        .Depr = EachItem.Item("DEPR")
        '    End With
        '    ReturnValue.Add(AddItem)
        'Next

        For Each EachItem As DataRow In QueryResult.Rows
            Dim AddItem As New DepreciationDisplayItem
            With AddItem
                .Number = EachItem.Item("NUMBER")
                .Name = EachItem.Item("NAME")
                .Number = EachItem.Item("NUMBER")
                .Quant = EachItem.Item("QUANT")
                .Amount = EachItem.Item("AMOUNT")
                .StartDate = EachItem.Item("DATE")
                .Uslaff = EachItem.Item("USLAFF")
                .Depr = EachItem.Item("DEPR")
                .Dept = EachItem.Item("DEPT")
                If Not IsLastPreMonth Then
                    .ACD2 = EachItem.Item("ACD2")
                End If
                'Dim FindAST20PF As DepreciationDisplayItem = (From A In AST201PFResult Where A.Number = .Number Select A).FirstOrDefault
                'If Not IsNothing(FindAST20PF) Then
                '    .AST201PF_Depr = FindAST20PF.Depr
                'End If
            End With
            ReturnValue.Add(AddItem)
        Next
        Return ReturnValue
    End Function



#Region "顯示名稱 屬性:DisplayName"

    Private _DisplayName As String
    ''' <summary>
    ''' 顯示名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DisplayName() As String
        Get
            Return _DisplayName
        End Get
        Set(ByVal value As String)
            _DisplayName = value
        End Set
    End Property
#End Region

#Region "單位代碼 屬性:DEPTSA"
    Private _DEPTSA As String
    ''' <summary>
    ''' 單位代碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DEPTSA() As String
        Get
            Return _DEPTSA
        End Get
        Set(ByVal value As String)
            _DEPTSA = value
        End Set
    End Property

#End Region

#Region "資產編號 屬性:Number"

    Private _Number As String
    ''' <summary>
    ''' 資產編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Number() As String
        Get
            Return _Number
        End Get
        Set(ByVal value As String)
            _Number = value
        End Set
    End Property
#End Region

#Region "資產名稱 屬性:Name"
    Private _Name As String
    ''' <summary>
    ''' 資產名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property
#End Region

#Region "數量 屬性:Quant"

    Private _Quant As Integer
    ''' <summary>
    ''' 數量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Quant() As Integer
        Get
            Return _Quant
        End Get
        Set(ByVal value As Integer)
            _Quant = value
        End Set
    End Property
#End Region

#Region "帳面金額 屬性:Amount"

    Private _Amount As Double
    ''' <summary>
    ''' 帳面金額
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Amount() As Double
        Get
            Return _Amount
        End Get
        Set(ByVal value As Double)
            _Amount = value
        End Set
    End Property
#End Region

#Region "入帳年月 屬性:StartDate"

    Private _StartDate As String
    ''' <summary>
    ''' 入帳年月
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StartDate() As String
        Get
            Return _StartDate
        End Get
        Set(ByVal value As String)
            _StartDate = value
        End Set
    End Property
#End Region

#Region "使用年限 屬性:Uslaff"

    Private _Uslaff As String
    ''' <summary>
    ''' 使用年限
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Uslaff() As String
        Get
            Return _Uslaff
        End Get
        Set(ByVal value As String)
            _Uslaff = value
        End Set
    End Property
#End Region

#Region "累計折舊 屬性:Depr"
    Private _Depr As Double
    ''' <summary>
    ''' 累計折舊
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Depr() As Double
        Get
            Return _Depr
        End Get
        Set(ByVal value As Double)
            _Depr = value
        End Set
    End Property
#End Region

#Region "單位 屬性:Dept"
    Private _Dept As String
    ''' <summary>
    ''' 單位
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Dept() As String
        Get
            Return _Dept
        End Get
        Set(ByVal value As String)
            _Dept = value
        End Set
    End Property
#End Region

#Region "狀態 屬性:ACD2"

    Private _ACD2 As String
    ''' <summary>
    ''' 狀態
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ACD2() As String
        Get
            Return _ACD2
        End Get
        Set(ByVal value As String)
            _ACD2 = value
        End Set
    End Property

#End Region

#Region "前期AST201PF累計折舊 屬性:AST201PF_Depr"

    Private _AST201PF_Depr As Double
    ''' <summary>
    ''' 前期AST02PF累計折舊
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AST201PF_Depr() As Double
        Get
            Return _AST201PF_Depr
        End Get
        Set(ByVal value As Double)
            _AST201PF_Depr = value
        End Set
    End Property

#End Region

#Region "本月折舊 屬性:ThisMonthDepr"
    ''' <summary>
    ''' 本月折舊
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ThisMonthDepr() As Double
        Get
            Return Me.Depr - Me.AST201PF_Depr
        End Get
    End Property

#End Region

#Region "資產類別 屬性:NumberKind"
    ''' <summary>
    ''' 資產類別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NumberKind() As String
        Get
            If String.IsNullOrEmpty(Me.Number) Then
                Return Nothing
            End If
            Return Me.Number.Substring(0, 1)
        End Get
    End Property
#End Region


#Region "狀態中文名稱 屬性:ACD2_ChineseName"
    ''' <summary>
    ''' 狀態中文名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ACD2_ChineseName() As String
        Get
            Select Case Me.ACD2
                Case " "
                    Return "正常"
                Case "A"
                    Return "閒置"
                Case "B"
                    Return "出租"
            End Select
            Return Nothing
        End Get
    End Property
#End Region

End Class
