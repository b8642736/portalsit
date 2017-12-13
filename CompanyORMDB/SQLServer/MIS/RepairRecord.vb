Namespace SQLServer
	Namespace MIS
	Public Class RepairRecord
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"MIS")
	End Sub

#Region "ID 屬性:ID"
	Private _ID As System.Int32
	''' <summary>
	''' ID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property ID () As System.Int32
		Get
			Return _ID
		End Get
		Set(Byval value as System.Int32)
			_ID = value
		End Set
	End Property
#End Region
#Region "RepareItem 屬性:RepareItem"
	Private _RepareItem As System.String
	''' <summary>
	''' RepareItem
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property RepareItem () As System.String
		Get
			Return _RepareItem
		End Get
		Set(Byval value as System.String)
			_RepareItem = value
		End Set
	End Property
#End Region
#Region "ApplyTime 屬性:ApplyTime"
	Private _ApplyTime As System.DateTime
	''' <summary>
	''' ApplyTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ApplyTime () As System.DateTime
		Get
			Return _ApplyTime
		End Get
		Set(Byval value as System.DateTime)
			_ApplyTime = value
		End Set
	End Property
#End Region
#Region "ProcessResult 屬性:ProcessResult"
	Private _ProcessResult As System.String
	''' <summary>
	''' ProcessResult
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ProcessResult () As System.String
		Get
			Return _ProcessResult
		End Get
		Set(Byval value as System.String)
			_ProcessResult = value
		End Set
	End Property
#End Region
#Region "FinishTime 屬性:FinishTime"
	Private _FinishTime As System.DateTime
	''' <summary>
	''' FinishTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FinishTime () As System.DateTime
		Get
			Return _FinishTime
		End Get
		Set(Byval value as System.DateTime)
			_FinishTime = value
		End Set
	End Property
#End Region
#Region "ProcessEmployee 屬性:ProcessEmployee"
	Private _ProcessEmployee As System.String
	''' <summary>
	''' ProcessEmployee
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ProcessEmployee () As System.String
		Get
			Return _ProcessEmployee
		End Get
		Set(Byval value as System.String)
			_ProcessEmployee = value
		End Set
	End Property
#End Region
#Region "ApplyEmplyee 屬性:ApplyEmplyee"
	Private _ApplyEmplyee As System.String
	''' <summary>
	''' ApplyEmplyee
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ApplyEmplyee () As System.String
		Get
			Return _ApplyEmplyee
		End Get
		Set(Byval value as System.String)
			_ApplyEmplyee = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace