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
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStreamURL = new System.Windows.Forms.Label();
            this.txtStreamURL = new System.Windows.Forms.TextBox();
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
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(198, 223);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(179, 50);
            this.btnPlay.TabIndex = 7;
            this.btnPlay.Text = "Play stream";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 223);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 50);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save stream";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStreamURL
            // 
            this.lblStreamURL.AutoSize = true;
            this.lblStreamURL.Location = new System.Drawing.Point(12, 172);
            this.lblStreamURL.Name = "lblStreamURL";
            this.lblStreamURL.Size = new System.Drawing.Size(65, 13);
            this.lblStreamURL.TabIndex = 13;
            this.lblStreamURL.Text = "Stream URL";
            // 
            // txtStreamURL
            // 
            this.txtStreamURL.Location = new System.Drawing.Point(15, 188);
            this.txtStreamURL.Name = "txtStreamURL";
            this.txtStreamURL.Size = new System.Drawing.Size(362, 20);
            this.txtStreamURL.TabIndex = 8;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 285);
            this.Controls.Add(this.txtStreamURL);
            this.Controls.Add(this.lblStreamURL);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPlay);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "GOMstreamer";
            this.Load += new System.EventHandler(this.MainWindow_Load);
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
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblStreamURL;
        private System.Windows.Forms.TextBox txtStreamURL;
    }
}

