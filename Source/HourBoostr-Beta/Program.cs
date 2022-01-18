using System;
using System.Linq;
using System.Windows.Forms;
using HourBoostr_Beta.Core;

namespace HourBoostr_Beta
{
    internal class Program
    {
        internal static ProgramAssembly Assembly;
        internal static Form SplashScreen; 

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Assembly = ProgramAssembly.GetInstance();
            SplashScreen = new SplashScreen();
            if (args.Any())
            {
                if (args[0].Contains("dev"))
                    Application.Run(SplashScreen);
            }
            else
                Application.Exit();
        }
    }
}
