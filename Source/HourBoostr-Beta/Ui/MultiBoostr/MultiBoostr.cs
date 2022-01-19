using System;
using System.Windows.Forms;
using HourBoostr_Beta.Core.MultiBoostr;

namespace HourBoostr_Beta.Ui.MultiBoostr
{
    public partial class MultiBoostr : Form
    {
        private Instance Instance;
        public MultiBoostr() => InitializeComponent();

        #region Header Controls
        private void BackButton_Click(object sender, EventArgs e)
        {
            Program.This.BoostrSelectionScreen.Show();
            Program.This.MultiBoostr.Hide();
        }
        private void ExitButton_Click(object sender, EventArgs e) => Program.This.Close();
        #endregion

        #region Main Controls
        private void SingleBoostr_Load(object sender, EventArgs e) => Instance = new(); 
        #endregion 
    }
}
