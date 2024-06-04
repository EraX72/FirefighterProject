using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefighterProject.Model
{
    public class IncidentParticipants
    {
        public int IncidentID { get; set; }
        public int FirefighterID { get; set; }

        public Incidents Incident { get; set; }
        public Firefighters Firefighter { get; set; }
    }
}