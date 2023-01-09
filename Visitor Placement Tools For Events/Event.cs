using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tools_For_Events
{
    public class Event
    {
        public DateTime StartDate { get; private set; }
        public int MaxVisitors { get; private set; }
        public List<Section> Sections { get; private set; }
        public List<Group> Groups { get; private set; }

        public Event(DateTime startDate, int maxVisitors)
        {
            StartDate = startDate;
            MaxVisitors = maxVisitors;
            Sections = new List<Section>();
            Groups = new List<Group>();
        }

        public void PlacePeople()
        {
         
        }

        public void AddSections(Section section)
        {
            Sections.Add(section);
        }
    }
}
