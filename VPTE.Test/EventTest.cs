using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor_Placement_Tools_For_Events;

namespace VPTE.Test;

public class EventTest
{
    [Fact]
    public void When_VisitorWouldExceedMaxCapacity_DontAllowVisitorInEvent()
    {
        // Arrange
        int maxCapacity = 4;
        Event event1 = new Event(new DateTime(2022, 1, 10), maxCapacity);
        List<Visitor> SignedUp = new();

        Visitor visitorOnTime1 = new Visitor(new DateTime(2014, 1, 10), "G1K1      ", event1); SignedUp.Add(visitorOnTime1);
        Visitor visitorOnTime2 = new Visitor(new DateTime(2015, 1, 10), "G1K2      ", event1); SignedUp.Add(visitorOnTime2);
        Visitor visitorOnTime3 = new Visitor(new DateTime(2001, 1, 10), "G1A1      ", event1); SignedUp.Add(visitorOnTime3);
        Visitor visitorOnTime4 = new Visitor(new DateTime(2002, 1, 10), "G4A1(G1A2)", event1); SignedUp.Add(visitorOnTime4);
        Visitor visitorThatDoesntFit = new Visitor(new DateTime(2003, 1, 10), "G4A2(G1A3)", event1); SignedUp.Add(visitorThatDoesntFit);


        // Act
        List<Visitor> AllowedVisitors = event1.NotTooLate(SignedUp);

        // Assert
        Assert.Collection(AllowedVisitors,
            i => Assert.Equal(i, visitorOnTime1),
            i => Assert.Equal(i, visitorOnTime2),
            i => Assert.Equal(i, visitorOnTime3),
            i => Assert.Equal(i, visitorOnTime4));
    }
}
