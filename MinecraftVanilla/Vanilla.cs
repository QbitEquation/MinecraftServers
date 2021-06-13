using ServerManagerFramework;
using MinecraftServer;

[assembly: Require("MinecraftServer", ItemType.Addon, DownloadURL = "https://github.com/ItzTobias/MinecraftServers/releases/download/v0.1.0.0-alpha/MinecraftServer.dll")]

namespace MinecraftVanilla
{
    [ComboBoxButton]
    public class Vanilla : MinecraftServerBase
    {
        public Vanilla() : base()
        {
            Arguments.Insert(0, "-jar server.jar", ArgumentPosition.right);
        }
    }
}
