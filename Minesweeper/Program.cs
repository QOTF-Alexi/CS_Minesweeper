public class Program
{
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
        for (int h = 1; h <= height; h++)
        {
            for (int w = 1; w <= width; w++)
            {
                Console.Write($" {w},{h} ");
            }

            Console.Write("\n");
        }

        Console.Write("Which field would you like to sweep first? ");
        var strFirstSweep = Console.ReadLine().Split(',');
        int[] firstSweep = { Convert.ToInt32(strFirstSweep[0]), Convert.ToInt32(strFirstSweep[1]) };
        var mineField = new MineField(width, height, numMines, firstSweep);
    }
}