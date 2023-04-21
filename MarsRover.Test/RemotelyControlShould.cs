using FluentAssertions;
using MarsRover.App;

namespace MarsRover.Test
{
    public class RemotelyControlShould
    {
        private RemotelyControl _remotelyControl;

        [SetUp]
        public void Setup()
        {
            _remotelyControl = new RemotelyControl();
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
            Command[] givenCommand = { Command.F };
            var result = _remotelyControl.Move(givenCommand);

            result.Should().BeEquivalentTo(new Position(1,0));
        }

        [Test]
        public void MoveOneStepRoverBackwardWhenStayInInitialPosition()
        {
            Command[] givenCommand = { Command.B };
            var result = _remotelyControl.Move(givenCommand);

            result.Should().BeEquivalentTo(new Position(1,2));
        }

        [Test]
        public void MoveTwoStepsRoverBackwardWhenStayInInitialPosition()
        {
            Command[] givenCommand = { Command.B , Command.B };
            var result = _remotelyControl.Move(givenCommand);

            result.Should().BeEquivalentTo(new Position(1, 3));
        }

        [Test]
        public void RotateLeftRoverWhenStayInInitialOrientation()
        {
            var result = RemotelyControl.Rotate("L");

            result.Should().Be("West");
        }
    }
}