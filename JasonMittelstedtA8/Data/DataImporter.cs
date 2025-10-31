using JasonMittelstedtA8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JasonMittelstedtA8.Data
{
    public class DataImporter
    {
        private const string FileName = "Assignment8Data.json"; 

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
