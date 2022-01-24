namespace HourBoostr_Beta.Ui.MultiBoostr
{
    partial class MultiBoostr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiBoostr));
            this.HeaderDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.HeaderPanel = new Bunifu.UI.WinForms.BunifuPanel();
            this.HeaderTitle = new Bunifu.UI.WinForms.BunifuLabel();
            this.BackButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.ExitButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.WindowElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.AccountListGroupBox = new System.Windows.Forms.GroupBox();
            this.AccountListBox = new System.Windows.Forms.ListBox();
            this.AddNewAccountButton = new System.Windows.Forms.Label();
            this.StartIdlerButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.AccountGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblFindGames = new System.Windows.Forms.Label();
            this.txtGameItem = new System.Windows.Forms.TextBox();
            this.gameList = new System.Windows.Forms.ListBox();
            this.lblRemoveLoginKey = new System.Windows.Forms.Label();
            this.LoginKeyInputBox = new System.Windows.Forms.TextBox();
            this.PasswordInputBox = new System.Windows.Forms.TextBox();
            this.UsernameInputBox = new System.Windows.Forms.TextBox();
            this.HeaderPanel.SuspendLayout();
            this.AccountListGroupBox.SuspendLayout();
            this.AccountGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderDragControl
            // 
            this.HeaderDragControl.Fixed = true;
            this.HeaderDragControl.Horizontal = true;
            this.HeaderDragControl.TargetControl = this.HeaderPanel;
            this.HeaderDragControl.Vertical = true;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackgroundColor = System.Drawing.Color.Transparent;
            this.HeaderPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HeaderPanel.BackgroundImage")));
            this.HeaderPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HeaderPanel.BorderColor = System.Drawing.Color.Transparent;
            this.HeaderPanel.BorderRadius = 3;
            this.HeaderPanel.BorderThickness = 1;
            this.HeaderPanel.Controls.Add(this.HeaderTitle);
            this.HeaderPanel.Controls.Add(this.BackButton);
            this.HeaderPanel.Controls.Add(this.ExitButton);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.ShowBorders = true;
            this.HeaderPanel.Size = new System.Drawing.Size(800, 35);
            this.HeaderPanel.TabIndex = 0;
            // 
            // HeaderTitle
            // 
            this.HeaderTitle.AllowParentOverrides = false;
            this.HeaderTitle.AutoEllipsis = false;
            this.HeaderTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.HeaderTitle.CursorType = System.Windows.Forms.Cursors.Default;
            this.HeaderTitle.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.HeaderTitle.Location = new System.Drawing.Point(352, 3);
            this.HeaderTitle.Name = "HeaderTitle";
            this.HeaderTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HeaderTitle.Size = new System.Drawing.Size(105, 22);
            this.HeaderTitle.TabIndex = 1;
            this.HeaderTitle.Text = "MultiBoostr";
            this.HeaderTitle.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.HeaderTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // BackButton
            // 
            this.BackButton.ActiveImage = global::HourBoostr_Beta.Properties.Resources.Back_Hovered;
            this.BackButton.AllowAnimations = true;
            this.BackButton.AllowBuffering = false;
            this.BackButton.AllowToggling = false;
            this.BackButton.AllowZooming = false;
            this.BackButton.AllowZoomingOnFocus = false;
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BackButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BackButton.ErrorImage")));
            this.BackButton.FadeWhenInactive = true;
            this.BackButton.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.BackButton.Image = global::HourBoostr_Beta.Properties.Resources.Back;
            this.BackButton.ImageActive = global::HourBoostr_Beta.Properties.Resources.Back_Hovered;
            this.BackButton.ImageLocation = null;
            this.BackButton.ImageMargin = 0;
            this.BackButton.ImageSize = new System.Drawing.Size(35, 34);
            this.BackButton.ImageZoomSize = new System.Drawing.Size(35, 34);
            this.BackButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("BackButton.InitialImage")));
            this.BackButton.Location = new System.Drawing.Point(0, 0);
            this.BackButton.Name = "BackButton";
            this.BackButton.Rotation = 0;
            this.BackButton.ShowActiveImage = true;
            this.BackButton.ShowCursorChanges = true;
            this.BackButton.ShowImageBorders = true;
            this.BackButton.ShowSizeMarkers = false;
            this.BackButton.Size = new System.Drawing.Size(35, 34);
            this.BackButton.TabIndex = 4;
            this.BackButton.ToolTipText = "Exit HourBoostr";
            this.BackButton.WaitOnLoad = false;
            this.BackButton.Zoom = 0;
            this.BackButton.ZoomSpeed = 10;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.ActiveImage = global::HourBoostr_Beta.Properties.Resources.Exit_Hovered;
            this.ExitButton.AllowAnimations = true;
            this.ExitButton.AllowBuffering = false;
            this.ExitButton.AllowToggling = false;
            this.ExitButton.AllowZooming = false;
            this.ExitButton.AllowZoomingOnFocus = false;
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ExitButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("ExitButton.ErrorImage")));
            this.ExitButton.FadeWhenInactive = false;
            this.ExitButton.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.ExitButton.Image = global::HourBoostr_Beta.Properties.Resources.Exit;
            this.ExitButton.ImageActive = global::HourBoostr_Beta.Properties.Resources.Exit_Hovered;
            this.ExitButton.ImageLocation = null;
            this.ExitButton.ImageMargin = 0;
            this.ExitButton.ImageSize = new System.Drawing.Size(35, 34);
            this.ExitButton.ImageZoomSize = new System.Drawing.Size(35, 34);
            this.ExitButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("ExitButton.InitialImage")));
            this.ExitButton.Location = new System.Drawing.Point(765, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Rotation = 0;
            this.ExitButton.ShowActiveImage = true;
            this.ExitButton.ShowCursorChanges = true;
            this.ExitButton.ShowImageBorders = true;
            this.ExitButton.ShowSizeMarkers = false;
            this.ExitButton.Size = new System.Drawing.Size(35, 34);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.ToolTipText = "Exit HourBoostr";
            this.ExitButton.WaitOnLoad = false;
            this.ExitButton.Zoom = 0;
            this.ExitButton.ZoomSpeed = 10;
            this.ExitButton.Click += Program.This.Close;
            // 
            // WindowElipse
            // 
            this.WindowElipse.ElipseRadius = 15;
            this.WindowElipse.TargetControl = this;
            // 
            // AccountListGroupBox
            // 
            this.AccountListGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.AccountListGroupBox.Controls.Add(this.AccountListBox);
            this.AccountListGroupBox.Location = new System.Drawing.Point(0, 57);
            this.AccountListGroupBox.Name = "AccountListGroupBox";
            this.AccountListGroupBox.Size = new System.Drawing.Size(183, 296);
            this.AccountListGroupBox.TabIndex = 10;
            this.AccountListGroupBox.TabStop = false;
            // 
            // AccountListBox
            // 
            this.AccountListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AccountListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AccountListBox.ColumnWidth = 5;
            this.AccountListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountListBox.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountListBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.AccountListBox.FormattingEnabled = true;
            this.AccountListBox.IntegralHeight = false;
            this.AccountListBox.ItemHeight = 21;
            this.AccountListBox.Items.AddRange(new object[] {
            "Test",
            "Test2"});
            this.AccountListBox.Location = new System.Drawing.Point(3, 16);
            this.AccountListBox.Name = "AccountListBox";
            this.AccountListBox.Size = new System.Drawing.Size(177, 277);
            this.AccountListBox.TabIndex = 0;
            this.AccountListBox.SelectedIndexChanged += new System.EventHandler(this.AccountListBox_SelectedIndexChanged);
            // 
            // AddNewAccountButton
            // 
            this.AddNewAccountButton.AutoSize = true;
            this.AddNewAccountButton.BackColor = System.Drawing.Color.Transparent;
            this.AddNewAccountButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddNewAccountButton.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewAccountButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.AddNewAccountButton.Location = new System.Drawing.Point(8, 54);
            this.AddNewAccountButton.Name = "AddNewAccountButton";
            this.AddNewAccountButton.Size = new System.Drawing.Size(101, 18);
            this.AddNewAccountButton.TabIndex = 12;
            this.AddNewAccountButton.Text = "+ Add account";
            this.AddNewAccountButton.Click += new System.EventHandler(this.AddNewAccountButton_Click);
            // 
            // StartIdlerButton
            // 
            this.StartIdlerButton.ActiveImage = null;
            this.StartIdlerButton.AllowAnimations = true;
            this.StartIdlerButton.AllowBuffering = false;
            this.StartIdlerButton.AllowToggling = false;
            this.StartIdlerButton.AllowZooming = true;
            this.StartIdlerButton.AllowZoomingOnFocus = false;
            this.StartIdlerButton.BackColor = System.Drawing.Color.Transparent;
            this.StartIdlerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StartIdlerButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.StartIdlerButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("StartIdlerButton.ErrorImage")));
            this.StartIdlerButton.FadeWhenInactive = true;
            this.StartIdlerButton.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.StartIdlerButton.Image = global::HourBoostr_Beta.Properties.Resources.TradingCardsButton;
            this.StartIdlerButton.ImageActive = null;
            this.StartIdlerButton.ImageLocation = null;
            this.StartIdlerButton.ImageMargin = 0;
            this.StartIdlerButton.ImageSize = new System.Drawing.Size(182, 92);
            this.StartIdlerButton.ImageZoomSize = new System.Drawing.Size(183, 93);
            this.StartIdlerButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("StartIdlerButton.InitialImage")));
            this.StartIdlerButton.Location = new System.Drawing.Point(0, 359);
            this.StartIdlerButton.Name = "StartIdlerButton";
            this.StartIdlerButton.Rotation = 0;
            this.StartIdlerButton.ShowActiveImage = true;
            this.StartIdlerButton.ShowCursorChanges = true;
            this.StartIdlerButton.ShowImageBorders = true;
            this.StartIdlerButton.ShowSizeMarkers = false;
            this.StartIdlerButton.Size = new System.Drawing.Size(183, 93);
            this.StartIdlerButton.TabIndex = 13;
            this.StartIdlerButton.ToolTipText = "Start Idler";
            this.StartIdlerButton.WaitOnLoad = false;
            this.StartIdlerButton.Zoom = 0;
            this.StartIdlerButton.ZoomSpeed = 10;
            this.StartIdlerButton.Click += new System.EventHandler(this.StartIdlerButton_Click);
            // 
            // AccountGroupBox
            // 
            this.AccountGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.AccountGroupBox.Controls.Add(this.groupBox3);
            this.AccountGroupBox.Controls.Add(this.lblRemoveLoginKey);
            this.AccountGroupBox.Controls.Add(this.LoginKeyInputBox);
            this.AccountGroupBox.Controls.Add(this.PasswordInputBox);
            this.AccountGroupBox.Controls.Add(this.UsernameInputBox);
            this.AccountGroupBox.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountGroupBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.AccountGroupBox.Location = new System.Drawing.Point(189, 56);
            this.AccountGroupBox.Name = "AccountGroupBox";
            this.AccountGroupBox.Size = new System.Drawing.Size(610, 392);
            this.AccountGroupBox.TabIndex = 14;
            this.AccountGroupBox.TabStop = false;
            this.AccountGroupBox.Text = "New Account";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblFindGames);
            this.groupBox3.Controls.Add(this.txtGameItem);
            this.groupBox3.Controls.Add(this.gameList);
            this.groupBox3.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBox3.Location = new System.Drawing.Point(343, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 361);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Games";
            // 
            // lblFindGames
            // 
            this.lblFindGames.AutoSize = true;
            this.lblFindGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFindGames.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFindGames.Location = new System.Drawing.Point(171, 331);
            this.lblFindGames.Name = "lblFindGames";
            this.lblFindGames.Size = new System.Drawing.Size(79, 16);
            this.lblFindGames.TabIndex = 4;
            this.lblFindGames.Text = "Find Games";
            // 
            // txtGameItem
            // 
            this.txtGameItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtGameItem.ForeColor = System.Drawing.Color.Gray;
            this.txtGameItem.Location = new System.Drawing.Point(6, 328);
            this.txtGameItem.Name = "txtGameItem";
            this.txtGameItem.Size = new System.Drawing.Size(246, 22);
            this.txtGameItem.TabIndex = 3;
            // 
            // gameList
            // 
            this.gameList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gameList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameList.ForeColor = System.Drawing.Color.Gainsboro;
            this.gameList.FormattingEnabled = true;
            this.gameList.IntegralHeight = false;
            this.gameList.ItemHeight = 16;
            this.gameList.Location = new System.Drawing.Point(6, 22);
            this.gameList.Name = "gameList";
            this.gameList.Size = new System.Drawing.Size(244, 300);
            this.gameList.TabIndex = 2;
            // 
            // lblRemoveLoginKey
            // 
            this.lblRemoveLoginKey.AutoSize = true;
            this.lblRemoveLoginKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRemoveLoginKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRemoveLoginKey.Location = new System.Drawing.Point(272, 94);
            this.lblRemoveLoginKey.Name = "lblRemoveLoginKey";
            this.lblRemoveLoginKey.Size = new System.Drawing.Size(54, 16);
            this.lblRemoveLoginKey.TabIndex = 3;
            this.lblRemoveLoginKey.Text = "remove";
            // 
            // LoginKeyInputBox
            // 
            this.LoginKeyInputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LoginKeyInputBox.ForeColor = System.Drawing.Color.Gray;
            this.LoginKeyInputBox.Location = new System.Drawing.Point(15, 91);
            this.LoginKeyInputBox.Name = "LoginKeyInputBox";
            this.LoginKeyInputBox.Size = new System.Drawing.Size(313, 22);
            this.LoginKeyInputBox.TabIndex = 2;
            // 
            // PasswordInputBox
            // 
            this.PasswordInputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PasswordInputBox.ForeColor = System.Drawing.Color.Gray;
            this.PasswordInputBox.Location = new System.Drawing.Point(15, 63);
            this.PasswordInputBox.Name = "PasswordInputBox";
            this.PasswordInputBox.PasswordChar = '*';
            this.PasswordInputBox.Size = new System.Drawing.Size(313, 22);
            this.PasswordInputBox.TabIndex = 1;
            // 
            // UsernameInputBox
            // 
            this.UsernameInputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UsernameInputBox.ForeColor = System.Drawing.Color.Gray;
            this.UsernameInputBox.Location = new System.Drawing.Point(15, 34);
            this.UsernameInputBox.Name = "UsernameInputBox";
            this.UsernameInputBox.Size = new System.Drawing.Size(313, 22);
            this.UsernameInputBox.TabIndex = 0;
            this.UsernameInputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UsernameInputBox_KeyUp);
            // 
            // MultiBoostr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.BackgroundImage = global::HourBoostr_Beta.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.AccountGroupBox);
            this.Controls.Add(this.StartIdlerButton);
            this.Controls.Add(this.AddNewAccountButton);
            this.Controls.Add(this.AccountListGroupBox);
            this.Controls.Add(this.HeaderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MultiBoostr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MulitBoostr";
            this.Load += new System.EventHandler(this.MultiBoostr_Load);
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.AccountListGroupBox.ResumeLayout(false);
            this.AccountGroupBox.ResumeLayout(false);
            this.AccountGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel HeaderPanel;
        private Bunifu.Framework.UI.BunifuDragControl HeaderDragControl;
        private Bunifu.UI.WinForms.BunifuImageButton ExitButton;
        private Bunifu.UI.WinForms.BunifuImageButton BackButton;
        private Bunifu.Framework.UI.BunifuElipse WindowElipse;
        private Bunifu.UI.WinForms.BunifuLabel HeaderTitle;
        private System.Windows.Forms.Label AddNewAccountButton;
        private System.Windows.Forms.GroupBox AccountListGroupBox;
        private Bunifu.UI.WinForms.BunifuImageButton StartIdlerButton;
        private System.Windows.Forms.ListBox AccountListBox;
        private System.Windows.Forms.GroupBox AccountGroupBox;
        private System.Windows.Forms.Label lblRemoveLoginKey;
        private System.Windows.Forms.TextBox LoginKeyInputBox;
        private System.Windows.Forms.TextBox PasswordInputBox;
        private System.Windows.Forms.TextBox UsernameInputBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblFindGames;
        private System.Windows.Forms.TextBox txtGameItem;
        private System.Windows.Forms.ListBox gameList;
    }
}