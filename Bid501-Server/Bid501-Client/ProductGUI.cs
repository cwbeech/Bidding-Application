using System;
using System.Collections;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            FormClosed += ProductGUI_FormClosed;
        }

        private void ProductGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            hpb(-1, -1);
        }

        public void UpdateProductGUI(IProductDB database)
        {
            this.database.activeItems = database.activeItems;

            if (uxProductBox.InvokeRequired)
            {
                uxProductBox.Invoke((MethodInvoker)(() => UpdateProductGUI(database)));
            }
            else if(uxProductBox.Items.Count > 0)
            {

                List<ProductProxy> pNew = this.database.itemsView.ToList<ProductProxy>();

                if(pNew.Count < prods.Count)
                {
                    IProduct placeholder = null;
                    List<ProductProxy> i = prods.ToList<ProductProxy>();

                    foreach (IProduct p in pNew)
                    {
                        if (!i.Contains(p))
                        {
                            prods.Add((ProductProxy)p);
                        }
                    }
                    foreach (IProduct p in i)
                    {
                        if (!pNew.Contains(p))
                        {
                            prods.Remove((ProductProxy)p);
                            placeholder = p;
                        }
                    }

                    if(placeholder != null)
                    {
                        if(placeholder.currBidID == clientID)
                        {
                            MessageBox.Show("You win!");
                        }
                        else
                        {
                            MessageBox.Show("You lost!");
                        }
                    }

                    foreach (IProduct p in pNew)
                    {
                        IProduct old = prods.FirstOrDefault(prod => prod.id == p.id);

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
                    foreach (IProduct p in pNew)
                    {
                        IProduct old = prods.FirstOrDefault(prod => prod.id == p.id);

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


                    int index = uxProductBox.SelectedIndex;
                    IProduct pp = uxProductBox.Items[index] as IProduct;
                    uxProductName.Text = pp.name;
                    uxTimeLeft.Text = pp.timeLeft.ToString();
                    uxMinBidAmount.Text = pp.minBid.ToString();
                    uxDetail.Text = pp.description;
                    uxBidAmount2.Value = Decimal.Ceiling(pp.minBid);
                    uxProductBox.Refresh();

                    //Show highest bidder
                    if (pp.currBidID == clientID)
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
            }
            else
            {
                prods = this.database.itemsView;
                uxProductBox.DataSource = prods;
            }
        }

        public void UpdateClient(int clientID)
        {
            this.clientID = clientID;

        }
        
        private void uxProductBox_SelectedIndexChanged(object sender, EventArgs e)
        {
			try
            {
                UpdateProductGUI(database);
            }

            //sussy catch
            catch(Exception ex)
            {
                new Exception();
            }
            
        }

        //When clicking to bid, first validate that amount is valid (> minBid), then try to send bid
        private void uxBidConfirm_Click(object sender, EventArgs e)
        {
            //get bid info
            int index = uxProductBox.SelectedIndex;
            IProduct p = uxProductBox.Items[index] as IProduct;

            //send bid info
            if (int.Parse(uxBidAmount2.Text) >= p.minBid)
            {
                hpb((decimal)int.Parse(uxBidAmount2.Text), p.id);
            }
        }
    }
}
