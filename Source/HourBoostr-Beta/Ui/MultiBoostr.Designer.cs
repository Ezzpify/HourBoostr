namespace HourBoostr_Beta.Ui
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
            this.BackButton = new Bunifu.UI.WinForms.BunifuImageButton();
            this.ExitButton = new Bunifu.UI.WinForms.BunifuImageButton();
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
            this.HeaderPanel.Controls.Add(this.BackButton);
            this.HeaderPanel.Controls.Add(this.ExitButton);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.ShowBorders = true;
            this.HeaderPanel.Size = new System.Drawing.Size(800, 35);
            this.HeaderPanel.TabIndex = 0;
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
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MultiBoostr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.BackgroundImage = global::HourBoostr_Beta.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.HeaderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MultiBoostr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MulitBoostr";
            this.HeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel HeaderPanel;
        private Bunifu.Framework.UI.BunifuDragControl HeaderDragControl;
        private Bunifu.UI.WinForms.BunifuImageButton ExitButton;
        private Bunifu.UI.WinForms.BunifuImageButton BackButton;
    }
}