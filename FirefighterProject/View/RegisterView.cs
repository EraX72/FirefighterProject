using FirefighterProject.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirefighterProject.View
{
    public partial class RegisterView : Form
    {
        RegisterController controller = new RegisterController();

        public RegisterView()
        {
            InitializeComponent();
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
            string confirmPassword = txtBoxConfirmReg.Text; // Поле за потвърждение на паролата

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

                // Покажи подробности за вътрешната грешка, ако има такава
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Inner exception details: {ex.InnerException.Message}");
                }
            }
        }
    }
}
