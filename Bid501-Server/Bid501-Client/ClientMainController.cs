﻿using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501_Client
{
    public class ClientMainController
    {
        private int clientID;
        private ProductDatabaseProxy database;
        public UpdateProductGUI upgui;
        public UpdateLoginGUI ulgui;
        public UpdateClient ucl;
        public HandleLogin hl;
        public HandleBid hb;

        public ClientMainController(IProductDB database, HandleLogin hl, HandleBid hb)
        {
            this.database = database as ProductDatabaseProxy;
            this.hl = hl;
            this.hb = hb;
        }

        public void HandleLoginAttempt(string user, string pass)
        {
            hl(user, pass);
        }

        public void HandlePlaceBid(decimal bidAmt, int prodID)
        {
            hb(bidAmt, prodID);
        }

        public void SetUpdateProductGUI(UpdateProductGUI upgui)
        {
            this.upgui = upgui;
        }

        public void SetUpdateLoginGUI(UpdateLoginGUI ulgui)
        {
            this.ulgui = ulgui;
        }

        public void SetUpdateClient(UpdateClient uc)
        {
            this.ucl = uc;
        }
        public void UpdateControl(IProductDB database, int clientID)
        {
            this.database.activeItems = database.activeItems;
            if (this.clientID != clientID) //if client is being set for the first time
            {
                ucl(clientID);
                ulgui(clientID != -1);
                this.clientID = clientID;
            }
            
            upgui(this.database);
        }

    }
}