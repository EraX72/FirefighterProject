using FirefighterProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefighterProject.Controller
{
    internal class RegisterController
    {
        public bool Register(string username, string password)
        {
            using (FirefighterDBEntities db = new FirefighterDBEntities())
            {
                // Проверка дали потребителското име вече съществува
                if (db.Firefighters.Any(u => u.Username == username))
                {
                    return false; 
                }

                // Създаваме нов запис за пожарникар в базата данни
                var firefighter = new Firefighters()
                {
                    Username = username,
                    Password = password,
                    FirefighterID = 1, 
                    FiretruckID = 1,
                };

                db.Firefighters.Add(firefighter);
                db.SaveChanges();

                return true; // Връщаме true, ако регистрацията е успешна
            }
        }
    }
}
