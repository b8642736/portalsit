Public Class BugEdit_BugInput

    Public WithEvents NumberKeyboardEvent As NumberKeyboard

    Public Event BugCallBackEvent(ByVal Sender As Object, ByVal UserSelectBugData As QABUG)

#Region "父控主制項 屬性:ParentMainControl"
    Private _ParentBugItemEditControl As BugItemEdit
    ''' <summary>
    ''' 父控主制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ParentBugItemEditControl As BugItemEdit
        Get
            Return _ParentBugItemEditControl
        End Get
        Set(value As BugItemEdit)
            _ParentBugItemEditControl = value
        End Set
    End Property
#End Region
#Region "載入/重新載入缺資料 函式:LoadBugData"
    Private Sub LoadBugData()
        AllBugDatas.Clear()
        Dim QryString As String = "Select * from QABug "
        Select Case True
            Case TheStationName = "APL1"
                QryString &= " Order by APL1SortNumber,Number"
            Case TheStationName = "APL2"
                QryString &= " Order by APL2SortNumber,Number"
            Case TheStationName = "BAL"
                QryString &= " Order by BALSortNumber,Number"
        End Select
        Dim SearchResult As List(Of QABUG) = QABUG.CDBSelect(Of QABUG)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
        AllBugDatas.AddRange(SearchResult)
    End Sub
#End Region
#Region "所有缺限資料 屬性:AllBugDatas"
    Property AllBugDatas As List(Of QABUG) = New List(Of QABUG)
#End Region

#Region "重整顯示缺陷 函式:RefreshShowBugData"
    ''' <summary>
    ''' 重整顯示缺陷
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshShowBugData()
        TreeView1.Nodes.Clear()
        If String.IsNullOrEmpty(TheStationName) OrElse Not {"APL1", "APL2", "BAL"}.Contains(TheStationName) Then
            Exit Sub
        End If

        Dim SearchResult As List(Of QABUG)
        Select Case True
            Case TheStationName = "APL1"
                SearchResult = (From A In AllBugDatas Where A.APL1SortNumber >= 0 Select A Order By A.APL1SortNumber Ascending).Union((From A In AllBugDatas Where A.APL1SortNumber < 0 Select A Order By A.Number Ascending)).ToList
            Case TheStationName = "APL2"
                SearchResult = (From A In AllBugDatas Where A.APL2SortNumber >= 0 Select A Order By A.APL2SortNumber Ascending).Union((From A In AllBugDatas Where A.APL2SortNumber < 0 Select A Order By A.Number Ascending)).ToList
            Case TheStationName = "BAL"
                SearchResult = (From A In AllBugDatas Where A.BALSortNumber >= 0 Select A Order By A.BALSortNumber Ascending).Union((From A In AllBugDatas Where A.BALSortNumber < 0 Select A Order By A.Number Ascending)).ToList
            Case Else
                Exit Sub
        End Select
        If Not String.IsNullOrEmpty(DisplayFilterBugNumber) Then
            SearchResult = (From A In SearchResult Where A.Number.Substring(0, DisplayFilterBugNumber.Length) = DisplayFilterBugNumber Select A).ToList
        End If
        Dim IsEval As Boolean = True
        Dim StartShowPageRecordCount As Integer = (ShowDataPage - 1) * 7 + 1
        Dim DataRowCount As Integer = 1
        For Each Eachitem As QABUG In SearchResult
            If DataRowCount < StartShowPageRecordCount Then
                DataRowCount += 1
                Continue For
            End If
            Dim AddNode As New TreeNode(Eachitem.Number.Trim & "." & Eachitem.CName.Replace(".", Nothing))
            AddNode.BackColor = IIf(IsEval, Color.White, Color.LightBlue)
            AddNode.Tag = Eachitem.Number
            TreeView1.Nodes.Add(AddNode)
            DataRowCount += 1
            IsEval = Not IsEval
        Next
    End Sub
#End Region

#Region "本機站名 屬性:TheStationName"
    Private _TheStationName As String = Nothing
    ''' <summary>
    ''' 本機站名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property TheStationName As String
        Get
            Return _TheStationName
        End Get
        Set(value As String)
            _TheStationName = value

        End Set
    End Property
#End Region
#Region "顯示篩選缺限編號 屬性:DisplayFilterBugNumber"
    Private _DisplayFilterBugNumber As String = ""
    ''' <summary>
    ''' 顯示篩選缺限編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property DisplayFilterBugNumber As String
        Get
            Return _DisplayFilterBugNumber
        End Get
        Set(value As String)
            _DisplayFilterBugNumber = value
            If _DisplayFilterBugNumber.Length > 5 Then
                _DisplayFilterBugNumber = _DisplayFilterBugNumber.Substring(0, 5)
            End If
            ShowDataPage = 1
        End Set
    End Property
#End Region
#Region "顯示缺限資料頁數 屬性:ShowDataPage"
    Private _ShowDataPage As Integer = 1
    ''' <summary>
    ''' 顯示缺限資料頁數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ShowDataPage() As Integer
        Get
            Return _ShowDataPage
        End Get
        Set(ByVal value As Integer)
            _ShowDataPage = value
            If _ShowDataPage <= 0 Then
                _ShowDataPage = 1
            End If
            lbPage.Text = ShowDataPage
        End Set
    End Property

#End Region

#Region "重設預設值 函式:ResetDefault"
    ''' <summary>
    ''' 重設預設值
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ResetDefault()
        DisplayFilterBugNumber = ""
        TreeView1.SelectedNode = Nothing
        ShowDataPage = 1
        RefreshShowBugData()
    End Sub
#End Region

#Region "初始化控制項值 屬性:InitControlValue"
    ''' <summary>
    ''' 初始化控制項值
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitControlValue(ByVal SetInitBugData As QABUG)
        For Each EachNode As TreeNode In TreeView1.Nodes
            If EachNode.Tag.ToString = SetInitBugData.Number Then
                TreeView1.SelectedNode = EachNode : Exit Sub
                Exit Sub
            End If
        Next
    End Sub

    Public Sub InitControlValue(ByVal SetInitBugDataNumber As String)
        If String.IsNullOrEmpty(SetInitBugDataNumber) OrElse SetInitBugDataNumber.Trim.Length = 0 Then
            Exit Sub
        End If
        For Each EachItem As QABUG In Me.AllBugDatas
            If EachItem.Number.Trim = SetInitBugDataNumber.Trim Then
                InitControlValue(EachItem) : Exit Sub
            End If
        Next
    End Sub
    Public Sub InitControlValue(ByVal SetInitQABugRecord As QABugRecord)
        If Not IsNothing(SetInitQABugRecord) Then
            InitControlValue(SetInitQABugRecord.QABug_Number)
        End If
    End Sub
#End Region

    Sub New(ByVal SetStationName As String, ByVal SetBugItemEditControl As BugItemEdit)
        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.ParentBugItemEditControl = SetBugItemEditControl
        TheStationName = SetStationName
        LoadBugData()

        Dim NumberControl As New NumberKeyboard
        NumberKeyboardEvent = NumberControl
        Panel1.Controls.Add(NumberControl)
        NumberControl.Dock = DockStyle.Fill
        ResetDefault()
    End Sub

    Private Sub NumberKeyboardEvent_ButtonClickEvent(sender As Object, Value As String) Handles NumberKeyboardEvent.ButtonClickEvent
        Select Case True
            Case Value = "DELETE" AndAlso DisplayFilterBugNumber.Length > 0
                DisplayFilterBugNumber = DisplayFilterBugNumber.Substring(0, DisplayFilterBugNumber.Length - 1)
            Case Value = "DELETE"
            Case Value = "CLEAR"
                DisplayFilterBugNumber = ""
            Case Value = "DOT"
            Case Value = "OK"
                Dim UserSelectItem As QABUG = Nothing
                If Not IsNothing(TreeView1.SelectedNode) Then
                    Dim SelectNumber As String = TreeView1.SelectedNode.Tag.Trim
                    UserSelectItem = (From A In AllBugDatas Where A.Number.Trim = SelectNumber Select A).FirstOrDefault
                Else
                    If String.IsNullOrEmpty(Me.ParentBugItemEditControl.EditQABugRecord.QABug_Number) AndAlso TreeView1.Nodes.Count > 0 Then
                        Dim SelectNumber As String = TreeView1.Nodes(0).Tag.Trim
                        UserSelectItem = (From A In AllBugDatas Where A.Number.Trim = SelectNumber Select A).FirstOrDefault
                    End If
                End If
                RaiseEvent BugCallBackEvent(Me, UserSelectItem)
            Case Else
                DisplayFilterBugNumber &= Value
        End Select
        RefreshShowBugData()
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If IsNothing(TreeView1.SelectedNode) Then
            Exit Sub
        End If
        Dim SelectNumber As String = TreeView1.SelectedNode.Tag.Trim
        Dim UserSelectItem As QABUG = (From A In AllBugDatas Where A.Number.Trim = SelectNumber Select A).FirstOrDefault
        If Not IsNothing(UserSelectItem) Then
            RaiseEvent BugCallBackEvent(Me, UserSelectItem)
        End If
        ResetDefault()
    End Sub

    Private Sub btnPageDown_Click(sender As Object, e As EventArgs) Handles btnPageDown.Click, btnPageUP.Click
        Select Case True
            Case sender Is btnPageDown
                ShowDataPage += 1
            Case sender Is btnPageUP
                ShowDataPage -= 1
        End Select
        RefreshShowBugData()
    End Sub
End Class
