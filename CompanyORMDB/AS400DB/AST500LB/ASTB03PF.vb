Namespace AST500LB
    ''' <summary>
    ''' 減少資產彙總檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ASTB03PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("AST500LB", GetType(ASTB03PF).Name)
        End Sub

#Region " 屬性:CODE"
        Private _CODE As System.String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CODE() As System.String
            Get
                Return _CODE
            End Get
            Set(ByVal value As System.String)
                _CODE = value
            End Set
        End Property
#End Region
#Region " 屬性:NUMBER"
        Private _NUMBER As System.Object
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property NUMBER() As System.Object
            Get
                Return _NUMBER
            End Get
            Set(ByVal value As System.Object)
                _NUMBER = value
            End Set
        End Property
#End Region
#Region "中文名稱 屬性:CNAME"
        Private _CNAME As System.String
        ''' <summary>
        ''' 中文名稱
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CNAME() As System.String
            Get
                Return _CNAME
            End Get
            Set(ByVal value As System.String)
                _CNAME = value
            End Set
        End Property
#End Region
#Region "發生日期 屬性:DATEC"
        Private _DATEC As System.Object
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DATEC() As System.Object
            Get
                Return _DATEC
            End Get
            Set(ByVal value As System.Object)
                _DATEC = value
            End Set
        End Property
#End Region
#Region " 屬性:DATE"
        Private _DATE As System.Object
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property [DATE]() As System.Object
            Get
                Return _DATE
            End Get
            Set(ByVal value As System.Object)
                _DATE = value
            End Set
        End Property
#End Region
#Region " 屬性:UNIT"
        Private _UNIT As System.Object
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UNIT() As System.Object
            Get
                Return _UNIT
            End Get
            Set(ByVal value As System.Object)
                _UNIT = value
            End Set
        End Property
#End Region
#Region " 屬性:QUANT"
        Private _QUANT As System.Object
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QUANT() As System.Object
            Get
                Return _QUANT
            End Get
            Set(ByVal value As System.Object)
                _QUANT = value
            End Set
        End Property
#End Region
#Region " 屬性:WHY"
        Private _WHY As System.Object
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WHY() As System.Object
            Get
                Return _WHY
            End Get
            Set(ByVal value As System.Object)
                _WHY = value
            End Set
        End Property
#End Region
#Region " 屬性:DEPR"
        Private _DEPR As System.Object
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEPR() As System.Object
            Get
                Return _DEPR
            End Get
            Set(ByVal value As System.Object)
                _DEPR = value
            End Set
        End Property
#End Region
#Region " 屬性:DEPREB"
        Private _DEPREB As System.Object
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEPREB() As System.Object
            Get
                Return _DEPREB
            End Get
            Set(ByVal value As System.Object)
                _DEPREB = value
            End Set
        End Property
#End Region
#Region " 屬性:USLAFF"
        Private _USLAFF As System.Object
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property USLAFF() As System.Object
            Get
                Return _USLAFF
            End Get
            Set(ByVal value As System.Object)
                _USLAFF = value
            End Set
        End Property
#End Region
#Region " 屬性:PRICE"
        Private _PRICE As System.Object
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PRICE() As System.Object
            Get
                Return _PRICE
            End Get
            Set(ByVal value As System.Object)
                _PRICE = value
            End Set
        End Property
#End Region
#Region " 屬性:TAMOUN"
        Private _TAMOUN As System.Object
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TAMOUN() As System.Object
            Get
                Return _TAMOUN
            End Get
            Set(ByVal value As System.Object)
                _TAMOUN = value
            End Set
        End Property
#End Region
#Region " 屬性:DEPT"
        Private _DEPT As System.Object
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property DEPT() As System.Object
            Get
                Return _DEPT
            End Get
            Set(ByVal value As System.Object)
                _DEPT = value
            End Set
        End Property
#End Region



#Region "相關AST106PF_使用單位 屬性:AboutAST106PF_UseDept"
        Private _AboutAST106PF_UseDept As String
        ''' <summary>
        ''' 相關AST106PF_使用單位
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutAST106PF_UseDept() As String
            Get
                If IsNothing(_AboutAST106PF_UseDept) Then
                    Dim GetAboutAST106PF As AST106PF = AboutAST106PF
                    If Not IsNothing(GetAboutAST106PF) Then
                        _AboutAST106PF_UseDept = GetAboutAST106PF.DEPTSA
                    End If
                End If
                Return _AboutAST106PF_UseDept
            End Get
        End Property
#End Region


#Region "相關AST401PF 屬性:AboutAST401PF"
        Private _AboutAST401PF As List(Of AST401PF)
        ''' <summary>
        ''' 相關AST401PF
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public ReadOnly Property AboutAST401PF(Optional ByVal SearchCash As List(Of AST401PF) = Nothing) As List(Of AST401PF)
            Get
                If IsNothing(_AboutAST401PF) Then
                    Dim FindObjects As List(Of AST401PF) = Nothing
                    If IsNothing(SearchCash) Then
                        FindObjects = ClassDBAS400.CDBSelect(Of AST401PF)("Select * From " & (New AST401PF).CDBFullAS400DBPath & " Where FNUMBER='" & Me.NUMBER & "' Order by TRNDATE, TRNTIME", Me.CDBCurrentUseSQLQueryAdapter)
                    Else
                        FindObjects = SearchCash
                    End If
                    _AboutAST401PF = New List(Of AST401PF)
                    For Each EachItem As AST401PF In FindObjects
                        If EachItem.FNUMBER = Me.NUMBER Then
                            _AboutAST401PF.Add(EachItem)
                        End If
                    Next
                End If
                Return _AboutAST401PF
            End Get
        End Property


#End Region
#Region "相關AS106PF  屬性:AboutAST106PF"
        ''' <summary>
        ''' 相關AS106PF
        ''' </summary>
        ''' <remarks></remarks>
        Private _AboutAST106PF As AST106PF
        Private Shared _AboutAST106PFAll As List(Of AST106PF)
        ''' <summary>
        ''' 相關AS106PF
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutAST106PF() As AST106PF
            Get
                If IsNothing(_AboutAST106PFAll) Then
                    _AboutAST106PFAll = CDBSelect(Of AST106PF)("Select * from " & Me.CDBFullAS400DBPath.ToUpper.Replace("ASTB03PF", "AST106PF"), Me.CDBCurrentUseSQLQueryAdapter)
                End If
                If IsNothing(_AboutAST106PF) Then
                    For Each EachItem As AST106PF In _AboutAST106PFAll
                        If EachItem.NUMBER = Me.NUMBER Then
                            _AboutAST106PF = EachItem
                            Exit For
                        End If
                    Next
                End If
                Return _AboutAST106PF
            End Get
        End Property
#End Region

    End Class
End Namespace