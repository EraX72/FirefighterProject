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
            var username = Prompt.ShowDialog("Enter Username:", "Add Firefighter (e.g., johndoe)");
            var password = Prompt.ShowDialog("Enter Password:", "Add Firefighter (e.g., password123)");

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
            _controller.LoadDashboard(dataGridViewIncidents);
        }

        private void btnViewIncidents_Click(object sender, EventArgs e)
        {
            LoadIncidentDataGrid();
        }

        private void btnViewIncidentDetails_Click(object sender, EventArgs e)
        {
            if (dataGridViewIncidents.SelectedRows.Count > 0)
            {
                var incidentID = (int)dataGridViewIncidents.SelectedRows[0].Cells["IncidentID"].Value;
                var details = _controller.GetIncidentDetails(incidentID);

                var detailString = details == null
                    ? "Incident not found"
                    : $"IncidentID = {details.IncidentID}, Date = {details.Date}, Duration = {details.Duration}, WaterUsed = {details.WaterUsed}, FiretruckID = {details.FiretruckID}, Firefighters = {string.Join(", ", details.Firefighters)}";

                MessageBox.Show(detailString);
            }
            else
            {
                MessageBox.Show("Please select an incident to view details");
            }
        }

        private void btnViewTopFirefighters_Click(object sender, EventArgs e)
        {
            var topFirefighters = _controller.GetTopFirefighters(5);
            var topFirefightersString = string.Join(Environment.NewLine, topFirefighters.Select(f => $"Firefighter: {f.Firefighter}, IncidentCount: {f.IncidentCount}"));
            MessageBox.Show(topFirefightersString);
        }

        private void btnViewTopFiretrucks_Click(object sender, EventArgs e)
        {
            var topFiretrucks = _controller.GetTopFiretrucks(5);
            var topFiretrucksString = string.Join(Environment.NewLine, topFiretrucks.Select(t => $"FiretruckID: {t.FiretruckID}, IncidentCount: {t.IncidentCount}"));
            MessageBox.Show(topFiretrucksString);
        }

        private void btnAddIncident_Click(object sender, EventArgs e)
        {
            try
            {
                var dateStr = Prompt.ShowDialog("Enter Incident Date (e.g., 2024-06-15):", "Add Incident");
                var durationStr = Prompt.ShowDialog("Enter Incident Duration (e.g., 02:30:00):", "Add Incident");
                var waterUsedStr = Prompt.ShowDialog("Enter Water Used (e.g., 150.5):", "Add Incident");
                var firetruckIDStr = Prompt.ShowDialog("Enter Firetruck ID (e.g., 1):", "Add Incident");
                var firefighterIDsStr = Prompt.ShowDialog("Enter Firefighter IDs (comma separated, e.g., 1,2,3):", "Add Incident");

                if (DateTime.TryParse(dateStr, out var date) &&
                    TimeSpan.TryParse(durationStr, out var duration) &&
                    decimal.TryParse(waterUsedStr, out var waterUsed) &&
                    int.TryParse(firetruckIDStr, out var firetruckID) &&
                    firefighterIDsStr.Split(',').All(id => int.TryParse(id, out _)))
                {
                    var firefighterIDs = firefighterIDsStr.Split(',').Select(int.Parse).ToArray();

                    if (_controller.AddIncident(date, duration, waterUsed, firetruckID, firefighterIDs))
                    {
                        MessageBox.Show("Incident added successfully");
                        _controller.LoadDashboard(dataGridViewIncidents); // Refresh the dashboard
                    }
                    else
                    {
                        MessageBox.Show("Failed to add incident. Ensure Firetruck and Firefighters exist.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input. Please check all fields and try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void btnAddFiretruck_Click(object sender, EventArgs e)
        {
            try
            {
                var firetruckID = int.Parse(Prompt.ShowDialog("Enter Firetruck ID (e.g., 123):", "Add Firetruck"));
                var isMondayShift = bool.Parse(Prompt.ShowDialog("Is Monday Shift? (true/false):", "Add Firetruck"));
                var isTuesdayShift = bool.Parse(Prompt.ShowDialog("Is Tuesday Shift? (true/false):", "Add Firetruck"));
                var isWednesdayShift = bool.Parse(Prompt.ShowDialog("Is Wednesday Shift? (true/false):", "Add Firetruck"));
                var isThursdayShift = bool.Parse(Prompt.ShowDialog("Is Thursday Shift? (true/false):", "Add Firetruck"));
                var isFridayShift = bool.Parse(Prompt.ShowDialog("Is Friday Shift? (true/false):", "Add Firetruck"));
                var isSaturdayShift = bool.Parse(Prompt.ShowDialog("Is Saturday Shift? (true/false):", "Add Firetruck"));
                var isSundayShift = bool.Parse(Prompt.ShowDialog("Is Sunday Shift? (true/false):", "Add Firetruck"));

                if (_controller.AddFiretruck(firetruckID, isMondayShift, isTuesdayShift, isWednesdayShift, isThursdayShift, isFridayShift, isSaturdayShift, isSundayShift))
                {
                    MessageBox.Show("Firetruck added successfully");
                    LoadIncidentDataGrid();
                }
                else
                {
                    MessageBox.Show("Firetruck ID already exists");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnAssignFirefightersToFiretruck_Click(object sender, EventArgs e)
        {
            try
            {
                var firetruckID = int.Parse(Prompt.ShowDialog("Enter Firetruck ID (e.g., 123):", "Assign Firefighters"));
                var firefighterIDs = Prompt.ShowDialog("Enter Firefighter IDs (comma separated, e.g., 1,2,3):", "Assign Firefighters")
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();

                if (_controller.AssignFirefightersToFiretruck(firetruckID, firefighterIDs))
                {
                    MessageBox.Show("Firefighters assigned successfully");
                    LoadDataGrid();
                }
                else
                {
                    MessageBox.Show("Failed to assign firefighters");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
