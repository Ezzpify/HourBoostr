using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HourBoostr_Beta.Ui
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            Task.Run(() => Init());
        }

        private async Task Init()
        {
            await Task.Delay(5 * 1000);
            InfoBox.Invoke((MethodInvoker)delegate 
            {
                InfoBox.Text = "Loaded";
            });
        } 
    }
}
