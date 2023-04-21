namespace MarsRover.App
{
    public class RemoteInvoker
    {
        private readonly RemoteReceiver _remoteReceiver;
        private readonly TurnRight _turnRight;
        private readonly TurnLeft _turnLeft;

        public RemoteInvoker(Orientation orientation, Position position)
        {
            _remoteReceiver = new RemoteReceiver(orientation, position);
            _turnRight = new TurnRight(this);
            _turnLeft = new TurnLeft(this);
        }

        public RemoteReceiver RemoteReceiver => _remoteReceiver;

        public void Execute(Command command)
        {
            if (command == Command.R)
            {
                _turnRight.Execute();
            }
            if (command == Command.L)
            {
                _turnLeft.Execute();
            }
        }
    }
}
