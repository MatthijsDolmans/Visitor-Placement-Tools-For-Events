using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor_Placement_Tools_For_Events;
using Visitor_Placement_Tools_For_Events.Enums;

namespace VPTE.Test;

public class RowTest
{
    [Fact]
    public void When_RowsAreMade_RowHasSeats()
    {
        // Arrange
        Row row = new(1, SectionLetterEnum.SectionLetter.A);

        // Act
        int TotalRowSeats = row.Seats.Count;

        // Assert
        Assert.Equal(3, TotalRowSeats);
    }

    [Fact]
    public void When_VisitorIsPlacedInRow_VisitorIsOnlySeatedOnFirstFreeSeat()
    {
        // Arrange
        Event event1 = new Event(new DateTime(2014, 1, 10), 5);
        Visitor visitorSeat1 = new(new DateTime(2014, 1, 10), "DSG", event1);
        Visitor visitorSeat2 = new(new DateTime(2014, 1, 10), "DSG", event1);
        Row row = new(1, SectionLetterEnum.SectionLetter.A);

        // Assert
        row.PlaceVisitorOnSeat(visitorSeat1);
        row.PlaceVisitorOnSeat(visitorSeat2);

        // Arrange
        Assert.Collection(row.Seats,
            seat => Assert.Equal(seat.SeatedVisitor, visitorSeat1),
            seat => Assert.Equal(seat.SeatedVisitor, visitorSeat2),
            seat => Assert.Null(seat.SeatedVisitor));
    }

    [Fact]
    public void When_OneVisitorIsPlacedInRow_OneLessFreeSeat()
    {
        // Arrange
        Event event1 = new Event(new DateTime(2014, 1, 10), 5);
        Visitor visitor = new(new DateTime(2014, 1, 10), "DSG", event1);
        Row row = new(1, SectionLetterEnum.SectionLetter.A);

        // Act
        row.PlaceVisitorOnSeat(visitor);
        int FreeSeatsLeft = row.TotalSeatsFree();

        // Assert
        Assert.Equal(2, FreeSeatsLeft);
    }

    [Fact]
    public void When_CheckingForFrontRowSeats_OnlyRowOneHasFrontRowSeats()
    {
        Row row1 = new(1, SectionLetterEnum.SectionLetter.A);
        Row row2 = new(2, SectionLetterEnum.SectionLetter.A);
        Row row3 = new(3, SectionLetterEnum.SectionLetter.A);

        int FreeFrontSeatsRow1 = row1.FrontRowSeatsLeft();
        int FreeFrontSeatsRow2 = row2.FrontRowSeatsLeft();

        Assert.NotEqual(FreeFrontSeatsRow1, FreeFrontSeatsRow2);
        Assert.Equal(3, FreeFrontSeatsRow1);
    }
}
