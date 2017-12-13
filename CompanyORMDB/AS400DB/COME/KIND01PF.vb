Namespace COME
Public Class KIND01PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("COME", GetType(KIND01PF).Name)
	End Sub

#Region "單據號碼1 屬性:KD101"
	Private _KD101 As System.String
	''' <summary>
	''' 單據號碼1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property KD101 () As System.String
		Get
			Return _KD101
		End Get
		Set(Byval value as System.String)
			_KD101 = value
		End Set
	End Property
#End Region
#Region "單據號碼2 屬性:KD102"
	Private _KD102 As System.Int32
	''' <summary>
	''' 單據號碼2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property KD102 () As System.Int32
		Get
			Return _KD102
		End Get
		Set(Byval value as System.Int32)
			_KD102 = value
		End Set
	End Property
#End Region
#Region "輸入職編 屬性:KD103"
	Private _KD103 As System.String
	''' <summary>
	''' 輸入職編
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KD103 () As System.String
		Get
			Return _KD103
		End Get
		Set(Byval value as System.String)
			_KD103 = value
		End Set
	End Property
#End Region
#Region "輸入部門 屬性:KD104"
	Private _KD104 As System.String
	''' <summary>
	''' 輸入部門
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KD104 () As System.String
		Get
			Return _KD104
		End Get
		Set(Byval value as System.String)
			_KD104 = value
		End Set
	End Property
#End Region
#Region "輸入日期 屬性:KD105"
	Private _KD105 As System.Int32
	''' <summary>
	''' 輸入日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KD105 () As System.Int32
		Get
			Return _KD105
		End Get
		Set(Byval value as System.Int32)
			_KD105 = value
		End Set
	End Property
#End Region
#Region "輸入時間 屬性:KD106"
	Private _KD106 As System.Int32
	''' <summary>
	''' 輸入時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KD106 () As System.Int32
		Get
			Return _KD106
		End Get
		Set(Byval value as System.Int32)
			_KD106 = value
		End Set
	End Property
#End Region
#Region "收款職編 屬性:KD107"
	Private _KD107 As System.String
	''' <summary>
	''' 收款職編
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KD107 () As System.String
		Get
			Return _KD107
		End Get
		Set(Byval value as System.String)
			_KD107 = value
		End Set
	End Property
#End Region
#Region "收款部門 屬性:KD108"
	Private _KD108 As System.String
	''' <summary>
	''' 收款部門
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KD108 () As System.String
		Get
			Return _KD108
		End Get
		Set(Byval value as System.String)
			_KD108 = value
		End Set
	End Property
#End Region
#Region "收款日期 屬性:KD109"
	Private _KD109 As System.Int32
	''' <summary>
	''' 收款日期
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KD109 () As System.Int32
		Get
			Return _KD109
		End Get
		Set(Byval value as System.Int32)
			_KD109 = value
		End Set
	End Property
#End Region
#Region "收款時間 屬性:KD110"
	Private _KD110 As System.Int32
	''' <summary>
	''' 收款時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KD110 () As System.Int32
		Get
			Return _KD110
		End Get
		Set(Byval value as System.Int32)
			_KD110 = value
		End Set
	End Property
#End Region
#Region "單據金額 屬性:KD111"
        Private _KD111 As System.Int64
	''' <summary>
	''' 單據金額
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
        Public Property KD111() As System.Int64
            Get
                Return _KD111
            End Get
            Set(ByVal value As System.Int64)
                _KD111 = value
            End Set
        End Property
#End Region
#Region "單據狀態 屬性:KD112"
	Private _KD112 As System.String
	''' <summary>
	''' 單據狀態
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KD112 () As System.String
		Get
			Return _KD112
		End Get
		Set(Byval value as System.String)
			_KD112 = value
		End Set
	End Property
#End Region
#Region "付款方式 屬性:KD113"
	Private _KD113 As System.String
	''' <summary>
	''' 付款方式
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KD113 () As System.String
		Get
			Return _KD113
		End Get
		Set(Byval value as System.String)
			_KD113 = value
		End Set
	End Property
#End Region
#Region "付款說明1 屬性:KD114"
	Private _KD114 As System.String
	''' <summary>
	''' 付款說明1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KD114 () As System.String
		Get
			Return _KD114
		End Get
		Set(Byval value as System.String)
			_KD114 = value
		End Set
	End Property
#End Region
#Region "付款說明2 屬性:KD115"
	Private _KD115 As System.String
	''' <summary>
	''' 付款說明2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property KD115 () As System.String
		Get
			Return _KD115
		End Get
		Set(Byval value as System.String)
			_KD115 = value
		End Set
	End Property
#End Region
#Region "購案編號 屬性:KD116"
        Private _KD116 As System.String
        ''' <summary>
        ''' 購案編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property KD116() As System.String
            Get
                Return _KD116
            End Get
            Set(ByVal value As System.String)
                _KD116 = value
            End Set
        End Property
#End Region

End Class
End Namespace