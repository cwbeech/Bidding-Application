using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Bid501_Server
{
	public class ServerCommunictionControl : WebSocketBehavior
	{
		protected override void OnMessage(OdbcInfoMessageEventArgs e)
		{

		}
	}
}
