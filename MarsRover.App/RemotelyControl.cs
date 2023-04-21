namespace MarsRover.App;

public class RemotelyControl
{
    private Orientation _orientation;
    public Position Position;

    public RemotelyControl(Orientation orientation, Position position)
    {
        Position = position;
        _orientation = orientation;
    }

    public Position Move(Command[] givenCommand)
    {
        foreach (var command in givenCommand)
        {
            if (command == Command.F)
                Position = new Position(Position.X, Position.Y - 1);
            if (command == Command.B)
                Position = new Position(Position.X, Position.Y + 1);
        }
        return Position;
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