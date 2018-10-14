using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.Cloud.Speech.V1;
using System.Threading.Tasks;

namespace GB
{
    public partial class SpeechToText : Form
    {
        public SpeechToText()
        {
            InitializeComponent();
        }

        private void btnSTart_Click(object sender, EventArgs e)
        {
            var speech = SpeechClient.Create();
            var config = new RecognitionConfig
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
                SampleRateHertz = 16000,
                LanguageCode = LanguageCodes.English.UnitedStates
            };
            var audio = RecognitionAudio.FromStorageUri("gs://cloud-samples-tests/speech/brooklyn.flac");

            var response = speech.Recognize(config, audio);

            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
        }

     
    }
}
