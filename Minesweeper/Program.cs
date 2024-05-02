public class Program
{
    public static int ClearedMines { get; set; } = 0;

    public static void Main(string[] args)
    {
        Console.Title = "Minesweeper V1 by QOTF-Alexi";
        Console.Write("Please enter the desired size in the format (WIDTH, HEIGHT): ");
        var dimensions = Console.ReadLine().Split(',');
        Console.Write("How many mines would you like? ");
        var strNumMines = Console.ReadLine();
        int width = Convert.ToInt32(dimensions[0]);
        int height = Convert.ToInt32(dimensions[1]);
        int numMines = Convert.ToInt32(strNumMines);
        Console.WriteLine("Your minefield:");
        for (int header = 1; header <= width; header++)
        {
            Console.Write($"    {header}");
        }
        Console.Write("\n");
        
        for (int h = 1; h <= height; h++)
        {
            Console.Write($"{h} ");
            for (int w = 1; w <= width; w++)
            {
                Console.Write($" 999 ");
            }

            Console.Write("\n");
        }

        Console.Write("Which field would you like to sweep first? ");
        var strFirstSweep = Console.ReadLine().Split(',');
        int[] firstSweep = { Convert.ToInt32(strFirstSweep[0]) - 1, Convert.ToInt32(strFirstSweep[1]) - 1 };
        var mineField = new MineField(width, height, numMines, firstSweep);
        bool running = true;
        while (running && ClearedMines != mineField.MineCount)
        {
            mineField.PrintField();
            Console.Write("Select a field: ");
            var selectedField = Console.ReadLine().Split(',');
            int[] sweep = { Convert.ToInt32(selectedField[0]), Convert.ToInt32(selectedField[1]) };
            Console.Write("What do you want the field to become (Questioned, Flagged, Clicked)? ");
            var newState = Console.ReadLine();
            running = mineField.SelectSpace(sweep[0], sweep[1], newState);
            Console.WriteLine(running ? $"Space state changed to {newState}" : "Mine!");
        }

        if (ClearedMines == mineField.MineCount)
        {
            Console.WriteLine("You disarmed all mines and won!");
        }
    }
}