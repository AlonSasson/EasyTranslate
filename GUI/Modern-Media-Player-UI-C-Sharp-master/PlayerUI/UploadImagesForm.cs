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
    public partial class UploadImagesForm : Form
    {
        private bool checkImageLoad = false;
        private bool checkInMiddleTranslate = false;
        private string translate_image_path = "";
        public UploadImagesForm()
        {
            InitializeComponent();

            //set the default function and language for translation
            choseFunction.SelectedIndex = 0;
            destLanguageBox.Text = "hebrew";

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
            if (!checkInMiddleTranslate)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        SetImage(open.FileName);
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
                MessageBox.Show("The image is in the middle of translation");
            }

        }

        public void SetImage(string imagePath)
        {

            uploadImage.Image = Image.FromFile(imagePath);
            textBoxPath.Text = imagePath;

            checkImageLoad = true;
            translateImage.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!checkInMiddleTranslate)
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
                MessageBox.Show("The image is in the middle of translation");
            }
        }

        private void btdTranslate_Click(object sender, EventArgs e)
        {
            if (!checkInMiddleTranslate)
            {
                lock (pictLoadingGif)
                {
                    pictLoadingGif.BringToFront();
                }

                string codeFunction = choseFunction.Text;
                string destLanguage = destLanguageBox.Text;
                Thread thr = new Thread(() => PythonThread(codeFunction, destLanguage));
                thr.Start();
            }
            else
            {
                MessageBox.Show("The image is in the middle of translation");
            }
        }

        private void PythonThread(string codeFunction, string destLanguage)
        {
            checkInMiddleTranslate = true;
            
            //make file name withe the name of function
            string destPath = Path.Combine(@"images\\translate", Path.GetFileNameWithoutExtension(textBoxPath.Text) + "_" + codeFunction +
               "_" + destLanguage + Path.GetExtension(textBoxPath.Text));

            if (!File.Exists(destPath))
            {
                string path = @"..\..\..\..\..\AppCode\EasyTranslate.py";
                string parameters = "image " + codeFunction + " " + destLanguage + " " + textBoxPath.Text + " " + Path.GetFullPath(destPath);
                PlayerUI.PythonRun.run_cmd(path, parameters);
            }

            //check if could create the image
            if (File.Exists(destPath))
            {
                translate_image_path = destPath;
                translateImage.Image = Image.FromFile(destPath);
            }

           
            lock (pictLoadingGif)
            {
                pictLoadingGif.Invoke(new Action(() =>
               {
                   pictLoadingGif.SendToBack();
               }));
            }
            checkInMiddleTranslate = false;
        }

        private void btnOpenTranslateImage_Click(object sender, EventArgs e)
        {
            if (!checkInMiddleTranslate)
            {
                if (translate_image_path != "")
                {
                    try
                    {
                        Process.Start(translate_image_path);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("not found translated image you need to save the image:(");
                        throw;
                    }

                }
            }
            else
            {
                MessageBox.Show("The image is in the middle of translation");
            }
        }
    }
}
