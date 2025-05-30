using System;
using System.Windows.Forms;
using УП_PR7.Forms;

namespace УП_PR7
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            string login = txtUsername.Text;
            string password = txtPassword.Text;

            AuthService authService = new AuthService();
            int userId = authService.AuthUser(login, password);

            if (userId == -1)
            {
                MessageBox.Show("Неверный логин или пароль.");
                return;
            }

            DeliveryViewForm deliveryViewForm = new DeliveryViewForm();
            deliveryViewForm.Show();
            this.Hide();
        }
    }
}
