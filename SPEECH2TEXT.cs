using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GB
{
    public partial class SPEECH2TEXT : Form
    {
        Image OriImage = null;
        public string LastStatus = "";
        public SPEECH2TEXT()
        {
            InitializeComponent();
            OriImage = edtPic.Image;
        }

        public string R = "";

        private void SPEECH2TEXT_Click(object sender, EventArgs e)
        {
            if (DBase.SPEECH_STATUS == "PAUSE" || DBase.SPEECH_STATUS == "")
            {
                LastChangeTime = DateTime.Now;
                StartTime = DateTime.Now;
                CountAddState = 0;
                Recognize.StreamingMicRecognizeAsync(60);
            }
            else
            {

                DBase.SPEECH_STATUS = "STOP";
            }

        }

        public string LastR = "";
        public DateTime LastChangeTime = DateTime.Now;
        public DateTime StartTime = DateTime.Now;
        public int CountAddState = 0;
        private void timerAction_Tick(object sender, EventArgs e)
        {
            edtTimeInfo.Text =   DBase.Int2Time(DBase.IntReturn( (DateTime.Now - StartTime).TotalSeconds));
            if (DBase.SPEECH_STATUS == "ON" && DBase.SPEECH_STATUS != LastStatus)
            {
                LastStatus = DBase.SPEECH_STATUS;
                edtPic.Image = Properties.Resources.Loading;
            }
            else if (DBase.SPEECH_STATUS == "PAUSE" &&  DBase.SPEECH_STATUS != LastStatus )
            {
                LastStatus = DBase.SPEECH_STATUS;
                edtPic.Image = OriImage;
                SPEECH2TEXT_Click(null, null);
            }
            if (DBase.SR != LastR)
            {
                if( (DateTime.Now - LastChangeTime).TotalSeconds > 1.4 ) // Add to Result
                {
                    CountAddState = CountAddState + 1;
                    this.Text = "Added State "  + CountAddState;
                    edtResult.Text = edtResult.Text + Environment.NewLine + LastR;
                }
                LastR = DBase.SR;
                LastChangeTime = DateTime.Now;
                edtText.Text = LastR;
            }
        }
    }
}
