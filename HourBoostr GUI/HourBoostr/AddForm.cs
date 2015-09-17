using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace HourBoostr
{
    public partial class AddForm : Form
    {
        /// <summary>
        /// Variables
        /// </summary>
        private int startLocX;
        private int startLocY;
        private List<Config.User> Users;
        private BotClass Bot;


        /// <summary>
        /// Holds bot class
        /// </summary>
        public BotClass BotAcc { get { return Bot; } }

        
        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public AddForm(int x, int y, List<Config.User> users)
        {
            /*Set form start location passed by Form1*/
            startLocX = x;
            startLocY = y;

            /*Set list of users*/
            Users = users;
            
            /*Initialize form*/
            InitializeComponent();
        }


        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddForm_Load(object sender, EventArgs e)
        {
            /*Set form position close to the Add button in Form1*/
            SetDesktopLocation(startLocX, startLocY);

            /*Set small size*/
            Size = new Size(287, 90);

            /*Set AddBtn as active control*/
            ActiveControl = AddBtn;
        }


        /// <summary>
        /// If account already exist in list
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        private bool UserExists(string acc)
        {
            foreach(var user in Users)
            {
                if(acc == user.Bot._Username)
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Add button event - Check if all info is correct before adding account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            /*Error count - if more than 1 we'll break at the end of the checks*/
            int errors = 0;

            /*Check if Username field is not empty*/
            if(string.IsNullOrEmpty(text_User.Text)) { errors++; user_Pic.BackColor = Color.FromArgb(255, 192, 192); }
            else { user_Pic.BackColor = Color.FromArgb(192, 255, 192); }

            /*Check if Password field is not empty*/
            if(string.IsNullOrEmpty(text_Pass.Text)) { errors++; pass_Pic.BackColor = Color.FromArgb(255, 192, 192); }
            else { pass_Pic.BackColor = Color.FromArgb(192, 255, 192); }

            /*Check if user is already logged in*/
            if(UserExists(text_User.Text)) { errors++; user_Pic.BackColor = Color.FromArgb(255, 192, 192); }
            
            /*If we have more than 0 errors we'll stop here*/
            if(errors > 0)
            {
                /*Some errors occured - stop function*/
                return;
            }
            else
            {
                /*No errors occured - log in*/
                Config.AccountInfo acc = new Config.AccountInfo();
                acc.Username = text_User.Text;
                acc.Password = text_Pass.Text;

                /*Disable UI*/
                AddBtn.Visible      = false;
                CloseBtn.Visible    = false;
                panel4.Visible      = false;
                panel5.Visible      = false;
                pic_Loading.Visible = true;

                /*Run login in new thread*/
                var t = new Thread(() => NewBot(acc));
                t.Start();
            }
        }


        /// <summary>
        /// Runs a new bot
        /// </summary>
        /// <param name="acc"></param>
        private void NewBot(Config.AccountInfo acc)
        {
            /*Login to steam*/
            Bot = new BotClass(acc, false, Location.X, Location.Y);

            /*Wait for bot to login*/
            while (!Bot._IsLoggedIn) { Thread.Sleep(250); }

            /*Invoke form and close it*/
            Invoke(new Action(() =>
            {
                Close();
            }));
        }


        /// <summary>
        /// Close button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            /*Simply close the form, we don't care about existing information*/
            Close();
        }


        /// <summary>
        /// Style events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_MouseEnter(object sender, EventArgs e) { AddBtn.Font = new Font(AddBtn.Font, FontStyle.Bold | FontStyle.Underline); }
        private void AddBtn_MouseLeave(object sender, EventArgs e) { AddBtn.Font = new Font(AddBtn.Font, FontStyle.Bold); }
        private void CloseBtn_MouseEnter(object sender, EventArgs e) { CloseBtn.Font = new Font(CloseBtn.Font, FontStyle.Bold | FontStyle.Underline); }
        private void CloseBtn_MouseLeave(object sender, EventArgs e) { CloseBtn.Font = new Font(CloseBtn.Font, FontStyle.Bold); }
    }
}
