using ServerManagerFramework.Addons;
using ServerManagerFramework.ServerInfo;
using ServerManagerFramework.Servers;
using System.Collections.Generic;
using System.IO;

[assembly: Require("Java", ItemType.ExeInstaller, DownloadURL = "https://javadl.oracle.com/webapps/download/AutoDL?BundleId=244554_d7fc238d0cbf4b0dac67be84580cfb4b")]
[assembly: Require("Java(TM) SE Development Kit", ItemType.ExeInstaller, DownloadURL = "https://www.oracle.com/java/technologies/javase-jdk16-downloads.html")]

namespace MinecraftServer
{

    [HasIcon(Filter = "PNG files (.png)|*.png", ToolTip = "The icon size must be 64 by 64 pixels")]
    public class MinecraftServer : Server, IHasLog, IHasServerInfoItems, IHasStartArgs
    {
        public MinecraftServer() : base()
        {
            StartInfo.FileName = "javaw.exe";
        }

        public override void Initialized()
        {
            if (Arguments == null)
            {
                Arguments = DefaultArgs;
            }
        }

        public string LogFolder => "logs";

        protected virtual string DefaultArgs => "nogui";
        public string Arguments
        {
            get => Config.GetValue("arguments");
            set => Config.SetValue("arguments", value);
        }

        public override void Start()
        {
            StartInfo.Arguments = Arguments;

            base.Start();
        }

        public virtual IEnumerable<ServerInfoItem> InitializeItems()
        {
            List<ServerInfoItem> items = new();

            string propertiesFilePath = Path.Combine(Directory, "server.properties");

            if (File.Exists(propertiesFilePath))
            {
                items.Add(new ServerInfoItem("PROPERTIES", new ServerProperties(this)));
            }

            return items;
        }
    }
}
