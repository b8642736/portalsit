Namespace SQLServer
	Namespace OtherOperator
	Public Class WebMenuDisplayForAuthority
	Inherits ClassDBSQLServer

	Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "OtherOperator")
                Me.ID = Guid.NewGuid.ToString

	End Sub

#Region "ID 屬性:ID"
	Private _ID As System.String
	''' <summary>
	''' ID
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ID () As System.String
		Get
			Return _ID
		End Get
		Set(Byval value as System.String)
			_ID = value
		End Set
	End Property
#End Region
#Region "FK_WebMenuID 屬性:FK_WebMenuID"
            Private _FK_WebMenuID As System.String
            ''' <summary>
            ''' FK_WebMenuID
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_WebMenuID() As System.String
                Get
                    Return _FK_WebMenuID
                End Get
                Set(ByVal value As System.String)
                    _FK_WebMenuID = value
                    AboutWebMenu = Nothing
                End Set
            End Property
#End Region
#Region "FK_SystemCode 屬性:FK_SystemCode"
	Private _FK_SystemCode As System.String
	''' <summary>
	''' FK_SystemCode
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FK_SystemCode () As System.String
		Get
			Return _FK_SystemCode
		End Get
		Set(Byval value as System.String)
			_FK_SystemCode = value
		End Set
	End Property
#End Region
#Region "FK_FunctionCode 屬性:FK_FunctionCode"
	Private _FK_FunctionCode As System.String
	''' <summary>
	''' FK_FunctionCode
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property FK_FunctionCode () As System.String
		Get
			Return _FK_FunctionCode
		End Get
		Set(Byval value as System.String)
			_FK_FunctionCode = value
		End Set
	End Property
#End Region

#Region "相關網頁Menu 屬性:AboutWebMenu"

            Private _AboutWebMenu As WebMenu
            ''' <summary>
            ''' 相關網頁Menu
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property AboutWebMenu() As WebMenu
                Get
                    If IsNothing(_AboutWebMenu) Then
                        Dim FindResult As List(Of WebMenu) = WebMenu.CDBSelect(Of WebMenu)("Select * From " & GetType(WebMenu).Name & " Where ID='" & Me.FK_WebMenuID & "'")
                        If FindResult.Count > 0 Then
                            _AboutWebMenu = FindResult(0)
                        End If
                    End If
                    Return _AboutWebMenu
                End Get
                Private Set(ByVal value As WebMenu)
                    _AboutWebMenu = value
                End Set
            End Property

#End Region

        End Class
	End Namespace
End Namespace