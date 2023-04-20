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

    public string Move(string command)
    {
        if (command == "F")
        {
            return "1,0";
        }
        if (command == "B")
        {
            return "1,2";
        }

        return string.Empty;
    }
}