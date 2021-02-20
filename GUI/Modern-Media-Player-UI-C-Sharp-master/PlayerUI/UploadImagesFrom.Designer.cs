﻿namespace PlayerUI
{
    partial class UploadImagesFrom
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
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictLoadingGif = new System.Windows.Forms.PictureBox();
            this.btdTranslate = new System.Windows.Forms.Button();
            this.btnOpenTranslateImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.translateImage = new System.Windows.Forms.PictureBox();
            this.uploadImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictLoadingGif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.translateImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uploadImage)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPath.Location = new System.Drawing.Point(59, 63);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(442, 24);
            this.textBoxPath.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("MingLiU-ExtB", 28F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.textBox1.Location = new System.Drawing.Point(59, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(277, 45);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Upload Image";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("MingLiU-ExtB", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.textBox2.Location = new System.Drawing.Point(379, 124);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(325, 40);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "Translate Image";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.label1.Location = new System.Drawing.Point(286, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 39);
            this.label1.TabIndex = 7;
            this.label1.Text = "Chose image";
            // 
            // pictLoadingGif
            // 
            this.pictLoadingGif.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictLoadingGif.Image = global::PlayerUI.Properties.Resources.giphy;
            this.pictLoadingGif.InitialImage = global::PlayerUI.Properties.Resources.giphy;
            this.pictLoadingGif.Location = new System.Drawing.Point(380, 188);
            this.pictLoadingGif.Name = "pictLoadingGif";
            this.pictLoadingGif.Size = new System.Drawing.Size(249, 167);
            this.pictLoadingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictLoadingGif.TabIndex = 13;
            this.pictLoadingGif.TabStop = false;
            // 
            // btdTranslate
            // 
            this.btdTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btdTranslate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.btdTranslate.FlatAppearance.BorderSize = 0;
            this.btdTranslate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btdTranslate.Font = new System.Drawing.Font("Perpetua", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btdTranslate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btdTranslate.Image = global::PlayerUI.Properties.Resources.google_translate_24;
            this.btdTranslate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btdTranslate.Location = new System.Drawing.Point(235, 458);
            this.btdTranslate.Name = "btdTranslate";
            this.btdTranslate.Size = new System.Drawing.Size(195, 53);
            this.btdTranslate.TabIndex = 12;
            this.btdTranslate.Text = "Translate";
            this.btdTranslate.UseVisualStyleBackColor = false;
            this.btdTranslate.Click += new System.EventHandler(this.btdTranslate_Click);
            // 
            // btnOpenTranslateImage
            // 
            this.btnOpenTranslateImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenTranslateImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.btnOpenTranslateImage.FlatAppearance.BorderSize = 0;
            this.btnOpenTranslateImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenTranslateImage.Font = new System.Drawing.Font("Perpetua", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenTranslateImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnOpenTranslateImage.Image = global::PlayerUI.Properties.Resources.open_in_browser_24;
            this.btnOpenTranslateImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenTranslateImage.Location = new System.Drawing.Point(450, 458);
            this.btnOpenTranslateImage.Name = "btnOpenTranslateImage";
            this.btnOpenTranslateImage.Size = new System.Drawing.Size(278, 53);
            this.btnOpenTranslateImage.TabIndex = 11;
            this.btnOpenTranslateImage.Text = "Open Translate Image";
            this.btnOpenTranslateImage.UseVisualStyleBackColor = false;
            this.btnOpenTranslateImage.Click += new System.EventHandler(this.btnOpenTranslateImage_Click);
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
            this.btnSave.Location = new System.Drawing.Point(74, 457);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 53);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.Color.LightGray;
            this.btnUpload.Image = global::PlayerUI.Properties.Resources.upload_2_24__1_;
            this.btnUpload.Location = new System.Drawing.Point(539, 64);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(24, 24);
            this.btnUpload.TabIndex = 6;
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // translateImage
            // 
            this.translateImage.Location = new System.Drawing.Point(380, 188);
            this.translateImage.Name = "translateImage";
            this.translateImage.Size = new System.Drawing.Size(249, 167);
            this.translateImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.translateImage.TabIndex = 3;
            this.translateImage.TabStop = false;
            // 
            // uploadImage
            // 
            this.uploadImage.Location = new System.Drawing.Point(59, 188);
            this.uploadImage.Name = "uploadImage";
            this.uploadImage.Size = new System.Drawing.Size(249, 167);
            this.uploadImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.uploadImage.TabIndex = 0;
            this.uploadImage.TabStop = false;
            // 
            // UploadImagesFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(692, 558);
            this.Controls.Add(this.pictLoadingGif);
            this.Controls.Add(this.btdTranslate);
            this.Controls.Add(this.btnOpenTranslateImage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.translateImage);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.uploadImage);
            this.Name = "UploadImagesFrom";
            this.Text = "UploadImagesFrom";
            ((System.ComponentModel.ISupportInitialize)(this.pictLoadingGif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.translateImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uploadImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox uploadImage;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.PictureBox translateImage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpenTranslateImage;
        private System.Windows.Forms.Button btdTranslate;
        private System.Windows.Forms.PictureBox pictLoadingGif;
    }
}