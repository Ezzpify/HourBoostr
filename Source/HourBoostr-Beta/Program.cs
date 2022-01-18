using System;
using System.Linq;
using System.Windows.Forms;
using HourBoostr_Beta.Core;
using HourBoostr_Beta.Ui;

namespace HourBoostr_Beta
{
    internal class Program
    {
        internal static Program This; 
        internal static ProgramAssembly Assembly;
        internal static SplashScreen SplashScreen;
        internal static BoostrSelectionScreen BoostrSelectionScreen;

        private Program()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Assembly = new();
            SplashScreen = new();
            BoostrSelectionScreen = new();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main(string[] args)
        {
            This = new();

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
