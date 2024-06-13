using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefighterProject.Model
{
    public class IncidentDetailsDTO
    {
        public int IncidentID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal WaterUsed { get; set; }
        public int FiretruckID { get; set; }
        public List<string> Firefighters { get; set; }
    }
}
