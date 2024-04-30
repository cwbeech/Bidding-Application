using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501_Client
{
    //login delegates
    public delegate bool HandleLoginAttempt(string user, string pass);
    public delegate void UpdateLoginGUI();
    //product delegates
    public delegate void HandlePlaceBid(decimal bidAmt, int prodID);
    public delegate void HandleProductSelected(IProduct p);
    public delegate void UpdateProductGUI();
    //controller delegates
    public delegate void HandleBid(decimal bidAmt, int prodID);
    public delegate bool HandleLogin(string user, string pass);
    public delegate void UpdateControl(IProductDB database);
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ClientCommunicationController ccc = new ClientCommunicationController();
            ClientMainController cmc = new ClientMainController(ccc.database, ccc.HandleLogin, ccc.HandleBid);

            LoginGUI lg = new LoginGUI(cmc.HandleLoginAttempt);
            ProductGUI pg = new ProductGUI(ccc.database, cmc.HandlePlaceBid, cmc.HandleProductSelected,-1);
            cmc.SetUpdateLoginGUI(lg.UpdateLoginGUI);
            cmc.SetUpdateProductGUI(pg.UpdateProductGUI);
            Application.Run(lg);
        }
    }
}
