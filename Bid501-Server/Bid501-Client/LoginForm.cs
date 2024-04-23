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
            ws = new WebSocketSharp.WebSocket("ws://10.130.160.19:8001/login"); //NOTE: might not want to hardcode this, might want to ask user for ip address - Aidan
            ws.OnMessage += MessageFromServer;
            ws.Connect();
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
            string username = uxUsername.Text;
            string password = uxPassword.Text;
            //MessageBox.Show("Username: " + username + "\nPassword: " + password);
            ws.Send("Username: "+username+"\nPassword: "+password);

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
