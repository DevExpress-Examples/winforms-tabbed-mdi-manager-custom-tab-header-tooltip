Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace WindowsApplication1

    Public Partial Class Form1
        Inherits Form

        Private r As Random = New Random()

        Private Function GetRandomColor() As Color
            Return Color.FromArgb(r.Next(255), r.Next(255), r.Next(255))
        End Function

        Public Sub New()
            InitializeComponent()
            For i As Integer = 0 To 10 - 1
                Dim form As Form = New Form()
                form.MdiParent = Me
                form.Show()
                form.BackColor = GetRandomColor()
                form.Text = String.Format("Form{0}", i)
                Dim button As SimpleButton = New SimpleButton()
                button.Location = New Point(button.Width * i, button.Height * i)
                button.Text = String.Format("Button{0}", i)
                form.Controls.Add(button)
                Dim dataGridView As DataGridView = New DataGridView()
                dataGridView.Dock = DockStyle.Bottom
                form.Controls.Add(dataGridView)
                form.Size = New Size(600, 600)
            Next

            Dim tmp_ThumbnailHintHelper = New ThumbnailHintHelper(xtraTabbedMdiManager1)
        End Sub
    End Class
End Namespace
