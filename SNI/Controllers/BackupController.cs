using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SNI.Controllers
{
    class BackupController
    {
        public static int BackupDatabase(string folder)
        {
            using (SqlConnection cn = new SqlConnection(Config.connect))
            {
                string name = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString()+DateTime.Now.Second.ToString();
                cn.Open();
                string path = folder + "\\" + name + ".bak";
                string sql = "Backup database " + Config.config.database + " to disk= N'" + path + "'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
