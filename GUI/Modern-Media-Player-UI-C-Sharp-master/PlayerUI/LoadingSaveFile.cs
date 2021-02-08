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
        PlayerUI.UploadVideForm uploadVideForm = null;
        PlayerUI.UploadImagesFrom uploadImagesFrom = null;

        public LoadingSaveFile(PlayerUI.Form1 form1, bool isImageCheck, PlayerUI.UploadVideForm videoChildForm)
        {
            InitializeComponent();
            initailzeList(form1, isImageCheck);
            uploadVideForm = videoChildForm;
        }

        public LoadingSaveFile(PlayerUI.Form1 form1, bool isImageCheck, PlayerUI.UploadImagesFrom imageChildForm)
        {
            InitializeComponent();
            initailzeList(form1, isImageCheck);
            uploadImagesFrom = imageChildForm;
        }

        private void initailzeList(PlayerUI.Form1 form1, bool isImageCheck)
        {
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
                {
                    b.BackgroundImage = Image.FromFile(files[i]);
                }
                else // video
                {
                    b.Text = Path.GetFileName(files[i]);
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.ForeColor = Color.White;

                }

                b.Size = new Size(148, 148);
                b.Name = files[i];
                b.BackgroundImageLayout = ImageLayout.Zoom;
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
                uploadImagesFrom.setImage(button.Name);

                mainForm.openChildForm(uploadImagesFrom);
                this.Hide();
            }
            else  // it means is a video
            {
                uploadVideForm.setVideo(button.Name);

                mainForm.openChildForm(uploadVideForm);
                this.Hide();
            }
        }




    }
}
