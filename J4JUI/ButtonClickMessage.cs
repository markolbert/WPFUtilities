
// Copyright (c) 2017 Mark A. Olbert some rights reserved
//
// This software is licensed under the terms of the MIT License
// (https://opensource.org/licenses/MIT)

namespace Olbert.JumpForJoy
{
    /// <summary>
    /// MvvmLight message class indicating when a button is clicked
    /// </summary>
    public class ButtonClickMessage
    {
        /// <summary>
        /// Creates an instance based on a particular button ID
        /// </summary>
        /// <param name="buttonID">the ID of the button that was clicked</param>
        public ButtonClickMessage( int buttonID )
        {
            ButtonID = buttonID;
        }

        /// <summary>
        /// The ID of the button that was clicked
        /// </summary>
        public int ButtonID { get; }
    }
}
