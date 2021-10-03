namespace SingleBoostr.Ui
{
    partial class AppDonate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppDonate));
            this.picGif = new System.Windows.Forms.PictureBox();
            this.picGoBack = new System.Windows.Forms.PictureBox();
            this.TxtBtcAdress = new System.Windows.Forms.RichTextBox();
            this.PanelBitcoin = new System.Windows.Forms.Panel();
            this.PanelBitcoinContent = new System.Windows.Forms.Panel();
            this.PicBitcoinSpacer = new System.Windows.Forms.PictureBox();
            this.PanelBitcoinPicture = new System.Windows.Forms.Panel();
            this.PicBitcoin = new System.Windows.Forms.PictureBox();
            this.PanelPaypal = new System.Windows.Forms.Panel();
            this.PanelPaypalContent = new System.Windows.Forms.Panel();
            this.LblPaypalLink = new System.Windows.Forms.Label();
            this.PicPaypalSpacer = new System.Windows.Forms.PictureBox();
            this.PanelPaypalPicture = new System.Windows.Forms.Panel();
            this.PicPaypal = new System.Windows.Forms.PictureBox();
            this.BgwGetInfo = new System.ComponentModel.BackgroundWorker();
            this.LblLoadingNotice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGoBack)).BeginInit();
            this.PanelBitcoin.SuspendLayout();
            this.PanelBitcoinContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBitcoinSpacer)).BeginInit();
            this.PanelBitcoinPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBitcoin)).BeginInit();
            this.PanelPaypal.SuspendLayout();
            this.PanelPaypalContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPaypalSpacer)).BeginInit();
            this.PanelPaypalPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPaypal)).BeginInit();
            this.SuspendLayout();
            // 
            // picGif
            // 
            this.picGif.Location = new System.Drawing.Point(60, 12);
            this.picGif.Name = "picGif";
            this.picGif.Size = new System.Drawing.Size(346, 21);
            this.picGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picGif.TabIndex = 0;
            this.picGif.TabStop = false;
            // 
            // picGoBack
            // 
            this.picGoBack.BackgroundImage = global::SingleBoostr.Properties.Resources.Back;
            this.picGoBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picGoBack.Location = new System.Drawing.Point(12, 12);
            this.picGoBack.Name = "picGoBack";
            this.picGoBack.Size = new System.Drawing.Size(20, 48);
            this.picGoBack.TabIndex = 17;
            this.picGoBack.TabStop = false;
            this.picGoBack.Click += new System.EventHandler(this.picGoBack_Click);
            this.picGoBack.MouseEnter += new System.EventHandler(this.picGoBack_MouseEnter);
            this.picGoBack.MouseLeave += new System.EventHandler(this.picGoBack_MouseLeave);
            // 
            // TxtBtcAdress
            // 
            this.TxtBtcAdress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.TxtBtcAdress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtBtcAdress.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtBtcAdress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.TxtBtcAdress.Location = new System.Drawing.Point(0, 8);
            this.TxtBtcAdress.Multiline = false;
            this.TxtBtcAdress.Name = "TxtBtcAdress";
            this.TxtBtcAdress.ReadOnly = true;
            this.TxtBtcAdress.Size = new System.Drawing.Size(311, 27);
            this.TxtBtcAdress.TabIndex = 37;
            this.TxtBtcAdress.Text = "";
            // 
            // PanelBitcoin
            // 
            this.PanelBitcoin.Controls.Add(this.PanelBitcoinContent);
            this.PanelBitcoin.Controls.Add(this.PanelBitcoinPicture);
            this.PanelBitcoin.Location = new System.Drawing.Point(60, 36);
            this.PanelBitcoin.Name = "PanelBitcoin";
            this.PanelBitcoin.Size = new System.Drawing.Size(346, 35);
            this.PanelBitcoin.TabIndex = 38;
            this.PanelBitcoin.Visible = false;
            // 
            // PanelBitcoinContent
            // 
            this.PanelBitcoinContent.Controls.Add(this.TxtBtcAdress);
            this.PanelBitcoinContent.Controls.Add(this.PicBitcoinSpacer);
            this.PanelBitcoinContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBitcoinContent.Location = new System.Drawing.Point(35, 0);
            this.PanelBitcoinContent.Name = "PanelBitcoinContent";
            this.PanelBitcoinContent.Size = new System.Drawing.Size(311, 35);
            this.PanelBitcoinContent.TabIndex = 40;
            // 
            // PicBitcoinSpacer
            // 
            this.PicBitcoinSpacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.PicBitcoinSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.PicBitcoinSpacer.Location = new System.Drawing.Point(0, 0);
            this.PicBitcoinSpacer.Name = "PicBitcoinSpacer";
            this.PicBitcoinSpacer.Size = new System.Drawing.Size(311, 8);
            this.PicBitcoinSpacer.TabIndex = 38;
            this.PicBitcoinSpacer.TabStop = false;
            // 
            // PanelBitcoinPicture
            // 
            this.PanelBitcoinPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.PanelBitcoinPicture.Controls.Add(this.PicBitcoin);
            this.PanelBitcoinPicture.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelBitcoinPicture.Location = new System.Drawing.Point(0, 0);
            this.PanelBitcoinPicture.Name = "PanelBitcoinPicture";
            this.PanelBitcoinPicture.Size = new System.Drawing.Size(35, 35);
            this.PanelBitcoinPicture.TabIndex = 39;
            // 
            // PicBitcoin
            // 
            this.PicBitcoin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicBitcoin.Image = ((System.Drawing.Image)(resources.GetObject("PicBitcoin.Image")));
            this.PicBitcoin.Location = new System.Drawing.Point(0, 0);
            this.PicBitcoin.Name = "PicBitcoin";
            this.PicBitcoin.Size = new System.Drawing.Size(35, 35);
            this.PicBitcoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PicBitcoin.TabIndex = 0;
            this.PicBitcoin.TabStop = false;
            // 
            // PanelPaypal
            // 
            this.PanelPaypal.Controls.Add(this.PanelPaypalContent);
            this.PanelPaypal.Controls.Add(this.PanelPaypalPicture);
            this.PanelPaypal.Location = new System.Drawing.Point(60, 77);
            this.PanelPaypal.Name = "PanelPaypal";
            this.PanelPaypal.Size = new System.Drawing.Size(346, 35);
            this.PanelPaypal.TabIndex = 41;
            this.PanelPaypal.Visible = false;
            // 
            // PanelPaypalContent
            // 
            this.PanelPaypalContent.Controls.Add(this.LblPaypalLink);
            this.PanelPaypalContent.Controls.Add(this.PicPaypalSpacer);
            this.PanelPaypalContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPaypalContent.Location = new System.Drawing.Point(35, 0);
            this.PanelPaypalContent.Name = "PanelPaypalContent";
            this.PanelPaypalContent.Size = new System.Drawing.Size(311, 35);
            this.PanelPaypalContent.TabIndex = 40;
            // 
            // LblPaypalLink
            // 
            this.LblPaypalLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.LblPaypalLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblPaypalLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPaypalLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.LblPaypalLink.Location = new System.Drawing.Point(0, 6);
            this.LblPaypalLink.Name = "LblPaypalLink";
            this.LblPaypalLink.Size = new System.Drawing.Size(311, 29);
            this.LblPaypalLink.TabIndex = 39;
            this.LblPaypalLink.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LblPaypalLink.Click += new System.EventHandler(this.LblPaypalLink_Click);
            this.LblPaypalLink.MouseEnter += new System.EventHandler(this.LblPaypalLink_MouseEnter);
            this.LblPaypalLink.MouseLeave += new System.EventHandler(this.LblPaypalLink_MouseLeave);
            // 
            // PicPaypalSpacer
            // 
            this.PicPaypalSpacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.PicPaypalSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.PicPaypalSpacer.Location = new System.Drawing.Point(0, 0);
            this.PicPaypalSpacer.Name = "PicPaypalSpacer";
            this.PicPaypalSpacer.Size = new System.Drawing.Size(311, 6);
            this.PicPaypalSpacer.TabIndex = 38;
            this.PicPaypalSpacer.TabStop = false;
            // 
            // PanelPaypalPicture
            // 
            this.PanelPaypalPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.PanelPaypalPicture.Controls.Add(this.PicPaypal);
            this.PanelPaypalPicture.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelPaypalPicture.Location = new System.Drawing.Point(0, 0);
            this.PanelPaypalPicture.Name = "PanelPaypalPicture";
            this.PanelPaypalPicture.Size = new System.Drawing.Size(35, 35);
            this.PanelPaypalPicture.TabIndex = 39;
            // 
            // PicPaypal
            // 
            this.PicPaypal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicPaypal.Image = ((System.Drawing.Image)(resources.GetObject("PicPaypal.Image")));
            this.PicPaypal.Location = new System.Drawing.Point(0, 0);
            this.PicPaypal.Name = "PicPaypal";
            this.PicPaypal.Size = new System.Drawing.Size(35, 35);
            this.PicPaypal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PicPaypal.TabIndex = 0;
            this.PicPaypal.TabStop = false;
            // 
            // BgwGetInfo
            // 
            this.BgwGetInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwGetInfo_DoWork);
            this.BgwGetInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwGetInfo_RunWorkerCompleted);
            // 
            // LblLoadingNotice
            // 
            this.LblLoadingNotice.AutoSize = true;
            this.LblLoadingNotice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.LblLoadingNotice.Location = new System.Drawing.Point(160, 12);
            this.LblLoadingNotice.Name = "LblLoadingNotice";
            this.LblLoadingNotice.Size = new System.Drawing.Size(149, 17);
            this.LblLoadingNotice.TabIndex = 42;
            this.LblLoadingNotice.Text = "Loading donation links...";
            // 
            // DonateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(443, 146);
            this.Controls.Add(this.LblLoadingNotice);
            this.Controls.Add(this.PanelBitcoin);
            this.Controls.Add(this.PanelPaypal);
            this.Controls.Add(this.picGoBack);
            this.Controls.Add(this.picGif);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DonateForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Donate";
            this.Load += new System.EventHandler(this.DonateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGoBack)).EndInit();
            this.PanelBitcoin.ResumeLayout(false);
            this.PanelBitcoinContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBitcoinSpacer)).EndInit();
            this.PanelBitcoinPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBitcoin)).EndInit();
            this.PanelPaypal.ResumeLayout(false);
            this.PanelPaypalContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicPaypalSpacer)).EndInit();
            this.PanelPaypalPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicPaypal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGif;
        private System.Windows.Forms.PictureBox picGoBack;
        private System.Windows.Forms.RichTextBox TxtBtcAdress;
        private System.Windows.Forms.Panel PanelBitcoin;
        private System.Windows.Forms.PictureBox PicBitcoinSpacer;
        private System.Windows.Forms.Panel PanelBitcoinContent;
        private System.Windows.Forms.Panel PanelBitcoinPicture;
        private System.Windows.Forms.PictureBox PicBitcoin;
        private System.Windows.Forms.Panel PanelPaypal;
        private System.Windows.Forms.Panel PanelPaypalContent;
        private System.Windows.Forms.PictureBox PicPaypalSpacer;
        private System.Windows.Forms.Panel PanelPaypalPicture;
        private System.Windows.Forms.PictureBox PicPaypal;
        private System.Windows.Forms.Label LblPaypalLink;
        private System.ComponentModel.BackgroundWorker BgwGetInfo;
        private System.Windows.Forms.Label LblLoadingNotice;
    }
}