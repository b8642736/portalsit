''' <summary>
''' 鋼捲產出率計算器
''' </summary>
''' <remarks></remarks>
Public Class CoilYieldRateCompute

    Sub New(ByVal SetProductData As PPS100LB.PPSCIAPF, ByVal SetAllPPSSHAPFsForCoilNumber As List(Of IPPS100LB.IPPSSHAPF))
        Me.ProductData = SetProductData
        Me.PPSSHAPFsForCoilNumber = SetAllPPSSHAPFsForCoilNumber
        Me.SHA01 = Me.ProductData.CIA02
        Me.SHA02 = Me.ProductData.CIA03
        Me.SHA04 = -1
        Me.IsBreaKPPSSHAPFRecord = False
    End Sub

    Private Sub New(ByVal SetChildCoilYieldRateCompute As CoilYieldRateCompute)
        Me.AboutChildCoilYieldRateCompute = SetChildCoilYieldRateCompute
        Me.PPSSHAPFsForCoilNumber = SetChildCoilYieldRateCompute.PPSSHAPFsForCoilNumber
        Dim FatherPPSSHAPF As IPPS100LB.IPPSSHAPF = FindFatherPPSSHAPF(SetChildCoilYieldRateCompute.AboutPPSSHAPF)
        If IsNothing(FatherPPSSHAPF) Then
            Throw New Exception("找不到PPSSHAPF父節點 原節點 SHA01,SHA02,SHA04,SHA29='" & SetChildCoilYieldRateCompute.AboutPPSSHAPF.SHA01 & "," & SetChildCoilYieldRateCompute.AboutPPSSHAPF.SHA02 & "," & SetChildCoilYieldRateCompute.AboutPPSSHAPF.SHA04 & "," & SetChildCoilYieldRateCompute.AboutPPSSHAPF.SHA29 & "'")
        End If
        AboutPPSSHAPF = FatherPPSSHAPF
        Me.SHA01 = AboutPPSSHAPF.SHA01
        Me.SHA02 = AboutPPSSHAPF.SHA02
        Me.SHA04 = AboutPPSSHAPF.SHA04
        Me.IsBreaKPPSSHAPFRecord = (AboutPPSSHAPF.SHA29 = "*")
    End Sub


#Region "尋找PPSSHAPF之前一筆(父)PPSSHAPF 方法:FindFatherPPSSHAPF"
    Private Function FindFatherPPSSHAPF(ByVal SourcePPSSHAPF As IPPS100LB.IPPSSHAPF) As IPPS100LB.IPPSSHAPF
        Dim ReturnValue As IPPS100LB.IPPSSHAPF = Nothing
        If SourcePPSSHAPF.SHA04 = 0 Then
            Return Nothing
        End If
        Dim FindSHA01 As String = SourcePPSSHAPF.SHA01
        Dim FindSHA02 As String = Nothing
        Dim FindSHA04 As Integer = -1
        For Each EachItem As IPPS100LB.IPPSSHAPF In Me.PPSSHAPFsForCoilNumber
            Select Case True
                'Case SourcePPSSHAPF.SHA29.Trim = "*" AndAlso SourcePPSSHAPF.SHA02.Trim.Length > 0
                Case SourcePPSSHAPF.SHA29.Trim = "*" 'AndAlso SourcePPSSHAPF.SHA02.Trim.Length = 0
                    For Each EachItem1 As IPPS100LB.IPPSSHAPF In Me.PPSSHAPFsForCoilNumber
                        If EachItem1.SHA29.Trim = "" AndAlso EachItem1.SHA01 = SourcePPSSHAPF.SHA01 AndAlso EachItem1.SHA02.Trim = SourcePPSSHAPF.SHA02.Trim AndAlso EachItem1.SHA04 = (SourcePPSSHAPF.SHA04 - 1) Then
                            Return EachItem1
                        End If
                    Next
                    For Each EachItem1 As IPPS100LB.IPPSSHAPF In Me.PPSSHAPFsForCoilNumber
                        If EachItem1.SHA29.Trim = "" AndAlso EachItem1.SHA01 = SourcePPSSHAPF.SHA01 AndAlso EachItem1.SHA02.Trim = SourcePPSSHAPF.SHA02.Trim.Substring(SourcePPSSHAPF.SHA02.Trim.Length - 1) AndAlso EachItem1.SHA04 = (SourcePPSSHAPF.SHA04 - 1) Then
                            Return EachItem1
                        End If
                    Next
                Case SourcePPSSHAPF.SHA29.Trim = "" AndAlso SourcePPSSHAPF.SHA02.Trim.Length = 0
                    For Each EachItem1 As IPPS100LB.IPPSSHAPF In Me.PPSSHAPFsForCoilNumber
                        If EachItem1.SHA29.Trim = "" AndAlso EachItem1.SHA01 = SourcePPSSHAPF.SHA01 AndAlso EachItem1.SHA04 = (SourcePPSSHAPF.SHA04 - 1) Then
                            Return EachItem1
                        End If
                    Next
                    For Each EachItem1 As IPPS100LB.IPPSSHAPF In Me.PPSSHAPFsForCoilNumber
                        If EachItem1.SHA29 = "*" AndAlso EachItem1.SHA01 = SourcePPSSHAPF.SHA01 AndAlso EachItem1.SHA04 = SourcePPSSHAPF.SHA04 Then
                            Return EachItem1
                        End If
                    Next
                Case SourcePPSSHAPF.SHA29.Trim = "" AndAlso SourcePPSSHAPF.SHA02.Trim.Length > 0
                    For Each EachItem1 As IPPS100LB.IPPSSHAPF In Me.PPSSHAPFsForCoilNumber
                        If EachItem1.SHA29.Trim = "" AndAlso EachItem1.SHA01 = SourcePPSSHAPF.SHA01 AndAlso EachItem1.SHA02.Trim = SourcePPSSHAPF.SHA02.Trim AndAlso EachItem1.SHA04 = (SourcePPSSHAPF.SHA04 - 1) Then
                            Return EachItem1
                        End If
                    Next

                    '1051206 by renhsin
                    '將SHA02(切捲)減一碼，查母捲
                    '--------------------------------------------------------------------------
                    Dim W_FatherSHA02 As String = SourcePPSSHAPF.SHA02.Trim
                    If W_FatherSHA02.Length >= 1 Then
                        W_FatherSHA02 = SourcePPSSHAPF.SHA02.Trim.Substring(0, SourcePPSSHAPF.SHA02.Trim.Length - 1)
                    End If
                    For Each EachItem1 As IPPS100LB.IPPSSHAPF In Me.PPSSHAPFsForCoilNumber
                        If EachItem1.SHA29.Trim = "" AndAlso EachItem1.SHA01 = SourcePPSSHAPF.SHA01 AndAlso EachItem1.SHA02.Trim = W_FatherSHA02 AndAlso EachItem1.SHA04 = (SourcePPSSHAPF.SHA04 - 1) Then
                            Return EachItem1
                        End If
                    Next
                    '--------------------------------------------------------------------------

                    For Each EachItem1 As IPPS100LB.IPPSSHAPF In Me.PPSSHAPFsForCoilNumber
                        If EachItem1.SHA29 = "*" AndAlso EachItem1.SHA01 = SourcePPSSHAPF.SHA01 AndAlso EachItem1.SHA02.Trim = SourcePPSSHAPF.SHA02.PadRight(5).Substring(0, SourcePPSSHAPF.SHA02.Trim.Length - 1) AndAlso EachItem1.SHA04 = SourcePPSSHAPF.SHA04 Then
                            Return EachItem1
                        End If
                    Next
            End Select
        Next
        Return Nothing
    End Function
#End Region
#Region "取某P.P.排程檔之子排程 方法:GetSubPPSSHAPFs"
    ''' <summary>
    ''' 取某P.P.排程檔之子排程(SHA29='*'也算一階段排程)
    ''' </summary>
    ''' <param name="SourcePPSSHAPF"></param>
    ''' <returns></returns>
    ''' <remarks>SHA29='*'也算一階段排程</remarks>
    Public Function GetSubPPSSHAPFs(ByVal SourcePPSSHAPF As IPPS100LB.IPPSSHAPF) As List(Of IPPS100LB.IPPSSHAPF)
        Dim GetSourcePPSSHAPF = SourcePPSSHAPF
        'If IsNothing(GetSourcePPSSHAPF) Then
        '    GetSourcePPSSHAPF = Me.FirstPPSSHAPF
        '    If IsNothing(GetSourcePPSSHAPF) Then
        '        Return New List(Of IPPS100LB.IPPSSHAPF)
        '    End If
        'End If
        Dim ReturnValue As New List(Of IPPS100LB.IPPSSHAPF)
        Dim SourcePPSSHAPFBorkenNO As String = GetSourcePPSSHAPF.SHA02.Trim
        If GetSourcePPSSHAPF.SHA29.Trim = "*" Then
            '此筆資料為分捲資料
            For Each EachItem In PPSSHAPFsForCoilNumber
                If EachItem.SHA29.Trim <> "*" AndAlso EachItem.SHA02.Trim.PadRight(SourcePPSSHAPFBorkenNO.Length).Substring(0, SourcePPSSHAPFBorkenNO.Length) = SourcePPSSHAPFBorkenNO AndAlso EachItem.SHA04 = GetSourcePPSSHAPF.SHA04 Then
                    ReturnValue.Add(EachItem)
                End If
            Next
        Else

            For Each EachItem In PPSSHAPFsForCoilNumber
                If EachItem.SHA29.Trim = "*" AndAlso EachItem.SHA02.Trim.PadRight(SourcePPSSHAPFBorkenNO.Length).Substring(0, SourcePPSSHAPFBorkenNO.Length) = SourcePPSSHAPFBorkenNO AndAlso EachItem.SHA04 = (GetSourcePPSSHAPF.SHA04 + 1) Then
                    '子排程資料為分捲排程
                    ReturnValue.Add(EachItem)
                End If
            Next
            If ReturnValue.Count = 0 Then
                '子排程資料非分捲排程
                For Each EachItem In PPSSHAPFsForCoilNumber
                    If EachItem.SHA02.Trim.PadRight(SourcePPSSHAPFBorkenNO.Length).Substring(0, SourcePPSSHAPFBorkenNO.Length) = SourcePPSSHAPFBorkenNO AndAlso EachItem.SHA04 = (GetSourcePPSSHAPF.SHA04 + 1) Then
                        ReturnValue.Add(EachItem)
                    End If
                Next
            End If
        End If
        Return ReturnValue
    End Function
#End Region

    '#Region "尋找PPSSHAPF之分捲定義PPSSHAPF 方法:FindBreakPPSSHAPFFromPPSSHAPF"
    '    ''' <summary>
    '    ''' 尋找PPSSHAPF之分捲定義PPSSHAPF
    '    ''' </summary>
    '    ''' <param name="FromPPSSHAPF"></param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Private Function FindBreakPPSSHAPFFromPPSSHAPF(ByVal FromPPSSHAPF As IPPS100LB.IPPSSHAPF) As IPPS100LB.IPPSSHAPF
    '        If IsNothing(FromPPSSHAPF) Then
    '            Return Nothing
    '        End If
    '        If FromPPSSHAPF.SHA29.Trim = "*" OrElse FromPPSSHAPF.SHA02.Trim = "" Then
    '            Return Nothing
    '        End If
    '        For Each EachItem As IPPS100LB.IPPSSHAPF In PPSSHAPFsForCoilNumber
    '            If EachItem.SHA04 = FromPPSSHAPF.SHA04 AndAlso EachItem.SHA01 = FromPPSSHAPF.SHA01 AndAlso EachItem.SHA02.Trim = FromPPSSHAPF.SHA02.Trim.Substring(0, FromPPSSHAPF.SHA02.Trim.Length - 1) Then
    '                Return EachItem
    '            End If
    '        Next
    '        Return Nothing
    '    End Function
    '#End Region
#Region "成品繳庫資料 屬性:ProductData"

    Private _ProductData As CompanyORMDB.PPS100LB.PPSCIAPF = Nothing
    ''' <summary>
    ''' 成品繳庫資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ProductData() As CompanyORMDB.PPS100LB.PPSCIAPF
        Get
            If IsNothing(_ProductData) AndAlso Not IsNothing(Me.AboutChildCoilYieldRateCompute) Then
                _ProductData = Me.AboutChildCoilYieldRateCompute.ProductData
            End If
            Return _ProductData
        End Get
        Private Set(ByVal value As CompanyORMDB.PPS100LB.PPSCIAPF)
            _ProductData = value
        End Set
    End Property

#End Region
#Region "鋼捲號碼 屬性:SHA01"

    Private _SHA01 As String
    Public Property SHA01() As String
        Get
            Return _SHA01
        End Get
        Set(ByVal value As String)
            _SHA01 = value
        End Set
    End Property

#End Region
#Region "分捲號碼 屬性:SHA02"

    Private _SHA02 As String
    Public Property SHA02() As String
        Get
            Return _SHA02
        End Get
        Set(ByVal value As String)
            _SHA02 = value
        End Set
    End Property

#End Region
#Region "鋼捲序號  屬性:SHA04"
    Private _SHA04 As Integer = -1
    ''' <summary>
    ''' 鋼捲序號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SHA04() As Integer
        Get

            If _SHA04 < 0 AndAlso Not IsNothing(Me.AboutPPSSHAPF) Then
                _SHA04 = Me.AboutPPSSHAPF.SHA04
            End If
            Return _SHA04
        End Get
        Private Set(ByVal value As Integer)
            _SHA04 = value
        End Set
    End Property
#End Region
#Region "是否為分捲資料 屬性:IsBreaKPPSSHAPFRecord"
    Private _IsBreaKPPSSHAPFRecord As Boolean
    ''' <summary>
    ''' 是否為分捲資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsBreaKPPSSHAPFRecord As Boolean
        Get
            Return _IsBreaKPPSSHAPFRecord
        End Get
        Private Set(ByVal value As Boolean)
            _IsBreaKPPSSHAPFRecord = value
        End Set
    End Property
#End Region

#Region "本站投料比率 屬性:InputWeightRate"
    ReadOnly Property InputWeightRate As Single
        Get
            If IsNothing(Me.AboutFatherCoilYieldRateCompute) Then
                Return 1
            End If
            Dim BreakLengRate As Single = 1
            If Me.AboutFatherCoilYieldRateCompute.IsBreaKPPSSHAPFRecord Then
                Dim TotalBreakCoilLeng As Double = 0
                Dim TotalBreakCoilWeight As Double = 0
                For Each EachItem As IPPS100LB.IPPSSHAPF In Me.AboutFatherCoilYieldRateCompute.AboutChildPPSSHAPFs
                    If EachItem.SHA16 = 0 Then
                        TotalBreakCoilLeng = 0 : Exit For
                    End If
                    TotalBreakCoilLeng += EachItem.SHA16
                Next
                If TotalBreakCoilLeng = 0 OrElse Me.AboutPPSSHAPF.SHA16 = 0 Then
                    If IsNothing(Me.AboutFatherCoilYieldRateCompute.AboutPPSSHAPF) OrElse Me.AboutFatherCoilYieldRateCompute.AboutPPSSHAPF.SHA17 = 0 Then
                        TotalBreakCoilWeight = 0
                    Else
                        For Each EachItem As IPPS100LB.IPPSSHAPF In Me.AboutFatherCoilYieldRateCompute.AboutChildPPSSHAPFs
                            TotalBreakCoilWeight += EachItem.SHA17
                        Next
                    End If
                    BreakLengRate = Me.AboutPPSSHAPF.SHA17 / TotalBreakCoilWeight
                Else
                    BreakLengRate = Me.AboutPPSSHAPF.SHA16 / TotalBreakCoilLeng
                End If
            End If
            Return BreakLengRate
        End Get
    End Property
#End Region
#Region "本站投入量 屬性:InputWeight"
    ''' <summary>
    ''' 本站投入量
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property InputWeight As Double
        Get
            'If IsNothing(Me.AboutFatherCoilYieldRateCompute) Then
            '    Return 0
            'End If
            'Dim BreakLengRate As Single = 1
            'If Me.AboutFatherCoilYieldRateCompute.IsBreaKPPSSHAPFRecord Then
            '    Dim TotalBreakCoilLeng As Double = 0
            '    Dim TotalBreakCoilWeight As Double = 0
            '    For Each EachItem As IPPS100LB.IPPSSHAPF In Me.AboutFatherCoilYieldRateCompute.AboutChildPPSSHAPFs
            '        If EachItem.SHA16 = 0 Then
            '            TotalBreakCoilLeng = 0 : Exit For
            '        End If
            '        TotalBreakCoilLeng += EachItem.SHA16
            '    Next
            '    If TotalBreakCoilLeng = 0 OrElse Me.AboutPPSSHAPF.SHA16 = 0 Then
            '        If IsNothing(Me.AboutFatherCoilYieldRateCompute.AboutPPSSHAPF) OrElse Me.AboutFatherCoilYieldRateCompute.AboutPPSSHAPF.SHA17 = 0 Then
            '            TotalBreakCoilWeight = 0
            '        Else
            '            For Each EachItem As IPPS100LB.IPPSSHAPF In Me.AboutFatherCoilYieldRateCompute.AboutChildPPSSHAPFs
            '                TotalBreakCoilWeight += EachItem.SHA17
            '            Next
            '        End If
            '        BreakLengRate = Me.AboutPPSSHAPF.SHA17 / TotalBreakCoilWeight
            '    Else
            '        BreakLengRate = Me.AboutPPSSHAPF.SHA16 / TotalBreakCoilLeng
            '    End If
            'End If

            Dim BreakLengRate As Single = 1
            Dim FahterCoilYieldRateCompute As CoilYieldRateCompute = Me
            Do While Not IsNothing(FahterCoilYieldRateCompute) AndAlso Not IsNothing(FahterCoilYieldRateCompute.AboutPPSSHAPF)
                BreakLengRate *= FahterCoilYieldRateCompute.InputWeightRate
                FahterCoilYieldRateCompute = FahterCoilYieldRateCompute.AboutFatherCoilYieldRateCompute
            Loop
            Return Me.AboutFatherCoilYieldRateCompute.AboutTopPPSSHAPF.SHA17 * BreakLengRate ' InputWeightRate
        End Get
    End Property
#End Region
#Region "本站產出量 屬性:OutputWeight"
    ReadOnly Property OutputWeight As Double
        Get
            Return Me.AboutPPSSHAPF.SHA17
        End Get
    End Property
#End Region
#Region "本站產出率 屬性:ProductRate"
    ''' <summary>
    ''' 產出率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ProductRate As Double
        Get
            If InputWeight = 0 Then
                Return 1
            End If
            Return OutputWeight / InputWeight
        End Get
    End Property
#End Region


#Region "相關父鋼捲產出率計算器 屬性:AboutFatherCoilYieldRateCompute"
    Private _AboutFatherCoilYieldRateCompute As CoilYieldRateCompute = Nothing
    ''' <summary>
    ''' 相關父鋼捲產出率計算器
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AboutFatherCoilYieldRateCompute As CoilYieldRateCompute
        Get
            If Me.SHA04 <= 0 Then
                Return Nothing
            End If
            If IsNothing(_AboutFatherCoilYieldRateCompute) Then
                _AboutFatherCoilYieldRateCompute = New CoilYieldRateCompute(Me)
            End If
            Return _AboutFatherCoilYieldRateCompute
        End Get
    End Property
#End Region
#Region "相關子鋼捲產出率計算器 屬性:AboutChildCoilYieldRateCompute"

    Private _AboutChildCoilYieldRateCompute As CoilYieldRateCompute
    ''' <summary>
    ''' 相關子鋼捲產出率計算器
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutChildCoilYieldRateCompute() As CoilYieldRateCompute
        Get
            Return _AboutChildCoilYieldRateCompute
        End Get
        Private Set(ByVal value As CoilYieldRateCompute)
            _AboutChildCoilYieldRateCompute = value
        End Set
    End Property

#End Region
#Region "相關根節點PPSSHAPF資料 屬性:AboutTopPPSSHAPF"
    ''' <summary>
    ''' 相關根節點PPSSHAPF資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AboutTopPPSSHAPF As IPPS100LB.IPPSSHAPF
        Get
            For Each EachItem As IPPS100LB.IPPSSHAPF In PPSSHAPFsForCoilNumber
                If EachItem.SHA04 = 0 Then
                    Return EachItem
                End If
            Next
            Return Nothing
        End Get
    End Property
#End Region
#Region "相關PPSSHAPF資料 屬性:AboutPPSSHAPF"
    Private _AboutPPSSHAPF As IPPS100LB.IPPSSHAPF = Nothing
    ''' <summary>
    ''' 相關PPSSHAPF資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutPPSSHAPF As IPPS100LB.IPPSSHAPF
        Get
            Dim IsFindLastFullCoilNumberItem As Boolean = IsNothing(Me.AboutChildCoilYieldRateCompute)
            If IsNothing(_AboutPPSSHAPF) Then
                For Each EachItem As IPPS100LB.IPPSSHAPF In PPSSHAPFsForCoilNumber
                    If EachItem.SHA01 = Me.SHA01 AndAlso EachItem.SHA02.Trim = Me.SHA02.Trim Then
                        Select Case True
                            Case IsBreaKPPSSHAPFRecord = True AndAlso EachItem.SHA29.Trim <> "*"
                                Continue For
                            Case IsBreaKPPSSHAPFRecord = False AndAlso EachItem.SHA29.Trim = "*"
                                Continue For
                            Case IsFindLastFullCoilNumberItem AndAlso IsNothing(_AboutPPSSHAPF)
                                _AboutPPSSHAPF = EachItem : Continue For
                            Case IsFindLastFullCoilNumberItem AndAlso Not IsNothing(_AboutPPSSHAPF) AndAlso _AboutPPSSHAPF.SHA04 < EachItem.SHA04
                                _AboutPPSSHAPF = EachItem : Continue For
                            Case Not IsFindLastFullCoilNumberItem AndAlso EachItem.SHA04 = Me.SHA04
                                _AboutPPSSHAPF = EachItem : Exit For
                        End Select
                    End If
                Next
            End If
            Return _AboutPPSSHAPF
        End Get
        Private Set(ByVal value As IPPS100LB.IPPSSHAPF)
            _AboutPPSSHAPF = value
        End Set
    End Property
#End Region
#Region "相關子PPSSHAPFs資料 屬性:AboutChildPPSSHAPFs"
    ''' <summary>
    ''' 相關子PPSSHAPFs資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AboutChildPPSSHAPFs As List(Of IPPS100LB.IPPSSHAPF)
        Get
            Return GetSubPPSSHAPFs(Me.AboutPPSSHAPF)
        End Get
    End Property
#End Region

#Region "鋼捲號碼(SHA01)所有相關PPSSHAPF資料 屬性:PPSSHAPFsForCoilNumber"
    Private _PPSSHAPFsForCoilNumber As List(Of IPPS100LB.IPPSSHAPF)
    ''' <summary>
    ''' 鋼捲號碼(SHA01)所有相關PPSSHAPF資料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PPSSHAPFsForCoilNumber() As List(Of IPPS100LB.IPPSSHAPF)
        Get
            Return _PPSSHAPFsForCoilNumber
        End Get
        Set(ByVal value As List(Of IPPS100LB.IPPSSHAPF))
            Dim SetValues As New List(Of IPPS100LB.IPPSSHAPF)
            For Each EachItem As IPPS100LB.IPPSSHAPF In value
                If EachItem.SHA01.Trim = Me.ProductData.CIA02.Trim Then
                    SetValues.Add(EachItem)
                End If
            Next
            _PPSSHAPFsForCoilNumber = SetValues
        End Set
    End Property
#End Region

End Class
