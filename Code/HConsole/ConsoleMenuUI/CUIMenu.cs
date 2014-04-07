using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HConsole
{
    public class CUIMenu
    {

        public string PrependMessage { get; set; }
        public List<MenuChoice> MenuChoices { get; set; }
        public ConsoleMenuOptions ConsoleMenuOptions { get; set; }

        public CUIMenu()
        {
            MenuChoices = new List<MenuChoice>();
            this.ConsoleMenuOptions = new ConsoleMenuOptions();
        }

        public CUIMenu AddMenuChoice(Action action, string description)
        {
            int keyCharVal;
            int i;
            if (MenuChoices.Any(mc => int.TryParse(mc.KeyCharacter.ToString(), out i)))
            {
                keyCharVal = MenuChoices.Where(mc => int.TryParse(mc.KeyCharacter.ToString(), out i))
                                        .Max(mc => int.Parse(mc.KeyCharacter.ToString())) + 1;
            }
            else
            {
                keyCharVal = 1;
            }

            return AddMenuChoice(action, description, char.Parse(keyCharVal.ToString()));
        }


        public CUIMenu AddMenuChoice(Action action, string description, char keyCharacter)
        {
            if (MenuChoices.Any(mc => mc.KeyCharacter.ToString().ToUpper() == keyCharacter.ToString().ToUpper()))
                throw new ArgumentException("The keyCharacter specificed has already been assigned: " + keyCharacter.ToString());
            if (keyCharacter.ToString().ToUpper() == this.ConsoleMenuOptions.EscapeCharacterMenuOption.ToString().ToUpper())
                throw new ArgumentException("The keyCharacter specified is being used as the escape character menu option");
            this.MenuChoices.Add(new MenuChoice(action, description, char.Parse(keyCharacter.ToString().ToUpper())));
            return this;
        }

        public void DrawMenu()
        {
            if (this.PrependMessage != String.Empty)
                Console.WriteLine(this.PrependMessage);

            SortMenuChoices();
            MenuChoices.ForEach(mc =>
                Console.WriteLine("  {0} - {1}", mc.KeyCharacter.ToString().ToUpper(), mc.Description));
            Console.WriteLine();

            if (this.ConsoleMenuOptions.EscapeCharacterMenuOption != ' ')
            {
                Console.WriteLine("  {0} - {1}", ConsoleMenuOptions.EscapeCharacterMenuOption.ToString().ToUpper(),
                    "Exit");
                Console.WriteLine();
            }

            char charPressed;

            if (!Helper.GetReadKeyChar(this.ConsoleMenuOptions,
                GetMenuChoicesWithExitCharacter(),
                out charPressed))
                return; //They pressed an exit sequence.

            var choice = MenuChoices.First(mc => mc.KeyCharacter.ToString().ToUpper() == charPressed.ToString().ToUpper());
            choice.Action.Invoke(); //Call the method that was selected

            Console.WriteLine();

            if (ConsoleMenuOptions.ShowPressEnterToContinue)
            {
                Console.WriteLine();
                Helper.PressEnterToContinue();
            }

            if (ConsoleMenuOptions.LoopMenuAfterSelection)
            {
                this.DrawMenu();
            }

        }

        private void SortMenuChoices()
        {
            int i;
            var choicesInts = MenuChoices.Where(mc => int.TryParse(mc.KeyCharacter.ToString(), out i));
            var choicesOther = MenuChoices.Where(mc => !int.TryParse(mc.KeyCharacter.ToString(), out i));
            var newList = new List<MenuChoice>(choicesInts.OrderBy(mc => int.Parse(mc.KeyCharacter.ToString())));
            newList.AddRange(choicesOther.OrderBy(mc => mc.KeyCharacter));
            MenuChoices = newList;
        }

        private IEnumerable<char> GetMenuChoicesWithExitCharacter()
        {
            if (this.ConsoleMenuOptions.EscapeCharacterMenuOption != ' ')
            {
                List<char> newList = new List<char>();
                newList.AddRange(MenuChoices.Select(mc => mc.KeyCharacter));
                newList.Add(ConsoleMenuOptions.EscapeCharacterMenuOption);
                return newList;
            }
            else
                return MenuChoices.Select(mc => mc.KeyCharacter);
        }
    }
}
