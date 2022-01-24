namespace HourBoostr_Beta.Ui.SingleBoostr
{
    partial class SingleBoostr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleBoostr));
            this.HeaderDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.HeaderTitle = new Bunifu.UI.WinForms.BunifuLabel();
            this.DonateButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.SettingsButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.BackButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.ExitButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.InfoVersionPanel = new System.Windows.Forms.Panel();
            this.TradingCardsButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.IdleHoursButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.WindowElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.HeaderPanel.SuspendLayout();
            this.InfoPanel.SuspendLayout();
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
            this.HeaderPanel.BackColor = System.Drawing.Color.Transparent;
            this.HeaderPanel.Controls.Add(this.HeaderTitle);
            this.HeaderPanel.Controls.Add(this.DonateButton);
            this.HeaderPanel.Controls.Add(this.SettingsButton);
            this.HeaderPanel.Controls.Add(this.BackButton);
            this.HeaderPanel.Controls.Add(this.ExitButton);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(800, 35);
            this.HeaderPanel.TabIndex = 4;
            // 
            // HeaderTitle
            // 
            this.HeaderTitle.AllowParentOverrides = false;
            this.HeaderTitle.AutoEllipsis = false;
            this.HeaderTitle.CursorType = null;
            this.HeaderTitle.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.HeaderTitle.Location = new System.Drawing.Point(279, 3);
            this.HeaderTitle.Name = "HeaderTitle";
            this.HeaderTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HeaderTitle.Size = new System.Drawing.Size(115, 22);
            this.HeaderTitle.TabIndex = 5;
            this.HeaderTitle.Text = "SingleBoostr";
            this.HeaderTitle.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.HeaderTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // DonateButton
            // 
            this.DonateButton.ActiveImage = global::HourBoostr_Beta.Properties.Resources.Donate_Hovered;
            this.DonateButton.AllowAnimations = true;
            this.DonateButton.AllowBuffering = false;
            this.DonateButton.AllowToggling = false;
            this.DonateButton.AllowZooming = false;
            this.DonateButton.AllowZoomingOnFocus = false;
            this.DonateButton.BackColor = System.Drawing.Color.Transparent;
            this.DonateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DonateButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.DonateButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("DonateButton.ErrorImage")));
            this.DonateButton.FadeWhenInactive = false;
            this.DonateButton.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.DonateButton.Image = global::HourBoostr_Beta.Properties.Resources.Donate;
            this.DonateButton.ImageActive = global::HourBoostr_Beta.Properties.Resources.Donate_Hovered;
            this.DonateButton.ImageLocation = null;
            this.DonateButton.ImageMargin = 0;
            this.DonateButton.ImageSize = new System.Drawing.Size(73, 35);
            this.DonateButton.ImageZoomSize = new System.Drawing.Size(73, 35);
            this.DonateButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("DonateButton.InitialImage")));
            this.DonateButton.Location = new System.Drawing.Point(615, 0);
            this.DonateButton.Name = "DonateButton";
            this.DonateButton.Rotation = 0;
            this.DonateButton.ShowActiveImage = true;
            this.DonateButton.ShowCursorChanges = true;
            this.DonateButton.ShowImageBorders = true;
            this.DonateButton.ShowSizeMarkers = false;
            this.DonateButton.Size = new System.Drawing.Size(73, 35);
            this.DonateButton.TabIndex = 5;
            this.DonateButton.ToolTipText = "Donate";
            this.DonateButton.WaitOnLoad = false;
            this.DonateButton.Zoom = 0;
            this.DonateButton.ZoomSpeed = 10;
            this.DonateButton.Click += new System.EventHandler(this.DonateButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.ActiveImage = global::HourBoostr_Beta.Properties.Resources.Settings_Hovered;
            this.SettingsButton.AllowAnimations = true;
            this.SettingsButton.AllowBuffering = false;
            this.SettingsButton.AllowToggling = false;
            this.SettingsButton.AllowZooming = false;
            this.SettingsButton.AllowZoomingOnFocus = false;
            this.SettingsButton.BackColor = System.Drawing.Color.Transparent;
            this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SettingsButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.SettingsButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("SettingsButton.ErrorImage")));
            this.SettingsButton.FadeWhenInactive = false;
            this.SettingsButton.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.SettingsButton.Image = global::HourBoostr_Beta.Properties.Resources.Settings;
            this.SettingsButton.ImageActive = global::HourBoostr_Beta.Properties.Resources.Settings_Hovered;
            this.SettingsButton.ImageLocation = null;
            this.SettingsButton.ImageMargin = 0;
            this.SettingsButton.ImageSize = new System.Drawing.Size(64, 35);
            this.SettingsButton.ImageZoomSize = new System.Drawing.Size(64, 35);
            this.SettingsButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("SettingsButton.InitialImage")));
            this.SettingsButton.Location = new System.Drawing.Point(684, 0);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Rotation = 0;
            this.SettingsButton.ShowActiveImage = true;
            this.SettingsButton.ShowCursorChanges = true;
            this.SettingsButton.ShowImageBorders = true;
            this.SettingsButton.ShowSizeMarkers = false;
            this.SettingsButton.Size = new System.Drawing.Size(64, 35);
            this.SettingsButton.TabIndex = 4;
            this.SettingsButton.ToolTipText = "Settings";
            this.SettingsButton.WaitOnLoad = false;
            this.SettingsButton.Zoom = 0;
            this.SettingsButton.ZoomSpeed = 10;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
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
            this.BackButton.FadeWhenInactive = true;
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
            this.BackButton.TabIndex = 3;
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
            this.ExitButton.TabIndex = 2;
            this.ExitButton.ToolTipText = "Exit HourBoostr";
            this.ExitButton.WaitOnLoad = false;
            this.ExitButton.Zoom = 0;
            this.ExitButton.ZoomSpeed = 10;
            this.ExitButton.Click += Program.This.Close;
            // 
            // InfoPanel
            // 
            this.InfoPanel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.InfoPanel.BackColor = System.Drawing.Color.Transparent;
            this.InfoPanel.Controls.Add(this.InfoVersionPanel);
            this.InfoPanel.Location = new System.Drawing.Point(0, 35);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(334, 415);
            this.InfoPanel.TabIndex = 1;
            // 
            // InfoVersionPanel
            // 
            this.InfoVersionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InfoVersionPanel.Location = new System.Drawing.Point(0, 380);
            this.InfoVersionPanel.Name = "InfoVersionPanel";
            this.InfoVersionPanel.Size = new System.Drawing.Size(334, 35);
            this.InfoVersionPanel.TabIndex = 2;
            // 
            // TradingCardsButton
            // 
            this.TradingCardsButton.ActiveImage = global::HourBoostr_Beta.Properties.Resources.TradingCardsButton_Hovered;
            this.TradingCardsButton.AllowAnimations = true;
            this.TradingCardsButton.AllowBuffering = false;
            this.TradingCardsButton.AllowToggling = false;
            this.TradingCardsButton.AllowZooming = true;
            this.TradingCardsButton.AllowZoomingOnFocus = false;
            this.TradingCardsButton.BackColor = System.Drawing.Color.Transparent;
            this.TradingCardsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TradingCardsButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.TradingCardsButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("TradingCardsButton.ErrorImage")));
            this.TradingCardsButton.FadeWhenInactive = true;
            this.TradingCardsButton.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.TradingCardsButton.Image = global::HourBoostr_Beta.Properties.Resources.TradingCardsButton;
            this.TradingCardsButton.ImageActive = global::HourBoostr_Beta.Properties.Resources.TradingCardsButton_Hovered;
            this.TradingCardsButton.ImageLocation = null;
            this.TradingCardsButton.ImageMargin = 0;
            this.TradingCardsButton.ImageSize = new System.Drawing.Size(184, 86);
            this.TradingCardsButton.ImageZoomSize = new System.Drawing.Size(185, 87);
            this.TradingCardsButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("TradingCardsButton.InitialImage")));
            this.TradingCardsButton.Location = new System.Drawing.Point(615, 363);
            this.TradingCardsButton.Name = "TradingCardsButton";
            this.TradingCardsButton.Rotation = 0;
            this.TradingCardsButton.ShowActiveImage = true;
            this.TradingCardsButton.ShowCursorChanges = true;
            this.TradingCardsButton.ShowImageBorders = true;
            this.TradingCardsButton.ShowSizeMarkers = false;
            this.TradingCardsButton.Size = new System.Drawing.Size(185, 87);
            this.TradingCardsButton.TabIndex = 2;
            this.TradingCardsButton.ToolTipText = "Farm trading cards";
            this.TradingCardsButton.WaitOnLoad = false;
            this.TradingCardsButton.Zoom = 0;
            this.TradingCardsButton.ZoomSpeed = 10;
            this.TradingCardsButton.Click += new System.EventHandler(this.TradingCardsButton_Click);
            // 
            // IdleHoursButton
            // 
            this.IdleHoursButton.ActiveImage = global::HourBoostr_Beta.Properties.Resources.IdleButton_Hovered;
            this.IdleHoursButton.AllowAnimations = true;
            this.IdleHoursButton.AllowBuffering = false;
            this.IdleHoursButton.AllowToggling = false;
            this.IdleHoursButton.AllowZooming = true;
            this.IdleHoursButton.AllowZoomingOnFocus = false;
            this.IdleHoursButton.BackColor = System.Drawing.Color.Transparent;
            this.IdleHoursButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.IdleHoursButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.IdleHoursButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("IdleHoursButton.ErrorImage")));
            this.IdleHoursButton.FadeWhenInactive = true;
            this.IdleHoursButton.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.IdleHoursButton.Image = global::HourBoostr_Beta.Properties.Resources.IdleButton;
            this.IdleHoursButton.ImageActive = global::HourBoostr_Beta.Properties.Resources.IdleButton_Hovered;
            this.IdleHoursButton.ImageLocation = null;
            this.IdleHoursButton.ImageMargin = 0;
            this.IdleHoursButton.ImageSize = new System.Drawing.Size(184, 329);
            this.IdleHoursButton.ImageZoomSize = new System.Drawing.Size(185, 330);
            this.IdleHoursButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("IdleHoursButton.InitialImage")));
            this.IdleHoursButton.Location = new System.Drawing.Point(615, 35);
            this.IdleHoursButton.Name = "IdleHoursButton";
            this.IdleHoursButton.Rotation = 0;
            this.IdleHoursButton.ShowActiveImage = true;
            this.IdleHoursButton.ShowCursorChanges = true;
            this.IdleHoursButton.ShowImageBorders = true;
            this.IdleHoursButton.ShowSizeMarkers = false;
            this.IdleHoursButton.Size = new System.Drawing.Size(185, 330);
            this.IdleHoursButton.TabIndex = 3;
            this.IdleHoursButton.ToolTipText = "Idle games";
            this.IdleHoursButton.WaitOnLoad = false;
            this.IdleHoursButton.Zoom = 0;
            this.IdleHoursButton.ZoomSpeed = 10;
            this.IdleHoursButton.Click += new System.EventHandler(this.IdleHoursButton_Click);
            // 
            // WindowElipse
            // 
            this.WindowElipse.ElipseRadius = 15;
            this.WindowElipse.TargetControl = this;
            // 
            // SingleBoostr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.BackgroundImage = global::HourBoostr_Beta.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.IdleHoursButton);
            this.Controls.Add(this.TradingCardsButton);
            this.Controls.Add(this.InfoPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SingleBoostr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SingleBoostr";
            this.Load += new System.EventHandler(this.SingleBoostr_Load);
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.InfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuImageButton ExitButton;
        private Bunifu.Framework.UI.BunifuDragControl HeaderDragControl;
        private Bunifu.UI.WinForms.BunifuImageButton BackButton;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Panel InfoVersionPanel;
        private Bunifu.UI.WinForms.BunifuImageButton TradingCardsButton;
        private Bunifu.UI.WinForms.BunifuImageButton IdleHoursButton;
        private System.Windows.Forms.Panel HeaderPanel;
        private Bunifu.UI.WinForms.BunifuImageButton SettingsButton;
        private Bunifu.UI.WinForms.BunifuImageButton DonateButton;
        private Bunifu.Framework.UI.BunifuElipse WindowElipse;
        private Bunifu.UI.WinForms.BunifuLabel HeaderTitle;
    }
}