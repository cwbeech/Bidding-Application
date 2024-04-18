using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Bid501_Server
{
    public class Login : WebSocketBehavior
    {
        private ServerCommunictionControl _ctrl;

        public Login(ServerCommunictionControl c)
        {
            this._ctrl = c;
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            //string[] tokens = e.Data.Split(':');
            //string User = tokens[0];
            //string Password = tokens[1];
            //string message = e.Data;
            //Sessions.Broadcast(message);
            //_ctrl.LoginDel();
        }

        public void sendResponse(bool result)
        {
            if (result)
            {
                Send("Valid");
            }
            else
            {
                Send("Invalid");
            }
        }
    }
}
