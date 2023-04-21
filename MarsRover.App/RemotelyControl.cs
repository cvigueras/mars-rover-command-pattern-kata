namespace MarsRover.App;

public class RemotelyControl
{
    private Position _currentPosition;
    public Orientation _orientation;

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
            if (command == Command.F)
                _currentPosition = new Position(_currentPosition.X, _currentPosition.Y - 1);
            if (command == Command.B)
                _currentPosition = new Position(_currentPosition.X, _currentPosition.Y + 1);
        }
        return _currentPosition;
    }

    public Orientation Turn(Command[] givenCommand)
    {
        switch (givenCommand[0])
        {
            case Command.R:
                _orientation += 1;
                break;
            default:
                _orientation -= 1;
                break;
        }
        if (_orientation > Orientation.West)
        {
            _orientation = Orientation.North;
        }
        if (_orientation <= Orientation.None)
        {
            _orientation = Orientation.West;
        }
        return _orientation;
    }
}