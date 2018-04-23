using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Color GetRandomColor()
        {
            return Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
        }

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                Form form = new Form();
                form.MdiParent = this;
                form.Show();
                form.BackColor = GetRandomColor();
                form.Text = String.Format("Form{0}", i);
                SimpleButton button = new SimpleButton();
                button.Location = new Point(button.Width * i, button.Height * i);
                button.Text = String.Format("Button{0}", i);
                form.Controls.Add(button);
                DataGridView dataGridView = new DataGridView();
                dataGridView.Dock = DockStyle.Bottom;
                form.Controls.Add(dataGridView);
                form.Size = new Size(600, 600);
            }
            new ThumbnailHintHelper(xtraTabbedMdiManager1);
        }
    }
}