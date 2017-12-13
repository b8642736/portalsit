Namespace SQLServer
	Namespace QCDB01
	Public Class LabRecordA2_M
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server0SM,"QCDB01")
	End Sub

#Region "LABREPORT_NO 屬性:LABREPORT_NO"
	Private _LABREPORT_NO As System.String
	''' <summary>
	''' LABREPORT_NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property LABREPORT_NO () As System.String
		Get
			Return _LABREPORT_NO
		End Get
		Set(Byval value as System.String)
			_LABREPORT_NO = value
		End Set
	End Property
#End Region
#Region "CUSTOMER 屬性:CUSTOMER"
	Private _CUSTOMER As System.String
	''' <summary>
	''' CUSTOMER
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CUSTOMER () As System.String
		Get
			Return _CUSTOMER
		End Get
		Set(Byval value as System.String)
			_CUSTOMER = value
		End Set
	End Property
#End Region
#Region "CONTRACT_NO 屬性:CONTRACT_NO"
	Private _CONTRACT_NO As System.String
	''' <summary>
	''' CONTRACT_NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CONTRACT_NO () As System.String
		Get
			Return _CONTRACT_NO
		End Get
		Set(Byval value as System.String)
			_CONTRACT_NO = value
		End Set
	End Property
#End Region
#Region "LC_NO 屬性:LC_NO"
	Private _LC_NO As System.String
	''' <summary>
	''' LC_NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property LC_NO () As System.String
		Get
			Return _LC_NO
		End Get
		Set(Byval value as System.String)
			_LC_NO = value
		End Set
	End Property
#End Region
#Region "DELIVERY_NO 屬性:DELIVERY_NO"
	Private _DELIVERY_NO As System.String
	''' <summary>
	''' DELIVERY_NO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DELIVERY_NO () As System.String
		Get
			Return _DELIVERY_NO
		End Get
		Set(Byval value as System.String)
			_DELIVERY_NO = value
		End Set
	End Property
#End Region
#Region "SAVE_DATATIME 屬性:SAVE_DATATIME"
	Private _SAVE_DATATIME As System.DateTime
	''' <summary>
	''' SAVE_DATATIME
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property SAVE_DATATIME () As System.DateTime
		Get
			Return _SAVE_DATATIME
		End Get
		Set(Byval value as System.DateTime)
			_SAVE_DATATIME = value
		End Set
	End Property
#End Region
#Region "REMARK_LIST 屬性:REMARK_LIST"
	Private _REMARK_LIST As System.String
	''' <summary>
	''' REMARK_LIST
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property REMARK_LIST () As System.String
		Get
			Return _REMARK_LIST
		End Get
		Set(Byval value as System.String)
			_REMARK_LIST = value
		End Set
	End Property
#End Region
#Region "EFF_FLAG 屬性:EFF_FLAG"
	Private _EFF_FLAG As System.String
	''' <summary>
	''' EFF_FLAG
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EFF_FLAG () As System.String
		Get
			Return _EFF_FLAG
		End Get
		Set(Byval value as System.String)
			_EFF_FLAG = value
		End Set
	End Property
#End Region
#Region "APPEND_LIST 屬性:APPEND_LIST"
	Private _APPEND_LIST As System.String
	''' <summary>
	''' APPEND_LIST
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property APPEND_LIST () As System.String
		Get
			Return _APPEND_LIST
		End Get
		Set(Byval value as System.String)
			_APPEND_LIST = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace