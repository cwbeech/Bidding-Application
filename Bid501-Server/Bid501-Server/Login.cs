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
            string[] tokens = e.Data.Split(':');
            string user = tokens[0];
            string password = tokens[1];

            int result = ctrl.LoginDel(user, password);

            Send(result.ToString());
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
}
}
}
