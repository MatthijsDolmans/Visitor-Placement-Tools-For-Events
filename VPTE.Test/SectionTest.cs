using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor_Placement_Tools_For_Events;
using Visitor_Placement_Tools_For_Events.Enums;

namespace VPTE.Test;

public class SectionTest
{
    [Fact]
    public void When_SectionIsCreated_SectionHasRowsAndSeats()
    {
        // Arrange
        Section section = new(SectionLetterEnum.SectionLetter.A, 3);

        // Act


        // Assert
        Assert.All(section.Rows, r => Assert.Equal(3, r.Seats.Count));
    }

    [Fact]
    public void When_GroupIsPlacedInSection_SeatsAreFilled()
    {
        // Arrange
        Event event1 = new Event(new DateTime(2022, 1, 10), 10);
        Section section = new(SectionLetterEnum.SectionLetter.A, 1);

        Visitor visitor = new(new DateTime(2001, 1, 10), "Adult1", event1);


        // Act
        section.SeatVisitorInRow(visitor);

        // Assert
        Assert.All(section.Rows, r => Assert.Collection(r.Seats, 
            s => Assert.Equal(visitor, s.SeatedVisitor),
            s => Assert.Null(s.SeatedVisitor),
            s => Assert.Null(s.SeatedVisitor)));

    }

    [Fact]
    public void When_GroupIsFewerThanFreeSeats_AllowThemInSection()
    {
        // Arrange
        Event event1 = new Event(new DateTime(2022, 1, 10), 10);
        Section section = new(SectionLetterEnum.SectionLetter.A, 3);

        List<Visitor> SignedUp = new()
        {
            new Visitor(new DateTime(2014, 1, 10), "Child1", event1),
            new Visitor(new DateTime(2015, 1, 10), "Child2", event1),
            new Visitor(new DateTime(2001, 1, 10), "Adult1", event1),
            new Visitor(new DateTime(2002, 1, 10), "Adult2", event1),
            new Visitor(new DateTime(2003, 1, 10), "Adult3", event1)
        };

        Group group = new Group(SignedUp.GetRange(0, 5));

        // Act
        bool EnoughSeatsForGroup = section.IsEnoughSeatsForGroupWithChildren(SignedUp.Count, 2);

        // Assert
        Assert.True(EnoughSeatsForGroup);
    }
}
