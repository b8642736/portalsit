Namespace SQLServer
    Namespace PPS100LB
        Public Class RunProcessData
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                Me.SysCoilStartTime = Now
                Me.SysCoilEndTime = Me.SysCoilStartTime
                Me.CoilStartTime = Me.SysCoilStartTime
                Me.CoilEndTime = Me.SysCoilStartTime
                Me.Guage = 0
                Me.Width = 0
                Me.Length = 0
                Me.Weight = 0
                Me.ReturnWeight = 0
                Me.ScaleWeight = 0
                Me.OtherWeight = 0
                Me.DataCreateTime = New DateTime(2000, 1, 1)
                Me.ThisRecordState = 1
                Me.FirstsysCoilStartTime = Me.SysCoilStartTime
                Me.RunPassCont = 1
                Me.UserRunningDataCheckedTime = New DateTime(2000, 1, 1)
            End Sub

            Sub New(ByVal SetLastRefPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF)
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                If IsNothing(SetLastRefPPSSHAPF) Then
                    Throw New Exception("RunProcessData類別中 建構函式設定SetLastRefPPSSHAPF  不可為Nothing")
                End If
                Me.SysCoilStartTime = Now
                Me.SysCoilEndTime = Me.SysCoilStartTime
                Me.CoilStartTime = Me.SysCoilStartTime
                Me.CoilEndTime = Me.SysCoilStartTime
                Me.Guage = 0
                Me.Width = 0
                Me.Length = 0
                Me.Weight = 0
                Me.ReturnWeight = 0
                Me.ScaleWeight = 0
                Me.OtherWeight = 0
                Me.AboutLastRefPPSSHAPF = SetLastRefPPSSHAPF
                Me.DataCreateTime = New DateTime(2000, 1, 1)
                Me.ThisRecordState = 1
                Me.FirstsysCoilStartTime = Me.SysCoilStartTime
                Me.RunPassCont = 1
                Me.UserRunningDataCheckedTime = New DateTime(2000, 1, 1)
            End Sub

#Region "ID 屬性:ID"
            Private _ID As System.String
            ''' <summary>
            ''' ID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property ID() As System.String
                Get
                    If String.IsNullOrEmpty(_ID) Then
                        _ID = Guid.NewGuid.ToString
                    End If
                    Return _ID
                End Get
                Set(ByVal value As System.String)
                    _ID = value
                End Set
            End Property
#End Region
#Region "資料轉換輸出SHA01 屬性:FK_OutSHA01"
            Private _FK_OutSHA01 As System.String
            ''' <summary>
            ''' 資料轉換輸出SHA01
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_OutSHA01() As System.String
                Get
                    Return _FK_OutSHA01
                End Get
                Set(ByVal value As System.String)
                    _FK_OutSHA01 = value
                    AboutPPSBLAPF = Nothing
                    AboutPPSBLAPF_BLA01 = String.Empty
                    AboutPPSBLAPF_BLA02 = String.Empty
                    HeadTailDescript = String.Empty

                End Set
            End Property
#End Region
#Region "資料轉換輸出SHA02 屬性:FK_OutSHA02"
            Private _FK_OutSHA02 As System.String
            ''' <summary>
            ''' 資料轉換輸出SHA02
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_OutSHA02() As System.String
                Get
                    Return _FK_OutSHA02
                End Get
                Set(ByVal value As System.String)
                    _FK_OutSHA02 = value
                End Set
            End Property
#End Region
#Region "資料轉換輸出SHA04 屬性:FK_OutSHA04"
            Private _FK_OutSHA04 As System.Int32
            ''' <summary>
            ''' 資料轉換輸出SHA04
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_OutSHA04() As System.Int32
                Get
                    Return _FK_OutSHA04
                End Get
                Set(ByVal value As System.Int32)
                    _FK_OutSHA04 = value
                End Set
            End Property
#End Region
#Region "建立此筆資料參考SHA01 屬性:FK_LastRefSHA01"
            Private _FK_LastRefSHA01 As System.String
            ''' <summary>
            ''' 建立此筆資料參考SHA01
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_LastRefSHA01() As System.String
                Get
                    Return _FK_LastRefSHA01
                End Get
                Set(ByVal value As System.String)
                    _FK_LastRefSHA01 = value
                End Set
            End Property
#End Region
#Region "建立此筆資料參考SHA02 屬性:FK_LastRefSHA02"
            Private _FK_LastRefSHA02 As System.String
            ''' <summary>
            ''' 建立此筆資料參考SHA02
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_LastRefSHA02() As System.String
                Get
                    Return _FK_LastRefSHA02
                End Get
                Set(ByVal value As System.String)
                    _FK_LastRefSHA02 = value
                End Set
            End Property
#End Region
#Region "建立此筆資料參考SHA04 屬性:FK_LastRefSHA04"
            Private _FK_LastRefSHA04 As System.Int32
            ''' <summary>
            ''' 建立此筆資料參考SHA04
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_LastRefSHA04() As System.Int32
                Get
                    Return _FK_LastRefSHA04
                End Get
                Set(ByVal value As System.Int32)
                    _FK_LastRefSHA04 = value
                End Set
            End Property
#End Region
#Region "建立此筆資料參考SchedualID 屬性:FK_RunProcessSchedualID"
            Private _FK_RunProcessSchedualID As System.String
            ''' <summary>
            ''' 建立此筆資料參考SchedualID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_RunProcessSchedualID() As System.String
                Get
                    Return _FK_RunProcessSchedualID
                End Get
                Set(ByVal value As System.String)
                    _FK_RunProcessSchedualID = value
                End Set
            End Property
#End Region
#Region "建立此筆資料參考站台名稱(現場執行的站台名稱) 屬性:FK_RunStationName"
            Private _FK_RunStationName As System.String
            ''' <summary>
            ''' 建立此筆資料參考站台名稱(現場執行的站台名稱)
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_RunStationName() As System.String
                Get
                    Return _FK_RunStationName
                End Get
                Set(ByVal value As System.String)
                    _FK_RunStationName = value
                End Set
            End Property
#End Region
#Region "分捲編號 屬性:BreakCoilNumber"
            Private _BreakCoilNumber As System.Int32 = -1
            ''' <summary>
            ''' 分捲編號(作為輸出PPSSHA參考用途)
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property BreakCoilNumber() As System.Int32
                Get
                    Return _BreakCoilNumber
                End Get
                Set(ByVal value As System.Int32)
                    _BreakCoilNumber = value
                End Set
            End Property
#End Region
#Region "建立此筆資料之電腦IP 屬性:RunStationPCIP"
            Private _RunStationPCIP As System.String
            ''' <summary>
            ''' 建立此筆資料之電腦IP
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RunStationPCIP() As System.String
                Get
                    Return _RunStationPCIP
                End Get
                Set(ByVal value As System.String)
                    _RunStationPCIP = value
                End Set
            End Property
#End Region
#Region "鋼捲作業起始系統記錄時間 屬性:SysCoilStartTime"
            Private _SysCoilStartTime As System.DateTime
            ''' <summary>
            ''' 鋼捲作業起始系統記錄時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SysCoilStartTime() As System.DateTime
                Get
                    Return _SysCoilStartTime
                End Get
                Set(ByVal value As System.DateTime)
                    _SysCoilStartTime = value
                End Set
            End Property
#End Region
#Region "鋼捲作業終止系統記錄時間 屬性:SysCoilEndTime"
            Private _SysCoilEndTime As System.DateTime
            ''' <summary>
            ''' 鋼捲作業終止系統記錄時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property SysCoilEndTime() As System.DateTime
                Get
                    Return _SysCoilEndTime
                End Get
                Set(ByVal value As System.DateTime)
                    _SysCoilEndTime = value
                End Set
            End Property
#End Region
#Region "鋼捲作業起始時間 屬性:CoilStartTime"
            Private _CoilStartTime As System.DateTime
            ''' <summary>
            ''' 鋼捲作業起始時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CoilStartTime() As System.DateTime
                Get
                    Return _CoilStartTime
                End Get
                Set(ByVal value As System.DateTime)
                    _CoilStartTime = value
                End Set
            End Property
#End Region
#Region "鋼捲作業終止時間 屬性:CoilEndTime"
            Private _CoilEndTime As System.DateTime
            ''' <summary>
            ''' 鋼捲作業終止時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CoilEndTime() As System.DateTime
                Get
                    Return _CoilEndTime
                End Get
                Set(ByVal value As System.DateTime)
                    _CoilEndTime = value
                End Set
            End Property
#End Region
#Region "厚度 屬性:Guage"
            Private _Guage As System.Decimal
            ''' <summary>
            ''' 厚度
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Guage() As System.Decimal
                Get
                    Return _Guage
                End Get
                Set(ByVal value As System.Decimal)
                    _Guage = value
                End Set
            End Property
#End Region
#Region "寬度 屬性:Width"
            Private _Width As System.Decimal
            ''' <summary>
            ''' 寬度
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Width() As System.Decimal
                Get
                    Return _Width
                End Get
                Set(ByVal value As System.Decimal)
                    _Width = value
                End Set
            End Property
#End Region
#Region "長度 屬性:Length"
            Private _Length As System.Decimal
            ''' <summary>
            ''' 長度
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Length() As System.Decimal
                Get
                    Return _Length
                End Get
                Set(ByVal value As System.Decimal)
                    _Length = value
                End Set
            End Property
#End Region
#Region "重量 屬性:Weight"
            Private _Weight As System.Decimal
            ''' <summary>
            ''' 重量
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Weight() As System.Decimal
                Get
                    Return _Weight
                End Get
                Set(ByVal value As System.Decimal)
                    _Weight = value
                End Set
            End Property
#End Region
#Region "耗損重 屬性:ScaleWeight"
            Private _ScaleWeight As System.Decimal
            ''' <summary>
            ''' 耗損重
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ScaleWeight() As System.Decimal
                Get
                    Return _ScaleWeight
                End Get
                Set(ByVal value As System.Decimal)
                    _ScaleWeight = value
                End Set
            End Property
#End Region
#Region "回爐重(退料) 屬性:ReturnWeight"
            Private _ReturnWeight As System.Decimal
            ''' <summary>
            ''' 回爐重(退料)
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ReturnWeight() As System.Decimal
                Get
                    Return _ReturnWeight
                End Get
                Set(ByVal value As System.Decimal)
                    _ReturnWeight = value
                End Set
            End Property
#End Region
#Region "其他重量(頭尾料) 屬性:OtherWeight"
            Private _OtherWeight As System.Decimal
            ''' <summary>
            ''' 其他重量(頭尾料)
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property OtherWeight() As System.Decimal
                Get
                    Return _OtherWeight
                End Get
                Set(ByVal value As System.Decimal)
                    _OtherWeight = value
                End Set
            End Property
#End Region
#Region "資料寫入工號 屬性:WriteEmployeeNumber"
            Private _WriteEmployeeNumber As System.String
            ''' <summary>
            ''' 資料寫入工號
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property WriteEmployeeNumber() As System.String
                Get
                    Return _WriteEmployeeNumber
                End Get
                Set(ByVal value As System.String)
                    _WriteEmployeeNumber = value
                End Set
            End Property
#End Region
#Region "備註1 屬性:Memo1"
            Private _Memo1 As System.String
            ''' <summary>
            ''' 備註1
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
#Region "資料建立時間 屬性:DataCreateTime"

            Private _DataCreateTime As DateTime
            ''' <summary>
            ''' 資料建立時間
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property DataCreateTime() As DateTime
                Get
                    Return _DataCreateTime
                End Get
                Set(ByVal value As DateTime)
                    _DataCreateTime = value
                End Set
            End Property

#End Region
#Region "次筆資料目前狀態(1.CoilStart2.CoilEnd3.SaveToAS400) 屬性:ThisRecordState"
            Private _ThisRecordState As Integer
            ''' <summary>
            ''' 次筆資料目前狀態(1.CoilStart2.CoilEnd3.SaveToAS400)
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ThisRecordState() As Integer
                Get
                    Return _ThisRecordState
                End Get
                Set(ByVal value As Integer)
                    _ThisRecordState = value
                End Set
            End Property

#End Region
#Region "第一顆鋼捲CoilStart的時間 屬性:FirstsysCoilStartTime"
            Private _FirstsysCoilStartTime As DateTime
            ''' <summary>
            ''' 第一顆鋼捲CoilStart的時間
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FirstsysCoilStartTime() As DateTime
                Get
                    Return _FirstsysCoilStartTime
                End Get
                Set(ByVal value As DateTime)
                    _FirstsysCoilStartTime = value
                End Set
            End Property

#End Region
#Region "是否取消 屬性:IsCancel"
            Private _IsCancel As Boolean
            ''' <summary>
            ''' 是否取消
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsCancel() As Boolean
                Get
                    Return _IsCancel
                End Get
                Set(ByVal value As Boolean)
                    _IsCancel = value
                End Set
            End Property
#End Region
#Region "執行PASS數 屬性:RunPassCont"
            Private _RunPassCont As Integer
            ''' <summary>
            ''' 執行PASS數
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RunPassCont() As Integer
                Get
                    Return _RunPassCont
                End Get
                Set(ByVal value As Integer)
                    _RunPassCont = value
                End Set
            End Property

#End Region
#Region "L2訊號字串 屬性:L2MessageString"
            Private _L2MessageString As String
            ''' <summary>
            ''' L2訊號字串
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property L2MessageString() As String
                Get
                    Return _L2MessageString
                End Get
                Set(ByVal value As String)
                    _L2MessageString = value
                End Set
            End Property
#End Region
#Region "過磅資料_夾整捲 屬性:CIC11"
            Private _CIC11 As String
            Public Property CIC11() As String
                Get
                    Return _CIC11
                End Get
                Set(ByVal value As String)
                    _CIC11 = value
                End Set
            End Property
#End Region         '襯紙
#Region "過磅資料_紙寬m 屬性:CIC12"
            Private _CIC12 As Double
            Public Property CIC12() As Double
                Get
                    Return _CIC12
                End Get
                Set(ByVal value As Double)
                    _CIC12 = value
                End Set
            End Property
#End Region
#Region "過磅資料_紙寬m 屬性:CIC13"
            Private _CIC13 As Double
            Public Property CIC13() As Double
                Get
                    Return _CIC13
                End Get
                Set(ByVal value As Double)
                    _CIC13 = value
                End Set
            End Property
#End Region
#Region "過磅資料_基重kg 屬性:CIC14"
            Private _CIC14 As Double
            Public Property CIC14() As Double
                Get
                    Return _CIC14
                End Get
                Set(ByVal value As Double)
                    _CIC14 = value
                End Set
            End Property
#End Region
#Region "過磅資料_薄厚紙 屬性:CIC15"
            Private _CIC15 As String
            Public Property CIC15() As String
                Get
                    Return _CIC15
                End Get
                Set(ByVal value As String)
                    _CIC15 = value
                End Set
            End Property
#End Region
#Region "過磅資料_有套筒 屬性:CIC21"
            Private _CIC21 As String
            Public Property CIC21() As String
                Get
                    Return _CIC21
                End Get
                Set(ByVal value As String)
                    _CIC21 = value
                End Set
            End Property
#End Region         '紙套筒
#Region "過磅資料_套筒外徑 屬性:CIC22"
            Private _CIC22 As Integer
            Public Property CIC22() As Integer
                Get
                    Return _CIC22
                End Get
                Set(ByVal value As Integer)
                    _CIC22 = value
                End Set
            End Property
#End Region
#Region "過磅資料_鋼捲內徑 屬性:CIC23"
            Private _CIC23 As Integer
            Public Property CIC23() As Integer
                Get
                    Return _CIC23
                End Get
                Set(ByVal value As Integer)
                    _CIC23 = value
                End Set
            End Property
#End Region
#Region "過磅資料_筒重kg 屬性:CIC24"
            Private _CIC24 As Integer
            Public Property CIC24() As Integer
                Get
                    Return _CIC24
                End Get
                Set(ByVal value As Integer)
                    _CIC24 = value
                End Set
            End Property
#End Region
#Region "過磅資料_包整捲 屬性:CIC31"
            Private _CIC31 As String
            Public Property CIC31() As String
                Get
                    Return _CIC31
                End Get
                Set(ByVal value As String)
                    _CIC31 = value
                End Set
            End Property
#End Region         '奇麗龍
#Region "過磅資料_加長m 屬性:AboutPPSCICPF_CIC32"
            Private _CIC32 As Double
            Public Property CIC32() As Double
                Get
                    Return _CIC32
                End Get
                Set(ByVal value As Double)
                    _CIC32 = value
                End Set
            End Property
#End Region
#Region "過磅資料_紙寬m 屬性:CIC33"
            Private _CIC33 As Double
            Public Property CIC33() As Double
                Get
                    Return _CIC33
                End Get
                Set(ByVal value As Double)
                    _CIC33 = value
                End Set
            End Property
#End Region
#Region "過磅資料_基重kg 屬性:CIC34"
            Private _CIC34 As Double
            Public Property CIC34() As Double
                Get
                    Return _CIC34
                End Get
                Set(ByVal value As Double)
                    _CIC34 = value
                End Set
            End Property
#End Region
#Region "ZML_BURod1 屬性:ZML_BURod1"
            Private _ZML_BURod1 As System.String
            ''' <summary>
            ''' 背輥A
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BURod1() As System.String
                Get
                    Return _ZML_BURod1
                End Get
                Set(ByVal value As System.String)
                    _ZML_BURod1 = value
                End Set
            End Property
#End Region
#Region "ZML_BURod2 屬性:ZML_BURod2"
            Private _ZML_BURod2 As System.String
            ''' <summary>
            ''' 背輥B
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BURod2() As System.String
                Get
                    Return _ZML_BURod2
                End Get
                Set(ByVal value As System.String)
                    _ZML_BURod2 = value
                End Set
            End Property
#End Region
#Region "ZML_BURod3 屬性:ZML_BURod3"
            Private _ZML_BURod3 As System.String
            ''' <summary>
            ''' 背輥C
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BURod3() As System.String
                Get
                    Return _ZML_BURod3
                End Get
                Set(ByVal value As System.String)
                    _ZML_BURod3 = value
                End Set
            End Property
#End Region
#Region "ZML_BURod4 屬性:ZML_BURod4"
            Private _ZML_BURod4 As System.String
            ''' <summary>
            ''' 背輥D
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BURod4() As System.String
                Get
                    Return _ZML_BURod4
                End Get
                Set(ByVal value As System.String)
                    _ZML_BURod4 = value
                End Set
            End Property
#End Region
#Region "ZML_BDRod1 屬性:ZML_BDRod1"
            Private _ZML_BDRod1 As System.String
            ''' <summary>
            ''' 背輥E
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BDRod1() As System.String
                Get
                    Return _ZML_BDRod1
                End Get
                Set(ByVal value As System.String)
                    _ZML_BDRod1 = value
                End Set
            End Property
#End Region
#Region "ZML_BDRod2 屬性:ZML_BDRod2"
            Private _ZML_BDRod2 As System.String
            ''' <summary>
            ''' 背輥F
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BDRod2() As System.String
                Get
                    Return _ZML_BDRod2
                End Get
                Set(ByVal value As System.String)
                    _ZML_BDRod2 = value
                End Set
            End Property
#End Region
#Region "ZML_BDRod3 屬性:ZML_BDRod3"
            Private _ZML_BDRod3 As System.String
            ''' <summary>
            ''' 背輥G
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BDRod3() As System.String
                Get
                    Return _ZML_BDRod3
                End Get
                Set(ByVal value As System.String)
                    _ZML_BDRod3 = value
                End Set
            End Property
#End Region
#Region "ZML_BDRod4 屬性:ZML_BDRod4"
            Private _ZML_BDRod4 As System.String
            ''' <summary>
            ''' 背輥H
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BDRod4() As System.String
                Get
                    Return _ZML_BDRod4
                End Get
                Set(ByVal value As System.String)
                    _ZML_BDRod4 = value
                End Set
            End Property
#End Region
#Region "ZML_MURod1 屬性:ZML_MURod1"
            Private _ZML_MURod1 As System.String
            ''' <summary>
            ''' 上左驅輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_MURod1() As System.String
                Get
                    Return _ZML_MURod1
                End Get
                Set(ByVal value As System.String)
                    _ZML_MURod1 = value
                End Set
            End Property
#End Region
#Region "ZML_MURod2 屬性:ZML_MURod2"
            Private _ZML_MURod2 As System.String
            ''' <summary>
            ''' 上惰輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_MURod2() As System.String
                Get
                    Return _ZML_MURod2
                End Get
                Set(ByVal value As System.String)
                    _ZML_MURod2 = value
                End Set
            End Property
#End Region
#Region "ZML_MURod3 屬性:ZML_MURod3"
            Private _ZML_MURod3 As System.String
            ''' <summary>
            ''' 上右驅輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_MURod3() As System.String
                Get
                    Return _ZML_MURod3
                End Get
                Set(ByVal value As System.String)
                    _ZML_MURod3 = value
                End Set
            End Property
#End Region
#Region "ZML_MDRod1 屬性:ZML_MDRod1"
            Private _ZML_MDRod1 As System.String
            ''' <summary>
            ''' 下左驅輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_MDRod1() As System.String
                Get
                    Return _ZML_MDRod1
                End Get
                Set(ByVal value As System.String)
                    _ZML_MDRod1 = value
                End Set
            End Property
#End Region
#Region "ZML_MDRod2 屬性:ZML_MDRod2"
            Private _ZML_MDRod2 As System.String
            ''' <summary>
            ''' 下惰輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_MDRod2() As System.String
                Get
                    Return _ZML_MDRod2
                End Get
                Set(ByVal value As System.String)
                    _ZML_MDRod2 = value
                End Set
            End Property
#End Region
#Region "ZML_MDRod3 屬性:ZML_MDRod3"
            Private _ZML_MDRod3 As System.String
            ''' <summary>
            ''' 下右驅輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_MDRod3() As System.String
                Get
                    Return _ZML_MDRod3
                End Get
                Set(ByVal value As System.String)
                    _ZML_MDRod3 = value
                End Set
            End Property
#End Region
#Region "ZML_SURod1 屬性:ZML_SURod1"
            Private _ZML_SURod1 As System.String
            ''' <summary>
            ''' 上左第一中間輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_SURod1() As System.String
                Get
                    Return _ZML_SURod1
                End Get
                Set(ByVal value As System.String)
                    _ZML_SURod1 = value
                End Set
            End Property
#End Region
#Region "ZML_SURod2 屬性:ZML_SURod2"
            Private _ZML_SURod2 As System.String
            ''' <summary>
            ''' 上工輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_SURod2() As System.String
                Get
                    Return _ZML_SURod2
                End Get
                Set(ByVal value As System.String)
                    If Not String.IsNullOrEmpty(value) Then
                        value = value.Trim.ToUpper
                    End If
                    _ZML_SURod2 = value
                End Set
            End Property
#End Region
#Region "ZML_SURod3 屬性:ZML_SURod3"
            Private _ZML_SURod3 As System.String
            ''' <summary>
            ''' 上右第一中間輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_SURod3() As System.String
                Get
                    Return _ZML_SURod3
                End Get
                Set(ByVal value As System.String)
                    _ZML_SURod3 = value
                End Set
            End Property
#End Region
#Region "ZML_SDRod1 屬性:ZML_SDRod1"
            Private _ZML_SDRod1 As System.String
            ''' <summary>
            ''' 下左第一中間輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_SDRod1() As System.String
                Get
                    Return _ZML_SDRod1
                End Get
                Set(ByVal value As System.String)
                    _ZML_SDRod1 = value
                End Set
            End Property
#End Region
#Region "ZML_SDRod2 屬性:ZML_SDRod2"
            Private _ZML_SDRod2 As System.String
            ''' <summary>
            ''' 下工輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_SDRod2() As System.String
                Get
                    Return _ZML_SDRod2
                End Get
                Set(ByVal value As System.String)
                    If Not String.IsNullOrEmpty(value) Then
                        value = value.Trim.ToUpper
                    End If
                    _ZML_SDRod2 = value
                End Set
            End Property
#End Region
#Region "ZML_SDRod3 屬性:ZML_SDRod3"
            Private _ZML_SDRod3 As System.String
            ''' <summary>
            ''' 下右第一中間輥
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_SDRod3() As System.String
                Get
                    Return _ZML_SDRod3
                End Get
                Set(ByVal value As System.String)
                    _ZML_SDRod3 = value
                End Set
            End Property
#End Region
#Region "ZML_OilColor 屬性:ZML_OilColor"
            Private _ZML_OilColor As System.Boolean
            ''' <summary>
            ''' ZML_OilColor
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_OilColor() As System.Boolean
                Get
                    Return _ZML_OilColor
                End Get
                Set(ByVal value As System.Boolean)
                    _ZML_OilColor = value
                End Set
            End Property
#End Region
#Region "ZML_OilIsReUse 屬性:ZML_OilIsReUse"
            Private _ZML_OilIsReUse As System.Boolean
            ''' <summary>
            ''' ZML_OilIsReUse
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_OilIsReUse() As System.Boolean
                Get
                    Return _ZML_OilIsReUse
                End Get
                Set(ByVal value As System.Boolean)
                    _ZML_OilIsReUse = value
                End Set
            End Property
#End Region
#Region "ZML_OiIslPressNormal 屬性:ZML_OiIslPressNormal"
            Private _ZML_OiIslPressNormal As System.Boolean
            ''' <summary>
            ''' ZML_OiIslPressNormal
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_OiIslPressNormal() As System.Boolean
                Get
                    Return _ZML_OiIslPressNormal
                End Get
                Set(ByVal value As System.Boolean)
                    _ZML_OiIslPressNormal = value
                End Set
            End Property
#End Region
#Region "ZML_CutCount 屬性:ZML_CutCount"
            Private _ZML_CutCount As System.Int32
            ''' <summary>
            ''' ZML_CutCount
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_CutCount() As System.Int32
                Get
                    Return _ZML_CutCount
                End Get
                Set(ByVal value As System.Int32)
                    _ZML_CutCount = value
                End Set
            End Property
#End Region
#Region "ZML_Scare 屬性:ZML_Scare"
            Private _ZML_Scare As System.Int32
            ''' <summary>
            ''' ZML_Scare
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_Scare() As System.Int32
                Get
                    Return _ZML_Scare
                End Get
                Set(ByVal value As System.Int32)
                    _ZML_Scare = value
                End Set
            End Property
#End Region
#Region "ZML_Peels 屬性:ZML_Peels"
            Private _ZML_Peels As System.Int32
            ''' <summary>
            ''' ZML_Peels
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_Peels() As System.Int32
                Get
                    Return _ZML_Peels
                End Get
                Set(ByVal value As System.Int32)
                    _ZML_Peels = value
                End Set
            End Property
#End Region
#Region "ZML_AT1 屬性:ZML_AT1"
            Private _ZML_AT1 As System.Decimal
            ''' <summary>
            ''' ZML_AT1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_AT1() As System.Decimal
                Get
                    Return _ZML_AT1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_AT1 = value
                End Set
            End Property
#End Region
#Region "ZML_AT2 屬性:ZML_AT2"
            Private _ZML_AT2 As System.Decimal
            ''' <summary>
            ''' ZML_AT2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_AT2() As System.Decimal
                Get
                    Return _ZML_AT2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_AT2 = value
                End Set
            End Property
#End Region
#Region "ZML_AT3 屬性:ZML_AT3"
            Private _ZML_AT3 As System.Decimal
            ''' <summary>
            ''' ZML_AT3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_AT3() As System.Decimal
                Get
                    Return _ZML_AT3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_AT3 = value
                End Set
            End Property
#End Region
#Region "ZML_AT4 屬性:ZML_AT4"
            Private _ZML_AT4 As System.Decimal
            ''' <summary>
            ''' ZML_AT4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_AT4() As System.Decimal
                Get
                    Return _ZML_AT4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_AT4 = value
                End Set
            End Property
#End Region
#Region "ZML_AT5 屬性:ZML_AT5"
            Private _ZML_AT5 As System.Decimal
            ''' <summary>
            ''' ZML_AT5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_AT5() As System.Decimal
                Get
                    Return _ZML_AT5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_AT5 = value
                End Set
            End Property
#End Region
#Region "ZML_AT6 屬性:ZML_AT6"
            Private _ZML_AT6 As System.Decimal
            ''' <summary>
            ''' ZML_AT6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_AT6() As System.Decimal
                Get
                    Return _ZML_AT6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_AT6 = value
                End Set
            End Property
#End Region
#Region "ZML_BT1 屬性:ZML_BT1"
            Private _ZML_BT1 As System.Decimal
            ''' <summary>
            ''' ZML_BT1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BT1() As System.Decimal
                Get
                    Return _ZML_BT1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_BT1 = value
                End Set
            End Property
#End Region
#Region "ZML_BT2 屬性:ZML_BT2"
            Private _ZML_BT2 As System.Decimal
            ''' <summary>
            ''' ZML_BT2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BT2() As System.Decimal
                Get
                    Return _ZML_BT2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_BT2 = value
                End Set
            End Property
#End Region
#Region "ZML_BT3 屬性:ZML_BT3"
            Private _ZML_BT3 As System.Decimal
            ''' <summary>
            ''' ZML_BT3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BT3() As System.Decimal
                Get
                    Return _ZML_BT3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_BT3 = value
                End Set
            End Property
#End Region
#Region "ZML_BT4 屬性:ZML_BT4"
            Private _ZML_BT4 As System.Decimal
            ''' <summary>
            ''' ZML_BT4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BT4() As System.Decimal
                Get
                    Return _ZML_BT4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_BT4 = value
                End Set
            End Property
#End Region
#Region "ZML_BT5 屬性:ZML_BT5"
            Private _ZML_BT5 As System.Decimal
            ''' <summary>
            ''' ZML_BT5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BT5() As System.Decimal
                Get
                    Return _ZML_BT5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_BT5 = value
                End Set
            End Property
#End Region
#Region "ZML_BT6 屬性:ZML_BT6"
            Private _ZML_BT6 As System.Decimal
            ''' <summary>
            ''' ZML_BT6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_BT6() As System.Decimal
                Get
                    Return _ZML_BT6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_BT6 = value
                End Set
            End Property
#End Region
#Region "ZML_CT1 屬性:ZML_CT1"
            Private _ZML_CT1 As System.Decimal
            ''' <summary>
            ''' ZML_CT1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_CT1() As System.Decimal
                Get
                    Return _ZML_CT1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_CT1 = value
                End Set
            End Property
#End Region
#Region "ZML_CT2 屬性:ZML_CT2"
            Private _ZML_CT2 As System.Decimal
            ''' <summary>
            ''' ZML_CT2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_CT2() As System.Decimal
                Get
                    Return _ZML_CT2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_CT2 = value
                End Set
            End Property
#End Region
#Region "ZML_CT3 屬性:ZML_CT3"
            Private _ZML_CT3 As System.Decimal
            ''' <summary>
            ''' ZML_CT3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_CT3() As System.Decimal
                Get
                    Return _ZML_CT3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_CT3 = value
                End Set
            End Property
#End Region
#Region "ZML_CT4 屬性:ZML_CT4"
            Private _ZML_CT4 As System.Decimal
            ''' <summary>
            ''' ZML_CT4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_CT4() As System.Decimal
                Get
                    Return _ZML_CT4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_CT4 = value
                End Set
            End Property
#End Region
#Region "ZML_CT5 屬性:ZML_CT5"
            Private _ZML_CT5 As System.Decimal
            ''' <summary>
            ''' ZML_CT5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_CT5() As System.Decimal
                Get
                    Return _ZML_CT5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_CT5 = value
                End Set
            End Property
#End Region
#Region "ZML_CT6 屬性:ZML_CT6"
            Private _ZML_CT6 As System.Decimal
            ''' <summary>
            ''' ZML_CT6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_CT6() As System.Decimal
                Get
                    Return _ZML_CT6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_CT6 = value
                End Set
            End Property
#End Region
#Region "ZML_DT1 屬性:ZML_DT1"
            Private _ZML_DT1 As System.Decimal
            ''' <summary>
            ''' ZML_DT1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_DT1() As System.Decimal
                Get
                    Return _ZML_DT1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_DT1 = value
                End Set
            End Property
#End Region
#Region "ZML_DT2 屬性:ZML_DT2"
            Private _ZML_DT2 As System.Decimal
            ''' <summary>
            ''' ZML_DT2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_DT2() As System.Decimal
                Get
                    Return _ZML_DT2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_DT2 = value
                End Set
            End Property
#End Region
#Region "ZML_DT3 屬性:ZML_DT3"
            Private _ZML_DT3 As System.Decimal
            ''' <summary>
            ''' ZML_DT3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_DT3() As System.Decimal
                Get
                    Return _ZML_DT3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_DT3 = value
                End Set
            End Property
#End Region
#Region "ZML_DT4 屬性:ZML_DT4"
            Private _ZML_DT4 As System.Decimal
            ''' <summary>
            ''' ZML_DT4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_DT4() As System.Decimal
                Get
                    Return _ZML_DT4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_DT4 = value
                End Set
            End Property
#End Region
#Region "ZML_DT5 屬性:ZML_DT5"
            Private _ZML_DT5 As System.Decimal
            ''' <summary>
            ''' ZML_DT5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_DT5() As System.Decimal
                Get
                    Return _ZML_DT5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_DT5 = value
                End Set
            End Property
#End Region
#Region "ZML_DT6 屬性:ZML_DT6"
            Private _ZML_DT6 As System.Decimal
            ''' <summary>
            ''' ZML_DT6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_DT6() As System.Decimal
                Get
                    Return _ZML_DT6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_DT6 = value
                End Set
            End Property
#End Region
#Region "ZML_ET1 屬性:ZML_ET1"
            Private _ZML_ET1 As System.Decimal
            ''' <summary>
            ''' ZML_ET1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_ET1() As System.Decimal
                Get
                    Return _ZML_ET1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_ET1 = value
                End Set
            End Property
#End Region
#Region "ZML_ET2 屬性:ZML_ET2"
            Private _ZML_ET2 As System.Decimal
            ''' <summary>
            ''' ZML_ET2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_ET2() As System.Decimal
                Get
                    Return _ZML_ET2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_ET2 = value
                End Set
            End Property
#End Region
#Region "ZML_ET3 屬性:ZML_ET3"
            Private _ZML_ET3 As System.Decimal
            ''' <summary>
            ''' ZML_ET3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_ET3() As System.Decimal
                Get
                    Return _ZML_ET3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_ET3 = value
                End Set
            End Property
#End Region
#Region "ZML_ET4 屬性:ZML_ET4"
            Private _ZML_ET4 As System.Decimal
            ''' <summary>
            ''' ZML_ET4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_ET4() As System.Decimal
                Get
                    Return _ZML_ET4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_ET4 = value
                End Set
            End Property
#End Region
#Region "ZML_ET5 屬性:ZML_ET5"
            Private _ZML_ET5 As System.Decimal
            ''' <summary>
            ''' ZML_ET5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_ET5() As System.Decimal
                Get
                    Return _ZML_ET5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_ET5 = value
                End Set
            End Property
#End Region
#Region "ZML_ET6 屬性:ZML_ET6"
            Private _ZML_ET6 As System.Decimal
            ''' <summary>
            ''' ZML_ET6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_ET6() As System.Decimal
                Get
                    Return _ZML_ET6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_ET6 = value
                End Set
            End Property
#End Region
#Region "ZML_FT1 屬性:ZML_FT1"
            Private _ZML_FT1 As System.Decimal
            ''' <summary>
            ''' ZML_FT1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_FT1() As System.Decimal
                Get
                    Return _ZML_FT1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_FT1 = value
                End Set
            End Property
#End Region
#Region "ZML_FT2 屬性:ZML_FT2"
            Private _ZML_FT2 As System.Decimal
            ''' <summary>
            ''' ZML_FT2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_FT2() As System.Decimal
                Get
                    Return _ZML_FT2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_FT2 = value
                End Set
            End Property
#End Region
#Region "ZML_FT3 屬性:ZML_FT3"
            Private _ZML_FT3 As System.Decimal
            ''' <summary>
            ''' ZML_FT3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_FT3() As System.Decimal
                Get
                    Return _ZML_FT3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_FT3 = value
                End Set
            End Property
#End Region
#Region "ZML_FT4 屬性:ZML_FT4"
            Private _ZML_FT4 As System.Decimal
            ''' <summary>
            ''' ZML_FT4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_FT4() As System.Decimal
                Get
                    Return _ZML_FT4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_FT4 = value
                End Set
            End Property
#End Region
#Region "ZML_FT5 屬性:ZML_FT5"
            Private _ZML_FT5 As System.Decimal
            ''' <summary>
            ''' ZML_FT5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_FT5() As System.Decimal
                Get
                    Return _ZML_FT5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_FT5 = value
                End Set
            End Property
#End Region
#Region "ZML_FT6 屬性:ZML_FT6"
            Private _ZML_FT6 As System.Decimal
            ''' <summary>
            ''' ZML_FT6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_FT6() As System.Decimal
                Get
                    Return _ZML_FT6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_FT6 = value
                End Set
            End Property
#End Region
#Region "ZML_GT1 屬性:ZML_GT1"
            Private _ZML_GT1 As System.Decimal
            ''' <summary>
            ''' ZML_GT1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_GT1() As System.Decimal
                Get
                    Return _ZML_GT1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_GT1 = value
                End Set
            End Property
#End Region
#Region "ZML_GT2 屬性:ZML_GT2"
            Private _ZML_GT2 As System.Decimal
            ''' <summary>
            ''' ZML_GT2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_GT2() As System.Decimal
                Get
                    Return _ZML_GT2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_GT2 = value
                End Set
            End Property
#End Region
#Region "ZML_GT3 屬性:ZML_GT3"
            Private _ZML_GT3 As System.Decimal
            ''' <summary>
            ''' ZML_GT3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_GT3() As System.Decimal
                Get
                    Return _ZML_GT3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_GT3 = value
                End Set
            End Property
#End Region
#Region "ZML_GT4 屬性:ZML_GT4"
            Private _ZML_GT4 As System.Decimal
            ''' <summary>
            ''' ZML_GT4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_GT4() As System.Decimal
                Get
                    Return _ZML_GT4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_GT4 = value
                End Set
            End Property
#End Region
#Region "ZML_GT5 屬性:ZML_GT5"
            Private _ZML_GT5 As System.Decimal
            ''' <summary>
            ''' ZML_GT5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_GT5() As System.Decimal
                Get
                    Return _ZML_GT5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_GT5 = value
                End Set
            End Property
#End Region
#Region "ZML_GT6 屬性:ZML_GT6"
            Private _ZML_GT6 As System.Decimal
            ''' <summary>
            ''' ZML_GT6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_GT6() As System.Decimal
                Get
                    Return _ZML_GT6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_GT6 = value
                End Set
            End Property
#End Region
#Region "ZML_HT1 屬性:ZML_HT1"
            Private _ZML_HT1 As System.Decimal
            ''' <summary>
            ''' ZML_HT1
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_HT1() As System.Decimal
                Get
                    Return _ZML_HT1
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_HT1 = value
                End Set
            End Property
#End Region
#Region "ZML_HT2 屬性:ZML_HT2"
            Private _ZML_HT2 As System.Decimal
            ''' <summary>
            ''' ZML_HT2
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_HT2() As System.Decimal
                Get
                    Return _ZML_HT2
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_HT2 = value
                End Set
            End Property
#End Region
#Region "ZML_HT3 屬性:ZML_HT3"
            Private _ZML_HT3 As System.Decimal
            ''' <summary>
            ''' ZML_HT3
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_HT3() As System.Decimal
                Get
                    Return _ZML_HT3
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_HT3 = value
                End Set
            End Property
#End Region
#Region "ZML_HT4 屬性:ZML_HT4"
            Private _ZML_HT4 As System.Decimal
            ''' <summary>
            ''' ZML_HT4
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_HT4() As System.Decimal
                Get
                    Return _ZML_HT4
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_HT4 = value
                End Set
            End Property
#End Region
#Region "ZML_HT5 屬性:ZML_HT5"
            Private _ZML_HT5 As System.Decimal
            ''' <summary>
            ''' ZML_HT5
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_HT5() As System.Decimal
                Get
                    Return _ZML_HT5
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_HT5 = value
                End Set
            End Property
#End Region
#Region "ZML_HT6 屬性:ZML_HT6"
            Private _ZML_HT6 As System.Decimal
            ''' <summary>
            ''' ZML_HT6
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_HT6() As System.Decimal
                Get
                    Return _ZML_HT6
                End Get
                Set(ByVal value As System.Decimal)
                    _ZML_HT6 = value
                End Set
            End Property
#End Region
#Region "ZML_Bised 屬性:ZML_Bised"
            Private _ZML_Bised As String
            ''' <summary>
            ''' 片偏
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_Bised() As String
                Get
                    Return _ZML_Bised
                End Get
                Set(ByVal value As String)
                    _ZML_Bised = value
                End Set
            End Property

#End Region
#Region "ZML_SideState"
            Private _ZML_SideState As Integer
            ''' <summary>
            ''' 邊緣狀況
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ZML_SideState() As Integer
                Get
                    Return _ZML_SideState
                End Get
                Set(ByVal value As Integer)
                    _ZML_SideState = value
                End Set
            End Property

#End Region
#Region "是否為最終產品 屬性:IsFinishProduct"
            Private _IsFinishProduct As Boolean
            ''' <summary>
            ''' 是否為最終產品
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsFinishProduct() As Boolean
                Get
                    Return _IsFinishProduct
                End Get
                Set(ByVal value As Boolean)
                    _IsFinishProduct = value
                End Set
            End Property

#End Region
#Region "使用者是否已確認資料 屬性:IsUserRunningDataChecked"
            Private _IsUserRunningDataChecked As Boolean
            ''' <summary>
            ''' 使用者是否已確認資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsUserRunningDataChecked() As Boolean
                Get
                    Return _IsUserRunningDataChecked
                End Get
                Set(ByVal value As Boolean)
                    _IsUserRunningDataChecked = value
                End Set
            End Property

#End Region
#Region "使用者確認資料時間 屬性:UserRunningDataCheckedTime"
            Private _UserRunningDataCheckedTime As DateTime
            ''' <summary>
            ''' 使用者確認資料時間
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property UserRunningDataCheckedTime() As DateTime
                Get
                    If _UserRunningDataCheckedTime = Date.MinValue Then
                        _UserRunningDataCheckedTime = New DateTime(2000, 1, 1)
                    End If
                    Return _UserRunningDataCheckedTime
                End Get
                Set(ByVal value As DateTime)
                    _UserRunningDataCheckedTime = value
                End Set
            End Property

#End Region


#Region "可刪除 原ZML有使用欄位目前已作廢不用"

            '#Region "ZML_HScare 屬性:ZML_HScare"
            '            Private _ZML_HScare As System.Boolean
            '            ''' <summary>
            '            ''' ZML_HScare
            '            ''' </summary>
            '            ''' <returns></returns>
            '            ''' <remarks></remarks>
            '            Public Property ZML_HScare() As System.Boolean
            '                Get
            '                    Return _ZML_HScare
            '                End Get
            '                Set(ByVal value As System.Boolean)
            '                    _ZML_HScare = value
            '                End Set
            '            End Property
            '#End Region
            '#Region "ZML_TScare 屬性:ZML_TScare"
            '            Private _ZML_TScare As System.Boolean
            '            ''' <summary>
            '            ''' ZML_TScare
            '            ''' </summary>
            '            ''' <returns></returns>
            '            ''' <remarks></remarks>
            '            Public Property ZML_TScare() As System.Boolean
            '                Get
            '                    Return _ZML_TScare
            '                End Get
            '                Set(ByVal value As System.Boolean)
            '                    _ZML_TScare = value
            '                End Set
            '            End Property
            '#End Region
            '#Region "ZML_Peel 屬性:ZML_Peel"
            '            Private _ZML_Peel As System.Boolean
            '            ''' <summary>
            '            ''' ZML_Peel
            '            ''' </summary>
            '            ''' <returns></returns>
            '            ''' <remarks></remarks>
            '            Public Property ZML_Peel() As System.Boolean
            '                Get
            '                    Return _ZML_Peel
            '                End Get
            '                Set(ByVal value As System.Boolean)
            '                    _ZML_Peel = value
            '                End Set
            '            End Property
            '#End Region

            '#Region "ZML_IsSideAbnormal 屬性:ZML_IsSideAbnormal"
            '            Private _ZML_IsSideAbnormal As Boolean
            '            ''' <summary>
            '            ''' 是否邊綠狀況異常
            '            ''' </summary>
            '            ''' <value></value>
            '            ''' <returns></returns>
            '            ''' <remarks></remarks>
            '            Public Property ZML_IsSideAbnormal() As Boolean
            '                Get
            '                    Return _ZML_IsSideAbnormal
            '                End Get
            '                Set(ByVal value As Boolean)
            '                    _ZML_IsSideAbnormal = value
            '                End Set
            '            End Property

            '#End Region
#End Region




#Region "依最後參考PPSSHAPF取得所有RunProcessData Shared方法:GetRunProcessDatasFromPPSSHAPF"
            ''' <summary>
            ''' 依最後參考PPSSHAPF取得所有RunProcessData
            ''' </summary>
            ''' <param name="FindLastRefPPSSHAPF"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared Function GetRunProcessDatasFromLastRefPPSSHAPF(ByVal FindLastRefPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF) As List(Of RunProcessData)
                If IsNothing(FindLastRefPPSSHAPF) Then
                    Return New List(Of RunProcessData)
                End If
                Dim GetNowDataStartTime As Date
                Select Case True
                    Case FindLastRefPPSSHAPF.SHA11 > 0
                        GetNowDataStartTime = (New AS400DateConverter(CType(FindLastRefPPSSHAPF.SHA11, Integer))).DateValue.AddMonths(-3)
                    Case FindLastRefPPSSHAPF.SHA21 > 0
                        GetNowDataStartTime = (New AS400DateConverter(CType(FindLastRefPPSSHAPF.SHA21, Integer))).DateValue.AddMonths(-3)
                    Case Else
                        GetNowDataStartTime = Now.AddYears(-2)
                End Select
                Dim QryString As String
                Dim CurrentClientIP As String = PPSSHAPFFlowAdapter.CurrentOperationPCRunningState.RunningPCIP.Trim
                QryString = "Select * from OperationPCRunningState Where RunningPCIP='" & CurrentClientIP & "'"
                Dim SearchResult As List(Of OperationPCRunningState) = OperationPCRunningState.CDBSelect(Of OperationPCRunningState)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                If SearchResult.Count = 0 OrElse String.IsNullOrEmpty(SearchResult(0).DefaultUseStationName) OrElse SearchResult(0).DefaultUseStationName.Trim.Length = 0 Then
                    Return New List(Of RunProcessData)
                End If
                Dim CurrentUseStationName As String = SearchResult(0).DefaultUseStationName.Trim


                QryString = "Select * from RunProcessData Where  SysCoilStartTime>=" & Format(GetNowDataStartTime, "yyyy/MM/dd") & " AND  FK_LastRefSHA01='" & FindLastRefPPSSHAPF.SHA01.Trim & "' AND FK_LastRefSHA02='" & FindLastRefPPSSHAPF.SHA02.Trim & "' AND FK_LastRefSHA04=" & FindLastRefPPSSHAPF.SHA04 & " AND  RunStationPCIP='" & CurrentClientIP & "' AND FK_RunStationName='" & CurrentUseStationName & "' Order By DataCreateTime "
                Return PPSSHAPF.CDBSelect(Of RunProcessData)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
            End Function
#End Region
#Region "相關最後參考PPSSHAPF 屬性:AboutLastRefPPSSHAPF"
            Private _AboutLastRefPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF
            ''' <summary>
            ''' 相關最後參考PPSSHAPF
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property AboutLastRefPPSSHAPF() As CompanyORMDB.IPPS100LB.IPPSSHAPF
                Get
                    If IsNothing(_AboutLastRefPPSSHAPF) Then
                        Dim Adapter As New PPSSHAPFFlowAdapter(Me.FK_LastRefSHA01.Trim & Me.FK_LastRefSHA02.Trim)
                        For Each EachItem As CompanyORMDB.IPPS100LB.IPPSSHAPF In Adapter.FinalALLPPSSHAPFs
                            If EachItem.SHA04 = Me.FK_LastRefSHA04 Then
                                _AboutLastRefPPSSHAPF = EachItem
                                Exit For
                            End If
                        Next
                    End If
                    Return _AboutLastRefPPSSHAPF
                End Get
                Set(ByVal value As CompanyORMDB.IPPS100LB.IPPSSHAPF)
                    _AboutLastRefPPSSHAPF = value
                    If IsNothing(_AboutLastRefPPSSHAPF) Then
                        Me.FK_LastRefSHA01 = ""
                        Me.FK_LastRefSHA02 = ""
                        Me.FK_LastRefSHA04 = ""
                    Else
                        Me.FK_LastRefSHA01 = _AboutLastRefPPSSHAPF.SHA01
                        Me.FK_LastRefSHA02 = _AboutLastRefPPSSHAPF.SHA02
                        Me.FK_LastRefSHA04 = _AboutLastRefPPSSHAPF.SHA04
                    End If
                End Set
            End Property
#End Region
#Region "相關Station 屬性:AboutStation"

            Private _AboutStation As Station
            ''' <summary>
            ''' 相關Station
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property AboutStation() As Station
                Get
                    If IsNothing(_AboutStation) AndAlso Not String.IsNullOrEmpty(Me.FK_RunStationName) Then
                        Dim GetDatas As List(Of Station) = Station.CDBSelect(Of Station)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, "Select * from Station Where StationName='" & Me.FK_RunStationName & "'")
                        If GetDatas.Count > 0 Then
                            _AboutStation = GetDatas(0)
                        End If
                    End If
                    Return _AboutStation
                End Get
                Set(ByVal value As Station)
                    _AboutStation = value
                    If IsNothing(_AboutStation) Then
                        Me.FK_RunStationName = ""
                    Else
                        Me.FK_RunStationName = _AboutStation.StationName
                    End If
                End Set
            End Property

#End Region
#Region "相關最後輸出PPSSHAPF 屬性:AboutLastOutPPSSHAPF"

            Private _AboutLastOutPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF
            ''' <summary>
            ''' 相關最後輸出PPSSHAPF
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property AboutLastOutPPSSHAPF() As CompanyORMDB.IPPS100LB.IPPSSHAPF
                Get
                    If IsNothing(_AboutLastOutPPSSHAPF) Then

                        Dim Adapter As New PPSSHAPFFlowAdapter(Me.FK_OutSHA01 & Me.FK_OutSHA02)
                        For Each EachItem As CompanyORMDB.IPPS100LB.IPPSSHAPF In Adapter.FinalALLPPSSHAPFs
                            If EachItem.SHA04 = Me.FK_OutSHA04 Then
                                _AboutLastOutPPSSHAPF = EachItem
                                Exit For
                            End If
                        Next
                    End If
                    Return _AboutLastOutPPSSHAPF
                End Get
                Set(ByVal value As CompanyORMDB.IPPS100LB.IPPSSHAPF)
                    _AboutLastOutPPSSHAPF = value
                    If IsNothing(_AboutLastOutPPSSHAPF) Then
                        Me.FK_OutSHA01 = ""
                        Me.FK_OutSHA02 = ""
                        Me.FK_OutSHA04 = ""
                    Else
                        Me.FK_OutSHA01 = _AboutLastOutPPSSHAPF.SHA01
                        Me.FK_OutSHA02 = _AboutLastOutPPSSHAPF.SHA02
                        Me.FK_OutSHA04 = _AboutLastOutPPSSHAPF.SHA04
                    End If
                End Set
            End Property

#End Region
#Region "相關RunProcessSchedual  屬性:AboutRunProcessSchedual"
            Private _AboutRunProcessSchedual As ProcessSchedual
            ''' <summary>
            ''' 相關RunProcessSchedual
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property AboutRunProcessSchedual() As ProcessSchedual
                Get
                    If IsNothing(_AboutRunProcessSchedual) Then
                        Dim GetDatas As List(Of ProcessSchedual) = ProcessSchedual.CDBSelect(Of ProcessSchedual)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, "Select * From ProcessSchedual Where ID='" & FK_RunProcessSchedualID.Trim & "'")
                        If GetDatas.Count > 0 Then
                            _AboutRunProcessSchedual = GetDatas(0)
                        End If
                    End If
                    Return _AboutRunProcessSchedual
                End Get
                Set(ByVal value As ProcessSchedual)
                    _AboutRunProcessSchedual = value
                    If IsNothing(_AboutRunProcessSchedual) Then
                        Me.FK_RunProcessSchedualID = ""
                    Else
                        Me.FK_RunProcessSchedualID = _AboutRunProcessSchedual.ID
                    End If
                End Set
            End Property

#End Region
#Region "相關黑皮檔 屬性:AboutPPSBLAPF"
            Private _AboutPPSBLAPF As CompanyORMDB.PPS100LB.PPSBLAPF
            ''' <summary>
            ''' 相關黑皮檔
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property AboutPPSBLAPF() As CompanyORMDB.PPS100LB.PPSBLAPF
                Get
                    If IsNothing(_AboutPPSBLAPF) Then
                        Dim GetDatas As List(Of CompanyORMDB.PPS100LB.PPSBLAPF) = CompanyORMDB.PPS100LB.PPSBLAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSBLAPF)("Select * From @#PPS100LB.PPSBLAPF WHERE BLA09='" & Me.FK_LastRefSHA01 & "' FETCH FIRST 1 ROWS ONLY", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

                        If GetDatas.Count > 0 Then
                            _AboutPPSBLAPF = GetDatas(0)
                        End If
                    End If
                    Return _AboutPPSBLAPF
                End Get
                Private Set(ByVal value As CompanyORMDB.PPS100LB.PPSBLAPF)
                    _AboutPPSBLAPF = value
                End Set
            End Property
#End Region
#Region "相關成份PPSQCAPF 屬性:AboutPPSQCAPF"
            Private _AboutPPSQCAPF As CompanyORMDB.PPS100LB.PPSQCAPF
            ''' <summary>
            ''' 相關成份PPSQCAPF
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property AboutPPSQCAPF() As CompanyORMDB.PPS100LB.PPSQCAPF
                Get
                    If IsNothing(_AboutPPSQCAPF) Then
                        Dim GetDatas As List(Of CompanyORMDB.PPS100LB.PPSQCAPF) = CompanyORMDB.PPS100LB.PPSQCAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSQCAPF)("Select A.* From @#PPS100LB.PPSQCAPF A JOIN @#PPS100LB.PPSBLAPF B ON  A.QCA01=LEFT(B.BLA07,5)  WHERE B.BLA09='" & Me.FK_LastRefSHA01 & "' FETCH FIRST 1 ROWS ONLY", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                        If GetDatas.Count > 0 Then
                            _AboutPPSQCAPF = GetDatas(0)
                        End If
                    End If
                    Return _AboutPPSQCAPF
                End Get
                Private Set(ByVal value As CompanyORMDB.PPS100LB.PPSQCAPF)
                    _AboutPPSQCAPF = value
                End Set
            End Property
#End Region
#Region "相關鋼胚資料SMSSGAPF 屬性:AboutSMSSGAPF"
            Private _AboutSMSSGAPF As CompanyORMDB.SMS100LB.SMSSGAPF
            ''' <summary>
            ''' 相關鋼胚資料SMSSGAPF
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property AboutSMSSGAPF() As CompanyORMDB.SMS100LB.SMSSGAPF
                Get
                    If IsNothing(_AboutSMSSGAPF) Then
                        Dim GetDatas As List(Of CompanyORMDB.SMS100LB.SMSSGAPF) = CompanyORMDB.SMS100LB.SMSSGAPF.CDBSelect(Of CompanyORMDB.SMS100LB.SMSSGAPF)("Select A.* From @#SMS100LB.SMSSGAPF A JOIN @#PPS100LB.PPSBLAPF B ON A.SGA35='C' AND (A.SGA01 || '-' || A.SGA02 || DIGITS(A.SGA03) || A.SGA04)=B.BLA09  WHERE B.BLA09='" & Me.FK_LastRefSHA01 & "' FETCH FIRST 1 ROWS ONLY", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                        If GetDatas.Count > 0 Then
                            _AboutSMSSGAPF = GetDatas(0)
                        End If
                    End If
                    Return _AboutSMSSGAPF
                End Get
                Private Set(ByVal value As CompanyORMDB.SMS100LB.SMSSGAPF)
                    _AboutSMSSGAPF = value
                End Set
            End Property
#End Region
#Region "相關中鋼代軋鋼捲攤檢資料 屬性:AboutPPSBLFPF"
            Private _AboutPPSBLFPF As CompanyORMDB.PPS100LB.PPSBLFPF
            ''' <summary>
            ''' 相關中鋼代軋鋼捲攤檢資料
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property AboutPPSBLFPF() As CompanyORMDB.PPS100LB.PPSBLFPF
                Get
                    If IsNothing(_AboutPPSBLFPF) Then
                        Dim GetDatas As List(Of CompanyORMDB.PPS100LB.PPSBLFPF) = CompanyORMDB.PPS100LB.PPSBLFPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSBLFPF)("Select A.* From @#PPS100LB.PPSBLFPF A JOIN @#PPS100LB.PPSBLAPF B ON A.BLF01=B.BLA11 AND A.BLF03=B.BLA07 WHERE B.BLA09='" & Me.FK_LastRefSHA01 & "' FETCH FIRST 1 ROWS ONLY", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                        If GetDatas.Count > 0 Then
                            _AboutPPSBLFPF = GetDatas(0)
                        End If
                    End If
                    Return _AboutPPSBLFPF
                End Get
                Private Set(ByVal value As CompanyORMDB.PPS100LB.PPSBLFPF)
                    _AboutPPSBLFPF = value
                End Set
            End Property

#End Region
#Region "最後產線之鋼捲厚寬 屬性:AboutLastOutPPSSHAPF_ThickWidth"
            ''' <summary>
            ''' 最後產線之鋼捲厚寬
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutLastOutPPSSHAPF_ThickWidth As String
                Get
                    Dim Adapter As New PPSSHAPFFlowAdapter(Me.FK_LastRefSHA01 & Me.FK_LastRefSHA02)
                    Dim GetAboutLastOutPPSSHAPF = Adapter.CoilFullNumberForLastPPSSHAPF
                    If Not IsNothing(AboutLastOutPPSSHAPF) Then
                        Return GetAboutLastOutPPSSHAPF.SHA14 & "/" & GetAboutLastOutPPSSHAPF.SHA15
                    End If
                    Return String.Empty
                End Get
            End Property
#End Region
#Region "最後產線之鋼捲重量 屬性:AboutLastOutPPSSHAPF_Weight"
            ''' <summary>
            ''' 最後產線之鋼捲厚寬
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutLastOutPPSSHAPF_Weight As String
                Get
                    Dim Adapter As New PPSSHAPFFlowAdapter(Me.FK_LastRefSHA01 & Me.FK_LastRefSHA02)
                    Dim GetAboutLastOutPPSSHAPF = Adapter.CoilFullNumberForLastPPSSHAPF
                    If Not IsNothing(AboutLastOutPPSSHAPF) Then
                        Return GetAboutLastOutPPSSHAPF.SHA17
                    End If
                    Return String.Empty
                End Get
            End Property
#End Region
#Region "最後產線之鋼捲表面 屬性:AboutLastOutPPSSHAPF_Face"
            ''' <summary>
            ''' 最後產線之鋼捲厚寬
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutLastOutPPSSHAPF_Face As String
                Get
                    Dim Adapter As New PPSSHAPFFlowAdapter(Me.FK_LastRefSHA01 & Me.FK_LastRefSHA02)
                    Dim GetAboutLastOutPPSSHAPF = Adapter.CoilFullNumberForLastPPSSHAPF
                    If Not IsNothing(AboutLastOutPPSSHAPF) Then
                        Return GetAboutLastOutPPSSHAPF.SHA06
                    End If
                    Return String.Empty
                End Get
            End Property
#End Region
#Region "最後產線之鋼捲產線名稱 屬性:AboutLastOutPPSSHAPF_LineName"
            ''' <summary>
            ''' 最後產線之鋼捲產線名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutLastOutPPSSHAPF_LineName As String
                Get
                    Dim Adapter As New PPSSHAPFFlowAdapter(Me.FK_LastRefSHA01 & Me.FK_LastRefSHA02)
                    Dim GetAboutLastOutPPSSHAPF = Adapter.CoilFullNumberForLastPPSSHAPF
                    If Not IsNothing(AboutLastOutPPSSHAPF) Then
                        Return GetAboutLastOutPPSSHAPF.SHA08
                    End If
                    Return String.Empty
                End Get
            End Property
#End Region
#Region "最後產線之鋼捲下一產線名稱 屬性:AboutLastOutPPSSHAPF_NextLineName"
            ''' <summary>
            ''' 最後產線之鋼捲下一產線名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutLastOutPPSSHAPF_NextLineName As String
                Get
                    Dim Adapter As New PPSSHAPFFlowAdapter(Me.FK_LastRefSHA01 & Me.FK_LastRefSHA02)
                    Dim GetAboutLastOutPPSSHAPF = Adapter.CoilFullNumberForLastPPSSHAPF
                    If Not IsNothing(AboutLastOutPPSSHAPF) Then
                        Return GetAboutLastOutPPSSHAPF.SHA27
                    End If
                    Return String.Empty
                End Get
            End Property
#End Region
#Region "此類型產線已執行次數 屬性:TheKindStationRunCount"
            ''' <summary>
            ''' 此產線已執行次數
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property TheKindStationRunCount As Integer
                Get
                    Dim ReturnValue As Integer = 0
                    If IsNothing(Me.AboutStation) Then
                        Return 0
                    End If
                    Dim TheStationName As String = Me.AboutStation.StationName.ToUpper
                    If TheStationName.Length < 2 Then
                        Return 0
                    End If
                    Dim Adapter As New PPSSHAPFFlowAdapter(Me.FK_LastRefSHA01 & Me.FK_LastRefSHA02)
                    For Each EachItem As IPPS100LB.IPPSSHAPF In Adapter.FinalALLPPSSHAPFs
                        If EachItem.SHA08.Substring(0, 2).ToUpper = TheStationName.Substring(0, 2) AndAlso EachItem.SHA28 = "*" AndAlso EachItem.SHA29 <> "*" Then
                            ReturnValue += 1
                        End If
                    Next
                    Return ReturnValue
                End Get
            End Property
#End Region
#Region "此鋼捲在某站產線時段處理之鋼序號 屬性:TheSerialNumberForStation"
            ''' <summary>
            ''' 此鋼捲在某站產線時段處理之鋼序號
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property TheSerialNumberForStation As Integer
                Get
                    Dim FindTime As String = Format(CoilStartTime, "HH:mm:ss")
                    Dim SearhStartTime As DateTime = CoilStartTime.Date
                    Dim SearhEndTime As DateTime = CoilStartTime.Date
                    If Not String.IsNullOrEmpty(FK_RunStationName) AndAlso FK_RunStationName.Length >= 2 _
                        AndAlso FK_RunStationName.Substring(0, 2).ToUpper = "CP" Then
                        'CPL 為二班二輪
                        Select Case True
                            Case FindTime >= "00:00:00" AndAlso FindTime < "15:45:00"
                                SearhEndTime = SearhEndTime.AddHours(15).AddMinutes(45)
                            Case Else
                                SearhStartTime = SearhEndTime.AddHours(15).AddMinutes(45)
                                SearhEndTime = SearhEndTime.AddDays(1).AddSeconds(-1)
                        End Select
                    Else
                        '非CPL 為四班三輪
                        Select Case True
                            Case FindTime >= "00:00:00" AndAlso FindTime < "08:00:00"
                                SearhEndTime = SearhEndTime.AddHours(8)
                            Case FindTime >= "08:00:00" AndAlso FindTime < "17:00:00"
                                SearhStartTime = SearhStartTime.AddHours(8)
                                SearhEndTime = SearhEndTime.AddHours(17)
                            Case Else
                                SearhStartTime = SearhStartTime.AddHours(17)
                                SearhEndTime = SearhEndTime.AddHours(24)
                        End Select
                    End If
                    '取得該時段之RunProcessData資料筆數
                    Dim QryString As String = "Select Count(Distinct fk_lastrefsha01 + fk_lastrefsha02) From RunProcessData where RTRIM(FK_LastRefSHA01 + FK_LastRefSHA02) <> '" & Trim(Me.FK_LastRefSHA01 & Me.FK_LastRefSHA02) & "' and CoilStartTime >= '" & Format(SearhStartTime, "yyyy/MM/dd HH:mm:ss") & "' and CoilStartTime < '" & Format(SearhEndTime, "yyyy/MM/dd HH:mm:ss") & "' AND RunStationPCIP='" & RunStationPCIP & "' "
                    Dim QryAdapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                    Return CType(QryAdapter.SelectQuery(QryString).Rows(0).Item(0), Integer) + 1

                End Get
            End Property
#End Region
#Region "最後參考PPSSHAPF寬度 屬性:AboutLastRefPPSSHAPF_SHA15"
            ''' <summary>
            ''' 最後參考PPSSHAPF寬度
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AboutLastRefPPSSHAPF_SHA15 As Double
                Get
                    If Not IsNothing(AboutLastRefPPSSHAPF) Then
                        Return AboutLastRefPPSSHAPF.SHA15
                    End If
                    Return Nothing
                End Get
            End Property
#End Region



#Region "設定各站預設作業資料"
            ''' <summary>
            ''' 設定各站預設作業資料
            ''' </summary>
            ''' <param name="SourceData"></param>
            ''' <remarks></remarks>
            Public Sub SetInitialWorkData(ByVal SourceData As OperationPCRunningState)
                Dim TheStationName As String = SourceData.RunPCName.ToUpper.Trim
                Select Case True
                    Case TheStationName.PadRight(3).Substring(0, 3) = "CPL"
                        SetCPLInitialWorkData()
                    Case TheStationName.PadRight(3).Substring(0, 3) = "APL"
                        SetAPLInitialWorkData()
                    Case TheStationName.PadRight(3).Substring(0, 3) = "ZML"
                        SetZMLInitialWorkData(SourceData)
                    Case TheStationName.PadRight(3).Substring(0, 3) = "GPL"
                    Case TheStationName.PadRight(3).Substring(0, 3) = "BAL"
                        SetBALInitialWorkData()
                    Case TheStationName.PadRight(3).Substring(0, 3) = "SPL"
                    Case TheStationName.PadRight(3).Substring(0, 3) = "SBL"
                    Case TheStationName.PadRight(3).Substring(0, 3) = "TLL"
                End Select
                SetCICWeightDefaultValues()
            End Sub
#End Region
#Region "設定過磅資料(襯紙/套筒/奇力龍)預設值 方法:SetCICWeightDefaultValues"
            ''' <summary>
            ''' 設定襯紙/套筒/奇力龍預設值
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function SetCICWeightDefaultValues() As Boolean
                If String.IsNullOrEmpty(FK_RunStationName) OrElse String.IsNullOrEmpty(Me.FK_LastRefSHA01) Then
                    Return False
                End If
                Static IsSuccessSetValue As Boolean = False
                Static SuccessSetCoilFullNumber As String = Nothing
                If IsSuccessSetValue AndAlso Not String.IsNullOrEmpty(SuccessSetCoilFullNumber) _
                    AndAlso SuccessSetCoilFullNumber = (Me.FK_LastRefSHA01 & Me.FK_LastRefSHA02.Trim) Then
                    Return False
                End If
                Dim TestObject As New CompanyORMDB.PPS100LB.PPSCICPF(Me.FK_RunStationName.Trim, Me.FK_LastRefSHA01 & Me.FK_LastRefSHA01.Trim)
                TestObject.SetDefaultValues(Me)

                With TestObject
                    Me.CIC11 = .CIC11
                    Me.CIC12 = .CIC12
                    Me.CIC13 = .CIC13
                    Me.CIC14 = .CIC14
                    Me.CIC15 = .CIC15
                    Me.CIC21 = .CIC21
                    Me.CIC22 = .CIC22
                    Me.CIC23 = .CIC23
                    Me.CIC24 = .CIC24
                    Me.CIC31 = .CIC31
                    Me.CIC32 = .CIC32
                    Me.CIC33 = .CIC33
                    Me.CIC34 = .CIC34
                End With
                IsSuccessSetValue = True
                SuccessSetCoilFullNumber = (Me.FK_LastRefSHA01 & Me.FK_LastRefSHA02.Trim)
                Return True
            End Function

            'CID93用途    說明              
            'A          不夾襯紙          
            'B          切頭尾，夾新襯紙  
            'C          加紙套筒          
            'D          內銷包裝          
            'E          切頭尾 8M 不夾襯紙
            'F          不切頭尾，夾襯紙  
            'G          不切頭尾，不夾襯紙
            'H          勿註明厚度        
            'I          包裝前外觀檢驗 CIC
            'J          標註實際厚度      
            'K          標註公稱厚度      
            'X          外銷包裝          
            'P          雙面 BA 
#End Region
#Region "設定ZML預設作業資料 函式:SetZMLInitialWorkData"
            ''' <summary>
            ''' 設定ZML預設作業資料(給定 第一中間/第二中間/背棍/外徑 預設值)
            ''' </summary>
            ''' <param name="SourceData"></param>
            ''' <remarks>給定 第一中間/第二中間/背棍/外徑 預設值</remarks>
            Public Sub SetZMLInitialWorkData(ByVal SourceData As OperationPCRunningState)
                If IsNothing(SourceData) Then
                    Exit Sub
                End If
                With SourceData
                    Me.ZML_SURod1 = .ZML_SURod1
                    Me.ZML_SURod3 = .ZML_SURod3
                    Me.ZML_SDRod1 = .ZML_SDRod1
                    Me.ZML_SDRod3 = .ZML_SDRod3
                    Me.ZML_MURod1 = .ZML_MURod1
                    Me.ZML_MURod2 = .ZML_MURod2
                    Me.ZML_MURod3 = .ZML_MURod3
                    Me.ZML_MDRod1 = .ZML_MDRod1
                    Me.ZML_MDRod2 = .ZML_MDRod2
                    Me.ZML_MDRod3 = .ZML_MDRod3
                    Me.ZML_BURod1 = .ZML_BURod1
                    Me.ZML_BURod2 = .ZML_BURod2
                    Me.ZML_BURod3 = .ZML_BURod3
                    Me.ZML_BURod4 = .ZML_BURod4
                    Me.ZML_BDRod1 = .ZML_BDRod1
                    Me.ZML_BDRod2 = .ZML_BDRod2
                    Me.ZML_BDRod3 = .ZML_BDRod3
                    Me.ZML_BDRod4 = .ZML_BDRod4
                    Me.ZML_AT1 = .ZML_AT1
                    Me.ZML_AT2 = .ZML_AT2
                    Me.ZML_AT3 = .ZML_AT3
                    Me.ZML_AT4 = .ZML_AT4
                    Me.ZML_AT5 = .ZML_AT5
                    Me.ZML_AT6 = .ZML_AT6
                    Me.ZML_BT1 = .ZML_BT1
                    Me.ZML_BT2 = .ZML_BT2
                    Me.ZML_BT3 = .ZML_BT3
                    Me.ZML_BT4 = .ZML_BT4
                    Me.ZML_BT5 = .ZML_BT5
                    Me.ZML_BT6 = .ZML_BT6
                    Me.ZML_CT1 = .ZML_CT1
                    Me.ZML_CT2 = .ZML_CT2
                    Me.ZML_CT3 = .ZML_CT3
                    Me.ZML_CT4 = .ZML_CT4
                    Me.ZML_CT5 = .ZML_CT5
                    Me.ZML_CT6 = .ZML_CT6
                    Me.ZML_DT1 = .ZML_DT1
                    Me.ZML_DT2 = .ZML_DT2
                    Me.ZML_DT3 = .ZML_DT3
                    Me.ZML_DT4 = .ZML_DT4
                    Me.ZML_DT5 = .ZML_DT5
                    Me.ZML_DT6 = .ZML_DT6
                    Me.ZML_ET1 = .ZML_ET1
                    Me.ZML_ET2 = .ZML_ET2
                    Me.ZML_ET3 = .ZML_ET3
                    Me.ZML_ET4 = .ZML_ET4
                    Me.ZML_ET5 = .ZML_ET5
                    Me.ZML_ET6 = .ZML_ET6
                    Me.ZML_FT1 = .ZML_FT1
                    Me.ZML_FT2 = .ZML_FT2
                    Me.ZML_FT3 = .ZML_FT3
                    Me.ZML_FT4 = .ZML_FT4
                    Me.ZML_FT5 = .ZML_FT5
                    Me.ZML_FT6 = .ZML_FT6
                    Me.ZML_GT1 = .ZML_GT1
                    Me.ZML_GT2 = .ZML_GT2
                    Me.ZML_GT3 = .ZML_GT3
                    Me.ZML_GT4 = .ZML_GT4
                    Me.ZML_GT5 = .ZML_GT5
                    Me.ZML_GT6 = .ZML_GT6
                    Me.ZML_HT1 = .ZML_HT1
                    Me.ZML_HT2 = .ZML_HT2
                    Me.ZML_HT3 = .ZML_HT3
                    Me.ZML_HT4 = .ZML_HT4
                    Me.ZML_HT5 = .ZML_HT5
                    Me.ZML_HT6 = .ZML_HT6
                End With
            End Sub
#End Region
#Region "設定CPL預設作業資料 函式:SetCPLInitialWorkData"
            ''' <summary>
            ''' 設定CPL預設作業資料
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub SetCPLInitialWorkData()
                Dim myAboutPPSBLAPF = Me.AboutPPSBLFPF

                If Not IsNothing(AboutPPSBLAPF) Then
                    Select Case True
                        Case AboutPPSBLAPF.BLA03 >= 6
                            Me.ReturnWeight = 60
                        Case AboutPPSBLAPF.BLA03 >= 5
                            Me.ReturnWeight = 50
                        Case AboutPPSBLAPF.BLA03 >= 4
                            Me.ReturnWeight = 40
                        Case Else
                            Me.ReturnWeight = 30
                    End Select
                End If

            End Sub
#End Region
#Region "設定APL預設作業資料 函式:SetAPLInitialWorkData"
            ''' <summary>
            ''' 設定APL預設作業資料
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub SetAPLInitialWorkData()
                Dim myStation As SQLServer.PPS100LB.Station = Me.AboutStation
                Dim RefPPSSHAPF As IPPS100LB.IPPSSHAPF = Me.AboutLastRefPPSSHAPF
                If IsNothing(myStation) OrElse IsNothing(RefPPSSHAPF) Then
                    Exit Sub
                End If
                If myStation.StationName.PadRight(4).Substring(0, 4).ToUpper = "APL1" Then
                    Me.ScaleWeight = 90
                    Me.ReturnWeight = RefPPSSHAPF.SHA17 Mod 100
                End If
                If myStation.StationName.PadRight(4).Substring(0, 4).ToUpper = "APL2" Then
                    Me.ScaleWeight = 50
                    Me.ReturnWeight = RefPPSSHAPF.SHA17 Mod (200 - Me.ScaleWeight)
                End If
                Me.Weight = RefPPSSHAPF.SHA17 - Me.ReturnWeight - Me.ScaleWeight
            End Sub
#End Region
#Region "設定BAL預設作業資料 函式:SetBALInitialWorkData"
            ''' <summary>
            ''' 設定BAL預設作業資料
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub SetBALInitialWorkData()
                Me.ReturnWeight = 30
            End Sub
#End Region
#Region "儲存過磅資料至AS400 方法:SaveCICWeightToAS400"
            ''' <summary>
            ''' 儲存過磅資料至AS400
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Private Function SaveCICWeightToAS400() As Boolean
                Static IsFirstRunThisFunction As Boolean = True
                Static IsThisIsServerStation As Boolean = False
                If String.IsNullOrEmpty(Me.FK_OutSHA01) OrElse String.IsNullOrEmpty(Me.FK_RunStationName) OrElse Me.FK_RunStationName.Trim.Length = 0 OrElse String.IsNullOrEmpty(Me.FK_RunStationName) Then
                    Return False
                End If
                If IsFirstRunThisFunction Then
                    IsThisIsServerStation = (RunStationPCIP.Trim = DeviceInformation.GetLocalIPs(0).Trim)
                End If
                IsFirstRunThisFunction = False
                If IsThisIsServerStation = False Then
                    Return False
                End If

                '是否有產生分捲(有分捲則刪除未分捲資料,未分捲則刪除分捲資料)
                Static RunLunDelQryTime As DateTime = New DateTime(200, 1, 1)
                Dim IsHaveBreakCoil As Boolean = ((Me.FK_LastRefSHA01 & Me.FK_LastRefSHA02).Trim <> (Me.FK_OutSHA01 & Me.FK_OutSHA02).Trim)
                If Now.Subtract(RunLunDelQryTime).TotalSeconds > 2 Then
                    Dim DeleteQry As String
                    If IsHaveBreakCoil Then
                        DeleteQry = "Delete from @#PPS100LB.PPSCICPF WHERE CIC00='" & Me.FK_RunStationName.Trim & "' AND RTRIM(CIC01 || CIC02) = '" & (Me.FK_LastRefSHA01 & Me.FK_LastRefSHA02).Trim & "' AND CIC03 >=" & New AS400DateConverter(Now.AddYears(-6)).TwIntegerTypeData
                    Else
                        DeleteQry = "Delete from @#PPS100LB.PPSCICPF WHERE CIC00='" & Me.FK_RunStationName.Trim & "' AND RTRIM(CIC01 || CIC02) <> '" & (Me.FK_LastRefSHA01 & Me.FK_LastRefSHA02).Trim & "' AND RTRIM(CIC01 || CIC02) LIKE '" & (Me.FK_LastRefSHA01 & Me.FK_LastRefSHA02).Trim & "%' AND CIC03 >=" & New AS400DateConverter(Now.AddYears(-6)).TwIntegerTypeData
                    End If
                    Dim Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, DeleteQry)
                    Adapter.ExecuteNonQuery()
                    RunLunDelQryTime = Now
                End If
                Dim QryString As String = "Select * from @#PPS100LB.PPSCICPF WHERE  CIC00='" & Me.FK_RunStationName.Trim & "' AND RTRIM(CIC01 || CIC02) = '" & (Me.FK_OutSHA01 & Me.FK_OutSHA02).Trim & "' AND CIC03 >=" & New AS400DateConverter(Now.AddYears(-6)).TwIntegerTypeData
                Dim SearchResult As List(Of CompanyORMDB.PPS100LB.PPSCICPF) = CompanyORMDB.PPS100LB.PPSCICPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSCICPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                Dim SaveObject As CompanyORMDB.PPS100LB.PPSCICPF
                If SearchResult.Count > 0 Then
                    SaveObject = SearchResult(0)
                Else
                    SaveObject = New CompanyORMDB.PPS100LB.PPSCICPF(Me.FK_RunStationName.Trim, (Me.FK_OutSHA01 & Me.FK_OutSHA02).Trim)
                End If

                With SaveObject
                    .CIC11 = Me.CIC11
                    .CIC12 = Me.CIC12
                    .CIC13 = Me.CIC13
                    .CIC14 = Me.CIC14
                    .CIC15 = Me.CIC15
                    .CIC21 = Me.CIC21
                    .CIC22 = Me.CIC22
                    .CIC23 = Me.CIC23
                    .CIC24 = Me.CIC24
                    .CIC31 = Me.CIC31
                    .CIC32 = Me.CIC32
                    .CIC33 = Me.CIC33
                    .CIC34 = Me.CIC34
                End With
                If SearchResult.Count > 0 Then
                    Return SaveObject.CDBUpdate > 0
                Else
                    Return SaveObject.CDBSave > 0
                End If
            End Function
#End Region
#Region "設定RGS日報資料 函式:SetRGSGridRecord"
            ''' <summary>
            ''' 設定RGS日報資料
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Function SetRGSGridRecord() As Boolean
                If Me.FK_RunStationName.PadRight(3).Substring(0, 3) <> "ZML" Then
                    Return False
                End If
                Dim FindBars As String = Nothing
                If Not String.IsNullOrEmpty(ZML_SURod1) AndAlso ZML_SURod1.Trim.Length > 0 Then
                    FindBars &= IIf(String.IsNullOrEmpty(FindBars), "", ",") & ZML_SURod1.Trim
                End If
                If Not String.IsNullOrEmpty(ZML_SURod2) AndAlso ZML_SURod2.Trim.Length > 0 Then
                    FindBars &= IIf(String.IsNullOrEmpty(FindBars), "", ",") & ZML_SURod2.Trim
                End If
                If Not String.IsNullOrEmpty(ZML_SURod3) AndAlso ZML_SURod3.Trim.Length > 0 Then
                    FindBars &= IIf(String.IsNullOrEmpty(FindBars), "", ",") & ZML_SURod3.Trim
                End If
                If Not String.IsNullOrEmpty(ZML_SDRod1) AndAlso ZML_SDRod1.Trim.Length > 0 Then
                    FindBars &= IIf(String.IsNullOrEmpty(FindBars), "", ",") & ZML_SDRod1.Trim
                End If
                If Not String.IsNullOrEmpty(ZML_SDRod2) AndAlso ZML_SDRod2.Trim.Length > 0 Then
                    FindBars &= IIf(String.IsNullOrEmpty(FindBars), "", ",") & ZML_SDRod2.Trim
                End If
                If Not String.IsNullOrEmpty(ZML_SDRod3) AndAlso ZML_SDRod3.Trim.Length > 0 Then
                    FindBars &= IIf(String.IsNullOrEmpty(FindBars), "", ",") & ZML_SDRod3.Trim
                End If
                If String.IsNullOrEmpty(FindBars) Then
                    Return True
                End If
                Dim QryString As String = "Select * from RGSGrindRecord Where RollerID IN ('" & FindBars.Replace(",", "','") & "') ORDER BY RollerID,DataSaveTime desc"
                Dim SearchResult As List(Of RGSGrindRecord) = RGSGrindRecord.CDBSelect(Of RGSGrindRecord)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                Dim FindRGSGrindRecord As RGSGrindRecord = Nothing
                '設定RGS日報資料
                For Each EachRollerID As String In FindBars.Split(",")
                    FindRGSGrindRecord = Nothing
                    For Each EachItem As RGSGrindRecord In SearchResult
                        If EachItem.RollerID.Trim = EachRollerID Then
                            FindRGSGrindRecord = EachItem : Exit For
                        End If
                    Next
                    If Not IsNothing(FindRGSGrindRecord) Then
                        FindRGSGrindRecord.AboutRunProcessData = Me
                        FindRGSGrindRecord.CDBSave()
                    End If
                Next
                Return True
            End Function
#End Region


            '#Region "取得某站產線時段處理之鋼捲數量 方法:GetProcessCoilCountForStation"
            '            ''' <summary>
            '            ''' 取得某站產線時段處理之鋼捲數量
            '            ''' </summary>
            '            ''' <param name="EditCoilFullNumber">排除正在編輯之鋼捲號碼</param>
            '            ''' <param name="RunStationPCIP">目正在作業之PC IP</param>
            '            ''' <param name="CoilStartTime">鋼捲CoilStart的時間</param>
            '            ''' <returns></returns>
            '            ''' <remarks></remarks>
            '            Shared Function GetProcessCoilCountForStation(ByVal EditCoilFullNumber As String, ByVal RunStationPCIP As String, ByVal CoilStartTime As DateTime) As Integer
            '                Dim FindTime As String = Format(CoilStartTime, "HH:mm:ss")
            '                Dim SearhStartTime As DateTime = CoilStartTime.Date
            '                Dim SearhEndTime As DateTime = CoilStartTime.Date
            '                Select Case True
            '                    Case FindTime >= "00:00:00" AndAlso FindTime <= "08:00:00"
            '                        SearhEndTime = SearhEndTime.AddHours(8)
            '                    Case FindTime > "08:00:00" AndAlso FindTime <= "17:00:00"
            '                        SearhStartTime = SearhStartTime.AddHours(8)
            '                        SearhEndTime = SearhEndTime.AddHours(17)
            '                    Case Else
            '                        SearhStartTime = SearhStartTime.AddHours(17)
            '                        SearhEndTime = SearhEndTime.AddHours(24)
            '                End Select
            '                '取得該時段之RunProcessData資料筆數
            '                Dim QryString As String = "Select Count(Distinct fk_lastrefsha01 + fk_lastrefsha02) From RunProcessData where RTRIM(FK_LastRefSHA01 + FK_LastRefSHA02) <> '" & Trim(EditCoilFullNumber) & "' and CoilStartTime >= '" & Format(SearhStartTime, "yyyy/MM/dd HH:mm:ss") & "' and CoilStartTime < '" & Format(SearhEndTime, "yyyy/MM/dd HH:mm:ss") & "' AND RunStationPCIP='" & RunStationPCIP & "' "
            '                Dim QryAdapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
            '                Return CType(QryAdapter.SelectQuery(QryString).Rows(0).Item(0), Integer)
            '            End Function
            '#End Region


#Region "相關黑皮檔_中鋼熱軋編號 屬性:AboutPPSBLAPF_BLA01"
            Private _AboutPPSBLAPF_BLA01 As String
            ''' <summary>
            ''' 相關黑皮檔_中鋼熱軋編號
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Property AboutPPSBLAPF_BLA01 As String
                Get
                    If String.IsNullOrEmpty(_AboutPPSBLAPF_BLA01) Then
                        Dim GetAboutPPSSHAPF As CompanyORMDB.PPS100LB.PPSBLAPF = AboutPPSBLAPF
                        If Not IsNothing(GetAboutPPSSHAPF) Then
                            _AboutPPSBLAPF_BLA01 = GetAboutPPSSHAPF.BLA01
                        End If
                    End If
                    Return _AboutPPSBLAPF_BLA01
                End Get
                Private Set(ByVal value As String)
                    _AboutPPSBLAPF_BLA01 = value
                End Set
            End Property
#End Region
#Region "相關黑皮檔_鋼種 屬性:AboutPPSBLAPF_BLA02"
            Private _AboutPPSBLAPF_BLA02 As String
            ''' <summary>
            ''' 相關黑皮檔_鋼種
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Property AboutPPSBLAPF_BLA02 As String
                Get
                    If String.IsNullOrEmpty(_AboutPPSBLAPF_BLA02) Then
                        Dim GetAboutPPSSHAPF As CompanyORMDB.PPS100LB.PPSBLAPF = AboutPPSBLAPF
                        If Not IsNothing(GetAboutPPSSHAPF) Then
                            _AboutPPSBLAPF_BLA02 = GetAboutPPSSHAPF.BLA02
                        End If
                    End If
                    Return _AboutPPSBLAPF_BLA02
                End Get
                Private Set(ByVal value As String)
                    _AboutPPSBLAPF_BLA02 = value
                End Set
            End Property
#End Region
#Region "頭尾塊指示 屬性:HeadTailDescript"
            Private _HeadTailDescript As String
            ''' <summary>
            ''' 相關黑皮檔_鋼種
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Property HeadTailDescript As String
                Get
                    If String.IsNullOrEmpty(_HeadTailDescript) Then
                        Dim GetAboutPPSSHAPF As CompanyORMDB.PPS100LB.PPSBLAPF = AboutPPSBLAPF
                        If Not IsNothing(GetAboutPPSSHAPF) Then
                            Dim GetSlabNumber As String = GetAboutPPSSHAPF.BLA07
                            Dim GetSlabNumbers() As String = GetSlabNumber.Split("-")
                            Select Case True
                                Case GetSlabNumbers.Length <= 1 OrElse GetSlabNumbers(1).Length < 4
                                    _HeadTailDescript = "鋼胚編號(" & GetSlabNumber & ")格式發生錯誤!"
                                Case GetSlabNumbers(1).Substring(1, 2) = "01"
                                    _HeadTailDescript = "頭塊"
                                Case GetSlabNumbers(1).Substring(1, 2) = "00"
                                    _HeadTailDescript = "尾塊"
                                Case Else
                                    _HeadTailDescript = "非頭尾塊(連鑄之第" & GetSlabNumbers(1).Substring(0, 1) & "爐 第" & GetSlabNumbers(1).Substring(1, 2) & "塊"
                                    If GetSlabNumbers(1).Substring(3, 1) <> 0 Then
                                        _HeadTailDescript &= "分割" & GetSlabNumbers(1).Substring(3, 1)
                                    End If
                                    _HeadTailDescript &= ")"
                            End Select
                        End If
                    End If
                    Return _HeadTailDescript
                End Get
                Private Set(ByVal value As String)
                    _HeadTailDescript = value
                End Set
            End Property

#End Region
#Region "供料厚度 屬性:InputGuage"
            ''' <summary>
            ''' InputGuage
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property InputGuage As Double
                Get
                    Dim LastRefPPSSHAPF As IPPS100LB.IPPSSHAPF = Me.AboutLastOutPPSSHAPF
                    If IsNothing(LastRefPPSSHAPF) Then
                        Return 0
                    End If
                    Return LastRefPPSSHAPF.SHA14
                End Get
            End Property
#End Region

#Region "注意事項 屬性:Attention"
            ''' <summary>
            ''' 注意事項
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property Attention As String
                Get
                    Dim ReturnValue As New System.Text.StringBuilder
                    Dim GetAboutPPSQCAPF As CompanyORMDB.PPS100LB.PPSQCAPF = AboutPPSQCAPF
                    '比對磷成份等級
                    Select Case True
                        Case IsNothing(AboutPPSQCAPF)
                            ReturnValue.AppendLine("無法取得成份資料,成份磷無法判斷!")
                        Case GetAboutPPSQCAPF.QCA10 > 0.039 AndAlso GetAboutPPSQCAPF.QCA10 <= 0.045
                            ReturnValue.AppendLine("磷高不宜做300系管料")
                        Case GetAboutPPSQCAPF.QCA10 > 0.045
                            ReturnValue.AppendLine("磷不符300系規範宜判次級品")
                    End Select
                    '氣罩異常指示
                    Dim GetSMSSGAPF As CompanyORMDB.SMS100LB.SMSSGAPF = AboutSMSSGAPF
                    If Not IsNothing(GetSMSSGAPF) Then
                        Dim ErrorCode As String = GetSMSSGAPF.SGA26
                        '錯誤代碼'1'為磷成份異常,以後之錯誤代碼則省略
                        If Not String.IsNullOrEmpty(ErrorCode) AndAlso ErrorCode <> "1" Then
                            Dim GetSMSSGEPF As CompanyORMDB.SMS100LB.SMSSGEPF = GetSMSSGAPF.AboutSMSSGEPF
                            If Not IsNothing(GetSMSSGEPF) Then
                                ErrorCode = Nothing
                                For Each EachItem As Char In GetSMSSGEPF.SGE11.ToCharArray
                                    If EachItem = "1" Then
                                        Exit For
                                    End If
                                    ErrorCode &= EachItem
                                    If ErrorCode.Length >= 2 Then
                                        Exit For
                                    End If
                                Next
                            End If
                            For Each EachItem As Char In ErrorCode.ToCharArray
                                Select Case EachItem
                                    Case "2"
                                        ReturnValue.AppendLine("#2氣罩異常宜派做管料")
                                    Case "3"
                                        ReturnValue.AppendLine("#3鋼液互混宜派做管料")
                                    Case "4"
                                        ReturnValue.AppendLine("#4自動澆鑄控制異常宜派做管料")
                                    Case "5"
                                        ReturnValue.AppendLine("#5澆鑄管異常宜派做管料")
                                    Case Else
                                End Select
                            Next
                        End If
                    End If

                    '回切
                    If Not IsNothing(GetSMSSGAPF) AndAlso GetSMSSGAPF.SGA27 > 0 Then
                        ReturnValue.AppendLine("煉鋼回切")
                    End If

                    '適合做304硬片
                    Dim GetAboutPPSBLAPF As CompanyORMDB.PPS100LB.PPSBLAPF = Nothing
                    If IsNothing(GetAboutPPSQCAPF) Then
                        ReturnValue.AppendLine("未找到成份資料無法判斷是否適合做304硬片/低碳鋼種/304-BA...!")
                    Else
                        GetAboutPPSBLAPF = Me.AboutPPSBLAPF
                        If IsNothing(GetAboutPPSBLAPF) Then
                            ReturnValue.AppendLine("未找到黑皮資料無法判斷是否適合做304硬片/低碳鋼種/304-BA...!")
                        Else
                            If Trim(GetAboutPPSBLAPF.BLA02) = "304" Then
                                Dim QCA0725 As Double = GetAboutPPSQCAPF.QCA07 + GetAboutPPSQCAPF.QCA25
                                If GetAboutPPSBLAPF.BLA03 >= 3.7 _
                                    AndAlso GetAboutPPSBLAPF.BLA03 <= 4 _
                                    AndAlso GetAboutPPSQCAPF.QCA07 >= 0.04 _
                                    AndAlso GetAboutPPSQCAPF.QCA07 <= 0.055 _
                                    AndAlso GetAboutPPSQCAPF.QCA25 >= 0.04 _
                                    AndAlso GetAboutPPSQCAPF.QCA25 <= 0.055 _
                                    AndAlso QCA0725 >= 0.08 _
                                    AndAlso QCA0725 <= 0.11 _
                                    AndAlso GetAboutPPSQCAPF.QCA12 >= 18.2 _
                                    AndAlso GetAboutPPSQCAPF.QCA12 <= 18.4 _
                                    AndAlso GetAboutPPSQCAPF.QCA13 >= 8.1 _
                                    AndAlso GetAboutPPSQCAPF.QCA13 <= 8.3 Then
                                    ReturnValue.AppendLine("適合做304硬片!")
                                End If
                            End If
                        End If
                    End If

                    '碳高不宜做低碳鋼種
                    If Not IsNothing(GetAboutPPSBLAPF) AndAlso Not IsNothing(GetAboutPPSQCAPF) _
                        AndAlso GetAboutPPSBLAPF.BLA02.Trim = "304L" AndAlso GetAboutPPSQCAPF.QCA07 > 0.03 Then
                        ReturnValue.AppendLine("碳高不宜做低碳鋼種!")
                    End If

                    '硼高不宜做304-BA
                    If Not IsNothing(GetAboutPPSBLAPF) AndAlso Not IsNothing(GetAboutPPSQCAPF) _
                        AndAlso GetAboutPPSBLAPF.BLA02.Trim = "304" AndAlso GetAboutPPSQCAPF.QCA27 > 0.0015 Then
                        ReturnValue.AppendLine("硼高不宜做304-BA!")
                    End If

                    '301鋼種C/N/NI超出管制範圍
                    If Not IsNothing(GetAboutPPSBLAPF) AndAlso Not IsNothing(GetAboutPPSQCAPF) AndAlso GetAboutPPSBLAPF.BLA02.Trim = "301" Then
                        Dim CA0725 As Double = GetAboutPPSQCAPF.QCA07 + GetAboutPPSQCAPF.QCA25
                        If GetAboutPPSQCAPF.QCA07 < 0.085 _
                            Or GetAboutPPSQCAPF.QCA07 > 0.105 _
                            Or GetAboutPPSQCAPF.QCA25 < 0.025 _
                            Or GetAboutPPSQCAPF.QCA25 > 0.045 _
                            Or CA0725 > 0.11 _
                            Or CA0725 < 0.15 Then
                            ReturnValue.AppendLine("301鋼種C/N/NI超出管制範圍!")
                        End If
                    End If

                    'MD30高不宜做304抽料
                    If Not IsNothing(GetAboutPPSQCAPF) AndAlso GetAboutPPSQCAPF.MD30 > 31 Then
                        ReturnValue.AppendLine("MD30高不宜做低碳鋼種!")
                    End If

                    'DF低不宜做304抽料
                    If Not IsNothing(GetAboutPPSQCAPF) AndAlso GetAboutPPSQCAPF.DF < 3.5 Then
                        ReturnValue.AppendLine("DF低不宜做304抽料!")
                    End If

                    '熱軋疤良或輥痕不宜做NO1
                    Dim GetAboutPPSBLFPF As CompanyORMDB.PPS100LB.PPSBLFPF = Me.AboutPPSBLFPF
                    If Not IsNothing(GetAboutPPSBLFPF) AndAlso GetAboutPPSBLFPF.BLF11 = "N" Then
                        ReturnValue.AppendLine("熱軋疤良或輥痕不宜做NO1!")
                    End If

                    '熱軋檢出剝片
                    If Not IsNothing(GetAboutPPSBLFPF) AndAlso GetAboutPPSBLFPF.BLF13.Trim = "S02A" Then
                        ReturnValue.AppendLine("熱軋檢出剝片!")
                    End If

                    '中鋼重捲NO1注意熱軋鑿痕片形
                    If Not IsNothing(GetAboutPPSBLAPF) AndAlso GetAboutPPSBLAPF.BLA16.Trim = "12" Then
                        ReturnValue.AppendLine("中鋼重捲NO1注意熱軋鑿痕片形!")
                    End If
                    '中鋼會判NO1注意裂邊片形
                    If Not IsNothing(GetAboutPPSBLAPF) AndAlso GetAboutPPSBLAPF.BLA16.Trim = "20" Then
                        ReturnValue.AppendLine("中鋼會判NO1注意裂邊片形!")
                    End If
                    Return ReturnValue.ToString
                End Get
            End Property
#End Region



#Region "以RunProcessData更新PPSSHAPF資料 函式:ReplacePPSSHAPFForRunProcessData"
            ''' <summary>
            ''' 以RunProcessData更新PPSSHAPF資料
            ''' </summary>
            ''' <param name="OrginData"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Function ReplacePPSSHAPFForRunProcessData(ByVal OrginData As IPPS100LB.IPPSSHAPF) As IPPS100LB.IPPSSHAPF
                Me.AboutLastOutPPSSHAPF = OrginData
                With OrginData
                    .SHA11 = New AS400DateConverter(Me.CoilEndTime).TwIntegerTypeData
                    .SHA01 = FK_OutSHA01
                    .SHA02 = FK_OutSHA02
                    .SHA14 = IIf(Guage <> 0, Guage, .SHA14)
                    .SHA15 = IIf(Width <> 0, Width, .SHA15)
                    .SHA16 = IIf(Length <> 0, Length, .SHA16)
                    .SHA17 = IIf(Weight <> 0, Weight, .SHA17)
                    .SHA18 = IIf(ReturnWeight <> 0, ReturnWeight, .SHA18)
                    .SHA19 = IIf(ScaleWeight <> 0, ScaleWeight, .SHA19)
                    .SHA20 = IIf(OtherWeight <> 0, OtherWeight, .SHA20)
                End With
                AddHandler OrginData.CDBDataInsertUpdateDeletedEvent, AddressOf AboutIPPSSHAPFDataInsertUpdateDeleted
                Return OrginData
            End Function

            Private Sub AboutIPPSSHAPFDataInsertUpdateDeleted(ByVal DBObject As ClassDB, ByVal DataInsertUpdateDeleteKind As IClassDBInherited.DataInsertUpdateDeleteType)
                If DataInsertUpdateDeleteKind = IClassDBInherited.DataInsertUpdateDeleteType.Insert OrElse DataInsertUpdateDeleteKind = IClassDBInherited.DataInsertUpdateDeleteType.Update Then
                    Me.CDBSave()
                End If
            End Sub
#End Region


#Region "群組資料儲存 Shared函式:CDBSaveGroupData"
            ''' <summary>
            ''' 群組資料儲存
            ''' </summary>
            ''' <param name="SaveDatas"></param>
            ''' <remarks></remarks>
            Public Shared Function CDBSaveGroupData(ByVal SaveDatas As List(Of RunProcessData)) As Integer
                If SaveDatas.Count = 0 Then
                    Exit Function
                End If
                Dim LastRefPPSSHAPFs As PPSSHAPF = SaveDatas(0).AboutLastRefPPSSHAPF
                Dim FinalSaveTempDatas As New Dictionary(Of String, RunProcessData)
                For Each EachItem As RunProcessData In SaveDatas
                    If EachItem._FK_LastRefSHA01.Trim <> LastRefPPSSHAPFs.SHA01.Trim OrElse EachItem._FK_LastRefSHA02.Trim <> LastRefPPSSHAPFs.SHA02.Trim AndAlso EachItem._FK_LastRefSHA04 <> LastRefPPSSHAPFs.SHA04 Then
                        Throw New Exception("儲存群組資料中有其中一筆沒有共同的LastRefPPSSHAPF")
                    End If
                    If FinalSaveTempDatas.ContainsKey(EachItem.ID) = False Then
                        FinalSaveTempDatas.Add(EachItem.ID, EachItem)
                    End If
                Next
                For Each EachItem As RunProcessData In GetRunProcessDatasFromLastRefPPSSHAPF(LastRefPPSSHAPFs)
                    If FinalSaveTempDatas.ContainsKey(EachItem.ID) = False Then
                        FinalSaveTempDatas.Add(EachItem.ID, EachItem)
                    End If
                Next
                Dim FinalSaveDatas As New List(Of RunProcessData)
                For Each EachItem As RunProcessData In FinalSaveTempDatas.Values
                    FinalSaveDatas.Add(EachItem)
                Next
                ReOrderBreakCoilNumber(FinalSaveDatas)
                Dim ReturnValue As Integer = 0
                For Each EachItem As RunProcessData In FinalSaveDatas
                    ReturnValue += EachItem.CDBSave
                Next
                Return ReturnValue
            End Function
#Region "重整分捲順序 Shared函式:ReOrderBreakCoilNumber"
            ''' <summary>
            ''' 重整分捲順序
            ''' </summary>
            ''' <param name="ReOrderDatas"></param>
            ''' <remarks></remarks>
            Private Shared Sub ReOrderBreakCoilNumber(ByVal ReOrderDatas As List(Of RunProcessData))
                Dim SetNumber As Integer = 1
                For Each EachItem As RunProcessData In ReOrderDatas
                    EachItem.BreakCoilNumber = SetNumber
                    SetNumber += 1
                Next
            End Sub
#End Region
#End Region

#Region "覆寫儲存新增 函式:CDBInsert"
            ''' <summary>
            ''' 覆寫儲存新增
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Overrides Function CDBInsert() As Integer
                SaveCICWeightToAS400()
                SetRGSGridRecord()      '設定RGS日報資料,只有ZML會執行
                Return MyBase.CDBInsert()
            End Function
#End Region

#Region "覆寫儲存更新 函式:CDBUpdate"
            ''' <summary>
            ''' 覆寫儲存更新
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Overrides Function CDBUpdate() As Integer
                SaveCICWeightToAS400()
                SetRGSGridRecord()      '設定RGS日報資料,只有ZML會執行
                Return MyBase.CDBUpdate()
            End Function
#End Region

#Region "覆寫刪除 函式:CDBDelete"
            ''' <summary>
            ''' 覆寫刪除
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Overrides Function CDBDelete() As Integer
                Dim DeleteQry = "Delete from @#PPS100LB.PPSCICPF WHERE CIC00='" & Me.FK_RunStationName.Trim & "' AND RTRIM(CIC01 || CIC02) = '" & (Me.FK_OutSHA01 & Me.FK_OutSHA02).Trim & "' AND CIC03 >=" & New AS400DateConverter(Now.AddYears(-6)).TwIntegerTypeData
                Dim Adapter As New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, DeleteQry)
                Adapter.ExecuteNonQuery()

                DeleteQry = "Delete from RunProcessQCTitle WHERE FK_RunProcessDataID='" & Me.ID & "'"
                Dim SQLAdapter As New SQLServerSQLQueryAdapter(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "PPS100LB")
                SQLAdapter.ExecuteNonQuery(DeleteQry)
                DeleteQry = "Delete from RunProcessQCDetail WHERE FK_RunProcessDataID='" & Me.ID & "'"
                SQLAdapter.ExecuteNonQuery(DeleteQry)

                Return MyBase.CDBDelete()
            End Function
#End Region


        End Class
    End Namespace
End Namespace