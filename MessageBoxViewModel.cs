using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Olbert.JumpForJoy
{
    public class MessageBoxViewModel : ViewModelBase
    {
        public event EventHandler Close;

        private string _title;
        private string _mesg;
        private MessageButtonViewModel _btn1;
        private MessageButtonViewModel _btn2;
        private MessageButtonViewModel _btn3;

        public MessageBoxViewModel()
        {
            Button1 = new MessageButtonViewModel
            {
                Text = "Yes",
                Visibility = Visibility.Visible,
                NormalBackground = (SolidColorBrush) new BrushConverter().ConvertFrom( "#bb911e" )
            };

            Button2 = new MessageButtonViewModel
            {
                Text = "No",
                Visibility = Visibility.Visible,
                NormalBackground = (SolidColorBrush) new BrushConverter().ConvertFrom( "#252315" )
            };

            Button3 = new MessageButtonViewModel
            {
                Text = "Cancel",
                Visibility = Visibility.Visible,
                NormalBackground = (SolidColorBrush) new BrushConverter().ConvertFrom( "#bc513e" )
            };

            Messenger.Default.Register<ButtonClickMessage>( this, ButtonClickHandler );
            Messenger.Default.Register<ResetMarginsMessage>( this, ResetMarginsHandler );
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

        public MessageButtonViewModel Button1
        {
            get => _btn1;
            set => Set<MessageButtonViewModel>( ref _btn1, value );
        }

        public MessageButtonViewModel Button2
        {
            get => _btn2;
            set => Set<MessageButtonViewModel>( ref _btn2, value );
        }

        public MessageButtonViewModel Button3
        {
            get => _btn3;
            set => Set<MessageButtonViewModel>( ref _btn3, value );
        }

        public int ButtonClicked { get; private set; }


        public List<MessageButtonViewModel> VisibleButtons
        {
            get
            {
                List<MessageButtonViewModel> retVal = new List<MessageButtonViewModel>();

                if( Button1.Visibility == Visibility.Visible ) retVal.Add( Button1 );
                if( Button2.Visibility == Visibility.Visible ) retVal.Add( Button2 );
                if( Button3.Visibility == Visibility.Visible ) retVal.Add( Button3 );

                return retVal;
            }
        }

        private void ButtonClickHandler( ButtonClickMessage clickMesg )
        {
            if( clickMesg != null )
            {
                ButtonClicked = clickMesg.ButtonID;
                Close?.Invoke( this, EventArgs.Empty );
            }
        }

        private void ResetMarginsHandler( ResetMarginsMessage obj )
        {
            if( Button1.Visibility == Visibility.Visible &&
                ( Button2.Visibility == Visibility.Visible || Button3.Visibility == Visibility.Visible ) )
                Button1.Margin = new Thickness( 0, 0, 5, 0 );
            else Button1.Margin = new Thickness( 0 );

            if( Button2.Visibility == Visibility.Visible && Button3.Visibility == Visibility.Visible )
                Button2.Margin = new Thickness( 0, 0, 5, 0 );
            else Button2.Margin = new Thickness( 0 );
        }

    }
}
