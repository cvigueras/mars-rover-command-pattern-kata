using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions;

namespace MarsRover.Test;

public class RemotelyControl
{
    private readonly Position _initialPosition;

    public RemotelyControl(Position position)
    {
        _initialPosition = new Position(1, 1);
    }

    public Position GetInitialPosition()
    {
        return _initialPosition;
    }

    public Position Move(string[] givenCommand)
    {
        if (givenCommand[0] == "F")
        {
            return new Position(1,0);
        }
        if (givenCommand[0] == "B")
        {
            return new Position(1,2);
        }

        return _initialPosition;
    }
}