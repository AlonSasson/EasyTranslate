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
using System.Threading;


namespace PlayerUI
{
    public partial class UploadImagesFrom : Form
    {
        private bool checkImageLoad = false;
        private bool checkInMideleTranslate = false;
        private string translate_image_path = "";
        public UploadImagesFrom()
        {
            InitializeComponent();
            lock (pictLoadingGif)
            {
                pictLoadingGif.SendToBack();
            }

            if (!Directory.Exists("images"))
                Directory.CreateDirectory(@"images");

            if (!Directory.Exists("images\\translate"))
                Directory.CreateDirectory(@"images\translate");
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (!checkInMideleTranslate)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        setImage(open.FileName);
                    }
                    catch (Exception)
                    {
                        checkImageLoad = false;
                        MessageBox.Show("Couldn't open the video");
                    }

                }
            }
            else
            {
                MessageBox.Show("The image in midle translate");
            }

        }

        public void setImage(string imagePath)
        {

            uploadImage.Image = Image.FromFile(imagePath);
            textBoxPath.Text = imagePath;

            checkImageLoad = true;
            translateImage.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!checkInMideleTranslate)
            {
                if (checkImageLoad)
                {


                    string destPath = Path.Combine(@"images\", Path.GetFileName(textBoxPath.Text));

                    if (File.Exists(destPath)) // if the video exsist he will delete the first 
                    {
                        MessageBox.Show("this image name alrady saved");
                    }
                    else
                    {
                        File.Copy(textBoxPath.Text, destPath);
                    }
                }
                else
                {
                    MessageBox.Show("You need upload image befor you save :(");
                }
            }
            else
            {
                MessageBox.Show("The image in midle translate");
            }
        }

        private void btdTranslate_Click(object sender, EventArgs e)
        {
            if (!checkInMideleTranslate)
            {
                lock (pictLoadingGif)
                {
                    pictLoadingGif.BringToFront();
                }


                Thread thr = new Thread(pythonThread);
                thr.Start();
            }
            else
            {
                MessageBox.Show("The image in midle translate");
            }
        }

        private void pythonThread()
        {
            checkInMideleTranslate = true;
            string destPath = Path.Combine(@"images\\translate", Path.GetFileName(textBoxPath.Text));

            if (!File.Exists(destPath))
            {
                string path = @"..\..\..\..\..\AppCode\EasyTranslate.py";
                string parameters = "0 " + textBoxPath.Text + " " + Path.GetFullPath(destPath);
                PlayerUI.PythonRun.run_cmd(path, parameters);
            }

            translate_image_path = destPath;
            //this is for now
            translateImage.Image = Image.FromFile(destPath);
           
            lock (pictLoadingGif)
            {
                pictLoadingGif.Invoke(new Action(() =>
               {
                   pictLoadingGif.SendToBack();
               }));
            }
            checkInMideleTranslate = false;
        }

        private void btnOpenTranslateImage_Click(object sender, EventArgs e)
        {
            if (!checkInMideleTranslate)
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
            else
            {
                MessageBox.Show("The image in midle translate");
            }
        }
    }
}
