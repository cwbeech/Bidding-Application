using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class ProductDatabase
    {
        /// <summary>
        /// A list of all active products and their ID
        /// </summary>
        public Dictionary<Product, int> activeItems;

        /// <summary>
        /// the nextID to assign to a product (not sure if we need this as of rn 04/18)
        /// </summary>
        private int nextID;

        /// <summary>
        /// Constructor for a ProductDatabase
        /// </summary>
        /// <param name="p">A ProductController</param>
        public ProductDatabase()
        {
            activeItems = new Dictionary<Product, int>();
            nextID = 1;
        }

        /// <summary>
        /// Adds a product to the activeItems list
        /// </summary>
        /// <param name="p">The product to add</param>
        public void AddProduct(string name, string desc, decimal price)
        {
            Product p = new Product(name, desc, nextID, price);
            nextID++;
            activeItems.Add(p, p.ID);
        }

        /// <summary>
        /// 'Closes' a bid by removing it from the activeItems list
        /// </summary>
        /// <param name="p">The product to close</param>
        public void BidClosed(Product p)
        {
            activeItems.Remove(p);
        }

        /// <summary>
        /// Updates a products current bidder id and minimum bid 
        /// </summary>
        /// <param name="userID">The ID of the bidder</param>
        /// <param name="bid">The bidder's bid</param>
        /// <param name="p">The product that they bid on</param>
        public void UpdateBid(int userID, decimal bid, Product p)
        {
            foreach(var kp in  activeItems)
            {
                if(kp.Key == p && bid > p.MinBid)
                {
                    kp.Key.CurrentBidderID = userID;
                    kp.Key.MinBid = bid;
                }
            }
        }
    }
}
