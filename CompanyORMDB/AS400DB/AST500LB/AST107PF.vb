Namespace AST500LB
    ''' <summary>
    ''' 備品與主設備對照
    ''' </summary>
    ''' <remarks></remarks>
    Public Class AST107PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("AST500LB", GetType(AST107PF).Name)
        End Sub

#Region "備品編號 屬性:NUMBER"
        Private _NUMBER As System.String
        ''' <summary>
        ''' 備品編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property NUMBER() As System.String
            Get
                Return _NUMBER
            End Get
            Set(ByVal value As System.String)
                _NUMBER = value
            End Set
        End Property
#End Region
#Region "主設備編號 屬性:MASTER"
        Private _MASTER As System.String
        ''' <summary>
        ''' 主設備編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MASTER() As System.String
            Get
                Return _MASTER
            End Get
            Set(ByVal value As System.String)
                _MASTER = value
            End Set
        End Property
#End Region

#Region "相關設備 屬性:AboutAssets"
        Private Shared _ALLAssets As List(Of AST101PF) = Nothing
        Private _AboutAssets As List(Of AST101PF) = Nothing
        ''' <summary>
        ''' 相關設備
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutAssets() As List(Of AST101PF)
            Get
                If IsNothing(_AboutAssets) Then
                    Dim Qry As String = Nothing
                    If IsNothing(_ALLAssets) Then
                        Qry = "Select * From " & (New AST101PF).CDBFullAS400DBPath.Trim & ".ASTFSA"
                        _ALLAssets = CDBSelect(Of AST101PF)(Qry, Me.CDBCurrentUseSQLQueryAdapter)
                    End If
                    _AboutAssets = New List(Of AST101PF)
                    For Each EachItem As AST101PF In _ALLAssets
                        If EachItem.NUMBER.Trim = Me.NUMBER.Trim OrElse EachItem.NUMBER.Trim = Me.MASTER.Trim Then
                            _AboutAssets.Add(EachItem)
                        End If
                        If _AboutAssets.Count >= 2 Then
                            Exit For
                        End If
                    Next
                End If
                Return _AboutAssets
            End Get
        End Property
#End Region
#Region "相關主設備 屬性:AboutMasterAsset"
        Private _AboutMasterAsset As AST101PF = Nothing
        ''' <summary>
        ''' 相關主設備
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
      ReadOnly Property AboutMasterAsset() As AST101PF
            Get
                If IsNothing(_AboutMasterAsset) Then
                    For Each EachItem As AST101PF In Me.AboutAssets
                        If EachItem.NUMBER.Trim = Me.MASTER.Trim Then
                            _AboutMasterAsset = EachItem
                            Exit For
                        End If
                    Next
                End If
                Return _AboutMasterAsset
            End Get
        End Property
#End Region
#Region "相關備品設備 屬性:AboutSubAsset"
        Private _AboutSubAsset As AST101PF = Nothing
        ''' <summary>
        ''' 相關備品設備
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutSubAsset() As AST101PF
            Get
                If IsNothing(_AboutSubAsset) Then
                    For Each EachItem As AST101PF In Me.AboutAssets
                        If EachItem.NUMBER.Trim = Me.NUMBER.Trim Then
                            _AboutSubAsset = EachItem
                            Exit For
                        End If
                    Next
                End If
                Return _AboutSubAsset
            End Get
        End Property
#End Region
#Region "主設備名稱 屬性:MasterAssetName"
        Private _MasterAssetName As String = Nothing
        ''' <summary>
        ''' 主設備名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property MasterAssetName() As String
            Get
                If IsNothing(_MasterAssetName) AndAlso Not IsNothing(Me.AboutMasterAsset) Then
                    _MasterAssetName = Me.AboutMasterAsset.NAME
                End If
                Return _MasterAssetName
            End Get
        End Property
#End Region
#Region "備品設備名稱 屬性:SubAssetName"
        Private _SubAssetName As String
        ''' <summary>
        ''' 備品設備名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property SubAssetName() As String
            Get
                If IsNothing(_SubAssetName) AndAlso Not IsNothing(Me.AboutSubAsset) Then
                    _SubAssetName = Me.AboutSubAsset.NAME
                End If
                Return _SubAssetName
            End Get
        End Property
#End Region


    End Class
End Namespace