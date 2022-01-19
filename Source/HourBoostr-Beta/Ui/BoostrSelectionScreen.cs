using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HourBoostr_Beta.Ui
{
    public partial class BoostrSelectionScreen : Form
    {
        public BoostrSelectionScreen() => InitializeComponent();

        private void ExitButton_Click(object sender, EventArgs e) => Program.This.Close();
          
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
