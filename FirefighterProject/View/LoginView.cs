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
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            lblTitle.Parent = pbox;
            lblTitle.BackColor = Color.Transparent;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void lblCreate_Click(object sender, EventArgs e)
        {

        }
    }
}
