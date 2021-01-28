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
        public string password;
        public string success;
        public static string connect;
        private static string currentfile= Directory.GetCurrentDirectory();
        public static void LoadFile()
        {
            var config = new Config
            {
                
            };
            string json = JsonConvert.SerializeObject(config);

            //write string to file
            System.IO.File.WriteAllText("config.json", json);
        }
        public static void ReadFile()
        {
            using (StreamReader r = new StreamReader("config.json"))
            {
                string json = r.ReadToEnd();
                Config items = JsonConvert.DeserializeObject<Config>(json);
                config = items;
                connect = @"Data Source = NAM-PC\SQLEXPRESS; Initial Catalog = SNI; Integrated Security = True";

            }
        }
    }
}
