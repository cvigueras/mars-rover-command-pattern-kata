using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions;

namespace MarsRover.Test;

public class RemotelyControl
{
    private Position _initialPosition;

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
        var position = _initialPosition;
        foreach (var command in givenCommand)
        {
            if (command == "F")
            {
                _initialPosition = new Position(_initialPosition.X, _initialPosition.Y - 1);
            }

            if (command == "B")
            {
                _initialPosition = new Position(_initialPosition.X, _initialPosition.Y + 1);
            }
        }

        return _initialPosition;
    }
}