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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGHLink = new System.Windows.Forms.LinkLabel();
            this.lblsjp = new System.Windows.Forms.LinkLabel();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblVersionTxt
            // 
            this.lblVersionTxt.AutoSize = true;
            this.lblVersionTxt.Location = new System.Drawing.Point(12, 9);
            this.lblVersionTxt.Name = "lblVersionTxt";
            this.lblVersionTxt.Size = new System.Drawing.Size(105, 13);
            this.lblVersionTxt.TabIndex = 0;
            this.lblVersionTxt.Text = "GOMstreamer v0.7.0";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 12, 12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Documentation is available at:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "The source code is available on GitHub at: ";
            // 
            // lblGHLink
            // 
            this.lblGHLink.AutoSize = true;
            this.lblGHLink.Location = new System.Drawing.Point(216, 86);
            this.lblGHLink.Name = "lblGHLink";
            this.lblGHLink.Size = new System.Drawing.Size(115, 13);
            this.lblGHLink.TabIndex = 4;
            this.lblGHLink.TabStop = true;
            this.lblGHLink.Text = "sjp/GOMstreamer.NET";
            this.lblGHLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblGHLink_LinkClicked);
            // 
            // lblsjp
            // 
            this.lblsjp.AutoSize = true;
            this.lblsjp.Location = new System.Drawing.Point(157, 61);
            this.lblsjp.Name = "lblsjp";
            this.lblsjp.Size = new System.Drawing.Size(192, 13);
            this.lblsjp.TabIndex = 5;
            this.lblsjp.TabStop = true;
            this.lblsjp.Text = "http://sjp.co.nz/projects/gomstreamer/";
            this.lblsjp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblsjp_LinkClicked);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(277, 126);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 25;
            this.okButton.Text = "&OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 161);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.lblsjp);
            this.Controls.Add(this.lblGHLink);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lblGHLink;
        private System.Windows.Forms.LinkLabel lblsjp;
        private System.Windows.Forms.Button okButton;

    }
}
