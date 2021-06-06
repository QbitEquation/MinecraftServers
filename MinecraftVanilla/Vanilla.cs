using ServerManagerFramework;
using MinecraftServer;

[assembly: RequireAddon("MinecraftServer")]

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
