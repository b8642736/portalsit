Namespace SQLServer
	Namespace PPS100LB
        Public Class StationToWebClientPCAccount
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
            End Sub

#Region "StationName 屬性:StationName"
            Private _StationName As System.String
            ''' <summary>
            ''' ProcessSchedualID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property StationName() As System.String
                Get
                    Return _StationName
                End Get
                Set(ByVal value As System.String)
                    _StationName = value
                End Set
            End Property
#End Region
#Region "ClientIP 屬性:ClientIP"
            Private _ClientIP As System.String
            ''' <summary>
            ''' ClientIP
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property ClientIP() As System.String
                Get
                    Return _ClientIP
                End Get
                Set(ByVal value As System.String)
                    _ClientIP = value
                End Set
            End Property
#End Region
        End Class
	End Namespace
End Namespace