using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment1
{
    class BeverageCollection
    {
        //Class Variables
        /*************************************/
        private Beverage[] beverages;

        //BACKING FIELDS
        /*************************************/
        private int lastBeverage; //Stores the index of the last beverage in the collection.

        //PROPERTIES
        /*************************************/
        /// <summary>
        /// The index of the Last beverage in the collection.
        /// -1 if the collection contains no Beverages.
        /// </summary>
        public int LastBeverage
        {
            get { return lastBeverage; }
        }

        //METHODS
        /*************************************/

        /// <summary>
        /// Adds a new instance of beverage to the BeverageCollection.
        /// </summary>
        /// <param name="newBeverage">An object of type Beverage.</param>
        public void AddBeverage(Beverage newBeverage)//                                                                       <-------------------------QUESTION
        {
            if(newBeverage != null) // Checks if the new beverage if null
            {
                if (lastBeverage < beverages.Length) // Checks if the collection is full.
                {
                    beverages[++lastBeverage] = newBeverage; // Assigns the new beverage to the next null index in the beverages array.
                }
                else
                {
                    this.ResizeCollection(beverages.Length + 100); // Adds 100 null elements to the array.
                    AddBeverage(newBeverage); // Recursive call to handle any further exceptions.
                }
            }
        }

        /// <summary>
        /// Returns the index of the Beverage who's Id matches the Target's. Returns -1 if no match is found.
        /// </summary>
        /// <param name="beverage">The Target Beverage to be searched.</param>
        /// <returns></returns>
        public int FindBeverage(Beverage target)
        {
            int i = this.lastBeverage;
            if(target != null)
            {
                bool found = false;
                while (!found && i >= 0)
                {
                    if (beverages[i].Id == target.Id)
                    {
                        found = true;
                    }
                    i--;
                }
            }
            return i;
        }

        //public int FindBeverage(Beverage target)                                                                          <----------------------QUESTION
        //{
        //    int i = this.lastBeverage;
        //    bool found = false;
        //    while (!found && i >= 0)
        //    {
        //        if (beverages[i].equals(beverage))
        //        {
        //            found = true;
        //        }
        //        i--;
        //    }
        //    return i;
        //}

        public void GetPrintString()//                                                                                   <-------------------------QUESTION
        {
            for(int i = this.lastBeverage; i >= 0; i--)
            {
                Console.WriteLine();
                Console.WriteLine(beverages[i].ToString());
            }
        }

        /// <summary>
        /// A helper method used to resize the beverages array.
        /// </summary>
        /// <param name="collectionSize">The size for the beverages array to be resized to.</param>
        private void ResizeCollection(int collectionSize)//                                                              <--------------------------QUESTION
        {
            Beverage[] newCollection = new Beverage[collectionSize]; // Creates a new Beverage array of the specified size.
            beverages.CopyTo(newCollection, 0); // Copies all the elements of the beverages array to the new array.
            beverages = newCollection; // Reassigns the beverages array to the newly made Beverage array.
        }

        //CONSTRUCTORS
        /*************************************/
        /// <summary>
        /// Creates an instance of the BeverageCollection class that contains an array, 
        /// with default size of 100, used to store a collection of Beverage objects.
        /// </summary>
        public BeverageCollection()
        {
            this.beverages = new Beverage[100];
            this.lastBeverage = -1;
        }

        /// <summary>
        /// Creates an instance of the BeverageCollection class that contains an array, 
        /// with specified size, used to store a collection of Beverage objects.
        /// </summary>
        /// <param name="collectionSize">size of the array used to a collection of Beverage objects</param>
        public BeverageCollection(int collectionSize)
        {
            try
            {
                this.beverages = new Beverage[collectionSize];
                this.lastBeverage = -1;
            }
            catch
            {

            }
        }
    }
}
