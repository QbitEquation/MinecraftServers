using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace MinecraftServer
{
    /// <summary>
    /// Interaction logic for ServerProperty.xaml
    /// </summary>
    public partial class ServerProperty : StackPanel
    {
        public static event EventHandler SaveNeededChanged;

        public static readonly DependencyProperty LineProperty =
                DependencyProperty.Register(
                        nameof(Line),
                        typeof(PropertyString),
                        typeof(ServerProperty),
                        new PropertyMetadata(OnLineChanged));

        private static void OnLineChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ServerProperty serverProperty = d as ServerProperty;
            PropertyString propertyString = e.NewValue as PropertyString;

            string formattedName = propertyString.Name;
            formattedName = formattedName.Replace('-', ' ');
            formattedName = formattedName.ToUpper(CultureInfo.InvariantCulture);

            serverProperty.FormattedName = formattedName;

            serverProperty.Value.Text = propertyString.Value;
        }

        public PropertyString Line
        {
            get => (PropertyString)GetValue(LineProperty);
            set => SetValue(LineProperty, value);
        }

        public string FormattedName { get; set; }

        public ServerProperty()
        {
            InitializeComponent();
        }

        private void PropertyValueChanged(object sender, RoutedEventArgs e)
        {
            string newValue = ((TextBox)sender).Text;

            bool oldMatch = Line.Matches;

            Line.Value = newValue;

            if (oldMatch != Line.Matches)
            {
                SaveNeededChanged.Invoke(this, EventArgs.Empty);
            }
        }

        private void SelectAllText(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
    }
}