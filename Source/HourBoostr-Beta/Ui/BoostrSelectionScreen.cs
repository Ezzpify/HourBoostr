using System;
using System.Windows.Forms;

namespace HourBoostr_Beta.Ui
{
    public partial class BoostrSelectionScreen : Form
    {
        public BoostrSelectionScreen() => InitializeComponent();
          
        private void SingleBoostrButton_Click(object sender, EventArgs e)
        {
            Program.This.SingleBoostr.Show();
            Program.This.BoostrSelectionScreen.Hide();
        }

        private void MultiBoostrButton_Click(object sender, EventArgs e)
        {
            Program.This.MultiBoostr.Show();
            Program.This.BoostrSelectionScreen.Hide();
        }
    }
}
