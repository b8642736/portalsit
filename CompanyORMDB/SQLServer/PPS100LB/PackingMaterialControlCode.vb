Namespace SQLServer
    Namespace PPS100LB
        Public Class PackingMaterialControlCode
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
            End Sub

#Region "MaterialName 屬性:MaterialName"
            Private _MaterialName As System.String
            ''' <summary>
            ''' MaterialName
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property MaterialName() As System.String
                Get
                    Return _MaterialName
                End Get
                Set(ByVal value As System.String)
                    _MaterialName = value
                End Set
            End Property
#End Region
#Region "Specification 屬性:Specification"
            Private _Specification As System.String
            ''' <summary>
            ''' Specification
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property Specification() As System.String
                Get
                    Return _Specification
                End Get
                Set(ByVal value As System.String)
                    _Specification = value
                End Set
            End Property
#End Region
#Region "ItemNumber 屬性:ItemNumber"
            Private _ItemNumber As System.String
            ''' <summary>
            ''' ItemNumber
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property ItemNumber() As System.String
                Get
                    Return _ItemNumber
                End Get
                Set(ByVal value As System.String)
                    _ItemNumber = value
                End Set
            End Property
#End Region
#Region "BaseWeight 屬性:BaseWeight"
            Private _BaseWeight As System.Double
            ''' <summary>
            ''' BaseWeight
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BaseWeight() As System.Double
                Get
                    Return _BaseWeight
                End Get
                Set(ByVal value As System.Double)
                    _BaseWeight = value
                End Set
            End Property
#End Region
#Region "WhoAdd 屬性:WhoAdd"
            Private _WhoAdd As System.String
            ''' <summary>
            ''' WhoAdd
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property WhoAdd() As System.String
                Get
                    Return _WhoAdd
                End Get
                Set(ByVal value As System.String)
                    _WhoAdd = value
                End Set
            End Property
#End Region
#Region "DateCreateTime 屬性:DateCreateTime"
            Private _DateCreateTime As System.DateTime
            ''' <summary>
            ''' DateCreateTime
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DateCreateTime() As System.DateTime
                Get
                    Return _DateCreateTime
                End Get
                Set(ByVal value As System.DateTime)
                    _DateCreateTime = value
                End Set
            End Property
#End Region
#Region "EditTime 屬性:EditTime"
            Private _EditTime As System.DateTime
            ''' <summary>
            ''' EditTime
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property EditTime() As System.DateTime
                Get
                    Return _EditTime
                End Get
                Set(ByVal value As System.DateTime)
                    _EditTime = value
                End Set
            End Property
#End Region
#Region "WhoDelete 屬性:WhoDelete"
            Private _WhoDelete As System.String
            ''' <summary>
            ''' WhoDelete
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property WhoDelete() As System.String
                Get
                    Return _WhoDelete
                End Get
                Set(ByVal value As System.String)
                    _WhoDelete = value
                End Set
            End Property
#End Region
#Region "DeleteTime 屬性:DeleteTime"
            Private _DeleteTime As System.DateTime
            ''' <summary>
            ''' DeleteTime
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DeleteTime() As System.DateTime
                Get
                    Return _DeleteTime
                End Get
                Set(ByVal value As System.DateTime)
                    _DeleteTime = value
                End Set
            End Property
#End Region
#Region "UserIP 屬性:UserIP"
            Private _UserIP As System.String
            ''' <summary>
            ''' UserIP
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property UserIP() As System.String
                Get
                    Return _UserIP
                End Get
                Set(ByVal value As System.String)
                    _UserIP = value
                End Set
            End Property
#End Region
        End Class
    End Namespace
End Namespace