using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp.Server;
using Bid501_Shared;
namespace Bid501_Server
{
    public delegate int LoginAttempt(string user, string password);

    public delegate IProductDB ReturnDatabase();

    public delegate bool PlaceBidAttempt(int userid, decimal bid, int pID);

    public delegate void AddItemDel(Product prod); //note: doesn't like it when I have question marks - Aidan, 4/29

    public delegate void BidCloseDel(int pID); //note: doesn't like it when I have question marks - Aidan, 4/29

    public delegate void UpdateGUIDel(BindingList<Product> prodList, BindingList<User> clientList); //Note: 1. changed to BindingLists compared to diagram 
                                 //to make updating GUIs easier. 2. In the diagram we have the second list as a list of Clients, which don't exist - Aidan, 4/29

    public delegate BindingList<Product> GetInactiveProds();

    public delegate BindingList<Product> GetActiveProds();

    public delegate void StartProdBid(int pid);

    public delegate BindingList<User> GetActiveUsers();

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

            //the starting 4 bids for the program
            pc.StartBid(4);
            pc.StartBid(5);
            pc.StartBid(6);
            pc.StartBid(7);

            /*WebSocketServer wss = new WebSocketServer(8001);
            wss.AddWebSocketService<Login>("/login", () =>
            {
                Login loginService = new Login(s);
                return loginService;
            });*/
			//***IMPORTANT NOTE*** Uncomment this line after testing
			//wss.Start(); //Note: getting a weird error here about my computer not liking using this number of sockets. Probably want to ask Jorge
			Application.EnableVisualStyles(); //about it in class - Aidan, 4/29. 
            Application.SetCompatibleTextRenderingDefault(false);
            //Note: these next two lines are dummy delegates to just let the code run for now. Delete later - Aidan, 4/29
            //AddItemDel aid = new AddItemDel(Dummy);
            //BidCloseDel bcd = new BidCloseDel(Dummy);
            AddItemDel aid = new AddItemDel(pc.AddProduct);
            BidCloseDel bcd = new BidCloseDel(pc.BidClosed);
            LoginAttempt ld = new LoginAttempt(ud.LoginAttempt);
            GetActiveProds gap = new GetActiveProds(pc.GetActiveProds);
            GetInactiveProds gip = new GetInactiveProds(pc.GetInactiveProds);
            StartProdBid spb = new StartProdBid(pc.StartBid);
            GetActiveUsers gau = new GetActiveUsers(ud.GetActiveUsers);
            LoginView lv = new LoginView(ld);
            PlaceBidAttempt pba = new PlaceBidAttempt(pc.PlaceBidAttempt);
            ReturnDatabase rd = new ReturnDatabase(pc.ReturnDatabase);
            s.SetDelegates(ld, pba, gap, rd);

            Application.Run(lv);

            if (lv.isValid)
            {
                Application.Run(new ServerForm(aid, bcd, gip, gap, spb, gau));
            }
            
            
            

             

        }

        //dummy method, delete in final version - Aidan, 4/29.
        static void Dummy(Product p) { }
    }
}
