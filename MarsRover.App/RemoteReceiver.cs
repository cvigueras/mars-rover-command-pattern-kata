namespace MarsRover.App;

public class RemoteReceiver
{
    public Orientation Orientation;
    public Position Position;

    public RemoteReceiver(Orientation orientation, Position position)
    {
        Position = position;
        Orientation = orientation;
    }

    public Position Move(Command[] givenCommand)
    {
        foreach (var command in givenCommand)
        {
            if (Orientation == Orientation.North)
            {
                if (command == Command.F)
                    Position = new Position(Position.X, Position.Y - 1);
                if (command == Command.B)
                    Position = new Position(Position.X, Position.Y + 1);
            }
            if (Orientation == Orientation.South)
            {
                if (command == Command.F)
                    Position = new Position(Position.X, Position.Y + 1);
                if (command == Command.B)
                    Position = new Position(Position.X, Position.Y - 1);
            }
            if (Orientation == Orientation.East)
            {
                if (command == Command.F)
                    Position = new Position(Position.X + 1, Position.Y);
                if (command == Command.B)
                    Position = new Position(Position.X - 1, Position.Y);
            }
            if (Orientation == Orientation.West)
            {
                if (command == Command.F)
                    Position = new Position(Position.X - 1, Position.Y);
            }
        }
        return Position;
    }

    public Orientation TurnRight()
    {
        Orientation += 1;
        if (Orientation > Orientation.West)
        {
            Orientation = Orientation.North;
        }
        return Orientation;
    }

    public Orientation TurnLeft()
    {
        Orientation -= 1;
        if (Orientation <= Orientation.None)
        {
            Orientation = Orientation.West;
        }
        return Orientation;
    }
}