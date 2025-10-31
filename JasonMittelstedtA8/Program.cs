using JasonMittelstedtA8.Controller;
using JasonMittelstedtA8.Data;

namespace JasonMittelstedtA8
{
    /// <summary>
    /// The entry point for the LINQ Practice Assignment program.
    /// </summary>
    /// <remarks>
    /// This program demonstrates the use of both standard query syntax and lambda syntax LINQ operations
    /// on a dataset of <see cref="House"/> objects. It loads JSON data using <see cref="DataImporter"/>,
    /// executes LINQ queries via <see cref="LinqController"/>, and outputs results to the console.
    /// </remarks>
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application (not used).</param>
        /// <remarks>
        /// The method:
        /// <list type="number">
        /// <item><description>Loads house data from a JSON file using <see cref="DataImporter"/>.</description></item>
        /// <item><description>Validates that data was successfully loaded.</description></item>
        /// <item><description>Executes both regular and lambda-style LINQ queries using <see cref="LinqController"/>.</description></item>
        /// <item><description>Displays query results in the console.</description></item>
        /// </list>
        /// </remarks>
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
