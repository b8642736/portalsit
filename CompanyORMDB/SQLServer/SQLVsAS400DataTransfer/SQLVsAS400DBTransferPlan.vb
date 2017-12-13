Namespace SQLServer
	Namespace SQLVsAS400DataTransfer
	Public Class SQLVsAS400DBTransferPlan
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"SQLVsAS400DataTransfer")
	End Sub

#Region "JobName 屬性:JobName"
	Private _JobName As System.String
	''' <summary>
	''' JobName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property JobName() As System.String
                Get
                    Return _JobName
                End Get
                Set(ByVal value As System.String)
                    _JobName = value
                End Set
            End Property
#End Region
#Region "SchedualType 屬性:SchedualType"
	Private _SchedualType As System.Int32
	''' <summary>
	''' SchedualType
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property SchedualType() As System.Int32
                Get
                    Return _SchedualType
                End Get
                Set(ByVal value As System.Int32)
                    _SchedualType = value
                End Set
            End Property
#End Region
#Region "SchedualRunTime 屬性:SchedualRunTime"
	Private _SchedualRunTime As System.DateTime
	''' <summary>
	''' SchedualRunTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property SchedualRunTime() As System.DateTime
                Get
                    Return _SchedualRunTime
                End Get
                Set(ByVal value As System.DateTime)
                    _SchedualRunTime = value
                End Set
            End Property
#End Region
	End Class
	End Namespace
End Namespace