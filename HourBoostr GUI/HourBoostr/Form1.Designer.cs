namespace HourBoostr
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel_Header = new System.Windows.Forms.Panel();
            this.game_listBtn = new System.Windows.Forms.Label();
            this.game_AddAll = new System.Windows.Forms.Label();
            this.divider_asdahga = new System.Windows.Forms.PictureBox();
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menu_Run = new System.Windows.Forms.Label();
            this.menu_Add2 = new System.Windows.Forms.Label();
            this.menu_Add1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userView = new System.Windows.Forms.ListView();
            this.divider_glkjjhasdfh = new System.Windows.Forms.PictureBox();
            this.panel_Container = new System.Windows.Forms.Panel();
            this.panel_Games = new System.Windows.Forms.Panel();
            this.panel_GameList = new System.Windows.Forms.Panel();
            this.game_listBox = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.game_labelCount = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.divider_kmasdgn = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.text_User = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label_Info = new System.Windows.Forms.Label();
            this.pic_Loading = new System.Windows.Forms.PictureBox();
            this.gameView = new System.Windows.Forms.ListView();
            this.control_Exit = new System.Windows.Forms.Button();
            this.panel_Controls = new System.Windows.Forms.Panel();
            this.control_Min = new System.Windows.Forms.Button();
            this.control_State = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gameFetcher = new System.ComponentModel.BackgroundWorker();
            this.divider_Top = new System.Windows.Forms.PictureBox();
            this.userMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.userMenu_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.divider_asdahga)).BeginInit();
            this.panel_Menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.divider_glkjjhasdfh)).BeginInit();
            this.panel_Container.SuspendLayout();
            this.panel_Games.SuspendLayout();
            this.panel_GameList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.divider_kmasdgn)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Loading)).BeginInit();
            this.panel_Controls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.divider_Top)).BeginInit();
            this.userMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Header
            // 
            this.panel_Header.Controls.Add(this.game_listBtn);
            this.panel_Header.Controls.Add(this.game_AddAll);
            this.panel_Header.Controls.Add(this.divider_asdahga);
            this.panel_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Header.Location = new System.Drawing.Point(130, 26);
            this.panel_Header.Name = "panel_Header";
            this.panel_Header.Size = new System.Drawing.Size(440, 30);
            this.panel_Header.TabIndex = 0;
            this.panel_Header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Header_MouseDown);
            // 
            // game_listBtn
            // 
            this.game_listBtn.AutoSize = true;
            this.game_listBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.game_listBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.game_listBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(196)))));
            this.game_listBtn.Location = new System.Drawing.Point(6, 8);
            this.game_listBtn.Name = "game_listBtn";
            this.game_listBtn.Size = new System.Drawing.Size(92, 15);
            this.game_listBtn.TabIndex = 8;
            this.game_listBtn.Text = "► Show added";
            this.game_listBtn.Click += new System.EventHandler(this.game_listBtn_Click);
            // 
            // game_AddAll
            // 
            this.game_AddAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.game_AddAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.game_AddAll.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.game_AddAll.ForeColor = System.Drawing.Color.Silver;
            this.game_AddAll.Location = new System.Drawing.Point(397, 0);
            this.game_AddAll.Name = "game_AddAll";
            this.game_AddAll.Size = new System.Drawing.Size(43, 29);
            this.game_AddAll.TabIndex = 2;
            this.game_AddAll.Text = "Add all";
            this.game_AddAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.game_AddAll.Visible = false;
            this.game_AddAll.Click += new System.EventHandler(this.game_AddAll_Click);
            // 
            // divider_asdahga
            // 
            this.divider_asdahga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.divider_asdahga.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.divider_asdahga.Location = new System.Drawing.Point(0, 29);
            this.divider_asdahga.Name = "divider_asdahga";
            this.divider_asdahga.Size = new System.Drawing.Size(440, 1);
            this.divider_asdahga.TabIndex = 1;
            this.divider_asdahga.TabStop = false;
            // 
            // panel_Menu
            // 
            this.panel_Menu.Controls.Add(this.panel1);
            this.panel_Menu.Controls.Add(this.panel2);
            this.panel_Menu.Controls.Add(this.divider_glkjjhasdfh);
            this.panel_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Menu.Location = new System.Drawing.Point(0, 26);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(130, 274);
            this.panel_Menu.TabIndex = 1;
            this.panel_Menu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Menu_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menu_Run);
            this.panel1.Controls.Add(this.menu_Add2);
            this.panel1.Controls.Add(this.menu_Add1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 30);
            this.panel1.TabIndex = 6;
            // 
            // menu_Run
            // 
            this.menu_Run.AutoSize = true;
            this.menu_Run.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_Run.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_Run.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(196)))));
            this.menu_Run.Location = new System.Drawing.Point(79, 8);
            this.menu_Run.Name = "menu_Run";
            this.menu_Run.Size = new System.Drawing.Size(44, 15);
            this.menu_Run.TabIndex = 8;
            this.menu_Run.Text = "► Run";
            this.toolTip.SetToolTip(this.menu_Run, "Run the bots");
            this.menu_Run.Visible = false;
            this.menu_Run.Click += new System.EventHandler(this.menu_Run_Click);
            // 
            // menu_Add2
            // 
            this.menu_Add2.AutoSize = true;
            this.menu_Add2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_Add2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.menu_Add2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(196)))));
            this.menu_Add2.Location = new System.Drawing.Point(30, 8);
            this.menu_Add2.Name = "menu_Add2";
            this.menu_Add2.Size = new System.Drawing.Size(18, 14);
            this.menu_Add2.TabIndex = 7;
            this.menu_Add2.Text = "▼";
            this.toolTip.SetToolTip(this.menu_Add2, "Add new account");
            this.menu_Add2.Click += new System.EventHandler(this.menu_Add2_Click);
            // 
            // menu_Add1
            // 
            this.menu_Add1.AutoSize = true;
            this.menu_Add1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_Add1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_Add1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(196)))));
            this.menu_Add1.Location = new System.Drawing.Point(3, -9);
            this.menu_Add1.Name = "menu_Add1";
            this.menu_Add1.Size = new System.Drawing.Size(70, 40);
            this.menu_Add1.TabIndex = 4;
            this.menu_Add1.Text = "+    ";
            this.toolTip.SetToolTip(this.menu_Add1, "Add new account");
            this.menu_Add1.Click += new System.EventHandler(this.menu_Add1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.userView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(129, 244);
            this.panel2.TabIndex = 8;
            // 
            // userView
            // 
            this.userView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.userView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userView.ContextMenuStrip = this.userMenu;
            this.userView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userView.Dock = System.Windows.Forms.DockStyle.Right;
            this.userView.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.userView.Location = new System.Drawing.Point(12, 0);
            this.userView.Name = "userView";
            this.userView.Size = new System.Drawing.Size(117, 244);
            this.userView.TabIndex = 0;
            this.userView.UseCompatibleStateImageBehavior = false;
            this.userView.View = System.Windows.Forms.View.SmallIcon;
            this.userView.SelectedIndexChanged += new System.EventHandler(this.userView_SelectedIndexChanged);
            // 
            // divider_glkjjhasdfh
            // 
            this.divider_glkjjhasdfh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.divider_glkjjhasdfh.Dock = System.Windows.Forms.DockStyle.Right;
            this.divider_glkjjhasdfh.Location = new System.Drawing.Point(129, 0);
            this.divider_glkjjhasdfh.Name = "divider_glkjjhasdfh";
            this.divider_glkjjhasdfh.Size = new System.Drawing.Size(1, 274);
            this.divider_glkjjhasdfh.TabIndex = 0;
            this.divider_glkjjhasdfh.TabStop = false;
            // 
            // panel_Container
            // 
            this.panel_Container.Controls.Add(this.panel_Games);
            this.panel_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Container.Location = new System.Drawing.Point(130, 56);
            this.panel_Container.Name = "panel_Container";
            this.panel_Container.Size = new System.Drawing.Size(440, 244);
            this.panel_Container.TabIndex = 2;
            // 
            // panel_Games
            // 
            this.panel_Games.Controls.Add(this.panel_GameList);
            this.panel_Games.Controls.Add(this.label_Info);
            this.panel_Games.Controls.Add(this.pic_Loading);
            this.panel_Games.Controls.Add(this.gameView);
            this.panel_Games.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Games.Location = new System.Drawing.Point(0, 0);
            this.panel_Games.Name = "panel_Games";
            this.panel_Games.Size = new System.Drawing.Size(440, 244);
            this.panel_Games.TabIndex = 2;
            // 
            // panel_GameList
            // 
            this.panel_GameList.Controls.Add(this.game_listBox);
            this.panel_GameList.Controls.Add(this.pictureBox1);
            this.panel_GameList.Controls.Add(this.game_labelCount);
            this.panel_GameList.Controls.Add(this.pictureBox2);
            this.panel_GameList.Controls.Add(this.divider_kmasdgn);
            this.panel_GameList.Controls.Add(this.panel4);
            this.panel_GameList.Location = new System.Drawing.Point(0, 0);
            this.panel_GameList.Name = "panel_GameList";
            this.panel_GameList.Size = new System.Drawing.Size(135, 244);
            this.panel_GameList.TabIndex = 4;
            this.panel_GameList.Visible = false;
            // 
            // game_listBox
            // 
            this.game_listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.game_listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.game_listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.game_listBox.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.game_listBox.ForeColor = System.Drawing.Color.Silver;
            this.game_listBox.FormattingEnabled = true;
            this.game_listBox.IntegralHeight = false;
            this.game_listBox.Location = new System.Drawing.Point(0, 28);
            this.game_listBox.Name = "game_listBox";
            this.game_listBox.Size = new System.Drawing.Size(134, 200);
            this.game_listBox.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 1);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // game_labelCount
            // 
            this.game_labelCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.game_labelCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.game_labelCount.ForeColor = System.Drawing.Color.Silver;
            this.game_labelCount.Location = new System.Drawing.Point(0, 0);
            this.game_labelCount.Name = "game_labelCount";
            this.game_labelCount.Size = new System.Drawing.Size(134, 27);
            this.game_labelCount.TabIndex = 9;
            this.game_labelCount.Text = "Games: 0";
            this.game_labelCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 228);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 1);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // divider_kmasdgn
            // 
            this.divider_kmasdgn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.divider_kmasdgn.Dock = System.Windows.Forms.DockStyle.Right;
            this.divider_kmasdgn.Location = new System.Drawing.Point(134, 0);
            this.divider_kmasdgn.Name = "divider_kmasdgn";
            this.divider_kmasdgn.Size = new System.Drawing.Size(1, 229);
            this.divider_kmasdgn.TabIndex = 6;
            this.divider_kmasdgn.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.text_User);
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.Location = new System.Drawing.Point(0, 229);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(135, 15);
            this.panel4.TabIndex = 12;
            // 
            // text_User
            // 
            this.text_User.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_User.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_User.Dock = System.Windows.Forms.DockStyle.Top;
            this.text_User.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_User.ForeColor = System.Drawing.Color.Gray;
            this.text_User.Location = new System.Drawing.Point(0, 0);
            this.text_User.Name = "text_User";
            this.text_User.Size = new System.Drawing.Size(134, 15);
            this.text_User.TabIndex = 2;
            this.text_User.Text = "Game ID";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox3.Location = new System.Drawing.Point(134, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1, 15);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // label_Info
            // 
            this.label_Info.AutoSize = true;
            this.label_Info.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Info.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Info.ForeColor = System.Drawing.Color.Silver;
            this.label_Info.Location = new System.Drawing.Point(140, 107);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(147, 13);
            this.label_Info.TabIndex = 3;
            this.label_Info.Text = "You\'re out of games to add";
            this.label_Info.Visible = false;
            // 
            // pic_Loading
            // 
            this.pic_Loading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Loading.Image = ((System.Drawing.Image)(resources.GetObject("pic_Loading.Image")));
            this.pic_Loading.Location = new System.Drawing.Point(186, 94);
            this.pic_Loading.Name = "pic_Loading";
            this.pic_Loading.Size = new System.Drawing.Size(40, 40);
            this.pic_Loading.TabIndex = 1;
            this.pic_Loading.TabStop = false;
            this.pic_Loading.Visible = false;
            // 
            // gameView
            // 
            this.gameView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.gameView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gameView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gameView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameView.Location = new System.Drawing.Point(0, 0);
            this.gameView.Name = "gameView";
            this.gameView.Size = new System.Drawing.Size(440, 244);
            this.gameView.TabIndex = 0;
            this.gameView.UseCompatibleStateImageBehavior = false;
            this.gameView.Visible = false;
            this.gameView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameView_MouseClick);
            // 
            // control_Exit
            // 
            this.control_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.control_Exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.control_Exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.control_Exit.FlatAppearance.BorderSize = 0;
            this.control_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.control_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.control_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.control_Exit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.control_Exit.Location = new System.Drawing.Point(545, 0);
            this.control_Exit.Name = "control_Exit";
            this.control_Exit.Size = new System.Drawing.Size(25, 25);
            this.control_Exit.TabIndex = 0;
            this.control_Exit.Text = "×";
            this.toolTip.SetToolTip(this.control_Exit, "Close");
            this.control_Exit.UseVisualStyleBackColor = true;
            this.control_Exit.Click += new System.EventHandler(this.control_Exit_Click);
            this.control_Exit.MouseEnter += new System.EventHandler(this.control_Exit_MouseEnter);
            this.control_Exit.MouseLeave += new System.EventHandler(this.control_Exit_MouseLeave);
            // 
            // panel_Controls
            // 
            this.panel_Controls.Controls.Add(this.control_Min);
            this.panel_Controls.Controls.Add(this.control_State);
            this.panel_Controls.Controls.Add(this.control_Exit);
            this.panel_Controls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Controls.Location = new System.Drawing.Point(0, 1);
            this.panel_Controls.Name = "panel_Controls";
            this.panel_Controls.Size = new System.Drawing.Size(570, 25);
            this.panel_Controls.TabIndex = 1;
            this.panel_Controls.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Controls_MouseDown);
            // 
            // control_Min
            // 
            this.control_Min.Cursor = System.Windows.Forms.Cursors.Hand;
            this.control_Min.Dock = System.Windows.Forms.DockStyle.Right;
            this.control_Min.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.control_Min.FlatAppearance.BorderSize = 0;
            this.control_Min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(82)))));
            this.control_Min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(82)))));
            this.control_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.control_Min.Location = new System.Drawing.Point(495, 0);
            this.control_Min.Name = "control_Min";
            this.control_Min.Size = new System.Drawing.Size(25, 25);
            this.control_Min.TabIndex = 2;
            this.control_Min.Text = "_";
            this.toolTip.SetToolTip(this.control_Min, "Minimize");
            this.control_Min.UseVisualStyleBackColor = true;
            this.control_Min.Click += new System.EventHandler(this.control_Min_Click);
            this.control_Min.MouseEnter += new System.EventHandler(this.control_Min_MouseEnter);
            this.control_Min.MouseLeave += new System.EventHandler(this.control_Min_MouseLeave);
            // 
            // control_State
            // 
            this.control_State.Cursor = System.Windows.Forms.Cursors.Hand;
            this.control_State.Dock = System.Windows.Forms.DockStyle.Right;
            this.control_State.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.control_State.FlatAppearance.BorderSize = 0;
            this.control_State.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.control_State.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.control_State.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.control_State.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.control_State.Location = new System.Drawing.Point(520, 0);
            this.control_State.Name = "control_State";
            this.control_State.Size = new System.Drawing.Size(25, 25);
            this.control_State.TabIndex = 1;
            this.control_State.Text = "□";
            this.toolTip.SetToolTip(this.control_State, "Maximize");
            this.control_State.UseVisualStyleBackColor = true;
            this.control_State.Click += new System.EventHandler(this.control_State_Click);
            this.control_State.MouseEnter += new System.EventHandler(this.control_State_MouseEnter);
            this.control_State.MouseLeave += new System.EventHandler(this.control_State_MouseLeave);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Silver;
            // 
            // gameFetcher
            // 
            this.gameFetcher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.gameFetcher_DoWork);
            this.gameFetcher.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.gameFetcher_RunWorkerCompleted);
            // 
            // divider_Top
            // 
            this.divider_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(196)))));
            this.divider_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.divider_Top.Location = new System.Drawing.Point(0, 0);
            this.divider_Top.Name = "divider_Top";
            this.divider_Top.Size = new System.Drawing.Size(570, 1);
            this.divider_Top.TabIndex = 4;
            this.divider_Top.TabStop = false;
            // 
            // userMenu
            // 
            this.userMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.userMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userMenu_Remove});
            this.userMenu.Name = "userMenu";
            this.userMenu.ShowImageMargin = false;
            this.userMenu.Size = new System.Drawing.Size(93, 26);
            this.userMenu.Opening += new System.ComponentModel.CancelEventHandler(this.userMenu_Opening);
            // 
            // userMenu_Remove
            // 
            this.userMenu_Remove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.userMenu_Remove.Name = "userMenu_Remove";
            this.userMenu_Remove.Size = new System.Drawing.Size(127, 22);
            this.userMenu_Remove.Text = "Remove";
            this.userMenu_Remove.Click += new System.EventHandler(this.userMenu_Remove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(570, 300);
            this.Controls.Add(this.panel_Container);
            this.Controls.Add(this.panel_Header);
            this.Controls.Add(this.panel_Menu);
            this.Controls.Add(this.panel_Controls);
            this.Controls.Add(this.divider_Top);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_Header.ResumeLayout(false);
            this.panel_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.divider_asdahga)).EndInit();
            this.panel_Menu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.divider_glkjjhasdfh)).EndInit();
            this.panel_Container.ResumeLayout(false);
            this.panel_Games.ResumeLayout(false);
            this.panel_Games.PerformLayout();
            this.panel_GameList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.divider_kmasdgn)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Loading)).EndInit();
            this.panel_Controls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.divider_Top)).EndInit();
            this.userMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Header;
        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.Panel panel_Container;
        private System.Windows.Forms.Button control_Exit;
        private System.Windows.Forms.Panel panel_Controls;
        private System.Windows.Forms.PictureBox divider_glkjjhasdfh;
        private System.Windows.Forms.PictureBox divider_asdahga;
        private System.Windows.Forms.Button control_Min;
        private System.Windows.Forms.Button control_State;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label menu_Add1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_Games;
        private System.Windows.Forms.Label menu_Add2;
        private System.Windows.Forms.ListView gameView;
        private System.ComponentModel.BackgroundWorker gameFetcher;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pic_Loading;
        private System.Windows.Forms.PictureBox divider_Top;
        private System.Windows.Forms.ListView userView;
        private System.Windows.Forms.Label game_AddAll;
        private System.Windows.Forms.Label label_Info;
        private System.Windows.Forms.Label game_listBtn;
        private System.Windows.Forms.Panel panel_GameList;
        private System.Windows.Forms.PictureBox divider_kmasdgn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label game_labelCount;
        private System.Windows.Forms.ListBox game_listBox;
        private System.Windows.Forms.TextBox text_User;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label menu_Run;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ContextMenuStrip userMenu;
        private System.Windows.Forms.ToolStripMenuItem userMenu_Remove;
    }
}

