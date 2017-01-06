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
            this.btnIdle = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblClearSelected = new System.Windows.Forms.Label();
            this.lblGithub = new System.Windows.Forms.Label();
            this.cbRestartGames = new System.Windows.Forms.CheckBox();
            this.lblSelectedGameCounter = new System.Windows.Forms.Label();
            this.panelLoading = new System.Windows.Forms.Panel();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelLaunchPadder = new System.Windows.Forms.Panel();
            this.gameListWorker = new System.ComponentModel.BackgroundWorker();
            this.btnPauseTimer = new System.Windows.Forms.Timer(this.components);
            this.panelWarning = new System.Windows.Forms.Panel();
            this.cmboxTosLanguage = new System.Windows.Forms.ComboBox();
            this.btnTosNo = new System.Windows.Forms.Button();
            this.btnTosYes = new System.Windows.Forms.Button();
            this.lblToS = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelRunning = new System.Windows.Forms.Panel();
            this.btnHideWindow = new System.Windows.Forms.Button();
            this.listGamesActive = new System.Windows.Forms.ListBox();
            this.lblActiveGames = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStopBoost = new System.Windows.Forms.Button();
            this.checkProcessTimer = new System.Windows.Forms.Timer(this.components);
            this.restartGamesTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelGame = new System.Windows.Forms.Panel();
            this.panelGameArea = new System.Windows.Forms.Panel();
            this.game_YouWon = new System.Windows.Forms.Label();
            this.game_Obsticle2 = new System.Windows.Forms.PictureBox();
            this.game_Obsticle1 = new System.Windows.Forms.PictureBox();
            this.game_Player1 = new System.Windows.Forms.PictureBox();
            this.game_Ball = new System.Windows.Forms.PictureBox();
            this.game_Player2 = new System.Windows.Forms.PictureBox();
            this.panelGameScore = new System.Windows.Forms.Panel();
            this.game_Player1_Score = new System.Windows.Forms.Label();
            this.game_Timer = new System.Windows.Forms.Timer(this.components);
            this.game_AITimer = new System.Windows.Forms.Timer(this.components);
            this.game_Instructions = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.panelWarning.SuspendLayout();
            this.panelRunning.SuspendLayout();
            this.panelGame.SuspendLayout();
            this.panelGameArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.game_Obsticle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.game_Obsticle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.game_Player1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.game_Ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.game_Player2)).BeginInit();
            this.panelGameScore.SuspendLayout();
            this.SuspendLayout();
            // 
            // listGames
            // 
            this.listGames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(12, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 23);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // listGamesSelected
            // 
            this.listGamesSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listGamesSelected.FormattingEnabled = true;
            this.listGamesSelected.IntegralHeight = false;
            this.listGamesSelected.ItemHeight = 15;
            this.listGamesSelected.Location = new System.Drawing.Point(268, 27);
            this.listGamesSelected.Name = "listGamesSelected";
            this.listGamesSelected.Size = new System.Drawing.Size(254, 169);
            this.listGamesSelected.TabIndex = 3;
            this.listGamesSelected.SelectedIndexChanged += new System.EventHandler(this.listGamesSelected_SelectedIndexChanged);
            // 
            // btnIdle
            // 
            this.btnIdle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIdle.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnIdle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIdle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnIdle.Location = new System.Drawing.Point(268, 202);
            this.btnIdle.Name = "btnIdle";
            this.btnIdle.Size = new System.Drawing.Size(254, 47);
            this.btnIdle.TabIndex = 4;
            this.btnIdle.Text = "IDLE";
            this.btnIdle.UseVisualStyleBackColor = true;
            this.btnIdle.Click += new System.EventHandler(this.btnIdle_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblClearSelected);
            this.panelMain.Controls.Add(this.lblGithub);
            this.panelMain.Controls.Add(this.cbRestartGames);
            this.panelMain.Controls.Add(this.lblSelectedGameCounter);
            this.panelMain.Controls.Add(this.btnIdle);
            this.panelMain.Controls.Add(this.listGamesSelected);
            this.panelMain.Controls.Add(this.txtSearch);
            this.panelMain.Controls.Add(this.lblGameCounter);
            this.panelMain.Controls.Add(this.listGames);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(538, 293);
            this.panelMain.TabIndex = 5;
            this.panelMain.Visible = false;
            // 
            // lblClearSelected
            // 
            this.lblClearSelected.AutoSize = true;
            this.lblClearSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClearSelected.Location = new System.Drawing.Point(489, 9);
            this.lblClearSelected.Name = "lblClearSelected";
            this.lblClearSelected.Size = new System.Drawing.Size(34, 15);
            this.lblClearSelected.TabIndex = 9;
            this.lblClearSelected.Text = "Clear";
            this.lblClearSelected.Visible = false;
            this.lblClearSelected.Click += new System.EventHandler(this.lblClearSelected_Click);
            this.lblClearSelected.MouseEnter += new System.EventHandler(this.lblClearSelected_MouseEnter);
            this.lblClearSelected.MouseLeave += new System.EventHandler(this.lblClearSelected_MouseLeave);
            // 
            // lblGithub
            // 
            this.lblGithub.AutoSize = true;
            this.lblGithub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGithub.Location = new System.Drawing.Point(414, 263);
            this.lblGithub.Name = "lblGithub";
            this.lblGithub.Size = new System.Drawing.Size(111, 15);
            this.lblGithub.TabIndex = 8;
            this.lblGithub.Text = "Github.com/Ezzpify";
            this.lblGithub.Click += new System.EventHandler(this.lblGithub_Click);
            this.lblGithub.MouseEnter += new System.EventHandler(this.lblGithub_MouseEnter);
            this.lblGithub.MouseLeave += new System.EventHandler(this.lblGithub_MouseLeave);
            // 
            // cbRestartGames
            // 
            this.cbRestartGames.AutoSize = true;
            this.cbRestartGames.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbRestartGames.Location = new System.Drawing.Point(12, 262);
            this.cbRestartGames.Name = "cbRestartGames";
            this.cbRestartGames.Size = new System.Drawing.Size(181, 19);
            this.cbRestartGames.TabIndex = 7;
            this.cbRestartGames.Text = "Restart games every ~3 hours";
            this.cbRestartGames.UseVisualStyleBackColor = true;
            this.cbRestartGames.MouseEnter += new System.EventHandler(this.cbRestartGames_MouseEnter);
            this.cbRestartGames.MouseLeave += new System.EventHandler(this.cbRestartGames_MouseLeave);
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
            // panelLoading
            // 
            this.panelLoading.Controls.Add(this.picLoading);
            this.panelLoading.Controls.Add(this.lblStatus);
            this.panelLoading.Controls.Add(this.panelLaunchPadder);
            this.panelLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoading.Location = new System.Drawing.Point(0, 0);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(538, 293);
            this.panelLoading.TabIndex = 6;
            this.panelLoading.Visible = false;
            // 
            // picLoading
            // 
            this.picLoading.Image = ((System.Drawing.Image)(resources.GetObject("picLoading.Image")));
            this.picLoading.Location = new System.Drawing.Point(237, 118);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(68, 68);
            this.picLoading.TabIndex = 6;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Location = new System.Drawing.Point(0, 100);
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
            this.panelLaunchPadder.Size = new System.Drawing.Size(538, 100);
            this.panelLaunchPadder.TabIndex = 8;
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
            this.panelWarning.Controls.Add(this.cmboxTosLanguage);
            this.panelWarning.Controls.Add(this.btnTosNo);
            this.panelWarning.Controls.Add(this.btnTosYes);
            this.panelWarning.Controls.Add(this.lblToS);
            this.panelWarning.Controls.Add(this.panel3);
            this.panelWarning.Controls.Add(this.panel2);
            this.panelWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWarning.Location = new System.Drawing.Point(0, 0);
            this.panelWarning.Name = "panelWarning";
            this.panelWarning.Size = new System.Drawing.Size(538, 293);
            this.panelWarning.TabIndex = 9;
            this.panelWarning.Visible = false;
            // 
            // cmboxTosLanguage
            // 
            this.cmboxTosLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxTosLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmboxTosLanguage.FormattingEnabled = true;
            this.cmboxTosLanguage.Location = new System.Drawing.Point(398, 12);
            this.cmboxTosLanguage.Name = "cmboxTosLanguage";
            this.cmboxTosLanguage.Size = new System.Drawing.Size(128, 23);
            this.cmboxTosLanguage.TabIndex = 15;
            this.cmboxTosLanguage.SelectedIndexChanged += new System.EventHandler(this.cmboxTosLanguage_SelectedIndexChanged);
            // 
            // btnTosNo
            // 
            this.btnTosNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTosNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTosNo.Location = new System.Drawing.Point(317, 244);
            this.btnTosNo.Name = "btnTosNo";
            this.btnTosNo.Size = new System.Drawing.Size(75, 23);
            this.btnTosNo.TabIndex = 17;
            this.btnTosNo.Text = "No";
            this.btnTosNo.UseVisualStyleBackColor = true;
            this.btnTosNo.Click += new System.EventHandler(this.btnTosNo_Click);
            // 
            // btnTosYes
            // 
            this.btnTosYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTosYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTosYes.Location = new System.Drawing.Point(145, 244);
            this.btnTosYes.Name = "btnTosYes";
            this.btnTosYes.Size = new System.Drawing.Size(75, 23);
            this.btnTosYes.TabIndex = 16;
            this.btnTosYes.Text = "Yes";
            this.btnTosYes.UseVisualStyleBackColor = true;
            this.btnTosYes.Click += new System.EventHandler(this.btnTosYes_Click);
            // 
            // lblToS
            // 
            this.lblToS.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblToS.Location = new System.Drawing.Point(20, 0);
            this.lblToS.Name = "lblToS";
            this.lblToS.Size = new System.Drawing.Size(498, 241);
            this.lblToS.TabIndex = 7;
            this.lblToS.Text = "Terms of Service";
            this.lblToS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(518, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 293);
            this.panel3.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 293);
            this.panel2.TabIndex = 18;
            // 
            // panelRunning
            // 
            this.panelRunning.Controls.Add(this.btnHideWindow);
            this.panelRunning.Controls.Add(this.listGamesActive);
            this.panelRunning.Controls.Add(this.lblActiveGames);
            this.panelRunning.Controls.Add(this.panel1);
            this.panelRunning.Controls.Add(this.btnStopBoost);
            this.panelRunning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRunning.Location = new System.Drawing.Point(0, 0);
            this.panelRunning.Name = "panelRunning";
            this.panelRunning.Size = new System.Drawing.Size(538, 293);
            this.panelRunning.TabIndex = 6;
            this.panelRunning.Visible = false;
            // 
            // btnHideWindow
            // 
            this.btnHideWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHideWindow.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnHideWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideWindow.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnHideWindow.Location = new System.Drawing.Point(145, 192);
            this.btnHideWindow.Name = "btnHideWindow";
            this.btnHideWindow.Size = new System.Drawing.Size(254, 40);
            this.btnHideWindow.TabIndex = 12;
            this.btnHideWindow.Text = "HIDE WINDOW";
            this.btnHideWindow.UseVisualStyleBackColor = true;
            this.btnHideWindow.Click += new System.EventHandler(this.btnHideWindow_Click);
            // 
            // listGamesActive
            // 
            this.listGamesActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listGamesActive.FormattingEnabled = true;
            this.listGamesActive.IntegralHeight = false;
            this.listGamesActive.ItemHeight = 15;
            this.listGamesActive.Location = new System.Drawing.Point(145, 56);
            this.listGamesActive.Name = "listGamesActive";
            this.listGamesActive.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listGamesActive.Size = new System.Drawing.Size(254, 84);
            this.listGamesActive.TabIndex = 11;
            // 
            // lblActiveGames
            // 
            this.lblActiveGames.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblActiveGames.Location = new System.Drawing.Point(0, 35);
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
            this.panel1.Size = new System.Drawing.Size(538, 35);
            this.panel1.TabIndex = 9;
            // 
            // btnStopBoost
            // 
            this.btnStopBoost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopBoost.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnStopBoost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopBoost.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnStopBoost.Location = new System.Drawing.Point(145, 146);
            this.btnStopBoost.Name = "btnStopBoost";
            this.btnStopBoost.Size = new System.Drawing.Size(254, 40);
            this.btnStopBoost.TabIndex = 5;
            this.btnStopBoost.Text = "STOP";
            this.btnStopBoost.UseVisualStyleBackColor = true;
            this.btnStopBoost.Click += new System.EventHandler(this.btnStopBoost_Click);
            // 
            // checkProcessTimer
            // 
            this.checkProcessTimer.Interval = 20000;
            this.checkProcessTimer.Tick += new System.EventHandler(this.checkProcessTimer_Tick);
            // 
            // restartGamesTimer
            // 
            this.restartGamesTimer.Interval = 5000;
            this.restartGamesTimer.Tick += new System.EventHandler(this.restartGamesTimer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Running minimized.";
            this.notifyIcon.BalloonTipTitle = "SingleBoostr";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "SingleBoostr";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // panelGame
            // 
            this.panelGame.Controls.Add(this.panelGameArea);
            this.panelGame.Controls.Add(this.panelGameScore);
            this.panelGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGame.Location = new System.Drawing.Point(0, 0);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(538, 293);
            this.panelGame.TabIndex = 9;
            this.panelGame.Visible = false;
            // 
            // panelGameArea
            // 
            this.panelGameArea.Controls.Add(this.game_Instructions);
            this.panelGameArea.Controls.Add(this.game_YouWon);
            this.panelGameArea.Controls.Add(this.game_Obsticle2);
            this.panelGameArea.Controls.Add(this.game_Obsticle1);
            this.panelGameArea.Controls.Add(this.game_Player1);
            this.panelGameArea.Controls.Add(this.game_Ball);
            this.panelGameArea.Controls.Add(this.game_Player2);
            this.panelGameArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGameArea.Location = new System.Drawing.Point(0, 0);
            this.panelGameArea.Name = "panelGameArea";
            this.panelGameArea.Size = new System.Drawing.Size(538, 262);
            this.panelGameArea.TabIndex = 6;
            // 
            // game_YouWon
            // 
            this.game_YouWon.AutoSize = true;
            this.game_YouWon.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.game_YouWon.Location = new System.Drawing.Point(202, 106);
            this.game_YouWon.Name = "game_YouWon";
            this.game_YouWon.Size = new System.Drawing.Size(142, 37);
            this.game_YouWon.TabIndex = 7;
            this.game_YouWon.Text = "YOU WON";
            this.game_YouWon.Visible = false;
            // 
            // game_Obsticle2
            // 
            this.game_Obsticle2.BackColor = System.Drawing.Color.Black;
            this.game_Obsticle2.Location = new System.Drawing.Point(387, 110);
            this.game_Obsticle2.Name = "game_Obsticle2";
            this.game_Obsticle2.Size = new System.Drawing.Size(5, 30);
            this.game_Obsticle2.TabIndex = 6;
            this.game_Obsticle2.TabStop = false;
            this.game_Obsticle2.Visible = false;
            // 
            // game_Obsticle1
            // 
            this.game_Obsticle1.BackColor = System.Drawing.Color.Black;
            this.game_Obsticle1.Location = new System.Drawing.Point(145, 110);
            this.game_Obsticle1.Name = "game_Obsticle1";
            this.game_Obsticle1.Size = new System.Drawing.Size(5, 30);
            this.game_Obsticle1.TabIndex = 5;
            this.game_Obsticle1.TabStop = false;
            this.game_Obsticle1.Visible = false;
            // 
            // game_Player1
            // 
            this.game_Player1.BackColor = System.Drawing.Color.Silver;
            this.game_Player1.Location = new System.Drawing.Point(12, 110);
            this.game_Player1.Name = "game_Player1";
            this.game_Player1.Size = new System.Drawing.Size(8, 30);
            this.game_Player1.TabIndex = 2;
            this.game_Player1.TabStop = false;
            // 
            // game_Ball
            // 
            this.game_Ball.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.game_Ball.Location = new System.Drawing.Point(260, 118);
            this.game_Ball.Name = "game_Ball";
            this.game_Ball.Size = new System.Drawing.Size(14, 14);
            this.game_Ball.TabIndex = 4;
            this.game_Ball.TabStop = false;
            // 
            // game_Player2
            // 
            this.game_Player2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.game_Player2.Location = new System.Drawing.Point(518, 110);
            this.game_Player2.Name = "game_Player2";
            this.game_Player2.Size = new System.Drawing.Size(8, 30);
            this.game_Player2.TabIndex = 3;
            this.game_Player2.TabStop = false;
            // 
            // panelGameScore
            // 
            this.panelGameScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelGameScore.Controls.Add(this.game_Player1_Score);
            this.panelGameScore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelGameScore.Location = new System.Drawing.Point(0, 262);
            this.panelGameScore.Name = "panelGameScore";
            this.panelGameScore.Size = new System.Drawing.Size(538, 31);
            this.panelGameScore.TabIndex = 5;
            // 
            // game_Player1_Score
            // 
            this.game_Player1_Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.game_Player1_Score.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.game_Player1_Score.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.game_Player1_Score.Location = new System.Drawing.Point(0, 0);
            this.game_Player1_Score.Name = "game_Player1_Score";
            this.game_Player1_Score.Size = new System.Drawing.Size(538, 31);
            this.game_Player1_Score.TabIndex = 5;
            this.game_Player1_Score.Text = "Score: 0/40    -    Lives: 5";
            this.game_Player1_Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // game_Timer
            // 
            this.game_Timer.Interval = 1;
            this.game_Timer.Tick += new System.EventHandler(this.game_Timer_Tick);
            // 
            // game_AITimer
            // 
            this.game_AITimer.Interval = 1;
            this.game_AITimer.Tick += new System.EventHandler(this.game_AITimer_Tick);
            // 
            // game_Instructions
            // 
            this.game_Instructions.AutoSize = true;
            this.game_Instructions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.game_Instructions.Location = new System.Drawing.Point(158, 143);
            this.game_Instructions.Name = "game_Instructions";
            this.game_Instructions.Size = new System.Drawing.Size(234, 34);
            this.game_Instructions.TabIndex = 8;
            this.game_Instructions.Text = "Press F12 to start.\r\nUse Arrow keys to move up and down.";
            this.game_Instructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(538, 293);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.panelWarning);
            this.Controls.Add(this.panelLoading);
            this.Controls.Add(this.panelRunning);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.Gray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(550, 300);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SingleBoostr :: Terms of Service";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyUp);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.panelWarning.ResumeLayout(false);
            this.panelRunning.ResumeLayout(false);
            this.panelGame.ResumeLayout(false);
            this.panelGameArea.ResumeLayout(false);
            this.panelGameArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.game_Obsticle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.game_Obsticle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.game_Player1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.game_Ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.game_Player2)).EndInit();
            this.panelGameScore.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listGames;
        private System.Windows.Forms.Label lblGameCounter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListBox listGamesSelected;
        private System.Windows.Forms.Button btnIdle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelLoading;
        private System.Windows.Forms.PictureBox picLoading;
        private System.ComponentModel.BackgroundWorker gameListWorker;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelLaunchPadder;
        private System.Windows.Forms.Label lblSelectedGameCounter;
        private System.Windows.Forms.Timer btnPauseTimer;
        private System.Windows.Forms.Panel panelWarning;
        private System.Windows.Forms.Label lblToS;
        private System.Windows.Forms.Button btnTosYes;
        private System.Windows.Forms.Button btnTosNo;
        private System.Windows.Forms.Panel panelRunning;
        private System.Windows.Forms.Label lblActiveGames;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStopBoost;
        private System.Windows.Forms.Timer checkProcessTimer;
        private System.Windows.Forms.ListBox listGamesActive;
        private System.Windows.Forms.CheckBox cbRestartGames;
        private System.Windows.Forms.Label lblGithub;
        private System.Windows.Forms.Timer restartGamesTimer;
        private System.Windows.Forms.Label lblClearSelected;
        private System.Windows.Forms.ComboBox cmboxTosLanguage;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnHideWindow;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.PictureBox game_Player1;
        public System.Windows.Forms.PictureBox game_Player2;
        public System.Windows.Forms.PictureBox game_Ball;
        public System.Windows.Forms.Timer game_Timer;
        public System.Windows.Forms.Timer game_AITimer;
        private System.Windows.Forms.Panel panelGameScore;
        public System.Windows.Forms.Panel panelGameArea;
        private System.Windows.Forms.Panel panelGame;
        public System.Windows.Forms.Label game_Player1_Score;
        public System.Windows.Forms.PictureBox game_Obsticle2;
        public System.Windows.Forms.PictureBox game_Obsticle1;
        public System.Windows.Forms.Label game_YouWon;
        public System.Windows.Forms.Label game_Instructions;
    }
}

