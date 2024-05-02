public class MineField
{
    private int HorizontalSize { get; }
    private int VerticalSize { get; }
    public int MineCount { get; }
    private bool _isInitialised = false;

    public Space[,] _mineField { get; private set; }

    public MineField(int horizontalSize, int verticalSize, int mineCount)
    {
        HorizontalSize = horizontalSize;
        VerticalSize = verticalSize;
        MineCount = mineCount;
        _mineField = new Space[HorizontalSize, VerticalSize];
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
            if (_mineField[ranH, ranV].GetType() != typeof(Mine) && _mineField[ranH, ranV].GetType() != typeof(Space))
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
                if (_mineField[i, j].GetType() == typeof(Space) || _mineField[i,j].GetType() == typeof(Space))
                {

                }
                else
                {
                    _mineField[i, j] = new Space(CalculateMines(i, j));
                }
            }
        }
    }

    private int CalculateMines(int x, int y)
    {
        int counter = 0;
        if (_mineField[x-1,y+1].GetType() == typeof(Mine))
        {
            counter += 1;
        }
        if (_mineField[x-1,y].GetType() == typeof(Mine))
        {
            counter += 1;
        }
        if (_mineField[x-1,y-1].GetType() == typeof(Mine))
        {
            counter += 1;
        }
        if (_mineField[x,y+1].GetType() == typeof(Mine))
        {
            counter += 1;
        }
        if (_mineField[x,y-1].GetType() == typeof(Mine))
        {
            counter += 1;
        }
        if (_mineField[x+1,y+1].GetType() == typeof(Mine))
        {
            counter += 1;
        }
        if (_mineField[x+1,y].GetType() == typeof(Mine))
        {
            counter += 1;
        }
        if (_mineField[x+1,y-1].GetType() == typeof(Mine))
        {
            counter += 1;
        }

        return counter;
    }

    public string SelectSpace(int posH, int posV, string newState)
    {
        if (!_isInitialised)
        {
            _mineField[posH, posV] = new Space("Clicked");
            PlaceMines();
            PlaceSpaces();
            _isInitialised = true;
        }
        var isSafe = _mineField[posH - 1, posV - 1].ChangeState(newState);
        return isSafe ? $"Space state changed to {newState}" : "Mine!";
    }
}