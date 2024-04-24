public class MineField
{
    private int _horizontalSize { get; }
    private int _verticalSize { get; }
    public int MineCount { get; }

    private Space[,] _mineField;

    public MineField(int horizontalSize, int verticalSize, int mineCount)
    {
        _horizontalSize = horizontalSize;
        _verticalSize = verticalSize;
        MineCount = mineCount;
        _mineField = new Space[_horizontalSize, _verticalSize];
    }

    public string SelectSpace(int posH, int posV, string newState)
    {
        var isSafe = _mineField[posH - 1, posV - 1].ChangeState(newState);
        return isSafe ? $"Space state changed to {newState}" : "Mine!";
    }
}