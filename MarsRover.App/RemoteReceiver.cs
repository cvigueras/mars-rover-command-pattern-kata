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