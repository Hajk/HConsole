using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using HConsole.Properties;

namespace HConsole
{
    internal static class Controls
    {
        public static T Ask<T>(string question) 
        {
            Console.Write(question + ": ");
            string answer = Console.ReadLine();
            var parsedAnswer = Convertor.TryParse<T>(answer);

            bool askAgin = true;
            do
            {
                // If have value of expected type
                if (parsedAnswer.Equals(default(T)))
                {
                    Console.WriteLine(Resources.error_wrong_answer_type);
                    askAgin = true;
                }
                else
                {
                    askAgin = false;
                }

            } while (askAgin);

            return parsedAnswer;
        }

        public static SecureString Password(string question)
        {
            Console.Write(question + ": ");

            SecureString pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }

            Console.WriteLine();

            return pwd;
        }

    }
}
