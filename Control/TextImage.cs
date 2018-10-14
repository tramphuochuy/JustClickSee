using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public partial class TextImage : UserControl
    {
     
        public string HText
        {
            get { return edtText.Text; }
            set { edtText.Text = value; }
        }

        public TextImage()
        {
            InitializeComponent();
        }
        
        
        

       
    }
}
