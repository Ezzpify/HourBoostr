namespace SingleBoostr
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.listGames = new System.Windows.Forms.ListBox();
            this.lblGameCounter = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.listGamesSelected = new System.Windows.Forms.ListBox();
            this.btnBoost = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblSelectedGameCounter = new System.Windows.Forms.Label();
            this.panelLaunch = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelLaunchPadder = new System.Windows.Forms.Panel();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.gameListWorker = new System.ComponentModel.BackgroundWorker();
            this.btnPauseTimer = new System.Windows.Forms.Timer(this.components);
            this.panelWarning = new System.Windows.Forms.Panel();
            this.btnTosNo = new System.Windows.Forms.Button();
            this.btnTosYes = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelRunning = new System.Windows.Forms.Panel();
            this.listGamesActive = new System.Windows.Forms.ListBox();
            this.lblActiveGames = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStopBoost = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelLaunch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.panelWarning.SuspendLayout();
            this.panelRunning.SuspendLayout();
            this.SuspendLayout();
            // 
            // listGames
            // 
            this.listGames.FormattingEnabled = true;
            this.listGames.IntegralHeight = false;
            this.listGames.ItemHeight = 15;
            this.listGames.Location = new System.Drawing.Point(12, 56);
            this.listGames.Name = "listGames";
            this.listGames.Size = new System.Drawing.Size(250, 193);
            this.listGames.TabIndex = 0;
            this.listGames.SelectedIndexChanged += new System.EventHandler(this.listGames_SelectedIndexChanged);
            // 
            // lblGameCounter
            // 
            this.lblGameCounter.AutoSize = true;
            this.lblGameCounter.Location = new System.Drawing.Point(9, 9);
            this.lblGameCounter.Name = "lblGameCounter";
            this.lblGameCounter.Size = new System.Drawing.Size(143, 15);
            this.lblGameCounter.TabIndex = 1;
            this.lblGameCounter.Text = "GAMES_COUNTER_LABEL";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 23);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // listGamesSelected
            // 
            this.listGamesSelected.FormattingEnabled = true;
            this.listGamesSelected.IntegralHeight = false;
            this.listGamesSelected.ItemHeight = 15;
            this.listGamesSelected.Location = new System.Drawing.Point(268, 27);
            this.listGamesSelected.Name = "listGamesSelected";
            this.listGamesSelected.Size = new System.Drawing.Size(254, 169);
            this.listGamesSelected.TabIndex = 3;
            this.listGamesSelected.SelectedIndexChanged += new System.EventHandler(this.listGamesSelected_SelectedIndexChanged);
            // 
            // btnBoost
            // 
            this.btnBoost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBoost.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnBoost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoost.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnBoost.Location = new System.Drawing.Point(268, 202);
            this.btnBoost.Name = "btnBoost";
            this.btnBoost.Size = new System.Drawing.Size(254, 47);
            this.btnBoost.TabIndex = 4;
            this.btnBoost.Text = "START";
            this.btnBoost.UseVisualStyleBackColor = true;
            this.btnBoost.Click += new System.EventHandler(this.btnBoost_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblSelectedGameCounter);
            this.panelMain.Controls.Add(this.btnBoost);
            this.panelMain.Controls.Add(this.listGamesSelected);
            this.panelMain.Controls.Add(this.txtSearch);
            this.panelMain.Controls.Add(this.lblGameCounter);
            this.panelMain.Controls.Add(this.listGames);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(538, 261);
            this.panelMain.TabIndex = 5;
            this.panelMain.Visible = false;
            // 
            // lblSelectedGameCounter
            // 
            this.lblSelectedGameCounter.AutoSize = true;
            this.lblSelectedGameCounter.Location = new System.Drawing.Point(265, 9);
            this.lblSelectedGameCounter.Name = "lblSelectedGameCounter";
            this.lblSelectedGameCounter.Size = new System.Drawing.Size(201, 15);
            this.lblSelectedGameCounter.TabIndex = 5;
            this.lblSelectedGameCounter.Text = "SELECTED_GAMES_COUNTER_LABEL";
            // 
            // panelLaunch
            // 
            this.panelLaunch.Controls.Add(this.lblStatus);
            this.panelLaunch.Controls.Add(this.panelLaunchPadder);
            this.panelLaunch.Controls.Add(this.picLoading);
            this.panelLaunch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLaunch.Location = new System.Drawing.Point(0, 0);
            this.panelLaunch.Name = "panelLaunch";
            this.panelLaunch.Size = new System.Drawing.Size(538, 261);
            this.panelLaunch.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Location = new System.Drawing.Point(0, 112);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(538, 15);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLaunchPadder
            // 
            this.panelLaunchPadder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLaunchPadder.Location = new System.Drawing.Point(0, 0);
            this.panelLaunchPadder.Name = "panelLaunchPadder";
            this.panelLaunchPadder.Size = new System.Drawing.Size(538, 112);
            this.panelLaunchPadder.TabIndex = 8;
            // 
            // picLoading
            // 
            this.picLoading.Image = ((System.Drawing.Image)(resources.GetObject("picLoading.Image")));
            this.picLoading.Location = new System.Drawing.Point(227, 88);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(68, 68);
            this.picLoading.TabIndex = 6;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // gameListWorker
            // 
            this.gameListWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.gameListWorker_DoWork);
            this.gameListWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.gameListWorker_RunWorkerCompleted);
            // 
            // btnPauseTimer
            // 
            this.btnPauseTimer.Interval = 5000;
            this.btnPauseTimer.Tick += new System.EventHandler(this.btnPauseTimer_Tick);
            // 
            // panelWarning
            // 
            this.panelWarning.Controls.Add(this.btnTosNo);
            this.panelWarning.Controls.Add(this.btnTosYes);
            this.panelWarning.Controls.Add(this.label7);
            this.panelWarning.Controls.Add(this.label6);
            this.panelWarning.Controls.Add(this.label5);
            this.panelWarning.Controls.Add(this.label4);
            this.panelWarning.Controls.Add(this.label3);
            this.panelWarning.Controls.Add(this.label2);
            this.panelWarning.Controls.Add(this.label1);
            this.panelWarning.Controls.Add(this.panel2);
            this.panelWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWarning.Location = new System.Drawing.Point(0, 0);
            this.panelWarning.Name = "panelWarning";
            this.panelWarning.Size = new System.Drawing.Size(538, 261);
            this.panelWarning.TabIndex = 9;
            // 
            // btnTosNo
            // 
            this.btnTosNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTosNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTosNo.Location = new System.Drawing.Point(313, 188);
            this.btnTosNo.Name = "btnTosNo";
            this.btnTosNo.Size = new System.Drawing.Size(75, 23);
            this.btnTosNo.TabIndex = 15;
            this.btnTosNo.Text = "No";
            this.btnTosNo.UseVisualStyleBackColor = true;
            this.btnTosNo.Click += new System.EventHandler(this.btnTosNo_Click);
            // 
            // btnTosYes
            // 
            this.btnTosYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTosYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTosYes.Location = new System.Drawing.Point(152, 188);
            this.btnTosYes.Name = "btnTosYes";
            this.btnTosYes.Size = new System.Drawing.Size(75, 23);
            this.btnTosYes.TabIndex = 16;
            this.btnTosYes.Text = "Yes";
            this.btnTosYes.UseVisualStyleBackColor = true;
            this.btnTosYes.Click += new System.EventHandler(this.btnTosYes_Click);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(538, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Do you understand this?";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(538, 15);
            this.label6.TabIndex = 13;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(538, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "I hope you\'re smart enough to not cheat in games and then blame it on this progra" +
    "m or me.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(538, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "However, I will take no responsibility if for any reason your account gets VAC ba" +
    "nned.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(538, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "This program will not cause your account to be VAC banned";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(538, 15);
            this.label2.TabIndex = 9;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(538, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Just a casual warning before you start";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(538, 50);
            this.panel2.TabIndex = 8;
            // 
            // panelRunning
            // 
            this.panelRunning.Controls.Add(this.listGamesActive);
            this.panelRunning.Controls.Add(this.lblActiveGames);
            this.panelRunning.Controls.Add(this.panel1);
            this.panelRunning.Controls.Add(this.btnStopBoost);
            this.panelRunning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRunning.Location = new System.Drawing.Point(0, 0);
            this.panelRunning.Name = "panelRunning";
            this.panelRunning.Size = new System.Drawing.Size(538, 261);
            this.panelRunning.TabIndex = 6;
            this.panelRunning.Visible = false;
            // 
            // listGamesActive
            // 
            this.listGamesActive.Enabled = false;
            this.listGamesActive.FormattingEnabled = true;
            this.listGamesActive.IntegralHeight = false;
            this.listGamesActive.ItemHeight = 15;
            this.listGamesActive.Location = new System.Drawing.Point(143, 62);
            this.listGamesActive.Name = "listGamesActive";
            this.listGamesActive.Size = new System.Drawing.Size(254, 84);
            this.listGamesActive.TabIndex = 11;
            // 
            // lblActiveGames
            // 
            this.lblActiveGames.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblActiveGames.Location = new System.Drawing.Point(0, 44);
            this.lblActiveGames.Name = "lblActiveGames";
            this.lblActiveGames.Size = new System.Drawing.Size(538, 15);
            this.lblActiveGames.TabIndex = 10;
            this.lblActiveGames.Text = "You\'re currently idling n games";
            this.lblActiveGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 44);
            this.panel1.TabIndex = 9;
            // 
            // btnStopBoost
            // 
            this.btnStopBoost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopBoost.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnStopBoost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopBoost.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnStopBoost.Location = new System.Drawing.Point(143, 152);
            this.btnStopBoost.Name = "btnStopBoost";
            this.btnStopBoost.Size = new System.Drawing.Size(254, 47);
            this.btnStopBoost.TabIndex = 5;
            this.btnStopBoost.Text = "STOP";
            this.btnStopBoost.UseVisualStyleBackColor = true;
            this.btnStopBoost.Click += new System.EventHandler(this.btnStopBoost_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(538, 261);
            this.Controls.Add(this.panelRunning);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelWarning);
            this.Controls.Add(this.panelLaunch);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.Gray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(550, 300);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SingleBoostr :: Terms of Service";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelLaunch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.panelWarning.ResumeLayout(false);
            this.panelRunning.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listGames;
        private System.Windows.Forms.Label lblGameCounter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListBox listGamesSelected;
        private System.Windows.Forms.Button btnBoost;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelLaunch;
        private System.Windows.Forms.PictureBox picLoading;
        private System.ComponentModel.BackgroundWorker gameListWorker;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelLaunchPadder;
        private System.Windows.Forms.Label lblSelectedGameCounter;
        private System.Windows.Forms.Timer btnPauseTimer;
        private System.Windows.Forms.Panel panelWarning;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTosYes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTosNo;
        private System.Windows.Forms.Panel panelRunning;
        private System.Windows.Forms.Label lblActiveGames;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStopBoost;
        private System.Windows.Forms.ListBox listGamesActive;
    }
}

