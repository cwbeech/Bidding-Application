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
    public partial class ServerForm : Form
    {
        private AddProductForm apf = new AddProductForm();
        public ServerForm()
        {
            InitializeComponent();

        }

		private void uxAddButton_Click(object sender, EventArgs e)
		{
            apf.Show();
		}
	}
}
