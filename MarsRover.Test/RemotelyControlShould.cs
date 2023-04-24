using FluentAssertions;
using MarsRover.App;

namespace MarsRover.Test
{
    public class RemotelyControlShould
    {
        private RemoteInvoker _remoteInvoker;
        private RemoteReceiver _remoteReceiver;

        [SetUp]
        public void Setup()
        {
            _remoteInvoker = new RemoteInvoker(Orientation.North, new Position(1,1));
            _remoteReceiver = new RemoteReceiver(Orientation.North, new Position(1,1));
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
            _remoteInvoker.Execute(Command.F);

            var result = _remoteInvoker.RemoteReceiver.Position;

            result.Should().BeEquivalentTo(new Position(1,0));
        }

        [Test]
        public void MoveOneStepRoverBackwardWhenStayInInitialPosition()
        {
            Command[] givenCommand = { Command.B };
            var result = _remoteReceiver.Move(givenCommand);

            result.Should().BeEquivalentTo(new Position(1,2));
        }

        [Test]
        public void MoveTwoStepsRoverBackwardWhenStayInInitialPosition()
        {
            Command[] givenCommand = { Command.B , Command.B };
            var result = _remoteReceiver.Move(givenCommand);

            result.Should().BeEquivalentTo(new Position(1, 3));
        }

        [Test]
        public void MoveThreeStepsRoverBackwardWhenStayInInitialPosition()
        {
            Command[] givenCommand = { Command.B , Command.B, Command.B };
            var result = _remoteReceiver.Move(givenCommand);

            result.Should().BeEquivalentTo(new Position(1, 4));
        }

        [Test]
        public void RotateLeftRoverWhenLookToInitialOrientation()
        {
            _remoteInvoker.Execute(Command.L);

            var result = _remoteInvoker.RemoteReceiver.Orientation;

            result.Should().Be(Orientation.West);
        }

        [Test]
        public void RotateRightRoverWhenLookToInitialOrientation()
        {
            _remoteInvoker.Execute(Command.R);

            var result = _remoteInvoker.RemoteReceiver.Orientation;

            result.Should().Be(Orientation.East);
        }

        [Test]
        public void RotateLeftRoverWhenLookToCurrentOrientation()
        {
            _remoteInvoker.Execute(Command.R);
            _remoteInvoker.Execute(Command.L);

            var result = _remoteInvoker.RemoteReceiver.Orientation;

            result.Should().Be(Orientation.North);
        }

        [Test]
        public void RotateLeftRoverWhenLookToNorth()
        {
            _remoteInvoker.Execute(Command.L);

            var result = _remoteInvoker.RemoteReceiver.Orientation;

            result.Should().Be(Orientation.West);
        }

        [Test]
        public void RotateRightRoverWhenLookToWest()
        {
            _remoteInvoker = new RemoteInvoker(Orientation.West, new Position(1, 1));
            _remoteInvoker.Execute(Command.R);

            var result = _remoteInvoker.RemoteReceiver.Orientation;

            result.Should().Be(Orientation.North);
        }

        [Test]
        public void RotateLeftRoverWhenLookToSouth()
        {
            _remoteInvoker = new RemoteInvoker(Orientation.South, new Position(1, 1));
            _remoteInvoker.Execute(Command.L);

            var result = _remoteInvoker.RemoteReceiver.Orientation;

            result.Should().Be(Orientation.East);
        }

        [Test]
        public void MoveTwoStepsRoverForwardWhenLookToSouthAndInitialPosition()
        {
            _remoteInvoker.RemoteReceiver.Orientation = Orientation.South;
            _remoteInvoker.Execute(Command.F);
            _remoteInvoker.Execute(Command.F);

            var result = _remoteInvoker.RemoteReceiver.Position;

            result.Should().BeEquivalentTo(new Position(1, 3));
        }

        [Test]
        public void MoveOneStepRoverBackwardWhenLookToSouthAndInitialPosition()
        {
            _remoteReceiver.Orientation = Orientation.South;
            Command[] givenCommand = { Command.B };

            var result = _remoteReceiver.Move(givenCommand);

            result.Should().BeEquivalentTo(new Position(1, 0));
        }

        [Test]
        public void MoveThreeStepsRoverForwardWhenLookToEastAndInitialPosition()
        {
            _remoteInvoker.RemoteReceiver.Orientation = Orientation.East;
            _remoteInvoker.Execute(Command.F);
            _remoteInvoker.Execute(Command.F);
            _remoteInvoker.Execute(Command.F);

            var result = _remoteInvoker.RemoteReceiver.Position;

            result.Should().BeEquivalentTo(new Position(4, 1));
        }

        [Test]
        public void MoveOneStepRoverBackwardWhenLookToEastAndInitialPosition()
        {
            _remoteReceiver.Orientation = Orientation.East;
            Command[] givenCommand = { Command.B };

            var result = _remoteReceiver.Move(givenCommand);

            result.Should().BeEquivalentTo(new Position(0, 1));
        }

        [Test]
        public void MoveOneStepRoverForwardWhenLookToWestAndInitialPosition()
        {
            _remoteInvoker.RemoteReceiver.Orientation = Orientation.West;
            _remoteInvoker.Execute(Command.F);

            var result = _remoteInvoker.RemoteReceiver.Position;

            result.Should().BeEquivalentTo(new Position(0, 1));
        }

        [Test]
        public void MoveFourStepsRoverBackwardWhenLookToWestAndInitialPosition()
        {
            _remoteReceiver.Orientation = Orientation.West;
            Command[] givenCommand = { Command.B, Command.B, Command.B, Command.B, };

            var result = _remoteReceiver.Move(givenCommand);

            result.Should().BeEquivalentTo(new Position(5, 1));
        }
    }
}