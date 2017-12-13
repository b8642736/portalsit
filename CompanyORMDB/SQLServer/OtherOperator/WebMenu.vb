Namespace SQLServer
    Namespace OtherOperator
        <Serializable()> _
        Public Class WebMenu
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "OtherOperator")
                Me.ID = Guid.NewGuid.ToString
                Me.NodeType = 1
                Me.IsEnable = True
            End Sub

#Region "ID 屬性:ID"
            Private _ID As System.String
            ''' <summary>
            ''' ID
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property ID() As System.String
                Get
                    Return _ID
                End Get
                Set(ByVal value As System.String)
                    _ID = value
                End Set
            End Property
#End Region
#Region "Menu名稱 屬性:MenuName"

            Private _MenuName As String
            ''' <summary>
            ''' Menu名稱
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property MenuName() As String
                Get
                    Return _MenuName
                End Get
                Set(ByVal value As String)
                    _MenuName = value
                End Set
            End Property

#End Region
#Region "NodeType 屬性:NodeType"
            Private _NodeType As System.Int32
            ''' <summary>
            ''' NodeType
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property NodeType() As System.Int32
                Get
                    Return _NodeType
                End Get
                Set(ByVal value As System.Int32)
                    _NodeType = value
                End Set
            End Property
#End Region
#Region "NodeText 屬性:NodeText"
            Private _NodeText As System.String
            ''' <summary>
            ''' NodeText
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property NodeText() As System.String
                Get
                    Return _NodeText
                End Get
                Set(ByVal value As System.String)
                    _NodeText = value
                End Set
            End Property
#End Region
#Region "GoWebSitName 屬性:GoWebSitName"
            Private _GoWebSitName As System.String
            ''' <summary>
            ''' GoWebSitName
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property GoWebSitName() As System.String
                Get
                    Return _GoWebSitName
                End Get
                Set(ByVal value As System.String)
                    _GoWebSitName = value
                End Set
            End Property
#End Region
#Region "GoWebSitFileName 屬性:GoWebSitFileName"
            Private _GoWebSitFileName As System.String
            ''' <summary>
            ''' GoWebSitFileName
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property GoWebSitFileName() As System.String
                Get
                    Return _GoWebSitFileName
                End Get
                Set(ByVal value As System.String)
                    _GoWebSitFileName = value
                End Set
            End Property
#End Region
#Region "ToolTip 屬性:ToolTip"
            Private _ToolTip As System.String
            ''' <summary>
            ''' ToolTip
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ToolTip() As System.String
                Get
                    Return _ToolTip
                End Get
                Set(ByVal value As System.String)
                    _ToolTip = value
                End Set
            End Property
#End Region
#Region "IsEnable 屬性:IsEnable"
            Private _IsEnable As System.Boolean
            ''' <summary>
            ''' IsEnable
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property IsEnable() As System.Boolean
                Get
                    Return _IsEnable
                End Get
                Set(ByVal value As System.Boolean)
                    _IsEnable = value
                End Set
            End Property
#End Region
#Region "FK_UpWebMenuID 屬性:FK_UpWebMenuID"

            Private _FK_UpWebMenuID As String
            ''' <summary>
            ''' FK_UpWebMenuID
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FK_UpWebMenuID() As String
                Get
                    Return _FK_UpWebMenuID
                End Get
                Set(ByVal value As String)
                    _FK_UpWebMenuID = value
                End Set
            End Property

#End Region


#Region "相關網頁Menu授權 屬性:AboutWebMenuDisplayForAuthoritys"

            Private _AboutWebMenuDisplayForAuthoritys As List(Of WebMenuDisplayForAuthority)
            ''' <summary>
            ''' 相關網頁Menu授權
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            Public Property AboutWebMenuDisplayForAuthoritys() As List(Of WebMenuDisplayForAuthority)
                Get
                    If IsNothing(_AboutWebMenuDisplayForAuthoritys) Then
                        _AboutWebMenuDisplayForAuthoritys = WebMenu.CDBSelect(Of WebMenuDisplayForAuthority)("Select * From " & GetType(WebMenuDisplayForAuthority).Name & " Where FK_WebMenuID='" & Me.ID & "'")
                    End If
                    Return _AboutWebMenuDisplayForAuthoritys
                End Get
                Private Set(ByVal value As List(Of WebMenuDisplayForAuthority))
                    _AboutWebMenuDisplayForAuthoritys = value
                End Set
            End Property

#End Region

        End Class
    End Namespace
End Namespace