﻿namespace PlayerUI
{
    partial class LoadingSaveFile
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
            this.listOfFile = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listOfFile
            // 
            this.listOfFile.AutoScroll = true;
            this.listOfFile.BackColor = System.Drawing.Color.Black;
            this.listOfFile.Location = new System.Drawing.Point(60, 99);
            this.listOfFile.Name = "listOfFile";
            this.listOfFile.Size = new System.Drawing.Size(536, 407);
            this.listOfFile.TabIndex = 0;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxTitle.Font = new System.Drawing.Font("Monotype Corsiva", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.ForeColor = System.Drawing.Color.White;
            this.textBoxTitle.Location = new System.Drawing.Point(74, 17);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(484, 79);
            this.textBoxTitle.TabIndex = 8;
            // 
            // LoadingSaveFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(692, 566);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.listOfFile);
            this.Name = "LoadingSaveFile";
            this.Text = "LoadingSaveFile";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel listOfFile;
        private System.Windows.Forms.Label textBoxTitle;
    }
}