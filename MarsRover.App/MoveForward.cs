namespace MarsRover.App;

public class MoveForward : ICommand
{
    private readonly RemoteInvoker _remoteInvoker;

    public MoveForward(RemoteInvoker remoteInvoker)
    {
        _remoteInvoker = remoteInvoker;
    }

    public void Execute()
    {
        _remoteInvoker.RemoteReceiver.MoveForward();
    }
}