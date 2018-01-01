namespace SingleBoostr
{
    partial class MsgBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgBox));
            this.PanelFooter = new System.Windows.Forms.Panel();
            this.PanelFooterFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.PanelHeaderLblMessage = new System.Windows.Forms.Label();
            this.PanelHeaderLblTitle = new System.Windows.Forms.Label();
            this.PanelIcon = new System.Windows.Forms.Panel();
            this.PanelIconPic = new System.Windows.Forms.PictureBox();
            this.TmrAnim = new System.Windows.Forms.Timer(this.components);
            this.PanelFooter.SuspendLayout();
            this.PanelHeader.SuspendLayout();
            this.PanelIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelIconPic)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelFooter
            // 
            this.PanelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.PanelFooter.Controls.Add(this.PanelFooterFlow);
            this.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelFooter.Location = new System.Drawing.Point(3, 242);
            this.PanelFooter.Name = "PanelFooter";
            this.PanelFooter.Padding = new System.Windows.Forms.Padding(10);
            this.PanelFooter.Size = new System.Drawing.Size(294, 55);
            this.PanelFooter.TabIndex = 1;
            // 
            // PanelFooterFlow
            // 
            this.PanelFooterFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelFooterFlow.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.PanelFooterFlow.Location = new System.Drawing.Point(10, 10);
            this.PanelFooterFlow.Name = "PanelFooterFlow";
            this.PanelFooterFlow.Size = new System.Drawing.Size(274, 35);
            this.PanelFooterFlow.TabIndex = 0;
            // 
            // PanelHeader
            // 
            this.PanelHeader.Controls.Add(this.PanelHeaderLblMessage);
            this.PanelHeader.Controls.Add(this.PanelHeaderLblTitle);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelHeader.Location = new System.Drawing.Point(73, 3);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Padding = new System.Windows.Forms.Padding(20);
            this.PanelHeader.Size = new System.Drawing.Size(224, 239);
            this.PanelHeader.TabIndex = 0;
            this.PanelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelHeader_MouseDown);
            // 
            // PanelHeaderLblMessage
            // 
            this.PanelHeaderLblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelHeaderLblMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelHeaderLblMessage.Location = new System.Drawing.Point(20, 52);
            this.PanelHeaderLblMessage.Name = "PanelHeaderLblMessage";
            this.PanelHeaderLblMessage.Padding = new System.Windows.Forms.Padding(5, 10, 10, 10);
            this.PanelHeaderLblMessage.Size = new System.Drawing.Size(184, 167);
            this.PanelHeaderLblMessage.TabIndex = 1;
            this.PanelHeaderLblMessage.Text = "Message";
            // 
            // PanelHeaderLblTitle
            // 
            this.PanelHeaderLblTitle.AutoSize = true;
            this.PanelHeaderLblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHeaderLblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelHeaderLblTitle.Location = new System.Drawing.Point(20, 20);
            this.PanelHeaderLblTitle.Name = "PanelHeaderLblTitle";
            this.PanelHeaderLblTitle.Size = new System.Drawing.Size(61, 32);
            this.PanelHeaderLblTitle.TabIndex = 0;
            this.PanelHeaderLblTitle.Text = "Title";
            // 
            // PanelIcon
            // 
            this.PanelIcon.Controls.Add(this.PanelIconPic);
            this.PanelIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelIcon.Location = new System.Drawing.Point(3, 3);
            this.PanelIcon.Name = "PanelIcon";
            this.PanelIcon.Padding = new System.Windows.Forms.Padding(20);
            this.PanelIcon.Size = new System.Drawing.Size(70, 239);
            this.PanelIcon.TabIndex = 0;
            this.PanelIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelIcon_MouseDown);
            // 
            // PanelIconPic
            // 
            this.PanelIconPic.Location = new System.Drawing.Point(30, 50);
            this.PanelIconPic.Name = "PanelIconPic";
            this.PanelIconPic.Size = new System.Drawing.Size(32, 32);
            this.PanelIconPic.TabIndex = 0;
            this.PanelIconPic.TabStop = false;
            // 
            // TmrAnim
            // 
            this.TmrAnim.Tick += new System.EventHandler(this.TmrAnim_Tick);
            // 
            // MsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.PanelHeader);
            this.Controls.Add(this.PanelIcon);
            this.Controls.Add(this.PanelFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MsgBox";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SingleBoostr";
            this.PanelFooter.ResumeLayout(false);
            this.PanelHeader.ResumeLayout(false);
            this.PanelHeader.PerformLayout();
            this.PanelIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelIconPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelFooter;
        private System.Windows.Forms.Panel PanelHeader;
        private System.Windows.Forms.Panel PanelIcon;
        private System.Windows.Forms.PictureBox PanelIconPic;
        private System.Windows.Forms.Label PanelHeaderLblMessage;
        private System.Windows.Forms.Label PanelHeaderLblTitle;
        private System.Windows.Forms.FlowLayoutPanel PanelFooterFlow;
        private System.Windows.Forms.Timer TmrAnim;
    }
}