using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SingleBoostr
{
    class Const
    {
        public static string GAME_LIST_URL = "https://raw.githubusercontent.com/Ezzpify/HourBoostr/master/gameList.xml";
        public static string GAME_LIST_LOCAL = Path.Combine(Application.StartupPath, "GameList.xml");
        public static string GAME_PROCESS = Path.Combine(Application.StartupPath, "SingleBoostr.Game.exe");
    }
}
