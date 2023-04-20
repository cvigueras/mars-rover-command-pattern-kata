namespace MarsRover.App;

public class RemotelyControl
{
    private Position _initialPosition;

    public RemotelyControl()
    {
        _initialPosition = new Position(1, 1);
    }

    public Position GetInitialPosition()
    {
        return _initialPosition;
    }

    public Position Move(Command[] givenCommand)
    {
        foreach (var command in givenCommand)
        {
            if (command == Command.F)
            {
                _initialPosition = new Position(_initialPosition.X, _initialPosition.Y - 1);
            }

            if (command == Command.B)
            {
                _initialPosition = new Position(_initialPosition.X, _initialPosition.Y + 1);
            }
        }

        return _initialPosition;
    }
}