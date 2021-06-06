using ServerManagerFramework;

[assembly: RequireProgram("Java")]

namespace MinecraftServer
{
    public class MinecraftServerBase : ServerProcess<NewableString>
    {
        public MinecraftServerBase() : base("javaw.exe")
        {
            Arguments.Add("nogui", ArgumentPosition.right);
        }
    }
}
