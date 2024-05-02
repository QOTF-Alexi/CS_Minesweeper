public class Mine : Space
{
    private string _state;
    public string State
    {
        get => _state;
        private set
        {
            if (value is "Armed" or "Flagged" or "Questioned" or "Exploded")
            {
                _state = value;
            }
        }
    }

    public Mine() : base(0)
    {
        State = "Armed";
    }

    /// <summary>
    ///  Changes the state of the space.
    /// </summary>
    /// <param name="newState"></param>
    /// <returns>true when it is a safe move, false when it explodes.</returns>
    public override bool ChangeState(string newState)
    {
        if (newState == "Clicked")
        {
            State = "Exploded";
            return false;
        }
        if (State is "Armed" or "Flagged" or "Questioned")
        {
            State = newState;
        }

        if (newState == "Flagged")
        {
            Program.ClearedMines++;
        }
        return true;
    }
}