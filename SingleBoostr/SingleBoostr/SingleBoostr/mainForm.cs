using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;
using System.Diagnostics;
using System.Drawing;
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

        private const int _eM_SETCUEBANNER = 0x1501;
        private const int _maxBoostGameCount = 33;

        private static Random _random = new Random();

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.warningdisplayed)
            {
                panelLoading.Visible = true;
                connectToClient();
            }
            else
            {
                foreach (var key in ToS.Languages)
                    cmboxTosLanguage.Items.Add(key.Key);

                setTosLanguage();
                panelWarning.Visible = true;
            }

            setRestartGamesTimerIntervalRandom();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            stopGames();

            Properties.Settings.Default.selectedgames = new System.Collections.Specialized.StringCollection();
            foreach (var game in _gameListSelected)
                Properties.Settings.Default.selectedgames.Add(game.appId.ToString());

            Properties.Settings.Default.Save();
            Environment.Exit(1);
        }

        private void btnTosYes_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.warningdisplayed = true;
            Properties.Settings.Default.Save();

            panelWarning.Visible = false;
            panelLoading.Visible = true;

            connectToClient();
        }

        private void btnTosNo_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnIdle_Click(object sender, EventArgs e)
        {
            if (!_areGamesRunning)
            {
                if (_gameListSelected.Count > 0)
                {
                    disableButtonsTemporarily();
                    startGames();

                    if (cbRestartGames.Checked)
                        restartGamesTimer.Start();
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
            restartGamesTimer.Stop();
            disableButtonsTemporarily();
            stopGames();
        }

        private void lblGithub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Ezzpify");
        }

        private void lblClearSelected_Click(object sender, EventArgs e)
        {
            _gameList.AddRange(_gameListSelected);
            _gameListSelected.Clear();
            refreshGameList();
        }

        private void cbRestartGames_MouseEnter(object sender, EventArgs e)
        {
            cbRestartGames.ForeColor = SystemColors.Highlight;
        }

        private void cbRestartGames_MouseLeave(object sender, EventArgs e)
        {
            cbRestartGames.ForeColor = Color.Gray;
        }

        private void lblGithub_MouseEnter(object sender, EventArgs e)
        {
            lblGithub.ForeColor = SystemColors.Highlight;
        }

        private void lblGithub_MouseLeave(object sender, EventArgs e)
        {
            lblGithub.ForeColor = Color.Gray;
        }

        private void lblClearSelected_MouseEnter(object sender, EventArgs e)
        {
            lblClearSelected.ForeColor = SystemColors.Highlight;
        }

        private void lblClearSelected_MouseLeave(object sender, EventArgs e)
        {
            lblClearSelected.ForeColor = Color.Gray;
        }

        private void cmboxTosLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = cmboxTosLanguage.SelectedItem;

            if (selectedItem != null)
            {
                string shortCode = string.Empty;

                if (ToS.Languages.TryGetValue((string)selectedItem, out shortCode))
                    setTosLanguage(shortCode);
                else
                    /*Defaults to English*/
                    setTosLanguage("en");
            }
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

                        string name = _steamClient.SteamApps001.GetAppData((uint)appId, "name");

                        if (!string.IsNullOrWhiteSpace(name) && _steamClient.SteamApps003.IsSubscribedApp(appId))
                        {
                            _gameList.Add(new GameInfo()
                            {
                                appId = appId,
                                name = getUnicodeString(name)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching game list.\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                panelLoading.Visible = false;
                panelMain.Visible = true;
            }
        }

        private void btnPauseTimer_Tick(object sender, EventArgs e)
        {
            btnPauseTimer.Stop();

            btnIdle.Enabled = true;
            btnStopBoost.Enabled = true;
        }

        private void checkProcessTimer_Tick(object sender, EventArgs e)
        {
            foreach (var process in _gameProcessList)
            {
                if (!_areGamesRunning)
                    break;

                process.Refresh();
                if (process.HasExited && _areGamesRunning)
                    process.Start();
            }
        }

        private void restartGamesTimer_Tick(object sender, EventArgs e)
        {
            /*I was looking to ensure that checkProcessTimer wouldn't re-enable the games
             but then I got the smart idea that we'll abuse that function and just let that
             restart the processes again after we've killed them here!*/

            _areGamesRunning = false;
            checkProcessTimer.Stop();

            foreach (var process in _gameProcessList)
            {
                process.Refresh();

                if (!process.HasExited)
                    process.Kill();
            }

            checkProcessTimer.Start();
            _areGamesRunning = true;

            setRestartGamesTimerIntervalRandom();
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

        private void connectToClient()
        {
            Text = "SingleBoostr :: Fetching user...";
            SendMessage(txtSearch.Handle, _eM_SETCUEBANNER, 0, "Search game");

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
                setTitleUsernameFromSteamId64(_steamClient.SteamUser.GetSteamID());
                gameListWorker.RunWorkerAsync();
            }
        }

        private void setRestartGamesTimerIntervalRandom()
        {
            int baseTime = (int)TimeSpan.FromHours(2).TotalMilliseconds;
            baseTime += _random.Next((int)TimeSpan.FromMinutes(45).TotalMilliseconds,
                (int)TimeSpan.FromMinutes(75).TotalMilliseconds);

            restartGamesTimer.Interval = baseTime;
        }

        private string getUnicodeString(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            return Encoding.UTF8.GetString(bytes);
        }

        private void disableButtonsTemporarily()
        {
            btnIdle.Enabled = false;
            btnStopBoost.Enabled = false;

            btnPauseTimer.Start();
        }

        private void setTosLanguage(string lang = "")
        {
            if (string.IsNullOrWhiteSpace(lang))
                lang = CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;

            lblToS.Text = ToS.GetTermsOfService(lang);

            var key = ToS.Languages.FirstOrDefault(o => o.Value == lang).Key;
            if (key != null)
                cmboxTosLanguage.Text = key;
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

            checkProcessTimer.Start();
            lblActiveGames.Text = $"You're currently idling {_gameProcessList.Count} game(s).";
        }

        private void stopGames()
        {
            checkProcessTimer.Stop();
            _areGamesRunning = false;

            foreach (var process in _gameProcessList)
            {
                process.Refresh();

                if (!process.HasExited)
                    process.Kill();
            }

            _gameProcessList.Clear();
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

                if (username != "Error" && !string.IsNullOrWhiteSpace(username))
                {
                    Text = $"SingleBoostr :: {getUnicodeString(username)}";
                }
                else
                {
                    Text = $"SingleBoostr :: Unknown user";
                }
            }
        }

        private void refreshGameList()
        {
            /*Check if we have any saved games from last time*/
            if (Properties.Settings.Default.selectedgames != null)
            {
                foreach (var game in Properties.Settings.Default.selectedgames)
                {
                    long gameId = 0;
                    if (!long.TryParse(game, out gameId) || gameId == 0)
                        continue;

                    var obj = _gameList.FirstOrDefault(o => o.appId == gameId);
                    if (obj != null)
                    {
                        _gameListSelected.Add(obj);
                        _gameList.Remove(obj);
                    }
                }

                /*Only want to do this once so we'll null this cunt*/
                Properties.Settings.Default.selectedgames = null;
            }
            
            _gameList.Sort();
            listGames.Items.Clear();
            listGamesSelected.Items.Clear();

            List<GameInfo> gameList;
            string searchQuery = txtSearch.Text;

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                /*If we have no search then use original list.
                 We use .ToList() to avoid creating a reference*/
                gameList = _gameList.ToList();
            }
            else
            {
                /*Pick out games which names match the search query*/
                gameList = _gameList.ToList().Where(o => o.name.ToLower().Contains(searchQuery.ToLower())).ToList();
            }
            
            /*Pick out only name from the game list and cast it to an object array so we can set
             whole listBox at once with the games*/
            var objectList = gameList.Select(o => o.name).ToList().Cast<object>().ToArray();
            listGames.Items.AddRange(objectList);

            /*Do the same for selected. We'll borrow the objectList.*/
            objectList = _gameListSelected.ToList().Select(o => o.name).ToList().Cast<object>().ToArray();
            _gameListSelected.ForEach(o => listGamesSelected.Items.Add(o.name));

            lblClearSelected.Visible = _gameListSelected.Count > 0;
            lblGameCounter.Text = string.IsNullOrWhiteSpace(searchQuery) ? $"Games available: {_gameList.Count}" : $"Matching games: {listGames.Items.Count}";
            lblSelectedGameCounter.Text = $"Selected games: {_gameListSelected.Count}";

            if (_gameListSelected.Count == _maxBoostGameCount && !_gameCountWarningDisplayed)
            {
                _gameCountWarningDisplayed = true;
                MessageBox.Show($"Steam only allows {_maxBoostGameCount} games to be played at once. You can continue adding games, but they won't track any hours.", 
                    "Steam limit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}