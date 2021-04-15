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
        private Form activeForm;

        public MainForm()
        {
            InitializeComponent();
            CreateForm();

            HideSubMenu();

            OpenChildForm(homePage);
        }

        // make all the option forms (like show images or tanslate them)
        private void CreateForm() 
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

        // hides all the sub menus
        private void HideSubMenu()
        {
            panelScreen.Visible = false;
            panelVideos.Visible = false;
            panelImage.Visible = false;
        }


        // shows a sub menu, and hides all the others, or hides the sub menu if already visible
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

        // handles when the home button is clicked
        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(homePage);
        }

        private void btnScreenList_Click(object sender, EventArgs e)
        //screen list btn
        {
            ShowSubMenu(panelScreen);
        }

        #region ToolsSubMenu

        // handles when the upload video button is clicked
        private void btnUploadVideo_Click(object sender, EventArgs e)
        {
            OpenChildForm(uploadVideosForm);
        }

        // handles when the saved videos button is clicked
        private void btnSavedVideos_Click(object sender, EventArgs e)
        {
            MainForm thisForm = this; // only for pass the class
            OpenChildForm(loadingSaveVideo);
        }

        #endregion

        // handles when the videos button is clicked
        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelVideos);
        }

        // handles when the exit button is clicked
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // the function get the settings of the form ready for be in form1 child
        private void BuildUpForChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
        }

        // the function opens the child form and shows it
        public void OpenChildForm(Form childForm)
        {
            activeForm = childForm;
            
            childForm.BringToFront();
            childForm.Show();
        }

        // handles when the images button is clicked
        private void btnImagesList_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelImage);
        }

        // handles when the upload images button is clicked
        private void btnUploadimage_Click(object sender, EventArgs e)
        {
            OpenChildForm(uploadImagesFrom);
        }

        // handles when the saved images button is clicked
        private void btnSavedImages_Click(object sender, EventArgs e)
        {
            OpenChildForm(loadingSaveImage);
        }

        // handles when the full screen button is clicked
        private void btnFullScreen_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(screenTranslate);
        }
    }
}
