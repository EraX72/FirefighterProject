using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefighterProject.Model
{
    public class Firetrucks
    {
        public int FiretruckID { get; set; }
        public bool IsMondayShift { get; set; }
        public bool IsTuesdayShift { get; set; }
        public bool IsWednesdayShift { get; set; }
        public bool IsThursdayShift { get; set; }
        public bool IsFridayShift { get; set; }
        public bool IsSaturdayShift { get; set; }
        public bool IsSundayShift { get; set; }

        public ICollection<Firefighters> Firefighters { get; set; }  // Navigation property
        public ICollection<Incidents> Incidents { get; set; }  // Navigation property
    }
}
