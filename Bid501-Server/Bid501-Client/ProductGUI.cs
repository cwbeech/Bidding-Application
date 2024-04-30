﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501_Client
{
    public partial class ProductGUI : Form
    {
        ProductDatabaseProxy database = new ProductDatabaseProxy();
        //NEEDS TO BE SET SOMETIME DURING SETUP
        public ProductGUI()
        {
            InitializeComponent();
            uxProductBox.DataSource = database.activeItems;
        }

        //When selected index changed, update pretty much everything: ProductName, timeLeft, minBidAmount, NumofBids, match current item selected
        private void uxProductBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TWO ITEMS ARE NOT IMPLEMENTED ON THIS LIST
            uxProductName.Text = ((ProductProxy)uxProductBox.SelectedItem).name;
            //uxTimeLeft.Text = ((ProductProxy)uxProductBox.SelectedItem).time;
            uxMinBidAmount.Text = ((ProductProxy)uxProductBox.SelectedItem).minBid.ToString();
            uxDetail.Text = ((ProductProxy)uxProductBox.SelectedItem).description;
        }

        //When clicking to bid, first validate that amount is valid, then try to send bid
        private void uxBidConfirm_Click(object sender, EventArgs e)
        {
            if (int.Parse(uxBidAmount.Text) >= ((ProductProxy)uxProductBox.SelectedItem).minBid)
            {
                //sEND bID
            }
        }
    }
}
