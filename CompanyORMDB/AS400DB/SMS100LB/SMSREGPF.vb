Namespace SMS100LB
Public Class SMSREGPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SMS100LB", GetType(SMSREGPF).Name)
	End Sub

#Region "澆鑄日期 屬性:T1"
	Private _T1 As System.Int32
	''' <summary>
	''' 澆鑄日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property T1 () As System.Int32
		Get
			Return _T1
		End Get
		Set(Byval value as System.Int32)
			_T1 = value
		End Set
	End Property
#End Region
#Region "爐號 屬性:T2"
	Private _T2 As System.String
	''' <summary>
	''' 爐號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property T2 () As System.String
		Get
			Return _T2
		End Get
		Set(Byval value as System.String)
                _T2 = value.ToUpper
		End Set
	End Property
#End Region
#Region "澆鑄粉 屬性:T3"
	Private _T3 As System.Int32
	''' <summary>
	''' 澆鑄粉
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
#Region "分鋼槽塗覆 屬性:T4"
	Private _T4 As System.Int32
	''' <summary>
	''' 分鋼槽塗覆
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T4 () As System.Int32
		Get
			Return _T4
		End Get
		Set(Byval value as System.Int32)
			_T4 = value
		End Set
	End Property
#End Region
#Region "模液位控制 屬性:T5"
        Private _T5 As System.Int32
        ''' <summary>
        ''' 模液位控制
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T5() As System.Int32
            Get
                Return _T5
            End Get
            Set(ByVal value As System.Int32)
                _T5 = value
            End Set
        End Property
#End Region
#Region "澆鑄管 屬性:T6"
        Private _T6 As System.Int32
        ''' <summary>
        ''' 澆鑄管
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T6() As System.Int32
            Get
                Return _T6
            End Get
            Set(ByVal value As System.Int32)
                _T6 = value
            End Set
        End Property
#End Region
#Region "澆鑄速度 屬性:T7"
	Private _T7 As System.Int32
	''' <summary>
	''' 澆鑄速度
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T7 () As System.Int32
		Get
			Return _T7
		End Get
		Set(Byval value as System.Int32)
			_T7 = value
		End Set
	End Property
#End Region
#Region "氣罩 屬性:T8"
	Private _T8 As System.Int32
	''' <summary>
	''' 氣罩
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T8 () As System.Int32
		Get
			Return _T8
		End Get
		Set(Byval value as System.Int32)
			_T8 = value
		End Set
	End Property
#End Region
#Region "冷卻水量 屬性:T9"
	Private _T9 As System.Int32
	''' <summary>
	''' 冷卻水量
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
#Region "攪拌時間 屬性:T10"
	Private _T10 As System.Int32
	''' <summary>
	''' 攪拌時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T10 () As System.Int32
		Get
			Return _T10
		End Get
		Set(Byval value as System.Int32)
			_T10 = value
		End Set
	End Property
#End Region
#Region "靜置時間 屬性:T11"
	Private _T11 As System.Int32
	''' <summary>
	''' 靜置時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T11 () As System.Int32
		Get
			Return _T11
		End Get
		Set(Byval value as System.Int32)
			_T11 = value
		End Set
	End Property
#End Region
#Region "交接爐重量 屬性:T12"
	Private _T12 As System.Single
	''' <summary>
	''' 交接爐重量
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T12 () As System.Single
		Get
			Return _T12
		End Get
		Set(Byval value as System.Single)
			_T12 = value
		End Set
	End Property
#End Region
#Region "攪拌狀況 屬性:T13"
	Private _T13 As System.Int32
	''' <summary>
	''' 攪拌狀況
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T13 () As System.Int32
		Get
			Return _T13
		End Get
		Set(Byval value as System.Int32)
			_T13 = value
		End Set
	End Property
#End Region
#Region "渣流動性 屬性:T14"
	Private _T14 As System.Single
	''' <summary>
	''' 渣流動性
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property T14 () As System.Single
		Get
			Return _T14
		End Get
		Set(Byval value as System.Single)
			_T14 = value
		End Set
	End Property
#End Region
#Region "攪拌強度 屬性:T15"
        Private _T15 As System.Single
        ''' <summary>
        ''' 攪拌強度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T15() As System.Single
            Get
                Return _T15
            End Get
            Set(ByVal value As System.Single)
                _T15 = value
            End Set
        End Property
#End Region
#Region "分鋼槽溫度1 屬性:T16"
        Private _T16 As Double
        ''' <summary>
        ''' 分鋼槽溫度1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T16() As Double
            Get
                Return _T16
            End Get
            Set(ByVal value As Double)
                _T16 = value
            End Set
        End Property
#End Region
#Region "分鋼槽溫度2 屬性:T17"
        Private _T17 As Double
        ''' <summary>
        ''' 分鋼槽溫度2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T17() As Double
            Get
                Return _T17
            End Get
            Set(ByVal value As Double)
                _T17 = value
            End Set
        End Property
#End Region
#Region "分鋼槽溫度3 屬性:T18"
        Private _T18 As Double
        ''' <summary>
        ''' 分鋼槽溫度3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T18() As Double
            Get
                Return _T18
            End Get
            Set(ByVal value As Double)
                _T18 = value
            End Set
        End Property
#End Region
#Region "吹氧次數 屬性:T19"
        Private _T19 As Double
        ''' <summary>
        ''' 吹氧次數
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T19() As Double
            Get
                Return _T19
            End Get
            Set(ByVal value As Double)
                _T19 = value
            End Set
        End Property
#End Region
#Region "分鋼槽內容積 屬性:T20"
        Private _T20 As Integer
        ''' <summary>
        ''' 分鋼槽內容積
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T20() As Integer
            Get
                Return _T20
            End Get
            Set(ByVal value As Integer)
                _T20 = value
            End Set
        End Property
#End Region
#Region "班別 屬性:T21"
        Private _T21 As String
        ''' <summary>
        ''' 班別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T21() As String
            Get
                If IsNothing(_T21) Then
                    Return String.Empty
                End If
                Return _T21.Trim
            End Get
            Set(ByVal value As String)
                _T21 = value.ToUpper
            End Set
        End Property
#End Region
#Region "輪班時間 屬性:T22"
        Private _T22 As Integer
        ''' <summary>
        ''' 輪班時間
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T22() As Integer
            Get
                Return _T22
            End Get
            Set(ByVal value As Integer)
                _T22 = value
            End Set
        End Property
#End Region
#Region "澆鑄管品名 屬性:T23"
        Private _T23 As String
        ''' <summary>
        ''' 澆鑄管品名
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T23() As String
            Get
                If IsNothing(_T23) Then
                    Return String.Empty
                End If
                Return _T23.Trim
            End Get
            Set(ByVal value As String)
                _T23 = value
            End Set
        End Property
#End Region
#Region "氣罩品名 屬性:T24"
        Private _T24 As String
        ''' <summary>
        ''' 分鋼槽內容積
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T24() As String
            Get
                If IsNothing(_T24) Then
                    Return String.Empty
                End If
                Return _T24.Trim
            End Get
            Set(ByVal value As String)
                _T24 = value
            End Set
        End Property
#End Region
#Region "起鑄時分 屬性:T25"
        Private _T25 As String
        ''' <summary>
        ''' 起鑄時分
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T25() As String
            Get
                If IsNothing(_T25) Then
                    Return String.Empty
                End If
                Return _T25.Trim
            End Get
            Set(ByVal value As String)
                _T25 = value
            End Set
        End Property
#End Region
#Region "連鑄 屬性:T26"
        Private _T26 As String
        ''' <summary>
        ''' 連鑄
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T26() As String
            Get
                If IsNothing(_T26) Then
                    Return String.Empty
                End If
                Return _T26.Trim
            End Get
            Set(ByVal value As String)
                _T26 = value
            End Set
        End Property
#End Region
#Region "投料 屬性:T27"
        Private _T27 As System.String
        ''' <summary>
        ''' 投料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T27() As System.String
            Get
                Return _T27
            End Get
            Set(ByVal value As System.String)
                _T27 = value
            End Set
        End Property
#End Region
#Region "澆鑄管長度 屬性:T28"
        Private _T28 As System.String
        ''' <summary>
        ''' 澆鑄管長度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T28() As System.String
            Get
                Return _T28
            End Get
            Set(ByVal value As System.String)
                _T28 = value
            End Set
        End Property
#End Region
#Region "氣罩品名MEMO 屬性:T29"
        Private _T29 As System.String
        ''' <summary>
        ''' 氣罩品名MEMO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T29() As System.String
            Get
                Return _T29
            End Get
            Set(ByVal value As System.String)
                _T29 = value
            End Set
        End Property
#End Region
#Region "插入深度 屬性:T30"
        Private _T30 As Integer
        ''' <summary>
        ''' 插入深度
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T30() As Integer
            Get
                Return _T30
            End Get
            Set(ByVal value As Integer)
                _T30 = value
            End Set
        End Property
#End Region
#Region "AOD出鋼量 屬性:T31"
        Private _T31 As Single
        ''' <summary>
        ''' AOD出鋼量
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T31() As Single
            Get
                Return _T31
            End Get
            Set(ByVal value As Single)
                _T31 = value
            End Set
        End Property
#End Region
#Region "澆鑄粉用量 屬性:T32"
        Private _T32 As System.Single
        ''' <summary>
        ''' 澆鑄粉用量
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T32() As System.Single
            Get
                Return _T32
            End Get
            Set(ByVal value As System.Single)
                _T32 = value
            End Set
        End Property
#End Region
#Region "模溢位波動 屬性:T33"
        Private _T33 As Integer
        ''' <summary>
        ''' 模溢位波動
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T33() As Integer
            Get
                Return _T33
            End Get
            Set(ByVal value As Integer)
                _T33 = value
            End Set
        End Property
#End Region
#Region "AOD出鋼渣量 屬性:T34"
        Private _T34 As System.Single
        ''' <summary>
        ''' AOD出鋼渣量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T34() As System.Single
            Get
                Return _T34
            End Get
            Set(ByVal value As System.Single)
                _T34 = value
            End Set
        End Property
#End Region
#Region "分鋼槽連鑄完剩餘重量 屬性:T35"
        Private _T35 As System.Single
        ''' <summary>
        ''' 分鋼槽連鑄完剩餘重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T35() As System.Single
            Get
                Return _T35
            End Get
            Set(ByVal value As System.Single)
                _T35 = value
            End Set
        End Property
#End Region
#Region "氣罩內壁夾鐵 屬性:T36"
        Private _T36 As Integer
        ''' <summary>
        ''' 氣罩內壁夾鐵
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T36() As Integer
            Get
                Return _T36
            End Get
            Set(ByVal value As Integer)
                _T36 = value
            End Set
        End Property

#End Region
#Region "台車編號 屬性:T37"
        Private _T37 As Integer
        ''' <summary>
        ''' 台車編號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T37() As Integer
            Get
                Return _T37
            End Get
            Set(ByVal value As Integer)
                _T37 = value
            End Set
        End Property

#End Region
#Region "氣罩使用回數 屬性:T38"
        Private _T38 As Integer
        ''' <summary>
        ''' 氣罩使用回數
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T38() As Integer
            Get
                Return _T38
            End Get
            Set(ByVal value As Integer)
                _T38 = value
            End Set
        End Property

#End Region
#Region "填充砂品牌 屬性:T39"
        Private _T39 As Integer
        ''' <summary>
        ''' 填充砂品牌
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T39() As Integer
            Get
                Return _T39
            End Get
            Set(ByVal value As Integer)
                _T39 = value
            End Set
        End Property

#End Region
#Region "氣罩頸部最大直徑 屬性:T40"
        Private _T40 As Single
        ''' <summary>
        ''' 氣罩頸部最大直徑
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T40() As Single
            Get
                Return _T40
            End Get
            Set(ByVal value As Single)
                _T40 = value
            End Set
        End Property

#End Region
#Region "鋼種 屬性:T41"
        Private _T41 As System.String
        ''' <summary>
        ''' 鋼種
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T41() As System.String
            Get
                Return _T41
            End Get
            Set(ByVal value As System.String)
                _T41 = value
            End Set
        End Property
#End Region
#Region "寬度 屬性:T42"
        Private _T42 As System.String
        ''' <summary>
        ''' 寬度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T42() As System.String
            Get
                Return _T42
            End Get
            Set(ByVal value As System.String)
                _T42 = value
            End Set
        End Property
#End Region
#Region "回爐次數 屬性:T43"
        Private _T43 As System.Int32
        ''' <summary>
        ''' 回爐次數
        ''' 1060505 by Minnie
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T43() As System.Int32
            Get
                Return _T43
            End Get
            Set(ByVal value As System.Int32)
                _T43 = value
            End Set
        End Property
#End Region
#Region "攪拌完成後溫度 屬性:T44"
        Private _T44 As System.Int32
        ''' <summary>
        ''' 攪拌完成後溫度
        ''' 1060509 by Minnie
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T44() As System.Int32
            Get
                Return _T44
            End Get
            Set(ByVal value As System.Int32)
                _T44 = value
            End Set
        End Property
#End Region
#Region "分鋼槽起鑄重量 屬性:T45"
        Private _T45 As System.Single
        ''' <summary>
        ''' 分鋼槽連鑄完剩餘重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T45() As System.Single
            Get
                Return _T45
            End Get
            Set(ByVal value As System.Single)
                _T45 = value
            End Set
        End Property
#End Region
#Region "分鋼槽編號 屬性:T46"
        '20171101 add by 30356
        Private _T46 As System.Int32
        ''' <summary>
        ''' 分鋼槽編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T46() As System.Int32
            Get
                Return _T46
            End Get
            Set(ByVal value As System.Int32)
                _T46 = value
            End Set
        End Property
#End Region
#Region "EMS 屬性:T47"
        Private _T47 As System.Int32
        ''' <summary>
        ''' 氣罩
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T47() As System.Int32
            Get
                Return _T47
            End Get
            Set(ByVal value As System.Int32)
                _T47 = value
            End Set
        End Property
#End Region



#Region "澆鑄日期-西元 屬性:T1Cdate"
        ''' <summary>
        ''' 澆鑄日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property T1Cdate() As Date
            Get
                Return (New AS400DateConverter(Me.T1)).DateValue
            End Get
            Set(ByVal value As Date)
                T1 = (New AS400DateConverter(value)).TwIntegerTypeData
            End Set
        End Property
#End Region


#Region "澆鑄粉代碼說明 屬性:T3_Descript"
        ''' <summary>
        ''' 澆鑄粉代碼說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T3_Descript As String
            Get
                Select Case T3
                    Case 1
                        Return "STE130"
                    Case 2
                        Return "INTOCAST"
                    Case 3
                        Return "STE816"
                    Case 4
                        Return "SL650/ATB"
                    Case 5
                        Return "STE130-1"
                    Case 6
                        Return "B1/77"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property
#End Region
#Region "分鋼槽塗覆說明 屬性:T4_Descript"
        ''' <summary>
        ''' 分鋼槽塗覆說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T4_Descript As String
            Get
                Select Case T4
                    Case 1
                        Return "正常"
                    Case 2
                        Return "異常"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property
#End Region
#Region "模液位控制說明 屬性:T5_Descript"
        ''' <summary>
        ''' 模液位控制說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T5_Descript As String
            Get
                Select Case T5
                    Case 1
                        Return "正常"
                    Case 2
                        Return "異常"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property
#End Region
#Region "澆鑄管說明 屬性:T6_Descript"
        ''' <summary>
        ''' 澆鑄管說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T6_Descript As String
            Get
                Select Case T6
                    Case 1
                        Return "正常"
                    Case 2
                        Return "異常"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property
#End Region
#Region "澆鑄速度說明 屬性:T7_Descript"
        ''' <summary>
        ''' 澆鑄速度說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T7_Descript As String
            Get
                Select Case T7
                    Case 1
                        Return "正常"
                    Case 2
                        Return "異常"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property
#End Region
#Region "氣罩說明 屬性:T8_Descript"
        ''' <summary>
        ''' 氣罩說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T8_Descript As String
            Get
                Select Case T8
                    Case 1
                        Return "正常"
                    Case 2
                        Return "異常"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property
#End Region
#Region "冷卻水量說明 屬性:T9_Descript"
        ''' <summary>
        ''' 冷卻水量說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T9_Descript As String
            Get
                Select Case T9
                    Case 1
                        Return "正常"
                    Case 2
                        Return "異常"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property
#End Region
#Region "攪拌狀況說明 屬性:T13_Descript"
        ''' <summary>
        ''' 攪拌狀況說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T13_Descript As String
            Get
                Select Case T13
                    Case 1
                        Return "成功"
                    Case 2
                        Return "失敗"
                    Case 3
                        Return "壓力大流量小"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property
#End Region
#Region "渣流動性說明 屬性:T14_Descript"
        ''' <summary>
        ''' 渣流動性說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T14_Descript As String
            Get
                Select Case T14
                    Case 1
                        Return "稠"
                    Case 2
                        Return "尚可"
                    Case 3
                        Return "佳"
                    Case 4
                        Return "稍清"
                    Case 5
                        Return "清"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property
#End Region
#Region "攪拌強度說明 屬性:T15_Descript"
        ''' <summary>
        ''' 攪拌強度說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T15_Descript As String
            Get
                Select Case T15
                    Case 1
                        Return "大攪拌(>500L/分)"
                    Case 2
                        Return "中攪拌(300<x<=500L/分)"
                    Case 3
                        Return "小攪拌(200<x<=300L/分)"
                    Case 4
                        Return "微攪拌(<=200L/分)"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property
#End Region
#Region "分鋼槽內容積說明 屬性:T20_Descript"
        ''' <summary>
        ''' 分鋼槽內容積說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T20_Descript As String
            Get
                Select Case T20
                    Case 1
                        Return "正常"
                    Case 2
                        Return "加大"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property

#End Region
#Region "輪班時間說明 屬性:T22_Descript"
        ''' <summary>
        ''' 輪班時間說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T22_Descript As String
            Get
                Select Case T22
                    Case 1
                        Return "早"
                    Case 2
                        Return "中"
                    Case 3
                        Return "夜"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property

#End Region
#Region "攪拌強度說明 屬性:T27_Descript"
        ''' <summary>
        ''' 攪拌強度說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T27_Descript As String
            Get
                Select Case T27
                    Case 0
                        Return "無"
                    Case 1
                        Return "1次"
                    Case 2
                        Return "2次"
                    Case 3
                        Return "3次"
                    Case 4
                        Return "4次"
                    Case 5
                        Return "5次"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property
#End Region
#Region "澆鑄管長度說明 屬性:T28_Descript"
        ''' <summary>
        ''' 澆鑄管長度說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T28_Descript As String
            Get
                Select Case T28
                    Case 0
                        Return "未知"
                    Case 1
                        Return "正常"
                    Case 2
                        Return "加長"
                    Case Else
                        Return "未知"
                End Select
            End Get
        End Property
#End Region
#Region "模溢位波動說明 屬性:T33_Descript"
        ''' <summary>
        ''' 模溢位波動說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T33_Descript As String
            Get
                Select Case T33
                    Case Is = 0
                        Return "未知"
                    Case Is = 1
                        Return "正常"
                    Case Else
                        Return "異常"
                End Select
            End Get
        End Property
#End Region
#Region "氣罩內壁夾鐵說明 屬性:T36_Descript"
        ''' <summary>
        ''' 氣罩內壁夾鐵說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T36_Descript As String
            Get
                Select Case T36
                    Case "1"
                        Return "正常"
                    Case "2"
                        Return "夾鐵"
                End Select
                Return "未知"
            End Get
        End Property
#End Region
#Region "填充砂品牌說明 屬性:T39_Descript"
        ''' <summary>
        ''' 填充砂品牌說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T39_Descript As String
            Get
                Select Case T39
                    Case "1"
                        Return "SK"
                    Case "2"
                        Return "鋼新"
                    Case "3"
                        Return "ST"
                End Select
                Return "未知"
            End Get
        End Property
#End Region
#Region "EMS說明 屬性:T47_Descript"
        ''' <summary>
        ''' 氣罩說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property T47_Descript As String
            Get
                Select Case T47
                    Case 1
                        Return "使用"
                    Case 2
                        Return "無"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property
#End Region


    End Class
End Namespace