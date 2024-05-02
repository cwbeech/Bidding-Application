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
		public LoginAttempt LoginDel;

		public PlaceBidAttempt PlaceBidDel;

		public GetActiveProds gap;

		public ReturnDatabase rd;

		private WebSocketServer wss;

		public ServerCommunictionControl()
		{ 

			wss = new WebSocketServer(8001);

			//wss.AddWebSocketService<Login>("/login", () =>
			//{
			//	Login loginService = new Login(this);
			//	return loginService;
			//});
			wss.AddWebSocketService("/login", () =>
			{
				return this;
			});

			wss.Start();
		}

		/// <summary>
		/// Sets the delegates for hte server communication ctrl
		/// </summary>
		/// <param name="ld"></param>
		/// <param name="pba"></param>
		/// <param name="gap"></param>
		public void SetDelegates(LoginAttempt ld, PlaceBidAttempt pba, GetActiveProds gap, ReturnDatabase rd)
		{
            this.LoginDel = ld;
            this.PlaceBidDel = pba;
            this.gap = gap;
			this.rd = rd;
        }

		protected override void OnMessage(MessageEventArgs e)
		{
			/*string msg = e.Data;
			msg = msg + " Received in server.";
			//Sessions.Broadcast(msg);
			Sessions.SendTo(ID, msg);*/

			//string[] msg = e.Data.Split(':');
			string[] msg = e.Data.Split(':');
			if (Convert.ToInt32(msg[0]) == 0)
			{//login attempt from client
			 //bool toReturn = PlaceBidDel(Convert.ToInt32(msg[0]), Convert.ToDecimal(msg[1]), Convert.ToInt32(msg[2]));
				int toReturn = LoginDel(msg[1], msg[2], 0); //NOTE: LoginDel needs to return userid which I don't believe it currently does - Aidan, 4/30
				string aaa = JsonConvert.SerializeObject(rd());
				string sendString = "0&" + toReturn + "&" + aaa;
				Sessions.SendTo(ID, sendString);
			}
			else if (Convert.ToInt32(msg[0]) == 1)
			{//place bid attempt from client
				bool bidGood = PlaceBidDel(Convert.ToInt32(msg[1]), Convert.ToDecimal(msg[2]), Convert.ToInt32(msg[3]));
				//if (bidGood)
				//{
				//**Note** Client side wants the database regardless of whether the bid went through or not, so I commented out these liens - Aidan, 5/1
					//List<Product> sendList = gap().ToList<Product>();
					IProductDB sendDB = rd();
					string toSend = JsonConvert.SerializeObject(sendDB);
					toSend = "1&" + toSend;
					Sessions.Broadcast(toSend);
				//}

			}
			

		}
	}
}
