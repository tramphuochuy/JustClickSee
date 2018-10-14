using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace GB
{
    class PictureBoxSpeed : Control
    {
        public PictureBoxSpeed()
        {
            //Set up double buffering and a little extra.
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor,
            true);

          //set the part of the source image to be drawn.
          //DrawRect = DeflateRect(ClientRectangle, Padding);
            DrawRect = ClientRectangle;

      

        }
    

        private Image _Image;

        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;

            }
        }

        private Rectangle DrawRect;


        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (_Image != null)
                {
                    e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    e.Graphics.DrawImage(_Image, ClientRectangle, new Rectangle(0,0,this.Width,this.Height), GraphicsUnit.Pixel);


                }

                base.OnPaint(e);
            }
            catch (Exception ex) { }
        }

      
        

        
    }
}
