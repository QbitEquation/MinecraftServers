using ServerManagerFramework;
using ServerManagerFramework.Addons;

[assembly: Require("MinecraftServer", ItemType.Addon, DownloadURL = "https://github.com/ItzTobias/MinecraftServers/releases/download/v0.1.0.0-alpha/MinecraftServer.dll")]

namespace MinecraftVanilla
{
    [ComboBoxButton("MC Vanilla")]
    public class Vanilla : MinecraftServer.MinecraftServer
    {
        protected override string DefaultArgs => "-jar server.jar nogui";

        public Vanilla() : base()
        {
        }
    }
}
