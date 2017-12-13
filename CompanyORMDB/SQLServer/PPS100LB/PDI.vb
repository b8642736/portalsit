Namespace SQLServer
	Namespace PPS100LB
	Public Class PDI
	Inherits ClassDBSQLServer

	Sub New()
		MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO,CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m,"PPS100LB")
            End Sub

#Region "鋼捲編號 屬性:CoilFullNumber"
            Private _CoilFullNumber As String
            ''' <summary>
            ''' 鋼捲編號
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property CoilFullNumber() As String
                Get
                    Return _CoilFullNumber
                End Get
                Set(ByVal value As String)
                    _CoilFullNumber = value
                End Set
            End Property
#End Region
#Region "訊息建立部門 屬性:CreateMsgDept"
            Private _CreateMsgDept As System.String
            ''' <summary>
            ''' 訊息建立部門
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property CreateMsgDept() As System.String
                Get
                    Return _CreateMsgDept
                End Get
                Set(ByVal value As System.String)
                    _CreateMsgDept = value
                End Set
            End Property
#End Region
#Region "訊息建立時間 屬性:CreateMsgTime"
            Private _CreateMsgTime As System.DateTime
            ''' <summary>
            ''' 訊息建立時間
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property CreateMsgTime() As System.DateTime
                Get
                    Return _CreateMsgTime
                End Get
                Set(ByVal value As System.DateTime)
                    _CreateMsgTime = value
                End Set
            End Property
#End Region
#Region "訊息類別 屬性:MsgType"
            Private _MsgType As System.Int32
            ''' <summary>
            ''' 訊息類別
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks>1.成品線作業規定</remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property MsgType() As System.Int32
                Get
                    Return _MsgType
                End Get
                Set(ByVal value As System.Int32)
                    _MsgType = value
                End Set
            End Property
#End Region
#Region "訊息類別名稱 屬性:MsgTypeName"
            Private _MsgTypeName As System.String
            ''' <summary>
            ''' 訊息類別名稱
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks>1.成品線作業規定</remarks>
            Public Property MsgTypeName() As System.String
                Get
                    Return _MsgTypeName
                End Get
                Set(ByVal value As System.String)
                    _MsgTypeName = value
                End Set
            End Property
#End Region
#Region "QA分捲名稱 屬性:QASeparateName"
            Private _QASeparateName As System.String
            ''' <summary>
            ''' QA分捲名稱
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks>QA分捲名稱 SA~SZ:分捲 H:頭料 T.尾料 M1~M9:中間段</remarks>
            Public Property QASeparateName() As System.String
                Get
                    Return _QASeparateName
                End Get
                Set(ByVal value As System.String)
                    _QASeparateName = value
                End Set
            End Property
#End Region
#Region "鋼捲寬度 屬性:CoilWidth"
            Private _CoilWidth As System.Decimal
            ''' <summary>
            ''' 鋼捲寬度
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CoilWidth() As System.Decimal
                Get
                    Return _CoilWidth
                End Get
                Set(ByVal value As System.Decimal)
                    _CoilWidth = value
                End Set
            End Property
#End Region
#Region "鋼捲厚度 屬性:CoilThick"
            Private _CoilThick As System.Decimal
            ''' <summary>
            ''' 鋼捲厚度
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CoilThick() As System.Decimal
                Get
                    Return _CoilThick
                End Get
                Set(ByVal value As System.Decimal)
                    _CoilThick = value
                End Set
            End Property
#End Region
#Region "鋼捲長度 屬性:CoilLength"
            Private _CoilLength As System.Decimal
            ''' <summary>
            ''' 鋼捲長度
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CoilLength() As System.Decimal
                Get
                    Return _CoilLength
                End Get
                Set(ByVal value As System.Decimal)
                    _CoilLength = value
                End Set
            End Property
#End Region
#Region "前切缺陷 屬性:FrontCutBug"
            Private _FrontCutBug As String
            ''' <summary>
            ''' 前切缺陷
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FrontCutBug() As String
                Get
                    Return _FrontCutBug
                End Get
                Set(ByVal value As String)
                    _FrontCutBug = value
                End Set
            End Property

#End Region
#Region "前切長度 屬性:FrontCutLength"
            Private _FrontCutLength As System.Decimal
            ''' <summary>
            ''' 前切長度
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property FrontCutLength() As System.Decimal
                Get
                    Return _FrontCutLength
                End Get
                Set(ByVal value As System.Decimal)
                    _FrontCutLength = value
                End Set
            End Property

#End Region
#Region "後切缺陷 屬性:TailCutBug"
            Private _TailCutBug As String
            ''' <summary>
            ''' 後切缺陷
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property TailCutBug() As String
                Get
                    Return _TailCutBug
                End Get
                Set(ByVal value As String)
                    _TailCutBug = value
                End Set
            End Property

#End Region
#Region "後切長度 屬性:TailCutLength"
            Private _TailCutLength As Decimal
            ''' <summary>
            ''' 後切長度
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property TailCutLength() As Decimal
                Get
                    Return _TailCutLength
                End Get
                Set(ByVal value As Decimal)
                    _TailCutLength = value
                End Set
            End Property

#End Region
#Region "執行線別 屬性:RunLineName"
            Private _RunLineName As String
            ''' <summary>
            ''' 執行線別
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property RunLineName() As String
                Get
                    If String.IsNullOrEmpty(_RunLineName) Then
                        Return ""
                    End If
                    Return _RunLineName.Trim
                End Get
                Set(ByVal value As String)
                    _RunLineName = value
                End Set
            End Property

#End Region
#Region "備註1"
            Property ToLineMessage As String
#End Region

#Region "QA分捲名稱文字  屬性:QASeparateNameText"
            ''' <summary>
            ''' QA分捲名稱文字
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks>QA分捲名稱 SA~SZ:分捲 H:頭料 T.尾料 M1~M9:中間段</remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
            ReadOnly Property QASeparateNameText As String
                Get
                    Select Case True
                        Case String.IsNullOrEmpty(QASeparateName) OrElse QASeparateName.Trim.Length = 0
                            Return Nothing
                        Case QASeparateName.Substring(0, 1) = "S"
                            Return QASeparateName.PadRight(2).Substring(1, 1) & "捲"
                        Case QASeparateName.Substring(0, 1) = "H"
                            Return "頭料"
                        Case QASeparateName.Substring(0, 1) = "T"
                            Return "尾料"
                        Case QASeparateName.Substring(0, 1) = "M"
                            Return "中" & QASeparateName.PadRight(2).Substring(1, 1)
                    End Select
                    Return "未知"
                End Get
            End Property
#End Region

        End Class
	End Namespace
End Namespace