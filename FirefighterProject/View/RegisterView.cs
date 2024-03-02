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
    }
}
