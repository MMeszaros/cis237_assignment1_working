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
            Beverage newBev;

            string userInput;

            do
            {
                userInput = ui.GetUserInput(Prompt.Menu);

                switch (userInput)
                {
                    case "1":
                        if (!file.DataLoaded)
                        {
                            Exception importStatus = file.Import(beverages);
                            if (importStatus == null)
                            {
                                ui.Display("File loaded successfully.");
                            }
                            else
                            {
                                ui.Display(importStatus.ToString());
                            }
                        }
                        else
                        {
                            ui.Display("Data files already loaded.");
                        }
                        break;

                    case "2":
                        ui.Display(beverages.GetPrintString());
                        break;

                    case "3":
                        ui.GetUserInput(Prompt.AddItem);
                        break;

                    case "4":
                        break;

                    case "5":
                        break;

                }
            } while (userInput != "5");
        }
    }
}
