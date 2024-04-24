using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;


namespace Bid501_Client
{
    public partial class LoginGUI : Form
    {
        private WebSocketSharp.WebSocket ws;

        public HandleLoginAttempt hla;
        private ProductDatabaseProxy database;

        public LoginGUI(IProductDB database, HandleLoginAttempt hla)
        {
            InitializeComponent();

            this.database = database as ProductDatabaseProxy;
            this.hla = hla;

            ws = new WebSocketSharp.WebSocket("ws://127.0.0.1:8001/login");
            ws.OnMessage += MessageFromServer;
            ws.Connect();
        }

        public void UpdateLoginGUI()
        {
            //basically just redraw everything.
        }

        private void MessageFromServer(object sender, MessageEventArgs e)
        {
            MessageBox.Show(e.Data.ToString());
            //if (e.Data.Equals("VALID"))
            //{
            //    MessageBox.Show("Success");
            //}
            //throw new NotImplementedException();
        }

        private void uxLogin_Click(object sender, EventArgs e)
        {
            hla(uxUsername.Text, uxPassword.Text);
        }

        //public bool MessageRecieved(string message)
        //{
        //    Invoke(new Action(() => MessageBox.Show(message.ToString())));
        //    return true;
        //}

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ws.Close();
        }
    }
}
