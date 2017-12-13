Public Class BugKeyboard

    Public WithEvents NumberKeyboardEvent As NumberKeyboard

    Public Event BugCallBackEvent(ByVal Sender As Object, ByVal UserSelectBugData As QABUG)

#Region "載入/重新載入缺資料 函式:LoadBugData"
    Private Sub LoadBugData()
        AllBugDatas.Clear()
        Dim QryString As String = "Select * from QABug "
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
                SearchResult = (From A In AllBugDatas Where A.APL1SortNumber >= 0 Select A Order By A.APL1SortNumber Ascending).ToList
            Case TheStationName = "APL2"
                SearchResult = (From A In AllBugDatas Where A.APL2SortNumber >= 0 Select A Order By A.APL2SortNumber Ascending).ToList
            Case TheStationName = "BAL"
                SearchResult = (From A In AllBugDatas Where A.BALSortNumber >= 0 Select A Order By A.BALSortNumber Ascending).ToList
            Case Else
                Exit Sub
        End Select
        If Not String.IsNullOrEmpty(DisplayFilterBugNumber) Then
            SearchResult = (From A In SearchResult Where A.Number.Substring(0, DisplayFilterBugNumber.Length) = DisplayFilterBugNumber Select A).ToList
        End If
        Dim IsEval As Boolean = True
        For Each Eachitem As QABUG In SearchResult
            Dim AddNode As New TreeNode(Eachitem.Number.Trim & "." & Eachitem.CName.Replace(".", Nothing))
            AddNode.BackColor = IIf(IsEval, Color.White, Color.LightBlue)
            TreeView1.Nodes.Add(AddNode)
            IsEval = Not IsEval
        Next
        lbCoilNumberSelect.Text = "缺陷選擇:" & DisplayFilterBugNumber
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
#Region "鋼捲編號 屬性:CoilNumber"
    ''' <summary>
    ''' 鋼捲編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property CoilNumber As String
        Get
            Return lbCoilNumber.Text
        End Get
        Set(value As String)
            lbCoilNumber.Text = value
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
        End Set
    End Property
#End Region

#Region "重設預設值 函式:ResetDefault"
    ''' <summary>
    ''' 重設預設值
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetDefault()
        lbCoilNumber.Text = Nothing
        DisplayFilterBugNumber = ""
        lbCoilNumberSelect.Text = "缺陷選擇:"
        TreeView1.SelectedNode = Nothing
        RefreshShowBugData()
    End Sub
#End Region

    Sub New(ByVal SetStationName As String)
        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        LoadBugData()
        Dim NumberControl As New NumberKeyboard
        NumberKeyboardEvent = NumberControl
        Panel1.Controls.Add(NumberControl)
        NumberControl.Dock = DockStyle.Fill
        TheStationName = SetStationName
        ResetDefault()
    End Sub

    Private Sub NumberKeyboardEvent_ButtonClickEvent(sender As Object, Value As String) Handles NumberKeyboardEvent.ButtonClickEvent
        Select Case True
            Case Value = "DELETE" AndAlso DisplayFilterBugNumber.Length > 0
                DisplayFilterBugNumber = DisplayFilterBugNumber.Substring(0, DisplayFilterBugNumber.Length - 1)
            Case Value = "CLEAR"
                DisplayFilterBugNumber = ""
            Case Else
                DisplayFilterBugNumber &= Value
        End Select
        RefreshShowBugData()
    End Sub

    Private Sub btnCancelAndReturn_Click(sender As Object, e As EventArgs) Handles btnCancelAndReturn.Click
        ResetDefault()
        RaiseEvent BugCallBackEvent(Me, Nothing)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        If IsNothing(TreeView1.SelectedNode) Then
            Exit Sub
        End If
        Dim SelectNumber As String = TreeView1.SelectedNode.Text.Trim
        Dim UserSelectItem As QABUG = (From A In AllBugDatas Where A.Number.Trim = SelectNumber Select A).FirstOrDefault
        ResetDefault()
        If Not IsNothing(UserSelectItem) Then
            RaiseEvent BugCallBackEvent(Me, UserSelectItem)
        End If
    End Sub

End Class
