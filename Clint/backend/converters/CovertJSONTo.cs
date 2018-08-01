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
    public class CovertJSONTo
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

        /*public static IList<T> DeserializeToList<T>(string jsonString)
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
        }*/
    }
}