namespace HourBoostr_Beta.Ui
{
    partial class BoostrSelectionScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoostrSelectionScreen));
            this.HeaderDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.HeaderPanel = new Bunifu.UI.WinForms.BunifuPanel();
            this.ExitButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.SingleBoostrLabel = new Bunifu.UI.WinForms.BunifuLabel();
            this.MultiBoostrLabel = new Bunifu.UI.WinForms.BunifuLabel();
            this.MultiBoostrButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.SingleBoostrButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.WindowElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.HeaderTitle = new Bunifu.UI.WinForms.BunifuLabel();
            this.HeaderPanel.SuspendLayout();
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
            this.HeaderPanel.Controls.Add(this.ExitButton);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.ShowBorders = true;
            this.HeaderPanel.Size = new System.Drawing.Size(800, 35);
            this.HeaderPanel.TabIndex = 0;
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
            this.ExitButton.TabIndex = 1;
            this.ExitButton.ToolTipText = "Exit HourBoostr";
            this.ExitButton.WaitOnLoad = false;
            this.ExitButton.Zoom = 0;
            this.ExitButton.ZoomSpeed = 10;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SingleBoostrLabel
            // 
            this.SingleBoostrLabel.AllowParentOverrides = false;
            this.SingleBoostrLabel.AutoEllipsis = false;
            this.SingleBoostrLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SingleBoostrLabel.CursorType = System.Windows.Forms.Cursors.Default;
            this.SingleBoostrLabel.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingleBoostrLabel.ForeColor = System.Drawing.Color.Gray;
            this.SingleBoostrLabel.Location = new System.Drawing.Point(135, 135);
            this.SingleBoostrLabel.Name = "SingleBoostrLabel";
            this.SingleBoostrLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SingleBoostrLabel.Size = new System.Drawing.Size(122, 26);
            this.SingleBoostrLabel.TabIndex = 4;
            this.SingleBoostrLabel.Text = "SingleBoostr";
            this.SingleBoostrLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.SingleBoostrLabel.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // MultiBoostrLabel
            // 
            this.MultiBoostrLabel.AllowParentOverrides = false;
            this.MultiBoostrLabel.AutoEllipsis = false;
            this.MultiBoostrLabel.CursorType = null;
            this.MultiBoostrLabel.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiBoostrLabel.ForeColor = System.Drawing.Color.Gray;
            this.MultiBoostrLabel.Location = new System.Drawing.Point(547, 135);
            this.MultiBoostrLabel.Name = "MultiBoostrLabel";
            this.MultiBoostrLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MultiBoostrLabel.Size = new System.Drawing.Size(112, 26);
            this.MultiBoostrLabel.TabIndex = 5;
            this.MultiBoostrLabel.Text = "MultiBoostr";
            this.MultiBoostrLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.MultiBoostrLabel.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // MultiBoostrButton
            // 
            this.MultiBoostrButton.ActiveImage = null;
            this.MultiBoostrButton.AllowAnimations = true;
            this.MultiBoostrButton.AllowBuffering = false;
            this.MultiBoostrButton.AllowToggling = false;
            this.MultiBoostrButton.AllowZooming = true;
            this.MultiBoostrButton.AllowZoomingOnFocus = false;
            this.MultiBoostrButton.BackColor = System.Drawing.Color.Transparent;
            this.MultiBoostrButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MultiBoostrButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.MultiBoostrButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("MultiBoostrButton.ErrorImage")));
            this.MultiBoostrButton.FadeWhenInactive = true;
            this.MultiBoostrButton.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.MultiBoostrButton.Image = global::HourBoostr_Beta.Properties.Resources.MultiBoostrSelection;
            this.MultiBoostrButton.ImageActive = null;
            this.MultiBoostrButton.ImageLocation = null;
            this.MultiBoostrButton.ImageMargin = 150;
            this.MultiBoostrButton.ImageSize = new System.Drawing.Size(248, 260);
            this.MultiBoostrButton.ImageZoomSize = new System.Drawing.Size(398, 410);
            this.MultiBoostrButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("MultiBoostrButton.InitialImage")));
            this.MultiBoostrButton.Location = new System.Drawing.Point(402, 40);
            this.MultiBoostrButton.Name = "MultiBoostrButton";
            this.MultiBoostrButton.Rotation = 0;
            this.MultiBoostrButton.ShowActiveImage = true;
            this.MultiBoostrButton.ShowCursorChanges = true;
            this.MultiBoostrButton.ShowImageBorders = true;
            this.MultiBoostrButton.ShowSizeMarkers = false;
            this.MultiBoostrButton.Size = new System.Drawing.Size(398, 410);
            this.MultiBoostrButton.TabIndex = 3;
            this.MultiBoostrButton.ToolTipText = "Open MultiBoostr";
            this.MultiBoostrButton.WaitOnLoad = false;
            this.MultiBoostrButton.Zoom = 150;
            this.MultiBoostrButton.ZoomSpeed = 10;
            this.MultiBoostrButton.Click += new System.EventHandler(this.MultiBoostrButton_Click);
            // 
            // SingleBoostrButton
            // 
            this.SingleBoostrButton.ActiveImage = null;
            this.SingleBoostrButton.AllowAnimations = true;
            this.SingleBoostrButton.AllowBuffering = false;
            this.SingleBoostrButton.AllowToggling = false;
            this.SingleBoostrButton.AllowZooming = true;
            this.SingleBoostrButton.AllowZoomingOnFocus = false;
            this.SingleBoostrButton.BackColor = System.Drawing.Color.Transparent;
            this.SingleBoostrButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.SingleBoostrButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("SingleBoostrButton.ErrorImage")));
            this.SingleBoostrButton.FadeWhenInactive = true;
            this.SingleBoostrButton.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.SingleBoostrButton.Image = global::HourBoostr_Beta.Properties.Resources.SingleBoostrSelection;
            this.SingleBoostrButton.ImageActive = null;
            this.SingleBoostrButton.ImageLocation = null;
            this.SingleBoostrButton.ImageMargin = 150;
            this.SingleBoostrButton.ImageSize = new System.Drawing.Size(248, 260);
            this.SingleBoostrButton.ImageZoomSize = new System.Drawing.Size(398, 410);
            this.SingleBoostrButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("SingleBoostrButton.InitialImage")));
            this.SingleBoostrButton.Location = new System.Drawing.Point(0, 40);
            this.SingleBoostrButton.Name = "SingleBoostrButton";
            this.SingleBoostrButton.Rotation = 0;
            this.SingleBoostrButton.ShowActiveImage = true;
            this.SingleBoostrButton.ShowCursorChanges = true;
            this.SingleBoostrButton.ShowImageBorders = true;
            this.SingleBoostrButton.ShowSizeMarkers = false;
            this.SingleBoostrButton.Size = new System.Drawing.Size(398, 410);
            this.SingleBoostrButton.TabIndex = 2;
            this.SingleBoostrButton.ToolTipText = "Open SingleBoostr";
            this.SingleBoostrButton.WaitOnLoad = false;
            this.SingleBoostrButton.Zoom = 150;
            this.SingleBoostrButton.ZoomSpeed = 10;
            this.SingleBoostrButton.Click += new System.EventHandler(this.SingleBoostrButton_Click);
            // 
            // WindowElipse
            // 
            this.WindowElipse.ElipseRadius = 15;
            this.WindowElipse.TargetControl = this;
            // 
            // HeaderTitle
            // 
            this.HeaderTitle.AllowParentOverrides = false;
            this.HeaderTitle.AutoEllipsis = false;
            this.HeaderTitle.CursorType = null;
            this.HeaderTitle.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.HeaderTitle.Location = new System.Drawing.Point(354, 7);
            this.HeaderTitle.Name = "HeaderTitle";
            this.HeaderTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HeaderTitle.Size = new System.Drawing.Size(103, 22);
            this.HeaderTitle.TabIndex = 6;
            this.HeaderTitle.Text = "HourBoostr";
            this.HeaderTitle.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.HeaderTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // BoostrSelectionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MultiBoostrLabel);
            this.Controls.Add(this.SingleBoostrLabel);
            this.Controls.Add(this.MultiBoostrButton);
            this.Controls.Add(this.SingleBoostrButton);
            this.Controls.Add(this.HeaderPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BoostrSelectionScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoostrSelectionScreen";
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel HeaderPanel;
        private Bunifu.Framework.UI.BunifuDragControl HeaderDragControl;
        private Bunifu.UI.WinForms.BunifuImageButton ExitButton;
        private Bunifu.UI.WinForms.BunifuImageButton SingleBoostrButton;
        private Bunifu.UI.WinForms.BunifuImageButton MultiBoostrButton;
        private Bunifu.UI.WinForms.BunifuLabel SingleBoostrLabel;
        private Bunifu.UI.WinForms.BunifuLabel MultiBoostrLabel;
        private Bunifu.Framework.UI.BunifuElipse WindowElipse;
        private Bunifu.UI.WinForms.BunifuLabel HeaderTitle;
    }
}