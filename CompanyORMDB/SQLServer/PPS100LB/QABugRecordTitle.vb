Namespace SQLServer
    Namespace PPS100LB
        ''' <summary>
        ''' 鋼捲缺陷其它資料
        ''' </summary>
        ''' <remarks></remarks>
        Public Class QABugRecordTitle
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                Me.CoilMaxLength = 9999
                Me.CoilMaxAddJointLength = 9999
                Me.CoilPositionErrLength = -2
                Me.CoilStartTime = Now
                Me.CoilEndTime = Me.CoilStartTime
                Me.ConvertToAS400Time = New DateTime(2000, 1, 1)
                Me.HandOverTime = New DateTime(2000, 1, 1)
                Me.JointLength = 0
                Me.APL1IsUseDestory = 1
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
#Region "輸出鋼捲編號 屬性:OutCoilNumber"
            Private _OutCoilNumber As String
            ''' <summary>
            ''' 輸出鋼捲編號
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property OutCoilNumber() As String
                Get
                    Return _OutCoilNumber
                End Get
                Set(ByVal value As String)
                    _OutCoilNumber = value
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
#Region "BALSection1PositionMM 屬性:BALSection1PositionMM"
            Private _BALSection1PositionMM As Long
            Public Property BALSection1PositionMM() As Long
                Get
                    Return _BALSection1PositionMM
                End Get
                Set(ByVal value As Long)
                    _BALSection1PositionMM = value
                End Set
            End Property
#End Region
#Region "BALSection2PositionMM 屬性:BALSection2PositionMM"
            Private _BALSection2PositionMM As Long
            Public Property BALSection2PositionMM() As Long
                Get
                    Return _BALSection2PositionMM
                End Get
                Set(ByVal value As Long)
                    _BALSection2PositionMM = value
                End Set
            End Property

#End Region
#Region "BALSection3PositionMM 屬性:BALSection3PositionMM"
            Private _BALSection3PositionMM As Long
            Public Property BALSection3PositionMM() As Long
                Get
                    Return _BALSection3PositionMM
                End Get
                Set(ByVal value As Long)
                    _BALSection3PositionMM = value
                End Set
            End Property

#End Region
#Region "BALSection4PositionMM 屬性:BALSection4PositionMM"
            Private _BALSection4PositionMM As Long
            Public Property BALSection4PositionMM() As Long
                Get
                    Return _BALSection4PositionMM
                End Get
                Set(ByVal value As Long)
                    _BALSection4PositionMM = value
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
#Region "最後編修員工編號 屬性:LastEditEmployeeID"
            Property LastEditEmployeeID As String
#End Region
#Region "計劃分捲重量 屬性:PlanCutCoilWeight"
            Private _PlanCutCoilWeight As Long
            ''' <summary>
            ''' 計劃分捲重量
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property PlanCutCoilWeight() As Long
                Get
                    Return _PlanCutCoilWeight
                End Get
                Set(ByVal value As Long)
                    _PlanCutCoilWeight = value
                End Set
            End Property

#End Region
#Region "鋼捲收捲型態 屬性:CoilReceiveType"
            ''' <summary>
            ''' 鋼捲收捲型態(1上收0下收)
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property CoilReceiveType As Integer
#End Region
#Region "轉檔至AS400之時間 屬性:ConvertToAS400Time"
            ''' <summary>
            ''' 轉檔至AS400之時間
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property ConvertToAS400Time As DateTime
#End Region
#Region "是否列入交接 屬性:IsWillHandOver"
            ''' <summary>
            ''' 是否列入交接
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property IsWillHandOver As Boolean
#End Region
#Region "交接工號 屬性:HandOverBeforeeEmpID"
            ''' <summary>
            ''' 交接工號
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property HandOverBeforeeEmpID As String
#End Region
#Region "交接鋼捲長度 屬性HandOverLength"
            ''' <summary>
            ''' 交接鋼捲長度
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property HandOverLength As Long
#End Region
#Region "交接時間 屬性:HandOverTime"
            ''' <summary>
            ''' 交接時間
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property HandOverTime As DateTime
#End Region
#Region "導片長度 屬性:JointLength"
            ''' <summary>
            ''' 導片長度
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Property JointLength As Long
#End Region

#Region "公稱厚度 屬性:PublicThickAndSubThick"
            ''' <summary>
            ''' 公稱厚度
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property PublicThickAndSubThick As String
                Get

                    Dim AllPPSSHAPF As List(Of CompanyORMDB.PPS100LB.PPSSHAPF) = Me.AboutAS400PPSSHAPF
                    Dim SortedAllPPSSHAPF As New SortedDictionary(Of Integer, IPPS100LB.IPPSSHAPF)
                    For Each EachItem As IPPS100LB.IPPSSHAPF In AllPPSSHAPF
                        SortedAllPPSSHAPF.Add(-EachItem.SHA04, EachItem)
                    Next
                    If AllPPSSHAPF.Count > 0 Then
                        For Each EachItem As IPPS100LB.IPPSSHAPF In SortedAllPPSSHAPF.Values
                            If EachItem.SHA14 > 0 Then
                                Return EachItem.SHA14
                            End If
                        Next
                    End If

                    Dim AverageThick As Single = 0
                    Dim AverageThickCount As Integer = 0
                    Dim AllThckness As List(Of QAThickness) = AboutQAThickness
                    If AllThckness.Count > 0 Then
                        Dim SumVlaue As Double = 0
                        For Each EachItem As QAThickness In AllThckness
                            If EachItem.Thick > 0 Then
                                AverageThickCount += 1
                                SumVlaue += EachItem.Thick
                            End If
                            If EachItem.Thick60 > 0 Then
                                AverageThickCount += 1
                                SumVlaue += EachItem.Thick60
                            End If
                        Next
                        AverageThick = SumVlaue / AverageThickCount
                    Else
                        Return 0
                    End If

                    Dim ReturnValue As String = Format(AverageThick, "0.00")
                    If AverageThick > 0 Then    '轉換實際厚度為公稱厚度
                        Dim QryString As New System.Text.StringBuilder
                        QryString.Append("Select * from @#sls300lb.sl2ch7pf where 1=1 ")
                        If Me.StationName = "APL1" Then
                            QryString.Append(" and (ch70a='A' or ch70a='B') ")
                        Else
                            QryString.Append(" and ch70a='B' ")
                        End If
                        QryString.Append(" and ch704 <= " & Format("{0:0.00}", AverageThick))
                        QryString.Append(" and ch705 >= " & Format("{0:0.00}", AverageThick))
                        Dim SearchResult As List(Of CompanyORMDB.SLS300LB.SL2CH7PF) = CompanyORMDB.SLS300LB.SL2CH7PF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2CH7PF)(QryString.ToString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                        If SearchResult.Count > 0 Then
                            Dim CH702Value As String = SearchResult(0).CH702.Trim.PadRight(4)
                            ReturnValue = CH702Value.Substring(0, 2) & "." & CH702Value.Substring(2, 2)
                            If Not String.IsNullOrEmpty(SearchResult(0).CH703) AndAlso SearchResult(0).CH703.Trim.Length > 0 Then
                                ReturnValue &= "-" & SearchResult(0).CH703.Trim
                            End If
                        End If
                    End If
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "鋼捲收捲型態名稱 屬性:CoilReceiveTypeName"
            ''' <summary>
            ''' 鋼捲收捲型態名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property CoilReceiveTypeName As String
                Get
                    Select Case True
                        Case CoilReceiveType = 0
                            Return "下收"
                        Case CoilReceiveType = 2
                            Return "上收"
                    End Select
                    Return "未知"
                End Get
            End Property

#End Region

#Region "是否已經過CPL站 屬性:IsOverCPLStation"
            Private _IsOverCPLStation As Nullable(Of Boolean) = Nothing
            ''' <summary>
            ''' 是否已經過CPL站
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property IsOverCPLStation As Boolean
                Get
                    If IsNothing(_IsOverCPLStation) Then
                        Dim GetAboutPPSSHAPFs As List(Of CompanyORMDB.PPS100LB.PPSSHAPF) = Me.AboutAS400PPSSHAPF
                        If GetAboutPPSSHAPFs.Count = 0 Then
                            _IsOverCPLStation = False
                        Else
                            For Each EachItem In GetAboutPPSSHAPFs
                                If EachItem.SHA08.PadRight(2).Substring(0, 1).ToUpper = "CP" Then
                                    _IsOverCPLStation = True : Exit For
                                End If
                            Next
                        End If
                    End If
                    Return _IsOverCPLStation.Value
                End Get
            End Property
#End Region

#Region "儲存陷缺資料至AS400 方法:SaveDataToAS400"
            ''' <summary>
            ''' 儲存陷缺資料至
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function SaveBugDataToAS400() As Integer
                Dim DateConvert As New CompanyORMDB.AS400DateConverter
                Dim AS400Adapter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                Dim QryString As Text.StringBuilder = New Text.StringBuilder
                QryString.Append("Select * from @#PPS100LB.PPSQDSPF Where 1=1 ")
                QryString.Append(" AND RTRIM(QDS01)='" & Me.StationName.Trim & "'")
                QryString.Append(" AND RTRIM(QDS02 || QDS03)='" & Me.OutCoilNumber.Trim & "'")
                QryString.Append(" AND RTRIM(QDS04)=" & New CompanyORMDB.AS400DateConverter(Me.DataDate).TwIntegerTypeData)

                Dim SearchResult As List(Of CompanyORMDB.PPS100LB.PPSQDSPF) = CompanyORMDB.PPS100LB.PPSQDSPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSQDSPF)(QryString.ToString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                Select Case True
                    Case SearchResult.Count > 1
                        Throw New Exception("查詢資料有誤出現多筆 PPS100LB.PPSQDSPF 無法做資料更新!")
                    Case SearchResult.Count = 1
                        If SearchResult(0).CDBDelete() > 0 Then
                            QryString = New Text.StringBuilder
                            QryString.Append("Delete from @#PPS100LB.PPSQDEPF Where 1=1 ")
                            QryString.Append(" and RTRIM(QDE01)=" & Me.StationName.Trim)
                            QryString.Append(" AND RTRIM(QDE02 || QDE03)=" & Me.OutCoilNumber.Trim)
                            QryString.Append(" AND RTRIM(QDS04)=" & New CompanyORMDB.AS400DateConverter(Me.DataDate).TwIntegerTypeData)  ''刪除當日缺陷資料
                            AS400Adapter.ExecuteNonQuery(QryString.ToString)
                        End If
                End Select
                Dim TitleData As New CompanyORMDB.PPS100LB.PPSQDSPF
                TitleData.SQLQueryAdapterByThisObject = AS400Adapter
                With TitleData
                    Select Case True
                        Case Me.StationName.Trim = "APL1"
                            .QDS01 = "AP1H"
                        Case Me.StationName.Trim = "APL2"
                            .QDS01 = "AP2C"
                        Case Me.StationName.Trim = "BAL"
                            .QDS01 = "BALC"
                    End Select
                    .QDS02 = Me.OutCoilNumber.PadRight(5).Substring(0, 5)
                    .QDS03 = Me.OutCoilNumber.PadRight(10).Substring(5, 5)
                    .QDS04 = New CompanyORMDB.AS400DateConverter(Me.DataDate.Date).TwIntegerTypeData
                    Select Case True
                        Case Me.StationName = "APL1"
                            .QDS05 = "NO1"
                        Case Me.StationName = "APL2"
                            .QDS05 = "2D"
                        Case Me.StationName = "BAL"
                            .QDS05 = "BAL"
                    End Select
                    If Not IsNothing(Me.LastEditEmployeeID) Then
                        .QDS07 = Me.LastEditEmployeeID.Trim
                    End If
                    '厚度轉換
                    Dim AboutThicks As List(Of QAThickness) = Me.AboutQAThickness
                    If Not IsNothing(AboutThicks) Then
                        Dim FieldThickIndex As Integer = 9
                        Dim FieldWidthIndex As Integer = 10
                        Dim FieldLengthIndex As Integer = 11
                        For Each EachItem As QAThickness In AboutThicks
                            ''當狀態為 1(完成) . 2(編修中)時，才可寫入AS400
                            If EachItem.RecordState <> "3" Then
                                Select Case True
                                    Case EachItem.Thick60 > 0
                                        .CDBSetFieldValue(IIf(FieldThickIndex < 10, "QDS0", "QDS") & FieldThickIndex, EachItem.Thick60)
                                    Case EachItem.Thick > 0
                                        .CDBSetFieldValue(IIf(FieldThickIndex < 10, "QDS0", "QDS") & FieldThickIndex, EachItem.Thick)
                                    Case Else
                                        .CDBSetFieldValue(IIf(FieldThickIndex < 10, "QDS0", "QDS") & FieldThickIndex, 0)
                                End Select


                                .CDBSetFieldValue("QDS" & FieldWidthIndex, EachItem.Width)
                                .CDBSetFieldValue("QDS" & FieldLengthIndex, EachItem.Length)

                                ''1060607
                                ''當狀態不為3(刪除)時，寫入資料後將Index往下指(每3格為一單位)
                                FieldThickIndex += 3
                                FieldWidthIndex += 3
                                FieldLengthIndex += 3
                            End If

                            'FieldThickIndex += IIf(EachItem.RecordState <> "3", 3, 0)
                            'FieldWidthIndex += IIf(EachItem.RecordState <> "3", 3, 0)
                            'FieldLengthIndex += IIf(EachItem.RecordState <> "3", 3, 0)

                            If FieldThickIndex > 24 Then
                                Exit For
                            End If
                        Next
                    End If
                    '亮度轉換
                    Dim BALLightValues As New List(Of Integer)
                    For EachFieldNumber As Integer = 1 To 6
                        Dim GetValue As Integer = CType(Me.CDBGetFieldValue("BALPBrightCenterMM" & EachFieldNumber), Single)
                        If GetValue > 0 AndAlso BALLightValues.Count <= 8 Then
                            BALLightValues.Add(GetValue)
                        End If
                    Next
                    For EachFieldNumber As Integer = 1 To 6
                        Dim GetValue As Integer = CType(Me.CDBGetFieldValue("BALPBrightSideMM" & EachFieldNumber), Single)
                        If GetValue > 0 AndAlso BALLightValues.Count <= 8 Then
                            BALLightValues.Add(GetValue)
                        End If
                    Next
                    If BALLightValues.Count > 0 Then
                        BALLightValues.Sort()
                        Dim TotalValue As Long = 0
                        For EachFieldNumber As Integer = 1 To BALLightValues.Count
                            .CDBSetFieldValue("QDS4" & EachFieldNumber, BALLightValues(EachFieldNumber - 1))
                            TotalValue += BALLightValues(EachFieldNumber - 1)

                        Next
                        .QDS49 = TotalValue / BALLightValues.Count
                        ''1060922 ADD
                        ''QDS50 長度為 4，不明原因再存入AS400會發生錯誤，因此再存入時做判斷
                        ''.QDS50 = BALLightValues(BALLightValues.Count - 1) - BALLightValues(0)
                        Dim tempBALDiff_Value = BALLightValues(BALLightValues.Count - 1) - BALLightValues(0)
                        If tempBALDiff_Value > 9998 Then
                            .QDS50 = 9999
                        Else
                            .QDS50 = BALLightValues(BALLightValues.Count - 1) - BALLightValues(0)
                        End If
                    End If
                End With
                '缺陷轉換
                Dim AboutBugs As List(Of QABugRecord) = AboutQABugRecords
                Dim SecondInputEmployeeID As String = Nothing
                Dim MaxCoilLength As Long = IIf(Me.CoilMaxLength > 9999, 9999, Me.CoilMaxLength)
                If TitleData.CDBSave > 0 AndAlso Not IsNothing(AboutBugs) Then
                    Me.ConvertToAS400Time = Now : Me.CDBSave()  '儲存資料轉換AS400之時
                    Dim DetailData As CompanyORMDB.PPS100LB.PPSQDEPF
                    Dim BugHappenTimes As New Dictionary(Of Integer, Integer)
                    For Each EachBug As QABugRecord In AboutBugs
                        If Val(EachBug.QABug_Number) = 0 Then   '交接班訊號
                            Continue For
                        End If
                        DetailData = New CompanyORMDB.PPS100LB.PPSQDEPF
                        DetailData.SQLQueryAdapterByThisObject = AS400Adapter
                        With DetailData
                            .QDE01 = TitleData.QDS01
                            .QDE02 = TitleData.QDS02
                            .QDE03 = TitleData.QDS03
                            .QDE04 = TitleData.QDS04
                            .QDE05 = EachBug.QABug_Number
                            If BugHappenTimes.ContainsKey(.QDE05) Then
                                Dim OldValue As Integer = BugHappenTimes.Item(.QDE05)
                                BugHappenTimes.Remove(.QDE05)
                                BugHappenTimes.Add(.QDE05, OldValue + 1)
                            Else
                                BugHappenTimes.Add(.QDE05, 1)
                            End If
                            .QDE06 = BugHappenTimes.Item(.QDE05)
                            .QDE07 = EachBug.StartPosition
                            .QDE08 = IIf(EachBug.EndPosition > MaxCoilLength, MaxCoilLength, EachBug.EndPosition)
                            .QDE08 = IIf(.QDE08 >= 9999, -1, .QDE08)
                            Select Case EachBug.DPositionType
                                Case 1
                                    .QDE09 = 1
                                Case 2
                                    .QDE09 = 3
                                Case 3
                                    .QDE09 = 0
                                Case 4
                                    .QDE09 = 4
                                Case 5
                                    .QDE09 = ""
                                Case Else
                                    .QDE09 = ""
                            End Select

                            .QDE10 = EachBug.DPositionStart
                            .QDE11 = EachBug.DPositionEnd
                            .QDE11 = IIf(.QDE11 >= 9999, -1, .QDE11)
                            .QDE12 = EachBug.PosOrNeg
                            .QDE13 = EachBug.Degree
                            .QDE14 = EachBug.Density
                            .QDE15 = EachBug.Cycle
                            .QDE17 = EachBug.SynthesesDegree
                            If Not IsNothing(EachBug.EditEmployeeID) AndAlso Not IsNothing(TitleData.QDS07) _
                                AndAlso EachBug.EditEmployeeID.Trim.Length > 0 AndAlso TitleData.QDS07.Trim.Length > 0 _
                                AndAlso EachBug.EditEmployeeID.Trim <> TitleData.QDS07 _
                                AndAlso IsNothing(SecondInputEmployeeID) Then
                                SecondInputEmployeeID = EachBug.EditEmployeeID.Trim
                                TitleData.QDS07 = SecondInputEmployeeID
                                TitleData.CDBSave()
                            End If
                        End With
                        DetailData.CDBSave()
                    Next
                    Return 1
                End If
                Return 0
            End Function
#End Region




#Region "相關厚度資料 屬性:AboutQAThickness"
            ''' <summary>
            ''' 相關厚度資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutQAThickness As List(Of QAThickness)
                Get
                    If String.IsNullOrEmpty(Me.CoilNumber) OrElse Me.CoilNumber.Trim.Length = 0 OrElse _
                        String.IsNullOrEmpty(Me.DataDate) OrElse _
                        String.IsNullOrEmpty(Me.StationName) OrElse Me.StationName.Trim.Length = 0 OrElse _
                        String.IsNullOrEmpty(Me.Version) OrElse Me.Version.Trim.Length = 0 OrElse _
                        String.IsNullOrEmpty(Me.OutCoilNumber) OrElse Me.OutCoilNumber.Trim.Length = 0 Then
                        Return Nothing
                    End If
                    Dim QryString As New System.Text.StringBuilder
                    QryString.Append("Select * from QAThickness where 1=1 ")
                    QryString.Append(" and CoilNumber='" & Me.CoilNumber.Trim & "' ")
                    QryString.Append(" and DataDate='" & Format(Me.DataDate, "yyyy/MM/dd") & "' ")
                    QryString.Append(" and StationName='" & Me.StationName.Trim & "' ")
                    QryString.Append(" and Version='" & Me.Version.Trim & "' ")
                    QryString.Append(" and OutCoilNumber='" & Me.OutCoilNumber.Trim & "' ")
                    Dim Searchresult As List(Of CompanyORMDB.SQLServer.PPS100LB.QAThickness) = CompanyORMDB.SQLServer.PPS100LB.QAThickness.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.QAThickness)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString.ToString)
                    Return Searchresult
                End Get
            End Property
#End Region
#Region "相關AS400排程資料 屬性:AboutAS400PPSSHAPF"
            ''' <summary>
            ''' 相關AS400排程資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutAS400PPSSHAPF As List(Of CompanyORMDB.PPS100LB.PPSSHAPF)
                Get
                    Dim QryString As New System.Text.StringBuilder
                    QryString.Append("Select * from @#PPS100LB.PPSSHAPF where 1=1 ")
                    QryString.Append(" and RTRIM(SHA01 || SHA02) ='" & Me.CoilNumber.Trim & "' ")
                    QryString.Append(" order by sha04")
                    Dim Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString.ToString)
                    Dim SearchResult As List(Of CompanyORMDB.PPS100LB.PPSSHAPF) = CompanyORMDB.PPS100LB.PPSSHAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSSHAPF)(QryString.ToString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    Return SearchResult
                End Get
            End Property
#End Region
#Region "相關黑皮鋼捲資料 屬性:屬性:AboutPPSBLAPF"
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public ReadOnly Property AboutPPSBLAPF As CompanyORMDB.PPS100LB.PPSBLAPF
                Get
                    If String.IsNullOrEmpty(Me.CoilNumber) OrElse Me.CoilNumber.Trim.Length = 0 OrElse String.IsNullOrEmpty(Me.StationName) OrElse Me.StationName.Trim.Length = 0 Then
                        Return Nothing
                    End If
                    Dim SetString As New System.Text.StringBuilder
                    Dim QryCoilNumber As String = Me.CoilNumber.Trim
                    If QryCoilNumber.Length > 5 Then
                        QryCoilNumber = QryCoilNumber.Substring(0, QryCoilNumber.Length - 1)
                    End If

                    Dim QryString As String = "Select * from RunProcessData Where (FK_LastRefSHA01 + FK_LastRefSHA02) like '" & QryCoilNumber & "%' and sysCoilEndTime < '" & Format(Now, "yyyy/MM/dd HH:mm:ss") & "' and  FK_RunStationName <> '" & Me.StationName & "' and (ThisRecordState=2 or ThisRecordState=3) order by sysCoilEndTime desc"
                    Dim SearchResult As List(Of CompanyORMDB.SQLServer.PPS100LB.RunProcessData) = RunProcessData.CDBSelect(Of RunProcessData)(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                    Dim FindRunProcessData As CompanyORMDB.SQLServer.PPS100LB.RunProcessData = Nothing
                    Dim myAboutPPSBLAPF As CompanyORMDB.PPS100LB.PPSBLAPF = Nothing
                    If SearchResult.Count > 0 Then
                        FindRunProcessData = SearchResult(0)
                        myAboutPPSBLAPF = FindRunProcessData.AboutPPSBLAPF
                    End If

                    If IsNothing(myAboutPPSBLAPF) Then
                        QryString = "Select A.* , B.SHA01,B.SHA02,B.SHA04,B.SHA12,B.SHA13,B.SHA17 From @#PPS100LB.PPSBLAPF A LEFT JOIN @#PPS100LB.PPSSHAPF B ON A.BLA09=B.SHA01 WHERE SHA01 || SHA02 LIKE '" & QryCoilNumber & "%' and sha11 <= '" & (New CompanyORMDB.AS400DateConverter(Now)).TwIntegerTypeData & "' Order by SHA04 desc ,SHA02 asc"
                        Dim Adapter As New CompanyORMDB.AS400SQLQueryAdapter(CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryString)
                        Dim SearchResult1 As DataTable = Adapter.SelectQuery(QryString)
                        If SearchResult1.Rows.Count > 0 Then
                            myAboutPPSBLAPF = New CompanyORMDB.PPS100LB.PPSBLAPF()
                            myAboutPPSBLAPF.CDBSetDataRowValueToObject(SearchResult1.Rows(0))
                        End If
                    End If

                    Return myAboutPPSBLAPF
                End Get
            End Property
#End Region
#Region "計劃分捲長 屬性:PlanCutCoilLength"
            ''' <summary>
            ''' 計劃分捲長(重/厚/寛/密度=長度)
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property PlanCutCoilLength As Long
                Get
                    If PlanCutCoilWeight <= 0 Then
                        Return 0
                    End If
                    Static GetAboutPPSBLAPF As CompanyORMDB.PPS100LB.PPSBLAPF
                    If IsNothing(GetAboutPPSBLAPF) Then
                        GetAboutPPSBLAPF = Me.AboutPPSBLAPF
                    End If
                    If IsNothing(GetAboutPPSBLAPF) OrElse GetAboutPPSBLAPF.BLA03 = 0 OrElse GetAboutPPSBLAPF.BLA04 = 0 Then
                        Return 0
                    End If
                    Return PlanCutCoilWeight / GetAboutPPSBLAPF.BLA03 / (GetAboutPPSBLAPF.BLA04 / 1000) / 7.93
                End Get
            End Property
#End Region

#Region "相關缺陷資料 屬性:AboutQABugRecords"
            ''' <summary>
            ''' 相關缺陷資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutQABugRecords As List(Of QABugRecord)
                Get
                    If String.IsNullOrEmpty(Me.CoilNumber) OrElse Me.CoilNumber.Trim.Length = 0 OrElse _
                        String.IsNullOrEmpty(Me.DataDate) OrElse _
                        String.IsNullOrEmpty(Me.StationName) OrElse Me.StationName.Trim.Length = 0 OrElse _
                        String.IsNullOrEmpty(Me.Version) OrElse Me.Version.Trim.Length = 0 OrElse _
                        String.IsNullOrEmpty(Me.OutCoilNumber) OrElse Me.OutCoilNumber.Trim.Length = 0 Then
                        Return Nothing
                    End If
                    Dim QryString As New System.Text.StringBuilder
                    QryString.Append("Select * from QABugRecord where 1=1 ")
                    QryString.Append(" and CoilNumber='" & Me.CoilNumber.Trim & "' ")
                    QryString.Append(" and DataDate='" & Format(Me.DataDate, "yyyy/MM/dd") & "' ")
                    QryString.Append(" and StationName='" & Me.StationName.Trim & "' ")
                    QryString.Append(" and Version='" & Me.Version.Trim & "' ")
                    QryString.Append(" and OutCoilNumber='" & Me.OutCoilNumber.Trim & "' ")
                    QryString.Append(" and RecordState <> 3 ")  '排除已刪除資料
                    Dim Searchresult As List(Of CompanyORMDB.SQLServer.PPS100LB.QABugRecord) = CompanyORMDB.SQLServer.PPS100LB.QAThickness.CDBSelect(Of CompanyORMDB.SQLServer.PPS100LB.QABugRecord)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString.ToString)
                    Return Searchresult
                End Get
            End Property
#End Region

        End Class
    End Namespace
End Namespace