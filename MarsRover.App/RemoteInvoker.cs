namespace MarsRover.App
{
    public class RemoteInvoker
    {
        private readonly TurnRight _turnRight;
        private readonly TurnLeft _turnLeft;
        private readonly MoveForward _moveForward;

        public RemoteInvoker(Orientation orientation, Position position)
        {
            RemoteReceiver = new RemoteReceiver(orientation, position);
            _turnRight = new TurnRight(this);
            _turnLeft = new TurnLeft(this);
            _moveForward = new MoveForward(this);
        }

        public RemoteReceiver RemoteReceiver { get; }

        public void Execute(Command command)
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
            }
        }
    }
}
