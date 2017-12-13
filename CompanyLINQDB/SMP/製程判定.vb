Partial Public Class 製程判定

#Region "取得元素值 方法:GetElementValue"
    ''' <summary>
    ''' 取得元素值
    ''' </summary>
    ''' <param name="GetElementName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetElementValue(ByVal GetElementName As String) As Single
        If IsNullElementValue(GetElementName) Then
            If Me.上下限 = "H" Then
                Return 999
            End If
            Return -999
        End If
        Dim ElementName As String = GetElementName.ToUpper
        Select Case ElementName
            Case "DF"
                Return Me.DF
            Case "MD30"
                Return Me.MD30
            Case "C"
                Return Me.C
            Case "SI"
                Return Me.Si
            Case "MN"
                Return Me.Mn
            Case "P"
                Return Me.P
            Case "CR"
                Return Me.Cr
            Case "NI"
                Return Me.Ni
            Case "CU"
                Return Me.Cu
            Case "MO"
                Return Me.Mo
            Case "SN"
                Return Me.Sn
            Case "PB"
                Return Me.Pb
            Case "N2"
                Return Me.N2
            Case "CO"
                Return Me.Co
            Case "AL"
                Return Me.AL
            Case "TI"
                Return Me.Ti
            Case "NB"
                Return Me.Nb
            Case "O2"
                Return Me.O2
            Case "B"
                Return Me.B
            Case "CA"
                Return Me.Ca
            Case "MG"
                Return Me.Mg


            Case "S"
                Return Me.S
            Case "V"
                Return Me.V
            Case "FE"
                Return Me.Fe
            Case "AS"
                Return Me.As
            Case "BI"
                Return Me.Bi
            Case "SB"
                Return Me.Sb
            Case "ZN"
                Return Me.Zn
            Case "ZR"
                Return Me.Zr
            Case "GP"
                Return Me.GP
            Case "TA"
                Return Me.Ta
            Case "CANDN"
                Return Me.CAndN
            Case "NBANDTA"
                Return Me.NbAndTa

        End Select
        If Me.上下限 = "H" Then
            Return 999
        End If
        Return -999
    End Function
#End Region
#Region "取得元素值是否為Nothing值 方法:IsNullElementValue"
    ''' <summary>
    ''' 取得元素值是否為Nothing值
    ''' </summary>
    ''' <param name="GetElementName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsNullElementValue(ByVal GetElementName As String) As Boolean
        Dim ElementName As String = GetElementName.ToUpper
        Select Case ElementName
            Case "DF"
                Return IsNothing(Me.DF)
            Case "MD30"
                Return IsNothing(Me.MD30)
            Case "C"
                Return IsNothing(Me.C)
            Case "SI"
                Return IsNothing(Me.Si)
            Case "MN"
                Return IsNothing(Me.Mn)
            Case "P"
                Return IsNothing(Me.P)
            Case "CR"
                Return IsNothing(Me.Cr)
            Case "NI"
                Return IsNothing(Me.Ni)
            Case "CU"
                Return IsNothing(Me.Cu)
            Case "MO"
                Return IsNothing(Me.Mo)
            Case "SN"
                Return IsNothing(Me.Sn)
            Case "PB"
                Return IsNothing(Me.Pb)
            Case "N2"
                Return IsNothing(Me.N2)
            Case "CO"
                Return IsNothing(Me.Co)
            Case "AL"
                Return IsNothing(Me.AL)
            Case "TI"
                Return IsNothing(Me.Ti)
            Case "NB"
                Return IsNothing(Me.Nb)
            Case "O2"
                Return IsNothing(Me.O2)
            Case "B"
                Return IsNothing(Me.B)
            Case "CA"
                Return IsNothing(Me.Ca)
            Case "MG"
                Return IsNothing(Me.Mg)


            Case "S"
                Return IsNothing(Me.S)
            Case "V"
                Return IsNothing(Me.V)
            Case "FE"
                Return IsNothing(Me.Fe)
            Case "AS"
                Return IsNothing(Me.As)
            Case "BI"
                Return IsNothing(Me.Bi)
            Case "SB"
                Return IsNothing(Me.Sb)
            Case "ZN"
                Return IsNothing(Me.Zn)
            Case "ZR"
                Return IsNothing(Me.Zr)
            Case "GP"
                Return IsNothing(Me.GP)
            Case "TA"
                Return IsNothing(Me.Ta)
            Case "CANDN"
                Return IsNothing(Me.CAndN)
            Case "NBANDTA"
                Return IsNothing(Me.NbAndTa)

        End Select
        Return True
    End Function

#End Region

#Region "是否有Nothing值 屬性:IsHaveNullValue"
    ''' <summary>
    ''' 是否有Nothing值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsHaveNullValue() As Boolean
        Get
            Select Case True
                Case IsNothing(Me.DF)
                    Return True
                Case IsNothing(Me.MD30)
                    Return True
                Case IsNothing(Me.C)
                    Return True
                Case IsNothing(Me.Si)
                    Return True
                Case IsNothing(Me.Mn)
                    Return True
                Case IsNothing(Me.P)
                    Return True
                Case IsNothing(Me.Cr)
                    Return True
                Case IsNothing(Me.Ni)
                    Return True
                Case IsNothing(Me.Cu)
                    Return True
                Case IsNothing(Me.Mo)
                    Return True
                Case IsNothing(Me.Sn)
                    Return True
                Case IsNothing(Me.Pb)
                    Return True
                Case IsNothing(Me.N2)
                    Return True
                Case IsNothing(Me.Co)
                    Return True
                Case IsNothing(Me.AL)
                    Return True
                Case IsNothing(Me.Ti)
                    Return True
                Case IsNothing(Me.Nb)
                    Return True
                Case IsNothing(Me.O2)
                    Return True
                Case IsNothing(Me.B)
                    Return True
                Case IsNothing(Me.Ca)
                    Return True
                Case IsNothing(Me.Mg)
                    Return True


                Case IsNothing(Me.S)
                    Return True
                Case IsNothing(Me.V)
                    Return True
                Case IsNothing(Me.Fe)
                    Return True
                Case IsNothing(Me.As)
                    Return True
                Case IsNothing(Me.Bi)
                    Return True
                Case IsNothing(Me.Sb)
                    Return True
                Case IsNothing(Me.Zn)
                    Return True
                Case IsNothing(Me.Zr)
                    Return True
                Case IsNothing(Me.GP)
                    Return True
                Case IsNothing(Me.Ta)
                    Return True
                Case IsNothing(Me.CAndN)
                    Return True
                Case IsNothing(Me.NbAndTa)
                    Return True



            End Select
            Return False
        End Get
    End Property
#End Region

End Class
