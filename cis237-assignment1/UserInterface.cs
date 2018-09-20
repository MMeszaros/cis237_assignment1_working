using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment1
{

    enum Prompt { Menu, AddItem}

    class UserInterface
    {
        //Variables
        /****************************************************/
        // A string to store the user menu
        private string menu = "Menu:\r\n" +
            "".PadRight(50, '-') + "\r\n" +
            "\"1\" - Load inventory from data files.\r\n" +
            "\"2\" - List beverage inventory.\r\n" +
            "\"3\" - Add an item to the beverage inventory.\r\n" +
            "\"4\" - Search for item by ID.\r\n" +
            "\"5\" - Close Program.\r\n" +
            "".PadRight(50, '-') + "\r\n";

        private bool inputValid;

        //Methods
        /****************************************************/

        public string GetUserInput(Prompt p)
        {
            string userInput;
            do
            {
                try
                {
                    switch (p)
                    {
                        case Prompt.AddItem:
                            Console.Write("Enter a 5 digit alphanumeric item ID: ");
                            if((userInput = Console.ReadLine().Trim()).Length == 5)
                            {
                                Console.WriteLine();
                                Console.Write("Enter the item name: ");
                                if(Console.ReadLine())
                                
                            }
                            break;


                        default:
                            Console.WriteLine(menu);
                            Console.Write("Enter a selection from the menu to execute (Type \"menu\" to redisplay the menu): ");
                            userInput = Console.ReadLine().Trim();
                            inputValid = int.TryParse(userInput, out int test);
                            break;
                    }
                }
                catch (Exception e)
                {
                    inputValid = false;
                    Display(e);
                }
                finally
                {

                }

            } while (!inputValid);

            return userInput;
        }

        public void Display(string output)
        {
            Console.WriteLine(output);
        }

        public void Display(Exception e)
        {
            Console.WriteLine("Invalid Entry!");
        }
    }
}
