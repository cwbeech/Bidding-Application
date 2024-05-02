using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Shared;

namespace Bid501_Client
{
    public class Product : IProduct
    {
        public static int ID;
        public string name { get; set; }
        public string description { get; set; }
        public int id { get; set; }
        public decimal price { get; set; }

        public decimal minBid { get; set; }

        public int currBidID { get; set; }

        public Product(string name, string desc, decimal price)
        {
            this.name = name;
            description = desc;
            this.id = ID++;
            this.price = price;
            this.minBid = price;
            this.currBidID = -1;
        }
    }

    public class Database : IProductDB
    {
        public Dictionary<int, IProduct> activeItems { get; set; }

        public Database()
        {
            activeItems = new Dictionary<int, IProduct>();
        }

        public void Add(Product p)
        {
            activeItems.Add(p.id, p);
        }
    }
    public class DummyValues
    {
        public static IProductDB GetDatabase()
        {
            Database d = new Database();

            try
            {
                using (StreamReader sr = new StreamReader("products.txt"))
                {
                    string line;

                    string name;
                    string desc;
                    decimal price;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length == 3)
                        {
                            name = parts[0];
                            desc = parts[1];
                            price = Decimal.Parse(parts[2]);

                            Product p = new Product(name, desc, price);

                            d.Add(p);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                throw new Exception("Could not find the specified file.");
            }
            return d;
        }

        
    }
}
