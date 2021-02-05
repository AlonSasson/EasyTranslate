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
        public Form1()
        {
            InitializeComponent();
            hideSubMenu();

            openChildForm(new HomePage());  
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
            openChildForm(new HomePage());
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
            openChildForm(new uploadVideForm());
        }

        private void btnSavedVideos_Click(object sender, EventArgs e)
        {
            Form1 thisForm = this; // only for pass the class
            openChildForm(new LoadingSaveFile(thisForm, false));
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

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnImagesList_Click(object sender, EventArgs e)
        {
            showSubMenu(panelImage);
        }

        private void btnUploadimage_Click(object sender, EventArgs e)
        {
            openChildForm(new UploadImagesFrom());
        }

        private void btnSavedImages_Click(object sender, EventArgs e)
        {
            Form1 thisForm = this; // only for pass the class
            openChildForm(new LoadingSaveFile(thisForm, true));
        }

        private void btnScreenList_MouseDown(object sender, MouseEventArgs e)
        {

        }

    }
}
