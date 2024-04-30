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
	public partial class AddProductForm : Form
	{
		private GetInactiveProds gip;

		private BindingList<Product> pList = new BindingList<Product>();

		public Product toReturn;

		public AddProductForm(GetInactiveProds gip)
		{
			InitializeComponent();
			this.gip = gip;
			pList = gip();
			uxProductBox.DataSource = pList;
		}

		private void uxAddButton_Click(object sender, EventArgs e)
		{
			//note: this needs to return something to the main form. 
			toReturn = (Product)uxProductBox.SelectedItem;
			//DialogResult.OK;
			this.Close();
		}
	}
}
