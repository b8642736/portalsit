Namespace SMS100LB
Public Class SMSC2PF
	Inherits ClassDBAS400

	Sub New()
            MyBase.New("SMS100LB", GetType(SMSC2PF).Name)
            Me.T3 = (Val(Format(Now, "yyyy")) - 1911) * 10000 + Val(Format(Now, "MMdd"))
            Me.IsFistAddNewData = True
            Me.SQLQueryAdapterByThisObject = New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        End Sub

#Region "爐號 屬性:T1"
	Private _T1 As System.String
	''' <summary>
	''' 爐號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property T1 () As System.String
		Get
			Return _T1
		End Get
            Set(ByVal value As System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T1 = value
            End Set
	End Property
#End Region
#Region "溫度及重量記錄表日期 屬性:T2"
        Private _T2 As System.Int32
        ''' <summary>
        ''' 溫度及重量記錄表日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property T2() As System.Int32
            Get
                Return _T2
            End Get
            Set(ByVal value As System.Int32)
                _T2 = value
            End Set
        End Property
#End Region
#Region "澆鑄日期 屬性:T3"
	Private _T3 As System.Int32
	''' <summary>
	''' 澆鑄日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T3 () As System.Int32
		Get
			Return _T3
		End Get
		Set(Byval value as System.Int32)
			_T3 = value
		End Set
	End Property
#End Region
#Region "班別 屬性:T4"
	Private _T4 As System.String
	''' <summary>
	''' 班別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T4 () As System.String
		Get
			Return _T4
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T4 = value
		End Set
	End Property
#End Region
#Region "鋼胚厚度 屬性:T5"
	Private _T5 As System.Int32
	''' <summary>
	''' 鋼胚厚度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T5 () As System.Int32
		Get
			Return _T5
		End Get
		Set(Byval value as System.Int32)
			_T5 = value
		End Set
	End Property
#End Region
#Region "鋼胚寬度 屬性:T6"
	Private _T6 As System.Int32
	''' <summary>
	''' 鋼胚寬度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T6 () As System.Int32
		Get
			Return _T6
		End Get
		Set(Byval value as System.Int32)
			_T6 = value
		End Set
	End Property
#End Region
#Region "鑄造號碼 屬性:T7"
	Private _T7 As System.String
	''' <summary>
	''' 鑄造號碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T7 () As System.String
		Get
			Return _T7
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T7 = value
		End Set
	End Property
#End Region
#Region "TD記錄員 屬性:T8"
        Private _T8 As String
        ''' <summary>
        ''' TD記錄員
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T8() As String
            Get
                Return _T8
            End Get
            Set(ByVal value As String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T8 = value
            End Set
        End Property
#End Region
#Region "液高設定% 屬性:T9"
	Private _T9 As System.Int32
	''' <summary>
	''' 液高設定%
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T9 () As System.Int32
		Get
			Return _T9
		End Get
		Set(Byval value as System.Int32)
			_T9 = value
		End Set
	End Property
#End Region
#Region "澆鑄粉末種類 屬性:T10"
        Private _T10 As System.Int32
	''' <summary>
	''' 澆鑄粉末種類
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
        Public Property T10() As System.Int32
            Get
                Return _T10
            End Get
            Set(ByVal value As System.Int32)
                _T10 = value
            End Set
        End Property
#End Region
#Region "澆鑄粉末用量 屬性:T11"
	Private _T11 As System.Single
	''' <summary>
	''' 澆鑄粉末用量
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T11 () As System.Single
		Get
			Return _T11
		End Get
		Set(Byval value as System.Single)
			_T11 = value
		End Set
	End Property
#End Region
#Region "盛鋼桶S/G開 屬性:T12"
	Private _T12 As System.String
	''' <summary>
	''' 盛鋼桶S/G開
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T12 () As System.String
		Get
			Return _T12
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T12 = value
		End Set
	End Property
#End Region
#Region "分鋼糟開 屬性:T13"
	Private _T13 As System.String
	''' <summary>
	''' 分鋼糟開
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T13 () As System.String
		Get
			Return _T13
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T13 = value
		End Set
	End Property
#End Region
#Region "引拔開始 屬性:T14"
	Private _T14 As System.String
	''' <summary>
	''' 引拔開始
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T14 () As System.String
		Get
			Return _T14
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T14 = value
		End Set
	End Property
#End Region
#Region "自動澆鑄開始 屬性:T15"
	Private _T15 As System.String
	''' <summary>
	''' 自動澆鑄開始
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T15 () As System.String
		Get
			Return _T15
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T15 = value
		End Set
	End Property
#End Region
#Region "盛鋼桶S/G關 屬性:T16"
	Private _T16 As System.String
	''' <summary>
	''' 盛鋼桶S/G關
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T16 () As System.String
		Get
			Return _T16
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T16 = value
		End Set
	End Property
#End Region
#Region "S/G關T/D重量 屬性:T17"
	Private _T17 As System.Single
	''' <summary>
	''' S/G關T/D重量
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T17 () As System.Single
		Get
			Return _T17
		End Get
		Set(Byval value as System.Single)
			_T17 = value
		End Set
	End Property
#End Region
#Region "自動澆鑄結束 屬性:T18"
	Private _T18 As System.String
	''' <summary>
	''' 自動澆鑄結束
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T18 () As System.String
		Get
			Return _T18
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T18 = value
		End Set
	End Property
#End Region
#Region "停止澆鑄 屬性:T19"
	Private _T19 As System.String
	''' <summary>
	''' 停止澆鑄
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T19 () As System.String
		Get
			Return _T19
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T19 = value
		End Set
	End Property
#End Region
#Region "鑄造長度M 屬性:T20"
	Private _T20 As System.Single
	''' <summary>
	''' 鑄造長度M
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T20 () As System.Single
		Get
			Return _T20
		End Get
		Set(Byval value as System.Single)
			_T20 = value
		End Set
	End Property
#End Region
#Region "模號 屬性:T21"
	Private _T21 As System.String
	''' <summary>
	''' 模號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T21 () As System.String
		Get
			Return _T21
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T21 = value
		End Set
	End Property
#End Region
#Region "使用回數 屬性:T22"
	Private _T22 As System.Int32
	''' <summary>
	''' 使用回數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T22 () As System.Int32
		Get
			Return _T22
		End Get
		Set(Byval value as System.Int32)
			_T22 = value
		End Set
	End Property
#End Region
#Region "上模口寬度 屬性:T23"
	Private _T23 As System.Single
	''' <summary>
	''' 上模口寬度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T23 () As System.Single
		Get
			Return _T23
		End Get
		Set(Byval value as System.Single)
			_T23 = value
		End Set
	End Property
#End Region
#Region "下模口寬度 屬性:T24"
	Private _T24 As System.Single
	''' <summary>
	''' 下模口寬度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T24 () As System.Single
		Get
			Return _T24
		End Get
		Set(Byval value as System.Single)
			_T24 = value
		End Set
	End Property
#End Region
#Region "模斜度 屬性:T25"
	Private _T25 As System.Single
	''' <summary>
	''' 模斜度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T25 () As System.Single
		Get
			Return _T25
		End Get
		Set(Byval value as System.Single)
			_T25 = value
		End Set
	End Property
#End Region
#Region "振動振幅 屬性:T26"
	Private _T26 As System.Single
	''' <summary>
	''' 振動振幅
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T26 () As System.Single
		Get
			Return _T26
		End Get
		Set(Byval value as System.Single)
			_T26 = value
		End Set
	End Property
#End Region
#Region "負性脫模係數% 屬性:T27"
	Private _T27 As System.Int32
	''' <summary>
	''' 負性脫模係數%
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T27 () As System.Int32
		Get
			Return _T27
		End Get
		Set(Byval value as System.Int32)
			_T27 = value
		End Set
	End Property
#End Region
#Region "冷卻水流量CL1 屬性:T28"
	Private _T28 As System.Int32
	''' <summary>
	''' 冷卻水流量CL1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T28 () As System.Int32
		Get
			Return _T28
		End Get
		Set(Byval value as System.Int32)
			_T28 = value
		End Set
	End Property
#End Region
#Region "冷卻水流量CL2 屬性:T29"
	Private _T29 As System.Int32
	''' <summary>
	''' 冷卻水流量CL2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T29 () As System.Int32
		Get
			Return _T29
		End Get
		Set(Byval value as System.Int32)
			_T29 = value
		End Set
	End Property
#End Region
#Region "冷卻水流量CL3 屬性:T30"
	Private _T30 As System.Int32
	''' <summary>
	''' 冷卻水流量CL3
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T30 () As System.Int32
		Get
			Return _T30
		End Get
		Set(Byval value as System.Int32)
			_T30 = value
		End Set
	End Property
#End Region
#Region "冷卻水流量CL4 屬性:T31"
	Private _T31 As System.Int32
	''' <summary>
	''' 冷卻水流量CL4
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T31 () As System.Int32
		Get
			Return _T31
		End Get
		Set(Byval value as System.Int32)
			_T31 = value
		End Set
	End Property
#End Region
#Region "分鋼槽號碼 屬性:T32"
	Private _T32 As System.Int32
	''' <summary>
	''' 分鋼槽號碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T32 () As System.Int32
		Get
			Return _T32
		End Get
		Set(Byval value as System.Int32)
			_T32 = value
		End Set
	End Property
#End Region
#Region "分鋼槽預熱開始 屬性:T33"
	Private _T33 As System.String
	''' <summary>
	''' 分鋼槽預熱開始
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T33 () As System.String
		Get
			Return _T33
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T33 = value
		End Set
	End Property
#End Region
#Region "分鋼槽預熱結束 屬性:T34"
	Private _T34 As System.String
	''' <summary>
	''' 分鋼槽預熱結束
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T34 () As System.String
		Get
			Return _T34
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T34 = value
		End Set
	End Property
#End Region
#Region "鑄管型態 屬性:T35"
	Private _T35 As System.String
	''' <summary>
	''' 鑄管型態
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T35 () As System.String
		Get
			Return _T35
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T35 = value
		End Set
	End Property
#End Region
#Region "鑄管孔型 屬性:T36"
	Private _T36 As System.String
	''' <summary>
	''' 鑄管孔型
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T36 () As System.String
		Get
			Return _T36
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T36 = value
		End Set
	End Property
#End Region
#Region "澆鑄管預熱開始 屬性:T37"
	Private _T37 As System.String
	''' <summary>
	''' 澆鑄管預熱開始
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T37 () As System.String
		Get
			Return _T37
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T37 = value
		End Set
	End Property
#End Region
#Region "澆鑄管預熱結束 屬性:T38"
	Private _T38 As System.String
	''' <summary>
	''' 澆鑄管預熱結束
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T38 () As System.String
		Get
			Return _T38
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T38 = value
		End Set
	End Property
#End Region
#Region "二水澆鑄速度1 屬性:T39"
	Private _T39 As System.Single
	''' <summary>
	''' 二水澆鑄速度1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T39 () As System.Single
		Get
			Return _T39
		End Get
		Set(Byval value as System.Single)
			_T39 = value
		End Set
	End Property
#End Region
#Region "二水澆鑄速度2 屬性:T40"
	Private _T40 As System.Single
	''' <summary>
	''' 二水澆鑄速度2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T40 () As System.Single
		Get
			Return _T40
		End Get
		Set(Byval value as System.Single)
			_T40 = value
		End Set
	End Property
#End Region
#Region "二水噴水量MS1 屬性:T41"
	Private _T41 As System.Int32
	''' <summary>
	''' 二水噴水量MS1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T41 () As System.Int32
		Get
			Return _T41
		End Get
		Set(Byval value as System.Int32)
			_T41 = value
		End Set
	End Property
#End Region
#Region "二水噴水量MS2 屬性:T42"
	Private _T42 As System.Int32
	''' <summary>
	''' 二水噴水量MS2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T42 () As System.Int32
		Get
			Return _T42
		End Get
		Set(Byval value as System.Int32)
			_T42 = value
		End Set
	End Property
#End Region
#Region "二水噴水量1A1 屬性:T43"
	Private _T43 As System.Int32
	''' <summary>
	''' 二水噴水量1A1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T43 () As System.Int32
		Get
			Return _T43
		End Get
		Set(Byval value as System.Int32)
			_T43 = value
		End Set
	End Property
#End Region
#Region "二水噴水量1A2 屬性:T44"
	Private _T44 As System.Int32
	''' <summary>
	''' 二水噴水量1A2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T44 () As System.Int32
		Get
			Return _T44
		End Get
		Set(Byval value as System.Int32)
			_T44 = value
		End Set
	End Property
#End Region
#Region "二水噴水量1B1 屬性:T45"
	Private _T45 As System.Int32
	''' <summary>
	''' 二水噴水量1B1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T45 () As System.Int32
		Get
			Return _T45
		End Get
		Set(Byval value as System.Int32)
			_T45 = value
		End Set
	End Property
#End Region
#Region "二水噴水量1B2 屬性:T46"
	Private _T46 As System.Int32
	''' <summary>
	''' 二水噴水量1B2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T46 () As System.Int32
		Get
			Return _T46
		End Get
		Set(Byval value as System.Int32)
			_T46 = value
		End Set
	End Property
#End Region
#Region "二水噴水量NS1 屬性:T47"
	Private _T47 As System.Int32
	''' <summary>
	''' 二水噴水量NS1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T47 () As System.Int32
		Get
			Return _T47
		End Get
		Set(Byval value as System.Int32)
			_T47 = value
		End Set
	End Property
#End Region
#Region "二水噴水量NS2 屬性:T48"
	Private _T48 As System.Int32
	''' <summary>
	''' 二水噴水量NS2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T48 () As System.Int32
		Get
			Return _T48
		End Get
		Set(Byval value as System.Int32)
			_T48 = value
		End Set
	End Property
#End Region
#Region "二水噴水量2FS1 屬性:T49"
	Private _T49 As System.Int32
	''' <summary>
	''' 二水噴水量2FS1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T49 () As System.Int32
		Get
			Return _T49
		End Get
		Set(Byval value as System.Int32)
			_T49 = value
		End Set
	End Property
#End Region
#Region "二水噴水量2FS2 屬性:T50"
	Private _T50 As System.Int32
	''' <summary>
	''' 二水噴水量2FS2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T50 () As System.Int32
		Get
			Return _T50
		End Get
		Set(Byval value as System.Int32)
			_T50 = value
		End Set
	End Property
#End Region
#Region "二水噴水量2LS1 屬性:T51"
	Private _T51 As System.Int32
	''' <summary>
	''' 二水噴水量2LS1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T51 () As System.Int32
		Get
			Return _T51
		End Get
		Set(Byval value as System.Int32)
			_T51 = value
		End Set
	End Property
#End Region
#Region "二水噴水量2LS2 屬性:T52"
	Private _T52 As System.Int32
	''' <summary>
	''' 二水噴水量2LS2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T52 () As System.Int32
		Get
			Return _T52
		End Get
		Set(Byval value as System.Int32)
			_T52 = value
		End Set
	End Property
#End Region
#Region "二水噴水量3FS1 屬性:T53"
	Private _T53 As System.Int32
	''' <summary>
	''' 二水噴水量3FS1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T53 () As System.Int32
		Get
			Return _T53
		End Get
		Set(Byval value as System.Int32)
			_T53 = value
		End Set
	End Property
#End Region
#Region "二水噴水量3FS2 屬性:T54"
	Private _T54 As System.Int32
	''' <summary>
	''' 二水噴水量3FS2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T54 () As System.Int32
		Get
			Return _T54
		End Get
		Set(Byval value as System.Int32)
			_T54 = value
		End Set
	End Property
#End Region
#Region "二水噴水量3LS1 屬性:T55"
	Private _T55 As System.Int32
	''' <summary>
	''' 二水噴水量3LS1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T55 () As System.Int32
		Get
			Return _T55
		End Get
		Set(Byval value as System.Int32)
			_T55 = value
		End Set
	End Property
#End Region
#Region "二水噴水量3LS2 屬性:T56"
	Private _T56 As System.Int32
	''' <summary>
	''' 二水噴水量3LS2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T56 () As System.Int32
		Get
			Return _T56
		End Get
		Set(Byval value as System.Int32)
			_T56 = value
		End Set
	End Property
#End Region
#Region "二水噴水量4FS1 屬性:T57"
	Private _T57 As System.Int32
	''' <summary>
	''' 二水噴水量4FS1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T57 () As System.Int32
		Get
			Return _T57
		End Get
		Set(Byval value as System.Int32)
			_T57 = value
		End Set
	End Property
#End Region
#Region "二水噴水量4FS2 屬性:T58"
	Private _T58 As System.Int32
	''' <summary>
	''' 二水噴水量4FS2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T58 () As System.Int32
		Get
			Return _T58
		End Get
		Set(Byval value as System.Int32)
			_T58 = value
		End Set
	End Property
#End Region
#Region "二水噴水量4LS1 屬性:T59"
	Private _T59 As System.Int32
	''' <summary>
	''' 二水噴水量4LS1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T59 () As System.Int32
		Get
			Return _T59
		End Get
		Set(Byval value as System.Int32)
			_T59 = value
		End Set
	End Property
#End Region
#Region "二水噴水量4LS2 屬性:T60"
	Private _T60 As System.Int32
	''' <summary>
	''' 二水噴水量4LS2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T60 () As System.Int32
		Get
			Return _T60
		End Get
		Set(Byval value as System.Int32)
			_T60 = value
		End Set
	End Property
#End Region
#Region "模冷卻水溫度 屬性:T61"
	Private _T61 As System.Int32
	''' <summary>
	''' 模冷卻水溫度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T61 () As System.Int32
		Get
			Return _T61
		End Get
		Set(Byval value as System.Int32)
			_T61 = value
		End Set
	End Property
#End Region
#Region "模冷卻水壓力 屬性:T62"
	Private _T62 As System.Single
	''' <summary>
	''' 模冷卻水壓力
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T62 () As System.Single
		Get
			Return _T62
		End Get
		Set(Byval value as System.Single)
			_T62 = value
		End Set
	End Property
#End Region
#Region "噴水壓力 屬性:T63"
	Private _T63 As System.Single
	''' <summary>
	''' 噴水壓力
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T63 () As System.Single
		Get
			Return _T63
		End Get
		Set(Byval value as System.Single)
			_T63 = value
		End Set
	End Property
#End Region
#Region "噴水入溫 屬性:T64"
	Private _T64 As System.Int32
	''' <summary>
	''' 噴水入溫
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T64 () As System.Int32
		Get
			Return _T64
		End Get
		Set(Byval value as System.Int32)
			_T64 = value
		End Set
	End Property
#End Region
#Region "盛鋼桶總重(t) 屬性:T65"
        Private _T65 As System.Single
        ''' <summary>
        ''' 盛鋼桶總重(t)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T65() As System.Single
            Get
                Return _T65
            End Get
            Set(ByVal value As System.Single)
                _T65 = value
            End Set
        End Property
#End Region
#Region "鋼液重(t) 屬性:T66"
        Private _T66 As System.Single
        ''' <summary>
        ''' 鋼液重(t)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T66() As System.Single
            Get
                Return _T66
            End Get
            Set(ByVal value As System.Single)
                _T66 = value
            End Set
        End Property
#End Region
#Region "分鋼槽殘重(t) 屬性:T67"
        Private _T67 As System.Single
        ''' <summary>
        ''' 分鋼槽殘重(t)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T67() As System.Single
            Get
                Return _T67
            End Get
            Set(ByVal value As System.Single)
                _T67 = value
            End Set
        End Property
#End Region
#Region "分鋼槽台車號碼 屬性:T68"
	Private _T68 As System.String
	''' <summary>
	''' 分鋼槽台車號碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T68 () As System.String
		Get
			Return _T68
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T68 = value
		End Set
	End Property
#End Region
#Region "氣罩回數 屬性:T69"
	Private _T69 As System.Int32
	''' <summary>
	''' 氣罩回數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T69 () As System.Int32
		Get
			Return _T69
		End Get
		Set(Byval value as System.Int32)
			_T69 = value
		End Set
	End Property
#End Region
#Region "備註 屬性:T70"
	Private _T70 As System.String
	''' <summary>
	''' 備註
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T70 () As System.String
		Get
			Return _T70
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T70 = value
		End Set
	End Property
#End Region
#Region "記錄員 屬性:T71"
	Private _T71 As System.String
	''' <summary>
	''' 記錄員
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T71 () As System.String
		Get
			Return _T71
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T71 = value
		End Set
	End Property
#End Region
#Region "班長 屬性:T72"
	Private _T72 As System.String
	''' <summary>
	''' 班長
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T72 () As System.String
		Get
			Return _T72
		End Get
		Set(Byval value as System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T72 = value
		End Set
	End Property
#End Region
#Region "TD測溫備註事項 屬性:T73"
        Private _T73 As System.String
        ''' <summary>
        ''' TD測溫備註事項
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T73() As System.String
            Get
                Return _T73
            End Get
            Set(ByVal value As System.String)
                If Not String.IsNullOrEmpty(value) Then
                    value = value.Trim
                End If
                _T73 = value
            End Set
        End Property
#End Region


#Region "盛鋼槽殘重(t) 屬性:T65SubT66Weight"
        ''' <summary>
        ''' 盛鋼槽殘重(t)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T65SubT66Weight As Single
            Get
                If T65 <= 0 OrElse T66 <= 0 Then
                    Return -1
                End If
                Return T65 - T66
            End Get
        End Property
#End Region
#Region "分鋼槽預熱時間 屬性:T34SubT33Times"
        ''' <summary>
        ''' 分鋼槽預熱時間
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T34SubT33Times As Integer
            Get
                If String.IsNullOrEmpty(T33) OrElse String.IsNullOrEmpty(T34) Then
                    Return 0
                End If
                Dim StartTime As DateTime = CType("2000/1/1 " & Format(Val(T33), "00:00") & ":00", DateTime)
                Dim EndTime As DateTime = CType("2000/1/1 " & Format(Val(T34), "00:00") & ":00", DateTime)
                If EndTime <= StartTime Then
                    EndTime = EndTime.AddDays(1)
                End If
                Return EndTime.Subtract(StartTime).TotalMinutes
            End Get
        End Property
#End Region
#Region "澆鑄管預熱時間 屬性:T38SubT37Times"
        ''' <summary>
        ''' 澆鑄管預熱時間
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T38SubT37Times As Integer
            Get
                If String.IsNullOrEmpty(T37) OrElse String.IsNullOrEmpty(T38) Then
                    Return 0
                End If
                Dim StartTime As DateTime = CType("2000/1/1 " & Format(Val(T37), "00:00") & ":00", DateTime)
                Dim EndTime As DateTime = CType("2000/1/1 " & Format(Val(T38), "00:00") & ":00", DateTime)
                If EndTime <= StartTime Then
                    EndTime = EndTime.AddDays(1)
                End If
                Return EndTime.Subtract(StartTime).TotalMinutes
            End Get
        End Property
#End Region



#Region "是否為第一次新增之資料 屬性:IsFistAddNewData"
        ''' <summary>
        ''' 是否為第一次新增之資料
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property IsFistAddNewData As Boolean
#End Region
#Region "相關分鋼槽液溫及振動記錄 屬性:AboutSMSC21PFs"
        Private _AboutSMSC21PFs As List(Of SMSC21PF)
        ''' <summary>
        ''' 相關分鋼槽液溫及振動記錄
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutSMSC21PFs() As List(Of SMSC21PF)
            Get
                If IsNothing(_AboutSMSC21PFs) OrElse _AboutSMSC21PFs.Count = 0 Then
                    _AboutSMSC21PFs = SMSC21PF.CDBSelect(Of SMSC21PF)("Select * From @#SMS100LB.SMSC21PF WHERE T1='" & Me.T1 & "' AND T2=" & Me.T2 & " Order by T2", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If

                '移除未有時間之資料
                For Each EachItem In _AboutSMSC21PFs.ToArray
                    If String.IsNullOrEmpty(EachItem.T3) OrElse EachItem.T3.Trim.Length = 0 Then
                        _AboutSMSC21PFs.Remove(EachItem)
                    End If
                Next

                Return _AboutSMSC21PFs
            End Get
            Set(ByVal value As List(Of SMSC21PF))
                _AboutSMSC21PFs = value
            End Set
        End Property
#End Region
#Region "相關模冷卻水溫度記錄 屬性:AboutSMSC22PFs"
        Private _AboutSMSC22PFs As List(Of SMSC22PF)
        ''' <summary>
        ''' 相關模冷卻水溫度記錄
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutSMSC22PFs() As List(Of SMSC22PF)
            Get
                If IsNothing(_AboutSMSC22PFs) Then
                    _AboutSMSC22PFs = SMSC22PF.CDBSelect(Of SMSC22PF)("Select * From @#SMS100LB.SMSC22PF WHERE T1='" & Me.T1 & "' AND T2=" & Me.T2 & " Order by T3", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If

                '移除未有時間之資料
                For Each EachItem In _AboutSMSC22PFs.ToArray
                    If String.IsNullOrEmpty(EachItem.T3) OrElse EachItem.T3.Trim.Length = 0 Then
                        _AboutSMSC22PFs.Remove(EachItem)
                    End If
                Next

                Return _AboutSMSC22PFs
            End Get
            Set(ByVal value As List(Of SMSC22PF))
                _AboutSMSC22PFs = value
            End Set
        End Property
#End Region
#Region "相關二次冷卻水記錄 屬性:AboutSMSC23PFs"
        Private _AboutSMSC23PFs As List(Of SMSC23PF)
        ''' <summary>
        ''' 相關二次冷卻水記錄
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutSMSC23PFs() As List(Of SMSC23PF)
            Get
                If IsNothing(_AboutSMSC23PFs) Then
                    _AboutSMSC23PFs = SMSC23PF.CDBSelect(Of SMSC23PF)("Select * From @#SMS100LB.SMSC23PF WHERE T1='" & Me.T1 & "' AND T2=" & Me.T2, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If

                '移除未有澆鑄速度之資料
                For Each EachItem In _AboutSMSC23PFs.ToArray
                    If EachItem.T3 = 0 Then
                        _AboutSMSC23PFs.Remove(EachItem)
                    End If
                Next

                Return _AboutSMSC23PFs
            End Get
            Set(ByVal value As List(Of SMSC23PF))
                _AboutSMSC23PFs = value
            End Set
        End Property
#End Region
#Region "相關鋼溫度及重量記錄表 屬性:AboutSMSC1PF"
        Private _AboutSMSC1PF As List(Of SMS100LB.SMSC1PF)
        ''' <summary>
        ''' 相關鋼溫度及重量記錄表
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutSMSC1PF As SMS100LB.SMSC1PF
            Get
                Static LastAccessTime As DateTime = Now.AddSeconds(-10)
                If Now.Subtract(LastAccessTime).TotalSeconds > 2 AndAlso (IsNothing(_AboutSMSC1PF) OrElse _AboutSMSC1PF.Count = 0) Then
                    Dim QryStirng As String = "Select * from @#SMS100LB.SMSC1PF WHERE T1='" & Me.T1 & "' AND T3=" & Me.T2
                    Dim Adpter As New CompanyORMDB.AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC, QryStirng)
                    _AboutSMSC1PF = SMS100LB.SMSC1PF.CDBSelect(Of SMS100LB.SMSC1PF)(QryStirng, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If
                LastAccessTime = Now
                If _AboutSMSC1PF.Count = 0 Then
                    Return Nothing
                End If
                _AboutSMSC1PF(0).IsFistAddNewData = False
                Return _AboutSMSC1PF(0)
            End Get
        End Property
#End Region
#Region "相關分鋼槽液溫及振動記錄_連鑄 屬性:AboutSMSC1PF_T4"
        Private _AboutSMSC1PF_T4 As String
        ''' <summary>
        ''' 相關分鋼槽液溫及振動記錄_連鑄
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutSMSC1PF_T4 As String
            Get
                If Not IsNothing(AboutSMSC1PF) Then
                    _AboutSMSC1PF_T4 = AboutSMSC1PF.T4
                End If
                Return _AboutSMSC1PF_T4
            End Get
        End Property
#End Region
#Region "相關分鋼槽液溫及振動記錄_鋼種 屬性:AboutSMSC1PF_T6"
        Private _AboutSMSC1PF_T6 As String
        ''' <summary>
        ''' 相關分鋼槽液溫及振動記錄_鋼種
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutSMSC1PF_T6 As String
            Get
                If Not IsNothing(AboutSMSC1PF) Then
                    _AboutSMSC1PF_T6 = AboutSMSC1PF.T6
                End If
                Return _AboutSMSC1PF_T6
            End Get
        End Property
#End Region
#Region "相關分鋼槽液溫及振動記錄_盛鋼桶號碼 屬性:AboutSMSC1PF_T2"
        Private _AboutSMSC1PF_T2 As String
        ''' <summary>
        ''' 相關分鋼槽液溫及振動記錄_盛鋼桶號碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutSMSC1PF_T2 As String
            Get
                If Not IsNothing(AboutSMSC1PF) Then
                    _AboutSMSC1PF_T2 = AboutSMSC1PF.T2
                End If
                Return _AboutSMSC1PF_T2
            End Get
        End Property
#End Region
#Region "相關分鋼槽液溫及振動記錄_空重 屬性:AboutSMSC1PF_T5"
        Private _AboutSMSC1PF_T5 As Single
        ''' <summary>
        ''' 相關分鋼槽液溫及振動記錄_空重
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutSMSC1PF_T5 As Single
            Get
                If Not IsNothing(AboutSMSC1PF) Then
                    _AboutSMSC1PF_T5 = AboutSMSC1PF.T5
                End If
                Return _AboutSMSC1PF_T5
            End Get
        End Property
#End Region
#Region "相關分鋼槽液溫及振動記錄_轉爐出鋼重量 屬性:AboutSMSC1PF_T13"
        Private _AboutSMSC1PF_T13 As Single
        ''' <summary>
        ''' 相關分鋼槽液溫及振動記錄_轉爐出鋼重量
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutSMSC1PF_T13 As Single
            Get
                If Not IsNothing(AboutSMSC1PF) Then
                    _AboutSMSC1PF_T13 = AboutSMSC1PF.T13
                End If
                Return _AboutSMSC1PF_T13
            End Get
        End Property
#End Region

#Region "取得爐號最近一年最後之鋼水溫度及重量記錄表 方法(Shared):GetOneYearLastSMSC1PFForStoveNumber"
        ''' <summary>
        ''' 取得爐號最近一年最後之鋼水溫度及重量記錄表
        ''' </summary>
        ''' <param name="FindStoveNumber"></param>
        ''' <param name="FindTime"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetOneYearLastSMSC1PFForStoveNumber(ByVal FindStoveNumber As String, Optional FindTime As Nullable(Of Date) = Nothing) As SMSC1PF
            If IsNothing(FindTime) Then
                FindTime = Now
            End If
            Dim FindDate As Integer = New CompanyORMDB.AS400DateConverter(FindTime.Value.AddYears(-1)).TwIntegerTypeData
            Dim QrtString As String = "Select * from @#SMS100LB.SMSC1PF WHERE T1='" & FindStoveNumber & "' and T3>=" & FindDate & " ORDER BY T3 DESC"
            Dim SearchResult = SMSC1PF.CDBSelect(Of SMSC1PF)(QrtString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            If SearchResult.Count = 0 Then
                Return Nothing
            End If
            Return SearchResult(0)
        End Function
#End Region

#Region "錯誤訊息 屬性:ErrorMessage"
        Private _ErrorMessage As String
        ''' <summary>
        ''' 錯誤訊息
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property ErrorMessage() As String
            Get
                Return _ErrorMessage
            End Get
            Set(ByVal value As String)
                _ErrorMessage = value
            End Set
        End Property

#End Region
#Region "驗證資料 方法:ValidData"
        ''' <summary>
        ''' 驗證資料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ValidData() As Boolean
            ErrorMessage = Nothing
            If String.IsNullOrEmpty(Me.T1) OrElse Me.T1.Trim.Length < 5 Then
                ErrorMessage = "爐號欄位必須有資料且欄位必須有五位文數字!"
                Return False
            End If
            If Me.T2.ToString.Trim.Length < 7 Then
                ErrorMessage = "攪拌記錄日期欄位必須有資料且欄位必須有七位數字!"
                Return False
            End If
            If Me.T3.ToString.Trim.Length < 7 Then
                ErrorMessage = "澆鑄日期欄位必須有資料且欄位必須有七位數字!"
                Return False
            End If
            'SMSC21PF資料驗證
            For Each EachItem As SMSC21PF In Me.AboutSMSC21PFs
                If String.IsNullOrEmpty(EachItem.T3) OrElse EachItem.T3.Trim.Length < 4 Then
                    ErrorMessage = "攪拌日期欄位必須有四位數字!"
                    Return False
                End If
            Next
            For Each EachItem As SMSC21PF In Me.AboutSMSC21PFs
                '驗證是否有時間重覆狀況
                For Each EachItem1 As SMSC21PF In Me.AboutSMSC21PFs
                    If Not EachItem Is EachItem1 AndAlso EachItem.T3.Trim = EachItem1.T3.Trim Then
                        ErrorMessage = "攪拌記錄日期欄位資料之時間不可重覆!"
                        Return False
                    End If
                Next
            Next
            'SMSC22PF資料驗證
            For Each EachItem As SMSC22PF In Me.AboutSMSC22PFs
                If String.IsNullOrEmpty(EachItem.T3) OrElse EachItem.T3.Trim.Length < 4 Then
                    ErrorMessage = "模冷却水日期欄位必須有四位數字!"
                    Return False
                End If
            Next
            For Each EachItem As SMSC22PF In Me.AboutSMSC22PFs
                '驗證是否有時間重覆狀況
                For Each EachItem1 As SMSC22PF In Me.AboutSMSC22PFs
                    If Not EachItem Is EachItem1 AndAlso EachItem.T3.Trim = EachItem1.T3.Trim Then
                        ErrorMessage = "模冷却水日期欄位資料之時間不可重覆!"
                        Return False
                    End If
                Next
            Next

            'SMSC23PF資料驗證
            For Each EachItem As SMSC23PF In Me.AboutSMSC23PFs
                '驗證是否有時間重覆狀況
                For Each EachItem1 As SMSC23PF In Me.AboutSMSC23PFs
                    If Not EachItem Is EachItem1 AndAlso EachItem.T14.Trim = EachItem1.T14.Trim Then
                        ErrorMessage = "二次冷卻水時間不可重覆請刪除其中一筆資料!"
                        Return False
                    End If
                Next
            Next

            Return True
        End Function
#End Region
#Region "覆寫儲存函式:CDBSave"
        ''' <summary>
        ''' 覆寫儲存
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function CDBSave() As Integer
            ErrorMessage = Nothing
            If Me.IsFistAddNewData Then
                Dim QryString As String = "Select count(*) from @#sms100lb.smsc2pf where T1='" & T1 & "' AND T2=" & T2
                If CType(Me.SQLQueryAdapterByThisObject.SelectQuery(QryString).Rows(0).Item(0), Integer) > 0 Then
                    ErrorMessage = "您輸入之爐號" & T1 & "已存在於資料庫請重新輸入!"
                    Exit Function
                End If
            End If

            Dim AlreadySaveItems As New List(Of ClassDBAS400)
            Try
                For Each EachItem In AboutSMSC21PFs
                    EachItem.T1 = Me.T1
                    EachItem.T2 = Me.T2
                    EachItem.SQLQueryAdapterByThisObject = Me.SQLQueryAdapterByThisObject
                    If EachItem.CDBSave() > 0 Then
                        AlreadySaveItems.Add(EachItem)
                    End If
                Next
                For Each EachItem In AboutSMSC22PFs
                    EachItem.T1 = Me.T1
                    EachItem.T2 = Me.T2
                    EachItem.SQLQueryAdapterByThisObject = Me.SQLQueryAdapterByThisObject
                    If EachItem.CDBSave() > 0 Then
                        AlreadySaveItems.Add(EachItem)
                    End If
                Next
                For Each EachItem In AboutSMSC23PFs
                    EachItem.T1 = Me.T1
                    EachItem.T2 = Me.T2
                    If String.IsNullOrEmpty(EachItem.T14) OrElse EachItem.T14.Trim.Length = 0 Then
                        EachItem.T14 = Format(Now, "HHmmss")
                    End If
                    EachItem.SQLQueryAdapterByThisObject = Me.SQLQueryAdapterByThisObject
                    If EachItem.CDBSave() > 0 Then
                        AlreadySaveItems.Add(EachItem)
                    End If
                Next

                If MyBase.CDBSave() > 0 Then
                    Me.IsFistAddNewData = False
                    Return True
                End If
                Return False
            Catch ex As Exception
                For Each EachItem In AlreadySaveItems
                    EachItem.CDBDelete()
                Next
                ErrorMessage = "資料儲存發生錯誤:" & ex.ToString
                Return 0
            End Try
        End Function
#End Region
#Region "覆寫刪除函式:CDBDelete"
        Public Overrides Function CDBDelete() As Integer
            Dim DeleteQry As String = "Delete From @#SMS100LB.SMSC21PF Where T1='" & Me.T1 & "' AND T2=" & Me.T2
            Me.SQLQueryAdapterByThisObject.ExecuteNonQuery(DeleteQry)
            DeleteQry = "Delete From @#SMS100LB.SMSC22PF Where T1='" & Me.T1 & "' AND T2=" & Me.T2
            Me.SQLQueryAdapterByThisObject.ExecuteNonQuery(DeleteQry)
            DeleteQry = "Delete From @#SMS100LB.SMSC23PF Where T1='" & Me.T1 & "' AND T2=" & Me.T2
            Me.SQLQueryAdapterByThisObject.ExecuteNonQuery(DeleteQry)
            Return MyBase.CDBDelete()
        End Function
#End Region

    End Class
End Namespace