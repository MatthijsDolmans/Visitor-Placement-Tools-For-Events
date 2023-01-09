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
            foreach(Group group in Groups)
            {
                if(group.HasChildInGroup() == true)
                {
                    PlaceGroupsWithChildren(group.Visitors);
                }
                else
                {

                }
            }
        }

        public void PlaceGroupsWithChildren(List<Visitor> visitors)
        {
            foreach( Visitor visitor in visitors)
            {

                foreach (var item in Sections)
                {
                    foreach (var item1 in item.Rows)
                    {
                        foreach (var item2 in item1.Seats)
                        { 
                            if (item2.SeatedVisitor == null)
                            {
                                item2.PlaceVisitor(visitor);
                                break;
                            }

                        }
                        break;
                    }
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
