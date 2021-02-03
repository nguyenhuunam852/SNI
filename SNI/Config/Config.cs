using Newtonsoft.Json;
using SNI.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
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
        public string apptoken;
        public string usertoken;
        public string reportapi;
        public string updateapi;


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
                connect = getconnect();
                r.Close();
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
        public static bool SaveBranch(string branchid,string apptoken,string usetoken)
        {
            try
            {
                Config.config.MaChiNhanh = branchid;
                Config.config.apptoken = apptoken;
                Config.config.usertoken = usetoken;
                Config.WriteFile();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool SaveApi(string reportapi, string updateapi)
        {
            try
            {
                Config.config.reportapi = reportapi;
                Config.config.updateapi = updateapi;
              
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
                    if(!RoleController.checkRole())
                    {
                        RoleController.AddRoles();
                    }
                   
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public static void CreateConnect(string servername, string username, string password,string database,int save)
        {
            Config.config.servername = servername;
            Config.config.username = username;
            Config.config.password = password;
            Config.config.database = database;
            if(save==1)
             WriteFile();
           
            connect = String.Format(@"Data Source={0};Initial Catalog={1};User ID= {2};Password= {3}", servername,database,username,password);
        }
        public static string getconnect()
        {
            return String.Format(@"Data Source={0};Initial Catalog={1};User ID= {2};Password= {3}", config.servername, config.database, config.username, config.password);

        }
        public static bool testConnect()
        {
            try
            {
                using (var context = new ControllerModel())
                {
                    context.Database.Connection.Open();
                    context.Database.Connection.Close();

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
