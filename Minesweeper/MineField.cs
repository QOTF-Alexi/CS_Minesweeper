public class MineField
{
    private int HorizontalSize { get; }
    private int VerticalSize { get; }
    public int MineCount { get; }
    private bool _isInitialised = false;

    private readonly Space[,] _mineField;

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
        /*
         * for loop through all elements in 2D array
         * if position is already of type Mine or Space, skip it
         * else make it a new Space object.
         * set Space's NumOfMines accordingly, default should be 0 and NotClicked value should be 0 too
         */
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