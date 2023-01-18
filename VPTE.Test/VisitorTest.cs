using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor_Placement_Tools_For_Events;

namespace VPTE.Test;

public class VisitorTest
{
    [Fact]
    public void When_VisitorIsBornWithinTwelveYearsOfEvent_FlaggedAsChild()
    {
        // Arrange
        Event event1 = new Event(new DateTime(2022, 1, 10), 10);
        Visitor visitor = new(new DateTime(2012, 1, 10), "Adult1", event1);

        // Act
        bool answer = visitor.Ischild;

        // Assert
        Assert.True(answer);
    }
}
