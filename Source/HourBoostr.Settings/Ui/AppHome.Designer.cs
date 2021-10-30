namespace HourBoostr.Settings.Ui
{
    partial class AppHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppHome));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.accountListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOnlineStatus = new MetroFramework.Controls.MetroToggle();
            this.OSLabel = new System.Windows.Forms.Label();
            this.OSTypeComboBox = new System.Windows.Forms.ComboBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRemoveLoginKey = new System.Windows.Forms.Label();
            this.txtLoginKey = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblFindGames = new System.Windows.Forms.Label();
            this.txtGameItem = new System.Windows.Forms.TextBox();
            this.gameList = new System.Windows.Forms.ListBox();
            this.gameListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblNewAccount = new System.Windows.Forms.Label();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.accountListBoxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStartBooster = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbJoinGroup = new MetroFramework.Controls.MetroToggle();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCommunity = new MetroFramework.Controls.MetroToggle();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRestartGames = new MetroFramework.Controls.MetroToggle();
            this.label5 = new System.Windows.Forms.Label();
            this.cbIgnoreAccount = new MetroFramework.Controls.MetroToggle();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCheckForUpdates = new MetroFramework.Controls.MetroRadioButton();
            this.cbHideToTray = new MetroFramework.Controls.MetroRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gameListMenu.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.accountListBoxMenu.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.Location = new System.Drawing.Point(179, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1, 328);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // accountListBox
            // 
            this.accountListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.accountListBox.ForeColor = System.Drawing.Color.Gray;
            this.accountListBox.FormattingEnabled = true;
            this.accountListBox.IntegralHeight = false;
            this.accountListBox.ItemHeight = 15;
            this.accountListBox.Location = new System.Drawing.Point(6, 22);
            this.accountListBox.Name = "accountListBox";
            this.accountListBox.Size = new System.Drawing.Size(143, 134);
            this.accountListBox.TabIndex = 1;
            this.accountListBox.SelectedIndexChanged += new System.EventHandler(this.accountListBox_SelectedIndexChanged);
            this.accountListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.accountListBox_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbIgnoreAccount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbRestartGames);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbCommunity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbJoinGroup);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbOnlineStatus);
            this.groupBox1.Controls.Add(this.OSLabel);
            this.groupBox1.Controls.Add(this.OSTypeComboBox);
            this.groupBox1.Controls.Add(this.txtResponse);
            this.groupBox1.Location = new System.Drawing.Point(3, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 215);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Online Status";
            // 
            // cbOnlineStatus
            // 
            this.cbOnlineStatus.AutoSize = true;
            this.cbOnlineStatus.Checked = true;
            this.cbOnlineStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOnlineStatus.Location = new System.Drawing.Point(21, 22);
            this.cbOnlineStatus.Name = "cbOnlineStatus";
            this.cbOnlineStatus.Size = new System.Drawing.Size(80, 19);
            this.cbOnlineStatus.TabIndex = 9;
            this.cbOnlineStatus.Tag = "ghfgh";
            this.cbOnlineStatus.Text = "On";
            this.cbOnlineStatus.UseStyleColors = true;
            this.cbOnlineStatus.UseVisualStyleBackColor = true;
            // 
            // OSLabel
            // 
            this.OSLabel.AutoSize = true;
            this.OSLabel.Location = new System.Drawing.Point(18, 153);
            this.OSLabel.Name = "OSLabel";
            this.OSLabel.Size = new System.Drawing.Size(46, 15);
            this.OSLabel.TabIndex = 8;
            this.OSLabel.Text = "OSType";
            // 
            // OSTypeComboBox
            // 
            this.OSTypeComboBox.FormattingEnabled = true;
            this.OSTypeComboBox.Items.AddRange(new object[] {
            "Windows",
            "Linux",
            "Mac"});
            this.OSTypeComboBox.Location = new System.Drawing.Point(136, 150);
            this.OSTypeComboBox.Name = "OSTypeComboBox";
            this.OSTypeComboBox.Size = new System.Drawing.Size(145, 23);
            this.OSTypeComboBox.TabIndex = 7;
            // 
            // txtResponse
            // 
            this.txtResponse.ForeColor = System.Drawing.Color.Gray;
            this.txtResponse.Location = new System.Drawing.Point(136, 179);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(145, 23);
            this.txtResponse.TabIndex = 3;
            this.txtResponse.TextChanged += new System.EventHandler(this.txtResponse_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRemoveLoginKey);
            this.groupBox2.Controls.Add(this.txtLoginKey);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Location = new System.Drawing.Point(3, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 115);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // lblRemoveLoginKey
            // 
            this.lblRemoveLoginKey.AutoSize = true;
            this.lblRemoveLoginKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRemoveLoginKey.Location = new System.Drawing.Point(225, 83);
            this.lblRemoveLoginKey.Name = "lblRemoveLoginKey";
            this.lblRemoveLoginKey.Size = new System.Drawing.Size(47, 15);
            this.lblRemoveLoginKey.TabIndex = 3;
            this.lblRemoveLoginKey.Text = "remove";
            this.lblRemoveLoginKey.Click += new System.EventHandler(this.lblRemoveLoginKey_Click);
            this.lblRemoveLoginKey.MouseEnter += new System.EventHandler(this.lblRemoveLoginKey_MouseEnter);
            this.lblRemoveLoginKey.MouseLeave += new System.EventHandler(this.lblRemoveLoginKey_MouseLeave);
            // 
            // txtLoginKey
            // 
            this.txtLoginKey.ForeColor = System.Drawing.Color.Gray;
            this.txtLoginKey.Location = new System.Drawing.Point(21, 80);
            this.txtLoginKey.Name = "txtLoginKey";
            this.txtLoginKey.Size = new System.Drawing.Size(260, 23);
            this.txtLoginKey.TabIndex = 2;
            this.txtLoginKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoginKey_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.Location = new System.Drawing.Point(21, 51);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(260, 23);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.ForeColor = System.Drawing.Color.Gray;
            this.txtUsername.Location = new System.Drawing.Point(21, 22);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(260, 23);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblFindGames);
            this.groupBox3.Controls.Add(this.txtGameItem);
            this.groupBox3.Controls.Add(this.gameList);
            this.groupBox3.Location = new System.Drawing.Point(313, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(243, 336);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Games";
            // 
            // lblFindGames
            // 
            this.lblFindGames.AutoSize = true;
            this.lblFindGames.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFindGames.Location = new System.Drawing.Point(156, 301);
            this.lblFindGames.Name = "lblFindGames";
            this.lblFindGames.Size = new System.Drawing.Size(69, 15);
            this.lblFindGames.TabIndex = 4;
            this.lblFindGames.Text = "Find Games";
            this.lblFindGames.Click += new System.EventHandler(this.lblFindGames_Click);
            this.lblFindGames.MouseEnter += new System.EventHandler(this.lblFindGames_MouseEnter);
            this.lblFindGames.MouseLeave += new System.EventHandler(this.lblFindGames_MouseLeave);
            // 
            // txtGameItem
            // 
            this.txtGameItem.ForeColor = System.Drawing.Color.Gray;
            this.txtGameItem.Location = new System.Drawing.Point(6, 298);
            this.txtGameItem.Name = "txtGameItem";
            this.txtGameItem.Size = new System.Drawing.Size(228, 23);
            this.txtGameItem.TabIndex = 3;
            this.txtGameItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGameItem_KeyDown);
            // 
            // gameList
            // 
            this.gameList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameList.ContextMenuStrip = this.gameListMenu;
            this.gameList.ForeColor = System.Drawing.Color.Gray;
            this.gameList.FormattingEnabled = true;
            this.gameList.IntegralHeight = false;
            this.gameList.ItemHeight = 15;
            this.gameList.Location = new System.Drawing.Point(6, 22);
            this.gameList.Name = "gameList";
            this.gameList.Size = new System.Drawing.Size(231, 264);
            this.gameList.TabIndex = 2;
            this.gameList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gameList_MouseDown);
            // 
            // gameListMenu
            // 
            this.gameListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.gameListMenu.Name = "gameListMenu";
            this.gameListMenu.ShowImageMargin = false;
            this.gameListMenu.Size = new System.Drawing.Size(127, 26);
            this.gameListMenu.Opening += new System.ComponentModel.CancelEventHandler(this.gameListMenu_Opening);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.removeToolStripMenuItem.Text = "Remove Game";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblNewAccount);
            this.groupBox4.Controls.Add(this.accountListBox);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(155, 162);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            // 
            // lblNewAccount
            // 
            this.lblNewAccount.AutoSize = true;
            this.lblNewAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNewAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAccount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblNewAccount.Location = new System.Drawing.Point(6, -2);
            this.lblNewAccount.Name = "lblNewAccount";
            this.lblNewAccount.Size = new System.Drawing.Size(94, 17);
            this.lblNewAccount.TabIndex = 2;
            this.lblNewAccount.Text = "+ Add account";
            this.lblNewAccount.Click += new System.EventHandler(this.lblNewAccount_Click);
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.groupBox1);
            this.panelSettings.Controls.Add(this.groupBox2);
            this.panelSettings.Controls.Add(this.groupBox3);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSettings.Location = new System.Drawing.Point(186, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(559, 351);
            this.panelSettings.TabIndex = 11;
            this.panelSettings.Visible = false;
            // 
            // accountListBoxMenu
            // 
            this.accountListBoxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeAccountToolStripMenuItem});
            this.accountListBoxMenu.Name = "accountListBoxMenu";
            this.accountListBoxMenu.ShowImageMargin = false;
            this.accountListBoxMenu.Size = new System.Drawing.Size(141, 26);
            this.accountListBoxMenu.Opening += new System.ComponentModel.CancelEventHandler(this.accountListBoxMenu_Opening);
            // 
            // removeAccountToolStripMenuItem
            // 
            this.removeAccountToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeAccountToolStripMenuItem.Name = "removeAccountToolStripMenuItem";
            this.removeAccountToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.removeAccountToolStripMenuItem.Text = "Remove Account";
            this.removeAccountToolStripMenuItem.Click += new System.EventHandler(this.removeAccountToolStripMenuItem_Click);
            // 
            // lblStartBooster
            // 
            this.lblStartBooster.AutoSize = true;
            this.lblStartBooster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStartBooster.Location = new System.Drawing.Point(36, 25);
            this.lblStartBooster.Name = "lblStartBooster";
            this.lblStartBooster.Size = new System.Drawing.Size(81, 15);
            this.lblStartBooster.TabIndex = 5;
            this.lblStartBooster.Text = "Start boosting";
            this.lblStartBooster.Click += new System.EventHandler(this.lblStartBooster_Click);
            this.lblStartBooster.MouseEnter += new System.EventHandler(this.lblStartBooster_MouseEnter);
            this.lblStartBooster.MouseLeave += new System.EventHandler(this.lblStartBooster_MouseLeave);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblStartBooster);
            this.groupBox6.Location = new System.Drawing.Point(12, 293);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(155, 55);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "HourBoostr";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbHideToTray);
            this.groupBox5.Controls.Add(this.cbCheckForUpdates);
            this.groupBox5.Location = new System.Drawing.Point(12, 180);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(155, 107);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "General";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Steam Group";
            // 
            // cbJoinGroup
            // 
            this.cbJoinGroup.AutoSize = true;
            this.cbJoinGroup.Checked = true;
            this.cbJoinGroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbJoinGroup.Location = new System.Drawing.Point(21, 47);
            this.cbJoinGroup.Name = "cbJoinGroup";
            this.cbJoinGroup.Size = new System.Drawing.Size(80, 19);
            this.cbJoinGroup.TabIndex = 11;
            this.cbJoinGroup.Tag = "ghfgh";
            this.cbJoinGroup.Text = "On";
            this.cbJoinGroup.UseStyleColors = true;
            this.cbJoinGroup.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Steam Community";
            // 
            // cbCommunity
            // 
            this.cbCommunity.AutoSize = true;
            this.cbCommunity.Checked = true;
            this.cbCommunity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCommunity.Location = new System.Drawing.Point(21, 72);
            this.cbCommunity.Name = "cbCommunity";
            this.cbCommunity.Size = new System.Drawing.Size(80, 19);
            this.cbCommunity.TabIndex = 13;
            this.cbCommunity.Tag = "ghfgh";
            this.cbCommunity.Text = "On";
            this.cbCommunity.UseStyleColors = true;
            this.cbCommunity.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Restart Games";
            // 
            // cbRestartGames
            // 
            this.cbRestartGames.AutoSize = true;
            this.cbRestartGames.Location = new System.Drawing.Point(21, 97);
            this.cbRestartGames.Name = "cbRestartGames";
            this.cbRestartGames.Size = new System.Drawing.Size(80, 19);
            this.cbRestartGames.TabIndex = 15;
            this.cbRestartGames.Tag = "ghfgh";
            this.cbRestartGames.Text = "Off";
            this.cbRestartGames.UseStyleColors = true;
            this.cbRestartGames.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Ignore account";
            // 
            // cbIgnoreAccount
            // 
            this.cbIgnoreAccount.AutoSize = true;
            this.cbIgnoreAccount.Location = new System.Drawing.Point(21, 122);
            this.cbIgnoreAccount.Name = "cbIgnoreAccount";
            this.cbIgnoreAccount.Size = new System.Drawing.Size(80, 19);
            this.cbIgnoreAccount.TabIndex = 17;
            this.cbIgnoreAccount.Tag = "ghfgh";
            this.cbIgnoreAccount.Text = "Off";
            this.cbIgnoreAccount.UseStyleColors = true;
            this.cbIgnoreAccount.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Chat response";
            // 
            // cbCheckForUpdates
            // 
            this.cbCheckForUpdates.AutoSize = true;
            this.cbCheckForUpdates.Location = new System.Drawing.Point(9, 25);
            this.cbCheckForUpdates.Name = "cbCheckForUpdates";
            this.cbCheckForUpdates.Size = new System.Drawing.Size(119, 15);
            this.cbCheckForUpdates.TabIndex = 9;
            this.cbCheckForUpdates.TabStop = true;
            this.cbCheckForUpdates.Text = "Check for updates";
            this.cbCheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // cbHideToTray
            // 
            this.cbHideToTray.AutoSize = true;
            this.cbHideToTray.Location = new System.Drawing.Point(9, 46);
            this.cbHideToTray.Name = "cbHideToTray";
            this.cbHideToTray.Size = new System.Drawing.Size(85, 15);
            this.cbHideToTray.TabIndex = 10;
            this.cbHideToTray.TabStop = true;
            this.cbHideToTray.Text = "Hide to tray";
            this.cbHideToTray.UseVisualStyleBackColor = true;
            // 
            // AppHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(745, 351);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(716, 343);
            this.Name = "AppHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HourBoostr Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gameListMenu.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.accountListBoxMenu.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox accountListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLoginKey;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.ListBox gameList;
        private System.Windows.Forms.TextBox txtGameItem;
        private System.Windows.Forms.Label lblNewAccount;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.ContextMenuStrip gameListMenu;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip accountListBoxMenu;
        private System.Windows.Forms.ToolStripMenuItem removeAccountToolStripMenuItem;
        private System.Windows.Forms.Label lblRemoveLoginKey;
        private System.Windows.Forms.Label lblFindGames;
        private System.Windows.Forms.Label lblStartBooster;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label OSLabel;
        private System.Windows.Forms.ComboBox OSTypeComboBox;
        private MetroFramework.Controls.MetroToggle cbOnlineStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroToggle cbIgnoreAccount;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroToggle cbRestartGames;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroToggle cbCommunity;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroToggle cbJoinGroup;
        private MetroFramework.Controls.MetroRadioButton cbHideToTray;
        private MetroFramework.Controls.MetroRadioButton cbCheckForUpdates;
    }
}

