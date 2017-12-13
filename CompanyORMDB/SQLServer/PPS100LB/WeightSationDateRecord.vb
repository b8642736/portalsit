Namespace SQLServer
	Namespace PPS100LB
	Public Class WeightSationDateRecord
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

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
#Region "掃描時間 屬性:掃描時間"
	Private _掃描時間 As System.DateTime
	''' <summary>
	''' 掃描時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property 掃描時間 () As System.DateTime
		Get
			Return _掃描時間
		End Get
		Set(Byval value as System.DateTime)
			_掃描時間 = value
		End Set
	End Property
#End Region
	End Class
	End Namespace
End Namespace