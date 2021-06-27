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
        private MainForm mainForm;
        PlayerUI.UploadVideosForm uploadVideosForm = null;
        PlayerUI.UploadImagesForm uploadImagesFrom = null;

        // CTOR for uploading saved videos
        public LoadingSaveFile(PlayerUI.MainForm form1, bool isImageCheck, PlayerUI.UploadVideosForm videoChildForm)
        {
            InitializeComponent();
            InitailzeList();
            mainForm = form1;
            isImage = isImageCheck;
            uploadVideosForm = videoChildForm;

        }

        // CTOR for uploading saved images
        public LoadingSaveFile(PlayerUI.MainForm form1, bool isImageCheck, PlayerUI.UploadImagesForm imageChildForm)
        {
            InitializeComponent();
            mainForm = form1;
            isImage = isImageCheck;
            uploadImagesFrom = imageChildForm;
            InitailzeList();


        }

        // initializes the form
        private void InitailzeList()
        {
            if (isImage)
            {
                LoadingImages();
            }
            else
            {
                LoadingVideos();
            }            
        }

        // loads the saved images
        public void LoadingImages()
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

                b.Size = new Size(150, 150);
                b.Name = Path.GetFullPath(files[i]);
                b.BackgroundImageLayout = ImageLayout.Zoom;
                b.Click += new EventHandler(button_Click);

                listOfFile.Controls.Add(b);
            }
        }

        // loads the saved videos
        private void LoadingVideos()
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

                b.Size = new Size(150, 150);
                b.Name = Path.GetFullPath(files[i]);
                b.BackgroundImageLayout = ImageLayout.Zoom;
                b.Click += new EventHandler(button_Click);

                listOfFile.Controls.Add(b);
            }
        }

        // handles when a saved file is clicked
        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (isImage) // if its an image that was clicked
            {
                uploadImagesFrom.SetImage(button.Name);

                mainForm.OpenChildForm(uploadImagesFrom);
                this.Hide();
            }
            else  // it means is a video
            {
                uploadVideosForm.SetVideo(button.Name);

                mainForm.OpenChildForm(uploadVideosForm);
                this.Hide();
            }
        }

        // handles when the reload button is clicked
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitailzeList();
        }
    }
}
