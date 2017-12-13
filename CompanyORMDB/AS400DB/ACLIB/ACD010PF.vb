Namespace ACLIB
Public Class ACD010PF
	Inherits ClassDBAS400

	Sub New()
            MyBase.New("ACLIB", GetType(ACD010PF).Name)
        End Sub

#Region "費用單位代號 屬性:DEPTNO"
        Private _DEPTNO As System.String
        ''' <summary>
        ''' 費用單位代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DEPTNO() As System.String
            Get
                Return _DEPTNO
            End Get
            Set(ByVal value As System.String)
                _DEPTNO = value
            End Set
        End Property
#End Region
#Region "傳票編者 屬性:EDITER"
        Private _EDITER As System.String
        ''' <summary>
        ''' 傳票編者
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property EDITER() As System.String
            Get
                Return _EDITER
            End Get
            Set(ByVal value As System.String)
                _EDITER = value
            End Set
        End Property
#End Region
#Region "編票日期 屬性:SHTDAT"
        Private _SHTDAT As System.Int32
        ''' <summary>
        ''' 編票日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHTDAT() As System.Int32
            Get
                Return _SHTDAT
            End Get
            Set(ByVal value As System.Int32)
                _SHTDAT = value
            End Set
        End Property
#End Region
#Region "傳票編號 屬性:SHTNO1"
        Private _SHTNO1 As System.String
        ''' <summary>
        ''' 傳票編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SHTNO1() As System.String
            Get
                Return _SHTNO1
            End Get
            Set(ByVal value As System.String)
                _SHTNO1 = value
            End Set
        End Property
#End Region
#Region "入帳日期 屬性:ACTDAT"
        Private _ACTDAT As System.Int32
        ''' <summary>
        ''' 入帳日期
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACTDAT() As System.Int32
            Get
                Return _ACTDAT
            End Get
            Set(ByVal value As System.Int32)
                _ACTDAT = value
            End Set
        End Property
#End Region
#Region "入帳編號 屬性:ENTNO1"
        Private _ENTNO1 As System.Int32
        ''' <summary>
        ''' 入帳編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ENTNO1() As System.Int32
            Get
                Return _ENTNO1
            End Get
            Set(ByVal value As System.Int32)
                _ENTNO1 = value
            End Set
        End Property
#End Region
#Region "案据名稱 屬性:FROMNM"
        Private _FROMNM As System.String
        ''' <summary>
        ''' 案据名稱
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FROMNM() As System.String
            Get
                Return _FROMNM
            End Get
            Set(ByVal value As System.String)
                _FROMNM = value
            End Set
        End Property
#End Region
#Region "案据憑單數 屬性:FROMST"
        Private _FROMST As System.Int32
        ''' <summary>
        ''' 案据憑單數
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FROMST() As System.Int32
            Get
                Return _FROMST
            End Get
            Set(ByVal value As System.Int32)
                _FROMST = value
            End Set
        End Property
#End Region
#Region "單項代號 屬性:ITEMNO"
        Private _ITEMNO As System.Int32
        ''' <summary>
        ''' 單項代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ITEMNO() As System.Int32
            Get
                Return _ITEMNO
            End Get
            Set(ByVal value As System.Int32)
                _ITEMNO = value
            End Set
        End Property
#End Region
#Region "會計科目代號 屬性:ACCTNO"
        Private _ACCTNO As System.String
        ''' <summary>
        ''' 會計科目代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ACCTNO() As System.String
            Get
                Return _ACCTNO
            End Get
            Set(ByVal value As System.String)
                _ACCTNO = value
            End Set
        End Property
#End Region
#Region "明細科目代號 屬性:DETLNO"
        Private _DETLNO As System.String
        ''' <summary>
        ''' 明細科目代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DETLNO() As System.String
            Get
                Return _DETLNO
            End Get
            Set(ByVal value As System.String)
                _DETLNO = value
            End Set
        End Property
#End Region
#Region "摘要 屬性:REMARK"
        Private _REMARK As System.String
        ''' <summary>
        ''' 摘要
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property REMARK() As System.String
            Get
                Return _REMARK
            End Get
            Set(ByVal value As System.String)
                _REMARK = value
            End Set
        End Property
#End Region
#Region "工程或承訂編號 屬性:WORKNO"
        Private _WORKNO As System.String
        ''' <summary>
        ''' 工程或承訂編號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WORKNO() As System.String
            Get
                Return _WORKNO
            End Get
            Set(ByVal value As System.String)
                _WORKNO = value
            End Set
        End Property
#End Region
#Region "成本類別 屬性:WORKCL"
        Private _WORKCL As System.String
        ''' <summary>
        ''' 成本類別
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WORKCL() As System.String
            Get
                Return _WORKCL
            End Get
            Set(ByVal value As System.String)
                _WORKCL = value
            End Set
        End Property
#End Region
#Region "往來代號 屬性:TFDEPT"
        Private _TFDEPT As System.String
        ''' <summary>
        ''' 往來代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TFDEPT() As System.String
            Get
                Return _TFDEPT
            End Get
            Set(ByVal value As System.String)
                _TFDEPT = value
            End Set
        End Property
#End Region
#Region "受款人代號 屬性:SALENO"
        Private _SALENO As System.String
        ''' <summary>
        ''' 受款人代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SALENO() As System.String
            Get
                Return _SALENO
            End Get
            Set(ByVal value As System.String)
                _SALENO = value
            End Set
        End Property
#End Region
#Region "借貸表示 屬性:DBORCR"
        Private _DBORCR As System.String
        ''' <summary>
        ''' 借貸表示
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DBORCR() As System.String
            Get
                Return _DBORCR
            End Get
            Set(ByVal value As System.String)
                _DBORCR = value
            End Set
        End Property
#End Region
#Region "借貸減項 屬性:MINUS1"
        Private _MINUS1 As System.String
        ''' <summary>
        ''' 借貸減項
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MINUS1() As System.String
            Get
                Return _MINUS1
            End Get
            Set(ByVal value As System.String)
                _MINUS1 = value
            End Set
        End Property
#End Region
#Region "金額 屬性:AMOUNT"
        Private _AMOUNT As Double
        ''' <summary>
        ''' 金額
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AMOUNT() As Double
            Get
                Return _AMOUNT
            End Get
            Set(ByVal value As Double)
                _AMOUNT = value
            End Set
        End Property
#End Region

#Region "會計科目中文名稱 屬性:ACCTNOName"
        ''' <summary>
        ''' 會計科目中文名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property ACCTNOName As String
            Get
                If IsNothing(Me.AboutACA010PF) Then
                    Return Nothing
                End If
                Return Me.AboutACA010PF.ACCTNM
            End Get
        End Property
#End Region
#Region "會計明細科目中文名稱 屬性:DETLNOName"
        ''' <summary>
        ''' 會計明細科目中文名稱
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property DETLNOName As String
            Get
                If IsNothing(Me.AboutACA020PF) Then
                    Return Nothing
                End If
                Return Me.AboutACA020PF.DETLNM
            End Get
        End Property
#End Region


#Region "是否為固定金額 屬性:IsFixMoney"
        ''' <summary>
        ''' 是否為固定金額
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property IsFixMoney As Boolean
            Get
                Dim myAboutACJ050PF As ACJ050PF = Me.AboutACJ050PF
                Select Case True
                    Case IsNothing(AboutACJ050PF)
                        For Each EachItem In ACJ050PF.AllACJ050PFs(Me.ACTDAT \ 10000, Me.CDBMemberName)
                            If EachItem.ACCTNO = Me.ACCTNO.Substring(0, 4) Then
                                Return True     '有會計科目,但無明細科目列為變動金額
                            End If
                        Next
                        Throw New Exception("相關費用類預算檔ACJ050PF 為Nothing! ACCTNO=" & ACCTNO & "  DETLNO=" & DETLNO)
                    Case AboutACJ050PF.BDGFIX > 0 AndAlso AboutACJ050PF.BDGVAR = 0
                        Return True
                    Case AboutACJ050PF.BDGFIX = 0 AndAlso AboutACJ050PF.BDGVAR > 0
                        Return False
                    Case AboutACJ050PF.BDGFIX = 0 AndAlso AboutACJ050PF.BDGVAR = 0
                        Return False
                    Case Else
                        Return Me.REMARK.Contains("&F")
                End Select

            End Get
        End Property
#End Region
#Region "相關費用類預算檔 屬性:AboutACJ050PF"
        Private _AboutACJ050PF As ACJ050PF = Nothing
        ''' <summary>
        ''' 相關費用類預算檔
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Public Property AboutACJ050PF() As ACJ050PF
            Get
                If IsNothing(_AboutACJ050PF) Then
                    For Each EachItem In ACJ050PF.AllACJ050PFs(Me.ACTDAT \ 10000, Me.CDBMemberName)
                        If EachItem.ACCTNO = Me.ACCTNO.Substring(0, 4) AndAlso EachItem.DETLNO = Me.DETLNO.Substring(0, 4) Then
                            _AboutACJ050PF = EachItem : Exit For
                        End If
                    Next
                End If
                Return _AboutACJ050PF
            End Get
            Private Set(ByVal value As ACJ050PF)
                _AboutACJ050PF = value
            End Set
        End Property

#End Region
#Region "相關會計科目代號檔 屬性:AboutACA010PF"
        Private _AboutACA010PF As ACA010PF = Nothing
        ''' <summary>
        ''' 相關會計科目代號檔
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutACA010PF As ACA010PF
            Get
                If IsNothing(_AboutACA010PF) Then
                    For Each EachItem As ACA010PF In ACA010PF.AllACA010PFs
                        If EachItem.ACCTNO = Me.ACCTNO.Substring(0, 4) Then
                            _AboutACA010PF = EachItem : Exit For
                        End If
                    Next
                End If
                Return _AboutACA010PF
            End Get
        End Property
#End Region
#Region "相關費用明細科目代號檔 屬性:AboutACA020PF"
        Private _AboutACA020PF As ACA020PF = Nothing
        ''' <summary>
        ''' 相關費用明細科目代號檔
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        ReadOnly Property AboutACA020PF As ACA020PF
            Get
                If IsNothing(_AboutACA020PF) Then
                    For Each EachItem As ACA020PF In ACA020PF.AllACA020PFs
                        If EachItem.DETLNO = Me.DETLNO Then
                            _AboutACA020PF = EachItem : Exit For
                        End If
                    Next
                End If
                Return _AboutACA020PF

            End Get
        End Property
#End Region


End Class
End Namespace