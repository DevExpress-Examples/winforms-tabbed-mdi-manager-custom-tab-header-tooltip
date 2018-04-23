Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace WindowsApplication1
	Public NotInheritable Class ThumbnailHelper

		Private Sub New()
		End Sub
		Public Shared Function FormToBitmap(ByVal form As Control, ByVal size As Size) As Image
			Dim formSize As Size = form.Size
			Dim rect As New Rectangle(New Point(0, 0), formSize)
			Dim bitmap As New Bitmap(formSize.Width, formSize.Height)
			form.DrawToBitmap(bitmap, rect)
			Dim result As New Bitmap(size.Width, size.Height)
			Dim g As Graphics = Graphics.FromImage(result)
			rect.Size = size
			g.DrawImage(bitmap, rect)
			Return result
		End Function
	End Class
End Namespace
