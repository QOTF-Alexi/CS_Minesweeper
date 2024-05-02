public class MineField
{
    private int HorizontalSize { get; }
    private int VerticalSize { get; }
    public int MineCount { get; }
    private int _placedFlags { get; set; }
    private bool _isInitialised = false;

    public Space[,] _mineField { get; private set; }

    public MineField(int horizontalSize, int verticalSize, int mineCount, int[] firstSweep)
    {
        HorizontalSize = horizontalSize;
        VerticalSize = verticalSize;
        MineCount = mineCount;
        _mineField = new Space[HorizontalSize, VerticalSize];
        _mineField[firstSweep[0], firstSweep[1]] = new Space("Clicked"); // required for setup.
        PlaceMines();
        PlaceSpaces();
        _mineField[firstSweep[0], firstSweep[1]] = new Space("Clicked", CalculateMines(firstSweep[0], firstSweep[1])); // re-create with correct mine count
    }

    /// <summary>
    /// Method to place mines inside a field.
    /// </summary>
    private void PlaceMines()
    {
        var rngH = new Random();
        var rngV = new Random();
        int ranH;
        int ranV;
        for (int i = 1; i <= MineCount; i++)
        {
            ranH = rngH.Next(0, HorizontalSize);
            ranV = rngV.Next(0, VerticalSize);
            if (_mineField[ranH, ranV] is null || (_mineField[ranH, ranV].GetType() != typeof(Mine) && _mineField[ranH, ranV].GetType() != typeof(Space)))
            {
                _mineField[ranH, ranV] = new Mine();
            }
            else
            {
                i--;
            }
        }
    }

    /// <summary>
    /// Fills in the blank spots of the minefield.
    /// </summary>
    private void PlaceSpaces()
    {
        for (int i = 0; i < _mineField.GetLength(0); i++) 
        {
            for (int j = 0; j < _mineField.GetLength(1); j++)
            {
                if (_mineField[i, j] is null || (_mineField[i, j].GetType() != typeof(Mine) && _mineField[i, j].GetType() != typeof(Space)))
                {
                    _mineField[i, j] = new Space(CalculateMines(i, j));
                }
            }
        }
    }

    private int CalculateMines(int x, int y)
    {
        int counter = 0;
        int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

        for (int i = 0; i < 8; i++)
        {
            int newX = x + dx[i];
            int newY = y + dy[i];

            if (newX >= 0 && newY >= 0 && newX < HorizontalSize && newY < VerticalSize)
            {
                if (_mineField[newX, newY] is not null && _mineField[newX, newY].GetType() == typeof(Mine))
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    public bool SelectSpace(int posH, int posV, string newState)
    {
        if (newState == "Flagged" && _placedFlags == MineCount)
        {
            Console.WriteLine("Maximum amount of flags has been placed. Remove one!");
            return true;
        }

        if (newState == "Flagged") _placedFlags++;
        if (_mineField[posH, posV].State == "Flagged") _placedFlags--;
        
        return _mineField[posH, posV].ChangeState(newState);
    }

    public void PrintField()
    {
        for (int header = 1; header <= HorizontalSize; header++)
        {
            Console.Write($"    {header}");
        }
        Console.Write("\n");
        
        for (int h = 1; h <= VerticalSize; h++)
        {
            Console.Write($"{h} ");
            for (int w = 1; w <= HorizontalSize; w++)
            {
                Console.Write($" {_mineField[w-1,h-1].NumOfMines} ");
            }

            Console.Write("\n");
        }
    }
}