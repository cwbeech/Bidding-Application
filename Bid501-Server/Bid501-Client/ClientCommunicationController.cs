using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace Bid501_Client
{
    public class ClientCommunicationController
    {
        private WebSocketSharp.WebSocket ws;
        private int clientID;
        public ProductDatabaseProxy database;
        public KeyValuePair<IProduct, decimal> bids;
        public UpdateControl uc;

        public ClientCommunicationController()
        {
            //websocket stuff
            ws = new WebSocketSharp.WebSocket("ws://127.0.0.1:8001/login");
            ws.OnMessage += MessageFromServer;
            ws.Connect();
        }

        private void MessageFromServer(object sender, MessageEventArgs e)
        {
            MessageBox.Show(e.Data.ToString());
        }

        public void Deserialize()
        {

        }

        public bool HandleLogin(string user, string pass)
        {
            return false;
        }

        public void HandleBid(decimal bidAmt, int prodID)
        {
            
        }

    }
}
