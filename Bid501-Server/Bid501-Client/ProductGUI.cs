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
            uxProductBox.DataSource = this.database;
            this.hpb = hpb;
            clientID = -1;
        }

        public void UpdateProductGUI()
        {
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
            uxProductName.Text = ((ProductProxy)uxProductBox.SelectedItem).name;
            //uxTimeLeft.Text = ((ProductProxy)uxProductBox.SelectedItem).time; THIS NEEDS TO BE IMPLEMENTED ON DATA STRUCTURE--------------------------------------------------
            uxMinBidAmount.Text = ((ProductProxy)uxProductBox.SelectedItem).minBid.ToString();
            uxDetail.Text = ((ProductProxy)uxProductBox.SelectedItem).description;
            if (((ProductProxy)uxProductBox.SelectedItem).currBidID == clientID)
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

        //When clicking to bid, first validate that amount is valid, then try to send bid
        private void uxBidConfirm_Click(object sender, EventArgs e)
        {
            if (int.Parse(uxBidAmount.Text) >= ((ProductProxy)uxProductBox.SelectedItem).minBid)
            {
                hpb((decimal)int.Parse(uxBidAmount.Text), ((ProductProxy)uxProductBox.SelectedItem).id);
            }
        }
    }
}
