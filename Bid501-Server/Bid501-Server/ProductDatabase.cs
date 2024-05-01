using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class ProductDatabase : IProductDB
    {
        /// <summary>
        /// A list of all active products and their ID
        /// </summary>
        public Dictionary<Product, int> actualActiveItems;

        /// <summary>
        /// A list of all products, active or inactive, and their ID
        /// </summary>
        public Dictionary<Product, int> allItems = new Dictionary<Product, int>();

        public Dictionary<int, IProduct> activeItems { get; set; }

        private FileIO fio;

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
            actualActiveItems = new Dictionary<Product, int>();
            fio = new FileIO("products.txt", this);
            fio.ReadProductFromFile();
            nextID = 1;
        }

        public Dictionary<int, IProduct> ReturnSendList()
        {
            foreach (KeyValuePair<Product, int> kvp in actualActiveItems)
            {
                activeItems.Add(kvp.Value, kvp.Key);
            }
            return activeItems;
        }

        /// <summary>
        /// Adds a product to the activeItems list
        /// </summary>
        /// <param name="p">The product to add</param>
        public void AddProduct(Product p)
        {
            p.id = nextID;
            nextID++;
            allItems.Add(p, p.id);
        }

        /// <summary>
        /// Overloaded method for AddProduct which takes raw data to create a new product
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        public void AddProduct(string name, string description, decimal price)
        {
            Product p = new Product(name, description, price);
            p.id = nextID;
            nextID++;
            allItems.Add(p, p.id);
        }

        /// <summary>
        /// 'Closes' a bid by removing it from the activeItems list
        /// </summary>
        /// <param name="p">The product to close</param>
        public void BidClosed(int pID)
        {
            Product prod = null;

            foreach (var kp in actualActiveItems)
            {
                if (kp.Value == pID)
                {
                    prod = kp.Key;
                }
            }

            if (prod != null)
            {
                allItems.Add(prod, prod.id);
                actualActiveItems.Remove(prod);
            }

        }

        /// <summary>
        /// Starts a bid based off product ID.
        /// </summary>
        /// <param name="pID"></param>
        public void BidStarted(int pID)
        {
            Product prod = null;

            foreach(var kp in allItems)
            {
                if(kp.Value == pID)
                {
                    prod = kp.Key;
                }
            }
            
            if(prod != null)
            {
                allItems.Remove(prod);
                actualActiveItems.Add(prod, prod.id);
            }
        }

        /// <summary>
        /// Updates a products current bidder id and minimum bid 
        /// </summary>
        /// <param name="userID">The ID of the bidder</param>
        /// <param name="bid">The bidder's bid</param>
        /// <param name="p">The product that they bid on</param>
        public void UpdateBid(int userID, decimal bid, int pID)
        {
            foreach(var kp in actualActiveItems)
            {
                if(kp.Value == pID)
                {
                    kp.Key.currBidID = userID;
                    kp.Key.minBid = bid;
                }
            }
        }

        /// <summary>
        /// Validates a bid
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="bid"></param>
        /// <param name="pID"></param>
        /// <returns></returns>
        public bool ValidateBid(int userID, decimal bid, int pID)
        {
            Product p = null;

            foreach(var kp in actualActiveItems)
            {
                if(kp.Value == pID)
                {
                    p = kp.Key;
                }
            }


            if(p != null)
            {
                if (userID != p.currBidID && bid > p.minBid)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Gets a list of all inactive items in the database
        /// </summary>
        /// <returns></returns>
        public List<Product> GetInactiveItems()
        {
            List<Product> inactive = new List<Product>();

            foreach(var kp in allItems)
            {
                if (!actualActiveItems.ContainsKey(kp.Key))
                {
                    inactive.Add(kp.Key);
                }
            }

            return inactive;
        }

        /// <summary>
        /// Gets a list of all active products in the database
        /// </summary>
        /// <returns></returns>
        public List<Product> GetActiveItems()
        {
            List<Product> active = new List<Product>();

            foreach(var kp in actualActiveItems)
            {
                active.Add(kp.Key);
            }

            return active;
        }
    }
}
