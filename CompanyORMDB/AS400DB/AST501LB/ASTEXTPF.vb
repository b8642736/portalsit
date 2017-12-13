Namespace AST501LB
Public Class ASTEXTPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("AST501LB", GetType(ASTEXTPF).Name)
	End Sub

#Region "廠別 屬性:FACNAM"
	Private _FACNAM As System.String
	''' <summary>
	''' 廠別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property FACNAM () As System.String
		Get
			Return _FACNAM
		End Get
		Set(Byval value as System.String)
			_FACNAM = value
		End Set
	End Property
#End Region
#Region "財產編號 屬性:NUMBER"
	Private _NUMBER As System.String
	''' <summary>
	''' 財產編號
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
#Region "重估年月 屬性:YDATE"
        Private _YDATE As System.Int32
        ''' <summary>
        ''' 重估年月
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property YDATE() As System.Int32
            Get
                Return _YDATE
            End Get
            Set(ByVal value As System.Int32)
                _YDATE = value
            End Set
        End Property
#End Region
#Region "延用年數 屬性:EXTYER"
	Private _EXTYER As System.Int32
	''' <summary>
	''' 延用年數
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property EXTYER () As System.Int32
		Get
			Return _EXTYER
		End Get
		Set(Byval value as System.Int32)
			_EXTYER = value
		End Set
	End Property
#End Region

#Region "相關訊息 屬性:AboutInformation"
        Private _AboutInformation As String
        ''' <summary>
        ''' 相關訊息
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutInformation() As String
            Get
                If IsNothing(AboutAST101PF) Then
                    _AboutInformation = "找不到原資產資料!"
                End If
                Return _AboutInformation
            End Get
            Private Set(value As String)
                _AboutInformation = value
            End Set
        End Property

#End Region
#Region "相關AST101PF資產名稱 屬性:AboutAST101PF_Name"
        ''' <summary>
        ''' 相關AST101PF資產名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutAST101PF_Name As String
            Get
                If IsNothing(AboutAST101PF) Then
                    Return Nothing
                End If
                Return AboutAST101PF.NAME
            End Get
        End Property
#End Region


#Region "相關AST101PF 屬性:AboutAST101PF"
        Private _AboutAST101PF As AST500LB.AST101PF
        Private _AboutAST101PFIsSearched As Boolean = False
        ''' <summary>
        ''' 相關AST101PF
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutAST101PF() As AST500LB.AST101PF
            Get
                If IsNothing(_AboutAST101PF) And Not String.IsNullOrEmpty(Me.CDBMemberName) AndAlso _AboutAST101PFIsSearched = False Then
                    Dim Qry As String = "Select * from @#AST500LB.AST101PF WHERE NUMBER='" & Me.NUMBER & "'"
                    Dim SearchResult As List(Of AST500LB.AST101PF) = AST500LB.AST101PF.CDBSelect(Of AST500LB.AST101PF)(Qry, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    If SearchResult.Count > 0 Then
                        _AboutAST101PF = SearchResult(0)
                    End If
                    _AboutAST101PFIsSearched = True
                End If
                Return _AboutAST101PF
            End Get
            Set(ByVal value As AST500LB.AST101PF)
                _AboutAST101PF = value
                _AboutAST101PFIsSearched = False
            End Set
        End Property

#End Region
End Class
End Namespace