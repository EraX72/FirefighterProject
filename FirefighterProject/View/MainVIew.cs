using System;
using System.Windows.Forms;
using FirefighterProject.Controller;
using Microsoft.Identity.Client;

namespace FirefighterProject.View
{
    public partial class MainView : Form
    {
        private readonly MainController _controller;

        public MainView()
        {
            InitializeComponent();
            _controller = new MainController();
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            // Load dashboard data
            _controller.LoadDashboard();
            MessageBox.Show("Dashboard data loaded");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var username = Prompt.ShowDialog("Enter Username:", "Add Firefighter");
            var password = Prompt.ShowDialog("Enter Password:", "Add Firefighter");

            if (_controller.AddFirefighter(username, password))
            {
                MessageBox.Show("Firefighter added successfully");
            }
            else
            {
                MessageBox.Show("Username already exists");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var id = int.Parse(Prompt.ShowDialog("Enter Firefighter ID:", "Update Firefighter"));
            var username = Prompt.ShowDialog("Enter New Username:", "Update Firefighter");
            var password = Prompt.ShowDialog("Enter New Password:", "Update Firefighter");

            if (_controller.UpdateFirefighter(id, username, password))
            {
                MessageBox.Show("Firefighter updated successfully");
            }
            else
            {
                MessageBox.Show("Firefighter not found");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = int.Parse(Prompt.ShowDialog("Enter Firefighter ID:", "Delete Firefighter"));

            if (_controller.DeleteFirefighter(id))
            {
                MessageBox.Show("Firefighter deleted successfully");
            }
            else
            {
                MessageBox.Show("Firefighter not found");
            }
        }
    }
}
