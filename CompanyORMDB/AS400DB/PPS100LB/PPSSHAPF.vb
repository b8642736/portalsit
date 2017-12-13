Namespace PPS100LB
    ''' <summary>
    ''' P.P.排程檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PPSSHAPF
        Inherits ClassDBAS400
        Implements IPPS100LB.IPPSSHAPF

        Sub New()
            MyBase.New("PPS100LB", GetType(PPSSHAPF).Name)
        End Sub

#Region "BUILD-UP NO 屬性:SHA01"
        Private _SHA01 As System.String
        ''' <summary>
        ''' BUILD-UP NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SHA01() As System.String Implements IPPS100LB.IPPSSHAPF.SHA01
            Get
                Return _SHA01
            End Get
            Set(ByVal value As System.String)
                _SHA01 = value
            End Set
        End Property
#End Region
#Region "COIL BROKEN NO 屬性:SHA02"
        Private _SHA02 As System.String
        ''' <summary>
        ''' COIL BROKEN NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SHA02() As System.String Implements IPPS100LB.IPPSSHAPF.SHA02
            Get
                Return _SHA02
            End Get
            Set(ByVal value As System.String)
                _SHA02 = value
            End Set
        End Property
#End Region
#Region "BUILD-UP SERIES NO 屬性:SHA03"
        Private _SHA03 As System.String
        ''' <summary>
        ''' BUILD-UP SERIES NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA03() As System.String Implements IPPS100LB.IPPSSHAPF.SHA03
            Get
                Return _SHA03
            End Get
            Set(ByVal value As System.String)
                _SHA03 = value
            End Set
        End Property
#End Region
#Region "SCHEDULING SERIES 屬性:SHA04"
        Private _SHA04 As Integer
        ''' <summary>
        ''' SCHEDULING SERIES
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property SHA04() As Integer Implements IPPS100LB.IPPSSHAPF.SHA04
            Get
                Return _SHA04
            End Get
            Set(ByVal value As Integer)
                _SHA04 = value
            End Set
        End Property
#End Region
#Region "PLANNING GAUGE-M/M+ 屬性:SHA05"
        Private _SHA05 As System.String
        ''' <summary>
        ''' PLANNING GAUGE-M/M+
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA05() As System.String Implements IPPS100LB.IPPSSHAPF.SHA05
            Get
                Return _SHA05
            End Get
            Set(ByVal value As System.String)
                _SHA05 = value
            End Set
        End Property
#End Region
#Region "REAL FINISH 屬性:SHA06"
        Private _SHA06 As System.String
        ''' <summary>
        ''' REAL FINISH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA06() As System.String Implements IPPS100LB.IPPSSHAPF.SHA06
            Get
                Return _SHA06.Trim
            End Get
            Set(ByVal value As System.String)
                _SHA06 = value
            End Set
        End Property
#End Region
#Region "PLANNING GAUGE-M/M+FOR FINAL PRODUCTS 屬性:SHA07"
        Private _SHA07 As System.String
        ''' <summary>
        ''' PLANNING GAUGE-M/M+FOR FINAL PRODUCTS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA07() As System.String Implements IPPS100LB.IPPSSHAPF.SHA07
            Get
                Return _SHA07
            End Get
            Set(ByVal value As System.String)
                _SHA07 = value
            End Set
        End Property
#End Region
#Region "OPERATION LINE 屬性:SHA08"
        Private _SHA08 As System.String
        ''' <summary>
        ''' OPERATION LINE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA08() As System.String Implements IPPS100LB.IPPSSHAPF.SHA08
            Get
                Return _SHA08
            End Get
            Set(ByVal value As System.String)
                _SHA08 = value
            End Set
        End Property
#End Region
#Region "CLASS 屬性:SHA09"
        Private _SHA09 As System.String
        ''' <summary>
        ''' CLASS
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA09() As System.String Implements IPPS100LB.IPPSSHAPF.SHA09
            Get
                Return _SHA09
            End Get
            Set(ByVal value As System.String)
                _SHA09 = value
            End Set
        End Property
#End Region
#Region "SCHEDULING NO 屬性:SHA10"
        Private _SHA10 As System.String
        ''' <summary>
        ''' SCHEDULING NO
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA10() As System.String Implements IPPS100LB.IPPSSHAPF.SHA10
            Get
                Return _SHA10
            End Get
            Set(ByVal value As System.String)
                _SHA10 = value
            End Set
        End Property
#End Region
#Region "SCHEDULING DATE 屬性:SHA11"
        Private _SHA11 As System.Decimal
        ''' <summary>
        ''' SCHEDULING DATE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA11() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA11
            Get
                Return _SHA11
            End Get
            Set(ByVal value As System.Double)
                _SHA11 = value
            End Set
        End Property
#End Region
#Region "GRADE 屬性:SHA12"
        Private _SHA12 As System.String
        ''' <summary>
        ''' GRADE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA12() As System.String Implements IPPS100LB.IPPSSHAPF.SHA12
            Get
                Return _SHA12
            End Get
            Set(ByVal value As System.String)
                _SHA12 = value
            End Set
        End Property
#End Region
#Region "GRADE TYPE 屬性:SHA13"
        Private _SHA13 As System.String
        ''' <summary>
        ''' GRADE TYPE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA13() As System.String Implements IPPS100LB.IPPSSHAPF.SHA13
            Get
                Return _SHA13
            End Get
            Set(ByVal value As System.String)
                _SHA13 = value
            End Set
        End Property
#End Region
#Region "GUAGE 屬性:SHA14"
        Private _SHA14 As System.Double
        ''' <summary>
        ''' GUAGE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA14() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA14
            Get
                Return _SHA14
            End Get
            Set(ByVal value As System.Double)
                _SHA14 = value
            End Set
        End Property
#End Region
#Region "WIDTH 屬性:SHA15"
        Private _SHA15 As System.Double
        ''' <summary>
        ''' WIDTH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA15() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA15
            Get
                Return _SHA15
            End Get
            Set(ByVal value As System.Double)
                _SHA15 = value
            End Set
        End Property
#End Region
#Region "LENGTH 屬性:SHA16"
        Private _SHA16 As System.Double
        ''' <summary>
        ''' LENGTH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA16() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA16
            Get
                Return _SHA16
            End Get
            Set(ByVal value As System.Double)
                _SHA16 = value
            End Set
        End Property
#End Region
#Region "WEIGHT 屬性:SHA17"
        Private _SHA17 As System.Double
        ''' <summary>
        ''' WEIGHT
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA17() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA17
            Get
                Return _SHA17
            End Get
            Set(ByVal value As System.Double)
                _SHA17 = value
            End Set
        End Property
#End Region
#Region "RETURN 屬性:SHA18"
        Private _SHA18 As System.Double
        ''' <summary>
        ''' RETURN
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA18() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA18
            Get
                Return _SHA18
            End Get
            Set(ByVal value As System.Double)
                _SHA18 = value
            End Set
        End Property
#End Region
#Region "SCALE 屬性:SHA19"
        Private _SHA19 As System.Double
        ''' <summary>
        ''' SCALE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA19() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA19
            Get
                Return _SHA19
            End Get
            Set(ByVal value As System.Double)
                _SHA19 = value
            End Set
        End Property
#End Region
#Region "OTHER 屬性:SHA20"
        Private _SHA20 As System.Double
        ''' <summary>
        ''' OTHER
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA20() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA20
            Get
                Return _SHA20
            End Get
            Set(ByVal value As System.Double)
                _SHA20 = value
            End Set
        End Property
#End Region
#Region "FINISH DATE 屬性:SHA21"
        Private _SHA21 As System.Double
        ''' <summary>
        ''' FINISH DATE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA21() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA21
            Get
                Return _SHA21
            End Get
            Set(ByVal value As System.Double)
                _SHA21 = value
            End Set
        End Property
#End Region
#Region "START TIME-HOUR 屬性:SHA22"
        Private _SHA22 As System.Double
        ''' <summary>
        ''' START TIME-HOUR
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA22() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA22
            Get
                Return _SHA22
            End Get
            Set(ByVal value As System.Double)
                _SHA22 = value
            End Set
        End Property
#End Region
#Region "START TIME-MINIUTE 屬性:SHA23"
        Private _SHA23 As System.Double
        ''' <summary>
        ''' START TIME-MINIUTE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA23() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA23
            Get
                Return _SHA23
            End Get
            Set(ByVal value As System.Double)
                _SHA23 = value
            End Set
        End Property
#End Region
#Region "FINISH TIME-HOUR 屬性:SHA24"
        Private _SHA24 As System.Double
        ''' <summary>
        ''' FINISH TIME-HOUR
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA24() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA24
            Get
                Return _SHA24
            End Get
            Set(ByVal value As System.Double)
                _SHA24 = value
            End Set
        End Property
#End Region
#Region "FINISH TIME-MINIUTE 屬性:SHA25"
        Private _SHA25 As System.Double
        ''' <summary>
        ''' FINISH TIME-MINIUTE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA25() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA25
            Get
                Return _SHA25
            End Get
            Set(ByVal value As System.Double)
                _SHA25 = value
            End Set
        End Property
#End Region
#Region "ＧＰ研磨次數 屬性:SHA26"
        Private _SHA26 As System.String
        ''' <summary>
        ''' ＧＰ研磨次數
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA26() As System.String Implements IPPS100LB.IPPSSHAPF.SHA26
            Get
                Return _SHA26
            End Get
            Set(ByVal value As System.String)
                _SHA26 = value
            End Set
        End Property
#End Region
#Region "NEXT OPERATION LINE 屬性:SHA27"
        Private _SHA27 As System.String
        ''' <summary>
        ''' NEXT OPERATION LINE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA27() As System.String Implements IPPS100LB.IPPSSHAPF.SHA27
            Get
                Return _SHA27
            End Get
            Set(ByVal value As System.String)
                _SHA27 = value
            End Set
        End Property
#End Region
#Region "CODE1 屬性:SHA28"
        Private _SHA28 As System.String
        ''' <summary>
        ''' CODE1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>'*'代表已做完成</remarks>
        Public Property SHA28() As System.String Implements IPPS100LB.IPPSSHAPF.SHA28
            Get
                Return _SHA28
            End Get
            Set(ByVal value As System.String)
                _SHA28 = value
            End Set
        End Property
#End Region
#Region "CODE2 屬性:SHA29"
        Private _SHA29 As System.String
        ''' <summary>
        ''' CODE2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA29() As System.String Implements IPPS100LB.IPPSSHAPF.SHA29
            Get
                Return _SHA29
            End Get
            Set(ByVal value As System.String)
                _SHA29 = value
            End Set
        End Property
#End Region
#Region "CODE3 屬性:SHA30"
        Private _SHA30 As System.String
        ''' <summary>
        ''' CODE3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA30() As System.String Implements IPPS100LB.IPPSSHAPF.SHA30
            Get
                Return _SHA30
            End Get
            Set(ByVal value As System.String)
                _SHA30 = value
            End Set
        End Property
#End Region
#Region "子厚度範圍 屬性:SHA31"
        Private _SHA31 As System.String
        ''' <summary>
        ''' 子厚度範圍
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA31() As System.String Implements IPPS100LB.IPPSSHAPF.SHA31
            Get
                Return _SHA31
            End Get
            Set(ByVal value As System.String)
                _SHA31 = value
            End Set
        End Property
#End Region
#Region "特用 屬性:SHA32"
        Private _SHA32 As System.String
        ''' <summary>
        ''' 特用("A"品管指定特殊用途鋼捲)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA32() As System.String Implements IPPS100LB.IPPSSHAPF.SHA32
            Get
                Return _SHA32
            End Get
            Set(ByVal value As System.String)
                _SHA32 = value
            End Set
        End Property
#End Region
#Region "STANDARD GAUGE 屬性:SHA33"
        Private _SHA33 As System.String
        ''' <summary>
        ''' STANDARD GAUGE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA33() As System.String Implements IPPS100LB.IPPSSHAPF.SHA33
            Get
                Return _SHA33
            End Get
            Set(ByVal value As System.String)
                _SHA33 = value
            End Set
        End Property
#End Region
#Region "STANDARD WIDTH 屬性:SHA34"
        Private _SHA34 As System.Double
        ''' <summary>
        ''' STANDARD WIDTH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA34() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA34
            Get
                Return _SHA34
            End Get
            Set(ByVal value As System.Double)
                _SHA34 = value
            End Set
        End Property
#End Region
#Region "EXPORT 屬性:SHA35"
        Private _SHA35 As System.String
        ''' <summary>
        ''' EXPORT
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA35() As System.String Implements IPPS100LB.IPPSSHAPF.SHA35
            Get
                Return _SHA35
            End Get
            Set(ByVal value As System.String)
                _SHA35 = value
            End Set
        End Property
#End Region
#Region "PIPE 屬性:SHA36"
        Private _SHA36 As System.String
        ''' <summary>
        ''' PIPE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA36() As System.String Implements IPPS100LB.IPPSSHAPF.SHA36
            Get
                Return _SHA36
            End Get
            Set(ByVal value As System.String)
                _SHA36 = value
            End Set
        End Property
#End Region
#Region "TEST 屬性:SHA37"
        Private _SHA37 As System.String
        ''' <summary>
        ''' TEST("R"退回加工後交還客戶)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA37() As System.String Implements IPPS100LB.IPPSSHAPF.SHA37
            Get
                Return _SHA37
            End Get
            Set(ByVal value As System.String)
                _SHA37 = value
            End Set
        End Property
#End Region
#Region "SHEET QUANTITY 屬性:SHA38"
        Private _SHA38 As System.Double
        ''' <summary>
        ''' SHEET QUANTITY
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA38() As System.Double Implements IPPS100LB.IPPSSHAPF.SHA38
            Get
                Return _SHA38
            End Get
            Set(ByVal value As System.Double)
                _SHA38 = value
            End Set
        End Property
#End Region
#Region "PLANNING FINISH 屬性:SHA39"
        Private _SHA39 As System.String
        ''' <summary>
        ''' PLANNING FINISH
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHA39() As System.String Implements IPPS100LB.IPPSSHAPF.SHA39
            Get
                Return _SHA39
            End Get
            Set(ByVal value As System.String)
                _SHA39 = value
            End Set
        End Property
#End Region

#Region "相關SQLServer現場產生的P.P.排程檔 屬性:AboutMachineCreatedPPSSHAPF"
        Private _AboutMachineCreatedPPSSHAPF As SQLServer.PPS100LB.PPSSHAPF
        ''' <summary>
        ''' 相關SQLServer現場產生的P.P.排程檔
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutMachineCreatedPPSSHAPF As SQLServer.PPS100LB.PPSSHAPF
            Get
                If IsNothing(_AboutMachineCreatedPPSSHAPF) Then
                    Dim QryString As String = "Select * From PPSSHAPF WHERE DataSourceType=2 AND SHA01='" & Me.SHA01.Trim & "' AND SHA02='" & Me.SHA02.Trim & "' AND SHA04=" & Me.SHA04 & " Order by FK_ProcessSchedualID Desc"
                    Dim ReturnValue As List(Of SQLServer.PPS100LB.PPSSHAPF) = SQLServer.PPS100LB.PPSSHAPF.CDBSelect(Of SQLServer.PPS100LB.PPSSHAPF)(SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, QryString)
                    If ReturnValue.Count = 0 Then
                        Return Nothing
                    End If
                    _AboutMachineCreatedPPSSHAPF = ReturnValue(0)
                End If
                Return _AboutMachineCreatedPPSSHAPF
            End Get
        End Property
#End Region
#Region "相關軋鋼處理排程 屬性:About_ProcessSchedual"
        ''' <summary>
        ''' 相關軋鋼處理排程
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property About_ProcessSchedual As CompanyORMDB.SQLServer.PPS100LB.ProcessSchedual Implements IPPS100LB.IPPSSHAPF.About_ProcessSchedual
            Get
                Dim myMachineCreatedPPSSHAPF As SQLServer.PPS100LB.PPSSHAPF = AboutMachineCreatedPPSSHAPF
                If IsNothing(myMachineCreatedPPSSHAPF) Then
                    Return Nothing
                End If
                Return myMachineCreatedPPSSHAPF.About_ProcessSchedual
            End Get
        End Property
#End Region
#Region "相關鋼捲編號(SHA01+SHA02)之在製品鋼捲入有主 屬性:AboutSL2CICPF"
        Private _AboutSL2CICPF As SLS300LB.SL2CICPF = Nothing
        ''' <summary>
        ''' 相關鋼捲編號(SHA01+SHA02)之在製品鋼捲入有主
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutSL2CICPF As SLS300LB.SL2CICPF Implements IPPS100LB.IPPSSHAPF.AboutSL2CICPF
            Get
                Dim FindCoilFullNumber As String = (Me.SHA01 & Me.SHA02).PadRight(5).Trim
                If IsNothing(_AboutSL2CICPF) OrElse ((_AboutSL2CICPF.CIC01 & _AboutSL2CICPF.CIC02).Trim <> FindCoilFullNumber AndAlso (_AboutSL2CICPF.CIC01 & _AboutSL2CICPF.CIC02).Trim <> FindCoilFullNumber.Substring(0, FindCoilFullNumber.Length - 1)) Then
                    _AboutSL2CICPF = FindSL2CIAPF(FindCoilFullNumber)
                End If
                Return _AboutSL2CICPF
            End Get
        End Property
        Private Function FindSL2CIAPF(ByVal CoilFullNumber As String) As SLS300LB.SL2CICPF
            Dim ReturnValue As SLS300LB.SL2CICPF = Nothing
            Dim AllSHA01_SL2CICPFs As List(Of SLS300LB.SL2CICPF) = AboutSHA01_SL2CICPFs
            For Each EachItem As SLS300LB.SL2CICPF In AllSHA01_SL2CICPFs
                If (EachItem.CIC01 & EachItem.CIC02.Trim) = CoilFullNumber Then
                    ReturnValue = EachItem : Return ReturnValue
                End If
            Next
            If CoilFullNumber.Length <= 5 Then
                Return ReturnValue
            End If
            For Each EachItem As SLS300LB.SL2CICPF In AllSHA01_SL2CICPFs
                If (EachItem.CIC01 & EachItem.CIC02.Trim) = CoilFullNumber.Substring(0, CoilFullNumber.Length - 1) Then
                    ReturnValue = EachItem : Exit For
                End If
            Next
            Return ReturnValue
        End Function

        ' ''' <summary>
        ' ''' 相關鋼捲編號(SHA01+SHA02)之在製品鋼捲入有主
        ' ''' </summary>
        ' ''' <value></value>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        '<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        'ReadOnly Property AboutSL2CICPF As SLS300LB.SL2CICPF Implements IPPS100LB.IPPSSHAPF.AboutSL2CICPF
        '    Get
        '        Return FindSL2CIAPF(Me.SHA01 & Me.SHA02.Trim)
        '    End Get
        'End Property

        'Private Function FindSL2CIAPF(ByVal CoilFullNumber As String) As SLS300LB.SL2CICPF
        '    Dim ReturnValue As SLS300LB.SL2CICPF = Nothing
        '    For Each EachItem As SLS300LB.SL2CICPF In AboutSHA01_SL2CICPFs
        '        If EachItem.CIC01 & EachItem.CIC02.Trim = CoilFullNumber Then
        '            ReturnValue = EachItem : Return ReturnValue
        '        End If
        '    Next
        '    If CoilFullNumber.Length <= 5 Then
        '        Return ReturnValue
        '    End If
        '    Return FindSL2CIAPF(CoilFullNumber.Substring(0, CoilFullNumber.Length - 1))
        'End Function
#End Region
#Region "相關鋼捲編號(SHA01+SHA02)之列管訂單 屬性:AboutSL2CIDPF"
        Private _AboutSL2CIDPF As SLS300LB.SL2CIDPF = Nothing
        Private _AboutSL2CIDPFAccTime As DateTime = New DateTime(200, 1, 1)
        ''' <summary>
        ''' 相關鋼捲編號(SHA01+SHA02)之列管訂單
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutSL2CIDPF As SLS300LB.SL2CIDPF Implements IPPS100LB.IPPSSHAPF.AboutSL2CIDPF
            Get
                If Now.Subtract(_AboutSL2CIDPFAccTime).TotalSeconds > 3 AndAlso IsNothing(_AboutSL2CIDPF) Then
                    Dim AboutSL2CICPF As CompanyORMDB.SLS300LB.SL2CICPF = Me.AboutSL2CICPF
                    If Not IsNothing(AboutSL2CICPF) Then
                        Dim Qry As String = "Select * From @#SLS300LB.SL2CIDPF Where (CID01 || CID02) ='" & AboutSL2CICPF.CIC10 & "' AND CID03='" & AboutSL2CICPF.CIC11 & "' AND CID04='" & AboutSL2CICPF.CIC12 & "' AND  CID05='" & AboutSL2CICPF.CIC13 & "' AND CID06='" & AboutSL2CICPF.CIC14.Substring(0, 2) & "." & AboutSL2CICPF.CIC14.Substring(2, 2) & "' AND CID07='" & AboutSL2CICPF.CIC15 & "' "
                        Dim SearchResult As List(Of CompanyORMDB.SLS300LB.SL2CIDPF) = SLS300LB.SL2CIDPF.CDBSelect(Of SLS300LB.SL2CIDPF)(Qry, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                        If SearchResult.Count > 0 Then
                            _AboutSL2CIDPF = SearchResult(0)
                        End If
                    End If
                    _AboutSL2CIDPFAccTime = Now
                End If
                Return _AboutSL2CIDPF
            End Get
        End Property

        '<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        'ReadOnly Property AboutSL2CIDPF As SLS300LB.SL2CIDPF Implements IPPS100LB.IPPSSHAPF.AboutSL2CIDPF
        '    Get
        '        Dim AboutSL2CICPF As CompanyORMDB.SLS300LB.SL2CICPF = Me.AboutSL2CICPF
        '        If Not IsNothing(AboutSL2CICPF) Then
        '            Dim Qry As String = "Select * From @#SLS300LB.SL2CIDPF Where (CID01 || CID02) ='" & AboutSL2CICPF.CIC10 & "' AND CID03='" & AboutSL2CICPF.CIC11 & "' AND CID05='" & AboutSL2CICPF.CIC13 & "' AND CID06='" & AboutSL2CICPF.CIC14.Substring(0, 2) & "." & AboutSL2CICPF.CIC14.Substring(2, 2) & "'"
        '            Dim SearchResult As List(Of CompanyORMDB.SLS300LB.SL2CIDPF) = SLS300LB.SL2CIDPF.CDBSelect(Of SLS300LB.SL2CIDPF)(Qry, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
        '            If SearchResult.Count > 0 Then
        '                Return SearchResult(0)
        '            End If
        '        End If
        '        Return Nothing
        '    End Get
        'End Property
#End Region
#Region "相關鋼捲編號(只有SHA01)之所有在製品鋼捲入有主 私有屬性:AboutSHA01_SL2CICPFs"
        Private _AboutSHA01_SL2CIAPFs As List(Of SLS300LB.SL2CICPF) = Nothing
        ''' <summary>
        ''' 相關鋼捲編號(只有SHA01)之有在製品鋼捲入有主
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Private ReadOnly Property AboutSHA01_SL2CICPFs As List(Of SLS300LB.SL2CICPF)
            Get
                If IsNothing(_AboutSHA01_SL2CIAPFs) OrElse _AboutSHA01_SL2CIAPFs.Count = 0 Then
                    Dim Qry As String = "Select * From @#SLS300LB.SL2CICPF Where CIC01='" & Me.SHA01 & "' AND CIC91<>'Z'"    'Z:表示已入庫並新增至PPSCIAPF
                    _AboutSHA01_SL2CIAPFs = SLS300LB.SL2CICPF.CDBSelect(Of SLS300LB.SL2CICPF)(Qry, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If
                Return _AboutSHA01_SL2CIAPFs
            End Get
        End Property
#End Region
#Region "相關黑皮資料 屬性:About_PPSBLAPF"
        Private _About_PPSBLAPF As CompanyORMDB.PPS100LB.PPSBLAPF = Nothing
        ''' <summary>
        ''' 相關黑皮資料
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property About_PPSBLAPF As CompanyORMDB.PPS100LB.PPSBLAPF Implements IPPS100LB.IPPSSHAPF.AboutPPSBLAPF
            Get
                If IsNothing(_About_PPSBLAPF) Then
                    Dim QryString As String = "Select * from @#PPS100LB.PPSBLAPF WHERE BLA09='" & Me.SHA01 & "'"
                    Dim SearchResult As List(Of CompanyORMDB.PPS100LB.PPSBLAPF) = CompanyORMDB.PPS100LB.PPSBLAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSBLAPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                    If SearchResult.Count = 0 Then
                        Return Nothing
                    End If
                    _About_PPSBLAPF = SearchResult(0)
                End If
                Return _About_PPSBLAPF
            End Get
        End Property

#End Region


#Region "內外銷判別"
        Private _PP_ExportJudge As Boolean
        ''' <summary>
        ''' 相關鋼捲編號(SHA01+SHA02)之列管訂單
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property PP_ExportJudge As Boolean Implements IPPS100LB.IPPSSHAPF.PP_ExportJudge
            Get
                Dim Qry As String

                Qry = " select *  from @#PPS100LB.PPSSHAPF " & _
                        "  where SHA01='" & SHA01 & "' and " & _
                        " SHA02 ='" & SHA02 & "' and SHA35 <> ''"

                Dim searchResult As List(Of CompanyORMDB.PPS100LB.PPSSHAPF) = CompanyORMDB.PPS100LB.PPSSHAPF.CDBSelect(Of CompanyORMDB.PPS100LB.PPSSHAPF)(Qry, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)

                If searchResult.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
                Return False
            End Get
        End Property
#End Region
    End Class

End Namespace
