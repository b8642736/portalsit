Namespace IPPS100LB

    Public Interface IPPSSHAPF
        Inherits IClassDB, IClassDBInherited
        ''' <summary>
        ''' BUILD-UP NO
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property SHA01 As String
        ''' <summary>
        ''' COIL BROKEN NO
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property SHA02 As String
        Property SHA03 As String
        ''' <summary>
        ''' SCHEDULING SERIES
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property SHA04 As Integer
        Property SHA05 As String
        ''' <summary>
        ''' REAL FINISH
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property SHA06 As String
        Property SHA07 As String
        ''' <summary>
        ''' OPERATION LINE
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property SHA08 As String
        ''' <summary>
        ''' CLASS
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property SHA09 As String
        Property SHA10 As String
        Property SHA11 As Double
        Property SHA12 As String
        Property SHA13 As String
        Property SHA14 As Double
        Property SHA15 As Double
        Property SHA16 As Double
        Property SHA17 As Double
        Property SHA18 As Double
        Property SHA19 As Double
        Property SHA20 As Double
        Property SHA21 As Double
        Property SHA22 As Double
        Property SHA23 As Double
        Property SHA24 As Double
        Property SHA25 As Double
        Property SHA26 As String
        ''' <summary>
        ''' NEXT OPERATION LINE
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property SHA27 As String
        Property SHA28 As String
        Property SHA29 As String
        Property SHA30 As String
        Property SHA31 As String
        Property SHA32 As String
        Property SHA33 As String
        Property SHA34 As Double
        Property SHA35 As String
        Property SHA36 As String
        Property SHA37 As String
        Property SHA38 As Double
        ''' <summary>
        ''' PLANNING FINISH
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property SHA39 As String
        ReadOnly Property About_ProcessSchedual As CompanyORMDB.SQLServer.PPS100LB.ProcessSchedual
        ReadOnly Property AboutSL2CICPF As SLS300LB.SL2CICPF
        ReadOnly Property AboutSL2CIDPF As SLS300LB.SL2CIDPF
        ReadOnly Property AboutPPSBLAPF As PPS100LB.PPSBLAPF

        ReadOnly Property PP_ExportJudge As Boolean
    End Interface

End Namespace
