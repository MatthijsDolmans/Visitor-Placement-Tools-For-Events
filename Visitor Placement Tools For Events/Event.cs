using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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

        #region SetUp
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
          
        public void AddSections(Section section)
        {
            Sections.Add(section);
        }
        #endregion

        public void PlaceAllVisitors()
        {
            List<Group> Adults = new();
            foreach(Group group in Groups)
            {
                if(group.HasChildInGroup() == true)
                {                 
                    PlaceGroupWithChildren(group);
                }
                else
                {
                    Adults.Add(group);
                }
            }

            foreach(Group group in Adults)
            {
                PlaceGroupsWithoutChildren(group);
            }
        }

        private void PlaceGroupWithChildren(Group group)
        {
            foreach(Section section in Sections)
            {
                if (section.IsEnoughSeatsForGroupWithChildren(group.Visitors.Count, group.GetAmountOfChildren()))
                {
                    foreach (Visitor visitor in group.Visitors.OrderByDescending(i => i.DateOfBirth))
                    {
                        section.SeatVisitorInRow(visitor);
                    }
                    break;
                }
            }
        }

        private void PlaceGroupsWithoutChildren(Group group)
        {
            foreach (Visitor visitor in group.Visitors)
            {
                foreach (Section section in Sections)
                {
                    bool placed = section.SeatVisitorInRow(visitor);
                    if (placed)
                    {
                        break;
                    }
                }
            }
        }
    }
}
