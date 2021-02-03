using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SNI.Views.Login;
using SNI.Views.FirstConfig;
using SNI.Controllers;
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
            if(!UserController.countUser())
            {
                CommonForm cf = new CommonForm();
                cf.signal = 1;
                Application.Run(cf);
            }
            if (Config.config.connectsuccess)
            {
                Application.Run(new LoginForm());
            }
            if (!Config.config.connectsuccess)
            {
                CommonForm cf = new CommonForm();
                cf.signal = 0;
                Application.Run(cf);
            }
        }
    }
}
