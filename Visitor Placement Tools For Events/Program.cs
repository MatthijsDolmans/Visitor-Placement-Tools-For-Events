using Visitor_Placement_Tools_For_Events.Enums;
using Visitor_Placement_Tools_For_Events;
using System;

int maxcap = 12;

#region Setup
Random r = new Random();
Event event1 = new Event(DateTime.Now, maxcap);
Section section = new Section(SectionLetterEnum.SectionLetter.A, 2);
Section section1 = new Section(SectionLetterEnum.SectionLetter.B, 2);
event1.AddSections(section);
event1.AddSections(section1);

List<Visitor> SignedUp = new();

SignedUp.Add(new Visitor(new DateTime(2014,1,10), "brimstone", event1)); //kind
SignedUp.Add(new Visitor(new DateTime(r.Next(2014, 2022), r.Next(1, 12), r.Next(1, 29)), "viper", event1));
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "kayo", event1));
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "omen", event1));
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "skye", event1));
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "astra", event1));
//SignedUp.Add(new Visitor(new DateTime(2014, 1, 10), "neon", event1));
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "jett", event1));
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "Reyna", event1));
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "chamber", event1));
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "yoru", event1));
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "phoenix", event1));
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "sage", event1)); 
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "fade", event1));
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "breach", event1));
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "cypher", event1));
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "harbor", event1));

List<Visitor> AllowedVisitors = event1.NotTooLate(SignedUp);

Group group1 = new Group(AllowedVisitors.GetRange(0, 4));
Group group2 = new Group(AllowedVisitors.GetRange(4, 3));
Group group3 = new Group(AllowedVisitors.GetRange(7, 5));

event1.Groups.Add(group1);
event1.Groups.Add(group2);
event1.Groups.Add(group3);

#endregion

event1.PlacePeople();

    foreach (var item1 in event1.Sections)
    {
        foreach (var item2 in item1.Rows)
        {
            foreach (var item3 in item2.Seats)
            {
                Console.WriteLine("Place: " + item3.SeatName);
                if (item3.SeatedVisitor != null)
                {
                    Console.WriteLine(item3.SeatedVisitor.Name + "Date of birth: " + item3.SeatedVisitor.DateOfBirth);
                }
            }
        }
    }
