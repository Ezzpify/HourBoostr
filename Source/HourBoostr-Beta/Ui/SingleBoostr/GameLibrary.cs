using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HourBoostr_Beta.Ui.SingleBoostr
{
    public partial class GameLibrary : Form
    {
        public GameLibrary() => InitializeComponent();

        #region Header Controls
        private void ExitButton_Click(object sender, EventArgs e) => Program.This.Close();
        private void BackButton_Click(object sender, EventArgs e)
        {
            Program.This.SingleBoostr.Show();
            Program.This.SingleBoostr.GameLibrary.Hide();
        }
        #endregion

        #region Main Controls

        #endregion
    }
}
