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

    public override string GetDisplay()
    {
        return $"Fixed Expense {base.GetDisplay()}\n{base.GetValue()}, from {_startDate.ToString("MM/dd/yyyy")} to {_endDate.ToString("MM/dd/yyyy")}";
    }


    // Public Setters
    public override void SetStartDate(DateTime startDate)
    {
        _startDate = startDate;
    }

    public override void SetEndDate(DateTime endDate)
    {
        _endDate = endDate;
    }

    // Serializer
    public override string Serialize()
    {
        return $"FixedExpense,{base.GetName()},{base.GetDescription()},{base.GetValue()},{_startDate},{_endDate}";
    }

    public override void SetDate(DateTime date)
    {
        return;
    }
}