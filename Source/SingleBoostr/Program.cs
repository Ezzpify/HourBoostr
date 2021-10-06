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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Base = new Core.Objects.Steam();
            Application.Run(new AppHome());
        }
    }
}
