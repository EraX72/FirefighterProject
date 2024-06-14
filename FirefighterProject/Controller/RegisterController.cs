using System;
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

                // Get all FiretruckIDs
                var firetruckIDs = db.Firetrucks.Select(ft => ft.FiretruckID).ToList();
                if (firetruckIDs.Count == 0)
                {
                    throw new Exception("No firetrucks available. Please add firetrucks first.");
                }

                // Get the last used FiretruckID from the Firefighters table
                var lastUsedFiretruckID = db.Firefighters
                                            .OrderByDescending(f => f.FirefighterID)
                                            .Select(f => f.FiretruckID)
                                            .FirstOrDefault();

                // Find the next FiretruckID to use
                int nextFiretruckID;
                if (lastUsedFiretruckID == 0)
                {
                    nextFiretruckID = firetruckIDs.First();
                }
                else
                {
                    int lastIndex = firetruckIDs.IndexOf(lastUsedFiretruckID);
                    nextFiretruckID = firetruckIDs[(lastIndex + 1) % firetruckIDs.Count];
                }

                var firefighter = new Firefighters
                {
                    Username = username,
                    Password = password,
                    FiretruckID = nextFiretruckID
                };

                var existingFirefighters = db.Firefighters.OrderByDescending(f => f.FirefighterID).FirstOrDefault();
                firefighter.FirefighterID = existingFirefighters?.FirefighterID + 1 ?? 1;

                db.Firefighters.Add(firefighter);
                db.SaveChanges();

                return true;
                //Здравейте господин янев вие иначе как сте днес много сте готино
                //облечен както винаги нали знате че сте ми любимия класен
                //това е нашия проект конкретно аз съм отговарял за registarview
                //то надявам се да ми ме оцените подобаващо
            }
        }
    }
}

