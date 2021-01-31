using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class uploadVide : Form
    {
        public uploadVide()
        {
            InitializeComponent();
        }

        private void upLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Video Files(*.avi; *.mp4;)";

            if (open.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = open.FileName;
            }


        }
    }
}
