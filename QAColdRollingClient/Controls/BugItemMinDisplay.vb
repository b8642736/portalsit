Public Class BugItemMinDisplay


#Region "父控主制項 屬性:ParentMainControl"
    Private _ParentMainControl As MainControl
    ''' <summary>
    ''' 父控主制項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ParentMainControl As MainControl
        Get
            Return _ParentMainControl
        End Get
        Set(value As MainControl)
            _ParentMainControl = value
        End Set
    End Property
#End Region
#Region "載入/重新載入缺資料 函式:LoadBugData"
    Private Sub LoadBugData()
        If AllBugDatas.Count > 0 Then
            Exit Sub
        End If
        AllBugDatas.Clear()
        Dim QryString As String = "Select * from QABug "
        Dim SearchResult As List(Of QABUG) = QABUG.CDBSelect(Of QABUG)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
        AllBugDatas.AddRange(SearchResult)
    End Sub
#End Region
#Region "所有缺限資料 屬性:AllBugDatas"
    Shared Property AllBugDatas As List(Of QABUG) = New List(Of QABUG)
#End Region

#Region "缺陷資料 屬性:QABugRecordData"
    Private _QABugRecordData As QABugRecord
    ''' <summary>
    ''' 缺陷資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property QABugRecordData As QABugRecord
        Get
            Return _QABugRecordData
        End Get
        Set(value As QABugRecord)
            _QABugRecordData = value
            If IsNothing(_QABugRecordData) Then
                lbBug_Number.Text = "--"
                lbCycle.Text = "--"
                lbPosition.Text = "--"
                lbDistribute.Text = "--"
                lbPosOrNeg.Text = "--"
                lbDensity.Text = "--"
                lbDegree.Text = "--"
            Else
                With _QABugRecordData
                    Dim FindBugDifineInfo As QABUG = (From A In AllBugDatas Where A.Number.Trim = .QABug_Number.Trim Select A).FirstOrDefault
                    lbBug_Number.Text = .QABug_Number
                    If Not IsNothing(FindBugDifineInfo) AndAlso FindBugDifineInfo.IsAttentation Then
                        lbBug_Number.BackColor = Color.Red
                    Else
                        lbBug_Number.BackColor = lbItemNumber.BackColor
                    End If
                    'If Not String.IsNullOrEmpty(lbBug_Number.Text) AndAlso lbBug_Number.Text.Trim = "33" Then
                    '    lbBug_Number.ForeColor = Color.FromName("Green")
                    'End If
                    lbDegree.Text = .Degree
                    'If .EndPosition >= .CoilMaxLength Then
                    If Not IsNothing(Me.ParentMainControl.CurrentEditQABugRecordTitle) AndAlso .EndPosition >= Me.ParentMainControl.CurrentEditQABugRecordTitle.CoilMaxLength Then
                        lbPosition.Text = .StartPosition & "~" & Me.ParentMainControl.CurrentEditQABugRecordTitle.CoilMaxLength
                        lbPosition.ForeColor = Color.Red
                    Else
                        lbPosition.Text = .StartPosition & "~" & vbNewLine & .EndPosition
                        lbPosition.ForeColor = Color.Black
                    End If
                    If .DPositionType = 0 OrElse .DPositionType = 5 Then
                        lbDistribute.Text = .DPositionTypeName
                    Else
                        lbDistribute.Text = .DPositionTypeName & ":" & vbNewLine & .DPositionStart & "~" & vbNewLine & .DPositionEnd
                    End If
                    lbPosOrNeg.Text = .PosOrNeg
                    lbDensity.Text = .Density
                    lbCycle.Text = .Cycle
                End With
            End If
        End Set
    End Property

#End Region
#Region "項次 屬性:ItemNumber"
    ''' <summary>
    ''' 項次
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ItemNumber As String
        Get
            Return lbItemNumber.Text
        End Get
        Set(value As String)
            lbItemNumber.Text = value
        End Set
    End Property

#End Region
#Region "是否要顯示抬頭 屬性:IsWillShowTitle"
    Private _IsWillShowTitle As Boolean = True
    ''' <summary>
    ''' 是否要顯示抬頭
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsWillShowTitle As Boolean
        Get
            Return _IsWillShowTitle
        End Get
        Set(value As Boolean)
            _IsWillShowTitle = value
            If _IsWillShowTitle Then
                TableLayoutPanel1.RowStyles(0).Height = 50
            Else
                TableLayoutPanel1.RowStyles(0).Height = 0
            End If
        End Set
    End Property
#End Region
#Region "是否要顯示資料明細 屬性:IsWillShowDatadetail"
    Private _IsWillShowDatadetail As Boolean = True
    ''' <summary>
    ''' 是否要顯示資料明細
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsWillShowDatadetail() As Boolean
        Get
            Return _IsWillShowDatadetail
        End Get
        Set(ByVal value As Boolean)
            _IsWillShowDatadetail = value
            If _IsWillShowDatadetail Then
                TableLayoutPanel1.RowStyles(1).Height = 50 ' New RowStyle(SizeType.Percent, 50)
            Else
                TableLayoutPanel1.RowStyles(1).Height = 0
            End If

        End Set
    End Property

#End Region
#Region "是否可以編修 屬性:IsCanEdit"
    Private _IsCanEdit As Boolean = False
    ''' <summary>
    ''' 是否可以編修
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsCanEdit As Boolean
        Get
            Return _IsCanEdit
        End Get
        Set(value As Boolean)
            _IsCanEdit = value
            If _IsCanEdit Then
                Me.BackColor = Color.LightGreen
            Else
                Me.BackColor = Color.LightGray
            End If
        End Set
    End Property
#End Region

#Region "傳送按鈕命令 列舉:ButtonTypeEnum"
    Public Enum ButtonTypeEnum
        BugNumberButton = 1
        DegreeButton = 2
        LengthButton = 3
        DPositionButton = 4
        PosOrNegButton = 5
        DensityButton = 6
        CycleButton = 7
    End Enum
#End Region


    Public Event ControlMouseDownClick(ByVal Sender As BugItemMinDisplay, e As MouseEventArgs, ByVal SendButtonType As BugItemMinDisplay.ButtonTypeEnum)

    Sub New(ByVal SetQABugRecord As QABugRecord, ByVal SetParentMainControl As MainControl)
        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        ParentMainControl = SetParentMainControl
        If Not IsNothing(SetQABugRecord) Then
            LoadBugData()
            Me.IsCanEdit = False
            Me.QABugRecordData = SetQABugRecord
        End If
    End Sub

    Private Sub BugItemMinDisplay_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Each EachControl As Control In TableLayoutPanel1.Controls
            AddHandler EachControl.MouseDown, AddressOf BugItemMinDisplay_MouseDown
        Next
        AddHandler TableLayoutPanel1.MouseDown, AddressOf BugItemMinDisplay_MouseDown
    End Sub

    Private Sub BugItemMinDisplay_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If Not IsCanEdit Then
            Exit Sub
        End If
        Select Case True
            Case sender Is lbBug_Number
                RaiseEvent ControlMouseDownClick(Me, e, ButtonTypeEnum.BugNumberButton)
            Case sender Is lbDegree  'ButtonTypeEnum.DegreeButton
                RaiseEvent ControlMouseDownClick(Me, e, ButtonTypeEnum.DegreeButton)
            Case sender Is lbPosition
                RaiseEvent ControlMouseDownClick(Me, e, ButtonTypeEnum.LengthButton)
            Case sender Is lbDistribute
                RaiseEvent ControlMouseDownClick(Me, e, ButtonTypeEnum.DPositionButton)
            Case sender Is lbPosOrNeg
                RaiseEvent ControlMouseDownClick(Me, e, ButtonTypeEnum.PosOrNegButton)
            Case sender Is lbDensity
                RaiseEvent ControlMouseDownClick(Me, e, ButtonTypeEnum.DensityButton)
            Case sender Is lbCycle
                RaiseEvent ControlMouseDownClick(Me, e, ButtonTypeEnum.CycleButton)
        End Select
    End Sub


End Class
