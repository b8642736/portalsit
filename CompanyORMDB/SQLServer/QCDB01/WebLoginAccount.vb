Namespace SQLServer
	Namespace QCDB01
        Public Class WebLoginAccount
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server0SM, "QCDB01")
            End Sub

#Region "WindowLoginName 屬性:WindowLoginName"
            Private _WindowLoginName As System.String
            ''' <summary>
            ''' WindowLoginName
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property WindowLoginName() As System.String
                Get
                    Return _WindowLoginName
                End Get
                Set(ByVal value As System.String)
                    _WindowLoginName = value
                End Set
            End Property
#End Region
#Region "DisplayName 屬性:DisplayName"
            Private _DisplayName As System.String
            ''' <summary>
            ''' DisplayName
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DisplayName() As System.String
                Get
                    Return _DisplayName
                End Get
                Set(ByVal value As System.String)
                    _DisplayName = value
                End Set
            End Property
#End Region
#Region "Memo1 屬性:Memo1"
            Private _Memo1 As System.String
            ''' <summary>
            ''' Memo1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Memo1() As System.String
                Get
                    Return _Memo1
                End Get
                Set(ByVal value As System.String)
                    _Memo1 = value
                End Set
            End Property
#End Region
#Region "Email 屬性:Email"
            Private _Email As System.String
            ''' <summary>
            ''' Email
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Email() As System.String
                Get
                    Return _Email
                End Get
                Set(ByVal value As System.String)
                    _Email = value
                End Set
            End Property
#End Region
        End Class
	End Namespace
End Namespace