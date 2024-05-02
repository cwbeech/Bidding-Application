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

        public BindingList<IProduct> itemsView
        {
            get
            {
                BindingList<IProduct> result = new BindingList<IProduct>();
                if (activeItems != null)
                {
                    foreach (KeyValuePair<int, IProduct> i in activeItems)
                    {
                        result.Add(i.Value);
                    }
                }
                return result;
            }
        }
    }
}
