public class FixedExpense : Expense
{
    private DateTime _startDate;
    private DateTime _endDate;
    public FixedExpense(float value, string name, string description, DateTime startDate, DateTime endDate) : base(value, name, description)
    {
        _startDate = startDate;
        _endDate = endDate;
    }

    // Public Getters
    public DateTime GetStartDate()
    {
        return _startDate;
    }

    public DateTime GetEndDate()
    {
        return _endDate;
    }


    // Public Setters
    public void SetStartDate(DateTime startDate)
    {
        _startDate = startDate;
    }

    public void SetEndDate(DateTime endDate)
    {
        _endDate = endDate;
    }
}