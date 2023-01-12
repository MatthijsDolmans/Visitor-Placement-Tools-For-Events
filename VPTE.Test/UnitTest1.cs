using Visitor_Placement_Tools_For_Events;
using Visitor_Placement_Tools_For_Events.Enums;

namespace VPTE.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Event event1 = new(DateTime.Now, 4);
            List<Visitor> SignedUp = new();
            SignedUp.Add(new Visitor(new DateTime(2014, 1, 10), "visitor1", event1)); //kind
            SignedUp.Add(new Visitor(new DateTime(2014, 1, 10), "visitor2", event1)); //kind
            SignedUp.Add(new Visitor(new DateTime(2014, 1, 10), "visitor3", event1)); //kind
            SignedUp.Add(new Visitor(new DateTime(2014, 1, 10), "visitor4", event1)); //kind

            Group group1 = new Group(SignedUp);

            //event1.PlaceGroupsWithChildren(group1);
        }

        [Fact]
        public void When_SectionHasEnoughSeats_ReturnTrue()
        {
            // Only works if randomize seats per row is off. 

            // Arrange
            Section section = new(SectionLetterEnum.SectionLetter.A, 3);
            int groupSize = 8;

            // Act
            bool answer = section.IsSpace(groupSize);

            // Assert
            Assert.True(answer);
            
            // Matthijs zou de //ACT in de // ASSERT gooien. 
        }
    }
}