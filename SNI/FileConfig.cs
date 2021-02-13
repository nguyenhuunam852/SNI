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
    class FileConfig
    {
        public static FileConfig config;

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
        public string codeGroup;
        public string defaultFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SNI");


        public DateTime reportstart;
        public DateTime reportfinish;

        public bool connectsuccess;
        public static string connect;
        private static string currentfile= Directory.GetCurrentDirectory();
        public static void WriteFile()
        {
            string json = JsonConvert.SerializeObject(config);
            System.IO.File.WriteAllText(config.defaultFolder+@"\config.json", json);
        }
        public static void ReadFile()
        {
            config = new FileConfig();
            if (!Directory.Exists(config.defaultFolder))
            {
                Directory.CreateDirectory(config.defaultFolder);
            }
            if (File.Exists(config.defaultFolder+@"\config.json") && new FileInfo(config.defaultFolder+@"\config.json").Length > 0)
            {
                using (StreamReader r = new StreamReader(config.defaultFolder + @"\config.json"))
                {
                    string json = r.ReadToEnd();
                    FileConfig items = JsonConvert.DeserializeObject<FileConfig>(json);
                    config = items;
                    connect = getconnect();
                    r.Close();
                }
            }
            else
            {
                File.Create(config.defaultFolder + @"\config.json").Close();
                
                config.MaChiNhanh = "";
                config.password = "";
                config.reportapi = "";
                config.reportfinish = DateTime.Now;
                config.reportstart = DateTime.Now;
                config.servername = "";
                config.updateapi = "";
                config.username = "";
                config.usertoken = "";
                config.workingtime = 0;
                config.database = "";
                config.connectsuccess = false;
                config.codeGroup = "";
                config.apptoken = "";
                WriteFile();
                ReadFile();
            }
        }
        public static bool SaveTime(string[] list,DateTime a,DateTime b)
        {
            try
            {
                FileConfig.config.workingtime = int.Parse(list[0]) * 60 + int.Parse(list[1]);
                FileConfig.config.reportstart = a;
                FileConfig.config.reportfinish = b;
                FileConfig.WriteFile();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool SaveBranch(string branchid)
        {
            try
            {
                FileConfig.config.MaChiNhanh = branchid;

                FileConfig.WriteFile();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool SaveApi(string reportapi, string updateapi, string apptoken, string usetoken,string codegroup)
        {
            try
            {

                FileConfig.config.reportapi = reportapi;
                FileConfig.config.updateapi = updateapi;
                FileConfig.config.apptoken = apptoken;
                FileConfig.config.usertoken = usetoken;
                FileConfig.config.codeGroup = codegroup;

                FileConfig.WriteFile();
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
            FileConfig.config.servername = servername;
            FileConfig.config.username = username;
            FileConfig.config.password = password;
            FileConfig.config.database = database;
            if(save==1)
             WriteFile();
           
            connect = String.Format(@"Data Source={0};Initial Catalog={1};User ID= {2};Password= {3}", servername,database,username,password);
        }
        public static string getconnect()
        {
            return String.Format(@"Data Source={0};Initial Catalog={1};User ID= {2};Password= {3}", config.servername, config.database, config.username, config.password);
        }
        public static string masterconnect()
        {
            return String.Format(@"Data Source={0};Initial Catalog={1};User ID= {2};Password= {3}", config.servername,"master", config.username, config.password);
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
