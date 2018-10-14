using System;
using System.Collections.Generic;
 
using System.Text;
using System.Windows.Forms;

namespace GB
{
    public class TextboxWarp : TextBox
    {

        protected override void OnTextChanged(EventArgs e)
        {
            const int padding = 3;
            int numLines = GetLineFromCharIndex(TextLength) + 1;
            int border = Height - ClientSize.Height;
            Height = Font.Height * numLines + padding + border;
            base.OnTextChanged(e);
        }
    }
}
