﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
