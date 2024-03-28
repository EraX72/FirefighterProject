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
                    return false; // Връщаме false, ако потребителското име вече е заето
                }

                // Създаваме нов запис за пожарникар в базата данни
                var firefighter = new Firefighters()
                {
                    Username = username,
                    Password = password,
                    // Можеш да направиш този ред, но виж дали е вярно за твоята логика
                    // FiretruckID = firetruckId
                };

                db.Firefighters.Add(firefighter);
                db.SaveChanges();

                return true; // Връщаме true, ако регистрацията е успешна
            }
        }
    }
}
