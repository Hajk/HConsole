using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HConsole
{
    internal static class Helper
    {
        public static bool GetReadKeyChar(ConsoleMenuOptions options, IEnumerable<char> keyChoices, out char readKey)
        {
            readKey = ' ';
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    if (options.EscapeKeyBahavior == EscapeKeyBehavior.PressOnceToExit)
                        return false;
                    else if (options.EscapeKeyBahavior == EscapeKeyBehavior.PressTwiceToExit)
                    {
                        if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                            return false;
                    }
                }
                else if (options.EscapeCharacterMenuOption != ' ' && key.KeyChar == options.EscapeCharacterMenuOption)
                    return false;
                else if (keyChoices.Any(c => c.ToString().ToUpper() == key.KeyChar.ToString().ToUpper()))
                {
                    readKey = key.KeyChar;
                    return true;
                }
            }
        }

        public static bool GetReadKeyString(ConsoleMenuOptions options, IEnumerable<string> keyChoices, out string readString) 
        {
            readString = "";
            return false;
        }


        public static void PressEnterToContinue(string message = "Press ENTER to continue...")
        {
            Console.WriteLine(message);
            Console.WriteLine();
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    return;
            }
        }
    }
}
