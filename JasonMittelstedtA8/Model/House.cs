using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtA8.Model
{
    public class House
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_Code { get; set; }
        public decimal Price { get; set; }
        public int Time_On_Market { get; set; }

        public override string ToString()
        {
            return $"House: {Address}, {City}, {State} {Zip_Code} - " +
                   $"Listed at: {Price:C} - On Market: {Time_On_Market} months";
        }
    }
}
