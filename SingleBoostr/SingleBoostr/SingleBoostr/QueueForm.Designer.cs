namespace SingleBoostr
{
    partial class QueueForm
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
            this.picGoBack = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblCurrentGame = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lvApps = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblNoItems = new System.Windows.Forms.Label();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.picGoBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // picGoBack
            // 
            this.picGoBack.BackgroundImage = global::SingleBoostr.Properties.Resources.Back;
            this.picGoBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picGoBack.Location = new System.Drawing.Point(12, 12);
            this.picGoBack.Name = "picGoBack";
            this.picGoBack.Size = new System.Drawing.Size(20, 48);
            this.picGoBack.TabIndex = 16;
            this.picGoBack.TabStop = false;
            this.picGoBack.Click += new System.EventHandler(this.picGoBack_Click);
            this.picGoBack.MouseEnter += new System.EventHandler(this.picGoBack_MouseEnter);
            this.picGoBack.MouseLeave += new System.EventHandler(this.picGoBack_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(5, 236);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(43, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 236);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblNoItems);
            this.panel2.Controls.Add(this.lvApps);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.lblCurrentGame);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 236);
            this.panel2.TabIndex = 20;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox4.Location = new System.Drawing.Point(0, 28);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(416, 2);
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox3.Location = new System.Drawing.Point(0, 27);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(416, 1);
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // lblCurrentGame
            // 
            this.lblCurrentGame.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(73)))), ((int)(((byte)(131)))));
            this.lblCurrentGame.Location = new System.Drawing.Point(0, 0);
            this.lblCurrentGame.Name = "lblCurrentGame";
            this.lblCurrentGame.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblCurrentGame.Size = new System.Drawing.Size(416, 27);
            this.lblCurrentGame.TabIndex = 20;
            this.lblCurrentGame.Text = "Current: The Witcher® 3: Wild Hunt";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(73)))), ((int)(((byte)(131)))));
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1, 236);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // lvApps
            // 
            this.lvApps.AllowDrop = true;
            this.lvApps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.lvApps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvApps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvApps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvApps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.lvApps.FullRowSelect = true;
            this.lvApps.Location = new System.Drawing.Point(0, 30);
            this.lvApps.MultiSelect = false;
            this.lvApps.Name = "lvApps";
            this.lvApps.Size = new System.Drawing.Size(416, 206);
            this.lvApps.TabIndex = 22;
            this.lvApps.UseCompatibleStateImageBehavior = false;
            this.lvApps.View = System.Windows.Forms.View.Details;
            this.lvApps.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvApps_ItemDrag);
            this.lvApps.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvApps_DragDrop);
            this.lvApps.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvApps_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Price";
            this.columnHeader1.Width = 49;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Hours";
            this.columnHeader2.Width = 51;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Game";
            this.columnHeader4.Width = 263;
            // 
            // lblNoItems
            // 
            this.lblNoItems.AutoSize = true;
            this.lblNoItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(73)))), ((int)(((byte)(131)))));
            this.lblNoItems.Location = new System.Drawing.Point(150, 128);
            this.lblNoItems.Name = "lblNoItems";
            this.lblNoItems.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblNoItems.Size = new System.Drawing.Size(117, 27);
            this.lblNoItems.TabIndex = 23;
            this.lblNoItems.Text = "No apps in queue!";
            this.lblNoItems.Visible = false;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Cards";
            this.columnHeader3.Width = 49;
            // 
            // QueueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(466, 260);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picGoBack);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QueueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QueueForm";
            this.Load += new System.EventHandler(this.QueueForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.QueueForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.picGoBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picGoBack;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblCurrentGame;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ListView lvApps;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblNoItems;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}