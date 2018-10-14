using System;
using System.Collections.Generic;
 
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GB.Properties;
using System.Reflection;
using System.ComponentModel;

namespace GB
{
  
    public class lbButton3 : Label
    {
        public int Init = 0;

        public int isColor = 0;

        public bool isBorder = true;

        public bool HisBorder
        {
            get { return isBorder; }
            set { isBorder = value; }
        }

        public bool AllowDisable = false;
        public bool HAllowDisable
        {
            get { return AllowDisable; }
            set { AllowDisable = value; }
        }

        public bool isDisable = false;

        public bool HisDisable
        {
            get { return isDisable; }
            set { isDisable = value; }
        }

        public string ResourceImage = "";
        public string HResourceImage
        {
            get { return ResourceImage; }
            set { ResourceImage = value; }
        }

        public bool isClickChange = true;

        public bool HisClickChange
        {
            get { return isClickChange; }
            set { isClickChange = value; }
        }

        public lbButton3()
        {

            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UseCompatibleTextRendering = true;
            AutoEllipsis = true;
            AutoSize = false;
            //Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            BackColor = Color.SkyBlue;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = Color.Transparent;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Init == 0)
            {
                Init = 1;
                if (AllowDisable)
                {
                    if (isDisable) Image = (Image)Resources.ResourceManager.GetObject(ResourceImage + "_dis");
                    else Image = (Image)Resources.ResourceManager.GetObject(ResourceImage);
                }
                //else Image = Resources.Music_48_dis;
            }
            if (isColor == 1 && isBorder)
            {
                e.Graphics.DrawRectangle(Pens.LightBlue, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }
         
        }
        protected override void OnClick(EventArgs e)
        {
           
            this.CreateGraphics().DrawRectangle(Pens.White, ClientRectangle);
            //if ( isBorder) System.Threading.Thread.Sleep(15);
            if (AllowDisable && isClickChange)
            {
                isDisable = isDisable == true ? false : true;
                if (isDisable ) Image = (Image)Resources.ResourceManager.GetObject(ResourceImage+ "_dis"); 
                else Image = (Image)Resources.ResourceManager.GetObject(ResourceImage); 
            }
            
            base.OnClick(e);
            Refresh();

      }

       public void ResetStatus(bool isdisable )
       {
           isDisable = isdisable;
           Init = 0;
           Refresh();
       }
    }
}
