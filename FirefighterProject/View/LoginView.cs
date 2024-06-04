using FirefighterProject.Controller;
using System;
using System.Windows.Forms;

namespace FirefighterProject.View
{
    public partial class LoginView : Form
    {
        LoginController controller = new LoginController();

        public LoginView()
        {
            InitializeComponent();
            txtBoxPassLog.UseSystemPasswordChar = false;
            txtBoxPassLog.TextChanged += TxtBoxPassLog_TextChanged;
        }

        private void TxtBoxPassLog_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.PasswordChar = '*';
        }

        private void LoginView_Load(object sender, EventArgs e) { }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtBoxUserLog.Text;
            var password = txtBoxPassLog.Text;
            var validUser = controller.IsLogin(username, password);
            if (validUser)
            {
                MainView m = new MainView();
                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        private void lblCreate_Click(object sender, EventArgs e)
        {
            RegisterView m = new RegisterView();
            m.Show();
            this.Hide();
        }

        private void chBoxLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxLogin.Checked == true)
            {
                txtBoxPassLog.UseSystemPasswordChar = true;
            }
            else
            {
                txtBoxPassLog.UseSystemPasswordChar = false;
            }
        }
    }
}
