using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Olbert.JumpForJoy
{
    public class MessageBoxModel : ViewModelBase
    {
        public event EventHandler Close;

        private string _title;
        private string _mesg;
        private string _btn1;
        private string _btn2;
        private string _btn3;

        public MessageBoxModel()
        {
            Button1 = "Yes";
            Button2 = "No";
            Button3 = "Cancel";

            ButtonClick = new RelayCommand<int>(ButtonClickHandler);
        }

        public string Title
        {
            get => _title;
            set => Set<string>( ref _title, value );
        }

        public string Message
        {
            get => _mesg;
            set => Set<string>( ref _mesg, value );
        }

        public string Button1
        {
            get => _btn1;
            set => Set<string>( ref _btn1, value );
        }

        public string Button2
        {
            get => _btn2;
            set => Set<string>(ref _btn2, value);
        }

        public string Button3
        {
            get => _btn3;
            set => Set<string>(ref _btn3, value);
        }

        public int ButtonClicked { get; private set; }

        public RelayCommand<int> ButtonClick { get; }

        private void ButtonClickHandler( int buttonNum )
        {
            ButtonClicked = buttonNum;

            Close?.Invoke( this, EventArgs.Empty );
        }
    }
}
