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
    public partial class MainForm : Form
    {

        private HomePage homePage;
        private UploadVideosForm uploadVideosForm;
        private UploadImagesForm uploadImagesFrom;
        private LoadingSaveFile loadingSaveVideo;
        private LoadingSaveFile loadingSaveImage;
        private ScreenTranslate screenTranslate;

        //private Form homePage = new HomePage();
        public MainForm()
        {
            InitializeComponent();
            CreateForm();

            HideSubMenu();

            OpenChildForm(homePage);
        }

        private void CreateForm() // make all the option form (like show images or tanslate them)
        {
            MainForm thisForm = this; // only for pass the class

            homePage = new HomePage();
            BuildUpForChildForm(homePage);

            uploadVideosForm = new UploadVideosForm();
            BuildUpForChildForm(uploadVideosForm);

            uploadImagesFrom = new UploadImagesForm();
            BuildUpForChildForm(uploadImagesFrom);

            loadingSaveVideo = new LoadingSaveFile(thisForm, false, uploadVideosForm);
            BuildUpForChildForm(loadingSaveVideo);

            loadingSaveImage = new LoadingSaveFile(thisForm, true, uploadImagesFrom);
            BuildUpForChildForm(loadingSaveImage);

            screenTranslate = new ScreenTranslate();
            BuildUpForChildForm(screenTranslate);

        }

        private void HideSubMenu()
        {
            panelScreen.Visible = false;
            panelVideos.Visible = false;
            panelImage.Visible = false;
        }


        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(homePage);
        }

        private void btnScreenList_Click(object sender, EventArgs e)
        //screen list btn
        {
            ShowSubMenu(panelScreen);
        }


        private void btnTools_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelVideos);
        }
        #region ToolsSubMenu
        private void btnUploadVideo_Click(object sender, EventArgs e)
        {
            OpenChildForm(uploadVideosForm);
        }

        private void btnSavedVideos_Click(object sender, EventArgs e)
        {
            MainForm thisForm = this; // only for pass the class
            OpenChildForm(loadingSaveVideo);
        }

        #endregion

        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelVideos);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void BuildUpForChildForm(Form childForm)
            // the function get the settings of the form ready for be in form1 child
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
        }

        private Form activeForm = null;
        public void OpenChildForm(Form childForm)
        {
            activeForm = childForm;
            
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnImagesList_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelImage);
        }

        private void btnUploadimage_Click(object sender, EventArgs e)
        {
            OpenChildForm(uploadImagesFrom);
        }

        private void btnSavedImages_Click(object sender, EventArgs e)
        {
            OpenChildForm(loadingSaveImage);
        }

        private void btnFullScreen_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(screenTranslate);
        }
    }
}
