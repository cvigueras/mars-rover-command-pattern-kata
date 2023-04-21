namespace MarsRover.App;

public class TurnRight : ICommand
{
    private readonly RemoteInvoker _remoteInvoker;

    public TurnRight(RemoteInvoker remoteInvoker)
    {
        _remoteInvoker = remoteInvoker;
    }

    public void Execute()
    {
        _remoteInvoker.RemoteReceiver.TurnRight();
    }
}