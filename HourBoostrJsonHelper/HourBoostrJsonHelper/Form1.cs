using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Xml;
using System.Drawing;

namespace HourBoostrJsonHelper
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Private variables
        /// </summary>
        private List<Config.AccountSettings> mAccounts = new List<Config.AccountSettings>();


        /// <summary>
        /// List containing games fetched from steam xml
        /// </summary>
        private List<string> mGameList = new List<string>();


        /// <summary>
        /// Search bar placeholder variable
        /// </summary>
        private bool mSearchEntered;


        /// <summary>
        /// Class constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Adds a new entry
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxUsername.Text) && !string.IsNullOrWhiteSpace(richTextBoxGames.Text))
            {
                List<int> setGames = new List<int>();
                for (int i = 0; i < richTextBoxGames.Lines.Length; i++)
                {
                    string line = richTextBoxGames.Lines[i].Trim();
                    if (!string.IsNullOrEmpty(line))
                    {
                        int gameId = 0;
                        if (int.TryParse(richTextBoxGames.Lines[i], out gameId))
                        {
                            if (!setGames.Contains(gameId))
                                setGames.Add(gameId);
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Unable to parse game id: {0}.\nGame ids can only consist of numbers.", line), "Error");
                        }
                    }
                }

                var account = new Config.AccountSettings()
                {
                    Username = textBoxUsername.Text.Trim(),
                    Password = textBoxPassword.Text.Trim(),
                    ShowOnlineStatus = checkBoxAppearOnline.Checked,
                    RestartGamesEveryThreeHours = checkBoxRestartGames.Checked,
                    ChatResponse = richTextBoxChatResponse.Text.Trim(),
                    Games = setGames
                };

                if (account.Games.Count > 0)
                {
                    mAccounts.Add(account);
                    listBoxEntries.Items.Add(account.Username);
                    buttonSave.Enabled = true;
                    textBoxUsername.Text = string.Empty;
                    richTextBoxGames.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("No games are added", "Error");
                }
            }
        }


        /// <summary>
        /// Saves the list of account to Settings.json
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string jsonFile = Path.Combine(Application.StartupPath, "Settings.json");
            var settings = new Config.Settings();
            settings.Accounts = mAccounts;
            settings.HideToTrayAutomatically = checkBoxHideToTray.Checked;

            string jsonString = JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);
            if (File.Exists(jsonFile))
            {
                DialogResult diagResult = MessageBox.Show("Do you want to overwrite the existing Settings.json", "File Exists", MessageBoxButtons.YesNo);
                if (diagResult == DialogResult.No)
                {
                    return;
                }
            }

            File.WriteAllText(jsonFile, jsonString);
            mAccounts.Clear();
            listBoxEntries.Items.Clear();
            MessageBox.Show("Settings.json saved!", "Success");
        }


        /// <summary>
        /// Fetch all games from profile
        /// Parses xml response from steam api
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFetch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCommunityUrl.Text))
                return;

            mGameList.Clear();
            listBoxGames.Items.Clear();
            string url = textBoxCommunityUrl.Text;
            if (!url.EndsWith("/"))
                url += "/";

            string xml = Website.DownloadString(string.Format("{0}/games?tab=all&xml=1", url));
            if (string.IsNullOrWhiteSpace(xml))
            {
                MessageBox.Show("Invalid response. Url probably not correct.");
            }

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);

                XmlNodeList nodeList = xmlDoc.SelectNodes("/gamesList/games/game");
                if (nodeList.Count == 0)
                {
                    MessageBox.Show("No games found. Make sure your profile is public.");
                    return;
                }

                foreach (XmlNode node in nodeList)
                {
                    string appId = node.SelectSingleNode("appID").InnerText;
                    string appName = node.SelectSingleNode("name").InnerText;
                    mGameList.Add($"{appId} | {appName}");
                }

                RefreshGames();
            }
            catch (XmlException xEx)
            {
                MessageBox.Show("Invalid XML response: " + xEx.Message);
            }
        }


        /// <summary>
        /// Refreshes the game list
        /// </summary>
        private void RefreshGames()
        {
            listBoxGames.Items.Clear();
            string searchString = textBoxGameSearch.Text.ToLower();
            foreach (var game in mGameList)
            {
                if (mSearchEntered && !string.IsNullOrEmpty(searchString))
                {
                    /*Filter out games based on search text*/
                    if (!game.ToLower().Contains(searchString))
                        continue;
                }

                listBoxGames.Items.Add(game);
            }
        }


        /// <summary>
        /// Get item text from object
        /// </summary>
        /// <param name="item">item list item object</param>
        /// <returns>Returns empty if fail</returns>
        private string GetItemStringGameId(object item)
        {
            string itemContent = listBoxGames.GetItemText(item);
            if (!string.IsNullOrWhiteSpace(itemContent))
            {
                string[] spl = itemContent.Split(new string[] { " | " }, StringSplitOptions.None);
                return spl[0];
            }

            return string.Empty;
        }


        /// <summary>
        /// Listbox double click event
        /// This will enter the appId to games id list
        /// </summary>
        private void listBoxGames_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var list = (ListBox)sender;
            int itemIndex = list.IndexFromPoint(e.Location);
            if (itemIndex != -1)
            {
                var item = list.Items[itemIndex];

                if (item != null)
                    richTextBoxGames.AppendText(GetItemStringGameId(item) + "\n");
            }
        }


        /// <summary>
        /// Add all selected items from listbox to game list
        /// </summary>
        private void btnAddSelected_Click(object sender, EventArgs e)
        {
            var items = listBoxGames.SelectedItems;

            foreach (var item in items)
                richTextBoxGames.AppendText(GetItemStringGameId(item) + "\n");
        }


        /// <summary>
        /// Searchbar enter event
        /// If we haven't been here before, clear text
        /// </summary>
        private void textBoxGameSearch_Enter(object sender, EventArgs e)
        {
            if (!mSearchEntered)
            {
                textBoxGameSearch.ForeColor = Color.FromArgb(224, 224, 224);
                textBoxGameSearch.Text = string.Empty;
                mSearchEntered = true;
            }
        }


        /// <summary>
        /// Enable the add selected button if we have items selected
        /// </summary>
        private void listBoxGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddSelected.Enabled = listBoxGames.SelectedItems.Count > 0;
        }


        /// <summary>
        /// Search box
        /// </summary>
        private void textBoxGameSearch_TextChanged(object sender, EventArgs e)
        {
            if (mSearchEntered)
            {
                RefreshGames();
            }
        }
    }
}
