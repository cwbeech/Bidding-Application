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
        private ProductDatabaseProxy database;
        public HandleLoginAttempt hla;

        public LoginGUI(IProductDB database, HandleLoginAttempt hla)
        {
            InitializeComponent();

            this.database = database as ProductDatabaseProxy;
            this.hla = hla;

        }

        public void UpdateLoginGUI()
        {
            
        }

        private void uxLogin_Click(object sender, EventArgs e)
        {
            hla(uxUsername.Text, uxPassword.Text);
        }

    }
}
