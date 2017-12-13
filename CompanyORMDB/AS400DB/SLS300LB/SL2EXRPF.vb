Namespace SLS300LB
Public Class SL2EXRPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SLS300LB", GetType(SL2EXRPF).Name)
	End Sub

#Region "年 屬性:EXR01"
	Private _EXR01 As System.String
	''' <summary>
	''' 年
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property EXR01 () As System.String
		Get
			Return _EXR01
		End Get
		Set(Byval value as System.String)
			_EXR01 = value
		End Set
	End Property
#End Region
#Region "月 屬性:EXR02"
	Private _EXR02 As System.String
	''' <summary>
	''' 月
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property EXR02 () As System.String
		Get
			Return _EXR02
		End Get
		Set(Byval value as System.String)
			_EXR02 = value
		End Set
	End Property
#End Region
#Region "客戶 屬性:EXR03"
	Private _EXR03 As System.String
	''' <summary>
	''' 客戶
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property EXR03 () As System.String
		Get
			Return _EXR03
		End Get
		Set(Byval value as System.String)
			_EXR03 = value
		End Set
	End Property
#End Region
#Region "沖銷選擇 屬性:EXR10"
	Private _EXR10 As System.String
	''' <summary>
	''' 沖銷選擇
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXR10 () As System.String
		Get
			Return _EXR10
		End Get
		Set(Byval value as System.String)
			_EXR10 = value
		End Set
	End Property
#End Region
#Region "Ａ料發貨 屬性:EXR11"
	Private _EXR11 As System.Single
	''' <summary>
	''' Ａ料發貨
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXR11 () As System.Single
		Get
			Return _EXR11
		End Get
		Set(Byval value as System.Single)
			_EXR11 = value
		End Set
	End Property
#End Region
#Region "Ｂ料發貨 屬性:EXR12"
	Private _EXR12 As System.Single
	''' <summary>
	''' Ｂ料發貨
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXR12 () As System.Single
		Get
			Return _EXR12
		End Get
		Set(Byval value as System.Single)
			_EXR12 = value
		End Set
	End Property
#End Region
#Region "A許可% 屬性:EXR13"
	Private _EXR13 As System.Single
	''' <summary>
	''' A許可%
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXR13 () As System.Single
		Get
			Return _EXR13
		End Get
		Set(Byval value as System.Single)
			_EXR13 = value
		End Set
	End Property
#End Region
#Region "B許可% 屬性:EXR14"
	Private _EXR14 As System.Single
	''' <summary>
	''' B許可%
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXR14 () As System.Single
		Get
			Return _EXR14
		End Get
		Set(Byval value as System.Single)
			_EXR14 = value
		End Set
	End Property
#End Region
#Region "C許可% 屬性:EXR15"
	Private _EXR15 As System.Single
	''' <summary>
	''' C許可%
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXR15 () As System.Single
		Get
			Return _EXR15
		End Get
		Set(Byval value as System.Single)
			_EXR15 = value
		End Set
	End Property
#End Region
#Region "門檻值 屬性:EXR16"
	Private _EXR16 As System.Single
	''' <summary>
	''' 門檻值
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXR16 () As System.Single
		Get
			Return _EXR16
		End Get
		Set(Byval value as System.Single)
			_EXR16 = value
		End Set
	End Property
#End Region
#Region "CODE-1 屬性:EXR91"
	Private _EXR91 As System.String
	''' <summary>
	''' CODE-1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXR91 () As System.String
		Get
			Return _EXR91
		End Get
		Set(Byval value as System.String)
			_EXR91 = value
		End Set
	End Property
#End Region
#Region "CODE-2 屬性:EXR92"
	Private _EXR92 As System.String
	''' <summary>
	''' CODE-2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXR92 () As System.String
		Get
			Return _EXR92
		End Get
		Set(Byval value as System.String)
			_EXR92 = value
		End Set
	End Property
#End Region

#Region "沖退金額 屬性:DrawMoney"
        ''' <summary>
        ''' 沖退金額
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property DrawWeight(ByVal SetWeight As Double) As Double
            Get
                Select Case True
                    Case EXR10 = 1
                        Return SetWeight * (EXR13 / 100) * 3000
                    Case EXR10 = 4
                        Return SetWeight * (IIf((EXR11 + EXR12) <= EXR16, 1, EXR16 / (EXR11 + EXR12))) * 3000
                    Case Else
                        Return 0
                End Select
                Return 0
            End Get
        End Property
#End Region

End Class
End Namespace