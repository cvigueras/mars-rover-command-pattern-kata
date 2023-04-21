namespace MarsRover.App
{
    public class TurnLeft : ICommand
    {
        private readonly RemoteInvoker _remoteInvoker;

        public TurnLeft(RemoteInvoker remoteInvoker)
        {
            _remoteInvoker = remoteInvoker;
        }

        public void Execute()
        {
            _remoteInvoker.RemoteReceiver.TurnLeft();
        }
    }
}
