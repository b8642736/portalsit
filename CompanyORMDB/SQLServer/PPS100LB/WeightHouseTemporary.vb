Namespace SQLServer
	Namespace PPS100LB
	Public Class WeightHouseTemporary
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

#Region "車牌 屬性:車牌"
	Private _車牌 As System.String
	''' <summary>
	''' 車牌
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 車牌 () As System.String
		Get
			Return _車牌
		End Get
		Set(Byval value as System.String)
			_車牌 = value
		End Set
	End Property
#End Region
#Region "案號 屬性:案號"
	Private _案號 As System.String
	''' <summary>
	''' 案號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 案號 () As System.String
		Get
			Return _案號
		End Get
		Set(Byval value as System.String)
			_案號 = value
		End Set
	End Property
#End Region
#Region "料號 屬性:料號"
	Private _料號 As System.String
	''' <summary>
	''' 料號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 料號 () As System.String
		Get
			Return _料號
		End Get
		Set(Byval value as System.String)
			_料號 = value
		End Set
	End Property
#End Region
#Region "時間 屬性:時間"
	Private _時間 As System.DateTime
	''' <summary>
	''' 時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 時間 () As System.DateTime
		Get
			Return _時間
		End Get
		Set(Byval value as System.DateTime)
			_時間 = value
		End Set
	End Property
#End Region
#Region "站別名稱 屬性:站別名稱"
	Private _站別名稱 As System.String
	''' <summary>
	''' 站別名稱
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 站別名稱 () As System.String
		Get
			Return _站別名稱
		End Get
		Set(Byval value as System.String)
			_站別名稱 = value
		End Set
	End Property
#End Region
#Region "車次 屬性:車次"
	Private _車次 As System.String
	''' <summary>
	''' 車次
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 車次 () As System.String
		Get
			Return _車次
		End Get
		Set(Byval value as System.String)
			_車次 = value
		End Set
	End Property
#End Region
#Region "流水號 屬性:流水號"
	Private _流水號 As System.String
	''' <summary>
	''' 流水號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 流水號 () As System.String
		Get
			Return _流水號
		End Get
		Set(Byval value as System.String)
			_流水號 = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace