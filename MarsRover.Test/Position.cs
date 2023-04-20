namespace MarsRover.Test;

public class Position
{
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; private set; }
    public int Y { get; private set; }
}