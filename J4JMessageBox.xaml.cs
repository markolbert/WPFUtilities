using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Olbert.JumpForJoy.WPF
{
    /// <summary>
    /// Interaction logic for J4JMessageBox.xaml
    /// </summary>
    public partial class J4JMessageBox : Window
    {
        public J4JMessageBox()
        {
            InitializeComponent();

            MouseDown += J4JMessageBox_MouseDown;

            ViewModel = new MessageBoxViewModel();
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
