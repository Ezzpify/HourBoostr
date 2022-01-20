using System;
using System.Windows.Forms;
using SingleBoostr.Ui;

namespace SingleBoostr
{
    public static class Program
    {
        internal static AppSettings Config = new AppSettings();
        internal static Core.Objects.Steam Base = new Core.Objects.Steam(Config.Settings.WebSession.APIKey);

        [STAThread]
        public static void Main() 
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppHome());
        }
    }
}
