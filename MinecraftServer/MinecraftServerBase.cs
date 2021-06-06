using ServerManagerFramework;

[assembly: RequireProgram("Java", DownloadURL = "https://sdlc-esd.oracle.com/ESD6/JSCDL/jdk/8u291-b10/d7fc238d0cbf4b0dac67be84580cfb4b/JavaSetup8u291.exe?GroupName=JSC&FilePath=/ESD6/JSCDL/jdk/8u291-b10/d7fc238d0cbf4b0dac67be84580cfb4b/JavaSetup8u291.exe&BHost=javadl.sun.com&File=JavaSetup8u291.exe&AuthParam=1623003887_f422ec3982dc5a0213c5b798e8628f71&ext=.exe")]

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
