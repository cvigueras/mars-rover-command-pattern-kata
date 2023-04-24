namespace MarsRover.App
{
    public class RemoteInvoker
    {
        private readonly TurnRight _turnRight;
        private readonly TurnLeft _turnLeft;
        private readonly MoveForward _moveForward;
        private readonly MoveBackward _moveBackward;

        public RemoteInvoker(Orientation orientation, Position position)
        {
            RemoteReceiver = new RemoteReceiver(orientation, position);
            _turnRight = new TurnRight(this);
            _turnLeft = new TurnLeft(this);
            _moveForward = new MoveForward(this);
            _moveBackward = new MoveBackward(this);
        }

        public RemoteReceiver RemoteReceiver { get; }

        public void Execute(Command[] commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case Command.R:
                        _turnRight.Execute();
                        break;
                    case Command.L:
                        _turnLeft.Execute();
                        break;
                    case Command.F:
                        _moveForward.Execute();
                        break;
                    case Command.B:
                        _moveBackward.Execute();
                        break;
                }
            }
        }
    }

    public class MoveBackward
    {
        private readonly RemoteInvoker _remoteInvoker;

        public MoveBackward(RemoteInvoker remoteInvoker)
        {
            _remoteInvoker = remoteInvoker;
        }

        public void Execute()
        {
            _remoteInvoker.RemoteReceiver.MoveBackward();
        }
    }
}