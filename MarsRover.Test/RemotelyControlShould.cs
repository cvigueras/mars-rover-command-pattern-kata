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
        public void MoveOneStepRoverForwardWhenStayInInitialPosition()
        {
            var result = RemotelyControl.Move("F");

            result.Should().Be("1,0");
        }

        [Test]
        public void MoveOneStepRoverBackwardWhenStayInInitialPosition()
        {
            var result = RemotelyControl.Move("B");

            result.Should().Be("1,2");
        }
    }
}