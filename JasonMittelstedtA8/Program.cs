using JasonMittelstedtA8.Controller;
using JasonMittelstedtA8.Data;

namespace JasonMittelstedtA8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Assignment 8: LINQ Practice ===\n");

            var importer = new DataImporter();
            var houses = importer.ImportData();

            if (houses == null || houses.Count == 0)
            {
                Console.WriteLine("No data loaded. Check your JSON file path.");
                return;
            }

            // Run LINQ controller
            var controller = new LinqController(houses);

            Console.WriteLine("\n--- Regular LINQ Queries ---\n");
            controller.RunRegularLinqQueries();

            Console.WriteLine("\n--- Lambda LINQ Queries ---\n");
            controller.RunLambdaLinqQueries();

            Console.WriteLine("\n=== End of Program ===");
        }
    }
}
