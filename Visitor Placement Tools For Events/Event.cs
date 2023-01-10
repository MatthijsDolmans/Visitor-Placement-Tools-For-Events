using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public List<Visitor> NotTooLate(List<Visitor> visitors)
        {
            int CurrentVisitors = 0;
            List<Visitor> VisitorsOnTime = new List<Visitor>();
            foreach( Visitor visitor in visitors.OrderByDescending(i => i.DateSignedUp))
            {
                if (visitor.DateSignedUp < StartDate && CurrentVisitors < MaxVisitors)
                {
                    VisitorsOnTime.Add(visitor);
                    CurrentVisitors++;
                }
            }
            return VisitorsOnTime;
        }
          

        public void PlacePeople()
        {
            foreach(Group group in Groups)
            {
                if(group.HasChildInGroup() == true)
                {                 
                        PlaceGroup(group.Visitors, group.Visitors.Count);
                }
                else
                {

                }
            }
        }

        public void PlaceGroup(List<Visitor> visitors, int groupSize)
        {
            foreach(Section section in Sections)
            {
                if (section.IsSpace(visitors.Count))
                {
                   section.SeatVisitorInRowSeat(visitors);
                    break;
                }
            }
        }

        public void AddSections(Section section)
        {
            Sections.Add(section);
        }
    }
}
