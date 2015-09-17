namespace HourBoostr
{
    partial class AddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pic_Loading = new System.Windows.Forms.PictureBox();
            this.CloseBtn = new System.Windows.Forms.Label();
            this.AddBtn = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.text_User = new System.Windows.Forms.TextBox();
            this.user_Pic = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.text_Pass = new System.Windows.Forms.TextBox();
            this.pass_Pic = new System.Windows.Forms.PictureBox();
            this.divider2 = new System.Windows.Forms.PictureBox();
            this.divider1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Loading)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_Pic)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pass_Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.divider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.divider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 10);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 15);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.panel2.Controls.Add(this.pic_Loading);
            this.panel2.Controls.Add(this.CloseBtn);
            this.panel2.Controls.Add(this.AddBtn);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.divider2);
            this.panel2.Controls.Add(this.divider1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(287, 80);
            this.panel2.TabIndex = 8;
            // 
            // pic_Loading
            // 
            this.pic_Loading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Loading.Image = ((System.Drawing.Image)(resources.GetObject("pic_Loading.Image")));
            this.pic_Loading.Location = new System.Drawing.Point(124, 18);
            this.pic_Loading.Name = "pic_Loading";
            this.pic_Loading.Size = new System.Drawing.Size(40, 40);
            this.pic_Loading.TabIndex = 13;
            this.pic_Loading.TabStop = false;
            this.pic_Loading.Visible = false;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseBtn.AutoSize = true;
            this.CloseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(196)))));
            this.CloseBtn.Location = new System.Drawing.Point(173, 49);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(69, 15);
            this.CloseBtn.TabIndex = 12;
            this.CloseBtn.Text = "✗ CANCEL";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            this.CloseBtn.MouseEnter += new System.EventHandler(this.CloseBtn_MouseEnter);
            this.CloseBtn.MouseLeave += new System.EventHandler(this.CloseBtn_MouseLeave);
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddBtn.AutoSize = true;
            this.AddBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(196)))));
            this.AddBtn.Location = new System.Drawing.Point(43, 49);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(58, 15);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "✓ LOGIN";
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            this.AddBtn.MouseEnter += new System.EventHandler(this.AddBtn_MouseEnter);
            this.AddBtn.MouseLeave += new System.EventHandler(this.AddBtn_MouseLeave);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.text_User);
            this.panel4.Controls.Add(this.user_Pic);
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.Location = new System.Drawing.Point(12, 11);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(127, 22);
            this.panel4.TabIndex = 10;
            // 
            // text_User
            // 
            this.text_User.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_User.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_User.Dock = System.Windows.Forms.DockStyle.Top;
            this.text_User.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_User.ForeColor = System.Drawing.Color.Gray;
            this.text_User.Location = new System.Drawing.Point(1, 0);
            this.text_User.Name = "text_User";
            this.text_User.Size = new System.Drawing.Size(126, 22);
            this.text_User.TabIndex = 2;
            this.text_User.Text = "username";
            // 
            // user_Pic
            // 
            this.user_Pic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(196)))));
            this.user_Pic.Dock = System.Windows.Forms.DockStyle.Left;
            this.user_Pic.Location = new System.Drawing.Point(0, 0);
            this.user_Pic.Name = "user_Pic";
            this.user_Pic.Size = new System.Drawing.Size(1, 22);
            this.user_Pic.TabIndex = 3;
            this.user_Pic.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.text_Pass);
            this.panel5.Controls.Add(this.pass_Pic);
            this.panel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel5.Location = new System.Drawing.Point(148, 11);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(127, 22);
            this.panel5.TabIndex = 11;
            // 
            // text_Pass
            // 
            this.text_Pass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.text_Pass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_Pass.Dock = System.Windows.Forms.DockStyle.Top;
            this.text_Pass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_Pass.ForeColor = System.Drawing.Color.Gray;
            this.text_Pass.Location = new System.Drawing.Point(1, 0);
            this.text_Pass.Name = "text_Pass";
            this.text_Pass.PasswordChar = '*';
            this.text_Pass.Size = new System.Drawing.Size(126, 22);
            this.text_Pass.TabIndex = 3;
            this.text_Pass.Text = "password";
            // 
            // pass_Pic
            // 
            this.pass_Pic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(196)))));
            this.pass_Pic.Dock = System.Windows.Forms.DockStyle.Left;
            this.pass_Pic.Location = new System.Drawing.Point(0, 0);
            this.pass_Pic.Name = "pass_Pic";
            this.pass_Pic.Size = new System.Drawing.Size(1, 22);
            this.pass_Pic.TabIndex = 3;
            this.pass_Pic.TabStop = false;
            // 
            // divider2
            // 
            this.divider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(196)))));
            this.divider2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.divider2.Location = new System.Drawing.Point(1, 79);
            this.divider2.Name = "divider2";
            this.divider2.Size = new System.Drawing.Size(286, 1);
            this.divider2.TabIndex = 4;
            this.divider2.TabStop = false;
            // 
            // divider1
            // 
            this.divider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(196)))));
            this.divider1.Dock = System.Windows.Forms.DockStyle.Left;
            this.divider1.Location = new System.Drawing.Point(0, 0);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(1, 80);
            this.divider1.TabIndex = 6;
            this.divider1.TabStop = false;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(287, 90);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.ShowInTaskbar = false;
            this.Text = "AddForm";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Loading)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_Pic)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pass_Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.divider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.divider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox divider2;
        private System.Windows.Forms.PictureBox divider1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox text_Pass;
        private System.Windows.Forms.PictureBox pass_Pic;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox text_User;
        private System.Windows.Forms.PictureBox user_Pic;
        private System.Windows.Forms.Label AddBtn;
        private System.Windows.Forms.Label CloseBtn;
        private System.Windows.Forms.PictureBox pic_Loading;
    }
}