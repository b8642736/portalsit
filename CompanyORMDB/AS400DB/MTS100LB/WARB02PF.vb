Namespace MTS100LB
Public Class WARB02PF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("MTS100LB", GetType(WARB02PF).Name)
	End Sub

#Region "合約案號 屬性:WRB201"
	Private _WRB201 As System.String
	''' <summary>
	''' 合約案號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property WRB201 () As System.String
		Get
			Return _WRB201
		End Get
		Set(Byval value as System.String)
			_WRB201 = value
		End Set
	End Property
#End Region
#Region "料號 屬性:WRB202"
	Private _WRB202 As System.String
	''' <summary>
	''' 料號
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property WRB202 () As System.String
		Get
			Return _WRB202
		End Get
		Set(Byval value as System.String)
			_WRB202 = value
		End Set
	End Property
#End Region
#Region "數量 屬性:WRB203"
        Private _WRB203 As Double
	''' <summary>
	''' 數量
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
        Public Property WRB203() As Double
            Get
                Return _WRB203
            End Get
            Set(ByVal value As Double)
                _WRB203 = value
            End Set
        End Property
#End Region
#Region "進料起日 屬性:WRB204"
	Private _WRB204 As System.Int32
	''' <summary>
	''' 進料起日
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property WRB204 () As System.Int32
		Get
			Return _WRB204
		End Get
		Set(Byval value as System.Int32)
			_WRB204 = value
		End Set
	End Property
#End Region
#Region "進料訖日 屬性:WRB205"
	Private _WRB205 As System.Int32
	''' <summary>
	''' 進料訖日
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property WRB205 () As System.Int32
		Get
			Return _WRB205
		End Get
		Set(Byval value as System.Int32)
			_WRB205 = value
		End Set
	End Property
#End Region
#Region "安排進料單位 屬性:WRB206"
	Private _WRB206 As System.String
	''' <summary>
	''' 安排進料單位
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB206 () As System.String
		Get
			Return _WRB206
		End Get
		Set(Byval value as System.String)
			_WRB206 = value
		End Set
	End Property
#End Region
#Region "單據種類 屬性:WRB207"
	Private _WRB207 As System.String
	''' <summary>
	''' 單據種類
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB207 () As System.String
		Get
			Return _WRB207
		End Get
		Set(Byval value as System.String)
			_WRB207 = value
		End Set
	End Property
#End Region
#Region "退料來源 屬性:WRB208"
	Private _WRB208 As System.String
	''' <summary>
	''' 退料來源
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB208 () As System.String
		Get
			Return _WRB208
		End Get
		Set(Byval value as System.String)
			_WRB208 = value
		End Set
	End Property
#End Region
#Region "代軋批次 屬性:WRB209"
	Private _WRB209 As System.String
	''' <summary>
	''' 代軋批次
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB209 () As System.String
		Get
			Return _WRB209
		End Get
		Set(Byval value as System.String)
			_WRB209 = value
		End Set
	End Property
#End Region
#Region "登錄人員 屬性:WRB2UR"
	Private _WRB2UR As System.String
	''' <summary>
	''' 登錄人員
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property WRB2UR () As System.String
		Get
			Return _WRB2UR
		End Get
		Set(Byval value as System.String)
			_WRB2UR = value
		End Set
	End Property
#End Region
#Region "登錄時間 屬性:WRB2TM"
        Private _WRB2TM As Long
	''' <summary>
	''' 登錄時間
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
        Public Property WRB2TM() As Long
            Get
                Return _WRB2TM
            End Get
            Set(ByVal value As Long)
                _WRB2TM = value
            End Set
        End Property
#End Region

#Region "未進數量 屬性:UnArriveWeight"
        ''' <summary>
        ''' 未進數量 
        ''' </summary>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        ReadOnly Property UnArriveWeight As Double
            Get
                Dim ArriveWeight As Double = 0
                For Each EachItem As WARB03PF In About_WARB03PFs
                    ArriveWeight += EachItem.WRB306
                Next
                Return Me.WRB203 - ArriveWeight
            End Get
        End Property
#End Region

#Region "相關合約實際進料車次檔 屬性:About_WARB03PFs"
        Private _About_WARB03PFs As List(Of WARB03PF)
        Private _About_WARB03PFsLastEditTime As DateTime = New DateTime(2000, 1, 1)
        ''' <summary>
        ''' 相關合約實際進料車次檔
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property About_WARB03PFs As List(Of WARB03PF)
            Get
                If IsNothing(_About_WARB03PFs) OrElse Now.Subtract(_About_WARB03PFsLastEditTime).TotalSeconds > 2 Then
                    _About_WARB03PFs = WARB03PF.CDBSelect(Of WARB03PF)("Select * From @#MTS100LB.WARB03PF Where WRB302='" & Me.WRB202 & "' and WRB303='" & Me.WRB201 & "' and WRB301=" & Me.WRB204 & " Order by wrb301 desc ", AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    _About_WARB03PFsLastEditTime = Now
                End If
                Return _About_WARB03PFs
            End Get
            Set(value As List(Of WARB03PF))
                _About_WARB03PFs = value
                _About_WARB03PFsLastEditTime = Now
            End Set
        End Property
#End Region

    End Class
End Namespace