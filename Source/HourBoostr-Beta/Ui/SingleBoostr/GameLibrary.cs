using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace HourBoostr_Beta.Ui.SingleBoostr
{
    public partial class GameLibrary : Form
    {
        internal Process IdlerProcess;
        public GameLibrary()
        {
            InitializeComponent();
        }

        #region Header Controls
        private void ExitButton_Click(object sender, EventArgs e) => Program.This.Close();
        private void BackButton_Click(object sender, EventArgs e)
        {
            Program.This.SingleBoostr.Show();
            Program.This.SingleBoostr.GameLibrary.Hide();
        }
        #endregion

        #region Main Controls
        private void GameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGamePanel();
        }
        private void GameLibrary_Load(object sender, EventArgs e)
        {
            GameList.Items.Clear();
            GameList.Items.AddRange(GetGameList());
            UpdateGamePanel();
        }
        #endregion

        private string[] GetGameList()
        {
            return new[]{
                "Aim Lab","Apex Legends",
                "Arma 2","Arma 3","DayZ",
                "Fallout 3","Fallout 4","Fallout 76"
            };
        }

        private void UpdateGamePanel()
        {
            var hasGames = GameList.Items.Count > 0;

            if (hasGames)
            {
                var noneselected = GameList.SelectedIndex < 0;
                if (noneselected)
                    GameList.SelectedIndex = 0;

                var item = GameList.SelectedItem.ToString();
                var validitem = !string.IsNullOrEmpty(item);
                if (validitem)
                {
                    //-- Set title
                    GameLabel.Text = item;




                }
            }
        }
        private const string GameSearchPlaceholder = "Search Name or appID";

        private void GameSearchBox_MouseHover(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GameSearchBox.Text))
                GameSearchBox.Text = GameSearchPlaceholder;
        }

        private void GameSearchBox_MouseLeave(object sender, EventArgs e)
        {
            if (GameSearchBox.Text.Equals(GameSearchPlaceholder))
                GameSearchBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var idler = Path.Combine(Application.StartupPath, "HourBoostr.Idler.exe");
            if (File.Exists(idler))
            {
                IdlerProcess = new Process() { StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    FileName = idler,
                    Arguments = $"-single 107410 {Process.GetCurrentProcess().Id}"
                }};
                IdlerProcess.Start();
            }
        }

        private void GameLibrary_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdlerProcess.Kill();
        }

        private void GameLibrary_FormClosing(object sender, FormClosedEventArgs e)
        {
            IdlerProcess.Kill();
        }
    }
}
