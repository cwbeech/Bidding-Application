using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
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

        public ProductGUI(IProductDB database, HandlePlaceBid hpb)
        {
            InitializeComponent();
            this.database = database as ProductDatabaseProxy;
            uxProductBox.DataSource = this.database.itemsView;
            this.hpb = hpb;
            clientID = -1;
        }

        public void UpdateProductGUI(IProductDB database)
        {
            this.database.activeItems = database.activeItems;
            uxProductBox.DataSource = this.database.itemsView;
            uxProductBox.Refresh();
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
            
            uxProductName.Text = (uxProductBox.SelectedItem as IProduct).name;
            uxTimeLeft.Text = (uxProductBox.SelectedItem as IProduct).timeLeft.ToString(); //THIS NEEDS TO BE IMPLEMENTED ON DATA STRUCTURE--------------------------------------------------
            uxMinBidAmount.Text = (uxProductBox.SelectedItem as IProduct).minBid.ToString();
            uxDetail.Text = (uxProductBox.SelectedItem as IProduct).description;
            if ((uxProductBox.SelectedItem as IProduct).currBidID == clientID)
            {
                uxHighest.Visible = true;
                uxBidConfirm.Visible = false;
            }
            else
            {
                uxHighest.Visible = false;
                uxBidConfirm.Visible = true;
            }
            
        }

        //When clicking to bid, first validate that amount is valid (> minBid), then try to send bid
        private void uxBidConfirm_Click(object sender, EventArgs e)
        {
            if (int.Parse(uxBidAmount.Text) >= (uxProductBox.SelectedItem as IProduct).minBid)
            {
                hpb((decimal)int.Parse(uxBidAmount.Text), (uxProductBox.SelectedItem as IProduct).id);
            }
        }
    }
}
