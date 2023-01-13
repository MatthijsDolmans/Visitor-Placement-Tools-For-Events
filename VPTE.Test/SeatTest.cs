using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor_Placement_Tools_For_Events;
using Visitor_Placement_Tools_For_Events.Enums;

namespace VPTE.Test;

public class SeatTest
{
    [Fact]
    public void When_VisitorHasBeenSeated_SeatHasVisitor()
    {
        // Arrange
        Event event1 = new Event(new DateTime(2014, 1, 10), 5);
        Visitor visitor = new (new DateTime(2014, 1, 10), "DSG", event1);
        Seat seat = new Seat(1, SectionLetterEnum.SectionLetter.A, 1);

        // Act
        seat.PlaceVisitor(visitor);

        // Assert
        Assert.Equal(seat.SeatedVisitor, visitor);
    }
}
