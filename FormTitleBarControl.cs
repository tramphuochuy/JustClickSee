using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GB
{
    public partial class FormTitleBarControl : UserControl
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormTitleBarControl()
        {


            InitializeComponent();

        }

        private void pbTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((e.Clicks == 1) && (this.ParentForm.WindowState != FormWindowState.Maximized))
                {
                    ReleaseCapture();
                    SendMessage(this.ParentForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        private void Caption_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((e.Clicks == 1) && (this.ParentForm.WindowState != FormWindowState.Maximized))
                {
                    ReleaseCapture();
                    SendMessage(this.ParentForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets the font of the title")]
        public Font TitleFont
        {
            set
            {
                lblTitle.Font = value;
            }
            get
            {
                return lblTitle.Font;
            }
        }
        [Category("Appearance")]
        [Description("Gets or sets the title of the title bar")]
        public string Title
        {
            set
            {
                lblTitle.Text = value;
            }
            get
            {
                return lblTitle.Text;
            }
        }
        [Category("Appearance")]
        [Description("Gets or sets the title text color")]
        public Color TitleForeColor
        {
            set
            {
                lblTitle.ForeColor = value;
            }
            get
            {
                return lblTitle.ForeColor;
            }
        }
        [Category("Appearance")]
        [Description("Gets or sets the title background color")]
        public Color TitleBackColor
        {
            set
            {
                lblTitle.BackColor = value;
            }
            get
            {
                return lblTitle.BackColor;
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets maximize button visibility")]
        public bool Maximize
        {
            set
            {
                frmControlBox.Maximize = value;
            }
            get
            {
                return frmControlBox.Maximize;
            }
        }
        [Category("Appearance")]
        [Description("Gets or sets minimize button visibility")]
        public bool Minimize
        {
            set
            {
                frmControlBox.Minimize = value;
            }
            get
            {
                return frmControlBox.Minimize;
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets close button visibility")]
        public bool Close
        {
            set
            {
                frmControlBox.Close = value;
            }
            get
            {
                return frmControlBox.Close;
            }
        }

        private void pbTitle_Click(object sender, EventArgs e)
        {

        }

        private void pbTitle_DoubleClick(object sender, EventArgs e)
        {
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }

        private void pbTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (frmControlBox.Maximize)
            {
                if (this.ParentForm.WindowState == FormWindowState.Maximized)
                {
                    this.ParentForm.WindowState = FormWindowState.Normal;
                    this.ParentForm.Show();
                }
                else if (this.ParentForm.WindowState == FormWindowState.Normal)
                {
                    this.ParentForm.WindowState = FormWindowState.Maximized;
                    this.ParentForm.Show();
                }
            }
        }

        private void lblTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void lblTitle_MouseUp(object sender, MouseEventArgs e)
        {
        }
    }
}
