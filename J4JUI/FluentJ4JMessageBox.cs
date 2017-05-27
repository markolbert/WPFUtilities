
// Copyright (c) 2017 Mark A. Olbert some rights reserved
//
// This software is licensed under the terms of the MIT License
// (https://opensource.org/licenses/MIT)

using System.Windows;
using System.Windows.Media;

namespace Olbert.JumpForJoy.WPF
{
    /// <summary>
    /// Extensions providing a fluent interface to configuring a J4JMessageBox object
    /// 
    /// The buttons are numbered from left to right, starting with 0 and ending with 2
    /// </summary>
    public static class FluentJ4JMessageBox
    {
        /// <summary>
        /// Sets the text for each of the three buttons
        /// </summary>
        /// <param name="msgBox">the J4JMessageBox object being modified</param>
        /// <param name="btn0">button 0 display text</param>
        /// <param name="btn1">button 1 display text</param>
        /// <param name="btn2">button 2 display text</param>
        /// <returns>the J4JMessageBox object being configured</returns>
        public static J4JMessageBox ButtonText( this J4JMessageBox msgBox, string btn0, string btn1 = null,
            string btn2 = null )
        {
            if( msgBox != null )
            {
                msgBox.ViewModel.Button0.Text = btn0;
                msgBox.ViewModel.Button1.Text = btn1;
                msgBox.ViewModel.Button2.Text = btn2;
            }

            return msgBox;
        }

        /// <summary>
        /// Sets the normal (i.e., unhighlighted) color for each of the three buttons
        /// </summary>
        /// <param name="msgBox">the J4JMessageBox object being modified</param>
        /// <param name="btn0">button 0 normal color</param>
        /// <param name="btn1">button 1 normal color</param>
        /// <param name="btn2">button 2 normal color</param>
        /// <returns>the J4JMessageBox object being configured</returns>
        public static J4JMessageBox ButtonNormalColors( this J4JMessageBox msgBox, Color btn0, Color? btn1,
            Color? btn2 )
        {
            if( msgBox != null )
            {
                msgBox.ViewModel.Button0.NormalBackground = new SolidColorBrush( btn0 );

                if( btn1.HasValue ) msgBox.ViewModel.Button1.NormalBackground = new SolidColorBrush( btn1.Value );
                if( btn2.HasValue ) msgBox.ViewModel.Button2.NormalBackground = new SolidColorBrush( btn2.Value );
            }

            return msgBox;
        }

        /// <summary>
        /// Sets the highlighted color for each of the three buttons
        /// </summary>
        /// <param name="msgBox">the J4JMessageBox object being modified</param>
        /// <param name="btn0">button 0 highlight color</param>
        /// <param name="btn1">button 1 highlight color; the default is null, meaning
        /// "use the btn0 value"</param>
        /// <param name="btn2">button 2 highlight color; the default is null, meaning
        /// "use the btn0 value"</param>
        /// <returns>the J4JMessageBox object being configured</returns>
        public static J4JMessageBox ButtonHiliteColors(this J4JMessageBox msgBox, Color btn0, Color? btn1 = null,
            Color? btn2 = null)
        {
            if (msgBox != null)
            {
                msgBox.ViewModel.Button0.HighlightedBackground = new SolidColorBrush(btn0);

                msgBox.ViewModel.Button1.HighlightedBackground = btn1.HasValue
                    ? new SolidColorBrush( btn1.Value )
                    : msgBox.ViewModel.Button0.HighlightedBackground;

                msgBox.ViewModel.Button2.HighlightedBackground = btn2.HasValue
                    ? new SolidColorBrush(btn2.Value)
                    : msgBox.ViewModel.Button0.HighlightedBackground;
            }

            return msgBox;
        }

        /// <summary>
        /// Sets the visibility for each of the three buttons; true means 'Visible',
        /// false means 'Collapsed'
        /// </summary>
        /// <param name="msgBox">the J4JMessageBox object being modified</param>
        /// <param name="btn0">button 0 visibility flag</param>
        /// <param name="btn1">button 1 visibility flag</param>
        /// <param name="btn2">button 2 visibility flag</param>
        /// <returns>the J4JMessageBox object being configured</returns>
        public static J4JMessageBox ButtonVisibility(this J4JMessageBox msgBox, bool btn0, bool btn1, bool btn2)
        {
            if (msgBox != null)
            {
                msgBox.ViewModel.Button0.Visibility = btn0 ? Visibility.Visible : Visibility.Collapsed;
                msgBox.ViewModel.Button1.Visibility = btn1 ? Visibility.Visible : Visibility.Collapsed;
                msgBox.ViewModel.Button2.Visibility = btn2 ? Visibility.Visible : Visibility.Collapsed;
            }

            return msgBox;
        }

        /// <summary>
        /// Configures button 0
        /// </summary>
        /// <param name="msgBox">the J4JMessageBox object being modified</param>
        /// <param name="text">the button's display text</param>
        /// <param name="visible">a flag indicating whether or not the button is visible (true) or
        /// collapsed (false); default is true/visible</param>
        /// <param name="normalBkgnd">the normal (i.e., unhighlighted) color of the button; the default is 
        /// null, meaning "use the system-configured color"</param>
        /// <param name="hiliteBkgnd">the highlighted color of the button; the default is 
        /// null, meaning "use the system-configured value"</param>
        /// <returns>the J4JMessageBox object being configured</returns>
        public static J4JMessageBox Button0( this J4JMessageBox msgBox, string text, bool visible = true,
            Color? normalBkgnd = null,
            Color? hiliteBkgnd = null )
        {
            if( msgBox != null )
                SetValues( msgBox.ViewModel.Button0, text, visible, normalBkgnd, hiliteBkgnd );

            return msgBox;
        }

        /// <summary>
        /// Configures button 1
        /// </summary>
        /// <param name="msgBox">the J4JMessageBox object being modified</param>
        /// <param name="text">the button's display text</param>
        /// <param name="visible">a flag indicating whether or not the button is visible (true) or
        /// collapsed (false); default is true/visible</param>
        /// <param name="normalBkgnd">the normal (i.e., unhighlighted) color of the button; the default is 
        /// null, meaning "use the system-configured color"</param>
        /// <param name="hiliteBkgnd">the highlighted color of the button; the default is 
        /// null, meaning "use the system-configured value"</param>
        /// <returns>the J4JMessageBox object being configured</returns>
        public static J4JMessageBox Button1(this J4JMessageBox msgBox, string text, bool visible = true,
            Color? normalBkgnd = null,
            Color? hiliteBkgnd = null)
        {
            if (msgBox != null)
                SetValues(msgBox.ViewModel.Button1, text, visible, normalBkgnd, hiliteBkgnd);

            return msgBox;
        }

        /// <summary>
        /// Configures button 2
        /// </summary>
        /// <param name="msgBox">the J4JMessageBox object being modified</param>
        /// <param name="text">the button's display text</param>
        /// <param name="visible">a flag indicating whether or not the button is visible (true) or
        /// collapsed (false); default is true/visible</param>
        /// <param name="normalBkgnd">the normal (i.e., unhighlighted) color of the button; the default is 
        /// null, meaning "use the system-configured color"</param>
        /// <param name="hiliteBkgnd">the highlighted color of the button; the default is 
        /// null, meaning "use the system-configured value"</param>
        /// <returns>the J4JMessageBox object being configured</returns>
        public static J4JMessageBox Button2(this J4JMessageBox msgBox, string text, bool visible = true,
            Color? normalBkgnd = null,
            Color? hiliteBkgnd = null)
        {
            if (msgBox != null)
                SetValues(msgBox.ViewModel.Button2, text, visible, normalBkgnd, hiliteBkgnd);

            return msgBox;
        }

        /// <summary>
        /// Sets the default button
        /// </summary>
        /// <param name="msgBox">the J4JMessageBox object being modified</param>
        /// <param name="buttonNum">the ID of the default button; valid values are 0, 1 or 2 (all
        /// other values prevent any button from being the default)</param>
        /// <returns>the J4JMessageBox object being configured</returns>
        public static J4JMessageBox DefaultButton( this J4JMessageBox msgBox, int buttonNum )
        {
            if( msgBox != null )
            {
                msgBox.ViewModel.Button0.IsDefault = buttonNum == 0;
                msgBox.ViewModel.Button1.IsDefault = buttonNum == 1;
                msgBox.ViewModel.Button2.IsDefault = buttonNum == 2;
            }

            return msgBox;
        }

        /// <summary>
        /// Sets the window title of the message box
        /// </summary>
        /// <param name="msgBox">the J4JMessageBox object being modified</param>
        /// <param name="title">the window title; null or empty values are ignored</param>
        /// <returns>the J4JMessageBox object being configured</returns>
        public static J4JMessageBox Title( this J4JMessageBox msgBox, string title )
        {
            if( msgBox != null ) msgBox.ViewModel.Title = title;

            return msgBox;
        }

        /// <summary>
        /// Sets the message to display
        /// </summary>
        /// <param name="msgBox">the J4JMessageBox object being modified</param>
        /// <param name="mesg">the message to display; null or empty messages are ignored</param>
        /// <returns>the J4JMessageBox object being configured</returns>
        public static J4JMessageBox Message( this J4JMessageBox msgBox, string mesg )
        {
            if (msgBox != null) msgBox.ViewModel.Message = mesg;

            return msgBox;
        }

        /// <summary>
        /// Displays the message box modally, and returns the button ID (0, 1, or 2) of the
        /// button clicked by the user
        /// </summary>
        /// <param name="msgBox">the J4JMessageBox to display</param>
        /// <returns>0, 1 or 2, depending on which button was clicked</returns>
        public static int ShowMessageBox( this J4JMessageBox msgBox )
        {
            if( msgBox == null ) return -1;

            var visButtons = msgBox.ViewModel.VisibleButtons;
            if( visButtons.Count == 1 )
            {
                msgBox.ViewModel.Button0.IsDefault = false;
                msgBox.ViewModel.Button1.IsDefault = false;
                msgBox.ViewModel.Button2.IsDefault = false;

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