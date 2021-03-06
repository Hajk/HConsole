﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HConsole
{
    public static class ConsoleCore
    {
        public static void WriteHorizontalLine()
        {
            Console.WriteLine(new string(Constants.TOKEN1, Constants.FRAME_WIDTH));
        }

        public static void WaitForInput(string message = "")
        {
            if (string.IsNullOrWhiteSpace(message)) message = "Press any keyboard button for continue...";
            
            Console.WriteLine(Environment.NewLine + message);
            Console.ReadLine();
        }

        public static void WriteText(string text, Align align = Align.Left, char fillToken = ' ', char sideToken = ' ')
        {
            string output = string.Empty;

            switch (align)
            {
                case Align.Left:
                    goto default;

                case Align.Right:
                    throw new NotImplementedException();

                case Align.Center:
                    int armLength = (Constants.FRAME_WIDTH - text.Length) / 2 - 1; // (frame - text) / 2 - (sideToken * 2)
                    string arm = new string(fillToken, armLength);
                    string oddToken = text.Length % 2 != 0 ? string.Empty : fillToken.ToString();
                    output = sideToken + arm + text + arm + oddToken + sideToken;
                    break;

                default:
                    output = text;
                    break;
            }



            
            Console.WriteLine(output);
        }
    }
}
