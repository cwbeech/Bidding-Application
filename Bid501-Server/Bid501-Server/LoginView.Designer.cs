﻿
namespace Bid501_Server
{
    partial class LoginView
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
            this.UxUserTextBox = new System.Windows.Forms.TextBox();
            this.UxPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UxLoginButton = new System.Windows.Forms.Button();
            this.UxLoginCancel = new System.Windows.Forms.Button();
            this.UxLoginStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UxUserTextBox
            // 
            this.UxUserTextBox.Location = new System.Drawing.Point(93, 66);
            this.UxUserTextBox.Name = "UxUserTextBox";
            this.UxUserTextBox.Size = new System.Drawing.Size(195, 20);
            this.UxUserTextBox.TabIndex = 0;
            // 
            // UxPasswordTextBox
            // 
            this.UxPasswordTextBox.Location = new System.Drawing.Point(93, 104);
            this.UxPasswordTextBox.Name = "UxPasswordTextBox";
            this.UxPasswordTextBox.Size = new System.Drawing.Size(195, 20);
            this.UxPasswordTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(149, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 31);
            this.label4.TabIndex = 6;
            this.label4.Text = "Login";
            // 
            // UxLoginButton
            // 
            this.UxLoginButton.Location = new System.Drawing.Point(213, 189);
            this.UxLoginButton.Name = "UxLoginButton";
            this.UxLoginButton.Size = new System.Drawing.Size(75, 23);
            this.UxLoginButton.TabIndex = 7;
            this.UxLoginButton.Text = "Login";
            this.UxLoginButton.UseVisualStyleBackColor = true;
            this.UxLoginButton.Click += new System.EventHandler(this.UxLoginButton_Click);
            // 
            // UxLoginCancel
            // 
            this.UxLoginCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UxLoginCancel.Location = new System.Drawing.Point(93, 189);
            this.UxLoginCancel.Name = "UxLoginCancel";
            this.UxLoginCancel.Size = new System.Drawing.Size(75, 23);
            this.UxLoginCancel.TabIndex = 8;
            this.UxLoginCancel.Text = "Cancel";
            this.UxLoginCancel.UseVisualStyleBackColor = true;
            this.UxLoginCancel.Click += new System.EventHandler(this.UxLoginCancel_Click);
            // 
            // UxLoginStatus
            // 
            this.UxLoginStatus.AutoSize = true;
            this.UxLoginStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UxLoginStatus.Location = new System.Drawing.Point(152, 143);
            this.UxLoginStatus.Name = "UxLoginStatus";
            this.UxLoginStatus.Size = new System.Drawing.Size(0, 16);
            this.UxLoginStatus.TabIndex = 9;
            // 
            // LoginView
            // 
            this.AcceptButton = this.UxLoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.UxLoginCancel;
            this.ClientSize = new System.Drawing.Size(384, 239);
            this.Controls.Add(this.UxLoginStatus);
            this.Controls.Add(this.UxLoginCancel);
            this.Controls.Add(this.UxLoginButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UxPasswordTextBox);
            this.Controls.Add(this.UxUserTextBox);
            this.Name = "LoginView";
            this.Text = "Bid501 Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UxUserTextBox;
        private System.Windows.Forms.TextBox UxPasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button UxLoginButton;
        private System.Windows.Forms.Button UxLoginCancel;
        private System.Windows.Forms.Label UxLoginStatus;
    }
}