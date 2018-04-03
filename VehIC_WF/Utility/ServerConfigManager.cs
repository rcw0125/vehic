using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace VehIC_WF.Utility
{
    public class ServerConfigManager
    {
        public static readonly ServerConfigManager Instance = new ServerConfigManager();

        private ServerInfo config = new ServerInfo();
        public ServerInfo ServerInfo
        {
            get
            {
                return config;
            }
        }

        private string configFileName = "ServerConfig.xml";

        private ServerConfigManager()
        {
            Load();
        }

        public void Load()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(ServerInfo));
                XmlReader sr = XmlReader.Create(configFileName);
                config = (ServerInfo)ser.Deserialize(sr);
                sr.Close();
            }
            catch
            {
            }
            if (config == null) config = new ServerInfo();
        }

        public void Save()
        {
            try
            {
                XmlWriter wr = XmlWriter.Create(configFileName);
                XmlSerializer ser = new XmlSerializer(typeof(ServerInfo));
                ser.Serialize(wr, config);
                wr.Close();
            }
            catch (Exception e)
            {
            }
        }
    }

    [Serializable]
    public class ServerInfo
    {

        private string webService = "";

        public string WebService
        {
            get { return webService; }
            set { webService = value; }
        }

        private string _DBServer = "";

        public string DBServer
        {
            get { return _DBServer; }
            set { _DBServer = value; }
        }

    }

}
