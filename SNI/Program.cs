using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SNI.Views.Login;
using SNI.Views.FirstConfig;
namespace SNI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config.ReadFile();
            if (Config.config.connectsuccess)
            {
                Application.Run(new LoginForm());
            }
            else
            {
                Application.Run(new CommonForm());
            }
        }
    }
}
