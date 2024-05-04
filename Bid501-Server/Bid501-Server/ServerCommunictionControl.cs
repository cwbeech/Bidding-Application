using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using Newtonsoft.Json;
using System.Net.Configuration;
using Bid501_Shared;

namespace Bid501_Server
{
	public class ServerCommunictionControl : WebSocketBehavior
	{
		public UpdateGUI ugui;

		public GetActiveUsers gau;

		public LoginAttempt LoginDel;

		public PlaceBidAttempt PlaceBidDel;

		public GetActiveProds gap;

		public ReturnDatabase rd;

		public Logout lo;

        public ProductController pc;

		private WebSocketServer wss;

		private List<WebSocketSharp.WebSocket> activeConnections = new List<WebSocketSharp.WebSocket>();

		public ServerCommunictionControl(ProductController pc)
		{ 

			wss = new WebSocketServer(8001);

            this.pc = pc;

            wss.AddWebSocketService<Login>("/login", () =>
            {
            	Login loginService = new Login(this, pc);
            	return loginService;
            });
            //wss.AddWebSocketService("/login", () =>
            //{
            //	return this;
            //});
            //wss.AddWebSocketService<Login>("/login");

			wss.Start();
		}

        public void pingAllConnections()
        {
            foreach(Login ws in wss.WebSocketServices["/login"].Sessions.Sessions)
            {
                ws.Context.WebSocket.Ping();
            }
        }

        protected override void OnOpen()
        {
			base.OnOpen();
			activeConnections.Add(Context.WebSocket);
        }

        protected override void OnClose(CloseEventArgs e)
        {
			base.OnClose(e);
			activeConnections.Remove(Context.WebSocket);
        }

        public void SendPing()
        {
            //wss.Ping();
            //wss.
        }

        /// <summary>
        /// Sets the delegates for hte server communication ctrl
        /// </summary>
        /// <param name="ld"></param>
        /// <param name="pba"></param>
        /// <param name="gap"></param>
        public void SetDelegates(LoginAttempt ld, PlaceBidAttempt pba, GetActiveProds gap, ReturnDatabase rd, Logout lo, UpdateGUI ugui, GetActiveUsers gau)
		{
            this.LoginDel = ld;
            this.PlaceBidDel = pba;
            this.gap = gap;
			this.rd = rd;
			this.lo = lo;
			this.ugui = ugui;
			this.gau = gau;
        }

		/*protected override void OnMessage(MessageEventArgs e)
		{
            Task.Run(() =>
            {
            string[] msg = e.Data.Split(':');
                if (Convert.ToInt32(msg[0]) == 0)
                {//login attempt from client
                 //bool toReturn = PlaceBidDel(Convert.ToInt32(msg[0]), Convert.ToDecimal(msg[1]), Convert.ToInt32(msg[2]));
                    bool logout;
                    int toReturn = LoginDel(msg[1], msg[2], 0, out logout); //NOTE: LoginDel needs to return userid which I don't believe it currently does - Aidan, 4/30

                    if (logout)
                    {
                        lo(toReturn);
                        ugui(gap(), gau());
                        Sessions.CloseSession(ID);
                    }

                    string aaa = JsonConvert.SerializeObject(rd());
                    string sendString = "0&" + toReturn + "&" + aaa;
                    Sessions.SendTo(ID, sendString);
                    ugui(gap(), gau());

                }
                else if (Convert.ToInt32(msg[0]) == 1)
                {//place bid attempt from client
                    bool bidGood = PlaceBidDel(Convert.ToInt32(msg[1]), Convert.ToDecimal(msg[2]), Convert.ToInt32(msg[3]));
                    string toSend = JsonConvert.SerializeObject(rd());
                    toSend = "1&" + toSend;

                    foreach (WebSocketSharp.WebSocket w in activeConnections)
                    {
                        w.Send(toSend);
                    }
                    //}

                }
            });
            
		}*/
	}
}
