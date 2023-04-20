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
            string[] givenCommand = { "F" };
            var result = _remotelyControl.Move(givenCommand);

            result.Should().BeEquivalentTo(new Position(1,0));
        }

        [Test]
        public void MoveOneStepRoverBackwardWhenStayInInitialPosition()
        {
            string[] givenCommand = { "B" };
            var result = _remotelyControl.Move(givenCommand);

            result.Should().BeEquivalentTo(new Position(1,2));
        }
    }
}