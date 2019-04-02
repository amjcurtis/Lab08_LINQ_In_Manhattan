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

            //////////////////////////////////////////////
            // Output all neighborhoods from data
            var allNeighborhoodsQuery = from neighborhood in json.features
                                        select neighborhood.properties.neighborhood;

            foreach (string neighborhood in allNeighborhoodsQuery)
            {
                Console.WriteLine(neighborhood);
            }


            //////////////////////////////////////////////
            // Output all neighborhoods with names
            var neighborhoodsWithNames = from neighborhood in allNeighborhoodsQuery
                                         where neighborhood != ""
                                         //group neighborhood by neighborhood
                                         orderby neighborhood ascending
                                         select neighborhood;

            foreach (var item in neighborhoodsWithNames)
            {
                Console.WriteLine(item);
            }


            //////////////////////////////////////////////
            // Output all neighborhoods (with duplicate names removed)
            var uniqueNeighborhoods = neighborhoodsWithNames.Distinct();

            foreach (var item in uniqueNeighborhoods)
            {
                Console.WriteLine(item);
            }


            //////////////////////////////////////////////
            // Consolidate above queries into single query
            var consolidatedQuery = json.features.Distinct()
                                    .Where(neighborhood => neighborhood.properties.neighborhood != "")
                                    .GroupBy(n => n.properties.neighborhood)
                                    .Select(group => group.First());

            foreach (var item in consolidatedQuery)
            {
                Console.WriteLine(item.properties.neighborhood);
            }
        }
    }
}
