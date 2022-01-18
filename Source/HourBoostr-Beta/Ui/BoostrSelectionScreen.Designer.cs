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
            this.HeaderPanel.Controls.Add(this.ExitButton);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.ShowBorders = true;
            this.HeaderPanel.Size = new System.Drawing.Size(800, 31);
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
            // BoostrSelectionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HeaderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BoostrSelectionScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoostrSelectionScreen";
            this.HeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel HeaderPanel;
        private Bunifu.Framework.UI.BunifuDragControl HeaderDragControl;
        private Bunifu.UI.WinForms.BunifuImageButton ExitButton;
    }
}