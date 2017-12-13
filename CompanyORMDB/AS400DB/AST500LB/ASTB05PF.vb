Namespace AST500LB
Public Class ASTB05PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("AST500LB", GetType(ASTB05PF).Name)
	End Sub

#Region "資產編號 屬性:NUMBER"
	Private _NUMBER As System.String
	''' <summary>
	''' 資產編號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property NUMBER () As System.String
		Get
			Return _NUMBER
		End Get
		Set(Byval value as System.String)
			_NUMBER = value
		End Set
	End Property
#End Region
#Region "發生年月 屬性:DATEC"
        Private _DATEC As Integer
        ''' <summary>
        ''' 發生年月
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property DATEC() As Integer
            Get
                Return _DATEC
            End Get
            Set(ByVal value As Integer)
                _DATEC = value
            End Set
        End Property

#End Region
#Region "狀態說明 屬性:STATION"
        Private _STATION As System.String
        ''' <summary>
        ''' 狀態說明
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property STATION() As System.String
            Get
                Return _STATION
            End Get
            Set(ByVal value As System.String)
                _STATION = value
            End Set
        End Property
#End Region
#Region "備註說明 屬性:MEMO1"
	Private _MEMO1 As System.String
	''' <summary>
	''' 備註說明
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MEMO1 () As System.String
		Get
			Return _MEMO1
		End Get
		Set(Byval value as System.String)
			_MEMO1 = value
		End Set
	End Property
#End Region
#Region "相關ASTB03PF報廢資產名稱 屬性:About_ASTB03PF_Name"
        ''' <summary>
        ''' 相關ASTB03PF報廢資產名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property About_ASTB03PF_Name As String
            Get
                If Not IsNothing(About_ASTB03PF) Then
                    Return About_ASTB03PF.CNAME
                End If
                Return Nothing
            End Get
            Set(value As String)


            End Set
        End Property
#End Region

#Region "報廢日期 屬性:DeclareDate"
        Private _DeclareDate As Double = -1
        ''' <summary>
        ''' 報廢日期
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property DeclareDate As Double
            Get
                If _DeclareDate < 0 Then
                    Dim Aboutastb03pf = About_ASTB03PF
                    If Not IsNothing(Aboutastb03pf) Then
                        _DeclareDate = Aboutastb03pf.DATEC
                    End If
                End If
                Return _DeclareDate
            End Get
            Set(value As Double)
                _DeclareDate = value
            End Set
        End Property
#End Region
#Region "數量 屬性:Quantity"

        Private _Quantity As Integer = -1
        ''' <summary>
        ''' 數量
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property Quantity() As Integer
            Get
                If _Quantity < 0 Then
                    Dim Aboutastb03pf = About_ASTB03PF
                    If Not IsNothing(Aboutastb03pf) Then
                        _Quantity = Aboutastb03pf.QUANT
                    End If
                End If
                Return _Quantity
            End Get
            Set(ByVal value As Integer)
                _Quantity = value
            End Set
        End Property

#End Region
#Region "使用單位 屬性:UseDept"

        Private _UseDept As String = Nothing
        ''' <summary>
        ''' 使用單位
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property UseDept() As String
            Get
                If IsNothing(_UseDept) Then
                    Dim Aboutastb03pf = About_ASTB03PF
                    If Not IsNothing(Aboutastb03pf) Then
                        _UseDept = Aboutastb03pf.AboutAST106PF_UseDept
                    End If
                End If
                Return _UseDept
            End Get
            Set(ByVal value As String)
                _UseDept = value
            End Set
        End Property

#End Region

#Region "相關ASTB03PF 屬性:About_ASTB03PF"
        Private _About_ASTB03PF As ASTB03PF = Nothing
        Private LastGetDataTime As DateTime = Now.AddSeconds(-20)
        ''' <summary>
        ''' 相關ASTB03PF
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property About_ASTB03PF As ASTB03PF
            Get
                If Now.Subtract(LastGetDataTime).TotalSeconds > 10 AndAlso IsNothing(_About_ASTB03PF) Then
                    Dim GetValues As List(Of ASTB03PF) = AST101PF.CDBSelect(Of ASTB03PF)("Select * from @#AST500LB.ASTB03PF.ASTFSA WHERE NUMBER='" & Me.NUMBER.Trim & "' AND DATEC=" & Me.DATEC, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    If GetValues.Count > 0 Then
                        _About_ASTB03PF = GetValues(0)
                    End If
                End If
                LastGetDataTime = Now
                Return _About_ASTB03PF
            End Get
        End Property
#End Region

    End Class
End Namespace