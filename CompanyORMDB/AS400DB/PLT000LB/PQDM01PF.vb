Namespace PLT000LB
    Public Class PQDM01PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("PLT000LB", GetType(PQDM01PF).Name)
        End Sub

#Region "員工編號 屬性:QD100A"
        Private _QD100A As System.String
        ''' <summary>
        ''' 員工編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QD100A() As System.String
            Get
                Return _QD100A
            End Get
            Set(ByVal value As System.String)
                _QD100A = value
            End Set
        End Property
#End Region
#Region "出勤年 屬性:QD100I"
        Private _QD100I As System.Int32
        ''' <summary>
        ''' 出勤年
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QD100I() As System.Int32
            Get
                Return _QD100I
            End Get
            Set(ByVal value As System.Int32)
                _QD100I = value
            End Set
        End Property
#End Region
#Region "出勤月 屬性:QD100J"
        Private _QD100J As System.Int32
        ''' <summary>
        ''' 出勤月
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property QD100J() As System.Int32
            Get
                Return _QD100J
            End Get
            Set(ByVal value As System.Int32)
                _QD100J = value
            End Set
        End Property
#End Region
#Region "身分證號 屬性:QD100B"
        Private _QD100B As System.String
        ''' <summary>
        ''' 身分證號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD100B() As System.String
            Get
                Return _QD100B
            End Get
            Set(ByVal value As System.String)
                _QD100B = value
            End Set
        End Property
#End Region
#Region "姓名 屬性:QD100C"
        Private _QD100C As System.String
        ''' <summary>
        ''' 姓名
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD100C() As System.String
            Get
                Return _QD100C
            End Get
            Set(ByVal value As System.String)
                _QD100C = value
            End Set
        End Property
#End Region
#Region "廠別 屬性:QD100D"
        Private _QD100D As System.String
        ''' <summary>
        ''' 廠別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD100D() As System.String
            Get
                Return _QD100D
            End Get
            Set(ByVal value As System.String)
                _QD100D = value
            End Set
        End Property
#End Region
#Region "服務部門 屬性:QD100E"
        Private _QD100E As System.String
        ''' <summary>
        ''' 服務部門
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD100E() As System.String
            Get
                Return _QD100E
            End Get
            Set(ByVal value As System.String)
                _QD100E = value
            End Set
        End Property
#End Region
#Region "成本中心 屬性:QD100F"
        Private _QD100F As System.String
        ''' <summary>
        ''' 成本中心
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD100F() As System.String
            Get
                Return _QD100F
            End Get
            Set(ByVal value As System.String)
                _QD100F = value
            End Set
        End Property
#End Region
#Region "類別碼 屬性:QD100G"
        Private _QD100G As System.String
        ''' <summary>
        ''' 類別碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD100G() As System.String
            Get
                Return _QD100G
            End Get
            Set(ByVal value As System.String)
                _QD100G = value
            End Set
        End Property
#End Region
#Region "班別 屬性:QD100H"
        Private _QD100H As System.String
        ''' <summary>
        ''' 班別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD100H() As System.String
            Get
                Return _QD100H
            End Get
            Set(ByVal value As System.String)
                _QD100H = value
            End Set
        End Property
#End Region
#Region "職工別 屬性:QD100K"
        Private _QD100K As System.String
        ''' <summary>
        ''' 職工別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD100K() As System.String
            Get
                Return _QD100K
            End Get
            Set(ByVal value As System.String)
                _QD100K = value
            End Set
        End Property
#End Region
#Region "建檔碼 屬性:QD100M"
        Private _QD100M As System.String
        ''' <summary>
        ''' 建檔碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD100M() As System.String
            Get
                Return _QD100M
            End Get
            Set(ByVal value As System.String)
                _QD100M = value
            End Set
        End Property
#End Region
#Region "辭職碼 屬性:QD100N"
        Private _QD100N As System.String
        ''' <summary>
        ''' 辭職碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD100N() As System.String
            Get
                Return _QD100N
            End Get
            Set(ByVal value As System.String)
                _QD100N = value
            End Set
        End Property
#End Region
#Region "01 屬性:QD1D01"
        Private _QD1D01 As System.String
        ''' <summary>
        ''' 01
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D01() As System.String
            Get
                Return _QD1D01
            End Get
            Set(ByVal value As System.String)
                _QD1D01 = value
            End Set
        End Property
#End Region
#Region "02 屬性:QD1D02"
        Private _QD1D02 As System.String
        ''' <summary>
        ''' 02
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D02() As System.String
            Get
                Return _QD1D02
            End Get
            Set(ByVal value As System.String)
                _QD1D02 = value
            End Set
        End Property
#End Region
#Region "03 屬性:QD1D03"
        Private _QD1D03 As System.String
        ''' <summary>
        ''' 03
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D03() As System.String
            Get
                Return _QD1D03
            End Get
            Set(ByVal value As System.String)
                _QD1D03 = value
            End Set
        End Property
#End Region
#Region "04 屬性:QD1D04"
        Private _QD1D04 As System.String
        ''' <summary>
        ''' 04
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D04() As System.String
            Get
                Return _QD1D04
            End Get
            Set(ByVal value As System.String)
                _QD1D04 = value
            End Set
        End Property
#End Region
#Region "05 屬性:QD1D05"
        Private _QD1D05 As System.String
        ''' <summary>
        ''' 05
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D05() As System.String
            Get
                Return _QD1D05
            End Get
            Set(ByVal value As System.String)
                _QD1D05 = value
            End Set
        End Property
#End Region
#Region "06 屬性:QD1D06"
        Private _QD1D06 As System.String
        ''' <summary>
        ''' 06
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D06() As System.String
            Get
                Return _QD1D06
            End Get
            Set(ByVal value As System.String)
                _QD1D06 = value
            End Set
        End Property
#End Region
#Region "07 屬性:QD1D07"
        Private _QD1D07 As System.String
        ''' <summary>
        ''' 07
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D07() As System.String
            Get
                Return _QD1D07
            End Get
            Set(ByVal value As System.String)
                _QD1D07 = value
            End Set
        End Property
#End Region
#Region "08 屬性:QD1D08"
        Private _QD1D08 As System.String
        ''' <summary>
        ''' 08
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D08() As System.String
            Get
                Return _QD1D08
            End Get
            Set(ByVal value As System.String)
                _QD1D08 = value
            End Set
        End Property
#End Region
#Region "09 屬性:QD1D09"
        Private _QD1D09 As System.String
        ''' <summary>
        ''' 09
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D09() As System.String
            Get
                Return _QD1D09
            End Get
            Set(ByVal value As System.String)
                _QD1D09 = value
            End Set
        End Property
#End Region
#Region "10 屬性:QD1D10"
        Private _QD1D10 As System.String
        ''' <summary>
        ''' 10
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D10() As System.String
            Get
                Return _QD1D10
            End Get
            Set(ByVal value As System.String)
                _QD1D10 = value
            End Set
        End Property
#End Region
#Region "11 屬性:QD1D11"
        Private _QD1D11 As System.String
        ''' <summary>
        ''' 11
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D11() As System.String
            Get
                Return _QD1D11
            End Get
            Set(ByVal value As System.String)
                _QD1D11 = value
            End Set
        End Property
#End Region
#Region "12 屬性:QD1D12"
        Private _QD1D12 As System.String
        ''' <summary>
        ''' 12
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D12() As System.String
            Get
                Return _QD1D12
            End Get
            Set(ByVal value As System.String)
                _QD1D12 = value
            End Set
        End Property
#End Region
#Region "13 屬性:QD1D13"
        Private _QD1D13 As System.String
        ''' <summary>
        ''' 13
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D13() As System.String
            Get
                Return _QD1D13
            End Get
            Set(ByVal value As System.String)
                _QD1D13 = value
            End Set
        End Property
#End Region
#Region "14 屬性:QD1D14"
        Private _QD1D14 As System.String
        ''' <summary>
        ''' 14
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D14() As System.String
            Get
                Return _QD1D14
            End Get
            Set(ByVal value As System.String)
                _QD1D14 = value
            End Set
        End Property
#End Region
#Region "15 屬性:QD1D15"
        Private _QD1D15 As System.String
        ''' <summary>
        ''' 15
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D15() As System.String
            Get
                Return _QD1D15
            End Get
            Set(ByVal value As System.String)
                _QD1D15 = value
            End Set
        End Property
#End Region
#Region "16 屬性:QD1D16"
        Private _QD1D16 As System.String
        ''' <summary>
        ''' 16
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D16() As System.String
            Get
                Return _QD1D16
            End Get
            Set(ByVal value As System.String)
                _QD1D16 = value
            End Set
        End Property
#End Region
#Region "17 屬性:QD1D17"
        Private _QD1D17 As System.String
        ''' <summary>
        ''' 17
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D17() As System.String
            Get
                Return _QD1D17
            End Get
            Set(ByVal value As System.String)
                _QD1D17 = value
            End Set
        End Property
#End Region
#Region "18 屬性:QD1D18"
        Private _QD1D18 As System.String
        ''' <summary>
        ''' 18
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D18() As System.String
            Get
                Return _QD1D18
            End Get
            Set(ByVal value As System.String)
                _QD1D18 = value
            End Set
        End Property
#End Region
#Region "19 屬性:QD1D19"
        Private _QD1D19 As System.String
        ''' <summary>
        ''' 19
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D19() As System.String
            Get
                Return _QD1D19
            End Get
            Set(ByVal value As System.String)
                _QD1D19 = value
            End Set
        End Property
#End Region
#Region "20 屬性:QD1D20"
        Private _QD1D20 As System.String
        ''' <summary>
        ''' 20
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D20() As System.String
            Get
                Return _QD1D20
            End Get
            Set(ByVal value As System.String)
                _QD1D20 = value
            End Set
        End Property
#End Region
#Region "21 屬性:QD1D21"
        Private _QD1D21 As System.String
        ''' <summary>
        ''' 21
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D21() As System.String
            Get
                Return _QD1D21
            End Get
            Set(ByVal value As System.String)
                _QD1D21 = value
            End Set
        End Property
#End Region
#Region "22 屬性:QD1D22"
        Private _QD1D22 As System.String
        ''' <summary>
        ''' 22
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D22() As System.String
            Get
                Return _QD1D22
            End Get
            Set(ByVal value As System.String)
                _QD1D22 = value
            End Set
        End Property
#End Region
#Region "23 屬性:QD1D23"
        Private _QD1D23 As System.String
        ''' <summary>
        ''' 23
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D23() As System.String
            Get
                Return _QD1D23
            End Get
            Set(ByVal value As System.String)
                _QD1D23 = value
            End Set
        End Property
#End Region
#Region "24 屬性:QD1D24"
        Private _QD1D24 As System.String
        ''' <summary>
        ''' 24
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D24() As System.String
            Get
                Return _QD1D24
            End Get
            Set(ByVal value As System.String)
                _QD1D24 = value
            End Set
        End Property
#End Region
#Region "25 屬性:QD1D25"
        Private _QD1D25 As System.String
        ''' <summary>
        ''' 25
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D25() As System.String
            Get
                Return _QD1D25
            End Get
            Set(ByVal value As System.String)
                _QD1D25 = value
            End Set
        End Property
#End Region
#Region "26 屬性:QD1D26"
        Private _QD1D26 As System.String
        ''' <summary>
        ''' 26
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D26() As System.String
            Get
                Return _QD1D26
            End Get
            Set(ByVal value As System.String)
                _QD1D26 = value
            End Set
        End Property
#End Region
#Region "27 屬性:QD1D27"
        Private _QD1D27 As System.String
        ''' <summary>
        ''' 27
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D27() As System.String
            Get
                Return _QD1D27
            End Get
            Set(ByVal value As System.String)
                _QD1D27 = value
            End Set
        End Property
#End Region
#Region "28 屬性:QD1D28"
        Private _QD1D28 As System.String
        ''' <summary>
        ''' 28
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D28() As System.String
            Get
                Return _QD1D28
            End Get
            Set(ByVal value As System.String)
                _QD1D28 = value
            End Set
        End Property
#End Region
#Region "29 屬性:QD1D29"
        Private _QD1D29 As System.String
        ''' <summary>
        ''' 29
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D29() As System.String
            Get
                Return _QD1D29
            End Get
            Set(ByVal value As System.String)
                _QD1D29 = value
            End Set
        End Property
#End Region
#Region "30 屬性:QD1D30"
        Private _QD1D30 As System.String
        ''' <summary>
        ''' 30
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D30() As System.String
            Get
                Return _QD1D30
            End Get
            Set(ByVal value As System.String)
                _QD1D30 = value
            End Set
        End Property
#End Region
#Region "31 屬性:QD1D31"
        Private _QD1D31 As System.String
        ''' <summary>
        ''' 31
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property QD1D31() As System.String
            Get
                Return _QD1D31
            End Get
            Set(ByVal value As System.String)
                _QD1D31 = value
            End Set
        End Property
#End Region

#Region "取得出勤主檔單位成員 方法:GetEmployees"
        ''' <summary>
        ''' 取得出勤主檔單位成員
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function GetEmployees(ByVal FindYear As Integer, ByVal FindMonth As Integer, ByVal FindDepCode As String) As List(Of PQDM01PF)
            Dim QryString As String = "Select * from @#PLT000LB.PQDM01PF WHERE QD100I=" & FindYear & " AND QD100J=" & FindMonth & " AND QD100E='" & FindDepCode & "' Order by QD100A"
            Return PQDM01PF.CDBSelect(Of PQDM01PF)(QryString, CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        End Function
#End Region
    End Class
End Namespace