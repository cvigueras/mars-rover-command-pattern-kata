namespace MarsRover.App;

public class RemoteReceiver
{
    public Orientation Orientation;
    public Position Position;
    public Planet Planet;

    public RemoteReceiver(Orientation orientation, Position position)
    {
        Position = position;
        Orientation = orientation;
        Planet = new Planet();
    }

    public Position Move(Command[] givenCommand)
    {
        var backWard = givenCommand.Where(b => b.Equals(Command.B)).ToList();
        var forWard = givenCommand.Where(f => f.Equals(Command.F)).ToList();
        switch (Orientation)
        {
            case Orientation.North:
                Position.Y -= forWard.Count;
                Position.Y += backWard.Count;
                break;
            case Orientation.South:
                Position.Y += forWard.Count;
                Position.Y -= backWard.Count;
                break;
            case Orientation.East:
                Position.X += forWard.Count;
                Position.X -= backWard.Count;
                break;
            case Orientation.West:
                Position.X -= forWard.Count;
                Position.X += backWard.Count;
                break;
            case Orientation.None:
                break;
            default:
                throw new ArgumentOutOfRangeException("Not valid argument");
        }

        Planet.CheckPosition(Position);
        return Position;
    }

    public Orientation TurnRight()
    {
        Orientation += 1;
        Orientation = Orientation > Orientation.West ? Orientation.North : Orientation;
        return Orientation;
    }

    public Orientation TurnLeft()
    {
        Orientation -= 1;
        Orientation = Orientation <= Orientation.None ? Orientation.West : Orientation;
        return Orientation;
    }
}