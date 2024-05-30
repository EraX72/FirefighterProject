using System;
using System.Linq;
using FirefighterProject.Data;
using FirefighterProject.Model;

namespace FirefighterProject.Controller
{
    internal class MainController
    {
        // Load dashboard data
        public void LoadDashboard()
        {
            // Implement dashboard loading logic
        }

        // Add a new firefighter
        public bool AddFirefighter(string username, string password)
        {
            using (var db = new FirefighterDbContext())
            {
                if (db.Firefighters.Any(u => u.Username == username))
                {
                    return false;
                }

                var firefighter = new Firefighters
                {
                    Username = username,
                    Password = password,
                    FiretruckID = 1,
                };

                var existingFirefighters = db.Firefighters.OrderByDescending(f => f.FirefighterID).FirstOrDefault();
                firefighter.FirefighterID = existingFirefighters?.FirefighterID + 1 ?? 1;

                db.Firefighters.Add(firefighter);
                db.SaveChanges();

                return true;
            }
        }

        // Update an existing firefighter
        public bool UpdateFirefighter(int id, string username, string password)
        {
            using (var db = new FirefighterDbContext())
            {
                var firefighter = db.Firefighters.FirstOrDefault(f => f.FirefighterID == id);
                if (firefighter == null)
                {
                    return false;
                }

                firefighter.Username = username;
                firefighter.Password = password;
                db.SaveChanges();

                return true;
            }
        }

        // Delete a firefighter
        public bool DeleteFirefighter(int id)
        {
            using (var db = new FirefighterDbContext())
            {
                var firefighter = db.Firefighters.FirstOrDefault(f => f.FirefighterID == id);
                if (firefighter == null)
                {
                    return false;
                }

                db.Firefighters.Remove(firefighter);
                db.SaveChanges();

                return true;
            }
        }
    }
}
