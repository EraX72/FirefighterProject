using FirefighterProject.Controller;
using System;
using System.Windows.Forms;

namespace FirefighterProject.View
{
    public partial class RegisterView : Form
    {
        RegisterController controller = new RegisterController();

        public RegisterView()
        {
            InitializeComponent();
            txtBoxPassReg.UseSystemPasswordChar = true;
            txtBoxConfirmReg.UseSystemPasswordChar = true;
            txtBoxPassReg.TextChanged += TxtBoxPassReg_TextChanged;
            txtBoxConfirmReg.TextChanged += TxtBoxConfirmReg_TextChanged;
        }

        private void TxtBoxPassReg_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.PasswordChar = '*';
        }

        private void TxtBoxConfirmReg_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.PasswordChar = '*';
        }

        private void lblCreate_Click(object sender, EventArgs e)
        {
            LoginView m = new LoginView();
            m.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtBoxUserReg.Text;
            string password = txtBoxPassReg.Text;
            string confirmPassword = txtBoxConfirmReg.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return;
            }

            try
            {
                bool registrationSuccessful = controller.Register(username, password);
                if (registrationSuccessful)
                {
                    MessageBox.Show("Registration successful.");
                    LoginView loginView = new LoginView();
                    loginView.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username already exists. Please choose a different one.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during registration: {ex.Message}");
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Inner exception details: {ex.InnerException.Message}");
                }
            }
        }
    }
}
