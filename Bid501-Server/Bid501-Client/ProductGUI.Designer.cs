namespace Bid501_Client
{
    partial class ProductGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxProductName = new System.Windows.Forms.Label();
            this.uxTimeLeft = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uxBidConfirm = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.uxProductBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uxMinBidAmount = new System.Windows.Forms.Label();
            this.uxDetail = new System.Windows.Forms.TextBox();
            this.uxHighest = new System.Windows.Forms.Label();
            this.uxBidAmount2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.uxBidAmount2)).BeginInit();
            this.SuspendLayout();
            // 
            // uxProductName
            // 
            this.uxProductName.AutoSize = true;
            this.uxProductName.Location = new System.Drawing.Point(42, 34);
            this.uxProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxProductName.Name = "uxProductName";
            this.uxProductName.Size = new System.Drawing.Size(178, 20);
            this.uxProductName.TabIndex = 0;
            this.uxProductName.Text = "Please Select a Product";
            // 
            // uxTimeLeft
            // 
            this.uxTimeLeft.AutoSize = true;
            this.uxTimeLeft.Location = new System.Drawing.Point(42, 85);
            this.uxTimeLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxTimeLeft.Name = "uxTimeLeft";
            this.uxTimeLeft.Size = new System.Drawing.Size(0, 20);
            this.uxTimeLeft.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Details:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 278);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Minimum bid $";
            // 
            // uxBidConfirm
            // 
            this.uxBidConfirm.Location = new System.Drawing.Point(90, 323);
            this.uxBidConfirm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxBidConfirm.Name = "uxBidConfirm";
            this.uxBidConfirm.Size = new System.Drawing.Size(112, 35);
            this.uxBidConfirm.TabIndex = 5;
            this.uxBidConfirm.Text = "Place Bid";
            this.uxBidConfirm.UseVisualStyleBackColor = true;
            this.uxBidConfirm.Click += new System.EventHandler(this.uxBidConfirm_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(418, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Products";
            // 
            // uxProductBox
            // 
            this.uxProductBox.FormattingEnabled = true;
            this.uxProductBox.ItemHeight = 20;
            this.uxProductBox.Location = new System.Drawing.Point(370, 52);
            this.uxProductBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxProductBox.Name = "uxProductBox";
            this.uxProductBox.Size = new System.Drawing.Size(178, 304);
            this.uxProductBox.TabIndex = 8;
            this.uxProductBox.SelectedIndexChanged += new System.EventHandler(this.uxProductBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 232);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "$";
            // 
            // uxMinBidAmount
            // 
            this.uxMinBidAmount.AutoSize = true;
            this.uxMinBidAmount.Location = new System.Drawing.Point(146, 278);
            this.uxMinBidAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxMinBidAmount.Name = "uxMinBidAmount";
            this.uxMinBidAmount.Size = new System.Drawing.Size(0, 20);
            this.uxMinBidAmount.TabIndex = 10;
            // 
            // uxDetail
            // 
            this.uxDetail.Enabled = false;
            this.uxDetail.Location = new System.Drawing.Point(105, 123);
            this.uxDetail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxDetail.Multiline = true;
            this.uxDetail.Name = "uxDetail";
            this.uxDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxDetail.Size = new System.Drawing.Size(246, 93);
            this.uxDetail.TabIndex = 11;
            this.uxDetail.UseWaitCursor = true;
            // 
            // uxHighest
            // 
            this.uxHighest.AutoSize = true;
            this.uxHighest.Location = new System.Drawing.Point(64, 331);
            this.uxHighest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxHighest.Name = "uxHighest";
            this.uxHighest.Size = new System.Drawing.Size(171, 20);
            this.uxHighest.TabIndex = 12;
            this.uxHighest.Text = "Current Highest Bidder";
            this.uxHighest.Visible = false;
            // 
            // uxBidAmount2
            // 
            this.uxBidAmount2.Location = new System.Drawing.Point(69, 229);
            this.uxBidAmount2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxBidAmount2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.uxBidAmount2.Name = "uxBidAmount2";
            this.uxBidAmount2.Size = new System.Drawing.Size(118, 26);
            this.uxBidAmount2.TabIndex = 13;
            // 
            // ProductGUI
            // 
            this.AcceptButton = this.uxBidConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 406);
            this.Controls.Add(this.uxBidAmount2);
            this.Controls.Add(this.uxHighest);
            this.Controls.Add(this.uxDetail);
            this.Controls.Add(this.uxMinBidAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxProductBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.uxBidConfirm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uxTimeLeft);
            this.Controls.Add(this.uxProductName);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProductGUI";
            this.Text = "Bid501";
            ((System.ComponentModel.ISupportInitialize)(this.uxBidAmount2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxProductName;
        private System.Windows.Forms.Label uxTimeLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button uxBidConfirm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox uxProductBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uxMinBidAmount;
        private System.Windows.Forms.TextBox uxDetail;
        private System.Windows.Forms.Label uxHighest;
        private System.Windows.Forms.NumericUpDown uxBidAmount2;
    }
}