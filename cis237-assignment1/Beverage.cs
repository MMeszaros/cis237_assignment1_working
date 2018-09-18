using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment1
{
    class Beverage
    {
        //BACKING FIELDS
        /************************************/
        private int id;
        private string name;
        private string pack; //The package size
        private decimal price;
        private bool active;

        //PROPERTIES
        /************************************/
        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Pack
        {
            set { pack = value; }
            get { return pack; }
        }

        public decimal Price
        {
            set { price = value; }
            get { return price; }
        }

        public bool Active
        {
            set { active = value; }
            get { return active; }
        }

        //METHODS
        /************************************/

        /// <summary>
        /// Overrides the ToString() method to properly format the beverage information for output.
        /// Example:
        ///     Beverage
        ///     Id#: #####
        ///     Name: BeverageName
        ///     Pack: ##.# unit
        ///     Price: $ ##.##
        ///     Active: True/False
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //Concatenates a string listing the beverage information in vertical orientation                                        <--------------------------QUESTION
            string output = "Beverage" +
                "\r\nId#: " + id +
                "\r\nName: " + name +
                "\r\nPack: " + pack +
                "\r\nPrice: " + price.ToString("c") +
                "\r\nActive: " + active;

            return output;
        }


        //CONSTRUCTORS
        /************************************/
        /// <summary>
        /// Create an instance of beverage class. Used to track inventory of beverages.
        /// </summary>
        /// <param name="id">The ID number of the beverage.</param>
        /// <param name="name">The name of the the beverage.</param>
        /// <param name="pack">The package size of the Beverage.</param>
        /// <param name="price">The price of the beverage.</param>
        /// <param name="active">"true" - the beverage is still being sold.
        /// "false" - The beverage is discontinued.</param>
        public Beverage(int id, string name, string pack, decimal price, bool active)
        {
            this.id = id;
            this.name = name;
            this.pack = pack;
            this.price = price;
            this.active = active;
        }

    }
}
