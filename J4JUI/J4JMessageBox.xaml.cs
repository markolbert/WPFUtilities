
// Copyright (c) 2017 Mark A. Olbert some rights reserved
//
// This software is licensed under the terms of the MIT License
// (https://opensource.org/licenses/MIT)

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;

namespace Olbert.JumpForJoy.WPF
{
    /// <summary>
    /// Interaction logic for J4JMessageBox.xaml
    /// </summary>
    public partial class J4JMessageBox : Window
    {
        /// <summary>
        /// The name of the resource DLL used to customize the message box's appearance
        /// </summary>
        public const string ResourceID = "Olbert.J4JResources";

        public J4JMessageBox()
        {
            InitializeComponent();

            // search for a custom resource directory; do this first in the application's
            // MergedDictionaries, followed by, if that fails, the file system
            ResourceDictionary j4jRD = null;

            try
            {
                // if the current application isn't defined, skip checking its MergedDictionaries
                if( Application.Current != null )
                    j4jRD = Application.Current.Resources.MergedDictionaries
                        .SingleOrDefault( rd => rd.Source.OriginalString.Contains( ResourceID ) );

                if( j4jRD == null )
                {
                    // check the file system
                    var resDllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{ResourceID}.dll");

                    if( File.Exists( resDllPath ) )
                    {
                        Assembly.LoadFile( resDllPath );

                        var uriText =
                            $"pack://application:,,,/{ResourceID};component/DefaultResources.xaml";

                        j4jRD = new ResourceDictionary { Source = new Uri( uriText ) };
                    }
                }

            }
            catch (Exception ex)
            {
            }

            if( j4jRD != null ) Resources.MergedDictionaries.Add( j4jRD );

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
