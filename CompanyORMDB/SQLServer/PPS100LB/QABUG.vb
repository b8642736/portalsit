Namespace SQLServer
	Namespace PPS100LB
	Public Class QABUG
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

#Region "Number 屬性:Number"
	Private _Number As System.String
	''' <summary>
	''' Number
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property Number() As System.String
                Get
                    Return _Number
                End Get
                Set(ByVal value As System.String)
                    _Number = value
                End Set
            End Property
#End Region
#Region "CName 屬性:CName"
	Private _CName As System.String
	''' <summary>
	''' CName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            Public Property CName() As System.String
                Get
                    Return _CName
                End Get
                Set(ByVal value As System.String)
                    _CName = value
                End Set
            End Property
#End Region
#Region "APL1SortNumber 屬性:APL1SortNumber"
	Private _APL1SortNumber As System.Decimal
	''' <summary>
	''' APL1SortNumber
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property APL1SortNumber () As System.Decimal
		Get
			Return _APL1SortNumber
		End Get
		Set(Byval value as System.Decimal)
			_APL1SortNumber = value
		End Set
	End Property
#End Region
#Region "APL2SortNumber 屬性:APL2SortNumber"
	Private _APL2SortNumber As System.Decimal
	''' <summary>
	''' APL2SortNumber
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property APL2SortNumber () As System.Decimal
		Get
			Return _APL2SortNumber
		End Get
		Set(Byval value as System.Decimal)
			_APL2SortNumber = value
		End Set
	End Property
#End Region
#Region "BALSortNumber 屬性:BALSortNumber"
	Private _BALSortNumber As System.Decimal
	''' <summary>
	''' BALSortNumber
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property BALSortNumber () As System.Decimal
		Get
			Return _BALSortNumber
		End Get
		Set(Byval value as System.Decimal)
			_BALSortNumber = value
		End Set
	End Property
#End Region
#Region "Memo1 屬性:Memo1"
	Private _Memo1 As System.String
	''' <summary>
	''' Memo1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Memo1 () As System.String
		Get
			Return _Memo1
		End Get
		Set(Byval value as System.String)
			_Memo1 = value
		End Set
	End Property
#End Region
#Region "是否為需注意之缺陷 屬性:IsAttentation"
            ''' <summary>
            ''' 是否為需注意之缺陷
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property IsAttentation As Boolean
#End Region
#Region "程度Degree 屬性:Degree"
            Private _Degree As System.Int32
            ''' <summary>
            ''' Degree
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Degree() As System.Int32
                Get
                    Return _Degree
                End Get
                Set(ByVal value As System.Int32)
                    _Degree = value
                End Set
            End Property
#End Region
#Region "啟始長度StartPosition 屬性:StartPosition"
            Private _StartPosition As System.Decimal
            ''' <summary>
            ''' StartPosition
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property StartPosition() As System.Decimal
                Get
                    Return _StartPosition
                End Get
                Set(ByVal value As System.Decimal)
                    _StartPosition = value
                End Set
            End Property
#End Region
#Region "終止長度EndPosition 屬性:EndPosition"
            Private _EndPosition As System.Decimal
            ''' <summary>
            ''' EndPosition
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property EndPosition() As System.Decimal
                Get
                    Return _EndPosition
                End Get
                Set(ByVal value As System.Decimal)
                    _EndPosition = value
                End Set
            End Property
#End Region
#Region "分佈形態DPositionType 屬性:DPositionType"
            Private _DPositionType As Integer
            ''' <summary>
            ''' DPositionType
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DPositionType() As Integer
                Get
                    Return _DPositionType
                End Get
                Set(ByVal value As Integer)
                    _DPositionType = value
                End Set
            End Property
#End Region
#Region "分佈起始DPositionStart 屬性:DPositionStart"
            Private _DPositionStart As System.Decimal
            ''' <summary>
            ''' DPositionStart
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DPositionStart() As System.Decimal
                Get
                    Return _DPositionStart
                End Get
                Set(ByVal value As System.Decimal)
                    _DPositionStart = value
                End Set
            End Property
#End Region
#Region "分佈終止DPositionEnd 屬性:DPositionEnd"
            Private _DPositionEnd As System.Decimal
            ''' <summary>
            ''' DPositionEnd
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DPositionEnd() As System.Decimal
                Get
                    Return _DPositionEnd
                End Get
                Set(ByVal value As System.Decimal)
                    _DPositionEnd = value
                End Set
            End Property
#End Region
#Region "正反面PosOrNeg 屬性:PosOrNeg"
            Private _PosOrNeg As Integer
            ''' <summary>
            ''' PosOrNeg
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property PosOrNeg() As Integer
                Get
                    Return _PosOrNeg
                End Get
                Set(ByVal value As Integer)
                    _PosOrNeg = value
                End Set
            End Property
#End Region
#Region "密度Density 屬性:Density"
            Private _Density As System.Decimal
            ''' <summary>
            ''' Density
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Density() As System.Decimal
                Get
                    Return _Density
                End Get
                Set(ByVal value As System.Decimal)
                    _Density = value
                End Set
            End Property
#End Region
#Region "週期Cycle 屬性:Cycle"
            Private _Cycle As Integer
            ''' <summary>
            ''' Cycle
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Cycle() As Integer
                Get
                    Return _Cycle
                End Get
                Set(ByVal value As Integer)
                    _Cycle = value
                End Set
            End Property
#End Region
#Region "TLLUseSortNumber 屬性:TLLUseSortNumber"
            Private _TLLUseSortNumber As System.Decimal
            ''' <summary>
            ''' TLLUseSortNumber
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property TLLUseSortNumber() As System.Decimal
                Get
                    Return _TLLUseSortNumber
                End Get
                Set(ByVal value As System.Decimal)
                    _TLLUseSortNumber = value
                End Set
            End Property
#End Region
#Region "SBLUseSortNumber 屬性:SBLUseSortNumber"
            Private _SBLUseSortNumber As System.Decimal
            ''' <summary>
            ''' SBLUseSortNumber
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SBLUseSortNumber() As System.Decimal
                Get
                    Return _SBLUseSortNumber
                End Get
                Set(ByVal value As System.Decimal)
                    _SBLUseSortNumber = value
                End Set
            End Property
#End Region
#Region "SPLUseSortNumber 屬性:SPLUseSortNumber"
            Private _SPLUseSortNumber As System.Decimal
            ''' <summary>
            ''' SPLUseSortNumber
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SPLUseSortNumber() As System.Decimal
                Get
                    Return _SPLUseSortNumber
                End Get
                Set(ByVal value As System.Decimal)
                    _SPLUseSortNumber = value
                End Set
            End Property
#End Region
#Region "TLLUseSortUpLineNumber 屬性:TLLUseSortUpLineNumber"
            Private _TLLUseSortUpLineNumber As System.Decimal
            ''' <summary>
            ''' TLLUseSortUpLineNumber
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property TLLUseSortUpLineNumber() As System.Decimal
                Get
                    Return _TLLUseSortUpLineNumber
                End Get
                Set(ByVal value As System.Decimal)
                    _TLLUseSortUpLineNumber = value
                End Set
            End Property
#End Region
#Region "SBLUseSortUpLineNumber 屬性:SBLUseSortUpLineNumber"
            Private _SBLUseSortUpLineNumber As System.Decimal
            ''' <summary>
            ''' SBLUseSortUpLineNumber
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SBLUseSortUpLineNumber() As System.Decimal
                Get
                    Return _SBLUseSortUpLineNumber
                End Get
                Set(ByVal value As System.Decimal)
                    _SBLUseSortUpLineNumber = value
                End Set
            End Property
#End Region
#Region "SPLUseSortUpLineNumber 屬性:SPLUseSortUpLineNumber"
            Private _SPLUseSortUpLineNumber As System.Decimal
            ''' <summary>
            ''' SPLUseSortUpLineNumber
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SPLUseSortUpLineNumber() As System.Decimal
                Get
                    Return _SPLUseSortUpLineNumber
                End Get
                Set(ByVal value As System.Decimal)
                    _SPLUseSortUpLineNumber = value
                End Set
            End Property
#End Region



#Region "分佈型態名稱 屬性:DPositionTypeName"
            ''' <summary>
            ''' 分佈型態名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property DPositionTypeName As String
                Get
                    Select Case True
                        Case DPositionType = 0
                            Return "全"
                        Case DPositionType = 1
                            Return "內"
                        Case DPositionType = 2
                            Return "中"
                        Case DPositionType = 3
                            Return "外"
                        Case DPositionType = 4
                            Return "雙"
                        Case DPositionType = 5
                            Return "無"
                    End Select
                    Return "未知"
                End Get
            End Property
#End Region
#Region "正反名稱 屬性:PosOrNegName"
            ''' <summary>
            ''' 正反名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property PosOrNegName As String
                Get
                    Select Case PosOrNeg
                        Case 1
                            Return "正"
                        Case 2
                            Return "反"
                        Case 3
                            Return "雙"
                        Case Else
                            Return "未知"
                    End Select
                End Get
            End Property
#End Region

#Region "是否已被使用者使用 屬性:IsUsedForUser"
            Shared AllUsedQABugNumbers As List(Of String)
            Shared IsUsedForUser_AccessTime As DateTime = Now
            ''' <summary>
            ''' 是否已被使用者使用
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property IsUsedForUser As Boolean
                Get
                    If String.IsNullOrEmpty(Me.Number) Then
                        Return False
                    End If
                    If IsNothing(AllUsedQABugNumbers) OrElse Now.Subtract(IsUsedForUser_AccessTime).TotalSeconds > 10 Then
                        AllUsedQABugNumbers = New List(Of String)
                        Dim Qry As String = "Select Distinct QABug_Number From QABugRecord Order by QABug_Number"
                        Dim Adapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                        For Each EachItem As DataRow In Adapter.SelectQuery(Qry).Rows
                            AllUsedQABugNumbers.Add(CType(EachItem.Item(0), String).Trim)
                        Next
                        IsUsedForUser_AccessTime = Now
                    End If
                    Return AllUsedQABugNumbers.Contains(Me.Number.Trim)
                End Get
            End Property
#End Region

#Region "所有缺陷資資料 屬性:AllBugDatas"
            Shared _AllBugDatas As New List(Of QABUG)
            Shared AllBugDatas_AccessTime As DateTime = Now
            ''' <summary>
            ''' 所有缺陷資資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Shared ReadOnly Property AllBugDatas As List(Of QABUG)
                Get
                    If Now.Subtract(AllBugDatas_AccessTime).TotalSeconds > 2 OrElse _AllBugDatas.Count = 0 Then
                        _AllBugDatas.Clear()
                        Dim SearchResult As List(Of QABUG) = QABUG.CDBSelect(Of QABUG)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, "Select * from QABUG Order by Number")
                        _AllBugDatas.AddRange(SearchResult)
                    End If
                    AllBugDatas_AccessTime = Now
                    Return _AllBugDatas
                End Get
            End Property
#End Region

	End Class
	End Namespace
End Namespace