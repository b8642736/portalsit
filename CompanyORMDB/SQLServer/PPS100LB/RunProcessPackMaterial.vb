Namespace SQLServer
    Namespace PPS100LB
        Public Class RunProcessPackMaterial
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
            End Sub


#Region "CoilNumber 屬性:CoilNumber"
            Private _CoilNumber As System.String
            ''' <summary>
            ''' CoilNumber
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property CoilNumber() As System.String
                Get
                    Return _CoilNumber
                End Get
                Set(ByVal value As System.String)
                    _CoilNumber = value
                End Set
            End Property
#End Region
#Region "CoilType 屬性:CoilType"
            Private _CoilType As System.String
            ''' <summary>
            ''' CoilType
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CoilType() As System.String
                Get
                    Return _CoilType
                End Get
                Set(ByVal value As System.String)
                    _CoilType = value
                End Set
            End Property
#End Region
#Region "CoilSurfaceType 屬性:CoilSurfaceType"
            Private _CoilSurfaceType As System.String
            ''' <summary>
            ''' CoilSurfaceType
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CoilSurfaceType() As System.String
                Get
                    Return _CoilSurfaceType
                End Get
                Set(ByVal value As System.String)
                    _CoilSurfaceType = value
                End Set
            End Property
#End Region
#Region "CoilThick 屬性:CoilThick"
            Private _CoilThick As System.Double
            ''' <summary>
            ''' CoilThick
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CoilThick() As System.Double
                Get
                    Return _CoilThick
                End Get
                Set(ByVal value As System.Double)
                    _CoilThick = value
                End Set
            End Property
#End Region
#Region "CoilWidth 屬性:CoilWidth"
            Private _CoilWidth As System.Double
            ''' <summary>
            ''' CoilWidth
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CoilWidth() As System.Double
                Get
                    Return _CoilWidth
                End Get
                Set(ByVal value As System.Double)
                    _CoilWidth = value
                End Set
            End Property
#End Region
#Region "CoilWeight 屬性:CoilWeight"
            Private _CoilWeight As System.Double
            ''' <summary>
            ''' CoilWeight
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CoilWeight() As System.Double
                Get
                    Return _CoilWeight
                End Get
                Set(ByVal value As System.Double)
                    _CoilWeight = value
                End Set
            End Property
#End Region
#Region "CoilMaterialType 屬性:CoilMaterialType"
            Private _CoilMaterialType As System.String
            ''' <summary>
            ''' CoilMaterialType
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CoilMaterialType() As System.String
                Get
                    Return _CoilMaterialType
                End Get
                Set(ByVal value As System.String)
                    _CoilMaterialType = value
                End Set
            End Property
#End Region
#Region "CoilRadius 屬性:CoilRadius"
            Private _CoilRadius As System.String
            ''' <summary>
            ''' CoilRadius
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CoilRadius() As System.String
                Get
                    Return _CoilRadius
                End Get
                Set(ByVal value As System.String)
                    _CoilRadius = value
                End Set
            End Property
#End Region
#Region "DataCreateTime 屬性:DataCreateTime"
            Private _DataCreateTime As System.DateTime
            ''' <summary>
            ''' DataCreateTime
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DataCreateTime() As System.DateTime
                Get
                    Return _DataCreateTime
                End Get
                Set(ByVal value As System.DateTime)
                    _DataCreateTime = value
                End Set
            End Property
#End Region
#Region "RunStationName 屬性:RunStationName"
            Private _RunStationName As System.String
            ''' <summary>
            ''' RunStationName
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RunStationName() As System.String
                Get
                    Return _RunStationName
                End Get
                Set(ByVal value As System.String)
                    _RunStationName = value
                End Set
            End Property
#End Region
#Region "RunStationIP 屬性:RunStationIP"
            Private _RunStationIP As System.String
            ''' <summary>
            ''' RunStationIP
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RunStationIP() As System.String
                Get
                    Return _RunStationIP
                End Get
                Set(ByVal value As System.String)
                    _RunStationIP = value
                End Set
            End Property
#End Region
#Region "MCode_SteelBuckle 屬性:MCode_SteelBuckle"
            Private _MCode_SteelBuckle As System.String
            ''' <summary>
            ''' MCode_SteelBuckle
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property MCode_SteelBuckle() As System.String
                Get
                    Return _MCode_SteelBuckle
                End Get
                Set(ByVal value As System.String)
                    _MCode_SteelBuckle = value
                End Set
            End Property
#End Region
#Region "Recycle_SteelBuckle 屬性:Recycle_SteelBuckle"
            Private _Recycle_SteelBuckle As System.String
            ''' <summary>
            ''' Recycle_SteelBuckle
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Recycle_SteelBuckle() As System.String
                Get
                    Return _Recycle_SteelBuckle
                End Get
                Set(ByVal value As System.String)
                    _Recycle_SteelBuckle = value
                End Set
            End Property
#End Region
#Region "Weight_SteelBuckle 屬性:Weight_SteelBuckle"
            Private _Weight_SteelBuckle As System.Int32
            ''' <summary>
            ''' Weight_SteelBuckle
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Weight_SteelBuckle() As System.Int32
                Get
                    Return _Weight_SteelBuckle
                End Get
                Set(ByVal value As System.Int32)
                    _Weight_SteelBuckle = value
                End Set
            End Property
#End Region
#Region "IsUse_KleinDragon 屬性:IsUse_KleinDragon"
            Private _IsUse_KleinDragon As System.String
            ''' <summary>
            ''' IsUse_KleinDragon
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsUse_KleinDragon() As System.String
                Get
                    Return _IsUse_KleinDragon
                End Get
                Set(ByVal value As System.String)
                    _IsUse_KleinDragon = value
                End Set
            End Property
#End Region
#Region "MCode_KleinDragon 屬性:MCode_KleinDragon"
            Private _MCode_KleinDragon As System.String
            ''' <summary>
            ''' MCode_KleinDragon
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property MCode_KleinDragon() As System.String
                Get
                    Return _MCode_KleinDragon
                End Get
                Set(ByVal value As System.String)
                    _MCode_KleinDragon = value
                End Set
            End Property
#End Region
#Region "Recycle_KleinDragon 屬性:Recycle_KleinDragon"
            Private _Recycle_KleinDragon As System.String
            ''' <summary>
            ''' Recycle_KleinDragon
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Recycle_KleinDragon() As System.String
                Get
                    Return _Recycle_KleinDragon
                End Get
                Set(ByVal value As System.String)
                    _Recycle_KleinDragon = value
                End Set
            End Property
#End Region
#Region "Speci_KleinDragon 屬性:Speci_KleinDragon"
            Private _Speci_KleinDragon As System.String
            ''' <summary>
            ''' Speci_KleinDragon
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Speci_KleinDragon() As System.String
                Get
                    Return _Speci_KleinDragon
                End Get
                Set(ByVal value As System.String)
                    _Speci_KleinDragon = value
                End Set
            End Property
#End Region
#Region "Length_KleinDragon 屬性:Length_KleinDragon"
            Private _Length_KleinDragon As System.Double
            ''' <summary>
            ''' Length_KleinDragon
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Length_KleinDragon() As System.Double
                Get
                    Return _Length_KleinDragon
                End Get
                Set(ByVal value As System.Double)
                    _Length_KleinDragon = value
                End Set
            End Property
#End Region
#Region "Weight_KleinDragon 屬性:Weight_KleinDragon"
            Private _Weight_KleinDragon As System.Int32
            ''' <summary>
            ''' Weight_KleinDragon
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Weight_KleinDragon() As System.Int32
                Get
                    Return _Weight_KleinDragon
                End Get
                Set(ByVal value As System.Int32)
                    _Weight_KleinDragon = value
                End Set
            End Property
#End Region
#Region "IsUse_Sleeve 屬性:IsUse_Sleeve"
            Private _IsUse_Sleeve As System.String
            ''' <summary>
            ''' IsUse_Sleeve
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsUse_Sleeve() As System.String
                Get
                    Return _IsUse_Sleeve
                End Get
                Set(ByVal value As System.String)
                    _IsUse_Sleeve = value
                End Set
            End Property
#End Region
#Region "MCode_Sleeve 屬性:MCode_Sleeve"
            Private _MCode_Sleeve As System.String
            ''' <summary>
            ''' MCode_Sleeve
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property MCode_Sleeve() As System.String
                Get
                    Return _MCode_Sleeve
                End Get
                Set(ByVal value As System.String)
                    _MCode_Sleeve = value
                End Set
            End Property
#End Region
#Region "Recycle_Sleeve 屬性:Recycle_Sleeve"
            Private _Recycle_Sleeve As System.String
            ''' <summary>
            ''' Recycle_Sleeve
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Recycle_Sleeve() As System.String
                Get
                    Return _Recycle_Sleeve
                End Get
                Set(ByVal value As System.String)
                    _Recycle_Sleeve = value
                End Set
            End Property
#End Region
#Region "Type_Sleeve 屬性:Type_Sleeve"
            Private _Type_Sleeve As System.String
            ''' <summary>
            ''' Type_Sleeve
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Type_Sleeve() As System.String
                Get
                    Return _Type_Sleeve
                End Get
                Set(ByVal value As System.String)
                    _Type_Sleeve = value
                End Set
            End Property
#End Region
#Region "Speci_Sleeve 屬性:Speci_Sleeve"
            Private _Speci_Sleeve As System.String
            ''' <summary>
            ''' Speci_Sleeve
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Speci_Sleeve() As System.String
                Get
                    Return _Speci_Sleeve
                End Get
                Set(ByVal value As System.String)
                    _Speci_Sleeve = value
                End Set
            End Property
#End Region
#Region "Weight_Sleeve 屬性:Weight_Sleeve"
            Private _Weight_Sleeve As System.Int32
            ''' <summary>
            ''' Weight_Sleeve
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Weight_Sleeve() As System.Int32
                Get
                    Return _Weight_Sleeve
                End Get
                Set(ByVal value As System.Int32)
                    _Weight_Sleeve = value
                End Set
            End Property
#End Region
#Region "IsUse_BackingPaper 屬性:IsUse_BackingPaper"
            Private _IsUse_BackingPaper As System.String
            ''' <summary>
            ''' IsUse_BackingPaper
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsUse_BackingPaper() As System.String
                Get
                    Return _IsUse_BackingPaper
                End Get
                Set(ByVal value As System.String)
                    _IsUse_BackingPaper = value
                End Set
            End Property
#End Region
#Region "MCode_BackingPaper 屬性:MCode_BackingPaper"
            Private _MCode_BackingPaper As System.String
            ''' <summary>
            ''' MCode_BackingPaper
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property MCode_BackingPaper() As System.String
                Get
                    Return _MCode_BackingPaper
                End Get
                Set(ByVal value As System.String)
                    _MCode_BackingPaper = value
                End Set
            End Property
#End Region
#Region "Recycle_BackingPaper 屬性:Recycle_BackingPaper"
            Private _Recycle_BackingPaper As System.String
            ''' <summary>
            ''' Recycle_BackingPaper
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Recycle_BackingPaper() As System.String
                Get
                    Return _Recycle_BackingPaper
                End Get
                Set(ByVal value As System.String)
                    _Recycle_BackingPaper = value
                End Set
            End Property
#End Region
#Region "Type_BackingPaper 屬性:Type_BackingPaper"
            Private _Type_BackingPaper As System.String
            ''' <summary>
            ''' Type_BackingPaper
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Type_BackingPaper() As System.String
                Get
                    Return _Type_BackingPaper
                End Get
                Set(ByVal value As System.String)
                    _Type_BackingPaper = value
                End Set
            End Property
#End Region
#Region "Speci_BackingPaper 屬性:Speci_BackingPaper"
            Private _Speci_BackingPaper As System.String
            ''' <summary>
            ''' Speci_BackingPaper
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Speci_BackingPaper() As System.String
                Get
                    Return _Speci_BackingPaper
                End Get
                Set(ByVal value As System.String)
                    _Speci_BackingPaper = value
                End Set
            End Property
#End Region
#Region "Length_BackingPaper 屬性:Length_BackingPaper"
            Private _Length_BackingPaper As System.String
            ''' <summary>
            ''' Length_BackingPaper
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Length_BackingPaper() As System.String
                Get
                    Return _Length_BackingPaper
                End Get
                Set(ByVal value As System.String)
                    _Length_BackingPaper = value
                End Set
            End Property
#End Region
#Region "Weight_BackingPaper 屬性:Weight_BackingPaper"
            Private _Weight_BackingPaper As System.Int32
            ''' <summary>
            ''' Weight_BackingPaper
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Weight_BackingPaper() As System.Int32
                Get
                    Return _Weight_BackingPaper
                End Get
                Set(ByVal value As System.Int32)
                    _Weight_BackingPaper = value
                End Set
            End Property
#End Region
#Region "TotalWeight 屬性:TotalWeight"
            Private _TotalWeight As System.Int32
            ''' <summary>
            ''' TotalWeight
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property TotalWeight() As System.Int32
                Get
                    Return _TotalWeight
                End Get
                Set(ByVal value As System.Int32)
                    _TotalWeight = value
                End Set
            End Property
#End Region
#Region "IsExport 屬性:IsExport"
            Private _IsExport As System.String
            ''' <summary>
            ''' IsExport
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsExport() As System.String
                Get
                    Return _IsExport
                End Get
                Set(ByVal value As System.String)
                    _IsExport = value
                End Set
            End Property
#End Region
#Region "FromEIP_EditUser 屬性:FromEIP_EditUser"
            Private _FromEIP_EditUser As System.String
            ''' <summary>
            ''' FromEIP_EditUser
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FromEIP_EditUser() As System.String
                Get
                    Return _FromEIP_EditUser
                End Get
                Set(ByVal value As System.String)
                    _FromEIP_EditUser = value
                End Set
            End Property
#End Region
        End Class
    End Namespace
End Namespace