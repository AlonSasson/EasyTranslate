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
using System.Diagnostics;

namespace PlayerUI
{
    public partial class UploadImagesFrom : Form
    {
        private bool checkImageLoad = false;
        private string translate_image_path = "";
        public UploadImagesFrom()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBoxPath.Text = open.FileName;
                    uploadImage.Image = Image.FromFile(textBoxPath.Text);

                    //not saving or play none video
                    checkImageLoad = true;
                }
                catch (Exception)
                {
                    checkImageLoad = false;
                    MessageBox.Show("Couldn't open the video");
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkImageLoad)
            {
                if (!Directory.Exists("images"))
                    Directory.CreateDirectory(@"images");

                if (!Directory.Exists("images\\translate"))
                    Directory.CreateDirectory(@"images\translate");

                string destPath = Path.Combine(@"images\", Path.GetFileName(textBoxPath.Text));

                if (File.Exists(destPath)) // if the video exsist he will delete the first 
                {
                    File.Delete(destPath);
                }

                File.Copy(textBoxPath.Text, destPath);
            }
            else
            {
                MessageBox.Show("You need upload image befor you save :(");
            }
        }

        private void btdTranslate_Click(object sender, EventArgs e)
        {
            //should send the image to python script and get image translate
            string destPath = Path.Combine(@"images\\translate", Path.GetFileName(textBoxPath.Text));
            File.Copy(textBoxPath.Text, destPath);

            translate_image_path = destPath;
            //this is for now
            translateImage.Image = Image.FromFile(destPath);
        }

        private void btnOpenTranslateImage_Click(object sender, EventArgs e)
        {
            if (translate_image_path != "")
            {
                try
                {
                    Process.Start(translate_image_path);
                }
                catch (Exception)
                {
                    MessageBox.Show("not found teanslate image you need to save the image:(");
                    throw;
                }

            }
        }
    }
}
