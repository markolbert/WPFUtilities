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
