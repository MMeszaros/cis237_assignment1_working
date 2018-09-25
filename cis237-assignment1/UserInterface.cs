using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment1
{
    enum MenuOption { AddItem, Search, ShowMenu};

    class UserInterface
    {

        //Variables
        /****************************************************/
        // A string to store the user menu
        private string menu = "Menu:\r\n" +
            "".PadRight(50, '-') + "\r\n" +
            "\"0\" - Load inventory from data files.\r\n" +
            "\"1\" - List beverage inventory.\r\n" +
            "\"2\" - Add an item to the beverage inventory.\r\n" +
            "\"3\" - Search for item by ID.\r\n" +
            "".PadRight(50, '-') + "\r\n";

        
        //Methods
        /****************************************************/

        public List<string> GetUserInput(MenuOption op)
        {
            List<string> userInput = new List<string>();

            bool inputValid;

            do
            {
                try
                {
                    Console.WriteLine("Type: \"cancel\" to return to the menu options. or \"exit\" to end the program.");
                    switch ((int)op)
                    {
                        case 0:
                            if(userInput.Count == 0)
                            {
                                Console.Write("Enter the Item Id#: ");
                                userInput.Add(Console.ReadLine().Trim());
                                if (userInput.Last().Length == 5)
                                {
                                    inputValid = true;
                                    Console.WriteLine();
                                }
                                else
                                    Console.WriteLine("");
                            }
                            if(userInput.Count == 1)
                            {

                            }
                            break;


                        default:
                            PrintMenu();
                            Console.Write("Enter a selection from the menu to execute:");
                            userInput.Add(Console.ReadLine().Trim());
                            if (uint.Parse(userInput[0]) < 3)
                                inputValid = true;
                            else
                                userInput.RemoveAt(userInput.Count - 1);
                                Console.WriteLine("Invalid entry. Must match a number option from the menu.");
                                break;
                    }
                }
                catch (Exception e)
                {
                    switch ((int)op)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            Console.WriteLine("Invalid entry. Must match an option number from the menu.");
                            break;
                        default:
                            
                            break;
                    }
                    userInput.RemoveAt(userInput.Count - 1);
                }
                finally
                {

                }
            } while (!inputValid);

            return userInput;
        }

        public void PrintMenu()
        {
            Console.WriteLine(menu);
        }

        public void Display(string output)
        {
            Console.WriteLine(output);
        }
    }
}
