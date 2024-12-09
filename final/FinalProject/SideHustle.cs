public class SideHustlle : Income
{   
    private DateTime _date;

    // Constructor
    public SideHustlle(float value, string name, string description, DateTime date) : base(value, name, description)
    {
        _date = date;
    }

    // Public Getters
    public DateTime GetDate()
    {
        return _date;
    }

    // Public Setters
    public void SetDate(DateTime date)
    {
        _date = date;
    }
}