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
        }

        private void btnPartScreen_Click(object sender, EventArgs e)
        {
            if (process == null) // ceck if have active process of translate screen
            {
                Thread thr = new Thread( () => pythonThread("5"));
                thr.Start();
            }
        }

        private void fullScreenBtn_Click(object sender, EventArgs e)
        {
            if (process == null) // ceck if have active process of translate screen
            {
                Thread thr = new Thread(() => pythonThread("4"));
                thr.Start();
            }
        }

        private void pythonThread(string code)
        {
   
            string path = @"..\..\..\..\..\AppCode\EasyTranslate.py";
            string parameters = code + " ";
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
