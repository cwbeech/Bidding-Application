namespace Bid501_Server
{
    partial class ServerForm
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
			this.uxAddButton = new System.Windows.Forms.Button();
			this.uxUserBox = new System.Windows.Forms.ListBox();
			this.uxProductBox = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// uxAddButton
			// 
			this.uxAddButton.Location = new System.Drawing.Point(169, 332);
			this.uxAddButton.Name = "uxAddButton";
			this.uxAddButton.Size = new System.Drawing.Size(75, 23);
			this.uxAddButton.TabIndex = 0;
			this.uxAddButton.Text = "Add Product";
			this.uxAddButton.UseVisualStyleBackColor = true;
			this.uxAddButton.Click += new System.EventHandler(this.uxAddButton_Click);
			// 
			// uxUserBox
			// 
			this.uxUserBox.FormattingEnabled = true;
			this.uxUserBox.Location = new System.Drawing.Point(209, 36);
			this.uxUserBox.Name = "uxUserBox";
			this.uxUserBox.Size = new System.Drawing.Size(169, 290);
			this.uxUserBox.TabIndex = 1;
			// 
			// uxProductBox
			// 
			this.uxProductBox.FormattingEnabled = true;
			this.uxProductBox.Location = new System.Drawing.Point(34, 36);
			this.uxProductBox.Name = "uxProductBox";
			this.uxProductBox.Size = new System.Drawing.Size(169, 290);
			this.uxProductBox.TabIndex = 2;
			// 
			// ServerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(427, 378);
			this.Controls.Add(this.uxProductBox);
			this.Controls.Add(this.uxUserBox);
			this.Controls.Add(this.uxAddButton);
			this.Name = "ServerForm";
			this.Text = "ServerForm";
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button uxAddButton;
		private System.Windows.Forms.ListBox uxUserBox;
		private System.Windows.Forms.ListBox uxProductBox;
	}
}

