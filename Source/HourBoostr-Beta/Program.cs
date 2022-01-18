using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HourBoostr_Beta.Core;
using HourBoostr_Beta.Ui;

namespace HourBoostr_Beta
{
    internal class Program
    {
        internal static Program This; 
        internal ProgramAssembly Assembly;
        internal ProgramArguments Arguments;
        internal SplashScreen SplashScreen;
        internal BoostrSelectionScreen BoostrSelectionScreen;

        private Program(List<string> arguments)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Assembly = new();
            Arguments = new(arguments);
            SplashScreen = new();
            BoostrSelectionScreen = new();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static async Task Main(string[] args)
        {
            This = new(args.ToList());

            await Task.CompletedTask;

            if (This.Arguments.DevMode)
               Application.Run(This.SplashScreen);
            else
                Application.Exit();
        }
    }
}
