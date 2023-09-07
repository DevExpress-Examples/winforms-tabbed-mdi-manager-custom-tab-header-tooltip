Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace WindowsApplication1

    Public Module ThumbnailHelper

        Public Function FormToBitmap(ByVal form As Control, ByVal size As Size) As Image
            Dim formSize As Size = form.Size
            Dim rect As Rectangle = New Rectangle(New Point(0, 0), formSize)
            Dim bitmap As Bitmap = New Bitmap(formSize.Width, formSize.Height)
            form.DrawToBitmap(bitmap, rect)
            Dim result As Bitmap = New Bitmap(size.Width, size.Height)
            Dim g As Graphics = Graphics.FromImage(result)
            rect.Size = size
            g.DrawImage(bitmap, rect)
            Return result
        End Function
    End Module
End Namespace
