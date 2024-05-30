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
    }
}
