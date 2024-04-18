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

        public Login(ServerCommunictionControl ctrl)
        {
            this.ctrl = ctrl;
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
        }
    }
}
