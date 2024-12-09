public class VariableExpense : Expense
{
    private DateTime _date;

    // Constructor
    public VariableExpense(float value, string name, string description, DateTime date) : base(value, name, description)
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
