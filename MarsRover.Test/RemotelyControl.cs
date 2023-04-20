namespace MarsRover.Test;

public class RemotelyControl
{
    public static string GetInitialPosition()
    {
        return "1,1";
    }

    public static string Move(string s)
    {
        if (s == "F")
        {
            return "1,0";
        }

        return string.Empty;
    }
}