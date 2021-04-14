using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;


namespace PlayerUI
{
    public partial class ScreenTranslate : Form
    {
        private Process process;
        public ScreenTranslate()
        {
            process = null;
            InitializeComponent();

            //set the default function and language for translation
            choseFunction.SelectedIndex = 0;
            destLanguageBox.Text = "hebrew";
        }

        private void btnPartScreen_Click(object sender, EventArgs e)
        {
            if (process == null) // ceck if have active process of translate screen
            {
                string codeFunction = choseFunction.Text;
                string destLanguage = destLanguageBox.Text;
                Thread thr = new Thread( () => PythonThread("part_of_screen", codeFunction, destLanguage));
                thr.Start();
            }
        }

        private void fullScreenBtn_Click(object sender, EventArgs e)
        {
            if (process == null) // ceck if have active process of translate screen
            {
                string codeFunction = choseFunction.Text;
                string destLanguage = destLanguageBox.Text;
                Thread thr = new Thread(() => PythonThread("screen", codeFunction, destLanguage));
                thr.Start();
            }
        }

        private void PythonThread(string platform, string code, string destLanguage)
        {
   
            string path = @"..\..\..\..\AppCode\EasyTranslate.py";
            string parameters = platform + " " + code + " " + destLanguage + " ";
            process = PlayerUI.PythonRun.run_cmd(path, parameters);
        }

        private void btnStopTranslate_Click(object sender, EventArgs e)
        {
            if (process != null) // check if have process active
            {
                try
                {
                    process.Kill();
                }
                catch (Exception)
                {}

                process = null;
            }
        }
    }
}
