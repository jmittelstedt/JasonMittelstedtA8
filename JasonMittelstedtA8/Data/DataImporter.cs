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
        private const string FilePath = "Assignment8Data.json"; 

        public List<House> ImportData()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string json = File.ReadAllText(FilePath);
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
