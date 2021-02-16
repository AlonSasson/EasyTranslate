namespace PlayerUI
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listOfFile
            // 
            this.listOfFile.AutoScroll = true;
            this.listOfFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
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
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.btnRefresh.Font = new System.Drawing.Font("Monotype Corsiva", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRefresh.Location = new System.Drawing.Point(474, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 68);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Loading";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // LoadingSaveFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(692, 566);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.listOfFile);
            this.Name = "LoadingSaveFile";
            this.Text = "LoadingSaveFile";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel listOfFile;
        private System.Windows.Forms.Label textBoxTitle;
        private System.Windows.Forms.Button btnRefresh;
    }
}