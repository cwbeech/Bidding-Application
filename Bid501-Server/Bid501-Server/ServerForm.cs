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
        //private AddProductForm apf = new AddProductForm();

        private BindingList<Product> pList = new BindingList<Product>();

        private BindingList<User> uList = new BindingList<User>();

        public ServerForm()
        {
            InitializeComponent();
            uxProductBox.DataSource = pList;
            uxUserBox.DataSource = uList;
        }

		private void uxAddButton_Click(object sender, EventArgs e)
		{
            AddProductForm apf = new AddProductForm();
            apf.ShowDialog();
            if (apf.DialogResult == DialogResult.OK)
            {
                pList.Add(apf.toReturn);
                uxProductBox.Refresh();
                //uxProductBox.
                uxUserBox.Refresh();
                //MessageBox.Show("test");
                //code to add result to the list
                //probably need to add some delegate to update stuff - Aidan, 4/29. 
            }
		}
	}
}
