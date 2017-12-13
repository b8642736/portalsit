Namespace SQLServer
	Namespace PPS100LB
	Public Class QAQuickInputGroup
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

#Region "StationName 屬性:StationName"
	Private _StationName As System.String
	''' <summary>
	''' StationName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property StationName () As System.String
		Get
			Return _StationName
		End Get
		Set(Byval value as System.String)
			_StationName = value
		End Set
	End Property
#End Region
#Region "GroupNumber 屬性:GroupNumber"
	Private _GroupNumber As System.Decimal
	''' <summary>
	''' GroupNumber
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property GroupNumber () As System.Decimal
		Get
			Return _GroupNumber
		End Get
		Set(Byval value as System.Decimal)
			_GroupNumber = value
		End Set
	End Property
#End Region
#Region "SortNumber 屬性:SortNumber"
	Private _SortNumber As System.Decimal
	''' <summary>
	''' SortNumber
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property SortNumber () As System.Decimal
		Get
			Return _SortNumber
		End Get
		Set(Byval value as System.Decimal)
			_SortNumber = value
		End Set
	End Property
#End Region
#Region "QABug_Number 屬性:QABug_Number"
	Private _QABug_Number As System.String
	''' <summary>
	''' QABug_Number
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QABug_Number () As System.String
		Get
			Return _QABug_Number
		End Get
		Set(Byval value as System.String)
			_QABug_Number = value
		End Set
	End Property
#End Region
#Region "群組名稱 屬性:GroupName"
            ''' <summary>
            ''' 群組名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property GroupName As String
#End Region
#Region "Degree 屬性:Degree"
	Private _Degree As System.Decimal
	''' <summary>
	''' Degree
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Degree () As System.Decimal
		Get
			Return _Degree
		End Get
		Set(Byval value as System.Decimal)
			_Degree = value
		End Set
	End Property
#End Region
#Region "StartPosition 屬性:StartPosition"
	Private _StartPosition As System.Decimal
	''' <summary>
	''' StartPosition
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property StartPosition () As System.Decimal
		Get
			Return _StartPosition
		End Get
		Set(Byval value as System.Decimal)
			_StartPosition = value
		End Set
	End Property
#End Region
#Region "EndPosition 屬性:EndPosition"
	Private _EndPosition As System.Decimal
	''' <summary>
	''' EndPosition
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EndPosition () As System.Decimal
		Get
			Return _EndPosition
		End Get
		Set(Byval value as System.Decimal)
			_EndPosition = value
		End Set
	End Property
#End Region
#Region "DPositionType 屬性:DPositionType"
	Private _DPositionType As System.Decimal
	''' <summary>
	''' DPositionType
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DPositionType () As System.Decimal
		Get
			Return _DPositionType
		End Get
		Set(Byval value as System.Decimal)
			_DPositionType = value
		End Set
	End Property
#End Region
#Region "DPositionStart 屬性:DPositionStart"
	Private _DPositionStart As System.Decimal
	''' <summary>
	''' DPositionStart
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DPositionStart () As System.Decimal
		Get
			Return _DPositionStart
		End Get
		Set(Byval value as System.Decimal)
			_DPositionStart = value
		End Set
	End Property
#End Region
#Region "DPositionEnd 屬性:DPositionEnd"
	Private _DPositionEnd As System.Decimal
	''' <summary>
	''' DPositionEnd
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DPositionEnd () As System.Decimal
		Get
			Return _DPositionEnd
		End Get
		Set(Byval value as System.Decimal)
			_DPositionEnd = value
		End Set
	End Property
#End Region
#Region "PosOrNeg 屬性:PosOrNeg"
	Private _PosOrNeg As System.Decimal
	''' <summary>
	''' PosOrNeg
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property PosOrNeg () As System.Decimal
		Get
			Return _PosOrNeg
		End Get
		Set(Byval value as System.Decimal)
			_PosOrNeg = value
		End Set
	End Property
#End Region
#Region "Density 屬性:Density"
	Private _Density As System.Decimal
	''' <summary>
	''' Density
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Density () As System.Decimal
		Get
			Return _Density
		End Get
		Set(Byval value as System.Decimal)
			_Density = value
		End Set
	End Property
#End Region
#Region "Cycle 屬性:Cycle"
	Private _Cycle As System.Decimal
	''' <summary>
	''' Cycle
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Cycle () As System.Decimal
		Get
			Return _Cycle
		End Get
		Set(Byval value as System.Decimal)
			_Cycle = value
		End Set
	End Property
#End Region

#Region "品管快速輸入所有資料 屬性:AllQAQuickInputGroupDatas"
            Private Shared _AllQAQuickInputGroupDatas As List(Of QAQuickInputGroup)
            Private Shared _AllQAQuickInputGroupDatasLastAccessTime As DateTime = Now
            ''' <summary>
            ''' 品管快速輸入所有資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Shared ReadOnly Property AllQAQuickInputGroupDatas As List(Of QAQuickInputGroup)
                Get
                    If IsNothing(_AllQAQuickInputGroupDatas) OrElse Now.Subtract(_AllQAQuickInputGroupDatasLastAccessTime).TotalSeconds > 3 Then
                        Dim QryString As String = "Select * from QAQuickInputGroup Order by StationName,GroupNumber,SortNumber"
                        _AllQAQuickInputGroupDatas = QAQuickInputGroup.CDBSelect(Of QAQuickInputGroup)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                    End If
                    _AllQAQuickInputGroupDatasLastAccessTime = Now
                    Return _AllQAQuickInputGroupDatas
                End Get
            End Property
#End Region

	End Class
	End Namespace
End Namespace