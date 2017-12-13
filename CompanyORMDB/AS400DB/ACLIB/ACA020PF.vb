Namespace ACLIB
    ''' <summary>
    ''' 費用明細科目代號檔
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ACA020PF
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("ACLIB", GetType(ACA020PF).Name)
        End Sub

#Region "明細科目代號 屬性:DETLNO"
        Private _DETLNO As System.String
        ''' <summary>
        ''' 明細科目代號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.FieldAndPrimaryKey)> _
        Public Property DETLNO() As System.String
            Get
                Return _DETLNO
            End Get
            Set(ByVal value As System.String)
                _DETLNO = value
            End Set
        End Property
#End Region
#Region "明細科目名稱 屬性:DETLNM"
        Private _DETLNM As System.String
        ''' <summary>
        ''' 明細科目名稱
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DETLNM() As System.String
            Get
                Return _DETLNM
            End Get
            Set(ByVal value As System.String)
                _DETLNM = value
            End Set
        End Property
#End Region

#Region "所有費用明細科目代號檔 屬性:AllACA020PFs"
        Private Shared _AllACA020PFs As List(Of ACA020PF) = Nothing
        ''' <summary>
        ''' 所有費用明細科目代號檔
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <SetCDBField(SetCDBFieldAttribute.FieldTypeEnum.NotField)> _
        Shared ReadOnly Property AllACA020PFs As List(Of ACA020PF)
            Get
                Static LastGetDataTime As DateTime = Now
                If Now.Subtract(LastGetDataTime).Seconds > 3 Then
                    _AllACA020PFs = Nothing
                End If
                If IsNothing(_AllACA020PFs) Then
                    _AllACA020PFs = ACA020PF.CDBSelect(Of ACA020PF)("Select * From @#ACLIB.ACA020PF Order by DETLNO ", CompanyORMDB.AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC)
                End If
                LastGetDataTime = Now
                Return _AllACA020PFs
            End Get
        End Property
#End Region

    End Class
End Namespace