Namespace SPMSQLServer
    Namespace SPM
        Public Class TEAccDepSelect
            Inherits ClassDBSQLServer

            Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.ServerSPM, "SPM")
            End Sub

#Region "電子表單類別 屬性:AC0001"

            Private _AC0001 As Integer



            ''' <summary>
            ''' 電子表單類別
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property AC0001() As Integer
                Get
                    Return _AC0001
                End Get
                Set(ByVal value As Integer)
                    _AC0001 = value
                End Set
            End Property
#End Region
#Region "使用單位代碼 屬性:AC0002"

            Private _AC0002 As String
            ''' <summary>
            ''' 使用單位代碼
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property AC0002() As String
                Get
                    Return _AC0002
                End Get
                Set(ByVal value As String)
                    _AC0002 = value
                End Set
            End Property
#End Region
#Region "會計科目代號 屬性:AC0003"

            Private _AC0003 As String
            ''' <summary>
            ''' 會計科目代號
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property AC0003() As String
                Get
                    Return _AC0003
                End Get
                Set(ByVal value As String)
                    _AC0003 = value
                End Set
            End Property
#End Region
#Region "明細科目代號 屬性:AC0004"

            Private _AC0004 As String
            ''' <summary>
            ''' 明細科目代號
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property AC0004() As String
                Get
                    Return _AC0004
                End Get
                Set(ByVal value As String)
                    _AC0004 = value
                End Set
            End Property
#End Region
#Region "使用說明 屬性:AC0005"

            Private _AC0005 As String
            ''' <summary>
            ''' 使用說明
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property AC0005() As String
                Get
                    Return _AC0005
                End Get
                Set(ByVal value As String)
                    _AC0005 = value
                End Set
            End Property
#End Region


#Region "電子表單類別中文 屬性:AC0001Chinese"
            ''' <summary>
            ''' 電子表單類別中文
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AC0001Chinese As String
                Get
                    Select Case True
                        Case AC0001 = 1
                            Return "外修申請單"
                    End Select
                    Return String.Empty
                End Get
            End Property
#End Region

#Region "使用單位中文 屬性:AC0002Chinese"
            Private _AC0002Chinese As String = Nothing
            ''' <summary>
            ''' 會計科目中文
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AC0002Chinese As String
                Get
                    If String.IsNullOrEmpty(_AC0003Chinese) Then
                        For Each EachItem In GPL2.DEPCODPF.AllDEPCODPFs
                            If EachItem.DEPCOD.Trim = Me.AC0002.Trim Then
                                _AC0002Chinese = EachItem.DEPNAM
                                Exit For
                            End If
                        Next
                    End If
                    Return _AC0002Chinese
                End Get
            End Property
#End Region

#Region "會計科目中文 屬性:AC0003Chinese"
            Private _AC0003Chinese As String = Nothing
            ''' <summary>
            ''' 會計科目中文
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AC0003Chinese As String
                Get
                    If String.IsNullOrEmpty(_AC0003Chinese) Then
                        For Each EachItem In ACLIB.ACA010PF.AllACA010PFs
                            If EachItem.ACCTNO.Trim = Me.AC0003.Trim Then
                                _AC0003Chinese = EachItem.ACCTNM
                                Exit For
                            End If
                        Next
                    End If
                    Return _AC0003Chinese
                End Get
            End Property
#End Region

#Region "明細科目中文 屬性:AC004Chinese"
            Private _AC0004Chinese As String = Nothing
            ''' <summary>
            ''' 明細科目中文
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AC0004Chinese As String
                Get
                    If String.IsNullOrEmpty(_AC0004Chinese) Then
                        For Each EachItem In ACLIB.ACA020PF.AllACA020PFs
                            If EachItem.DETLNO.Trim = Me.AC0004.Trim Then
                                _AC0004Chinese = EachItem.DETLNM
                                Exit For
                            End If
                        Next
                    End If
                    Return _AC0004Chinese
                End Get
            End Property
#End Region

#Region "使用單位數字加中文 屬性:AC0002NOAndChinese"
            ''' <summary>
            ''' 使用單位數字加中文
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AC0002NOAndChinese As String
                Get
                    Return Me.AC0002 & Me.AC0002Chinese
                End Get
            End Property

#End Region

#Region "會計科目數字加中文 屬性:AC0003NOAndChinese"
            ''' <summary>
            ''' 會計科目數字加中文
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AC0003NOAndChinese As String
                Get
                    Return Me.AC0003 & Me.AC0003Chinese
                End Get
            End Property
#End Region

#Region "明細科目數字加中文 屬性:AC004NOAndChinese"
            ''' <summary>
            ''' 會計科目數字加中文
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property AC0004NOAndChinese As String
                Get
                    Return Me.AC0004 & Me.AC0004Chinese
                End Get
            End Property
#End Region



        End Class

    End Namespace
End Namespace
