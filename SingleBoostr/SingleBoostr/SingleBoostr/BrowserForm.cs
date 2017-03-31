using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace SingleBoostr
{
    public partial class BrowserForm : Form
    {
        public SessionInfo Session = new SessionInfo();

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
            Pen pen = new Pen(Const.LABEL_HOVER);
            e.Graphics.DrawRectangle(pen, rect);
        }

        public BrowserForm()
        {
            InitializeComponent();
        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {
            NativeMethods.InternetSetOption(0, 42, null, 0);
            NativeMethods.InternetSetCookie("http://steamcommunity.com", "sessionid", ";expires=Mon, 01 Jan 0001 00:00:00 GMT");
            NativeMethods.InternetSetCookie("http://steamcommunity.com", "steamLogin", ";expires=Mon, 01 Jan 0001 00:00:00 GMT");
            NativeMethods.InternetSetCookie("http://steamcommunity.com", "steamRememberLogin", ";expires=Mon, 01 Jan 0001 00:00:00 GMT");

            WebBrowser.Navigate("https://steamcommunity.com/login/home/?goto=my/profile", "_self", null, "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko");
        }

        private void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string url = e.Url.AbsoluteUri;
            if (url.Contains("github"))
            {
                Process.Start(Const.GITHUB_REPO_URL);
                e.Cancel = true;
            }
            else
            {
                WebBrowser.Visible = false;
            }
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string url = WebBrowser.Url.AbsoluteUri;

            if (url.Contains("steam"))
            {
                /*Remove more page content and inject the 'why join steam' section with some replacement html about the program
                 http://i.imgur.com/VXDCfFE.png see image to see exactly which elements are removed.*/
                foreach (HtmlElement element in WebBrowser.Document.GetElementsByTagName("html"))
                    element.SetAttribute("className", "");

                var header = WebBrowser.Document.GetElementById("global_header");
                if (header != null) header.OuterHtml = "";

                var footer = WebBrowser.Document.GetElementById("footer");
                if (footer != null) footer.OuterHtml = "";

                foreach (HtmlElement element in WebBrowser.Document.GetElementsByTagName("div"))
                {
                    string attr = element.GetAttribute("className");
                    if (attr == "whyJoinLeft" || attr == "whyJoinRight")
                    {
                        element.OuterHtml = "";
                    }
                    else if (attr == "mainLoginRightPanel")
                    {
                        element.InnerHtml =
                            "<div class=\"createInfo\">"
                                + "<h1>What is this?</h1>"
                                + "<p>SingleBoostr now does Trading Cards! But...</p>"
                                + "<p>You are required to login with Steam in order for SingleBoostr to detect which games still have cards remaining for "
                                + "drop. If you're worried about entering your Steam details, then don't be. This program is Open Source and won't harm "
                                + "your account. You are currently on the official Steam login page.</p>"
                                + "<p>Check out the source code at <a href=\"https://github.com/Ezzpify/HourBoostr\">GitHub</a>."
                            + "</div>";
                    }
                    else if (attr == "mainLoginPanel")
                    {
                        element.SetAttribute("className", "");
                        element.Style = "margin-left: 20px;";
                    }
                }
                
                WebBrowser.Visible = true;

                if (url == "https://steamcommunity.com/login/home/?goto=my/profile" || url == "https://store.steampowered.com/login/transfer" || url == "https://store.steampowered.com//login/transfer")
                {
                    CookieContainer container = GetUriCookieContainer(WebBrowser.Url);
                    var cookies = container.GetCookies(WebBrowser.Url);

                    foreach (Cookie cookie in cookies)
                    {
                        if (cookie.Name.StartsWith("steamMachineAuth"))
                            Session.SteamMachineAuth = cookie.Value;
                    }
                }
                else if (!url.StartsWith("javascript:") && !url.StartsWith("about:"))
                {
                    CookieCollection cookies = GetUriCookieContainer(WebBrowser.Url).GetCookies(WebBrowser.Url);

                    foreach (Cookie cookie in cookies)
                    {
                        switch (cookie.Name)
                        {
                            case "sessionid":
                                Session.SessionId = cookie.Value;
                                break;

                            case "steamLogin":
                                Session.SteamLogin = cookie.Value;
                                break;

                            case "steamparental":
                                Session.SteamParental = cookie.Value;
                                break;

                            case "steamRememberLogin":
                                Session.SteamRememberLogin = cookie.Value;
                                break;
                        }
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        public static CookieContainer GetUriCookieContainer(Uri uri)
        {
            CookieContainer cookies = null;

            var datasize = 8192 * 16;
            var cookieData = new StringBuilder(datasize);

            if (!NativeMethods.InternetGetCookieEx(uri.ToString(), null, cookieData, ref datasize, Const.INTERNET_COOKIE_HTTP_ONLY, IntPtr.Zero))
            {
                if (datasize < 0)
                    return null;

                cookieData = new StringBuilder(datasize);
                if (!NativeMethods.InternetGetCookieEx(uri.ToString(), null, cookieData, ref datasize, Const.INTERNET_COOKIE_HTTP_ONLY, IntPtr.Zero))
                    return null;
            }

            if (cookieData.Length > 0)
            {
                cookies = new CookieContainer();
                cookies.SetCookies(uri, cookieData.ToString().Replace(';', ','));
            }

            return cookies;
        }

        private void PanelUserPicGoBack_MouseEnter(object sender, EventArgs e)
        {
            PanelUserPicGoBack.BackgroundImage = Properties.Resources.Back_Selected;
        }

        private void PanelUserPicGoBack_MouseLeave(object sender, EventArgs e)
        {
            PanelUserPicGoBack.BackgroundImage = Properties.Resources.Back;
        }

        private void PanelUserPicGoBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    public class SessionInfo
    {
        public string SteamMachineAuth { get; set; } = string.Empty;

        public string SessionId { get; set; } = string.Empty;

        public string SteamLogin { get; set; } = string.Empty;

        public string SteamRememberLogin { get; set; } = string.Empty;

        public string SteamParental { get; set; } = string.Empty;

        public bool IsLoggedIn()
        {
            return !string.IsNullOrWhiteSpace(SessionId) && !string.IsNullOrWhiteSpace(SteamLogin);
        }
    }
}
