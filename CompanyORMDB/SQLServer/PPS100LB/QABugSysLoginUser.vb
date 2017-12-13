Namespace SQLServer
	Namespace PPS100LB
        Public Class QABugSysLoginUser
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
            End Sub

#Region "EmployeeID 屬性:EmployeeID"
            Private _EmployeeID As System.String
            ''' <summary>
            ''' EmployeeID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property EmployeeID() As System.String
                Get
                    Return _EmployeeID
                End Get
                Set(ByVal value As System.String)
                    _EmployeeID = value
                End Set
            End Property
#End Region
#Region "Password 屬性:Password"
            Private _Password As System.String
            ''' <summary>
            ''' Password
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Password() As System.String
                Get
                    Return _Password
                End Get
                Set(ByVal value As System.String)
                    _Password = value
                End Set
            End Property
#End Region
#Region "ChineseName 屬性:ChineseName"
            Private _ChineseName As System.String
            ''' <summary>
            ''' ChineseName
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ChineseName() As System.String
                Get
                    Return _ChineseName
                End Get
                Set(ByVal value As System.String)
                    _ChineseName = value
                End Set
            End Property
#End Region
        End Class
	End Namespace
End Namespace