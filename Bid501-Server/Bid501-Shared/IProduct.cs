using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public interface IProduct
    {
        string name { get; set; }

        string description { get; set; }

        int id { get; set; }

        decimal price { get; set; }

        decimal minBid { get; } //note: don't know if it will 
        //allow you to return price in the getter here - Aidan

        int currBidID { get; set; }

        DateTime timeLeft { get; set; }
    }
}
