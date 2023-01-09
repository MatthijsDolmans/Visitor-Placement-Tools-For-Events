using Visitor_Placement_Tools_For_Events.Enums;
using Visitor_Placement_Tools_For_Events;
using System;

int maxcap = 12;

Random r = new Random();
Event event1 = new Event(DateTime.Now, maxcap);
Section section = new Section(SectionLetterEnum.SectionLetter.A, 2);
Section section1 = new Section(SectionLetterEnum.SectionLetter.B, 2);
event1.AddSections(section);
event1.AddSections(section1);
Visitor visitor1 = new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "brimstone");
Visitor visitor2 = new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "viper");
Visitor visitor3 = new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "kayo");
Visitor visitor4 = new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "omen");
Visitor visitor5 = new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "skye"); 
Visitor visitor6 = new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "astra"); 
Visitor visitor7 = new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "neon");
Visitor visitor8 = new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "jett");
Visitor visitor9 = new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "Reyna");
Visitor visitor10 = new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "chamber");
Visitor visitor11 = new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "phoenix");
Visitor visitor12 = new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "yoru");





Group group1 = new Group();
Group group2 = new Group();
Group group3 = new Group();
group1.AddPeopleToGroup(visitor1);
group1.AddPeopleToGroup(visitor2);
group1.AddPeopleToGroup(visitor3);
group1.AddPeopleToGroup(visitor4);

group2.AddPeopleToGroup(visitor5);
group2.AddPeopleToGroup(visitor6);
group2.AddPeopleToGroup(visitor7);

group3.AddPeopleToGroup(visitor8);
group3.AddPeopleToGroup(visitor9);
group3.AddPeopleToGroup(visitor10);
group3.AddPeopleToGroup(visitor11);
group3.AddPeopleToGroup(visitor12);



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
