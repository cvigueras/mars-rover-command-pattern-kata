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
            _remotelyControl = new RemotelyControl(Orientation.North, new Position(1,1));
        }

        [Test]
        public void PlaceRoverInInitialPosition()
        {
            var result = _remotelyControl.Position;
            
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
        public void MoveThreeStepsRoverBackwardWhenStayInInitialPosition()
        {
            Command[] givenCommand = { Command.B , Command.B, Command.B };
            var result = _remotelyControl.Move(givenCommand);

            result.Should().BeEquivalentTo(new Position(1, 4));
        }

        [Test]
        public void RotateLeftRoverWhenStayInInitialOrientation()
        {
            Command[] givenCommand = { Command.L };
            var result = _remotelyControl.Turn(givenCommand);

            result.Should().Be(Orientation.West);
        }

        [Test]
        public void RotateRightRoverWhenStayInInitialOrientation()
        {
            Command[] givenCommand = { Command.R };
            var result = _remotelyControl.Turn(givenCommand);

            result.Should().Be(Orientation.East);
        }

        [Test]
        public void RotateRightRoverWhenStayInCurrentOrientation()
        {
            Command[] firstCommand = { Command.R };
            _remotelyControl.Turn(firstCommand);
            Command[] secondCommand = { Command.L };

            var result = _remotelyControl.Turn(secondCommand);

            result.Should().Be(Orientation.North);
        }

        [Test]
        public void RotateLeftRoverWhenStayInNorth()
        {
            Command[] secondCommand = { Command.L };

            var result = _remotelyControl.Turn(secondCommand);

            result.Should().Be(Orientation.West);
        }

        [Test]
        public void RotateRightRoverWhenStayInWest()
        {
            _remotelyControl = new RemotelyControl(Orientation.West, new Position(1, 1));
            Command[] secondCommand = { Command.R };

            var result = _remotelyControl.Turn(secondCommand);

            result.Should().Be(Orientation.North);
        }

        [Test]
        public void RotateLeftRoverWhenStayInSouth()
        {
            _remotelyControl = new RemotelyControl(Orientation.South, new Position(1, 1));
            Command[] secondCommand = { Command.L };

            var result = _remotelyControl.Turn(secondCommand);

            result.Should().Be(Orientation.East);
        }
    }
}