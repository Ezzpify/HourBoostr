using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace HourBoostr
{
    public partial class Form1 : Form
    {
        /*

            NOTE:
            This project is FAR from finished!!!!
            The code you will see below is not up to my standards,
            and it should not be up to yours either. However, the base is 
            written, so we can build upon that.

            The code is crap and a lot of cleaning has to be made
            This is just a release so people can test it out
            More features and fixes will come in as people request them

        */


        /// <summary>
        /// DllImport section
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


        /// <summary>
        /// Variables
        /// </summary>
        private Functions Func = new Functions();
        private List<Config.Game> Games = new List<Config.Game>();


        /// <summary>
        /// Sessions
        /// </summary>
        private List<Config.User> Users_All = new List<Config.User>();
        private Config.User Users_Current;


        /// <summary>
        /// Initializer
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        

        /// <summary>
        /// Control button for exiting the applicaton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(3);
        }


        /// <summary>
        /// Control button for maximizing the application window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_State_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            { WindowState = FormWindowState.Maximized; toolTip.SetToolTip(control_State, "Normal"); }
            else
            { WindowState = FormWindowState.Normal; toolTip.SetToolTip(control_State, "Maximize"); }
        }


        /// <summary>
        /// Control button for minimizing the application window to traybar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_Min_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) WindowState = FormWindowState.Minimized;
            else WindowState = FormWindowState.Normal;
        }


        /// <summary>
        /// Moving the form if user clicks and drags
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_Controls_MouseDown(object sender, MouseEventArgs e)
        {
            /*Move the form*/
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }


        /// <summary>
        /// Control button design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_Exit_MouseEnter(object sender, EventArgs e) { divider_Top.BackColor = Color.FromArgb(255, 128, 128); }
        private void control_Exit_MouseLeave(object sender, EventArgs e) { divider_Top.BackColor = Color.FromArgb(0, 119, 196); }
        private void control_State_MouseEnter(object sender, EventArgs e) { divider_Top.BackColor = Color.CornflowerBlue; }
        private void control_State_MouseLeave(object sender, EventArgs e) { divider_Top.BackColor = Color.FromArgb(0, 119, 196); }
        private void control_Min_MouseEnter(object sender, EventArgs e) { divider_Top.BackColor = Color.FromArgb(77, 77, 82); }
        private void control_Min_MouseLeave(object sender, EventArgs e) { divider_Top.BackColor = Color.FromArgb(0, 119, 196); }


        /// <summary>
        /// Moving the form if user clicks and drags
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_Header_MouseDown(object sender, MouseEventArgs e)
        {
            /*Move the form*/
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }


        /// <summary>
        /// Moving the form if user clicks and drags
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_Menu_MouseDown(object sender, MouseEventArgs e)
        {
            /*Move the form*/
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }


        /// <summary>
        /// Convert to long
        /// </summary>
        /// <param name="lowPart"></param>
        /// <param name="highPart"></param>
        /// <returns></returns>
        public int MakeLong(short lowPart, short highPart)
        {
            return (int)(((ushort)lowPart) | (uint)(highPart << 16));
        }


        /// <summary>
        /// Edits a listview control spacing
        /// </summary>
        /// <param name="listview">ListView to edit</param>
        /// <param name="cx">X axis</param>
        /// <param name="cy">Y axis</param>
        public void ListView_SetSpacing(ListView listview, short cx, short cy)
        {
            const int LVM_FIRST = 0x1000;
            const int LVM_SETICONSPACING = LVM_FIRST + 53;
            SendMessage(listview.Handle, LVM_SETICONSPACING,
            IntPtr.Zero, (IntPtr)MakeLong(cx, cy));
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        /// <summary>
        /// BackgroundWorker to fetch game information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameFetcher_DoWork(object sender, DoWorkEventArgs e)
        {
            /*Fetch XML data from steam profile*/
            string XMLData = Func.Fetch((string)e.Argument);

            /*Parse the data*/
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XMLData);

            /*Semaphore for queue*/
            Semaphore sem = new Semaphore(5, 5);

            /*Node count*/
            int nodes = doc.SelectNodes("gamesList/games/game").Count;

            /*Go through each game node*/
            foreach (XmlNode childrenNode in doc.SelectNodes("gamesList/games/game"))
            {
                /*Wait until sem has an open spot*/
                sem.WaitOne();

                /*Fetch information and logo in a new thread*/
                new Thread(() =>
                {
                    try
                    {
                        /*Load up var info about game*/
                        string appID = childrenNode.SelectSingleNode(".//appID").InnerText;
                        string name = childrenNode.SelectSingleNode(".//name").InnerText;
                        string logo = childrenNode.SelectSingleNode(".//logo").InnerText;

                        /*Add game to list*/
                        Games.Add(new Config.Game(appID, name, Func.ImageFromUrl(logo)));
                    }
                    catch (Exception ex)
                    {
                        /*Unsure what could have happpen*/
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        /*Thread finished, release sem and decrease nodes count*/
                        sem.Release(1);
                        nodes--;
                    }

                }).Start();
            }

            /*Wait for threads to finish*/
            while (nodes > 0) { Thread.Sleep(100); }
        }

        
        /// <summary>
        /// BackgroundWorker complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameFetcher_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /*Hide loading animation*/
            pic_Loading.Visible = false;

            /*Show listview of games*/
            gameView.Visible = true;
            game_AddAll.Visible = true;

            /*Set list of games to listview*/
            SetList(Games);
            Games.Clear();
        }


        /// <summary>
        /// Sets a list of games to the GameViewList
        /// </summary>
        /// <param name="games"></param>
        void SetList(List<Config.Game> games)
        {
            /*Remove previous entries*/
            gameView.Clear();

            /*Set spacing*/
            ListView_SetSpacing(gameView, 130, 55);

            /*Set image list*/
            gameView.LargeImageList = Users_Current.imList;

            /*Go through each game and add them to ListView*/
            foreach (Config.Game game in games)
            {
                try
                {
                    /*Add image*/
                    if(!Users_Current.imList.Images.Keys.Contains(game.appID))
                    {
                        Users_Current.imList.Images.Add(game.appID, game.logo);
                    }

                    /*Add game to current user game list*/
                    if (!Users_Current.GameList.Contains(game))
                    {
                        Users_Current.GameList.Add(game);
                    }

                    /*Add item*/
                    ListViewItem lvi = new ListViewItem();
                    lvi.SubItems.Add(game.appID);
                    lvi.SubItems.Add(game.name);
                    lvi.ImageKey = game.appID;
                    gameView.Items.Add(lvi);
                }
                catch(Exception ex)
                {
                    /*Debug error*/
                    Console.WriteLine(ex.ToString());
                }
            }
        }


        /// <summary>
        /// Adds the game the user clicked to list of games to boost and remove it from the listView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameView_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                /*Remove from selected index*/
                for (int i = 0; i < gameView.SelectedItems.Count; i++)
                {
                    RemoveFromList(gameView.SelectedItems[i]);
                }

                /*Hide game menu if visible*/
                panel_GameList.Visible = false;
                game_listBtn.Text = "► Show added";
            }
            catch(Exception ex)
            {
                /*SelectedItems could've been null*/
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Add all games from the list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void game_AddAll_Click(object sender, EventArgs e)
        {
            /*Game warning*/
            if(gameView.Items.Count > 30)
            {
                DialogResult diagr = MessageBox.Show("Steam does not record more than 30 games.\nThe extra games will not get boosted.", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (diagr == DialogResult.Cancel)
                    return;
            }

            /*Go through all items and add to list*/
            for (int i = 0; i < gameView.Items.Count; i++)
            {
                RemoveFromList(gameView.Items[i], false);
            }

            /*Clear listview*/
            gameView.Items.Clear();
            label_Info.Visible = true;
            game_AddAll.Visible = false;
        }


        /// <summary>
        /// Delete an item from GameView and add it to globals
        /// </summary>
        /// <param name="item">Listview item to delete</param>
        /// <param name="delete">If the item should be removed from gameView</param>
        private void RemoveFromList(ListViewItem item, bool delete = true)
        {
            /*Add to listBox*/
            game_listBox.Items.Add(item.SubItems[2].Text);

            /*Add to games*/
            Users_Current.Games.Add(new Config.Game(item.SubItems[1].Text, item.SubItems[2].Text, Users_Current.imList.Images[item.Index]));
            
            /*Scroll to bottom*/
            int visibleItems = game_listBox.ClientSize.Height / game_listBox.ItemHeight;
            game_listBox.TopIndex = Math.Max(game_listBox.Items.Count - visibleItems + 1, 0);

            /*Update count*/
            game_labelCount.Text = string.Format("Games: {0}", game_listBox.Items.Count);

            /*Remove item from gameList*/
            if(delete)
                gameView.Items.Remove(item);

            /*Remove item from user game list*/
            for(int i = 0; i < Users_Current.GameList.Count; i++)
            {
                if(Users_Current.GameList[i].appID == item.SubItems[1].Text)
                {
                    Users_Current.GameList.RemoveAt(i);
                }

            } UpdateUser();

            /*If we're out of games to add*/
            if (gameView.Items.Count == 0)
            {
                label_Info.Text = "You're out of games to add";
                label_Info.Visible = true;
            }
        }


        /// <summary>
        /// Show the acc account form
        /// </summary>
        void ShowAddForm()
        {
            /*Show the add account dialog*/
            using (AddForm af = new AddForm(Location.X - 17, Location.Y + 52, Users_All))
            {
                /*Show form as a dialog (think MessageBox)*/
                /*This means that Form1 can't be accessed while AddForm is active*/
                af.ShowDialog(this);

                /*Check if bot isn't null - will be null if user closes AddForm*/
                if(af.BotAcc != null)
                {
                    /*Set up user class*/
                    Config.User User = new Config.User();
                    User.Bot = af.BotAcc;
                    User.Profile = string.Format("http://steamcommunity.com/profiles/{0}/", af.BotAcc._SteamClient.SteamID.ConvertToUInt64());

                    /*Set this user as the current global user*/
                    Users_Current = User;

                    /*Add to user list*/
                    Users_All.Add(User);

                    /*Refresh User list*/
                    RefreshUserList();

                    /*Set this account as active account visually*/
                    /*New user is always last in list, and list is not 0-index so we do minus 1 on count*/
                    SetActiveAccount(Users_All.Count - 1);

                    /*Clear game viewList from previous users*/
                    gameView.Clear();

                    /*Load games*/
                    pic_Loading.Visible = true;
                    gameFetcher.RunWorkerAsync(User.Profile + "games?tab=all&xml=1");
                }
            }
        }


        /// <summary>
        /// Refreshes the userViewList to display all users
        /// </summary>
        void RefreshUserList()
        {
            userView.Clear();
            menu_Run.Visible = true;
            foreach (var user in Users_All)
            {
                userView.Items.Add(user.Bot._Username);
            }
        }


        /// <summary>
        /// Button events to show the add account form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_Add1_Click(object sender, EventArgs e) { ShowAddForm(); }
        private void menu_Add2_Click(object sender, EventArgs e) { ShowAddForm(); }


        private void game_listBtn_Click(object sender, EventArgs e)
        {
            if(panel_GameList.Visible)
            {
                panel_GameList.Visible = false;
                game_listBtn.Text = "► Show added";
            }
            else
            {
                panel_GameList.Visible = true;
                game_listBtn.Text = "▼ Hide added";
            }
        }

        void UpdateUser()
        {
            for(int i = 0; i < Users_All.Count; i++)
            {
                if (Users_All[i].Bot._Username == Users_Current.Bot._Username)
                {
                    Users_All[i] = Users_Current;
                }
            }
        }

        void SetActiveAccount(int index)
        {
            /*Make userList look a bit nicer*/
            userView.Items[index].Text = " › " + userView.Items[index].Text;

            /*Remove arrow from other items*/
            for (int i = 0; i < userView.Items.Count; i++)
            {
                if (i != index)
                    userView.Items[i].Text = Users_All[i].Bot._Username;
            }
        }

        private void userView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userView.SelectedItems.Count > 0)
            {
                /*Get selected item - although we only care about the item index*/
                var item = userView.SelectedItems[0];

                if (Users_Current != Users_All[item.Index])
                {
                    /*Update user*/
                    UpdateUser();

                    /*Set user*/
                    Users_Current = Users_All[item.Index];

                    /*Set games*/
                    SetList(Users_Current.GameList);

                    /*Reset picked game list*/
                    game_listBox.Items.Clear();

                    /*Set picked game list*/
                    foreach(var game in Users_Current.Games)
                    {
                        game_listBox.Items.Add(game.name);
                    }

                    /*Update count*/
                    game_labelCount.Text = string.Format("Games: {0}", game_listBox.Items.Count);

                    /*Sets active account visually*/
                    SetActiveAccount(item.Index);

                    /*Text info text if needed*/
                    label_Info.Visible = (gameView.Items.Count == 0);
                }
            }
        }

        private void userMenu_Opening(object sender, CancelEventArgs e)
        {
            if (userView.SelectedItems.Count == 0)
                e.Cancel = true;
        }

        private void userMenu_Remove_Click(object sender, EventArgs e)
        {
            Users_Current = null;
            Users_All.RemoveAt(userView.SelectedItems[0].Index);
            userView.Items.RemoveAt(userView.SelectedItems[0].Index);
            gameView.Items.Clear();
        }

        private void menu_Run_Click(object sender, EventArgs e)
        {
            menu_Run.Click -= menu_Run_Click;
            menu_Run.ForeColor = Color.Gray;

            foreach(var user in Users_All)
            {
                List<int> Games = new List<int>();
                foreach(var game in user.Games)
                {
                    Games.Add(Convert.ToInt32(game.appID));
                }
                user.Bot.SetGamesPlaying(Games);
            }
        }
    }
}
