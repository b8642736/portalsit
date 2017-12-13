Namespace SQLServer
	Namespace PPS100LB
	Public Class WeightSationData
	Inherits ClassDBSQLServer

	Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
	End Sub

#Region "過磅類別 屬性:過磅類別"
	Private _過磅類別 As System.String
	''' <summary>
	''' 過磅類別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 過磅類別 () As System.String
		Get
			Return _過磅類別
		End Get
		Set(Byval value as System.String)
			_過磅類別 = value
		End Set
	End Property
#End Region
#Region "合約案號 屬性:合約案號"
	Private _合約案號 As System.String
	''' <summary>
	''' 合約案號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 合約案號 () As System.String
		Get
			Return _合約案號
		End Get
		Set(Byval value as System.String)
			_合約案號 = value
		End Set
	End Property
#End Region
#Region "原料編號 屬性:原料編號"
	Private _原料編號 As System.String
	''' <summary>
	''' 原料編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 原料編號 () As System.String
		Get
			Return _原料編號
		End Get
		Set(Byval value as System.String)
			_原料編號 = value
		End Set
	End Property
#End Region
#Region "鋼捲編號 屬性:鋼捲編號"
	Private _鋼捲編號 As System.String
	''' <summary>
	''' 鋼捲編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 鋼捲編號 () As System.String
		Get
			Return _鋼捲編號
		End Get
		Set(Byval value as System.String)
			_鋼捲編號 = value
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
#Region "磅重 屬性:磅重"
	Private _磅重 As System.String
	''' <summary>
	''' 磅重
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 磅重 () As System.String
		Get
			Return _磅重
		End Get
		Set(Byval value as System.String)
			_磅重 = value
		End Set
	End Property
#End Region
#Region "雜物重 屬性:雜物重"
	Private _雜物重 As System.Int32
	''' <summary>
	''' 雜物重
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 雜物重 () As System.Int32
		Get
			Return _雜物重
		End Get
		Set(Byval value as System.Int32)
			_雜物重 = value
		End Set
	End Property
#End Region
#Region "淨重 屬性:淨重"
	Private _淨重 As System.Int32
	''' <summary>
	''' 淨重
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 淨重 () As System.Int32
		Get
			Return _淨重
		End Get
		Set(Byval value as System.Int32)
			_淨重 = value
		End Set
	End Property
#End Region
#Region "過磅日期 屬性:過磅日期"
	Private _過磅日期 As System.DateTime
	''' <summary>
	''' 過磅日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 過磅日期 () As System.DateTime
		Get
			Return _過磅日期
		End Get
		Set(Byval value as System.DateTime)
			_過磅日期 = value
		End Set
	End Property
#End Region
#Region "內儲倉位 屬性:內儲倉位"
	Private _內儲倉位 As System.String
	''' <summary>
	''' 內儲倉位
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 內儲倉位 () As System.String
		Get
			Return _內儲倉位
		End Get
		Set(Byval value as System.String)
			_內儲倉位 = value
		End Set
	End Property
#End Region
#Region "操作人員 屬性:操作人員"
	Private _操作人員 As System.String
	''' <summary>
	''' 操作人員
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 操作人員 () As System.String
		Get
			Return _操作人員
		End Get
		Set(Byval value as System.String)
			_操作人員 = value
		End Set
	End Property
#End Region
#Region "建立日期 屬性:建立日期"
	Private _建立日期 As System.DateTime
	''' <summary>
	''' 建立日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 建立日期 () As System.DateTime
		Get
			Return _建立日期
		End Get
		Set(Byval value as System.DateTime)
			_建立日期 = value
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
	Public Property 車牌 () As System.String
		Get
			Return _車牌
		End Get
		Set(Byval value as System.String)
			_車牌 = value
		End Set
	End Property
#End Region
#Region "品名 屬性:品名"
	Private _品名 As System.String
	''' <summary>
	''' 品名
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 品名 () As System.String
		Get
			Return _品名
		End Get
		Set(Byval value as System.String)
			_品名 = value
		End Set
	End Property
#End Region
#Region "廠商 屬性:廠商"
	Private _廠商 As System.String
	''' <summary>
	''' 廠商
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 廠商 () As System.String
		Get
			Return _廠商
		End Get
		Set(Byval value as System.String)
			_廠商 = value
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
            Public Property 車次() As System.String
                Get
                    Return _車次
                End Get
                Set(ByVal value As System.String)
                    _車次 = value
                End Set
            End Property
#End Region

	End Class
	End Namespace
End Namespace