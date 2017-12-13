Namespace PPS100LB
    ''' <summary>
    ''' 過磅資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PPSCICPF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("PPS100LB", GetType(PPSCICPF).Name, New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC))
        End Sub

        Sub New(ByVal SetCIC00LineName As String, ByVal SetCoilFullNumber As String)
            MyBase.New("PPS100LB", GetType(PPSCICPF).Name, New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC))
            Me.CIC00 = SetCIC00LineName
            Me.CIC01 = SetCoilFullNumber.PadRight(10).ToUpper.Substring(0, 5)
            Me.CIC02 = SetCoilFullNumber.PadRight(10).ToUpper.Substring(5, 5)
            Try
                Dim GetServerTime As DateTime = DeviceInformation.GetSQLServerTime(SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m)
                CIC03 = New CompanyORMDB.AS400DateConverter(GetServerTime).TwIntegerTypeData
                CIC04 = Format(GetServerTime, "HHmmss")
            Catch ex As Exception
                CIC03 = New CompanyORMDB.AS400DateConverter(Now).TwIntegerTypeData
                CIC04 = Format(Now, "HHmmss")
            End Try
            SetDefaultValues()
        End Sub

#Region "線別 屬性:CIC00"
        Private _CIC00 As System.String
        ''' <summary>
        ''' 線別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CIC00() As System.String
            Get
                Return _CIC00
            End Get
            Set(ByVal value As System.String)
                _CIC00 = value
            End Set
        End Property
#End Region
#Region "鋼捲號碼 屬性:CIC01"
        Private _CIC01 As System.String
        ''' <summary>
        ''' 鋼捲號碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CIC01() As System.String
            Get
                Return _CIC01
            End Get
            Set(ByVal value As System.String)
                If value <> _CIC01 Then
                    AboutCoilNumberLastPPSSHAPF = Nothing
                    AboutPPSSHAPF = Nothing
                End If
                _CIC01 = value
            End Set
        End Property
#End Region
#Region "分捲號碼 屬性:CIC02"
        Private _CIC02 As System.String
        ''' <summary>
        ''' 分捲號碼
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CIC02() As System.String
            Get
                Return _CIC02
            End Get
            Set(ByVal value As System.String)
                _CIC02 = value
            End Set
        End Property
#End Region
#Region "日期 屬性:CIC03"
        Private _CIC03 As System.Int32
        ''' <summary>
        ''' 日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CIC03() As System.Int32
            Get
                Return _CIC03
            End Get
            Set(ByVal value As System.Int32)
                If value <> _CIC03 Then
                    AboutPPSSHAPF = Nothing
                End If
                _CIC03 = value
            End Set
        End Property
#End Region
#Region "時間 屬性:CIC04"
        Private _CIC04 As System.String
        ''' <summary>
        ''' 時間
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property CIC04() As System.String
            Get
                Return _CIC04
            End Get
            Set(ByVal value As System.String)
                If value <> _CIC04 Then
                    AboutPPSSHAPF = Nothing
                End If
                _CIC04 = value
            End Set
        End Property
#End Region
#Region "磅序 屬性:CIC05"
        Private _CIC05 As System.Int32
        ''' <summary>
        ''' 磅序
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC05() As System.Int32
            Get
                Return _CIC05
            End Get
            Set(ByVal value As System.Int32)
                _CIC05 = value
            End Set
        End Property
#End Region
#Region "磅重 屬性:CIC06"
        Private _CIC06 As System.Int32
        ''' <summary>
        ''' 磅重
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC06() As System.Int32
            Get
                Return _CIC06
            End Get
            Set(ByVal value As System.Int32)
                _CIC06 = value
            End Set
        End Property
#End Region
#Region "夾整捲 屬性:CIC11"
        Private _CIC11 As System.String
        ''' <summary>
        ''' 夾整捲
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC11() As System.String
            Get
                Return _CIC11
            End Get
            Set(ByVal value As System.String)
                _CIC11 = value
            End Set
        End Property
#End Region
#Region "加長m 屬性:CIC12"
        Private _CIC12 As System.Single
        ''' <summary>
        ''' 加長m
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC12() As System.Single
            Get
                Return _CIC12
            End Get
            Set(ByVal value As System.Single)
                _CIC12 = value
            End Set
        End Property
#End Region
#Region "紙寬m 屬性:CIC13"
        Private _CIC13 As System.Single
        ''' <summary>
        ''' 紙寬m
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC13() As System.Single
            Get
                Return _CIC13
            End Get
            Set(ByVal value As System.Single)
                _CIC13 = value
            End Set
        End Property
#End Region
#Region "基重kg 屬性:CIC14"
        Private _CIC14 As System.Single
        ''' <summary>
        ''' 基重kg
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC14() As System.Single
            Get
                Return _CIC14
            End Get
            Set(ByVal value As System.Single)
                _CIC14 = value
            End Set
        End Property
#End Region
#Region "薄厚紙 屬性:CIC15"
        Private _CIC15 As System.String
        ''' <summary>
        ''' 薄厚紙
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC15() As System.String
            Get
                Return _CIC15
            End Get
            Set(ByVal value As System.String)
                _CIC15 = value
            End Set
        End Property
#End Region
#Region "有套筒 屬性:CIC21"
        Private _CIC21 As System.String
        ''' <summary>
        ''' 有套筒
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC21() As System.String
            Get
                Return _CIC21
            End Get
            Set(ByVal value As System.String)
                _CIC21 = value
            End Set
        End Property
#End Region
#Region "套筒外徑 屬性:CIC22"
        Private _CIC22 As System.Int32
        ''' <summary>
        ''' 套筒外徑
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC22() As System.Int32
            Get
                Return _CIC22
            End Get
            Set(ByVal value As System.Int32)
                _CIC22 = value
            End Set
        End Property
#End Region
#Region "鋼捲內徑 屬性:CIC23"
        Private _CIC23 As System.Int32
        ''' <summary>
        ''' 鋼捲內徑
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC23() As System.Int32
            Get
                Return _CIC23
            End Get
            Set(ByVal value As System.Int32)
                _CIC23 = value
            End Set
        End Property
#End Region
#Region "筒重kg 屬性:CIC24"
        Private _CIC24 As System.Int32
        ''' <summary>
        ''' 筒重kg
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC24() As System.Int32
            Get
                Return _CIC24
            End Get
            Set(ByVal value As System.Int32)
                _CIC24 = value
            End Set
        End Property
#End Region
#Region "包整捲 屬性:CIC31"
        Private _CIC31 As System.String
        ''' <summary>
        ''' 包整捲
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC31() As System.String
            Get
                Return _CIC31
            End Get
            Set(ByVal value As System.String)
                _CIC31 = value
            End Set
        End Property
#End Region
#Region "加長m 屬性:CIC32"
        Private _CIC32 As System.Single
        ''' <summary>
        ''' 加長m
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC32() As System.Single
            Get
                Return _CIC32
            End Get
            Set(ByVal value As System.Single)
                _CIC32 = value
            End Set
        End Property
#End Region
#Region "紙寬m 屬性:CIC33"
        Private _CIC33 As System.Single
        ''' <summary>
        ''' 紙寬m
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC33() As System.Single
            Get
                Return _CIC33
            End Get
            Set(ByVal value As System.Single)
                _CIC33 = value
            End Set
        End Property
#End Region
#Region "基重kg 屬性:CIC34"
        Private _CIC34 As System.Single
        ''' <summary>
        ''' 基重kg
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC34() As System.Single
            Get
                Return _CIC34
            End Get
            Set(ByVal value As System.Single)
                _CIC34 = value
            End Set
        End Property
#End Region
#Region "CODE-1 屬性:CIC91"
        Private _CIC91 As System.String
        ''' <summary>
        ''' CODE-1
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC91() As System.String
            Get
                Return _CIC91
            End Get
            Set(ByVal value As System.String)
                _CIC91 = value
            End Set
        End Property
#End Region
#Region "CODE-2 屬性:CIC92"
        Private _CIC92 As System.String
        ''' <summary>
        ''' CODE-2
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC92() As System.String
            Get
                Return _CIC92
            End Get
            Set(ByVal value As System.String)
                _CIC92 = value
            End Set
        End Property
#End Region
#Region "CODE-3 屬性:CIC93"
        Private _CIC93 As System.String
        ''' <summary>
        ''' CODE-3
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC93() As System.String
            Get
                Return _CIC93
            End Get
            Set(ByVal value As System.String)
                _CIC93 = value
            End Set
        End Property
#End Region
#Region "使用者CODE-4 屬性:CIC94"
        Private _CIC94 As System.String
        ''' <summary>
        ''' 使用者CODE-4
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC94() As System.String
            Get
                Return _CIC94
            End Get
            Set(ByVal value As System.String)
                _CIC94 = value
            End Set
        End Property
#End Region
#Region "鋼捲儲區CODE-5 屬性:CIC95"
        Private _CIC95 As System.String
        ''' <summary>
        ''' 鋼捲儲區CODE-5
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC95() As System.String
            Get
                Return _CIC95
            End Get
            Set(ByVal value As System.String)
                _CIC95 = value
            End Set
        End Property
#End Region
#Region "CODE-6 屬性:CIC96"
        Private _CIC96 As System.String
        ''' <summary>
        ''' CODE-6
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CIC96() As System.String
            Get
                Return _CIC96
            End Get
            Set(ByVal value As System.String)
                _CIC96 = value
            End Set
        End Property
#End Region


#Region "襯紙夾整捲說明 屬性:CIC11Descript"
        ''' <summary>
        ''' 襯紙夾整捲說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CIC11Descript As String
            Get
                Select Case Me.CIC11
                    Case "1"
                        Return "薄"
                    Case "2"
                        Return "厚"
                End Select
                Return "無"
            End Get
        End Property
#End Region
#Region "襯紙厚薄說明 屬性:CIC15Descript"
        ''' <summary>
        ''' 襯紙厚薄說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CIC15Descript As String
            Get

                Select Case CIC15
                    Case "1"
                        Return "薄紙"
                    Case "2"
                        Return "厚紙"
                End Select
                Return "不夾襯紙"
            End Get
        End Property
#End Region
#Region "是否使用紙套筒說明 屬性:CIC21Descript"
                ''' <summary>
                ''' 是否使用紙套筒說明
                ''' </summary>
                ''' <value></value>
                ''' <returns></returns>
                ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CIC21Descript As String
            Get
                If Me.CIC21 = "Y" Then
                    Return "薄板"
                End If
                Return "無"
            End Get
        End Property
#End Region
#Region "奇力龍包整捲說明 屬性:CIC31Descript"
        ''' <summary>
        ''' 奇力龍包整捲說明
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CIC31Descript As String
            Get
                If CIC31 = "Y" Then
                    Return "是"
                End If
                Return "無"
            End Get
        End Property
#End Region


#Region "設定襯紙/套筒/奇力龍預設值 方法:SetDefaultValues"
        ''' <summary>
        ''' 設定襯紙/套筒/奇力龍預設值
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SetDefaultValues(Optional SetRunProcessData As CompanyORMDB.SQLServer.PPS100LB.RunProcessData = Nothing)
            Dim ReutrnValue As Boolean = SetDefaultInterleave()
            ReutrnValue = ReutrnValue And SetDefaultCasting()
            ReutrnValue = ReutrnValue And SetDefaultOutleave()

            '依特殊訂單之要求來設定預設值
            Dim ThisStationName As String = Me.CIC00.ToUpper.Trim.PadRight(3).Substring(0, 3)
            If Not IsNothing(SetRunProcessData) AndAlso ((ThisStationName = "APL" And SetRunProcessData.IsFinishProduct = True) OrElse ThisStationName = "SPL" OrElse ThisStationName = "SBL" OrElse ThisStationName = "TLL") Then
                Dim AboutPPSSHAPF As CompanyORMDB.IPPS100LB.IPPSSHAPF = SetRunProcessData.AboutLastRefPPSSHAPF
                If Not IsNothing(AboutPPSSHAPF) Then
                    Dim AboutSL2CIDPF As SLS300LB.SL2CIDPF = AboutPPSSHAPF.AboutSL2CIDPF
                    If Not IsNothing(AboutSL2CIDPF) Then
                        If AboutSL2CIDPF.CID93 = "B" OrElse AboutSL2CIDPF.CID93 = "F" Then
                            '夾襯紙
                            CIC15 = "1"
                        End If
                        If AboutSL2CIDPF.CID93 = "A" OrElse AboutSL2CIDPF.CID93 = "E" OrElse AboutSL2CIDPF.CID93 = "G" Then
                            '不夾襯紙
                            CIC15 = "N"
                        End If
                        If AboutSL2CIDPF.CID93 = "C" Then
                            '加紙套筒
                            CIC21 = "Y"
                        End If
                    End If
                End If
            End If
            Return ReutrnValue
        End Function
        '依據SetRunProcessData 找到PPSCIDPF之CID93欄位設定特殊訂單之要求
        'CID93用途    說明              
        'A          不夾襯紙          
        'B          切頭尾，夾新襯紙  
        'C          加紙套筒          
        'D          內銷包裝          
        'E          切頭尾 8M 不夾襯紙
        'F          不切頭尾，夾襯紙  
        'G          不切頭尾，不夾襯紙
        'H          勿註明厚度        
        'I          包裝前外觀檢驗 CIC
        'J          標註實際厚度      
        'K          標註公稱厚度      
        'X          外銷包裝          
        'P          雙面 BA 
#End Region
#Region "設定襯紙預設值 方法:SetDefaultInterleave"
        ''' <summary>
        ''' 設定襯紙預設值
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SetDefaultInterleave() As Boolean
            'CIC11:夾整捲 CIC12:定長 CIC13:紙寬 CIC14:基重 CIC15:襯紙薄厚紙(N/1薄/2厚)
            If Me.CoilStandWidth = 0 OrElse String.IsNullOrEmpty(Me.CIC00) OrElse Me.CIC00.Trim.Length < 3 OrElse IsNothing(Me.AboutCoilNumberLastPPSSHAPF) _
                OrElse (Me.CIC00.Trim.ToUpper.Substring(0, 3) = "APL" AndAlso String.IsNullOrEmpty(Me.CoilStateCR_HR)) Then
                Return False
            End If
            Dim StationName As String = Me.CIC00.Trim.ToUpper.Substring(0, 3)
            Select Case True
                Case StationName = "CPL"
                    CIC11 = "N" : CIC12 = 0 : CIC13 = 0 : CIC14 = 0 : CIC15 = "N"
                    Return True
                Case StationName = "APL" AndAlso Me.CoilStateCR_HR = "HR"
                    Select Case Me.CoilStandWidth
                        Case 950
                            CIC11 = "N" : CIC12 = 50 : CIC13 = 0.94 : CIC14 = 0.04 : CIC15 = "2"
                        Case 1000
                            CIC11 = "N" : CIC12 = 50 : CIC13 = 1.0 : CIC14 = 0.04 : CIC15 = "2"
                        Case 1219
                            CIC11 = "N" : CIC12 = 50 : CIC13 = 1.22 : CIC14 = 0.04 : CIC15 = "2"
                    End Select
                    Return True
                Case StationName = "APL" AndAlso Me.CoilStateCR_HR = "CR"
                    If Me.AboutCoilNumberLastPPSSHAPF.SHA39.ToUpper.Trim = "2D" Then
                        CIC11 = "N" : CIC12 = 0 : CIC13 = 0 : CIC14 = 0 : CIC15 = "N"
                    Else
                        Select Case Me.CoilStandWidth
                            Case 950
                                CIC11 = "Y" : CIC12 = 9999.9 : CIC13 = 0.94 : CIC14 = 0.04 : CIC15 = "2"
                            Case 1000
                                CIC11 = "Y" : CIC12 = 9999.9 : CIC13 = 1.0 : CIC14 = 0.04 : CIC15 = "2"
                            Case 1219
                                CIC11 = "Y" : CIC12 = 9999.9 : CIC13 = 1.22 : CIC14 = 0.04 : CIC15 = "2"
                        End Select
                    End If
                    Return True
                Case StationName = "GPL"
                    Select Case Me.CoilStandWidth
                        Case 950
                            CIC11 = "Y" : CIC12 = 9999.9 : CIC13 = 0.94 : CIC14 = 0.04 : CIC15 = "2"
                        Case 1000
                            CIC11 = "Y" : CIC12 = 9999.9 : CIC13 = 1.0 : CIC14 = 0.04 : CIC15 = "2"
                        Case 1219
                            CIC11 = "Y" : CIC12 = 9999.9 : CIC13 = 1.22 : CIC14 = 0.04 : CIC15 = "2"
                    End Select
                    Return True

                Case StationName = "SPL"
                    Select Case Me.CoilStandWidth
                        Case 950
                            CIC11 = "Y" : CIC12 = 9999.9 : CIC13 = 0.94 : CIC14 = 0.04 : CIC15 = "2"
                        Case 1000
                            CIC11 = "Y" : CIC12 = 9999.9 : CIC13 = 1.0 : CIC14 = 0.028 : CIC15 = "1"
                        Case 1219
                            CIC11 = "Y" : CIC12 = 9999.9 : CIC13 = 1.22 : CIC14 = 0.028 : CIC15 = "1"
                    End Select
                    Return True
                Case StationName = "SBL" OrElse StationName = "TLL"
                    If Me.AboutCoilNumberLastPPSSHAPF.SHA39.ToUpper.Trim = "2D" OrElse Me.AboutCoilNumberLastPPSSHAPF.SHA39.ToUpper.Trim = "NO1" Then
                        CIC11 = "N" : CIC12 = 0 : CIC13 = 0 : CIC14 = 0 : CIC15 = "N"
                    Else
                        Select Case Me.CoilStandWidth
                            Case 950
                                CIC11 = "Y" : CIC12 = 9999.9 : CIC13 = 0.94 : CIC14 = 0.04 : CIC15 = "2"
                            Case 1000
                                CIC11 = "Y" : CIC12 = 9999.9 : CIC13 = 1.0 : CIC14 = 0.028 : CIC15 = "1"
                            Case 1219
                                CIC11 = "Y" : CIC12 = 9999.9 : CIC13 = 1.22 : CIC14 = 0.028 : CIC15 = "1"
                        End Select
                    End If
                    Return True
            End Select
            Return False
        End Function
#End Region
#Region "設定紙套筒預設值 方法:SetDefaultCasting"
        ''' <summary>
        ''' 設定紙套筒預設值
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SetDefaultCasting() As Boolean
            'CIC21:有套筒 CIC22:套筒外徑 CIC23:鋼捲內徑 CIC24:筒重kg
            If Me.CoilStandWidth = 0 OrElse String.IsNullOrEmpty(Me.CIC00) OrElse Me.CIC00.Trim.Length < 3 OrElse IsNothing(Me.AboutCoilNumberLastPPSSHAPF) _
                OrElse (Me.CIC00.Trim.ToUpper.Substring(0, 3) = "APL" AndAlso String.IsNullOrEmpty(Me.CoilStateCR_HR)) Then
                Return False
            End If
            Dim StationName As String = Me.CIC00.Trim.ToUpper.Substring(0, 3)
            Select Case True
                Case StationName = "CPL"
                    CIC21 = "N" : CIC22 = 0 : CIC23 = 0 : CIC24 = 0
                    Return True
                Case StationName = "APL" AndAlso Me.CoilStateCR_HR = "HR"
                    CIC21 = "N" : CIC22 = 0 : CIC23 = 0 : CIC24 = 0
                    Return True
                Case StationName = "APL" AndAlso Me.CoilStateCR_HR = "CR"
                    Select Case Me.CoilStandWidth
                        Case 950
                            CIC21 = "Y" : CIC22 = 645 : CIC23 = 610 : CIC24 = 30
                        Case 1000
                            CIC21 = "Y" : CIC22 = 645 : CIC23 = 610 : CIC24 = 30
                        Case 1219
                            CIC21 = "Y" : CIC22 = 645 : CIC23 = 610 : CIC24 = 33
                    End Select
                    Return True
                Case StationName = "GPL"
                    Select Case Me.CoilStandWidth
                        Case 950
                            CIC21 = "Y" : CIC22 = 645 : CIC23 = 610 : CIC24 = 33
                        Case 1000
                            CIC21 = "Y" : CIC22 = 645 : CIC23 = 610 : CIC24 = 33
                        Case 1219
                            CIC21 = "Y" : CIC22 = 645 : CIC23 = 610 : CIC24 = 33
                    End Select
                    Return True
                Case StationName = "SPL"
                    Select Case Me.CoilStandWidth
                        Case 950
                            CIC21 = "Y" : CIC22 = 645 : CIC23 = 610 : CIC24 = 30
                        Case 1000
                            CIC21 = "Y" : CIC22 = 645 : CIC23 = 610 : CIC24 = 30
                        Case 1219
                            CIC21 = "Y" : CIC22 = 645 : CIC23 = 610 : CIC24 = 33
                    End Select
                    Return True
                Case StationName = "SBL" OrElse StationName = "TLL"
                    Select Case Me.CoilStandWidth
                        Case 950
                            CIC21 = "Y" : CIC22 = 540 : CIC23 = 508 : CIC24 = 19
                        Case 1000
                            CIC21 = "Y" : CIC22 = 540 : CIC23 = 508 : CIC24 = 19
                        Case 1219
                            CIC21 = "Y" : CIC22 = 540 : CIC23 = 508 : CIC24 = 22
                    End Select
                    Return True
            End Select
            Return False
        End Function
#End Region
#Region "設奇力龍預設值 方法:SetDefaultOutleave"
        ''' <summary>
        ''' 設奇力龍預設值
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SetDefaultOutleave() As Boolean
            'CIC31:包整捲 CIC32:加長m CIC33:紙寬m CIC34:基重kg
            If Me.CoilStandWidth = 0 OrElse String.IsNullOrEmpty(Me.CIC00) OrElse Me.CIC00.Trim.Length < 3 OrElse IsNothing(Me.AboutCoilNumberLastPPSSHAPF) _
                OrElse (Me.CIC00.Trim.ToUpper.Substring(0, 3) = "APL" AndAlso String.IsNullOrEmpty(Me.CoilStateCR_HR)) Then
                Return False
            End If
            Dim StationName As String = Me.CIC00.Trim.ToUpper.Substring(0, 3)
            Select Case True
                Case StationName = "CPL"
                    Select Case Me.CoilStandWidth
                        Case 950
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.05 : CIC34 = 1.4
                        Case 1000
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.05 : CIC34 = 1.4
                        Case 1219
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.22 : CIC34 = 1.4
                    End Select
                    If Me.AboutCoilNumberLastPPSSHAPF.SHA35.Trim <> "" Then
                        CIC32 = 1.5
                    End If
                    Return True
                Case StationName = "APL" AndAlso Me.CoilStateCR_HR = "HR"
                    Select Case Me.CoilStandWidth
                        Case 950
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.05 : CIC34 = 1.4
                        Case 1000
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.05 : CIC34 = 1.4
                        Case 1219
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.22 : CIC34 = 1.4
                    End Select
                    Return True
                Case StationName = "APL" AndAlso Me.CoilStateCR_HR = "CR"
                    Select Case Me.CoilStandWidth
                        Case 950
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.05 : CIC34 = 1.4
                        Case 1000
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.05 : CIC34 = 1.4
                        Case 1219
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.22 : CIC34 = 1.4
                    End Select
                    Return True
                Case StationName = "GPL"
                    Select Case Me.CoilStandWidth
                        Case 950
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.05 : CIC34 = 1.4
                        Case 1000
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.05 : CIC34 = 1.4
                        Case 1219
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.22 : CIC34 = 1.4
                    End Select
                    Return True
                Case StationName = "SPL"
                    Select Case Me.CoilStandWidth
                        Case 950
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.05 : CIC34 = 1.4
                        Case 1000
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.05 : CIC34 = 1.4
                        Case 1219
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.22 : CIC34 = 1.4
                    End Select
                    Return True
                Case StationName = "SBL" OrElse StationName = "TLL"
                    Select Case Me.CoilStandWidth
                        Case 950
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.05 : CIC34 = 1.4
                        Case 1000
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.05 : CIC34 = 1.4
                        Case 1219
                            CIC31 = "Y" : CIC32 = 0.3 : CIC33 = 1.22 : CIC34 = 1.4
                    End Select
                    Return True
            End Select
            Return False

        End Function
#End Region


        '#Region "鋼捲號碼 屬性:PPS01"
        '        Private _PPS01 As System.String
        '        ''' <summary>
        '        ''' 鋼捲號碼
        '        ''' </summary>
        '        ''' <returns></returns>
        '        ''' <remarks></remarks>
        '        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        '        Public Property PPS01() As System.String
        '            Get
        '                Return _PPS01
        '            End Get
        '            Set(ByVal value As System.String)
        '                _PPS01 = value
        '            End Set
        '        End Property
        '#End Region
        '#Region "分捲號碼 屬性:PPS02"
        '        Private _PPS02 As System.String
        '        ''' <summary>
        '        ''' 分捲號碼
        '        ''' </summary>
        '        ''' <returns></returns>
        '        ''' <remarks></remarks>
        '        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        '        Public Property PPS02() As System.String
        '            Get
        '                Return _PPS02
        '            End Get
        '            Set(ByVal value As System.String)
        '                _PPS02 = value
        '            End Set
        '        End Property
        '#End Region
        '#Region "日期 屬性:PPS03"
        '        Private _PPS03 As System.Int32
        '        ''' <summary>
        '        ''' 日期
        '        ''' </summary>
        '        ''' <returns></returns>
        '        ''' <remarks></remarks>
        '        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        '        Public Property PPS03() As System.Int32
        '            Get
        '                Return _PPS03
        '            End Get
        '            Set(ByVal value As System.Int32)
        '                _PPS03 = value
        '            End Set
        '        End Property
        '#End Region
        '#Region "時間 屬性:PPS04"
        '        Private _PPS04 As System.String
        '        ''' <summary>
        '        ''' 時間
        '        ''' </summary>
        '        ''' <returns></returns>
        '        ''' <remarks></remarks>
        '        Public Property PPS04() As System.String
        '            Get
        '                Return _PPS04
        '            End Get
        '            Set(ByVal value As System.String)
        '                _PPS04 = value
        '            End Set
        '        End Property
        '#End Region
        '#Region "重量 屬性:PPS05"
        '        Private _PPS05 As System.Int32
        '        ''' <summary>
        '        ''' 重量
        '        ''' </summary>
        '        ''' <returns></returns>
        '        ''' <remarks></remarks>
        '        Public Property PPS05() As System.Int32
        '            Get
        '                Return _PPS05
        '            End Get
        '            Set(ByVal value As System.Int32)
        '                _PPS05 = value
        '            End Set
        '        End Property
        '#End Region
        '#Region "內徑 屬性:PPS06"
        '        Private _PPS06 As System.Int32
        '        ''' <summary>
        '        ''' 內徑
        '        ''' </summary>
        '        ''' <returns></returns>
        '        ''' <remarks></remarks>
        '        Public Property PPS06() As System.Int32
        '            Get
        '                Return _PPS06
        '            End Get
        '            Set(ByVal value As System.Int32)
        '                _PPS06 = value
        '            End Set
        '        End Property
        '#End Region
        '#Region "編號 屬性:PPS07"
        '        Private _PPS07 As System.Int32
        '        ''' <summary>
        '        ''' 內徑
        '        ''' </summary>
        '        ''' <returns></returns>
        '        ''' <remarks></remarks>
        '        Public Property PPS07() As System.Int32
        '            Get
        '                Return _PPS07
        '            End Get
        '            Set(ByVal value As System.Int32)
        '                _PPS07 = value
        '            End Set
        '        End Property
        '#End Region

#Region "鋼捲完整號碼 屬性:CoilFullNumber"
        ''' <summary>
        ''' 鋼捲完整號碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CoilFullNumber As String
            Get
                Return CIC01 & CIC02.Trim
            End Get
        End Property
#End Region
#Region "鋼捲標準寬度 屬性:CoilStandWidth"
        ''' <summary>
        ''' 鋼捲標準寬度
        ''' </summary>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CoilStandWidth As Double
            Get
                If IsNothing(AboutCoilNumberLastPPSSHAPF) Then
                    Return 0
                End If
                Select Case True
                    Case AboutCoilNumberLastPPSSHAPF.SHA34 <= 950
                        Return 950
                    Case AboutCoilNumberLastPPSSHAPF.SHA34 < 1219
                        Return 1000
                    Case Else
                        Return 1219
                End Select
            End Get
        End Property
#End Region
#Region "鋼捲狀態CR/HR 屬性:CoilStateCR_HR"
        ''' <summary>
        ''' 鋼捲狀態CR/HR
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property CoilStateCR_HR As String
            Get
                If IsNothing(AboutCoilNumberLastPPSSHAPF) Then
                    Return ""
                End If

                ''106/09/04 ADD
                ''EX: S6754 --SHA06 欄位會有空值出現，避免Substring時錯誤
                If AboutCoilNumberLastPPSSHAPF.SHA06.Trim.Length > 0 Then
                    Dim Sha06Code As String = AboutCoilNumberLastPPSSHAPF.SHA06.Trim.ToUpper.Substring(0, 2)
                    If Sha06Code = "NO" OrElse Sha06Code = "BH" OrElse Sha06Code = "BL" OrElse Sha06Code = "CH" OrElse Sha06Code = "GH" Then
                        Return "HR"
                    End If
                    Return "CR"
                End If
                Return ""
            End Get
        End Property
#End Region

#Region "相關PP排程檔_鋼種 屬性:AboutPPSSHAPF_SHA12"
        ''' <summary>
        ''' 相關PP排程檔_鋼種
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ORMBaseClass.SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutPPSSHAPFs_LastRecordSHA12() As String
            Get
                If IsNothing(AboutPPSSHAPF) Then
                    Return Nothing
                End If
                Return AboutPPSSHAPF.SHA12
            End Get
        End Property
#End Region
#Region "相關PP排程檔_表面 屬性:AboutPPSSHAPF_SHA06"
        ''' <summary>
        ''' 相關PP排程檔_表面
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ORMBaseClass.SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutPPSSHAPFs_LastRecordSHA06() As String
            Get
                If IsNothing(AboutPPSSHAPF) Then
                    Return Nothing
                End If
                Return AboutPPSSHAPF.SHA06
            End Get
        End Property
#End Region
#Region "相關PP排程檔_厚度 屬性:AboutPPSSHAPFs_LastRecordSHA14"
        ''' <summary>
        ''' 相關PP排程檔_厚度
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ORMBaseClass.SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutPPSSHAPFs_LastRecordSHA14() As String
            Get
                If IsNothing(AboutPPSSHAPF) Then
                    Return Nothing
                End If
                Return AboutPPSSHAPF.SHA14
            End Get
        End Property
#End Region
#Region "相關PP排程檔_寬度 屬性:AboutPPSSHAPFs_LastRecordSHA15"
        ''' <summary>
        ''' 相關PP排程檔_寬度
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ORMBaseClass.SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutPPSSHAPFs_LastRecordSHA15() As String
            Get
                If IsNothing(AboutPPSSHAPF) Then
                    Return Nothing
                End If
                Return AboutPPSSHAPF.SHA15
            End Get
        End Property
#End Region
#Region "相關PP排程檔_繳庫單位 屬性:AboutPPSSHAPF_SHA08"
        ''' <summary>
        ''' 相關PP排程檔_繳庫單位
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ORMBaseClass.SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutPPSSHAPFs_LastRecordSHA08() As String
            Get
                If IsNothing(AboutPPSSHAPF) Then
                    Return Nothing
                End If
                Return AboutPPSSHAPF.SHA08
            End Get
        End Property

#End Region
#Region "相關PP排程檔_內外銷代碼 屬性:AboutPPSSHAPF_SHA36"
        ''' <summary>
        ''' 相關PP排程檔_內外銷代碼
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ORMBaseClass.SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutPPSSHAPFs_LastRecordSHA35() As String
            Get
                If IsNothing(AboutPPSSHAPF) Then
                    Return Nothing
                End If
                Return _AboutPPSSHAPF.SHA35
            End Get
        End Property
#End Region
#Region "相關PP排程檔(PPSSHAPF) 屬性:AboutPPSSHAPF"
        Private _AboutPPSSHAPF As PPSSHAPF
        Private _AboutPPSSHAPFLastAccessTime As DateTime = New DateTime(2000, 1, 1)
        ''' <summary>
        ''' 相關PP排程檔(PPSSHAPF)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ORMBaseClass.SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property AboutPPSSHAPF() As PPSSHAPF
            Get
                If String.IsNullOrEmpty(CIC00) OrElse CIC00.Trim.Length = 0 Then
                    Return Nothing
                End If
                If Now.Subtract(_AboutPPSSHAPFLastAccessTime).TotalSeconds > 3 AndAlso IsNothing(_AboutPPSSHAPF) Then
                    Dim SearchResult As List(Of PPSSHAPF) = PPSSHAPF.CDBSelect(Of PPSSHAPF)("Select * From " & (New PPSSHAPF).CDBFullAS400DBPath & " Where SHA01='" & Me.CIC01 & "' AND SHA02='" & Me.CIC02 & "'" _
                        & " and sha08 like '" & StationConvertLikeString() & "' Order by SHA04 ASC ", Me.CDBCurrentUseSQLQueryAdapter)
                    If SearchResult.Count > 0 Then
                        _AboutPPSSHAPF = SearchResult(SearchResult.Count - 1)
                    End If
                    _AboutPPSSHAPFLastAccessTime = Now
                End If
                Return _AboutPPSSHAPF
            End Get
            Private Set(value As PPSSHAPF)
                _AboutPPSSHAPF = value
                If IsNothing(value) Then
                    _AboutPPSSHAPFLastAccessTime = New DateTime(2000, 1, 1)
                Else
                    _AboutPPSSHAPFLastAccessTime = Now
                End If
            End Set
        End Property

        Private Function StationConvertLikeString() As String
            If String.IsNullOrEmpty(CIC00) OrElse CIC00.Trim.Length = 0 Then
                Return Nothing
            End If
            Dim FindString As String = CIC00.Trim.ToUpper
            Select Case True
                Case FindString.Substring(0, 3) = "CPL"
                    Return "CP%"
                Case FindString.Substring(0, 3) = "APL"
                    Return "AP%"
                Case FindString.Substring(0, 3) = "ZML"
                    Return "Z%"
                Case FindString.Substring(0, 3) = "GPL"
                    Return "GP%"
                Case FindString.Substring(0, 3) = "BAL"
                    Return "B%"
                Case FindString.Substring(0, 3) = "TLL"
                    Return "TL%"
                Case FindString.Substring(0, 3) = "SPL"
                    Return "SP%"
                Case FindString.Substring(0, 3) = "SBL"
                    Return "SB%"
                    'Case FindString.Substring(0, 3) = "STK"
                    '    Return "%*"
            End Select
            Return Nothing
        End Function

#End Region

#Region "相關鋼捲編號之最後PP排程檔(PPSSHAPF) 屬性:AboutCoilNumberLastPPSSHAPF"
        Private _AboutCoilNumberLastPPSSHAPF As PPSSHAPF
        Private _AboutCoilNumberLastPPSSHAPFLastAccessTime As DateTime = New DateTime(2000, 1, 1)
        ''' <summary>
        ''' 相關鋼捲編號之最後PP排程檔(PPSSHAPF)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ORMBaseClass.SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Property AboutCoilNumberLastPPSSHAPF() As PPSSHAPF
            Get
                If String.IsNullOrEmpty(CIC00) OrElse CIC00.Trim.Length = 0 Then
                    Return Nothing
                End If
                If Now.Subtract(_AboutCoilNumberLastPPSSHAPFLastAccessTime).TotalSeconds > 3 OrElse IsNothing(_AboutCoilNumberLastPPSSHAPF) Then
                    Dim SearchResult As List(Of PPSSHAPF) = PPSSHAPF.CDBSelect(Of PPSSHAPF)("Select * From " & (New PPSSHAPF).CDBFullAS400DBPath & " Where SHA01='" & Me.CIC01 & "' " _
                        & " Order by SHA04 ASC ", Me.CDBCurrentUseSQLQueryAdapter)
                    If SearchResult.Count > 0 Then
                        _AboutCoilNumberLastPPSSHAPF = SearchResult(SearchResult.Count - 1)
                    End If
                    _AboutCoilNumberLastPPSSHAPFLastAccessTime = Now
                End If
                Return _AboutCoilNumberLastPPSSHAPF
            End Get
            Private Set(value As PPSSHAPF)
                _AboutCoilNumberLastPPSSHAPF = value
                If IsNothing(value) Then
                    _AboutCoilNumberLastPPSSHAPFLastAccessTime = New DateTime(2000, 1, 1)
                Else
                    _AboutCoilNumberLastPPSSHAPFLastAccessTime = Now
                End If
            End Set
        End Property
#End Region


    End Class
End Namespace