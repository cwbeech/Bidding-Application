using System;
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

        public LoginView()
        {
            InitializeComponent();
        }

        private void UxLoginButton_Click(object sender, EventArgs e)
        {
            string user = UxUserTextBox.Text;
            string pass = UxPasswordTextBox.Text;

            LoginDel(user, pass);
        }

        private void UxLoginCancel_Click(object sender, EventArgs e)
        {
            UxUserTextBox.Clear();
            UxPasswordTextBox.Clear();
        }
    }
}
