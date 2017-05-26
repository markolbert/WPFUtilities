
// Copyright (c) 2017 Mark A. Olbert some rights reserved
//
// This software is licensed under the terms of the MIT License
// (https://opensource.org/licenses/MIT)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbert.JumpForJoy
{
    public class ButtonClickMessage
    {
        public ButtonClickMessage( int buttonID )
        {
            ButtonID = buttonID;
        }

        public int ButtonID { get; }
    }
}
