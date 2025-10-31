using JasonMittelstedtA8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JasonMittelstedtA8.Data
{
    /// <summary>
    /// Handles importing house data from a JSON file.
    /// </summary>
    public class DataImporter
    {
        /// <summary>
        /// The name of the JSON file containing the house data.
        /// </summary>
        private const string FileName = "Assignment8Data.json";

        /// <summary>
        /// Imports house data from the JSON file located in the project’s Data folder.
        /// </summary>
        /// <returns>
        /// A list of <see cref="House"/> objects deserialized from the JSON file.
        /// If the file cannot be read or an error occurs, an empty list is returned.
        /// </returns>
        /// <remarks>
        /// This method determines the path of the executing assembly, navigates up three directory levels 
        /// to the project root, then appends the "Data" folder and file name to build the full path.
        /// It uses case-insensitive property name matching when deserializing.
        /// </remarks>
        public List<House> ImportData()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string ep = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string sp = Directory.GetParent(ep).Parent.Parent.Parent.FullName;
                Console.WriteLine(sp);
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string dataFilePath = Path.Combine(sp, "Data", FileName);
                string json = File.ReadAllText(dataFilePath);
                Console.WriteLine(json);
                var houses = JsonSerializer.Deserialize<List<House>>(json, options);
                return houses ?? new List<House>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return new List<House>();
            }
        }
    }
}
