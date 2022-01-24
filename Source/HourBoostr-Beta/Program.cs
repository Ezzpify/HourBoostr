using HourBoostr_Beta.Core;
using HourBoostr_Beta.Ui;
using HourBoostr_Beta.Ui.MultiBoostr;
using HourBoostr_Beta.Ui.SingleBoostr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HourBoostr_Beta
{
    internal class Program
    {
        internal static Program This;
        internal event EventHandler ProcessExit;
        internal ProgramAssembly Assembly;
        internal ProgramArguments Arguments;
        internal ProgramConfig Config;
        internal SplashScreen SplashScreen;
        internal BoostrSelectionScreen BoostrSelectionScreen;
        internal SingleBoostr SingleBoostr;
        internal MultiBoostr MultiBoostr;

        private Program(List<string> arguments)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Assembly = new();
            Arguments = new(arguments);
            Config = new();
            SplashScreen = new();
            BoostrSelectionScreen = new();

            //Single bootsr
            SingleBoostr = new();
            SingleBoostr.GameLibrary = new();
            ProcessExit += SingleBoostr.Instance.Exit;

            //Multi bootsr
            MultiBoostr = new();
            foreach (var instance in MultiBoostr.Instance) 
                ProcessExit += instance.Exit;

            //Register event onto main apps thread exit handler
            Application.ThreadExit += ProcessExit;
        }

        internal void Start() => Application.Run(SplashScreen);
        internal void Close(object sender, EventArgs e)
        {
            This.ProcessExit?.Invoke(sender, e);
            Application.Exit();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static async Task Main(string[] args)
        {
            This = new(args.ToList());

            await Task.CompletedTask;
            /*
            if (This.Arguments.DevMode)
                This.Start();
            else
                This.Close();
            */
            This.Start();
        }
    }
}
