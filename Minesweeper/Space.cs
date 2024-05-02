public class Space
{
    private string _state;
    private string State
    {
        get => _state;
        set
        {
            if (value is "Clicked" or "NotClicked" or "Questioned" or "Flagged")
            {
                _state = value;
            }
        }
    }

    private int _numOfMines;
    public int NumOfMines
    {
        get
        {
            if (State is "Clicked") return _numOfMines;
            return 0;
        }
    }

    public Space(int numOfMines)
    {
        State = "NotClicked";
        
        _numOfMines = numOfMines;
    }

    public Space(string state)
    {
        State = state;
    }

    /// <summary>
    /// Changes the state of the space.
    /// </summary>
    /// <param name="newState"></param>
    /// <returns>Always returns true if the main type is Space.</returns>
    public virtual bool ChangeState(string newState)
    {
        if (State == "NotClicked")
        {
            State = newState;
        }
        return true;
    }
}