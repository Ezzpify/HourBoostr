namespace HourBoostr_Beta.Ui.SingleBoostr
{
    partial class GameLibrary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameLibrary));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.BackButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.ExitButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.WindowElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.HeaderPanel = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.HeaderTitle = new Bunifu.UI.WinForms.BunifuLabel();
            this.HeaderDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.GameSearchBox = new Bunifu.UI.WinForms.BunifuTextBox();
            this.bunifuDropdown1 = new Bunifu.UI.WinForms.BunifuDropdown();
            this.GameList = new System.Windows.Forms.ListBox();
            this.SelectedGamePanel = new System.Windows.Forms.Panel();
            this.GameLabel = new Bunifu.UI.WinForms.BunifuLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.HeaderPanel.SuspendLayout();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SelectedGamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuPanel2
            // 
            this.bunifuPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bunifuPanel2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel2.BackgroundImage")));
            this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuPanel2.BorderRadius = 0;
            this.bunifuPanel2.BorderThickness = 0;
            this.bunifuPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuPanel2.Location = new System.Drawing.Point(0, 406);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.ShowBorders = true;
            this.bunifuPanel2.Size = new System.Drawing.Size(800, 44);
            this.bunifuPanel2.TabIndex = 1;
            // 
            // BackButton
            // 
            this.BackButton.ActiveImage = global::HourBoostr_Beta.Properties.Resources.Back_Hovered;
            this.BackButton.AllowAnimations = true;
            this.BackButton.AllowBuffering = false;
            this.BackButton.AllowToggling = false;
            this.BackButton.AllowZooming = true;
            this.BackButton.AllowZoomingOnFocus = false;
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BackButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("BackButton.ErrorImage")));
            this.BackButton.FadeWhenInactive = false;
            this.BackButton.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.BackButton.Image = global::HourBoostr_Beta.Properties.Resources.Back;
            this.BackButton.ImageActive = global::HourBoostr_Beta.Properties.Resources.Back_Hovered;
            this.BackButton.ImageLocation = null;
            this.BackButton.ImageMargin = 0;
            this.BackButton.ImageSize = new System.Drawing.Size(34, 33);
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
            this.BackButton.TabIndex = 5;
            this.BackButton.ToolTipText = "Go back";
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
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ExitButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("ExitButton.ErrorImage")));
            this.ExitButton.FadeWhenInactive = false;
            this.ExitButton.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.ExitButton.Image = global::HourBoostr_Beta.Properties.Resources.Exit;
            this.ExitButton.ImageActive = global::HourBoostr_Beta.Properties.Resources.Exit_Hovered;
            this.ExitButton.ImageLocation = null;
            this.ExitButton.ImageMargin = 0;
            this.ExitButton.ImageSize = new System.Drawing.Size(55, 35);
            this.ExitButton.ImageZoomSize = new System.Drawing.Size(55, 35);
            this.ExitButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("ExitButton.InitialImage")));
            this.ExitButton.Location = new System.Drawing.Point(745, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Rotation = 0;
            this.ExitButton.ShowActiveImage = true;
            this.ExitButton.ShowCursorChanges = true;
            this.ExitButton.ShowImageBorders = true;
            this.ExitButton.ShowSizeMarkers = false;
            this.ExitButton.Size = new System.Drawing.Size(55, 35);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.ToolTipText = "Exit HourBoostr";
            this.ExitButton.WaitOnLoad = false;
            this.ExitButton.Zoom = 0;
            this.ExitButton.ZoomSpeed = 10;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // WindowElipse
            // 
            this.WindowElipse.ElipseRadius = 15;
            this.WindowElipse.TargetControl = this;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.Transparent;
            this.HeaderPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HeaderPanel.BackgroundImage")));
            this.HeaderPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HeaderPanel.BorderRadius = 1;
            this.HeaderPanel.Controls.Add(this.HeaderTitle);
            this.HeaderPanel.Controls.Add(this.BackButton);
            this.HeaderPanel.Controls.Add(this.ExitButton);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.HeaderPanel.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.HeaderPanel.GradientTopLeft = System.Drawing.Color.DodgerBlue;
            this.HeaderPanel.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Quality = 10;
            this.HeaderPanel.Size = new System.Drawing.Size(800, 33);
            this.HeaderPanel.TabIndex = 2;
            // 
            // HeaderTitle
            // 
            this.HeaderTitle.AllowParentOverrides = false;
            this.HeaderTitle.AutoEllipsis = false;
            this.HeaderTitle.CursorType = null;
            this.HeaderTitle.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.HeaderTitle.Location = new System.Drawing.Point(310, 5);
            this.HeaderTitle.Name = "HeaderTitle";
            this.HeaderTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HeaderTitle.Size = new System.Drawing.Size(172, 22);
            this.HeaderTitle.TabIndex = 6;
            this.HeaderTitle.Text = "SingleBoostr Library";
            this.HeaderTitle.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.HeaderTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // HeaderDragControl
            // 
            this.HeaderDragControl.Fixed = true;
            this.HeaderDragControl.Horizontal = true;
            this.HeaderDragControl.TargetControl = this.HeaderPanel;
            this.HeaderDragControl.Vertical = true;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.BorderRadius = 1;
            this.bunifuGradientPanel1.Controls.Add(this.GameSearchBox);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuDropdown1);
            this.bunifuGradientPanel1.Controls.Add(this.GameList);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.DodgerBlue;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(30)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 33);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(200, 373);
            this.bunifuGradientPanel1.TabIndex = 3;
            // 
            // GameSearchBox
            // 
            this.GameSearchBox.AcceptsReturn = false;
            this.GameSearchBox.AcceptsTab = false;
            this.GameSearchBox.AnimationSpeed = 200;
            this.GameSearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.GameSearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.GameSearchBox.BackColor = System.Drawing.Color.Transparent;
            this.GameSearchBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GameSearchBox.BackgroundImage")));
            this.GameSearchBox.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.GameSearchBox.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.GameSearchBox.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.GameSearchBox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.GameSearchBox.BorderRadius = 1;
            this.GameSearchBox.BorderThickness = 0;
            this.GameSearchBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.GameSearchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GameSearchBox.DefaultFont = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameSearchBox.DefaultText = "";
            this.GameSearchBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.GameSearchBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GameSearchBox.HideSelection = true;
            this.GameSearchBox.IconLeft = global::HourBoostr_Beta.Properties.Resources.Min_Hovered;
            this.GameSearchBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.GameSearchBox.IconPadding = 10;
            this.GameSearchBox.IconRight = null;
            this.GameSearchBox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.GameSearchBox.Lines = new string[0];
            this.GameSearchBox.Location = new System.Drawing.Point(0, 45);
            this.GameSearchBox.MaxLength = 32767;
            this.GameSearchBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.GameSearchBox.Modified = false;
            this.GameSearchBox.Multiline = false;
            this.GameSearchBox.Name = "GameSearchBox";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.GameSearchBox.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.GameSearchBox.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.GameSearchBox.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            stateProperties4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            stateProperties4.ForeColor = System.Drawing.Color.WhiteSmoke;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.GameSearchBox.OnIdleState = stateProperties4;
            this.GameSearchBox.Padding = new System.Windows.Forms.Padding(3);
            this.GameSearchBox.PasswordChar = '\0';
            this.GameSearchBox.PlaceholderForeColor = System.Drawing.Color.WhiteSmoke;
            this.GameSearchBox.PlaceholderText = "";
            this.GameSearchBox.ReadOnly = false;
            this.GameSearchBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.GameSearchBox.SelectedText = "";
            this.GameSearchBox.SelectionLength = 0;
            this.GameSearchBox.SelectionStart = 0;
            this.GameSearchBox.ShortcutsEnabled = true;
            this.GameSearchBox.Size = new System.Drawing.Size(200, 35);
            this.GameSearchBox.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.GameSearchBox.TabIndex = 1;
            this.GameSearchBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.GameSearchBox.TextMarginBottom = 0;
            this.GameSearchBox.TextMarginLeft = 5;
            this.GameSearchBox.TextMarginTop = 0;
            this.GameSearchBox.TextPlaceholder = "";
            this.GameSearchBox.UseSystemPasswordChar = false;
            this.GameSearchBox.WordWrap = true;
            this.GameSearchBox.MouseLeave += new System.EventHandler(this.GameSearchBox_MouseLeave);
            this.GameSearchBox.MouseHover += new System.EventHandler(this.GameSearchBox_MouseHover);
            // 
            // bunifuDropdown1
            // 
            this.bunifuDropdown1.AutoCompleteCustomSource.AddRange(new string[] {
            "Games",
            "Tools",
            "Software",
            "DLC",
            "Other"});
            this.bunifuDropdown1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDropdown1.BackgroundColor = System.Drawing.Color.Transparent;
            this.bunifuDropdown1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuDropdown1.BorderRadius = 1;
            this.bunifuDropdown1.Color = System.Drawing.Color.Transparent;
            this.bunifuDropdown1.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.bunifuDropdown1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.bunifuDropdown1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuDropdown1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.bunifuDropdown1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.bunifuDropdown1.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.bunifuDropdown1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bunifuDropdown1.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.bunifuDropdown1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bunifuDropdown1.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.bunifuDropdown1.FillDropDown = true;
            this.bunifuDropdown1.FillIndicator = false;
            this.bunifuDropdown1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuDropdown1.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDropdown1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuDropdown1.FormattingEnabled = true;
            this.bunifuDropdown1.Icon = null;
            this.bunifuDropdown1.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.bunifuDropdown1.IndicatorColor = System.Drawing.Color.Gray;
            this.bunifuDropdown1.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.bunifuDropdown1.ItemBackColor = System.Drawing.Color.White;
            this.bunifuDropdown1.ItemBorderColor = System.Drawing.Color.White;
            this.bunifuDropdown1.ItemForeColor = System.Drawing.Color.White;
            this.bunifuDropdown1.ItemHeight = 26;
            this.bunifuDropdown1.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.bunifuDropdown1.ItemHighLightForeColor = System.Drawing.Color.White;
            this.bunifuDropdown1.Items.AddRange(new object[] {
            "Games",
            "Software",
            "Tools",
            "DLC",
            "Other"});
            this.bunifuDropdown1.ItemTopMargin = 3;
            this.bunifuDropdown1.Location = new System.Drawing.Point(3, 7);
            this.bunifuDropdown1.Name = "bunifuDropdown1";
            this.bunifuDropdown1.Size = new System.Drawing.Size(118, 32);
            this.bunifuDropdown1.TabIndex = 1;
            this.bunifuDropdown1.Text = "Selection";
            this.bunifuDropdown1.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.bunifuDropdown1.TextLeftMargin = 5;
            // 
            // GameList
            // 
            this.GameList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.GameList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GameList.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameList.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GameList.FormattingEnabled = true;
            this.GameList.ItemHeight = 22;
            this.GameList.Items.AddRange(new object[] {
            "Aim Lab",
            "Apex Legends",
            "Arma 3"});
            this.GameList.Location = new System.Drawing.Point(0, 77);
            this.GameList.Name = "GameList";
            this.GameList.Size = new System.Drawing.Size(197, 308);
            this.GameList.TabIndex = 0;
            this.GameList.SelectedIndexChanged += new System.EventHandler(this.GameList_SelectedIndexChanged);
            // 
            // SelectedGamePanel
            // 
            this.SelectedGamePanel.BackColor = System.Drawing.Color.Transparent;
            this.SelectedGamePanel.Controls.Add(this.button1);
            this.SelectedGamePanel.Controls.Add(this.GameLabel);
            this.SelectedGamePanel.Location = new System.Drawing.Point(203, 33);
            this.SelectedGamePanel.Name = "SelectedGamePanel";
            this.SelectedGamePanel.Size = new System.Drawing.Size(597, 373);
            this.SelectedGamePanel.TabIndex = 4;
            // 
            // GameLabel
            // 
            this.GameLabel.AllowParentOverrides = false;
            this.GameLabel.AutoEllipsis = false;
            this.GameLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.GameLabel.CursorType = System.Windows.Forms.Cursors.Default;
            this.GameLabel.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameLabel.ForeColor = System.Drawing.Color.Silver;
            this.GameLabel.Location = new System.Drawing.Point(12, 6);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GameLabel.Size = new System.Drawing.Size(213, 33);
            this.GameLabel.TabIndex = 0;
            this.GameLabel.Text = "Some Game Title";
            this.GameLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.GameLabel.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(213, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GameLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HourBoostr_Beta.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectedGamePanel);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.bunifuPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameLibrary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GameLibrary";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameLibrary_FormClosing);
            this.Load += new System.EventHandler(this.GameLibrary_Load);
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.SelectedGamePanel.ResumeLayout(false);
            this.SelectedGamePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
        private Bunifu.UI.WinForms.BunifuImageButton BackButton;
        private Bunifu.UI.WinForms.BunifuImageButton ExitButton;
        private Bunifu.Framework.UI.BunifuElipse WindowElipse;
        private Bunifu.UI.WinForms.BunifuGradientPanel HeaderPanel;
        private Bunifu.Framework.UI.BunifuDragControl HeaderDragControl;
        private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.ListBox GameList;
        private System.Windows.Forms.Panel SelectedGamePanel;
        private Bunifu.UI.WinForms.BunifuLabel GameLabel;
        private Bunifu.UI.WinForms.BunifuTextBox GameSearchBox;
        private Bunifu.UI.WinForms.BunifuDropdown bunifuDropdown1;
        private Bunifu.UI.WinForms.BunifuLabel HeaderTitle;
        private System.Windows.Forms.Button button1;
    }
}