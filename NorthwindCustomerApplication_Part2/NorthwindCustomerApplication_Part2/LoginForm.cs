using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NorthwindCustomerApp
{
    public partial class LoginForm : Form
    {
        private ErrorProvider errorProvider1;

        public string Server => txtServer.Text?.Trim();
        public string Database => txtDatabase.Text?.Trim();
        public string Username => txtUsername.Text?.Trim();
        public string Password => txtPassword.Text;

        public LoginForm()
        {
            InitializeComponent();

            errorProvider1 = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };

            txtServer.Validating += (s, e) => ValidateServer();
            txtDatabase.Validating += (s, e) => ValidateDatabase();
            txtUsername.Validating += (s, e) => ValidateUsername();
            txtPassword.Validating += (s, e) => ValidatePassword();
        }

        private bool ValidateInputs()
        {
            errorProvider1.Clear();
            bool ok = true;

            ok &= ValidateServer();
            ok &= ValidateDatabase();
            ok &= ValidateUsername();
            ok &= ValidatePassword();

            return ok;
        }

        private bool ValidateServer()
        {
            if (string.IsNullOrWhiteSpace(Server))
            {
                errorProvider1.SetError(txtServer, "Server is required.");
                return false;
            }

            bool formatOk = Regex.IsMatch(Server,
                @"^[A-Za-z0-9\.\-]+(\\[A-Za-z0-9_\-]+)?(,[0-9]{1,5})?$");
            if (!formatOk)
            {
                errorProvider1.SetError(txtServer, "Invalid server format (e.g., server,1433 or server\\instance).");
                return false;
            }

            return true;
        }

        private bool ValidateDatabase()
        {
            if (string.IsNullOrWhiteSpace(Database))
            {
                errorProvider1.SetError(txtDatabase, "Database is required.");
                return false;
            }

            bool formatOk = Regex.IsMatch(Database, @"^[A-Za-z0-9_]{1,128}$");
            if (!formatOk)
            {
                errorProvider1.SetError(txtDatabase, "Database may contain letters, digits, underscore (1–128).");
                return false;
            }

            return true;
        }

        private bool ValidateUsername()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                errorProvider1.SetError(txtUsername, "Username is required.");
                return false;
            }

            if (Username.Length < 3 || Username.Length > 50)
            {
                errorProvider1.SetError(txtUsername, "Username must be 3–50 characters.");
                return false;
            }

            return true;
        }

        private bool ValidatePassword()
        {
            if (string.IsNullOrWhiteSpace(Password))
            {
                errorProvider1.SetError(txtPassword, "Password is required.");
                return false;
            }

            if (Password.Length > 256)
            {
                errorProvider1.SetError(txtPassword, "Password appears unusually long.");
                return false;
            }

            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                {
                    MessageBox.Show(
                        "Please correct the highlighted fields.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {

                Trace.WriteLine(ex);
                MessageBox.Show(
                    "An unexpected error occurred. Please try again or contact support.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
