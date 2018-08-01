using System;
using System.Collections.Generic;
using System.IO;
using Clint.backend.model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Clint.backend.converters
{
    /// <summary>
    /// Converts between JSON and Menu Items list. 
    /// </summary>
    class ConvertJson2Menu
    {
        /// <summary>
        /// Coverts JSON file into List of Menu Items.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static List<MenuItem> ParseJsonFile(string fullPath)
        {
            //TODO: Fix the path top search from within the project
            //TODO: Change to relative path
            using (var r = new StreamReader(fullPath))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<MenuItem>>(json);
                return items;
            }
        }

        public static IList<T> DeserializeToList<T>(string jsonString)
        {
            List<string> invalidItems = null;
            var array = JArray.Parse(jsonString);
            IList<T> items = new List<T>();

            foreach (var item in array)
            {
                try
                {
                    items.Add(item.ToObject<T>());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occured: {ex}");
                    invalidItems = invalidItems ?? new List<string>();
                    invalidItems.Add(item.ToString());
                }
            }
            return items;
        }

        /*public static List<MenuItem> ParseJson()
        {
            //string fullPath = "C:\vsproj\\Clint\\Clint\\backend\\menuses\\menu_main.json";
            const string json = @"[
	            {id:0, entry: 'List all files in current location.'},
                {id:1, entry: 'Create me new file.'},
                {id:2, entry: 'GIT - make it a new repo'},
                {id:3, entry: 'Build this project'},
                {id:4, entry: 'Let\'s play a game - Dice Lairs?'},
                {id:5, entry: 'Show yourself!'},
                {id:6, entry: 'Lorem ipsum!'},
                {id:9, entry: 'Kill yourself!'}
            ]";

            var items = (List<MenuItem>)DeserializeToList<MenuItem>(json);

            return items;
        }*/

        /*public static List<string> ParseFile()
        {
            var lines = new List<string>();

            const string fullPath = "C:\\vsproj\\Clint\\Clint\\Clint\\backend\\menuses\\menu_main.json";
            var counter = 0;
            string line;

            // Read the file and display it line by line.  
            var file = new StreamReader(fullPath);

            //Check, if file exists
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
                lines.Add(line);
            }

            file.Close();
            Console.WriteLine($"There were {counter} lines.");
            // Suspend the screen.  
            Console.ReadLine();
            return lines;
        }*/
    }
}
