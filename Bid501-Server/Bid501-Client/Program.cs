using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501_Client
{
    //login delegates
    public delegate void HandleLoginAttempt(string user, string pass);
    public delegate void UpdateLoginGUI();
    //product delegates
    public delegate void HandlePlaceBid(decimal bidAmt, int prodID);
    public delegate void HandleProductSelected(IProduct p);
    public delegate void UpdateProductGUI();
    //controller delegates
    public delegate bool HandleBid(decimal bidAmt, int prodID);
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
            Application.Run(new LoginGUI());
        }
    }
}
