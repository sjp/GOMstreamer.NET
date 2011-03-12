namespace GOMstreamer
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblVLCloc = new System.Windows.Forms.Label();
            this.txtVLCloc = new System.Windows.Forms.TextBox();
            this.btnVLCLoc = new System.Windows.Forms.Button();
            this.lblStream = new System.Windows.Forms.Label();
            this.txtdumploc = new System.Windows.Forms.TextBox();
            this.btnDumpLoc = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblStreamURL = new System.Windows.Forms.Label();
            this.txtStreamURL = new System.Windows.Forms.TextBox();
            this.lblQuality = new System.Windows.Forms.Label();
            this.cbQuality = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKoreanTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.koreanMinute = new System.Windows.Forms.NumericUpDown();
            this.koreanHour = new System.Windows.Forms.NumericUpDown();
            this.btnAbout = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.koreanMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.koreanHour)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 26);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(180, 20);
            this.txtEmail.TabIndex = 0;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(9, 10);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(73, 13);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email Address";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(195, 9);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(198, 26);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(179, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblVLCloc
            // 
            this.lblVLCloc.AutoSize = true;
            this.lblVLCloc.Location = new System.Drawing.Point(9, 62);
            this.lblVLCloc.Name = "lblVLCloc";
            this.lblVLCloc.Size = new System.Drawing.Size(71, 13);
            this.lblVLCloc.TabIndex = 4;
            this.lblVLCloc.Text = "VLC Location";
            // 
            // txtVLCloc
            // 
            this.txtVLCloc.Location = new System.Drawing.Point(12, 78);
            this.txtVLCloc.Name = "txtVLCloc";
            this.txtVLCloc.Size = new System.Drawing.Size(286, 20);
            this.txtVLCloc.TabIndex = 2;
            this.txtVLCloc.Text = "C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe";
            // 
            // btnVLCLoc
            // 
            this.btnVLCLoc.Location = new System.Drawing.Point(302, 76);
            this.btnVLCLoc.Name = "btnVLCLoc";
            this.btnVLCLoc.Size = new System.Drawing.Size(75, 23);
            this.btnVLCLoc.TabIndex = 3;
            this.btnVLCLoc.Text = "Open";
            this.btnVLCLoc.UseVisualStyleBackColor = true;
            this.btnVLCLoc.Click += new System.EventHandler(this.btnVLCLoc_Click);
            // 
            // lblStream
            // 
            this.lblStream.AutoSize = true;
            this.lblStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblStream.Location = new System.Drawing.Point(9, 115);
            this.lblStream.Name = "lblStream";
            this.lblStream.Size = new System.Drawing.Size(125, 13);
            this.lblStream.TabIndex = 7;
            this.lblStream.Text = "File to save the stream to";
            // 
            // txtdumploc
            // 
            this.txtdumploc.Location = new System.Drawing.Point(12, 131);
            this.txtdumploc.Name = "txtdumploc";
            this.txtdumploc.Size = new System.Drawing.Size(286, 20);
            this.txtdumploc.TabIndex = 4;
            // 
            // btnDumpLoc
            // 
            this.btnDumpLoc.Location = new System.Drawing.Point(302, 128);
            this.btnDumpLoc.Name = "btnDumpLoc";
            this.btnDumpLoc.Size = new System.Drawing.Size(75, 23);
            this.btnDumpLoc.TabIndex = 5;
            this.btnDumpLoc.Text = "Open";
            this.btnDumpLoc.UseVisualStyleBackColor = true;
            this.btnDumpLoc.Click += new System.EventHandler(this.btnDumpLoc_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(15, 277);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(362, 39);
            this.btnGo.TabIndex = 12;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblStreamURL
            // 
            this.lblStreamURL.AutoSize = true;
            this.lblStreamURL.Location = new System.Drawing.Point(12, 225);
            this.lblStreamURL.Name = "lblStreamURL";
            this.lblStreamURL.Size = new System.Drawing.Size(65, 13);
            this.lblStreamURL.TabIndex = 13;
            this.lblStreamURL.Text = "Stream URL";
            // 
            // txtStreamURL
            // 
            this.txtStreamURL.Location = new System.Drawing.Point(15, 241);
            this.txtStreamURL.Name = "txtStreamURL";
            this.txtStreamURL.Size = new System.Drawing.Size(283, 20);
            this.txtStreamURL.TabIndex = 10;
            // 
            // lblQuality
            // 
            this.lblQuality.AutoSize = true;
            this.lblQuality.Location = new System.Drawing.Point(146, 171);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(75, 13);
            this.lblQuality.TabIndex = 14;
            this.lblQuality.Text = "Stream Quality";
            // 
            // cbQuality
            // 
            this.cbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuality.FormattingEnabled = true;
            this.cbQuality.Items.AddRange(new object[] {
            "SQTest",
            "SQ",
            "HQ"});
            this.cbQuality.Location = new System.Drawing.Point(149, 187);
            this.cbQuality.Name = "cbQuality";
            this.cbQuality.Size = new System.Drawing.Size(118, 21);
            this.cbQuality.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 331);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(389, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(42, 17);
            this.statusLabel.Text = "Ready.";
            // 
            // lblKoreanTime
            // 
            this.lblKoreanTime.AutoSize = true;
            this.lblKoreanTime.Location = new System.Drawing.Point(270, 171);
            this.lblKoreanTime.Name = "lblKoreanTime";
            this.lblKoreanTime.Size = new System.Drawing.Size(113, 13);
            this.lblKoreanTime.TabIndex = 17;
            this.lblKoreanTime.Text = "Korean Time (HH:MM)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Mode";
            // 
            // cbMode
            // 
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "Play",
            "Save",
            "Delayed Save"});
            this.cbMode.Location = new System.Drawing.Point(12, 187);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(131, 21);
            this.cbMode.TabIndex = 6;
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // koreanMinute
            // 
            this.koreanMinute.Location = new System.Drawing.Point(328, 188);
            this.koreanMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.koreanMinute.Name = "koreanMinute";
            this.koreanMinute.Size = new System.Drawing.Size(49, 20);
            this.koreanMinute.TabIndex = 9;
            this.koreanMinute.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // koreanHour
            // 
            this.koreanHour.Location = new System.Drawing.Point(273, 188);
            this.koreanHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.koreanHour.Name = "koreanHour";
            this.koreanHour.Size = new System.Drawing.Size(49, 20);
            this.koreanHour.TabIndex = 8;
            this.koreanHour.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(304, 238);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(73, 23);
            this.btnAbout.TabIndex = 11;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 353);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.koreanHour);
            this.Controls.Add(this.koreanMinute);
            this.Controls.Add(this.cbMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblKoreanTime);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbQuality);
            this.Controls.Add(this.lblQuality);
            this.Controls.Add(this.txtStreamURL);
            this.Controls.Add(this.lblStreamURL);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnDumpLoc);
            this.Controls.Add(this.txtdumploc);
            this.Controls.Add(this.lblStream);
            this.Controls.Add(this.btnVLCLoc);
            this.Controls.Add(this.txtVLCloc);
            this.Controls.Add(this.lblVLCloc);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "GOMstreamer";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.koreanMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.koreanHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblVLCloc;
        private System.Windows.Forms.TextBox txtVLCloc;
        private System.Windows.Forms.Button btnVLCLoc;
        private System.Windows.Forms.Label lblStream;
        private System.Windows.Forms.TextBox txtdumploc;
        private System.Windows.Forms.Button btnDumpLoc;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblStreamURL;
        private System.Windows.Forms.TextBox txtStreamURL;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.ComboBox cbQuality;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label lblKoreanTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.NumericUpDown koreanMinute;
        private System.Windows.Forms.NumericUpDown koreanHour;
        private System.Windows.Forms.Button btnAbout;
    }
}

