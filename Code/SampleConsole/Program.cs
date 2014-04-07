using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HConsole;

namespace SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CUI.WriteAppHeader();

            var cm = new CUIMenu();
            cm.ConsoleMenuOptions.ShowPressEnterToContinue = false;
            cm.AddMenuChoice(GenerateKey, "Generate key");
            cm.DrawMenu();


            CUI.WaitForInput();
        
        }

        private static void GenerateKey()
        {
            Console.WriteLine("This is process of generating key...");
        }
    }
}
