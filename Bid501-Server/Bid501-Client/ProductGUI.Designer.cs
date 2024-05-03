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
            this.uxBidAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uxProductBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uxMinBidAmount = new System.Windows.Forms.Label();
            this.uxDetail = new System.Windows.Forms.TextBox();
            this.uxHighest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxProductName
            // 
            this.uxProductName.AutoSize = true;
            this.uxProductName.Location = new System.Drawing.Point(28, 22);
            this.uxProductName.Name = "uxProductName";
            this.uxProductName.Size = new System.Drawing.Size(107, 13);
            this.uxProductName.TabIndex = 0;
            this.uxProductName.Text = "___productName___";
            // 
            // uxTimeLeft
            // 
            this.uxTimeLeft.AutoSize = true;
            this.uxTimeLeft.Location = new System.Drawing.Point(28, 55);
            this.uxTimeLeft.Name = "uxTimeLeft";
            this.uxTimeLeft.Size = new System.Drawing.Size(80, 13);
            this.uxTimeLeft.TabIndex = 1;
            this.uxTimeLeft.Text = "___timeLeft___";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Details:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Minimum bid $";
            // 
            // uxBidConfirm
            // 
            this.uxBidConfirm.Location = new System.Drawing.Point(60, 210);
            this.uxBidConfirm.Name = "uxBidConfirm";
            this.uxBidConfirm.Size = new System.Drawing.Size(75, 23);
            this.uxBidConfirm.TabIndex = 5;
            this.uxBidConfirm.Text = "Place Bid";
            this.uxBidConfirm.UseVisualStyleBackColor = true;
            this.uxBidConfirm.Click += new System.EventHandler(this.uxBidConfirm_Click);
            // 
            // uxBidAmount
            // 
            this.uxBidAmount.Location = new System.Drawing.Point(46, 148);
            this.uxBidAmount.Name = "uxBidAmount";
            this.uxBidAmount.Size = new System.Drawing.Size(71, 20);
            this.uxBidAmount.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Products";
            // 
            // uxProductBox
            // 
            this.uxProductBox.FormattingEnabled = true;
            this.uxProductBox.Location = new System.Drawing.Point(247, 34);
            this.uxProductBox.Name = "uxProductBox";
            this.uxProductBox.Size = new System.Drawing.Size(120, 199);
            this.uxProductBox.TabIndex = 8;
            this.uxProductBox.SelectedIndexChanged += new System.EventHandler(this.uxProductBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "$";
            // 
            // uxMinBidAmount
            // 
            this.uxMinBidAmount.AutoSize = true;
            this.uxMinBidAmount.Location = new System.Drawing.Point(97, 181);
            this.uxMinBidAmount.Name = "uxMinBidAmount";
            this.uxMinBidAmount.Size = new System.Drawing.Size(78, 13);
            this.uxMinBidAmount.TabIndex = 10;
            this.uxMinBidAmount.Text = "___amount___";
            // 
            // uxDetail
            // 
            this.uxDetail.Enabled = false;
            this.uxDetail.Location = new System.Drawing.Point(70, 80);
            this.uxDetail.Multiline = true;
            this.uxDetail.Name = "uxDetail";
            this.uxDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxDetail.Size = new System.Drawing.Size(165, 62);
            this.uxDetail.TabIndex = 11;
            this.uxDetail.UseWaitCursor = true;
            // 
            // uxHighest
            // 
            this.uxHighest.AutoSize = true;
            this.uxHighest.Location = new System.Drawing.Point(43, 215);
            this.uxHighest.Name = "uxHighest";
            this.uxHighest.Size = new System.Drawing.Size(113, 13);
            this.uxHighest.TabIndex = 12;
            this.uxHighest.Text = "Current Highest Bidder";
            this.uxHighest.Visible = false;
            // 
            // ProductGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 264);
            this.Controls.Add(this.uxHighest);
            this.Controls.Add(this.uxDetail);
            this.Controls.Add(this.uxMinBidAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxProductBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.uxBidAmount);
            this.Controls.Add(this.uxBidConfirm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uxTimeLeft);
            this.Controls.Add(this.uxProductName);
            this.Name = "ProductGUI";
            this.Text = "Bid501";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProductGUI_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxProductName;
        private System.Windows.Forms.Label uxTimeLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button uxBidConfirm;
        private System.Windows.Forms.TextBox uxBidAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox uxProductBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uxMinBidAmount;
        private System.Windows.Forms.TextBox uxDetail;
        private System.Windows.Forms.Label uxHighest;
    }
}