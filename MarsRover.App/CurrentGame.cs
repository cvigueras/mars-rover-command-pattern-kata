namespace MarsRover.App
{
    public class CurrentGame
    {
        public Planet Planet;
        private readonly RemoteInvoker _remoteInvoker;
        private readonly Dictionary<string, Command> commandsDict;

        public CurrentGame()
        {
            Planet = new Planet();
            _remoteInvoker = new RemoteInvoker(Orientation.North, new Position(1, 1));
            Planet.SetInitialValue();
            commandsDict = new Dictionary<string, Command>
            {
                {"F",Command.F},
                {"B",Command.B},
                {"L",Command.L},
                {"R",Command.R},
            };
        }

        public void ResetPlanet()
        {
            Planet = new Planet();
        }

        public void ExecuteCommand(string[] commands)
        {
            Command[] executeCommands = { };
            foreach (var command in commands)
            {
                var com = commandsDict.FirstOrDefault(c => c.Key.Equals(command)).Value;
                executeCommands = executeCommands.Append(com).ToArray();
            }
            _remoteInvoker.Execute(executeCommands);

            ResetPlanet();
            Planet.CheckPosition(_remoteInvoker.RemoteReceiver.Position);
            SetPositionInPlanet();
        }

        private void SetPositionInPlanet()
        {
            Planet.Value[_remoteInvoker.RemoteReceiver.Position.X, _remoteInvoker.RemoteReceiver.Position.Y] =
                Planet.GetCurrentUnicodeOrientation(_remoteInvoker.RemoteReceiver.Orientation);
        }
    }
}