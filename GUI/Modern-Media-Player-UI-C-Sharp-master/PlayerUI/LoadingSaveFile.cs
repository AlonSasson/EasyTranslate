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
    public partial class LoadingSaveFile : Form
    {
        private bool isImage;
        private Form1 mainForm;
        public LoadingSaveFile(PlayerUI.Form1 form1, bool isImageCheck)
        {
            InitializeComponent();
            mainForm = form1;
            isImage = isImageCheck;

            String[] files = null;

            if (isImage)
            {
                files = Directory.GetFiles("images");
                textBoxTitle.Text = "Image files";
            }
            else
            { 
                files = Directory.GetFiles("videos");
                textBoxTitle.Text = "video files";
            }

            for (int i = 0; i < files.Length; i++)
            {
                Button b = new Button();

                if (isImage)
                    b.Image = Image.FromFile(files[i]);
                else
                {
                    b.Text = Path.GetFileName(files[i]);
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.ForeColor = Color.White;
                    b.BackgroundImageLayout = ImageLayout.Zoom;
                }


                b.Name = files[i];
                b.Size = new Size(148, 148);
                b.Click += new EventHandler(button_Click);


                listOfFile.Controls.Add(b);
            }
            
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (isImage)
            {
                UploadImagesFrom imageForm = new UploadImagesFrom(button.Name);
                
                mainForm.openChildForm(imageForm);
                this.Close();
            }
            else  // it means is a video
            {
                uploadVideForm videForm = new uploadVideForm(button.Name);

                mainForm.openChildForm(videForm);
                this.Close();
            }


        }




    }
}
