using System;
using System.IO;
using System.Linq;
using Lab08_LINQ_In_Manhattan.Classes;
using Newtonsoft.Json;

namespace Lab08_LINQ_In_Manhattan
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = "../../../../data.json";

            // Use StreamReader to read in JSON and store in a variable
            var data = "";
            using (StreamReader sr = File.OpenText(path))
            {
                data = sr.ReadToEnd();
            }

            // Instantiate object from deserialized JSON
            RootObject json = JsonConvert.DeserializeObject<RootObject>(data);

            // Output all neighborhoods from data
            var allNeighborhoodsQuery = from neighborhood in json.features
                                        select neighborhood.properties.neighborhood;

            foreach (string neighborhood in allNeighborhoodsQuery)
            {
                Console.WriteLine(neighborhood);
            }

            //TODO Get neighborhoods and neighborhood names from deserialized JSON
            //TODO Create classes for Neighborhood (and Name)?


            Console.ReadLine();
        }
    }
}
