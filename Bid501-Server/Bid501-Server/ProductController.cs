﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public void StartBid(int pID)
        {
            pd.BidStarted(pID);
        }

        /// <summary>
        /// Validates the bid revieved from the ServerCommunicationControl, if valid, places it
        /// </summary>
        /// <param name="userID">the userID of the bidder</param>
        /// <param name="bid">the bid amount they're attempting</param>
        /// <param name="p">the product that theyre bidding on</param>
        /// <returns>true if valid and bid was placed, false if not</returns>
        public bool PlaceBidAttempt(int userID, decimal bid, Product p)
        {
            if(ValidateBid(userID, bid, p))
            {
                UpdateCurrentBid(userID, bid, p);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the attempted bid is greater than the minimum bid of the product, as well as checks if the bidder is already the highest bidder
        /// </summary>
        /// <param name="userID">the userID of the bidder</param>
        /// <param name="bid">the bid amount they're attempting</param>
        /// <param name="p">the product that theyre bidding on</param>
        /// <returns>true if valid and user is not already the highest bidder, false if not</returns>
        public bool ValidateBid(int userID, decimal bid, Product p)
        {
            if (userID != p.CurrentBidderID && bid > p.MinBid)
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

        /// <summary>
        /// Returns all relevant information about a product in a List of strings in the order of:
        /// name, description, price, minbid, currentbidderid
        /// </summary>
        /// <param name="p">The product to get info about</param>
        public List<string> SendProdInfo(Product p)
        {
            return p.ToListString();
        }

        /// <summary>
        /// Returns a list of all inactive items
        /// </summary>
        /// <returns></returns>
        public BindingList<Product> GetInactiveProds()
        {
            BindingList<Product> bl = new BindingList<Product>();

            foreach(var p in pd.GetInactiveItems())
            {
                bl.Add(p);
            }

            return bl;
        }

        /// <summary>
        /// Returns a list of all active items
        /// </summary>
        /// <returns></returns>
        public BindingList<Product> GetActiveProds()
        {
            BindingList<Product> bl = new BindingList<Product>();

            foreach(var p in pd.GetActiveItems())
            {
                bl.Add(p);
            }

            return bl;
        }
    }
}
