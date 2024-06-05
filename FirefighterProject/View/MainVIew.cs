using System;
using System.Linq;
using System.Windows.Forms;
using FirefighterProject.Controller;
using FirefighterProject.Data;
using FirefighterProject.Model;

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
            LoadIncidentDataGrid();
            EnsureFiretrucksExist();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Add logic if needed
        }

        private void dataGridViewIncidents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Add logic if needed
        }

        private void LoadDataGrid()
        {
            using (var db = new FirefighterDbContext())
            {
                var firefighters = db.Firefighters.ToList();
                dataGridView1.DataSource = firefighters;
            }
        }

        private void LoadIncidentDataGrid()
        {
            using (var db = new FirefighterDbContext())
            {
                var incidents = db.Incidents.ToList();
                dataGridViewIncidents.DataSource = incidents;
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
            var firetruckIDInput = Prompt.ShowDialog("Enter Firetruck ID:", "Add Firefighter");
            int firetruckID;

            // Validate the entered Firetruck ID
            if (!int.TryParse(firetruckIDInput, out firetruckID))
            {
                MessageBox.Show("Invalid Firetruck ID. Please enter a valid number.");
                return;
            }

            // Attempt to add the firefighter with the provided Firetruck ID
            if (_controller.AddFirefighter(username, password, firetruckID))
            {
                MessageBox.Show("Firefighter added successfully");
                LoadDataGrid();
            }
            else
            {
                MessageBox.Show("Firetruck ID does not exist. Please enter a valid Firetruck ID.");
            }
        }

        private void EnsureFiretrucksExist()
        {
            using (var db = new FirefighterDbContext())
            {
                if (!db.Firetrucks.Any())
                {
                    db.Firetrucks.Add(new Firetrucks { IsMondayShift = true, IsTuesdayShift = true, IsWednesdayShift = true, IsThursdayShift = true, IsFridayShift = true, IsSaturdayShift = false, IsSundayShift = false });
                    db.Firetrucks.Add(new Firetrucks { IsMondayShift = false, IsTuesdayShift = false, IsWednesdayShift = false, IsThursdayShift = false, IsFridayShift = false, IsSaturdayShift = true, IsSundayShift = true });
                    db.SaveChanges();
                }
            }
        }

        private void btnDash_Click_1(object sender, EventArgs e)
        {
            _controller.LoadDashboard();
            MessageBox.Show("Dashboard data loaded");
        }

        private void btnAddIncident_Click(object sender, EventArgs e)
        {
            var date = DateTime.Parse(Prompt.ShowDialog("Enter Date (yyyy-mm-dd) :", "Add Incident"));
            var duration = TimeSpan.Parse(Prompt.ShowDialog("Enter Duration (hh:mm:ss) :", "Add Incident"));
            var waterUsed = decimal.Parse(Prompt.ShowDialog("Enter Water Used  (liters) :", "Add Incident"));
            var firetruckID = int.Parse(Prompt.ShowDialog("Enter Firetruck ID:", "Add Incident"));
            var firefighterIDs = Prompt.ShowDialog("Enter Firefighter IDs  (comma separated) :", "Add Incident")
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            _controller.AddIncident(date, duration, waterUsed, firetruckID, firefighterIDs);
            MessageBox.Show("Incident added successfully");
            LoadIncidentDataGrid();
        }

        private void btnViewIncidentDetails_Click(object sender, EventArgs e)
        {
            if (dataGridViewIncidents.SelectedRows.Count > 0)
            {
                var incidentID = (int)dataGridViewIncidents.SelectedRows[0].Cells["IncidentID"].Value;
                var details = _controller.GetIncidentDetails(incidentID);
                MessageBox.Show(details.ToString());
            }
            else
            {
                MessageBox.Show("Please select an incident to view details");
            }
        }

        private void btnAddFiretruck_Click(object sender, EventArgs e)
        {
            var isMondayShift = bool.Parse(Prompt.ShowDialog("Is Monday Shift? (true/false):", "Add Firetruck"));
            var isTuesdayShift = bool.Parse(Prompt.ShowDialog("Is Tuesday Shift? (true/false):", "Add Firetruck"));
            var isWednesdayShift = bool.Parse(Prompt.ShowDialog("Is Wednesday Shift? (true/false):", "Add Firetruck"));
            var isThursdayShift = bool.Parse(Prompt.ShowDialog("Is Thursday Shift? (true/false):", "Add Firetruck"));
            var isFridayShift = bool.Parse(Prompt.ShowDialog("Is Friday Shift? (true/false):", "Add Firetruck"));
            var isSaturdayShift = bool.Parse(Prompt.ShowDialog("Is Saturday Shift? (true/false):", "Add Firetruck"));
            var isSundayShift = bool.Parse(Prompt.ShowDialog("Is Sunday Shift? (true/false):", "Add Firetruck"));

            if (_controller.AddFiretruck(isMondayShift, isTuesdayShift, isWednesdayShift, isThursdayShift, isFridayShift, isSaturdayShift, isSundayShift))
            {
                MessageBox.Show("Firetruck added successfully");
            }
            else
            {
                MessageBox.Show("Error adding firetruck");
            }
        }

        private void btnAssignFirefightersToFiretruck_Click(object sender, EventArgs e)
        {
            var firetruckID = int.Parse(Prompt.ShowDialog("Enter Firetruck ID:", "Assign Firefighters to Firetruck"));
            var firefighterIDs = Prompt.ShowDialog("Enter Firefighter IDs  |comma separated| :", "Assign Firefighters to Firetruck")
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            if (_controller.AssignFirefightersToFiretruck(firetruckID, firefighterIDs))
            {
                MessageBox.Show("Firefighters assigned to firetruck successfully");
                LoadDataGrid();
            }
            else
            {
                MessageBox.Show("Error assigning firefighters to firetruck");
            }

        }
        private void btnShowDialog_Click(object sender, EventArgs e)
        {
            string result = Prompt.ShowDialog("Title", "Default Text");
            MessageBox.Show("Dialog Result: " + result);
        }


        private void btnSortFirefighters_Click(object sender, EventArgs e)
        {
            var sortedFirefighters = _controller.GetFirefightersByIncidentCount();
            dataGridView1.DataSource = sortedFirefighters;
        }
    }
}