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
		protected override void OnMessage(MessageEventArgs e)
		{
			string msg = e.Data;
			msg = msg + " Received in server.";
			Sessions.Broadcast(msg);
		}
	}
}
