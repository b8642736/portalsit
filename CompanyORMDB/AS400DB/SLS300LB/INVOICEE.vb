Namespace SLS300LB
    Public Class INVOICEE
        Inherits ClassDBAS400

        Sub New()
            MyBase.New("SLS300LB", GetType(INVOICEE).Name, New AS400SQLQueryAdapter(AS400SQLQueryAdapter.ConnectionMoeEnum.ODBC))
        End Sub

#Region "文字 屬性:TEXT"
        Private _TEXT As System.String
        ''' <summary>
        ''' 文字
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TEXT() As System.String
            Get
                Return _TEXT
            End Get
            Set(ByVal value As System.String)
                _TEXT = value
            End Set
        End Property
#End Region


#Region "轉碼為UTF8文字 屬性:TEXTConvertToUTF8Text"
        ReadOnly Property TEXTConvertToUTF8Text() As String
            Get
                Dim OrginStringReader() As Byte = System.Text.Encoding.GetEncoding(950).GetBytes(Me.TEXT)
                Dim Result() As Byte = System.Text.Encoding.Convert(System.Text.Encoding.Default, System.Text.Encoding.UTF8, OrginStringReader)
                Return System.Text.Encoding.UTF8.GetString(Result).Replace("", "銹")
            End Get
        End Property
#End Region

    End Class
End Namespace