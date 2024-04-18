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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
