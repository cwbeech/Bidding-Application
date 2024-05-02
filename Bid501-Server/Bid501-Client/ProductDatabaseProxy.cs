using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public BindingList<ProductProxy> itemsView
        {
            get
            {
                BindingList<ProductProxy> result = new BindingList<ProductProxy>();
                if (activeItems != null)
                {
                    foreach (KeyValuePair<int, IProduct> i in activeItems)
                    {
                        result.Add(new ProductProxy(i.Value));
                    }
                }
                return result;
            }
        }
    }
}
