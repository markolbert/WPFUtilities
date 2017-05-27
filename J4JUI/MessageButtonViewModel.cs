
// Copyright (c) 2017 Mark A. Olbert some rights reserved
//
// This software is licensed under the terms of the MIT License
// (https://opensource.org/licenses/MIT)

using System;
using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Olbert.JumpForJoy
{
    /// <summary>
    /// The view-model for one of the displayed buttons
    /// </summary>
    public class MessageButtonViewModel : ViewModelBase
    {
        private string _text;
        private Visibility _visibility;
        private Brush _normalBkgnd;
        private Brush _hiliteBkgnd;
        private Thickness _margin;
        private bool _isDefault;

        /// <summary>
        /// Creates an instance using display parameters (e.g., button colors) defined in
        /// a ResourceDictionary
        /// </summary>
        /// <param name="j4jRes">the ResourceDictionary to use to initialize the appearance
        /// of the J4JMessageBox; can be null, in which case defaults will be used</param>
        public MessageButtonViewModel( ResourceDictionary j4jRes )
        {
            HighlightedBackground = new SolidColorBrush(
                MessageBoxViewModel.GetColor( "J4JButtonHighlightColor", j4jRes, "Orange" ) );

            Margin = new Thickness( 0 );

            ButtonClick = new RelayCommand<int>( ButtonClickHandler );
        }

        /// <summary>
        /// The text displayed in the button
        /// </summary>
        public string Text
        {
            get => _text;
            set
            {
                Set<string>( ref _text, value );

                Visibility = String.IsNullOrEmpty( value ) ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        /// <summary>
        /// The button's visibility
        /// </summary>
        public Visibility Visibility
        {
            get => _visibility;
            set
            {
                Set<Visibility>( ref _visibility, value ); 
                Messenger.Default.Send<ResetMarginsMessage>(new ResetMarginsMessage());
            }
        }

        /// <summary>
        /// The button's normal (i.e., unhighlighted) color
        /// </summary>
        public Brush NormalBackground
        {
            get => _normalBkgnd;
            set => Set<Brush>(ref _normalBkgnd, value);
        }

        /// <summary>
        /// The button's highlighted color
        /// </summary>
        public Brush HighlightedBackground
        {
            get => _hiliteBkgnd;
            set => Set<Brush>(ref _hiliteBkgnd, value);
        }

        /// <summary>
        /// The button's margin
        /// </summary>
        public Thickness Margin
        {
            get => _margin;
            set => Set<Thickness>( ref _margin, value );
        }

        /// <summary>
        /// A flag indicating whether or not the button is the default button
        /// for the message box
        /// </summary>
        public bool IsDefault
        {
            get => _isDefault;
            set => Set<bool>( ref _isDefault, value );
        }

        /// <summary>
        /// The MvvmLight RelayCommand activated when the button is clicked
        /// </summary>
        public RelayCommand<int> ButtonClick { get; }

        private void ButtonClickHandler( int obj )
        {
            Messenger.Default.Send<ButtonClickMessage>( new ButtonClickMessage( obj ) );
        }
    }
}
