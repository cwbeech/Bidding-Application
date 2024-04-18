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

namespace Bid501_Server
{
	public class ServerCommunictionControl : WebSocketBehavior
	{
		public LoginAttempt LoginDel;

		private WebSocketServer wss;

		public ServerCommunictionControl()
		{
			wss = new WebSocketServer(8001);

			wss.AddWebSocketService<Login>("/login", () =>
			{
				Login loginService = new Login(this);
				return loginService;
			});

			wss.Start();
		}

		protected override void OnMessage(MessageEventArgs e)
		{
			string msg = e.Data;
			msg = msg + " Received in server.";
			//Sessions.Broadcast(msg);
			Sessions.SendTo(ID, msg);
		}
	}
}
