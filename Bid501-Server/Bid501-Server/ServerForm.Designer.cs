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
			this.SuspendLayout();
			// 
			// uxAddButton
			// 
			this.uxAddButton.Location = new System.Drawing.Point(97, 364);
			this.uxAddButton.Name = "uxAddButton";
			this.uxAddButton.Size = new System.Drawing.Size(75, 23);
			this.uxAddButton.TabIndex = 0;
			this.uxAddButton.Text = "Add Product";
			this.uxAddButton.UseVisualStyleBackColor = true;
			this.uxAddButton.Click += new System.EventHandler(this.uxAddButton_Click);
			// 
			// ServerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.uxAddButton);
			this.Name = "ServerForm";
			this.Text = "ServerForm";
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button uxAddButton;
	}
}

