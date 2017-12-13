Namespace MTS600LB
Public Class MTSBC1PF
	Inherits ClassDBAS400

	Sub New()
            MyBase.New("MTS600LB", GetType(MTSBC1PF).Name)
        End Sub

#Region "記錄時間 屬性:MTSB01"
        Private _MTSB01 As System.String
        ''' <summary>
        ''' 記錄時間
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property MTSB01() As System.String
            Get
                Return _MTSB01
            End Get
            Set(ByVal value As System.String)
                _MTSB01 = value
            End Set
        End Property
#End Region
#Region "開標日期 屬性:MTSB02"
        Private _MTSB02 As System.String
        ''' <summary>
        ''' 開標日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MTSB02() As System.String
            Get
                Return _MTSB02
            End Get
            Set(ByVal value As System.String)
                _MTSB02 = value
            End Set
        End Property
#End Region
#Region "開標時間起 屬性:MTSB03"
	Private _MTSB03 As System.String
	''' <summary>
	''' 開標時間起
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
        Public Property MTSB03() As System.String
            Get
                Return _MTSB03
            End Get
            Set(ByVal value As System.String)
                _MTSB03 = value
            End Set
        End Property
#End Region
#Region "開標時間訖 屬性:MTSB04"
	Private _MTSB04 As System.String
	''' <summary>
	''' 開標時間訖
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSB04 () As System.String
		Get
			Return _MTSB04
		End Get
		Set(Byval value as System.String)
			_MTSB04 = value
		End Set
	End Property
#End Region
#Region "開標金額類別 屬性:MTSB05"
	Private _MTSB05 As System.Int32
	''' <summary>
	''' 開標金額類別
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSB05 () As System.Int32
		Get
			Return _MTSB05
		End Get
		Set(Byval value as System.Int32)
			_MTSB05 = value
		End Set
	End Property
#End Region
#Region "使用開標室 屬性:MTSB06"
	Private _MTSB06 As System.Int32
	''' <summary>
	''' 使用開標室
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSB06 () As System.Int32
		Get
			Return _MTSB06
		End Get
		Set(Byval value as System.Int32)
			_MTSB06 = value
		End Set
	End Property
#End Region
#Region "開標說明 屬性:MTSB07"
	Private _MTSB07 As System.String
	''' <summary>
	''' 開標說明
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MTSB07 () As System.String
            Get
                _MTSB07 = AS400StringConverter.QuickConvert(_MTSB07, AS400StringConverter.SourceDataTypeEnum.AS400)
                Return _MTSB07
            End Get
		Set(Byval value as System.String)
			_MTSB07 = value
		End Set
	End Property
#End Region
#Region "輸入人工號 屬性:MTSB08"
        Private _MTSB08 As System.String
        ''' <summary>
        ''' 輸入人工號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MTSB08() As System.String
            Get
                Return _MTSB08
            End Get
            Set(ByVal value As System.String)
                _MTSB08 = value
            End Set
        End Property
#End Region

#Region "開標類別說明 屬性:MTSB05Descript"
        ''' <summary>
        ''' 開標類別說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property MTSB05Descript As String
            Get
                Select Case MTSB05
                    Case 1
                        Return "100(不含)萬以下"
                    Case 2
                        Return "100~1000(不含)萬"
                    Case 3
                        Return "1000萬以上"
                    Case Else
                        Return "未知"
                End Select
            End Get
        End Property
#End Region
#Region "開標區域說明 屬性:MTSB06Descript"
        ''' <summary>
        ''' 開標區域說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property MTSB06Descript As String
            Get
                Select Case MTSB06
                    Case 1
                        Return "1室"
                    Case 2
                        Return "2室"
                    Case 3
                        Return "3室"
                    Case 4
                        Return "4室"
                    Case 5
                        Return "1樓"
                    Case 6
                        Return "5室"
                    Case 7
                        Return "6室"
                    Case Else
                        Return "未知"
                End Select
            End Get
        End Property
#End Region

    End Class
End Namespace