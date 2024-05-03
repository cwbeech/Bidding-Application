using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bid501_Shared;

namespace Bid501_Client
{
    public partial class ProductGUI : Form
    {
        private ProductDatabaseProxy database;
        private int clientID;

        public HandlePlaceBid hpb;
        public BindingList<ProductProxy> prods;

        public ProductGUI(IProductDB database, HandlePlaceBid hpb)
        {
            InitializeComponent();
            this.database = database as ProductDatabaseProxy;
            this.hpb = hpb;
            clientID = -1;
            uxProductBox.SelectedIndex = 0;//mebby delete this
            FormClosed += ProductGUI_FormClosed;
        }

        private void ProductGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            hpb(-1, -1);
        }

        public void UpdateProductGUI(IProductDB database)
        {
            /*uxBidAmount.Show();
            //uxBidConfirm.Show();
            uxProductName.Show();
            uxTimeLeft.Show();*/
            //uxMinBidAmount.Show();
            this.database.activeItems = database.activeItems;

            if (uxProductBox.InvokeRequired)
            {
                uxProductBox.Invoke((MethodInvoker)(() => UpdateProductGUI(database)));
            }
            else if(uxProductBox.Items.Count > 0)
            {
                BindingList<ProductProxy> pNew = this.database.itemsView;
                List<ProductProxy> i = new List<ProductProxy>();



                foreach (IProduct p in pNew)
                {
                    IProduct old = prods.First(prod => prod.id == p.id);
                    IProduct modified;

                    if (old != null)
                    {
                        old.price = p.price;
                        old.currBidID = p.currBidID;
                    }
                    else
                    {
                        prods.Add((ProductProxy)p);
                    }
                }

                uxProductBox.Refresh();
            }
            else
            {
                prods = this.database.itemsView;
                uxProductBox.DataSource = prods;
            }


            //await Task.Delay(500);
            //uxProductBox.Refresh();
        }

        public void UpdateClient(int clientID)
        {
            this.clientID = clientID;

        }
        
        /// <summary>
        /// Selected index of list box changed, update everything on GUI to represent current product selected: ProductName, MinBidAmount, Detail, TimeLeft.
        /// Also updates if clientID is the current highest bidder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxProductBox_SelectedIndexChanged(object sender, EventArgs e)
        {
			//uxBidAmount.Show();
			//uxBidConfirm.Show();
			//uxProductName.Show();
			//uxTimeLeft.Show();
            //uxMinBidAmount.Show();
			try
            {
                int index = uxProductBox.SelectedIndex;
                IProduct p = uxProductBox.Items[index] as IProduct;
                uxProductName.Text = p.name;
                uxTimeLeft.Text = p.timeLeft.ToString(); //THIS NEEDS TO BE IMPLEMENTED ON DATA STRUCTURE--------------------------------------------------
                uxMinBidAmount.Text = p.minBid.ToString();
                uxDetail.Text = p.description;
                if (p.currBidID == clientID)
                {
                    MessageBox.Show("You are current highest bidder");
                    //uxHighest.Visible = true;
                    //uxBidConfirm.Visible = false;
                }
                else
                {
                    uxHighest.Visible = false;
                    uxBidConfirm.Visible = true;
                }
            } catch(Exception ex)
            {
                new Exception();
            }
            
        }

        //When clicking to bid, first validate that amount is valid (> minBid), then try to send bid
        private void uxBidConfirm_Click(object sender, EventArgs e)
        {
            int index = uxProductBox.SelectedIndex;
            IProduct p = uxProductBox.Items[index] as IProduct;
            if (int.Parse(uxBidAmount.Text) >= p.minBid)
            {
                hpb((decimal)int.Parse(uxBidAmount.Text), p.id);
            }
        }
    }
}
