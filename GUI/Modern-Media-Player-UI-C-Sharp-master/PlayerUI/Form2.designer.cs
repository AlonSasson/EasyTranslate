namespace PlayerUI
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.controlSound = new System.Windows.Forms.TrackBar();
            this.textBoxSoundValue = new System.Windows.Forms.Label();
            this.videoMadia = new AxWMPLib.AxWindowsMediaPlayer();
            this.btdTranslate = new System.Windows.Forms.Button();
            this.soundPict = new System.Windows.Forms.PictureBox();
            this.restartVideBtn = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoMadia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundPict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restartVideBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(250, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chose video ";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPath.Location = new System.Drawing.Point(54, 46);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(442, 24);
            this.textBoxPath.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.LightGray;
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 25);
            this.button5.TabIndex = 7;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panelPlayer
            // 
            this.panelPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panelPlayer.Controls.Add(this.controlSound);
            this.panelPlayer.Controls.Add(this.textBoxSoundValue);
            this.panelPlayer.Controls.Add(this.soundPict);
            this.panelPlayer.Controls.Add(this.restartVideBtn);
            this.panelPlayer.Controls.Add(this.pictureBox4);
            this.panelPlayer.Controls.Add(this.pictureBox3);
            this.panelPlayer.Controls.Add(this.pictureBox2);
            this.panelPlayer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPlayer.Location = new System.Drawing.Point(0, 434);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(692, 124);
            this.panelPlayer.TabIndex = 9;
            // 
            // controlSound
            // 
            this.controlSound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlSound.AutoSize = false;
            this.controlSound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
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
            this.textBoxSoundValue.Location = new System.Drawing.Point(558, 37);
            this.textBoxSoundValue.Name = "textBoxSoundValue";
            this.textBoxSoundValue.Size = new System.Drawing.Size(21, 13);
            this.textBoxSoundValue.TabIndex = 11;
            this.textBoxSoundValue.Text = "0%";
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
            // btdTranslate
            // 
            this.btdTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btdTranslate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btdTranslate.FlatAppearance.BorderSize = 0;
            this.btdTranslate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btdTranslate.Font = new System.Drawing.Font("Perpetua", 18.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btdTranslate.ForeColor = System.Drawing.Color.Red;
            this.btdTranslate.Image = global::PlayerUI.Properties.Resources.google_translate_321;
            this.btdTranslate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btdTranslate.Location = new System.Drawing.Point(530, 180);
            this.btdTranslate.Name = "btdTranslate";
            this.btdTranslate.Size = new System.Drawing.Size(150, 40);
            this.btdTranslate.TabIndex = 10;
            this.btdTranslate.Text = "Translate";
            this.btdTranslate.UseVisualStyleBackColor = false;
            // 
            // soundPict
            // 
            this.soundPict.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.soundPict.Image = ((System.Drawing.Image)(resources.GetObject("soundPict.Image")));
            this.soundPict.Location = new System.Drawing.Point(322, 34);
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
            this.restartVideBtn.Image = ((System.Drawing.Image)(resources.GetObject("restartVideBtn.Image")));
            this.restartVideBtn.Location = new System.Drawing.Point(283, 34);
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
            this.pictureBox4.Location = new System.Drawing.Point(133, 34);
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
            this.pictureBox3.Location = new System.Drawing.Point(242, 34);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(184, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Perpetua", 24.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Red;
            this.btnSave.Image = global::PlayerUI.Properties.Resources.save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(530, 116);
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
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.LightGray;
            this.button1.Image = global::PlayerUI.Properties.Resources.upload_2_24;
            this.button1.Location = new System.Drawing.Point(530, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(692, 558);
            this.Controls.Add(this.btdTranslate);
            this.Controls.Add(this.videoMadia);
            this.Controls.Add(this.panelPlayer);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.panelPlayer.ResumeLayout(false);
            this.panelPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoMadia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundPict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restartVideBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panelPlayer;
        private AxWMPLib.AxWindowsMediaPlayer videoMadia;
        private System.Windows.Forms.TrackBar controlSound;
        private System.Windows.Forms.Label textBoxSoundValue;
        private System.Windows.Forms.PictureBox soundPict;
        private System.Windows.Forms.PictureBox restartVideBtn;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btdTranslate;
    }
}