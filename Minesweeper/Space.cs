public class Space
{
    private string _state;
    public string State
    {
        get => _state;
        set
        {
            if (value == "Clicked" || value == "NotClicked" || value == "Questioned" || value == "Flagged")
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
            if (State is "Questioned") return -1;
            if (State is "Flagged") return -2;
            return 999;
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
    
    public Space(string state, int numOfMines)
    {
        State = state;
        _numOfMines = numOfMines;
    }

    /// <summary>
    /// Changes the state of the space.
    /// </summary>
    /// <param name="newState"></param>
    /// <returns>Always returns true if the main type is Space.</returns>
    public virtual bool ChangeState(string newState)
    {
        if (_state is "NotClicked" or "Flagged" or "Questioned")
        {
            State = newState;
        }
        return true;
    }
}