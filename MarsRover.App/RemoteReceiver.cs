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

    public void TurnRight()
    {
        Orientation += 1;
        Orientation = Orientation > Orientation.West ? Orientation.North : Orientation;
    }

    public void TurnLeft()
    {
        Orientation -= 1;
        Orientation = Orientation <= Orientation.None ? Orientation.West : Orientation;
    }

    public void MoveForward()
    {
        Position = Orientation switch
        {
            Orientation.North => new Position(Position.X, Position.Y - 1),
            Orientation.South => new Position(Position.X, Position.Y + 1),
            Orientation.East => new Position(Position.X + 1, Position.Y),
            Orientation.West => new Position(Position.X - 1, Position.Y),
            _ => Position
        };
    }

    public void MoveBackward()
    {
        Position = Orientation switch
        {
            Orientation.North => new Position(Position.X, Position.Y + 1),
            Orientation.South => new Position(Position.X, Position.Y - 1),
            Orientation.East => new Position(Position.X - 1, Position.Y),
            Orientation.West => new Position(Position.X + 1, Position.Y),
            _ => Position
        };
    }
}