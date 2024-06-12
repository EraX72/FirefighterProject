using System;
using System.Collections.Generic;
using System.Linq;
using FirefighterProject.Data;
using FirefighterProject.Model;

namespace FirefighterProject.Controller
{
    internal class MainController
    {
        public void LoadDashboard()
        {
            // Implement dashboard loading logic
        }

        public bool AddFirefighter(string username, string password, int firetruckID)
        {
            using (var db = new FirefighterDbContext())
            {
                if (db.Firefighters.Any(u => u.Username == username))
                {
                    return false;
                }

                // Check if the provided FiretruckID exists
                var validFiretruck = db.Firetrucks.FirstOrDefault(ft => ft.FiretruckID == firetruckID);

                if (validFiretruck == null)
                {
                    // If the provided FiretruckID does not exist, return false
                    return false;
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

        public void AddIncident(DateTime date, TimeSpan duration, decimal waterUsed, int firetruckID, int[] firefighterIDs)
        {
            using (var db = new FirefighterDbContext())
            {
                var incident = new Incidents
                {
                    Date = date,
                    Duration = duration,
                    WaterUsed = waterUsed,
                    FiretruckID = firetruckID
                };

                var existingIncidents = db.Incidents.OrderByDescending(i => i.IncidentID).FirstOrDefault();
                incident.IncidentID = existingIncidents?.IncidentID + 1 ?? 1;

                db.Incidents.Add(incident);
                db.SaveChanges();

                foreach (var firefighterID in firefighterIDs)
                {
                    var participant = new IncidentParticipants
                    {
                        IncidentID = incident.IncidentID,
                        FirefighterID = firefighterID
                    };
                    db.IncidentParticipants.Add(participant);
                }

                db.SaveChanges();
            }
        }

        public object GetIncidentDetails(int incidentID)
        {
            using (var db = new FirefighterDbContext())
            {
                var incident = db.Incidents
                    .Where(i => i.IncidentID == incidentID)
                    .Select(i => new
                    {
                        i.IncidentID,
                        i.Date,
                        i.Duration,
                        i.WaterUsed,
                        i.FiretruckID,
                        Firefighters = i.IncidentParticipants.Select(p => p.Firefighter).ToList()
                    }).FirstOrDefault();

                return incident;
            }
        }

        public bool AddFiretruck(bool isMondayShift, bool isTuesdayShift, bool isWednesdayShift, bool isThursdayShift, bool isFridayShift, bool isSaturdayShift, bool isSundayShift)
        {
            using (var db = new FirefighterDbContext())
            {
                var firetruck = new Firetrucks
                {
                    IsMondayShift = isMondayShift,
                    IsTuesdayShift = isTuesdayShift,
                    IsWednesdayShift = isWednesdayShift,
                    IsThursdayShift = isThursdayShift,
                    IsFridayShift = isFridayShift,
                    IsSaturdayShift = isSaturdayShift,
                    IsSundayShift = isSundayShift
                };

                var existingFiretrucks = db.Firetrucks.OrderByDescending(f => f.FiretruckID).FirstOrDefault();
                firetruck.FiretruckID = existingFiretrucks?.FiretruckID + 1 ?? 1;

                db.Firetrucks.Add(firetruck);
                db.SaveChanges();

                return true;
            }
        }

        public bool AssignFirefightersToFiretruck(int firetruckID, int[] firefighterIDs)
        {
            using (var db = new FirefighterDbContext())
            {
                var firetruck = db.Firetrucks.FirstOrDefault(f => f.FiretruckID == firetruckID);
                if (firetruck == null)
                {
                    return false;
                }

                var firefighters = db.Firefighters.Where(f => firefighterIDs.Contains(f.FirefighterID)).ToList();

                foreach (var firefighter in firefighters)
                {
                    firefighter.FiretruckID = firetruckID;
                }

                db.SaveChanges();

                return true;
            }
        }

        public List<Firefighters> GetFirefightersByIncidentCount()
        {
            using (var db = new FirefighterDbContext())
            {
                var firefighters = db.Firefighters
                    .Select(f => new
                    {
                        Firefighter = f,
                        IncidentCount = db.Incidents.Count(i => i.Firetruck.Firefighters.Any(ff => ff.FirefighterID == f.FirefighterID))
                    })
                    .OrderByDescending(f => f.IncidentCount)
                    .Select(f => f.Firefighter)
                    .ToList();

                return firefighters;
            }
        }

        public Firefighters GetTopFirefighter()
        {
            using (var db = new FirefighterDbContext())
            {
                var topFirefighter = db.Firefighters
                    .Select(f => new
                    {
                        Firefighter = f,
                        IncidentCount = db.IncidentParticipants.Count(p => p.FirefighterID == f.FirefighterID)
                    })
                    .OrderByDescending(f => f.IncidentCount)
                    .Select(f => f.Firefighter)
                    .FirstOrDefault();

                return topFirefighter;
            }
        }
    }
}
