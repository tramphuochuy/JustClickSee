using System;
using System.Collections.Generic;
 
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GB
{
    [System.ComponentModel.DesignerCategory("Code")]
    public class ColorPanelFlow : FlowLayoutPanel
    {
        public int isColor = 1;
       

        public int HisColor
        {
            get { return isColor; }
            set { isColor = value; }
        }

        public ColorPanelFlow()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (HisColor == 1)
            {
                using (SolidBrush brush = new SolidBrush(BackColor))
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                e.Graphics.DrawRectangle(Pens.LightBlue, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }

            if (HisColor == 2)
            {
                using (SolidBrush brush = new SolidBrush(BackColor))
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                e.Graphics.DrawRectangle(Pens.LightBlue, 0, 0, ClientSize.Width - 1, ClientSize.Height);
            }

            if (HisColor == 3)
            {
                using (SolidBrush brush = new SolidBrush(BackColor))
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                e.Graphics.DrawRectangle(Pens.LightBlue, 0, -1, ClientSize.Width - 1, ClientSize.Height - 1);
            }

            if (HisColor == 4)
            {
                using (SolidBrush brush = new SolidBrush(BackColor))
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                e.Graphics.DrawRectangle(Pens.LightBlue, 0, -1, ClientSize.Width - 1 , ClientSize.Height + 1 );
            }

            if (HisColor == 5)
            {
                using (SolidBrush brush = new SolidBrush(BackColor))
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                e.Graphics.DrawRectangle(Pens.LightBlue, 1, -1, ClientSize.Width + 1, ClientSize.Height + 1);
            }
        }

    }
}
