Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTabbedMdi

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Private r As New Random()
		Private Function GetRandomColor() As Color
			Return Color.FromArgb(r.Next(255), r.Next(255), r.Next(255))
		End Function

		Public Sub New()
			InitializeComponent()
			For i As Integer = 0 To 9
				Dim form As New Form()
				form.MdiParent = Me
				form.Show()
				form.BackColor = GetRandomColor()
				form.Text = String.Format("Form{0}", i)
				Dim button As New SimpleButton()
				button.Location = New Point(button.Width * i, button.Height * i)
				button.Text = String.Format("Button{0}", i)
				form.Controls.Add(button)
				Dim dataGridView As New DataGridView()
				dataGridView.Dock = DockStyle.Bottom
				form.Controls.Add(dataGridView)
				form.Size = New Size(600, 600)
			Next i
			Dim TempThumbnailHintHelper As ThumbnailHintHelper = New ThumbnailHintHelper(xtraTabbedMdiManager1)
		End Sub
	End Class
End Namespace