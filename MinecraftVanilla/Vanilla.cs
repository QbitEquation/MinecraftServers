using ServerManagerFramework;
using MinecraftServer;

[assembly: RequireAddon("MinecraftServer", DownloadURL = "https://github-releases.githubusercontent.com/374428709/0e608280-c702-11eb-94f1-53eca7b09128?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAIWNJYAX4CSVEH53A%2F20210606%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20210606T180521Z&X-Amz-Expires=300&X-Amz-Signature=5c90d21205f089b1108e990ce2a0bd70dfdee53b196648d2a669a040a2b70944&X-Amz-SignedHeaders=host&actor_id=57042329&key_id=0&repo_id=374428709&response-content-disposition=attachment%3B%20filename%3DMinecraftServer.dll&response-content-type=application%2Foctet-stream")]

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
