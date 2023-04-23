using MarsRover.App;

var currentGame = new CurrentGame();
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine(
    "You’re part of the team that explores Mars by sending remotely controlled vehicles to the surface of the planet." +
    "Develop an API that translates the commands sent from earth to instructions that are understood by the rover.");
Console.WriteLine();
Console.WriteLine("Rover starts in Position 1,1 looking at North. Be careful don't fall off the planet");
Console.WriteLine();

while (true)
{
    try
    {
        currentGame.Planet.Print();
        Console.WriteLine();
        Console.Write(
            "Please write a Command or multiple Commands separated for comas: 'L' ==> (To turn Left Rover) 'R' ==> (To turn Right Rover)" +
            "'F' ==> (To move Forward Rover) 'B' ==> (To move Backward Rover): ");
        var command = Console.ReadLine();
        currentGame.ExecuteCommand(command!.ToUpper().Split(","));
        Console.Clear();
    }
    catch (Exception ex)
    {
        Console.Clear();
        Console.WriteLine(ex.Message);
        break;
    }
}