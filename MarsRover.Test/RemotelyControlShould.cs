using FluentAssertions;

namespace MarsRover.Test
{
    public class RemotelyControlShould
    {
        private RemotelyControl _remotelyControl;
        [SetUp]
        public void Setup()
        {
            _remotelyControl = new RemotelyControl(new Position(1,1));
        }

        [Test]
        public void PlaceRoverInInitialPosition()
        {
            var result = _remotelyControl.GetInitialPosition();
            
            result.Should().BeEquivalentTo(new Position(1,1));
        }

        [Test]
        public void MoveOneStepRoverForwardWhenStayInInitialPosition()
        {
            var result = _remotelyControl.Move("F");

            result.Should().Be("1,0");
        }

        [Test]
        public void MoveOneStepRoverBackwardWhenStayInInitialPosition()
        {
            var result = _remotelyControl.Move("B");

            result.Should().Be("1,2");
        }
    }
}