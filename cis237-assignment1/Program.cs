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
            do
            {
                switch (ui.GetUserInput(MenuOption.ShowMenu).Last())
                {
                    case "0":
                        if (!file.DataLoaded)
                        {
                            if (file.Import(beverages) == null)
                                ui.Display("File loaded succesfully");
                            else
                                ui.Display("Unable to load file. File may not be in correct directory.");
                        }
                        else
                        {
                            ui.Display("Data file is already loaded");
                        }
                        break;
                    case "1":
                        if (beverages.LastBeverage >= 0)
                            ui.Display(beverages.GetPrintString());
                        else
                            ui.Display("No item's are in the inventory. Add items or load them from a CSV file.");
                        break;
                    case "2":
                        var values = ui.GetUserInput(MenuOption.AddItem);
                        beverages.AddBeverage(values[0], values[1], values[2], decimal.Parse(values[3]), bool.Parse(values[4]));
                        break;
                    case "3":
                        break;
                    default:
                        break;
                }
            } while (userInput != "exit");


        }
    }
}
