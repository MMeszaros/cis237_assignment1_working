using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cis237_assignment1
{
    class CsvProcessor
    {
        //Variables
        /*********************************************/
        private StreamReader stream = null;
        private string path;

        //Backing Fields
        /*********************************************/
        private bool dataLoaded = false; // stores whether or not the user loaded the data files so that the data in the beverageCollection is overwritten.

        //Properties
        /*********************************************/
        public bool DataLoaded
        {
            get { return dataLoaded; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        //Methods
        /*********************************************/
        public Exception Import(BeverageCollection beverageCollection)
        {
            try
            {
                stream = new StreamReader(path);
                string line;

                while ((line = stream.ReadLine()) != null)
                {
                    CsvProcessor.ProcessLine(line, beverageCollection);
                }
                dataLoaded = true;
            }
            catch(Exception e)
            {
                return e;
            }
            finally
            {
                stream.Close();
            }
            return null;
        }

        public static void ProcessLine(string line, BeverageCollection collection)
        {
            var fields = line.Split(',');
            string id = fields[0].Trim();
            string name = fields[1].Trim();
            string pack = fields[2].Trim();
            decimal price = Decimal.Parse(fields[3].Trim());
            bool active = Convert.ToBoolean(fields[4].Trim());

            collection.AddBeverage(id, name, pack, price, active);
        }

        //Constructors
        /*********************************************/
        public CsvProcessor(string path)
        {
            this.path = path;
        }
    }
}
