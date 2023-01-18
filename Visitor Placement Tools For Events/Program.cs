using Visitor_Placement_Tools_For_Events.Enums;
using Visitor_Placement_Tools_For_Events;
using System;

int maxCap = 15;

#region Setup
Random r = new Random();

Event event1 = new Event(new DateTime(2022, 1, 10), maxCap);

Section section = new Section(SectionLetterEnum.SectionLetter.A, 3);
Section section1 = new Section(SectionLetterEnum.SectionLetter.B, 3);
event1.AddSections(section);
event1.AddSections(section1);

List<Visitor> SignedUp = new();

// Group 1
SignedUp.Add(new Visitor(new DateTime(2014, 1, 10), "G1K1      ", event1));
SignedUp.Add(new Visitor(new DateTime(2015, 1, 10), "G1K2      ", event1));
SignedUp.Add(new Visitor(new DateTime(2001, 1, 10), "G1A1      ", event1));
SignedUp.Add(new Visitor(new DateTime(2002, 1, 10), "G4A1(G1A2)", event1));
SignedUp.Add(new Visitor(new DateTime(2003, 1, 10), "G4A2(G1A3)", event1));
//Group 2
SignedUp.Add(new Visitor(new DateTime(2014, 1, 10), "G2K1      ", event1));
SignedUp.Add(new Visitor(new DateTime(2016, 1, 10), "G2K2      ", event1));
SignedUp.Add(new Visitor(new DateTime(1950, 1, 10), "G2A1      ", event1));
SignedUp.Add(new Visitor(new DateTime(1951, 1, 10), "G4A3(G2A2)", event1));
SignedUp.Add(new Visitor(new DateTime(1952, 1, 10), "G4A4(G2A3)", event1));
//Group 3
SignedUp.Add(new Visitor(new DateTime(2014, 1, 10), "G3K1      ", event1));
SignedUp.Add(new Visitor(new DateTime(1971, 1, 10), "G3A1      ", event1));
SignedUp.Add(new Visitor(new DateTime(1972, 1, 10), "G4A5(G3A2)", event1));
SignedUp.Add(new Visitor(new DateTime(1973, 1, 10), "G4A6(G3A3)", event1));
SignedUp.Add(new Visitor(new DateTime(1974, 1, 10), "G4A7(G3A4)", event1));


/*
SignedUp.Add(new Visitor(new DateTime(2014,1,10), "brimstone", event1)); //kind
SignedUp.Add(new Visitor(new DateTime(r.Next(1900, 2022), r.Next(1, 12), r.Next(1, 29)), "viper", event1));
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
*/

List<Visitor> AllowedVisitors = event1.NotTooLate(SignedUp);

Group group1 = new Group(AllowedVisitors.GetRange(0, 5));
Group group2 = new Group(AllowedVisitors.GetRange(5, 5));
Group group3 = new Group(AllowedVisitors.GetRange(10, 5));

event1.Groups.Add(group1);
event1.Groups.Add(group2);
event1.Groups.Add(group3);

#endregion

event1.PlaceAllVisitors();
//event1.ToString();

foreach (Section sections in event1.Sections)
{
    foreach (Row row in sections.Rows)
    {
        foreach (Seat seat in row.Seats)
        {

            if (seat.SeatedVisitor != null)
            {
                Console.WriteLine("Place: " + seat.SeatName +  " ------ " + seat.SeatedVisitor.Name +  " -- " + seat.SeatedVisitor.VisitorId +  " -- " + " ------ Date of birth: " + seat.SeatedVisitor.DateOfBirth);
            }
            else { Console.WriteLine("Place: " + seat.SeatName); }
        }
    }
}
