using FirefighterProject.Data;
using FirefighterProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FirefighterProject.Controller
{
    public class MainController
    {
        private readonly FirefighterDbContext _context;

        public MainController()
        {
            _context = new FirefighterDbContext();
        }

        public bool AddFirefighter(string username, string password)
        {
            if (_context.Firefighters.Any(f => f.Username == username))
                return false;

            var firefighter = new Firefighters { Username = username, Password = password };
            _context.Firefighters.Add(firefighter);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateFirefighter(int id, string username, string password)
        {
            var firefighter = _context.Firefighters.Find(id);
            if (firefighter == null)
                return false;

            firefighter.Username = username;
            firefighter.Password = password;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteFirefighter(int id)
        {
            var firefighter = _context.Firefighters.Find(id);
            if (firefighter == null)
                return false;

            _context.Firefighters.Remove(firefighter);
            _context.SaveChanges();
            return true;
        }

        public void LoadDashboard()
        {
            // Add dashboard logic here
        }

        public void AddIncident(DateTime date, TimeSpan duration, decimal waterUsed, int firetruckID, int[] firefighterIDs)
        {
            var incident = new Incidents
            {
                Date = date,
                Duration = duration,
                WaterUsed = waterUsed,
                FiretruckID = firetruckID
            };

            _context.Incidents.Add(incident);
            _context.SaveChanges();

            var incidentParticipants = firefighterIDs.Select(id => new IncidentParticipants
            {
                IncidentID = incident.IncidentID,
                FirefighterID = id
            }).ToList();

            _context.IncidentParticipants.AddRange(incidentParticipants);
            _context.SaveChanges();
        }

        public IncidentDetailsDTO GetIncidentDetails(int incidentID)
        {
            var incident = _context.Incidents
                .SingleOrDefault(i => i.IncidentID == incidentID);

            if (incident == null)
                return null;

            var firefighterIDs = _context.IncidentParticipants
                .Where(ip => ip.IncidentID == incidentID)
                .Select(ip => ip.FirefighterID)
                .ToList();

            var firefighters = _context.Firefighters
                .Where(f => firefighterIDs.Contains(f.FirefighterID))
                .Select(f => f.Username)
                .ToList();

            return new IncidentDetailsDTO
            {
                IncidentID = incident.IncidentID,
                Date = incident.Date,
                Duration = incident.Duration,
                WaterUsed = incident.WaterUsed,
                FiretruckID = incident.FiretruckID,
                Firefighters = firefighters
            };
        }

        public List<TopFirefighterDTO> GetTopFirefighters(int count)
        {
            var topFirefighters = _context.IncidentParticipants
                .GroupBy(ip => ip.FirefighterID)
                .Select(g => new TopFirefighterDTO
                {
                    FirefighterID = g.Key,
                    IncidentCount = g.Count(),
                    Firefighter = _context.Firefighters.FirstOrDefault(f => f.FirefighterID == g.Key).Username
                })
                .OrderByDescending(f => f.IncidentCount)
                .Take(count)
                .ToList();

            return topFirefighters;
        }

        public List<TopFiretruckDTO> GetTopFiretrucks(int count)
        {
            var topFiretrucks = _context.Incidents
                .GroupBy(i => i.FiretruckID)
                .Select(g => new TopFiretruckDTO
                {
                    FiretruckID = g.Key,
                    IncidentCount = g.Count()
                })
                .OrderByDescending(f => f.IncidentCount)
                .Take(count)
                .ToList();

            return topFiretrucks;
        }

        public bool AddFiretruck(bool isMondayShift, bool isTuesdayShift, bool isWednesdayShift, bool isThursdayShift, bool isFridayShift, bool isSaturdayShift, bool isSundayShift)
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

            _context.Firetrucks.Add(firetruck);
            _context.SaveChanges();
            return true;
        }

        public bool AssignFirefightersToFiretruck(int firetruckID, int[] firefighterIDs)
        {
            var firetruck = _context.Firetrucks.Find(firetruckID);
            if (firetruck == null)
                return false;

            var firefighters = _context.Firefighters.Where(f => firefighterIDs.Contains(f.FirefighterID)).ToList();
            foreach (var firefighter in firefighters)
            {
                firefighter.FiretruckID = firetruckID;
            }

            _context.SaveChanges();
            return true;
        }
    }
}
