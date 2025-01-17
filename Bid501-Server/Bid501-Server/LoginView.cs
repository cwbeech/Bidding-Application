﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501_Server
{
    public partial class LoginView : Form
    {
        private LoginAttempt LoginDel;

        public bool isValid = false;

        public UpdateGUI ugui;

        public GetActiveUsers gau;

        public GetActiveProds gap;

        public LoginView(LoginAttempt ld, UpdateGUI ugui, GetActiveUsers gau, GetActiveProds gap)
        {
            this.LoginDel = ld;
            this.ugui = ugui;
            this.gau = gau;
            this.gap = gap;
            InitializeComponent();
        }

        private void UxLoginButton_Click(object sender, EventArgs e)
        {
            string user = UxUserTextBox.Text;
            string pass = UxPasswordTextBox.Text;
            bool logout;

            int loginAttempt = LoginDel(user, pass, 1, "server", out logout);

            if(loginAttempt == -1)
            {
                UxLoginStatus.Text = "Invalid Login";
                isValid = false;
            }
            else
            {
                isValid = true;
                ugui(gap(), gau());
                this.Close();
            }
        }

        private void UxLoginCancel_Click(object sender, EventArgs e)
        {
            UxUserTextBox.Clear();
            UxPasswordTextBox.Clear();
        }
    }
}
