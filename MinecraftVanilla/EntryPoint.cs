using ServerManagerFramework.Installing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace MinecraftVanilla
{
    public static class EntryPoint
    {
        public static void AddonLoaded()
        {
            Installables.SetInstallable("MC Vanilla", new Installable(Array.Empty<UIElement>(), typeof(Vanilla), InstallVanilla));
        }

        private const string DOWNLOADURL = "https://launcher.mojang.com/v1/objects/a16d67e5807f57fc4e550299cf20226194497dc2/server.jar";

        private static async IAsyncEnumerable<Progress> InstallVanilla(string path)
        {
            yield return new Progress()
            {
                Text = "Downloading server.jar",
                Percentage = 0

            };

            string eulaPath = Path.Combine(path, "eula.txt");
            await File.WriteAllTextAsync(eulaPath, "eula = true");

            using WebClient webClient = new();
            string fileName = Path.Combine(path, "server.jar");

            TaskCompletionSource<int> TCS = new();
            bool resultSet = false;
            int oldPercentage = -1;

            webClient.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
            {
                if (resultSet || oldPercentage == e.ProgressPercentage)
                {
                    return;
                }

                resultSet = true;
                oldPercentage = e.ProgressPercentage;
                TCS.SetResult(e.ProgressPercentage);
            };

            webClient.DownloadFileAsync(new Uri(DOWNLOADURL), fileName);

            while (webClient.IsBusy)
            {
                int progress = await TCS.Task;
                TCS = new();
                resultSet = false;

                yield return new Progress()
                {
                    Percentage = progress
                };

                await Task.Delay(100);
            }
        }
    }
}
