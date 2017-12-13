Namespace SQLServer
	Namespace PPS100LB
	Public Class ProcessSchedualFilter
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

#Region "ID 屬性:ID"
	Private _ID As System.String
	''' <summary>
	''' ID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ID () As System.String
		Get
			Return _ID
		End Get
		Set(Byval value as System.String)
			_ID = value
		End Set
	End Property
#End Region
#Region "FK_ProcessSchedualID 屬性:FK_ProcessSchedualID"
	Private _FK_ProcessSchedualID As System.String
	''' <summary>
	''' FK_ProcessSchedualID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FK_ProcessSchedualID () As System.String
		Get
			Return _FK_ProcessSchedualID
		End Get
		Set(Byval value as System.String)
			_FK_ProcessSchedualID = value
		End Set
	End Property
#End Region
#Region "FilterFinalFish 屬性:FilterFinalFish"
	Private _FilterFinalFish As System.String
	''' <summary>
	''' FilterFinalFish
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FilterFinalFish () As System.String
		Get
			Return _FilterFinalFish
		End Get
		Set(Byval value as System.String)
			_FilterFinalFish = value
		End Set
	End Property
#End Region
#Region "FilterMaxThickness 屬性:FilterMaxThickness"
	Private _FilterMaxThickness As System.Decimal
	''' <summary>
	''' FilterMaxThickness
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FilterMaxThickness () As System.Decimal
		Get
			Return _FilterMaxThickness
		End Get
		Set(Byval value as System.Decimal)
			_FilterMaxThickness = value
		End Set
	End Property
#End Region
#Region "FilterMinThickness 屬性:FilterMinThickness"
	Private _FilterMinThickness As System.Decimal
	''' <summary>
	''' FilterMinThickness
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FilterMinThickness () As System.Decimal
		Get
			Return _FilterMinThickness
		End Get
		Set(Byval value as System.Decimal)
			_FilterMinThickness = value
		End Set
	End Property
#End Region
#Region "FilterMaxThicknessIsIncludeMaxNumber 屬性:FilterMaxThicknessIsIncludeMaxNumber"
	Private _FilterMaxThicknessIsIncludeMaxNumber As System.Boolean
	''' <summary>
	''' FilterMaxThicknessIsIncludeMaxNumber
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FilterMaxThicknessIsIncludeMaxNumber () As System.Boolean
		Get
			Return _FilterMaxThicknessIsIncludeMaxNumber
		End Get
		Set(Byval value as System.Boolean)
			_FilterMaxThicknessIsIncludeMaxNumber = value
		End Set
	End Property
#End Region
#Region "FilterMinThicknessIsIncludeMinNumber 屬性:FilterMinThicknessIsIncludeMinNumber"
	Private _FilterMinThicknessIsIncludeMinNumber As System.Boolean
	''' <summary>
	''' FilterMinThicknessIsIncludeMinNumber
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FilterMinThicknessIsIncludeMinNumber () As System.Boolean
		Get
			Return _FilterMinThicknessIsIncludeMinNumber
		End Get
		Set(Byval value as System.Boolean)
			_FilterMinThicknessIsIncludeMinNumber = value
		End Set
	End Property
#End Region
#Region "FilterSellKind 屬性:FilterSellKind"
	Private _FilterSellKind As System.String
	''' <summary>
	''' FilterSellKind
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FilterSellKind () As System.String
		Get
			Return _FilterSellKind
		End Get
		Set(Byval value as System.String)
			_FilterSellKind = value
		End Set
	End Property
#End Region
#Region "FilterMaterialKind 屬性:FilterMaterialKind"
	Private _FilterMaterialKind As System.String
	''' <summary>
	''' FilterMaterialKind
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FilterMaterialKind () As System.String
		Get
			Return _FilterMaterialKind
		End Get
		Set(Byval value as System.String)
			_FilterMaterialKind = value
		End Set
	End Property
#End Region
#Region "ProcessPriority 屬性:ProcessPriority"
	Private _ProcessPriority As System.Int32
	''' <summary>
	''' ProcessPriority
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ProcessPriority () As System.Int32
		Get
			Return _ProcessPriority
		End Get
		Set(Byval value as System.Int32)
			_ProcessPriority = value
		End Set
	End Property
#End Region

	End Class
	End Namespace
End Namespace