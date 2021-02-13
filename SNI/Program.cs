using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SNI.Views.Login;
using SNI.Views.FirstConfig;
using SNI.Controllers;
using SNI.Views.Setting;
using SNI.Config;

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
            FileConfig.ReadFile();
            try
            {
                try
                {
                    if (FileConfig.config.updateapi != "")
                    {
                        Updater.checkversion();
                        if (Updater.ready.Count() > 0)
                        {
                            DialogResult dlr = MessageBox.Show("Sẵn sàng cho cật nhập", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (dlr == DialogResult.OK)
                            {
                                UpdaterForm upd = new UpdaterForm();
                                upd.ShowDialog();
                                return;
                            }
                        }
                    }
                }
                catch(Exception ex)
                {

                }
                
                if (!FileConfig.config.connectsuccess)
                {
                    CommonForm cf = new CommonForm();
                    cf.signal = 0;
                    Application.Run(cf);
                }
                else if (FileConfig.config.connectsuccess)
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
