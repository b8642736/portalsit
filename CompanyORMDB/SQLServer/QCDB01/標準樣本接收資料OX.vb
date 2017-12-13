Namespace SQLServer
	Namespace QCDB01
	Public Class 標準樣本接收資料OX
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"QCDB01")
	End Sub

#Region "SampleID 屬性:SampleID"
	Private _SampleID As System.String
	''' <summary>
	''' SampleID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property SampleID () As System.String
		Get
			Return _SampleID
		End Get
		Set(Byval value as System.String)
			_SampleID = value
		End Set
	End Property
#End Region
#Region "日期時間 屬性:日期時間"
	Private _日期時間 As System.DateTime
	''' <summary>
	''' 日期時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 日期時間 () As System.DateTime
		Get
			Return _日期時間
		End Get
		Set(Byval value as System.DateTime)
			_日期時間 = value
		End Set
	End Property
#End Region
#Region "N1 屬性:N1"
	Private _N1 As System.Double
	''' <summary>
	''' N1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property N1 () As System.Double
		Get
			Return _N1
		End Get
		Set(Byval value as System.Double)
			_N1 = value
		End Set
	End Property
#End Region
#Region "O1 屬性:O1"
	Private _O1 As System.Double
	''' <summary>
	''' O1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property O1 () As System.Double
		Get
			Return _O1
		End Get
		Set(Byval value as System.Double)
			_O1 = value
		End Set
	End Property
#End Region
#Region "MachineID 屬性:MachineID"
	Private _MachineID As System.String
	''' <summary>
	''' MachineID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MachineID () As System.String
		Get
			Return _MachineID
		End Get
		Set(Byval value as System.String)
			_MachineID = value
		End Set
	End Property
#End Region
#Region "ShowSampleID 屬性:ShowSampleID"
	Private _ShowSampleID As System.String
	''' <summary>
	''' ShowSampleID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ShowSampleID () As System.String
		Get
			Return _ShowSampleID
		End Get
		Set(Byval value as System.String)
			_ShowSampleID = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace