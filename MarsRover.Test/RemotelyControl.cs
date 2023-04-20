namespace MarsRover.Test;

public class RemotelyControl
{
    public static string GetInitialPosition()
    {
        return "1,1";
    }

    public static string Move(string command)
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