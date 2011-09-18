namespace GOMstreamer
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.lblVersionTxt = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblDocumentation = new System.Windows.Forms.Label();
            this.lblGithub = new System.Windows.Forms.Label();
            this.linkGithub = new System.Windows.Forms.LinkLabel();
            this.linkSjp = new System.Windows.Forms.LinkLabel();
            this.btnOkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblVersionTxt
            // 
            this.lblVersionTxt.AutoSize = true;
            this.lblVersionTxt.Location = new System.Drawing.Point(12, 9);
            this.lblVersionTxt.Name = "lblVersionTxt";
            this.lblVersionTxt.Size = new System.Drawing.Size(105, 13);
            this.lblVersionTxt.TabIndex = 0;
            this.lblVersionTxt.Text = "GOMstreamer v0.7.1";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(12, 34);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(12);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(150, 13);
            this.lblCopyright.TabIndex = 1;
            this.lblCopyright.Text = "Copyright ©2011 Simon Potter";
            // 
            // lblDocumentation
            // 
            this.lblDocumentation.AutoSize = true;
            this.lblDocumentation.Location = new System.Drawing.Point(12, 61);
            this.lblDocumentation.Margin = new System.Windows.Forms.Padding(0, 12, 12, 12);
            this.lblDocumentation.Name = "lblDocumentation";
            this.lblDocumentation.Size = new System.Drawing.Size(149, 13);
            this.lblDocumentation.TabIndex = 2;
            this.lblDocumentation.Text = "Documentation is available at:";
            // 
            // lblGithub
            // 
            this.lblGithub.AutoSize = true;
            this.lblGithub.Location = new System.Drawing.Point(12, 86);
            this.lblGithub.Name = "lblGithub";
            this.lblGithub.Size = new System.Drawing.Size(212, 13);
            this.lblGithub.TabIndex = 3;
            this.lblGithub.Text = "The source code is available on GitHub at: ";
            // 
            // linkGithub
            // 
            this.linkGithub.AutoSize = true;
            this.linkGithub.Location = new System.Drawing.Point(216, 86);
            this.linkGithub.Name = "linkGithub";
            this.linkGithub.Size = new System.Drawing.Size(115, 13);
            this.linkGithub.TabIndex = 4;
            this.linkGithub.TabStop = true;
            this.linkGithub.Text = "sjp/GOMstreamer.NET";
            this.linkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblGHLink_LinkClicked);
            // 
            // linkSjp
            // 
            this.linkSjp.AutoSize = true;
            this.linkSjp.Location = new System.Drawing.Point(157, 61);
            this.linkSjp.Name = "linkSjp";
            this.linkSjp.Size = new System.Drawing.Size(192, 13);
            this.linkSjp.TabIndex = 5;
            this.linkSjp.TabStop = true;
            this.linkSjp.Text = "http://sjp.co.nz/projects/gomstreamer/";
            this.linkSjp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblsjp_LinkClicked);
            // 
            // btnOkButton
            // 
            this.btnOkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOkButton.Location = new System.Drawing.Point(277, 126);
            this.btnOkButton.Name = "btnOkButton";
            this.btnOkButton.Size = new System.Drawing.Size(75, 23);
            this.btnOkButton.TabIndex = 25;
            this.btnOkButton.Text = "&OK";
            this.btnOkButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 161);
            this.Controls.Add(this.btnOkButton);
            this.Controls.Add(this.linkSjp);
            this.Controls.Add(this.linkGithub);
            this.Controls.Add(this.lblGithub);
            this.Controls.Add(this.lblDocumentation);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblVersionTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About GOMstreamer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersionTxt;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblDocumentation;
        private System.Windows.Forms.Label lblGithub;
        private System.Windows.Forms.LinkLabel linkGithub;
        private System.Windows.Forms.LinkLabel linkSjp;
        private System.Windows.Forms.Button btnOkButton;

    }
}
