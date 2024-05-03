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
using Newtonsoft.Json.Linq;

namespace Bid501_Client
{
    public class ClientCommunicationController
    {
        private WebSocketSharp.WebSocket ws;

        private int clientID;
        public ProductDatabaseProxy database;

        public UpdateControl uc;

        public ClientCommunicationController()
        {
            //websocket stuff
            ws = new WebSocketSharp.WebSocket("ws://127.0.0.1:8001/login"); //personal machine's IP
            //ws = new WebSocketSharp.WebSocket("ws://10.150.109.119:8001/login"); //Aidan's IP
            //ws = new WebSocketSharp.WebSocket("ws://192.168.0.63:8001/login");
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
                string toDeserialize = message.Split('&')[2];

                JObject jObject = JObject.Parse(toDeserialize);
                JObject activeItemsJson = (JObject)jObject["activeItems"];
                Dictionary<int, IProduct> items = new Dictionary<int, IProduct>();

                foreach(JProperty j in activeItemsJson.Properties())
                {
                    JObject pData = (JObject)j.Value;

                    string name = (string)pData["name"];
                    string description = (string)pData["description"];
                    int productID = (int)pData["id"];
                    decimal price = (decimal)pData["price"];
                    int currBidID = (int)pData["currBidID"];
                    DateTime timeLeft = (DateTime)pData["timeLeft"];

                    ProductProxy p = new ProductProxy()
                    {
                        name = name,
                        description = description,
                        id = productID,
                        price = price,
                        currBidID = currBidID,
                        timeLeft = timeLeft,
                    };

                    items.Add(productID, (IProduct)p);
                }

             

                database.activeItems = items;
            }
            else if (message[0] == '1') //bid
            {
                string toDeserialize = message.Split('&')[1];
                JObject jObject = JObject.Parse(toDeserialize);
                JObject activeItemsJson = (JObject)jObject["activeItems"];
                Dictionary<int, IProduct> items = new Dictionary<int, IProduct>();

                foreach (JProperty j in activeItemsJson.Properties())
                {
                    JObject pData = (JObject)j.Value;

                    string name = (string)pData["name"];
                    string description = (string)pData["description"];
                    int productID = (int)pData["id"];
                    decimal price = (decimal)pData["price"];
                    int currBidID = (int)pData["currBidID"];
                    DateTime timeLeft = (DateTime)pData["timeLeft"];

                    ProductProxy p = new ProductProxy()
                    {
                        name = name,
                        description = description,
                        id = productID,
                        price = price,
                        currBidID = currBidID,
                        timeLeft = timeLeft,
                    };

                    items.Add(productID, (IProduct)p);
                }



                database.activeItems = items;
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
            //clientID = 1;
            //database.activeItems = DummyValues.GetDatabase().activeItems;
            //uc(database, clientID);
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
