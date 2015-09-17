using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace JsonHelper
{
    public partial class Form1 : Form
    {
        //http://steamcommunity.com/id/pandaclick/games?tab=all&xml=1

        /// <summary>
        /// DllImport regarding moving the window
        /// </summary>
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        /// <summary>
        /// Initializer
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Header stuff
        /// </summary>
        #region Header
        /// <summary>
        /// Moves the form when holding down mouse1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void header_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            /*Move the form*/
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        /// <summary>
        /// Directs user to my github
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void header_Label_ToWebsite_Click(object sender, EventArgs e)
        {
            /*Go to my github*/
            Process.Start("https://github.com/Ezzpify");
        }


        /// <summary>
        /// Exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void header_Label_Exit_Click(object sender, EventArgs e)
        {
            /*Exit the application*/
            Environment.Exit(1);
        }


        /// <summary>
        /// MouseEvent for highlighting the label when user hover over it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void header_Label_Exit_MouseEnter(object sender, EventArgs e)
        {
            header_Label_Exit.ForeColor = Color.Gainsboro;
        }
        private void header_Label_Exit_MouseLeave(object sender, EventArgs e)
        {
            header_Label_Exit.ForeColor = Color.DodgerBlue;
        }
        private void header_Label_ToWebsite_MouseEnter(object sender, EventArgs e)
        {
            header_Label_ToWebsite.ForeColor = Color.Gainsboro;
        }
        private void header_Label_ToWebsite_MouseLeave(object sender, EventArgs e)
        {
            header_Label_ToWebsite.ForeColor = Color.DodgerBlue;
        }
        #endregion Header


        /// <summary>
        /// Settings class to hold all entries
        /// </summary>
        public class Settings
        {
            public List<Entry> Account { get; set; }
        }


        /// <summary>
        /// Entry class for user input
        /// </summary>
        public class Entry
        {
            public string Username { get; set; }
            public List<int> Games { get; set; }
        }


        /// <summary>
        /// Global list that holds all entries
        /// </summary>
        List<Entry> Entries = new List<Entry>();


        /// <summary>
        /// Event that adds an entry to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            /*If we the nessesary information*/
            if(text_Username.Text.Length > 0 && text_Games.Text.Length > 0)
            {
                /*Format the information*/
                string tempUsername = text_Username.Text;
                List<int> tempGames = new List<int>();
                for (int i = 0; i < text_Games.Lines.Length; i++)
                {
                    /*Try to parse the line to int*/
                    int GameID = 0;
                    bool Parsed = int.TryParse(text_Games.Lines[i].Replace(",", ""), out GameID);

                    if(Parsed)
                    {
                        tempGames.Add(GameID);
                    }
                    else
                    {
                        MessageBox.Show(String.Format("Unable to parse GameID '{0}'\n"
                            + "Make sure it's correct, and only numbers.", text_Games.Lines[i]), "Parsing error");
                        return;
                    }
                }

                /*Construct a new entry*/
                Entry newEntry = new Entry()
                {
                    Username = tempUsername,
                    Games = tempGames
                };

                /*Add the entry to the global list*/
                Entries.Add(newEntry);

                /*Add the username to the Listbox so the user can see it's working*/
                list_Entries.Items.Add(newEntry.Username);

                /*Enable the save button*/
                btn_Save.Enabled = true;

                /*Remove the information*/
                text_Username.Text = String.Empty;
                text_Games.Text = String.Empty;
            }
        }


        /// <summary>
        /// Save all settings to Settings.json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            /*Format the path to save the file*/
            string jsonPath = Path.Combine(Application.StartupPath, "Settings.json");

            /*Convert global list*/
            Settings jsonSettings = new Settings();
            jsonSettings.Account = Entries;

            /*Serialize new class*/
            string jsonString = JsonConvert.SerializeObject(jsonSettings, Formatting.Indented);

            /*If the file already exist, ask if user wants to overwrite*/
            if (File.Exists(jsonPath))
            {
                DialogResult dialogResult = MessageBox.Show("Settings.json already exists. Do you want to overwrite it?", 
                    "File Exists", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    File.WriteAllText(jsonPath, jsonString);
                }
                else
                {
                    return;
                }
            }
            else
            {
                /*File doesn't exist, so just write it*/
                File.WriteAllText(jsonPath, jsonString);
            }

            /*Done*/
            MessageBox.Show("Wrote Settings.json!");

            /*Clear everything*/
            Entries.Clear();
            list_Entries.Items.Clear();
        }
    }
}
