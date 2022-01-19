using System;
using System.Threading;
using System.Windows.Forms;

namespace HourBoostr_Beta.Ui
{
    public partial class SingleBoostr : Form
    {
        public SingleBoostr() => InitializeComponent();

        private void ExitButton_Click(object sender, EventArgs e) => Program.This.Close();

        private void BackButton_Click(object sender, EventArgs e)
        {
            Program.This.BoostrSelectionScreen.Show();
            Program.This.SingleBoostr.Hide();
        }
    }
}
