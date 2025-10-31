using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtA8.Model
{
    /// <summary>
    /// Represents a single real estate listing with address, city, state, zip code, price, and time on market.
    /// </summary>
    public class House
    {
        /// <summary>
        /// Gets or sets the address of the house.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the city of the house.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state of the house.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the zip code of the house.
        /// </summary>
        public string Zip_Code { get; set; }

        /// <summary>
        /// Gets or sets the price of the house.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the time on market of the house.
        /// </summary>
        public int Time_On_Market { get; set; }

        /// <summary>
        /// Returns a string representation of the house, including address, city, state, zip code, price, and time on market.
        /// </summary>
        /// <returns>A formatted string containing house details.</returns>
        public override string ToString()
        {
            return $"House: {Address}, {City}, {State} {Zip_Code} - " +
                   $"Listed at: {Price:C} - On Market: {Time_On_Market} months";
        }
    }
}
