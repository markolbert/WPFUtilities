using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Olbert.JumpForJoy.WPF
{
    /// <summary>
    /// Interaction logic for J4JMessageBox.xaml
    /// </summary>
    public partial class J4JMessageBox : Window
    {
        private const string ResourceDll = "Olbert.JumpForJoy.DefaultResources";

        public J4JMessageBox()
        {
            InitializeComponent();

            // search for, and load if found, the resource dll
            ResourceDictionary j4jRD = null;

            try
            {
                var resDllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{ResourceDll}.dll");

                if (File.Exists(resDllPath))
                {
                    var resAssembly = Assembly.LoadFile(resDllPath);
                    var uriText =
                        $"pack://application:,,,/{resAssembly.GetName().Name};component/DefaultResources.xaml";

                    j4jRD =
                        new ResourceDictionary
                        {
                            Source = new Uri(uriText)
                        };

                    Resources.MergedDictionaries.Add(j4jRD);
                }
            }
            catch (Exception ex)
            {
            }

            MouseDown += J4JMessageBox_MouseDown;

            ViewModel = new MessageBoxViewModel( j4jRD );
            ViewModel.Close += Model_Close;
        }

        private void J4JMessageBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if( e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Model_Close(object sender, EventArgs e)
        {
            ButtonClicked = ViewModel.ButtonClicked;
            Close();
        }

        public MessageBoxViewModel ViewModel { get; }
        public int ButtonClicked { get; private set; }
    }
}
