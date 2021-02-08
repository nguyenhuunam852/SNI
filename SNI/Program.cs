using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SNI.Views.Login;
using SNI.Views.FirstConfig;
using SNI.Controllers;
using SNI.Views.Setting;
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
            try
            {
                if (!Config.config.connectsuccess)
                {
                    CommonForm cf = new CommonForm();
                    cf.signal = 0;
                    Application.Run(cf);
                }
                else if (Config.config.connectsuccess)
                {
                    using (var context = new ControllerModel())
                    {
                        if (context.Database.Exists())
                        {
                            if (!UserController.countUser())
                            {
                                CommonForm cf = new CommonForm();
                                cf.signal = 1;
                                Application.Run(cf);
                            }

                        }
                        else
                        {
                            BackupFile buf = new BackupFile();
                            buf.ShowDialog();
                        }
                    }

                    Application.Run(new LoginForm());
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex);
                BackupFile buf = new BackupFile();
                buf.ShowDialog();
            }
        }
    }
}
