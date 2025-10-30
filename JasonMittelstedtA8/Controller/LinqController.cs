using JasonMittelstedtA8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtA8.Controller
{
    public class LinqController
    {
        private readonly List<House> houses;

        public LinqController(List<House> houses)
        {
            this.houses = houses;
        }

        // ---------- Regular LINQ ----------
        public void RunRegularLinqQueries()
        {
            var q1 = from h in houses
                     where h.Time_On_Market > 5
                     select h;
            PrintResults("Houses on market > 5 months", q1);

            var q2 = from h in houses
                     where h.Time_On_Market > 5 && h.Price < 175000
                     select h;
            PrintResults("Houses on market > 5 months and < $175,000", q2);

            var q3 = from h in houses
                     where new[] { "GA", "NY", "TX" }.Contains(h.State) && h.Price > 140000
                     orderby h.Price ascending
                     select h;
            PrintResults("GA/NY/TX houses > $140,000 (Price Ascending)", q3);

            var q4 = from h in houses
                     where h.Price > 140000
                     orderby h.Zip_Code descending
                     select h.Zip_Code;
            Console.WriteLine("\nZip codes > $140,000 (Descending):");
            foreach (var z in q4.Distinct()) Console.WriteLine(z);

            var q5 = from h in houses
                     where new[] { "GA", "NY", "TX" }.Contains(h.State)
                     orderby h.Price descending
                     group h by h.State into stateGroup
                     select stateGroup;

            Console.WriteLine("\nGrouped by State (Price Descending):");
            foreach (var group in q5)
            {
                Console.WriteLine($"\nState: {group.Key}");
                foreach (var h in group)
                    Console.WriteLine($"  {h}");
            }

            // Custom Query Example
            var q6 = from h in houses
                     where h.Price > 150000 && h.Time_On_Market < 6
                     orderby h.Price descending
                     group h by h.City into cityGroup
                     select cityGroup;

            Console.WriteLine("\nCustom Query (Price > 150k & <6 months grouped by City):");
            foreach (var group in q6)
            {
                Console.WriteLine($"\nCity: {group.Key}");
                foreach (var h in group)
                    Console.WriteLine($"  {h}");
            }
        }

        // ---------- Lambda LINQ ----------
        public void RunLambdaLinqQueries()
        {
            var q1 = houses.Where(h => h.Time_On_Market > 5);
            PrintResults("Lambda: Houses on market > 5 months", q1);

            var q2 = houses.Where(h => h.Time_On_Market > 5 && h.Price < 175000);
            PrintResults("Lambda: Houses > 5 months & < $175k", q2);

            var q3 = houses.Where(h => new[] { "GA", "NY", "TX" }.Contains(h.State) && h.Price > 140000)
                            .OrderBy(h => h.Price);
            PrintResults("Lambda: GA/NY/TX > $140k (Price Asc)", q3);

            var q4 = houses.Where(h => h.Price > 140000)
                            .OrderByDescending(h => h.Zip_Code)
                            .Select(h => h.Zip_Code)
                            .Distinct();
            Console.WriteLine("\nLambda: Zip codes > $140k (Descending):");
            foreach (var z in q4) Console.WriteLine(z);

            var q5 = houses.Where(h => new[] { "GA", "NY", "TX" }.Contains(h.State))
                            .OrderByDescending(h => h.Price)
                            .GroupBy(h => h.State);
            Console.WriteLine("\nLambda: Grouped by State (Price Descending):");
            foreach (var group in q5)
            {
                Console.WriteLine($"\nState: {group.Key}");
                foreach (var h in group)
                    Console.WriteLine($"  {h}");
            }

            var q6 = houses.Where(h => h.Price > 150000 && h.Time_On_Market < 6)
                            .OrderByDescending(h => h.Price)
                            .GroupBy(h => h.City);
            Console.WriteLine("\nLambda Custom Query:");
            foreach (var group in q6)
            {
                Console.WriteLine($"\nCity: {group.Key}");
                foreach (var h in group)
                    Console.WriteLine($"  {h}");
            }
        }

        private void PrintResults(string title, IEnumerable<House> results)
        {
            Console.WriteLine($"\n{title}:");
            foreach (var h in results)
                Console.WriteLine(h);
        }
    }
}
