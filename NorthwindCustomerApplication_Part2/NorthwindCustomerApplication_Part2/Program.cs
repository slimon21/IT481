using System;
using System.Windows.Forms;

namespace NorthwindCustomerApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (LoginForm login = new LoginForm())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm(
                        login.Server,
                        login.Database,
                        login.Username,
                        login.Password));
                }
            }
        }
    }
}
