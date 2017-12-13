Namespace SQLServer
    Namespace PPS100LB
        Public Class PhysicalTest
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
#Region "TestDate 屬性:TestDate"
            Private _TestDate As System.String
            ''' <summary>
            ''' TestDate
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property TestDate() As System.String
                Get
                    Return _TestDate
                End Get
                Set(ByVal value As System.String)
                    _TestDate = value
                End Set
            End Property
#End Region
#Region "Line 屬性:Line"
            Private _Line As System.String
            ''' <summary>
            ''' Line
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property Line() As System.String
                Get
                    Return _Line
                End Get
                Set(ByVal value As System.String)
                    _Line = value
                End Set
            End Property
#End Region
#Region "Direction 屬性:Direction"
            Private _Direction As System.String
            ''' <summary>
            ''' Direction
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property Direction() As System.String
                Get
                    Return _Direction
                End Get
                Set(ByVal value As System.String)
                    _Direction = value
                End Set
            End Property
#End Region
#Region "Gauge 屬性:Gauge"
            Private _Gauge As System.Double
            ''' <summary>
            ''' Gauge
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Gauge() As System.Double
                Get
                    Return _Gauge
                End Get
                Set(ByVal value As System.Double)
                    _Gauge = value
                End Set
            End Property
#End Region
#Region "Width 屬性:Width"
            Private _Width As System.Double
            ''' <summary>
            ''' Width
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Width() As System.Double
                Get
                    Return _Width
                End Get
                Set(ByVal value As System.Double)
                    _Width = value
                End Set
            End Property
#End Region
#Region "Area 屬性:Area"
            Private _Area As System.Double
            ''' <summary>
            ''' Area
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Area() As System.Double
                Get
                    Return _Area
                End Get
                Set(ByVal value As System.Double)
                    _Area = value
                End Set
            End Property
#End Region
#Region "HRB 屬性:HRB"
            Private _HRB As System.Double
            ''' <summary>
            ''' HRB
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property HRB() As System.Double
                Get
                    Return _HRB
                End Get
                Set(ByVal value As System.Double)
                    _HRB = value
                End Set
            End Property
#End Region
#Region "HRC 屬性:HRC"
            Private _HRC As System.Double
            ''' <summary>
            ''' HRC
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property HRC() As System.Double
                Get
                    Return _HRC
                End Get
                Set(ByVal value As System.Double)
                    _HRC = value
                End Set
            End Property
#End Region
#Region "HV 屬性:HV"
            Private _HV As System.Double
            ''' <summary>
            ''' HV
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property HV() As System.Double
                Get
                    Return _HV
                End Get
                Set(ByVal value As System.Double)
                    _HV = value
                End Set
            End Property
#End Region
#Region "YS 屬性:YS"
            Private _YS As System.Double
            ''' <summary>
            ''' YS
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property YS() As System.Double
                Get
                    Return _YS
                End Get
                Set(ByVal value As System.Double)
                    _YS = value
                End Set
            End Property
#End Region
#Region "EModulus 屬性:EModulus"
            Private _EModulus As System.Double
            ''' <summary>
            ''' EModulus
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property EModulus() As System.Double
                Get
                    Return _EModulus
                End Get
                Set(ByVal value As System.Double)
                    _EModulus = value
                End Set
            End Property
#End Region
#Region "TS 屬性:TS"
            Private _TS As System.Double
            ''' <summary>
            ''' TS
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property TS() As System.Double
                Get
                    Return _TS
                End Get
                Set(ByVal value As System.Double)
                    _TS = value
                End Set
            End Property
#End Region
#Region "Elongation 屬性:Elongation"
            Private _Elongation As System.Double
            ''' <summary>
            ''' Elongation
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Elongation() As System.Double
                Get
                    Return _Elongation
                End Get
                Set(ByVal value As System.Double)
                    _Elongation = value
                End Set
            End Property
#End Region
#Region "NValue 屬性:NValue"
            Private _NValue As System.Double
            ''' <summary>
            ''' NValue
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property NValue() As System.Double
                Get
                    Return _NValue
                End Get
                Set(ByVal value As System.Double)
                    _NValue = value
                End Set
            End Property
#End Region
#Region "Surface 屬性:Surface"
            Private _Surface As System.Double
            ''' <summary>
            ''' Surface
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Surface() As System.Double
                Get
                    Return _Surface
                End Get
                Set(ByVal value As System.Double)
                    _Surface = value
                End Set
            End Property
#End Region
#Region "RValue 屬性:RValue"
            Private _RValue As System.Double
            ''' <summary>
            ''' RValue
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RValue() As System.Double
                Get
                    Return _RValue
                End Get
                Set(ByVal value As System.Double)
                    _RValue = value
                End Set
            End Property
#End Region
#Region "Mirco 屬性:Mirco"
            Private _Mirco As System.Double
            ''' <summary>
            ''' Mirco
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Mirco() As System.Double
                Get
                    Return _Mirco
                End Get
                Set(ByVal value As System.Double)
                    _Mirco = value
                End Set
            End Property
#End Region
#Region "Rp10 屬性:Rp10"
            Private _Rp10 As System.Double
            ''' <summary>
            ''' Rp10
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Rp10() As System.Double
                Get
                    Return _Rp10
                End Get
                Set(ByVal value As System.Double)
                    _Rp10 = value
                End Set
            End Property
#End Region
#Region "WriteAS400Time 屬性:WriteAS400Time"
            Private _WriteAS400Time As System.DateTime
            ''' <summary>
            ''' WriteAS400Time
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property WriteAS400Time() As System.DateTime
                Get
                    Return _WriteAS400Time
                End Get
                Set(ByVal value As System.DateTime)
                    _WriteAS400Time = value
                End Set
            End Property
#End Region
#Region "IsDelete 屬性:IsDelete"
            Private _IsDelete As System.String
            ''' <summary>
            ''' IsDelete
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property IsDelete() As System.String
                Get
                    Return _IsDelete
                End Get
                Set(ByVal value As System.String)
                    _IsDelete = value
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
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property DeleteTime() As System.DateTime
                Get
                    Return _DeleteTime
                End Get
                Set(ByVal value As System.DateTime)
                    _DeleteTime = value
                End Set
            End Property
#End Region
#Region "StationIP 屬性:StationIP"
            Private _StationIP As System.String
            ''' <summary>
            ''' StationIP
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property StationIP() As System.String
                Get
                    Return _StationIP
                End Get
                Set(ByVal value As System.String)
                    _StationIP = value
                End Set
            End Property
#End Region
#Region "IsUpdate 屬性:IsUpdate"
            Private _IsUpdate As System.String
            ''' <summary>
            ''' IsUpdate
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsUpdate() As System.String
                Get
                    Return _IsUpdate
                End Get
                Set(ByVal value As System.String)
                    _IsUpdate = value
                End Set
            End Property
#End Region
        End Class
    End Namespace
End Namespace