using System;
using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Olbert.JumpForJoy
{
    public class MessageButtonViewModel : ViewModelBase
    {
        private string _text;
        private Visibility _visibility;
        private Brush _normalBkgnd;
        private Brush _hiliteBkgnd;
        private Thickness _margin;
        private bool _isDefault;

        public MessageButtonViewModel( ResourceDictionary j4jRes )
        {
            HighlightedBackground = new SolidColorBrush(
                MessageBoxViewModel.GetColor( "J4JButtonHighlightColor", j4jRes, "Orange" ) );

            Margin = new Thickness( 0 );

            ButtonClick = new RelayCommand<int>( ButtonClickHandler );
        }

        public string Text
        {
            get => _text;
            set
            {
                Set<string>( ref _text, value );

                Visibility = String.IsNullOrEmpty( value ) ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public Visibility Visibility
        {
            get => _visibility;
            set
            {
                Set<Visibility>( ref _visibility, value ); 
                Messenger.Default.Send<ResetMarginsMessage>(new ResetMarginsMessage());
            }
        }

        public Brush NormalBackground
        {
            get => _normalBkgnd;
            set => Set<Brush>(ref _normalBkgnd, value);
        }

        public Brush HighlightedBackground
        {
            get => _hiliteBkgnd;
            set => Set<Brush>(ref _hiliteBkgnd, value);
        }

        public Thickness Margin
        {
            get => _margin;
            set => Set<Thickness>( ref _margin, value );
        }

        public bool IsDefault
        {
            get => _isDefault;
            set => Set<bool>( ref _isDefault, value );
        }

        public RelayCommand<int> ButtonClick { get; }

        private void ButtonClickHandler( int obj )
        {
            Messenger.Default.Send<ButtonClickMessage>( new ButtonClickMessage( obj ) );
        }
    }
}
