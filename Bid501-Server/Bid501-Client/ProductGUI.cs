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
        //make list for products of whatever form
        public ProductGUI()
        {
            InitializeComponent();
            //Set up listbox
        }

        //When selected index changed, update pretty much everything: ProductName, timeLeft, minBidAmount, NumofBids, match current item selected
        private void uxProductBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //When clicking to bid, first validate that amount is valid (> minBid), then try to send bid
        private void uxBidConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}