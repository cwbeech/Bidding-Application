using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class Product :IProduct
    {
        /// <summary>
        /// The name of the product
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// A brief description of the product
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// The product ID
        /// </summary>
        public int id { get; set; } = 0;

        /// <summary>
        /// Starting price of the product
        /// </summary>
        public decimal price { get; set; }  

        /// <summary>
        /// Current minimum bid allowed on the product
        /// </summary>
        public decimal minBid
        {
            get
            {
                if(currBidID == 0)
                {
                    return price;
                }

                return price * 1.1m;
            }
            set 
            {
                minBid = value;
            }
        }

        /// <summary>
        /// The id of the bidder who currently has the highest bid on the product
        /// </summary>
        public int currBidID { get; set; }

        public DateTime timeLeft { get; set; }

        /// <summary>
        /// Constructor for a Product object, initially it will set MinBid to price, and CurrentBidderid to 0.
        /// </summary>
        /// <param name="name">The name of the product</param>
        /// <param name="description">A description of the product</param>
        /// <param name="id">The id of the product</param>
        /// <param name="price">The initial price of the product</param>
        public Product(string name, string description, decimal price)
        {
            this.name = name;
            this.description = description;
            this.price = price;
			currBidID = 0;
            timeLeft = DateTime.Now; //NOTE: whenever you display this, probably want to use ToShortDateString or something like it - Aidan, 5/2
        }

        /// <summary>
        /// Returns all relevant information, as strings, in a List.
        /// </summary>
        /// <returns>List<string> containing all information about the product</returns>
        public List<string> ToListString()
        {
            List<string> pInfo = new List<string>();

            pInfo.Add(name);
            pInfo.Add(description);
            pInfo.Add(price.ToString());
            pInfo.Add(minBid.ToString());
            pInfo.Add(currBidID.ToString());
            pInfo.Add(timeLeft.ToShortDateString());

            return pInfo;
        }


        
        /// <summary>
        /// Overrides the ToString to return the Product's name.
        /// </summary>
        /// <returns>The Product's name.</returns>
		public override string ToString()
		{
            return name;
		}
        

        /// <summary>
        /// Returns a string separated by ':' containing the information of a product
        /// </summary>
        /// <returns></returns>
        public string ToFileString()
        {
            return this.name + ":" + this.description + ":" + this.price.ToString();
        }


	}
}
