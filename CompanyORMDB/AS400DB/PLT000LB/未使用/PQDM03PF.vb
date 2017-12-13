Namespace PLT000LB
Public Class PQDM03PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("PLT000LB", GetType(PQDM03PF).Name)
	End Sub

#Region "員工碼 屬性:QD3001"
	Private _QD3001 As System.String
	''' <summary>
	''' 員工碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QD3001 () As System.String
		Get
			Return _QD3001
		End Get
		Set(Byval value as System.String)
			_QD3001 = value
		End Set
	End Property
#End Region
#Region "身份証號 屬性:QD3002"
	Private _QD3002 As System.String
	''' <summary>
	''' 身份証號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3002 () As System.String
		Get
			Return _QD3002
		End Get
		Set(Byval value as System.String)
			_QD3002 = value
		End Set
	End Property
#End Region
#Region "姓名 屬性:QD3003"
	Private _QD3003 As System.String
	''' <summary>
	''' 姓名
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3003 () As System.String
		Get
			Return _QD3003
		End Get
		Set(Byval value as System.String)
			_QD3003 = value
		End Set
	End Property
#End Region
#Region "廠別 屬性:QD3004"
	Private _QD3004 As System.String
	''' <summary>
	''' 廠別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3004 () As System.String
		Get
			Return _QD3004
		End Get
		Set(Byval value as System.String)
			_QD3004 = value
		End Set
	End Property
#End Region
#Region "單位 屬性:QD3005"
	Private _QD3005 As System.String
	''' <summary>
	''' 單位
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3005 () As System.String
		Get
			Return _QD3005
		End Get
		Set(Byval value as System.String)
			_QD3005 = value
		End Set
	End Property
#End Region
#Region "職／工 屬性:QD3006"
	Private _QD3006 As System.String
	''' <summary>
	''' 職／工
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3006 () As System.String
		Get
			Return _QD3006
		End Get
		Set(Byval value as System.String)
			_QD3006 = value
		End Set
	End Property
#End Region
#Region "年 屬性:QD3007"
	Private _QD3007 As System.String
	''' <summary>
	''' 年
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QD3007 () As System.String
		Get
			Return _QD3007
		End Get
		Set(Byval value as System.String)
			_QD3007 = value
		End Set
	End Property
#End Region
#Region "月 屬性:QD3008"
	Private _QD3008 As System.String
	''' <summary>
	''' 月
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QD3008 () As System.String
		Get
			Return _QD3008
		End Get
		Set(Byval value as System.String)
			_QD3008 = value
		End Set
	End Property
#End Region
#Region "日 屬性:QD3009"
	Private _QD3009 As System.String
	''' <summary>
	''' 日
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property QD3009 () As System.String
		Get
			Return _QD3009
		End Get
		Set(Byval value as System.String)
			_QD3009 = value
		End Set
	End Property
#End Region
#Region "值勤類別碼 屬性:QD3010"
	Private _QD3010 As System.String
	''' <summary>
	''' 值勤類別碼
	''' </summary>
	''' <returns></returns>
        ''' <remarks>R(7:50~16:00)S(15:50~24:00)T(23:50~8:00)</remarks>
	Public Property QD3010 () As System.String
		Get
			Return _QD3010
		End Get
		Set(Byval value as System.String)
			_QD3010 = value
		End Set
	End Property
#End Region
#Region "班別 屬性:QD3011"
	Private _QD3011 As System.String
	''' <summary>
	''' 班別
	''' </summary>
	''' <returns></returns>
        ''' <remarks>1~4輪班,F:彈性上班,空:正常班</remarks>
	Public Property QD3011 () As System.String
		Get
			Return _QD3011
		End Get
		Set(Byval value as System.String)
			_QD3011 = value
		End Set
	End Property
#End Region
#Region "應上班時間－起 屬性:QD3012"
	Private _QD3012 As System.String
	''' <summary>
	''' 應上班時間－起
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3012 () As System.String
		Get
			Return _QD3012
		End Get
		Set(Byval value as System.String)
			_QD3012 = value
		End Set
	End Property
#End Region
#Region "應上班時間－訖 屬性:QD3013"
	Private _QD3013 As System.String
	''' <summary>
	''' 應上班時間－訖
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3013 () As System.String
		Get
			Return _QD3013
		End Get
		Set(Byval value as System.String)
			_QD3013 = value
		End Set
	End Property
#End Region
#Region "１次上班01 屬性:QD3014"
	Private _QD3014 As System.String
	''' <summary>
	''' １次上班01
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3014 () As System.String
		Get
			Return _QD3014
		End Get
		Set(Byval value as System.String)
			_QD3014 = value
		End Set
	End Property
#End Region
#Region "１次下班01 屬性:QD3015"
	Private _QD3015 As System.String
	''' <summary>
	''' １次下班01
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3015 () As System.String
		Get
			Return _QD3015
		End Get
		Set(Byval value as System.String)
			_QD3015 = value
		End Set
	End Property
#End Region
#Region "２次上班02 屬性:QD3016"
	Private _QD3016 As System.String
	''' <summary>
	''' ２次上班02
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3016 () As System.String
		Get
			Return _QD3016
		End Get
		Set(Byval value as System.String)
			_QD3016 = value
		End Set
	End Property
#End Region
#Region "２次下班02 屬性:QD3017"
	Private _QD3017 As System.String
	''' <summary>
	''' ２次下班02
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3017 () As System.String
		Get
			Return _QD3017
		End Get
		Set(Byval value as System.String)
			_QD3017 = value
		End Set
	End Property
#End Region
#Region "３次上班03 屬性:QD3018"
	Private _QD3018 As System.String
	''' <summary>
	''' ３次上班03
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3018 () As System.String
		Get
			Return _QD3018
		End Get
		Set(Byval value as System.String)
			_QD3018 = value
		End Set
	End Property
#End Region
#Region "３次下班03 屬性:QD3019"
	Private _QD3019 As System.String
	''' <summary>
	''' ３次下班03
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3019 () As System.String
		Get
			Return _QD3019
		End Get
		Set(Byval value as System.String)
			_QD3019 = value
		End Set
	End Property
#End Region
#Region "加班申請時間－起 屬性:QD3020"
	Private _QD3020 As System.String
	''' <summary>
	''' 加班申請時間－起
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3020 () As System.String
		Get
			Return _QD3020
		End Get
		Set(Byval value as System.String)
			_QD3020 = value
		End Set
	End Property
#End Region
#Region "加班申請時間－訖 屬性:QD3021"
	Private _QD3021 As System.String
	''' <summary>
	''' 加班申請時間－訖
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3021 () As System.String
		Get
			Return _QD3021
		End Get
		Set(Byval value as System.String)
			_QD3021 = value
		End Set
	End Property
#End Region
#Region "加班加班費時數 屬性:QD3022"
	Private _QD3022 As System.Single
	''' <summary>
	''' 加班加班費時數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3022 () As System.Single
		Get
			Return _QD3022
		End Get
		Set(Byval value as System.Single)
			_QD3022 = value
		End Set
	End Property
#End Region
#Region "加班補休時數 屬性:QD3023"
	Private _QD3023 As System.Single
	''' <summary>
	''' 加班補休時數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3023 () As System.Single
		Get
			Return _QD3023
		End Get
		Set(Byval value as System.Single)
			_QD3023 = value
		End Set
	End Property
#End Region
#Region "請假假別碼 屬性:QD3024"
	Private _QD3024 As System.String
	''' <summary>
	''' 請假假別碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3024 () As System.String
		Get
			Return _QD3024
		End Get
		Set(Byval value as System.String)
			_QD3024 = value
		End Set
	End Property
#End Region
#Region "請假時數 屬性:QD3025"
	Private _QD3025 As System.Single
	''' <summary>
	''' 請假時數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3025 () As System.Single
		Get
			Return _QD3025
		End Get
		Set(Byval value as System.Single)
			_QD3025 = value
		End Set
	End Property
#End Region
#Region "入廠碼 屬性:QD3026"
	Private _QD3026 As System.String
	''' <summary>
	''' 入廠碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3026 () As System.String
		Get
			Return _QD3026
		End Get
		Set(Byval value as System.String)
			_QD3026 = value
		End Set
	End Property
#End Region
#Region "出廠碼 屬性:QD3027"
	Private _QD3027 As System.String
	''' <summary>
	''' 出廠碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3027 () As System.String
		Get
			Return _QD3027
		End Get
		Set(Byval value as System.String)
			_QD3027 = value
		End Set
	End Property
#End Region
#Region "遲到次數 屬性:QD3028"
	Private _QD3028 As System.Int32
	''' <summary>
	''' 遲到次數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3028 () As System.Int32
		Get
			Return _QD3028
		End Get
		Set(Byval value as System.Int32)
			_QD3028 = value
		End Set
	End Property
#End Region
#Region "早退次數 屬性:QD3029"
	Private _QD3029 As System.Int32
	''' <summary>
	''' 早退次數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3029 () As System.Int32
		Get
			Return _QD3029
		End Get
		Set(Byval value as System.Int32)
			_QD3029 = value
		End Set
	End Property
#End Region
#Region "曠職（工）次數 屬性:QD3030"
	Private _QD3030 As System.Single
	''' <summary>
	''' 曠職（工）次數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3030 () As System.Single
		Get
			Return _QD3030
		End Get
		Set(Byval value as System.Single)
			_QD3030 = value
		End Set
	End Property
#End Region
#Region "夜點費Ｃ－８０元 屬性:QD3031"
	Private _QD3031 As System.Int32
	''' <summary>
	''' 夜點費Ｃ－８０元
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3031 () As System.Int32
		Get
			Return _QD3031
		End Get
		Set(Byval value as System.Int32)
			_QD3031 = value
		End Set
	End Property
#End Region
#Region "夜點費Ｂ－５０元 屬性:QD3032"
	Private _QD3032 As System.Int32
	''' <summary>
	''' 夜點費Ｂ－５０元
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3032 () As System.Int32
		Get
			Return _QD3032
		End Get
		Set(Byval value as System.Int32)
			_QD3032 = value
		End Set
	End Property
#End Region
#Region "值勤時間碼 屬性:QD3033"
	Private _QD3033 As System.String
	''' <summary>
	''' 值勤時間碼
	''' </summary>
	''' <returns></returns>
        ''' <remarks>A:四班三輪I:兩班兩輪E:正常班X:正常班休息日</remarks>
	Public Property QD3033 () As System.String
		Get
			Return _QD3033
		End Get
		Set(Byval value as System.String)
			_QD3033 = value
		End Set
	End Property
#End Region
#Region "待查碼 屬性:QD3034"
	Private _QD3034 As System.String
	''' <summary>
	''' 待查碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3034 () As System.String
		Get
			Return _QD3034
		End Get
		Set(Byval value as System.String)
			_QD3034 = value
		End Set
	End Property
#End Region
#Region "值班碼 屬性:QD3035"
	Private _QD3035 As System.String
	''' <summary>
	''' 值班碼
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3035 () As System.String
		Get
			Return _QD3035
		End Get
		Set(Byval value as System.String)
			_QD3035 = value
		End Set
	End Property
#End Region
#Region "成本中心 屬性:QD3036"
	Private _QD3036 As System.String
	''' <summary>
	''' 成本中心
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3036 () As System.String
		Get
			Return _QD3036
		End Get
		Set(Byval value as System.String)
			_QD3036 = value
		End Set
	End Property
#End Region
#Region "狀況碼01 屬性:QD3037"
	Private _QD3037 As System.String
	''' <summary>
	''' 狀況碼01
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3037 () As System.String
		Get
			Return _QD3037
		End Get
		Set(Byval value as System.String)
			_QD3037 = value
		End Set
	End Property
#End Region
#Region "狀況碼02 屬性:QD3038"
	Private _QD3038 As System.String
	''' <summary>
	''' 狀況碼02
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3038 () As System.String
		Get
			Return _QD3038
		End Get
		Set(Byval value as System.String)
			_QD3038 = value
		End Set
	End Property
#End Region
#Region "狀況碼03 屬性:QD3039"
	Private _QD3039 As System.String
	''' <summary>
	''' 狀況碼03
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3039 () As System.String
		Get
			Return _QD3039
		End Get
		Set(Byval value as System.String)
			_QD3039 = value
		End Set
	End Property
#End Region
#Region "備用 屬性:QD3040"
	Private _QD3040 As System.Int32
	''' <summary>
	''' 備用
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3040 () As System.Int32
		Get
			Return _QD3040
		End Get
		Set(Byval value as System.Int32)
			_QD3040 = value
		End Set
	End Property
#End Region
#Region "前１次上 屬性:QD3041"
	Private _QD3041 As System.String
	''' <summary>
	''' 前１次上
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3041 () As System.String
		Get
			Return _QD3041
		End Get
		Set(Byval value as System.String)
			_QD3041 = value
		End Set
	End Property
#End Region
#Region "前１次下 屬性:QD3042"
	Private _QD3042 As System.String
	''' <summary>
	''' 前１次下
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3042 () As System.String
		Get
			Return _QD3042
		End Get
		Set(Byval value as System.String)
			_QD3042 = value
		End Set
	End Property
#End Region
#Region "前２次上 屬性:QD3043"
	Private _QD3043 As System.String
	''' <summary>
	''' 前２次上
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3043 () As System.String
		Get
			Return _QD3043
		End Get
		Set(Byval value as System.String)
			_QD3043 = value
		End Set
	End Property
#End Region
#Region "前２次下 屬性:QD3044"
	Private _QD3044 As System.String
	''' <summary>
	''' 前２次下
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3044 () As System.String
		Get
			Return _QD3044
		End Get
		Set(Byval value as System.String)
			_QD3044 = value
		End Set
	End Property
#End Region
#Region "前３次上 屬性:QD3045"
	Private _QD3045 As System.String
	''' <summary>
	''' 前３次上
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3045 () As System.String
		Get
			Return _QD3045
		End Get
		Set(Byval value as System.String)
			_QD3045 = value
		End Set
	End Property
#End Region
#Region "前３次下 屬性:QD3046"
	Private _QD3046 As System.String
	''' <summary>
	''' 前３次下
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3046 () As System.String
		Get
			Return _QD3046
		End Get
		Set(Byval value as System.String)
			_QD3046 = value
		End Set
	End Property
#End Region
#Region "前加班申請起 屬性:QD3047"
	Private _QD3047 As System.String
	''' <summary>
	''' 前加班申請起
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property QD3047 () As System.String
		Get
			Return _QD3047
		End Get
		Set(Byval value as System.String)
			_QD3047 = value
		End Set
	End Property
#End Region
#Region "前加班申請訖 屬性:QD3048"
        Private _QD3048 As System.String
        ''' <summary>
        ''' 前加班申請訖
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD3048() As System.String
            Get
                Return _QD3048
            End Get
            Set(ByVal value As System.String)
                _QD3048 = value
            End Set
        End Property
#End Region

End Class
End Namespace