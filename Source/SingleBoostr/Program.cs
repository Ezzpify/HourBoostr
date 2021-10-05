using System;
using System.Windows.Forms;
using SingleBoostr.Ui;

namespace SingleBoostr
{
    public static class Program
    {
        internal static Core.Objects.Steam Base;

        [STAThread]
        public static void Main(string[] args) 
        { 
            string ApiKey = "";
             
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Base = new Core.Objects.Steam(ApiKey);

            Application.Run(new AppHome());
        }
    }
}
