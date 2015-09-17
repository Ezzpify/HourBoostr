using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HourBoostr
{
    public class Config
    {
        /// <summary>
        /// Class for account information
        /// </summary>
        public class AccountInfo
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }


        /// <summary>
        /// Class for holding information about a Steam game
        /// </summary>
        public class Game
        {
            /*Variables*/
            public string appID { get; private set; }
            public string name { get; private set; }
            public Image logo { get; private set; }

            /*Initializer*/
            public Game(string _appID, string _name, Image _logo)
            {
                appID = _appID;
                name = _name;
                logo = _logo;
            }
        }

        /// <summary>
        /// User class
        /// </summary>
        public class User
        {
            public BotClass Bot { get; set; }
            public ImageList imList { get; set; } = new ImageList();
            public List<Game> Games { get; set; } = new List<Game>();
            public List<Game> GameList { get; set; } = new List<Game>();
            public string Profile { get; set; }

            public User()
            {
                imList.ColorDepth = ColorDepth.Depth32Bit;
                imList.ImageSize = new Size(120, 45);
            }
        }
    }
}
