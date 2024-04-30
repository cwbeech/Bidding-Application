using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Client
{
    public class ClientMainController
    {
        private int clientID;
        private ProductDatabaseProxy database;
        public UpdateProductGUI upgui;
        public UpdateLoginGUI ulgui;
        public HandleLogin hl;
        public HandleBid hb;

        public ClientMainController(IProductDB database, HandleLogin hl, HandleBid hb)
        {
            this.database = database as ProductDatabaseProxy;
            this.hl = hl;
            this.hb = hb;
        }

        public bool HandleLoginAttempt(string user, string pass)
        {
            return false;
        }

        public bool HandlePlaceBid(decimal bidAmt, int prodID)
        {
            return false;
        }

        public void HandleProductSelected(IProduct p)
        {

        }

        public void SetUpdateProductGUI(UpdateProductGUI upgui)
        {
            this.upgui = upgui;
        }

        public void SetUpdateLoginGUI(UpdateLoginGUI ulgui)
        {
            this.ulgui = ulgui;
        }

        public void UpdateControl(IProductDB database)
        {

        }

    }
}
