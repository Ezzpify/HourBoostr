﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Linq;
using System.Windows.Forms;
using HourBoostr.Settings.Core;
using HourBoostr.Settings.Objects;
using SingleBoostr.Core.Misc;
using SingleBoostr.Core.Enums;

namespace HourBoostr.Settings.Ui
{
    public partial class AppGames : Form
    {
        /// <summary>
        /// Stores all selected games
        /// </summary>
        public List<Config.Game> mGamesSelected = new List<Config.Game>();


        /// <summary>
        /// Stores all game available on a user account
        /// </summary>
        private List<Config.Game> mGames = new List<Config.Game>();
         
        /// <summary>
        /// Form constructor
        /// Sets placeholder text
        /// </summary>
        public AppGames()
        {
            InitializeComponent();
            Size = new Size(381, 120);

            /*Set placeholder text for text controls*/
            Utils.SendMessage(txtProfile.Handle, Messages.EM_SETCUEBANNER, 0, Const.Steam.Example_Profile.URLCUSTOM);
            Utils.SendMessage(txtSearch.Handle, Messages.EM_SETCUEBANNER, 0, "Search Game");
            
            ActiveControl = lvlExampleInput;
        }


        /// <summary>
        /// Shows/Hides the loading animation
        /// </summary>
        /// <param name="show">True to show, false to hide</param>
        private void ShowLoading(bool show)
        {
            picLoading.Image = Properties.Resources.loading;
            picLoading.Visible = show;
        }

        /// <summary>
        /// Highlight when mouse over
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void lvlExampleInput_MouseEnter(object sender, EventArgs e) => lvlExampleInput.ForeColor = SystemColors.Highlight;

        /// <summary>
        /// De-highlight when mouse over
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void lvlExampleInput_MouseLeave(object sender, EventArgs e) => lvlExampleInput.ForeColor = Color.Gray;
        
        /// <summary>
        /// Input example click
        /// Shows several ways to input acceptable data
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void lvlExampleInput_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Full url\n"
                + $"• {Const.Steam.Example_Profile.URLCUSTOM}\n"
                + $"• {Const.Steam.Example_Profile.URL}\n\n"
                + "Custom url or SteamID64\n"
                + $"• {Const.Steam.Example_Profile.STEAMID}\n"
                + $"• {Const.Steam.Example_Profile.CUSTOMURL}",
                "Example input");
        }

        /// <summary>
        /// txtProfile keydown
        /// If input is valid it will start the background worker and try to fetch the games
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">KeyEventArgs</param>
        private void txtProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string input = CheckInput(txtProfile.Text.Trim());
                if (!string.IsNullOrWhiteSpace(input))
                {
                    input += "/games?tab=all&xml=1";

                    /*Pass input to bwg*/
                    backgroundWorker.RunWorkerAsync(input);

                    ShowLoading(true);
                    Size = new Size(381, 420);
                    txtProfile.Enabled = false;
                    gameGroup.Visible = false;

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else
                {
                    MessageBox.Show("Profile input value is invalid", "You fucked up");
                }
            }
        }

        /// <summary>
        /// Checks if the input value is a steam url, or can be formatted as one
        /// </summary>
        /// <param name="input">input to check</param>
        /// <returns>Returns empty string is invalid input</returns>
        private static string CheckInput(string input)
        {
            string url = string.Empty;

            /* Matches http://steamcommunity.com/id/ezzpify */
            var reg1 = new Regex(@"^(https?:\/\/(?:[a-z0-9-]+\.)*steamcommunity\.com.id.[a-zA-Z0-9](?:\S*)?)$");

            /* Matches https://steamcommunity.com/profile/76561197960285265 */
            var reg2 = new Regex(@"^(https?:\/\/(?:[a-z0-9-]+\.)*steamcommunity\.com.profiles.[0-9](?:\S*)?)$");

            /* Matches 76561197960285265*/
            var reg3 = new Regex(@"^[0-9]*$");

            /* Matches Ezzpify*/
            var reg4 = new Regex(@"^[a-zA-Z0-9_-]*$");

            if (input.Contains("steamcommunity"))
            {
                /*We'll assume that this is a steamcommunity link*/
                if (reg1.IsMatch(input) || reg2.IsMatch(input))
                    url = input;
            }
            else
            {
                /*See if the input is SteamID64 (which is 17 in length, only numbers)*/
                if (reg3.IsMatch(input) && input.Length == 17)
                    url = Utils.STEAM_URL("community", $"profiles/{input}");
                /*Lastly we'll assume it's a custom url*/
                else if (reg4.IsMatch(input))
                    url = Utils.STEAM_URL("community", $"id/{input}");
            }

            /*We'll strip the url of the last slash since we'll add that later on*/
            if (url.EndsWith("/"))
                url = url.Substring(0, url.LastIndexOf('/'));

            return url;
        }

        /// <summary>
        /// Bwg main worker
        /// Fetches game list from steam profile
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">DoWorkEventArgs</param>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string url = (string)e.Argument;

            string rawXml = Network.DownloadString($"{url}/games?tab=all&xml=1");
            if (!string.IsNullOrWhiteSpace(rawXml) && rawXml.Contains("gamesList"))
            {
                mGames = Xmlc.ParseXML(rawXml)
                .OrderBy(o => o.name).ToList();
            }
        }

        /// <summary>
        /// Bwg completed
        /// Adds all the games fetched to the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowLoading(false);
            gameGroup.Visible = true;
            gameGroup.Text = $"Games: {mGames.Count}";
            txtProfile.Enabled = true;

            gameList.Items.Clear();
            mGames.ForEach(game => gameList.Items.Add(game.name));

            if (gameList.Items.Count != 0) return;

            Size = new Size(381, 120);
            gameGroup.Visible = false;
        }

        /// <summary>
        /// Loads all games from available games list into listboxes
        /// </summary>
        private void LoadAvailableGames()
        {
            gameList.Items.Clear();
            mGames.ForEach(game => gameList.Items.Add(game.name));
        }

        /// <summary>
        /// Sorts the global lists by name and adds them to the listboxes
        /// </summary>
        private void RefreshLists()
        {
            gameList.Items.Clear();
            selectedList.Items.Clear();

            mGames = mGames.OrderBy(o => o.name).ToList();
            
            string searchQuery = txtSearch.Text;
            foreach (var game in mGames)
            {
                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    if (!game.name.ToLower().Contains(searchQuery.ToLower()))
                        continue;
                }

                gameList.Items.Add(game.name);
            }

            mGamesSelected.ForEach(o => selectedList.Items.Add(o.name));
        }

        /// <summary>
        /// Adds the selected game to selected games and removes it from games
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void gameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = gameList.SelectedItem;
            if (item == null)
                return;

            var selected = mGames.FirstOrDefault(o => o.name == (string)item);
            if (selected != null)
            {
                mGamesSelected.Add(selected);
                mGames.Remove(selected);

                RefreshLists();
            }
        }

        /// <summary>
        /// Re-adds the selected game to games and removes it from selected games
        /// Just reverse of the above function
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void selectedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = selectedList.SelectedItem;
            if (item == null) return;

            var selected = mGamesSelected.FirstOrDefault(o => o.name == (string)item);
            if (selected == null) return;

            mGames.Add(selected);
            mGamesSelected.Remove(selected);
            RefreshLists();
        }

        /// <summary>
        /// Just refresh each time user types and it will filter
        /// games in RefreshLists function
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void txtSearch_TextChanged(object sender, EventArgs e) => RefreshLists();
        
        /// <summary>
        /// Closing event
        /// Since we want to be able to access the game list after user closes form
        /// we'll just hide it instead, and then close it from mainForm when we're done
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">FormClosingEventArgs</param>
        private void gameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        /// <summary>
        /// select random games
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rndGames_Click(object sender, EventArgs e)
        {
            //purge
            mGames.AddRange(mGamesSelected); //add them all back to selection
            mGamesSelected.Clear(); //remove all from selected

            //users apps
            var apps = mGames.ToList();

            //random
            if (apps.Count() >= Const.Steam.MAX_GAMES)
                apps = Utils.GetRandomElements(apps, Const.Steam.MAX_GAMES - 1);

            //add
            foreach (var app in apps)
            {
                mGamesSelected.Add(app);//add app to selected 
                mGames.Remove(app);//remove app from selection
            }

            //update view
            RefreshLists();
        }
    }
}
