public class Investment : Expense
{
    private DateTime _startDate;
    private DateTime _endDate;
    private float _interestRate;
    private float _checkOutValue;


    // Constructor
    public Investment(float value, string name, string description, DateTime startDate, float rate) : base(value, name, description)
    {
        _startDate = startDate;
        _endDate = startDate.AddYears(1);
        _interestRate = rate;
        _checkOutValue = value * (float)Math.Pow((float)Math.E,_interestRate);
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

    public float GetMonthlyPayment()
    {
        return _monthlyPayment;
    }

    public float GetRate()
    {
        return _interestRate;
    }

    public float GetCheckOutValue()
    {
        return _checkOutValue;
    }

    public List<VariableExpense> GetAdditionalPayments()
    {
        return _additionalPayments;
    }

    public override string GetDisplay()
    {
        string h_value = GetCheckOutValue().ToString("0.00");
        string i_value = base.GetValue().ToString("0.00");
        string start_d = _startDate.ToString("MM/dd/yyyy");
        string end_d = _endDate.ToString("MM/dd/yyyy");
        return $"Investment {base.GetDisplay()}\nStarting value: {i_value}, on {start_d}\nFinal value: {h_value}, on {end_d}";
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

    public void SetInterestRate(float rate)
    {
        _interestRate = rate;
    }

}