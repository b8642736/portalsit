Namespace SLS300LB
Public Class SL2CINPF
	Inherits ClassDBAS400

	Sub New()
		MyBase.New("SLS300LB", GetType(SL2CINPF).Name)
	End Sub

#Region "用途 屬性:CIN01"
	Private _CIN01 As System.String
	''' <summary>
	''' 用途
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	<SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
	Public Property CIN01 () As System.String
		Get
			Return _CIN01
		End Get
		Set(Byval value as System.String)
			_CIN01 = value
		End Set
	End Property
#End Region
#Region "說明 屬性:CIN02"
	Private _CIN02 As System.String
	''' <summary>
	''' 說明
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CIN02 () As System.String
		Get
			Return _CIN02
		End Get
		Set(Byval value as System.String)
			_CIN02 = value
		End Set
	End Property
#End Region
#Region "CODE- 1 屬性:CIN91"
	Private _CIN91 As System.String
	''' <summary>
	''' CODE- 1
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property CIN91 () As System.String
		Get
			Return _CIN91
		End Get
		Set(Byval value as System.String)
			_CIN91 = value
		End Set
	End Property
#End Region

#Region "所有其它要求說明檔資料 屬性:AllSL2CINPFs"
        ''' <summary>
        ''' 所有其它要求說明檔資料
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Shared ReadOnly Property AllSL2CINPFs As List(Of SL2CINPF)
            Get
                Dim QryString As String = "Select * from @#SLS300LB.SL2CH7PF"
                Return CompanyORMDB.SLS300LB.SL2CH7PF.CDBSelect(Of CompanyORMDB.SLS300LB.SL2CINPF)(QryString, AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
            End Get
        End Property
#End Region


        '用途    說明              
        'A      不夾襯紙          
        'B      切頭尾，夾新襯紙  
        'C      加紙套筒          
        'D      內銷包裝          
        'E      切頭尾 8M 不夾襯紙
        'F      不切頭尾，夾襯紙  
        'G      不切頭尾，不夾襯紙
        'H      勿註明厚度        
        'I      包裝前外觀檢驗 CIC
        'J      標註實際厚度      
        'K      標註公稱厚度     
        'L      單面磨2次
        'M      鋼捲片尾接縫處請貼膠帶固定
        'N      鋼捲片尾和襯紙需切齊
        'O      GPL單面2B
        'P      雙面 BA 
        'Q      表面軋花
        'R      用襯紙纏繞或膠帶固定
        'S      夾白襯紙繳庫
        'W  	繳庫線加護角
        'X      外銷包裝  
        'Y      做腐蝕測試
        'Z      煌傑用料
End Class
End Namespace