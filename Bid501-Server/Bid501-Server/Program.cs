using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp.Server;
namespace Bid501_Server
{
    public delegate int LoginAttempt(string user, string password);

    public delegate bool PlaceBidAttempt(int userid, decimal bid, int prodid);

    public delegate void AddItemDel(Product prod); //note: doesn't like it when I have question marks - Aidan, 4/29

    public delegate void BidCloseDel(Product p); //note: doesn't like it when I have question marks - Aidan, 4/29

    public delegate void UpdateGUIDel(BindingList<Product> prodList, BindingList<User> clientList); //Note: 1. changed to BindingLists compared to diagram 
				//to make updating GUIs easier. 2. In the diagram we have the second list as a list of Clients, which don't exist - Aidan, 4/29

	public delegate List<string> SendProdInfo();

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServerCommunictionControl s = new ServerCommunictionControl();
            UserDatabase ud = new UserDatabase();
            ProductDatabase pd = new ProductDatabase();
            ProductController pc = new ProductController(pd);
            WebSocketServer wss = new WebSocketServer(8001);
            wss.AddWebSocketService<Login>("/login", () =>
            {
                Login loginService = new Login(s);
                return loginService;
            });
			//***IMPORTANT NOTE*** Uncomment this line after testing
			//wss.Start(); //Note: getting a weird error here about my computer not liking using this number of sockets. Probably want to ask Jorge
			Application.EnableVisualStyles(); //about it in class - Aidan, 4/29. 
            Application.SetCompatibleTextRenderingDefault(false);
            //Note: these next two lines are dummy delegates to just let the code run for now. Delete later - Aidan, 4/29
            AddItemDel aid = new AddItemDel(Dummy);
            BidCloseDel bcd = new BidCloseDel(Dummy);
            LoginAttempt ld = new LoginAttempt(ud.LoginAttempt);
            LoginView lv = new LoginView(ld);

            Application.Run(lv);

            if (lv.isValid)
            {
                Application.Run(new ServerForm(aid, bcd));
            }
            
            
            

             

        }

        //dummy method, delete in final version - Aidan, 4/29.
        static void Dummy(Product p) { }
    }
}
