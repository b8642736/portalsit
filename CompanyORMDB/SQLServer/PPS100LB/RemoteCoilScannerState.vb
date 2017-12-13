Namespace SQLServer
	Namespace PPS100LB
	Public Class RemoteCoilScannerState
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

#Region "LocalPCIP 屬性:LocalPCIP"
	Private _LocalPCIP As System.String
	''' <summary>
	''' LocalPCIP
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property LocalPCIP() As System.String
                Get
                    Return _LocalPCIP
                End Get
                Set(ByVal value As System.String)
                    _LocalPCIP = value
                End Set
            End Property
#End Region
#Region "ConnectToServerIP 屬性:ConnectToServerIP"
	Private _ConnectToServerIP As System.String
	''' <summary>
	''' ConnectToServerIP
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            Public Property ConnectToServerIP() As System.String
                Get
                    Return _ConnectToServerIP
                End Get
                Set(ByVal value As System.String)
                    _ConnectToServerIP = value
                End Set
            End Property
#End Region
#Region "IsOffLineOperator 屬性:IsOffLineOperator"
	Private _IsOffLineOperator As System.Boolean
	''' <summary>
	''' IsOffLineOperator
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property IsOffLineOperator () As System.Boolean
		Get
			Return _IsOffLineOperator
		End Get
		Set(Byval value as System.Boolean)
			_IsOffLineOperator = value
		End Set
	End Property
#End Region

	End Class
	End Namespace
End Namespace