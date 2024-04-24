public class Space
{
    public int ID { get; }
    
    private string _state;
    public string State
    {
        get => _state;
        private set
        {
            if (value is "Clicked" or "NotClicked" or "Questioned" or "Flagged")
            {
                _state = value;
            }
        }
    }

    public string NumOfMines { get; }
    
    public Space(int id)
    {
        ID = id;
        State = "NotClicked";
    }

    /// <summary>
    /// Changes the state of the space.
    /// </summary>
    /// <param name="newState"></param>
    /// <returns>Always returns true.</returns>
    public virtual bool ChangeState(string newState)
    {
        if (State == "NotClicked")
        {
            State = newState;
        }
        return true;
    }
}