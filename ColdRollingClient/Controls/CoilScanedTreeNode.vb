Public Class CoilScanedTreeNode
    Inherits TreeNode


    'Sub New(ByVal SetTangOrCSCCoilFullNumber As String)
    '    CoilFullNumber = SetTangOrCSCCoilFullNumber
    '    NonCoilRunningOrderNodeText = CoilFullNumber
    '    SetImageIndexBySteelAndType()
    'End Sub

    'Sub New(ByVal SetTangOrCSCOrBWDCoilFullNumber As String, ByVal IsCPLOrAPLStation As Boolean)
    '    If IsCPLOrAPLStation Then
    '        Select Case GetHotCoilFromType(SetTangOrCSCOrBWDCoilFullNumber)
    '            Case HotCoilFromType.CSC
    '                CoilFullNumber = CSCNumToTangNum(SetTangOrCSCOrBWDCoilFullNumber)
    '                Dim CSCFullNumber As String = TangNumToCSCNum(CoilFullNumber)
    '                NonCoilRunningOrderNodeText = CoilFullNumber & IIf(CoilFullNumber <> CSCFullNumber, "/" & CSCFullNumber, Nothing)
    '            Case HotCoilFromType.BWD
    '                CoilFullNumber = BWDNumToTangNum(SetTangOrCSCOrBWDCoilFullNumber)
    '                Dim BWDFullNumber As String = TangNumToBWDNum(CoilFullNumber)
    '                NonCoilRunningOrderNodeText = CoilFullNumber & IIf(CoilFullNumber <> BWDFullNumber, "/" & BWDFullNumber, Nothing)
    '            Case Else
    '                CoilFullNumber = SetTangOrCSCOrBWDCoilFullNumber
    '                NonCoilRunningOrderNodeText = CoilFullNumber
    '        End Select
    '    Else
    '        CoilFullNumber = SetTangOrCSCOrBWDCoilFullNumber
    '        NonCoilRunningOrderNodeText = CoilFullNumber
    '    End If
    '    SetImageIndexBySteelAndType()
    'End Sub

    'Sub New(ByVal SetTangOrCSCOrBWDCoilFullNumber As String, ByVal SetCoilScanWaitProcessNumber As Integer, ByVal IsCPLOrAPLStation As Boolean)
    '    If IsCPLOrAPLStation Then
    '        Select Case GetHotCoilFromType(SetTangOrCSCOrBWDCoilFullNumber)
    '            Case HotCoilFromType.CSC
    '                CoilFullNumber = CSCNumToTangNum(SetTangOrCSCOrBWDCoilFullNumber)
    '                Dim CSCFullNumber As String = TangNumToCSCNum(CoilFullNumber)
    '                NonCoilRunningOrderNodeText = CoilFullNumber & IIf(CoilFullNumber <> CSCFullNumber, "/" & CSCFullNumber, Nothing)
    '            Case HotCoilFromType.BWD
    '                CoilFullNumber = BWDNumToTangNum(SetTangOrCSCOrBWDCoilFullNumber)
    '                Dim BWDFullNumber As String = TangNumToBWDNum(CoilFullNumber)
    '                NonCoilRunningOrderNodeText = CoilFullNumber & IIf(CoilFullNumber <> BWDFullNumber, "/" & BWDFullNumber, Nothing)
    '            Case Else
    '                CoilFullNumber = SetTangOrCSCOrBWDCoilFullNumber
    '                NonCoilRunningOrderNodeText = CoilFullNumber
    '        End Select
    '    Else
    '        CoilFullNumber = SetTangOrCSCOrBWDCoilFullNumber
    '        NonCoilRunningOrderNodeText = CoilFullNumber
    '    End If
    '    Me.CoilScanWaitProcessNumber = SetCoilScanWaitProcessNumber
    '    SetImageIndexBySteelAndType()
    'End Sub

    Sub New(ByVal SetTangOrCSCOrBWDCoilFullNumber As String)
        If IsCPLOrAPLOrZMLStation Then
            Select Case GetHotCoilFromType(SetTangOrCSCOrBWDCoilFullNumber)
                Case HotCoilFromType.CSC
                    CoilFullNumber = CSCNumToTangNum(SetTangOrCSCOrBWDCoilFullNumber)
                    Dim CSCFullNumber As String = TangNumToCSCNum(CoilFullNumber)
                    NonCoilRunningOrderNodeText = CoilFullNumber & IIf(CoilFullNumber <> CSCFullNumber, "/" & CSCFullNumber, Nothing)
                Case HotCoilFromType.BWD
                    CoilFullNumber = BWDNumToTangNum(SetTangOrCSCOrBWDCoilFullNumber)
                    Dim BWDFullNumber As String = TangNumToBWDNum(CoilFullNumber)
                    NonCoilRunningOrderNodeText = CoilFullNumber & IIf(CoilFullNumber <> BWDFullNumber, "/" & BWDFullNumber, Nothing)
                Case Else
                    CoilFullNumber = SetTangOrCSCOrBWDCoilFullNumber
                    NonCoilRunningOrderNodeText = CoilFullNumber
            End Select
        Else
            CoilFullNumber = SetTangOrCSCOrBWDCoilFullNumber
            NonCoilRunningOrderNodeText = CoilFullNumber
        End If
        SetImageIndexBySteelAndType()
    End Sub

    Sub New(ByVal SetTangOrCSCOrBWDCoilFullNumber As String, ByVal SetCoilScanWaitProcessNumber As Integer)
        If IsCPLOrAPLOrZMLStation Then
            Select Case GetHotCoilFromType(SetTangOrCSCOrBWDCoilFullNumber)
                Case HotCoilFromType.CSC
                    CoilFullNumber = CSCNumToTangNum(SetTangOrCSCOrBWDCoilFullNumber)
                    Dim CSCFullNumber As String = TangNumToCSCNum(CoilFullNumber)
                    NonCoilRunningOrderNodeText = CoilFullNumber & IIf(CoilFullNumber <> CSCFullNumber, "/" & CSCFullNumber, Nothing)
                Case HotCoilFromType.BWD
                    CoilFullNumber = BWDNumToTangNum(SetTangOrCSCOrBWDCoilFullNumber)
                    Dim BWDFullNumber As String = TangNumToBWDNum(CoilFullNumber)
                    NonCoilRunningOrderNodeText = CoilFullNumber & IIf(CoilFullNumber <> BWDFullNumber, "/" & BWDFullNumber, Nothing)
                Case Else
                    CoilFullNumber = SetTangOrCSCOrBWDCoilFullNumber
                    NonCoilRunningOrderNodeText = CoilFullNumber
            End Select
        Else
            CoilFullNumber = SetTangOrCSCOrBWDCoilFullNumber
            NonCoilRunningOrderNodeText = CoilFullNumber
        End If
        Me.CoilScanWaitProcessNumber = SetCoilScanWaitProcessNumber
        SetImageIndexBySteelAndType()
    End Sub

#Region "不含鋼捲執行順序之節點文字 屬性:NonCoilRunningOrderNodeText"
    Private _NonCoilRunningOrderNodeText As String
    ''' <summary>
    ''' 不含鋼捲執行順序之節點文字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NonCoilRunningOrderNodeText() As String
        Get
            Return _NonCoilRunningOrderNodeText
        End Get
        Set(ByVal value As String)
            _NonCoilRunningOrderNodeText = value
            Me.Text = IIf(IsWillShowCoilRunningOrder, CoilRunningOrderNumber & ".", Nothing) & _NonCoilRunningOrderNodeText.Trim & IIf(IsSpecialOrder, "列", Nothing)

            'APL2 Will Display Width
            If Not IsNothing(Me.AboutOperationPCRunningState) AndAlso Me.AboutOperationPCRunningState.DefaultUseStationName.PadRight(4).Substring(0, 4) = "APL2" Then
                Me.Text &= Format(Me.SteelGuage, "厚0.0")
            End If
        End Set
    End Property

#End Region
#Region "是否顯示鋼捲執行順序 屬性:IsWillShowCoilRunningOrder"
    Private _IsWillShowCoilRunningOrder As Boolean = False
    ''' <summary>
    ''' 是否顯示鋼捲執行順序
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsWillShowCoilRunningOrder() As Boolean
        Get
            Return _IsWillShowCoilRunningOrder
        End Get
        Set(ByVal value As Boolean)
            _IsWillShowCoilRunningOrder = value
            NonCoilRunningOrderNodeText = NonCoilRunningOrderNodeText   '更新節點文字
        End Set
    End Property

#End Region
#Region "鋼捲執行順序/鋼捲執行順序變更事件 屬性:CoilRunningOrderNumber/CoilRunningOrderNumberChanged"
    ''' <summary>
    ''' 鋼捲執行順序變更事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="NewCoilNumber"></param>
    ''' <remarks></remarks>
    Public Event CoilRunningOrderNumberChanged(ByVal sender As CoilScanedTreeNode, ByVal NewCoilNumber As String)
    Private _CoilRunningOrderNumber As Integer = 0
    ''' <summary>
    ''' 鋼捲執行順序
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CoilRunningOrderNumber() As Integer
        Get
            Return _CoilRunningOrderNumber
        End Get
        Set(ByVal value As Integer)
            Dim IsValueDifferent As Boolean = Not (value = _CoilRunningOrderNumber)
            _CoilRunningOrderNumber = value
            NonCoilRunningOrderNodeText = NonCoilRunningOrderNodeText   '更新節點文字
            If IsValueDifferent Then
                RaiseEvent CoilRunningOrderNumberChanged(Me, _CoilRunningOrderNumber)
            End If
        End Set
    End Property

#End Region


#Region "驗證鋼捲 函式:VerifyCoil"
    ''' <summary>
    ''' 驗證鋼捲
    ''' </summary>                                      
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function VerifyCoil() As Boolean
        Return True
        Try
            If MyPPSSHAPFFlowAdapter.FinalALLPPSSHAPFs.Count = 0 Then
                Me.Message = "資料庫中找不到任何鋼捲資料!"
                Return False
            End If
            Return True
        Catch ex As Exception
            Me.Message = ex.ToString
        End Try
        Return False
    End Function
#End Region

#Region "P.P排程檔流程配接器 屬性:MyPPSSHAPFFlowAdapter"

    Private _MyPPSSHAPFFlowAdapter As CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter
    ''' <summary>
    ''' P.P排程檔流程配接器
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MyPPSSHAPFFlowAdapter() As CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter
        Get
            Return _MyPPSSHAPFFlowAdapter
        End Get
        Private Set(ByVal value As CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter)
            _MyPPSSHAPFFlowAdapter = value
        End Set
    End Property

#End Region
#Region "訊息 屬性:Message"

    Private _Message As String = Nothing
    Public Property Message() As String
        Get
            Return _Message
        End Get
        Set(ByVal value As String)
            _Message = value
        End Set
    End Property

#End Region

#Region "鋼捲完整編號 屬性:CoilFullNumber"
    Private _CoilFullNumber As String
    ''' <summary>
    ''' 鋼捲完整編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CoilFullNumber() As String
        Get
            Return _CoilFullNumber
        End Get
        Set(ByVal value As String)
            Dim PreValue As String = _CoilFullNumber
            _CoilFullNumber = value
            If PreValue <> _CoilFullNumber OrElse String.IsNullOrEmpty(_CoilFullNumber) Then
                MyPPSSHAPFFlowAdapter = New CompanyORMDB.SQLServer.PPS100LB.PPSSHAPFFlowAdapter(_CoilFullNumber)
            End If
        End Set
    End Property
#End Region
#Region "鋼捲掃描進入準備編號 屬性:CoilScanWaitProcessNumber"

    Private _CoilScanWaitProcessNumber As Integer = 1
    ''' <summary>
    ''' 鋼捲掃描進入準備編號1.上線2.下線
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CoilScanWaitProcessNumber() As Integer
        Get
            Return _CoilScanWaitProcessNumber
        End Get
        Set(ByVal value As Integer)
            _CoilScanWaitProcessNumber = value
        End Set
    End Property

#End Region
#Region "外購鋼捲尋找 方法:FindOutsourcingCoilNumber"
    ''' <summary>
    ''' 外購鋼捲尋找
    ''' </summary>
    ''' <param name="FindCoilNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FindOutsourcingCoilNumber(ByVal FindCoilNumber As String) As String
        If IsNothing(FindCoilNumber) OrElse FindCoilNumber.Trim <= 10 Then
            Return FindCoilNumber
        End If
        FindCoilNumber = FindCoilNumber.Trim
        Dim FindNumber As String = FindCoilNumber.Trim.Substring(0, 10)
        Dim QryAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        Dim Qrystring As String = "Select count(*) from @#PPS100LB.PPSBLAPF Where bla01='" & FindNumber & "'"
        If Val(QryAdapter.SelectQuery(Qrystring).Rows(0).Item(0)) > 0 Then
            Return FindNumber
        End If
        FindNumber = FindCoilNumber.Trim.Substring(Len(FindCoilNumber) - 10, 10)
        Qrystring = "Select count(*) from @#PPS100LB.PPSBLAPF Where bla01='" & FindNumber & "'"
        If Val(QryAdapter.SelectQuery(Qrystring).Rows(0).Item(0)) > 0 Then
            Return FindNumber
        End If
        Return Nothing
    End Function
#End Region


#Region "轉換中鋼熱軋號碼至唐榮鋼捲號碼 方法:CSCNumToTangNum"
    ''' <summary>
    ''' 轉換中鋼熱軋號碼至唐榮鋼捲號碼
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CSCNumToTangNum(ByVal SourceNumber As String) As String
        '如果為中鋼鋼捲號碼(大於6位)
        If SourceNumber.Trim.Length < 7 Then
            Return SourceNumber
        End If
        Dim QryString As String = "Select BLA09 FROM @#PPS100LB.PPSBLAPF WHERE BLA01='" & SourceNumber & "' ORDER BY BLA08 DESC ,BLA13 DESC FETCH FIRST 1 ROWS ONLY"
        Dim DBAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
        Dim SearchResult As DataTable = DBAdapter.SelectQuery
        If SearchResult.Rows.Count > 0 Then
            Return CType(SearchResult.Rows(0).Item(0), String)
        End If
        Return SourceNumber
    End Function
#End Region
#Region "轉換唐榮鋼捲號碼至中鋼熱軋號碼 方法:TangNumToCSCNum"
    ''' <summary>
    ''' 轉換唐榮鋼捲號碼至中鋼熱軋號碼
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TangNumToCSCNum(ByVal SourceNumber As String) As String
        '如果為唐榮鋼捲號碼(等於5位)
        If SourceNumber.Trim.Length <> 5 Then
            Return SourceNumber
        End If
        Dim QryString As String = "Select BLA01 FROM @#PPS100LB.PPSBLAPF WHERE BLA09='" & SourceNumber & "' ORDER BY BLA13 DESC FETCH FIRST 1 ROWS ONLY"
        Dim DBAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
        Dim SearchResult As DataTable = DBAdapter.SelectQuery
        If SearchResult.Rows.Count > 0 Then
            Return CType(SearchResult.Rows(0).Item(0), String)
        End If
        Return SourceNumber
    End Function
#End Region
#Region "轉換代工熱軋號碼至唐榮鋼捲號碼 方法:BWDNumToTangNum"
    ''' <summary>
    ''' 轉換代工熱軋號碼至唐榮鋼捲號碼
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function BWDNumToTangNum(ByVal SourceNumber As String) As String
        '如果為代工鋼捲號碼(大於4位)
        If SourceNumber.Trim.Length < 5 Then
            Return SourceNumber
        End If
        Dim QryString As String = "Select BWD09 FROM @#PPS100LB.PPSBWDPF WHERE BWD01='" & SourceNumber & "' ORDER BY BWD08 DESC FETCH FIRST 1 ROWS ONLY"
        Dim DBAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
        Dim SearchResult As DataTable = DBAdapter.SelectQuery
        If SearchResult.Rows.Count > 0 Then
            Return CType(SearchResult.Rows(0).Item(0), String)
        End If
        Return SourceNumber
    End Function
#End Region
#Region "轉換唐榮鋼捲號碼至代工熱軋號碼 方法:TangNumToBWDNum"
    ''' <summary>
    ''' 轉換唐榮鋼捲號碼至代工熱軋號碼
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TangNumToBWDNum(ByVal SourceNumber As String) As String
        '如果為唐榮鋼捲號碼(等於5位)
        If SourceNumber.Trim.Length <> 5 OrElse SourceNumber.Substring(0, 1).PadRight(1) <> "X" Then
            Return SourceNumber
        End If
        Dim QryString As String = "Select BWD01 FROM @#PPS100LB.PPSBWDPF WHERE BWD09='" & SourceNumber & "' ORDER BY BWD08 FETCH FIRST 1 ROWS ONLY"
        Dim DBAdapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
        Dim SearchResult As DataTable = DBAdapter.SelectQuery
        If SearchResult.Rows.Count > 0 Then
            Return CType(SearchResult.Rows(0).Item(0), String)
        End If
        Return SourceNumber
    End Function
#End Region

#Region "鋼種 屬性:SteelKind"
    ''' <summary>
    ''' 鋼種
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SteelKind As String
        Get
            If Not IsNothing(Me.MyPPSSHAPFFlowAdapter) AndAlso Not IsNothing(Me.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF) Then
                Return Me.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF.SHA12
            End If
            Return ""
        End Get
    End Property
#End Region
#Region "鋼捲TYPE 屬性:SteelType"
    ''' <summary>
    ''' 鋼捲TYP
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SteelType As String
        Get
            If Not IsNothing(Me.MyPPSSHAPFFlowAdapter) AndAlso Not IsNothing(Me.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF) Then
                Return Me.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF.SHA13
            End If
            Return ""
        End Get
    End Property
#End Region
#Region "厚度 屬性:SteelGuage"
    ''' <summary>
    ''' 厚度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SteelGuage As Double
        Get
            If Not IsNothing(Me.MyPPSSHAPFFlowAdapter) AndAlso Not IsNothing(Me.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF) Then
                Return Me.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF.SHA14
            End If
            Return 0
        End Get
    End Property
#End Region
#Region "寬度 屬性:SteelWidth"
    ''' <summary>
    ''' 寬度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SteelWidth As Double
        Get
            If Not IsNothing(Me.MyPPSSHAPFFlowAdapter) AndAlso Not IsNothing(Me.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF) Then
                Return Me.MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF.SHA15
            End If
            Return 0

        End Get
    End Property
#End Region
#Region "是否為CPL或APL站台 屬性:IsCPLOrAPLStation"
    ''' <summary>
    ''' 是否為CPL或APL站台
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsCPLOrAPLOrZMLStation As Boolean
        Get
            If IsNothing(Me.AboutOperationPCRunningState) Then
                Return False
            End If
            Dim StationName As String = Me.AboutOperationPCRunningState.DefaultUseStationName
            Return StationName.Substring(0, 2) = "CP" OrElse StationName.Substring(0, 2) = "AP" OrElse StationName.Substring(0, 2) = "ZM"
        End Get
    End Property
#End Region
#Region "本站種類(CPL1與CPL2算同一站)執行次數 屬性:TheStationKindRunCount"
    ''' <summary>
    ''' 本站種類(CPL1與CPL2算同一站)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TheStationKindRunCount As Integer
        Get
            'Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
            'Dim QryString As String = "Select * from OperationPCRunningState Where RunningPCIP='" & PPSSHAPFFlowAdapter.TheMachinePCRunningState.RunningPCIP.Trim & "'"
            'Dim ThisStationName As String = Nothing
            'Dim SearchResult As DataTable = Adapter.SelectQuery(QryString)
            'If SearchResult.Rows.Count > 0 Then
            '    ThisStationName = CType(SearchResult.Rows(0).Item("DefaultUseStationName"), String).Trim.Substring(0, 3)
            'End If

            Dim Adapter As New CompanyORMDB.SQLServerSQLQueryAdapter(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
            Dim QryString As String
            Dim SearchResult As DataTable
            Dim ThisStationName As String = Nothing
            If Not IsNothing(Me.AboutOperationPCRunningState) Then
                ThisStationName = Me.AboutOperationPCRunningState.DefaultUseStationName
            End If

            QryString = "Select * from StationToWebClientPCAccount "
            SearchResult = Adapter.SelectQuery(QryString)
            Dim StationNameIPs As String = Nothing
            For Each EachItem As DataRow In SearchResult.Rows
                If CType(EachItem.Item("StationName"), String).Trim.Substring(0, 3) = ThisStationName Then
                    StationNameIPs &= IIf(String.IsNullOrEmpty(StationNameIPs), "", ",") & CType(EachItem.Item("ClientIP"), String).Trim
                End If
            Next

            QryString = "Select Count(*) from RunProcessData Where RunStationPCIP in ('" & StationNameIPs.Replace(",", "','") & "')"
            QryString &= " and (FK_LastRefSHA01 + LTRIM(FK_LastRefSHA02))='" & Me.CoilFullNumber.Trim & "' "
            Return CType(Adapter.SelectQuery(QryString).Rows(0).Item(0), Integer)
        End Get
    End Property
#End Region

#Region "取得鋼捲號碼來源種類 屬性:GetHotCoilFromType"
    ''' <summary>
    ''' 取得鋼捲號碼來源種類
    ''' </summary>
    ''' <param name="FindCoilNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetHotCoilFromType(ByVal FindCoilNumber As String) As HotCoilFromType
        Dim OrginFindCoilNumber As String = FindCoilNumber.Trim
        Select Case True
            Case CSCNumToTangNum(FindCoilNumber).Trim <> OrginFindCoilNumber
                Return HotCoilFromType.CSC
            Case TangNumToCSCNum(FindCoilNumber).Trim <> OrginFindCoilNumber
                Return HotCoilFromType.CSC
            Case BWDNumToTangNum(FindCoilNumber).Trim <> OrginFindCoilNumber
                Return HotCoilFromType.BWD
            Case TangNumToBWDNum(FindCoilNumber).Trim <> OrginFindCoilNumber
                Return HotCoilFromType.BWD
        End Select
        Return HotCoilFromType.UnKnow
    End Function
#End Region
#Region "熱軋鋼捲來源種類 列舉:HotCoilFromType"
    ''' <summary>
    ''' 熱軋鋼捲來源種類
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum HotCoilFromType
        UnKnow = 0      '未知
        CSC = 2         '中鋼鋼捲
        BWD = 3         '代工鋼捲
        'Outsourcing = 4 '外購鋼捲
    End Enum
#End Region

#Region "依鋼種Type設定圖片 函式:SetImageIndexBySteelAndType"
    Public Sub SetImageIndexBySteelAndType()

        Me.ImageIndex = 0
        Try
            Dim mySteelKind As String = Me.SteelKind.Trim
            Dim mySteelType As String = Me.SteelType.Trim
            Select Case True
                Case mySteelKind.PadRight(3).Substring(0, 3) = "201"
                    Me.ImageIndex = 1
                Case mySteelKind.PadRight(3).Substring(0, 3) = "202" AndAlso mySteelType = "TE"
                    Me.ImageIndex = 2
                Case mySteelKind.PadRight(3).Substring(0, 3) = "202"
                    Me.ImageIndex = 3
                Case mySteelKind.PadRight(3).Substring(0, 3) = "301"
                    Me.ImageIndex = 4
                Case mySteelKind.PadRight(3).Substring(0, 3) = "304"
                    Me.ImageIndex = 5
            End Select
        Catch ex As Exception
            Me.ImageIndex = 0
        End Try
        Me.SelectedImageIndex = Me.ImageIndex
    End Sub
#End Region

#Region "是否為列管訂單 屬性:IsSpecialOrder"
    ''' <summary>
    ''' 是否為列管訂單
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsSpecialOrder As Boolean
        Get
            If IsNothing(MyPPSSHAPFFlowAdapter) Then
                Return False
            End If
            Dim GetPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = MyPPSSHAPFFlowAdapter.CoilFullNumberForLastPPSSHAPF
            If IsNothing(GetPPSSHAPF) Then
                Return False
            End If
            Return Not IsNothing(GetPPSSHAPF.AboutSL2CIDPF)
        End Get
    End Property
#End Region

#Region "相關OperationPCRunningState  屬性:AboutOperationPCRunningState"
    Private _AboutOperationPCRunningState As OperationPCRunningState = Nothing
    Private _AboutOperationPCRunningStateAccessTime As DateTime = New Date(Now.Year)
    ''' <summary>
    ''' 相關OperationPCRunningState
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AboutOperationPCRunningState As OperationPCRunningState
        Get
            If Now.Subtract(_AboutOperationPCRunningStateAccessTime).TotalSeconds > 3 AndAlso IsNothing(_AboutOperationPCRunningState) Then
                Dim QryString As String = "Select * from OperationPCRunningState Where RunningPCIP='" & PPSSHAPFFlowAdapter.TheMachinePCRunningState.RunningPCIP.Trim & "'"
                Dim SearchResult As List(Of CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState) = CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.OperationPCRunningState)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                If SearchResult.Count > 0 Then
                    _AboutOperationPCRunningState = SearchResult(0)
                End If
            End If
            _AboutOperationPCRunningStateAccessTime = Now
            Return _AboutOperationPCRunningState
        End Get
    End Property
#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
