using System.Linq;
using FirefighterProject.Data;
using FirefighterProject.Model;

namespace FirefighterProject.Controller
{
    internal class RegisterController
    {
        public bool Register(string username, string password)
        {
            using (var db = new FirefighterDbContext())
            {
                if (db.Firefighters.Any(u => u.Username == username))
                {
                    return false;
                }

                // Find an existing FiretruckID or create a new one if needed
                var existingFiretruck = db.Firetrucks.FirstOrDefault();
                int firetruckID;

                if (existingFiretruck == null)
                {
                    // Create a new Firetruck if none exists
                    var newFiretruck = new Firetrucks
                    {
                        IsMondayShift = false,
                        IsTuesdayShift = false,
                        IsWednesdayShift = false,
                        IsThursdayShift = false,
                        IsFridayShift = false,
                        IsSaturdayShift = false,
                        IsSundayShift = false
                    };

                    db.Firetrucks.Add(newFiretruck);
                    db.SaveChanges();
                    firetruckID = newFiretruck.FiretruckID;
                }
                else
                {
                    // Use the existing FiretruckID
                    firetruckID = existingFiretruck.FiretruckID;
                }

                var firefighter = new Firefighters
                {
                    Username = username,
                    Password = password,
                    FiretruckID = firetruckID,
                };

                var existingFirefighters = db.Firefighters.OrderByDescending(f => f.FirefighterID).FirstOrDefault();
                firefighter.FirefighterID = existingFirefighters?.FirefighterID + 1 ?? 1;

                db.Firefighters.Add(firefighter);
                db.SaveChanges();

                return true;
            }
        }
    }
}
