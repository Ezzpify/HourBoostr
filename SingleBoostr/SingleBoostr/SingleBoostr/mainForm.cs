using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Xml;

namespace SingleBoostr
{
    public partial class mainForm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        
        private Client _steamClient = new Client();
        private List<GameInfo> _gameList = new List<GameInfo>();
        private List<GameInfo> _gameListSelected = new List<GameInfo>();
        private List<Process> _gameProcessList = new List<Process>();

        private bool _areGamesRunning;
        private bool _gameCountWarningDisplayed;
        
        private const int EM_SETCUEBANNER = 0x1501;
        
        public mainForm()
        {
            InitializeComponent();
        }
        
        private void mainForm_Load(object sender, EventArgs e)
        {
            #if DEBUG
                Properties.Settings.Default.warningdisplayed = false;
            #endif

            /*If VAC warning has already been displayed when we'll skip that part*/
            if (Properties.Settings.Default.warningdisplayed)
            {
                connectToClient();
            }
        }
        
        private void btnTosYes_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.warningdisplayed = true;
            Properties.Settings.Default.Save();

            connectToClient();
        }

        private void btnTosNo_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void connectToClient()
        {
            panelWarning.Visible = false;
            Text = "SingleBoostr :: Fetching user...";
            SendMessage(txtSearch.Handle, EM_SETCUEBANNER, 0, "Search game");
            
            if (Application.StartupPath == Steam.GetInstallPath())
            {
                lblStatus.Text = "Don't run this application from the Steam directory.";
            }
            else if (!File.Exists(Const.GAME_PROCESS))
            {
                lblStatus.Text = "Missing SingleBoostr.Game application.";
            }
            else if (!_steamClient.Initialize(0L))
            {
                lblStatus.Text = "Steam is not running. Please start Steam then run me again.";
            }
            else if (!_steamClient.SteamUser.IsLoggedIn())
            {
                lblStatus.Text = "You're not logged into Steam.";
            }
            else
            {
                picLoading.Visible = true;
                panelLaunchPadder.Visible = false;

                setTitleUsernameFromSteamId64(_steamClient.SteamUser.GetSteamID());
                gameListWorker.RunWorkerAsync();
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopGames();
        }

        private void btnBoost_Click(object sender, EventArgs e)
        {
            if (!_areGamesRunning)
            {
                if (_gameListSelected.Count > 0)
                {
                    disableButtonsTemporarily();
                    startGames();
                }
                else
                {
                    MessageBox.Show("No games added. Click on games in the left list to select them.", 
                        "Uhh...", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                }
            }
        }

        private void btnStopBoost_Click(object sender, EventArgs e)
        {
            disableButtonsTemporarily();
            stopGames();
        }

        private void listGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Move clicked items from the game list to the selected list*/
            var item = listGames.SelectedItem;
            if (item != null)
            {
                var game = _gameList.FirstOrDefault(o => o.name == (string)item);
                if (game != null)
                {
                    _gameListSelected.Add(game);
                    _gameList.Remove(game);

                    refreshGameList();
                }
            }
        }
        
        private void listGamesSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Move clicked items from the selected list to the game list*/
            var item = listGamesSelected.SelectedItem;
            if (item != null)
            {
                var game = _gameListSelected.FirstOrDefault(o => o.name == (string)item);
                if (game != null)
                {
                    _gameList.Add(game);
                    _gameListSelected.Remove(game);

                    refreshGameList();
                }
            }
        }
        
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            refreshGameList();
        }
        
        private void gameListWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var document = new XmlDocument();

            try
            {
                string localXml = Const.GAME_LIST_LOCAL;
                if (!File.Exists(localXml))
                {
                    /*Fetch the game list from Github*/
                    string xml = downloadXmlList(Const.GAME_LIST_URL);
                    if (!string.IsNullOrWhiteSpace(xml))
                    {
                        File.WriteAllText(Const.GAME_LIST_LOCAL, xml);
                    }
                }

                /*Load it from file*/
                document.Load(localXml);

                foreach (XmlNode node in document.SelectNodes("/games/game"))
                {
                    if (string.IsNullOrWhiteSpace(node.InnerText))
                        continue;

                    long appId = 0;
                    if (long.TryParse(node.InnerText, out appId))
                    {
                        if (appId == 0)
                            continue;

                        var gameInfo = new GameInfo();
                        gameInfo.name = _steamClient.SteamApps001.GetAppData((uint)appId, "name");
                        gameInfo.appId = appId;

                        if (!string.IsNullOrWhiteSpace(gameInfo.name) && _steamClient.SteamApps003.IsSubscribedApp(appId))
                            _gameList.Add(gameInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching game list.\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string downloadXmlList(string url)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    return client.DownloadString(new Uri(url));
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        private void gameListWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_gameList.Count == 0)
            {
                panelLaunchPadder.Visible = true;
                picLoading.Visible = false;
                lblStatus.Text = "Either you have 0 games, or something went wrong. Hmm... Are you sure you're logged in?";
            }
            else
            {
                refreshGameList();
                panelLaunch.Visible = false;
                panelMain.Visible = true;
            }
        }

        private void disableButtonsTemporarily()
        {
            btnBoost.Enabled = false;
            btnStopBoost.Enabled = false;

            btnPauseTimer.Start();
        }
        
        private void btnPauseTimer_Tick(object sender, EventArgs e)
        {
            btnPauseTimer.Stop();

            btnBoost.Enabled = true;
            btnStopBoost.Enabled = true;
        }

        private void startGames()
        {
            listGamesActive.Items.Clear();

            if (_gameListSelected.Count > 0)
            {
                foreach (var game in _gameListSelected)
                {
                    var process = new Process();

                    /*Run windowless*/
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    /*Argument*/
                    process.StartInfo.FileName = @"SingleBoostr.Game.exe";
                    process.StartInfo.Arguments = $"\"{game.appId}\" \"{game.name}\" \"{Process.GetCurrentProcess().Id}\"";

                    _gameProcessList.Add(process);
                    listGamesActive.Items.Add(game.name);
                }
            }

            foreach (var process in _gameProcessList)
            {
                process.Start();
            }

            panelRunning.Visible = true;
            panelMain.Visible = false;
            _areGamesRunning = true;

            lblActiveGames.Text = $"You're currently idling {_gameProcessList.Count} game(s).";
        }

        private void stopGames()
        {
            foreach (var process in _gameProcessList)
            {
                process.Refresh();

                if (!process.HasExited)
                    process.Kill();
            }

            _gameProcessList.Clear();
            _areGamesRunning = false;

            panelRunning.Visible = false;
            panelMain.Visible = true;
        }

        private void setTitleUsernameFromSteamId64(ulong id)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    client.DownloadStringCompleted += steamProfileJsonDownloaded;
                    client.DownloadStringAsync(new Uri($"https://steamcommunity.com/profiles/{id}"));
                }
            }
            catch
            {
                Text = "SingleBoostr :: Unknown user";
            }
        }

        private void steamProfileJsonDownloaded(object sender, DownloadStringCompletedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Result) && e.Result.Contains("Steam Community :: "))
            {
                /*Oh shit some naughty quick html parsing. Or well, just grabbing some stuff inbetween. ;-)*/
                string username = Regex.Match(e.Result, @"Steam Community :: (.+?)</title>").Groups[1].Value.Trim();

                if (username != "Error")
                    Text = $"SingleBoostr :: {username}";
            }
        }

        private void refreshGameList()
        {
            _gameList.Sort();
            _gameListSelected.Sort();

            listGames.Items.Clear();
            listGamesSelected.Items.Clear();

            string searchQuery = txtSearch.Text;
            foreach (var game in _gameList)
            {
                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    if (!game.name.ToLower().Contains(searchQuery.ToLower()))
                        continue;
                }

                listGames.Items.Add(game.name);
            }

            _gameListSelected.ForEach(o => listGamesSelected.Items.Add(o.name));
            lblGameCounter.Text = string.IsNullOrWhiteSpace(searchQuery) ? $"Games available: {_gameList.Count}" : $"Matching games: {listGames.Items.Count}";
            lblSelectedGameCounter.Text = $"Selected games: {_gameListSelected.Count}";

            if (_gameListSelected.Count == 33 && !_gameCountWarningDisplayed)
            {
                _gameCountWarningDisplayed = true;
                MessageBox.Show("Steam only allows 33 games to be played at once. You can continue adding games, but they won't track any hours.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
