Namespace FOD100LB
Public Class FODM03PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("FOD100LB", GetType(FODM03PF).Name)
	End Sub

#Region "單位編號 屬性:FD301"
	Private _FD301 As System.String
	''' <summary>
	''' 單位編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property FD301 () As System.String
		Get
			Return _FD301
		End Get
		Set(Byval value as System.String)
			_FD301 = value
		End Set
	End Property
#End Region
#Region "職工編號 屬性:FD302"
	Private _FD302 As System.String
	''' <summary>
	''' 職工編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property FD302 () As System.String
		Get
			Return _FD302
		End Get
		Set(Byval value as System.String)
			_FD302 = value
		End Set
	End Property
#End Region
#Region "是否刪除 屬性:FD303"
	Private _FD303 As System.String
	''' <summary>
	''' 是否刪除
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FD303 () As System.String
		Get
			Return _FD303
		End Get
		Set(Byval value as System.String)
			_FD303 = value
		End Set
	End Property
#End Region
#Region "異動日期時間 屬性:FD304"
        Private _FD304 As System.String
        ''' <summary>
        ''' 異動日期時間
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FD304() As System.String
            Get
                Return _FD304
            End Get
            Set(ByVal value As System.String)
                _FD304 = value
            End Set
        End Property
#End Region
End Class
End Namespace