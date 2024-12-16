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

    public override string GetDisplay()
    {
        return $"Variable Expense {base.GetDisplay()}\n{base.GetValue()} - {_date.ToString("MM/dd/yyyy")}";
    }

   
    
    // Serializer
    public override string Serialize()
    {
        return $"VariableExpense,{base.GetName()},{base.GetDescription()},{base.GetValue()},{_date}";
    }

    public override void SetDate(DateTime date)
    {
        _date = date;
    }

    public override void SetEndDate(DateTime endDate)
    {
        return;
    }

    public override void SetStartDate(DateTime startDate)
    {
        return;
    }
}
