using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HConsole
{
    public class ConsoleMenuOptions
    {
        public EscapeKeyBehavior EscapeKeyBahavior { get; set; }
        public char EscapeCharacterMenuOption { get; set; }
        public bool LoopMenuAfterSelection { get; set; }
        public bool ShowPressEnterToContinue { get; set; }

        public ConsoleMenuOptions()
        {
            this.EscapeKeyBahavior = EscapeKeyBehavior.PressTwiceToExit;
            this.EscapeCharacterMenuOption = '0';
            this.LoopMenuAfterSelection = true;
            this.ShowPressEnterToContinue = true;
        }
    }
}
