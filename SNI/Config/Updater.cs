using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SNI.Config
{
    class Updater
    {
        public static string api;
        public static List<XMLreader> ready;
        public static List<LocalSystemCheck> delete;

        public static void checkversion()
        {
            try
            {
                Uri uri = new Uri(FileConfig.config.updateapi + "/update.xml");
                List<XMLreader> xmlreader = XMLreader.Parse(uri);
                List<LocalSystemCheck> local = LocalSystemCheck.getListFile();

                ready = new List<XMLreader>();
                delete = new List<LocalSystemCheck>();

                foreach (XMLreader xml in xmlreader)
                {
                    if (!local.Select(o => o.filepath).ToList().Contains(xml.FilePath))
                    {
                        ready.Add(xml);
                        continue;
                    }
                    foreach (LocalSystemCheck lc in local)
                    {
                        if (lc.filepath == xml.FilePath)
                        {
                            if (lc.version < xml.Version)
                            {
                                ready.Add(xml);
                                break;
                            }
                            else if(lc.version == new Version("0.0.0.0"))
                            {
                                if(new FileInfo(lc.filepath).Length != xml.Size)
                                {
                                    ready.Add(xml);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
