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

        public LoginView(LoginAttempt ld)
        {
            this.LoginDel = ld;
            InitializeComponent();
        }

        private void UxLoginButton_Click(object sender, EventArgs e)
        {
            string user = UxUserTextBox.Text;
            string pass = UxPasswordTextBox.Text;

            int loginAttempt = LoginDel(user, pass);

            if(loginAttempt == -1)
            {
                UxLoginStatus.Text = "Invalid Login";
                isValid = false;
            }
            else
            {
                isValid = true;
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
