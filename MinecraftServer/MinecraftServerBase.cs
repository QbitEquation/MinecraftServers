﻿using ServerManagerFramework;

[assembly: RequireProgram("Java", DownloadURL = "https://javadl.oracle.com/webapps/download/AutoDL?BundleId=244554_d7fc238d0cbf4b0dac67be84580cfb4b")]

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
