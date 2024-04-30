using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public interface IProductDB
    {
        Dictionary<int, IProduct> activeItems { get; set; }
        //don't know if we can include this - Aidan
    }
}
