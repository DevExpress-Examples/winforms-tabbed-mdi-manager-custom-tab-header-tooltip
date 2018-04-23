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
Imports DevExpress.XtraTab.ViewInfo
Imports DevExpress.Utils

Namespace WindowsApplication1
	Public Class ThumbnailHintHelper

		Private _Manager As XtraTabbedMdiManager
		Public Sub New(ByVal manager As XtraTabbedMdiManager)
			_Manager = manager
			AddHandler manager.MouseMove, AddressOf manager_MouseMove
		End Sub

		Private Sub manager_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim hi As BaseTabHitInfo = _Manager.CalcHitInfo(e.Location)
			If hi.HitTest = XtraTabHitTest.PageHeader Then
				ShowHint(hi.Page)
			End If
		End Sub
		Private Sub ShowHint(ByVal page As DevExpress.XtraTab.IXtraTabPage)
			Dim toolTip As New ToolTipControlInfo()
			toolTip.ToolTipType = ToolTipType.SuperTip
			toolTip.Interval = 500
			toolTip.Object = page
			Dim superTip As New SuperToolTip()
			toolTip.SuperTip = superTip
			superTip.Items.AddTitle(page.Text)
			superTip.Items.AddSeparator()
			Dim item1 As New ToolTipItem()
			item1.Image = ThumbnailHelper.FormToBitmap((TryCast(page, XtraMdiTabPage)).MdiChild, New Size(200, 200))
			superTip.Items.Add(item1)
			ToolTipController.DefaultController.ShowHint(toolTip)
		End Sub
	End Class
End Namespace
