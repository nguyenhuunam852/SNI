using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace SNI.Controllers
{
    class BackupController
    {
        private static string addzero(int a)
        {
            if (a < 10) return "0" + a.ToString();
            return a.ToString();
        }
        internal static string getbase(string v)
        {
            try
            {
                SqlConnection con = new SqlConnection(Config.connect);
                con.Open();
                string path = Path.GetDirectoryName(v);
                if (Directory.Exists(path) == true)
                {
                    string sql = "SELECT b.name FROM sys.master_files a join sys.databases b on a.database_id = b.database_id where a.physical_name =N'" + v + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    return cmd.ExecuteScalar().ToString();
                }
                return null;

            }
            catch
            {
                return null;
            }
        }
        public static DataTable getDTB(string txtFileName, string txtFolder)
        {
            try
            {
                DataTable ds = new DataTable();
                string path = txtFolder + "\\" + txtFileName;
                SqlConnection con = new SqlConnection(Config.connect);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "restore filelistonly from disk= N'" + path + "'";
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }

        public static int BackupDatabase(string folder)
        {
            using (SqlConnection cn = new SqlConnection(Config.connect))
            {
                string name =
                   addzero(DateTime.Now.Day)
                   + addzero(DateTime.Now.Month)
                   + DateTime.Now.Year
                   + "_"
                   + addzero(DateTime.Now.Hour)
                   + addzero(DateTime.Now.Minute)
                   + addzero(DateTime.Now.Second);
                cn.Open();
                string path = folder + "\\" + name + ".bak";
                string sql = "Backup database " + Config.config.database + " to disk= N'" + path + "'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
