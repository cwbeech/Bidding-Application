using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bid501_Shared;

namespace Bid501_Client
{
    public partial class ProductGUI : Form
    {
        private ProductDatabaseProxy database;
        public HandlePlaceBid hpb;
        public HandleProductSelected hps;
        public ProductGUI(IProductDB database, HandlePlaceBid hpb, HandleProductSelected hps)
        {
            InitializeComponent();
            this.database = database as ProductDatabaseProxy;
            this.hpb = hpb;
            this.hps = hps;
        }

        public void UpdateProductGUI()
        {
            uxProductBox.Refresh();
        }
        
        /// <summary>
        /// Selected index of list box changed, update everything on GUI to represent current product selected: ProductName, MinBidAmount, Detail, TimeLeft
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxProductBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            uxProductName.Text = ((ProductProxy)uxProductBox.SelectedItem).name;
            //uxTimeLeft.Text = ((ProductProxy)uxProductBox.SelectedItem).time; THIS NEEDS TO BE IMPLEMENTED ON DATA STRUCTURE--------------------------------------------------
            uxMinBidAmount.Text = ((ProductProxy)uxProductBox.SelectedItem).minBid.ToString();
            uxDetail.Text = ((ProductProxy)uxProductBox.SelectedItem).description;
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
