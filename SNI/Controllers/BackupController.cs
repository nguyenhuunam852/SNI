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
        public static string defaultconnect;
        internal static string getbase(string v)
        {
            try
            {
                SqlConnection con = new SqlConnection(FileConfig.masterconnect());
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
        public static int RestoreDatabase(string text, string text1, string text2)
        {
            using (SqlConnection cn = new SqlConnection(FileConfig.masterconnect()))
            {
                cn.Open();
                string path = text2 + "\\" + text1;
                string sql1 = "ALTER DATABASE " + text + " set offline with rollback immediate";
                SqlCommand cmd1 = new SqlCommand(sql1, cn);
                cmd1.ExecuteNonQuery();
                string sql = "Restore database " + text + " from disk= N'" + path + "' WITH REPLACE";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();
                string sql2 = "ALTER DATABASE " + text + " set online";
                SqlCommand cmd2 = new SqlCommand(sql2, cn);
                return cmd2.ExecuteNonQuery();
            }
        }
        public static int RestoreDatabase1(string text, string text1, string text2)
        {
            using (SqlConnection cn = new SqlConnection(FileConfig.masterconnect()))
            {
                cn.Open();
                string path = text2 + "\\" + text1;
                string sql = "Restore database " + text + " from disk= N'" + path + "'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                return cmd.ExecuteNonQuery();
            }
        }
        public  static DataTable getDTB(string txtFileName, string txtFolder)
        {
            try
            {
                DataTable ds = new DataTable();
                string path = txtFolder + "\\" + txtFileName;
                SqlConnection con = new SqlConnection(FileConfig.masterconnect());
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
            using (SqlConnection cn = new SqlConnection(FileConfig.connect))
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
                string sql = "Backup database " + FileConfig.config.database + " to disk= N'" + path + "'";
                SqlCommand cmd = new SqlCommand(sql, cn);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
