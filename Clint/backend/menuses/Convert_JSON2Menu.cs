using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Clint.backend.menuses
{
    /**
     * Converts between JSON and Menu Items list.
     */
    class Convert_JSON2Menu
    {
        /**
         * 
         */
        public static List<MenuItem> parseJSONFile()
        {
            //TODO: Fix the path top search from within the project
            //TODO: Change to relative path
            string fullPath = "C:\\vsproj\\Clint\\Clint\\Clint\\backend\\menuses\\menu_main.json";
            using (StreamReader r = new StreamReader(fullPath))
            {
                string json = r.ReadToEnd();
                List<MenuItem> items = JsonConvert.DeserializeObject<List<MenuItem>>(json);
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
                    invalidItems = invalidItems ?? new List<string>();
                    invalidItems.Add(item.ToString());
                }
            }
            return items;
        }

        public static List<MenuItem> parseJSON()
        {
            //string fullPath = "C:\vsproj\\Clint\\Clint\\backend\\menuses\\menu_main.json";
            string json = @"[
	            {id:0, entry: 'List all files in current location.'},
                {id:1, entry: 'Create me new file.'},
                {id:2, entry: 'GIT - make it a new repo'},
                {id:3, entry: 'Build this project'},
                {id:4, entry: 'Let\'s play a game - Dice Lairs?'},
                {id:5, entry: 'Show yourself!'},
                {id:6, entry: 'Lorem ipsum!'},
                {id:9, entry: 'Kill yourself!'}
            ]";

            List<MenuItem> items = (List<MenuItem>)DeserializeToList<MenuItem>(json);

            return items;
        }

        public static List<string> parseFile()
        {
            List<string> lines = new List<string>();

            string fullPath = "C:\\vsproj\\Clint\\Clint\\Clint\\backend\\menuses\\menu_main.json";
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            StreamReader file = new StreamReader(fullPath);

            //TODO Check, if file exists

            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
                lines.Add(line);
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            Console.ReadLine();
            return lines;
        }
    }
}
