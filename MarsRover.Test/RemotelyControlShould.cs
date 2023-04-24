using FluentAssertions;
using MarsRover.App;

namespace MarsRover.Test
{
    public class RemotelyControlShould
    {
        private RemoteInvoker _remoteInvoker;

        [SetUp]
        public void Setup()
        {
            _remoteInvoker = new RemoteInvoker(Orientation.North, new Position(1,1));
        }

        [Test]
        public void PlaceRoverInInitialPosition()
        {
            var result = _remoteInvoker.RemoteReceiver.Position;
            
            result.Should().BeEquivalentTo(new Position(1,1));
        }

        [Test]
        public void MoveOneStepRoverForwardWhenStayInInitialPosition()
        {
            Command[] givenCommands = { Command.F };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Position;

            result.Should().BeEquivalentTo(new Position(1,0));
        }

        [Test]
        public void MoveOneStepRoverBackwardWhenStayInInitialPosition()
        {
            Command[] givenCommands = { Command.B };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Position;

            result.Should().BeEquivalentTo(new Position(1,2));
        }

        [Test]
        public void MoveTwoStepsRoverBackwardWhenStayInInitialPosition()
        {
            Command[] givenCommands = { Command.B, Command.B };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Position;

            result.Should().BeEquivalentTo(new Position(1, 3));
        }

        [Test]
        public void MoveThreeStepsRoverBackwardWhenStayInInitialPosition()
        {
            Command[] givenCommands = { Command.B, Command.B, Command.B };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Position;

            result.Should().BeEquivalentTo(new Position(1, 4));
        }

        [Test]
        public void RotateLeftRoverWhenLookToInitialOrientation()
        {
            Command[] givenCommands = { Command.L };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Orientation;

            result.Should().Be(Orientation.West);
        }

        [Test]
        public void RotateRightRoverWhenLookToInitialOrientation()
        {
            Command[] givenCommands = { Command.R };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Orientation;

            result.Should().Be(Orientation.East);
        }

        [Test]
        public void RotateLeftRoverWhenLookToCurrentOrientation()
        {
            Command[] givenCommands = { Command.R, Command.L };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Orientation;

            result.Should().Be(Orientation.North);
        }

        [Test]
        public void RotateLeftRoverWhenLookToNorth()
        {
            Command[] givenCommands = { Command.L };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Orientation;

            result.Should().Be(Orientation.West);
        }

        [Test]
        public void RotateRightRoverWhenLookToWest()
        {
            _remoteInvoker = new RemoteInvoker(Orientation.West, new Position(1, 1));
            Command[] givenCommands = { Command.R };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Orientation;

            result.Should().Be(Orientation.North);
        }

        [Test]
        public void RotateLeftRoverWhenLookToSouth()
        {
            _remoteInvoker = new RemoteInvoker(Orientation.South, new Position(1, 1));
            Command[] givenCommands = { Command.L };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Orientation;

            result.Should().Be(Orientation.East);
        }

        [Test]
        public void MoveTwoStepsRoverForwardWhenLookToSouthAndInitialPosition()
        {
            _remoteInvoker.RemoteReceiver.Orientation = Orientation.South;
            Command[] givenCommands = { Command.F,Command.F };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Position;

            result.Should().BeEquivalentTo(new Position(1, 3));
        }

        [Test]
        public void MoveOneStepRoverBackwardWhenLookToSouthAndInitialPosition()
        {
            _remoteInvoker.RemoteReceiver.Orientation = Orientation.South;
            Command[] givenCommands = { Command.B };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Position;

            result.Should().BeEquivalentTo(new Position(1, 0));
        }

        [Test]
        public void MoveThreeStepsRoverForwardWhenLookToEastAndInitialPosition()
        {
            _remoteInvoker.RemoteReceiver.Orientation = Orientation.East;
            Command[] givenCommands = { Command.F, Command.F, Command.F };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Position;

            result.Should().BeEquivalentTo(new Position(4, 1));
        }

        [Test]
        public void MoveOneStepRoverBackwardWhenLookToEastAndInitialPosition()
        {
            _remoteInvoker.RemoteReceiver.Orientation = Orientation.East;
            Command[] givenCommands = { Command.B };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Position;

            result.Should().BeEquivalentTo(new Position(0, 1));
        }

        [Test]
        public void MoveOneStepRoverForwardWhenLookToWestAndInitialPosition()
        {
            _remoteInvoker.RemoteReceiver.Orientation = Orientation.West;
            Command[] givenCommands = { Command.F };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Position;

            result.Should().BeEquivalentTo(new Position(0, 1));
        }

        [Test]
        public void MoveFourStepsRoverBackwardWhenLookToWestAndInitialPosition()
        {
            _remoteInvoker.RemoteReceiver.Orientation = Orientation.West;
            Command[] givenCommands = { Command.B, Command.B, Command.B, Command.B };
            _remoteInvoker.Execute(givenCommands);

            var result = _remoteInvoker.RemoteReceiver.Position;

            result.Should().BeEquivalentTo(new Position(5, 1));
        }
    }
}