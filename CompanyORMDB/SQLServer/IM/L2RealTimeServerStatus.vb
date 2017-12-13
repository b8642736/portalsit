Namespace SQLServer
	Namespace IM
	Public Class L2RealTimeServerStatus
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"IM")
	End Sub

#Region "ServerIP 屬性:ServerIP"
	Private _ServerIP As System.String
	''' <summary>
	''' ServerIP
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property ServerIP () As System.String
		Get
			Return _ServerIP
		End Get
		Set(Byval value as System.String)
			_ServerIP = value
		End Set
	End Property
#End Region
#Region "NextStartUPOrder 屬性:NextStartUPOrder"
	Private _NextStartUPOrder As System.Decimal
	''' <summary>
	''' NextStartUPOrder
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property NextStartUPOrder () As System.Decimal
		Get
			Return _NextStartUPOrder
		End Get
		Set(Byval value as System.Decimal)
			_NextStartUPOrder = value
		End Set
	End Property
#End Region
#Region "IsRunningServer 屬性:IsRunningServer"
	Private _IsRunningServer As System.Boolean
	''' <summary>
	''' IsRunningServer
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property IsRunningServer () As System.Boolean
		Get
			Return _IsRunningServer
		End Get
		Set(Byval value as System.Boolean)
			_IsRunningServer = value
		End Set
	End Property
#End Region
#Region "LastRunningTime 屬性:LastRunningTime"
	Private _LastRunningTime As System.DateTime
	''' <summary>
	''' LastRunningTime
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property LastRunningTime () As System.DateTime
		Get
			Return _LastRunningTime
		End Get
		Set(Byval value as System.DateTime)
			_LastRunningTime = value
		End Set
	End Property
#End Region
#Region "是否啟用 屬性:IsEnable"
            Private _IsEnable As System.Boolean
            ''' <summary>
            ''' IsRunningServer
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsEnable() As System.Boolean
                Get
                    Return _IsEnable
                End Get
                Set(ByVal value As System.Boolean)
                    _IsEnable = value
                End Set
            End Property
#End Region
#Region "APL1處理狀態記錄 函式:APLP1rocessStatus"
            ''' <summary>
            ''' APL1處理狀態記錄
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property APL1ProcessStatus As String
#End Region

        End Class
	End Namespace
End Namespace