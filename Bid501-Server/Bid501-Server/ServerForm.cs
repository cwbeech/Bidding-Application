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

        private AddItemDel aid;

        private BidCloseDel bcd;

        public ServerForm(AddItemDel aid, BidCloseDel bcd)
        {
            InitializeComponent();
            uxProductBox.DataSource = pList;
            uxUserBox.DataSource = uList;
            this.aid = aid;
            this.bcd = bcd;
        }

        public void UpdateGUI(BindingList<Product> prodList, BindingList<User> clientList)
        { //note: might not need to be public - Aidan, 4/29
            pList = prodList;
            uList = clientList;
            uxProductBox.Refresh();
            uxUserBox.Refresh();
            //note: Refresh method might not work, might need to reset data sources - Aidan, 4/29. 
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
                aid(apf.toReturn);
                //MessageBox.Show("test");
                //code to add result to the list
                //probably need to add some delegate to update stuff - Aidan, 4/29. 
            }
		}

		private void uxCloseBid_Click(object sender, EventArgs e)
		{
            //I fucking swear we had to close the bids somehow, but I don't see it in the final project pdf.
            //Might just need to delete this and the button. - Aidan, 4/29. 
            bcd((Product)uxProductBox.SelectedItem);
		}
	}
}
