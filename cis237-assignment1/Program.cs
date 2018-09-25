using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment1
{
    class Program
    {
        /**********************************************/
        /*              Program Main                  */
        /**********************************************/
        static void Main(string[] args)
        {

            UserInterface ui = new UserInterface();
            CsvProcessor file = new CsvProcessor("../../../datafiles/beverage_list.csv");
            BeverageCollection beverages = new BeverageCollection(4000, 100);

            string userInput = "";
            ui.PrintMenu();
            do
            {
                switch (ui.GetUserInput(MenuOption.ShowMenu).Last())
                {
                    case "0":
                        break;
                    default:
                        break;
                }
            } while (userInput != "exit");


        }
    }
}
