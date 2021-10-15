using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Net;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using Steam4NET;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq; 
using SingleBoostr.objects; 
using SingleBoostr.Core.Enums;
using SingleBoostr.Core.Misc;
using SingleBoostr.Core.Objects;

namespace SingleBoostr.Ui
{
    public partial class AppHome : Form
    {
        private Log _log;
        private Log _logChat;
        private SteamWeb _steamWeb;
        private AppDonate _donation;
        private AppSettings _settings;
        private Dictionary<ulong, DateTime> _chatResponses = new Dictionary<ulong, DateTime>();

        private bool _canGoBack;
        private bool _appExiting;
        private bool _appCountWarningDisplayed;

        private Session _activeSession;
        private WindowPanel _activeWindow;
        private DateTime _idleTimeStarted;

        private List<App> _appList = new List<App>();
        private List<App> _appListActive = new List<App>();
        private List<App> _appListBadges = new List<App>();
        private List<App> _appListSelected = new List<App>();

        private App _appCurrentBadge;

        public AppHome()
        {
            InitializeComponent();
        }
         
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            _log = new Log("Main.txt");
            _logChat = new Log("Chat.txt");

            _settings = new AppSettings();
            _donation = new AppDonate();

            Program.Base.APIKey = _settings.Settings.WebSession.APIKey;

            Directory.CreateDirectory("Error");

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                        | SecurityProtocolType.Tls11
                        | SecurityProtocolType.Tls12
                        | SecurityProtocolType.Ssl3;

            if (IsDuplicateAlreadyRunning())
                ExitApplication();

            /*Overwrites the cursor and renderer for the ContextMenuStrip we use for CardsStarted options panel.*/
            CardsStartedOptionsMenu.Cursor = Cursors.Hand;
            CardsStartedOptionsMenu.Renderer = new MyRenderer();

            if (!File.Exists(Const.SingleBoostr.IDLER_EXE))
            {
                /*I don't know if it's a good idea to embed the game exe into the main program. That might [trigger] some Anti-Virus software.*/
                AppMessageBox.Show($"Missing {Const.SingleBoostr.IDLER_EXE} please redownload program.", "Error", AppMessageBox.Buttons.OK, AppMessageBox.MsgIcon.Error);
                ExitApplication();
            }

            try
            {
                /*We need to register the application under Internet Explorer emulation registry key. Not doing this would cause the Steam Login web browser to render the css all wonky.*/
                RegistryKey ie_root = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION");
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                key.SetValue(AppDomain.CurrentDomain.FriendlyName, 10001, RegistryValueKind.DWord);
            }
            catch (Exception ex)
            {
                _log.Write(LogLevel.Error, $"Error adding registry key for browser emulation support. {ex.Message}");
                AppMessageBox.Show($"Unable to add registry key for browser support. Web pages may appear rather... wonky.\n\n{ex.Message}", "Registry error",
                    AppMessageBox.Buttons.OK, AppMessageBox.MsgIcon.Error);
            }

            /*Here we're just setting a placeholder text for the AppSearch textbox in the Idle panel*/
            if (!PanelIdleTxtSearch.IsDisposed)
                NativeMethods.SendMessage(PanelIdleTxtSearch.Handle, Const.EM_SETCUEBANNER, IntPtr.Zero, "Search game");

            if (_settings.Settings.VACWarningDisplayed)
            {
                ShowWindow(WindowPanel.Loading);
                InitializeApp();
            }
            else
            {
                /*We'll display the Terms of Service in whatever language the user is running on his computer.
                 Provided that we have that translation, of course.*/
                string language = CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;
                PanelTosLblText.Text = localization.TermsOfService.GetTermsOfService(language);
                ShowWindow(WindowPanel.Tos);
            }

            PanelStartLblVersion.Text = $"v{System.Windows.Forms.Application.ProductVersion}";
            ToolTip.OwnerDraw = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopApps();
            _appExiting = true;
            BgwSteamCallback.CancelAsync();

            if (_settings.Settings.SaveAppIdleHistory)
            {
                _settings.Settings.GameHistoryIds = _appListSelected.Select(o => o.Appid).ToList();
                _settings.SaveSettings();
            }

            if (_settings.Settings.ClearRecentlyPlayedOnExit)
            {
                /*These three games does not show up in the recently played section on your profile,
                 however they still take a spot. So essentially they do clear the recently played games.*/
                _appListActive.Clear();
                _appListActive.Add(new App() { Appid = 399220 });
                _appListActive.Add(new App() { Appid = 399080 });
                _appListActive.Add(new App() { Appid = 399480 });
                StartApps(Session.Idle);
            }

            AppNotifyIcon.Visible = false;
            AppNotifyIcon.Dispose();
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            /*We set the active control to a random label else when the user tabs out of the form
             it will automatically focus the next button which makes it get a clunky border
             which looks absolutely awful.*/
            ActiveControl = PanelUserLblName;
        }

        #region ButtonEvents

        private void PanelCardsStartedLblOptions_Click(object sender, EventArgs e)
        {
            /*The options button in CardsStarted opens a ContextMenuStrip on right click.
             So here we will make it work with left click as well.*/
            Label btnSender = (Label)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            CardsStartedOptionsMenu.Show(ptLowerLeft);
        }

        private void CardsStartedOptionsMenuBtnBlacklist_Click(object sender, EventArgs e)
        {
            if (_appCurrentBadge == null)
            {
                _log.Write(LogLevel.Error, $"Current app is null. Unable to add it to block list. Hmmmm ...");
                return;
            }

            //https://github.com/dotnet/roslyn/pull/3507
            var diag = AppMessageBox.Show($"Do you want to blacklist {_appCurrentBadge.Name}? You can always undo this in Settings.", "Blacklist game", AppMessageBox.Buttons.YesNo, AppMessageBox.MsgIcon.Question);
            if (diag == DialogResult.Yes)
            {
                _settings.Settings.BlacklistedCardGames.Add(_appCurrentBadge.Appid);
                StartNextCard();
            }
        }

        private void CardsStartedOptionsMenuBtnSortQueue_Click(object sender, EventArgs e)
        {
            AppQueue frm = null;
            if (_settings.Settings.OnlyIdleGamesWithCertainMinutes)
            {
                int minimumMinutes = _settings.Settings.NumOnlyIdleGamesWithCertainMinutes;
                frm = new AppQueue(_appListBadges.Where(o => o.Card.Minutesplayed > minimumMinutes).ToList(), _appCurrentBadge);
            }
            else
            {
                frm = new AppQueue(_appListBadges, _appCurrentBadge);
            }

            if (frm.ShowDialog() == DialogResult.OK)
                _appListBadges = frm.AppList.Union(_appListBadges).ToList();
        }

        private void PanelStartLblVersion_Click(object sender, EventArgs e)
        {
            Process.Start(Const.GitHub.REPO_RELEASE_URL);
        }

        private void MessageText_Click(object sender, EventArgs e, string url)
        {
            Process.Start(url);
        }

        private void CloseText_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Control grandparent = control?.Parent?.Parent;

            if (grandparent != null)
                PanelStartChatPanel.Controls.Remove(grandparent);
        }

        private void showToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void PanelCardsStartedBtnHide_Click(object sender, EventArgs e)
        {
            if (_settings.Settings.HideToTraybar)
            {
                Hide();
                AppNotifyIcon.ShowBalloonTip(1000, "SingleBoostr", "I'm down here.", ToolTipIcon.Info);
            }
            else
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void PanelIdleStartedBtnHide_Click(object sender, EventArgs e)
        {
            if (_settings.Settings.HideToTraybar)
            {
                Hide();
                AppNotifyIcon.ShowBalloonTip(1000, "SingleBoostr", "I'm down here.", ToolTipIcon.Info);
            }
            else
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void PanelCardsStartedBtnNext_Click(object sender, EventArgs e)
        {
            _log.Write(LogLevel.Info, $"Skipping current game");
            PanelCardsStartedBtnNext.Enabled = false;
            StartNextCard();
        }

        private void PanelIdleStartedBtnStop_Click(object sender, EventArgs e)
        {
            StopApps();
        }

        private void PanelCardsStartedBtnStopIdle_Click(object sender, EventArgs e)
        {
            StopApps();
        }

        private void PanelIdleLblClear_Click(object sender, EventArgs e)
        {
            _appList.AddRange(_appListSelected);
            _appListSelected.Clear();
            RefreshGameList();
        }

        private void PanelStartBtnIdle_Click(object sender, EventArgs e)
        {
            switch (_activeSession)
            {
                case Session.Cards:
                    var diag = AppMessageBox.Show("You're already farming Trading Cards.\nDo you wish to stop that and idle other apps?",
                    "Already active", AppMessageBox.Buttons.YesNo, AppMessageBox.MsgIcon.Question);
                    if (diag == DialogResult.Yes)
                    {
                        StopApps();
                        ShowWindow(WindowPanel.Idle);
                    }
                    break;

                case Session.Idle:
                    ShowWindow(WindowPanel.IdleStarted);
                    break;

                case Session.None:
                    ShowWindow(WindowPanel.Idle);
                    break;
            }
        }

        private void PanelStartBtnCards_Click(object sender, EventArgs e)
        {
            switch (_activeSession)
            {
                case Session.Cards:
                    ShowWindow(WindowPanel.CardsStarted);
                    break;

                case Session.Idle:
                    var diag = AppMessageBox.Show("You're already idling other apps.\nDo you wish to stop that and start farming cards?",
                    "Already active", AppMessageBox.Buttons.YesNo, AppMessageBox.MsgIcon.Question);
                    if (diag == DialogResult.Yes)
                    {
                        StopApps();
                        goto case Session.None;
                    }
                    break;

                case Session.None:
                    if (_settings.Settings.WebSession.IsLoggedIn())
                    {
                        _steamWeb = new SteamWeb(_settings.Settings.WebSession);
                        ShowWindow(WindowPanel.Loading);
                        StartCardsFarming();
                    }
                    else
                    {
                        ShowWindow(WindowPanel.Cards);
                    }
                    break;
            }
        }

        private void PanelUserPicGoBack_Click(object sender, EventArgs e)
        {
            if (_canGoBack)
            {
                if (_activeWindow == WindowPanel.Start)
                {
                    switch (_activeSession)
                    {
                        case Session.Cards:
                            ShowWindow(WindowPanel.CardsStarted);
                            break;

                        case Session.Idle:
                        case Session.CardsBatch:
                            ShowWindow(WindowPanel.IdleStarted);
                            break;
                    }
                }
                else
                {
                    ShowWindow(WindowPanel.Start);
                }
            }
        }

        private void PanelidleBtnIdle_Click(object sender, EventArgs e)
        {
            if (_appListSelected.Count > 0)
            {
                if (_activeSession == Session.None)
                {
                    _appListActive = _appListSelected.ToList();
                    StartApps(Session.Idle);
                }
            }
            else
            {
                AppMessageBox.Show("You didn't select any games.", "Start Idle", AppMessageBox.Buttons.OK, AppMessageBox.MsgIcon.Info);
            }
        }

        private async void PanelCardsBtnLogin_Click(object sender, EventArgs e)
        {
            var browser = new AppWebBrowser();
            if (browser.ShowDialog() == DialogResult.OK)
            {
                if (browser.Session.IsLoggedIn())
                {
                    ShowWindow(WindowPanel.Loading);
                    if (_settings.Settings.SaveLoginCookies)
                        _settings.AddBrowserSessionInfo(browser.Session);

                    _steamWeb = new SteamWeb(_settings.Settings.WebSession);
                    if (_settings.Settings.JoinSteamGroup)
                    {
                        string joinGroupUrl = $"{Const.Steam.GROUP.URL}?sessionID={browser.Session.SessionId}&action=join";
                        string resp = await _steamWeb.Request(joinGroupUrl);
                    }

                    StartCardsFarming();
                    return;
                }
            }

            ShowWindow(WindowPanel.Start);
        }

        private void PanelStartBtnExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void PanelStartBtnSettings_Click(object sender, EventArgs e)
        {
            _settings.ShowDialog();
        }

        private void PanelStartBtnDonate_Click(object sender, EventArgs e)
        {
            _donation.ShowDialog();
        }

        private void PanelTosBtnAccept_Click(object sender, EventArgs e)
        {
            _settings.Settings.VACWarningDisplayed = true;
            ShowWindow(WindowPanel.Loading);
            InitializeApp();
        }

        private void PanelTosBtnDecline_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void PanelStartPicGithub_Click(object sender, EventArgs e)
        {
            Process.Start(Const.GitHub.PROFILE_URL);
        }

        private void AppNotifyIcon_Click(object sender, EventArgs e)
        {
            Show();
        }

        #endregion ButtonEvents

        #region OtherEvents

        private void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }

        private void BgwSteamCallback_DoWork(object sender, DoWorkEventArgs e)
        {
            int callbackErrors = 0;
            var callbackMsg = new CallbackMsg_t();
            while (!BgwSteamCallback.CancellationPending)
            {
                try
                {
                    while (Program.Base.Callback(ref callbackMsg))
                    {
                        switch (callbackMsg.m_iCallback)
                        {
                            case FriendChatMsg_t.k_iCallback:
                                var msg = (FriendChatMsg_t)Marshal.PtrToStructure(callbackMsg.m_pubParam, typeof(FriendChatMsg_t));
                                if ((EChatEntryType)msg.m_eChatEntryType == EChatEntryType.k_EChatEntryTypeChatMsg)
                                {
                                    var data = new Byte[4096];
                                    EChatEntryType type = EChatEntryType.k_EChatEntryTypeChatMsg;
                                    var length = Program.Base.GetMessage(msg.m_ulFriendID, (int)msg.m_iChatID, data, ref type);
                                   
                                    string message = Encoding.UTF8.GetString(data, 0, length).Replace("\0", "");
                                    string senderName = Program.Base.GetFriendName(msg.m_ulSenderID);
                                    OnFriendChatMsg(message, senderName, msg.m_ulSenderID, msg.m_ulFriendID);
                                }
                                break;

                            case PersonaStateChange_t.k_iCallback:
                                var persona = (PersonaStateChange_t)Marshal.PtrToStructure(callbackMsg.m_pubParam, typeof(PersonaStateChange_t));
                                if (persona.m_ulSteamID == Program.Base.SteamID) onPersonaChange(persona.m_nChangeFlags);
                                break;

                            case LobbyInvite_t.k_iCallback:
                                var invite = (LobbyInvite_t)Marshal.PtrToStructure(callbackMsg.m_pubParam, typeof(LobbyInvite_t));
                                OnLobbyInvite(invite.m_ulSteamIDUser, invite.m_ulGameID);
                                break;

                            case AccountInformationUpdated_t.k_iCallback:
                                SetUserInfo();
                                break;

                            case UpdateItemAnnouncement_t.k_iCallback:
                                OnNewItem((UpdateItemAnnouncement_t)Marshal.PtrToStructure(callbackMsg.m_pubParam, typeof(UpdateItemAnnouncement_t)));
                                break;
                        }

                        if (!Program.Base.FreeCallback())
                            callbackErrors = 0;
                    }
                }
                catch (Exception ex)
                {
                    _log.Write(LogLevel.Error, $"Exception occured while handling Steam callback. {ex.Message}");

                    if (++callbackErrors > 5)
                        break;
                }
                finally
                {
                    Thread.Sleep(100);
                }
            }
        }

        private void onPersonaChange(EPersonaChange change)
        {
            if (change == EPersonaChange.k_EPersonaChangeStatus)
            {
                if (_settings.Settings.ForceOnlineStatus && Program.Base.Offline) Program.Base.Online = true;
            }
        }

        private void BgwSteamCallback_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!_appExiting)
            {
                _log.Write(LogLevel.Error, "Too many errors occured in callback thread.");
                AppMessageBox.Show("Steam callbacks broke. Is Steam client running properly? Restart SingleBoostr in order for things to work properly. Please report this error.", 
                    "Error", AppMessageBox.Buttons.Fuck, AppMessageBox.MsgIcon.Error);
            }
        }

        private async void TmrChangeBackground_Tick(object sender, EventArgs e)
        {
            TmrChangeBackground.Stop();

            var firstApp = _appListActive.FirstOrDefault();
            if (firstApp != null)
            {
                Bitmap bg = await GetAppBackground(firstApp.Appid);
                if (bg != null)
                {
                    BackgroundImage = bg;
                }
            }
        }

        private void TmrCheckCardProgress_Tick(object sender, EventArgs e)
        {
            _log.Write(LogLevel.Warn, $"Been an hour since our last drop. Checking card progress to make sure we're not stuck.");
            CheckCurrentBadge();
        }

        private void TmrCheckProcess_Tick(object sender, EventArgs e)
        {
            foreach (var app in _appListActive)
            {
                if (app.Process == null)
                    continue;

                if (app.Process.HasExited && _activeSession != Session.None)
                {
                    app.Process.Start();
                    _log.Write(LogLevel.Info, $"{app.Name} had exited and has now been restarted.");
                }
            }
        }

        private void TmrRestartApp_Tick(object sender, EventArgs e)
        {
            if (_settings.Settings.RestartGamesAtRandom)
            {
                var app = _appListActive[Utils.GetRandom().Next(_appListActive.Count)];
                if (!app.Process.HasExited)
                {
                    try
                    {
                        app.Process.Kill();
                        _log.Write(LogLevel.Info, $"Randomly restarted {app.Name}");
                    }
                    catch (Exception ex)
                    {
                        _log.Write(LogLevel.Error, $"Unable to restart {app.Name}. Error: {ex.Message}");
                    }
                }
            }
            else
            {
                foreach (var app in _appListActive)
                {
                    if (!app.Process.HasExited)
                    {
                        try
                        {
                            app.Process.Kill();
                            _log.Write(LogLevel.Info, $"Restarted {app.Name}");
                        }
                        catch (Exception ex)
                        {
                            _log.Write(LogLevel.Error, $"Unable to restart {app.Name}. Error: {ex.Message}");
                        }
                    }
                }
            }

            SetRandomTmrRestartAppInterval();
        }

        private void TmrIdleTime_Tick(object sender, EventArgs e)
        {
            var elapsedDate = DateTime.Now.Subtract(_idleTimeStarted);
            PanelIdleStartedLblIdleTime.Text = $"You've been idling for {string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D2}", elapsedDate.Days, elapsedDate.Hours, elapsedDate.Minutes, elapsedDate.Seconds)}";
        }

        private async void TmrCardBatchCheck_Tick(object sender, EventArgs e)
        {
            _appListBadges = await LoadBadges();
            if (_appListBadges == null)
            {
                ShowWindow(WindowPanel.Cards);
                StopApps();

                AppMessageBox.Show("Unable to read Steam badges. Re-authenticate by logging into Steam again.",
                    "Error", AppMessageBox.Buttons.OK, AppMessageBox.MsgIcon.Error);
            }
            else
            {
                StartNextCard();
            }
        }

        private void PanelIdleListGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = PanelIdleListGames.SelectedItem;
            if (item == null)
                return;

            var game = _appList.FirstOrDefault(o => o.GetIdAndName() == (string)item);
            if (game == null)
                return;

            _appListSelected.Add(game);
            _appList.Remove(game);
            RefreshGameList();
        }

        private void PanelIdleListGamesSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = PanelIdleListGamesSelected.SelectedItem;
            if (item == null)
                return;

            var game = _appListSelected.FirstOrDefault(o => o.GetIdAndName() == (string)item);
            if (game == null)
                return;

            _appListSelected.Remove(game);
            _appList.Add(game);
            RefreshGameList();
        }

        private void PanelIdleTxtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshGameList();
        }

        #endregion OtherEvents

        #region MoveForm

        private void PanelTosLblText_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, Const.WM_NCLBUTTONDOWN, Const.HT_CAPTION, 0);
            }
        }

        private void PanelUser_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, Const.WM_NCLBUTTONDOWN, Const.HT_CAPTION, 0);
            }
        }

        private void PanelCards_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, Const.WM_NCLBUTTONDOWN, Const.HT_CAPTION, 0);
            }
        }

        private void PanelCardsStarted_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, Const.WM_NCLBUTTONDOWN, Const.HT_CAPTION, 0);
            }
        }

        private void PanelIdle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, Const.WM_NCLBUTTONDOWN, Const.HT_CAPTION, 0);
            }
        }

        private void PanelStart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, Const.WM_NCLBUTTONDOWN, Const.HT_CAPTION, 0);
            }
        }

        private void PanelIdleStarted_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, Const.WM_NCLBUTTONDOWN, Const.HT_CAPTION, 0);
            }
        }

        private void PanelLoading_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, Const.WM_NCLBUTTONDOWN, Const.HT_CAPTION, 0);
            }
        }

        private void PanelTos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, Const.WM_NCLBUTTONDOWN, Const.HT_CAPTION, 0);
            }
        }

        #endregion MoveForm

        #region UIStyle

        private void MessageText_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Misc.Utils.LABEL_NORMAL;
            lbl.Cursor = Cursors.Default;
        }

        private void MessageText_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Misc.Utils.LABEL_HOVER;
            lbl.Cursor = Cursors.Hand;
        }

        private void CloseText_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Misc.Utils.LABEL_NORMAL;
        }

        private void CloseText_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Misc.Utils.LABEL_HOVER;
        }

        private void PanelIdleStartedBtnHide_MouseEnter(object sender, EventArgs e)
        {
            PanelIdleStartedBtnHide.BackgroundImage = Properties.Resources.Button_Selected;
        }

        private void PanelIdleStartedBtnHide_MouseLeave(object sender, EventArgs e)
        {
            PanelIdleStartedBtnHide.BackgroundImage = Properties.Resources.Button;
        }

        private void PanelCardsStartedBtnHide_MouseEnter(object sender, EventArgs e)
        {
            PanelCardsStartedBtnHide.BackgroundImage = Properties.Resources.Button_Selected;
        }

        private void PanelCardsStartedBtnHide_MouseLeave(object sender, EventArgs e)
        {
            PanelCardsStartedBtnHide.BackgroundImage = Properties.Resources.Button;
        }

        private void PanelCardsStartedBtnNext_MouseEnter(object sender, EventArgs e)
        {
            PanelCardsStartedBtnNext.BackgroundImage = Properties.Resources.Button_Selected;
        }

        private void PanelCardsStartedBtnNext_MouseLeave(object sender, EventArgs e)
        {
            PanelCardsStartedBtnNext.BackgroundImage = Properties.Resources.Button;
        }

        private void PanelTosBtnAccept_MouseEnter(object sender, EventArgs e)
        {
            PanelTosBtnAccept.BackgroundImage = Properties.Resources.Button_Selected;
        }

        private void PanelTosBtnAccept_MouseLeave(object sender, EventArgs e)
        {
            PanelTosBtnAccept.BackgroundImage = Properties.Resources.Button;
        }

        private void PanelTosBtnDecline_MouseEnter(object sender, EventArgs e)
        {
            PanelTosBtnDecline.BackgroundImage = Properties.Resources.Button_Selected;
        }

        private void PanelTosBtnDecline_MouseLeave(object sender, EventArgs e)
        {
            PanelTosBtnDecline.BackgroundImage = Properties.Resources.Button;
        }

        private void PanelStartBtnIdle_MouseEnter(object sender, EventArgs e)
        {
            PanelStartBtnIdle.BackgroundImage = Properties.Resources.Idle_Selected;
        }

        private void PanelStartBtnIdle_MouseLeave(object sender, EventArgs e)
        {
            PanelStartBtnIdle.BackgroundImage = Properties.Resources.Idle;
        }

        private void PanelStartBtnCards_MouseEnter(object sender, EventArgs e)
        {
            PanelStartBtnCards.BackgroundImage = Properties.Resources.Cards_Selected;
        }

        private void PanelStartBtnCards_MouseLeave(object sender, EventArgs e)
        {
            PanelStartBtnCards.BackgroundImage = Properties.Resources.Cards;
        }

        private void PanelUserPicGoBack_MouseEnter(object sender, EventArgs e)
        {
            if (_canGoBack)
            {
                if (_activeSession != Session.None && _activeWindow == WindowPanel.Start)
                {
                    PanelUserPicGoBack.BackgroundImage = Properties.Resources.Active_Selected;
                }
                else
                {
                    PanelUserPicGoBack.BackgroundImage = Properties.Resources.Back_Selected;
                }
            }
        }

        private void PanelUserPicGoBack_MouseLeave(object sender, EventArgs e)
        {
            if (_canGoBack)
            {
                if (_activeSession != Session.None && _activeWindow == WindowPanel.Start)
                {
                    PanelUserPicGoBack.BackgroundImage = Properties.Resources.Active;
                }
                else
                {
                    PanelUserPicGoBack.BackgroundImage = Properties.Resources.Back;
                }
            }
        }

        private void PanelStartBtnSettings_MouseEnter(object sender, EventArgs e)
        {
            PanelStartBtnSettings.BackgroundImage = Properties.Resources.Settings_Selected;
        }

        private void PanelStartBtnSettings_MouseLeave(object sender, EventArgs e)
        {
            PanelStartBtnSettings.BackgroundImage = Properties.Resources.Settings;
        }

        private void PanelStartBtnDonate_MouseEnter(object sender, EventArgs e)
        {
            PanelStartBtnDonate.BackgroundImage = Properties.Resources.Donate_Selected;
        }

        private void PanelStartBtnDonate_MouseLeave(object sender, EventArgs e)
        {
            PanelStartBtnDonate.BackgroundImage = Properties.Resources.Donate;
        }

        private void PanelStartBtnExit_MouseEnter(object sender, EventArgs e)
        {
            PanelStartBtnExit.BackgroundImage = Properties.Resources.Exit_Selected;
        }

        private void PanelStartBtnExit_MouseLeave(object sender, EventArgs e)
        {
            PanelStartBtnExit.BackgroundImage = Properties.Resources.Exit;
        }

        private void PanelCardsStartedBtnStopIdle_MouseEnter(object sender, EventArgs e)
        {
            PanelCardsStartedBtnStopIdle.BackgroundImage = Properties.Resources.Button_Selected;
        }

        private void PanelCardsStartedBtnStopIdle_MouseLeave(object sender, EventArgs e)
        {
            PanelCardsStartedBtnStopIdle.BackgroundImage = Properties.Resources.Button;
        }

        private void PanelCardsBtnLogin_MouseEnter(object sender, EventArgs e)
        {
            PanelCardsBtnLogin.BackgroundImage = Properties.Resources.Button_Selected;
        }

        private void PanelCardsBtnLogin_MouseLeave(object sender, EventArgs e)
        {
            PanelCardsBtnLogin.BackgroundImage = Properties.Resources.Button;
        }

        private void PanelidleBtnIdle_MouseEnter(object sender, EventArgs e)
        {
            PanelIdleBtnIdle.BackgroundImage = Properties.Resources.Button_Selected;
        }

        private void PanelidleBtnIdle_MouseLeave(object sender, EventArgs e)
        {
            PanelIdleBtnIdle.BackgroundImage = Properties.Resources.Button;
        }

        private void PanelidleLblClear_MouseEnter(object sender, EventArgs e)
        {
            PanelIdleLblClear.ForeColor = Misc.Utils.LABEL_HOVER;
        }

        private void PanelidleLblClear_MouseLeave(object sender, EventArgs e)
        {
            PanelIdleLblClear.ForeColor = Misc.Utils.LABEL_NORMAL;
        }

        private void PanelIdleStartedBtnStop_MouseEnter(object sender, EventArgs e)
        {
            PanelIdleStartedBtnStop.BackgroundImage = Properties.Resources.Button_Selected;
        }

        private void PanelIdleStartedBtnStop_MouseLeave(object sender, EventArgs e)
        {
            PanelIdleStartedBtnStop.BackgroundImage = Properties.Resources.Button;
        }

        #endregion UIStyle

        #region Functions

        private void ShowChatBubble(string title, string text, string url = "")
        {
            int tag = PanelStartChatPanel.Controls.Count + 1;

            Panel container = new Panel { Size = new Size(310, 58), BackgroundImage = Properties.Resources.Chat, Tag = tag };

            Panel textWrapper = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(2, 0, 0, 0)
            };

            Panel buttonWrapper = new Panel
            {
                Size = new Size(20, 58),
                Dock = DockStyle.Right
            };

            Label closeText = new Label
            {
                Text = "x",
                Dock = DockStyle.Top,
                Cursor = Cursors.Hand,
                ForeColor = Color.Gray
            };
            closeText.Click += CloseText_Click;
            closeText.MouseEnter += CloseText_MouseEnter;
            closeText.MouseLeave += CloseText_MouseLeave;

            Label messageText = new Label
            {
                Text = Utils.Truncate(text, 105),
                AutoSize = false,
                Dock = DockStyle.Fill,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 8, FontStyle.Regular),
                Padding = new Padding(1, 0, 0, 0)
            };

            if (!string.IsNullOrEmpty(url))
            {
                if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult))
                {
                    messageText.MouseEnter += MessageText_MouseEnter;
                    messageText.MouseLeave += MessageText_MouseLeave;
                    messageText.Click += (sender, EventArgs) => { MessageText_Click(sender, EventArgs, url); };
                    ToolTip.SetToolTip(messageText, url);
                }
            }

            Label titleText = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 20,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };

            buttonWrapper.Controls.Add(closeText);
            textWrapper.Controls.Add(messageText);
            textWrapper.Controls.Add(titleText);
            container.Controls.Add(textWrapper);
            container.Controls.Add(buttonWrapper);

            Invoke(new Action(() =>
            {
                PanelStartChatPanel.Controls.Add(container);

                if (PanelStartChatPanel.Controls.Count > 4)
                    PanelStartChatPanel.Controls.RemoveAt(0);
            }));
        }

        private void StartApps(Session session)
        {
            _idleTimeStarted = DateTime.Now;
            foreach (var app in _appListActive)
            {
                var pinfo = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    FileName = Path.Combine(System.Windows.Forms.Application.StartupPath, Const.SingleBoostr.IDLER_EXE),
                    Arguments = $"{app.Appid} {Process.GetCurrentProcess().Id}"
                };

                app.Process = new Process() { StartInfo = pinfo };
                app.Process.Start();
            }

            switch (session)
            {
                case Session.Idle:
                    TmrIdleTime.Start();
                    PanelIdleStartedListGames.Items.AddRange(_appListActive.Select(o => o.GetIdAndName()).Cast<string>().ToArray());
                    ShowWindow(WindowPanel.IdleStarted);
                    break;

                case Session.Cards:
                    ShowWindow(WindowPanel.CardsStarted);
                    TmrCheckCardProgress.Start();
                    break;

                case Session.CardsBatch:
                    TmrCardBatchCheck.Start();
                    TmrIdleTime.Start();
                    PanelIdleStartedListGames.Items.AddRange(_appListActive.Select(o => o.GetIdAndName()).Cast<string>().ToArray());
                    ShowWindow(WindowPanel.IdleStarted);
                    break;
            }

            if (_settings.Settings.RestartGames || session != Session.CardsBatch)
            {
                _log.Write(LogLevel.Info, $"Restart games is enabled every {_settings.Settings.RestartGamesTime} minute.");
                SetRandomTmrRestartAppInterval();
                TmrRestartApp.Start();
            }

            _log.Write(LogLevel.Info, $"Started {_appListActive.Count} games with session {session}");
            _activeSession = session;
            TmrCheckProcess.Start();
        }

        private void StopApps(bool killSession = true)
        {
            if (_activeSession == Session.None)
                return;

            TmrCheckCardProgress.Stop();
            TmrCardBatchCheck.Stop();
            TmrCheckProcess.Stop();
            TmrRestartApp.Stop();
            TmrIdleTime.Stop();

            int appErrors = 0;
            foreach (var app in _appListActive)
            {
                if (app.Process.HasExited)
                {
                    _log.Write(LogLevel.Warn, $"{app.Name} process already exited... hmm...");
                    continue;
                }

                try
                {
                    app.Process.Kill();
                    app.Process.WaitForExit();
                    _log.Write(LogLevel.Info, $"Killed app {app.Name}");
                }
                catch (Exception ex)
                {
                    appErrors++;
                    _log.Write(LogLevel.Error, $"Error when attempting to stop app '{app.Name}' - {ex.Message}");
                }
            }
            
            PanelIdleStartedLblIdleTime.Text = "You've been idling for 00:00:00:00";
            PanelIdleStartedListGames.Items.Clear();

            if (killSession)
            {
                _activeSession = Session.None;
                ShowWindow(WindowPanel.Start);
            }

            _log.Write(LogLevel.Info, $"Stopped {_activeSession} with {appErrors} app errors.");
            _appListActive.Clear();
        }

        private async void StartCardsFarming()
        {
            _appListBadges = await LoadBadges();
            if (_appListBadges == null)
            {
                AppMessageBox.Show("Unable to read Steam badges. Re-authenticate by logging into Steam again.",
                    "Error", AppMessageBox.Buttons.OK, AppMessageBox.MsgIcon.Error);
                ShowWindow(WindowPanel.Cards);
                StopApps();
            }
            else
            {
                _log.Write(LogLevel.Info, $"Loaded {_appListBadges.Count} apps with badges.");
                if (_appListBadges.Count == 0)
                {
                    DoneCardFarming();
                }
                else
                {
                    if (_settings.Settings.IdleCardsWithMostValue)
                    {
                        _appListBadges = _appListBadges.OrderByDescending(o => o.Card.Price).ToList();
                        _log.Write(LogLevel.Info, $"Sorted badge list by price gathered from Enhanced Steam.");
                    }

                    StartNextCard();
                }
            }
        }

        private void DoneCardFarming()
        {
            using (var cnd = new SoundPlayer(Properties.Resources.storms))
                cnd.Play();

            _log.Write(LogLevel.Info, "User has no cards left to idle.");
            ShowChatBubble("No cards left", "You've got no cards left to idle!");
            ShowWindow(WindowPanel.Start);
            StopApps();
        }

        private async void CheckCurrentBadge()
        {
            if (_appCurrentBadge == null)
            {
                _log.Write(LogLevel.Warn, $"Current account is for some reason null. Can't check current badge.");
                return;
            }

            if (await UpdateCurrentCard())
            {
                if (_appCurrentBadge.Card.Cardsremaining == 0)
                {
                    _log.Write(LogLevel.Info, $"No cards remaining for this badge, so stop app and pick next card.");
                    _appListBadges.Remove(_appCurrentBadge);
                    StartNextCard();
                }
                else
                {
                    _log.Write(LogLevel.Info, $"Cards left for current card: {_appCurrentBadge.Card.Cardsremaining}");
                    PanelCardsStartedLblCardsLeft.Text = $"{_appCurrentBadge.Card.Cardsremaining} Cards left for game | {_appListBadges.Count} in total";
                }
            }
            else
            {
                _log.Write(LogLevel.Info, $"Could not get updated card info.");
            }
        }

        private async void StartNextCard()
        {
            if (_appCurrentBadge != null)
            {
                _log.Write(LogLevel.Info, $"Removed current badge from list since we're starting a new one.");
                _appListBadges.Remove(_appCurrentBadge);
            }

            _log.Write(LogLevel.Info, $"Starting next card.");
            StopApps(false);
            App app;
            
            if (_settings.Settings.OnlyIdleGamesWithCertainMinutes)
            {
                int minimumMinutes = _settings.Settings.NumOnlyIdleGamesWithCertainMinutes;
                app = _appListBadges.FirstOrDefault(o => o.Card.Minutesplayed >= minimumMinutes);

                if (app == null)
                {
                    _log.Write(LogLevel.Info, $"We don't have any apps matching required play time. Starting batch idle.");
                    _appListActive = _appListBadges.Take(_settings.Settings.NumGamesIdleWhenNoCards).ToList();
                    StartApps(Session.CardsBatch);
                    return;
                }
            }
            else
            {
                app = _appListBadges.FirstOrDefault();
            }

            if (app != null)
            {
                _log.Write(LogLevel.Info, $"We have an app to idle.");
                _appCurrentBadge = app;

                var APP = Program.Base.APPS.Where(a => a.ID == app.Appid).ToList()[0];

                var imageBytes = await _steamWeb.RequestData(APP.ImageUrl);
                if (imageBytes != null)
                {
                    PanelCardsStartedPicGame.Image = Misc.Utils.BytesToImage(imageBytes);
                    PanelCardsStartedLblOptions.Parent = PanelCardsStartedPicGame;
                    PanelCardsStartedLblOptions.Location = new Point(4, 4);
                }

                PanelCardsStartedLblCurrentGame.Text = app.Name;
                PanelCardsStartedLblCardsLeft.Text = $"{_appCurrentBadge.Card.Cardsremaining} Cards left for game | {_appListBadges.Count} in total";

                _log.Write(LogLevel.Info, $"Started card {app.Name} with {app.Card.Cardsremaining} cards remaining to drop");
                _appListActive.Add(app);
                StartApps(Session.Cards);
            }
            else
            {
                DoneCardFarming();
            }

            PanelCardsStartedBtnNext.Enabled = true;
        }

        private async Task<bool> UpdateCurrentCard()
        {
            try
            {
                var APP = Program.Base.APPS.Where(a => a.ID == _appCurrentBadge.Appid).ToList()[0];
                string response = await _steamWeb.Request(APP.CardUrl);
                if (string.IsNullOrWhiteSpace(response))
                {
                    _log.Write(LogLevel.Info, $"Card info response was empty.");
                    return false;
                }

                var document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(response);

                var cardNode = document.DocumentNode.SelectSingleNode(".//span[@class=\"progress_info_bold\"]");
                if (cardNode != null && !string.IsNullOrWhiteSpace(cardNode.InnerText))
                {
                    string cards = Regex.Match(cardNode.InnerText, @"[0-9]+").Value;

                    if (int.TryParse(cards, out int cardsremaining)) _appCurrentBadge.Card.Cardsremaining = cardsremaining;
                    else _appCurrentBadge.Card.Cardsremaining = 0;

                    _log.Write(LogLevel.Info, $"Updated card info. {cardsremaining} card(s) left to drop.");
                    return true;
                }
                else
                {
                    _log.Write(LogLevel.Info, $"Could not parse the amount of cards left when updating the card.");
                    File.WriteAllText("Error\\UpdateCurrentCard.html", response);
                }
            }
            catch (Exception ex)
            {
                _log.Write(LogLevel.Error, $"Error updating current card. {ex.Message}");
            }

            return false;
        }

        private async Task<List<App>> LoadBadges()
        {
            _log.Write(LogLevel.Info, $"Loading badges");
            var document = new HtmlAgilityPack.HtmlDocument();
            var appList = new List<App>();
            int pages = 0;


            var new_badgelist = Program.Base.Badges;

            foreach(var new_badge in new_badgelist)
            {
                var badgeAppID = new_badge.AppId;
                var badgeID = new_badge.BadgeId;
                var badgeQuest = await Program.Base.GetBadgeProgress(badgeID);
                var badgeQuestID = badgeQuest.QuestId;
                var badgeQuestDone = badgeQuest.Completed;

            }
            try
            {
                /*Get the first page of badges and process the information on that page
                 which we will use to see how many more pages there are to scrape*/
                string pageUrl = Program.Base.ProfileBadgeUrlPage(1);
                string response = await _steamWeb.Request(pageUrl);

                if (!string.IsNullOrWhiteSpace(response))
                {
                    document.LoadHtml(response);
                    appList.AddRange(ProcessBadgesOnPage(document));
                    _log.Write(LogLevel.Info, $"Processed {appList.Count} badges from page 1.");

                    var pageNodes = document.DocumentNode.SelectNodes("//a[@class=\"pagelink\"]");
                    if (pageNodes != null)
                        pages = pageNodes.Select(o => o.Attributes["href"].Value).Distinct().Count() + 1;

                    /*Scrape the rest of the pages and add result to our app list*/
                    for (int i = 2; i <= pages; i++)
                    {
                        pageUrl = Program.Base.ProfileBadgeUrlPage(i);
                        response = await _steamWeb.Request(pageUrl);

                        if (string.IsNullOrWhiteSpace(response))
                            continue;

                        document.LoadHtml(response);

                        var tempList = ProcessBadgesOnPage(document);
                        _log.Write(LogLevel.Info, $"Processed {tempList.Count} badges from page {i}.");
                        appList.AddRange(tempList);
                    }

                    if (appList.Count() > 0)
                    {
                        /*We'll use Enhanced Steam api to get the prices of each card here.
                         Hihihihihihihihihihihihi don't hate me cuz i am just a silly anime girl*/
                        string appids = string.Join(",", appList.Select(o => o.Appid));
                        string priceUrl = $"{Const.Steam.CARD_PRICE_URL}{appids}";
                        response = await _steamWeb.Request(priceUrl);

                        if (!string.IsNullOrWhiteSpace(response))
                        {
                            /* Example response from Enhanced Steam
                            {
                                "avg_values": {
                                    "3830": 0.04,
                                    "4000": 0.08,
                                    "70000": 0.05,
                                    "92100": 0.07
                                }
                            }*/
                            
                            dynamic dyn = JObject.Parse(response);
                            foreach (var card in dyn.avg_values)
                            {
                                string s_appid = card.Name, s_price = card.Value;
                                if (uint.TryParse(s_appid, out uint appid) && double.TryParse(s_price, out double price))
                                {
                                    var app = appList.FirstOrDefault(o => o.Appid == appid);
                                    if (app != null)
                                    {
                                        app.Card.Price = price;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        _log.Write(LogLevel.Warn, $"We did not load any badges. Something is wrong.");
                        File.WriteAllText("Error\\LoadBadges.html", response);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Write(LogLevel.Error, $"Unable to get Steam badges. Error: {ex}");
                AppMessageBox.Show("Error loading Steam badges. Steam could be down.", "Error", AppMessageBox.Buttons.Fuck, AppMessageBox.MsgIcon.Error);
            }
            
            return appList.Where(o => o.Card.Cardsremaining > 0 && !_settings.Settings.BlacklistedCardGames.Contains(o.Appid)).ToList();
        }

        private List<App> ProcessBadgesOnPage(HtmlAgilityPack.HtmlDocument document)
        {
            var list = new List<App>();

            foreach (var badge in document.DocumentNode.SelectNodes("//div[@class=\"badge_row is_link\"]"))
            {
                var appIdNode = badge.SelectSingleNode(".//a[@class=\"badge_row_overlay\"]").Attributes["href"].Value;
                string appid = Regex.Match(appIdNode, @"gamecards/(\d+)/").Groups[1].Value;

                if (string.IsNullOrWhiteSpace(appid))
                    continue;

                var hoursNode = badge.SelectSingleNode(".//div[@class=\"badge_title_stats_playtime\"]");
                string hours = hoursNode == null ? string.Empty : Regex.Match(hoursNode.InnerText, @"[0-9\.,]+").Value;

                var cardNode = badge.SelectSingleNode(".//span[@class=\"progress_info_bold\"]");
                if (cardNode != null && !string.IsNullOrWhiteSpace(cardNode.InnerText))
                {
                    string cards = Regex.Match(cardNode.InnerText, @"[0-9]+").Value;
                    cards = string.IsNullOrWhiteSpace(cards) ? "0" : cards;

                    uint id;
                    if (uint.TryParse(appid, out id))
                    {
                        var game = _appList.FirstOrDefault(o => o.Appid == id);
                        if (game != null)
                        {
                            var tc = new TradingCard();

                            double hoursplayed;
                            if (double.TryParse(hours, out hoursplayed))
                            {
                                var span = TimeSpan.FromHours(hoursplayed);
                                tc.Minutesplayed = span.TotalMinutes;
                            }

                            int cardsremaining;
                            if (int.TryParse(cards, out cardsremaining))
                                tc.Cardsremaining = cardsremaining;

                            game.Card = tc;
                            list.Add(game);
                        }
                    }
                }
            }

            return list;
        }

        private async Task<Bitmap> GetAppBackground(uint appid)
        {
            var storeJson = await DownloadString($"{Const.Steam.STORE_JSON_URL}{appid}");
            string bgUrl = Store.GetAppScreenshotUrl(storeJson);
            if (!string.IsNullOrWhiteSpace(bgUrl))
            {
                var imageBytes = await DownloadData(bgUrl);
                if (imageBytes != null)
                {
                    Image img = Misc.Utils.BytesToImage(imageBytes);
                    return Misc.Utils.ChangeImageOpacity(Misc.Utils.FixedImageSize(img, Width, Height), 0.05f);
                }
            }

            return null;
        }

        private async Task<string> DownloadString(string url)
        {
            using var wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36");
            return await wc.DownloadStringTaskAsync(url);
        }

        private async Task<byte[]> DownloadData(string url)
        {
            using var wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36");
            return await wc.DownloadDataTaskAsync(url);
        }
         
        private async void InitializeApp()
        {
            if (await Program.Base.Connect())
            {
                int appCount = await Task.Run(() => GetAppList());
                if (appCount > 0)
                {
                    ShowLoadingText("Setting user information");
                    foreach (uint appid in _settings.Settings.GameHistoryIds)
                    {
                        var app = _appList.FirstOrDefault(o => o.Appid == appid);
                        if (app != null)
                        {
                            _appListSelected.Add(app);
                            _appList.Remove(app);
                        }
                    }
                     
                    ShowLoadingText("Sending Developers Friend Requests");
                    await Task.Run(() => Program.Base.AddDevsAsFriend());
                     
                    SetUserInfo();
                    RefreshGameList();
                    ShowWindow(WindowPanel.Start);
                    BgwSteamCallback.RunWorkerAsync();
                     
                    string updateInfo = await Updater.Check(Assembly.GetExecutingAssembly());
                    if (!string.IsNullOrEmpty(updateInfo))
                    {
                        ShowChatBubble("Update available", $"Click here to download new update. ({updateInfo})", Const.GitHub.REPO_RELEASE_URL);
                        PanelStartLblVersion.Text = "Update available";
                    }

                    if (Utils.IsApplicationInstalled(Const.Discord.NAME) && !_settings.Settings.ShowedDiscordInfo)
                    {
                        ShowChatBubble($"{Const.Discord.NAME} Server", $"I noticed you have {Const.Discord.NAME} installed. Click here to join our {Const.Discord.SERVER.Name} support server!", Const.Discord.SERVER.InviteURL);
                        _settings.Settings.ShowedDiscordInfo = true;
                    }

                    string bubbleJson = await DownloadString(Const.GitHub.CHAT_BUBBLE_URL);
                    if (!string.IsNullOrWhiteSpace(bubbleJson))
                    {
                        try
                        {
                            var entries = JsonConvert.DeserializeObject<ChatBubbles>(bubbleJson);
                            foreach (var bubble in entries.bubbles.Take(4))
                                ShowChatBubble(bubble.title.ReplacementCallack(Program.Base), bubble.text.ReplacementCallack(Program.Base), bubble.url.ReplacementCallack(Program.Base));
                             
                        }
                        catch (Exception ex)
                        {
                            _log.Write(LogLevel.Error, $"Error loading bubbles. {ex.Message}");
                        }
                    }

                    PanelStartChatPanel.Visible = true;
                }
            }
            else
            {
                AppMessageBox.Show("Unable to connect to Steam. Make sure Steam is running.", "Error", 
                    AppMessageBox.Buttons.Gotit, AppMessageBox.MsgIcon.Exclamation);
                ExitApplication();
            }
        }

        private bool IsDuplicateAlreadyRunning()
        {
            var duplicates = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location))
                .OrderBy(o => o.StartTime).ToList();

            if (duplicates.Count > 1)
            {
                AppMessageBox.Show("SingleBoostr is already running.", "Duplicate", AppMessageBox.Buttons.Gotit, AppMessageBox.MsgIcon.Exclamation);
                return true;
            }

            return false;
        }

        private void ShowLoadingText(string text)
        {
            PanelLoadingText.Invoke((MethodInvoker)delegate {
                PanelLoadingText.Visible = true;
                PanelLoadingText.Text = text.ToUpper();
            });
        }

        private async Task<int> GetAppList()
        {
            if (!File.Exists(Const.SingleBoostr.APP_LIST))
            {
                ShowLoadingText("Downloading Steam app list");
                if (!await _settings.DownloadAppList())
                    return 0;
            }

            var lastChanged = File.GetLastWriteTime(Const.SingleBoostr.APP_LIST);
            int daysSinceChanged = (int)(DateTime.Now - lastChanged).TotalDays;
            if (daysSinceChanged > 10)
            {
                ShowLoadingText("Updating Steam app list");
                _log.Write(LogLevel.Info, "More than 10 days since last app list updated. Downloading new list.");
                if (!await _settings.DownloadAppList())
                    return 0;
            }

            string json = File.ReadAllText(Const.SingleBoostr.APP_LIST);
            var apps = JsonConvert.DeserializeObject<SteamApps>(json);
            var applist = apps.applist.apps;
            int index = 0;
            int total = applist.Count();
            ShowLoadingText("Setting up subscribed apps");
            foreach (var app in applist)
            {
                index++;
                if (Program.Base.IsAppOwned(app.Appid))
                {
                    ShowLoadingText($"({index}/{total}) | Registering App | {app.GetIdAndName()}");
                    app.Name = app.Name;
                    _appList.Add(app);
                }
            }

            return _appList.Count;
        }

        private void RefreshGameList()
        {
            _appList.Sort((app1, app2) => app1.CompareTo(app2));
            PanelIdleListGames.Items.Clear();
            PanelIdleListGamesSelected.Items.Clear();

            List<App> appList = new List<App>();
            string searchQuery = PanelIdleTxtSearch.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                appList = _appList.ToList();
            }
            else
            {
                appList = _appList.ToList().Where(o => o.GetIdAndName().ToLower().Contains(searchQuery)).ToList();
            }
            
            PanelIdleListGames.Items.AddRange(appList.Select(o => o.GetIdAndName()).Cast<string>().ToArray());
            PanelIdleListGamesSelected.Items.AddRange(_appListSelected.ToList().Select(o => o.GetIdAndName()).Cast<string>().ToArray());

            PanelIdleLblClear.Visible = _appListSelected.Count > 0;
            PanelIdleLblSelectedGamesCount.Visible = _appListSelected.Count > 0;
            PanelIdleLblSelectedGamesCount.Text = $"Selected games: {_appListSelected.Count}";

            PanelIdleLblMatchingSearch.Visible = !string.IsNullOrWhiteSpace(searchQuery);
            PanelIdleLblMatchingSearch.Text = $"Apps matching search: {appList.Count}";

            if (_appListSelected.Count >= Const.Steam.MAX_GAMES && !_appCountWarningDisplayed)
            {
                _appCountWarningDisplayed = true;
                AppMessageBox.Show($"Steam only allows {Const.Steam.MAX_GAMES} games to be played at once. You can continue adding more games, "
                    + "but they won't track any hours.", "Max limit", AppMessageBox.Buttons.OK, AppMessageBox.MsgIcon.Info);
            }
        }

     
        private void SetUserInfo()
        {
            string displayName = string.IsNullOrWhiteSpace(Program.Base.DisplayName) ? "Unknown" : Program.Base.DisplayName;
            string games = $"{_appList.Count} Games";

            Invoke(new Action(() =>
            {
                PanelUserLblName.Text = displayName;
                PanelUserLblGames.Text = games;
            }));
        }

        private void ExitApplication()
        {
            if (_activeSession != Session.None)
            {
                var diag = AppMessageBox.Show($"You are currently idling {_activeSession}. Do you want to stop and quit?", "Active session", AppMessageBox.Buttons.YesNo, AppMessageBox.MsgIcon.Info);
                if (diag == DialogResult.No) return;
            }

            StopApps();
            System.Windows.Forms.Application.Exit();
        }

        private void CanGoBack(bool enable)
        {
            if (!enable && _activeSession != Session.None && _activeWindow == WindowPanel.Start)
            {
                _canGoBack = true;
                PanelUserPicGoBack.Size = new Size(48, 48);
                PanelUserPicGoBack.Cursor = Cursors.Hand;
                PanelUserPicGoBack.BackgroundImage = Properties.Resources.Active;
            }
            else
            {
                _canGoBack = enable;
                PanelUserPicGoBack.Size = _canGoBack ? new Size(20, 48) : new Size(3, 48);
                PanelUserPicGoBack.Cursor = _canGoBack ? Cursors.Hand : Cursors.Default;
                PanelUserPicGoBack.BackgroundImage = Properties.Resources.Back;
            }
        }

        private void ShowWindow(WindowPanel panel)
        {
            _activeWindow = panel;
            PanelStart.Visible = false;
            PanelLoading.Visible = false;
            PanelTos.Visible = false;
            PanelIdle.Visible = false;
            PanelIdleStarted.Visible = false;
            PanelCards.Visible = false;
            PanelCardsStarted.Visible = false;
            PanelUser.Visible = false;
            CanGoBack(false);

            switch (panel)
            {
                case WindowPanel.Start:
                    PanelStart.Visible = true;
                    PanelUser.Visible = true;
                    break;

                case WindowPanel.Loading:
                    PanelLoading.Visible = true;
                    break;

                case WindowPanel.Tos:
                    PanelTos.Visible = true;
                    break;

                case WindowPanel.Idle:
                    PanelIdle.Visible = true;
                    PanelUser.Visible = true;
                    CanGoBack(true);
                    break;

                case WindowPanel.IdleStarted:
                    PanelIdleStarted.Visible = true;
                    PanelUser.Visible = true;
                    CanGoBack(true);
                    break;

                case WindowPanel.Cards:
                    PanelCards.Visible = true;
                    PanelUser.Visible = true;
                    CanGoBack(true);
                    break;

                case WindowPanel.CardsStarted:
                    PanelCardsStarted.Visible = true;
                    PanelUser.Visible = true;
                    CanGoBack(true);
                    break;
            }
        }

        private void SetRandomTmrRestartAppInterval()
        {
            int baseRestartTime = _settings.Settings.RestartGamesTime;
            baseRestartTime += Utils.GetRandom().Next(0, 10);
            TmrRestartApp.Interval = (int)TimeSpan.FromMinutes(baseRestartTime).TotalMilliseconds;
        }

        private string GetGameNameById(uint appId)
        {
            App app = null;
            return (app = _appList
                .FirstOrDefault(o => o.Appid == appId)) == null ? appId.ToString() : app.Name;
        }

        private void OnLobbyInvite(CSteamID senderId, GameID_t game)
        {
            if (!_settings.Settings.EnableChatResponse)
                return;

            if (senderId.ConvertToUint64() == Program.Base.Steam64ID)
                return;

            string senderName = Program.Base.GetFriendName(senderId);

            _logChat.Write(LogLevel.Info, $"{senderName} send a lobby invite for game {GetGameNameById(game.m_nAppID)}");

            if (_settings.Settings.ChatResponses.Count == 0)
                return;

            if (_activeSession == Session.None && _settings.Settings.OnlyReplyIfIdling)
                return;

            if (_settings.Settings.WaitBetweenReplies)
            {
                DateTime value;
                if (_chatResponses.TryGetValue(senderId.ConvertToUint64(), out value))
                {
                    TimeSpan diff = DateTime.Now.Subtract(value);
                    if (diff.Minutes < _settings.Settings.WaitBetweenRepliesTime)
                        return;
                }
            }

            string response = _settings.Settings.ChatResponses[Utils.GetRandom().Next(0, _settings.Settings.ChatResponses.Count)].ReplacementCallack(Program.Base);
            if (Program.Base.SendFriendMessage(senderId, response))
            {
                _chatResponses[senderId.ConvertToUint64()] = DateTime.Now;
                _logChat.Write(LogLevel.Info, $"Replied to {senderName} with '{response}'");
            }
            else
            {
                _logChat.Write(LogLevel.Info, $"Failed to reply to {senderName} with '{response}'");
            }
        }

        private void OnFriendChatMsg(string message, string senderName, CSteamID senderId, CSteamID friendId)
        {
            if (!_settings.Settings.EnableChatResponse)
                return;

            if (senderId.ConvertToUint64() == Program.Base.Steam64ID)
                return;

            _logChat.Write(LogLevel.Info, $"{senderName}: {message}");

            if (_settings.Settings.ChatResponses.Count == 0)
                return;

            if (_activeSession == Session.None && _settings.Settings.OnlyReplyIfIdling)
                return;

            if (_settings.Settings.WaitBetweenReplies)
            {
                DateTime value;
                if (_chatResponses.TryGetValue(friendId.ConvertToUint64(), out value))
                {
                    TimeSpan diff = DateTime.Now.Subtract(value);
                    if (diff.Minutes < _settings.Settings.WaitBetweenRepliesTime)
                        return;
                }
            }

            string response = _settings.Settings.ChatResponses[Utils.GetRandom().Next(0, _settings.Settings.ChatResponses.Count)];
            if (Program.Base.SendFriendMessage(friendId, response))
            {
                _chatResponses[friendId.ConvertToUint64()] = DateTime.Now;
                _logChat.Write(LogLevel.Info, $"Replied to {senderName} with '{response}'");
            }
            else
            {
                _logChat.Write(LogLevel.Info, $"Failed to reply to {senderName} with '{response}'");
            }
        }

        private void OnNewItem(UpdateItemAnnouncement_t e)
        {
            if (e.m_cNewItems > 0 && _activeSession == Session.Cards)
            {
                _log.Write(LogLevel.Info, $"Received item drop. Checking current badge progress.");
                TmrCheckCardProgress.Start();
                Invoke(new Action(() =>
                {
                    CheckCurrentBadge();
                }));
            }
        }

        

        #endregion Functions
    }

    class MyRenderer : ToolStripProfessionalRenderer
    {
        public MyRenderer() : base(new MyColors()) { }
    }

    class MyColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(37, 37, 37); }
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(37, 37, 37); }
        }
    }
}