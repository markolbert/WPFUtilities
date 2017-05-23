using System.Windows;
using System.Windows.Media;

namespace Olbert.JumpForJoy.WPF
{
    public static class FluentJ4JMessageBox
    {
        public static J4JMessageBox ButtonText( this J4JMessageBox msgBox, string btn1, string btn2 = null,
            string btn3 = null )
        {
            if( msgBox != null )
            {
                msgBox.ViewModel.Button1.Text = btn1;
                msgBox.ViewModel.Button2.Text = btn2;
                msgBox.ViewModel.Button3.Text = btn3;
            }

            return msgBox;
        }

        public static J4JMessageBox ButtonNormalColors( this J4JMessageBox msgBox, Color btn1, Color? btn2,
            Color? btn3 )
        {
            if( msgBox != null )
            {
                msgBox.ViewModel.Button1.NormalBackground = new SolidColorBrush( btn1 );

                if( btn2.HasValue ) msgBox.ViewModel.Button2.NormalBackground = new SolidColorBrush( btn2.Value );
                if( btn3.HasValue ) msgBox.ViewModel.Button3.NormalBackground = new SolidColorBrush( btn3.Value );
            }

            return msgBox;
        }

        public static J4JMessageBox ButtonHiliteColors(this J4JMessageBox msgBox, Color btn1, Color? btn2,
            Color? btn3)
        {
            if (msgBox != null)
            {
                msgBox.ViewModel.Button1.HighlightedBackground = new SolidColorBrush(btn1);

                msgBox.ViewModel.Button2.HighlightedBackground = btn2.HasValue
                    ? new SolidColorBrush( btn2.Value )
                    : msgBox.ViewModel.Button1.HighlightedBackground;

                msgBox.ViewModel.Button3.HighlightedBackground = btn3.HasValue
                    ? new SolidColorBrush(btn3.Value)
                    : msgBox.ViewModel.Button1.HighlightedBackground;
            }

            return msgBox;
        }

        public static J4JMessageBox ButtonVisibility(this J4JMessageBox msgBox, bool btn1, bool btn2, bool btn3)
        {
            if (msgBox != null)
            {
                msgBox.ViewModel.Button1.Visibility = btn1 ? Visibility.Visible : Visibility.Collapsed;
                msgBox.ViewModel.Button2.Visibility = btn2 ? Visibility.Visible : Visibility.Collapsed;
                msgBox.ViewModel.Button3.Visibility = btn3 ? Visibility.Visible : Visibility.Collapsed;
            }

            return msgBox;
        }

        public static J4JMessageBox Button1( this J4JMessageBox msgBox, string text, bool visible = true,
            Color? normalBkgnd = null,
            Color? hiliteBkgnd = null )
        {
            if( msgBox != null )
                SetValues( msgBox.ViewModel.Button1, text, visible, normalBkgnd, hiliteBkgnd );

            return msgBox;
        }

        public static J4JMessageBox Button2(this J4JMessageBox msgBox, string text, bool visible = true,
            Color? normalBkgnd = null,
            Color? hiliteBkgnd = null)
        {
            if (msgBox != null)
                SetValues(msgBox.ViewModel.Button2, text, visible, normalBkgnd, hiliteBkgnd);

            return msgBox;
        }

        public static J4JMessageBox Button3(this J4JMessageBox msgBox, string text, bool visible = true,
            Color? normalBkgnd = null,
            Color? hiliteBkgnd = null)
        {
            if (msgBox != null)
                SetValues(msgBox.ViewModel.Button3, text, visible, normalBkgnd, hiliteBkgnd);

            return msgBox;
        }

        public static J4JMessageBox DefaultButton( this J4JMessageBox msgBox, int buttonNum )
        {
            if( msgBox != null )
            {
                msgBox.ViewModel.Button1.IsDefault = buttonNum == 0;
                msgBox.ViewModel.Button2.IsDefault = buttonNum == 1;
                msgBox.ViewModel.Button3.IsDefault = buttonNum == 2;
            }

            return msgBox;
        }

        public static J4JMessageBox Title( this J4JMessageBox msgBox, string title )
        {
            if( msgBox != null ) msgBox.ViewModel.Title = title;

            return msgBox;
        }

        public static J4JMessageBox Message( this J4JMessageBox msgBox, string mesg )
        {
            if (msgBox != null) msgBox.ViewModel.Message = mesg;

            return msgBox;
        }

        public static int ShowMessageBox( this J4JMessageBox msgBox )
        {
            if( msgBox == null ) return -1;

            var visButtons = msgBox.ViewModel.VisibleButtons;
            if( visButtons.Count == 1 )
            {
                msgBox.ViewModel.Button1.IsDefault = false;
                msgBox.ViewModel.Button2.IsDefault = false;
                msgBox.ViewModel.Button3.IsDefault = false;

                visButtons[ 0 ].IsDefault = true;
            }

            msgBox.DataContext = msgBox.ViewModel;
            msgBox.ShowDialog();

            return msgBox.ButtonClicked;
        }

        private static void SetValues( MessageButtonViewModel btnVM, string text, bool visible, Color? normal,
            Color? hilite )
        {
            if( btnVM == null ) return;

            btnVM.Text = text;
            if( !visible ) btnVM.Visibility = Visibility.Collapsed;
            if( normal.HasValue ) btnVM.NormalBackground = new SolidColorBrush( normal.Value );
            if( hilite.HasValue )
                btnVM.HighlightedBackground = new SolidColorBrush( hilite.Value );
        }
    }
}