namespace SingleBoostr
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.PanelFooter = new System.Windows.Forms.Panel();
            this.BtnClose = new System.Windows.Forms.PictureBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.LblClearBlackList = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NumGamesIdleWhenNoCards = new System.Windows.Forms.NumericUpDown();
            this.LblDownloadNewAppList = new System.Windows.Forms.Label();
            this.CbIdleCardsWithMostValue = new System.Windows.Forms.CheckBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.NumOnlyIdleGamesWithCertainMinutes = new System.Windows.Forms.NumericUpDown();
            this.CbOnlyIdleGamesWithCertainMinutes = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CbSaveLoginCookies = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.CbJoinSteamGroup = new System.Windows.Forms.CheckBox();
            this.CbSaveAppIdleHistory = new System.Windows.Forms.CheckBox();
            this.CbClearRecentlyPlayed = new System.Windows.Forms.CheckBox();
            this.CbCheckForUpdates = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.CbRestartGamesRandomly = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NumRestartGamesMinutes = new System.Windows.Forms.NumericUpDown();
            this.CbRestartGames = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NumWaitBetweenReplies = new System.Windows.Forms.NumericUpDown();
            this.CbWaitBetweenReplies = new System.Windows.Forms.CheckBox();
            this.CbOnlyReplyIfIdling = new System.Windows.Forms.CheckBox();
            this.TxtChatResponses = new System.Windows.Forms.RichTextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.CbEnableChatResponse = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).BeginInit();
            this.PanelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumGamesIdleWhenNoCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOnlyIdleGamesWithCertainMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumRestartGamesMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWaitBetweenReplies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelFooter
            // 
            this.PanelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.PanelFooter.Controls.Add(this.BtnClose);
            this.PanelFooter.Controls.Add(this.BtnSave);
            this.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelFooter.Location = new System.Drawing.Point(1, 429);
            this.PanelFooter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PanelFooter.Name = "PanelFooter";
            this.PanelFooter.Size = new System.Drawing.Size(348, 70);
            this.PanelFooter.TabIndex = 2;
            // 
            // BtnClose
            // 
            this.BtnClose.BackgroundImage = global::SingleBoostr.Properties.Resources.Back;
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Location = new System.Drawing.Point(29, 10);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(20, 48);
            this.BtnClose.TabIndex = 66;
            this.BtnClose.TabStop = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.BtnClose.MouseEnter += new System.EventHandler(this.BtnClose_MouseEnter);
            this.BtnClose.MouseLeave += new System.EventHandler(this.BtnClose_MouseLeave);
            // 
            // BtnSave
            // 
            this.BtnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSave.BackgroundImage")));
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(55, 10);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(265, 48);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "Save Settings";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.BtnSave.MouseEnter += new System.EventHandler(this.BtnSave_MouseEnter);
            this.BtnSave.MouseLeave += new System.EventHandler(this.BtnSave_MouseLeave);
            // 
            // PanelContainer
            // 
            this.PanelContainer.AutoScroll = true;
            this.PanelContainer.Controls.Add(this.LblClearBlackList);
            this.PanelContainer.Controls.Add(this.label8);
            this.PanelContainer.Controls.Add(this.NumGamesIdleWhenNoCards);
            this.PanelContainer.Controls.Add(this.LblDownloadNewAppList);
            this.PanelContainer.Controls.Add(this.CbIdleCardsWithMostValue);
            this.PanelContainer.Controls.Add(this.pictureBox8);
            this.PanelContainer.Controls.Add(this.label7);
            this.PanelContainer.Controls.Add(this.pictureBox6);
            this.PanelContainer.Controls.Add(this.NumOnlyIdleGamesWithCertainMinutes);
            this.PanelContainer.Controls.Add(this.CbOnlyIdleGamesWithCertainMinutes);
            this.PanelContainer.Controls.Add(this.label6);
            this.PanelContainer.Controls.Add(this.CbSaveLoginCookies);
            this.PanelContainer.Controls.Add(this.label5);
            this.PanelContainer.Controls.Add(this.pictureBox5);
            this.PanelContainer.Controls.Add(this.pictureBox4);
            this.PanelContainer.Controls.Add(this.CbJoinSteamGroup);
            this.PanelContainer.Controls.Add(this.CbSaveAppIdleHistory);
            this.PanelContainer.Controls.Add(this.CbClearRecentlyPlayed);
            this.PanelContainer.Controls.Add(this.CbCheckForUpdates);
            this.PanelContainer.Controls.Add(this.label4);
            this.PanelContainer.Controls.Add(this.pictureBox3);
            this.PanelContainer.Controls.Add(this.CbRestartGamesRandomly);
            this.PanelContainer.Controls.Add(this.label3);
            this.PanelContainer.Controls.Add(this.NumRestartGamesMinutes);
            this.PanelContainer.Controls.Add(this.CbRestartGames);
            this.PanelContainer.Controls.Add(this.label2);
            this.PanelContainer.Controls.Add(this.pictureBox2);
            this.PanelContainer.Controls.Add(this.pictureBox1);
            this.PanelContainer.Controls.Add(this.NumWaitBetweenReplies);
            this.PanelContainer.Controls.Add(this.CbWaitBetweenReplies);
            this.PanelContainer.Controls.Add(this.CbOnlyReplyIfIdling);
            this.PanelContainer.Controls.Add(this.TxtChatResponses);
            this.PanelContainer.Controls.Add(this.pictureBox7);
            this.PanelContainer.Controls.Add(this.CbEnableChatResponse);
            this.PanelContainer.Controls.Add(this.label1);
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.PanelContainer.Location = new System.Drawing.Point(1, 1);
            this.PanelContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(348, 428);
            this.PanelContainer.TabIndex = 3;
            this.PanelContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelContainer_MouseDown);
            // 
            // LblClearBlackList
            // 
            this.LblClearBlackList.AutoSize = true;
            this.LblClearBlackList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblClearBlackList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblClearBlackList.Location = new System.Drawing.Point(14, 941);
            this.LblClearBlackList.Name = "LblClearBlackList";
            this.LblClearBlackList.Size = new System.Drawing.Size(150, 17);
            this.LblClearBlackList.TabIndex = 72;
            this.LblClearBlackList.Text = "Clear 0 blacklisted cards";
            this.LblClearBlackList.Click += new System.EventHandler(this.LblClearBlackList_Click);
            this.LblClearBlackList.MouseEnter += new System.EventHandler(this.LblClearBlackList_MouseEnter);
            this.LblClearBlackList.MouseLeave += new System.EventHandler(this.LblClearBlackList_MouseLeave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(133, 870);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 17);
            this.label8.TabIndex = 71;
            this.label8.Text = "games when no cards available";
            // 
            // NumGamesIdleWhenNoCards
            // 
            this.NumGamesIdleWhenNoCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.NumGamesIdleWhenNoCards.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumGamesIdleWhenNoCards.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NumGamesIdleWhenNoCards.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.NumGamesIdleWhenNoCards.Location = new System.Drawing.Point(48, 870);
            this.NumGamesIdleWhenNoCards.Maximum = new decimal(new int[] {
            33,
            0,
            0,
            0});
            this.NumGamesIdleWhenNoCards.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumGamesIdleWhenNoCards.Name = "NumGamesIdleWhenNoCards";
            this.NumGamesIdleWhenNoCards.Size = new System.Drawing.Size(79, 21);
            this.NumGamesIdleWhenNoCards.TabIndex = 70;
            this.NumGamesIdleWhenNoCards.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // LblDownloadNewAppList
            // 
            this.LblDownloadNewAppList.AutoSize = true;
            this.LblDownloadNewAppList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblDownloadNewAppList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDownloadNewAppList.Location = new System.Drawing.Point(14, 703);
            this.LblDownloadNewAppList.Name = "LblDownloadNewAppList";
            this.LblDownloadNewAppList.Size = new System.Drawing.Size(214, 17);
            this.LblDownloadNewAppList.TabIndex = 68;
            this.LblDownloadNewAppList.Text = "Download new App list from Steam";
            this.LblDownloadNewAppList.Click += new System.EventHandler(this.LblDownloadNewAppList_Click);
            this.LblDownloadNewAppList.MouseEnter += new System.EventHandler(this.LblDownloadNewAppList_MouseEnter);
            this.LblDownloadNewAppList.MouseLeave += new System.EventHandler(this.LblDownloadNewAppList_MouseLeave);
            // 
            // CbIdleCardsWithMostValue
            // 
            this.CbIdleCardsWithMostValue.AutoSize = true;
            this.CbIdleCardsWithMostValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbIdleCardsWithMostValue.Location = new System.Drawing.Point(17, 907);
            this.CbIdleCardsWithMostValue.Name = "CbIdleCardsWithMostValue";
            this.CbIdleCardsWithMostValue.Size = new System.Drawing.Size(204, 21);
            this.CbIdleCardsWithMostValue.TabIndex = 67;
            this.CbIdleCardsWithMostValue.Text = "Idle cards with most value first";
            this.CbIdleCardsWithMostValue.UseVisualStyleBackColor = true;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox8.Location = new System.Drawing.Point(0, 958);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(331, 20);
            this.pictureBox8.TabIndex = 65;
            this.pictureBox8.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 833);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 64;
            this.label7.Text = "minutes";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pictureBox6.Location = new System.Drawing.Point(32, 833);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(1, 58);
            this.pictureBox6.TabIndex = 63;
            this.pictureBox6.TabStop = false;
            // 
            // NumOnlyIdleGamesWithCertainMinutes
            // 
            this.NumOnlyIdleGamesWithCertainMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.NumOnlyIdleGamesWithCertainMinutes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumOnlyIdleGamesWithCertainMinutes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NumOnlyIdleGamesWithCertainMinutes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.NumOnlyIdleGamesWithCertainMinutes.Location = new System.Drawing.Point(48, 833);
            this.NumOnlyIdleGamesWithCertainMinutes.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumOnlyIdleGamesWithCertainMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumOnlyIdleGamesWithCertainMinutes.Name = "NumOnlyIdleGamesWithCertainMinutes";
            this.NumOnlyIdleGamesWithCertainMinutes.Size = new System.Drawing.Size(79, 21);
            this.NumOnlyIdleGamesWithCertainMinutes.TabIndex = 62;
            this.NumOnlyIdleGamesWithCertainMinutes.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // CbOnlyIdleGamesWithCertainMinutes
            // 
            this.CbOnlyIdleGamesWithCertainMinutes.AutoSize = true;
            this.CbOnlyIdleGamesWithCertainMinutes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbOnlyIdleGamesWithCertainMinutes.Location = new System.Drawing.Point(17, 796);
            this.CbOnlyIdleGamesWithCertainMinutes.Name = "CbOnlyIdleGamesWithCertainMinutes";
            this.CbOnlyIdleGamesWithCertainMinutes.Size = new System.Drawing.Size(277, 21);
            this.CbOnlyIdleGamesWithCertainMinutes.TabIndex = 61;
            this.CbOnlyIdleGamesWithCertainMinutes.Text = "Only idle games over a certain time played";
            this.CbOnlyIdleGamesWithCertainMinutes.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 60;
            this.label6.Text = "minutes";
            // 
            // CbSaveLoginCookies
            // 
            this.CbSaveLoginCookies.AutoSize = true;
            this.CbSaveLoginCookies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbSaveLoginCookies.Location = new System.Drawing.Point(17, 669);
            this.CbSaveLoginCookies.Name = "CbSaveLoginCookies";
            this.CbSaveLoginCookies.Size = new System.Drawing.Size(135, 21);
            this.CbSaveLoginCookies.TabIndex = 58;
            this.CbSaveLoginCookies.Text = "Save login cookies";
            this.CbSaveLoginCookies.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 766);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 57;
            this.label5.Text = "Trading Cards";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pictureBox5.Location = new System.Drawing.Point(17, 743);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(295, 1);
            this.pictureBox5.TabIndex = 56;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pictureBox4.Location = new System.Drawing.Point(32, 394);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(1, 58);
            this.pictureBox4.TabIndex = 55;
            this.pictureBox4.TabStop = false;
            // 
            // CbJoinSteamGroup
            // 
            this.CbJoinSteamGroup.AutoSize = true;
            this.CbJoinSteamGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbJoinSteamGroup.Location = new System.Drawing.Point(17, 632);
            this.CbJoinSteamGroup.Name = "CbJoinSteamGroup";
            this.CbJoinSteamGroup.Size = new System.Drawing.Size(180, 21);
            this.CbJoinSteamGroup.TabIndex = 53;
            this.CbJoinSteamGroup.Text = "Join Steam support group";
            this.CbJoinSteamGroup.UseVisualStyleBackColor = true;
            // 
            // CbSaveAppIdleHistory
            // 
            this.CbSaveAppIdleHistory.AutoSize = true;
            this.CbSaveAppIdleHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbSaveAppIdleHistory.Location = new System.Drawing.Point(17, 595);
            this.CbSaveAppIdleHistory.Name = "CbSaveAppIdleHistory";
            this.CbSaveAppIdleHistory.Size = new System.Drawing.Size(149, 21);
            this.CbSaveAppIdleHistory.TabIndex = 52;
            this.CbSaveAppIdleHistory.Text = "Save idle app history";
            this.CbSaveAppIdleHistory.UseVisualStyleBackColor = true;
            // 
            // CbClearRecentlyPlayed
            // 
            this.CbClearRecentlyPlayed.AutoSize = true;
            this.CbClearRecentlyPlayed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbClearRecentlyPlayed.Location = new System.Drawing.Point(17, 558);
            this.CbClearRecentlyPlayed.Name = "CbClearRecentlyPlayed";
            this.CbClearRecentlyPlayed.Size = new System.Drawing.Size(235, 21);
            this.CbClearRecentlyPlayed.TabIndex = 51;
            this.CbClearRecentlyPlayed.Text = "Clear recently played games on exit";
            this.CbClearRecentlyPlayed.UseVisualStyleBackColor = true;
            // 
            // CbCheckForUpdates
            // 
            this.CbCheckForUpdates.AutoSize = true;
            this.CbCheckForUpdates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbCheckForUpdates.Location = new System.Drawing.Point(17, 521);
            this.CbCheckForUpdates.Name = "CbCheckForUpdates";
            this.CbCheckForUpdates.Size = new System.Drawing.Size(133, 21);
            this.CbCheckForUpdates.TabIndex = 50;
            this.CbCheckForUpdates.Text = "Check for updates";
            this.CbCheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 491);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 49;
            this.label4.Text = "General";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pictureBox3.Location = new System.Drawing.Point(17, 468);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(295, 1);
            this.pictureBox3.TabIndex = 48;
            this.pictureBox3.TabStop = false;
            // 
            // CbRestartGamesRandomly
            // 
            this.CbRestartGamesRandomly.AutoSize = true;
            this.CbRestartGamesRandomly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbRestartGamesRandomly.Location = new System.Drawing.Point(48, 431);
            this.CbRestartGamesRandomly.Name = "CbRestartGamesRandomly";
            this.CbRestartGamesRandomly.Size = new System.Drawing.Size(176, 21);
            this.CbRestartGamesRandomly.TabIndex = 47;
            this.CbRestartGamesRandomly.Text = "Restart games at random";
            this.CbRestartGamesRandomly.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 46;
            this.label3.Text = "minutes";
            // 
            // NumRestartGamesMinutes
            // 
            this.NumRestartGamesMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.NumRestartGamesMinutes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumRestartGamesMinutes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NumRestartGamesMinutes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.NumRestartGamesMinutes.Location = new System.Drawing.Point(48, 394);
            this.NumRestartGamesMinutes.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumRestartGamesMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumRestartGamesMinutes.Name = "NumRestartGamesMinutes";
            this.NumRestartGamesMinutes.Size = new System.Drawing.Size(79, 21);
            this.NumRestartGamesMinutes.TabIndex = 45;
            this.NumRestartGamesMinutes.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // CbRestartGames
            // 
            this.CbRestartGames.AutoSize = true;
            this.CbRestartGames.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbRestartGames.Location = new System.Drawing.Point(17, 357);
            this.CbRestartGames.Name = "CbRestartGames";
            this.CbRestartGames.Size = new System.Drawing.Size(66, 21);
            this.CbRestartGames.TabIndex = 44;
            this.CbRestartGames.Text = "Enable";
            this.CbRestartGames.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 43;
            this.label2.Text = "Restart games";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pictureBox2.Location = new System.Drawing.Point(17, 304);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(295, 1);
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pictureBox1.Location = new System.Drawing.Point(60, 267);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1, 21);
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // NumWaitBetweenReplies
            // 
            this.NumWaitBetweenReplies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.NumWaitBetweenReplies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumWaitBetweenReplies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NumWaitBetweenReplies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.NumWaitBetweenReplies.Location = new System.Drawing.Point(75, 267);
            this.NumWaitBetweenReplies.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumWaitBetweenReplies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumWaitBetweenReplies.Name = "NumWaitBetweenReplies";
            this.NumWaitBetweenReplies.Size = new System.Drawing.Size(79, 21);
            this.NumWaitBetweenReplies.TabIndex = 40;
            this.NumWaitBetweenReplies.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // CbWaitBetweenReplies
            // 
            this.CbWaitBetweenReplies.AutoSize = true;
            this.CbWaitBetweenReplies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbWaitBetweenReplies.Location = new System.Drawing.Point(48, 230);
            this.CbWaitBetweenReplies.Name = "CbWaitBetweenReplies";
            this.CbWaitBetweenReplies.Size = new System.Drawing.Size(248, 21);
            this.CbWaitBetweenReplies.TabIndex = 38;
            this.CbWaitBetweenReplies.Text = "Wait before replying to the same user";
            this.CbWaitBetweenReplies.UseVisualStyleBackColor = true;
            // 
            // CbOnlyReplyIfIdling
            // 
            this.CbOnlyReplyIfIdling.AutoSize = true;
            this.CbOnlyReplyIfIdling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbOnlyReplyIfIdling.Location = new System.Drawing.Point(48, 193);
            this.CbOnlyReplyIfIdling.Name = "CbOnlyReplyIfIdling";
            this.CbOnlyReplyIfIdling.Size = new System.Drawing.Size(133, 21);
            this.CbOnlyReplyIfIdling.TabIndex = 37;
            this.CbOnlyReplyIfIdling.Text = "Only reply if idling";
            this.CbOnlyReplyIfIdling.UseVisualStyleBackColor = true;
            // 
            // TxtChatResponses
            // 
            this.TxtChatResponses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.TxtChatResponses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtChatResponses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.TxtChatResponses.Location = new System.Drawing.Point(48, 81);
            this.TxtChatResponses.Name = "TxtChatResponses";
            this.TxtChatResponses.Size = new System.Drawing.Size(264, 96);
            this.TxtChatResponses.TabIndex = 36;
            this.TxtChatResponses.Text = "I\'m currently Idling with: https://github.com/Ezzpify/HourBoostr\nI\'m idling games" +
    ". I\'ll get back to you later.";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pictureBox7.Location = new System.Drawing.Point(32, 81);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(1, 170);
            this.pictureBox7.TabIndex = 35;
            this.pictureBox7.TabStop = false;
            // 
            // CbEnableChatResponse
            // 
            this.CbEnableChatResponse.AutoSize = true;
            this.CbEnableChatResponse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbEnableChatResponse.Location = new System.Drawing.Point(17, 44);
            this.CbEnableChatResponse.Name = "CbEnableChatResponse";
            this.CbEnableChatResponse.Size = new System.Drawing.Size(66, 21);
            this.CbEnableChatResponse.TabIndex = 2;
            this.CbEnableChatResponse.Text = "Enable";
            this.CbEnableChatResponse.UseVisualStyleBackColor = true;
            this.CbEnableChatResponse.CheckedChanged += new System.EventHandler(this.CbEnableChatResponse_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Automatic Steam chat reply";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(350, 500);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.PanelFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.PanelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).EndInit();
            this.PanelContainer.ResumeLayout(false);
            this.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumGamesIdleWhenNoCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOnlyIdleGamesWithCertainMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumRestartGamesMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWaitBetweenReplies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelFooter;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox TxtChatResponses;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.CheckBox CbEnableChatResponse;
        private System.Windows.Forms.CheckBox CbWaitBetweenReplies;
        private System.Windows.Forms.CheckBox CbOnlyReplyIfIdling;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown NumWaitBetweenReplies;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.CheckBox CbJoinSteamGroup;
        private System.Windows.Forms.CheckBox CbSaveAppIdleHistory;
        private System.Windows.Forms.CheckBox CbClearRecentlyPlayed;
        private System.Windows.Forms.CheckBox CbCheckForUpdates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.CheckBox CbRestartGamesRandomly;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumRestartGamesMinutes;
        private System.Windows.Forms.CheckBox CbRestartGames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.NumericUpDown NumOnlyIdleGamesWithCertainMinutes;
        private System.Windows.Forms.CheckBox CbOnlyIdleGamesWithCertainMinutes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox CbSaveLoginCookies;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox BtnClose;
        private System.Windows.Forms.CheckBox CbIdleCardsWithMostValue;
        private System.Windows.Forms.Label LblDownloadNewAppList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NumGamesIdleWhenNoCards;
        private System.Windows.Forms.Label LblClearBlackList;
    }
}
