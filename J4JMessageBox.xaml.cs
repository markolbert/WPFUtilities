using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Command;
using Olbert.JumpForJoy;
using Olbert.JumpForJoy.Annotations;

namespace Olbert.LanHistory
{
    /// <summary>
    /// Interaction logic for J4JMessageBox.xaml
    /// </summary>
    public partial class J4JMessageBox : Window
    {
        public static int Show( string message, string title = null, string btn1Text = null, string btn2Text = null, string btn3Text = null )
        {
            var msgBox = new J4JMessageBox();

            msgBox.Model.Message = message;
            msgBox.Model.Title = title;

            if ( String.IsNullOrEmpty( btn1Text ) && String.IsNullOrEmpty( btn2Text ) &&
                String.IsNullOrEmpty( btn3Text ) )
                msgBox.Model.Button1 = "Okay";
            else msgBox.Model.Button1 = btn1Text;

            msgBox.Model.Button2 = btn2Text;
            msgBox.Model.Button3 = btn3Text;

            msgBox.DataContext = msgBox.Model;

            msgBox.ShowDialog();

            return msgBox._btnClicked;
        }

        private int _btnClicked;

        private J4JMessageBox()
        {
            InitializeComponent();

            MouseDown += J4JMessageBox_MouseDown;

            Model = new MessageBoxModel();
            Model.Close += Model_Close;
        }

        private void J4JMessageBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if( e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Model_Close(object sender, EventArgs e)
        {
            _btnClicked = Model.ButtonClicked;
            Close();
        }

        private MessageBoxModel Model { get; }
    }
}
