using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tools_For_Events
{
    public class Visitor
    {
        public DateTime DateOfBirth { get; private set; }
        public DateTime DateSignedUp { get; private set; }
        public int VisitorId { get; private set; }
        public string Name { get; private set; }
        public bool Ischild { get; private set; }

        private static int LastVisitorId = 0;

        public Visitor(DateTime dateOfBirth, string name, Event _event)
        {
            DateOfBirth = dateOfBirth;
            DateSignedUp = new DateTime(2020, 1, 10);
            //DateSignedUp = RandomSignUpDate();
            Name = name;
            VisitorId = NextId();
            Ischild = IsChild(_event.StartDate);
        }

        public int NextId()
        {
            LastVisitorId++;
            return LastVisitorId;
        }
        
        public bool IsChild(DateTime eventDate)
        {
            if (DateOfBirth > eventDate.Date.AddYears(-12))
            {
                return true;
            }
            else return false;
        }

        #region Formatting

        public override string ToString()
        {
            return $"{Name}";
        }

        private DateTime RandomSignUpDate()
        {
            Random r = new Random();
            DateTime signedUp = new DateTime(r.Next(2014, 2023), r.Next(1, 13), r.Next(1, 29), r.Next(1, 24), r.Next(1, 60), r.Next(1, 60));
            return signedUp;
        }
        #endregion
    }
}
