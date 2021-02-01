using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SNI
{
    class Config
    {
        public static Config config;

        public string MaChiNhanh;
        public int workingtime;
        public string servername;
        public string username;
        public string database;
        public string password;
        public DateTime reportstart;
        public DateTime reportfinish;

        public bool connectsuccess;
        public static string connect;
        private static string currentfile= Directory.GetCurrentDirectory();
        public static void WriteFile()
        {
            string json = JsonConvert.SerializeObject(config);
            System.IO.File.WriteAllText("config.json", json);
        }
        public static void ReadFile()
        {
            using (StreamReader r = new StreamReader("config.json"))
            {
                string json = r.ReadToEnd();
                Config items = JsonConvert.DeserializeObject<Config>(json);
                config = items;
            }
        }
        public static bool SaveTime(string[] list,DateTime a,DateTime b)
        {
            try
            {
                Config.config.workingtime = int.Parse(list[0]) * 60 + int.Parse(list[1]);
                Config.config.reportstart = a;
                Config.config.reportfinish = b;
                Config.WriteFile();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool CheckDatabase()
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    context.Database.CreateIfNotExists();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public static void CreateConnect(string servername, string username, string password,string database)
        {
            Config.config.servername = servername;
            Config.config.username = username;
            Config.config.password = password;
            Config.config.database = database;
            WriteFile();
           
            connect = String.Format(@"Data Source={0};Initial Catalog={1};User ID= {2};Password= {3}", servername,database,username,password);
        }
        
        public static bool testConnect()
        {
            try
            {
                using (var context = new ControllerModel())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
