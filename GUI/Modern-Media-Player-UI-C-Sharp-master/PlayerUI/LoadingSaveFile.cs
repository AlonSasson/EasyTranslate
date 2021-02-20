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

            mainForm = form1;
            isImage = isImageCheck;
            uploadVideForm = videoChildForm;

        }

        public LoadingSaveFile(PlayerUI.Form1 form1, bool isImageCheck, PlayerUI.UploadImagesFrom imageChildForm)
        {
            InitializeComponent();

            mainForm = form1;
            isImage = isImageCheck;
            uploadImagesFrom = imageChildForm;

        }

        private void initailzeList()
        {
            if (isImage)
            {
                loadingImages();
            }
            else
            {
                loadingVideos();
            }            
        }

        public void loadingImages()
        {
            String[] files = null;
            listOfFile.Controls.Clear();

            if (!Directory.Exists("images"))
                Directory.CreateDirectory("images");

            files = Directory.GetFiles("images");
            textBoxTitle.Text = "Image files";

            for (int i = 0; i < files.Length; i++)
            {
                Button b = new Button();

                b.BackgroundImage = Image.FromFile(files[i]);

                b.Size = new Size(230, 230);
                b.Name = Path.GetFullPath(files[i]);
                b.BackgroundImageLayout = ImageLayout.Zoom;
                b.Click += new EventHandler(button_Click);

                listOfFile.Controls.Add(b);
            }
        }
        private void loadingVideos()
        {
            String[] files = null;
            listOfFile.Controls.Clear();

            if (!Directory.Exists("videos"))
                Directory.CreateDirectory("videos");

            files = Directory.GetFiles("videos");
            textBoxTitle.Text = "video files";

            for (int i = 0; i < files.Length; i++)
            {
                Button b = new Button();

                b.Text = files[i];
                b.TextAlign = ContentAlignment.MiddleLeft;
                b.ForeColor = Color.White;

                b.Size = new Size(230, 230);
                b.Name = Path.GetFullPath(files[i]);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            initailzeList();
        }
    }
}
