namespace MarsRover.App
{
    public class CurrentGame
    {
        public Planet Planet;
        private readonly RemoteInvoker _remoteInvoker;

        public CurrentGame()
        {
            Planet = new Planet();
            _remoteInvoker = new RemoteInvoker(Orientation.North, new Position(1, 1));
            Planet.SetInitialValue();
        }

        public void ResetPlanet()
        {
            Planet = new Planet();
        }

        public void ExecuteCommand(string[] commands)
        {
            Command[] commandsMove = { };
            foreach (var command in commands)
            {
                if (command == "R")
                {
                    _remoteInvoker.Execute(Command.R);
                }
                if (command == "L")
                {
                    _remoteInvoker.Execute(Command.L);
                }
                if (command == "F")
                {
                    _remoteInvoker.Execute(Command.F);
                }

                if (command == "B")
                {
                    commandsMove = commandsMove.Concat(new[] { Command.B }).ToArray();
                }
            }

            if (commandsMove.Length > 0)
            {
                _remoteInvoker.RemoteReceiver.Move(commandsMove);
            }
            ResetPlanet();
            Planet.Value[_remoteInvoker.RemoteReceiver.Position.X, _remoteInvoker.RemoteReceiver.Position.Y] =
                Planet.GetCurrentUnicodeOrientation(_remoteInvoker.RemoteReceiver.Orientation);
        }
    }
}