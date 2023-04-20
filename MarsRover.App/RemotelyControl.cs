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
            _initialPosition = command switch
            {
                Command.F => new Position(_initialPosition.X, _initialPosition.Y - 1),
                Command.B => new Position(_initialPosition.X, _initialPosition.Y + 1),
                _ => _initialPosition
            };
        }

        return _initialPosition;
    }
}