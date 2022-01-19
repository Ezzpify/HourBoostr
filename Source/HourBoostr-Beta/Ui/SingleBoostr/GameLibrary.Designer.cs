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
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.BackButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.ExitButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.WindowElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.HeaderPanel = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.HeaderDragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.HeaderPanel.SuspendLayout();
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
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(30)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.DodgerBlue;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(23)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 33);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(200, 373);
            this.bunifuGradientPanel1.TabIndex = 3;
            // 
            // GameLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HourBoostr_Beta.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.bunifuPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameLibrary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GameLibrary";
            this.HeaderPanel.ResumeLayout(false);
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
    }
}