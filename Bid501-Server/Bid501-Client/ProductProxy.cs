using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Shared;
namespace Bid501_Client
{
    public class ProductProxy : IProduct
    {
        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        private string _description;
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        private int _id;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        private decimal _price;
        public decimal price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public decimal minBid
        {
            get
            {
                return price; //idk what this is supposed to be
            }
        }

        private int _currBidID;
        public int currBidID
        {
            get
            {
                return _currBidID;
            }
            set
            {
                _currBidID = value;
            }
        }

        public ProductProxy(string n, string d, int i, decimal p)
        {
            name = n;
            description = d;
            id = i;
            price = p;
            currBidID = 0; //may want to change how we handle no bid ID
        }
    }
}
