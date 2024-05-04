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
                if(currBidID == 0)
                {
                    return price;
                }
                return price * 1.1m;
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

        public DateTime timeLeft { get; set; }

        public override string ToString()
        {
            return name;
        }

        public ProductProxy()
        {
            name = "";
            description = "";
            id = 0;
            price = 0;
            currBidID = 0;
            timeLeft = DateTime.Now;
        }
        
        public ProductProxy(IProduct p)
        {
            name = p.name;
            description = p.description;
            id = p.id;
            price = p.price;
            currBidID = p.currBidID;
            timeLeft = p.timeLeft;

        }
    }
}
