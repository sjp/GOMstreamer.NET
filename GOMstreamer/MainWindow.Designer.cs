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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.lblVlcLocation = new System.Windows.Forms.Label();
            this.txtVlcLocation = new System.Windows.Forms.TextBox();
            this.btnVlcLocation = new System.Windows.Forms.Button();
            this.lblDumpLocation = new System.Windows.Forms.Label();
            this.txtDumpLocation = new System.Windows.Forms.TextBox();
            this.btnDumpLocation = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblStreamURL = new System.Windows.Forms.Label();
            this.txtStreamURL = new System.Windows.Forms.TextBox();
            this.lblStreamQuality = new System.Windows.Forms.Label();
            this.cbStreamQuality = new System.Windows.Forms.ComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKoreanTime = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.frmKoreanMinute = new System.Windows.Forms.NumericUpDown();
            this.frmKoreanHour = new System.Windows.Forms.NumericUpDown();
            this.btnAbout = new System.Windows.Forms.Button();
            this.gomNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frmKoreanMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmKoreanHour)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(12, 26);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(180, 20);
            this.txtEmailAddress.TabIndex = 0;
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(9, 10);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(73, 13);
            this.lblEmailAddress.TabIndex = 1;
            this.lblEmailAddress.Text = "Email Address";
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.Location = new System.Drawing.Point(195, 9);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(53, 13);
            this.lblUserPassword.TabIndex = 2;
            this.lblUserPassword.Text = "Password";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(198, 26);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(179, 20);
            this.txtUserPassword.TabIndex = 1;
            this.txtUserPassword.UseSystemPasswordChar = true;
            // 
            // lblVlcLocation
            // 
            this.lblVlcLocation.AutoSize = true;
            this.lblVlcLocation.Location = new System.Drawing.Point(9, 62);
            this.lblVlcLocation.Name = "lblVlcLocation";
            this.lblVlcLocation.Size = new System.Drawing.Size(71, 13);
            this.lblVlcLocation.TabIndex = 4;
            this.lblVlcLocation.Text = "VLC Location";
            // 
            // txtVlcLocation
            // 
            this.txtVlcLocation.Location = new System.Drawing.Point(12, 78);
            this.txtVlcLocation.Name = "txtVlcLocation";
            this.txtVlcLocation.Size = new System.Drawing.Size(286, 20);
            this.txtVlcLocation.TabIndex = 2;
            this.txtVlcLocation.Text = "C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe";
            // 
            // btnVlcLocation
            // 
            this.btnVlcLocation.Location = new System.Drawing.Point(302, 76);
            this.btnVlcLocation.Name = "btnVlcLocation";
            this.btnVlcLocation.Size = new System.Drawing.Size(75, 23);
            this.btnVlcLocation.TabIndex = 3;
            this.btnVlcLocation.Text = "Open";
            this.btnVlcLocation.UseVisualStyleBackColor = true;
            this.btnVlcLocation.Click += new System.EventHandler(this.btnVlcLocation_Click);
            // 
            // lblDumpLocation
            // 
            this.lblDumpLocation.AutoSize = true;
            this.lblDumpLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDumpLocation.Location = new System.Drawing.Point(9, 115);
            this.lblDumpLocation.Name = "lblDumpLocation";
            this.lblDumpLocation.Size = new System.Drawing.Size(125, 13);
            this.lblDumpLocation.TabIndex = 7;
            this.lblDumpLocation.Text = "File to save the stream to";
            // 
            // txtDumpLocation
            // 
            this.txtDumpLocation.Location = new System.Drawing.Point(12, 131);
            this.txtDumpLocation.Name = "txtDumpLocation";
            this.txtDumpLocation.Size = new System.Drawing.Size(286, 20);
            this.txtDumpLocation.TabIndex = 4;
            // 
            // btnDumpLocation
            // 
            this.btnDumpLocation.Location = new System.Drawing.Point(302, 128);
            this.btnDumpLocation.Name = "btnDumpLocation";
            this.btnDumpLocation.Size = new System.Drawing.Size(75, 23);
            this.btnDumpLocation.TabIndex = 5;
            this.btnDumpLocation.Text = "Open";
            this.btnDumpLocation.UseVisualStyleBackColor = true;
            this.btnDumpLocation.Click += new System.EventHandler(this.btnDumpLocation_Click);
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
            // lblStreamQuality
            // 
            this.lblStreamQuality.AutoSize = true;
            this.lblStreamQuality.Location = new System.Drawing.Point(146, 171);
            this.lblStreamQuality.Name = "lblStreamQuality";
            this.lblStreamQuality.Size = new System.Drawing.Size(75, 13);
            this.lblStreamQuality.TabIndex = 14;
            this.lblStreamQuality.Text = "Stream Quality";
            // 
            // cbStreamQuality
            // 
            this.cbStreamQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStreamQuality.FormattingEnabled = true;
            this.cbStreamQuality.Items.AddRange(new object[] {
            "SQTest",
            "SQ",
            "HQ"});
            this.cbStreamQuality.Location = new System.Drawing.Point(149, 187);
            this.cbStreamQuality.Name = "cbStreamQuality";
            this.cbStreamQuality.Size = new System.Drawing.Size(118, 21);
            this.cbStreamQuality.TabIndex = 7;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 331);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(389, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 15;
            this.statusStrip.Text = "statusStrip";
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
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(12, 171);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(34, 13);
            this.lblMode.TabIndex = 19;
            this.lblMode.Text = "Mode";
            // 
            // cbMode
            // 
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "Play",
            "Save",
            "Scheduled Save"});
            this.cbMode.Location = new System.Drawing.Point(12, 187);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(131, 21);
            this.cbMode.TabIndex = 6;
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // frmKoreanMinute
            // 
            this.frmKoreanMinute.Location = new System.Drawing.Point(328, 188);
            this.frmKoreanMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.frmKoreanMinute.Name = "frmKoreanMinute";
            this.frmKoreanMinute.Size = new System.Drawing.Size(49, 20);
            this.frmKoreanMinute.TabIndex = 9;
            this.frmKoreanMinute.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // frmKoreanHour
            // 
            this.frmKoreanHour.Location = new System.Drawing.Point(273, 188);
            this.frmKoreanHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.frmKoreanHour.Name = "frmKoreanHour";
            this.frmKoreanHour.Size = new System.Drawing.Size(49, 20);
            this.frmKoreanHour.TabIndex = 8;
            this.frmKoreanHour.Value = new decimal(new int[] {
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
            // gomNotifyIcon
            // 
            this.gomNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.gomNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("gomNotifyIcon.Icon")));
            this.gomNotifyIcon.Text = "GOMstreamer";
            this.gomNotifyIcon.Visible = true;
            this.gomNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gomNotifyIcon_MouseDoubleClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 353);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.frmKoreanHour);
            this.Controls.Add(this.frmKoreanMinute);
            this.Controls.Add(this.cbMode);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.lblKoreanTime);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.cbStreamQuality);
            this.Controls.Add(this.lblStreamQuality);
            this.Controls.Add(this.txtStreamURL);
            this.Controls.Add(this.lblStreamURL);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnDumpLocation);
            this.Controls.Add(this.txtDumpLocation);
            this.Controls.Add(this.lblDumpLocation);
            this.Controls.Add(this.btnVlcLocation);
            this.Controls.Add(this.txtVlcLocation);
            this.Controls.Add(this.lblVlcLocation);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.lblUserPassword);
            this.Controls.Add(this.lblEmailAddress);
            this.Controls.Add(this.txtEmailAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "GOMstreamer";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frmKoreanMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmKoreanHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Label lblUserPassword;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Label lblVlcLocation;
        private System.Windows.Forms.TextBox txtVlcLocation;
        private System.Windows.Forms.Button btnVlcLocation;
        private System.Windows.Forms.Label lblDumpLocation;
        private System.Windows.Forms.TextBox txtDumpLocation;
        private System.Windows.Forms.Button btnDumpLocation;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblStreamURL;
        private System.Windows.Forms.TextBox txtStreamURL;
        private System.Windows.Forms.Label lblStreamQuality;
        private System.Windows.Forms.ComboBox cbStreamQuality;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label lblKoreanTime;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.NumericUpDown frmKoreanMinute;
        private System.Windows.Forms.NumericUpDown frmKoreanHour;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.NotifyIcon gomNotifyIcon;
    }
}

