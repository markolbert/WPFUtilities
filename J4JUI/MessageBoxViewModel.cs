
// Copyright (c) 2017 Mark A. Olbert some rights reserved
//
// This software is licensed under the terms of the MIT License
// (https://opensource.org/licenses/MIT)

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Olbert.JumpForJoy
{
    /// <summary>
    /// The view-model for a J4JMessage box object
    /// </summary>
    public class MessageBoxViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets a color, if one exists, from a ResourceDictionary, based on a key, or
        /// a default color
        /// </summary>
        /// <param name="key">the key of the color to find</param>
        /// <param name="dict">the ResourceDictionary to search</param>
        /// <param name="defaultColor">the color returned if the ResourceDictionary does
        /// not contain a key defining a Color</param>
        /// <returns>a Color</returns>
        internal static Color GetColor(string key, ResourceDictionary dict, string defaultColor)
        {
            Color retVal = (Color?)ColorConverter.ConvertFromString(defaultColor) ?? Colors.LightGray;

            try
            {
                retVal = (Color)dict[key];
            }
            catch
            {
            }

            return retVal;
        }

        /// <summary>
        /// Raised to indicate that the J4JMessageBox should close
        /// </summary>
        public event EventHandler Close;

        private string _title;
        private string _mesg;
        private MessageButtonViewModel _btn1;
        private MessageButtonViewModel _btn2;
        private MessageButtonViewModel _btn3;

        /// <summary>
        /// Creates an instance using display parameters (e.g., button colors) defined in
        /// a ResourceDictionary
        /// </summary>
        /// <param name="j4jRes">the ResourceDictionary to use to initialize the appearance
        /// of the J4JMessageBox; can be null, in which case defaults will be used</param>
        public MessageBoxViewModel( ResourceDictionary j4jRes )
        {
            Button0 = new MessageButtonViewModel(j4jRes)
            {
                Text = "Yes",
                Visibility = Visibility.Visible,
                NormalBackground = new SolidColorBrush(GetColor("J4JButton1Color", j4jRes, "#bb911e"))
            };

            Button1 = new MessageButtonViewModel(j4jRes)
            {
                Text = "No",
                Visibility = Visibility.Visible,
                NormalBackground = new SolidColorBrush(GetColor("J4JButton1Color", j4jRes, "#252315"))
            };

            Button2 = new MessageButtonViewModel(j4jRes)
            {
                Text = "Cancel",
                Visibility = Visibility.Visible,
                NormalBackground = new SolidColorBrush(GetColor("J4JButton1Color", j4jRes, "#bc513e"))
            };

            Messenger.Default.Register<ButtonClickMessage>( this, ButtonClickHandler );
            Messenger.Default.Register<ResetMarginsMessage>( this, ResetMarginsHandler );
        }

        /// <summary>
        /// The message box's window title
        /// </summary>
        public string Title
        {
            get => _title;
            set => Set<string>( ref _title, value );
        }

        /// <summary>
        /// The message dispalyed in the message box
        /// </summary>
        public string Message
        {
            get => _mesg;
            set => Set<string>( ref _mesg, value );
        }

        /// <summary>
        /// The view model for button 0, the left-most button
        /// </summary>
        public MessageButtonViewModel Button0
        {
            get => _btn1;
            set => Set<MessageButtonViewModel>( ref _btn1, value );
        }

        /// <summary>
        /// The view model for button 1
        /// </summary>
        public MessageButtonViewModel Button1
        {
            get => _btn2;
            set => Set<MessageButtonViewModel>( ref _btn2, value );
        }

        /// <summary>
        /// The view model for button 2, the right-most button
        /// </summary>
        public MessageButtonViewModel Button2
        {
            get => _btn3;
            set => Set<MessageButtonViewModel>( ref _btn3, value );
        }

        /// <summary>
        /// The ID of the button that was clicked (0, 1 or 2); the buttons
        /// are numbered from left to right, starting with 0
        /// </summary>
        public int ButtonClicked { get; private set; }

        /// <summary>
        /// Gets a list of the buttons that are currently visible
        /// </summary>
        public List<MessageButtonViewModel> VisibleButtons
        {
            get
            {
                List<MessageButtonViewModel> retVal = new List<MessageButtonViewModel>();

                if( Button0.Visibility == Visibility.Visible ) retVal.Add( Button0 );
                if( Button1.Visibility == Visibility.Visible ) retVal.Add( Button1 );
                if( Button2.Visibility == Visibility.Visible ) retVal.Add( Button2 );

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
            if( Button0.Visibility == Visibility.Visible &&
                ( Button1.Visibility == Visibility.Visible || Button2.Visibility == Visibility.Visible ) )
                Button0.Margin = new Thickness( 0, 0, 5, 0 );
            else Button0.Margin = new Thickness( 0 );

            if( Button1.Visibility == Visibility.Visible && Button2.Visibility == Visibility.Visible )
                Button1.Margin = new Thickness( 0, 0, 5, 0 );
            else Button1.Margin = new Thickness( 0 );
        }

    }
}
