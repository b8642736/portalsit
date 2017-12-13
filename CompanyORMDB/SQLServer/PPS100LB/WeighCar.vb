Namespace SQLServer
	Namespace PPS100LB
	Public Class WeighCar
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

            '#Region "流水號 屬性:流水號"
            '	Private _流水號 As System.Int32
            '	''' <summary>
            '	''' 流水號
            '	''' </summary>
            '	''' <returns></returns>
            '	''' <remarks></remarks>
            '	Public Property 流水號 () As System.Int32
            '		Get
            '			Return _流水號
            '		End Get
            '		Set(Byval value as System.Int32)
            '			_流水號 = value
            '		End Set
            '	End Property
            '#End Region
#Region "日期 屬性:日期"
	Private _日期 As System.DateTime
	''' <summary>
	''' 日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 日期 () As System.DateTime
		Get
			Return _日期
		End Get
		Set(Byval value as System.DateTime)
			_日期 = value
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
#Region "車牌 屬性:車牌"
	Private _車牌 As System.String
	''' <summary>
	''' 車牌
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 車牌 () As System.String
		Get
			Return _車牌
		End Get
		Set(Byval value as System.String)
			_車牌 = value
		End Set
	End Property
#End Region
#Region "每日空重 屬性:每日空重"
	Private _每日空重 As System.String
	''' <summary>
	''' 每日空重
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 每日空重 () As System.String
		Get
			Return _每日空重
		End Get
		Set(Byval value as System.String)
			_每日空重 = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace