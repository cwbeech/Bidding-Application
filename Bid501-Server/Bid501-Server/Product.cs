using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class Product
    {
        /// <summary>
        /// The name of the product
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// A brief description of the product
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The product ID
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Starting price of the product
        /// </summary>
        public decimal Price { get; }  

        /// <summary>
        /// Current minimum bid allowed on the product
        /// </summary>
        public decimal MinBid { get; set; }

        /// <summary>
        /// The id of the bidder who currently has the highest bid on the product
        /// </summary>
        public int CurrentBidderID { get; set; }

        /// <summary>
        /// Constructor for a Product object, initially it will set MinBid to price, and CurrentBidderID to 0.
        /// </summary>
        /// <param name="name">The name of the product</param>
        /// <param name="description">A description of the product</param>
        /// <param name="id">The id of the product</param>
        /// <param name="price">The initial price of the product</param>
        public Product(string name, string description, int id, decimal price)
        {
            Name = name;
            Description = description;
            ID = id;
            Price = price;

            MinBid = price;
            CurrentBidderID = 0;
        }

        /// <summary>
        /// Returns all relevant information, as strings, in a List.
        /// </summary>
        /// <returns>List<string> containing all information about the product</returns>
        public List<string> ToListString()
        {
            List<string> pInfo = new List<string>();

            pInfo.Add(Name);
            pInfo.Add(Description);
            pInfo.Add(Price.ToString());
            pInfo.Add(MinBid.ToString());
            pInfo.Add(CurrentBidderID.ToString());

            return pInfo;
        }

        /// <summary>
        /// Overrides the ToString to return the Product's name.
        /// </summary>
        /// <returns>The Product's name.</returns>
		public override string ToString()
		{
            return Name;
		}


	}
}
