namespace SingleBoostr
{
    partial class BrowserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this.WebBrowser = new System.Windows.Forms.WebBrowser();
            this.PicLoading = new System.Windows.Forms.PictureBox();
            this.PanelUserPicGoBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelUserPicGoBack)).BeginInit();
            this.SuspendLayout();
            // 
            // WebBrowser
            // 
            this.WebBrowser.AllowWebBrowserDrop = false;
            this.WebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebBrowser.Location = new System.Drawing.Point(1, 1);
            this.WebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowser.Name = "WebBrowser";
            this.WebBrowser.ScriptErrorsSuppressed = true;
            this.WebBrowser.ScrollBarsEnabled = false;
            this.WebBrowser.Size = new System.Drawing.Size(898, 438);
            this.WebBrowser.TabIndex = 9;
            this.WebBrowser.Visible = false;
            this.WebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser_DocumentCompleted);
            this.WebBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.WebBrowser_Navigating);
            // 
            // PicLoading
            // 
            this.PicLoading.BackgroundImage = global::SingleBoostr.Properties.Resources.Load;
            this.PicLoading.Location = new System.Drawing.Point(143, 40);
            this.PicLoading.Name = "PicLoading";
            this.PicLoading.Size = new System.Drawing.Size(600, 350);
            this.PicLoading.TabIndex = 10;
            this.PicLoading.TabStop = false;
            // 
            // PanelUserPicGoBack
            // 
            this.PanelUserPicGoBack.BackgroundImage = global::SingleBoostr.Properties.Resources.Back;
            this.PanelUserPicGoBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PanelUserPicGoBack.Location = new System.Drawing.Point(12, 12);
            this.PanelUserPicGoBack.Name = "PanelUserPicGoBack";
            this.PanelUserPicGoBack.Size = new System.Drawing.Size(20, 48);
            this.PanelUserPicGoBack.TabIndex = 15;
            this.PanelUserPicGoBack.TabStop = false;
            this.PanelUserPicGoBack.Click += new System.EventHandler(this.PanelUserPicGoBack_Click);
            this.PanelUserPicGoBack.MouseEnter += new System.EventHandler(this.PanelUserPicGoBack_MouseEnter);
            this.PanelUserPicGoBack.MouseLeave += new System.EventHandler(this.PanelUserPicGoBack_MouseLeave);
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(900, 440);
            this.Controls.Add(this.PanelUserPicGoBack);
            this.Controls.Add(this.WebBrowser);
            this.Controls.Add(this.PicLoading);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BrowserForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign in";
            this.Load += new System.EventHandler(this.BrowserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelUserPicGoBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WebBrowser;
        private System.Windows.Forms.PictureBox PicLoading;
        private System.Windows.Forms.PictureBox PanelUserPicGoBack;
    }
}