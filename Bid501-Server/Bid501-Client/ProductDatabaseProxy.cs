using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Shared;

namespace Bid501_Client
{
    public class ProductDatabaseProxy : IProductDB
    {
        private Dictionary<int, IProduct> _activeItems;
        public Dictionary<int, IProduct> activeItems
        {
            get
            {
                return _activeItems;
            }
            set
            {
                _activeItems = value;
            }
        }
    }
}
