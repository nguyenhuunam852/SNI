using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace SNI
{
    class XMLreader
    {
        public Version Version { get; }
        public string Uri { get; }
        public string FilePath { get; }
        public string MD5 { get; }
        public string Description { get; }
        public string LaunchArgs { get; }
        public long Size { get; }

        public XMLreader(Version version, string uri, string filePath, string md5, string description, string launchArgs,long size)
        {
            Version = version;
            Uri = uri;
            FilePath = filePath;
            MD5 = md5;
            Description = description;
            LaunchArgs = launchArgs;
            Size = size;
        }

        public static List<XMLreader> Parse(Uri location)
        {
            List<XMLreader> result = new List<XMLreader>();
            Version version = null;
            string url = "", filePath = "", md5 = "", description = "", launchArgs = "";
            long size = 0;
            try
            {
                // Load the document
                ServicePointManager.ServerCertificateValidationCallback = (s, ce, ch, ssl) => true;
                XmlDocument doc = new XmlDocument();
                doc.Load(location.AbsoluteUri);

                XmlNodeList updateNodes = doc.DocumentElement.SelectNodes("/sharpUpdate/update");
                foreach (XmlNode updateNode in updateNodes)
                {
                    if (updateNode == null)
                        return null;
                    version = Version.Parse(updateNode["version"].InnerText);
                    url = updateNode["url"].InnerText;
                    filePath = updateNode["filePath"].InnerText;
                    md5 = updateNode["md5"].InnerText;
                    description = updateNode["description"].InnerText;
                    launchArgs = updateNode["launchArgs"].InnerText;
                    size = long.Parse(updateNode["size"].InnerText);

                    result.Add(new XMLreader(version, url, filePath, md5, description, launchArgs,size));
                }

                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
