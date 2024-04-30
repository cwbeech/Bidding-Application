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

		private List<Product> pList = new List<Product>();

		public Product toReturn;

		public AddProductForm()
		{
			InitializeComponent(); 
			//			***IMPORTANT NOTE*** need to get proper product IDs. 
			Product nswitch = new Product("Nintendo Switch", "It annoys me that I can't just call this variable 'switch.' Also go play Fire Emblem.", (decimal)100.00);
			Product art = new Product("Renaissance Artwork", "Code me like one of your French girls. Also probably just a reproduction", (decimal)250.50);
			Product knife = new Product("Antique Knife", "'Nice Knife' - Senator Armstrong.", (decimal)80.00);
			Product horse = new Product("Racing Horse", "What's the best way to make a million dollars horse racing? Start with 2 million.", (decimal)20);
			pList.Add(nswitch);
			pList.Add(art);
			pList.Add(knife);
			pList.Add(horse);
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
