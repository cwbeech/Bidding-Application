using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp.Server;
namespace Bid501_Server
{
    public delegate int LoginAttempt(string user, string password);

    public delegate bool PlaceBidAttempt(int userid, decimal bid, Product p);

    public delegate List<string> SendProdInfo(Product p);

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServerCommunictionControl s = new ServerCommunictionControl();
            WebSocketServer wss = new WebSocketServer(8001);
            wss.AddWebSocketService<Login>("/login", () =>
            {
                Login loginService = new Login(s);
                return loginService;
            });
            //wss.Start(); //Note: getting a weird error here about my computer not liking using this number of sockets. Probably want to ask Jorge
            Application.EnableVisualStyles(); //about it in class - Aidan, 4/29. 
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerForm());
            //***IMPORTANT NOTE*** Testing line. Delete in final version. 

        }
    }
}
