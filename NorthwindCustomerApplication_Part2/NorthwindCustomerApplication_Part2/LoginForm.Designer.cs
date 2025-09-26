namespace NorthwindCustomerApp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;

        private void InitializeComponent()
        {
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtServer
            this.txtServer.Location = new System.Drawing.Point(12, 12);
            this.txtServer.Size = new System.Drawing.Size(260, 23);
            this.txtServer.PlaceholderText = "Server";

            // txtDatabase
            this.txtDatabase.Location = new System.Drawing.Point(12, 41);
            this.txtDatabase.Size = new System.Drawing.Size(260, 23);
            this.txtDatabase.PlaceholderText = "Database";

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(12, 70);
            this.txtUsername.Size = new System.Drawing.Size(260, 23);
            this.txtUsername.PlaceholderText = "Username";

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(12, 99);
            this.txtPassword.Size = new System.Drawing.Size(260, 23);
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.PasswordChar = '*';

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(12, 128);
            this.btnLogin.Size = new System.Drawing.Size(260, 30);
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // LoginForm
            this.ClientSize = new System.Drawing.Size(284, 171);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
