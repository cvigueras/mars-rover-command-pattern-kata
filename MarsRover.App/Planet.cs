namespace MarsRover.App
{
    public class Planet
    {
        public string[,] Value;
        public string West = "\u2190";
        public string North = "\u2191";
        public string East = "\u2192";
        public string South = "\u2193";

        public Planet()
        {
            Value = new[,]
            {
                { "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]" },
                { "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]" },
                { "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]" },
                { "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]" },
                { "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]" },
                { "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]" },
                { "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]" },
                { "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]" },
                { "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]" },
                { "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]" }
            };
        }

        private void PrintHeader()
        {
            Console.WriteLine("   ===============================");
            Console.WriteLine("     Welcome to MARS ROVER Game");
            Console.WriteLine("   ===============================");
        }

        public void Print()
        {
            PrintHeader();
            for (var i = 0; i < Value.GetLength(0); i++)
            {
                Console.WriteLine(Environment.NewLine);
                for (var j = 0; j < Value.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Console.Write("            " + Value[j, i]);
                    }
                    else
                    {
                        Console.Write("  " + Value[j, i]);
                    }
                }
            }
            Console.WriteLine();
        }

        public void SetInitialValue()
        {
            Value[1, 1] = $"[{North}]";
        }

        public void CheckPosition(Position position)
        {
            if (position.X < 0 || position.Y < 0 || position.X >= Value.GetLength(0) ||
                position.Y >= Value.GetLength(1))
            {
                throw new Exception("Rover has fallen out the planet and has died.");
            }
        }

        public string GetCurrentUnicodeOrientation(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.North:
                    return $"[{North}]";
                case Orientation.South:
                    return $"[{South}]";
                case Orientation.East:
                    return $"[{East}]";
                case Orientation.West:
                    return $"[{West}]";
                default:
                    throw new Exception("Invalid Orientation");
            }
        }
    }
}
