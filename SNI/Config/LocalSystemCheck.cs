using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SNI
{
    class LocalSystemCheck
    {
        public string filepath;
        public Version version;

        public LocalSystemCheck()
        {
           

        }
        
        public static List<LocalSystemCheck> getListFile()
        {
            List<LocalSystemCheck> lis = new List<LocalSystemCheck>(); 
            string root = Directory.GetCurrentDirectory();

            string[] folder_new = Directory.GetFiles(root, "*", SearchOption.AllDirectories);
            foreach (string file in folder_new)
            {
                LocalSystemCheck lsc = new LocalSystemCheck();
                try
                {
                    string extension = Path.GetExtension(file);
                    lsc.filepath = file.Replace(root + @"\", "");
                    if (extension == ".exe" || extension == ".dll")
                    {
                        lsc.version = Version.Parse(AssemblyName.GetAssemblyName(file).Version.ToString());
                    }
                    else
                    {
                        lsc.version = Version.Parse("0.0.0.0");
                    }
                }
                catch(Exception ex)
                {
                    lsc.version = Version.Parse("0.0.0.0");
                }
                lis.Add(lsc);
            }
            return lis;
        }
    }
}
