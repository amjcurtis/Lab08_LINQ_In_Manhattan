using System;
using System.IO;
using Lab08_LINQ_In_Manhattan.Classes;
using Newtonsoft.Json;

namespace Lab08_LINQ_In_Manhattan
{
    class Program
    {
        static void Main(string[] args)
        {

            //TODO Use StreamReader to read in JSON and store in a variable
            // Use StreamReader command "Read all lines" so it keeps formatting
            // Then query the data under that variable name
            string path = "../../../../data.json";

            var data = "";

            using (StreamReader sr = File.OpenText(path))
            {
                data = sr.ReadToEnd();
            }

            //TODO Deserialize JSON to object
            RootObject json = JsonConvert.DeserializeObject<RootObject>(data);



            //TODO Get neighborhoods and neighborhood names from deserialized JSON
            //TODO Create classes for Neighborhood (and Name)?


            Console.ReadLine();
        }
    }
}
