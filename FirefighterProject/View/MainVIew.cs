using System;
using System.Windows.Forms;
using FirefighterProject.Controller;
using FirefighterProject.Data;
using Microsoft.Identity.Client;
using System.Linq;

namespace FirefighterProject.View
{
    public partial class MainView : Form
    {
        private readonly MainController _controller;

        public MainView()
        {
            InitializeComponent();
            _controller = new MainController();
            LoadDataGrid();
        }

        // Method to load data into the DataGridView
        private void LoadDataGrid()
        {
            using (var db = new FirefighterDbContext())
            {
                var firefighters = db.Firefighters.ToList();
                dataGridView1.DataSource = firefighters;
            }
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var id = (int)dataGridView1.SelectedRows[0].Cells["FirefighterID"].Value;

                if (_controller.DeleteFirefighter(id))
                {
                    MessageBox.Show("Firefighter deleted successfully");
                    LoadDataGrid();
                }
                else
                {
                    MessageBox.Show("Firefighter not found");
                }
            }
            else
            {
                MessageBox.Show("Please select a firefighter to delete");
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var id = (int)dataGridView1.SelectedRows[0].Cells["FirefighterID"].Value;
                var username = Prompt.ShowDialog("Enter New Username:", "Update Firefighter");
                var password = Prompt.ShowDialog("Enter New Password:", "Update Firefighter");

                if (_controller.UpdateFirefighter(id, username, password))
                {
                    MessageBox.Show("Firefighter updated successfully");
                    LoadDataGrid();
                }
                else
                {
                    MessageBox.Show("Firefighter not found");
                }
            }
            else
            {
                MessageBox.Show("Please select a firefighter to update");
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            var username = Prompt.ShowDialog("Enter Username:", "Add Firefighter");
            var password = Prompt.ShowDialog("Enter Password:", "Add Firefighter");

            if (_controller.AddFirefighter(username, password))
            {
                MessageBox.Show("Firefighter added successfully");
                LoadDataGrid();
            }
            else
            {
                MessageBox.Show("Username already exists");
            }
        }

        private void btnDash_Click_1(object sender, EventArgs e)
        {
            _controller.LoadDashboard();
            MessageBox.Show("Dashboard data loaded");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
