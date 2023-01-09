using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tools_For_Events
{
    public class Group
    {
        public List<Visitor> Visitors { get;  private set; }
        public int GroupId { get; private set; }

        private static int id;

        public Group()
        {
            Visitors = new List<Visitor>();
            id++;
            GroupId = id;
        }

        public bool HasChildInGroup()
        {
            foreach(var visitor in Visitors)
            {
                if(visitor.Ischild == true)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddPeopleToGroup(Visitor visitor)
        {
            Visitors.Add(visitor);
        }
    }
}
