Namespace SQLServer
    Namespace PPS100LB
        ''' <summary>
        ''' 鋼捲缺陷其它資料
        ''' </summary>
        ''' <remarks></remarks>
        Public Class QABugRecordOtherData
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                Me.CoilMaxLength = 9999
                Me.CoilMaxAddJointLength = 9999
                Me.CoilPositionErrLength = -2
                Me.CoilStartTime = Now
                Me.CoilEndTime = Me.CoilStartTime
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
#Region "DataDate 屬性:DataDate"
            Private _DataDate As System.DateTime
            ''' <summary>
            ''' DataDate
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property DataDate() As System.DateTime
                Get
                    Return _DataDate
                End Get
                Set(ByVal value As System.DateTime)
                    _DataDate = value
                End Set
            End Property
#End Region
#Region "StationName 屬性:StationName"
            Private _StationName As System.String
            ''' <summary>
            ''' StationName
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
#Region "Version 屬性:Version"
            Private _Version As System.String
            ''' <summary>
            ''' Version
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property Version() As System.String
                Get
                    Return _Version
                End Get
                Set(ByVal value As System.String)
                    _Version = value
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
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property DataCreateTime() As System.DateTime
                Get
                    Return _DataCreateTime
                End Get
                Set(ByVal value As System.DateTime)
                    _DataCreateTime = value
                End Set
            End Property
#End Region
#Region "BALPBrightLengthMM1 屬性:BALPBrightLengthMM1"
            Private _BALPBrightLengthMM1 As System.Decimal
            ''' <summary>
            ''' BALPBrightLengthMM1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightLengthMM1() As System.Decimal
                Get
                    Return _BALPBrightLengthMM1
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightLengthMM1 = value
                End Set
            End Property
#End Region
#Region "BALPBrightLengthMM2 屬性:BALPBrightLengthMM2"
            Private _BALPBrightLengthMM2 As System.Decimal
            ''' <summary>
            ''' BALPBrightLengthMM2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightLengthMM2() As System.Decimal
                Get
                    Return _BALPBrightLengthMM2
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightLengthMM2 = value
                End Set
            End Property
#End Region
#Region "BALPBrightLengthMM3 屬性:BALPBrightLengthMM3"
            Private _BALPBrightLengthMM3 As System.Decimal
            ''' <summary>
            ''' BALPBrightLengthMM3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightLengthMM3() As System.Decimal
                Get
                    Return _BALPBrightLengthMM3
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightLengthMM3 = value
                End Set
            End Property
#End Region
#Region "BALPBrightLengthMM4 屬性:BALPBrightLengthMM4"
            Private _BALPBrightLengthMM4 As System.Decimal
            ''' <summary>
            ''' BALPBrightLengthMM4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightLengthMM4() As System.Decimal
                Get
                    Return _BALPBrightLengthMM4
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightLengthMM4 = value
                End Set
            End Property
#End Region
#Region "BALPBrightLengthMM5 屬性:BALPBrightLengthMM5"
            Private _BALPBrightLengthMM5 As System.Decimal
            ''' <summary>
            ''' BALPBrightLengthMM5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightLengthMM5() As System.Decimal
                Get
                    Return _BALPBrightLengthMM5
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightLengthMM5 = value
                End Set
            End Property
#End Region
#Region "BALPBrightLengthMM6 屬性:BALPBrightLengthMM6"
            Private _BALPBrightLengthMM6 As System.Decimal
            ''' <summary>
            ''' BALPBrightLengthMM6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightLengthMM6() As System.Decimal
                Get
                    Return _BALPBrightLengthMM6
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightLengthMM6 = value
                End Set
            End Property
#End Region
#Region "BALNBrightLengthMM1 屬性:BALNBrightLengthMM1"
            Private _BALNBrightLengthMM1 As System.Decimal
            ''' <summary>
            ''' BALNBrightLengthMM1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightLengthMM1() As System.Decimal
                Get
                    Return _BALNBrightLengthMM1
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightLengthMM1 = value
                End Set
            End Property
#End Region
#Region "BALNBrightLengthMM2 屬性:BALNBrightLengthMM2"
            Private _BALNBrightLengthMM2 As System.Decimal
            ''' <summary>
            ''' BALNBrightLengthMM2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightLengthMM2() As System.Decimal
                Get
                    Return _BALNBrightLengthMM2
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightLengthMM2 = value
                End Set
            End Property
#End Region
#Region "BALNBrightLengthMM3 屬性:BALNBrightLengthMM3"
            Private _BALNBrightLengthMM3 As System.Decimal
            ''' <summary>
            ''' BALNBrightLengthMM3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightLengthMM3() As System.Decimal
                Get
                    Return _BALNBrightLengthMM3
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightLengthMM3 = value
                End Set
            End Property
#End Region
#Region "BALNBrightLengthMM4 屬性:BALNBrightLengthMM4"
            Private _BALNBrightLengthMM4 As System.Decimal
            ''' <summary>
            ''' BALNBrightLengthMM4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightLengthMM4() As System.Decimal
                Get
                    Return _BALNBrightLengthMM4
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightLengthMM4 = value
                End Set
            End Property
#End Region
#Region "BALNBrightLengthMM5 屬性:BALNBrightLengthMM5"
            Private _BALNBrightLengthMM5 As System.Decimal
            ''' <summary>
            ''' BALNBrightLengthMM5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightLengthMM5() As System.Decimal
                Get
                    Return _BALNBrightLengthMM5
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightLengthMM5 = value
                End Set
            End Property
#End Region
#Region "BALNBrightLengthMM6 屬性:BALNBrightLengthMM6"
            Private _BALNBrightLengthMM6 As System.Decimal
            ''' <summary>
            ''' BALNBrightLengthMM6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightLengthMM6() As System.Decimal
                Get
                    Return _BALNBrightLengthMM6
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightLengthMM6 = value
                End Set
            End Property
#End Region
#Region "BALPBrightCenterMM1 屬性:BALPBrightCenterMM1"
            Private _BALPBrightCenterMM1 As System.Decimal
            ''' <summary>
            ''' BALPBrightCenterMM1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightCenterMM1() As System.Decimal
                Get
                    Return _BALPBrightCenterMM1
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightCenterMM1 = value
                End Set
            End Property
#End Region
#Region "BALPBrightCenterMM2 屬性:BALPBrightCenterMM2"
            Private _BALPBrightCenterMM2 As System.Decimal
            ''' <summary>
            ''' BALPBrightCenterMM2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightCenterMM2() As System.Decimal
                Get
                    Return _BALPBrightCenterMM2
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightCenterMM2 = value
                End Set
            End Property
#End Region
#Region "BALPBrightCenterMM3 屬性:BALPBrightCenterMM3"
            Private _BALPBrightCenterMM3 As System.Decimal
            ''' <summary>
            ''' BALPBrightCenterMM3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightCenterMM3() As System.Decimal
                Get
                    Return _BALPBrightCenterMM3
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightCenterMM3 = value
                End Set
            End Property
#End Region
#Region "BALPBrightCenterMM4 屬性:BALPBrightCenterMM4"
            Private _BALPBrightCenterMM4 As System.Decimal
            ''' <summary>
            ''' BALPBrightCenterMM4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightCenterMM4() As System.Decimal
                Get
                    Return _BALPBrightCenterMM4
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightCenterMM4 = value
                End Set
            End Property
#End Region
#Region "BALPBrightCenterMM5 屬性:BALPBrightCenterMM5"
            Private _BALPBrightCenterMM5 As System.Decimal
            ''' <summary>
            ''' BALPBrightCenterMM5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightCenterMM5() As System.Decimal
                Get
                    Return _BALPBrightCenterMM5
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightCenterMM5 = value
                End Set
            End Property
#End Region
#Region "BALPBrightCenterMM6 屬性:BALPBrightCenterMM6"
            Private _BALPBrightCenterMM6 As System.Decimal
            ''' <summary>
            ''' BALPBrightCenterMM6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightCenterMM6() As System.Decimal
                Get
                    Return _BALPBrightCenterMM6
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightCenterMM6 = value
                End Set
            End Property
#End Region
#Region "BALNBrightCenterMM1 屬性:BALNBrightCenterMM1"
            Private _BALNBrightCenterMM1 As System.Decimal
            ''' <summary>
            ''' BALNBrightCenterMM1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightCenterMM1() As System.Decimal
                Get
                    Return _BALNBrightCenterMM1
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightCenterMM1 = value
                End Set
            End Property
#End Region
#Region "BALNBrightCenterMM2 屬性:BALNBrightCenterMM2"
            Private _BALNBrightCenterMM2 As System.Decimal
            ''' <summary>
            ''' BALNBrightCenterMM2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightCenterMM2() As System.Decimal
                Get
                    Return _BALNBrightCenterMM2
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightCenterMM2 = value
                End Set
            End Property
#End Region
#Region "BALNBrightCenterMM3 屬性:BALNBrightCenterMM3"
            Private _BALNBrightCenterMM3 As System.Decimal
            ''' <summary>
            ''' BALNBrightCenterMM3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightCenterMM3() As System.Decimal
                Get
                    Return _BALNBrightCenterMM3
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightCenterMM3 = value
                End Set
            End Property
#End Region
#Region "BALNBrightCenterMM4 屬性:BALNBrightCenterMM4"
            Private _BALNBrightCenterMM4 As System.Decimal
            ''' <summary>
            ''' BALNBrightCenterMM4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightCenterMM4() As System.Decimal
                Get
                    Return _BALNBrightCenterMM4
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightCenterMM4 = value
                End Set
            End Property
#End Region
#Region "BALNBrightCenterMM5 屬性:BALNBrightCenterMM5"
            Private _BALNBrightCenterMM5 As System.Decimal
            ''' <summary>
            ''' BALNBrightCenterMM5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightCenterMM5() As System.Decimal
                Get
                    Return _BALNBrightCenterMM5
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightCenterMM5 = value
                End Set
            End Property
#End Region
#Region "BALNBrightCenterMM6 屬性:BALNBrightCenterMM6"
            Private _BALNBrightCenterMM6 As System.Decimal
            ''' <summary>
            ''' BALNBrightCenterMM6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightCenterMM6() As System.Decimal
                Get
                    Return _BALNBrightCenterMM6
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightCenterMM6 = value
                End Set
            End Property
#End Region
#Region "BALPBrightSideMM1 屬性:BALPBrightSideMM1"
            Private _BALPBrightSideMM1 As System.Decimal
            ''' <summary>
            ''' BALPBrightSideMM1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightSideMM1() As System.Decimal
                Get
                    Return _BALPBrightSideMM1
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightSideMM1 = value
                End Set
            End Property
#End Region
#Region "BALPBrightSideMM2 屬性:BALPBrightSideMM2"
            Private _BALPBrightSideMM2 As System.Decimal
            ''' <summary>
            ''' BALPBrightSideMM2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightSideMM2() As System.Decimal
                Get
                    Return _BALPBrightSideMM2
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightSideMM2 = value
                End Set
            End Property
#End Region
#Region "BALPBrightSideMM3 屬性:BALPBrightSideMM3"
            Private _BALPBrightSideMM3 As System.Decimal
            ''' <summary>
            ''' BALPBrightSideMM3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightSideMM3() As System.Decimal
                Get
                    Return _BALPBrightSideMM3
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightSideMM3 = value
                End Set
            End Property
#End Region
#Region "BALPBrightSideMM4 屬性:BALPBrightSideMM4"
            Private _BALPBrightSideMM4 As System.Decimal
            ''' <summary>
            ''' BALPBrightSideMM4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightSideMM4() As System.Decimal
                Get
                    Return _BALPBrightSideMM4
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightSideMM4 = value
                End Set
            End Property
#End Region
#Region "BALPBrightSideMM5 屬性:BALPBrightSideMM5"
            Private _BALPBrightSideMM5 As System.Decimal
            ''' <summary>
            ''' BALPBrightSideMM5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightSideMM5() As System.Decimal
                Get
                    Return _BALPBrightSideMM5
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightSideMM5 = value
                End Set
            End Property
#End Region
#Region "BALPBrightSideMM6 屬性:BALPBrightSideMM6"
            Private _BALPBrightSideMM6 As System.Decimal
            ''' <summary>
            ''' BALPBrightSideMM6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALPBrightSideMM6() As System.Decimal
                Get
                    Return _BALPBrightSideMM6
                End Get
                Set(ByVal value As System.Decimal)
                    _BALPBrightSideMM6 = value
                End Set
            End Property
#End Region
#Region "BALNBrightSideMM1 屬性:BALNBrightSideMM1"
            Private _BALNBrightSideMM1 As System.Decimal
            ''' <summary>
            ''' BALNBrightSideMM1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightSideMM1() As System.Decimal
                Get
                    Return _BALNBrightSideMM1
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightSideMM1 = value
                End Set
            End Property
#End Region
#Region "BALNBrightSideMM2 屬性:BALNBrightSideMM2"
            Private _BALNBrightSideMM2 As System.Decimal
            ''' <summary>
            ''' BALNBrightSideMM2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightSideMM2() As System.Decimal
                Get
                    Return _BALNBrightSideMM2
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightSideMM2 = value
                End Set
            End Property
#End Region
#Region "BALNBrightSideMM3 屬性:BALNBrightSideMM3"
            Private _BALNBrightSideMM3 As System.Decimal
            ''' <summary>
            ''' BALNBrightSideMM3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightSideMM3() As System.Decimal
                Get
                    Return _BALNBrightSideMM3
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightSideMM3 = value
                End Set
            End Property
#End Region
#Region "BALNBrightSideMM4 屬性:BALNBrightSideMM4"
            Private _BALNBrightSideMM4 As System.Decimal
            ''' <summary>
            ''' BALNBrightSideMM4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightSideMM4() As System.Decimal
                Get
                    Return _BALNBrightSideMM4
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightSideMM4 = value
                End Set
            End Property
#End Region
#Region "BALNBrightSideMM5 屬性:BALNBrightSideMM5"
            Private _BALNBrightSideMM5 As System.Decimal
            ''' <summary>
            ''' BALNBrightSideMM5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightSideMM5() As System.Decimal
                Get
                    Return _BALNBrightSideMM5
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightSideMM5 = value
                End Set
            End Property
#End Region
#Region "BALNBrightSideMM6 屬性:BALNBrightSideMM6"
            Private _BALNBrightSideMM6 As System.Decimal
            ''' <summary>
            ''' BALNBrightSideMM6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALNBrightSideMM6() As System.Decimal
                Get
                    Return _BALNBrightSideMM6
                End Get
                Set(ByVal value As System.Decimal)
                    _BALNBrightSideMM6 = value
                End Set
            End Property
#End Region
#Region "BALSection1OperateMM 屬性:BALSection1OperateMM"
            Private _BALSection1OperateMM As System.Decimal
            ''' <summary>
            ''' BALSection1OperateMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALSection1OperateMM() As System.Decimal
                Get
                    Return _BALSection1OperateMM
                End Get
                Set(ByVal value As System.Decimal)
                    _BALSection1OperateMM = value
                End Set
            End Property
#End Region
#Region "BALSection2OperateMM 屬性:BALSection2OperateMM"
            Private _BALSection2OperateMM As System.Decimal
            ''' <summary>
            ''' BALSection2OperateMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALSection2OperateMM() As System.Decimal
                Get
                    Return _BALSection2OperateMM
                End Get
                Set(ByVal value As System.Decimal)
                    _BALSection2OperateMM = value
                End Set
            End Property
#End Region
#Region "BALSection3OperateMM 屬性:BALSection3OperateMM"
            Private _BALSection3OperateMM As System.Decimal
            ''' <summary>
            ''' BALSection3OperateMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALSection3OperateMM() As System.Decimal
                Get
                    Return _BALSection3OperateMM
                End Get
                Set(ByVal value As System.Decimal)
                    _BALSection3OperateMM = value
                End Set
            End Property
#End Region
#Region "BALSection4OperateMM 屬性:BALSection4OperateMM"
            Private _BALSection4OperateMM As System.Decimal
            ''' <summary>
            ''' BALSection4OperateMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALSection4OperateMM() As System.Decimal
                Get
                    Return _BALSection4OperateMM
                End Get
                Set(ByVal value As System.Decimal)
                    _BALSection4OperateMM = value
                End Set
            End Property
#End Region
#Region "BALSection1MiddleMM 屬性:BALSection1MiddleMM"
            Private _BALSection1MiddleMM As System.Decimal
            ''' <summary>
            ''' BALSection1MiddleMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALSection1MiddleMM() As System.Decimal
                Get
                    Return _BALSection1MiddleMM
                End Get
                Set(ByVal value As System.Decimal)
                    _BALSection1MiddleMM = value
                End Set
            End Property
#End Region
#Region "BALSection2MiddleMM 屬性:BALSection2MiddleMM"
            Private _BALSection2MiddleMM As System.Decimal
            ''' <summary>
            ''' BALSection2MiddleMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALSection2MiddleMM() As System.Decimal
                Get
                    Return _BALSection2MiddleMM
                End Get
                Set(ByVal value As System.Decimal)
                    _BALSection2MiddleMM = value
                End Set
            End Property
#End Region
#Region "BALSection3MiddleMM 屬性:BALSection3MiddleMM"
            Private _BALSection3MiddleMM As System.Decimal
            ''' <summary>
            ''' BALSection3MiddleMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALSection3MiddleMM() As System.Decimal
                Get
                    Return _BALSection3MiddleMM
                End Get
                Set(ByVal value As System.Decimal)
                    _BALSection3MiddleMM = value
                End Set
            End Property
#End Region
#Region "BALSection4MiddleMM 屬性:BALSection4MiddleMM"
            Private _BALSection4MiddleMM As System.Decimal
            ''' <summary>
            ''' BALSection4MiddleMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALSection4MiddleMM() As System.Decimal
                Get
                    Return _BALSection4MiddleMM
                End Get
                Set(ByVal value As System.Decimal)
                    _BALSection4MiddleMM = value
                End Set
            End Property
#End Region
#Region "BALSection1PowerMM 屬性:BALSection1PowerMM"
            Private _BALSection1PowerMM As System.Decimal
            ''' <summary>
            ''' BALSection1PowerMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALSection1PowerMM() As System.Decimal
                Get
                    Return _BALSection1PowerMM
                End Get
                Set(ByVal value As System.Decimal)
                    _BALSection1PowerMM = value
                End Set
            End Property
#End Region
#Region "BALSection2PowerMM 屬性:BALSection2PowerMM"
            Private _BALSection2PowerMM As System.Decimal
            ''' <summary>
            ''' BALSection2PowerMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALSection2PowerMM() As System.Decimal
                Get
                    Return _BALSection2PowerMM
                End Get
                Set(ByVal value As System.Decimal)
                    _BALSection2PowerMM = value
                End Set
            End Property
#End Region
#Region "BALSection3PowerMM 屬性:BALSection3PowerMM"
            Private _BALSection3PowerMM As System.Decimal
            ''' <summary>
            ''' BALSection3PowerMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALSection3PowerMM() As System.Decimal
                Get
                    Return _BALSection3PowerMM
                End Get
                Set(ByVal value As System.Decimal)
                    _BALSection3PowerMM = value
                End Set
            End Property
#End Region
#Region "BALSection4PowerMM 屬性:BALSection4PowerMM"
            Private _BALSection4PowerMM As System.Decimal
            ''' <summary>
            ''' BALSection4PowerMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BALSection4PowerMM() As System.Decimal
                Get
                    Return _BALSection4PowerMM
                End Get
                Set(ByVal value As System.Decimal)
                    _BALSection4PowerMM = value
                End Set
            End Property
#End Region
#Region "APL2ThickMM 屬性:APL2ThickMM"
            Private _APL2ThickMM As System.Decimal
            ''' <summary>
            ''' APL2ThickMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property APL2ThickMM() As System.Decimal
                Get
                    Return _APL2ThickMM
                End Get
                Set(ByVal value As System.Decimal)
                    _APL2ThickMM = value
                End Set
            End Property
#End Region
#Region "APL2BATestHeadMM 屬性:APL2BATestHeadMM"
            Private _APL2BATestHeadMM As System.Decimal
            ''' <summary>
            ''' APL2BATestHeadMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property APL2BATestHeadMM() As System.Decimal
                Get
                    Return _APL2BATestHeadMM
                End Get
                Set(ByVal value As System.Decimal)
                    _APL2BATestHeadMM = value
                End Set
            End Property
#End Region
#Region "APL2BATestTailMM 屬性:APL2BATestTailMM"
            Private _APL2BATestTailMM As System.Decimal
            ''' <summary>
            ''' APL2BATestTailMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property APL2BATestTailMM() As System.Decimal
                Get
                    Return _APL2BATestTailMM
                End Get
                Set(ByVal value As System.Decimal)
                    _APL2BATestTailMM = value
                End Set
            End Property
#End Region
#Region "APL2IsExportPackage 屬性:APL2IsExportPackage"
            Private _APL2IsExportPackage As System.Decimal
            ''' <summary>
            ''' BALIsExpAPL2IsExportPackageortPackage
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property APL2IsExportPackage() As System.Decimal
                Get
                    Return _APL2IsExportPackage
                End Get
                Set(ByVal value As System.Decimal)
                    _APL2IsExportPackage = value
                End Set
            End Property
#End Region
#Region "APL1IsExportPackage 屬性:APL1IsExportPackage"
            Private _APL1IsExportPackage As System.Decimal
            ''' <summary>
            ''' APL1IsExportPackage
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property APL1IsExportPackage() As System.Decimal
                Get
                    Return _APL1IsExportPackage
                End Get
                Set(ByVal value As System.Decimal)
                    _APL1IsExportPackage = value
                End Set
            End Property
#End Region
#Region "APL1IsNo1GetTest 屬性:APL1IsNo1GetTest"
            Private _APL1IsNo1GetTest As System.Decimal
            ''' <summary>
            ''' APL1IsNo1GetTest
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property APL1IsNo1GetTest() As System.Decimal
                Get
                    Return _APL1IsNo1GetTest
                End Get
                Set(ByVal value As System.Decimal)
                    _APL1IsNo1GetTest = value
                End Set
            End Property
#End Region
#Region "APL1No1TestThickMM 屬性:APL1No1TestThickMM"
            Private _APL1No1TestThickMM As System.Decimal
            ''' <summary>
            ''' APL1No1TestThickMM
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property APL1No1TestThickMM() As System.Decimal
                Get
                    Return _APL1No1TestThickMM
                End Get
                Set(ByVal value As System.Decimal)
                    _APL1No1TestThickMM = value
                End Set
            End Property
#End Region
#Region "APL1IsUseDestory 屬性:APL1IsUseDestory"
            Private _APL1IsUseDestory As System.Decimal
            ''' <summary>
            ''' APL1IsUseDestory
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property APL1IsUseDestory() As System.Decimal
                Get
                    Return _APL1IsUseDestory
                End Get
                Set(ByVal value As System.Decimal)
                    _APL1IsUseDestory = value
                End Set
            End Property
#End Region
#Region "APL1No1Form 屬性:APL1No1Form"
            Private _APL1No1Form As System.Decimal
            ''' <summary>
            ''' APL1No1Form
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property APL1No1Form() As System.Decimal
                Get
                    Return _APL1No1Form
                End Get
                Set(ByVal value As System.Decimal)
                    _APL1No1Form = value
                End Set
            End Property
#End Region
#Region "CoilMaxLength 屬性:CoilMaxLength"
            Private _CoilMaxLength As System.Decimal
            ''' <summary>
            ''' CoilMaxLength
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CoilMaxLength() As System.Decimal
                Get
                    Return _CoilMaxLength
                End Get
                Set(ByVal value As System.Decimal)
                    _CoilMaxLength = value
                End Set
            End Property
#End Region
#Region "鋼捲全長加導片長 屬性:CoilMaxAddJointLength"
            ''' <summary>
            ''' 鋼捲全長加導片長
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property CoilMaxAddJointLength As Long
#End Region
#Region "鋼捲位置調整誤值 屬性:CoilPositionErrLength"
            ''' <summary>
            ''' 鋼捲位置調整誤值
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property CoilPositionErrLength As Long
#End Region
#Region "鋼捲起始時間 屬性:CoilStartTime"
            ''' <summary>
            ''' 鋼捲起始時間
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property CoilStartTime As DateTime
#End Region
#Region "鋼捲終止時間 屬性:CoilEndTime"
            ''' <summary>
            ''' 鋼捲終止時間
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property CoilEndTime As DateTime
#End Region
#Region "是否已由L2更新此筆資料 屬性:IsUpdateFromL2Value"
            ''' <summary>
            ''' 是否已由L2更新此筆資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property IsUpdateFromL2Value As Boolean
#End Region

        End Class
    End Namespace
End Namespace