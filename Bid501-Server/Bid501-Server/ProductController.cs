using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class ProductController
    {
        private ProductDatabase pd;

        public ProductController(ProductDatabase p)
        {
            this.pd = p;
        }

        /// <summary>
        /// Validates a bid recieved from the ServerCommunicationControl
        /// </summary>
        /// <param name="userID">the userID of the bidder</param>
        /// <param name="bid">the bid amount they're attempting</param>
        /// <param name="p">the product that theyre bidding on</param>
        /// <returns>true if valid, false if not</returns>
        public bool ValidateBid(int userID, decimal bid, Product p)
        {
            if(userID != p.CurrentBidderID && bid > p.MinBid)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Passes a request to update a bid to the product database
        /// </summary>
        /// <param name="userID">the userID of the bidder</param>
        /// <param name="bid">the bid amount</param>
        /// <param name="p">the product</param>
        public void UpdateCurrentBid(int userID, decimal bid, Product p) 
        {
            pd.UpdateBid(userID, bid, p);
        }

        /// <summary>
        /// Passes a request to add a product to the product database
        /// </summary>
        /// <param name="name">name of the product</param>
        /// <param name="desc">description of the product</param>
        /// <param name="price">price of the product</param>
        public void AddProduct(string name, string desc, decimal price)
        {
            pd.AddProduct(name, desc, price);
        }

        /// <summary>
        /// Passes a request to close a bid to the product database
        /// </summary>
        /// <param name="p">The product to close</param>
        public void BidClosed(Product p)
        {
            pd.BidClosed(p);
        }
    }
}
