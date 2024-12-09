public class Investment : Expense
{
    private DateTime _startDate;
    private DateTime _endDate;
    private float _monthlyPayment;
    private float _interestRate;
    private float _checkOutValue;
    private List<VariableExpense> _additionalPayments;
    
    // Constructor
    public Investment(float value, string name, string description, DateTime startDate, DateTime endDate, float monthlyPayment, float rate) : base(value, name, description)
    {
        _startDate = startDate;
        _endDate = endDate;
        _monthlyPayment = monthlyPayment;
        _interestRate = rate;

        // TODO At creation, the final checkout value should be calculated based on value, rate, and investment duration    6./
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


    // Public Setters
    public void SetStartDate(DateTime startDate)
    {
        _startDate = startDate;
    }

    public void SetEndDate(DateTime endDate)
    {
        _endDate = endDate;
    }

    public void SetMonthlyPayment(float value)
    {
        _monthlyPayment = value;
    }

    public void SetInterestRate(float rate)
    {
        _interestRate = rate;
    }

    public void AddAdditionalPayment(VariableExpense expense)
    {
        _additionalPayments.Add(expense);
        // TODO For every Additional payment, the final check out value should be updated
    }

    private void UpdateCheckOutValue()
    {
        _checkOutValue = base.GetValue();
        foreach(VariableExpense expense in _additionalPayments)
        {
            _checkOutValue += expense.GetValue();
        }

        // TODO: implement calculation to take in account interest rate and duration of investment
    }
}