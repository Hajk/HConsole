﻿
namespace HConsole
{
    // facade for provide main functionality as static class

    /// <summary>
    /// Console UI functions as static class
    /// </summary>
    public static class CUI
    {

        #region App
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appName"></param>
        public static void WriteAppHeader()
        {
            App.WriteAppHeader();
        }
        #endregion


        #region Console
        /// <summary>
        /// 
        /// </summary>
        public static void WriteHorizontalLine()
        {
            ConsoleCore.WriteHorizontalLine();
        }

        /// <summary>
        /// wait for user input
        /// <param name="message">optional message</param>
        /// </summary>
        public static void WaitForInput(string message = "")
        {
            ConsoleCore.WaitForInput(message);
        }

        /// <summary>
        /// Write text wrapped with arm
        /// </summary>
        /// <param name="text">Text for wrapping</param>
        /// <param name="fillToken">Token for creating arms</param>
        public static void WriteText(string text, Align align = Align.Left, char fillToken = ' ')
        {
            ConsoleCore.WriteText(text, align, fillToken);
        }
        #endregion



        
    }
}
