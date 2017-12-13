Namespace SQLServer
	Namespace QCDB01
	Public Class LabRecordA1_M
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"QCDB01")
	End Sub

#Region "LAB_REPORTNO 屬性:LAB_REPORTNO"
	Private _LAB_REPORTNO As System.String
	''' <summary>
	''' LAB_REPORTNO
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property LAB_REPORTNO () As System.String
		Get
			Return _LAB_REPORTNO
		End Get
		Set(Byval value as System.String)
			_LAB_REPORTNO = value
		End Set
	End Property
#End Region
#Region "標題1 屬性:標題1"
	Private _標題1 As System.String
	''' <summary>
	''' 標題1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 標題1 () As System.String
		Get
			Return _標題1
		End Get
		Set(Byval value as System.String)
			_標題1 = value
		End Set
	End Property
#End Region
#Region "標題2 屬性:標題2"
	Private _標題2 As System.String
	''' <summary>
	''' 標題2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 標題2 () As System.String
		Get
			Return _標題2
		End Get
		Set(Byval value as System.String)
			_標題2 = value
		End Set
	End Property
#End Region
#Region "說明1 屬性:說明1"
	Private _說明1 As System.String
	''' <summary>
	''' 說明1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 說明1 () As System.String
		Get
			Return _說明1
		End Get
		Set(Byval value as System.String)
			_說明1 = value
		End Set
	End Property
#End Region
#Region "說明2 屬性:說明2"
	Private _說明2 As System.String
	''' <summary>
	''' 說明2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 說明2 () As System.String
		Get
			Return _說明2
		End Get
		Set(Byval value as System.String)
			_說明2 = value
		End Set
	End Property
#End Region
#Region "原能會字號 屬性:原能會字號"
	Private _原能會字號 As System.String
	''' <summary>
	''' 原能會字號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 原能會字號 () As System.String
		Get
			Return _原能會字號
		End Get
		Set(Byval value as System.String)
			_原能會字號 = value
		End Set
	End Property
#End Region
#Region "檢驗人員字號 屬性:檢驗人員字號"
	Private _檢驗人員字號 As System.String
	''' <summary>
	''' 檢驗人員字號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 檢驗人員字號 () As System.String
		Get
			Return _檢驗人員字號
		End Get
		Set(Byval value as System.String)
			_檢驗人員字號 = value
		End Set
	End Property
#End Region
#Region "客戶名稱 屬性:客戶名稱"
	Private _客戶名稱 As System.String
	''' <summary>
	''' 客戶名稱
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 客戶名稱 () As System.String
		Get
			Return _客戶名稱
		End Get
		Set(Byval value as System.String)
			_客戶名稱 = value
		End Set
	End Property
#End Region
#Region "公司名稱 屬性:公司名稱"
	Private _公司名稱 As System.String
	''' <summary>
	''' 公司名稱
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 公司名稱 () As System.String
		Get
			Return _公司名稱
		End Get
		Set(Byval value as System.String)
			_公司名稱 = value
		End Set
	End Property
#End Region
#Region "公司地址 屬性:公司地址"
	Private _公司地址 As System.String
	''' <summary>
	''' 公司地址
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 公司地址 () As System.String
		Get
			Return _公司地址
		End Get
		Set(Byval value as System.String)
			_公司地址 = value
		End Set
	End Property
#End Region
#Region "公司負責人 屬性:公司負責人"
	Private _公司負責人 As System.String
	''' <summary>
	''' 公司負責人
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 公司負責人 () As System.String
		Get
			Return _公司負責人
		End Get
		Set(Byval value as System.String)
			_公司負責人 = value
		End Set
	End Property
#End Region
#Region "品檢主管 屬性:品檢主管"
	Private _品檢主管 As System.String
	''' <summary>
	''' 品檢主管
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 品檢主管 () As System.String
		Get
			Return _品檢主管
		End Get
		Set(Byval value as System.String)
			_品檢主管 = value
		End Set
	End Property
#End Region
#Region "品檢日期_起 屬性:品檢日期_起"
	Private _品檢日期_起 As System.DateTime
	''' <summary>
	''' 品檢日期_起
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 品檢日期_起 () As System.DateTime
		Get
			Return _品檢日期_起
		End Get
		Set(Byval value as System.DateTime)
			_品檢日期_起 = value
		End Set
	End Property
#End Region
#Region "品檢日期_迄 屬性:品檢日期_迄"
	Private _品檢日期_迄 As System.DateTime
	''' <summary>
	''' 品檢日期_迄
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 品檢日期_迄 () As System.DateTime
		Get
			Return _品檢日期_迄
		End Get
		Set(Byval value as System.DateTime)
			_品檢日期_迄 = value
		End Set
	End Property
#End Region
#Region "資料日期 屬性:資料日期"
	Private _資料日期 As System.DateTime
	''' <summary>
	''' 資料日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property 資料日期 () As System.DateTime
		Get
			Return _資料日期
		End Get
		Set(Byval value as System.DateTime)
			_資料日期 = value
		End Set
	End Property
#End Region
#Region "LAB_REPORTNO2 屬性:LAB_REPORTNO2"
	Private _LAB_REPORTNO2 As System.Int32
	''' <summary>
	''' LAB_REPORTNO2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property LAB_REPORTNO2 () As System.Int32
		Get
			Return _LAB_REPORTNO2
		End Get
		Set(Byval value as System.Int32)
			_LAB_REPORTNO2 = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace