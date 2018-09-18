using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage beverage1 = new Beverage(10000, "Bell's Two Hearted Ale", "12.0 oz.", 1.25m, true);
            Beverage beverage2 = new Beverage(10001, "Bell's Oberon", "12.0 oz.", 1.50m, true);
            Beverage beverage3 = new Beverage(10002, "Bell's Amber Ale", "12.0 oz.", 1.50m, true);
            Beverage beverage4 = new Beverage(10003, "Bell's Kalamazoo Stout", "12.0 oz.", 1.99m, true);

            BeverageCollection beverageCollection1 = new BeverageCollection();

            beverageCollection1.AddBeverage(beverage1);
            beverageCollection1.AddBeverage(beverage2);
            beverageCollection1.AddBeverage(beverage3);
            beverageCollection1.AddBeverage(beverage4);

            beverageCollection1.GetPrintString();

            Console.WriteLine();

            if(beverageCollection1.FindBeverage(beverage3) >= 0)
            {
                Console.WriteLine("found " + beverage3.Name);
            }
            else
            {
                Console.WriteLine("Beverage Not Found");
            }

            Beverage fake = new Beverage(00000, " Fake Bell's Kalamazoo Stout", "12.0 oz.", 1.99m, true);

            Console.WriteLine();

            if (beverageCollection1.FindBeverage(fake) >= 0)
            {
                Console.WriteLine("found " + fake.Name);
            }
            else
            {
                Console.WriteLine("Beverage Not Found");
            }

            Console.WriteLine();

            Beverage none = null;
                if (beverageCollection1.FindBeverage(none) >= 0)
                {
                    //Console.WriteLine("found " + none.Name);
                }
                else
                {
                    Console.WriteLine("Beverage Not Found");
                }
            
        }
    }
}
