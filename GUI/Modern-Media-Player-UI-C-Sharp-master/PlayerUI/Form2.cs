using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PlayerUI
{
    public partial class Form2 : Form
    {
        private bool checkLoadVideo = false;
        public Form2()
        {
            InitializeComponent();
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";

            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBoxPath.Text = open.FileName;
                    videoMadia.URL = open.FileName;
                    videoMadia.Ctlcontrols.pause();

                    //make sound visual and settings to 10
                    controlSound.Value = 10;
                    videoMadia.settings.volume = controlSound.Value;
                    textBoxSoundValue.Text = controlSound.Value + "%";

                    //not saving or play none video
                    checkLoadVideo = true;
                }
                catch (Exception)
                {
                    checkLoadVideo = false;
                    MessageBox.Show("Couldn't open the video");
                }
                
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (checkLoadVideo)
            {
                if (videoMadia.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    videoMadia.Ctlcontrols.pause();
                }
                else
                {
                    videoMadia.Ctlcontrols.play();
                }
            }
        }

        private void controlSound_Scroll_1(object sender, EventArgs e)
        {
            videoMadia.settings.volume = controlSound.Value;
            textBoxSoundValue.Text = controlSound.Value + "%";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            controlSound.Location = new Point(soundPict.Location.X + 40, soundPict.Location.Y);
            textBoxSoundValue.Location = new Point(controlSound.Location.X + 200, controlSound.Location.Y);
               
        }

        private void Form2_Load(object sender, EventArgs e)
        {
      
        }

        private void restartVideBtn_Click(object sender, EventArgs e)
        {
            if (checkLoadVideo)
            {
                videoMadia.Ctlcontrols.stop();
                videoMadia.URL = "";
                videoMadia.URL = textBoxPath.Text;
                videoMadia.Ctlcontrols.play();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkLoadVideo)
            {
                if (!Directory.Exists("videos"))
                    Directory.CreateDirectory(@"videos");

                string destPath = Path.Combine(@"videos\", Path.GetFileName(textBoxPath.Text));

                if (File.Exists(destPath)) // if the video exsist he will delete the first 
                {
                    File.Delete(destPath);
                }

                File.Copy(textBoxPath.Text, destPath);
            }
            else
            {
                MessageBox.Show("You need upload video befor you save :(");
            }
        }
    }
}
