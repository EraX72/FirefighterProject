using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefighterProject.Model
{
    public class Firefighters
    {
        public int FirefighterID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int FiretruckID { get; set; }

        public Firetrucks Firetruck { get; set; }
        public ICollection<IncidentParticipants> IncidentParticipants { get; set; }
    }
}
