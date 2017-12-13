Namespace SQLServer
	Namespace SQLVsAS400DataTransfer
	Public Class SQLVsAS400DBTransferPlanLog
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
#Region "RunTime 屬性:RunTime"
            Private _RunTime As System.DateTime
            ''' <summary>
            ''' LastRunTime
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property RunTime() As System.DateTime
                Get
                    Return _RunTime
                End Get
                Set(ByVal value As System.DateTime)
                    _RunTime = value
                End Set
            End Property
#End Region
#Region "RunServerName 屬性:RunServerName"
            Private _RunServerName As System.String
            ''' <summary>
            ''' LastRunServerName
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property RunServerName() As System.String
                Get
                    Return _RunServerName
                End Get
                Set(ByVal value As System.String)
                    _RunServerName = value
                End Set
            End Property
#End Region
#Region "RunLog 屬性:RunLog"
	Private _RunLog As System.String
	''' <summary>
	''' RunLog
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property RunLog () As System.String
		Get
			Return _RunLog
		End Get
		Set(Byval value as System.String)
			_RunLog = value
		End Set
	End Property
#End Region


	End Class
	End Namespace
End Namespace