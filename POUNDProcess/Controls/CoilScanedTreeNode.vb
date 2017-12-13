Public Class CoilScanedTreeNode
    Inherits TreeNode


    Sub New(ByVal SetTangCoilFullNumber As String, ByVal SetLineStationName As String, ByVal SetBaseStartOrderNumber As Integer, ByVal SetLoginUserID As String)
        Me.LoginUserID = SetLoginUserID
        Me.BaseStartOrderNumber = SetBaseStartOrderNumber
        Me.CoilFullNumber = SetTangCoilFullNumber
        Me.LineStationName = SetLineStationName
        Me.ImageIndex = 1
        Me.SelectedImageIndex = 2
    End Sub

    Sub New(ByVal SetPPSCICPFData As CompanyORMDB.PPS100LB.PPSCICPF, ByVal SetBaseStartOrderNumber As Integer, ByVal SetLoginUserID As String)
        Me.LoginUserID = SetLoginUserID
        Me.BaseStartOrderNumber = SetBaseStartOrderNumber
        Me.CoilFullNumber = SetPPSCICPFData.CoilFullNumber
        Me.AboutPPSCICPF = SetPPSCICPFData
        Me.ImageIndex = 1
        Me.SelectedImageIndex = 2
    End Sub


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
            _CoilFullNumber = value
        End Set
    End Property

#End Region
#Region "產線站台名稱 屬性:LineStationName"
    Private _LineStationName As String
    ''' <summary>
    ''' 產線站台名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LineStationName() As String
        Get
            Return _LineStationName
        End Get
        Private Set(ByVal value As String)
            _LineStationName = value
        End Set
    End Property

#End Region
#Region "登入者ID  屬性:LoginUserID"
    Private _LoginUserID As String
    Public Property LoginUserID() As String
        Get
            Return _LoginUserID
        End Get
        Set(ByVal value As String)
            _LoginUserID = value
        End Set
    End Property

#End Region
#Region "由資料庫中讀取過磅鋼捲資料 方法:ReadPPSCICPFFromDB"
    ''' <summary>
    ''' 由資料庫中讀取過磅鋼捲資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadPPSCICPFFromDB() As Boolean
        Dim Today As Integer = New CompanyORMDB.AS400DateConverter(Now).TwIntegerTypeData
        Dim Qry As String = "Select * from @#PPS100LB.PPSCICPF WHERE CIC00='" & Me.LineStationName & "' AND CIC01 || CIC02 ='" & Me.CoilFullNumber.PadRight(10) & "' and CIC03=" & Today & " order by CIC03 desc ,CIC04 desc"
        Dim SearchResult As List(Of CompanyORMDB.PPS100LB.PPSCICPF) = CompanyORMDB.PPS100LB.PPSCICPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSCICPF)(Qry, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        If SearchResult.Count = 0 Then
            Me.AboutPPSCICPF = Nothing
            Return False
        End If
        Me.AboutPPSCICPF = SearchResult(0)
        Return True
    End Function
#End Region
#Region "儲存/建立過磅鋼捲資料至資料庫 方法:SaveToPPSCICPF"
    ''' <summary>
    ''' 儲存/建立過磅鋼捲資料至資料庫
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SaveToPPSCICPF(Optional WillOrderNumber As Boolean = False) As Boolean
        If IsNothing(Me.TreeView) Then
            Throw New Exception("請先將此節點加入TreeView中")
        End If
        Dim SaveObject As CompanyORMDB.PPS100LB.PPSCICPF = Me.AboutPPSCICPF
        If IsNothing(SaveObject) Then
            SaveObject = New CompanyORMDB.PPS100LB.PPSCICPF
            With SaveObject
                .CIC00 = LineStationName
                .CIC01 = Me.CoilFullNumber.PadRight(5).Substring(0, 5)
                .CIC02 = Me.CoilFullNumber.PadRight(10).Substring(5, 5)
                .CIC03 = New CompanyORMDB.AS400DateConverter(Now).TwIntegerTypeData
                .CIC04 = Format(Now, "hhMMss")
                .CIC05 = GetTreeViewOrderNumber()
                .CIC94 = Me.LoginUserID
            End With
        End If
        If WillOrderNumber Then
            SaveObject.CIC05 = GetTreeViewOrderNumber()
        End If

        Dim ReturnValue As Integer = SaveObject.CDBSave
        If ReturnValue > 0 Then
            Me.AboutPPSCICPF = SaveObject
        End If
        Return (ReturnValue > 0)
    End Function
#End Region
#Region "相關PPSCICPF 屬性:AboutPPSCICPF"
    Private _AboutPPSCICPF As CompanyORMDB.PPS100LB.PPSCICPF = Nothing
    ''' <summary>
    ''' 相關PPSCICPF
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutPPSCICPF() As CompanyORMDB.PPS100LB.PPSCICPF
        Get
            Return _AboutPPSCICPF
        End Get
        Private Set(ByVal value As CompanyORMDB.PPS100LB.PPSCICPF)
            _AboutPPSCICPF = value
            If Not IsNothing(_AboutPPSCICPF) Then
                Me.CoilFullNumber = (_AboutPPSCICPF.CIC01 & _AboutPPSCICPF.CIC02.PadRight(1)).Trim
                Me.LineStationName = _AboutPPSCICPF.CIC00
                Me.LoginUserID = _AboutPPSCICPF.CIC94
            End If
        End Set
    End Property

#End Region

#Region "鋼捲排序起始編號 屬性:BaseStartOrderNumber"
    Private _BaseStartOrderNumber As Integer = 1
    ''' <summary>
    ''' 鋼捲排序起始編號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BaseStartOrderNumber() As Integer
        Get
            Return _BaseStartOrderNumber
        End Get
        Set(ByVal value As Integer)
            _BaseStartOrderNumber = value

        End Set
    End Property

#End Region
#Region "取得鋼捲TreeView的排序編號 GetTreeViewOrderNumber"
    ''' <summary>
    ''' 取得鋼捲TreeView的排序編號
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTreeViewOrderNumber() As Integer
        Dim NumberCount As Integer = BaseStartOrderNumber
        For Each EachNode As TreeNode In Me.TreeView.Nodes
            If EachNode Is Me Then
                Return NumberCount
            End If
            NumberCount += 1
        Next
        Return NumberCount
    End Function
#End Region




End Class
