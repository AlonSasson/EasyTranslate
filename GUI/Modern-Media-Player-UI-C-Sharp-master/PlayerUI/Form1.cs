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
    public partial class Form1 : Form
    {

        private HomePage homePage;
        private UploadVideForm uploadVideoForm;
        private UploadImagesFrom uploadImagesFrom;
        private LoadingSaveFile loadingSaveVideo;
        private LoadingSaveFile loadingSaveImage;

        //private Form homePage = new HomePage();
        public Form1()
        {
            InitializeComponent();
            createForm();

            hideSubMenu();

            openChildForm(homePage);
        }

        private void createForm()
        {
            Form1 thisForm = this; // only for pass the class

            homePage = new HomePage();
            buildUpForChildForm(homePage);

            uploadVideoForm = new UploadVideForm();
            buildUpForChildForm(uploadVideoForm);

            uploadImagesFrom = new UploadImagesFrom();
            buildUpForChildForm(uploadImagesFrom);

            loadingSaveVideo = new LoadingSaveFile(thisForm, false, uploadVideoForm);
            buildUpForChildForm(loadingSaveVideo);

            loadingSaveImage = new LoadingSaveFile(thisForm, true, uploadImagesFrom);
            buildUpForChildForm(loadingSaveImage);

        }

        private void hideSubMenu()
        {
            panelScreen.Visible = false;
            panelVideos.Visible = false;
            panelImage.Visible = false;
        }


        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(homePage);
        }

        private void btnScreenList_Click(object sender, EventArgs e)
        //screen list btn
        {
            showSubMenu(panelScreen);
        }

        #region ScreenManagemetSubMenu
        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnPartOfScreen_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        #endregion

        private void btnTools_Click(object sender, EventArgs e)
        {
            showSubMenu(panelVideos);
        }
        #region ToolsSubMenu
        private void btnUploadVideo_Click(object sender, EventArgs e)
        {
            openChildForm(uploadVideoForm);
        }

        private void btnSavedVideos_Click(object sender, EventArgs e)
        {
            Form1 thisForm = this; // only for pass the class
            openChildForm(loadingSaveVideo);
        }

        #endregion

        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            showSubMenu(panelVideos);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void buildUpForChildForm(Form childForm)
            // the function get the settings of the form ready for be in form1 child
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
        }

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            //if (activeForm != null) activeForm.Hide();
            activeForm = childForm;
            
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnImagesList_Click(object sender, EventArgs e)
        {
            showSubMenu(panelImage);
        }

        private void btnUploadimage_Click(object sender, EventArgs e)
        {
            openChildForm(uploadImagesFrom);
        }

        private void btnSavedImages_Click(object sender, EventArgs e)
        {
            openChildForm(loadingSaveImage);
        }

    }
}
