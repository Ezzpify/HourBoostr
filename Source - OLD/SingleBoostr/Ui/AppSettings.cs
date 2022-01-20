using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using SingleBoostr.Objects;
using SingleBoostr.Core.Objects;
using SingleBoostr.Core.Misc;

namespace SingleBoostr.Ui
{
    public partial class AppSettings : Form
    {
        public Settings Settings { get; private set; }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
            Pen pen = new Pen(Misc.Utils.LABEL_HOVER);
            e.Graphics.DrawRectangle(pen, rect);
        }

        public AppSettings()
        {
            InitializeComponent();

            if (!LoadSettings())
                SaveSettings();
        }

        public bool SaveSettings()
        {
            string jsonStr = JsonConvert.SerializeObject(Settings, Formatting.Indented);
            if (!string.IsNullOrWhiteSpace(jsonStr))
            {
                File.WriteAllText(Const.SingleBoostr.SETTINGS_FILE, jsonStr);
                return true;
            }

            return false;
        }

        public bool LoadSettings()
        {
            if (File.Exists(Const.SingleBoostr.SETTINGS_FILE))
            {
                string jsonStr = File.ReadAllText(Const.SingleBoostr.SETTINGS_FILE);
                if (!string.IsNullOrWhiteSpace(jsonStr))
                {
                    try
                    {
                        Settings = JsonConvert.DeserializeObject<Settings>(jsonStr);
                        Settings.Verify();
                        return Settings != null;
                    }
                    catch (Exception ex)
                    {
                        AppMessageBox.Show($"Error parsing {Const.SingleBoostr.SETTINGS_FILE}. File is probably corrupt. Settings will be reset. Don't mess with the file directly unless you know what you're doing.\nError: {ex.Message}", "Settings error",
                            AppMessageBox.Buttons.OK, AppMessageBox.MsgIcon.Error);
                    }
                }
            }

            Settings = new Settings();
            Settings.ChatResponses.Add("I'm idling with {PROJECT_ONE_NAME}. {STEAM_GROUP_URL}");
            Settings.ChatResponses.Add("Right now I'm idling games with {PROJECT_ONE_NAME}!");
            return false;
        }

        public void AddBrowserSessionInfo(SessionInfo info)
        {
            Settings.WebSession = info;
        }

        public async Task<bool> DownloadAppList()
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    client.Encoding = Encoding.UTF8;

                    string str = await client.DownloadStringTaskAsync(new Uri(Const.Steam.APP_LIST_URL));

                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        File.WriteAllText(Const.SingleBoostr.APP_LIST, str);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                AppMessageBox.Show($"Error downloading app list. Steam might be down.\n{ex.Message}", "Error", AppMessageBox.Buttons.OK, AppMessageBox.MsgIcon.Error);
            }

            return false;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            CbEnableChatResponse.Checked = Settings.EnableChatResponse;
            TxtChatResponses.Lines = Settings.ChatResponses.ToArray();
            CbOnlyReplyIfIdling.Checked = Settings.OnlyReplyIfIdling;
            CbWaitBetweenReplies.Checked = Settings.WaitBetweenReplies;
            NumWaitBetweenReplies.Value = Settings.WaitBetweenRepliesTime;
            CbRestartGames.Checked = Settings.RestartGames;
            NumRestartGamesMinutes.Value = Settings.RestartGamesTime;
            CbRestartGamesRandomly.Checked = Settings.RestartGamesAtRandom;
            CbCheckForUpdates.Checked = Settings.CheckForUpdates;
            CbClearRecentlyPlayed.Checked = Settings.ClearRecentlyPlayedOnExit;
            CbForceOnlineStatus.Checked = Settings.ForceOnlineStatus;
            CbSaveAppIdleHistory.Checked = Settings.SaveAppIdleHistory;
            CbJoinSteamGroup.Checked = Settings.JoinSteamGroup;
            CbSaveLoginCookies.Checked = Settings.SaveLoginCookies;
            CbHideToTraybar.Checked = Settings.HideToTraybar;
            CbOnlyIdleGamesWithCertainMinutes.Checked = Settings.OnlyIdleGamesWithCertainMinutes;
            NumOnlyIdleGamesWithCertainMinutes.Value = Settings.NumOnlyIdleGamesWithCertainMinutes;
            NumGamesIdleWhenNoCards.Value = Settings.NumGamesIdleWhenNoCards;
            CbIdleCardsWithMostValue.Checked = Settings.IdleCardsWithMostValue;
            LblClearBlackList.Text = $"Clear {Settings.BlacklistedCardGames.Count} blacklisted card(s)";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Settings.EnableChatResponse = CbEnableChatResponse.Checked;
            Settings.ChatResponses = TxtChatResponses.Lines.Where(o => !string.IsNullOrWhiteSpace(o)).ToList();
            Settings.OnlyReplyIfIdling = CbOnlyReplyIfIdling.Checked;
            Settings.WaitBetweenReplies = CbWaitBetweenReplies.Checked;
            Settings.RestartGames = CbRestartGames.Checked;
            Settings.RestartGamesTime = (int)NumRestartGamesMinutes.Value;
            Settings.RestartGamesAtRandom = CbRestartGamesRandomly.Checked;
            Settings.CheckForUpdates = CbCheckForUpdates.Checked;
            Settings.ClearRecentlyPlayedOnExit = CbClearRecentlyPlayed.Checked;
            Settings.ForceOnlineStatus = CbForceOnlineStatus.Checked;
            Settings.SaveAppIdleHistory = CbSaveAppIdleHistory.Checked;
            Settings.JoinSteamGroup = CbJoinSteamGroup.Checked;
            Settings.SaveLoginCookies = CbSaveLoginCookies.Checked;
            Settings.HideToTraybar = CbHideToTraybar.Checked;
            Settings.OnlyIdleGamesWithCertainMinutes = CbOnlyIdleGamesWithCertainMinutes.Checked;
            Settings.NumOnlyIdleGamesWithCertainMinutes = (int)NumOnlyIdleGamesWithCertainMinutes.Value;
            Settings.NumGamesIdleWhenNoCards = (int)NumGamesIdleWhenNoCards.Value;
            Settings.IdleCardsWithMostValue = CbIdleCardsWithMostValue.Checked;
            Settings.WaitBetweenRepliesTime = (int)NumWaitBetweenReplies.Value;

            DialogResult = DialogResult.OK;
            ActiveControl = label1;
            SaveSettings();
            Close();
        }

        private void PanelContainer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, Const.WM_NCLBUTTONDOWN, Const.HT_CAPTION, 0);
            }
        }

        private void BtnSave_MouseEnter(object sender, EventArgs e)
        {
            BtnSave.BackgroundImage = Properties.Resources.Back_Selected;
        }

        private void BtnSave_MouseLeave(object sender, EventArgs e)
        {
            BtnSave.BackgroundImage = Properties.Resources.Back;
        }

        private void LblDownloadNewAppList_MouseEnter(object sender, EventArgs e)
        {
            LblDownloadNewAppList.ForeColor = Misc.Utils.LABEL_HOVER;
        }

        private void LblDownloadNewAppList_MouseLeave(object sender, EventArgs e)
        {
            LblDownloadNewAppList.ForeColor = Misc.Utils.LABEL_NORMAL;
        }

        private async void LblDownloadNewAppList_Click(object sender, EventArgs e)
        {
            LblDownloadNewAppList.Enabled = false;
            if (await DownloadAppList())
            {
                AppMessageBox.Show("Downloaded new app list! Restart application in order for new games to be loaded.", "Success", AppMessageBox.Buttons.OK, AppMessageBox.MsgIcon.Info);
                LblDownloadNewAppList.Enabled = true;
            }
        }

        private void LblClearBlackList_Click(object sender, EventArgs e)
        {
            Settings.BlacklistedCardGames.Clear();
            LblClearBlackList.Text = $"Clear {Settings.BlacklistedCardGames.Count} blacklisted card(s)";
        }

        private void LblClearBlackList_MouseEnter(object sender, EventArgs e)
        {
            LblClearBlackList.ForeColor = Misc.Utils.LABEL_HOVER;
        }

        private void LblClearBlackList_MouseLeave(object sender, EventArgs e)
        {
            LblClearBlackList.ForeColor = Misc.Utils.LABEL_NORMAL;
        }

        private void CbEnableChatResponse_CheckedChanged(object sender, EventArgs e)
        {
            if (!Settings.ChatResponseTipDisplayed)
            {
                Settings.ChatResponseTipDisplayed = true;
                AppMessageBox.Show("Enter multiple lines into the chat responses box and the program will pick a random line every time someone sends you a message.", 
                    "Tip!", AppMessageBox.Buttons.Gotit, AppMessageBox.MsgIcon.Info);
            }
        }
    }
}
