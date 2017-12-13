Namespace SQLServer
	Namespace PPS100LB
	Public Class ProcessToInOutOperationLineName
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
	End Sub

#Region "ProcessSchedualID 屬性:ProcessSchedualID"
	Private _ProcessSchedualID As System.String
	''' <summary>
	''' ProcessSchedualID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property ProcessSchedualID() As System.String
                Get
                    Return _ProcessSchedualID
                End Get
                Set(ByVal value As System.String)
                    _ProcessSchedualID = value
                End Set
            End Property
#End Region
#Region "InOutOperationLineName 屬性:InOutOperationLineName"
            Private _InOutOperationLineNameID As System.String
	''' <summary>
	''' InOutOperationLineName
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property InOutOperationLineNameID() As System.String
                Get
                    Return _InOutOperationLineNameID
                End Get
                Set(ByVal value As System.String)
                    _InOutOperationLineNameID = value
                End Set
            End Property
#End Region

	End Class
	End Namespace
End Namespace