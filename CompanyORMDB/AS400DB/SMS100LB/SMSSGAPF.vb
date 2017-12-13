Namespace SMS100LB
    ''' <summary>
    ''' SGM鋼胚主檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SMSSGAPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SMS100LB", GetType(SMSSGAPF).Name)
        End Sub

#Region "爐號 屬性:SGA01"

        Private _SGA01 As String
        ''' <summary>
        ''' 爐號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SGA01() As String
            Get
                Return _SGA01
            End Get
            Set(ByVal value As String)
                _SGA01 = value
            End Set
        End Property

#End Region
#Region "連鑄爐次 屬性:SGA02"

        Private _SGA02 As String
        ''' <summary>
        ''' 連鑄爐次
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SGA02() As String
            Get
                Return _SGA02
            End Get
            Set(ByVal value As String)
                _SGA02 = value
            End Set
        End Property

#End Region
#Region "這一爐第幾塊鋼胚 屬性:SGA03"
        Private _SGA03 As Integer
        ''' <summary>
        ''' 這一爐第幾塊鋼胚 0.尾塊 1,2,3 其餘
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SGA03() As Integer
            Get
                Return _SGA03
            End Get
            Set(ByVal value As Integer)
                _SGA03 = value
            End Set
        End Property
#End Region
#Region "鋼胚切割 屬性:SGA04"

        Private _SGA04 As String
        ''' <summary>
        ''' 鋼胚切割 0.未切 1,2,3 有切
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SGA04() As String
            Get
                Return _SGA04
            End Get
            Set(ByVal value As String)
                _SGA04 = value
            End Set
        End Property

#End Region
#Region "鋼種 屬性:SGA05"

        Private _SGA05 As String
        ''' <summary>
        ''' 鋼種
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA05() As String
            Get
                Return _SGA05
            End Get
            Set(ByVal value As String)
                _SGA05 = value
            End Set
        End Property

#End Region
#Region "材質 屬性:SGA06"

        Private _SGA06 As String
        ''' <summary>
        ''' 材質
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA06() As String
            Get
                Return _SGA06
            End Get
            Set(ByVal value As String)
                _SGA06 = value
            End Set
        End Property

#End Region
#Region "澆鑄日期 DATE 屬性:SGA07"
        Private _SGA07 As System.Int32
        ''' <summary>
        ''' 澆鑄日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA07() As System.Int32
            Get
                Return _SGA07
            End Get
            Set(ByVal value As System.Int32)
                _SGA07 = value
            End Set
        End Property
#End Region
#Region "LENGTH OF CCM-M/M 屬性:SGA08"
        Private _SGA08 As System.Int32
        ''' <summary>
        ''' LENGTH OF CCM-M/M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA08() As System.Int32
            Get
                Return _SGA08
            End Get
            Set(ByVal value As System.Int32)
                _SGA08 = value
            End Set
        End Property
#End Region
#Region "WIDTH OF CCM-M/M 屬性:SGA09"
        Private _SGA09 As System.Int32
        ''' <summary>
        ''' WIDTH OF CCM-M/M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA09() As System.Int32
            Get
                Return _SGA09
            End Get
            Set(ByVal value As System.Int32)
                _SGA09 = value
            End Set
        End Property
#End Region
#Region "THICK OF CCM-M/M 屬性:SGA10"
        Private _SGA10 As System.Int32
        ''' <summary>
        ''' THICK OF CCM-M/M
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA10() As System.Int32
            Get
                Return _SGA10
            End Get
            Set(ByVal value As System.Int32)
                _SGA10 = value
            End Set
        End Property
#End Region
#Region "LENGTH OF CCM-STANDARD 屬性:SGA11"
        Private _SGA11 As System.Int32
        ''' <summary>
        ''' LENGTH OF CCM-STANDARD
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA11() As System.Int32
            Get
                Return _SGA11
            End Get
            Set(ByVal value As System.Int32)
                _SGA11 = value
            End Set
        End Property
#End Region
#Region "WIDTH OF CCM-STANDARD 屬性:SGA12"
        Private _SGA12 As System.Int32
        ''' <summary>
        ''' WIDTH OF CCM-STANDARD
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA12() As System.Int32
            Get
                Return _SGA12
            End Get
            Set(ByVal value As System.Int32)
                _SGA12 = value
            End Set
        End Property
#End Region
#Region "THICK OF CCM-STANDARD 屬性:SGA13"
        Private _SGA13 As System.Int32
        ''' <summary>
        ''' THICK OF CCM-STANDARD
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA13() As System.Int32
            Get
                Return _SGA13
            End Get
            Set(ByVal value As System.Int32)
                _SGA13 = value
            End Set
        End Property
#End Region
#Region "WEIGHT-ESTIMATE 屬性:SGA14"
        Private _SGA14 As System.Int32
        ''' <summary>
        ''' WEIGHT-ESTIMATE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA14() As System.Int32
            Get
                Return _SGA14
            End Get
            Set(ByVal value As System.Int32)
                _SGA14 = value
            End Set
        End Property
#End Region
#Region "研磨前過磅重量 屬性:SGA15"
        Private _SGA15 As System.Int32
        ''' <summary>
        ''' 研磨前過磅重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA15() As System.Int32
            Get
                Return _SGA15
            End Get
            Set(ByVal value As System.Int32)
                _SGA15 = value
            End Set
        End Property
#End Region
#Region "GRINDING DATE 屬性:SGA16"
        Private _SGA16 As System.Int32
        ''' <summary>
        ''' GRINDING DATE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA16() As System.Int32
            Get
                Return _SGA16
            End Get
            Set(ByVal value As System.Int32)
                _SGA16 = value
            End Set
        End Property
#End Region
#Region "班別 屬性:SGA17"
        Private _SGA17 As String
        ''' <summary>
        ''' 班別
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA17() As String
            Get
                Return _SGA17
            End Get
            Set(ByVal value As String)
                _SGA17 = value
            End Set
        End Property

#End Region
#Region "LENGTH-AFTER GRINDING 屬性:SGA18"
        Private _SGA18 As System.Int32
        ''' <summary>
        ''' LENGTH-AFTER GRINDING
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA18() As System.Int32
            Get
                Return _SGA18
            End Get
            Set(ByVal value As System.Int32)
                _SGA18 = value
            End Set
        End Property
#End Region
#Region "WIDTH-AFTER GRINDING 屬性:SGA19"
        Private _SGA19 As System.Int32
        ''' <summary>
        ''' WIDTH-AFTER GRINDING
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA19() As System.Int32
            Get
                Return _SGA19
            End Get
            Set(ByVal value As System.Int32)
                _SGA19 = value
            End Set
        End Property
#End Region
#Region "THICK-AFTER GRINDING 屬性:SGA20"
        Private _SGA20 As System.Int32
        ''' <summary>
        ''' THICK-AFTER GRINDING
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA20() As System.Int32
            Get
                Return _SGA20
            End Get
            Set(ByVal value As System.Int32)
                _SGA20 = value
            End Set
        End Property
#End Region
#Region "STANDARD LENGTH-AFTER GRIND 屬性:SGA21"
        Private _SGA21 As System.Int32
        ''' <summary>
        ''' STANDARD LENGTH-AFTER GRIND
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA21() As System.Int32
            Get
                Return _SGA21
            End Get
            Set(ByVal value As System.Int32)
                _SGA21 = value
            End Set
        End Property
#End Region
#Region "STANDARD WIDTH 屬性:SGA22"
        Private _SGA22 As System.Int32
        ''' <summary>
        ''' STANDARD WIDTH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA22() As System.Int32
            Get
                Return _SGA22
            End Get
            Set(ByVal value As System.Int32)
                _SGA22 = value
            End Set
        End Property
#End Region
#Region "研磨角度 屬性:SGA23"
        Private _SGA23 As System.Int32
        ''' <summary>
        ''' 研磨角度
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA23() As System.Int32
            Get
                Return _SGA23
            End Get
            Set(ByVal value As System.Int32)
                _SGA23 = value
            End Set
        End Property
#End Region
#Region "研磨後過磅重量 屬性:SGA24"
        Private _SGA24 As System.Int32
        ''' <summary>
        ''' 研磨後過磅重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA24() As System.Int32
            Get
                Return _SGA24
            End Get
            Set(ByVal value As System.Int32)
                _SGA24 = value
            End Set
        End Property
#End Region
#Region "RE-GRINDING CODE 屬性:SGA25"
        Private _SGA25 As System.Int32
        ''' <summary>
        ''' RE-GRINDING CODE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SGA25() As System.Int32
            Get
                Return _SGA25
            End Get
            Set(ByVal value As System.Int32)
                _SGA25 = value
            End Set
        End Property
#End Region
#Region "氣罩異常註記 屬性:SGA26"
        Private _SGA26 As String
        ''' <summary>
        ''' 氣罩異常註記
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA26() As String
            Get
                Return _SGA26
            End Get
            Set(ByVal value As String)
                _SGA26 = value
            End Set
        End Property

#End Region
#Region "切塊退回重量 屬性:SGA27"
        Private _SGA27 As System.Int32
        ''' <summary>
        ''' 切塊退回重量
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA27() As System.Int32
            Get
                Return _SGA27
            End Get
            Set(ByVal value As System.Int32)
                _SGA27 = value
            End Set
        End Property
#End Region
#Region "INSPECTION DATE 屬性:SGA28"
        Private _SGA28 As System.Int32
        ''' <summary>
        ''' INSPECTION DATE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA28() As System.Int32
            Get
                Return _SGA28
            End Get
            Set(ByVal value As System.Int32)
                _SGA28 = value
            End Set
        End Property
#End Region
#Region "LOCATION-AREA 屬性:SGA29"
        Private _SGA29 As System.Int32
        ''' <summary>
        ''' LOCATION-AREA
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA29() As System.Int32
            Get
                Return _SGA29
            End Get
            Set(ByVal value As System.Int32)
                _SGA29 = value
            End Set
        End Property
#End Region
#Region "LOCATION-FLOOR 屬性:SGA30"
        Private _SGA30 As System.Int32
        ''' <summary>
        ''' LOCATION-FLOOR
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA30() As System.Int32
            Get
                Return _SGA30
            End Get
            Set(ByVal value As System.Int32)
                _SGA30 = value
            End Set
        End Property
#End Region
#Region "LOCATION-PACKING 屬性:SGA31"
        Private _SGA31 As System.Int32
        ''' <summary>
        ''' LOCATION-PACKING
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA31() As System.Int32
            Get
                Return _SGA31
            End Get
            Set(ByVal value As System.Int32)
                _SGA31 = value
            End Set
        End Property
#End Region
#Region "LOCATION-PIECE 屬性:SGA32"
        Private _SGA32 As System.Int32
        ''' <summary>
        ''' LOCATION-PIECE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA32() As System.Int32
            Get
                Return _SGA32
            End Get
            Set(ByVal value As System.Int32)
                _SGA32 = value
            End Set
        End Property
#End Region
#Region "熱軋批次 屬性:SGA33"

        Private _SGA33 As String
        ''' <summary>
        ''' 熱軋批次
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA33() As String
            Get
                Return _SGA33
            End Get
            Set(ByVal value As String)
                _SGA33 = value
            End Set
        End Property

#End Region
#Region "HIRE ROLLING-SEND DATE 屬性:SGA34"
        Private _SGA34 As System.Int32
        ''' <summary>
        ''' HIRE ROLLING-SEND DATE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA34() As System.Int32
            Get
                Return _SGA34
            End Get
            Set(ByVal value As System.Int32)
                _SGA34 = value
            End Set
        End Property
#End Region
#Region "鋼胚狀態 屬性:SGA35"

        Private _SGA35 As String
        ''' <summary>
        ''' 鋼胚狀態(空白：進入ＣＣＭ；Ａ：研磨中；Ｂ：繳庫可送外 Ｃ：已外送；＊：回廠或繳庫 ; Ｒ：重磨 )
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA35() As String
            Get
                Return _SGA35
            End Get
            Set(ByVal value As String)
                _SGA35 = value
            End Set
        End Property

#End Region

#Region "CODE-6 屬性:SGA40"
        Private _SGA40 As System.String
        ''' <summary>
        ''' CODE-6  中鋼鋼胚壓完註記(空白：正常      C：壓壞)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA40() As System.String
            Get
                Return _SGA40
            End Get
            Set(ByVal value As System.String)
                _SGA40 = value
            End Set
        End Property
#End Region

#Region "HIRE ROLLING-RECEIVE DATE 屬性:SGA41"
        Private _SGA41 As System.Int32
        ''' <summary>
        ''' HIRE ROLLING-RECEIVE DATE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SGA41() As System.Int32
            Get
                Return _SGA41
            End Get
            Set(ByVal value As System.Int32)
                _SGA41 = value
            End Set
        End Property
#End Region
#Region "澆鑄日期轉日期格式 SGA07DateType"
        ''' <summary>
        ''' 澆鑄日期轉日期格式
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property SGA07DateType() As DateTime
            Get
                Return New AS400DateConverter(Me.SGA07).DateValue
            End Get
        End Property
#End Region
#Region "研磨率 屬性:GrindRate"
        ''' <summary>
        ''' 研磨率
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property GrindRate() As Single
            Get
                Return Me.GrindWeight / Me.SGA15 * 100
            End Get
        End Property
#End Region
#Region "鋼胚號碼 屬性:StoveNumber"
        ''' <summary>
        ''' 鋼胚號碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property StoveNumber() As String
            Get
                Return Me.SGA01 & "-" & Me.SGA02 & Format(Me.SGA03, "00") & Me.SGA04
            End Get
        End Property
#End Region
#Region "研磨重量 屬性:GrindWeight"
        ''' <summary>
        ''' 研磨重量
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property GrindWeight() As Single
            Get
                Return (Me.SGA15 - Me.SGA24 - Me.SGA27)
            End Get
        End Property
#End Region
#Region "是否品質不良 屬性:IsQualityBad"
        ''' <summary>
        ''' 是否品質不良
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property IsQualityBad() As Boolean
            Get
                If SGA02 = "1" And SGA03 = 1 Then
                    Return Me.GrindWeight > 300
                End If
                Return Me.GrindWeight > 100
            End Get
        End Property
#End Region
#Region "鋼種名稱1 屬性:StoveKindName1"
        ''' <summary>
        ''' 鋼種名稱1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property StoveKindName1() As String
            Get
                Return Me.SGA05 & IIf(Me.SGA06.Trim.Length = 0, Nothing, "-" & Me.SGA06)
            End Get
        End Property
#End Region
#Region "顯示尺寸 屬性:DisplaySize"
        ''' <summary>
        ''' 顯示尺寸
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property DisplaySize() As String
            Get
                Return Me.SGA20 & "*" & Me.SGA19 & "*" & Me.SGA18
            End Get
        End Property
#End Region

#Region "鋼種+材質+寬度+長度 字串 屬性:SteelKindAndMaterialAndWidthAndLongString"
        Private _SteelKindAndMaterialAndWidthAndLongString As String = Nothing
        ''' <summary>
        ''' 鋼種+材質+寬度+長度
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property SteelKindAndMaterialAndWidthAndLongString() As String
            Get
                If Not IsNothing(_SteelKindAndMaterialAndWidthAndLongString) Then
                    Return _SteelKindAndMaterialAndWidthAndLongString
                End If
                Dim GetSGA05 As String = SGA05.Trim
                If String.IsNullOrEmpty(GetSGA05) OrElse GetSGA05.Trim = "" Then
                    _SteelKindAndMaterialAndWidthAndLongString = ""
                    Return _SteelKindAndMaterialAndWidthAndLongString
                End If
                Dim ReturnValue As String = Nothing
                ReturnValue = GetSGA05  '鋼種

                Dim GetSGA06 As String = SGA06.Trim
                If Not String.IsNullOrEmpty(GetSGA06) AndAlso GetSGA06.Trim <> "" Then
                    '鋼種+材質
                    ReturnValue = Left(GetSGA06, 2) & GetSGA05
                    If GetSGA06.Length >= 3 Then
                        ReturnValue &= "-" & Right(GetSGA06, 1)
                    End If
                End If

                Dim SetWith As Long = Val(SGA09)
                ReturnValue = IIf(IsNothing(SetWith), ReturnValue, ReturnValue & " 寬:" & SetWith & "m") '鋼種+材質+寬度

                '鋼種+材質+寬度+長度
                Dim SetSize As Long
                If SGA35 = "A" OrElse SGA35 = " " OrElse Val(SGA18) = 0 Then
                    SetSize = Val(SGA08) '研磨中
                Else
                    SetSize = Val(SGA18) '研磨後 EachItem("SGA35") = "B"
                End If
                If SGA05.Trim.Substring(0, 1) = "3" Then
                    '300系
                    If SGA05.Trim = "316L" Then
                        '316L專用 20170807 by30356
                        If Me.SGA09 <= 1040 Then
                            Select Case True
                                Case SetSize >= 7000 AndAlso SetSize <= 8000
                                    ReturnValue &= "(7.00M~8.00M)"
                                Case SetSize > 8000 AndAlso SetSize <= 8400
                                    ReturnValue &= "(8.01M~8.40M)"
                                Case SetSize > 8400 AndAlso SetSize <= 9000
                                    ReturnValue &= "(8.41M~9.00M)"
                                Case SetSize > 9000 AndAlso SetSize <= 9400
                                    ReturnValue &= "(9.01M~9.40M)"
                                Case SetSize > 9400 AndAlso SetSize <= 9600
                                    ReturnValue &= "(9.41M~9.60M)"
                                Case SetSize > 9600
                                    ReturnValue &= "(9.60M以上)"
                            End Select
                        Else
                            Select Case True
                                Case SetSize >= 7000 AndAlso SetSize <= 7400
                                    ReturnValue &= "中一(7.00M~7.40M)"
                                Case SetSize > 7400 AndAlso SetSize <= 7800
                                    ReturnValue &= "中一(7.41M~7.80M)"
                                Case SetSize > 7800 AndAlso SetSize <= 8600
                                    ReturnValue &= "中二(7.81M~8.60M)"
                                Case SetSize > 8600 AndAlso SetSize <= 9200
                                    ReturnValue &= "中三(8.61M~9.20M)"
                                Case SetSize > 9200 AndAlso SetSize <= 9600
                                    ReturnValue &= "中四(9.21M~9.60M)"
                                Case SetSize > 9600
                                    ReturnValue &= "(9.60M以上)"
                            End Select
                        End If
                    Else
                        '其它300系產品
                        If Me.SGA09 <= 1040 Then
                            Select Case True
                                Case SetSize >= 7000 AndAlso SetSize <= 8400
                                    ReturnValue &= "(7.00M~8.40M)"
                                Case SetSize > 8400 AndAlso SetSize <= 9000
                                    ReturnValue &= "(8.41M~9.00M)"
                                Case SetSize > 9000 AndAlso SetSize <= 9200
                                    ReturnValue &= "(9.01M~9.20M)"
                                Case SetSize > 9200 AndAlso SetSize <= 9600
                                    ReturnValue &= "(9.21M~9.60M)"
                                Case SetSize > 9600
                                    ReturnValue &= "(9.60M以上)"
                            End Select
                        Else
                            Select Case True
                                Case SetSize >= 7000 AndAlso SetSize <= 7400
                                    ReturnValue &= "中一(7.00M~7.40M)"
                                Case SetSize > 7400 AndAlso SetSize <= 8000
                                    ReturnValue &= "中一(7.41M~8.00M)"
                                Case SetSize > 8000 AndAlso SetSize <= 8600
                                    ReturnValue &= "中二(8.01M~8.60M)"
                                Case SetSize > 8600 AndAlso SetSize <= 9200
                                    ReturnValue &= "中三(8.60M~9.20M)"
                                Case SetSize > 9200 AndAlso SetSize <= 9600
                                    ReturnValue &= "中四(9.21M~9.60M)"
                                Case SetSize > 9600
                                    ReturnValue &= "(9.60M以上)"
                            End Select
                        End If
                    End If
                Else
                    '非300系專用
                    Select Case True
                        Case SetSize >= 7000 AndAlso SetSize <= 7400
                            ReturnValue &= "中一(7.00M~7.40M)"
                        Case SetSize > 7400 AndAlso SetSize <= 7800
                            ReturnValue &= "中一(7.41M~7.80M)"
                        Case SetSize > 7800 AndAlso SetSize <= 8600
                            ReturnValue &= "中二(7.81M~8.60M)"
                        Case SetSize > 8600 AndAlso SetSize <= 9200
                            ReturnValue &= "中三(8.61M~9.20M)"
                        Case SetSize > 9200 AndAlso SetSize <= 9600
                            ReturnValue &= "中四(9.21M~9.60M)"
                        Case SetSize > 9600
                            ReturnValue &= "(9.60M以上)"
                    End Select
                End If
                _SteelKindAndMaterialAndWidthAndLongString = ReturnValue
                Return _SteelKindAndMaterialAndWidthAndLongString
            End Get
        End Property
#End Region
#Region "鋼胚狀態重量 屬性:SGA35StateWeight"
        ''' <summary>
        ''' 鋼胚狀態重量
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property SGA35StateWeight() As Double
            Get
                Dim ReturnValue As Double = 0
                Select Case SGA35.Substring(0, 1)
                    Case " "
                        ReturnValue = IIf(SGA15 = 0, SGA14, SGA15)
                    Case "A"
                        ReturnValue = IIf(SGA24 = 0, SGA15, SGA14)
                    Case Else
                        ReturnValue = SGA24
                End Select
                Return ReturnValue
            End Get
        End Property
#End Region
#Region "鋼胚狀態長度 屬性:SGA35StateLeng"
        ''' <summary>
        ''' 鋼胚狀態長度
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property SGA35StateLeng() As Integer
            Get
                If SGA35 = " " OrElse SGA35 = "A" OrElse SGA18 = 0 Then
                    Return SGA08    '研磨中長
                End If
                Return SGA18    '研磨後長
            End Get
        End Property
#End Region

#Region "相關化學成份 屬性:AboutPPSQCAPF"
        Private _AboutPPSQCAPF As PPS100LB.PPSQCAPF = Nothing
        ''' <summary>
        ''' 相關化學成份
        ''' </summary>
        ''' <param name="CashData"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
         Property AboutPPSQCAPF(Optional ByVal CashData As List(Of PPS100LB.PPSQCAPF) = Nothing) As PPS100LB.PPSQCAPF
            Get
                If IsNothing(_AboutPPSQCAPF) Then
                    If Not IsNothing(CashData) Then
                        For Each EachItem As PPS100LB.PPSQCAPF In CashData
                            If EachItem.QCA01 = Me.SGA01 Then
                                _AboutPPSQCAPF = EachItem
                                Exit For
                            End If
                        Next
                        If IsNothing(_AboutPPSQCAPF) Then
                            Dim GetData As List(Of PPS100LB.PPSQCAPF) = PPS100LB.PPSQCAPF.CDBSelect(Of PPS100LB.PPSQCAPF)("Select * From " & (New PPS100LB.PPSQCAPF).CDBFullAS400DBPath & " Where QCA01='" & Me.SGA01 & "'", Me.CDBCurrentUseSQLQueryAdapter)
                            If GetData.Count > 0 Then
                                _AboutPPSQCAPF = GetData(0)
                            End If
                        End If
                    End If
                End If
                Return _AboutPPSQCAPF
            End Get
            Private Set(ByVal value As PPS100LB.PPSQCAPF)
                _AboutPPSQCAPF = value
            End Set
        End Property
#End Region
#Region "相關鋼胚製程異常註記SMSSGEPF 屬性:AboutSMSSGEPF"
        Private _AboutSMSSGEPF As CompanyORMDB.SMS100LB.SMSSGEPF
        ''' <summary>
        ''' 相關鋼胚製程異常註記SMSSGEPF
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutSMSSGEPF() As SMSSGEPF
            Get
                If Not String.IsNullOrEmpty(Me.SGA26) AndAlso IsNothing(_AboutSMSSGEPF) Then
                    Dim GetDatas As List(Of SMSSGEPF) = SMSSGEPF.CDBSelect(Of SMSSGEPF)("Select * From @#SMS100LB.SMSSGEPF Where SGA01 || SGA02 || DIGITS(SGA03) || SGA04='" & Me.SGA01 & Me.SGA02 & Format(Me.SGA03, "00") & Me.SGA04 & "' FETCH FIRST 1 ROWS ONLY", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    If GetDatas.Count > 0 Then
                        _AboutSMSSGEPF = GetDatas(0)
                    End If
                Else
                    _AboutSMSSGEPF = Nothing
                End If
                Return _AboutSMSSGEPF
            End Get
            Private Set(ByVal value As SMSSGEPF)
                _AboutSMSSGEPF = value
            End Set
        End Property

#End Region

#Region "鋼胚號碼 屬性:SLABNumber"
        ''' <summary>
        ''' 鋼胚號碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property SLABNumber() As String
            Get
                Return Me.SGA01 & Me.SGA02 & Format(Me.SGA03, "00") & Me.SGA04
            End Get
        End Property
#End Region


#Region "是否為頭塊 屬性:IsHead"
        ''' <summary>
        ''' 是否為頭塊
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property IsHead As Boolean
            Get
                Return (SGA03 = 1)
            End Get
        End Property

#End Region
#Region "是否為尾塊 屬性:IsTail"
        ''' <summary>
        ''' 是否為尾塊
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property IsTail As Boolean
            Get
                Return (SGA03 = 0)
            End Get
        End Property
#End Region

    End Class

End Namespace
