using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Bid501_Server
{
    /// <summary>
    /// Login service for the server
    /// </summary>
    public class Login : WebSocketBehavior
    {
        private ServerCommunictionControl ctrl;

        public Login(ServerCommunictionControl c)
        //public Login()
        {
            this.ctrl = c;
        }

        /// <summary>
        /// Parses user data, attempts login, sends 0 to client for valid, -1 for invalid login.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMessage(MessageEventArgs e)
        {
			/*string[] tokens = e.Data.Split(':');
            string user = tokens[0];
            string password = tokens[1];
            bool logout;

            int result = ctrl.LoginDel(user, password, 0, out logout);

            Send(result.ToString());*/
			//Note: Got a weird merge conflict. Wasn't sure which was current, so I'm keeping this code commented out. - Aidan, 4/29
			/*
            string User = tokens[0];
            string Password = tokens[1];
            //string message = e.Data;
            //Sessions.Broadcast(message);
            //_ctrl.LoginDel();
            //NOTE: the following lines below are for testing purposes
            sendResponse(true);
            */
			string[] msg = e.Data.Split(':');
			if (Convert.ToInt32(msg[0]) == 0)
			{//login attempt from client
			 //bool toReturn = PlaceBidDel(Convert.ToInt32(msg[0]), Convert.ToDecimal(msg[1]), Convert.ToInt32(msg[2]));
				HandleLogin(msg);
			}
			else if (Convert.ToInt32(msg[0]) == 1)
			{//place bid attempt from client
				HandleBid(msg);
			}
		}

		private void HandleLogin(string[] msg)
		{
			bool logout;
			int toReturn = ctrl.LoginDel(msg[1], msg[2], 0, out logout); //NOTE: LoginDel needs to return userid which I don't believe it currently does - Aidan, 4/30

			if (logout)
			{
				ctrl.lo(toReturn);
				ctrl.ugui(ctrl.gap(), ctrl.gau());
				Sessions.CloseSession(ID);
			}

			string aaa = JsonConvert.SerializeObject(ctrl.rd());
			string sendString = "0&" + toReturn + "&" + aaa;
			Sessions.SendTo(ID, sendString);
			ctrl.ugui(ctrl.gap(), ctrl.gau());
		}

		private void HandleBid(string[] msg)
		{
			bool bidGood = ctrl.PlaceBidDel(Convert.ToInt32(msg[1]), Convert.ToDecimal(msg[2]), Convert.ToInt32(msg[3]));
			string toSend = JsonConvert.SerializeObject(ctrl.rd());
			toSend = "1&" + toSend;
			Sessions.Broadcast(toSend);

			//foreach (WebSocketSharp.WebSocket w in ctrl.activeConnections)
			//{
			//	w.Send(toSend);
			//}
		}
	}
}
