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
        private uint bufferSize; //The size that the collection 

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

        /// <summary>
        /// The size of the buffer for the array, when the collection because full it will be resized to add the bufferSize
        /// (The buffer size will be set to 1 plus the input value.)
        /// </summary>
        public uint BufferSize
        {
            get { return bufferSize; }
            set { bufferSize = value + 1; }
        }

        //METHODS
        /*************************************/

        /// <summary>
        /// Adds a new instance of beverage to the BeverageCollection.
        /// </summary>
        public bool AddBeverage(string id, string name, string pack, decimal price, bool active)
        {
            if(FindBeverage(id) == -1) // Checks if the new beverage if null
            {
                if (lastBeverage < beverages.Length - 1) // Checks if the collection is full.
                {
                    beverages[++lastBeverage] = new Beverage(id, name, pack, price, active); // Assigns the new beverage to the next null index in the beverages array.
                    return true;
                }
                else
                {
                    this.ResizeCollection(beverages.Length + 100); // Adds 100 null elements to the array.
                    beverages[++lastBeverage] = new Beverage(id, name, pack, price, active);
                }
            }
            return false;
        }

        /// <summary>
        /// Retrieves a the Beverage the specified index.
        /// </summary>
        /// <param name="index">The index of element to retrieve.</param>
        /// <returns>A Beverage element from the beverageCollection array. Returns null if the index is out of range.</returns>
        public Beverage Get(int index)
        {// Just validating the passed variable then index the beverages array.
            if(index >= 0 && index <= lastBeverage)
            {
                return beverages[index];
            }
            return null;
        }

        /// <summary>
        /// Searches the beverageCollection array for a beverage element specified Id.
        /// </summary>
        /// <param name="targetId">The id of the beverage to search for.</param>
        /// <returns>Returns the index of the Beverage who's Id matches the target Id. Returns -1 if no match is found.</returns>
        public int FindBeverage(string targetId)
        {
            int i = this.lastBeverage; // a counter variable set to the index of the last Beverage element in the array.
            if(targetId == string.Empty) // validates the passed targetId
            {
                bool found = false; // sets a control variable for whether or not a match has been made.
                while (!found && i >= 0) // loop through each element until match has been found.
                {
                    if (beverages[i].Id == targetId) // check for match.
                    {
                        found = true; // breaks loop if match found.
                    }
                    i--; // looping backward through array.
                }
            }
            else
            {// returning either: -1 no match found, or the index of the matching element.
                return -1; 
            }
            return i;
        }

        /// <summary>
        /// Concatenates the properties of each beverage element in the beverageCollection array in a string.
        /// </summary>
        /// <returns>A string of information of the beverages contained in the collection array, formatted to list the beverages vertically. </returns>
        public string GetPrintString()
        { // incrementing through each element then toString()ing them and concatenating.
            string printString = "";
            for(int i = 0; i <= this.lastBeverage; i++)
            {
                printString += "\r\n" + ((i+1) + ".").PadRight(8) + beverages[i].ToString();
            }
            return printString;
        }

        /// <summary>
        /// A helper method used to resize the beverages array.
        /// </summary>
        /// <param name="collectionSize">The size for the beverages array to be resized to.</param>
        private void ResizeCollection(int collectionSize)
        {
            Beverage[] newCollection = new Beverage[collectionSize]; // Creates a new Beverage array of the specified size.
            beverages.CopyTo(newCollection, 0); // Copies all the elements of the beverages array to the new array.
            beverages = newCollection; // Reassigns the beverages array to the newly made Beverage array.
        }

        //CONSTRUCTORS
        /*************************************/
        /// <summary>
        /// Creates an instance of the BeverageCollection class that contains an array, 
        /// with specified size and buffer size, used to store a collection of Beverage objects.
        /// </summary>
        /// <param name="collectionSize">The initial size of the collection must be a real number</param>
        /// <param name="bufferSize">The size of the buffer for the array, when the collection because full it will be resized to add the bufferSize
        /// (The buffer size will be set to 1 plus the input value.)</param>
        public BeverageCollection(uint collectionSize, uint bufferSize)
        {
            this.beverages = new Beverage[collectionSize];
            this.lastBeverage = -1;
            this.bufferSize = bufferSize + 1; // sets the bufferSize to 1 + the buffer perameter so that the adding elements doesn't result in exception.
        }
    }
}
