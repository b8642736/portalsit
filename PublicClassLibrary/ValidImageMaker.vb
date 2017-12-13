Public Class ValidImageMaker
    Sub ValidateCode(ByVal VNum As String)
        ''gheight為圖片寬度,根據字符長度自動更改圖片寬度 
        'Dim GWidth As Integer = Int(System.Text.Encoding.Default.GetBytes(VNum).Length * 11.5)
        ''創建一個寬度已定，高度為20的圖像 
        'Dim Img As System.Drawing.Bitmap = New Bitmap(GWidth, 20)
        'Dim Graphic As Graphics = Graphics.FromImage(Img)
        ''在矩形內繪製字串（字串，字體，畫筆顏色，左上x.左上y） 
        'Graphic.DrawString(VNum, (New Font("細明體", 12)), (New SolidBrush(Color.Blue)), 3, 3)
        'Img.Save(New System.IO.MemoryStream, System.Drawing.Imaging.ImageFormat.Png)
        'Me.PictureBox1.Image = Img

        'Response.ClearContent() '需要輸出圖像信息 要修改HTTP頭 

        'Response.ContentType = "image/Png"

        'Response.BinaryWrite(MS.ToArray())

        'g.Dispose()

        'Img.Dispose()

        'Response.End()

    End Sub
End Class
