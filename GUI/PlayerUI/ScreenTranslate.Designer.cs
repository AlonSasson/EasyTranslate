namespace PlayerUI
{
    partial class ScreenTranslate
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
            this.fullScreenBtn = new System.Windows.Forms.Button();
            this.btnPartScreen = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnStopTranslate = new System.Windows.Forms.Button();
            this.choseFunction = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.destLanguageBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // fullScreenBtn
            // 
            this.fullScreenBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fullScreenBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(145)))), ((int)(((byte)(148)))));
            this.fullScreenBtn.FlatAppearance.BorderSize = 0;
            this.fullScreenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fullScreenBtn.Font = new System.Drawing.Font("Perpetua", 24.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullScreenBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.fullScreenBtn.Image = global::PlayerUI.Properties.Resources.expand_256;
            this.fullScreenBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fullScreenBtn.Location = new System.Drawing.Point(813, 183);
            this.fullScreenBtn.Margin = new System.Windows.Forms.Padding(4);
            this.fullScreenBtn.Name = "fullScreenBtn";
            this.fullScreenBtn.Size = new System.Drawing.Size(269, 238);
            this.fullScreenBtn.TabIndex = 11;
            this.fullScreenBtn.UseVisualStyleBackColor = false;
            this.fullScreenBtn.Click += new System.EventHandler(this.fullScreenBtn_Click);
            // 
            // btnPartScreen
            // 
            this.btnPartScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPartScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(145)))), ((int)(((byte)(148)))));
            this.btnPartScreen.FlatAppearance.BorderSize = 0;
            this.btnPartScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPartScreen.Font = new System.Drawing.Font("Perpetua", 24.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartScreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnPartScreen.Image = global::PlayerUI.Properties.Resources.puzzle_piece_256;
            this.btnPartScreen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPartScreen.Location = new System.Drawing.Point(365, 183);
            this.btnPartScreen.Margin = new System.Windows.Forms.Padding(4);
            this.btnPartScreen.Name = "btnPartScreen";
            this.btnPartScreen.Size = new System.Drawing.Size(256, 238);
            this.btnPartScreen.TabIndex = 10;
            this.btnPartScreen.UseVisualStyleBackColor = false;
            this.btnPartScreen.Click += new System.EventHandler(this.btnPartScreen_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("MingLiU-ExtB", 28F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.textBox1.Location = new System.Drawing.Point(116, 91);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(369, 56);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "Part Of Screen";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("MingLiU-ExtB", 28F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.textBox2.Location = new System.Drawing.Point(564, 91);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(369, 56);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Full Screen";
            // 
            // btnStopTranslate
            // 
            this.btnStopTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopTranslate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(145)))), ((int)(((byte)(148)))));
            this.btnStopTranslate.FlatAppearance.BorderSize = 0;
            this.btnStopTranslate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopTranslate.Font = new System.Drawing.Font("Perpetua", 50F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopTranslate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.btnStopTranslate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopTranslate.Location = new System.Drawing.Point(431, 572);
            this.btnStopTranslate.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopTranslate.Name = "btnStopTranslate";
            this.btnStopTranslate.Size = new System.Drawing.Size(521, 128);
            this.btnStopTranslate.TabIndex = 14;
            this.btnStopTranslate.Text = "Stop";
            this.btnStopTranslate.UseVisualStyleBackColor = false;
            this.btnStopTranslate.Click += new System.EventHandler(this.btnStopTranslate_Click);
            // 
            // choseFunction
            // 
            this.choseFunction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.choseFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.choseFunction.Font = new System.Drawing.Font("Perpetua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choseFunction.ForeColor = System.Drawing.Color.White;
            this.choseFunction.FormattingEnabled = true;
            this.choseFunction.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.choseFunction.Items.AddRange(new object[] {
            "tesseract",
            "tensorflow"});
            this.choseFunction.Location = new System.Drawing.Point(493, 453);
            this.choseFunction.Margin = new System.Windows.Forms.Padding(4);
            this.choseFunction.Name = "choseFunction";
            this.choseFunction.Size = new System.Drawing.Size(195, 36);
            this.choseFunction.TabIndex = 16;
            this.choseFunction.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("MingLiU-ExtB", 28F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.textBox3.Location = new System.Drawing.Point(116, 444);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(369, 56);
            this.textBox3.TabIndex = 17;
            this.textBox3.Text = "Choose function:";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("MingLiU-ExtB", 28F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.textBox4.Location = new System.Drawing.Point(116, 508);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(369, 56);
            this.textBox4.TabIndex = 18;
            this.textBox4.Text = "Choose function:";
            // 
            // destLanguageBox
            // 
            this.destLanguageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.destLanguageBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destLanguageBox.Font = new System.Drawing.Font("Perpetua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destLanguageBox.ForeColor = System.Drawing.Color.White;
            this.destLanguageBox.FormattingEnabled = true;
            this.destLanguageBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.destLanguageBox.Items.AddRange(new object[] {
            "afrikaans",
            "albanian",
            "amharic",
            "arabic",
            "armenian",
            "azerbaijani",
            "basque",
            "belarusian",
            "bengali",
            "bosnian",
            "bulgarian",
            "catalan",
            "cebuano",
            "chichewa",
            "chinese",
            "chinese (simplified)",
            "chinese (traditional)",
            "corsican",
            "croatian",
            "czech",
            "danish",
            "dutch",
            "english",
            "esperanto",
            "estonian",
            "filipino",
            "finnish",
            "french",
            "frisian",
            "galician",
            "georgian",
            "german",
            "greek",
            "gujarati",
            "haitian creole",
            "hausa",
            "hawaiian",
            "hebrew",
            "hindi",
            "hmong",
            "hungarian",
            "icelandic",
            "igbo",
            "indonesian",
            "irish",
            "italian",
            "japanese",
            "javanese",
            "kannada",
            "kazakh",
            "khmer",
            "korean",
            "kurdish (kurmanji)",
            "kyrgyz",
            "lao",
            "latin",
            "latvian",
            "lithuanian",
            "luxembourgish",
            "macedonian",
            "malagasy",
            "malay",
            "malayalam",
            "maltese",
            "maori",
            "marathi",
            "mongolian",
            "myanmar (burmese)",
            "nepali",
            "norwegian",
            "pashto",
            "persian",
            "polish",
            "portuguese",
            "punjabi",
            "romanian",
            "russian",
            "samoan",
            "scots gaelic",
            "serbian",
            "sesotho",
            "shona",
            "sindhi",
            "sinhala",
            "slovak",
            "slovenian",
            "somali",
            "spanish",
            "sundanese",
            "swahili",
            "swedish",
            "tajik",
            "tamil",
            "telugu",
            "thai",
            "turkish",
            "ukrainian",
            "urdu",
            "uzbek",
            "vietnamese",
            "welsh",
            "xhosa",
            "yiddish",
            "yoruba",
            "zulu",
            "Filipino",
            "Hebrew"});
            this.destLanguageBox.Location = new System.Drawing.Point(493, 517);
            this.destLanguageBox.Margin = new System.Windows.Forms.Padding(4);
            this.destLanguageBox.Name = "destLanguageBox";
            this.destLanguageBox.Size = new System.Drawing.Size(195, 36);
            this.destLanguageBox.TabIndex = 19;
            this.destLanguageBox.TabStop = false;
            // 
            // ScreenTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1089, 804);
            this.Controls.Add(this.destLanguageBox);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.choseFunction);
            this.Controls.Add(this.btnStopTranslate);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.fullScreenBtn);
            this.Controls.Add(this.btnPartScreen);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScreenTranslate";
            this.Text = "ScreenTranslate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPartScreen;
        private System.Windows.Forms.Button fullScreenBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnStopTranslate;
        private System.Windows.Forms.ComboBox choseFunction;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox destLanguageBox;
    }
}