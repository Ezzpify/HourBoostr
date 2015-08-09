namespace JsonHelper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.header_Divider = new System.Windows.Forms.PictureBox();
            this.header_Panel = new System.Windows.Forms.Panel();
            this.header_Label_Exit = new System.Windows.Forms.Label();
            this.header_Label_ToWebsite = new System.Windows.Forms.Label();
            this.main_Divider = new System.Windows.Forms.PictureBox();
            this.text_Username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.list_Entries = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.text_Games = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.header_Divider)).BeginInit();
            this.header_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_Divider)).BeginInit();
            this.SuspendLayout();
            // 
            // header_Divider
            // 
            this.header_Divider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.header_Divider.Location = new System.Drawing.Point(14, 38);
            this.header_Divider.Name = "header_Divider";
            this.header_Divider.Size = new System.Drawing.Size(246, 1);
            this.header_Divider.TabIndex = 0;
            this.header_Divider.TabStop = false;
            // 
            // header_Panel
            // 
            this.header_Panel.Controls.Add(this.header_Label_Exit);
            this.header_Panel.Controls.Add(this.header_Label_ToWebsite);
            this.header_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.header_Panel.ForeColor = System.Drawing.Color.Gainsboro;
            this.header_Panel.Location = new System.Drawing.Point(0, 0);
            this.header_Panel.Name = "header_Panel";
            this.header_Panel.Size = new System.Drawing.Size(272, 37);
            this.header_Panel.TabIndex = 1;
            this.header_Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_Panel_MouseDown);
            // 
            // header_Label_Exit
            // 
            this.header_Label_Exit.AutoSize = true;
            this.header_Label_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.header_Label_Exit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_Label_Exit.ForeColor = System.Drawing.Color.Gainsboro;
            this.header_Label_Exit.Location = new System.Drawing.Point(241, 7);
            this.header_Label_Exit.Name = "header_Label_Exit";
            this.header_Label_Exit.Size = new System.Drawing.Size(19, 21);
            this.header_Label_Exit.TabIndex = 3;
            this.header_Label_Exit.Text = "X";
            this.header_Label_Exit.Click += new System.EventHandler(this.header_Label_Exit_Click);
            this.header_Label_Exit.MouseEnter += new System.EventHandler(this.header_Label_Exit_MouseEnter);
            this.header_Label_Exit.MouseLeave += new System.EventHandler(this.header_Label_Exit_MouseLeave);
            // 
            // header_Label_ToWebsite
            // 
            this.header_Label_ToWebsite.AutoSize = true;
            this.header_Label_ToWebsite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.header_Label_ToWebsite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_Label_ToWebsite.ForeColor = System.Drawing.Color.Gainsboro;
            this.header_Label_ToWebsite.Location = new System.Drawing.Point(10, 7);
            this.header_Label_ToWebsite.Name = "header_Label_ToWebsite";
            this.header_Label_ToWebsite.Size = new System.Drawing.Size(87, 21);
            this.header_Label_ToWebsite.TabIndex = 2;
            this.header_Label_ToWebsite.Text = "JsonHelper";
            this.header_Label_ToWebsite.Click += new System.EventHandler(this.header_Label_ToWebsite_Click);
            this.header_Label_ToWebsite.MouseEnter += new System.EventHandler(this.header_Label_ToWebsite_MouseEnter);
            this.header_Label_ToWebsite.MouseLeave += new System.EventHandler(this.header_Label_ToWebsite_MouseLeave);
            // 
            // main_Divider
            // 
            this.main_Divider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.main_Divider.Location = new System.Drawing.Point(109, 38);
            this.main_Divider.Name = "main_Divider";
            this.main_Divider.Size = new System.Drawing.Size(1, 181);
            this.main_Divider.TabIndex = 2;
            this.main_Divider.TabStop = false;
            // 
            // text_Username
            // 
            this.text_Username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.text_Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_Username.ForeColor = System.Drawing.Color.Gainsboro;
            this.text_Username.Location = new System.Drawing.Point(119, 75);
            this.text_Username.Name = "text_Username";
            this.text_Username.Size = new System.Drawing.Size(129, 16);
            this.text_Username.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(116, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(116, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Games";
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Location = new System.Drawing.Point(119, 196);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(129, 23);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = "Add entry";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // list_Entries
            // 
            this.list_Entries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.list_Entries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_Entries.ForeColor = System.Drawing.Color.Gainsboro;
            this.list_Entries.FormattingEnabled = true;
            this.list_Entries.IntegralHeight = false;
            this.list_Entries.ItemHeight = 15;
            this.list_Entries.Location = new System.Drawing.Point(14, 75);
            this.list_Entries.Name = "list_Entries";
            this.list_Entries.Size = new System.Drawing.Size(86, 115);
            this.list_Entries.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Entries";
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.Enabled = false;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Location = new System.Drawing.Point(15, 196);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(85, 23);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // text_Games
            // 
            this.text_Games.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.text_Games.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_Games.ForeColor = System.Drawing.Color.Gainsboro;
            this.text_Games.Location = new System.Drawing.Point(119, 123);
            this.text_Games.Name = "text_Games";
            this.text_Games.Size = new System.Drawing.Size(129, 67);
            this.text_Games.TabIndex = 1;
            this.text_Games.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(272, 234);
            this.Controls.Add(this.text_Games);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.list_Entries);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_Username);
            this.Controls.Add(this.header_Panel);
            this.Controls.Add(this.header_Divider);
            this.Controls.Add(this.main_Divider);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JsonHelper for HourBoostr";
            ((System.ComponentModel.ISupportInitialize)(this.header_Divider)).EndInit();
            this.header_Panel.ResumeLayout(false);
            this.header_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_Divider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox header_Divider;
        private System.Windows.Forms.Panel header_Panel;
        private System.Windows.Forms.Label header_Label_ToWebsite;
        private System.Windows.Forms.Label header_Label_Exit;
        private System.Windows.Forms.PictureBox main_Divider;
        private System.Windows.Forms.TextBox text_Username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ListBox list_Entries;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.RichTextBox text_Games;
    }
}

