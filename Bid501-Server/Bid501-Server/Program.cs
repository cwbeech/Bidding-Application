using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp.Server;
namespace Bid501_Server
{
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
            wss.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
