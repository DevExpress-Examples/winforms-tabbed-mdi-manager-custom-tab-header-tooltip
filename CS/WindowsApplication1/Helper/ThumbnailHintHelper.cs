using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.Utils;

namespace WindowsApplication1
{
    public class ThumbnailHintHelper
    {

        private XtraTabbedMdiManager _Manager;
        public ThumbnailHintHelper(XtraTabbedMdiManager manager)
        {
            _Manager = manager;
            manager.MouseMove += new MouseEventHandler(manager_MouseMove);
        }

        void manager_MouseMove(object sender, MouseEventArgs e)
        {
            BaseTabHitInfo hi = _Manager.CalcHitInfo(e.Location);
            if (hi.HitTest == XtraTabHitTest.PageHeader)
                ShowHint(hi.Page);
        }
        private void ShowHint(DevExpress.XtraTab.IXtraTabPage page)
        {
            ToolTipControlInfo toolTip = new ToolTipControlInfo();
            toolTip.ToolTipType = ToolTipType.SuperTip;
            toolTip.Interval = 500;
            toolTip.Object = page;
            SuperToolTip superTip = new SuperToolTip();
            toolTip.SuperTip = superTip;
            superTip.Items.AddTitle(page.Text);
            superTip.Items.AddSeparator();
            ToolTipItem item1 = new ToolTipItem();
            item1.Image = ThumbnailHelper.FormToBitmap((page as XtraMdiTabPage).MdiChild, new Size(200, 200));
            superTip.Items.Add(item1);
            ToolTipController.DefaultController.ShowHint(toolTip);
        }
    }
}
