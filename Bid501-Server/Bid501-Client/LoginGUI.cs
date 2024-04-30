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

        public LoginGUI(HandleLoginAttempt hla)
        {
            //setup
            InitializeComponent();
            this.hla = hla;
            //gui stuff
            uxPassword.Enabled = false;
            uxLogin.Enabled = false;
            uxUsername.TextChanged += UxUsername_TextChanged;
            uxPassword.TextChanged += UxPassword_TextChanged;
        }

        private void UxPassword_TextChanged(object sender, EventArgs e)
        {
            uxLogin.Enabled = true;
        }

        private void UxUsername_TextChanged(object sender, EventArgs e)
        {
            uxPassword.Enabled = true;
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
