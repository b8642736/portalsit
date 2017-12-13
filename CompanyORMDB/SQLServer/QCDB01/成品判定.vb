Namespace SQLServer
	Namespace QCDB01
	Public Class 成品判定
	Inherits ClassDBSQLServer

	Sub New()
                MyBase.New(CompanyORMDB.SQLServerSQLQueryAdapter.ConnectionMoeEnum.ADO, CompanyORMDB.SQLServerSQLQueryAdapter.ConnectServerNameEnum.Server04m, "QCDB01")
	End Sub

#Region "鋼種 屬性:鋼種"
	Private _鋼種 As System.String
	''' <summary>
	''' 鋼種
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property 鋼種() As System.String
                Get
                    Return _鋼種
                End Get
                Set(ByVal value As System.String)
                    _鋼種 = value
                End Set
            End Property
#End Region
#Region "材質 屬性:材質"
	Private _材質 As System.String
	''' <summary>
	''' 材質
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property 材質() As System.String
                Get
                    Return _材質
                End Get
                Set(ByVal value As System.String)
                    _材質 = value
                End Set
            End Property
#End Region
#Region "管制種類 屬性:管制種類"
	Private _管制種類 As System.String
	''' <summary>
	''' 管制種類
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
            <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
            Public Property 管制種類() As System.String
                Get
                    Return _管制種類
                End Get
                Set(ByVal value As System.String)
                    _管制種類 = value
                End Set
            End Property
#End Region
#Region "DF 屬性:DF"
	Private _DF As System.Double
	''' <summary>
	''' DF
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property DF () As System.Double
		Get
			Return _DF
		End Get
		Set(Byval value as System.Double)
			_DF = value
		End Set
	End Property
#End Region
#Region "MD30 屬性:MD30"
	Private _MD30 As System.Double
	''' <summary>
	''' MD30
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MD30 () As System.Double
		Get
			Return _MD30
		End Get
		Set(Byval value as System.Double)
			_MD30 = value
		End Set
	End Property
#End Region
#Region "C 屬性:C"
	Private _C As System.Double
	''' <summary>
	''' C
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property C () As System.Double
		Get
			Return _C
		End Get
		Set(Byval value as System.Double)
			_C = value
		End Set
	End Property
#End Region
#Region "Si 屬性:Si"
	Private _Si As System.Double
	''' <summary>
	''' Si
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Si () As System.Double
		Get
			Return _Si
		End Get
		Set(Byval value as System.Double)
			_Si = value
		End Set
	End Property
#End Region
#Region "Mn 屬性:Mn"
	Private _Mn As System.Double
	''' <summary>
	''' Mn
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Mn () As System.Double
		Get
			Return _Mn
		End Get
		Set(Byval value as System.Double)
			_Mn = value
		End Set
	End Property
#End Region
#Region "P 屬性:P"
	Private _P As System.Double
	''' <summary>
	''' P
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property P () As System.Double
		Get
			Return _P
		End Get
		Set(Byval value as System.Double)
			_P = value
		End Set
	End Property
#End Region
#Region "S 屬性:S"
	Private _S As System.Double
	''' <summary>
	''' S
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property S () As System.Double
		Get
			Return _S
		End Get
		Set(Byval value as System.Double)
			_S = value
		End Set
	End Property
#End Region
#Region "Cr 屬性:Cr"
	Private _Cr As System.Double
	''' <summary>
	''' Cr
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Cr () As System.Double
		Get
			Return _Cr
		End Get
		Set(Byval value as System.Double)
			_Cr = value
		End Set
	End Property
#End Region
#Region "Ni 屬性:Ni"
	Private _Ni As System.Double
	''' <summary>
	''' Ni
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Ni () As System.Double
		Get
			Return _Ni
		End Get
		Set(Byval value as System.Double)
			_Ni = value
		End Set
	End Property
#End Region
#Region "Cu 屬性:Cu"
	Private _Cu As System.Double
	''' <summary>
	''' Cu
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Cu () As System.Double
		Get
			Return _Cu
		End Get
		Set(Byval value as System.Double)
			_Cu = value
		End Set
	End Property
#End Region
#Region "Mo 屬性:Mo"
	Private _Mo As System.Double
	''' <summary>
	''' Mo
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Mo () As System.Double
		Get
			Return _Mo
		End Get
		Set(Byval value as System.Double)
			_Mo = value
		End Set
	End Property
#End Region
#Region "Co 屬性:Co"
	Private _Co As System.Double
	''' <summary>
	''' Co
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Co () As System.Double
		Get
			Return _Co
		End Get
		Set(Byval value as System.Double)
			_Co = value
		End Set
	End Property
#End Region
#Region "AL 屬性:AL"
	Private _AL As System.Double
	''' <summary>
	''' AL
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property AL () As System.Double
		Get
			Return _AL
		End Get
		Set(Byval value as System.Double)
			_AL = value
		End Set
	End Property
#End Region
#Region "Sn 屬性:Sn"
	Private _Sn As System.Double
	''' <summary>
	''' Sn
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Sn () As System.Double
		Get
			Return _Sn
		End Get
		Set(Byval value as System.Double)
			_Sn = value
		End Set
	End Property
#End Region
#Region "Pb 屬性:Pb"
	Private _Pb As System.Double
	''' <summary>
	''' Pb
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Pb () As System.Double
		Get
			Return _Pb
		End Get
		Set(Byval value as System.Double)
			_Pb = value
		End Set
	End Property
#End Region
#Region "Ti 屬性:Ti"
	Private _Ti As System.Double
	''' <summary>
	''' Ti
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Ti () As System.Double
		Get
			Return _Ti
		End Get
		Set(Byval value as System.Double)
			_Ti = value
		End Set
	End Property
#End Region
#Region "Nb 屬性:Nb"
	Private _Nb As System.Double
	''' <summary>
	''' Nb
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Nb () As System.Double
		Get
			Return _Nb
		End Get
		Set(Byval value as System.Double)
			_Nb = value
		End Set
	End Property
#End Region
#Region "V 屬性:V"
	Private _V As System.Double
	''' <summary>
	''' V
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property V () As System.Double
		Get
			Return _V
		End Get
		Set(Byval value as System.Double)
			_V = value
		End Set
	End Property
#End Region
#Region "W 屬性:W"
	Private _W As System.Double
	''' <summary>
	''' W
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property W () As System.Double
		Get
			Return _W
		End Get
		Set(Byval value as System.Double)
			_W = value
		End Set
	End Property
#End Region
#Region "O2 屬性:O2"
	Private _O2 As System.Double
	''' <summary>
	''' O2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property O2 () As System.Double
		Get
			Return _O2
		End Get
		Set(Byval value as System.Double)
			_O2 = value
		End Set
	End Property
#End Region
#Region "N2 屬性:N2"
	Private _N2 As System.Double
	''' <summary>
	''' N2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property N2 () As System.Double
		Get
			Return _N2
		End Get
		Set(Byval value as System.Double)
			_N2 = value
		End Set
	End Property
#End Region
#Region "H2 屬性:H2"
	Private _H2 As System.Double
	''' <summary>
	''' H2
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property H2 () As System.Double
		Get
			Return _H2
		End Get
		Set(Byval value as System.Double)
			_H2 = value
		End Set
	End Property
#End Region
#Region "B 屬性:B"
	Private _B As System.Double
	''' <summary>
	''' B
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property B () As System.Double
		Get
			Return _B
		End Get
		Set(Byval value as System.Double)
			_B = value
		End Set
	End Property
#End Region
#Region "Ca 屬性:Ca"
	Private _Ca As System.Double
	''' <summary>
	''' Ca
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Ca () As System.Double
		Get
			Return _Ca
		End Get
		Set(Byval value as System.Double)
			_Ca = value
		End Set
	End Property
#End Region
#Region "Mg 屬性:Mg"
	Private _Mg As System.Double
	''' <summary>
	''' Mg
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Mg () As System.Double
		Get
			Return _Mg
		End Get
		Set(Byval value as System.Double)
			_Mg = value
		End Set
	End Property
#End Region
#Region "Fe 屬性:Fe"
	Private _Fe As System.Double
	''' <summary>
	''' Fe
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Fe () As System.Double
		Get
			Return _Fe
		End Get
		Set(Byval value as System.Double)
			_Fe = value
		End Set
	End Property
#End Region
#Region "碳加氮 屬性:CAndN"
            Private _CAndN As System.Double
            ''' <summary>
            ''' CAndN
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property CAndN() As System.Double
                Get
                    Return _CAndN
                End Get
                Set(ByVal value As System.Double)
                    _CAndN = value
                End Set
            End Property
#End Region
#Region "As 屬性:As"
            Private _As As System.Double
            ''' <summary>
            ''' As
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property [As]() As System.Double
                Get
                    Return _As
                End Get
                Set(ByVal value As System.Double)
                    _As = value
                End Set
            End Property
#End Region
#Region "Bi 屬性:Bi"
            Private _Bi As System.Double
            ''' <summary>
            ''' Bi
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Bi() As System.Double
                Get
                    Return _Bi
                End Get
                Set(ByVal value As System.Double)
                    _Bi = value
                End Set
            End Property
#End Region
#Region "Sb 屬性:Sb"
            Private _Sb As System.Double
            ''' <summary>
            ''' Sb
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Sb() As System.Double
                Get
                    Return _Sb
                End Get
                Set(ByVal value As System.Double)
                    _Sb = value
                End Set
            End Property
#End Region
#Region "Zn 屬性:Zn"
            Private _Zn As System.Double
            ''' <summary>
            ''' Zn
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Zn() As System.Double
                Get
                    Return _Zn
                End Get
                Set(ByVal value As System.Double)
                    _Zn = value
                End Set
            End Property
#End Region
#Region "Zr 屬性:Zr"
            Private _Zr As System.Double
            ''' <summary>
            ''' Zr
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Zr() As System.Double
                Get
                    Return _Zr
                End Get
                Set(ByVal value As System.Double)
                    _Zr = value
                End Set
            End Property
#End Region
#Region "GP 屬性:GP"
            Private _GP As System.Double
            ''' <summary>
            ''' GP
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property GP() As System.Double
                Get
                    Return _GP
                End Get
                Set(ByVal value As System.Double)
                    _GP = value
                End Set
            End Property
#End Region
#Region "Ta 屬性:Ta"
            Private _Ta As System.Double
            ''' <summary>
            ''' Ta
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Ta() As System.Double
                Get
                    Return _Ta
                End Get
                Set(ByVal value As System.Double)
                    _Ta = value
                End Set
            End Property
#End Region
#Region "NbAndTa 屬性:NbAndTa"
            Private _NbAndTa As System.Double
            ''' <summary>
            ''' NbAndTa
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property NbAndTa() As System.Double
                Get
                    Return _NbAndTa
                End Get
                Set(ByVal value As System.Double)
                    _NbAndTa = value
                End Set
            End Property
#End Region
#Region "Ag 屬性:Ag"
            Private _Ag As System.Double
            ''' <summary>
            ''' Ag
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property Ag() As System.Double
                Get
                    Return _Ag
                End Get
                Set(ByVal value As System.Double)
                    _Ag = value
                End Set
            End Property
#End Region

        End Class
	End Namespace
End Namespace