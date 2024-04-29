namespace Bid501_Server
{
	partial class AddProductForm
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
			this.uxProductBox = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// uxAddButton
			// 
			this.uxAddButton.Location = new System.Drawing.Point(29, 372);
			this.uxAddButton.Name = "uxAddButton";
			this.uxAddButton.Size = new System.Drawing.Size(75, 23);
			this.uxAddButton.TabIndex = 0;
			this.uxAddButton.Text = "Add";
			this.uxAddButton.UseVisualStyleBackColor = true;
			this.uxAddButton.Click += new System.EventHandler(this.uxAddButton_Click);
			// 
			// uxProductBox
			// 
			this.uxProductBox.FormattingEnabled = true;
			this.uxProductBox.Location = new System.Drawing.Point(29, 24);
			this.uxProductBox.Name = "uxProductBox";
			this.uxProductBox.Size = new System.Drawing.Size(198, 342);
			this.uxProductBox.TabIndex = 3;
			// 
			// AddProductForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(280, 450);
			this.Controls.Add(this.uxProductBox);
			this.Controls.Add(this.uxAddButton);
			this.Name = "AddProductForm";
			this.Text = "AddProductForm";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button uxAddButton;
		private System.Windows.Forms.ListBox uxProductBox;
	}
}