using FluentAssertions;

namespace MarsRover.Test
{
    public class RemotelyControlShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PlaceRoverInInitialPosition()
        {
            var result = RemotelyControl.GetInitialPosition();
            
            result.Should().Be("1,1");
        }

        [Test]
        public void MoveRoverForwardWhenStayInInitialPosition()
        {
            var result = RemotelyControl.Move("F");

            result.Should().Be("1,0");
        }
    }
}