namespace MarsRover.App;

public class RemotelyControl
{
    private Position _currentPosition;
    private Orientation _orientation;

    public RemotelyControl()
    {
        _currentPosition = new Position(1, 1);
        _orientation = Orientation.North;
    }

    public Position GetInitialPosition()
    {
        return _currentPosition;
    }

    public Position Move(Command[] givenCommand)
    {
        foreach (var command in givenCommand)
        {
            _currentPosition = command switch
            {
                Command.F => new Position(_currentPosition.X, _currentPosition.Y - 1),
                Command.B => new Position(_currentPosition.X, _currentPosition.Y + 1),
                _ => _currentPosition
            };
        }

        return _currentPosition;
    }

    public Orientation Turn(Command[] givenCommand)
    {
        if (givenCommand[0] == Command.L)
        {
            return Orientation.West;
        }
        return Orientation.East;
    }
}