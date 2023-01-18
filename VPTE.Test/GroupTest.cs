using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor_Placement_Tools_For_Events.Enums;
using Visitor_Placement_Tools_For_Events;

namespace VPTE.Test;

public class GroupTest
{
    [Fact]
    public void When_GroupHasVisitorThatIsChild_GroupIsMarked()
    {
        // Arrange
        Event event1 = new Event(new DateTime(2022, 1, 10), 10);
        Section section = new(SectionLetterEnum.SectionLetter.A, 3);

        List<Visitor> VisitorsGroup1 = new()
        {
            new Visitor(new DateTime(2014, 1, 10), "Child1", event1),
            new Visitor(new DateTime(2001, 1, 10), "Adult1", event1),
        };

        Group group = new Group(VisitorsGroup1.GetRange(0, 2));

        // Act
        bool answer = group.HasChildInGroup();

        // Assert
        Assert.True(answer);
    }

    [Fact]  
    public void When_GroupHasChild_CheckHowManyChildren()
    {
        // Arrange
        Event event1 = new Event(new DateTime(2022, 1, 10), 10);
        Section section = new(SectionLetterEnum.SectionLetter.A, 3);

        List<Visitor> VisitorsGroup1 = new()
        {
            new Visitor(new DateTime(2014, 1, 10), "Child1", event1),
            new Visitor(new DateTime(2014, 1, 10), "Child2", event1),
            new Visitor(new DateTime(2001, 1, 10), "Adult1", event1),
            new Visitor(new DateTime(2001, 1, 10), "Adult2", event1),
        };

        Group group = new Group(VisitorsGroup1.GetRange(0, 2));
    }
}
