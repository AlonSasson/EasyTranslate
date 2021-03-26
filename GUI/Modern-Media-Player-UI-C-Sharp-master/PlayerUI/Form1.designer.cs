namespace PlayerUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelImage = new System.Windows.Forms.Panel();
            this.btnSavedImages = new System.Windows.Forms.Button();
            this.btnUploadimage = new System.Windows.Forms.Button();
            this.btnImagesList = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelVideos = new System.Windows.Forms.Panel();
            this.btnSavedVideos = new System.Windows.Forms.Button();
            this.btnUploadVideo = new System.Windows.Forms.Button();
            this.btnEqualizer = new System.Windows.Forms.Button();
            this.panelScreen = new System.Windows.Forms.Panel();
            this.btnPartOfScreen = new System.Windows.Forms.Button();
            this.btnFullScreen = new System.Windows.Forms.Button();
            this.btnScreenList = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panelSideMenu.SuspendLayout();
            this.panelImage.SuspendLayout();
            this.panelVideos.SuspendLayout();
            this.panelScreen.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(112)))), ((int)(((byte)(114)))));
            this.panelSideMenu.Controls.Add(this.panelImage);
            this.panelSideMenu.Controls.Add(this.btnImagesList);
            this.panelSideMenu.Controls.Add(this.btnExit);
            this.panelSideMenu.Controls.Add(this.panelVideos);
            this.panelSideMenu.Controls.Add(this.btnEqualizer);
            this.panelSideMenu.Controls.Add(this.panelScreen);
            this.panelSideMenu.Controls.Add(this.btnScreenList);
            this.panelSideMenu.Controls.Add(this.btnHome);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 692);
            this.panelSideMenu.TabIndex = 0;
            // 
            // panelImage
            // 
            this.panelImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelImage.Controls.Add(this.btnSavedImages);
            this.panelImage.Controls.Add(this.btnUploadimage);
            this.panelImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelImage.Location = new System.Drawing.Point(0, 431);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(250, 83);
            this.panelImage.TabIndex = 13;
            // 
            // btnSavedImages
            // 
            this.btnSavedImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(112)))), ((int)(((byte)(114)))));
            this.btnSavedImages.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSavedImages.FlatAppearance.BorderSize = 0;
            this.btnSavedImages.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
            this.btnSavedImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavedImages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnSavedImages.Location = new System.Drawing.Point(0, 40);
            this.btnSavedImages.Name = "btnSavedImages";
            this.btnSavedImages.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSavedImages.Size = new System.Drawing.Size(250, 43);
            this.btnSavedImages.TabIndex = 1;
            this.btnSavedImages.Text = "Saved Images";
            this.btnSavedImages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavedImages.UseVisualStyleBackColor = false;
            this.btnSavedImages.Click += new System.EventHandler(this.btnSavedImages_Click);
            // 
            // btnUploadimage
            // 
            this.btnUploadimage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(112)))), ((int)(((byte)(114)))));
            this.btnUploadimage.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUploadimage.FlatAppearance.BorderSize = 0;
            this.btnUploadimage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
            this.btnUploadimage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadimage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnUploadimage.Location = new System.Drawing.Point(0, 0);
            this.btnUploadimage.Name = "btnUploadimage";
            this.btnUploadimage.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnUploadimage.Size = new System.Drawing.Size(250, 40);
            this.btnUploadimage.TabIndex = 0;
            this.btnUploadimage.Text = "Upload Image";
            this.btnUploadimage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUploadimage.UseVisualStyleBackColor = false;
            this.btnUploadimage.Click += new System.EventHandler(this.btnUploadimage_Click);
            // 
            // btnImagesList
            // 
            this.btnImagesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(112)))), ((int)(((byte)(114)))));
            this.btnImagesList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnImagesList.FlatAppearance.BorderSize = 0;
            this.btnImagesList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
            this.btnImagesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImagesList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnImagesList.Image = global::PlayerUI.Properties.Resources.picture_2_24;
            this.btnImagesList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImagesList.Location = new System.Drawing.Point(0, 386);
            this.btnImagesList.Name = "btnImagesList";
            this.btnImagesList.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnImagesList.Size = new System.Drawing.Size(250, 45);
            this.btnImagesList.TabIndex = 11;
            this.btnImagesList.Text = " Image";
            this.btnImagesList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImagesList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImagesList.UseVisualStyleBackColor = false;
            this.btnImagesList.Click += new System.EventHandler(this.btnImagesList_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(112)))), ((int)(((byte)(114)))));
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnExit.Image = global::PlayerUI.Properties.Resources.exit_24;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(0, 647);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(250, 45);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "  Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelVideos
            // 
            this.panelVideos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelVideos.Controls.Add(this.btnSavedVideos);
            this.panelVideos.Controls.Add(this.btnUploadVideo);
            this.panelVideos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelVideos.Location = new System.Drawing.Point(0, 303);
            this.panelVideos.Name = "panelVideos";
            this.panelVideos.Size = new System.Drawing.Size(250, 83);
            this.panelVideos.TabIndex = 7;
            // 
            // btnSavedVideos
            // 
            this.btnSavedVideos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(112)))), ((int)(((byte)(114)))));
            this.btnSavedVideos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSavedVideos.FlatAppearance.BorderSize = 0;
            this.btnSavedVideos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
            this.btnSavedVideos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavedVideos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnSavedVideos.Location = new System.Drawing.Point(0, 40);
            this.btnSavedVideos.Name = "btnSavedVideos";
            this.btnSavedVideos.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnSavedVideos.Size = new System.Drawing.Size(250, 43);
            this.btnSavedVideos.TabIndex = 1;
            this.btnSavedVideos.Text = "Saved Videos";
            this.btnSavedVideos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavedVideos.UseVisualStyleBackColor = false;
            this.btnSavedVideos.Click += new System.EventHandler(this.btnSavedVideos_Click);
            // 
            // btnUploadVideo
            // 
            this.btnUploadVideo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(112)))), ((int)(((byte)(114)))));
            this.btnUploadVideo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUploadVideo.FlatAppearance.BorderSize = 0;
            this.btnUploadVideo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
            this.btnUploadVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadVideo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnUploadVideo.Location = new System.Drawing.Point(0, 0);
            this.btnUploadVideo.Name = "btnUploadVideo";
            this.btnUploadVideo.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnUploadVideo.Size = new System.Drawing.Size(250, 40);
            this.btnUploadVideo.TabIndex = 0;
            this.btnUploadVideo.Text = "Upload Video";
            this.btnUploadVideo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUploadVideo.UseVisualStyleBackColor = false;
            this.btnUploadVideo.Click += new System.EventHandler(this.btnUploadVideo_Click);
            // 
            // btnEqualizer
            // 
            this.btnEqualizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(112)))), ((int)(((byte)(114)))));
            this.btnEqualizer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEqualizer.FlatAppearance.BorderSize = 0;
            this.btnEqualizer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
            this.btnEqualizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqualizer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnEqualizer.Image = global::PlayerUI.Properties.Resources.video_play_4_24__1_;
            this.btnEqualizer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEqualizer.Location = new System.Drawing.Point(0, 258);
            this.btnEqualizer.Name = "btnEqualizer";
            this.btnEqualizer.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnEqualizer.Size = new System.Drawing.Size(250, 45);
            this.btnEqualizer.TabIndex = 5;
            this.btnEqualizer.Text = "Video ";
            this.btnEqualizer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEqualizer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEqualizer.UseVisualStyleBackColor = false;
            this.btnEqualizer.Click += new System.EventHandler(this.btnEqualizer_Click);
            // 
            // panelScreen
            // 
            this.panelScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelScreen.Controls.Add(this.btnPartOfScreen);
            this.panelScreen.Controls.Add(this.btnFullScreen);
            this.panelScreen.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelScreen.Location = new System.Drawing.Point(0, 182);
            this.panelScreen.Name = "panelScreen";
            this.panelScreen.Size = new System.Drawing.Size(250, 76);
            this.panelScreen.TabIndex = 4;
            // 
            // btnPartOfScreen
            // 
            this.btnPartOfScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(112)))), ((int)(((byte)(114)))));
            this.btnPartOfScreen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPartOfScreen.FlatAppearance.BorderSize = 0;
            this.btnPartOfScreen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
            this.btnPartOfScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPartOfScreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnPartOfScreen.Location = new System.Drawing.Point(0, 40);
            this.btnPartOfScreen.Name = "btnPartOfScreen";
            this.btnPartOfScreen.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnPartOfScreen.Size = new System.Drawing.Size(250, 40);
            this.btnPartOfScreen.TabIndex = 1;
            this.btnPartOfScreen.Text = "who to";
            this.btnPartOfScreen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPartOfScreen.UseVisualStyleBackColor = false;
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(112)))), ((int)(((byte)(114)))));
            this.btnFullScreen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFullScreen.FlatAppearance.BorderSize = 0;
            this.btnFullScreen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
            this.btnFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFullScreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnFullScreen.Location = new System.Drawing.Point(0, 0);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnFullScreen.Size = new System.Drawing.Size(250, 40);
            this.btnFullScreen.TabIndex = 0;
            this.btnFullScreen.Text = "screen translation";
            this.btnFullScreen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFullScreen.UseVisualStyleBackColor = false;
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click_1);
            // 
            // btnScreenList
            // 
            this.btnScreenList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(112)))), ((int)(((byte)(114)))));
            this.btnScreenList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnScreenList.FlatAppearance.BorderSize = 0;
            this.btnScreenList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
            this.btnScreenList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScreenList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnScreenList.Image = global::PlayerUI.Properties.Resources.monitor_24;
            this.btnScreenList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScreenList.Location = new System.Drawing.Point(0, 137);
            this.btnScreenList.Name = "btnScreenList";
            this.btnScreenList.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnScreenList.Size = new System.Drawing.Size(250, 45);
            this.btnScreenList.TabIndex = 3;
            this.btnScreenList.Text = "   Translate Screen";
            this.btnScreenList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScreenList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnScreenList.UseVisualStyleBackColor = false;
            this.btnScreenList.Click += new System.EventHandler(this.btnScreenList_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(112)))), ((int)(((byte)(114)))));
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnHome.Image = global::PlayerUI.Properties.Resources.house_24;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 92);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnHome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnHome.Size = new System.Drawing.Size(250, 45);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "    Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(112)))), ((int)(((byte)(114)))));
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 92);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PlayerUI.Properties.Resources.download1;
            this.pictureBox1.Location = new System.Drawing.Point(-40, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(250, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(833, 692);
            this.panelChildForm.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1083, 692);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelSideMenu.ResumeLayout(false);
            this.panelImage.ResumeLayout(false);
            this.panelVideos.ResumeLayout(false);
            this.panelScreen.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panelVideos;
        private System.Windows.Forms.Button btnSavedVideos;
        private System.Windows.Forms.Button btnUploadVideo;
        private System.Windows.Forms.Button btnEqualizer;
        private System.Windows.Forms.Panel panelScreen;
        private System.Windows.Forms.Button btnPartOfScreen;
        private System.Windows.Forms.Button btnFullScreen;
        private System.Windows.Forms.Button btnScreenList;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Button btnImagesList;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.Button btnSavedImages;
        private System.Windows.Forms.Button btnUploadimage;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

