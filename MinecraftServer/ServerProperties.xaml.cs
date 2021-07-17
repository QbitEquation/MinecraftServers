using ServerManagerFramework.ServerInfo;
using ServerManagerFramework.Servers;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MinecraftServer
{
    /// <summary>
    /// Interaction logic for ServerProperties.xaml
    /// </summary>
    public partial class ServerProperties : ItemsControl, ISavableServerInfoItem
    {
        public ObservableCollection<PropertyString> Properties { get; set; } = new();

        public bool CanSave { get; set; }
        public Guid ID { get; set; }
        private readonly IHasDirectory directory;

        public ServerProperties(IHasDirectory directory)
        {
            InitializeComponent();

            this.directory = directory;

            ServerProperty.SaveNeededChanged += ServerProperty_SaveNeededChanged;

            ItemsSource = Properties;

            _ = LoadProperties();
        }

        private void ServerProperty_SaveNeededChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                ContentPresenter container = ItemContainerGenerator.ContainerFromIndex(i) as ContentPresenter;
                PropertyString propString = container.GetValue(ContentPresenter.ContentProperty) as PropertyString;

                if (!propString.Matches)
                {
                    if (!CanSave)
                    {
                        CanSave = true;
                        CanSaveChanged?.Invoke(this, new CanSaveChangedEventArgs(CanSave));
                    }

                    return;
                }
            }

            if (CanSave)
            {
                CanSave = false;
                CanSaveChanged?.Invoke(this, new CanSaveChangedEventArgs(CanSave));
            }
        }

#pragma warning disable 0067
        public event CanSaveChangedEventHandler CanSaveChanged;
#pragma warning restore

        private async Task LoadProperties()
        {
            string propertiesFilePath = Path.Combine(directory.Directory, "server.properties");

            using StreamReader reader = new(propertiesFilePath);

            while (!reader.EndOfStream)
            {
                string line = await reader.ReadLineAsync();

                if (!line.Contains('='))
                {
                    continue;
                }

                Properties.Add(new PropertyString(line));
            }
        }

        public void Save()
        {
            StringBuilder allProperties = new();

            for (int i = 0; i < Properties.Count; i++)
            {
                string line = Properties[i].ToString();
                allProperties.AppendLine(line);
                Properties[i] = new PropertyString(line);
            }

            string propertiesFilePath = Path.Combine(directory.Directory, "server.properties");

            _ = File.WriteAllTextAsync(propertiesFilePath, allProperties.ToString());
        }
    }
}
