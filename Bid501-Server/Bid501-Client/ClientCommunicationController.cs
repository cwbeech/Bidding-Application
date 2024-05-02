using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using Newtonsoft.Json;
using System.Net.WebSockets;

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
            //ws = new WebSocketSharp.WebSocket("ws://10.150.109.119:8001/login");
            database = new ProductDatabaseProxy();
            ws.OnMessage += MessageFromServer;
            ws.Connect();
        }

        private void MessageFromServer(object sender, MessageEventArgs e)
        {
            Deserialize(e.Data);
        }

        public void Deserialize(string message)
        {
            if (message[0] == '0') //login
            {
                clientID = int.Parse(message.Split('&')[1]);
                database = JsonConvert.DeserializeObject<IProductDB>(message.Split('&')[2]) as ProductDatabaseProxy;
            }
            else if (message[0] == '1') //bid
            {
                database = JsonConvert.DeserializeObject<IProductDB>(message.Split('&')[1]) as IProductDB as ProductDatabaseProxy;
            }
            else
            {
                throw new Exception("Deserialization fail");
            }
            uc(database, clientID);
        }

        public void HandleLogin(string user, string pass)
        {
            ws.Send("0:" + user + ":" + pass);
            // For testing ProductGUI
            clientID = 1;
            database.activeItems = DummyValues.GetDatabase().activeItems;
            uc(database, clientID);
        }

        public void HandleBid(decimal bidAmt, int prodID)
        {
            ws.Send("1:" + clientID + ":" + bidAmt + ":" + prodID);
        }

        public void SetUpdateControl(UpdateControl uc)
        {
            this.uc = uc;
        }
    }
}
