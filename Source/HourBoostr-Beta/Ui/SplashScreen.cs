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
            InfoBox.Invoke((MethodInvoker)async delegate
            {
                InfoBox.Text = "Loaded";
                await Task.Delay(1000);
                Program.This.SplashScreen.Hide();
                Program.This.BoostrSelectionScreen.Show();
            });
        }
    }
}
