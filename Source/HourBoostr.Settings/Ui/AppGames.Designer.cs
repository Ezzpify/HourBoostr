namespace HourBoostr.Settings.Ui
{
    partial class AppGames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppGames));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvlExampleInput = new System.Windows.Forms.Label();
            this.txtProfile = new System.Windows.Forms.TextBox();
            this.gameGroup = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gameList = new System.Windows.Forms.ListBox();
            this.selectedList = new System.Windows.Forms.ListBox();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox2.SuspendLayout();
            this.gameGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvlExampleInput);
            this.groupBox2.Controls.Add(this.txtProfile);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 60);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Steam Community Url";
            // 
            // lvlExampleInput
            // 
            this.lvlExampleInput.AutoSize = true;
            this.lvlExampleInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvlExampleInput.Location = new System.Drawing.Point(248, 0);
            this.lvlExampleInput.Name = "lvlExampleInput";
            this.lvlExampleInput.Size = new System.Drawing.Size(82, 15);
            this.lvlExampleInput.TabIndex = 0;
            this.lvlExampleInput.Text = "Example Input";
            this.lvlExampleInput.Click += new System.EventHandler(this.lvlExampleInput_Click);
            this.lvlExampleInput.MouseEnter += new System.EventHandler(this.lvlExampleInput_MouseEnter);
            this.lvlExampleInput.MouseLeave += new System.EventHandler(this.lvlExampleInput_MouseLeave);
            // 
            // txtProfile
            // 
            this.txtProfile.ForeColor = System.Drawing.Color.Gray;
            this.txtProfile.Location = new System.Drawing.Point(21, 22);
            this.txtProfile.Name = "txtProfile";
            this.txtProfile.Size = new System.Drawing.Size(298, 23);
            this.txtProfile.TabIndex = 255;
            this.txtProfile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProfile_KeyDown);
            // 
            // gameGroup
            // 
            this.gameGroup.Controls.Add(this.txtSearch);
            this.gameGroup.Controls.Add(this.gameList);
            this.gameGroup.Controls.Add(this.selectedList);
            this.gameGroup.Location = new System.Drawing.Point(12, 78);
            this.gameGroup.Name = "gameGroup";
            this.gameGroup.Size = new System.Drawing.Size(341, 292);
            this.gameGroup.TabIndex = 0;
            this.gameGroup.TabStop = false;
            this.gameGroup.Text = "Games";
            this.gameGroup.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(21, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(298, 23);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // gameList
            // 
            this.gameList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameList.ForeColor = System.Drawing.Color.Gray;
            this.gameList.FormattingEnabled = true;
            this.gameList.IntegralHeight = false;
            this.gameList.ItemHeight = 15;
            this.gameList.Location = new System.Drawing.Point(21, 58);
            this.gameList.Name = "gameList";
            this.gameList.Size = new System.Drawing.Size(298, 126);
            this.gameList.TabIndex = 4;
            this.gameList.SelectedIndexChanged += new System.EventHandler(this.gameList_SelectedIndexChanged);
            // 
            // selectedList
            // 
            this.selectedList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedList.ForeColor = System.Drawing.Color.Gray;
            this.selectedList.FormattingEnabled = true;
            this.selectedList.IntegralHeight = false;
            this.selectedList.ItemHeight = 15;
            this.selectedList.Location = new System.Drawing.Point(21, 190);
            this.selectedList.Name = "selectedList";
            this.selectedList.Size = new System.Drawing.Size(298, 84);
            this.selectedList.TabIndex = 77;
            this.selectedList.SelectedIndexChanged += new System.EventHandler(this.selectedList_SelectedIndexChanged);
            // 
            // picLoading
            // 
            this.picLoading.Location = new System.Drawing.Point(148, 170);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(68, 68);
            this.picLoading.TabIndex = 5;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // gameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(365, 382);
            this.Controls.Add(this.picLoading);
            this.Controls.Add(this.gameGroup);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.Gray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "gameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Steam Games";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.gameForm_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gameGroup.ResumeLayout(false);
            this.gameGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtProfile;
        private System.Windows.Forms.GroupBox gameGroup;
        private System.Windows.Forms.ListBox selectedList;
        private System.Windows.Forms.ListBox gameList;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Label lvlExampleInput;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.TextBox txtSearch;
    }
}