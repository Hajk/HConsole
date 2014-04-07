using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HConsole
{
    public class MenuChoice
    {
        public char KeyCharacter { get; set; }
        public string Description { get; set; }
        public Action Action { get; set; }

        public MenuChoice(Action action, string description, char keyCharacter)
            : this(action, description)
        {
            this.KeyCharacter = keyCharacter;
        }

        public MenuChoice(Action action, string description)
        {
            Description = description;
            Action = action;
        }
    }
}
