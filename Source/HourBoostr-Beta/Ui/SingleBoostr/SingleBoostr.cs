using HourBoostr_Beta.Core.SingleBoostr;
using System;
using System.Windows.Forms;

namespace HourBoostr_Beta.Ui.SingleBoostr
{
    public partial class SingleBoostr : Form
    {
        internal GameLibrary GameLibrary;
        internal Instance Instance;
        public SingleBoostr() => InitializeComponent();

        #region Header Controls
        private void BackButton_Click(object sender, EventArgs e)
        {
            Program.This.BoostrSelectionScreen.Show();
            Program.This.SingleBoostr.Hide();
        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {

        }
        private void DonateButton_Click(object sender, EventArgs e)
        {

        }
 
        #endregion

        #region Main Controls
        private void SingleBoostr_Load(object sender, EventArgs e)
        {
            if (Instance == null)
                Instance = new();
        }
        private void TradingCardsButton_Click(object sender, EventArgs e)
        {

        }
        private void IdleHoursButton_Click(object sender, EventArgs e)
        {
            GameLibrary.Show();
            Program.This.SingleBoostr.Hide();
        }
        #endregion

    }
}
