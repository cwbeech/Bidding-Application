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
    public partial class LoginForm : Form
    {
        private WebSocketSharp.WebSocket ws;
        public LoginForm()
        {
            InitializeComponent();
            ws = new WebSocketSharp.WebSocket("ws://127.0.0.1:8001/login");
            ws.OnMessage += MessageFromServer;
            ws.Connect();

        }

        private void MessageFromServer(object sender, MessageEventArgs e)
        {
            if (e.Data.Equals("VALID"))
            {
                MessageBox.Show("Success");
            }
            //throw new NotImplementedException();
        }

        //private void Close()
        //{
        //    ws.Close();
        //}

        private void uxLogin_Click(object sender, EventArgs e)
        {
            string username = uxUsername.Text;
            string password = uxPassword.Text;
            ws.Send("Username: "+username+"\nPassword: "+password);

        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ws.Close();

        }
    }
}
