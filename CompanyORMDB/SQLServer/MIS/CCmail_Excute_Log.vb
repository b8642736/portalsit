Namespace SQLServer
    Namespace MIS
        Public Class CCmail_Excute_Log
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "MIS")
            End Sub

#Region "Target 屬性:Target"
            Private _Target As System.String
            ''' <summary>
            ''' Target
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Target() As System.String
                Get
                    Return _Target
                End Get
                Set(ByVal value As System.String)
                    _Target = value
                End Set
            End Property
#End Region
#Region "XML 屬性:XML"
            Private _XML As System.String
            ''' <summary>
            ''' XML
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property XML() As System.String
                Get
                    Return _XML
                End Get
                Set(ByVal value As System.String)
                    _XML = value
                End Set
            End Property
#End Region
#Region "Result 屬性:Result"
            Private _Result As System.String
            ''' <summary>
            ''' Result
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Result() As System.String
                Get
                    Return _Result
                End Get
                Set(ByVal value As System.String)
                    _Result = value
                End Set
            End Property
#End Region
#Region "Excute_Date 屬性:Excute_Date"
            Private _Excute_Date As System.DateTime
            ''' <summary>
            ''' Excute_Date
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Excute_Date() As System.DateTime
                Get
                    Return _Excute_Date
                End Get
                Set(ByVal value As System.DateTime)
                    _Excute_Date = value
                End Set
            End Property
#End Region
        End Class
    End Namespace
End Namespace