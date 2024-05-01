namespace Bid501_Client
{
    partial class LoginGUI
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
            this.uxUsername = new System.Windows.Forms.TextBox();
            this.uxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uxLogin = new System.Windows.Forms.Button();
            this.loginFail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxUsername
            // 
            this.uxUsername.Location = new System.Drawing.Point(201, 174);
            this.uxUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxUsername.Name = "uxUsername";
            this.uxUsername.Size = new System.Drawing.Size(148, 26);
            this.uxUsername.TabIndex = 0;
            // 
            // uxPassword
            // 
            this.uxPassword.Location = new System.Drawing.Point(201, 246);
            this.uxPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxPassword.Name = "uxPassword";
            this.uxPassword.Size = new System.Drawing.Size(148, 26);
            this.uxPassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 251);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // uxLogin
            // 
            this.uxLogin.Location = new System.Drawing.Point(201, 306);
            this.uxLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxLogin.Name = "uxLogin";
            this.uxLogin.Size = new System.Drawing.Size(112, 35);
            this.uxLogin.TabIndex = 5;
            this.uxLogin.Text = "Login";
            this.uxLogin.UseVisualStyleBackColor = true;
            this.uxLogin.Click += new System.EventHandler(this.uxLogin_Click);
            // 
            // loginFail
            // 
            this.loginFail.AutoSize = true;
            this.loginFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginFail.Location = new System.Drawing.Point(197, 221);
            this.loginFail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loginFail.Name = "loginFail";
            this.loginFail.Size = new System.Drawing.Size(163, 20);
            this.loginFail.TabIndex = 6;
            this.loginFail.Text = "Incorrect Password";
            this.loginFail.Visible = false;
            // 
            // LoginGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 360);
            this.Controls.Add(this.loginFail);
            this.Controls.Add(this.uxLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxPassword);
            this.Controls.Add(this.uxUsername);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoginGUI";
            this.Text = "Login501";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxUsername;
        private System.Windows.Forms.TextBox uxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button uxLogin;
        private System.Windows.Forms.Label loginFail;
    }
}

