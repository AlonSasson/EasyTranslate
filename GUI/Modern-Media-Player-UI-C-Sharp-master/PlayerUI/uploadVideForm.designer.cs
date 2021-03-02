namespace PlayerUI
{
    partial class UploadVideForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadVideForm));
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.controlSound = new System.Windows.Forms.TrackBar();
            this.textBoxSoundValue = new System.Windows.Forms.Label();
            this.soundPict = new System.Windows.Forms.PictureBox();
            this.restartVideBtn = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.playButton = new System.Windows.Forms.PictureBox();
            this.videoMadia = new AxWMPLib.AxWindowsMediaPlayer();
            this.label2 = new System.Windows.Forms.Label();
            this.btdTranslate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictLoadingGif = new System.Windows.Forms.PictureBox();
            this.panelPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundPict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restartVideBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoMadia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictLoadingGif)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPath.Location = new System.Drawing.Point(54, 46);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(470, 24);
            this.textBoxPath.TabIndex = 1;
            // 
            // panelPlayer
            // 
            this.panelPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.panelPlayer.Controls.Add(this.controlSound);
            this.panelPlayer.Controls.Add(this.textBoxSoundValue);
            this.panelPlayer.Controls.Add(this.soundPict);
            this.panelPlayer.Controls.Add(this.restartVideBtn);
            this.panelPlayer.Controls.Add(this.pictureBox4);
            this.panelPlayer.Controls.Add(this.pictureBox3);
            this.panelPlayer.Controls.Add(this.playButton);
            this.panelPlayer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPlayer.Location = new System.Drawing.Point(0, 442);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(720, 124);
            this.panelPlayer.TabIndex = 9;
            // 
            // controlSound
            // 
            this.controlSound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlSound.AutoSize = false;
            this.controlSound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.controlSound.CausesValidation = false;
            this.controlSound.Location = new System.Drawing.Point(352, 34);
            this.controlSound.Maximum = 100;
            this.controlSound.MaximumSize = new System.Drawing.Size(150, 45);
            this.controlSound.MinimumSize = new System.Drawing.Size(150, 45);
            this.controlSound.Name = "controlSound";
            this.controlSound.RightToLeftLayout = true;
            this.controlSound.Size = new System.Drawing.Size(150, 45);
            this.controlSound.TabIndex = 1;
            this.controlSound.TickFrequency = 10;
            this.controlSound.Scroll += new System.EventHandler(this.controlSound_Scroll_1);
            // 
            // textBoxSoundValue
            // 
            this.textBoxSoundValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSoundValue.AutoSize = true;
            this.textBoxSoundValue.ForeColor = System.Drawing.Color.LightGray;
            this.textBoxSoundValue.Location = new System.Drawing.Point(572, 37);
            this.textBoxSoundValue.Name = "textBoxSoundValue";
            this.textBoxSoundValue.Size = new System.Drawing.Size(21, 13);
            this.textBoxSoundValue.TabIndex = 11;
            this.textBoxSoundValue.Text = "0%";
            // 
            // soundPict
            // 
            this.soundPict.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.soundPict.Image = ((System.Drawing.Image)(resources.GetObject("soundPict.Image")));
            this.soundPict.Location = new System.Drawing.Point(336, 34);
            this.soundPict.Name = "soundPict";
            this.soundPict.Size = new System.Drawing.Size(24, 24);
            this.soundPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.soundPict.TabIndex = 7;
            this.soundPict.TabStop = false;
            // 
            // restartVideBtn
            // 
            this.restartVideBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.restartVideBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restartVideBtn.Image = global::PlayerUI.Properties.Resources.sinchronize_24;
            this.restartVideBtn.Location = new System.Drawing.Point(297, 34);
            this.restartVideBtn.Name = "restartVideBtn";
            this.restartVideBtn.Size = new System.Drawing.Size(24, 24);
            this.restartVideBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.restartVideBtn.TabIndex = 4;
            this.restartVideBtn.TabStop = false;
            this.restartVideBtn.Click += new System.EventHandler(this.restartVideBtn_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(147, 34);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(256, 34);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // playButton
            // 
            this.playButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playButton.Image = ((System.Drawing.Image)(resources.GetObject("playButton.Image")));
            this.playButton.Location = new System.Drawing.Point(198, 30);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(32, 32);
            this.playButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.playButton.TabIndex = 1;
            this.playButton.TabStop = false;
            this.playButton.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // videoMadia
            // 
            this.videoMadia.AllowDrop = true;
            this.videoMadia.Enabled = true;
            this.videoMadia.Location = new System.Drawing.Point(54, 116);
            this.videoMadia.Name = "videoMadia";
            this.videoMadia.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("videoMadia.OcxState")));
            this.videoMadia.Size = new System.Drawing.Size(397, 223);
            this.videoMadia.TabIndex = 8;
            this.videoMadia.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.label2.Location = new System.Drawing.Point(238, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 39);
            this.label2.TabIndex = 11;
            this.label2.Text = "Chose video";
            // 
            // btdTranslate
            // 
            this.btdTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btdTranslate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.btdTranslate.FlatAppearance.BorderSize = 0;
            this.btdTranslate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btdTranslate.Font = new System.Drawing.Font("Perpetua", 18.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btdTranslate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btdTranslate.Image = global::PlayerUI.Properties.Resources.google_translate_24;
            this.btdTranslate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btdTranslate.Location = new System.Drawing.Point(558, 180);
            this.btdTranslate.Name = "btdTranslate";
            this.btdTranslate.Size = new System.Drawing.Size(150, 40);
            this.btdTranslate.TabIndex = 10;
            this.btdTranslate.Text = "Translate";
            this.btdTranslate.UseVisualStyleBackColor = false;
            this.btdTranslate.Click += new System.EventHandler(this.btdTranslate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Perpetua", 24.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnSave.Image = global::PlayerUI.Properties.Resources.save_32__3_;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(558, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.LightGray;
            this.button1.Image = global::PlayerUI.Properties.Resources.upload_2_24__1_;
            this.button1.Location = new System.Drawing.Point(558, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictLoadingGif
            // 
            this.pictLoadingGif.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictLoadingGif.Image = ((System.Drawing.Image)(resources.GetObject("pictLoadingGif.Image")));
            this.pictLoadingGif.Location = new System.Drawing.Point(54, 116);
            this.pictLoadingGif.Name = "pictLoadingGif";
            this.pictLoadingGif.Size = new System.Drawing.Size(397, 223);
            this.pictLoadingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictLoadingGif.TabIndex = 14;
            this.pictLoadingGif.TabStop = false;
            // 
            // UploadVideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(720, 566);
            this.Controls.Add(this.pictLoadingGif);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btdTranslate);
            this.Controls.Add(this.videoMadia);
            this.Controls.Add(this.panelPlayer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPath);
            this.Name = "UploadVideForm";
            this.Text = "uploadVideForm";
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.panelPlayer.ResumeLayout(false);
            this.panelPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundPict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restartVideBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoMadia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictLoadingGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelPlayer;
        private AxWMPLib.AxWindowsMediaPlayer videoMadia;
        private System.Windows.Forms.TrackBar controlSound;
        private System.Windows.Forms.Label textBoxSoundValue;
        private System.Windows.Forms.PictureBox soundPict;
        private System.Windows.Forms.PictureBox restartVideBtn;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox playButton;
        private System.Windows.Forms.Button btdTranslate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictLoadingGif;
    }
}